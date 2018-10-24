using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class EZMAnimTrack
    {
        // <AnimTrack name="RootNode" count="61" has_scale="true">
        /// <summary>
        /// Tracks a bone's states of all frames in one pose.
        /// </summary>
        /// <param name="xAnimTrack"></param>
        /// <returns></returns>
        public static EZMAnimTrack Parse(System.Xml.Linq.XElement xElement)
        {
            EZMAnimTrack result = null;
            if (xElement.Name == "AnimTrack")
            {
                result = new EZMAnimTrack();
                {
                    var name = xElement.Attribute("name");
                    if (name != null) { result.BoneName = name.Value; }
                }
                int count = 0;
                bool hasScale = false;
                {
                    var c = xElement.Attribute("count");
                    if (c != null) { count = int.Parse(c.Value); }
                    var h = xElement.Attribute("has_scale");
                    if (h != null) { hasScale = bool.Parse(h.Value); }
                }
                {
                    string[] parts = xElement.Value.Split(Separator.separators, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length % 10 != 0) { throw new Exception("Parsing failed."); }
                    var values = new float[parts.Length];
                    var states = new EZMBoneState[parts.Length / 10];
                    int index = 0;
                    vec3 p = new vec3(); Quaternion o = new Quaternion(); vec3 s = new vec3();
                    while (index < parts.Length)
                    {
                        {
                            var x = float.Parse(parts[index++]);
                            var y = float.Parse(parts[index++]);
                            var z = float.Parse(parts[index++]);
                            p = new vec3(x, y, z);
                        }
                        {
                            var x = float.Parse(parts[index++]);
                            var y = float.Parse(parts[index++]);
                            var z = float.Parse(parts[index++]);
                            var w = float.Parse(parts[index++]);
                            o = new Quaternion(x, y, z, w);
                        }
                        {
                            var x = float.Parse(parts[index++]);
                            var y = float.Parse(parts[index++]);
                            var z = float.Parse(parts[index++]);
                            s = new vec3(x, y, z);
                        }

                        states[index / 10 - 1] = new EZMBoneState(p, o, s);
                    }
                    result.States = states;
                }
            }

            return result;
        }

        public string BoneName { get; private set; }

        public EZMBone Bone { get; internal set; }

        public EZMBoneState[] States { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} {1} states.", this.BoneName, this.States.Length);
        }
    }
}
