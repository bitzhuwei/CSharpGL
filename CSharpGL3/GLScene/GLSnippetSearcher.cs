using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    static class GLSnippetSearcher
    {
        // (glAction, glNode) -> snippet.
        static Dictionary<Type, Dictionary<Type, GLSnippet>> dictionary = new Dictionary<Type, Dictionary<Type, GLSnippet>>();

        /// <summary>
        /// Find the wanted <see cref="GLSnippet"/> according to specified <paramref name="glAction"/> and <paramref name="glNode"/>.
        /// </summary>
        /// <param name="glAction"></param>
        /// <param name="glNode"></param>
        /// <returns></returns>
        public static GLSnippet Find(GLAction glAction, GLNode glNode)
        {
            Type actionType = glAction.GetType();
            Type nodeType = glNode.GetType();
            Dictionary<Type, GLSnippet> dict = null;
            GLSnippet snippet = null;

            if (dictionary.TryGetValue(actionType, out dict))
            {
                if (!dict.TryGetValue(nodeType, out snippet))
                {
                    snippet = CreateInstance(glAction, glNode);
                    dict.Add(nodeType, snippet);
                }
            }
            else
            {
                dict = new Dictionary<Type, GLSnippet>();
                snippet = CreateInstance(glAction, glNode);
                dict.Add(nodeType, snippet);
                dictionary.Add(actionType, dict);
            }

            return snippet;
        }

        private static GLSnippet CreateInstance(GLAction someAction, GLNode glSomeNode)
        {
            Type actionType = someAction.GetType();
            Type nodeType = glSomeNode.GetType();

            GLSnippet result = null;
            // TODO: This forces GLSnippet's class name's pattern.
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
