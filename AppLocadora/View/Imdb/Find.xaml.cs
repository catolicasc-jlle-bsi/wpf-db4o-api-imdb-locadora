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
            e.Result = new ImdbController().SearchAllByMovieName(_pesquisa);
        }

        private void Refresh(List<Model.Imdb> imdb)
        {
            lbImdb.ItemsSource = imdb;
        }

        private void btnCadastrarFilme_Click(object sender, RoutedEventArgs e)
        {
            Model.Imdb imdb = (sender as FrameworkElement).DataContext as Model.Imdb;
            Model.Filme foundMovie = new FilmeController().Cast(imdb);
            this.NavigationService.Navigate(new View.Filme.Create(foundMovie));
            this.NavigationService.RemoveBackEntry();
        }

        #region Actions
        private void tbPesquisa_GotFocus(object sender, RoutedEventArgs e)
        {
            tbPesquisa.Text = string.Empty;
            tbPesquisa.FontStyle = FontStyles.Normal;
            tbPesquisa.Foreground = Brushes.Black;
        }

        private void tbPesquisa_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbPesquisa.Text == string.Empty)
            {
                tbPesquisa.Text = "Nome do Filme...";
                tbPesquisa.FontStyle = FontStyles.Italic;
                tbPesquisa.Foreground = Brushes.DarkGray;
            }
        }
        #endregion
    }
}
