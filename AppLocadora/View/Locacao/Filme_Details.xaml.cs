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
using System.Collections.ObjectModel;
using AppLocadora.Helper;
using AppLocadora.Controller;

namespace AppLocadora.View.Locacao
{
    /// <summary>
    /// Interaction logic for Filme_Details.xaml
    /// </summary>
    public partial class Filme_Details : Page
    {
        #region Fields
        private ObservableCollection<SelectableObject<Model.Genero>> _collectionGeneros;
        private ObservableCollection<SelectableObject<Model.Diretor>> _collectionDiretores;
        private ObservableCollection<SelectableObject<Model.Ator>> _collectionAtores;
        private ObservableCollection<SelectableObject<Model.Roteirista>> _collectionRoteiristas;
        #endregion

        #region Constructor
        public Filme_Details(Model.Filme movie)
        {
            InitializeComponent();

            _collectionGeneros = new SelectableObjectHelper().Cast(movie.Generos, true);
            _collectionDiretores = new SelectableObjectHelper().Cast(movie.Diretores, true);
            _collectionAtores = new SelectableObjectHelper().Cast(movie.Atores, true);
            _collectionRoteiristas = new SelectableObjectHelper().Cast(movie.Roteiristas, true);
            this.LoadImage(new ImageHelper().ByteToBitmapImage(movie.Capa));

            //_collectionCopias = new SelectableObjectHelper().Cast(new CopiaController().HelpComboBox());

            cbGeneros.ItemsSource = _collectionGeneros;
            cbDiretor.ItemsSource = _collectionDiretores;
            cbRoteirista.ItemsSource = _collectionRoteiristas;
            cbAtor.ItemsSource = _collectionAtores;
            cbCensura.ItemsSource = new CensuraController().SelectAll<Model.Censura>();

            cbGenerosItem_Checked(null, null);
            cbDiretorItem_Checked(null, null);
            cbAtorItem_Checked(null, null);
            cbRoteiristaItem_Checked(null, null);

            this.DataContext = movie;
        }
        #endregion

        #region Actions
        private void btnSelecionar_Click(object sender, RoutedEventArgs e)
        {
            Model.Filme filme = this.DataContext as Model.Filme;
            filme.Censura = cbCensura.SelectedItem as Model.Censura;
            filme.Generos = ObservableCollectionHelper.SelectedObjects<Model.Genero>(_collectionGeneros);
            filme.Diretores = ObservableCollectionHelper.SelectedObjects<Model.Diretor>(_collectionDiretores);
            filme.Atores = ObservableCollectionHelper.SelectedObjects<Model.Ator>(_collectionAtores);
            filme.Roteiristas = ObservableCollectionHelper.SelectedObjects<Model.Roteirista>(_collectionRoteiristas);

            Session.Current.Locacao.Filme = filme;
            this.NavigationService.Navigate(new View.Locacao.Index());
            this.NavigationService.RemoveBackEntry();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        #endregion

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

        #region Tratamento para o ComboBox
        private void cbGenerosItem_Checked(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (SelectableObject<Model.Genero> p in cbGeneros.Items)
                if (p.IsSelected)
                    sb.AppendFormat("{0}, ", p.ObjectData.Descricao);
            tbGeneros.Text = sb.ToString().Trim().TrimEnd(',');
        }

        private void cbDiretorItem_Checked(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (SelectableObject<Model.Diretor> p in cbDiretor.Items)
                if (p.IsSelected)
                    sb.AppendFormat("{0}, ", p.ObjectData.Nome);
            tbDiretor.Text = sb.ToString().Trim().TrimEnd(',');
        }

        private void cbRoteiristaItem_Checked(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (SelectableObject<Model.Roteirista> p in cbRoteirista.Items)
                if (p.IsSelected)
                    sb.AppendFormat("{0}, ", p.ObjectData.Nome);
            tbRoteirista.Text = sb.ToString().Trim().TrimEnd(',');
        }

        private void cbAtorItem_Checked(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (SelectableObject<Model.Ator> p in cbAtor.Items)
                if (p.IsSelected)
                    sb.AppendFormat("{0}, ", p.ObjectData.Nome);
            tbAtor.Text = sb.ToString().Trim().TrimEnd(',');
        }

        #region Evento Genérico
        private void Generic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            comboBox.SelectedItem = null;
        }
        #endregion
        #endregion
    }
}
