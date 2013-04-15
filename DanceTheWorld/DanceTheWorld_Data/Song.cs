using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceTheWorld_Data
{
    public class Song
    {
        public int SongID { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Danceability { get; set; }
        public int Year { get; set; }
    }
}
