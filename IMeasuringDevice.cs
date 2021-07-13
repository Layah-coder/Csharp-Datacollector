using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector
{
    interface IMeasuringDevice
    {
        void SetUnit(Units unit);
        //Will return a decimal that represents the metric value of the most recent
        //measurement that was captured.
        decimal MetricValue();
        //Will return a decimal that represents the imperial value of the most recent
        //measurement that was captured.
        decimal ImperialValue();
        DateTime TimeStampValue();
        //Will start the device and begin collecting the measurements and record them.
        void StartCollecting();
        //Will stop the device and cease collecting measurements.
        void StopCollecting();
        //Will retrieve a copy of all of the recent data that the measuring device captured. 
        //Will return the data as an array of int values.
        int[] GetRawData();

    }
}
