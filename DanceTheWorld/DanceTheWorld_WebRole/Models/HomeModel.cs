using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanceTheWorld_WebRole.Models
{
    public class Claster
    {
        public int Weight { get; set; }
        public int Size { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }

    public class HomeModel
    {
        public string SongsMarkers { get; set; }
    }
}