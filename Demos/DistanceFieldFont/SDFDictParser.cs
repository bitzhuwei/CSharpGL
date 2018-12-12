using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceFieldFont
{
    public static class SDFDictParser
    {
        public static Dictionary<char, GlyphInfo> Parse(string filename)
        {
            var dict = new Dictionary<char, GlyphInfo>();
            int count = 0;
            using (var stream = new System.IO.StreamReader(filename))
            {
                while (!stream.EndOfStream)
                {
                    string line = stream.ReadLine().Trim();
                    if (line.StartsWith("chars"))
                    {
                        count = ParseCount(line);
                    }
                    else if (line.StartsWith("char"))
                    {
                        GlyphInfo glyph = ParseGlyph(line);
                        dict.Add(glyph.name, glyph);
                    }
                }
            }

            return dict;
        }

        private static char[] separators = new char[] { ' ', '=', '\t', '\n' };

        private static GlyphInfo ParseGlyph(string line)
        {
            string[] parts = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            char name;
            {
                string item = parts[2];
                int value = int.Parse(item);
                name = (char)value;
            }
            int x, y, width, height;
            float xOffset, yOffset, xAdvance;
            int page, channel;
            {
                string item = parts[4];
                x = int.Parse(item);
            }
            {
                string item = parts[6];
                y = int.Parse(item);
            }
            {
                string item = parts[8];
                width = int.Parse(item);
            }
            {
                string item = parts[10];
                height = int.Parse(item);
            }
            {
                string item = parts[12];
                xOffset = float.Parse(item);
            }
            {
                string item = parts[14];
                yOffset = float.Parse(item);
            }
            {
                string item = parts[16];
                xAdvance = float.Parse(item);
            }
            {
                string item = parts[18];
                page = int.Parse(item);
            }
            {
                string item = parts[20];
                channel = int.Parse(item);
            }

            var result = new GlyphInfo(name);
            result.x = x; result.y = y; result.width = width; result.height = height;
            result.xOffset = xOffset; result.yOffset = yOffset;
            result.xAdvance = xAdvance;
            result.page = page;
            result.channel = channel;

            return result;
        }

        private static int ParseCount(string line)
        {
            string[] parts = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string item = parts[2];
            return int.Parse(item);
        }
    }
}
