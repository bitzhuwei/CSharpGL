using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// A node in scene that maintains some <see cref="GLState"/>s.
    /// </summary>
    public class LightModelNode : SceneNode
    {
        public LightModelNode(LightModel model)
        {

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum LightModel
    {
        /// <summary>
        /// Render a model with position and direct color. No light applied.
        /// </summary>
        NoLight,
    }
}
