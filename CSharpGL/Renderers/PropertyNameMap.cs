using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Linq;

namespace CSharpGL
{
    /// <summary>
    /// 持有从<see cref="IBufferable"/>到GLSL中in/uniform变量名的对应关系。
    /// 每个<see cref="IBufferable"/>和每个GLSL的代表（Renderer）都有一个Map关系。
    /// 这里存储的内容需要OpenGL开发者和APP开发者协商对接。
    /// 策略A：如果没有，或者map中有的名字不存在，就默认为两者使用的名字相同。
    /// 策略B：如果没有，或者map中有的名字不存在， 就说明此map不完整，即OpenGL开发者和APP开发者没有完全协商。
    /// 现在选择策略A。
    /// </summary>
    public class PropertyNameMap : IEnumerable<PropertyNameMap.NamePair>
    {
        List<string> namesInShader = new List<string>();
        List<string> namesInIBufferable = new List<string>();

        /// <summary>
        /// 持有从<see cref="IBufferable"/>到GLSL中in/uniform变量名的对应关系。
        /// 每个<see cref="IBufferable"/>和每个GLSL的代表（Renderer）都有一个Map关系。
        /// 这里存储的内容需要OpenGL开发者和APP开发者协商对接。
        /// 策略A：如果没有，或者map中有的名字不存在，就默认为两者使用的名字相同。
        /// 策略B：如果没有，或者map中有的名字不存在， 就说明此map不完整，即OpenGL开发者和APP开发者没有完全协商。
        /// 现在选择策略A。
        /// </summary>
        public PropertyNameMap() { }

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
        public PropertyNameMap(string nameInShader, string nameInIBufferable)
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
        public PropertyNameMap(string[] nameInShaders, string[] nameInIBufferables)
        {
            if (nameInShaders == null || nameInIBufferables == null
                || nameInShaders.Length != nameInIBufferables.Length)
            { throw new ArgumentException(); }

            for (int i = 0; i < nameInShaders.Length; i++)
            {
                this.Add(nameInShaders[i], nameInIBufferables[i]);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameInShader"></param>
        /// <param name="nameInIBufferable"></param>
        public void Add(string nameInShader, string nameInIBufferable)
        {
            this.namesInShader.Add(nameInShader);
            this.namesInIBufferable.Add(nameInIBufferable);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public XElement ToXElement()
        {
            XElement result = new XElement(typeof(PropertyNameMap).Name,
                from nameInShader in this.namesInShader
                join nameInIBufferable in this.namesInIBufferable
                on this.namesInShader.IndexOf(nameInShader) equals this.namesInIBufferable.IndexOf(nameInIBufferable)
                select new NamePair(nameInShader, nameInIBufferable).ToXElement()
                );

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xElement"></param>
        /// <returns></returns>
        public static PropertyNameMap Parse(XElement xElement)
        {
            if (xElement.Name != typeof(PropertyNameMap).Name) { throw new Exception(); }

            PropertyNameMap result = new PropertyNameMap();

            foreach (var item in xElement.Elements(typeof(NamePair).Name))
            {
                var pair = NamePair.Parse(item);
                result.namesInShader.Add(pair.VarNameInShader);
                result.namesInIBufferable.Add(pair.nameInIBufferable);
            }

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        public class NamePair
        {
            const string strVarNameInShader = "VarNameInShader";
            /// <summary>
            /// 
            /// </summary>
            public string VarNameInShader { get; set; }

            const string strNameInIBufferable = "NameInIBufferable";
            /// <summary>
            /// 
            /// </summary>
            public string nameInIBufferable { get; set; }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="nameInShader"></param>
            /// <param name="nameInIBufferable"></param>
            public NamePair(string nameInShader, string nameInIBufferable)
            {
                this.VarNameInShader = nameInShader;
                this.nameInIBufferable = nameInIBufferable;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public XElement ToXElement()
            {
                return new XElement(typeof(NamePair).Name,
                    new XAttribute(strVarNameInShader, VarNameInShader),
                    new XAttribute(strNameInIBufferable, nameInIBufferable));
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="xElement"></param>
            /// <returns></returns>
            public static NamePair Parse(XElement xElement)
            {
                if (xElement.Name != typeof(NamePair).Name)
                { throw new Exception(string.Format("name not match for {0}", typeof(NamePair).Name)); }

                NamePair result = new NamePair(
                    xElement.Attribute(strVarNameInShader).Value,
                    xElement.Attribute(strNameInIBufferable).Value);

                return result;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return string.Format("shader [{0}] -> model [{1}]", VarNameInShader, nameInIBufferable);
            }
        }
    }

}
