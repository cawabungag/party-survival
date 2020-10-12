using Core.Utils.Newtonsoft.CustomConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.UnityConverters.Math;
using ColorConverter = Core.Utils.Newtonsoft.CustomConverters.ColorConverter;

namespace Core.Utils.Newtonsoft
{
	public static class Json
	{
		private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
		{
			Converters =
			{
				new ColorConverter(),
				new Vector2Converter(),
				new Vector2IntConverter(),
				new Vector3Converter(),
				new Vector3IntConverter(),
				new QuaternionConverter(),
				new UidConverter(),
			},
			NullValueHandling = NullValueHandling.Ignore
		};

		public static string Serialize(object obj)
			=> JsonConvert.SerializeObject(obj, Settings);

		public static T Deserialize<T>(string json)
			=> JsonConvert.DeserializeObject<T>(json, Settings);
	}
}