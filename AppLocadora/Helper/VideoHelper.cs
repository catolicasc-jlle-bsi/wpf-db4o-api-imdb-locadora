using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AppLocadora.Helper
{
    public class VideoHelper
    {
        private readonly string _default = AppDomain.CurrentDomain.BaseDirectory + "temp.wmv";

        public byte[] PathToByte(string path)
        {
            if (path == null) { return null; }
            return File.ReadAllBytes(path);
        }

        public Uri ByteToPath(byte[] param)
        {
            File.WriteAllBytes(_default, param);
            return new Uri(_default);
        }
        
    }
}
