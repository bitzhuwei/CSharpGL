using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class EZMBone
    {
        private static int idCounter = 0;
        public int Id { get; private set; }

        public EZMBone() { Id = idCounter++; }

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
                    vec3 p = new vec3(); Quaternion o = new Quaternion(); vec3 s = new vec3();
                    var orientation = xElement.Attribute("orientation");
                    if (orientation != null)
                    {
                        string[] parts = orientation.Value.Split(' ');
                        float x = float.Parse(parts[0]);
                        float y = float.Parse(parts[1]);
                        float z = float.Parse(parts[2]);
                        float w = float.Parse(parts[3]);
                        o = new Quaternion(w, x, y, z);
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

                    result.state = new EZMBoneState(p, o, s);
                    result.OriginalState = result.state;
                }
            }

            return result;
        }

        public string Name { get; private set; }

        internal string ParentName { get; private set; }

        public EZMBone Parent { get; internal set; }

        internal List<EZMBone> children = new List<EZMBone>();

        public EZMBoneState state;

        public EZMBoneState OriginalState { get; private set; }

        /// <summary>
        /// cache combined matrix.
        /// </summary>
        public mat4 combinedMat;

        /// <summary>
        /// cache inversed combined matrix.
        /// </summary>
        public mat4 inverseCombinedMatrix;

        public override string ToString()
        {
            return string.Format("{0}: Parent:{1} {2}.", this.Name, this.ParentName, this.state);
        }
    }
}
