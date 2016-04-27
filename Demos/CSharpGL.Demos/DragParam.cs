using GLM;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Demos
{

    class DragParam
    {

        public List<uint> pickedIndexes = new List<uint>();
        public mat4 projectionMatrix;
        public mat4 viewMatrix;
        public Point lastMousePositionOnScreen;
        public vec4 viewport;

        public DragParam(mat4 projectionMatrix, mat4 viewMatrix, Point lastMousePositionOnScreen)
        {
            this.projectionMatrix = projectionMatrix;
            this.viewMatrix = viewMatrix;
            this.lastMousePositionOnScreen = lastMousePositionOnScreen;
            var viewport = new int[4]; GL.GetInteger(GetTarget.Viewport, viewport);
            this.viewport = new vec4(viewport[0], viewport[1], viewport[2], viewport[3]);
        }

        public DragParam(mat4 projectionMatrix, mat4 viewMatrix, Point lastMousePositionOnScreen,
           IEnumerable<uint> indexes)
            :this(projectionMatrix, viewMatrix, lastMousePositionOnScreen)
        {
            this.pickedIndexes.AddRange(indexes);
        }

        public DragParam(mat4 projectionMatrix, mat4 viewMatrix, Point lastMousePositionOnScreen,
            params uint[] indexes)
            : this(projectionMatrix, viewMatrix, lastMousePositionOnScreen)
        {
            this.pickedIndexes.AddRange(indexes);
        }

        public override string ToString()
        {
            return string.Format("Last Mouse Position On Screen: [{0}]", this.lastMousePositionOnScreen);
        }
    }
}
