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
using Db4objects.Db4o.Linq;
using Db4objects.Db4o;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.IO;
using System.Reflection;

namespace AppLocadora.View.Filme
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Page
    {
        private ObservableCollection<SelectableObject<Model.Genero>> _collectionGeneros;
        private ObservableCollection<SelectableObject<Model.Diretor>> _collectionDiretores;
        private ObservableCollection<SelectableObject<Model.Ator>> _collectionAtores;
        private ObservableCollection<SelectableObject<Model.Roteirista>> _collectionRoteiristas;

        public Create(Model.Filme filme = null)
        {
            InitializeComponent();

            if (filme == null)
            {
                this.ReloadMovie(new Model.Filme());
            }
            else
            {
                this.ReloadMovie(filme, true);
            }

            //var atorA = new Model.Ator { Nome = "Guareschi", };

            /*
            var file = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "no_picture.gif");
            MemoryStream byteStream = new MemoryStream(file);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = byteStream;
            image.EndInit();
            imgCapa.Source = image;
            */
            //var ator = new AtorController().First<Model.Ator>();
            //File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + "1.wmv", ator.File);


            //imgCapa.DataContext = System.IO.Path.GetFullPath("Images/no_picture.gif");
            //imgCapa.DataContext = System.IO.Path.GetDirectoryName("Images/no_picture.gif");
        }

        private void ReloadMovie(Model.Filme movie, bool isReload = false)
        {
            if (!isReload)
            {
                _collectionGeneros = new SelectableObjectHelper().Cast(new GeneroController().SelectAll<Model.Genero>());
                _collectionDiretores = new SelectableObjectHelper().Cast(new GeneroController().SelectAll<Model.Diretor>());
                _collectionAtores = new SelectableObjectHelper().Cast(new GeneroController().SelectAll<Model.Ator>());
                _collectionRoteiristas = new SelectableObjectHelper().Cast(new GeneroController().SelectAll<Model.Roteirista>());
                imgCapa.Source = new ImageHelper().ByteToBitmapImage(new ConfigurationController().First<Model.Configuration>().DefaultPoster); ;
            }
            else
            {
                _collectionGeneros = new SelectableObjectHelper().Cast(movie.Generos, true);
                _collectionDiretores = new SelectableObjectHelper().Cast(movie.Diretores, true);
                _collectionAtores = new SelectableObjectHelper().Cast(movie.Atores, true);
                _collectionRoteiristas = new SelectableObjectHelper().Cast(movie.Roteiristas, true);
                imgCapa.Source = new ImageHelper().ByteToBitmapImage(movie.Capa);
            }

            cbGeneros.ItemsSource = _collectionGeneros;
            cbDiretor.ItemsSource = _collectionDiretores;
            cbRoteirista.ItemsSource = _collectionRoteiristas;
            cbAtor.ItemsSource = _collectionAtores;
            cbCensura.ItemsSource = new CensuraController().SelectAll<Model.Censura>();
            this.DataContext = movie;
        }

        private void RefreshControls()
        {
            /*
            BindingExpression tb = this.tbNome.GetBindingExpression(TextBox.TextProperty);
            tb.UpdateSource();
            
            BindingExpression cb = this.cbEstado.GetBindingExpression(ComboBox.SelectedValueProperty);
            cb.UpdateSource();*/
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            /*
             
            Model.Genero genero = cbGenero.SelectedItem as Model.Genero;
            Model.Censura censura = cbCensura.SelectedItem as Model.Censura;
            Model.Diretor diretor = cbDiretor.SelectedItem as Model.Diretor;
            Model.Ator ator = cbAtor.SelectedItem as Model.Ator;
             
             */

            //DEBUG

            /*
            RefreshControls();
            Model.Filme filme = this.Resources["Filme"] as Model.Filme;

            var atores = lvAtores.SelectedItems;
            filme.Atores = new List<Model.Ator>();

            foreach (var ator in atores) { filme.Atores.Add(ator as Model.Ator); }

            new FilmeController().Save(filme);
            */

            /*
            IObjectContainer db = ConnectionFactory.Create();
            Model.Filme filme = new FilmeController().Last<Model.Filme>(db);
            db.Close();*/

        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Model.Filme filme = this.DataContext as Model.Filme;
            filme.Censura = cbCensura.SelectedItem as Model.Censura;
            filme.Generos = new ApplicationController().SelectedObjects<Model.Genero>(_collectionGeneros);
            filme.Diretores = new ApplicationController().SelectedObjects<Model.Diretor>(_collectionDiretores);
            filme.Atores = new ApplicationController().SelectedObjects<Model.Ator>(_collectionAtores);
            filme.Roteiristas = new ApplicationController().SelectedObjects<Model.Roteirista>(_collectionRoteiristas);

            new FilmeController().Save(filme);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OnCbObjectCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (SelectableObject<Model.Genero> cbObject in cbGeneros.Items)
                if (cbObject.IsSelected)
                    sb.AppendFormat("{0}, ", cbObject.ObjectData.Descricao);
            cbGeneros.Text = sb.ToString().Trim().TrimEnd(',');
        }

        private void Generic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            comboBox.SelectedItem = null;
        }

        private void imgCapa_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image Files|*.jpg;*.gif;*.bmp;*.png;*.jpeg|All Files|*.*";

            if (openDialog.ShowDialog().Value)
                imgCapa.Source = new ImageHelper().ByteToBitmapImage(File.ReadAllBytes(openDialog.FileName));
        }

        private void btnVerificarIMDB_Click(object sender, RoutedEventArgs e)
        {
            Model.Filme foundMovie;
            Model.Filme filme = this.DataContext as Model.Filme;

            try
            {
                Model.Imdb imdb = new ImdbController().SearchByMovieName(filme.Nome);
                foundMovie = new FilmeController().Cast(imdb);
                this.ReloadMovie(foundMovie, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
