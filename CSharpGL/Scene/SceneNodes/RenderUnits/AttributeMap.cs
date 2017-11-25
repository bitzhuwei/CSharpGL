using System;
using System.Collections.Generic;
using System.Linq;

using System.Xml.Linq;

namespace CSharpGL
{
    /// <summary>
    /// 持有从<see cref="IBufferSource"/>到GLSL中in变量名的对应关系。
    /// 每个<see cref="IBufferSource"/>和每个<see cref="RenderMethod"/>都有一个Map关系。
    /// <para>Relations between vertex attribute buffers and 'in' variables in GLSL vertex shader.</para>
    /// <para>This relation map connects <see cref="IBufferSource"/> to <see cref="ModernNode"/>.</para>
    /// </summary>
    public class AttributeMap : IEnumerable<AttributeMap.NamePair>
    {
        private List<string> namesInShader = new List<string>();
        private List<string> namesInIBufferSource = new List<string>();

        /// <summary>
        /// 持有从<see cref="IBufferSource"/>到GLSL中in变量名的对应关系。
        /// 每个<see cref="IBufferSource"/>和每个<see cref="ModernNode"/>都有一个Map关系。
        /// <para>Relations between vertex attribute buffers and 'in' variables in GLSL vertex shader.</para>
        /// <para>This relation map connects <see cref="IBufferSource"/> to <see cref="ModernNode"/>.</para>
        /// </summary>
        public AttributeMap() { }

        /// <summary>
        /// 持有从<see cref="IBufferSource"/>到GLSL中in变量名的对应关系。
        /// 每个<see cref="IBufferSource"/>和每个<see cref="ModernNode"/>都有一个Map关系。
        /// <para>Relations between vertex attribute buffers and 'in' variables in GLSL vertex shader.</para>
        /// <para>This relation map connects <see cref="IBufferSource"/> to <see cref="ModernNode"/>.</para>
        /// </summary>
        /// <param name="nameInShader">'vPos' in vertex shader(in vec3 vPos;)</param>
        /// <param name="nameInIBufferSource">user defined identifier for a buffer.</param>
        public AttributeMap(string nameInShader, string nameInIBufferSource)
        {
            this.Add(nameInShader, nameInIBufferSource);
        }

        /// <summary>
        /// 持有从<see cref="IBufferSource"/>到GLSL中in变量名的对应关系。
        /// 每个<see cref="IBufferSource"/>和每个<see cref="ModernNode"/>都有一个Map关系。
        /// <para>Relations between vertex attribute buffers and 'in' variables in GLSL vertex shader.</para>
        /// <para>This relation map connects <see cref="IBufferSource"/> to <see cref="ModernNode"/>.</para>
        /// </summary>
        /// <param name="nameInShader">'vPos' in vertex shader(in vec3 vPos;)</param>
        /// <param name="nameInIBufferSource">user defined identifier for a buffer.</param>
        public AttributeMap(string[] nameInShader, string[] nameInIBufferSource)
        {
            if (nameInShader == null || nameInIBufferSource == null
                || nameInShader.Length != nameInIBufferSource.Length)
            { throw new ArgumentException(); }

            for (int i = 0; i < nameInShader.Length; i++)
            {
                this.Add(nameInShader[i], nameInIBufferSource[i]);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="nameInShader">'vPos' in vertex shader(in vec3 vPos;)</param>
        /// <param name="nameInIBufferSource">user defined identifier for a buffer.</param>
        public void Add(string nameInShader, string nameInIBufferSource)
        {
            if (this.namesInShader.Contains(nameInShader))
            { throw new ArgumentException(string.Format("name[{0}] in shader already registered!", nameInShader)); }

            this.namesInShader.Add(nameInShader);
            this.namesInIBufferSource.Add(nameInIBufferSource);
        }

        ///// <summary>
        /////
        ///// </summary>
        ///// <returns></returns>
        //public XElement ToXElement()
        //{
        //    XElement result = new XElement(typeof(AttributeMap).Name,
        //        from nameInShader in this.namesInShader
        //        join nameInIBufferSource in this.namesInIBufferSource
        //        on this.namesInShader.IndexOf(nameInShader) equals this.namesInIBufferSource.IndexOf(nameInIBufferSource)
        //        select new NamePair(nameInShader, nameInIBufferSource).ToXElement()
        //        );

        //    return result;
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="xElement"></param>
        ///// <returns></returns>
        //public static AttributeMap Parse(XElement xElement)
        //{
        //    if (xElement.Name != typeof(AttributeMap).Name) { throw new Exception(); }

        //    AttributeMap result = new AttributeMap();

        //    foreach (XElement item in xElement.Elements(typeof(NamePair).Name))
        //    {
        //        var pair = NamePair.Parse(item);
        //        result.namesInShader.Add(pair.VarNameInShader);
        //        result.namesInIBufferSource.Add(pair.NameInIBufferSource);
        //    }

        //    return result;
        //}

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IEnumerator<NamePair> GetEnumerator()
        {
            List<string> namesInShader = this.namesInShader;
            List<string> namesInIBufferSource = this.namesInIBufferSource;
            for (int i = 0; i < namesInShader.Count; i++)
            {
                yield return new NamePair(namesInShader[i], namesInIBufferSource[i]);
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
            private const string strVarNameInShader = "VarNameInShader";

            /// <summary>
            ///
            /// </summary>
            public string VarNameInShader { get; set; }

            private const string strNameInIBufferSource = "NameInIBufferSource";

            /// <summary>
            ///
            /// </summary>
            public string NameInIBufferSource { get; set; }

            /// <summary>
            ///
            /// </summary>
            /// <param name="nameInShader"></param>
            /// <param name="nameInIBufferSource"></param>
            public NamePair(string nameInShader, string nameInIBufferSource)
            {
                this.VarNameInShader = nameInShader;
                this.NameInIBufferSource = nameInIBufferSource;
            }

            /// <summary>
            ///
            /// </summary>
            /// <returns></returns>
            public XElement ToXElement()
            {
                return new XElement(typeof(NamePair).Name,
                    new XAttribute(strVarNameInShader, VarNameInShader),
                    new XAttribute(strNameInIBufferSource, NameInIBufferSource));
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
                    xElement.Attribute(strNameInIBufferSource).Value);

                return result;
            }

            /// <summary>
            ///
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return string.Format("shader [{0}] -> model [{1}]", VarNameInShader, NameInIBufferSource);
            }
        }
    }
}