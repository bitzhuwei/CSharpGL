using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{

    public class Edge
    {
        public readonly ushort vertexId1;
        public readonly ushort vertexId2;

        public Edge(ushort v1, ushort v2)
        {
            if (v1 <= v2)
            {
                this.vertexId1 = v1;
                this.vertexId2 = v2;
            }
            else
            {
                this.vertexId1 = v2;
                this.vertexId2 = v1;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", this.vertexId1, this.vertexId2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }

            var other = (Edge)obj;
            if (this.vertexId1 != other.vertexId1) { return false; }
            if (this.vertexId2 != other.vertexId2) { return false; }

            return true;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}
