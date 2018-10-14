using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
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
                    if (parent != null) { result.ParentName = parent.Value; }
                }
                {
                    vec3 p = new vec3(); vec4 o = new vec4(); vec3 s = new vec3();
                    var orientation = xElement.Attribute("orientation");
                    if (orientation != null)
                    {
                        string[] parts = orientation.Value.Split(' ');
                        float x = float.Parse(parts[0]);
                        float y = float.Parse(parts[1]);
                        float z = float.Parse(parts[2]);
                        float w = float.Parse(parts[3]);
                        o = new vec4(x, y, z, w);
                    }
                    var position = xElement.Attribute("position");
                    if (position != null)
                    {
                        string[] parts = position.Value.Split(' ');
                        float x = float.Parse(parts[0]);
                        float y = float.Parse(parts[1]);
                        float z = float.Parse(parts[2]);
                        p = new vec3(x, y, z);
                    }
                    var scale = xElement.Attribute("scale");
                    if (scale != null)
                    {
                        string[] parts = scale.Value.Split(' ');
                        float x = float.Parse(parts[0]);
                        float y = float.Parse(parts[1]);
                        float z = float.Parse(parts[2]);
                        s = new vec3(x, y, z);
                    }

                    result.State = new EZMBoneState(p, o, s);
                }
            }

            return result;
        }

        public string Name { get; private set; }

        internal string ParentName { get; private set; }

        public EZMBone Parent { get; internal set; }

        public EZMBoneState State { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}: Parent:{1} {2}.", this.Name, this.ParentName, this.State);
        }
    }
}
