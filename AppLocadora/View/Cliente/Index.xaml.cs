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

namespace AppLocadora.View.Cliente
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
            lbAtores.ItemsSource = new ClienteController().SelectAll<Model.Cliente>();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Model.Cliente cliente = (sender as FrameworkElement).DataContext as Model.Cliente;
            this.NavigationService.Navigate(new View.Cliente.Create(cliente));
            this.NavigationService.RemoveBackEntry();
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            Model.Cliente cliente = (sender as FrameworkElement).DataContext as Model.Cliente;
            new ClienteController().Delete(cliente);
            Refresh();
        }
    }
}
