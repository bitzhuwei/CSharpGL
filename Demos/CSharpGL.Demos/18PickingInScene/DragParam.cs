using System.Collections.Generic;
using System.Drawing;

namespace CSharpGL.Demos
{
    internal class DragParam
    {
        public List<uint> pickedVertexIds = new List<uint>();
        public mat4 projectionMatrix;
        public mat4 viewMatrix;
        public Point lastMousePositionOnScreen;
        public vec4 viewport;

        public DragParam(mat4 projectionMatrix, mat4 viewMatrix, vec4 viewport, Point lastMousePositionOnScreen)
        {
            this.projectionMatrix = projectionMatrix;
            this.viewMatrix = viewMatrix;
            this.lastMousePositionOnScreen = lastMousePositionOnScreen;
            this.viewport = viewport;
        }

        public DragParam(mat4 projectionMatrix, mat4 viewMatrix, vec4 viewport, Point lastMousePositionOnScreen,
           IEnumerable<uint> indexes)
            : this(projectionMatrix, viewMatrix, viewport, lastMousePositionOnScreen)
        {
            this.pickedVertexIds.AddRange(indexes);
        }

        public DragParam(mat4 projectionMatrix, mat4 viewMatrix, vec4 viewport, Point lastMousePositionOnScreen,
            params uint[] indexes)
            : this(projectionMatrix, viewMatrix, viewport, lastMousePositionOnScreen)
        {
            this.pickedVertexIds.AddRange(indexes);
        }

        public override string ToString()
        {
            return string.Format("Last Mouse Position On Screen: [{0}]", this.lastMousePositionOnScreen);
        }
    }
}