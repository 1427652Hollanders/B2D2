/************************************************
 * Author: Rianne Boumans                       *
 * Zuyd Hogeschool; B2D2                        *
 * Date: 01-2017                                *
 *                                              *
 * B2D2 Example project                         *                                                      
 * WifiCommunication between 2 Raspberries      *
 * Based on project from Dion, Wouter and Tim   *
 ************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace B2D2_Sluis_Controller
{
    public class SocketServer
    {
        //Poortnummer waar de server op luistert (zie constructor)
        private readonly int _port;
        //Listner die luistert voor nieuwe data op de meegegeven poort        
        private StreamSocketListener listener;

        public delegate void DataOntvangenDelegate(string data);

        public DataOntvangenDelegate OnDataOntvangen;

        private List<SocketClient> teams;
        private List<string> teamIP = new List<string>();

        /// <summary>
        /// Initialiseer en start de server
        /// </summary>
        /// <param name="port"></param>
        public SocketServer(int port)
        {
            teams = new List<SocketClient>();
            _port = port;
            Start();
        }

        /// <summary>
        /// Start de listner die luistert naar inkomende connecties
        /// </summary>
        public async void Start()
        {
            listener = new StreamSocketListener();
            listener.ConnectionReceived += Listener_ConnectionReceived;

            Debug.WriteLine("Wacht op connecties..");
            await listener.BindServiceNameAsync(_port.ToString());
        }

        /// <summary>
        /// Zodra een bericht binnen komt, wordt via de listner deze methode aangeroepen.
        /// </summary>
        /// <param name="bericht"></param>
        public async void Server_OnDataOntvangen(string bericht)
        {
            IPAddress addr;
            if (IPAddress.TryParse(bericht, out addr))
            {
                Debug.WriteLine("Bericht ontvangen van ip: " + bericht);
                //Als hij niet in de lijst voorkomt, is het een nieuw team
                Task.Delay(150).Wait();
                if (!teamIP.Contains(bericht))
                {
                    teamIP.Add(bericht);
                    SocketClient tmp = new SocketClient(bericht, 9000);
                    teams.Add(tmp);
                    VerstuurBerichtIedereen("Team " + teams.Count.ToString() + " doet mee!");

                    Debug.WriteLine("Team " + teams.Count.ToString() + " doet mee!");
                }
                else
                {
                    Debug.WriteLine("IP adres heeft al connectie, niks mee doen");
                }
            }
            else
            {
                Debug.WriteLine("Bericht ontvangen van een Team: " + bericht);


                await SentMessageBack(bericht);
            }
        }

        private async Task SentMessageBack(string bericht)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                () =>
                {
                    var frame = (Frame)Window.Current.Content;
                    var page = (MainPage)frame.Content;
                    page?.OntvangCode(bericht);
                }

            );
        }

        /// <summary>
        /// Zodra de listner een nieuwe connectie binnen krijgt, wordt deze methode aangeroepen
        /// Deze zal het bericht controleren op compleetheid en daarna doorsturen naar de OnDataOntvangen methode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public async void Listener_ConnectionReceived(StreamSocketListener sender,
            StreamSocketListenerConnectionReceivedEventArgs args)
        {
            var reader = new DataReader(args.Socket.InputStream);
            try
            {
                while (true)
                {
                    uint sizeFieldCount = await reader.LoadAsync(sizeof(uint));
                    if (sizeFieldCount != sizeof(uint)) return; //Disconnect
                    uint stringLength = reader.ReadUInt32();
                    uint actualStringLength = await reader.LoadAsync(stringLength);
                    if (stringLength != actualStringLength) return; //Disconnect

                    //Zodra data binnen is en er is een functie gekoppeld aan het event:                    
                    if (OnDataOntvangen != null)
                    {
                        //Trigger het event, zodat er iets gedaan wordt met de ontvangen data
                        OnDataOntvangen(reader.ReadString(actualStringLength));
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// In dit geval wordt hetzelfde bericht gestuurd naar iedere socket die aangemeld wordt bij de server
        /// </summary>
        /// <param name="bericht">Het te versturen bericht</param>
        public void VerstuurBerichtIedereen(string bericht)
        {
            foreach (SocketClient sc in teams)
            {
                if (sc != null) sc.Verstuur(bericht);
            }
        }
    }
}