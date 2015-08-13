using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Objects.UI.SimpleUI
{

    public class ColorPalette
    {

        public ColorPalette(String paletteName, GLColor[] colors, float[] coords)
        {
            if (colors == null || colors == null || colors.Length < 2 || colors.Length < 2 || colors.Length != coords.Length)
            {
                throw new ArgumentNullException("ColorPalette", "ColorPalette define error");
            }

            this.Colors = colors;
            this.Coords = coords;
            this.Name = paletteName;
        }

        /// <summary>
        /// meaningful name for the Palette, eg.rainbow,blackwhite, and so on.
        /// </summary>
        public String Name { get; protected set; }

        public float[] Coords { get; protected set; }

        public GLColor[] Colors { get; protected set; }

        public GLColor MapToColor(float x, float minValue, float maxValue)
        {
            return ColorMapHelper.MapToColor(this.Colors, this.Coords, x, minValue, maxValue);
        }
    }

    public class ColorPaletteFactory
    {

        public static ColorPalette CreateRainbow()
        {
            GLColor[] colors = new GLColor[5];
            float[] coords = new float[5];
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
            return new ColorPalette("Rainbow", colors, coords);
        }

        public static IList<ColorPalette> LoadColorPalettes(String filePath)
        {
            throw new NotImplementedException("Not Implementation");
        }
    }

    public class ColorMapHelper
    {

        /// <summary>
        /// 如果两点重合，则斜率为NAN.
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <returns></returns>
        private static float LineSlope(float y2, float y1, float dx)
        {
            return (y2 - y1) / dx;
        }

        public static GLColor MapToColor(GLColor[] colors, float[] coords, float value, float minValue, float maxValue)
        {
            if (colors.Length < 2)
                throw new ArgumentException("template colors size error");

            float d = maxValue - minValue;
            if (d < 0.0f)
                throw new ArgumentException("fault value range");

            if (value < minValue)
                value = minValue;
            if (value > maxValue)
                value = maxValue;

            if (d == 0.0d)
                return colors[0];

            float dx = value - minValue;

            float x = dx / d;
            if (x <= 0.000000001d)
                return colors[0];

            bool find = false;
            float x1 = 0.0f, x2 = 0.0f;
            GLColor y1 = colors[0], y2 = colors[1];

            for (int i = 0; i < coords.Length - 1; i++)
            {
                x1 = coords[i];
                x2 = coords[i + 1];
                y1 = colors[i];
                y2 = colors[i + 1];
                if (x >= x1 && x <= x2)
                {
                    find = true;
                    break;
                }
            }
            if (!find)
                throw new ArgumentException("not found colors,template fault default not in[0,1] ?");



            dx = x2 - x1;
            float kr = LineSlope(y2.R, y1.R, dx);
            float kg = LineSlope(y2.G, y1.G, dx);
            float kb = LineSlope(y2.B, y1.B, dx);
            float ka = LineSlope(y2.A, y1.A, dx);
            float r = y1.R + kr * (x - x1);
            float g = y1.G + kg * (x - x1);
            float b = y1.B + kb * (x - x1);
            float a = y1.A + ka * (x - x1);

            return new GLColor(r, g, b, a);


        }
    }
}
