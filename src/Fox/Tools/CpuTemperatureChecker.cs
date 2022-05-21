using Fox.Tools.Interfaces;
using System;
using System.Management;

namespace Fox.Tools
{
    public class CpuTemperatureChecker : ICpuTemperatureChecker
    {
        public double GetCpuTemperature()
        {
            double temperature = 0;

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(
                "root\\WMI",
                "SELECT * FROM MSAcpi_ThermalZoneTemperature");

            ManagementObjectCollection.ManagementObjectEnumerator enumerator = searcher.Get().GetEnumerator();

            while (enumerator.MoveNext())
            {
                ManagementBaseObject tempObject = enumerator.Current;
                temperature = ((Convert.ToDouble(tempObject["CurrentTemperature"]) - 2732) / 10);
            }

            return temperature;
        }
    }
}
