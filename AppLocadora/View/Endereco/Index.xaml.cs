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

namespace AppLocadora.View.Endereco
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
            lbEnderecos.ItemsSource = new EnderecoController().SelectAll<Model.Endereco>();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Model.Endereco endereco = (sender as FrameworkElement).DataContext as Model.Endereco;
            this.NavigationService.Navigate(new View.Endereco.Create(endereco));
            this.NavigationService.RemoveBackEntry();
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            Model.Endereco endereco = (sender as FrameworkElement).DataContext as Model.Endereco;
            new GeneroController().Delete(endereco);
            Refresh();
        }
    }
}
