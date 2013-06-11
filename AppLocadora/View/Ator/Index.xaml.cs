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
using Db4objects.Db4o;
using AppLocadora.Helper;
using AppLocadora.Controller;
using AppLocadora.Model;
using System.IO;

namespace AppLocadora.View.Ator
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : Page
    {
        public Index()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh()
        {
            lbAtores.ItemsSource = new AtorController().SelectAll<Model.Ator>();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Model.Ator ator = (sender as FrameworkElement).DataContext as Model.Ator;
            this.NavigationService.Navigate(new View.Ator.Create(ator));
            this.NavigationService.RemoveBackEntry();
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            Model.Ator ator = (sender as FrameworkElement).DataContext as Model.Ator;
            new AtorController().Delete(ator);
            Refresh();
        }

        private void btnSincronizar_Click(object sender, RoutedEventArgs e)
        {
            //new ImdbController().IntegrateWithDatabase();
            /*
            List<Model.Ator> actors = new ImdbController().SelectAllActors();
            actors.ForEach(actor => new AtorController().Save(actor));
            Refresh();
            */
            
            var filme = new Model.Filme { Nome = "Frizzo muito louco", };
            filme.Trailer = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "Wildlife.wmv");
            new FilmeController().Save(filme);

            var recup = new FilmeController().Last<Model.Filme>();
            File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + "Frizzo doidao.wmv", recup.Trailer);
        }
    }
}
