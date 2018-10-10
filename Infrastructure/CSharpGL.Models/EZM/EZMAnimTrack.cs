using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.EZM
{
    class EZMAnimTrack
    {
        // <AnimTrack name="RootNode" count="61" has_scale="true">
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xAnimTrack"></param>
        /// <returns></returns>
        internal static EZMAnimTrack Parse(System.Xml.Linq.XElement xElement)
        {
            EZMAnimTrack result = null;
            if (xElement.Name == "AnimTrack")
            {
                result = new EZMAnimTrack();
                result.Name = xElement.Attribute("name").Value;
                int count = int.Parse(xElement.Attribute("count").Value);
                bool hasScale = bool.Parse(xElement.Attribute("has_scale").Value);
                {
                    // value: [ ... ] , [ ... ] , [ ... ] ..
                }
            }

            return result;
        }

        public string Name { get; private set; }

    }
}
