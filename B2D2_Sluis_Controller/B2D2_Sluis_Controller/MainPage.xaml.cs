using B2D2_Sluis_Controller.Classes;
using Inleveropdracht2;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace B2D2_Sluis_Controller
{
    public sealed partial class MainPage : Page
    {
        string[] letters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        int letterInput;

        private const int enablePin = 16;
        private const int RWPin = 5;
        private const int registerSelectPin = 20;
        private const int dataPin07 = 6;
        private const int dataPin08 = 13;
        private const int dataPin09 = 19;
        private const int dataPin10 = 26;
        private const int dataPin11 = 22;
        private const int dataPin12 = 27;
        private const int dataPin13 = 4;
        private const int dataPin14 = 17;

        private const int RpiButton1PinNumber = 8;
        private const int RpiButton2PinNumber = 7;

        private GpioPin gpioButton1;
        private GpioPin gpioButton2;
        
        private GpioController gpioController;

        private LCDLibrary lcd = new LCDLibrary();

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

            for (;;)
            {
                Run();
            }
        }

        private void Init()
        {
            QueSluice1 = new List<Boat>();
            QueSluice2 = new List<Boat>();

            IsSluice1Open = true;
            IsSluice2Open = false;

            var server = new SocketServer(9000);
            server.OnDataOntvangen += server.Server_OnDataOntvangen;

            lcd.Init(registerSelectPin, RWPin, enablePin, dataPin14, dataPin13, dataPin12, dataPin11, dataPin10, dataPin09, dataPin08, dataPin07);
            Task.Delay(5).Wait();

            gpioController = GpioController.GetDefault();
            letterInput = 0;

            gpioButton1 = gpioController.OpenPin(RpiButton1PinNumber);
            gpioButton1.SetDriveMode(GpioPinDriveMode.InputPullUp);
            gpioButton1.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            gpioButton1.ValueChanged += gpioButton1_ValueChanged;

            gpioButton2 = gpioController.OpenPin(RpiButton2PinNumber);
            gpioButton2.SetDriveMode(GpioPinDriveMode.InputPullUp);
            gpioButton2.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            gpioButton2.ValueChanged += gpioButton2_ValueChanged;
        }

        public void Run()
        {
            {
                

            }
        }

        private void gpioButton1_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs e)
        {
            if (e.Edge == GpioPinEdge.FallingEdge)
            {
                lcd.ClearDisplay();
                Task.Delay(5).Wait();
                letterInput++;
                lcd.WriteLine(letters[letterInput]);
            }
        }

        private void gpioButton2_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs e)
        {
            if (e.Edge == GpioPinEdge.FallingEdge)
            {
                lcd.ClearDisplay();
                Task.Delay(5).Wait();
                letterInput--;
                lcd.WriteLine(letters[letterInput]);
            }
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

