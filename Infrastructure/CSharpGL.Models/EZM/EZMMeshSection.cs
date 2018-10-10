using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.EZM
{
    class EZMMeshSection
    {
        // <MeshSection material="character_anim:headM" ctype="fff fff ff ff ff ffff hhhh" semantic="position normal texcoord1 texcoord2 texcoord3 blendweights blendindices">
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xMeshSection"></param>
        /// <returns></returns>
        internal static EZMMeshSection Parse(System.Xml.Linq.XElement xElement)
        {
            EZMMeshSection result = null;
            if (xElement.Name == "MeshSection")
            {
                result = new EZMMeshSection();
                result.Material = xElement.Attribute("material").Value;
                result.Ctype = xElement.Attribute("ctype").Value;
                result.Semantic = xElement.Attribute("semantic").Value;
                result.Indexbuffer = ParseIndexbuffer(xElement.Element("indexbuffer"));
            }

            return result;
        }

        private static readonly char[] separators = new char[] { ' ', ',' };
        private static uint[] ParseIndexbuffer(System.Xml.Linq.XElement xElement)
        {
            uint[] result = null;
            if (xElement.Name == "indexbuffer")
            {
                int triangleCount = int.Parse(xElement.Attribute("triangle_count").Value);
                result = new uint[triangleCount * 3];
                string[] parts = xElement.Value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != result.Length) { throw new Exception(string.Format("EZMMeshSection: parts [{0}] != result [{1}]", parts.Length, result.Length)); }
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = uint.Parse(parts[i]);
                }
            }

            return result;
        }

        public string Material { get; private set; }

        public string Ctype { get; private set; }

        public string Semantic { get; private set; }

        public uint[] Indexbuffer { get; private set; }
    }
}
