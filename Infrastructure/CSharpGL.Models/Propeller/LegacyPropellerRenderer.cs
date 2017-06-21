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
    /// Render propeller in legacy opengl.
    /// </summary>
    public class LegacyPropellerRenderer : RendererBase, IRenderable, ILegacyPickable
    {
        private const float xLength = 0.3f;
        private const float yLength = 0.2f;
        private const float zLength = 0.3f;
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
        /// Render propeller in legacy opengl.
        /// </summary>
        public LegacyPropellerRenderer()
        {
            this.ModelSize = new vec3(xLength * 2, yLength * 2, zLength * 2);
        }

        #region IRenderable 成员

        private bool renderingEnabled = true;
        /// <summary>
        /// 
        /// </summary>
        public bool RenderingEnabled { get { return renderingEnabled; } set { renderingEnabled = value; } }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            this.PushProjectionViewMatrix(arg);
            this.PushModelMatrix();

            DoRender();

            this.PopModelMatrix();
            this.PopProjectionViewMatrix();
        }

        #endregion

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

        #region ILegacyPickable 成员

        private bool legacyPickingEnabled = false;
        /// <summary>
        /// 
        /// </summary>
        public bool LegacyPickingEnabled
        {
            get { return legacyPickingEnabled; }
            set { legacyPickingEnabled = value; }
        }

        public void RenderForLegacyPicking(LegacyPickEventArgs arg)
        {
            this.PushProjectionViewMatrix(arg);
            this.PushModelMatrix();

            DoRender();

            this.PopModelMatrix();
            this.PopProjectionViewMatrix();
        }

        #endregion

    }
}
