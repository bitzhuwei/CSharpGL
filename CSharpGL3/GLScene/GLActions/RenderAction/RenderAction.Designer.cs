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
        private static readonly Type type = typeof(RenderAction);

        /// <summary>
        /// 
        /// </summary>
        internal override Type ThisTypeCache
        {
            get { return type; }
        }

        // appliedNode -> snippet.
        private static readonly Dictionary<Type, GLSnippet> dictionary = new Dictionary<Type, GLSnippet>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="glNode"></param>
        /// <returns></returns>
        protected override GLSnippet FindSnippet(GLNode glNode)
        {
            Type nodeType = glNode.ThisTypeCache;
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
