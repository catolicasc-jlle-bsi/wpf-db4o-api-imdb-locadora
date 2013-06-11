using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.IO;

namespace AppLocadora.Helper
{
    public class ImageHelper
    {
        public BitmapImage ByteToBitmapImage(byte[] param)
        {
            MemoryStream byteStream = new MemoryStream(param);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = byteStream;
            image.EndInit();
            return image;
        }
    }
}
