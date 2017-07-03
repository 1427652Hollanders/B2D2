using B2D2_Sluis_Controller.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2D2_Sluis_Controller.Classes
{
    public class Boat
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Sluice { get; set; }

        public Boat()
        {

        }
        public Boat(int id, string name, int weight, int sluice)
        {
            ID = id;
            Name = name;
            Weight = weight;
            Sluice = sluice;
        }
    }
  
}
