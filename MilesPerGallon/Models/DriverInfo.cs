using System;
using System.Collections.Generic;

namespace MilesPerGallon
{
    public partial class DriverInfo
    {

        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string CarModel { get; set; }
        public double MilesDriven { get; set; }
        public int GallonsFilled { get; set; }
        public DateTime FillupDate { get; set; }
    }
}
