using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Winform
{
    /// <summary>
    /// 配色方案
    /// </summary>
    class ColorBar
    {
        /// <summary>
        /// 获取默认的配色方案
        /// </summary>
        /// <returns></returns>
        public static ColorBar GetDefault()
        {
            List<ColorCoordTuple> list = new List<ColorCoordTuple>();
            list.Add(new ColorCoordTuple() { Color = new vec3(0 / 255.0f, 22.0f / 255.0f, 76.0f / 255.0f), Coord = 0.0f, });
            list.Add(new ColorCoordTuple() { Color = new vec3(0 / 255.0f, 193.0f / 255.0f, 136.0f / 255.0f), Coord = 0.25f, });
            list.Add(new ColorCoordTuple() { Color = new vec3(166 / 255.0f, 255.0f / 255.0f, 27.0f / 255.0f), Coord = 0.5f, });
            list.Add(new ColorCoordTuple() { Color = new vec3(255 / 255.0f, 173.0f / 255.0f, 0.0f / 255.0f), Coord = 0.75f, });
            list.Add(new ColorCoordTuple() { Color = new vec3(255 / 255.0f, 8.0f / 255.0f, 2.0f / 255.0f), Coord = 1.0f, });

            ColorBar result = new ColorBar(list);
            return result;
        }

        List<ColorCoordTuple> colorList = new List<ColorCoordTuple>();
        public ColorBar(IEnumerable<ColorCoordTuple> colors)
        {
            if (colors == null)
            { throw new ArgumentNullException("colors"); }
            if (colors.Count() < 2)
            { throw new ArgumentException("template colors size error"); }

            this.colorList.AddRange(colors);
        }

        /// <summary>
        /// 插值获取颜色
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public vec3 GetColor(float minValue, float maxValue, float value)
        {
            if (maxValue < minValue) { throw new ArgumentException("fault value range"); }
            if (minValue == maxValue) { return this.colorList[0].Color; }

            if (value < minValue)
                value = minValue;
            if (value > maxValue)
                value = maxValue;

            float position = (value - minValue) / (maxValue - minValue);
            int leftIndex = 0;
            float totalLength = this.colorList.Last().Coord - this.colorList[0].Coord;
            for (int i = 1; i < this.colorList.Count; i++)
            {
                if (position <= (this.colorList[i].Coord - this.colorList[0].Coord) / totalLength)
                {
                    leftIndex = i - 1;
                    break;
                }
            }

            float relativePosition = position - (this.colorList[leftIndex].Coord / totalLength);
            vec3 result = this.colorList[leftIndex].Color * relativePosition
                + this.colorList[leftIndex + 1].Color * (1 - relativePosition);

            return result;
        }

    }

    class ColorCoordTuple
    {
        public vec3 Color { get; set; }
        public float Coord { get; set; }


        public override string ToString()
        {
            return string.Format("{0} -> {1}", Coord, Color);
        }
    }
}
