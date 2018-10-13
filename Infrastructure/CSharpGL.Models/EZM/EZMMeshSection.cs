using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.EZM
{
    public class EZMMeshSection
    {
        // <MeshSection material="character_anim:headM" ctype="fff fff ff ff ff ffff hhhh" semantic="position normal texcoord1 texcoord2 texcoord3 blendweights blendindices">
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xMeshSection"></param>
        /// <returns></returns>
        public static EZMMeshSection Parse(System.Xml.Linq.XElement xElement)
        {
            EZMMeshSection result = null;
            if (xElement.Name == "MeshSection")
            {
                result = new EZMMeshSection();
                {
                    var attr = xElement.Attribute("material");
                    if (attr != null) { result.MaterialName = attr.Value; }
                }
                {
                    var attr = xElement.Attribute("ctype");
                    if (attr != null) { result.Ctype = attr.Value; }
                }
                {
                    var attr = xElement.Attribute("semantic");
                    if (attr != null) { result.Semantic = attr.Value; }
                }
                {
                    var aabb = xElement.Element("MeshAABB");
                    if (aabb != null)
                    {
                        var xMin = aabb.Attribute("min");
                        if (xMin != null)
                        {
                            string[] parts = xMin.Value.Split(Separator.separators, StringSplitOptions.RemoveEmptyEntries);
                            var x = float.Parse(parts[0]);
                            var y = float.Parse(parts[1]);
                            var z = float.Parse(parts[2]);
                            result.Min = new vec3(x, y, z);
                        }
                        var xMax = aabb.Attribute("max");
                        if (xMax != null)
                        {
                            string[] parts = xMax.Value.Split(Separator.separators, StringSplitOptions.RemoveEmptyEntries);
                            var x = float.Parse(parts[0]);
                            var y = float.Parse(parts[1]);
                            var z = float.Parse(parts[2]);
                            result.Max = new vec3(x, y, z);
                        }
                    }
                }
                {
                    result.Indexbuffer = ParseIndexbuffer(xElement.Element("indexbuffer"));
                }
            }

            return result;
        }

        private static uint[] ParseIndexbuffer(System.Xml.Linq.XElement xElement)
        {
            uint[] result = null;
            if (xElement.Name == "indexbuffer")
            {
                //int triangleCount = int.Parse(xElement.Attribute("triangle_count").Value);
                string[] parts = xElement.Value.Split(Separator.separators, StringSplitOptions.RemoveEmptyEntries);
                result = new uint[parts.Length];
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = uint.Parse(parts[i]);
                }
            }

            return result;
        }

        public string MaterialName { get; private set; }

        public EZMMaterial Material { get; internal set; }

        public string Ctype { get; private set; }

        public string Semantic { get; private set; }

        public uint[] Indexbuffer { get; private set; }

        public vec3 Min { get; private set; }

        public vec3 Max { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", this.MaterialName, this.Ctype, this.Semantic, this.Indexbuffer.Length);
        }
    }
}
