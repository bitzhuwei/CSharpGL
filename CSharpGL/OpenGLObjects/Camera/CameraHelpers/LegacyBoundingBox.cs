using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Specify a cuboid that marks a model's edges.
    /// </summary>
    public class LegacyBoundingBox : IBoundingBox
    {
        /// <summary>
        /// Maximum position of this cuboid.
        /// </summary>
        private vec3 maxPosition;


        /// <summary>
        /// Minimum position of this cuboid.
        /// </summary>
        private vec3 minPosition;


        /// <summary>
        /// Cuboid's color of its lines.
        /// </summary>
        public vec4 BoxColor { get; set; }

        /// <summary>
        /// Specify a cuboid that marks a model's edges.
        /// </summary>
        public LegacyBoundingBox()
        {
            BoxColor = new vec4(1, 1, 1, 1);// white color
        }


        #region IBoundingBox 成员

        /// <summary>
        /// Maximum position of this cuboid.
        /// </summary>
        public vec3 MaxPosition
        {
            get { return maxPosition; }
            private set { maxPosition = value; }
        }

        /// <summary>
        /// Minimum position of this cuboid.
        /// </summary>
        public vec3 MinPosition
        {
            get { return minPosition; }
            private set { minPosition = value; }
        }

        /// <summary>
        /// Get center position of this cuboid.
        /// </summary>
        /// <param name="x">x position.</param>
        /// <param name="y">y position.</param>
        /// <param name="z">z position.</param>
        public void GetCenter(out float x, out float y, out float z)
        {
            x = (this.MaxPosition.x + this.MinPosition.x) / 2;
            y = (this.MaxPosition.y + this.MinPosition.y) / 2;
            z = (this.MaxPosition.z + this.MinPosition.z) / 2;
        }

        /// <summary>
        /// Gets the bound dimensions.
        /// </summary>
        /// <param name="xSize">The x size.</param>
        /// <param name="ySize">The y size.</param>
        /// <param name="zSize">The z size.</param>
        public void GetBoundDimensions(out float xSize, out float ySize, out float zSize)
        {
            vec3 diff = this.MaxPosition - this.MinPosition;
            xSize = Math.Abs(diff.x);
            ySize = Math.Abs(diff.y);
            zSize = Math.Abs(diff.z);
        }

        /// <summary>
        /// Render to the provided instance of GL.
        /// </summary>
        /// <param name="renderMode">The render mode.</param>
        public virtual void Render(RenderModes renderMode)
        {
            //  Push attributes, disable lighting.
            OpenGL.PushAttrib(OpenGL.GL_CURRENT_BIT | OpenGL.GL_ENABLE_BIT |
                OpenGL.GL_LINE_BIT | OpenGL.GL_POLYGON_BIT);
            OpenGL.Disable(OpenGL.GL_LIGHTING);
            OpenGL.Disable(OpenGL.GL_TEXTURE_2D);
            OpenGL.LineWidth(1.0f);
            OpenGL.Color(BoxColor.x, BoxColor.y, BoxColor.z, BoxColor.w);

            //QuadsDraw(gl);

            //GL.Color(1.0f, 0, 0);
            OpenGL.Begin(DrawMode.LineLoop);
            OpenGL.Vertex(MinPosition.x, MinPosition.y, MinPosition.z);
            OpenGL.Vertex(MaxPosition.x, MinPosition.y, MinPosition.z);
            OpenGL.Vertex(MaxPosition.x, MinPosition.y, MaxPosition.z);
            OpenGL.Vertex(MinPosition.x, MinPosition.y, MaxPosition.z);
            OpenGL.End();

            //GL.Color(0, 1.0f, 0);
            OpenGL.Begin(DrawMode.LineLoop);
            OpenGL.Vertex(MinPosition.x, MaxPosition.y, MinPosition.z);
            OpenGL.Vertex(MaxPosition.x, MaxPosition.y, MinPosition.z);
            OpenGL.Vertex(MaxPosition.x, MaxPosition.y, MaxPosition.z);
            OpenGL.Vertex(MinPosition.x, MaxPosition.y, MaxPosition.z);
            OpenGL.End();

            //GL.Color(0, 0, 1.0f);
            OpenGL.Begin(DrawMode.Lines);
            OpenGL.Vertex(MinPosition.x, MinPosition.y, MinPosition.z);
            OpenGL.Vertex(MinPosition.x, MaxPosition.y, MinPosition.z);
            OpenGL.Vertex(MaxPosition.x, MinPosition.y, MinPosition.z);
            OpenGL.Vertex(MaxPosition.x, MaxPosition.y, MinPosition.z);
            OpenGL.Vertex(MaxPosition.x, MinPosition.y, MaxPosition.z);
            OpenGL.Vertex(MaxPosition.x, MaxPosition.y, MaxPosition.z);
            OpenGL.Vertex(MinPosition.x, MinPosition.y, MaxPosition.z);
            OpenGL.Vertex(MinPosition.x, MaxPosition.y, MaxPosition.z);
            OpenGL.End();

            OpenGL.PopAttrib();
        }

        /// <summary>
        /// This simulates BoundingVolume's render method.
        /// </summary>
        /// <param name="renderMode"></param>
        private void QuadsDraw(RenderModes renderMode)
        {
            OpenGL.Begin(DrawMode.Quads);
            OpenGL.Vertex(maxPosition.x, maxPosition.y, minPosition.z);// Top Right Of The Quad (Top)
            OpenGL.Vertex(minPosition.x, maxPosition.y, minPosition.z);// Top Left Of The Quad (Top)
            OpenGL.Vertex(minPosition.x, maxPosition.y, maxPosition.z);// Bottom Left Of The Quad (Top)
            OpenGL.Vertex(maxPosition.x, maxPosition.y, maxPosition.z);// Bottom Right Of The Quad (Top)
            OpenGL.Vertex(maxPosition.x, minPosition.y, maxPosition.z);// Top Right Of The Quad (Bottom)
            OpenGL.Vertex(minPosition.x, minPosition.y, maxPosition.z);// Top Left Of The Quad (Bottom)
            OpenGL.Vertex(minPosition.x, minPosition.y, minPosition.z);// Bottom Left Of The Quad (Bottom)
            OpenGL.Vertex(maxPosition.x, minPosition.y, minPosition.z);// Bottom Right Of The Quad (Bottom)
            OpenGL.Vertex(maxPosition.x, maxPosition.y, maxPosition.z);// Top Right Of The Quad (Front)
            OpenGL.Vertex(minPosition.x, maxPosition.y, maxPosition.z);// Top Left Of The Quad (Front)
            OpenGL.Vertex(minPosition.x, minPosition.y, maxPosition.z);// Bottom Left Of The Quad (Front)
            OpenGL.Vertex(maxPosition.x, minPosition.y, maxPosition.z);// Bottom Right Of The Quad (Front)
            OpenGL.Vertex(maxPosition.x, minPosition.y, minPosition.z);// Top Right Of The Quad (Back)
            OpenGL.Vertex(minPosition.x, minPosition.y, minPosition.z);// Top Left Of The Quad (Back)
            OpenGL.Vertex(minPosition.x, maxPosition.y, minPosition.z);// Bottom Left Of The Quad (Back)
            OpenGL.Vertex(maxPosition.x, maxPosition.y, minPosition.z);// Bottom Right Of The Quad (Back)
            OpenGL.Vertex(minPosition.x, maxPosition.y, maxPosition.z);// Top Right Of The Quad (Left)
            OpenGL.Vertex(minPosition.x, maxPosition.y, minPosition.z);// Top Left Of The Quad (Left)
            OpenGL.Vertex(minPosition.x, minPosition.y, minPosition.z);// Bottom Left Of The Quad (Left)
            OpenGL.Vertex(minPosition.x, minPosition.y, maxPosition.z);// Bottom Right Of The Quad (Left)
            OpenGL.Vertex(maxPosition.x, maxPosition.y, minPosition.z);// Top Right Of The Quad (Right)
            OpenGL.Vertex(maxPosition.x, maxPosition.y, maxPosition.z);// Top Left Of The Quad (Right)
            OpenGL.Vertex(maxPosition.x, minPosition.y, maxPosition.z);// Bottom Left Of The Quad (Right)
            OpenGL.Vertex(maxPosition.x, minPosition.y, minPosition.z);// Bottom Right Of The Quad (Right)
            OpenGL.End();
        }

        public void SetBounds(vec3 min, vec3 max)
        {
            this.minPosition = min;
            this.maxPosition = max;
        }

        public void Set(float minX = 0, float minY = 0, float minZ = 0, float maxX = 0, float maxY = 0, float maxZ = 0)
        {
            this.minPosition.x = minX;
            this.minPosition.y = minY;
            this.minPosition.z = minZ;

            this.maxPosition.x = maxX;
            this.maxPosition.y = maxY;
            this.maxPosition.z = maxZ;
        }

        #endregion

        /// <summary>
        /// Make sure the bounding box covers specifed vec3.
        /// </summary>
        /// <param name="vertex"></param>
        public void Extend(vec3 vertex)
        {
            if (vertex.x < this.minPosition.x) { this.minPosition.x = vertex.x; }
            if (vertex.y < this.minPosition.y) { this.minPosition.y = vertex.y; }
            if (vertex.z < this.minPosition.z) { this.minPosition.z = vertex.z; }

            if (vertex.x > this.maxPosition.x) { this.maxPosition.x = vertex.x; }
            if (vertex.y > this.maxPosition.y) { this.maxPosition.y = vertex.y; }
            if (vertex.z > this.maxPosition.z) { this.maxPosition.z = vertex.z; }

        }

    }
}
