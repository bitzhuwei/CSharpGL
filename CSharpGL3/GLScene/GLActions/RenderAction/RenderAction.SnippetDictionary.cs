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
        static Dictionary<Type, GLSnippet> dictionary = new Dictionary<Type, GLSnippet>();

        /// <summary>
        /// provides a dictionary to cache <see cref="GLSnippet"/>s.
        /// </summary>
        protected internal override Dictionary<Type, GLSnippet> Dictionary
        {
            get { return dictionary; }
        }
    }
}
