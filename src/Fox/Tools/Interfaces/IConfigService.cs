using Fox.Models;

namespace Fox.Tools.Interfaces
{
    public interface IConfigService
    {
        GeneratorOutputModel GeneratorOutputModel { get; }
        SmtpConfiguration SmtpConfiguration { get; }
    }
}
