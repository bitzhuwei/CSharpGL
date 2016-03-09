using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Winform
{
    class ColorBar
    {
        public static ColorBar GetDefault()
        {
            List<ColorCoordTuple> list = new List<ColorCoordTuple>();
            /*
                         coords[0] = 0.0f;
            colors[0] = System.Drawing.Color.FromArgb(255, 0, 22, 76);

            coords[1] = 0.25f;
            colors[1] = System.Drawing.Color.FromArgb(255, 0, 193, 136);

            coords[2] = 0.5f;
            colors[2] = System.Drawing.Color.FromArgb(255, 166, 255, 27);

            coords[3] = 0.75f;
            colors[3] = System.Drawing.Color.FromArgb(255, 255, 173, 0);

            coords[4] = 1.0f;
            colors[4] = System.Drawing.Color.FromArgb(255, 255, 8, 1);
             */
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

        /// <summary>
        /// 如果两点重合，则斜率为NAN.
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <returns></returns>
        private static vec3 LineSlope(vec3 y2, vec3 y1, float dx)
        {
            return (y2 - y1) / dx;
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
