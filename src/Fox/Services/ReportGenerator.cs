using Fox.Models;
using Fox.Services.Interfaces;
using Fox.Tools.Interfaces;
using Microsoft.Extensions.Logging;

namespace Fox.Services
{
    public class ReportGenerator : IReportGenerator
    {
        private readonly IHardwareInformationGetter _hardwareInformationGetter;
        private readonly ILogger<ReportGenerator> _logger;
        private readonly IStringFileWriter _writer;
        private readonly IReportFormatter _reportFormatter;
        private readonly IConfigService _config;
        private readonly IEmailSender _emailSender;
        public ReportGenerator(IHardwareInformationGetter hardwareInformationGetter,
           ILogger<ReportGenerator> logger,
           IStringFileWriter writer, 
           IReportFormatter reportFormatter, 
           IConfigService config,
           IEmailSender emailSender)
        {
            _hardwareInformationGetter = hardwareInformationGetter;
            _logger = logger;
            _writer = writer;
            _reportFormatter = reportFormatter;
            _config = config;
            _emailSender = emailSender;
        }
        public void Generate()
        {
            _logger.LogInformation("Generating report");
            
            HardwareInformationModel informationModel = _hardwareInformationGetter.GetHardwareInformation();

            if (_config.GeneratorOutputModel.IsReportToFileEnabled == true)
            {
                SaveToFile(informationModel);
            }

            if (_config.GeneratorOutputModel.IsReportToEmailEnabled == true)
            {
                MailMessage(informationModel);
            }
        }
        
        private void SaveToFile(HardwareInformationModel informationModel)
        {
            _logger.LogInformation("Saving report to file");

            string text = _reportFormatter.PlainTextFormat(informationModel);
            _writer.Write(text, _config.GeneratorOutputModel.FilePath);
        }

        private void MailMessage(HardwareInformationModel informationModel)
        {
            _logger.LogInformation("Sending report by email");

            string text = _reportFormatter.HtmlFormat(informationModel);
            _emailSender.Send(_config.GeneratorOutputModel.SendToEmail, text, _config.SmtpConfiguration);
        }
    }
}
