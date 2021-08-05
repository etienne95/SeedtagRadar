using FluentAssertions;
using Xunit;
using SeedtagRadar.Domain.Entities;
using SeedtagRadar.Application.Filters;
using SeedtagRadar.Domain;

namespace SeedtagRadar.Tests.Application.Filters
{
    public class DefaultProtocolFilterTest : TestBase
    {
        [Fact]
        public void Given_scan_with_distance_more_than_limit_should_return_false()
        {
            // Arrange
            var sut = _mockProvider.Create<DefaultProtocolFilter>();
            var filter = sut.GetPredicate();
            var scan = new AttackScan { Coordinates = new Point { X = Constants.DISTANCE_LIMIT + 1, Y = Constants.DISTANCE_LIMIT + 1 } };

            // Act
            var result = filter.Compile()(scan);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Given_scan_with_distance_lower_than_limit_should_return_true()
        {
            // Arrange
            var sut = _mockProvider.Create<DefaultProtocolFilter>();
            var filter = sut.GetPredicate();
            var scan = new AttackScan { Coordinates = new Point() };

            // Act
            var result = filter.Compile()(scan);

            // Assert
            result.Should().BeTrue();
        }
    }
}