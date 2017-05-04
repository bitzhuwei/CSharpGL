using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Action that applys to a scene made of <see cref="GLNode"/>.
    /// </summary>
    public abstract class GLAction
    {
        internal abstract Type ThisTypeCache { get; }

        private GLNode appliedNode;

        /// <summary>
        /// node that this action applies to.
        /// </summary>
        protected GLNode AppliedNode
        {
            get { return appliedNode; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="glNode"></param>
        public void Apply(GLNode glNode)
        {
            this.appliedNode = glNode;
        }

        ///// <summary>
        ///// Give me an static dictionary.
        ///// </summary>
        //internal protected abstract Dictionary<Type, GLSnippet> Dictionary { get; }

        /// <summary>
        /// Find the wanted <see cref="GLSnippet"/> according to specified <paramref name="glNode"/>.
        /// </summary>
        /// <param name="glNode"></param>
        /// <returns></returns>
        protected abstract GLSnippet FindSnippet(GLNode glNode);


    }
}
