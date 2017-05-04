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
        internal override Type SelfTypeCache
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
            Type nodeType = glNode.SelfTypeCache;
            GLSnippet snippet = null;
            if (!dictionary.TryGetValue(nodeType, out snippet))
            {
                snippet = CreateInstance(this.SelfTypeCache, glNode.SelfTypeCache);
                dictionary.Add(nodeType, snippet);
            }

            return snippet;
        }

        private static GLSnippet CreateInstance(Type actionType, Type nodeType)
        {
            GLSnippet result = null;
            // NOTE: This forces GLSnippet's class name's pattern.
            string prefix = actionType.Name.Substring(0, actionType.Name.Length - "Action".Length);
            string postfix = nodeType.Name.Substring("GL".Length, nodeType.Name.Length - "GL".Length - "Node".Length);
            try
            {
                Type type = Type.GetType(prefix + "_" + postfix);
                result = Activator.CreateInstance(type) as GLSnippet;
            }
            catch (Exception)
            {
            }

            return result;
        }
    }
}
