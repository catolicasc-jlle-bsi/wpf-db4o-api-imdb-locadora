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
using AppLocadora.Model;
using Newtonsoft.Json;
using AppLocadora.Controller;
using System.ComponentModel;

namespace AppLocadora.View.Imdb
{
    /// <summary>
    /// Interaction logic for Find.xaml
    /// </summary>
    public partial class Find : Page
    {
        private string _address = @"http://imdbapi.org/?title={0}&type=json&plot=simple&episode=0&limit=10&yg=0&mt=M&lang=en-US&offset=&aka=simple&release=simple&business=0&tech=0";
        private string _pesquisa = String.Empty;
        private BackgroundWorker _backgroundWorker = new BackgroundWorker();

        public Find()
        {
            InitializeComponent();
        }

        private void btnPesquisarFilme_Click(object sender, RoutedEventArgs e)
        {
            if (_backgroundWorker.IsBusy) { return; }

            _pesquisa = tbPesquisa.Text;

            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += new DoWorkEventHandler(_backgroundWorker_DoWork);
            _backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_backgroundWorker_RunWorkerCompleted);
            _backgroundWorker.RunWorkerAsync();
        }

        void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<Model.Imdb> imdb = e.Result as List<Model.Imdb>;
            Refresh(imdb);
        }

        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string content = Session.Current.Internet.Down(string.Format(_address, _pesquisa));
            e.Result = JsonConvert.DeserializeObject<List<Model.Imdb>>(content);
        }

        private void Refresh(List<Model.Imdb> imdb)
        {
            lbImdb.ItemsSource = imdb;
            //Implementar focus no último item da lista
        }

        private void btnInserirFilme_Click(object sender, RoutedEventArgs e)
        {
            Model.Imdb imdb = (sender as FrameworkElement).DataContext as Model.Imdb;
            new ImdbController().Save(imdb);
        }
    }
}
