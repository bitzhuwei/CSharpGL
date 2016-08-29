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
    public class LegacyBoundingBoxRenderer : RendererBase, IBoundingBox, IModelSpace
    {

        /// <summary>
        /// Cuboid's color of its lines.
        /// </summary>
        public Color BoxColor { get; set; }

        /// <summary>
        /// Specify a cuboid that marks a model's edges.
        /// </summary>
        public LegacyBoundingBoxRenderer()
            : this(new vec3(-0.5f, -0.5f, -0.5f), new vec3(0.5f, 0.5f, 0.5f), Color.White)
        { }

        /// <summary>
        /// Specify a cuboid that marks a model's edges.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="color"></param>
        public LegacyBoundingBoxRenderer(vec3 min, vec3 max, Color color)
        {
            this.MinPosition = min;
            this.MaxPosition = max;
            this.BoxColor = color;

            this.Scale = new vec3(1, 1, 1);
            this.RotationAxis = new vec3(0, 1, 0);

            this.Lengths = max - min;
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
            this.RotationAngle += 3.0f;
            OpenGL.LoadIdentity();
            this.LegacyTransform();

            OpenGL.Color4f(BoxColor.R / 255.0f, BoxColor.G / 255.0f, BoxColor.B / 255.0f, BoxColor.A / 255.0f);

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
        }

        public vec3 WorldPosition { get; set; }

        public float RotationAngle { get; set; }

        public vec3 RotationAxis { get; set; }

        public vec3 Scale { get; set; }

        public vec3 Lengths { get; set; }
    }
}
