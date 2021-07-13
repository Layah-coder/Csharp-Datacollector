using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DataCollector
{
    class MeasureLengthDevice : IMeasuringDevice
    {
        Device myDevice = new Device();

        //User input will determine whether the generated measurements are interpreted in metric or imperial.
        private Units unitsToUse;
        //Will store a history of a limited set of recently captured measurements.
        //When full, class will overwrite the oldest element and record new one.
        private int[] dataCaptured;
        //Will hold most recent measurement to display.
        private int mostRecentMeasure;
        private Timer timer;
        private DateTime dateTime;
        private int index = 0;

        //Constructor that initializes fields of MeasureLengthDevice class and assigns them to local variables.
        public MeasureLengthDevice()
        {
            this.unitsToUse = Units.Imperial;
            this.dataCaptured = new int[10];
            this.mostRecentMeasure = 0;

        }

        //Set units according to user input.
        public void SetUnit(Units unit)
        {
            unitsToUse = unit;
        }


        public int[] GetRawData()
        {
            return dataCaptured;
        }

        public decimal ImperialValue()
        {
            if (unitsToUse.Equals(Units.Imperial))
            {
                decimal inches = mostRecentMeasure;
                const decimal multiplier = 2.54M;
                //Convert from Inches to Centimeters.
                //Use Decimal method for multiplication and assign to variable convertedValue.
                decimal convertedValue = inches * multiplier;
                return convertedValue;
            }
            return mostRecentMeasure;
        }


        public decimal MetricValue()
        {
            if (unitsToUse.Equals(Units.Metric))
            {
                decimal centimeters = mostRecentMeasure;
                const decimal divider = 2.54M;
                //Convert from Centimeters to Inches.
                //Use Decimal method for division and assign to variable convertedValue.
                decimal convertedValue = centimeters / divider;
                return convertedValue;
            }
            return mostRecentMeasure;

        }

        public DateTime TimeStampValue()
        {
            return dateTime;
        }

        public void StartCollecting()
        {
            //Start a timer(using System.Windows.Threading.DispatcherTimer) to perform a data capture every 15 seconds.
            //The timer will call an EventHandler(hooked up to the Tick event) which should set mostRecentMeasurewith a new value fromDevice.
            //GetMeasurement() and add that value to the dataCaptured history array.Each time this event occurs, you will also need to update
            //your form by displaying the new measurement along with a current time stamp.
            //Should your device also capture a value before the first 15 second interval has elapsed?
            timer = new Timer(timer_Tick, null, (int)TimeSpan.FromSeconds(1).TotalMilliseconds, (int)TimeSpan.FromSeconds(15).TotalMilliseconds);
        }

        private async void timer_Tick(object state)
        {

            //code to randomly generate a new value and update GetMeasurement
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                index = index % 10;
                mostRecentMeasure = myDevice.GetMeasurement;
                dateTime = myDevice.GetTimeStamp;
                dataCaptured[index++] = mostRecentMeasure;

            });
        }
        public void StopCollecting()
        {
            //Stop the timer that started in StartCollecting()
            timer.Dispose();
        }
    }
}

