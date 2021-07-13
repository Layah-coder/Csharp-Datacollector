using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace DataCollector
{
    //Public class that holds get method.
    class Device
    {
        private Timer timer;
        private DateTime dateTime;
        private int data = 0;
       
        //Create random object.
        Random random = new Random();

        public Device()
        {
            //Runs timer_tick method every second.
            timer = new Timer(timer_Tick, null, (int)TimeSpan.FromSeconds(1).TotalMilliseconds, (int)TimeSpan.FromSeconds(1).TotalMilliseconds);
        }
        //runs when timer executes
        private async void timer_Tick(object state)
        {
            //code to randomly generate a new value and update GetMeasurement
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                //Call Random Next method and assign to int variable randomMeasurement.
                data = random.Next(1, 11);
                dateTime = DateTime.Now; 
            });
        }
        //Will return a random number between 1 to 10 to create an imaginary objects measurement.
        public int GetMeasurement => data;
        public DateTime GetTimeStamp => dateTime;

    }
}
