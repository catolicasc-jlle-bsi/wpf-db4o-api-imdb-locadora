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

namespace AppLocadora.View.GerenciadorProxy
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Create : Page
    {
        public Create()
        {
            InitializeComponent();
            Helper.GerenciadorProxy gp = new GerenciadorProxyController().First<Helper.GerenciadorProxy>();
            this.DataContext = gp ?? new Helper.GerenciadorProxy();
        }

        private void ReturnIndex()
        {
            //this.NavigationService.Navigate(new View.Ator.Index());
            //this.NavigationService.RemoveBackEntry();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Helper.GerenciadorProxy gp = this.DataContext as Helper.GerenciadorProxy;
            new GerenciadorProxyController().Save(gp);
            ReturnIndex();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            ReturnIndex();
        }
    }
}
