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
            lbCensuras.ItemsSource = new CensuraController().SelectAll<Model.Censura>();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Model.Censura censura = (sender as FrameworkElement).DataContext as Model.Censura;
            this.NavigationService.Navigate(new View.Censura.Create(censura));
            this.NavigationService.RemoveBackEntry();
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            Model.Censura censura = (sender as FrameworkElement).DataContext as Model.Censura;
            new CensuraController().Delete(censura);
            Refresh();
        }
    }
}
