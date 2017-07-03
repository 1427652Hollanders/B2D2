using B2D2_Sluis_Controller.Classes;
using System.Collections.Generic;

namespace B2D2_Sluis_Controller
{
    public sealed partial class MainPage
    {
        private bool IsSluice1Open { get; set; }
        private bool IsSluice2Open { get; set; }
        private int Waterlevel { get; set; }

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

            IsSluice1Open = true;
            IsSluice2Open = false;

            var server = new SocketServer(9000);
            server.OnDataOntvangen += server.Server_OnDataOntvangen;
        }

        public void RecieveCode(string code)
        {
            if (code == "S1NB")
            {
                //Nieuwe boot voor QueSluice1
            }
            if (code == "S2NB")
            {
                //Nieuwe boot voor QueSluice2
            }

        }
    }
}
