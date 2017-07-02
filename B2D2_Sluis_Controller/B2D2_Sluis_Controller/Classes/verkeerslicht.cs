using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2D2_Sluis_Controller.Classes
{
    public class Verkeerslicht
    {
        public int VerkeerslichtGroen { get; set; }
        public int VerkeerslichtRood { get; set; }
        public int VerkeerslichtRechts { get; set; }
        public int VerkeerslichtLinks { get; set; }

        public Verkeerslicht(int rood, int groen, int rechts, int links)
        {
            VerkeerslichtGroen = groen;
            VerkeerslichtRood = rood;
            VerkeerslichtRechts = rechts;
            VerkeerslichtLinks = links;
        }
        private bool IsVerkeerslichtGroen = true;
        private bool IsVerkeerslichtRood = false;
    }
    // private void WachtEenVaartuig
    // {
    //     if (IsVerkeerslichtGroen)
}
