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
using AppLocadora.Controller;

namespace AppLocadora.View.Credito
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
            lbCreditos.ItemsSource = new CreditoController().SelectAll<Model.Credito>();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Model.Credito credito = (sender as FrameworkElement).DataContext as Model.Credito;
            this.NavigationService.Navigate(new View.Credito.Create(credito));
            this.NavigationService.RemoveBackEntry();
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            Model.Credito credito = (sender as FrameworkElement).DataContext as Model.Credito;
            new CensuraController().Delete(credito);
            Refresh();
        }
    }
}
