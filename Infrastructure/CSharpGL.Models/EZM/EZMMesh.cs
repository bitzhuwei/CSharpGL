using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CSharpGL.EZM
{
    class EZMMesh
    {
        // <Mesh name="him" skeleton="null" submesh_count="5">
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xElement"></param>
        /// <returns></returns>
        public static EZMMesh Parse(XElement xElement)
        {
            EZMMesh result = null;
            if (xElement.Name == "Mesh")
            {
                result = new EZMMesh();
                result.Name = xElement.Attribute("name").Value;
                result.Skeleton = xElement.Attribute("skeleton").Value;
                result.Vertexbuffer = EZMVertexbuffer.Parse(xElement.Element("vertexbuffer"));
                {
                    var xMeshSections = xElement.Elements("MeshSection");
                    var meshSections = new EZMMeshSection[xMeshSections.Count()];
                    int index = 0;
                    foreach (var xMeshSection in xMeshSections)
                    {
                        meshSections[index++] = EZMMeshSection.Parse(xMeshSection);
                    }
                    result.MeshSections = meshSections;
                }
            }

            return result;
        }

        public string Name { get; private set; }

        public string Skeleton { get; private set; }

        public EZMVertexbuffer Vertexbuffer { get; private set; }

        public EZMMeshSection[] MeshSections { get; private set; }

    }
}
