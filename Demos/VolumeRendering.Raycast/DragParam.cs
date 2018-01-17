using CSharpGL;
using System.Collections.Generic;
using System.Drawing;

namespace VolumeRendering.Raycast
{
    internal class DragParam
    {
        public vec3 lastModelSpacePos;
        public List<uint> pickedVertexIds = new List<uint>();
        public mat4 projectionMatrix;
        public mat4 viewMatrix;
        public ivec2 lastMousePositionOnScreen;
        public vec4 viewport;

        public DragParam(vec3 lastModelPos, mat4 projectionMatrix, mat4 viewMatrix, vec4 viewport, ivec2 lastMousePositionOnScreen)
        {
            this.lastModelSpacePos = lastModelPos;
            this.projectionMatrix = projectionMatrix;
            this.viewMatrix = viewMatrix;
            this.lastMousePositionOnScreen = lastMousePositionOnScreen;
            this.viewport = viewport;
        }

        public DragParam(vec3 lastModelPos, mat4 projectionMatrix, mat4 viewMatrix, vec4 viewport, ivec2 lastMousePositionOnScreen,
           IEnumerable<uint> indexes)
            : this(lastModelPos, projectionMatrix, viewMatrix, viewport, lastMousePositionOnScreen)
        {
            this.pickedVertexIds.AddRange(indexes);
        }

        public DragParam(vec3 lastModelPos, mat4 projectionMatrix, mat4 viewMatrix, vec4 viewport, ivec2 lastMousePositionOnScreen,
            params uint[] indexes)
            : this(lastModelPos, projectionMatrix, viewMatrix, viewport, lastMousePositionOnScreen)
        {
            this.pickedVertexIds.AddRange(indexes);
        }

        public override string ToString()
        {
            return string.Format("Last Mouse Position On Screen: [{0}]", this.lastMousePositionOnScreen);
        }
    }
}