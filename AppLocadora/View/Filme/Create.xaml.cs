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
        #region Fields
        private ObservableCollection<SelectableObject<Model.Genero>> _collectionGeneros;
        private ObservableCollection<SelectableObject<Model.Diretor>> _collectionDiretores;
        private ObservableCollection<SelectableObject<Model.Ator>> _collectionAtores;
        private ObservableCollection<SelectableObject<Model.Roteirista>> _collectionRoteiristas;
        #endregion

        #region Constructor
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
        }
        #endregion

        #region Methods
        private void ReloadMovie(Model.Filme movie, bool isReload = false)
        {
            if (!isReload)
            {
                _collectionGeneros = new SelectableObjectHelper().Cast(new GeneroController().SelectAll<Model.Genero>());
                _collectionDiretores = new SelectableObjectHelper().Cast(new GeneroController().SelectAll<Model.Diretor>());
                _collectionAtores = new SelectableObjectHelper().Cast(new GeneroController().SelectAll<Model.Ator>());
                _collectionRoteiristas = new SelectableObjectHelper().Cast(new GeneroController().SelectAll<Model.Roteirista>());
                this.LoadImage(new ImageHelper().ByteToBitmapImage(new ConfigurationController().First<Model.Configuration>().DefaultPoster));
            }
            else
            {
                _collectionGeneros = new SelectableObjectHelper().Cast(movie.Generos, true);
                _collectionDiretores = new SelectableObjectHelper().Cast(movie.Diretores, true);
                _collectionAtores = new SelectableObjectHelper().Cast(movie.Atores, true);
                _collectionRoteiristas = new SelectableObjectHelper().Cast(movie.Roteiristas, true);
                this.LoadImage(new ImageHelper().ByteToBitmapImage(movie.Capa));
                this.LoadVideo(movie.Trailer);
            }

            cbGeneros.ItemsSource = _collectionGeneros;
            cbDiretor.ItemsSource = _collectionDiretores;
            cbRoteirista.ItemsSource = _collectionRoteiristas;
            cbAtor.ItemsSource = _collectionAtores;
            cbCensura.ItemsSource = new CensuraController().SelectAll<Model.Censura>();

            cbCreditoDVD.ItemsSource = new CreditoController().SelectAllByFormato(Model.Formato.DVD);
            cbCreditoBluray.ItemsSource = new CreditoController().SelectAllByFormato(Model.Formato.Bluray);

            if (movie.Copias == null)
            {
                tbCopiasDVD.Text = 0.ToString();
                tbCopiasBluray.Text = 0.ToString();
            }
            else
            {
                tbCopiasDVD.Text = movie.Copias.Where(w => w.Credito.Formato == Model.Formato.DVD).Count().ToString();
                tbCopiasBluray.Text = movie.Copias.Where(w => w.Credito.Formato == Model.Formato.Bluray).Count().ToString();

                cbCreditoDVD.SelectedItem = new CreditoController().SelectByFormato(Model.Formato.DVD, movie);
                cbCreditoBluray.SelectedItem = new CreditoController().SelectByFormato(Model.Formato.Bluray, movie);
            }       

            cbGenerosItem_Checked(null, null);
            cbDiretorItem_Checked(null, null);
            cbAtorItem_Checked(null, null);
            cbRoteiristaItem_Checked(null, null);

            this.DataContext = movie;
        }
        #endregion

        #region Integração com o IMDB
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
        #endregion

        #region Actions
        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Model.Filme filme = this.DataContext as Model.Filme;
            filme.Censura = cbCensura.SelectedItem as Model.Censura;
            filme.Generos = ObservableCollectionHelper.SelectedObjects<Model.Genero>(_collectionGeneros);
            filme.Diretores = ObservableCollectionHelper.SelectedObjects<Model.Diretor>(_collectionDiretores);
            filme.Atores = ObservableCollectionHelper.SelectedObjects<Model.Ator>(_collectionAtores);
            filme.Roteiristas = ObservableCollectionHelper.SelectedObjects<Model.Roteirista>(_collectionRoteiristas);
            filme.Copias = new CopiaController().Generate(this.HelperCopias());
            filme.Capa = new ImageHelper().BitmapImageToByte((BitmapImage)imgCapa.Source);
            filme.Trailer = this.SerializeVideo();
            
            new FilmeController().Save(filme);
            this.ReturnIndex();
        }

        private Dictionary<List<Model.Formato>, Model.Credito> HelperCopias()
        {
            

            Dictionary<List<Model.Formato>, Model.Credito> dicCopias = new Dictionary<List<Model.Formato>, Model.Credito>();

            //Dictionary<int, Model.Credito> dicCopias = new Dictionary<int, Model.Credito>();

            if (!string.IsNullOrEmpty(tbCopiasDVD.Text) && cbCreditoDVD.SelectedItem as Model.Credito != null)
            {
                List<Model.Formato> list = new List<Model.Formato>();
                Model.Credito dvdCredito = cbCreditoDVD.SelectedItem as Model.Credito;
                dvdCredito.Formato = Model.Formato.DVD;
                for (int aux = 1; aux <= int.Parse(tbCopiasDVD.Text); aux++)
                    list.Add(Model.Formato.DVD);

                dicCopias.Add(list, dvdCredito);
            }

            if (!string.IsNullOrEmpty(tbCopiasBluray.Text) && cbCreditoBluray.SelectedItem as Model.Credito != null)
            {
                List<Model.Formato> list = new List<Model.Formato>();
                Model.Credito blurayCredito = cbCreditoBluray.SelectedItem as Model.Credito;
                blurayCredito.Formato = Model.Formato.Bluray;
                for (int aux = 1; aux <= int.Parse(tbCopiasBluray.Text); aux++)
                    list.Add(Model.Formato.Bluray);

                dicCopias.Add(list, blurayCredito);
            }

            return dicCopias;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.ReturnIndex();
        }

        private void ReturnIndex()
        {
            this.NavigationService.Navigate(new View.Filme.Index());
            this.NavigationService.RemoveBackEntry();
        }
        #endregion

        #region Tratamento de Validações
        private void RefreshControls()
        {

            BindingExpression tb = this.tbNome.GetBindingExpression(TextBox.TextProperty);
            tb.UpdateSource();

            /*
            BindingExpression cb = this.cbEstado.GetBindingExpression(ComboBox.SelectedValueProperty);
            cb.UpdateSource();*/
        }
        #endregion

        #region Tratamento para a Image
        private void LoadImage(ImageSource param)
        {
            if (param == null) { return; }
            try
            {
                imgCapa.Source = param;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void imgCapa_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image Files|*.jpg;*.gif;*.bmp;*.png;*.jpeg|All Files|*.*";

            if (openDialog.ShowDialog().Value)
                imgCapa.Source = new ImageHelper().ByteToBitmapImage(File.ReadAllBytes(openDialog.FileName));
        }
        #endregion

        #region Tratamento para o Video

        private byte[] SerializeVideo()
        {
            return mediaPlayerMain.Source != null ?
                new VideoHelper().PathToByte(mediaPlayerMain.Source.LocalPath) :
                null;
        }

        /// <summary>
        /// Stop media when ended
        /// </summary>
        private void mediaPlayerMain_MediaEnded(object sender, RoutedEventArgs e)
        {
            mediaPlayerMain.Stop();
        }

        /// <summary>
        /// Initialise UI elements based on current media item
        /// </summary>
        private void mediaPlayerMain_MediaOpened(object sender, RoutedEventArgs e)
        {
            sliderVolume.IsEnabled = mediaPlayerMain.IsLoaded;
        }

        /// <summary>
        /// stop the media playing
        /// </summary>
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayerMain.Stop();
        }

        /// <summary>
        /// pause the media playing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayerMain.Pause();
        }

        /// <summary>
        /// play the media
        /// </summary>
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayerMain.Play();
            mediaPlayerMain.Volume = (double)sliderVolume.Value;
        }

        /// <summary>
        /// change media volume to position (x)
        /// </summary>
        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            mediaPlayerMain.Volume = (double)sliderVolume.Value;
        }

        private void LoadVideo(byte[] param)
        {
            if (param == null) { return; }
            try
            {
                mediaPlayerMain.Source = new VideoHelper().ByteToPath(param);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMediaPlayerMain_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openDialog = new Microsoft.Win32.OpenFileDialog();
            openDialog.Filter = "Video Files|*.wmv;|All Files|*.*";

            if (openDialog.ShowDialog().Value)
            {
                mediaPlayerMain.Source = null;
                mediaPlayerMain.Source = new Uri(openDialog.FileName);
                mediaPlayerBorder.Visibility = Visibility.Visible;
                mediaPlayerMain.Play();
                mediaPlayerMain.Volume = (double)sliderVolume.Value;
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

