namespace Core.Utils.Dao
{
	public class DaoEmpty<T> : IDao<T> where T : class
	{
		private readonly string _filename;

		private T _data;

		public DaoEmpty(string filename)
		{
			_filename = filename;
		}

		public bool Exists() => _data != null;

		public void Save(T vo) => _data = vo;

		public T Load() => _data;

		public void Remove() => _data = null;

		private string GetPath() => "";
	}
}