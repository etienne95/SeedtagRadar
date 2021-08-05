using FluentAssertions;
using Xunit;
using SeedtagRadar.Domain.Entities;
using SeedtagRadar.Application.Filters;

namespace SeedtagRadar.Tests.Application.Filters
{
    public class AvoidMechFilterTest : TestBase
    {
        [Fact]
        public void Given_scan_with_mech_should_return_false()
        {
            // Arrange
            var sut = _mockProvider.Create<AvoidMechFilter>();
            var filter = sut.GetPredicate();
            var scan = new AttackScan { Enemies = new Enemy { Type = "mech", Number = 1 } };

            // Act
            var result = filter.Compile()(scan);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Given_scan_without_mech_should_return_true()
        {
            // Arrange
            var sut = _mockProvider.Create<AvoidMechFilter>();
            var filter = sut.GetPredicate();
            var scan = new AttackScan { Enemies = new Enemy { Type = "other", Number = 1 } };

            // Act
            var result = filter.Compile()(scan);

            // Assert
            result.Should().BeTrue();
        }
    }
}