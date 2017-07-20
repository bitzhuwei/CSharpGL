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
    public class LegacyRectangleRenderer : SceneNodeBase, IRenderable, ILegacyPickable
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

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        public ThreeFlags EnableRendering
        {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            this.PushProjectionViewMatrix(arg);
            this.PushModelMatrix();

            DoRender();

            this.PopModelMatrix();
            this.PopProjectionViewMatrix();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion

        private static GLDelegates.void_uint glActiveTexture;
        private void DoRender()
        {
            var texture = this.TextureSource.BindingTexture;
            if (texture != null)
            {
                if (glActiveTexture == null)
                { glActiveTexture = GL.Instance.GetDelegateFor("glActiveTexture", GLDelegates.typeof_void_uint) as GLDelegates.void_uint; }
                const uint textureUnitIndex = 0;
                glActiveTexture(textureUnitIndex + GL.GL_TEXTURE0);
                texture.Bind();
            }
            GL.Instance.Begin((uint)DrawMode.Quads);
            for (int i = 0; i < positions.Length; i++)
            {
                vec3 position = positions[i];
                GL.Instance.Vertex3f(position.x, position.y, position.z);
                vec2 color = uvs[i];
                GL.Instance.TexCoord2f(color.x, color.y);
            }
            GL.Instance.End();
            if (texture != null) { texture.Unbind(); }
        }

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

        public void RenderBeforeChildrenForLegacyPicking(LegacyPickingEventArgs arg)
        {
            this.PushProjectionViewMatrix(arg);
            this.PushModelMatrix();

            DoRender();

            this.PopModelMatrix();
            this.PopProjectionViewMatrix();
        }

        ///// <summary>
        ///// Render this model after rendering its children in legacy OpenGL.
        ///// </summary>
        ///// <param name="arg"></param>
        //public void RenderAfterChildrenForLegacyPicking(LegacyPickEventArgs arg) { }

        #endregion

        public ITextureSource TextureSource { get; set; }
    }
}
