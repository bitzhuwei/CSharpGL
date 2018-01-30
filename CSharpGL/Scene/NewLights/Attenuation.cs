using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Attenuation of light.
    /// <para>光源的衰减参数。</para>
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public class Attenuation
    {
        /// <summary>
        /// 
        /// </summary>
        public float Constant { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float Linear { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float Exp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="constant"></param>
        /// <param name="linear"></param>
        /// <param name="exp"></param>
        public Attenuation(float constant, float linear, float exp)
        {
            this.Constant = constant;
            this.Linear = linear;
            this.Exp = exp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("constant:{0}, linear:{1}, exp:{2}",
                this.Constant, this.Linear, this.Exp);
        }
    }
}
