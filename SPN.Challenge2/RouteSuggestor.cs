using System.Collections.Generic;
using System.Linq;

namespace SPN.Challenge2
{
    public static class MinCostAndMinTimeRouteSuggestor
    {
        public static CalculatedRoute SuggestRoute(IEnumerable<CalculatedRoute> routes)
        {
            var minCost = routes.Min(x => x.TotalCost);
            var minTime = routes.Min(x => x.TotalTime);

            var routesWithBothMinCostAndMinTime = routes.Where(x => x.TotalTime == minTime && x.TotalCost == minCost).ToList();

            if (routesWithBothMinCostAndMinTime.Count == 1)
            {
                return routesWithBothMinCostAndMinTime.First();
            }

            return null;
        }
    }
}
