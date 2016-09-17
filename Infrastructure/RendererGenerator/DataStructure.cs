using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace RendererGenerator
{
    /// <summary>
    /// data structure of Renderer.
    /// </summary>
    internal class DataStructure
    {
        private const string strTargetName = "TargetName";
        public string TargetName { get; set; }

        private const string strPropertyList = "PropertyList";
        private List<VertexAttribute> propertyList = new List<VertexAttribute>();

        internal List<VertexAttribute> PropertyList
        {
            get { return propertyList; }
        }

        public string ModelName { get { return string.Format("{0}Model", this.TargetName); } }

        public string RendererName { get { return string.Format("{0}Renderer", this.TargetName); } }

        private const string strZeroIndexBuffer = "ZeroIndexBuffer";

        /// <summary>
        /// If true, use ZeroIndexBuffer; otherwise, use OneIndexBuffer<>.
        /// </summary>
        public bool ZeroIndexBuffer { get; set; }

        private const string strDrawMode = "DrawMode";
        public DrawMode DrawMode { get; set; }

        public DataStructure()
        {
        }

        public static DataStructure Parse(XElement xElement)
        {
            string targetName = xElement.Attribute(strTargetName).Value;
            bool zeroIndexBuffer = bool.Parse(xElement.Attribute(strZeroIndexBuffer).Value);
            DrawMode mode = (DrawMode)Enum.Parse(typeof(DrawMode), xElement.Attribute(strDrawMode).Value);
            var result = new DataStructure();
            result.TargetName = targetName;
            result.ZeroIndexBuffer = zeroIndexBuffer;
            result.DrawMode = mode;
            foreach (var item in xElement.Elements(VertexAttribute.strVertexAttribute))
            {
                VertexAttribute property = VertexAttribute.Parse(item);
                result.propertyList.Add(property);
            }

            return result;
        }

        public XElement ToXElement()
        {
            return new XElement(RendererGenerator,
                new XAttribute(strTargetName, TargetName),
                new XAttribute(strZeroIndexBuffer, ZeroIndexBuffer),
                new XAttribute(strDrawMode, DrawMode),
                from item in this.propertyList
                select item.ToXElement()
                );
        }

        private const string RendererGenerator = "RendererGenerator";
    }
}