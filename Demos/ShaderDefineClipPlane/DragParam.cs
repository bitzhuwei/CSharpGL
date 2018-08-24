using CSharpGL;
using System.Collections.Generic;
using System.Drawing;

namespace ShaderDefineClipPlane
{
    internal class DragParam
    {
        public vec3 lastModelSpacePos;
        public List<uint> pickedVertexIds = new List<uint>();
        public mat4 projectionMat;
        public mat4 viewMat;
        public ivec2 lastMousePositionOnScreen;
        public vec4 viewport;

        public DragParam(vec3 lastModelPos, mat4 projectionMat, mat4 viewMat, vec4 viewport, ivec2 lastMousePositionOnScreen)
        {
            this.lastModelSpacePos = lastModelPos;
            this.projectionMat = projectionMat;
            this.viewMat = viewMat;
            this.lastMousePositionOnScreen = lastMousePositionOnScreen;
            this.viewport = viewport;
        }

        public DragParam(vec3 lastModelPos, mat4 projectionMat, mat4 viewMat, vec4 viewport, ivec2 lastMousePositionOnScreen,
           IEnumerable<uint> indexes)
            : this(lastModelPos, projectionMat, viewMat, viewport, lastMousePositionOnScreen)
        {
            this.pickedVertexIds.AddRange(indexes);
        }

        public DragParam(vec3 lastModelPos, mat4 projectionMat, mat4 viewMat, vec4 viewport, ivec2 lastMousePositionOnScreen,
            params uint[] indexes)
            : this(lastModelPos, projectionMat, viewMat, viewport, lastMousePositionOnScreen)
        {
            this.pickedVertexIds.AddRange(indexes);
        }

        public override string ToString()
        {
            return string.Format("Last Mouse Position On Screen: [{0}]", this.lastMousePositionOnScreen);
        }
    }
}