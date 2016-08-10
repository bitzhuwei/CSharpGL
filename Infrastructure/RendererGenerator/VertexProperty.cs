using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace RendererGenerator
{
    public class VertexProperty
    {
        private const string strNameInShader = "NameInShader";
        public string NameInShader { get; set; }
        private const string strNameInModel = "NameInModel";
        public string NameInModel { get; set; }
        private const string strPropertyType = "PropertyType";
        public Type PropertyType { get; set; }
        public string BufferPtrName { get { return string.Format("{0}BufferPtr", this.NameInModel); } }

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

        public static VertexProperty Parse(XElement xElement)
        {
            string nameInShader = xElement.Attribute(strNameInShader).Value;
            string nameInModel = xElement.Attribute(strNameInModel).Value;
            Type propertyType = Type.GetType(xElement.Attribute(strPropertyType).Value);
            var result = new VertexProperty(nameInShader, nameInModel, propertyType);
            return result;
        }

        public XElement ToXElement()
        {
            return new XElement(strVertexProperty,
                new XAttribute(strNameInShader, NameInShader),
                new XAttribute(strNameInModel, NameInModel),
                new XAttribute(strPropertyType, PropertyType.FullName));
        }

        public const string strVertexProperty = "VertexProperty";
    }
}
