namespace Fox.Models
{
    public class GeneratorOutputModel
    {
        public string FilePath { get; set; }
        public bool IsReportToFileEnabled { get; set; }
        public bool IsReportToEmailEnabled { get; set; }
        public string SendToEmail { get; set; }
    }
}
