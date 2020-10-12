using System;
using Ecs.Core;
using Newtonsoft.Json;

namespace Core.Utils.Newtonsoft.CustomConverters
{
	public class UidConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteValue(value.ToString());
		}

		public override object ReadJson(
			JsonReader reader,
			Type objectType,
			object existingValue,
			JsonSerializer serializer
		)
		{
			var value = reader.Value as string;
			return Uid.Parse(value);
		}

		public override bool CanConvert(Type objectType)
			=> objectType == typeof(Uid) || objectType == typeof(Uid?);
	}
}