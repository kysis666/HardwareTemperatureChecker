using FakeItEasy;
using FluentAssertions;
using Fox.Models;
using Fox.Services;
using Fox.Tools.Interfaces;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Fox.Tests.Services
{
    [TestFixture]
    public class HardwareInformationGetterTests
    {
        private ICpuTemperatureChecker _cpuTemperatureChecker;
        private IGpuTemperatureChecker _gpuTemperatureChecker;
        private ILogger<HardwareInformationGetter> _logger;

        private HardwareInformationGetter _sut;
        [SetUp]
        public void Setup()
        {
            _cpuTemperatureChecker = A.Fake<ICpuTemperatureChecker>();
            _gpuTemperatureChecker = A.Fake<IGpuTemperatureChecker>();
            _logger = A.Fake<ILogger<HardwareInformationGetter>>();
            
            _sut = new HardwareInformationGetter(_cpuTemperatureChecker, _gpuTemperatureChecker, _logger);
        }

        [Test]
        public void GetHardwareInformation_ReturnsCorrectInformation()
        {
            // Arrange
            var expected = new HardwareInformationModel
            {
                CpuTemperature = 20,
                GpuTemperature = 30
            };
            A.CallTo(() => _cpuTemperatureChecker.GetCpuTemperature()).Returns(expected.CpuTemperature);
            A.CallTo(() => _gpuTemperatureChecker.GetGpuTemperature()).Returns(expected.GpuTemperature);

            // Act
            var actual = _sut.GetHardwareInformation();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
