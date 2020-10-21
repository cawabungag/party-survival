using System.Collections.Generic;

namespace Core.Utils.Job
{
	public struct JobData<TData, TResult>
	{
		private readonly List<TData> _datas;
		private readonly List<TResult> _results;

		public JobData(List<TData> datas, List<TResult> results)
		{
			_datas = datas;
			_results = results;
		}

		public TData Get(int index) => _datas[index];

		public void Put(TResult result)
		{
			lock (_results)
			{
				_results.Add(result);
			}
		}
		
		public List<TResult> GetResult() => _results;
	}
}