using System.Collections.Generic;
using System.Linq;

namespace SPN.Challenge2
{
    public class Graph
    {
        public HashSet<Node> Nodes { get; set; } = new();

        public void AddRoute(string source, string target, int cost, int time)
        {
            if (!Nodes.TryGetValue(new Node (source), out Node sourceNode))
            {
                sourceNode = new Node(source);
                Nodes.Add(sourceNode);
            }


            if (!Nodes.TryGetValue(new Node(target), out Node targetNode))
            {
                targetNode = new Node(target);
                Nodes.Add(targetNode);
            }

            sourceNode.Routes.Add(new Route{Target = targetNode, Cost = cost, Time = time});
        }
        
        public List<CalculatedRoute> PrintAllRoutes(string s, string d)
        {
            var result = new List<CalculatedRoute>();
            
            HashSet<string> isVisited = new HashSet<string>();
            RouteTracker pathList = new RouteTracker();
            
            pathList.Nodes.Add(Nodes.Single(x => x.Name == s));
            
            PrintAllRoutesUtil(s, d, isVisited, pathList, result);

            return result;
        }
        
        private void PrintAllRoutesUtil(string u, string d,
            HashSet<string> isVisited,
            RouteTracker localPathList,
            List<CalculatedRoute> result)
        {
            if (u.Equals(d))
            {
                if (localPathList.Nodes.Count > 2)
                {
                    result.Add(new CalculatedRoute(localPathList));
                }

                return;
            }
            
            isVisited.Add(u);
            
            var currentNode = Nodes.Single(x => x.Name == u);
            foreach (var i in currentNode.Routes)
            {
                if (!isVisited.Contains(i.Target.Name))
                {
                    localPathList.AddRoute(i);
                    PrintAllRoutesUtil(i.Target.Name, d, isVisited,
                        localPathList, result);
                    localPathList.RemoveRoute(i);
                }
            }
            
            isVisited.Remove(u);
        }
    }
}