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
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;

namespace B2D2_Sluis_Controller
{
    public class SocketClient
    {
        //IP adress van de Client die geconnect is
        private readonly string _ip;
        //Poort waar de client op luistert
        private readonly int _port;
        private StreamSocket _socket;
        private DataWriter _writer;

        public string Ip { get { return _ip; } }
        public int Port { get { return _port; } }

        /// <summary>
        /// Initialiseer client en maak verbinding met de server
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public SocketClient(string ip, int port)
        {
            _ip = ip;
            _port = port;
            Task.Run(() => Connect()).Wait();            
        }

        /// <summary>
        /// Open een StreamSocket om data te kunnen versturen naar deze client.
        /// </summary>
        public async void Connect()
        {            
            try
            {
                var hostName = new HostName(Ip);
                _socket = new StreamSocket();
                await _socket.ConnectAsync(hostName, Port.ToString());
                _writer = new DataWriter(_socket.OutputStream);
                Task.Delay(1000).Wait();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Verstuur het bericht van de server naar deze client
        /// </summary>
        /// <param name="message">Bericht dat verstuurd moet worden</param>
        public async void Verstuur(string message)
        {
            if (_writer != null)
            {
                _writer.WriteUInt32(_writer.MeasureString(message));
                _writer.WriteString(message);

                try
                {
                    await _writer.StoreAsync();
                    await _writer.FlushAsync();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            else
            {
                Debug.WriteLine("No Connection..");
            }
        }

        public void Close()
        {
            _writer.DetachStream();
            _writer.Dispose();

            _socket.Dispose();
        }
    }
}
