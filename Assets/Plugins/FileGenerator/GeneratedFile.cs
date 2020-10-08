using System.IO;

namespace FileGenerator
{
	public class GeneratedFile
	{
		public readonly FileInfo FileInfo;
		public readonly string FileData;

		public GeneratedFile(FileInfo fileInfo, string fileData)
		{
			FileInfo = fileInfo;
			FileData = fileData;
		}
	}
}