using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using AppLocadora.Model;

namespace AppLocadora.Helper
{
    /// <summary>
    /// Classe responsável por fazer download do código fonte de uma determinar página da web
    /// </summary>
    public static class Downloader
    {

        #region Download de código fonte da página
        /// <summary>
        /// Realiza o download do código fonte da página
        /// </summary>
        /// <param name="url">Url responsável pelo endereço</param>
        /// <returns></returns>
        public static string DownloadArquivo(Uri url, GerenciadorProxy Proxy)
        {
            try
            {
                using (WebClient cliente = new WebClient())
                {
                    if (Proxy != null)
                    {
                        WebProxy proxy = ConfigurarProxy(Proxy.Endereco, Proxy.Porta);
                        proxy.Credentials = CredentialCache.DefaultCredentials;
                        cliente.Proxy = proxy;
                    }
                    Stream stream = cliente.OpenRead(url);
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        #endregion

        #region Configuração de Proxy
        /// <summary>
        /// Configura conexão proxy
        /// </summary>
        /// <param name="endereco">endereço</param>
        /// <param name="porta">porta</param>
        /// <returns></returns>
        public static WebProxy ConfigurarProxy(string endereco, string porta)
        {
            return new WebProxy(string.Format("http://{0}:{1}", endereco, porta));
        }
        #endregion

    }
}
