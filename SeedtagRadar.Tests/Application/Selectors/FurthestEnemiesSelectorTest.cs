using FluentAssertions;
using Xunit;
using SeedtagRadar.Domain.Entities;
using SeedtagRadar.Application.Selectors;

namespace SeedtagRadar.Tests.Application.Selectors
{
    public class FurthestEnemiesSelectorTest : TestBase
    {
        [Fact]
        public void Given_scans_should_select_the_largest_distance_one()
        {
            // Arrange
            var sut = _mockProvider.Create<FurthestEnemiesSelector>();
            var scan1 = new AttackScan { Coordinates = new Point { X = 10, Y = 10 } };
            var scan2 = new AttackScan { Coordinates = new Point { X = 5, Y = 5 } };

            // Act
            var result = sut.SelectOne(new[] { scan1, scan2 });

            // Assert
            result.Should().BeSameAs(scan1);
        }
    }
}