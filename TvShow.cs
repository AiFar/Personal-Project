using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODStarterCode_Feb20_2023
{
    public class TvShow
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Cast { get; set; }
        public int Rating { get; set; }
        public string Stars { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Image { get; set; }


        public TvShow(string name, DateTime releaseDate, string description, List<string> cast, int rating, string stars)
        {
            Name = name;
            ReleaseDate = releaseDate;
            Description = description;
            Cast = cast;
            Stars = stars;
            Rating = rating;
        }

        public TvShow(string name, DateTime releaseDate, string description, List<string> cast, int rating, string stars, string image)
        {
            Name = name;
            ReleaseDate = releaseDate;
            Description = description;
            Cast = cast;
            Rating = rating;
            Stars = stars;
            Image = image;
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
