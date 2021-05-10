using System;

namespace SPN.Challenge2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

			//var pathFinder = new PathFinder();
			//pathFinder.

			Graph g = new Graph(5);
            g.addEdge(0, 1);
            g.addEdge(0, 2);
            g.addEdge(0, 3);
            g.addEdge(2, 0);
            g.addEdge(2, 1);
            g.addEdge(1, 3);
            g.addEdge(1, 4);

            // arbitrary source
            int s = 2;

            // arbitrary destination
            int d = 3;

            Console.WriteLine("Following are all different"
                              + " paths from " + s + " to " + d);
            g.printAllPaths(s, d);

            Graph2 g2 = new Graph2();
            g2.AddRoute("a", "b", 1, 2);
            g2.AddRoute("a", "c", 1, 2);
            g2.AddRoute("a", "d", 1, 2);
            g2.AddRoute("c", "a", 1, 2);
            g2.AddRoute("c", "b", 1, 2);
            g2.AddRoute("b", "d", 1, 2);

            g2.printAllPaths("c", "d");
        }    
    }
}
