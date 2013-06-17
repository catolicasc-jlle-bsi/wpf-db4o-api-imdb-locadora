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
            this.DataContext = new GerenciadorProxyController().Single<Model.GerenciadorProxy>();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Model.GerenciadorProxy gp = this.DataContext as Model.GerenciadorProxy;
            new GerenciadorProxyController().Save(gp);
        }
    }
}
