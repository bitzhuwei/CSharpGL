using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    static class GLSnippetSearcher
    {
        // (action, node) -> snippet.
        static Dictionary<Type, Dictionary<Type, GLSnippet>> dictionary = new Dictionary<Type, Dictionary<Type, GLSnippet>>();

        /// <summary>
        /// Find the wanted <see cref="GLSnippet"/> according to specified <paramref name="action"/> and <paramref name="node"/>.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        public static GLSnippet Find(GLAction action, GLNode node)
        {
            Dictionary<Type, GLSnippet> dict = null;
            GLSnippet snippet = null;

            if (dictionary.TryGetValue(action.ThisTypeCache, out dict))
            {
                if (!dict.TryGetValue(node.ThisTypeCache, out snippet))
                {
                    snippet = CreateInstance(action, node);
                    dict.Add(node.ThisTypeCache, snippet);
                }
            }
            else
            {
                dict = new Dictionary<Type, GLSnippet>();
                snippet = CreateInstance(action, node);
                dict.Add(node.ThisTypeCache, snippet);
                dictionary.Add(action.ThisTypeCache, dict);
            }

            return snippet;
        }

        private static GLSnippet CreateInstance(GLAction action, GLNode node)
        {
            GLSnippet result = null;
            // TODO: This forces GLSnippet's class name's pattern.
            string prefix = action.ThisTypeCache.Name.Substring(0, action.ThisTypeCache.Name.Length - "Action".Length);
            string postfix = node.ThisTypeCache.Name.Substring(2);
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
