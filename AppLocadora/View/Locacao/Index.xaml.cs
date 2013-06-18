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
using AppLocadora.Helper;

namespace AppLocadora.View.Locacao
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : Page
    {
        public Index()
        {
            InitializeComponent();
            this.ReloadCliente(Session.Current.Locacao.Cliente);
            this.ReloadFilme(Session.Current.Locacao.Filme);
        }

        private void ReloadCliente(Model.Cliente cliente)
        {
            if (cliente == null) { return; }

            tbCliente.DataContext = cliente;
            //spCliente.DataContext = cliente;
            //spCliente.Visibility = Visibility.Visible;
        }

        private void ReloadFilme(Model.Filme filme)
        {
            if (filme == null) { return; }

            tbFilme.DataContext = filme;
            //spCliente.DataContext = filme;
            this.LoadImage(new ImageHelper().ByteToBitmapImage(Session.Current.Locacao.Filme.Capa));
            cbCopias.ItemsSource = filme.Copias;
            spCopias.Visibility = Visibility.Visible;
        }

        #region Tratamento para a Image
        private void LoadImage(ImageSource param)
        {
            try
            {
                imgCapa.Source = param;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Actions
        private void btnSearchClient_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new View.Locacao.Cliente_List(new ClienteController().SearchAllClientsByName(tbCliente.Text)));
        }

        private void btnSearchFilme_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new View.Locacao.Filme_List(new FilmeController().SearchAllMoviesByName(tbFilme.Text)));
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Session.Current.Locacao = new Model.Locacao();
        }

        private void btnLocar_Click(object sender, RoutedEventArgs e)
        {
            Session.Current.Locacao.Copia = cbCopias.SelectedItem as Model.Copia;
            new LocacaoController().Save(Session.Current.Locacao);
            Session.Current.Locacao = new Model.Locacao();
        }
        #endregion
    }
}
