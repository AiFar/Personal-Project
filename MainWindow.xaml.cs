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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.IO;

namespace OODStarterCode_Feb20_2023
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Movie> movieList;

        List<TvShow> tvShowList;

        public MainWindow()
        {
            InitializeComponent();
 
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           movieList = new List<Movie>
        {   new Movie("Cocaine Bear", new DateTime(2023, 03, 03), "A story about a bear who ingested large amounts of cocaine that was dropped from a plane by a drug smuggler.", new List<string> { "Elizabeth Banks", "Margo Martindale", "Kiersey Clemons" }, 3, "stars", "/movieImages/CocainBear.jpg"),
            new Movie("Creed III", new DateTime(2023), "The third installment in the Rocky franchise spinoff series, following the life and career of Adonis Creed.", new List<string> { "Michael B. Jordan", "Sylvester Stallone", "Tessa Thompson" }, 4, "stars", "/movieImages/Creed3.jpg"),
            new Movie("M3gan", new DateTime(2023),  "A thriller about a female hacker who begins to torment a corporate lawyer after he gains access to an artificial intelligence program.", new List<string> { "Kate Mara", "Ramón Rodríguez", "Jordi Mollà" }, 3, "stars", "/movieImages/m3gan.jpg"),
            new Movie("Avatar: The Way of Water", new DateTime(2022), "The long-awaited sequel to Avatar, which takes place underwater on the alien world of Pandora.", new List<string> { "Sam Worthington", "Zoe Saldana", "Sigourney Weaver" }, 4, "stars", "/movieImages/avatar.jpg"),
            new Movie("Ant-Man", new DateTime(2015),  "A superhero film about a man who can shrink in size and gain strength while retaining his human-level intellect, created by Marvel Comics.", new List<string> { "Paul Rudd", "Evangeline Lilly", "Michael Douglas" }, 4, "stars", "/movieImages/antman.jpg")
        };
           tvShowList = new List<TvShow>
        {
            new TvShow("The Last of Us", new DateTime(2023), "An upcoming post-apocalyptic TV series based on the video game of the same name, following a smuggler and a teenage girl who must navigate a world ravaged by a deadly pandemic.", new List<string> { "Pedro Pascal", "Bella Ramsey", "Gabriel Luna" }, 4, "stars", "/tvshowImages/tlou.jpg"),
            new TvShow("House of the Dragon", new DateTime(2022),  "An upcoming prequel to Game of Thrones, following the Targaryen family's rise to power in Westeros.", new List<string> { "Paddy Considine", "Olivia Cooke", "Matt Smith" }, 4, "stars", "/tvshowImages/hotd.jpg"),
            new TvShow("Game of Thrones", new DateTime(2011),  "A fantasy drama television series based on George R. R. Martin's series of novels A Song of Ice and Fire, following the violent struggles among noble families for control of the Iron Throne of the Seven Kingdoms.", new List<string> { "Emilia Clarke", "Kit Harington", "Peter Dinklage" }, 5, "stars", "/tvshowImages/got.jpg"),
            new TvShow("You", new DateTime(2018),  "A psychological thriller TV series about a bookstore manager who becomes obsessed with a woman and starts stalking her.", new List<string> { "Penn Badgley", "Victoria Pedr" + " etti", "Jenna Ortega" }, 4, "stars", "/tvshowImages/you.jpg"),
            new TvShow("Luther", new DateTime(2010), "A British crime drama TV series about a brilliant but emotionally impulsive detective who solves murders while battling his own inner demons.", new List<string> { "Idris Elba", "Ruth Wilson", "Dermot Crowley" }, 5, "stars", "/tvshowImages/luther.jpg"),
        };

        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            lbxResults.ItemsSource = movieList;

        }

        private void RbTvshows_Click(object sender, RoutedEventArgs e)
        {
            lbxResults.ItemsSource = tvShowList;
        }

        private void lbxResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // get selected item
            object selectedItem = lbxResults.SelectedItem;

            if (selectedItem is Movie selectedMovie)
            {
                // display movie image
                imgMovie.Source = new BitmapImage(new Uri(selectedMovie.Image, UriKind.Relative));
                imgTvShow.Source = null;
                lblReleaseDate.Content = selectedMovie.ReleaseDate.ToString("dd-MM-yyyy");
            }
            else if (selectedItem is TvShow selectedTvShow)
            {
                // display tv show image
                imgTvShow.Source = new BitmapImage(new Uri(selectedTvShow.Image, UriKind.Relative));
                imgMovie.Source = null;
                lblReleaseDate.Content = selectedTvShow.ReleaseDate.ToString("dd-MM-yyyy");
            }
            else
            {
                // clear both images if no selection
                imgMovie.Source = null;
                imgTvShow.Source = null;
                lblReleaseDate.Content = "";
            }
        }

        private void btnSelected_Click(object sender, RoutedEventArgs e)
        {
            // get selected item from list box
            object selectedItem = lbxResults.SelectedItem;

            if (selectedItem is Movie selectedMovie)
            {
                // create new window to display movie details
                var movieDetailsWindow = new MovieOrTvShowDetailsWindow(selectedMovie);
                movieDetailsWindow.Show();
            }
            else if (selectedItem is TvShow selectedTvShow)
            {
                // create new window to display TV show details
                var tvShowDetailsWindow = new MovieOrTvShowDetailsWindow(selectedTvShow);
                tvShowDetailsWindow.Show();
            }
        }

        private void btnSaveJSON_Click(object sender, RoutedEventArgs e)
        {
            //if time later come back and add multiple selection
            
            object selectedItem = lbxResults.SelectedItem;

            if (selectedItem is Movie selectedMovie)
            {
                string movieInfo = Newtonsoft.Json.JsonConvert.SerializeObject(selectedMovie);
                using (StreamWriter sw = new StreamWriter(@"c:\temp\movie.json"))
                {
                    sw.Write(movieInfo);
                }
            }
            else if (selectedItem is TvShow selectedTvShow)
            {

            }

        }
    }
}
