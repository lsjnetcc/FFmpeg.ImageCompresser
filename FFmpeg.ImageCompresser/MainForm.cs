using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Reflection;
using FFmpeg.ImageCompresser.Properties;

namespace FFmpeg.ImageCompresser
{
	public partial class MainForm : Form
	{
		private static readonly string FFmpegPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ffmpeg.exe");  //FFmpeg压缩软件路径

		//文件格式：图片、视频
		private static readonly List<string> arrExtName_Image_To_Jpg = new List<string> { "jpg", "jpeg", "bmp", "tiff", "psd" };                //扩展名：需转换为Jpg格式的图片类型
		private static readonly List<string> arrExtName_Image_Use_Src = new List<string> { "png", "gif" };                                      //扩展名：需保留源格式的图片类型
		private static readonly List<string> arrExtName_Video_To_Mp4 = new List<string> { "wmv", "mov", "m4v", "avi", "mp4", "mkv", "flv" };    //扩展名：需转换为MP4的视频类型

		//文件格式：图片、视频
		private static readonly List<string> arrExtName_Image = arrExtName_Image_To_Jpg.Union(arrExtName_Image_Use_Src, StringComparer.OrdinalIgnoreCase).ToList();
		private static readonly List<string> arrExtName_Video = arrExtName_Video_To_Mp4.ToList();

		//待处理的文件类型
		private static readonly List<string> CompressFileTypes = arrExtName_Image.Union(arrExtName_Video, StringComparer.OrdinalIgnoreCase).ToList();

		private List<FileCompressItem> arrWaitCompressFiles = new List<FileCompressItem>(); //待压缩的文件
		private string saveFolderPath = string.Empty;                                       //保存文件夹路径
		private int width = 0;      // 缩放后宽度
		private int height = 0;     // 缩放后高度
		private int changeType;     // 缩放类型：1-等比例缩放；2-保留原尺寸

		public MainForm()
		{
			InitializeComponent();
			InitializeApp();

			// 读取版本号
			var version = Assembly.GetExecutingAssembly().GetName().Version;
			StringBuilder ver = new StringBuilder();
			ver.AppendFormat(" v{0}", version.Major);
			ver.AppendFormat(".{0}", version.Minor);
			if (version.Build > 0)
				ver.AppendFormat(".{0}", version.Build);
			if (version.Revision > 0)
				ver.AppendFormat(".{0}", version.Revision);
			this.Text += ver.ToString();
		}

		/// <summary>
		/// 初始化应用程序
		/// </summary>
		private void InitializeApp()
		{
			if (!File.Exists(FFmpegPath))
			{
				Task.Run(() =>
				{
					try
					{
						//File.WriteAllBytes(FFmpegPath, Resources.ffmpeg);
						WriteAllBytes(FFmpegPath, Resources.ffmpeg);
					}
					catch (Exception ex)
					{
						MessageBox.Show("读取资源文件异常：" + ex, "文件压缩");
					}
				});
			}
			SetDoubleBuffering(this.lvFileCompress, true);
			SetDoubleBuffering(this.lvFileCompressResult, true);

			this.gbxChangeSize.Enabled = false;
			this.cmbChangeType.DataSource = new[] { new { KEY = "等比例缩放", VALUE = 1 }, new { KEY = "保留原尺寸", VALUE = 2 } };
			this.cmbChangeType.DisplayMember = "KEY";
			this.cmbChangeType.ValueMember = "VALUE";
		}
		private static void WriteAllBytes(string filePath, byte[] bytes)
		{
			using (MemoryStream inStream = new MemoryStream(bytes))
			{
				using (FileStream outStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
				{
					byte[] buffer = new byte[4096];
					int length;
					while ((length = inStream.Read(buffer, 0, buffer.Length)) > 0)
					{
						outStream.Write(buffer, 0, length);
					}
					outStream.Flush();
				}
			}
		}
		/// <summary>
		/// 选择压缩文件夹
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSelectCompressFolder_Click(object sender, EventArgs e)
		{
			if (DialogResult.OK == this.folderBrowserDialog.ShowDialog())
			{
				this.ResetUI();
				string compressFolderPath = this.folderBrowserDialog.SelectedPath;
				this.txtCompressFolderPath.Text = compressFolderPath;
				this.txtSaveFolderPath.Text = string.Format("{0}_{1}", compressFolderPath, "压缩后");
				this.AddFiles(compressFolderPath);
			}
		}

		/// <summary>
		/// 选择保存文件夹
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSelectSaveFolder_Click(object sender, EventArgs e)
		{
			if (DialogResult.OK == this.folderBrowserDialog.ShowDialog())
			{
				this.txtSaveFolderPath.Text = this.folderBrowserDialog.SelectedPath;
			}
		}

		/// <summary>
		/// 清空
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnClear_Click(object sender, EventArgs e)
		{
			this.ResetUI();
		}

		/// <summary>
		/// 开始压缩
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStartCompress_Click(object sender, EventArgs e)
		{
			this.saveFolderPath = this.txtSaveFolderPath.Text;
			if (this.arrWaitCompressFiles == null || this.arrWaitCompressFiles.Count == 0)
			{
				MessageBox.Show("没有需要压缩的文件。", "文件压缩");
				return;
			}
			if (string.IsNullOrWhiteSpace(this.saveFolderPath))
			{
				MessageBox.Show("请选择压缩文件要保存的目录。", "文件压缩");
				return;
			}
			if (!File.Exists(FFmpegPath))
			{
				MessageBox.Show("未找到压缩软件FFmpeg。", "文件压缩");
				return;
			}
			try
			{
				if (Directory.Exists(this.saveFolderPath))
				{
					Directory.Delete(this.saveFolderPath, true);
				}
			}
			catch (Exception)
			{
				MessageBox.Show("无权限操作压缩文件保存目录");
				return;
			}

			if (this.chkChangeSize.Checked)
			{
				if (int.TryParse(this.txtWidth.Text, out width) == false)
					width = -1;
				if (int.TryParse(this.txtHeight.Text, out height) == false)
					height = -1;

				if (width < 0 && height < 0)
				{
					MessageBox.Show("已选择缩放，请设置“宽度”或“高度”");
					return;
				}

				changeType = (int)this.cmbChangeType.SelectedValue;
			}

			this.lvFileCompressResult.Items.Clear();
			this.lblSuccessCount.Text = this.lblFailCount.Text = "0";

			Task.Run(() => { this.CompressFiles(); });
		}

		/// <summary>
		/// 压缩文件
		/// </summary>
		private void CompressFiles()
		{
			List<Button> enableBtns = new List<Button>() { this.btnStartCompress, this.btnClear };

			this.EnableButton(enableBtns, false);

			foreach (var waitCompressFile in this.arrWaitCompressFiles)
			{
				if (!File.Exists(waitCompressFile.FileName))
				{
					continue;
				}
				FileInfo waitCompressFileInfo = new FileInfo(waitCompressFile.FileName);
				FileCompressResult result = new FileCompressResult(waitCompressFile.FileName, waitCompressFileInfo.Length);
				try
				{
					string relativeFileName = waitCompressFile.FileName.Substring(waitCompressFile.DirectoryName.TrimEnd('\\').Length + 1);
					string saveFileName = Path.Combine(this.saveFolderPath, relativeFileName);
					string extensionName = Path.GetExtension(saveFileName).TrimStart('.');

					string extensionNameNew = extensionName;
					if (arrExtName_Image_To_Jpg.Contains(extensionName, StringComparer.OrdinalIgnoreCase))
					{
						extensionNameNew = "jpg";
					}
					else if (arrExtName_Video_To_Mp4.Contains(extensionName, StringComparer.OrdinalIgnoreCase))
					{
						extensionNameNew = "mp4";
					}
					saveFileName = Path.Combine(Path.GetDirectoryName(saveFileName), Path.GetFileNameWithoutExtension(saveFileName) + "." + extensionNameNew);
					string saveDirPath = Path.GetDirectoryName(saveFileName);
					if (!Directory.Exists(saveDirPath))
					{
						Directory.CreateDirectory(saveDirPath);
					}
					result.FileName_After = saveFileName;

					this.WriteMessage(string.Format("正在压缩文件:{0}", waitCompressFileInfo.Name));
					bool compressSuccessed;
					if (width > 0 || height > 0)
					{
						// 需要缩放压缩
						if (width <= 0 || height <= 0)
						{
							Image img = Image.FromFile(waitCompressFile.FileName);
							if (width <= 0)
							{
								if (changeType == 1)
									width = img.Width * height / img.Height;
								else
									width = img.Width;
							}
							if (height <= 0)
							{
								if (changeType == 1)
									height = img.Height * width / img.Width;
								else
									height = img.Height;
							}
						}
						compressSuccessed = FFmpegHelper.CompressFile(FFmpegPath, width, height, waitCompressFile.FileName, saveFileName);
					}
					else
						compressSuccessed = FFmpegHelper.CompressFile(FFmpegPath, waitCompressFile.FileName, saveFileName);

					result.Success = compressSuccessed && File.Exists(saveFileName);
					if (result.Success)
					{
						result.FileSize_After = new FileInfo(saveFileName).Length;
					}
					this.WriteResult(result);
				}
				catch (Exception ex)
				{
					result.Success = false;
					result.ResultMessage = "处理时发生异常：" + ex.Message;
					this.WriteResult(result);
				}
			}
			this.WriteMessage("压缩完成");

			this.EnableButton(enableBtns, true);
		}

		/// <summary>
		/// 添加指定目录文件
		/// </summary>
		/// <param name="dirPath">指定文件夹</param>
		private void AddFiles(string dirPath)
		{
			List<FileCompressItem> arrCompressFiles = this.GetCompressFiles(dirPath);
			this.AddFiles(arrCompressFiles);
		}

		/// <summary>
		/// 添加文件
		/// </summary>
		/// <param name="arrCompressFiles">压缩文件集合</param>
		private void AddFiles(List<FileCompressItem> arrCompressFiles)
		{
			if (arrCompressFiles == null || arrCompressFiles.Count == 0)
			{
				return;
			}

			int waitCompressFileCount = 0;
			foreach (var compressFile in arrCompressFiles)
			{
				if (File.Exists(compressFile.FileName))
				{
					this.arrWaitCompressFiles.Add(compressFile);

					ListViewItem lvItem = new ListViewItem(compressFile.FileName);
					lvItem.SubItems.Add(Bytes2Kb(new FileInfo(compressFile.FileName).Length));

					try
					{
						string extensionName = Path.GetExtension(compressFile.FileName).TrimStart('.');
						if (arrExtName_Image.Contains(extensionName, StringComparer.OrdinalIgnoreCase))
						{
							Image image = Image.FromFile(compressFile.FileName);
							lvItem.SubItems.Add(String.Format("{0}x{1}", image.Width, image.Height));
						}
					}
					catch (Exception)
					{
						Console.WriteLine("非图片文件：" + compressFile.FileName);
					}

					this.lvFileCompress.Items.Add(lvItem);
					waitCompressFileCount++;
				}
			}
			this.lblWaitCompressFileCount.Text = waitCompressFileCount.ToString();
		}

		/// <summary>
		/// 获取压缩文件
		/// </summary>
		/// <param name="dirPath">指定文件夹</param>
		/// <returns></returns>
		private List<FileCompressItem> GetCompressFiles(string dirPath)
		{
			List<FileCompressItem> arrCompressFiles = new List<FileCompressItem>();
			List<string> arrFiles = FileHelper.GetFiles(dirPath, CompressFileTypes);
			if (arrFiles != null && arrFiles.Count > 0)
			{
				arrFiles.ForEach(fileName => arrCompressFiles.Add(new FileCompressItem(dirPath, fileName)));
			}
			return arrCompressFiles;
		}

		/// <summary>
		/// 显示状态信息
		/// </summary>
		/// <param name="message"></param>
		private void WriteMessage(string message)
		{
			UIHelper.RenderOnUIThread(this, () =>
			{
				this.lblInfomation.Text = message;
			});
		}

		/// <summary>
		/// 显示压缩结果信息
		/// </summary>
		/// <param name="result">文件压缩结果信息</param>
		private void WriteResult(FileCompressResult result)
		{
			UIHelper.RenderOnUIThread(this, () =>
			{
				ListViewItem lvItem = new ListViewItem(result.FileName_Before) { ForeColor = Color.White };
				lvItem.SubItems.Add(Bytes2Kb(result.FileSize_Before));
				lvItem.SubItems.Add(Bytes2Kb(result.FileSize_After));

				if (result.Success)
				{
					lvItem.BackColor = Color.DarkGreen;
					lvItem.SubItems.Add("成功。" + result.ResultMessage);
					this.lblSuccessCount.Text = (Convert.ToInt32(this.lblSuccessCount.Text) + 1).ToString();
				}
				else
				{
					lvItem.BackColor = Color.Red;
					lvItem.SubItems.Add("失败。" + result.ResultMessage);
					this.lblFailCount.Text = (Convert.ToInt32(this.lblFailCount.Text) + 1).ToString();
				}
				this.lvFileCompressResult.Items.Add(lvItem);
				this.ScrollToItem(this.lvFileCompressResult, this.lvFileCompressResult.Items.Count - 1);
			});
		}
		private void ResetUI()
		{
			this.arrWaitCompressFiles.Clear();
			this.saveFolderPath = string.Empty;

			this.lvFileCompress.Items.Clear();
			this.lvFileCompressResult.Items.Clear();
			this.txtCompressFolderPath.Text = string.Empty;
			this.txtSaveFolderPath.Text = string.Empty;
			this.lblInfomation.Text = "未开始压缩";
			this.lblWaitCompressFileCount.Text = this.lblSuccessCount.Text = this.lblFailCount.Text = "0";
		}
		private string Bytes2Kb(long bytesSize)
		{
			return string.Format("{0}KB", (bytesSize / 1024m).ToString("F2"));
		}
		private void ScrollToItem(ListView lv, int lvItemIndex)
		{
			if (lv != null && lv.Items.Count > 0 && lvItemIndex >= 0 && lvItemIndex <= lv.Items.Count - 1)
			{
				lv.EnsureVisible(lvItemIndex);
			}
		}
		private static void SetDoubleBuffering(Control control, bool value)
		{
			System.Reflection.PropertyInfo controlProperty = typeof(Control)
				.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
			if (controlProperty != null)
			{
				controlProperty.SetValue(control, value, null);
			}
		}
		/// <summary>
		/// 启用/禁用按钮
		/// </summary>
		private void EnableButton(Button btn, bool enable)
		{
			UIHelper.RenderOnUIThread(btn, () =>
			{
				btn.Enabled = enable;
			});
		}
		private void EnableButton(List<Button> btns, bool enable)
		{
			if (btns != null && btns.Count > 0)
			{
				btns.ForEach(btn => this.EnableButton(btn, enable));
			}
		}
		private void lvFileCompress_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.All;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}
		private void lvFileCompress_DragDrop(object sender, DragEventArgs e)
		{
			string[] arrDragFiles = e.Data.GetData(DataFormats.FileDrop, false) as string[];

			if (arrDragFiles == null || arrDragFiles.Length == 0)
			{
				return;
			}

			#region 获取压缩文件目录及保存目录
			string compressFolderPath = string.Empty;
			string saveFolderPath = string.Empty;
			FileInfo firstDragFileInfo = new FileInfo(arrDragFiles[0]);
			if (arrDragFiles.Length == 1 && firstDragFileInfo.Attributes == FileAttributes.Directory)
			{
				compressFolderPath = arrDragFiles[0];
				saveFolderPath = string.Format("{0}_{1}", compressFolderPath, "压缩后");
			}
			else
			{
				compressFolderPath = firstDragFileInfo.DirectoryName;
				saveFolderPath = Path.Combine(compressFolderPath, "压缩后");
			}
			#endregion

			#region 获取压缩文件
			List<FileCompressItem> arrWaitCompressFiles = new List<FileCompressItem>();
			foreach (string dragFileName in arrDragFiles)
			{
				FileInfo dragFileInfo = new FileInfo(dragFileName);
				if (dragFileInfo.Attributes == FileAttributes.Directory)
				{
					//文件夹 
					List<string> arrFiles = FileHelper.GetFiles(dragFileName, CompressFileTypes);
					if (arrFiles != null && arrFiles.Count > 0)
					{
						arrFiles.ForEach(fileName => arrWaitCompressFiles.Add(new FileCompressItem(compressFolderPath, fileName)));
					}
				}
				else
				{
					//文件 
					if (FileHelper.ValidFileType(dragFileName, CompressFileTypes))
					{
						arrWaitCompressFiles.Add(new FileCompressItem(compressFolderPath, dragFileName));
					}
				}
			}
			#endregion

			#region 添加压缩文件
			if (arrWaitCompressFiles.Count == 0) { return; }
			this.ResetUI();
			this.txtCompressFolderPath.Text = compressFolderPath;
			this.txtSaveFolderPath.Text = saveFolderPath;
			this.AddFiles(arrWaitCompressFiles);
			#endregion
		}

		private void ChkChangeSize_Click(object sender, EventArgs e)
		{
			this.gbxChangeSize.Enabled = this.chkChangeSize.Checked;
		}
	}
}
