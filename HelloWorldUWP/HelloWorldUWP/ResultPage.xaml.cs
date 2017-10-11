using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HelloWorldUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ResultPage : Page
    {
        public ResultPage()
        {
            this.InitializeComponent();
            calcArea();
        }

        internal void calcArea()
        {
            string widthString = "";
            string heightString = "";
            string colorTint = "";
            ApplicationDataContainer localStorage = ApplicationData.Current.LocalSettings;
            if (localStorage.Values["Width"] != null && localStorage.Values["Height"] != null && localStorage.Values["Tint"] != null)
            {
                widthString = localStorage.Values["Width"].ToString();
                heightString = localStorage.Values["Height"].ToString();
                colorTint = localStorage.Values["Tint"].ToString();
            }
            double width, height, woodLength, glassArea;
            width = double.Parse(widthString);
            height = double.Parse(heightString);
            woodLength = 2 * (width + height) * 3.25;
            glassArea = 2 * (width * height);
            resultTextBlock.Text += "Width: " + width + "\n";
            resultTextBlock.Text += "Height: " + height + "\n";
            resultTextBlock.Text += "Selected Color Tint: " + colorTint + "\n";
            resultTextBlock.Text += "The length of the wood is " + woodLength + " feet\n";
            resultTextBlock.Text += "The area of the glass is " + glassArea + " square metres\n";
            resultTextBlock.Text += "Date Ordered: " + DateTime.Now;
        }

        private void quanitySlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Slider slider = sender as Slider;
            if (slider != null)
            {
                quanityValue.Text = slider.Value.ToString();
            }
        }
    }
}
