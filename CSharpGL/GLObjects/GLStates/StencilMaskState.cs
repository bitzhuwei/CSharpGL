using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// glStencilMask
    /// </summary>
    public class StencilMaskState : GLState
    {
        /// <summary>
        ///
        /// </summary>
        public uint Mask { get; set; }

        /// <summary>
        /// glStencilMask
        /// </summary>
        /// <param name="mask"></param>
        public StencilMaskState(uint mask)
        {
            this.Mask = mask;
        }

        private float[] original = new float[1];

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            return string.Format("glStencilMask({0});", Mask);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOn()
        {
            GL.Instance.GetFloatv((uint)GetTarget.StencilValueMask, original);

            GL.Instance.StencilMask(this.Mask);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOff()
        {
            //GL.Instance.LineWidth(original[0]);
        }
    }
}
