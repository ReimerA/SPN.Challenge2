// C# program to print all
// paths from a source to
// destination.

using System;
using System.Collections.Generic;
using System.Linq;

namespace SPN.Challenge2
{
    // A directed graph using
// adjacency list representation

    public class Node : IEquatable<Node>
    {
        public string Name { get; set; }
        public List<Route> Routes { get; set; } = new List<Route>();
        
        public bool Equals(Node other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Node) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }

    public class Route
    {
        public int Cost { get; set; }
        public int Time { get; set; }
        public Node Target { get; set; }
    }

    public class Graph2
    {

        public HashSet<Node> Nodes { get; set; } = new();
        public Graph2()
        {
            
        }

        //// adjacency list
        //private List<int>[] adjList;

        //// Constructor
        //public Graph2()
        //{
        //    // initialise adjacency list
        //    initAdjList();
        //}



        //// utility method to initialise
        //// adjacency list
        //private void initAdjList()
        //{
        //    adjList = new List<int>[v];

        //    for (int i = 0; i < v; i++)
        //    {
        //        adjList[i] = new List<int>();
        //    }
        //}

        public void AddRoute(string source, string target, int cost, int time)
        {
            if (!Nodes.TryGetValue(new Node {Name = source}, out Node sourceNode))
            {
                sourceNode = new Node {Name = source};
                Nodes.Add(sourceNode);
            }


            if (!Nodes.TryGetValue(new Node { Name = target }, out Node targetNode))
            {
                targetNode = new Node { Name = target };
                Nodes.Add(targetNode);
            }

            sourceNode.Routes.Add(new Route{Target = targetNode, Cost = cost, Time = time});
        }

        // add edge from u to v
        //public void addEdge(int u, int v)
        //{
        //    // Add v to u's list.
        //    adjList[u].Add(v);
        //}

        // Prints all paths from
        // 's' to 'd'
        public void printAllPaths(string s, string d)
        {
            //bool[] isVisited = new bool[v];
            HashSet<string> isVisited = new HashSet<string>();
            List<string> pathList = new List<string>();

            // add source to path[]
            pathList.Add(s);

            // Call recursive utility
            printAllPathsUtil(s, d, isVisited, pathList);
        }

        // A recursive function to print
        // all paths from 'u' to 'd'.
        // isVisited[] keeps track of
        // vertices in current path.
        // localPathList<> stores actual
        // vertices in the current path
        private void printAllPathsUtil(string u, string d,
            HashSet<string> isVisited,
            List<string> localPathList)
        {

            if (u.Equals(d))
            {
                Console.WriteLine(string.Join(" ", localPathList));
                // if match found then no need
                // to traverse more till depth
                return;
            }

            // Mark the current node
            //isVisited[u] = true;
            isVisited.Add(u);

            // Recur for all the vertices
            // adjacent to current vertex
            var currentNode = Nodes.Single(x => x.Name == u);
            foreach (var i in currentNode.Routes)
            {
                if (!isVisited.Contains(i.Target.Name))
                {
                    // store current node
                    // in path[]
                    localPathList.Add(i.Target.Name);
                    printAllPathsUtil(i.Target.Name, d, isVisited,
                        localPathList);

                    // remove current node
                    // in path[]
                    //localPathList.Remove(i);
                    localPathList.Remove(i.Target.Name);

                }
            }

            // Mark the current node
            //isVisited[u] = false;
            isVisited.Remove(u);
        }
    }
}