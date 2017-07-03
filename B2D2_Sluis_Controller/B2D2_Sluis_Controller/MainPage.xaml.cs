using B2D2_Sluis_Controller.Classes;
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
            var server = new SocketServer(9000);
            server.OnDataOntvangen += server.Server_OnDataOntvangen;
        }
    }
}
