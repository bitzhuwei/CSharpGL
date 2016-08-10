using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RendererGenerator
{
    /// <summary>
    /// data structure of Renderer.
    /// </summary>
    class DataStructure
    {
        public string TargetName { get; set; }

        private List<VertexProperty> propertyList = new List<VertexProperty>();

        internal List<VertexProperty> PropertyList
        {
            get { return propertyList; }
        }

        public string ModelName { get { return string.Format("{0}Model", this.TargetName); } }

        public string RendererName { get { return string.Format("{0}Renderer", this.TargetName); } }

        /// <summary>
        /// If true, use ZeroIndexBuffer; otherwise, use OneIndexBuffer<>.
        /// </summary>
        public bool ZeroIndexBuffer { get; set; }

        public DrawMode DrawMode { get; set; }

        public DataStructure(string targetName)
        {
            this.TargetName = targetName;
        }



    }
}
