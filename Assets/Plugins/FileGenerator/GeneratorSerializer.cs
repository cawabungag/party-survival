using System.Collections.Generic;
using System.IO;

namespace FileGenerator
{
	public static class GeneratorSerializer
	{
		public static void Save(List<GeneratedFile> files)
		{
			foreach (var proxyFiles in files)
			{
				SaveToFile(proxyFiles.FileInfo, proxyFiles.FileData);
			}
		}

		private static void SaveToFile(FileInfo fileInfo, string data)
		{
			var fileDirectory = fileInfo.Directory;
			if (!fileDirectory.Exists)
				fileDirectory.Create();
			if (fileInfo.Exists)
				fileInfo.Delete();
			File.WriteAllText(fileInfo.FullName, data);
		}
	}
}