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

namespace AppLocadora.View.Diretor
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Page
    {
        public Create(Model.Diretor diretor = null)
        {
            InitializeComponent();

            cbSexo.ItemsSource = new DiretorController().SelectAll<Model.Diretor>();
            this.DataContext = diretor;
        }

        private void ReturnIndex()
        {
            this.NavigationService.Navigate(new View.Diretor.Index());
            this.NavigationService.RemoveBackEntry();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Model.Diretor diretor = this.DataContext as Model.Diretor;
            new AtorController().Save(diretor);
            ReturnIndex();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            ReturnIndex();
        }
    }
}
