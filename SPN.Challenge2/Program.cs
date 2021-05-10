using System;

namespace SPN.Challenge2
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g3 = new Graph();
            g3.AddRoute("A", "H", 1, 10);
            g3.AddRoute("A", "E", 5, 30);
            g3.AddRoute("A", "C", 20, 1);
            g3.AddRoute("C", "B", 12, 1);
            g3.AddRoute("H", "E", 1, 30);
            g3.AddRoute("E", "D", 5, 3);
            g3.AddRoute("D", "F", 50, 4);
            g3.AddRoute("F", "I", 50, 45);
            g3.AddRoute("F", "G", 50, 40);
            g3.AddRoute("I", "B", 5, 65);
            g3.AddRoute("G", "B", 73, 64);

            var calculatedRoutes = g3.PrintAllRoutes("A", "B");

            foreach (var calculatedRoute in calculatedRoutes)
            {
                RoutePrinter.PrintRoute(calculatedRoute);
            }

            var suggestRoute = MinCostAndMinTimeRouteSuggestor.SuggestRoute(calculatedRoutes);
            if (suggestRoute != null)
            {
                Console.WriteLine();
                Console.WriteLine($"Suggested route is : {string.Join(" ", suggestRoute.Nodes)} since it has lowest time and cost");
            }
        }    
    }
}
