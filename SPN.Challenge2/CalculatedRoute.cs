using System.Collections.Generic;
using System.Linq;

namespace SPN.Challenge2
{
    public class CalculatedRoute
    {
        public CalculatedRoute()
        {
            
        }

        public CalculatedRoute(RouteTracker state)
        {
            this.Nodes = state.Nodes.Select(x => x.Name).ToList();
            this.TotalCost = state.Cost;
            this.TotalTime = state.Time;
        }

        public List<string> Nodes { get; set; }
        public int TotalCost { get; set; }
        public int TotalTime { get; set; }
    }
}