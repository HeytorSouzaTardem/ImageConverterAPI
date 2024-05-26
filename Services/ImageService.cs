using System.Drawing;

namespace ImageConverter.Services
{
    public class ImageService
    {
        public static string ImageToBase64(Image image)
        {
            var format = image.RawFormat;
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }
}
