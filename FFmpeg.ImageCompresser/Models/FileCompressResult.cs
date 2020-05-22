using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFmpeg.ImageCompresser
{
	/// <summary>
	/// 文件压缩结果
	/// </summary>
	public class FileCompressResult
	{
		public FileCompressResult()
		{

		}
		public FileCompressResult(string fileName_Before)
			: this()
		{
			this.FileName_Before = fileName_Before;
		}
		public FileCompressResult(string fileName_Before, long fileSize_Before)
			: this(fileName_Before)
		{
			this.FileSize_Before = fileSize_Before;
		}

		/// <summary>
		/// 压缩前文件名
		/// </summary>
		public string FileName_Before { get; set; }

		/// <summary>
		/// 压缩前文件大小
		/// </summary>
		public long FileSize_Before { get; set; }

		/// <summary>
		/// 压缩后文件名
		/// </summary>
		public string FileName_After { get; set; }

		/// <summary>
		/// 压缩后文件大小
		/// </summary>
		public long FileSize_After { get; set; }

		/// <summary>
		/// 压缩是否成功
		/// </summary>
		public bool Success { get; set; }

		/// <summary>
		/// 压缩结果
		/// </summary>
		public string ResultMessage { get; set; }
	}
}
