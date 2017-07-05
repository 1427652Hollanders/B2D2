using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace B2D2_Sluis_Controller.Classes
{
    class WaterLevel
    {
        public int WaterlevelId = 2;

        public void Waterlevelrising()
        {
            while (WaterlevelId != 7)
            {
                WaterlevelId++;
                Debug.WriteLine(WaterlevelId + "meter");
                Task.Delay(1000).Wait();
            }
            var frame = (Frame) Window.Current.Content;
            var page = (MainPage) frame.Content;
            page?.OpenSluiceGates(2);
        }

        public void Waterlevelfalling()
        {
            while (WaterlevelId != 2)
            {
                WaterlevelId--;
                Debug.WriteLine(WaterlevelId + "meter");
                Task.Delay(1000).Wait();
            }

            var frame = (Frame) Window.Current.Content;
            var page = (MainPage) frame.Content;
            page?.OpenSluiceGates(1);
        }
    }
}