using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Base type for dependent actions.
    /// </summary>
    public abstract class DependentActionBase : ActionBase
    {
        /// <summary>
        /// Base type for rendering actions.
        /// </summary>
        /// <param name="scene"></param>
        public DependentActionBase(Scene scene) : base(scene) { }

        /// <summary>
        /// 
        /// </summary>
        public abstract void Act();

    }
}
