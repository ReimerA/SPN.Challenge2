using System.Linq;
using FluentAssertions;
using Xunit;

namespace SPN.Challenge2.Test
{
    public class GraphTests
    {
        private readonly Graph _graph;

        public GraphTests()
        {

            _graph = new Graph();
            _graph.AddRoute("A", "H", 1, 10);
            _graph.AddRoute("A", "E", 5, 30);
            _graph.AddRoute("A", "C", 20, 1);
            _graph.AddRoute("C", "B", 12, 1);
            _graph.AddRoute("H", "E", 1, 30);
            _graph.AddRoute("E", "D", 5, 3);
            _graph.AddRoute("D", "F", 50, 4);
            _graph.AddRoute("F", "I", 50, 45);
            _graph.AddRoute("F", "G", 50, 40);
            _graph.AddRoute("I", "B", 5, 65);
            _graph.AddRoute("G", "B", 73, 64);
        }

        [Fact]
        public void NoDirectDeliveryAllowed()
        {
            var calculatedRoutes = _graph.PrintAllRoutes("A", "E");

            calculatedRoutes.Count.Should().Be(1);
            calculatedRoutes[0].Nodes.Should().NotBeEmpty()
                .And.HaveCount(3)
                .And.ContainInOrder(new[] {"A", "H", "E"});

        }

        [Fact]
        public void ShouldListAllAllowedRoutes()
        {
            var calculatedRoutes = _graph.PrintAllRoutes("A", "B");

            calculatedRoutes.Should().HaveCount(5);
            calculatedRoutes.Select(x => string.Join("", x.Nodes))
                .Should().Contain("ACB")
                .And.Contain("AEDFIB")
                .And.Contain("AEDFGB")
                .And.Contain("AHEDFIB")
                .And.Contain("AHEDFGB");

            calculatedRoutes.Should().Contain(route => string.Join("", route.Nodes) == "ACB").Which.TotalCost.Should().Be(32);
            calculatedRoutes.Should().Contain(route => string.Join("", route.Nodes) == "ACB").Which.TotalTime.Should().Be(2);

            calculatedRoutes.Should().Contain(route => string.Join("", route.Nodes) == "AEDFIB").Which.TotalCost.Should().Be(115);
            calculatedRoutes.Should().Contain(route => string.Join("", route.Nodes) == "AEDFIB").Which.TotalTime.Should().Be(147);

            calculatedRoutes.Should().Contain(route => string.Join("", route.Nodes) == "AEDFGB").Which.TotalCost.Should().Be(183);
            calculatedRoutes.Should().Contain(route => string.Join("", route.Nodes) == "AEDFGB").Which.TotalTime.Should().Be(141);

            calculatedRoutes.Should().Contain(route => string.Join("", route.Nodes) == "AHEDFIB").Which.TotalCost.Should().Be(112);
            calculatedRoutes.Should().Contain(route => string.Join("", route.Nodes) == "AHEDFIB").Which.TotalTime.Should().Be(157);

            calculatedRoutes.Should().Contain(route => string.Join("", route.Nodes) == "AHEDFGB").Which.TotalCost.Should().Be(180);
            calculatedRoutes.Should().Contain(route => string.Join("", route.Nodes) == "AHEDFGB").Which.TotalTime
                .Should().Be(151);
        }
    }
}
