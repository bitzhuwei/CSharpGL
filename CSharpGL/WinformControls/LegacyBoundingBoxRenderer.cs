using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Specify a cuboid that marks a model's edges.
    /// </summary>
    public class LegacyBoundingBoxRenderer : RendererBase, IBoundingBox
    {

        /// <summary>
        /// Cuboid's color of its lines.
        /// </summary>
        public vec4 BoxColor { get; set; }

        /// <summary>
        /// Specify a cuboid that marks a model's edges.
        /// </summary>
        public LegacyBoundingBoxRenderer()
            : this(new vec3(0.5f, 0.5f, 0.5f), new vec3(0.5f, 0.5f, 0.5f), Color.White)
        { }

        /// <summary>
        /// Specify a cuboid that marks a model's edges.
        /// </summary>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <param name="color"></param>
        public LegacyBoundingBoxRenderer(vec3 max, vec3 min, Color color)
        {
            this.MaxPosition = max;
            this.MinPosition = min;
            this.BoxColor = color.ToVec4();
        }

        #region IBoundingBox 成员

        /// <summary>
        /// Maximum position of this cuboid.
        /// </summary>
        public vec3 MaxPosition { get; set; }

        /// <summary>
        /// Minimum position of this cuboid.
        /// </summary>
        public vec3 MinPosition { get; set; }

        #endregion

        /// <summary>
        /// This simulates BoundingVolume's render method.
        /// </summary>
        /// <param name="renderMode"></param>
        private void QuadsDraw(RenderModes renderMode)
        {
            OpenGL.Begin(DrawMode.Quads);
            OpenGL.Vertex3f(MaxPosition.x, MaxPosition.y, MinPosition.z);// Top Right Of The Quad (Top)
            OpenGL.Vertex3f(MinPosition.x, MaxPosition.y, MinPosition.z);// Top Left Of The Quad (Top)
            OpenGL.Vertex3f(MinPosition.x, MaxPosition.y, MaxPosition.z);// Bottom Left Of The Quad (Top)
            OpenGL.Vertex3f(MaxPosition.x, MaxPosition.y, MaxPosition.z);// Bottom Right Of The Quad (Top)
            OpenGL.Vertex3f(MaxPosition.x, MinPosition.y, MaxPosition.z);// Top Right Of The Quad (Bottom)
            OpenGL.Vertex3f(MinPosition.x, MinPosition.y, MaxPosition.z);// Top Left Of The Quad (Bottom)
            OpenGL.Vertex3f(MinPosition.x, MinPosition.y, MinPosition.z);// Bottom Left Of The Quad (Bottom)
            OpenGL.Vertex3f(MaxPosition.x, MinPosition.y, MinPosition.z);// Bottom Right Of The Quad (Bottom)
            OpenGL.Vertex3f(MaxPosition.x, MaxPosition.y, MaxPosition.z);// Top Right Of The Quad (Front)
            OpenGL.Vertex3f(MinPosition.x, MaxPosition.y, MaxPosition.z);// Top Left Of The Quad (Front)
            OpenGL.Vertex3f(MinPosition.x, MinPosition.y, MaxPosition.z);// Bottom Left Of The Quad (Front)
            OpenGL.Vertex3f(MaxPosition.x, MinPosition.y, MaxPosition.z);// Bottom Right Of The Quad (Front)
            OpenGL.Vertex3f(MaxPosition.x, MinPosition.y, MinPosition.z);// Top Right Of The Quad (Back)
            OpenGL.Vertex3f(MinPosition.x, MinPosition.y, MinPosition.z);// Top Left Of The Quad (Back)
            OpenGL.Vertex3f(MinPosition.x, MaxPosition.y, MinPosition.z);// Bottom Left Of The Quad (Back)
            OpenGL.Vertex3f(MaxPosition.x, MaxPosition.y, MinPosition.z);// Bottom Right Of The Quad (Back)
            OpenGL.Vertex3f(MinPosition.x, MaxPosition.y, MaxPosition.z);// Top Right Of The Quad (Left)
            OpenGL.Vertex3f(MinPosition.x, MaxPosition.y, MinPosition.z);// Top Left Of The Quad (Left)
            OpenGL.Vertex3f(MinPosition.x, MinPosition.y, MinPosition.z);// Bottom Left Of The Quad (Left)
            OpenGL.Vertex3f(MinPosition.x, MinPosition.y, MaxPosition.z);// Bottom Right Of The Quad (Left)
            OpenGL.Vertex3f(MaxPosition.x, MaxPosition.y, MinPosition.z);// Top Right Of The Quad (Right)
            OpenGL.Vertex3f(MaxPosition.x, MaxPosition.y, MaxPosition.z);// Top Left Of The Quad (Right)
            OpenGL.Vertex3f(MaxPosition.x, MinPosition.y, MaxPosition.z);// Bottom Left Of The Quad (Right)
            OpenGL.Vertex3f(MaxPosition.x, MinPosition.y, MinPosition.z);// Bottom Right Of The Quad (Right)
            OpenGL.End();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void DoInitialize()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            //  Push attributes, disable lighting.
            OpenGL.PushAttrib(OpenGL.GL_CURRENT_BIT | OpenGL.GL_ENABLE_BIT |
                OpenGL.GL_LINE_BIT | OpenGL.GL_POLYGON_BIT);
            OpenGL.Disable(OpenGL.GL_LIGHTING);
            OpenGL.Disable(OpenGL.GL_TEXTURE_2D);
            OpenGL.LineWidth(1.0f);
            OpenGL.Color4f(BoxColor.x, BoxColor.y, BoxColor.z, BoxColor.w);

            //QuadsDraw(gl);

            //GL.Color(1.0f, 0, 0);
            OpenGL.Begin(DrawMode.LineLoop);
            OpenGL.Vertex3f(MinPosition.x, MinPosition.y, MinPosition.z);
            OpenGL.Vertex3f(MaxPosition.x, MinPosition.y, MinPosition.z);
            OpenGL.Vertex3f(MaxPosition.x, MinPosition.y, MaxPosition.z);
            OpenGL.Vertex3f(MinPosition.x, MinPosition.y, MaxPosition.z);
            OpenGL.End();

            //GL.Color(0, 1.0f, 0);
            OpenGL.Begin(DrawMode.LineLoop);
            OpenGL.Vertex3f(MinPosition.x, MaxPosition.y, MinPosition.z);
            OpenGL.Vertex3f(MaxPosition.x, MaxPosition.y, MinPosition.z);
            OpenGL.Vertex3f(MaxPosition.x, MaxPosition.y, MaxPosition.z);
            OpenGL.Vertex3f(MinPosition.x, MaxPosition.y, MaxPosition.z);
            OpenGL.End();

            //GL.Color(0, 0, 1.0f);
            OpenGL.Begin(DrawMode.Lines);
            OpenGL.Vertex3f(MinPosition.x, MinPosition.y, MinPosition.z);
            OpenGL.Vertex3f(MinPosition.x, MaxPosition.y, MinPosition.z);
            OpenGL.Vertex3f(MaxPosition.x, MinPosition.y, MinPosition.z);
            OpenGL.Vertex3f(MaxPosition.x, MaxPosition.y, MinPosition.z);
            OpenGL.Vertex3f(MaxPosition.x, MinPosition.y, MaxPosition.z);
            OpenGL.Vertex3f(MaxPosition.x, MaxPosition.y, MaxPosition.z);
            OpenGL.Vertex3f(MinPosition.x, MinPosition.y, MaxPosition.z);
            OpenGL.Vertex3f(MinPosition.x, MaxPosition.y, MaxPosition.z);
            OpenGL.End();

            OpenGL.PopAttrib();
        }
    }
}
