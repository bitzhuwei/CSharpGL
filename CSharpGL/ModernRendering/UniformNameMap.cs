using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class UniformNameMap : IEnumerable<UniformNameMap.NamePair>
    {
        List<string> namesInShader = new List<string>();
        List<string> namesInIBufferable = new List<string>();

        public string this[string nameInIBufferable]
        {
            get
            {
                string result = null;
                int index = this.namesInIBufferable.IndexOf(nameInIBufferable);
                if (index < 0)
                {
                    result = nameInIBufferable;
                }
                else
                {
                    result = this.namesInShader[index];
                }

                return result;
            }
        }

        public void Add(string nameInIBufferable, string nameInShader)
        {
            this.namesInIBufferable.Add(nameInIBufferable);
            this.namesInShader.Add(nameInShader);
        }

        public XElement ToXElement()
        {
            XElement result = new XElement(typeof(UniformNameMap).Name,
                from nameInIBufferable in this.namesInIBufferable
                join nameInShader in this.namesInShader
                on this.namesInIBufferable.IndexOf(nameInIBufferable) equals this.namesInShader.IndexOf(nameInShader)
                select new NamePair(nameInIBufferable, nameInShader).ToXElement()
                );

            return result;
        }

        public static UniformNameMap Parse(XElement xElement)
        {
            if (xElement.Name != typeof(UniformNameMap).Name) { throw new Exception(); }

            UniformNameMap result = new UniformNameMap();

            foreach (var item in xElement.Elements(typeof(NamePair).Name))
            {
                var pair = NamePair.Parse(item);
                result.namesInIBufferable.Add(pair.NameInIBufferable);
                result.namesInShader.Add(pair.UniformNameInShader);
            }

            return result;
        }

        public IEnumerator<NamePair> GetEnumerator()
        {
            List<string> namesInIBufferable = this.namesInIBufferable;
            List<string> namesInShader = this.namesInShader;
            for (int i = 0; i < namesInShader.Count; i++)
            {
                yield return new NamePair(namesInIBufferable[i], namesInShader[i]);
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public class NamePair
        {

            const string strNameInIBufferable = "NameInIBufferable";
            public string NameInIBufferable { get; set; }

            const string strUniformNameInShader = "UniformNameInShader";
            public string UniformNameInShader { get; set; }


            public NamePair(string nameInIBufferable, string uniformNameInShader)
            {
                this.NameInIBufferable = nameInIBufferable;
                this.UniformNameInShader = uniformNameInShader;
            }

            public XElement ToXElement()
            {
                return new XElement(typeof(NamePair).Name,
                    new XAttribute(strNameInIBufferable, NameInIBufferable),
                    new XAttribute(strUniformNameInShader, UniformNameInShader));
            }

            public static NamePair Parse(XElement xElement)
            {
                if (xElement.Name != typeof(NamePair).Name)
                { throw new Exception(string.Format("name not match for {0}", typeof(NamePair).Name)); }

                NamePair result = new NamePair(
                    xElement.Attribute(strNameInIBufferable).Value,
                    xElement.Attribute(strUniformNameInShader).Value);

                return result;
            }

            public override string ToString()
            {
                return string.Format("model [{0}] -> shader \"uniform\" [{1}]", NameInIBufferable, UniformNameInShader);
            }
        }
    }


}
