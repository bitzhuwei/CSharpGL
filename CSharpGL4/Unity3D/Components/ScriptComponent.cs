using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ScriptComponent : ComponentBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameObject">Game object that this componnet belongs to.</param>
        public ScriptComponent(GameObject gameObject) : base(gameObject) { }

        public virtual void Update() { }
    }
}
