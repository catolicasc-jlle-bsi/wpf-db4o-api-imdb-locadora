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

namespace AppLocadora.View.Filme
{
    /// <summary>
    /// Interaction logic for Show.xaml
    /// </summary>
    public partial class Show : Page
    {
        public Show()
        {
            InitializeComponent();

            Model.Filme filme = new FilmeController().Last<Model.Filme>();
        }
    }
}
