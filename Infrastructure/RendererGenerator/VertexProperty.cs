using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RendererGenerator
{
    class VertexProperty
    {
        private string nameInShader;
        private string nameInModel;
        private Type type;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameInShader"></param>
        /// <param name="nameInModel"></param>
        /// <param name="type"></param>
        public VertexProperty(string nameInShader, string nameInModel, Type type)
        {
            // TODO: Complete member initialization
            this.nameInShader = nameInShader;
            this.nameInModel = nameInModel;
            this.type = type;
        }

        public string ToGLSL()
        {
            return string.Format("in {0} {1};", this.type.Name, this.nameInShader);
        }
    }
}
