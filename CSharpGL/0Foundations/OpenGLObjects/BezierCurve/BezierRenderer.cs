using System;
using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public abstract partial class BezierRenderer : RendererBase, IDisposable
    {
        /// <summary>
        ///
        /// </summary>
        public BezierRenderer() { }

        /// <summary>
        /// The control points.
        /// </summary>
        private UnmanagedArray<vec3> controlPoints;

        /// <summary>
        /// Draw points flag.
        /// </summary>
        private bool drawPoints = true;

        /// <summary>
        /// Draw lines flag.
        /// </summary>
        private bool drawLines = true;

        /// <summary>
        /// Gets or sets the control points.
        /// </summary>
        /// <value>
        /// The control points.
        /// </value>
        [Description("The control points."), Category("BezierRendererBase")]
        public UnmanagedArray<vec3> ControlPoints
        {
            get { return controlPoints; }
            set
            {
                if (value != controlPoints)
                {
                    if (controlPoints != null)
                    { controlPoints.Dispose(); }
                    controlPoints = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [draw control points].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [draw control points]; otherwise, <c>false</c>.
        /// </value>
        [Description("Should the control points be drawn?"), Category("BezierRendererBase")]
        public bool DrawControlPoints
        {
            get { return drawPoints; }
            set { drawPoints = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [draw control grid].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [draw control grid]; otherwise, <c>false</c>.
        /// </value>
        [Description("Should the control grid be drawn?"), Category("Evaluator")]
        public bool DrawControlGrid
        {
            get { return drawLines; }
            set { drawLines = value; }
        }
    }
}