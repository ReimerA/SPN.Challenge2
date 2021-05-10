using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace SPN.Challenge2.Test
{
    public class SuggestorTest
    {
        [Fact]
        public void MinCostAndMinTimeSuggestorTest()
        {
            var routes = new List<CalculatedRoute>();
            routes.Add(new CalculatedRoute{Nodes = new List<string>{"A", "B", "D"}, TotalTime = 10, TotalCost = 20});
            routes.Add(new CalculatedRoute { Nodes = new List<string> { "A", "C", "D" }, TotalTime = 20, TotalCost = 10 });
            routes.Add(new CalculatedRoute { Nodes = new List<string> { "A", "T", "D" }, TotalTime = 10, TotalCost = 10 });

            var suggestRoute = MinCostAndMinTimeRouteSuggestor.SuggestRoute(routes);

            suggestRoute.Should().NotBeNull();
            suggestRoute.Nodes.Should().BeEquivalentTo(new[] {"A", "T", "D"});
            suggestRoute.TotalCost.Should().Be(10);
            suggestRoute.TotalTime.Should().Be(10);
        }
    }
}
