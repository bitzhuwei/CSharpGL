using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    // Y
    // ^
    // |
    // |
    // 1--------------------0
    // |      .             |
    // |      |             |
    // |                    |
    // |    .               |
    // |   .                |
    // |  .                 |
    // | .                  |
    // 2--------------------3 --> X
    //
    /// <summary>
    /// Render propeller in legacy opengl.
    /// </summary>
    public class LegacyRectangleRenderer : RendererBase, IRenderable, ILegacyPickable
    {
        private const float xLength = 0.5f;
        private const float yLength = 0.5f;
        /// <summary>
        /// four vertexes.
        /// </summary>
        private static readonly vec3[] positions = new vec3[]
        {
            new vec3(+xLength, +yLength, 0),// 0
            new vec3(-xLength, +yLength, 0),// 1
            new vec3(-xLength, -yLength, 0),// 2
            new vec3(+xLength, -yLength, 0),// 3
        };
        /// <summary>
        /// four uvs.
        /// </summary>
        private static readonly vec2[] uvs = new vec2[]
        {
            new vec2(1, 1),// 0
            new vec2(0, 1),// 1
            new vec2(0, 0),// 2
            new vec2(1, 0),// 3
        };

        /// <summary>
        /// Render propeller in legacy opengl.
        /// </summary>
        public LegacyRectangleRenderer()
        {
            this.ModelSize = new vec3(xLength * 2, yLength * 2, 0.01f);
        }

        #region IRenderable 成员

        private bool renderingEnabled = true;
        /// <summary>
        /// 
        /// </summary>
        public bool RenderingEnabled { get { return renderingEnabled; } set { renderingEnabled = value; } }

        public void Render(RenderEventArgs arg)
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
            var texture = this.BindingTexture;
            if (texture != null) { texture.Bind(); }
            GL.Instance.Begin((uint)DrawMode.Quads);
            for (int i = 0; i < positions.Length; i++)
            {
                vec2 color = uvs[i];
                GL.Instance.TexCoord2f(color.x, color.y);
                vec3 position = positions[i];
                GL.Instance.Vertex3f(position.x, position.y, position.z);
            }
            GL.Instance.End();
            if (texture != null) { texture.Unbind(); }
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


        public Texture BindingTexture { get; set; }
    }
}
