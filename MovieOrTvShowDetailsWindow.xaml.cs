using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OODStarterCode_Feb20_2023
{
   
    public partial class MovieOrTvShowDetailsWindow : Window
    {
        public MovieOrTvShowDetailsWindow(Movie selectedMovie)
        {
            InitializeComponent();

            //display movie image and details
            imgMovie.Source = new BitmapImage(new Uri(selectedMovie.Image, UriKind.Relative));
        }

        public MovieOrTvShowDetailsWindow(TvShow selectedTvShow)
        {
            InitializeComponent();

            //display tv show image and details
            imgTvShow.Source = new BitmapImage(new Uri(selectedTvShow.Image, UriKind.Relative));
        }
    }
}
