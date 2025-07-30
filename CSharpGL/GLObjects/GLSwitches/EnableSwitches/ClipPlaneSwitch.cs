﻿using System.ComponentModel;

namespace CSharpGL {
    // TODO: 'glClipPlane' doesn't work in modern opengl. I don't know why.
    // I didn't try legacy opengl, because I can clip planes in shader.
    /// <summary>
    /// specify a plane against which all geometry is clipped.
    /// <para>you can't use glClipPlane and vertex programs together.</para>
    /// </summary>
    public unsafe class ClipPlaneSwitch : EnableSwitch {
        private static readonly double[] defaultEquation = new double[4] { 0, 1, 0, 0, };
        private static int maxClipPlanes;

        static ClipPlaneSwitch() {
            var gl = GL.current; if (gl == null) { return; }
            var result = stackalloc int[1];
            gl.glGetIntegerv((GLenum)GetTarget.MaxClipPlanes, result);
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
        public uint PlaneIndex {
            get { return this.Capacity - GL.GL_CLIP_PLANE0; }
            set {
                if (value >= maxClipPlanes) {
                    throw new System.ArgumentOutOfRangeException(string.Format(
                        "Plane index must be in range of [0, {0})!", maxClipPlanes));
                }
                else {
                    this.Capacity = GL.GL_CLIP_PLANE0 + value;
                }
            }
        }

        private double[] equation;

        /// <summary>
        /// Specifies the address of an array of four double-precision floating-point values. These values are interpreted as a plane equation.
        /// </summary>
        public double[] Equation {
            get { return equation; }
            set {
                if (value == null || value.Length != 4) {
                    throw new System.ArgumentException(string.Format(
                      "Equation must be an array with length of 4!"));
                }
                else {
                    equation = value;
                }
            }
        }

        // Activator needs a non-parameter constructor.
        /// <summary>
        /// specify a plane against which all geometry is clipped.
        /// </summary>
        public ClipPlaneSwitch()
            : this(enableCapacity: true) {
        }

        /// <summary>
        /// specify a plane against which all geometry is clipped.
        /// </summary>
        /// <param name="enableCapacity">Enable() or Disable() this capacity?</param>
        public ClipPlaneSwitch(bool enableCapacity)
            : this(0u, defaultEquation, enableCapacity) {
        }

        /// <summary>
        /// specify a plane against which all geometry is clipped.
        /// </summary>
        /// <param name="planeIndex">Specifies which clipping plane is being positioned. Symbolic names of the form GL_CLIP_PLANEi, where i is an integer between 0 and GL_MAX_CLIP_PLANES -1 , are accepted.
        /// <para>Just put in 0, 1, ... GL_MAX_CLIP_PLANES -1./// </para>
        /// </param>
        /// <param name="equation">Specifies the address of an array of four double-precision floating-point values. These values are interpreted as a plane equation.</param>
        public ClipPlaneSwitch(uint planeIndex, double[] equation)
            : this(planeIndex, equation, true) {
        }

        /// <summary>
        /// specify a plane against which all geometry is clipped.
        /// </summary>
        /// <param name="planeIndex">Specifies which clipping plane is being positioned. Symbolic names of the form GL_CLIP_PLANEi, where i is an integer between 0 and GL_MAX_CLIP_PLANES -1 , are accepted.
        /// <para>Just put in 0, 1, ... GL_MAX_CLIP_PLANES -1./// </para>
        /// </param>
        /// <param name="equation">Specifies the address of an array of four double-precision floating-point values. These values are interpreted as a plane equation.</param>
        /// <param name="enableCapacity">Enable() or Disable() this capacity?</param>
        public ClipPlaneSwitch(uint planeIndex, double[] equation, bool enableCapacity = true)
            : base(GL.GL_CLIP_PLANE0 + planeIndex, enableCapacity) {
            this.PlaneIndex = planeIndex;
            if (equation == null || equation.Length != 4) {
                throw new System.ArgumentException(string.Format(
                  "Equation must be an array with length of 4!"));
            }
            else {
                this.equation = equation;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString() {
            if (this.EnableCapacity) {
                return string.Format("Enabled glClipPlane(GL.GL_CLIP_PLANE0 + {0}, {1});", this.PlaneIndex, this.Equation.PrintArray(", "));
            }
            else {
                return string.Format("Disabled glClipPlane(GL.GL_CLIP_PLANE0 + {0}, {1});", this.PlaneIndex, this.Equation.PrintArray(", "));
            }
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOn() {
            var gl = GL.current; if (gl == null) { return; }
            base.StateOn();

            if (this.enableCapacityWhenStateOn) {
                gl.glClipPlane(this.Capacity, this.equation);
            }
        }
    }
}