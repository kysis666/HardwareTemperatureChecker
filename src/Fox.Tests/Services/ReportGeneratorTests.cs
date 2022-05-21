using FakeItEasy;
using Fox.Models;
using Fox.Services;
using Fox.Services.Interfaces;
using Fox.Tools.Interfaces;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Fox.Tests.Services
{
    [TestFixture]
    public class ReportGeneratorTests
    {
        private IHardwareInformationGetter _informationGetter;
        private ILogger<ReportGenerator> _logger;
        private IStringFileWriter _writer;
        private IReportFormatter _reportFormatter;
        private IConfigService _config;
        private IEmailSender _emailSender;

        private ReportGenerator _sut;
        [SetUp]
        public void Setup()
        {
            _informationGetter = A.Fake<IHardwareInformationGetter>();
            _logger = A.Fake<ILogger<ReportGenerator>>();
            _writer = A.Fake<IStringFileWriter>();
            _reportFormatter = A.Fake<IReportFormatter>();
            _config = A.Fake<IConfigService>();
            _emailSender = A.Fake<IEmailSender>();

            _sut = new ReportGenerator(_informationGetter, _logger, _writer, _reportFormatter, _config, _emailSender);
        }

        [Test]
        public void Generate_ReportFileFlagsTrue_PlainTextFormatHappend()
        {
            //Arrange
            var outputModel = new GeneratorOutputModel()
            {
                IsReportToFileEnabled = true
            };

            A.CallTo(() => _config.GeneratorOutputModel).Returns(outputModel);

            //Act
            _sut.Generate();

            //Assert
            A.CallTo(() => _reportFormatter
                .PlainTextFormat(A<HardwareInformationModel>.Ignored))
                .MustHaveHappened();
        }

        [Test]
        public void Generate_ReportToFileFlagsFalse_PlainTextFormatNotHappend()
        {
            //Arrange
            var outputModel = new GeneratorOutputModel()
            {
                IsReportToFileEnabled = false
            };

            A.CallTo(() => _config.GeneratorOutputModel).Returns(outputModel);

            //Act
            _sut.Generate();

            //Assert
            A.CallTo(() => _reportFormatter
                .PlainTextFormat(A<HardwareInformationModel>.Ignored))
                .MustNotHaveHappened();
        }

        [Test]
        public void Generate_ReportToEmailFlagsTrue_HtmlFormatHappend()
        {
            //Arrange
            var outputModel = new GeneratorOutputModel()
            {
                IsReportToEmailEnabled = true
            };

            A.CallTo(() => _config.GeneratorOutputModel).Returns(outputModel);

            //Act
            _sut.Generate();

            //Assert
            A.CallTo(() => _reportFormatter
                .HtmlFormat(A<HardwareInformationModel>.Ignored))
                .MustHaveHappened();
        }

        [Test]
        public void Generate_ReportToEmailFlagsFalse_HtmlFormatNotHappend()
        {
            //Arrange
            var outputModel = new GeneratorOutputModel()
            {
                IsReportToEmailEnabled = false
            };

            A.CallTo(() => _config.GeneratorOutputModel).Returns(outputModel);

            //Act
            _sut.Generate();

            //Assert
            A.CallTo(() => _reportFormatter
                .HtmlFormat(A<HardwareInformationModel>.Ignored))
                .MustNotHaveHappened();
        }

        [Test]
        public void Generate_ReportToEmailFlagsTrue_EmailSenderHappend()
        {
            //Arrange
            var outputModel = new GeneratorOutputModel()
            {
                IsReportToEmailEnabled = true
            };

            A.CallTo(() => _config.GeneratorOutputModel).Returns(outputModel);

            //Act
            _sut.Generate();

            //Assert
            A.CallTo(() => _emailSender
                .Send(A<string>.Ignored, A<string>.Ignored, A<SmtpConfiguration>.Ignored))
                .MustHaveHappened();
        }

        [Test]
        public void Generate_ReportToEmailFlagsFalse_EmailSenderNotHappend()
        {
            //Arrange
            var outputModel = new GeneratorOutputModel()
            {
                IsReportToEmailEnabled = false
            };

            A.CallTo(() => _config.GeneratorOutputModel).Returns(outputModel);

            //Act
            _sut.Generate();

            //Assert
            A.CallTo(() => _emailSender
                .Send(A<string>.Ignored, A<string>.Ignored, A<SmtpConfiguration>.Ignored))
                .MustNotHaveHappened();
        }

        [Test]
        public void Generate_ReportToFileFlagsTrue_FileWriterHappend()
        {
            //Arrange
            var outputModel = new GeneratorOutputModel()
            {
                IsReportToFileEnabled = true
            };

            A.CallTo(() => _config.GeneratorOutputModel).Returns(outputModel);

            //Act
            _sut.Generate();

            //Assert
            A.CallTo(() => _writer
                .Write(A<string>.Ignored, A<string>.Ignored))
                .MustHaveHappened();
        }

        [Test]
        public void Generate_ReportToFileFlagsFalse_FileWriterNotHappend()
        {
            //Arrange
            var outputModel = new GeneratorOutputModel()
            {
                IsReportToFileEnabled = false
            };

            A.CallTo(() => _config.GeneratorOutputModel).Returns(outputModel);

            //Act
            _sut.Generate();

            //Assert
            A.CallTo(() => _writer
                .Write(A<string>.Ignored, A<string>.Ignored))
                .MustNotHaveHappened();
        }
    }
}