using ProtoBuf;
using System.IO;
using Avalonia.Media.Imaging;
using DrDDiary.Helpers.ValueConverter.BitMapSurrogate;

namespace DrDDiary.Helpers.ValueConverter
{
    [ProtoContract]
    public class ImageConverter //: JsonConverter<Bitmap>
    {
        public static BitmapSurrogate ToSurrogate(Bitmap bitmap)
        {
            if (bitmap == null)
                return null;

            using (var memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream); // Serialize the Bitmap to a stream (memory)
                return new BitmapSurrogate { ImageData = memoryStream.ToArray() }; // Convert to byte array
            }
        }

        public static Bitmap FromSurrogate(BitmapSurrogate surrogate)
        {
            if (surrogate == null || surrogate.ImageData == null)
                return null;

            using (var memoryStream = new MemoryStream(surrogate.ImageData))
            {
                return new Bitmap(memoryStream); // Convert byte array back to Bitmap
            }
        }
        //public override Bitmap Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        //{
        //    var base64String = reader.GetString();
        //    if (string.IsNullOrEmpty(base64String))
        //    {
        //        return null;
        //    }

        //    byte[] imageBytes = Convert.FromBase64String(base64String);
        //    using (var ms = new MemoryStream(imageBytes))
        //    {
        //        return new Bitmap(ms);
        //    }
        //}

        //public override void Write(Utf8JsonWriter writer, Bitmap value, JsonSerializerOptions options)
        //{
        //    if (value == null)
        //    {
        //        writer.WriteNullValue();
        //        return;
        //    }

        //    using (var ms = new MemoryStream())
        //    {
        //        value.Save(ms);
        //        byte[] imageBytes = ms.ToArray();
        //        string base64String = Convert.ToBase64String(imageBytes);
        //        writer.WriteStringValue(base64String);
        //    }
        //}
    }
}