using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class ComponentBase
    {
        /// <summary>
        /// Game object that this componnet belongs to.
        /// </summary>
        public readonly GameObject gameObject;

        public ComponentBase(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }
    }
}
