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
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Page
    {
        public Create(Model.Genero genero = null)
        {
            InitializeComponent();
            this.DataContext = genero;
        }

        private void ReturnIndex()
        {
            this.NavigationService.Navigate(new View.Genero.Index());
            this.NavigationService.RemoveBackEntry();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Model.Genero genero = this.DataContext as Model.Genero;
            new GeneroController().Save(genero);
            ReturnIndex();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            ReturnIndex();
        }
    }
}
