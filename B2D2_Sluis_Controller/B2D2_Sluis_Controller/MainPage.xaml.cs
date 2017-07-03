using B2D2_Sluis_Controller.Classes;
using System;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using Windows.UI.Xaml.Controls;
using System.Collections.Generic;

namespace B2D2_Sluis_Controller
{
    public sealed partial class MainPage
    {

        private List<Boat> QueSluice1 { get; set; }
        private List<Boat> QueSluice2 { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            QueSluice1 = new List<Boat>();
            QueSluice2 = new List<Boat>();
        }
    }
}
