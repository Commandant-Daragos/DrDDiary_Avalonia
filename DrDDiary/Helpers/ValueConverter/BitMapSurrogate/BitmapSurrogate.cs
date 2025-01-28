using Avalonia.Media.Imaging;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrDDiary.Helpers.ValueConverter.BitMapSurrogate
{
    [ProtoContract]
    public class BitmapSurrogate
    {
        [ProtoMember(1)]
        public byte[] ImageData { get; set; }

        public BitmapSurrogate() { }

        public BitmapSurrogate(Bitmap bitmap)
        {
            if (bitmap != null)
            {
                using (var stream = new MemoryStream())
                {
                    bitmap.Save(stream);  // Convert Bitmap to byte array
                    ImageData = stream.ToArray();
                }
            }
        }

        public Bitmap ToBitmap()
        {
            if (ImageData == null)
                return null;

            using (var stream = new MemoryStream(ImageData))
            {
                return new Bitmap(stream);  // Convert byte array back to Bitmap
            }
        }

        // Implement the required methods for IProtoSurrogate
        public static explicit operator BitmapSurrogate(Bitmap bitmap)
        {
            return new BitmapSurrogate(bitmap);
        }

        public static explicit operator Bitmap(BitmapSurrogate surrogate)
        {
            return surrogate?.ToBitmap();
        }
    }
}
