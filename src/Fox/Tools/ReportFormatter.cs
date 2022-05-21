using Fox.Models;
using Fox.Tools.Interfaces;
using System;

namespace Fox.Tools
{
    public class ReportFormatter : IReportFormatter
    {
        public string PlainTextFormat(HardwareInformationModel informationModel)
        {
            string cpuText = $"Cpu temperature: {informationModel.CpuTemperature}°C";
            string gpuText = $"Gpu temperature: {informationModel.GpuTemperature}°C";

            return $"{DateTime.Now.ToString("HH:mm dd-MM-yyyy")}\n{cpuText}\n{gpuText}\n\n";
        }

        public string HtmlFormat(HardwareInformationModel informationModel)
        {
            string cpuText = $"<p>Cpu temperature: {informationModel.CpuTemperature}°C</p>";
            string gpuText = $"<p>Gpu temperature: {informationModel.GpuTemperature}°C</p>";

            return $"<html><body>{DateTime.Now.ToString("HH:mm dd-MM-yyyy")}<br>{cpuText}{gpuText}</body></html>";
        }
    }
}
