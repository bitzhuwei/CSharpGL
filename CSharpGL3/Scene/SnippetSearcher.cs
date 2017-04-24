using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    static class SnippetSearcher
    {
        static Dictionary<Type, Dictionary<Type, Snippet>> dictionary = new Dictionary<Type, Dictionary<Type, Snippet>>();

        /// <summary>
        /// Find the wanted <see cref="Snippet"/> according to specified <paramref name="action"/> and <paramref name="node"/>.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        public static Snippet Find(SceneAction action, GLNode node)
        {
            Dictionary<Type, Snippet> dict = null;
            Snippet snippet = null;

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
                dict = new Dictionary<Type, Snippet>();
                snippet = CreateInstance(action, node);
                dict.Add(node.ThisTypeCache, snippet);
                dictionary.Add(action.ThisTypeCache, dict);
            }

            return snippet;
        }

        private static Snippet CreateInstance(SceneAction action, GLNode node)
        {
            Snippet result = null;
            // TODO: This forces Snippet's class name's pattern.
            string prefix = action.ThisTypeCache.Name.Substring(0, action.ThisTypeCache.Name.Length - "Action".Length);
            string postfix = node.ThisTypeCache.Name.Substring(2);
            try
            {
                Type type = Type.GetType(prefix + "_" + postfix);
                result = Activator.CreateInstance(type) as Snippet;
            }
            catch (Exception)
            {
            }

            return result;
        }
    }
}
