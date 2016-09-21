using System;
using System.Collections.Generic;
using System.Linq;

using System.Xml.Linq;

namespace CSharpGL.CSSLGenetator
{
    /// <summary>
    /// 持有从<see cref="IBufferable"/>到GLSL中in/uniform变量名的对应关系。
    /// 每个<see cref="IBufferable"/>和每个GLSL的代表（Renderer）都有一个Map关系。
    /// 这里存储的内容需要OpenGL开发者和APP开发者协商对接。
    /// 策略A：如果没有，或者map中有的名字不存在，就默认为两者使用的名字相同。
    /// 策略B：如果没有，或者map中有的名字不存在， 就说明此map不完整，即OpenGL开发者和APP开发者没有完全协商。
    /// 现在选择策略A。
    /// </summary>
    public class AttributeNameMap : IEnumerable<AttributeNameMap.NamePair>
    {
        private List<string> namesInShader = new List<string>();
        private List<string> namesInIBufferable = new List<string>();

        /// <summary>
        /// 持有从<see cref="IBufferable"/>到GLSL中in/uniform变量名的对应关系。
        /// 每个<see cref="IBufferable"/>和每个GLSL的代表（Renderer）都有一个Map关系。
        /// 这里存储的内容需要OpenGL开发者和APP开发者协商对接。
        /// 策略A：如果没有，或者map中有的名字不存在，就默认为两者使用的名字相同。
        /// 策略B：如果没有，或者map中有的名字不存在， 就说明此map不完整，即OpenGL开发者和APP开发者没有完全协商。
        /// 现在选择策略A。
        /// </summary>
        public AttributeNameMap() { }

        /// <summary>
        /// 持有从<see cref="IBufferable"/>到GLSL中in/uniform变量名的对应关系。
        /// 每个<see cref="IBufferable"/>和每个GLSL的代表（Renderer）都有一个Map关系。
        /// 这里存储的内容需要OpenGL开发者和APP开发者协商对接。
        /// 策略A：如果没有，或者map中有的名字不存在，就默认为两者使用的名字相同。
        /// 策略B：如果没有，或者map中有的名字不存在， 就说明此map不完整，即OpenGL开发者和APP开发者没有完全协商。
        /// 现在选择策略A。
        /// </summary>
        /// <param name="nameInShader"></param>
        /// <param name="nameInIBufferable"></param>
        public AttributeNameMap(string nameInShader, string nameInIBufferable)
        {
            this.Add(nameInShader, nameInIBufferable);
        }

        /// <summary>
        /// 持有从<see cref="IBufferable"/>到GLSL中in/uniform变量名的对应关系。
        /// 每个<see cref="IBufferable"/>和每个GLSL的代表（Renderer）都有一个Map关系。
        /// 这里存储的内容需要OpenGL开发者和APP开发者协商对接。
        /// 策略A：如果没有，或者map中有的名字不存在，就默认为两者使用的名字相同。
        /// 策略B：如果没有，或者map中有的名字不存在， 就说明此map不完整，即OpenGL开发者和APP开发者没有完全协商。
        /// 现在选择策略A。
        /// </summary>
        /// <param name="nameInShaders"></param>
        /// <param name="nameInIBufferables"></param>
        public AttributeNameMap(string[] nameInShaders, string[] nameInIBufferables)
        {
            if (nameInShaders == null || nameInIBufferables == null
                || nameInShaders.Length != nameInIBufferables.Length)
            { throw new ArgumentException(); }

            for (int i = 0; i < nameInShaders.Length; i++)
            {
                this.Add(nameInShaders[i], nameInIBufferables[i]);
            }
        }

        public void Add(string nameInShader, string nameInIBufferable)
        {
            this.namesInShader.Add(nameInShader);
            this.namesInIBufferable.Add(nameInIBufferable);
        }

        public XElement ToXElement()
        {
            XElement result = new XElement(typeof(AttributeNameMap).Name,
                from nameInShader in this.namesInShader
                join nameInIBufferable in this.namesInIBufferable
                on this.namesInShader.IndexOf(nameInShader) equals this.namesInIBufferable.IndexOf(nameInIBufferable)
                select new NamePair(nameInShader, nameInIBufferable).ToXElement()
                );

            return result;
        }

        public static AttributeNameMap Parse(XElement xElement)
        {
            if (xElement.Name != typeof(AttributeNameMap).Name) { throw new Exception(); }

            AttributeNameMap result = new AttributeNameMap();

            foreach (var item in xElement.Elements(typeof(NamePair).Name))
            {
                var pair = NamePair.Parse(item);
                result.namesInShader.Add(pair.VarNameInShader);
                result.namesInIBufferable.Add(pair.nameInIBufferable);
            }

            return result;
        }

        public IEnumerator<NamePair> GetEnumerator()
        {
            List<string> namesInShader = this.namesInShader;
            List<string> namesInIBufferable = this.namesInIBufferable;
            for (int i = 0; i < namesInShader.Count; i++)
            {
                yield return new NamePair(namesInShader[i], namesInIBufferable[i]);
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public class NamePair
        {
            private const string strVarNameInShader = "VarNameInShader";
            public string VarNameInShader { get; set; }

            private const string strNameInIBufferable = "NameInIBufferable";
            public string nameInIBufferable { get; set; }

            public NamePair(string nameInShader, string nameInIBufferable)
            {
                this.VarNameInShader = nameInShader;
                this.nameInIBufferable = nameInIBufferable;
            }

            public XElement ToXElement()
            {
                return new XElement(typeof(NamePair).Name,
                    new XAttribute(strVarNameInShader, VarNameInShader),
                    new XAttribute(strNameInIBufferable, nameInIBufferable));
            }

            public static NamePair Parse(XElement xElement)
            {
                if (xElement.Name != typeof(NamePair).Name)
                { throw new Exception(string.Format("name not match for {0}", typeof(NamePair).Name)); }

                NamePair result = new NamePair(
                    xElement.Attribute(strVarNameInShader).Value,
                    xElement.Attribute(strNameInIBufferable).Value);

                return result;
            }

            public override string ToString()
            {
                return string.Format("shader [{0}] -> model [{1}]", VarNameInShader, nameInIBufferable);
            }
        }
    }
}