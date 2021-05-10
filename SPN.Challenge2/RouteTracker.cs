using System.Collections.Generic;

namespace SPN.Challenge2
{
    public class RouteTracker
    {
        public List<Node> Nodes { get; set; } = new();
        public int Cost { get; set; }
        public int Time { get; set; }

        public void AddRoute(Route route)
        {
            Nodes.Add(route.Target);
            Cost += route.Cost;
            Time += route.Time;
        }

        public void RemoveRoute(Route route)
        {
            Nodes.Remove(route.Target);
            Cost -= route.Cost;
            Time -= route.Time;
        }
    }
}