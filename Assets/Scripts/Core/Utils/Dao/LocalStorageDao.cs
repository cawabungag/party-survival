using System.IO;
using Core.Utils.Newtonsoft;
using UnityEngine;

namespace Core.Utils.Dao
{
	public class LocalStorageDao<T> : IDao<T> where T : class
	{
		private readonly string _filename;

		public LocalStorageDao(string filename)
		{
			_filename = filename;
		}

		public bool Exists() => File.Exists(GetPath());

		public void Save(T vo)
		{
			var json = Json.Serialize(vo);
			var serialized = json.Base64Encode();
			var path = GetPath();
			FileUtils.WriteAllText(path, serialized);
		}

		public T Load()
		{
			var path = GetPath();
			if (!Exists())
				return null;
			var json = File.ReadAllText(path).Base64Decode();
			return Json.Deserialize<T>(json);
		}

		public void Remove()
		{
			var path = GetPath();
			FileUtils.DeleteFile(path);
		}

		private string GetPath() => Path.Combine(Application.persistentDataPath, _filename);
	}
}