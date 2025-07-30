using CSharpGL;
using System.Collections.Generic;
using System.Drawing;

namespace ColorCodedPicking {
    internal class DragParam {
        public vec3 lastModelSpacePos;
        public List<uint> pickedVertexIds = new List<uint>();
        public mat4 projectionMat;
        public mat4 viewMat;
        public vec4 viewport;

        public DragParam(vec3 lastModelPos, mat4 projectionMat, mat4 viewMat, vec4 viewport) {
            this.lastModelSpacePos = lastModelPos;
            this.projectionMat = projectionMat;
            this.viewMat = viewMat;
            this.viewport = viewport;
        }

        public DragParam(vec3 lastModelPos, mat4 projectionMat, mat4 viewMat, vec4 viewport,
           IEnumerable<uint> indexes)
            : this(lastModelPos, projectionMat, viewMat, viewport) {
            this.pickedVertexIds.AddRange(indexes);
        }

        public DragParam(vec3 lastModelPos, mat4 projectionMat, mat4 viewMat, vec4 viewport,
            params uint[] indexes)
            : this(lastModelPos, projectionMat, viewMat, viewport) {
            this.pickedVertexIds.AddRange(indexes);
        }

    }
}