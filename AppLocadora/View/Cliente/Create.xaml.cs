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
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Page
    {
        public Create(Model.Cliente cliente = null)
        {
            InitializeComponent();
            cbSexo.ItemsSource = new SexoController().SelectAll<Model.Sexo>();

            if (cliente == null)
            {
                cliente = new Model.Cliente 
                { 
                    Endereco = new Model.Endereco(),
                    Conta = new Model.Conta(), 
                };
            }

            this.DataContext = cliente;
        }

        private void ReturnIndex()
        {
            this.NavigationService.Navigate(new View.Cliente.Index());
            this.NavigationService.RemoveBackEntry();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Model.Cliente cliente = this.DataContext as Model.Cliente;
            new ClienteController().Save(cliente);
            ReturnIndex();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            ReturnIndex();
        }
    }
}
