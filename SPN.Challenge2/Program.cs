using System;

namespace SPN.Challenge2
{
    class Program
    {
        static void Main(string[] args)
        {
   //         Console.WriteLine("Hello World!");

			////var pathFinder = new PathFinder();
			////pathFinder.

			//Graph g = new Graph(5);
   //         g.addEdge(0, 1);
   //         g.addEdge(0, 2);
   //         g.addEdge(0, 3);
   //         g.addEdge(2, 0);
   //         g.addEdge(2, 1);
   //         g.addEdge(1, 3);
   //         g.addEdge(1, 4);

   //         // arbitrary source
   //         int s = 2;

   //         // arbitrary destination
   //         int d = 3;

   //         Console.WriteLine("Following are all different"
   //                           + " paths from " + s + " to " + d);
   //         g.printAllPaths(s, d);

   //         Graph2 g2 = new Graph2();
   //         g2.AddRoute("a", "b", 1, 2);
   //         g2.AddRoute("a", "c", 1, 2);
   //         g2.AddRoute("a", "d", 1, 2);
   //         g2.AddRoute("c", "a", 1, 2);
   //         g2.AddRoute("c", "b", 1, 2);
   //         g2.AddRoute("b", "d", 1, 2);

   //         g2.PrintAllRoutes("c", "d");


            Graph2 g3 = new Graph2();
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

            g3.PrintAllRoutes("A", "E");
        }    
    }
}
