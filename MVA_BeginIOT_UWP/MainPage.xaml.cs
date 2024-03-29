﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MVA_BeginIOT_UWP
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

		// do some stuff now that the page has loaded.
		private async void MainPage_Loaded(object sender, RoutedEventArgs e)
		{
			HelloControl.Text = "Hello Earth";

			// turn on webcam and mic to use this in Package.appxmanifest
			MediaCapture capture = new MediaCapture();
			await capture.InitializeAsync();

			CameraCapture.Source = capture;

			await capture.StartPreviewAsync();
		}
	}
}
