using Fox.Tools.Interfaces;
using NvAPIWrapper.GPU;

namespace Fox.Tools
{
    public class GpuTemperatureChecker : IGpuTemperatureChecker
    {
        public double GetGpuTemperature()
        {
            double temperature = 0;

            PhysicalGPU[] gpus = PhysicalGPU.GetPhysicalGPUs();

            foreach (PhysicalGPU gpu in gpus)
            {
                foreach (GPUThermalSensor sensor in gpu.ThermalInformation.ThermalSensors)
                {
                    temperature = sensor.CurrentTemperature;
                }
            }

            return temperature;
        }
    }
}
