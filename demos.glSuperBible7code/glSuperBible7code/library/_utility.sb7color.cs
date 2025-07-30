
using CSharpGL;
using System.Diagnostics;
using System.Xml.Linq;
using static CSharpGL.GLProgram;

namespace demos.glSuperBible7code {
    public unsafe partial class Utility {

        public static vec4 colorfromhex(uint hex) {
            return new vec4(
                ((hex >> 16) & 0xFF) / 255.0f,
                ((hex >> 8) & 0xFF) / 255.0f,
                ((hex >> 0) & 0xFF) / 255.0f, 1.0f);
        }

        public static class color {

            public static readonly vec4 AliceBlue = colorfromhex(0xF0F8FF);
            public static readonly vec4 AntiqueWhite = colorfromhex(0xFAEBD7);
            public static readonly vec4 Aqua = colorfromhex(0x00FFFF);
            public static readonly vec4 Aquamarine = colorfromhex(0x7FFFD4);
            public static readonly vec4 Azure = colorfromhex(0xF0FFFF);
            public static readonly vec4 Beige = colorfromhex(0xF5F5DC);
            public static readonly vec4 Bisque = colorfromhex(0xFFE4C4);
            public static readonly vec4 Black = colorfromhex(0x000000);
            public static readonly vec4 BlanchedAlmond = colorfromhex(0xFFEBCD);
            public static readonly vec4 Blue = colorfromhex(0x0000FF);
            public static readonly vec4 BlueViolet = colorfromhex(0x8A2BE2);
            public static readonly vec4 Brown = colorfromhex(0xA52A2A);
            public static readonly vec4 BurlyWood = colorfromhex(0xDEB887);
            public static readonly vec4 CadetBlue = colorfromhex(0x5F9EA0);
            public static readonly vec4 Chartreuse = colorfromhex(0x7FFF00);
            public static readonly vec4 Chocolate = colorfromhex(0xD2691E);
            public static readonly vec4 Coral = colorfromhex(0xFF7F50);
            public static readonly vec4 CornflowerBlue = colorfromhex(0x6495ED);
            public static readonly vec4 Cornsilk = colorfromhex(0xFFF8DC);
            public static readonly vec4 Crimson = colorfromhex(0xDC143C);
            public static readonly vec4 Cyan = colorfromhex(0x00FFFF);
            public static readonly vec4 DarkBlue = colorfromhex(0x00008B);
            public static readonly vec4 DarkCyan = colorfromhex(0x008B8B);
            public static readonly vec4 DarkGoldenRod = colorfromhex(0xB8860B);
            public static readonly vec4 DarkGray = colorfromhex(0xA9A9A9);
            public static readonly vec4 DarkGreen = colorfromhex(0x006400);
            public static readonly vec4 DarkKhaki = colorfromhex(0xBDB76B);
            public static readonly vec4 DarkMagenta = colorfromhex(0x8B008B);
            public static readonly vec4 DarkOliveGreen = colorfromhex(0x556B2F);
            public static readonly vec4 DarkOrange = colorfromhex(0xFF8C00);
            public static readonly vec4 DarkOrchid = colorfromhex(0x9932CC);
            public static readonly vec4 DarkRed = colorfromhex(0x8B0000);
            public static readonly vec4 DarkSalmon = colorfromhex(0xE9967A);
            public static readonly vec4 DarkSeaGreen = colorfromhex(0x8FBC8F);
            public static readonly vec4 DarkSlateBlue = colorfromhex(0x483D8B);
            public static readonly vec4 DarkSlateGray = colorfromhex(0x2F4F4F);
            public static readonly vec4 DarkTurquoise = colorfromhex(0x00CED1);
            public static readonly vec4 DarkViolet = colorfromhex(0x9400D3);
            public static readonly vec4 DeepPink = colorfromhex(0xFF1493);
            public static readonly vec4 DeepSkyBlue = colorfromhex(0x00BFFF);
            public static readonly vec4 DimGray = colorfromhex(0x696969);
            public static readonly vec4 DodgerBlue = colorfromhex(0x1E90FF);
            public static readonly vec4 FireBrick = colorfromhex(0xB22222);
            public static readonly vec4 FloralWhite = colorfromhex(0xFFFAF0);
            public static readonly vec4 ForestGreen = colorfromhex(0x228B22);
            public static readonly vec4 Fuchsia = colorfromhex(0xFF00FF);
            public static readonly vec4 Gainsboro = colorfromhex(0xDCDCDC);
            public static readonly vec4 GhostWhite = colorfromhex(0xF8F8FF);
            public static readonly vec4 Gold = colorfromhex(0xFFD700);
            public static readonly vec4 GoldenRod = colorfromhex(0xDAA520);
            public static readonly vec4 Gray = colorfromhex(0x808080);
            public static readonly vec4 Green = colorfromhex(0x008000);
            public static readonly vec4 GreenYellow = colorfromhex(0xADFF2F);
            public static readonly vec4 HoneyDew = colorfromhex(0xF0FFF0);
            public static readonly vec4 HotPink = colorfromhex(0xFF69B4);
            public static readonly vec4 IndianRed = colorfromhex(0xCD5C5C);
            public static readonly vec4 Indigo = colorfromhex(0x4B0082);
            public static readonly vec4 Ivory = colorfromhex(0xFFFFF0);
            public static readonly vec4 Khaki = colorfromhex(0xF0E68C);
            public static readonly vec4 Lavender = colorfromhex(0xE6E6FA);
            public static readonly vec4 LavenderBlush = colorfromhex(0xFFF0F5);
            public static readonly vec4 LawnGreen = colorfromhex(0x7CFC00);
            public static readonly vec4 LemonChiffon = colorfromhex(0xFFFACD);
            public static readonly vec4 LightBlue = colorfromhex(0xADD8E6);
            public static readonly vec4 LightCoral = colorfromhex(0xF08080);
            public static readonly vec4 LightCyan = colorfromhex(0xE0FFFF);
            public static readonly vec4 LightGoldenRodYellow = colorfromhex(0xFAFAD2);
            public static readonly vec4 LightGray = colorfromhex(0xD3D3D3);
            public static readonly vec4 LightGreen = colorfromhex(0x90EE90);
            public static readonly vec4 LightPink = colorfromhex(0xFFB6C1);
            public static readonly vec4 LightSalmon = colorfromhex(0xFFA07A);
            public static readonly vec4 LightSeaGreen = colorfromhex(0x20B2AA);
            public static readonly vec4 LightSkyBlue = colorfromhex(0x87CEFA);
            public static readonly vec4 LightSlateGray = colorfromhex(0x778899);
            public static readonly vec4 LightSteelBlue = colorfromhex(0xB0C4DE);
            public static readonly vec4 LightYellow = colorfromhex(0xFFFFE0);
            public static readonly vec4 Lime = colorfromhex(0x00FF00);
            public static readonly vec4 LimeGreen = colorfromhex(0x32CD32);
            public static readonly vec4 Linen = colorfromhex(0xFAF0E6);
            public static readonly vec4 Magenta = colorfromhex(0xFF00FF);
            public static readonly vec4 Maroon = colorfromhex(0x800000);
            public static readonly vec4 MediumAquaMarine = colorfromhex(0x66CDAA);
            public static readonly vec4 MediumBlue = colorfromhex(0x0000CD);
            public static readonly vec4 MediumOrchid = colorfromhex(0xBA55D3);
            public static readonly vec4 MediumPurple = colorfromhex(0x9370DB);
            public static readonly vec4 MediumSeaGreen = colorfromhex(0x3CB371);
            public static readonly vec4 MediumSlateBlue = colorfromhex(0x7B68EE);
            public static readonly vec4 MediumSpringGreen = colorfromhex(0x00FA9A);
            public static readonly vec4 MediumTurquoise = colorfromhex(0x48D1CC);
            public static readonly vec4 MediumVioletRed = colorfromhex(0xC71585);
            public static readonly vec4 MidnightBlue = colorfromhex(0x191970);
            public static readonly vec4 MintCream = colorfromhex(0xF5FFFA);
            public static readonly vec4 MistyRose = colorfromhex(0xFFE4E1);
            public static readonly vec4 Moccasin = colorfromhex(0xFFE4B5);
            public static readonly vec4 NavajoWhite = colorfromhex(0xFFDEAD);
            public static readonly vec4 Navy = colorfromhex(0x000080);
            public static readonly vec4 OldLace = colorfromhex(0xFDF5E6);
            public static readonly vec4 Olive = colorfromhex(0x808000);
            public static readonly vec4 OliveDrab = colorfromhex(0x6B8E23);
            public static readonly vec4 Orange = colorfromhex(0xFFA500);
            public static readonly vec4 OrangeRed = colorfromhex(0xFF4500);
            public static readonly vec4 Orchid = colorfromhex(0xDA70D6);
            public static readonly vec4 PaleGoldenRod = colorfromhex(0xEEE8AA);
            public static readonly vec4 PaleGreen = colorfromhex(0x98FB98);
            public static readonly vec4 PaleTurquoise = colorfromhex(0xAFEEEE);
            public static readonly vec4 PaleVioletRed = colorfromhex(0xDB7093);
            public static readonly vec4 PapayaWhip = colorfromhex(0xFFEFD5);
            public static readonly vec4 PeachPuff = colorfromhex(0xFFDAB9);
            public static readonly vec4 Peru = colorfromhex(0xCD853F);
            public static readonly vec4 Pink = colorfromhex(0xFFC0CB);
            public static readonly vec4 Plum = colorfromhex(0xDDA0DD);
            public static readonly vec4 PowderBlue = colorfromhex(0xB0E0E6);
            public static readonly vec4 Purple = colorfromhex(0x800080);
            public static readonly vec4 RebeccaPurple = colorfromhex(0x663399);
            public static readonly vec4 Red = colorfromhex(0xFF0000);
            public static readonly vec4 RosyBrown = colorfromhex(0xBC8F8F);
            public static readonly vec4 RoyalBlue = colorfromhex(0x4169E1);
            public static readonly vec4 SaddleBrown = colorfromhex(0x8B4513);
            public static readonly vec4 Salmon = colorfromhex(0xFA8072);
            public static readonly vec4 SandyBrown = colorfromhex(0xF4A460);
            public static readonly vec4 SeaGreen = colorfromhex(0x2E8B57);
            public static readonly vec4 SeaShell = colorfromhex(0xFFF5EE);
            public static readonly vec4 Sienna = colorfromhex(0xA0522D);
            public static readonly vec4 Silver = colorfromhex(0xC0C0C0);
            public static readonly vec4 SkyBlue = colorfromhex(0x87CEEB);
            public static readonly vec4 SlateBlue = colorfromhex(0x6A5ACD);
            public static readonly vec4 SlateGray = colorfromhex(0x708090);
            public static readonly vec4 Snow = colorfromhex(0xFFFAFA);
            public static readonly vec4 SpringGreen = colorfromhex(0x00FF7F);
            public static readonly vec4 SteelBlue = colorfromhex(0x4682B4);
            public static readonly vec4 Tan = colorfromhex(0xD2B48C);
            public static readonly vec4 Teal = colorfromhex(0x008080);
            public static readonly vec4 Thistle = colorfromhex(0xD8BFD8);
            public static readonly vec4 Tomato = colorfromhex(0xFF6347);
            public static readonly vec4 Turquoise = colorfromhex(0x40E0D0);
            public static readonly vec4 Violet = colorfromhex(0xEE82EE);
            public static readonly vec4 Wheat = colorfromhex(0xF5DEB3);
            public static readonly vec4 White = colorfromhex(0xFFFFFF);
            public static readonly vec4 WhiteSmoke = colorfromhex(0xF5F5F5);
            public static readonly vec4 Yellow = colorfromhex(0xFFFF00);
            public static readonly vec4 YellowGreen = colorfromhex(0x9ACD32);
        }
    }
}
