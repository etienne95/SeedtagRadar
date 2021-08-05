using FluentAssertions;
using Xunit;
using SeedtagRadar.Api.Controllers;
using SeedtagRadar.Domain.Entities;
using SeedtagRadar.Domain.Interfaces;

namespace SeedtagRadar.Tests.Api
{
    public class RadarControllerTest : TestBase
    {
        [Fact]
        public void Given_radar_request_should_return_target_point()
        {
            // Arrange
            var sut = _mockProvider.Create<RadarController>();
            var request = new AttackInstruction();
            var expectedResult = new Point { X = 1, Y = 2 };

            _mockProvider.Mock<IScanService>()
                .Setup(mock => mock.GetTargetPoint(request))
                .Returns(expectedResult);

            // Act
            var result = sut.Post(request);

            // Assert
            result.X.Should().Be(expectedResult.X);
            result.Y.Should().Be(expectedResult.Y);
        }
    }
}