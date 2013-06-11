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
using Db4objects.Db4o;
using AppLocadora.Helper;
using AppLocadora.Controller;
using AppLocadora.Model;

namespace AppLocadora.View.Ator
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Page
    {
        public Create(Model.Ator ator = null)
        {
            InitializeComponent();

            cbSexo.ItemsSource = new SexoController().SelectAll<Model.Sexo>();
            this.DataContext = ator;
        }

        private void ReturnIndex()
        {
            this.NavigationService.Navigate(new View.Ator.Index());
            this.NavigationService.RemoveBackEntry();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Model.Ator ator = this.DataContext as Model.Ator;
            new AtorController().Save(ator);
            ReturnIndex();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            ReturnIndex();
        }
    }
}
