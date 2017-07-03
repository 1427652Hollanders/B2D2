
using System.Collections.Generic;
using Windows.Devices.Gpio;

namespace B2D2_Sluis_Controller
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            var server = new SocketServer(9000);
            server.OnDataOntvangen += server.Server_OnDataOntvangen;
        }
    }
}
