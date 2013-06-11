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

namespace AppLocadora.View.Genero
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
            lbGeneros.ItemsSource = new GeneroController().SelectAll<Model.Genero>();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Model.Genero genero = (sender as FrameworkElement).DataContext as Model.Genero;
            this.NavigationService.Navigate(new View.Genero.Create(genero));
            this.NavigationService.RemoveBackEntry();
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            Model.Genero genero = (sender as FrameworkElement).DataContext as Model.Genero;
            new GeneroController().Delete(genero);
            Refresh();
        }
    }
}
