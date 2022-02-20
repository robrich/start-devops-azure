using FluentAssertions;
using FluentAssertions.Execution;
using Site.Models;
using Site.Tests.Fixtures;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Site.Tests;

public class ItemController_IntegrationTests
{
    [Fact]
    public async Task GetItems_ReturnsTwo()
    {
        // arrange
        int expected = 2;

        await using var application = new SiteApp();
        using var client = application.CreateClient();

        // act
        using var res = await client.GetAsync("/api/item");
        var body = await res.Content.ReadAsStringAsync();
        List<Item>? items = JsonSerializer.Deserialize<List<Item>>(body);

        // assert
        using (new AssertionScope())
        {
            items.Should().NotBeNull();
            items.Should().HaveCount(expected);
        }
    }

}
