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
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Page
    {
        public Create(Model.Credito credito = null)
        {
            InitializeComponent();
            this.DataContext = credito;
        }

        private void ReturnIndex()
        {
            this.NavigationService.Navigate(new View.Credito.Index());
            this.NavigationService.RemoveBackEntry();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Model.Credito credito = this.DataContext as Model.Credito;
            new CreditoController().Save(credito);
            ReturnIndex();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            ReturnIndex();
        }
    }
}
