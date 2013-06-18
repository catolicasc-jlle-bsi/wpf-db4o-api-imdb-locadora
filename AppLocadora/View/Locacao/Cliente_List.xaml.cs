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
using AppLocadora.Helper;

namespace AppLocadora.View.Locacao
{
    /// <summary>
    /// Interaction logic for Cliente_List.xaml
    /// </summary>
    public partial class Cliente_List : Page
    {
        public Cliente_List(IEnumerable<Model.Cliente> clientes)
        {
            InitializeComponent();
            lbClientes.ItemsSource = clientes;
        }

        #region Actions
        private void btnDetalhes_Click(object sender, RoutedEventArgs e)
        {
            Model.Cliente cliente = (sender as FrameworkElement).DataContext as Model.Cliente;
            this.NavigationService.Navigate(new View.Locacao.Cliente_Details(cliente));
            this.NavigationService.RemoveBackEntry();
        }

        private void btnSelecionar_Click(object sender, RoutedEventArgs e)
        {
            Session.Current.Locacao.Cliente = (sender as FrameworkElement).DataContext as Model.Cliente;
            this.NavigationService.Navigate(new View.Locacao.Index());
            this.NavigationService.RemoveBackEntry();
        }
        #endregion
    }
}
