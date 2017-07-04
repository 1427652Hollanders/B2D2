using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2D2_Sluis_Controller.Classes
{
    public class Verkeerslicht
    {
        private int TrafficLightGreen { get; set; }
        private int TrafficLightRed { get; set; }
        private int Gate1 { get; set; }
        private int Gate2 { get; set; }

        private bool IsTrafficLightGreen = true;
        private bool IsTrafficLightRed = false;

        //public Verkeerslicht(int red, int green, int sluispoort1, int sluispoort2)
        //{
        //    TrafficLightGreen = green;
        //    TrafficLightRed = red;
        //    SluisPoort = sluispoort1;
        //    SluisPoort = sluispoort2;
        //}


        public void ChangeColor(int GateSide, int TrafficLightColor, int red, int green)
        {
            if (IsTrafficLightRed)
            {
                GateSide = Gate1;
                GateSide = Gate2;
                TrafficLightColor = red;
            }
            else if (IsTrafficLightGreen)
            {
                GateSide = Gate1;
                GateSide = Gate2;
                TrafficLightColor = green;
            }
        }
    }
    // private void WachtEenVaartuig 
    // {
    //     if (IsVerkeerslichtGroen) 
}
