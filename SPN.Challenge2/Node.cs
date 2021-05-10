using System;
using System.Collections.Generic;

namespace SPN.Challenge2
{
    public class Node : IEquatable<Node>
    {
        public Node(string name)
        {
            Name = name;
        }

        public string Name { get; }
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
}