using Fox.Services;
using Fox.Services.Interfaces;
using Fox.Tools;
using Fox.Tools.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fox.Configs
{
    public static class ApplicationServicesConfig
    {
        public static void ConfigureServices(ServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IReportGenerator, ReportGenerator>();
            services.AddTransient<IStringFileWriter, StringFileWriter>();
            services.AddTransient<IHardwareInformationGetter, HardwareInformationGetter>();
            services.AddTransient<ICpuTemperatureChecker, CpuTemperatureChecker>();
            services.AddTransient<IGpuTemperatureChecker, GpuTemperatureChecker>();
            services.AddTransient<IHardwareInformationGetter, HardwareInformationGetter>();
            services.AddTransient<IReportFormatter, ReportFormatter>();
            services.AddTransient<IConfigService, ConfigService>();
            services.AddTransient<IEmailSender, EmailSender>();
        }
    }
}
