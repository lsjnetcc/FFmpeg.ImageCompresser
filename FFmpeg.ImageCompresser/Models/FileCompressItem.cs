using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFmpeg.ImageCompresser
{
	/// <summary>
	/// 文件压缩项
	/// </summary>
	public class FileCompressItem
	{
		public FileCompressItem()
		{

		}
		public FileCompressItem(string directoryName)
			: this()
		{
			this.DirectoryName = directoryName;
		}
		public FileCompressItem(string directoryName, string fileName)
			: this(directoryName)
		{
			this.FileName = fileName;
		}
		/// <summary>
		///目录名称 
		/// </summary>
		public string DirectoryName { get; set; }
		/// <summary>
		/// 文件名称
		/// </summary>
		public string FileName { get; set; }
	}
}
