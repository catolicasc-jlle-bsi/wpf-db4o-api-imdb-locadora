using AppLocadora.Controller;
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

namespace AppLocadora.View.Filme
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
            lbFilmes.ItemsSource = new FilmeController().SelectAll<Model.Filme>();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Model.Filme filme = (sender as FrameworkElement).DataContext as Model.Filme;
            this.NavigationService.Navigate(new View.Filme.Create(filme));
            this.NavigationService.RemoveBackEntry();
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            Model.Filme filme = (sender as FrameworkElement).DataContext as Model.Filme;
            new FilmeController().Delete(filme);
            Refresh();
        }
    }
}
