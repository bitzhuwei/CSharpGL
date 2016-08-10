using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RendererGenerator
{
    public class VertexProperty
    {
        public string NameInShader { get; set; }
        public string NameInModel { get; set; }
        public Type PropertyType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameInShader"></param>
        /// <param name="nameInModel"></param>
        /// <param name="type"></param>
        public VertexProperty(string nameInShader, string nameInModel, Type type)
        {
            // TODO: Complete member initialization
            this.NameInShader = nameInShader;
            this.NameInModel = nameInModel;
            this.PropertyType = type;
        }

        public string ToGLSL()
        {
            return string.Format("in {0} {1};", this.PropertyType.Name, this.NameInShader);
        }

        public string BufferPtrName { get { return string.Format("{0}BufferPtr", this.NameInModel); } }
    }
}
