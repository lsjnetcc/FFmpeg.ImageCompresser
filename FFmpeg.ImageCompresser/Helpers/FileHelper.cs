using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FFmpeg.ImageCompresser
{
	public sealed class FileHelper
	{
		/// <summary>
		///  根据文件搜索类型获取指定目录里的所有文件(包含子目录文件)
		/// </summary>
		/// <param name="dirPath">指定文件夹</param>
		/// <param name="fileSearchTypes">文件搜索类型集合</param>
		/// <returns></returns>
		public static List<string> GetFiles(string dirPath, List<string> fileSearchTypes)
		{
			List<string> arrFiles = new List<string>();
			if (!string.IsNullOrWhiteSpace(dirPath) && Directory.Exists(dirPath))
			{
				string[] files = Directory.GetFiles(dirPath, "*.*", SearchOption.AllDirectories);
				foreach (string fileName in files)
				{
					if (ValidFileType(fileName, fileSearchTypes))
					{
						arrFiles.Add(fileName);
					}
				}
			}
			return arrFiles;
		}

		/// <summary>
		/// 验证文件类型
		/// </summary>
		/// <param name="fileName">文件名</param>
		/// <param name="fileSearchTypes">文件搜索类型集合</param>
		/// <returns></returns>
		public static bool ValidFileType(string fileName, List<string> fileSearchTypes)
		{
			if (string.IsNullOrWhiteSpace(fileName))
			{
				return false;
			}
			if (fileSearchTypes != null && fileSearchTypes.Count > 0)
			{
				return fileSearchTypes.Contains(Path.GetExtension(fileName).TrimStart('.'), StringComparer.OrdinalIgnoreCase);
			}
			return true;
		}
	}
}
