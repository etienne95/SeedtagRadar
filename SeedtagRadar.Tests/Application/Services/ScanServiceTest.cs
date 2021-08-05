using FluentAssertions;
using Xunit;
using SeedtagRadar.Domain.Entities;
using SeedtagRadar.Application.Selectors;
using SeedtagRadar.Application.Services;
using SeedtagRadar.Domain;
using SeedtagRadar.Domain.Interfaces;
using SeedtagRadar.Application.Filters;

namespace SeedtagRadar.Tests.Application.Services
{
    public class ScanServiceTest : TestBase
    {
        [Fact]
        public void Given_attack_instruction_with_filter_should_filter_point_correctly()
        {
            // Arrange
            var sut = _mockProvider.Create<ScanService>();
            var instruction = new AttackInstruction
            {
                Protocols = new[] { Constants.AVOID_CROSSFIRE },
                Scan = new[]
                {
                     new AttackScan { Allies = 1, Coordinates = new Point{X = 1, Y = 1} },
                     new AttackScan{Coordinates = new Point{X = 2, Y = 2}}
                }
            };
            var protocol = new AvoidCrossfireFilter();

            _mockProvider.Mock<IProtocolFactory>()
                        .Setup(mock => mock.GetProtocol(Constants.AVOID_CROSSFIRE))
                        .Returns(protocol);

            // Act
            var result = sut.GetTargetPoint(instruction);

            // Assert
            result.X.Should().Be(2);
            result.Y.Should().Be(2);
        }

        [Fact]
        public void Given_attack_instruction_with_selector_should_select_the_correct_point()
        {
            // Arrange
            var sut = _mockProvider.Create<ScanService>();
            var instruction = new AttackInstruction
            {
                Protocols = new[] { Constants.CLOSEST_ENEMIES },
                Scan = new[]
                {
                     new AttackScan{Coordinates = new Point{X = 1, Y = 1}},
                     new AttackScan{Coordinates = new Point{X = 2, Y = 2}}
                }
            };
            var protocol = new ClosestEnemiesSelector();

            _mockProvider.Mock<IProtocolFactory>()
                        .Setup(mock => mock.GetProtocol(Constants.CLOSEST_ENEMIES))
                        .Returns(protocol);

            // Act
            var result = sut.GetTargetPoint(instruction);

            // Assert
            result.X.Should().Be(1);
            result.Y.Should().Be(1);
        }

        [Fact]
        public void Given_attack_instruction_with_selector_and_filter_should_select_the_correct_point_after_filter()
        {
            // Arrange
            var sut = _mockProvider.Create<ScanService>();
            var instruction = new AttackInstruction
            {
                Protocols = new[] { Constants.CLOSEST_ENEMIES, Constants.AVOID_CROSSFIRE },
                Scan = new[]
                {
                     new AttackScan{Allies= 1, Coordinates = new Point{X = 1, Y = 1}},
                     new AttackScan{Coordinates = new Point{X = 2, Y = 2}},
                     new AttackScan{Coordinates = new Point{X = 3, Y = 3}}
                }
            };
            var selector = new ClosestEnemiesSelector();
            var filter = new AvoidCrossfireFilter();

            _mockProvider.Mock<IProtocolFactory>()
                        .Setup(mock => mock.GetProtocol(Constants.CLOSEST_ENEMIES))
                        .Returns(selector);
            _mockProvider.Mock<IProtocolFactory>()
                        .Setup(mock => mock.GetProtocol(Constants.AVOID_CROSSFIRE))
                        .Returns(filter);

            // Act
            var result = sut.GetTargetPoint(instruction);

            // Assert
            result.X.Should().Be(2);
            result.Y.Should().Be(2);
        }
    }
}