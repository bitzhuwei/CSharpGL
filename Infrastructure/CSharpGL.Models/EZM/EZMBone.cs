using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.EZM
{
    class EZMBone
    {
        // <Bone name="RootNode" orientation="0 0 0 1" position="0 0 0" scale="1 1 1"/>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xBone"></param>
        /// <returns></returns>
        internal static EZMBone Parse(System.Xml.Linq.XElement xElement)
        {
            EZMBone result = null;
            if (xElement.Name == "Bone")
            {
                result = new EZMBone();
                result.Name = xElement.Attribute("name").Value;
                {
                    string[] parts = xElement.Attribute("orientation").Value.Split(' ');
                    float x = float.Parse(parts[0]);
                    float y = float.Parse(parts[1]);
                    float z = float.Parse(parts[2]);
                    float w = float.Parse(parts[3]);
                    result.Orientation = new vec4(x, y, z, w);
                }
                {
                    string[] parts = xElement.Attribute("position").Value.Split(' ');
                    float x = float.Parse(parts[0]);
                    float y = float.Parse(parts[1]);
                    float z = float.Parse(parts[2]);
                    result.Position = new vec3(x, y, z);
                }
                {
                    string[] parts = xElement.Attribute("scale").Value.Split(' ');
                    float x = float.Parse(parts[0]);
                    float y = float.Parse(parts[1]);
                    float z = float.Parse(parts[2]);
                    result.Scale = new vec3(x, y, z);
                }
            }

            return result;
        }

        public string Name { get; private set; }

        public vec4 Orientation { get; private set; }

        public vec3 Position { get; private set; }

        public vec3 Scale { get; private set; }
    }
}
