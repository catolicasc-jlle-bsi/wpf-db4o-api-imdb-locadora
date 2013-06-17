using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using AppLocadora.Controller;
using System.IO;
using AppLocadora.Model;

namespace AppLocadora.Helper
{
    public class ConnectionInternetFactory : WebClient
    {
        public ConnectionInternetFactory Create()
        {
            GerenciadorProxy gp = new GerenciadorProxyController().Single<GerenciadorProxy>();

            if (gp != null)
            {
                if (gp.Active)
                {
                    Proxy = new WebProxy(string.Format("http://{0}:{1}", gp.Endereco, gp.Porta));
                    Proxy.Credentials = CredentialCache.DefaultCredentials;
                }
            }

            return this;
        }

        public string Down(string url)
        {
            try
            {
                using (StreamReader reader = new StreamReader(this.OpenRead(url)))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public byte[] DownBytes(string url)
        {
            try
            {
                return this.DownloadData(url);
            }
            catch (Exception)
            {
                return new byte[0];
            }
        }
    }
}
