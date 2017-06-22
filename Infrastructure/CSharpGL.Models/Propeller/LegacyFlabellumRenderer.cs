using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    //
    //        2-------------------3
    //      / .                  /|
    //     /  .                 / |
    //    /   .                /  |
    //   /    .               /   |
    //  /     .              /    |
    // 6--------------------7     |
    // |      .             |     |
    // |      0 . . . . . . |. . .1
    // |     .              |    /
    // |    .               |   /
    // |   .                |  /
    // |  .                 | /
    // | .                  |/
    // 4 -------------------5
    //
    /// <summary>
    /// Render flabellum in legacy opengl.
    /// </summary>
    public class LegacyFlabellumRenderer : RendererBase, IRenderable, ILegacyPickable
    {
        private const float xLength = 1.6f;
        private const float yLength = 0.05f;
        private const float zLength = 0.2f;
        /// <summary>
        /// eight vertexes.
        /// </summary>
        private static readonly vec3[] positions = new vec3[]
        {
            new vec3(-xLength, -yLength, -zLength),// 0
            new vec3(-xLength, -yLength, +zLength),// 1
            new vec3(-xLength, +yLength, -zLength),// 2
            new vec3(-xLength, +yLength, +zLength),// 3
            new vec3(+xLength, -yLength, -zLength),// 4
            new vec3(+xLength, -yLength, +zLength),// 5
            new vec3(+xLength, +yLength, -zLength),// 6
            new vec3(+xLength, +yLength, +zLength),// 7
        };

        private static readonly vec3 red = new vec3(1, 0, 0);
        private static readonly vec3 green = new vec3(0, 1, 0);
        private static readonly vec3 blue = new vec3(0, 0, 1);

        private const float darkFactor = 4.0f;
        private static readonly vec3[] colors = new vec3[]
        {
            (red / darkFactor + green / darkFactor + blue / darkFactor),
            (red / darkFactor + green / darkFactor + blue),
            (red / darkFactor + green + blue / darkFactor),
            (red / darkFactor + green + blue),
            (red + green / darkFactor + blue / darkFactor),
            (red + green / darkFactor + blue),
            (red + green + blue / darkFactor),
            (red + green + blue),
        };

        /// <summary>
        /// render in GL_QUADS.
        /// </summary>
        private static readonly byte[] indexes = new byte[24]
        {
            1, 3, 7, 5, 0, 4, 6, 2,
            2, 6, 7, 3, 0, 1, 5, 4,
            4, 5, 7, 6, 0, 2, 3, 1,
        };

        /// <summary>
        /// Render flabellum in legacy opengl.
        /// </summary>
        public LegacyFlabellumRenderer()
        {
            this.ModelSize = new vec3(xLength * 2, yLength * 2, zLength * 2);
        }

        #region IRenderable 成员

        private bool renderingEnabled = true;
        /// <summary>
        /// 
        /// </summary>
        public bool RenderingEnabled { get { return renderingEnabled; } set { renderingEnabled = value; } }

        private bool renderingChildrenEnabled = true;
        /// <summary>
        /// Render this object's children or not.
        /// </summary>
        public bool RenderingChildrenEnabled { get { return renderingChildrenEnabled; } set { renderingChildrenEnabled = value; } }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            this.PushProjectionViewMatrix(arg);
            this.PushModelMatrix();

            if (this.RenderWireframe)
            {
                DoRender(new vec3(1, 1, 1));
            }
            else
            {
                DoRender();
            }

            this.PopModelMatrix();
            this.PopProjectionViewMatrix();
        }

        private PolygonModeState polygonModeState = new PolygonModeState(PolygonMode.Line);

        private void DoRender(vec3 lineColor)
        {
            polygonModeState.On();
            GL.Instance.Begin((uint)DrawMode.Quads);
            GL.Instance.Color3f(lineColor.x, lineColor.y, lineColor.z);
            for (int i = 0; i < indexes.Length; i++)
            {
                vec3 position = positions[indexes[i]];
                GL.Instance.Vertex3f(position.x, position.y, position.z);
            }
            GL.Instance.End();
            polygonModeState.Off();
        }

        private void DoRender()
        {
            GL.Instance.Begin((uint)DrawMode.Quads);
            for (int i = 0; i < indexes.Length; i++)
            {
                vec3 color = colors[indexes[i]];
                GL.Instance.Color3f(color.x, color.y, color.z);
                vec3 position = positions[indexes[i]];
                GL.Instance.Vertex3f(position.x, position.y, position.z);
            }
            GL.Instance.End();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion

        #region ILegacyPickable 成员

        private ThreeFlags enableLegacyPicking = ThreeFlags.Children;
        /// <summary>
        /// 
        /// </summary>
        public ThreeFlags EnableLegacyPicking
        {
            get { return this.enableLegacyPicking; }
            set { this.enableLegacyPicking = value; }
        }

        public void RenderBeforeChildrenForLegacyPicking(LegacyPickEventArgs arg)
        {
            this.PushProjectionViewMatrix(arg);
            this.PushModelMatrix();

            DoRender();

            this.PopModelMatrix();
            this.PopProjectionViewMatrix();
        }

        /// <summary>
        /// Render this model after rendering its children in legacy OpenGL.
        /// </summary>
        /// <param name="arg"></param>
        public void RenderAfterChildrenForLegacyPicking(LegacyPickEventArgs arg) { }

        #endregion

        #region IRenderWireframe 成员

        /// <summary>
        /// 
        /// </summary>
        public bool RenderWireframe { get; set; }

        #endregion
    }
}
