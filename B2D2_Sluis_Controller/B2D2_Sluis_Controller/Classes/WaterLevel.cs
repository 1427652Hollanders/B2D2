using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            // aangeven aan controller dat waterpeil gestegen is.
        }

        public void Waterlevelfalling()
        {
            while (WaterlevelId != 2)
            {
                WaterlevelId--;
                Debug.WriteLine(WaterlevelId + "meter");
                Task.Delay(1000).Wait();
            }
            // aangeven aan controller dat waterpeil gestegen is.

        }
    }
}
