using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AppLocadora.Helper
{
    /*
    using NLog;
    using NLog.Targets;

    
    public class LoggerLocadora
    {
        private static readonly LoggerLocadora instancia;

        private Logger logger;

        static LoggerLocadora()
        {
            instancia = new LoggerLocadora();
        }

        private LoggerLocadora()
        {
            string arquivo_log = Directory.GetCurrentDirectory() + @"\Logs\Locadora.txt";
            if (File.Exists(arquivo_log))
            {
                FileInfo info = new FileInfo(arquivo_log);
                if (info.Length > 400000)
                {
                    File.Copy(arquivo_log, Directory.GetCurrentDirectory() + string.Format(@"\Logs\Locadora-{0}.txt", DateTime.Now.ToString("ddMMyyyyHHmmss")));
                    File.Delete(arquivo_log);
                }
            }
            this.logger = LogManager.GetCurrentClassLogger();
        }

        public static LoggerLocadora Instancia
        {
            get
            {
                return instancia;
            }
        }

        private static readonly object sinc = new object();

        /// <summary>
        /// Grava uma mensagem de debug no log do POS.
        /// </summary>
        /// <param name="mensagem"></param>
        public void GravaDebug(string mensagem)
        {
            lock (sinc)
            {
                this.logger.Debug(mensagem.Replace("\n", "\r\n"));
            }
        }

        /// <summary>
        /// Grava uma mensagem de erro no log do POS.
        /// </summary>
        /// <param name="mensagemErro">Mensagem de erro a ser gravada.</param>
        public void GravaErro(string mensagemErro)
        {
            lock (sinc)
            {
                this.logger.Error(mensagemErro.Replace("\n", "\r\n"));
            }
        }

        /// <summary>
        /// Grava uma exceção não-tratada no log do POS.
        /// </summary>
        /// <param name="e">Exceção a ser gravada no log.</param>
        public void GravaExcecaoNaoTratada(Exception e)
        {
            string mensagem = "Ocorreu uma exceção não-tratada.";
            lock (sinc)
            {
                this.logger.FatalException(mensagem.Replace("\n", "\r\n"), e);
            }
        }

        public void GravaExcecaoNaoTratada(string mensagem, Exception e)
        {
            lock (sinc)
            {
                this.logger.FatalException(mensagem.Replace("\n", "\r\n"), e);
            }
        }

        /// <summary>
        /// Grava uma exceção tratada (com catch) no log do POS.
        /// </summary>
        /// <param name="e">Exceção a ser gravada no log.</param>
        public void GravaExcecao(Exception e)
        {
            string mensagem = "O sistema capturou uma exceção.";
            lock (sinc)
            {
                this.logger.ErrorException(mensagem.Replace("\n", "\r\n"), e);
            }
        }

        /// <summary>
        /// Grava uma exceção tratada (com catch) no log do POS.
        /// </summary>
        /// <param name="mensagem">Mensagem associada a exceção.</param>
        /// <param name="e">Exceção a ser gravada no log.</param>
        public void GravaExcecao(string mensagem, Exception e)
        {
            lock (sinc)
            {
                this.logger.ErrorException(mensagem.Replace("\n", "\r\n") + "\r\n", e);
            }
        }
        /// <summary>
        /// Grava uma exceção tratada (com catch) no log do POS.
        /// </summary>
        /// <param name="mensagem">Mensagem associada a exceção.</param>
        /// <param name="e">Exceção a ser gravada no log.</param>
        public void GravaExcecao(string mensagem)
        {
            lock (sinc)
            {
                this.logger.Fatal(mensagem.Replace("\n", "\r\n") + "\r\n");
            }
        }

    }
    */
}

