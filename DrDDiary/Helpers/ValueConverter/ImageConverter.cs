using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avalonia.Media.Imaging;

namespace DrDDiary.Helpers.ValueConverter
{
    public class ImageConverter : JsonConverter<Bitmap>
    {
        public override Bitmap Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var base64String = reader.GetString();
            if (string.IsNullOrEmpty(base64String))
            {
                return null;
            }

            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (var ms = new MemoryStream(imageBytes))
            {
                return new Bitmap(ms);
            }
        }

        public override void Write(Utf8JsonWriter writer, Bitmap value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            using (var ms = new MemoryStream())
            {
                value.Save(ms);
                byte[] imageBytes = ms.ToArray();
                string base64String = Convert.ToBase64String(imageBytes);
                writer.WriteStringValue(base64String);
            }
        }
    }
}