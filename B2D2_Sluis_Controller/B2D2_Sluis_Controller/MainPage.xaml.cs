using B2D2_Sluis_Controller.Classes;
using System;
using System.Collections.Generic;
using System.Threading;
using Windows.UI.Xaml;

namespace B2D2_Sluis_Controller
{
    public sealed partial class MainPage
    {
        private bool IsSluice1Open { get; set; }
        private bool IsSluice2Open { get; set; }
        private int Waterlevel { get; set; }
        private Timer myTimer { get; set; }
        private readonly Boat _boat = new Boat();

        public List<Boat> QueSluice1 { get; set; }
        public List<Boat> QueSluice2 { get; set; }
        private Random rnd = new Random();

        

        public MainPage()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            QueSluice1 = new List<Boat>();
            QueSluice2 = new List<Boat>();

            IsSluice1Open = true;
            IsSluice2Open = false;

            var server = new SocketServer(9000);
            server.OnDataOntvangen += server.Server_OnDataOntvangen;

         
        }

        public void RecieveCode(string code)
        {
            if (code == "S1NB")
            {
                _boat.AddBoat(1);

            }
            if (code == "S2NB")
            {
                //Nieuwe boot voor QueSluice2
            }

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            RecieveCode("S1NB");
        }   
    }
}
