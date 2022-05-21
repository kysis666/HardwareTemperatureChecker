using Fox.Models;
using Fox.Tools.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Fox.Tools
{
    public class ConfigService : IConfigService
    {
        private readonly IConfiguration _config;
        public GeneratorOutputModel GeneratorOutputModel => _config.GetSection("Output").Get<GeneratorOutputModel>();
        public SmtpConfiguration SmtpConfiguration => _config.GetSection("Smtp").Get<SmtpConfiguration>();
        public ConfigService(IConfiguration config)
        {
            _config = config;
        }
    }
}
