using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AppLocadora.Helper;
using Newtonsoft.Json;
using AppLocadora.Controller;
using System.Net;
using AppLocadora.Model;
using System.ComponentModel;

namespace AppLocadora.View.Imdb
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : Page
    {
        private string _address = @"http://imdbapi.org/?id=tt{0}&type=json&plot=simple&episode=1&lang=en-US&aka=simple&release=simple&business=0&tech=0";
        private BackgroundWorker _backgroundWorker = new BackgroundWorker();

        private long _currentId = 1;
        private long _controlBreak;
        private const long MAX = 10;

        public Index()
        {
            InitializeComponent();
            Refresh();
        }

        /// <summary>
        /// Um background assíncrono e recursivo, quer mais?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSincronizar_Click(object sender, RoutedEventArgs e)
        {
            if (_backgroundWorker.IsBusy) { return; }

            string id = new ImdbController().LastId();

            if (id != String.Empty)
                _currentId += Convert.ToInt64(id.Replace("tt", String.Empty));

            _controlBreak = _currentId + MAX;

            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += new DoWorkEventHandler(_backgroundWorker_DoWork);
            _backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_backgroundWorker_RunWorkerCompleted);
            _backgroundWorker.RunWorkerAsync();
        }

        void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Model.Imdb imdb = e.Result as Model.Imdb;
            new ImdbController().Save(imdb);

            Refresh();
            _currentId++;

            if (_currentId < _controlBreak)
                _backgroundWorker.RunWorkerAsync();
        }

        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string content = Session.Current.Internet.Down(string.Format(_address, _currentId));
            e.Result = JsonConvert.DeserializeObject<Model.Imdb>(content);
        }

        private void Refresh()
        {
            lbImdb.ItemsSource = new ImdbController().SelectAll<Model.Imdb>();
            //Implementar focus no último item da lista
        }
    }
}
