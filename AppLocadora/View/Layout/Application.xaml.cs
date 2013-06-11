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
using System.Windows.Shapes;
using AppLocadora.Controller;
using AppLocadora.Helper;
using Db4objects.Db4o.Linq;
using Db4objects.Db4o;

namespace AppLocadora.View.Layout
{
    /// <summary>
    /// Interaction logic for Application.xaml
    /// </summary>
    public partial class Application : Window
    {
        public Application()
        {
            InitializeComponent();
            new ApplicationController();
        }

        private void miLocar_Click(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(new View.Locacao.Index());
            framePrincipal.NavigationService.RemoveBackEntry();
        }

        private void miSair_Click(object sender, RoutedEventArgs e)
        {
            // Implementar
        }

        private void miAtor_Click(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(new View.Ator.Index());
            framePrincipal.NavigationService.RemoveBackEntry();
        }

        private void miDiretor_Click(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(new View.Diretor.Index());
            framePrincipal.NavigationService.RemoveBackEntry();
        }

        private void miGenero_Click(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(new View.Genero.Index());
            framePrincipal.NavigationService.RemoveBackEntry();
        }

        private void miCensura_Click(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(new View.Censura.Index());
            framePrincipal.NavigationService.RemoveBackEntry();
        }

        private void miCredito_Click(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(new View.Credito.Index());
            framePrincipal.NavigationService.RemoveBackEntry();
        }

        private void miNovoFilme_Click(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(new View.Filme.Create());
            framePrincipal.NavigationService.RemoveBackEntry();
        }

        private void miPesquisarFilme_Click(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(new View.Filme.Find());
            framePrincipal.NavigationService.RemoveBackEntry();
        }

        private void miListarFilme_Click(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(new View.Filme.Index());
            framePrincipal.NavigationService.RemoveBackEntry();
        }

        private void miEndereco_Click(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(new View.Endereco.Index());
            framePrincipal.NavigationService.RemoveBackEntry();
        }

        private void miNovoCliente_Click(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(new View.Cliente.Create());
            framePrincipal.NavigationService.RemoveBackEntry();
        }

        private void miPesquisarCliente_Click(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(new View.Cliente.Find());
            framePrincipal.NavigationService.RemoveBackEntry();
        }

        private void miSobre_Click(object sender, RoutedEventArgs e)
        {
            // Não implementado.
        }

        private void miPesquisar_Filme_Click(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(new View.Imdb.Find());
            framePrincipal.NavigationService.RemoveBackEntry();
        }

        private void miSincronizar_Click(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(new View.Imdb.Index());
            framePrincipal.NavigationService.RemoveBackEntry();
        }

        private void miDefinirProxy_Click(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(new View.GerenciadorProxy.Create());
            framePrincipal.NavigationService.RemoveBackEntry();
        }
    }
}
