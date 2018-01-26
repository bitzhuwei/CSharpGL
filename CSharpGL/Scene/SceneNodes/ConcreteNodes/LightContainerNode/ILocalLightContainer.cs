using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    // TODO: delete this interface.
    /// <summary>
    /// contains some lights that affects its children node.
    /// </summary>
    public interface ILocalLightContainer
    {
        /// <summary>
        /// 
        /// </summary>
        List<LightBase> LightList { get; }
    }
}
