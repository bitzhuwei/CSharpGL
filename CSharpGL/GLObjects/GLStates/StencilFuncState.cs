using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// glStencilFunc
    /// </summary>
    public class StencilFuncState : GLState
    {
        /// <summary>
        ///
        /// </summary>
        public EStencilFunc Func { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int Reference { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public uint Mask { get; private set; }

        /// <summary>
        /// glStencilFunc
        /// </summary>
        /// <param name="func"></param>
        /// <param name="reference"></param>
        /// <param name="mask"></param>
        public StencilFuncState(EStencilFunc func, int reference, uint mask)
        {
            this.Func = func;
            this.Reference = reference;
            this.Mask = mask;
        }

        private float[] original = new float[10];

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            return string.Format("glStencilFunc({0}, {1}, {2});", Func);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOn()
        {
            GL.Instance.GetFloatv((uint)GetTarget.StencilFunc, original);

            GL.Instance.StencilFunc((uint)this.Func, this.Reference, this.Mask);
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
