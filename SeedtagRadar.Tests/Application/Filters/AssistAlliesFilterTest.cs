using FluentAssertions;
using Xunit;
using SeedtagRadar.Domain.Entities;
using SeedtagRadar.Application.Filters;

namespace SeedtagRadar.Tests.Application.Filters
{
    public class AssistAlliesFilterTest : TestBase
    {
        [Fact]
        public void Given_scan_with_alliases_should_return_true()
        {
            // Arrange
            var sut = _mockProvider.Create<AssistAlliesFilter>();
            var filter = sut.GetPredicate();
            var scan = new AttackScan { Allies = 1 };

            // Act
            var result = filter.Compile()(scan);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Given_scan_without_alliases_should_return_false()
        {
            // Arrange
            var sut = _mockProvider.Create<AssistAlliesFilter>();
            var filter = sut.GetPredicate();
            var scan = new AttackScan();

            // Act
            var result = filter.Compile()(scan);

            // Assert
            result.Should().BeFalse();
        }
    }
}