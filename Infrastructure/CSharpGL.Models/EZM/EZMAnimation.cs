using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class EZMAnimation
    {
        // <Animation name="Take 001" trackcount="60" framecount="61" duration="1.199999928" dtime="4">
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xAnimation"></param>
        /// <returns></returns>
        public static EZMAnimation Parse(System.Xml.Linq.XElement xElement)
        {
            EZMAnimation result = null;
            if (xElement.Name == "Animation")
            {
                result = new EZMAnimation();
                {
                    var xAttr = xElement.Attribute("name");
                    if (xAttr != null) { result.Name = xAttr.Value; }
                }
                {
                    var xAttr = xElement.Attribute("trackcount");
                    if (xAttr != null) { result.TrackCount = int.Parse(xAttr.Value); }
                }
                {
                    var xAttr = xElement.Attribute("framecount");
                    if (xAttr != null) { result.FrameCount = int.Parse(xAttr.Value); }
                }
                {
                    var xAttr = xElement.Attribute("duration");
                    if (xAttr != null) { result.duration = float.Parse(xAttr.Value); }
                }
                {
                    var xAttr = xElement.Attribute("dtime");
                    if (xAttr != null) { result.dtime = float.Parse(xAttr.Value); }
                }
                {
                    var xAnimTracks = xElement.Elements("AnimTrack");
                    var animTracks = new EZMAnimTrack[xAnimTracks.Count()];
                    int index = 0;
                    foreach (var xAnimTrack in xAnimTracks)
                    {
                        animTracks[index++] = EZMAnimTrack.Parse(xAnimTrack);
                    }
                    result.AnimTracks = animTracks;
                }
            }

            return result;
        }

        public string Name { get; private set; }

        public int TrackCount { get; private set; }

        public int FrameCount { get; private set; }

        public float duration { get; private set; }

        public float dtime { get; private set; }

        public EZMAnimTrack[] AnimTracks { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}, {1} AnimTracks", this.Name, this.AnimTracks.Length);
        }
    }
}
