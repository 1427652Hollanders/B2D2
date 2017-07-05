using B2D2_Sluis_Controller.Classes;
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
    public class Boat
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Sluice { get; set; }
        private Random rnd = new Random();
        private int boatcount = 0;

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
            boatcount = boatcount + 1;
            var name = "Boot" + boatcount;
            var frame = (Frame) Window.Current.Content;
            var page = (MainPage) frame.Content;

            if (sluiceid == 1)
            {
                page?.QueSluice1.Add(new Boat {Name = name, Sluice = sluiceid, Weight = rnd.Next(0, 200000)});
                Debug.WriteLine("Er vaart een boot naar sluis " + sluiceid);
            }
            if (sluiceid == 2)
            {
                page?.QueSluice2.Add(new Boat {Name = name, Sluice = sluiceid, Weight = rnd.Next(0, 200000)});
                Debug.WriteLine("Er vaart een boot naar sluis " + sluiceid);
            }
        }

        public void BoatLeavesGate()
        {
            var frame = (Frame) Window.Current.Content;
            var page = (MainPage) frame.Content;

            if (page != null)
                foreach (var boat in page.BoatsinSluice)
                {
                    Debug.WriteLine("Boot: "+ boat.Name + ". met gewicht: "+boat.Weight + ". Verlaat de sluis " + boat.Sluice +" nu");
                }
        }
    }
}