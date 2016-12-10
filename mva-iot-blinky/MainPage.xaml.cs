using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Gpio;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace mva_iot_blinky
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

			Loaded += MainPage_Loaded;
        }

		GpioPin pin;

		private void MainPage_Loaded(object sender, RoutedEventArgs e)
		{
			var controller = GpioController.GetDefault();
			// could ask for the lightening provider if you wanted, which is for fast stuff

			pin = controller.OpenPin(26);
			pin.SetDriveMode(GpioPinDriveMode.Output);
			pin.Write(GpioPinValue.Low);
		}

		private void ToggleLed_Checked(object sender, RoutedEventArgs e)
		{
			pin.Write(GpioPinValue.High);
		}

		private void ToggleLed_Unchecked(object sender, RoutedEventArgs e)
		{
			pin.Write(GpioPinValue.Low);
		}
	}
}
