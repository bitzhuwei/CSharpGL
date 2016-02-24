using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSharpGL.Buffers
{
    /// <summary>
    /// 持有从<see cref="IDumpBufferRenderers"/>到GLSL中in变量名的对应关系。
    /// 每个<see cref="IDumpBufferRenderers"/>和每个GLSL的代表（Renderer）都有一个Map关系。
    /// 如果没有，或者map中有的名字不存在，就默认为两者使用的名字相同。
    /// 这里存储的内容需要OpenGL开发者和APP开发者协商对接。
    /// </summary>
    public class BufferNameMap
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();

        public string GetNameInIDumpBufferRenderers(string nameInShader)
        {
            string result = null;
            if (!this.dictionary.TryGetValue(nameInShader, out result))
            {
                result = nameInShader;
            }

            return result;
        }

        public void Add(string nameInShader, string nameInIDumpBufferRenderers)
        {
            this.dictionary.Add(nameInShader, nameInIDumpBufferRenderers);
        }

        const string strDumperType = "DumperType";
        /// <summary>
        /// Type's fullname
        /// </summary>
        public string DumperType { get; set; }

        const string strRendererType = "RendererType";
        /// <summary>
        /// type's fullname
        /// </summary>
        public string RendererType { get; set; }

        public XElement ToXElement()
        {
            XElement result = new XElement(typeof(BufferNameMap).Name,
                new XAttribute(strDumperType, DumperType),
                new XAttribute(strRendererType, RendererType),
                from item in this.dictionary
                select KeyValuePairHelper.ToXElement(item)
                );

            return result;
        }

        public static BufferNameMap Parse(XElement xElement)
        {
            if (xElement.Name != typeof(BufferNameMap).Name) { throw new Exception(); }

            BufferNameMap result = new BufferNameMap();
            result.DumperType = xElement.Attribute(strDumperType).Value;
            result.RendererType = xElement.Attribute(strRendererType).Value;

            foreach (var item in xElement.Elements(KeyValuePairHelper.strItem))
            {
                var pair = KeyValuePairHelper.Parse(item);
                result.dictionary.Add(pair.Key, pair.Value);
            }

            return result;
        }

        static class KeyValuePairHelper
        {
            public const string strItem = "Item";

            const string strKey = "Key";

            const string strValue = "Value";

            public static XElement ToXElement(KeyValuePair<string, string> item)
            {
                return new XElement(strItem,
                    new XAttribute(strKey, item.Key),
                    new XAttribute(strValue, item.Value));
            }

            public static KeyValuePair<string, string> Parse(XElement xElement)
            {
                if (xElement.Name != strItem) { throw new Exception(); }

                KeyValuePair<string, string> result = new KeyValuePair<string, string>(
                    xElement.Attribute(strKey).Value,
                    xElement.Attribute(strValue).Value);

                return result;
            }

        }
    }


}
