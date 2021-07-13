using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI;
using System.Text;
/*
4/4/2021 
Leah Oswald
Program that generates random measurements and allows user to convert them to metric or imperial.
Also, program stores some of the past data in an array.
*/

namespace DataCollector
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MeasureLengthDevice measureDevice = null;
        

        public MainPage()
        {
            this.InitializeComponent();
            measureDevice = new MeasureLengthDevice();
        }

        private void startClick(object sender, RoutedEventArgs e)
        {
            if ((bool)imperialRadioButton.IsChecked)
            {
                measureDevice.SetUnit(Units.Imperial);
                measureDevice.StartCollecting();
            }
            if ((bool)metricRadioButton.IsChecked)
            {
                measureDevice.SetUnit(Units.Metric);
                measureDevice.StartCollecting();

            }
        }

        private void stopClick(object sender, RoutedEventArgs e)
        {
            measureDevice.StopCollecting();
        }

        private void currentMeasurementClick(object sender, RoutedEventArgs e)
        {
            if ((bool)imperialRadioButton.IsChecked)
            {
                measureDevice.SetUnit(Units.Imperial);
                resultLabel.Text = measureDevice.MetricValue().ToString() + " in.";
            }
            if ((bool)metricRadioButton.IsChecked)
            {
                measureDevice.SetUnit(Units.Metric);
                resultLabel.Text = measureDevice.MetricValue().ToString() + " cm.";
            }
            
            timeStampLabel.Text = measureDevice.TimeStampValue().ToString();
        }

        private void historyButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder myString = new StringBuilder();
            int []dataHistory = measureDevice.GetRawData();
            foreach(int i in dataHistory)
            {
                myString.AppendLine(i.ToString());
            }
            historyText.Text = myString.ToString();
        }

    }
}
