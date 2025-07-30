using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    public struct AdjacentFace {
        public ushort vertexId1;
        public ushort adjacentId1;
        public ushort vertexId2;
        public ushort adjacentId2;
        public ushort vertexId3;
        public ushort adjacentId3;

        public AdjacentFace(ushort v1, ushort a1, ushort v2, ushort a2, ushort v3, ushort a3) {
            this.vertexId1 = v1; this.adjacentId1 = a1;
            this.vertexId2 = v2; this.adjacentId2 = a2;
            this.vertexId3 = v3; this.adjacentId3 = a3;
        }

        public override string ToString() {
            return string.Format("{0}, {1}, {2}, {3}, {4}, {5}", vertexId1, adjacentId1, vertexId2, adjacentId2, vertexId3, adjacentId3);
        }
    }

}
