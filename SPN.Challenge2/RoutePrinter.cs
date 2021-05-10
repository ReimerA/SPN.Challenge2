using System;

namespace SPN.Challenge2
{
    public static class RoutePrinter
    {
        public static void PrintRoute(CalculatedRoute calculatedRoute)
        {
            Console.WriteLine($"{string.Join(" ", calculatedRoute.Nodes)} Cost: {calculatedRoute.TotalCost} Time: {calculatedRoute.TotalTime}");
        }
    }
}
