using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.EZM
{
    public class EZMBone
    {
        // <Bone name="RootNode" parent="xx" orientation="0 0 0 1" position="0 0 0" scale="1 1 1"/>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xBone"></param>
        /// <returns></returns>
        public static EZMBone Parse(System.Xml.Linq.XElement xElement)
        {
            EZMBone result = null;
            if (xElement.Name == "Bone")
            {
                result = new EZMBone();
                {
                    var name = xElement.Attribute("name");
                    if (name != null) { result.Name = name.Value; }
                }
                {
                    var parent = xElement.Attribute("parent");
                    if (parent != null) { result.Parent = parent.Value; }
                }
                {
                    var orientation = xElement.Attribute("orientation");
                    if (orientation != null)
                    {
                        string[] parts = orientation.Value.Split(' ');
                        float x = float.Parse(parts[0]);
                        float y = float.Parse(parts[1]);
                        float z = float.Parse(parts[2]);
                        float w = float.Parse(parts[3]);
                        result.Orientation = new vec4(x, y, z, w);
                    }
                }
                {
                    var position = xElement.Attribute("position");
                    if (position != null)
                    {
                        string[] parts = position.Value.Split(' ');
                        float x = float.Parse(parts[0]);
                        float y = float.Parse(parts[1]);
                        float z = float.Parse(parts[2]);
                        result.Position = new vec3(x, y, z);
                    }
                }
                {
                    var scale = xElement.Attribute("scale");
                    if (scale != null)
                    {
                        string[] parts = scale.Value.Split(' ');
                        float x = float.Parse(parts[0]);
                        float y = float.Parse(parts[1]);
                        float z = float.Parse(parts[2]);
                        result.Scale = new vec3(x, y, z);
                    }
                }
            }

            return result;
        }

        public string Name { get; private set; }

        public string Parent { get; private set; }

        public vec4 Orientation { get; private set; }

        public vec3 Position { get; private set; }

        public vec3 Scale { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}: Parent:{1} Orientation:{2} Pos:{3} Scale:{4}.", this.Name, this.Parent, this.Orientation, this.Position, this.Scale);
        }
    }
}
