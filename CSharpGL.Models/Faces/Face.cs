using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {

    public struct Face {
        public ushort vertexId1;
        public ushort vertexId2;
        public ushort vertexId3;

        public Face(ushort vertexId1, ushort vertexId2, ushort vertexId3) {
            this.vertexId1 = vertexId1;
            this.vertexId2 = vertexId2;
            this.vertexId3 = vertexId3;
        }

        public override string ToString() {
            return string.Format("{0}, {1}, {2}", vertexId1, vertexId2, vertexId3);
        }
    }

}
