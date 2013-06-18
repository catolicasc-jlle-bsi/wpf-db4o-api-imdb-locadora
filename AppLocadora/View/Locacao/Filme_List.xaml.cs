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

namespace AppLocadora.View.Locacao
{
    /// <summary>
    /// Interaction logic for Filme_List.xaml
    /// </summary>
    public partial class Filme_List : Page
    {
        public Filme_List(IEnumerable<Model.Filme> filmes)
        {
            InitializeComponent();
            lbFilmes.ItemsSource = filmes;
        }

        #region Actions
        private void btnSelecionar_Click(object sender, RoutedEventArgs e)
        {
            Session.Current.Locacao.Filme = (sender as FrameworkElement).DataContext as Model.Filme;
            this.NavigationService.Navigate(new View.Locacao.Index());
            this.NavigationService.RemoveBackEntry();
        }

        private void btnDetalhes_Click(object sender, RoutedEventArgs e)
        {
            Model.Filme filme = (sender as FrameworkElement).DataContext as Model.Filme;
            this.NavigationService.Navigate(new View.Locacao.Filme_Details(filme));
            this.NavigationService.RemoveBackEntry();
        }
        #endregion
    }
}
