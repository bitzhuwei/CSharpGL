using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GridViewer
{
    public class CodedColor
    {

        public static CodedColor[] GetDefault()
        {
            var result = new CodedColor[5];
            result[0] = new CodedColor(
                Color.FromArgb(255, 0, 22, 76).ToVec3(), 0.0f, 100.0f);
            result[1] = new CodedColor(
                Color.FromArgb(255, 0, 193, 136).ToVec3(), 0.25f, 200.0f);
            result[2] = new CodedColor(
                Color.FromArgb(255, 166, 255, 27).ToVec3(), 0.5f, 300.0f);
            result[3] = new CodedColor(
                Color.FromArgb(255, 255, 173, 0).ToVec3(), 0.75f, 400.0f);
            result[4] = new CodedColor(
                Color.FromArgb(255, 255, 8, 1).ToVec3(), 1.0f, 500.0f);

            return result;
        }

        public CodedColor(vec3 color, float coord, float value)
        {
            this.DisplayColor = color; this.Coord = coord; this.Value = value;
        }

        /// <summary>
        /// Display color.
        /// (x, y, z) equals Color.FromArgb(255, x * 255, y * 255, z * 255);
        /// </summary>
        public vec3 DisplayColor { get; set; }

        private float coord;
        /// <summary>
        /// position in coded color bar. Ranges from 0.0f to 1.0f.
        /// </summary>
        public float Coord
        {
            get { return coord; }
            set
            {
                if (value < 0) { coord = 0; }
                else if (value > 1.0f) { coord = 1.0f; }
                else { coord = value; }
            }
        }

        /// <summary>
        /// Display value.
        /// </summary>
        public float Value { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}: {2}", DisplayColor, Coord, Value);
        }
    }
}
