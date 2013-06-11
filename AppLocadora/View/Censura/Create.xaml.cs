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

namespace AppLocadora.View.Censura
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Page
    {
        public Create(Model.Censura censura = null)
        {
            InitializeComponent();
            this.DataContext = censura;
        }

        private void ReturnIndex()
        {
            this.NavigationService.Navigate(new View.Censura.Index());
            this.NavigationService.RemoveBackEntry();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Model.Censura censura = this.DataContext as Model.Censura;
            new CensuraController().Save(censura);
            ReturnIndex();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            ReturnIndex();
        }
    }
}
