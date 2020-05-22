using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFmpeg.ImageCompresser
{
	public sealed class FFmpegHelper
	{
		// 缩放尺寸：D:\ffmpeg.exe -y -i input.jpg -s 宽x高 output.jpg

		/// <summary>
		/// 压缩文件
		/// </summary>
		/// <param name="ffmpegPath">ffmpeg压缩软件路径</param>
		/// <param name="inputFileName">输入文件名</param>
		/// <param name="outputFileName">输出文件名</param>
		/// <returns>是否压缩成功</returns>
		/// </summary>
		public static bool CompressFile(string ffmpegPath, string inputFileName, string outputFileName)
		{
			return CompressFile(ffmpegPath, 0, 0, inputFileName, outputFileName);
		}

		/// <summary>
		/// 缩放并压缩文件
		/// </summary>
		/// <param name="ffmpegPath">ffmpeg压缩软件路径</param>
		/// <param name="width">缩放后的宽度</param>
		/// <param name="height">缩放后的高度</param>
		/// <param name="inputFileName">输入文件名</param>
		/// <param name="outputFileName">输出文件名</param>
		/// <returns>是否压缩成功</returns>
		/// </summary>
		public static bool CompressFile(string ffmpegPath, int width, int height, string inputFileName, string outputFileName)
		{
			StringBuilder processArguments = new StringBuilder();
			processArguments.AppendFormat(" -y -i \"{0}\"", inputFileName);
			if (width > 0 && height > 0)
				processArguments.AppendFormat(" -s {0}x{1}", width, height);
			processArguments.AppendFormat(" \"{0}\"", outputFileName);

			string outputStr = string.Empty;
			StartProcess(ffmpegPath, processArguments.ToString(), out outputStr);
			//ffmpeg转换完成
			if (!string.IsNullOrWhiteSpace(outputStr) && outputStr.Contains("video:") && outputStr.Contains("muxing overhead") && File.Exists(outputFileName))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// 启动进程
		/// </summary>
		/// <param name="processFileName">进程名称</param>
		/// <param name="processArguments">进程参数</param>
		/// <param name="outputStr"></param>
		private static void StartProcess(string processFileName, string processArguments, out string outputStr)
		{
			outputStr = string.Empty;

			using (Process process = new Process())
			{
				process.StartInfo.FileName = processFileName;
				process.StartInfo.Arguments = processArguments;
				process.StartInfo.UseShellExecute = false;

				process.StartInfo.RedirectStandardInput = true;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.RedirectStandardError = true;
				process.StartInfo.CreateNoWindow = true;
				//process.StartInfo.StandardOutputEncoding = Encoding.UTF8;

				StringBuilder sbReceviedData = new StringBuilder();
				DataReceivedEventHandler outputDataReceived = (object sender, DataReceivedEventArgs e) =>
				{
					if (!string.IsNullOrEmpty(e.Data))
					{
						sbReceviedData.Append(e.Data);
					}
				};

				process.OutputDataReceived += outputDataReceived;
				process.ErrorDataReceived += outputDataReceived;

				process.Start();
				process.BeginOutputReadLine();
				process.BeginErrorReadLine();
				process.WaitForExit();

				outputStr = sbReceviedData.ToString();
			}
		}
	}
}
