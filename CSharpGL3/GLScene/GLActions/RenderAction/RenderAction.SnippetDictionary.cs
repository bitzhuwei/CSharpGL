using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class RenderAction
    {
        // appliedNode -> snippet.
        static Dictionary<Type, GLSnippet> dictionary = new Dictionary<Type, GLSnippet>();

        /// <summary>
        /// Find the wanted <see cref="GLSnippet"/> according to specified <paramref name="glAction"/> and <paramref name="glNode"/>.
        /// </summary>
        /// <param name="glAction"></param>
        /// <param name="glNode"></param>
        /// <returns></returns>
        private GLSnippet Find(GLNode glNode)
        {
            Type nodeType = glNode.GetType();
            GLSnippet snippet = null;
            if (!dictionary.TryGetValue(nodeType, out snippet))
            {
                snippet = GLSnippetHelper.CreateInstance(this, glNode);
                dictionary.Add(nodeType, snippet);
            }

            return snippet;
        }

    }
}
