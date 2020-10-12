using System.IO;
using System.Text;

namespace Core.Utils.Dao
{
	public static class FileUtils
	{
		/// <summary>
		/// Create directory if doesnt exist and write all text
		/// </summary>
		public static bool WriteAllText(string path, string text)
		{
			var bytes = Encoding.UTF8.GetBytes(text);
			return WriteAllBytes(path, bytes);
		}

		/// <summary>
		/// Create directory if doesnt exist and write all bytes
		/// </summary>
		public static bool WriteAllBytes(string path, byte[] bytes)
		{
			var fileInfo = new FileInfo(path);
			var directory = fileInfo.Directory;
			if (directory == null)
				return false;

			if (!directory.Exists)
				directory.Create();
			File.WriteAllBytes(path, bytes);
			return true;
		}

		public static bool DeleteFile(string path)
		{
			if (!File.Exists(path))
				return false;
			File.Delete(path);
			return true;
		}
	}
}