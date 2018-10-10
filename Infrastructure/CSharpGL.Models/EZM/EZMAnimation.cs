using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.EZM
{
    class EZMAnimation
    {
        // <Animation name="Take 001" trackcount="60" framecount="61" duration="1.199999928" dtime="4">
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xAnimation"></param>
        /// <returns></returns>
        internal static EZMAnimation Parse(System.Xml.Linq.XElement xElement)
        {
            EZMAnimation result = null;
            if (xElement.Name == "Animation")
            {
                result = new EZMAnimation();
                result.Name = xElement.Attribute("name").Value;
                result.duration = float.Parse(xElement.Attribute("duration").Value);
                result.dtime = float.Parse(xElement.Attribute("dtime").Value);
                {
                    var xAnimTracks = xElement.Elements("AnimTrack");
                    var animTracks = new EZMAnimTrack[xAnimTracks.Count()];
                    int index = 0;
                    foreach (var xAnimTrack in xAnimTracks)
                    {
                        animTracks[index++] = EZMAnimTrack.Parse(xAnimTrack);
                    }
                    result.AnimTrack = animTracks;
                }
            }

            return result;
        }

        public string Name { get; private set; }

        public float duration { get; private set; }

        public float dtime { get; private set; }

        public EZMAnimTrack[] AnimTrack { get; private set; }
    }
}
