using B2D2_Sluis_Controller.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace B2D2_Sluis_Controller.Classes
{
    public class Boat
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Sluice { get; set; }
        private Random rnd = new Random();

       

        public Boat()
        {

        }
        public Boat(string name, int weight, int sluice)
        {
            Name = name;
            Weight = weight;
            Sluice = sluice;
        }
        public void AddBoat(int sluiceid)
        {
            rnd.Next(0, 3);
            var name = "Boot1";
            var frame = (Frame)Window.Current.Content;
            var page = (MainPage)frame.Content;

            if (sluiceid == 1)
            {
                page.QueSluice1.Add(new Boat {Name = "Boot1", Weight = rnd.Next(0,200000)});
            }  
             
        }
    }
  
}
