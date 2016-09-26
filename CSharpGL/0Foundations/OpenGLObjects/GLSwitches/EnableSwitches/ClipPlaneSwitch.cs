using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// specify a plane against which all geometry is clipped.
    /// <para>you can't use glClipPlane and vertex programs together.</para>
    /// </summary>
    public class ClipPlaneSwitch : EnableSwitch
    {
        private static readonly double[] defaultEquation = new double[4] { 0, 1, 0, 0, };
        private static int maxClipPlanes;

        static ClipPlaneSwitch()
        {
            var result = new int[1];
            OpenGL.GetInteger(GetTarget.MaxClipPlanes, result);
            maxClipPlanes = result[0];
        }

        /// <summary>
        /// you can't use glClipPlane and vertex programs together.
        /// </summary>
        [Description("you can't use glClipPlane and vertex programs together.")]
        public int MaxClipPlanes { get { return maxClipPlanes; } }

        //private uint planeIndex;

        /// <summary>
        /// Specifies which clipping plane is being positioned. Symbolic names of the form GL_CLIP_PLANEi, where i is an integer between 0 and GL_MAX_CLIP_PLANES -1 , are accepted.
        /// <para>Just put in 0, 1, ... GL_MAX_CLIP_PLANES -1.
        /// </para>
        /// </summary>
        public uint PlaneIndex
        {
            get { return this.Capacity - OpenGL.GL_CLIP_PLANE0; }
            set
            {
                if (value >= maxClipPlanes)
                {
                    throw new System.ArgumentOutOfRangeException(string.Format(
                        "Plane index must be in range of [0, {0})!", maxClipPlanes));
                }
                else
                {
                    this.Capacity = OpenGL.GL_CLIP_PLANE0 + value;
                }
            }
        }

        private double[] equation;

        /// <summary>
        /// Specifies the address of an array of four double-precision floating-point values. These values are interpreted as a plane equation.
        /// </summary>
        public double[] Equation
        {
            get { return equation; }
            set
            {
                if (value == null || value.Length != 4)
                {
                    throw new System.ArgumentException(string.Format(
                      "Equation must be an array with length of 4!"));
                }
                else
                {
                    equation = value;
                }
            }
        }

        /// <summary>
        /// specify a plane against which all geometry is clipped.
        /// </summary>
        public ClipPlaneSwitch()
            : this(enableCapacity: true)
        {
        }

        /// <summary>
        /// specify a plane against which all geometry is clipped.
        /// </summary>
        /// <param name="enableCapacity">Enable() or Disable() this capacity?</param>
        public ClipPlaneSwitch(bool enableCapacity)
            : this(0u, defaultEquation, enableCapacity)
        {
        }

        /// <summary>
        /// specify a plane against which all geometry is clipped.
        /// </summary>
        /// <param name="planeIndex">Specifies which clipping plane is being positioned. Symbolic names of the form GL_CLIP_PLANEi, where i is an integer between 0 and GL_MAX_CLIP_PLANES -1 , are accepted.
        /// <para>Just put in 0, 1, ... GL_MAX_CLIP_PLANES -1./// </para>
        /// </param>
        /// <param name="equation">Specifies the address of an array of four double-precision floating-point values. These values are interpreted as a plane equation.</param>
        public ClipPlaneSwitch(uint planeIndex, double[] equation)
            : this(planeIndex, equation, true)
        {
        }

        /// <summary>
        /// specify a plane against which all geometry is clipped.
        /// </summary>
        /// <param name="planeIndex">Specifies which clipping plane is being positioned. Symbolic names of the form GL_CLIP_PLANEi, where i is an integer between 0 and GL_MAX_CLIP_PLANES -1 , are accepted.
        /// <para>Just put in 0, 1, ... GL_MAX_CLIP_PLANES -1./// </para>
        /// </param>
        /// <param name="equation">Specifies the address of an array of four double-precision floating-point values. These values are interpreted as a plane equation.</param>
        /// <param name="enableCapacity">Enable() or Disable() this capacity?</param>
        public ClipPlaneSwitch(uint planeIndex, double[] equation, bool enableCapacity)
            : base(OpenGL.GL_CLIP_PLANE0 + planeIndex, enableCapacity)
        {
            this.Init(planeIndex, equation);
        }

        private void Init(uint planeIndex, double[] equation)
        {
            this.PlaneIndex = planeIndex;
            this.Equation = equation;
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            if (this.EnableCapacity)
            {
                return string.Format("Enabled glClipPlane(OpenGL.GL_CLIP_PLANE0 + {0}, {1});", this.PlaneIndex, this.Equation.PrintArray(", "));
            }
            else
            {
                return string.Format("Disabled glClipPlane(OpenGL.GL_CLIP_PLANE0 + {0}, {1});", this.PlaneIndex, this.Equation.PrintArray(", "));
            }
        }

        /// <summary>
        ///
        /// </summary>
        protected override void SwitchOn()
        {
            base.SwitchOn();

            if (this.enableCapacityWhenSwitchOn)
            {
                OpenGL.ClipPlane(this.Capacity, this.equation);
            }
        }
    }
}