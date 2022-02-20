using FluentAssertions;
using Site.Controllers;
using Xunit;

namespace Site.Tests;

public class ItemController_Get_UnitTests
{
    [Fact]
    public void Get_Returns2()
    {

        // Arrange
        int expected = 2;

        // Act
        ItemController controller = new ItemController();
        var results = controller.Get();

        // Assert
        results.Should().HaveCount(expected);

    }
}
