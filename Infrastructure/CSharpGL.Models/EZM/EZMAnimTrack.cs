using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.EZM
{
    public class EZMAnimTrack
    {
        private static readonly char[] separators = new char[] { ' ', ',' };

        // <AnimTrack name="RootNode" count="61" has_scale="true">
        /// <summary>
        /// 
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
                    if (name != null) { result.Name = name.Value; }
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
                    string[] parts = xElement.Value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    var values = new float[parts.Length];
                    for (int i = 0; i < parts.Length; i++)
                    {
                        values[i] = float.Parse(parts[i]);
                    }
                    result.Values = values;
                }
            }

            return result;
        }

        public string Name { get; private set; }

        public float[] Values { get; private set; }

    }
}
