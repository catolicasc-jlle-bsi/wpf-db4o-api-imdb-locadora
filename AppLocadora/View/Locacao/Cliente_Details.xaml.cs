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
    /// Interaction logic for Cliente_Details.xaml
    /// </summary>
    public partial class Cliente_Details : Page
    {
        public Cliente_Details(Model.Cliente cliente)
        {
            InitializeComponent();
            this.DataContext = cliente;
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void btnSelecionar_Click(object sender, RoutedEventArgs e)
        {
            Session.Current.Locacao.Cliente = (sender as FrameworkElement).DataContext as Model.Cliente;
            this.NavigationService.Navigate(new View.Locacao.Index());
            this.NavigationService.RemoveBackEntry();
        }
    }
}
