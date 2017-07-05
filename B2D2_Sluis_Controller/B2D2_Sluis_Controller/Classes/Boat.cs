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
        public int ID { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Sluice { get; set; }
        public int Condition { get; set; }
        private Random rnd = new Random();

        string[,] Boats = { { "Zephyr", "2.0 ton", "1" }, { "Jolly Roger", "2.1 ton", "1" }, { "Black Pearl", "1.8 ton", "1" }, { "Reel Time", "2.5 ton", "1" }, { "Dragonfly", "1.4 ton", "1" }, { "Fish Tales", "2.2 ton", "1" }, { "Sea Biscuit", "2.1 ton", "1" }, { "Fantasea", "2.6 ton", "1" }, { "Odyssey", "1.8 ton", "1" }, { "Solitude", "4.0 ton", "1" } };


        public Boat()
        {

        }
        public Boat(int id, string name, int weight, int sluice, int condition)
        {
            ID = id;
            Name = name;
            Weight = weight;
            Sluice = sluice;
            Condition = condition;

        }
        public void AddBoat(int sluiceid)
        {
            var name = "Boot1";
            var frame = (Frame)Window.Current.Content;
            var page = (MainPage)frame.Content;

            if (sluiceid == 1)
            {
                page?.QueSluice1.Add(new Boat {Name = name, Sluice = sluiceid, Weight = rnd.Next(0,200000)});
            }  
             
        }

    
    }
  
}
