using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace B2D2_Sluis_Controller.Classes
{
    public class Trafficlight
    {
        private Color Trafficlight1color { get; set; }
        private Color Trafficlight2color { get; set; }
        public int SluiceID { get; set; }
        public Color TrafficLightColor { get; set; }

        public Trafficlight()
        {
        }

        public Trafficlight(int sluiceid, Color trafficlightColor)
        {
            SluiceID = sluiceid;
            TrafficLightColor = trafficlightColor;
        }

        public void ChangeTrafficLight(int idofsluice, Color trafficlightColor)
        {
            if (idofsluice == 1)
            {
                ChangeTrafficLight1(trafficlightColor);
            }
            if (idofsluice == 2)
            {
                ChangeTrafficLight2(trafficlightColor);
            }
        }

        private void ChangeTrafficLight1(Color changeColor)
        {
            
        }

        private void ChangeTrafficLight2(Color changeColor)
        {
            
        }
    }

}
