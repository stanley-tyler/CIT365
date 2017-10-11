using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HelloWorldUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            MediaElement mediaElement = new MediaElement();
            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync("Hello, World!");
            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();
        }

        internal void calcAreaButton(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer localStorage = ApplicationData.Current.LocalSettings;
            localStorage.Values["Width"] = widthTextBox.Text;
            localStorage.Values["Height"] = heightTextBox.Text;
            localStorage.Values["Tint"] = ((ContentControl)colorTint.SelectedItem).Content.ToString();
            this.Frame.Navigate(typeof(ResultPage), null);
        }


        private async void ValidateWidthInput(object sender, KeyRoutedEventArgs e)
        {
            int keyValue = (int)e.Key;
            if (keyValue >= 0x41 && keyValue <= 0x5A)
            {
                heightTextBox.Text = "";
                var dialog = new MessageDialog("Please enter numbers only");
                await dialog.ShowAsync();
            }
            

        }

        private async void ValidateHeightInput(object sender, KeyRoutedEventArgs e)
        {
            int keyValue = (int)e.Key;
            if (keyValue >= 0x41 && keyValue <= 0x5A)
            {
                widthTextBox.Text = "";
                var dialog = new MessageDialog("Please enter numbers only");
                await dialog.ShowAsync();
            }

        }
        
    }
}
