using B2D2_Sluis_Controller.Classes;
using System.Collections.Generic;
using Windows.UI.Xaml;

namespace B2D2_Sluis_Controller
{
    public sealed partial class MainPage
    {
        private bool IsSluice1Open { get; set; }
        private bool IsSluice2Open { get; set; }
        private bool IsSluiceRunning { get; set; }
        public int SluicePriority { get; set; }

        private readonly Boat _boat = new Boat();

        public List<Boat> QueSluice1 { get; set; }
        public List<Boat> QueSluice2 { get; set; }

        private List<Boat> BoatsinSluice { get; set; }

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
                TrafficController();
            }
            if (code == "S2NB")
            {
                _boat.AddBoat(2);
                TrafficController();
            }
            if (code == "S1OV")
            {
                //waterpeil
                //OpenSluiceGates(1);
            }
            if (code == "S2OV")
            {
                //waterpijl
                //OpenSluiceGates(2);
            }
            if (code == "S1OG")
            {
                BoatControl();
            }
        }

        private void TrafficController()
        {
            //start new timer
            if (IsSluiceRunning == false)
            {
                if (QueSluice1.Count == 1)
                {
                    SluicePriority = 1;
                    IsSluiceRunning = true;
                }
                if (QueSluice2.Count == 1)
                {
                    SluicePriority = 2;
                    IsSluiceRunning = true;
                }
            }

            if (QueSluice1.Count == 3 && SluicePriority == 1)
            {
                OpenSluiceValves(1);
            }

            if (QueSluice2.Count == 3 && SluicePriority == 2)
            {
                OpenSluiceValves(2);
            }

        }

        private void OpenSluiceValves(int idforsluice)
        {
            var server = new SocketServer(9000);

            if (idforsluice == 1)
            {
                server.VerstuurBerichtIedereen("S1VO");
            }
            if (idforsluice == 2)
            {
                server.VerstuurBerichtIedereen("S2VO");
            }
        }

        private void OpenSluiceGates(int idfofsluice)
        {
            var server = new SocketServer(9000);

            if (idfofsluice == 1)
            {
                server.VerstuurBerichtIedereen("S1OG");
            }
            if (idfofsluice == 2)
            {
                server.VerstuurBerichtIedereen("S2OG");
            }

        }

        private void BoatControl()
        {
            if (SluicePriority == 1)
            {
                
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            RecieveCode("S1NB");
        }
    }
}
