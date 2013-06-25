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
            if (param.Length == 0) { throw new Exception("Falha ao carregar a imagem: Imagem inexistente!"); };

            MemoryStream byteStream = new MemoryStream(param);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = byteStream;
            image.EndInit();
            return image;
        }

        public byte[] BitmapImageToByte(BitmapImage param)
        {
            if (param == null) { throw new Exception("Falha ao carregar a imagem: Imagem inexistente!"); };

            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(param));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }
    }
}
