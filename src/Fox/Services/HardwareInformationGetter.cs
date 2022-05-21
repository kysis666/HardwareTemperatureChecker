using Fox.Models;
using Fox.Services.Interfaces;
using Fox.Tools.Interfaces;
using Microsoft.Extensions.Logging;

namespace Fox.Services
{
    public class HardwareInformationGetter : IHardwareInformationGetter
    {
        private readonly ICpuTemperatureChecker _cpuTemperatureChecker;
        private readonly IGpuTemperatureChecker _gpuTemperatureChecker;
        private readonly ILogger<HardwareInformationGetter> _logger;

        public HardwareInformationGetter(ICpuTemperatureChecker cpuTemperatureChecker, IGpuTemperatureChecker gpuTemperatureChecker, ILogger<HardwareInformationGetter> logger)
        {
            _cpuTemperatureChecker = cpuTemperatureChecker;
            _gpuTemperatureChecker = gpuTemperatureChecker;
            _logger = logger;
        }

        public HardwareInformationModel GetHardwareInformation()
        {
            double cpuTemperature = _cpuTemperatureChecker.GetCpuTemperature();
            double gpuTemperature = _gpuTemperatureChecker.GetGpuTemperature();

            return new HardwareInformationModel
            {
                CpuTemperature = cpuTemperature,
                GpuTemperature = gpuTemperature
            };
        }
    }
}
