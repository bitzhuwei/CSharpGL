using System.Xml.Linq;

namespace RendererGenerator
{
    public class VertexAttribute
    {
        private const string strNameInShader = "NameInShader";
        public string NameInShader { get; set; }
        private const string strNameInModel = "NameInModel";
        public string NameInModel { get; set; }
        private const string strAttributeType = "AttributeType";
        public string AttributeType { get; set; }
        public string BufferPtrName { get { return string.Format("{0}BufferPtr", this.NameInModel); } }

        /// <summary>
        ///
        /// </summary>
        /// <param name="nameInShader"></param>
        /// <param name="nameInModel"></param>
        /// <param name="attributeType"></param>
        public VertexAttribute(string nameInShader, string nameInModel, string attributeType)
        {
            this.NameInShader = nameInShader;
            this.NameInModel = nameInModel;
            this.AttributeType = attributeType;
        }

        public string ToGLSL()
        {
            return string.Format("in {0} {1};", this.AttributeType, this.NameInShader);
        }

        public static VertexAttribute Parse(XElement xElement)
        {
            string nameInShader = xElement.Attribute(strNameInShader).Value;
            string nameInModel = xElement.Attribute(strNameInModel).Value;
            string attributeType = xElement.Attribute(strAttributeType).Value;
            var result = new VertexAttribute(nameInShader, nameInModel, attributeType);
            return result;
        }

        public XElement ToXElement()
        {
            return new XElement(strVertexAttribute,
                new XAttribute(strNameInShader, NameInShader),
                new XAttribute(strNameInModel, NameInModel),
                new XAttribute(strAttributeType, AttributeType));
        }

        public const string strVertexAttribute = "VertexAttribute";
    }
}