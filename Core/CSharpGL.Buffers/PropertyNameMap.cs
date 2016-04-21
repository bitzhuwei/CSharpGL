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
    public class PropertyNameMap : IEnumerable<CSharpGL.Buffers.PropertyNameMap.NamePair>
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

        //public string this[string nameInShader]
        //{
        //    get
        //    {
        //        string result = null;
        //        int index = this.namesInShader.IndexOf(nameInShader);
        //        if (index < 0)
        //        {
        //            result = nameInShader;
        //        }
        //        else
        //        {
        //            result = this.namesInIConvert2BufferRenderer[index];
        //        }

        //        return result;
        //    }
        //}

        public void Add(string nameInShader, string nameInIConvert2BufferRenderer)
        {
            this.namesInShader.Add(nameInShader);
            this.namesInIConvert2BufferRenderer.Add(nameInIConvert2BufferRenderer);
        }

        //const string strDumperType = "DumperType";
        ///// <summary>
        ///// Type's fullname
        ///// </summary>
        //public string DumperType { get; set; }

        //const string strRendererType = "RendererType";
        ///// <summary>
        ///// type's fullname
        ///// </summary>
        //public string RendererType { get; set; }

        public XElement ToXElement()
        {
            XElement result = new XElement(typeof(PropertyNameMap).Name,
                //new XAttribute(strDumperType, DumperType),
                //new XAttribute(strRendererType, RendererType),
                from nameInShader in this.namesInShader
                join nameInIConvert2BufferRenderer in this.namesInIConvert2BufferRenderer
                on this.namesInShader.IndexOf(nameInShader) equals this.namesInIConvert2BufferRenderer.IndexOf(nameInIConvert2BufferRenderer)
                select new NamePair(nameInShader, nameInIConvert2BufferRenderer).ToXElement()
                );

            return result;
        }

        public static PropertyNameMap Parse(XElement xElement)
        {
            if (xElement.Name != typeof(PropertyNameMap).Name) { throw new Exception(); }

            PropertyNameMap result = new PropertyNameMap();
            //result.DumperType = xElement.Attribute(strDumperType).Value;
            //result.RendererType = xElement.Attribute(strRendererType).Value;

            foreach (var item in xElement.Elements(typeof(NamePair).Name))
            {
                var pair = NamePair.Parse(item);
                result.namesInShader.Add(pair.VarNameInShader);
                result.namesInIConvert2BufferRenderer.Add(pair.NameInIConvert2BufferRenderer);
            }

            return result;
        }

        public IEnumerator<NamePair> GetEnumerator()
        {
            List<string> namesInShader = this.namesInShader;
            List<string> namesInIConvert2BufferRenderer = this.namesInIConvert2BufferRenderer;
            for (int i = 0; i < namesInShader.Count; i++)
            {
                yield return new NamePair(namesInShader[i], namesInIConvert2BufferRenderer[i]);
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public class NamePair
        {
            const string strVarNameInShader = "VarNameInShader";
            public string VarNameInShader { get; set; }

            const string strNameInIConvert2BufferRenderer = "NameInIConvert2BufferRenderer";
            public string NameInIConvert2BufferRenderer { get; set; }

            public NamePair(string nameInShader, string nameInIConvert2BufferRenderer)
            {
                this.VarNameInShader = nameInShader;
                this.NameInIConvert2BufferRenderer = nameInIConvert2BufferRenderer;
            }

            public XElement ToXElement()
            {
                return new XElement(typeof(NamePair).Name,
                    new XAttribute(strVarNameInShader, VarNameInShader),
                    new XAttribute(strNameInIConvert2BufferRenderer, NameInIConvert2BufferRenderer));
            }

            public static NamePair Parse(XElement xElement)
            {
                if (xElement.Name != typeof(NamePair).Name)
                { throw new Exception(string.Format("name not match for {0}", typeof(NamePair).Name)); }

                NamePair result = new NamePair(
                    xElement.Attribute(strVarNameInShader).Value,
                    xElement.Attribute(strNameInIConvert2BufferRenderer).Value);

                return result;
            }

            public override string ToString()
            {
                return string.Format("shader [{0}] -> model [{1}]", VarNameInShader, NameInIConvert2BufferRenderer);
            }
        }
    }

}
