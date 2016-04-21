using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSharpGL.Buffers
{
    /// <summary>
    /// 持有从<see cref="IConvert2BufferPointer"/>到GLSL中in/uniform变量名的对应关系。
    /// 每个<see cref="IConvert2BufferPointer"/>和每个GLSL的代表（Renderer）都有一个Map关系。
    /// 这里存储的内容需要OpenGL开发者和APP开发者协商对接。
    /// 策略A：如果没有，或者map中有的名字不存在，就默认为两者使用的名字相同。
    /// 策略B：如果没有，或者map中有的名字不存在， 就说明此map不完整，即OpenGL开发者和APP开发者没有完全协商。
    /// 现在选择策略A。
    /// </summary>
    public class UniformNameMap : IEnumerable<CSharpGL.Buffers.UniformNameMap.NamePair>
    {
        List<string> namesInShader = new List<string>();
        List<string> namesInIConvert2BufferRenderer = new List<string>();

        //public string GetNameInIConvert2BufferRenderer(string nameInShader)
        //{
        //    string result = null;
        //    int index = this.namesInShader.IndexOf(nameInShader);
        //    if (index < 0)
        //    {
        //        result = nameInShader;
        //    }
        //    else
        //    {
        //        result = this.namesInIConvert2BufferRenderer[index];
        //    }

        //    return result;
        //}

        public string this[string nameInShader]
        {
            get
            {
                string result = null;
                int index = this.namesInIConvert2BufferRenderer.IndexOf(nameInShader);
                if (index < 0)
                {
                    result = nameInShader;
                }
                else
                {
                    result = this.namesInShader[index];
                }

                return result;
            }
        }

        public void Add(string nameInIConvert2BufferRenderer, string nameInShader)
        {
            this.namesInIConvert2BufferRenderer.Add(nameInIConvert2BufferRenderer);
            this.namesInShader.Add(nameInShader);
        }

        //const string strRendererType = "RendererType";
        ///// <summary>
        ///// type's fullname
        ///// </summary>
        //public string RendererType { get; set; }

        //const string strDumperType = "DumperType";
        ///// <summary>
        ///// Type's fullname
        ///// </summary>
        //public string DumperType { get; set; }


        public XElement ToXElement()
        {
            XElement result = new XElement(typeof(PropertyNameMap).Name,
                //new XAttribute(strRendererType, RendererType),
                //new XAttribute(strDumperType, DumperType),
                from nameInIConvert2BufferRenderer in this.namesInIConvert2BufferRenderer
                join nameInShader in this.namesInShader
                on this.namesInIConvert2BufferRenderer.IndexOf(nameInIConvert2BufferRenderer) equals this.namesInShader.IndexOf(nameInShader)
                select new NamePair(nameInIConvert2BufferRenderer, nameInShader).ToXElement()
                );

            return result;
        }

        public static UniformNameMap Parse(XElement xElement)
        {
            if (xElement.Name != typeof(UniformNameMap).Name) { throw new Exception(); }

            UniformNameMap result = new UniformNameMap();
            //result.RendererType = xElement.Attribute(strRendererType).Value;
            //result.DumperType = xElement.Attribute(strDumperType).Value;

            foreach (var item in xElement.Elements(typeof(NamePair).Name))
            {
                var pair = NamePair.Parse(item);
                result.namesInIConvert2BufferRenderer.Add(pair.NameInIConvert2BufferRenderer);
                result.namesInShader.Add(pair.UniformNameInShader);
            }

            return result;
        }

        public IEnumerator<NamePair> GetEnumerator()
        {
            List<string> namesInIConvert2BufferRenderer = this.namesInIConvert2BufferRenderer;
            List<string> namesInShader = this.namesInShader;
            for (int i = 0; i < namesInShader.Count; i++)
            {
                yield return new NamePair(namesInIConvert2BufferRenderer[i], namesInShader[i]);
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public class NamePair
        {

            const string strNameInIConvert2BufferRenderer = "NameInIConvert2BufferRenderer";
            public string NameInIConvert2BufferRenderer { get; set; }

            const string strUniformNameInShader = "UniformNameInShader";
            public string UniformNameInShader { get; set; }


            public NamePair(string nameInIConvert2BufferRenderer, string uniformNameInShader)
            {
                this.NameInIConvert2BufferRenderer = nameInIConvert2BufferRenderer;
                this.UniformNameInShader = uniformNameInShader;
            }

            public XElement ToXElement()
            {
                return new XElement(typeof(NamePair).Name,
                    new XAttribute(strNameInIConvert2BufferRenderer, NameInIConvert2BufferRenderer),
                    new XAttribute(strUniformNameInShader, UniformNameInShader));
            }

            public static NamePair Parse(XElement xElement)
            {
                if (xElement.Name != typeof(NamePair).Name)
                { throw new Exception(string.Format("name not match for {0}", typeof(NamePair).Name)); }

                NamePair result = new NamePair(
                    xElement.Attribute(strNameInIConvert2BufferRenderer).Value,
                    xElement.Attribute(strUniformNameInShader).Value);

                return result;
            }

            public override string ToString()
            {
                return string.Format("model [{0}] -> shader \"uniform\" [{1}]", NameInIConvert2BufferRenderer, UniformNameInShader);
            }
        }
    }


}
