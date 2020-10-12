using System;
using Newtonsoft.Json;
using UnityEngine;

namespace Core.Utils.Newtonsoft.CustomConverters
{
	public class ColorConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var hex = ((Color) value).ToRgbaHex();
			writer.WriteValue(hex);
		}

		public override object ReadJson(
			JsonReader reader,
			Type objectType,
			object existingValue,
			JsonSerializer serializer
		)
		{
			var value = (string) reader.Value;
			if (string.IsNullOrEmpty(value) || value[0] != '#')
			{
				serializer.Populate(reader, existingValue);
				return existingValue;
			}

			var color = new Color(
				Convert.ToByte(value.Substring(1, 2), 16) / 255f,
				Convert.ToByte(value.Substring(3, 2), 16) / 255f,
				Convert.ToByte(value.Substring(5, 2), 16) / 255f
			);
			if (value.Length == 9)
				color.a = Convert.ToByte(value.Substring(7, 2), 16) / 255f;
			return color;
		}

		public override bool CanConvert(Type objectType) => objectType == typeof(Color);
	}
}