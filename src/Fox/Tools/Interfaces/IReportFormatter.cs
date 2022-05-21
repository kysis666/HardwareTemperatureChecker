using Fox.Models;

namespace Fox.Tools.Interfaces
{
    public interface IReportFormatter
    {
        string PlainTextFormat(HardwareInformationModel informationModel);
        string HtmlFormat(HardwareInformationModel informationModel);
    }
}
