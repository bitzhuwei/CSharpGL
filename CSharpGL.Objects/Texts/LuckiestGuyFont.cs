using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Texts
{

    public struct kerning_t
    {
        public char charcode;
        public float kerning;

        public kerning_t(char charcode, float kerning)
        {
            this.charcode = charcode;
            this.kerning = kerning;
        }
    }

    public struct texture_glyph_t
    {
        public char charcode;
        public int width, height;
        public int offset_x, offset_y;
        public float advance_x, advance_y;
        public float s0, t0, s1, t1;
        public int kerning_count;
        public kerning_t[] kerning;//[17]

        public texture_glyph_t(char charcode, int width, int height, int offset_x, int offset_y, float advance_x, float advance_y, float s0, float t0, float s1, float t1, int kerning_count, kerning_t[] kerning)
        {
            this.charcode = charcode; this.width = width; this.height = height;
            this.offset_x = offset_x; this.offset_y = offset_y;
            this.advance_x = advance_x; this.advance_y = advance_y;
            this.s0 = s0; this.t0 = t0; this.s1 = s1; this.t1 = t1;
            this.kerning_count = kerning_count;
            this.kerning = kerning;
        }
    }

    public struct texture_font_t
    {
        internal const int tex_data_count = 65536;
        public int tex_width;
        public int tex_height;
        public int tex_depth;
        public char[] tex_data;//[65536];
        public float size;
        public float height;
        public float linegap;
        public float ascender;
        public float descender;
        public int glyphs_count;
        public texture_glyph_t[] glyphs;//[96];
    }

    public static class LuckiestGuyFont
    {

        public static readonly texture_font_t qqFont;

        static LuckiestGuyFont()
        {
            qqFont = new texture_font_t() { tex_width = 256, tex_height = 256, tex_depth = 1, size = 10.000000f, height = 10.000000f, linegap = -0.000000f, ascender = 7.030000f, descender = -2.970000f, glyphs_count = 96, };

            qqFont.tex_data = new char[texture_font_t.tex_data_count];
            InitTex_data();

            qqFont.glyphs = new texture_glyph_t[96]//[qqFont.glyphs_count] 
            {
               new texture_glyph_t('\0', 0, 0, 0, 0, 0.000000f, 0.000000f, 0.011719f, 0.011719f, 0.015625f, 0.015625f, 0, new kerning_t[0] ),
new texture_glyph_t(' ', 0, 0, 0, 0, 1.953125f, 0.000000f, 0.023438f, 0.003906f, 0.023438f, 0.003906f, 0, new kerning_t[0] ),
new texture_glyph_t('!', 3, 8, 0, 7, 2.796875f, 0.000000f, 0.027344f, 0.003906f, 0.039063f, 0.035156f, 0, new kerning_t[0] ),
new texture_glyph_t('"', 5, 3, 0, 8, 4.796875f, 0.000000f, 0.042969f, 0.003906f, 0.062500f, 0.015625f, 3, new kerning_t[]{ new kerning_t(',', -1.420898f), new kerning_t('.', -1.455078f), new kerning_t('\\', -0.625000f)} ),
new texture_glyph_t('#', 6, 7, 0, 7, 6.062500f, 0.000000f, 0.066406f, 0.003906f, 0.089844f, 0.031250f, 0, new kerning_t[0] ),
new texture_glyph_t('$', 5, 10, 0, 8, 4.359375f, 0.000000f, 0.093750f, 0.003906f, 0.113281f, 0.042969f, 0, new kerning_t[0] ),
new texture_glyph_t('%', 8, 7, 0, 7, 7.250000f, 0.000000f, 0.117188f, 0.003906f, 0.148438f, 0.031250f, 0, new kerning_t[0] ),
new texture_glyph_t('&', 7, 8, 0, 7, 6.296875f, 0.000000f, 0.152344f, 0.003906f, 0.179688f, 0.035156f, 0, new kerning_t[0] ),
new texture_glyph_t('\'', 3, 3, 0, 8, 2.328125f, 0.000000f, 0.183594f, 0.003906f, 0.195313f, 0.015625f, 3, new kerning_t[]{ new kerning_t(',', -1.420898f), new kerning_t('.', -1.455078f), new kerning_t('\\', -0.625000f)} ),
new texture_glyph_t('(', 5, 9, 0, 8, 3.890625f, 0.000000f, 0.199219f, 0.003906f, 0.218750f, 0.039063f, 0, new kerning_t[0] ),
new texture_glyph_t(')', 5, 9, -1, 8, 3.812500f, 0.000000f, 0.222656f, 0.003906f, 0.242188f, 0.039063f, 2, new kerning_t[]{ new kerning_t('O', -0.532227f), new kerning_t('o', -0.522461f)} ),
new texture_glyph_t('*', 6, 5, 0, 7, 5.421875f, 0.000000f, 0.246094f, 0.003906f, 0.269531f, 0.023438f, 0, new kerning_t[0] ),
new texture_glyph_t('+', 5, 6, 0, 6, 4.562500f, 0.000000f, 0.273438f, 0.003906f, 0.292969f, 0.027344f, 0, new kerning_t[0] ),
new texture_glyph_t(',', 3, 3, 0, 2, 2.234375f, 0.000000f, 0.296875f, 0.003906f, 0.308594f, 0.015625f, 9, new kerning_t[]{ new kerning_t('"', -1.479492f), new kerning_t('\'', -1.479492f), new kerning_t('F', -0.712891f), new kerning_t('P', -0.957031f), new kerning_t('T', -0.571289f), new kerning_t('Y', -0.747070f), new kerning_t('f', -0.708008f), new kerning_t('p', -0.732422f), new kerning_t('y', -0.644531f)} ),
new texture_glyph_t('-', 4, 3, 0, 6, 3.828125f, 0.000000f, 0.312500f, 0.003906f, 0.328125f, 0.015625f, 0, new kerning_t[0] ),
new texture_glyph_t('.', 3, 3, 0, 3, 2.218750f, 0.000000f, 0.332031f, 0.003906f, 0.343750f, 0.015625f, 9, new kerning_t[]{ new kerning_t('"', -1.523438f), new kerning_t('\'', -1.523438f), new kerning_t('F', -0.717773f), new kerning_t('P', -1.059570f), new kerning_t('T', -0.576172f), new kerning_t('Y', -0.751953f), new kerning_t('f', -0.712891f), new kerning_t('p', -0.825195f), new kerning_t('y', -0.644531f)} ),
new texture_glyph_t('/', 5, 9, 0, 8, 5.046875f, 0.000000f, 0.347656f, 0.003906f, 0.367188f, 0.039063f, 17, new kerning_t[]{ new kerning_t('"', -0.693359f), new kerning_t('\'', -0.693359f), new kerning_t('/', -1.123047f), new kerning_t('7', -0.781250f), new kerning_t('F', -0.761719f), new kerning_t('P', -0.717773f), new kerning_t('T', -0.878906f), new kerning_t('U', -0.595703f), new kerning_t('V', -0.742188f), new kerning_t('W', -0.541992f), new kerning_t('Y', -1.010742f), new kerning_t('f', -0.747070f), new kerning_t('p', -0.683594f), new kerning_t('t', -0.830078f), new kerning_t('v', -0.761719f), new kerning_t('w', -0.566406f), new kerning_t('y', -0.986328f)} ),
new texture_glyph_t('0', 7, 7, 0, 7, 6.328125f, 0.000000f, 0.371094f, 0.003906f, 0.398438f, 0.031250f, 0, new kerning_t[0] ),
new texture_glyph_t('1', 5, 7, -1, 7, 3.875000f, 0.000000f, 0.402344f, 0.003906f, 0.421875f, 0.031250f, 1, new kerning_t[]{ new kerning_t('\\', -0.634766f)} ),
new texture_glyph_t('2', 5, 7, 0, 7, 5.093750f, 0.000000f, 0.425781f, 0.003906f, 0.445313f, 0.031250f, 0, new kerning_t[0] ),
new texture_glyph_t('3', 6, 7, 0, 7, 5.281250f, 0.000000f, 0.449219f, 0.003906f, 0.472656f, 0.031250f, 0, new kerning_t[0] ),
new texture_glyph_t('4', 6, 8, 0, 7, 5.390625f, 0.000000f, 0.476563f, 0.003906f, 0.500000f, 0.035156f, 0, new kerning_t[0] ),
new texture_glyph_t('5', 6, 7, 0, 7, 5.312500f, 0.000000f, 0.503906f, 0.003906f, 0.527344f, 0.031250f, 0, new kerning_t[0] ),
new texture_glyph_t('6', 6, 7, 0, 7, 5.734375f, 0.000000f, 0.531250f, 0.003906f, 0.554688f, 0.031250f, 0, new kerning_t[0] ),
new texture_glyph_t('7', 5, 7, 0, 7, 5.062500f, 0.000000f, 0.558594f, 0.003906f, 0.578125f, 0.031250f, 1, new kerning_t[]{ new kerning_t('Y', 0.566406f)} ),
new texture_glyph_t('8', 6, 7, 0, 7, 5.718750f, 0.000000f, 0.582031f, 0.003906f, 0.605469f, 0.031250f, 0, new kerning_t[0] ),
new texture_glyph_t('9', 6, 7, 0, 7, 5.546875f, 0.000000f, 0.609375f, 0.003906f, 0.632813f, 0.031250f, 0, new kerning_t[0] ),
new texture_glyph_t(':', 3, 6, 0, 6, 2.484375f, 0.000000f, 0.636719f, 0.003906f, 0.648438f, 0.027344f, 0, new kerning_t[0] ),
new texture_glyph_t(';', 3, 7, 0, 6, 2.468750f, 0.000000f, 0.652344f, 0.003906f, 0.664063f, 0.031250f, 0, new kerning_t[0] ),
new texture_glyph_t('<', 5, 7, 0, 7, 4.546875f, 0.000000f, 0.667969f, 0.003906f, 0.687500f, 0.031250f, 0, new kerning_t[0] ),
new texture_glyph_t('=', 4, 4, 0, 5, 3.906250f, 0.000000f, 0.691406f, 0.003906f, 0.707031f, 0.019531f, 0, new kerning_t[0] ),
new texture_glyph_t('>', 5, 7, 0, 7, 4.546875f, 0.000000f, 0.710938f, 0.003906f, 0.730469f, 0.031250f, 0, new kerning_t[0] ),
new texture_glyph_t('?', 6, 8, 0, 7, 5.546875f, 0.000000f, 0.734375f, 0.003906f, 0.757813f, 0.035156f, 2, new kerning_t[]{ new kerning_t('L', -0.556641f), new kerning_t('l', -0.551758f)} ),
new texture_glyph_t('@', 7, 6, 0, 6, 6.640625f, 0.000000f, 0.761719f, 0.003906f, 0.789063f, 0.027344f, 3, new kerning_t[]{ new kerning_t('K', -0.527344f), new kerning_t('Y', -0.527344f), new kerning_t('y', -0.576172f)} ),
new texture_glyph_t('A', 8, 7, -1, 7, 6.265625f, 0.000000f, 0.792969f, 0.003906f, 0.824219f, 0.031250f, 9, new kerning_t[]{ new kerning_t('*', -0.546875f), new kerning_t('/', -0.776367f), new kerning_t('F', -0.639648f), new kerning_t('T', -0.673828f), new kerning_t('Y', -0.703125f), new kerning_t('f', -0.610352f), new kerning_t('t', -0.634766f), new kerning_t('v', -0.537109f), new kerning_t('y', -0.815430f)} ),
new texture_glyph_t('B', 6, 7, 0, 7, 5.937500f, 0.000000f, 0.828125f, 0.003906f, 0.851563f, 0.031250f, 0, new kerning_t[0] ),
new texture_glyph_t('C', 6, 7, 0, 7, 5.140625f, 0.000000f, 0.855469f, 0.003906f, 0.878906f, 0.031250f, 1, new kerning_t[]{ new kerning_t('y', -0.585938f)} ),
new texture_glyph_t('D', 6, 7, 0, 7, 5.828125f, 0.000000f, 0.882813f, 0.003906f, 0.906250f, 0.031250f, 0, new kerning_t[0] ),
new texture_glyph_t('E', 5, 7, 0, 7, 4.796875f, 0.000000f, 0.910156f, 0.003906f, 0.929688f, 0.031250f, 0, new kerning_t[0] ),
new texture_glyph_t('F', 5, 7, 0, 7, 4.875000f, 0.000000f, 0.933594f, 0.003906f, 0.953125f, 0.031250f, 0, new kerning_t[0] ),
new texture_glyph_t('G', 7, 7, 0, 7, 6.265625f, 0.000000f, 0.957031f, 0.003906f, 0.984375f, 0.031250f, 1, new kerning_t[]{ new kerning_t('y', -0.566406f)} ),
new texture_glyph_t('H', 6, 7, 0, 7, 6.265625f, 0.000000f, 0.296875f, 0.019531f, 0.320313f, 0.046875f, 0, new kerning_t[0] ),
new texture_glyph_t('I', 3, 7, 0, 7, 2.968750f, 0.000000f, 0.183594f, 0.019531f, 0.195313f, 0.046875f, 0, new kerning_t[0] ),
new texture_glyph_t('J', 6, 7, -1, 7, 5.093750f, 0.000000f, 0.246094f, 0.027344f, 0.269531f, 0.054688f, 15, new kerning_t[]{ new kerning_t('"', -0.859375f), new kerning_t('\'', -0.859375f), new kerning_t('*', -0.698242f), new kerning_t('/', -0.913086f), new kerning_t('7', -0.541992f), new kerning_t('F', -1.088867f), new kerning_t('P', -0.922852f), new kerning_t('T', -1.030273f), new kerning_t('V', -0.742188f), new kerning_t('Y', -1.357422f), new kerning_t('f', -0.957031f), new kerning_t('p', -0.649414f), new kerning_t('t', -0.937500f), new kerning_t('v', -0.781250f), new kerning_t('y', -1.225586f)} ),
new texture_glyph_t('K', 7, 8, 0, 8, 6.140625f, 0.000000f, 0.761719f, 0.031250f, 0.789063f, 0.062500f, 0, new kerning_t[0] ),
new texture_glyph_t('L', 5, 7, 0, 7, 4.515625f, 0.000000f, 0.042969f, 0.019531f, 0.062500f, 0.046875f, 0, new kerning_t[0] ),
new texture_glyph_t('M', 8, 7, 0, 7, 7.906250f, 0.000000f, 0.636719f, 0.035156f, 0.667969f, 0.062500f, 0, new kerning_t[0] ),
new texture_glyph_t('N', 7, 7, 0, 7, 7.031250f, 0.000000f, 0.671875f, 0.035156f, 0.699219f, 0.062500f, 0, new kerning_t[0] ),
new texture_glyph_t('O', 7, 7, 0, 7, 6.375000f, 0.000000f, 0.703125f, 0.035156f, 0.730469f, 0.062500f, 4, new kerning_t[]{ new kerning_t('(', -0.585938f), new kerning_t('/', -0.537109f), new kerning_t('Y', -0.644531f), new kerning_t('y', -0.703125f)} ),
new texture_glyph_t('P', 6, 7, 0, 7, 5.953125f, 0.000000f, 0.066406f, 0.035156f, 0.089844f, 0.062500f, 0, new kerning_t[0] ),
new texture_glyph_t('Q', 7, 9, 0, 7, 6.906250f, 0.000000f, 0.117188f, 0.035156f, 0.144531f, 0.070313f, 2, new kerning_t[]{ new kerning_t('(', -0.541992f), new kerning_t('y', -0.537109f)} ),
new texture_glyph_t('R', 6, 8, 0, 7, 6.062500f, 0.000000f, 0.371094f, 0.035156f, 0.394531f, 0.066406f, 0, new kerning_t[0] ),
new texture_glyph_t('S', 6, 7, 0, 7, 5.312500f, 0.000000f, 0.398438f, 0.035156f, 0.421875f, 0.062500f, 0, new kerning_t[0] ),
new texture_glyph_t('T', 6, 7, 0, 7, 5.437500f, 0.000000f, 0.425781f, 0.035156f, 0.449219f, 0.062500f, 5, new kerning_t[]{ new kerning_t('A', -0.576172f), new kerning_t('L', -0.756836f), new kerning_t('\\', -0.742188f), new kerning_t('a', -0.576172f), new kerning_t('l', -0.761719f)} ),
new texture_glyph_t('U', 7, 7, 0, 7, 6.234375f, 0.000000f, 0.503906f, 0.035156f, 0.531250f, 0.062500f, 0, new kerning_t[0] ),
new texture_glyph_t('V', 8, 8, -1, 8, 6.125000f, 0.000000f, 0.535156f, 0.035156f, 0.566406f, 0.066406f, 6, new kerning_t[]{ new kerning_t('(', 0.590820f), new kerning_t('A', -0.537109f), new kerning_t('L', -0.600586f), new kerning_t('\\', -0.825195f), new kerning_t('a', -0.537109f), new kerning_t('l', -0.649414f)} ),
new texture_glyph_t('W', 10, 7, 0, 7, 9.078125f, 0.000000f, 0.570313f, 0.035156f, 0.609375f, 0.062500f, 1, new kerning_t[]{ new kerning_t('\\', -0.571289f)} ),
new texture_glyph_t('X', 8, 8, -1, 8, 5.890625f, 0.000000f, 0.792969f, 0.035156f, 0.824219f, 0.066406f, 0, new kerning_t[0] ),
new texture_glyph_t('Y', 7, 8, 0, 8, 6.062500f, 0.000000f, 0.828125f, 0.035156f, 0.855469f, 0.066406f, 6, new kerning_t[]{ new kerning_t('&', -0.532227f), new kerning_t('A', -0.605469f), new kerning_t('L', -0.800781f), new kerning_t('\\', -0.727539f), new kerning_t('a', -0.605469f), new kerning_t('l', -0.800781f)} ),
new texture_glyph_t('Z', 5, 7, 0, 7, 4.875000f, 0.000000f, 0.324219f, 0.019531f, 0.343750f, 0.046875f, 0, new kerning_t[0] ),
new texture_glyph_t('[', 4, 9, 0, 8, 3.656250f, 0.000000f, 0.003906f, 0.023438f, 0.019531f, 0.058594f, 0, new kerning_t[0] ),
new texture_glyph_t('\\', 5, 9, 0, 8, 5.046875f, 0.000000f, 0.273438f, 0.031250f, 0.292969f, 0.066406f, 4, new kerning_t[]{ new kerning_t('A', -0.737305f), new kerning_t('L', -0.722656f), new kerning_t('a', -0.737305f), new kerning_t('l', -0.747070f)} ),
new texture_glyph_t(']', 5, 9, -1, 8, 3.656250f, 0.000000f, 0.453125f, 0.035156f, 0.472656f, 0.070313f, 1, new kerning_t[]{ new kerning_t('Y', 0.532227f)} ),
new texture_glyph_t('^', 5, 4, 0, 7, 4.859375f, 0.000000f, 0.613281f, 0.035156f, 0.632813f, 0.050781f, 0, new kerning_t[0] ),
new texture_glyph_t('_', 5, 3, -1, 1, 3.015625f, 0.000000f, 0.859375f, 0.035156f, 0.878906f, 0.046875f, 0, new kerning_t[0] ),
new texture_glyph_t('`', 3, 4, 0, 10, 2.828125f, 0.000000f, 0.882813f, 0.035156f, 0.894531f, 0.050781f, 0, new kerning_t[0] ),
new texture_glyph_t('a', 8, 7, -1, 7, 6.265625f, 0.000000f, 0.898438f, 0.035156f, 0.929688f, 0.062500f, 9, new kerning_t[]{ new kerning_t('*', -0.546875f), new kerning_t('/', -0.776367f), new kerning_t('F', -0.639648f), new kerning_t('T', -0.673828f), new kerning_t('Y', -0.703125f), new kerning_t('f', -0.610352f), new kerning_t('t', -0.634766f), new kerning_t('v', -0.537109f), new kerning_t('y', -0.815430f)} ),
new texture_glyph_t('b', 6, 7, 0, 7, 5.937500f, 0.000000f, 0.933594f, 0.035156f, 0.957031f, 0.062500f, 0, new kerning_t[0] ),
new texture_glyph_t('c', 5, 7, 0, 7, 5.125000f, 0.000000f, 0.960938f, 0.035156f, 0.980469f, 0.062500f, 1, new kerning_t[]{ new kerning_t('y', -0.600586f)} ),
new texture_glyph_t('d', 6, 7, 0, 7, 5.828125f, 0.000000f, 0.148438f, 0.039063f, 0.171875f, 0.066406f, 0, new kerning_t[0] ),
new texture_glyph_t('e', 6, 7, 0, 7, 5.765625f, 0.000000f, 0.476563f, 0.039063f, 0.500000f, 0.066406f, 0, new kerning_t[0] ),
new texture_glyph_t('f', 5, 7, 0, 7, 4.875000f, 0.000000f, 0.734375f, 0.039063f, 0.753906f, 0.066406f, 0, new kerning_t[0] ),
new texture_glyph_t('g', 7, 7, 0, 7, 6.281250f, 0.000000f, 0.199219f, 0.042969f, 0.226563f, 0.070313f, 1, new kerning_t[]{ new kerning_t('y', -0.590820f)} ),
new texture_glyph_t('h', 6, 7, 0, 7, 6.265625f, 0.000000f, 0.023438f, 0.050781f, 0.046875f, 0.078125f, 0, new kerning_t[0] ),
new texture_glyph_t('i', 3, 7, 0, 7, 2.937500f, 0.000000f, 0.230469f, 0.042969f, 0.242188f, 0.070313f, 0, new kerning_t[0] ),
new texture_glyph_t('j', 6, 7, -1, 7, 5.093750f, 0.000000f, 0.296875f, 0.050781f, 0.320313f, 0.078125f, 15, new kerning_t[]{ new kerning_t('"', -0.859375f), new kerning_t('\'', -0.859375f), new kerning_t('*', -0.698242f), new kerning_t('/', -0.913086f), new kerning_t('7', -0.541992f), new kerning_t('F', -1.088867f), new kerning_t('P', -0.922852f), new kerning_t('T', -1.030273f), new kerning_t('V', -0.742188f), new kerning_t('Y', -1.357422f), new kerning_t('f', -0.957031f), new kerning_t('p', -0.649414f), new kerning_t('t', -0.937500f), new kerning_t('v', -0.781250f), new kerning_t('y', -1.225586f)} ),
new texture_glyph_t('k', 7, 8, 0, 7, 6.031250f, 0.000000f, 0.324219f, 0.050781f, 0.351563f, 0.082031f, 0, new kerning_t[0] ),
new texture_glyph_t('l', 5, 7, 0, 7, 4.515625f, 0.000000f, 0.093750f, 0.046875f, 0.113281f, 0.074219f, 0, new kerning_t[0] ),
new texture_glyph_t('m', 9, 7, 0, 7, 8.984375f, 0.000000f, 0.859375f, 0.054688f, 0.894531f, 0.082031f, 0, new kerning_t[0] ),
new texture_glyph_t('n', 7, 7, 0, 7, 6.515625f, 0.000000f, 0.757813f, 0.066406f, 0.785156f, 0.093750f, 0, new kerning_t[0] ),
new texture_glyph_t('o', 7, 7, 0, 7, 6.375000f, 0.000000f, 0.050781f, 0.066406f, 0.078125f, 0.093750f, 3, new kerning_t[]{ new kerning_t('(', -0.556641f), new kerning_t('\\', -0.546875f), new kerning_t('y', -0.532227f)} ),
new texture_glyph_t('p', 6, 7, 0, 7, 5.968750f, 0.000000f, 0.246094f, 0.058594f, 0.269531f, 0.085938f, 0, new kerning_t[0] ),
new texture_glyph_t('q', 7, 9, 0, 7, 6.906250f, 0.000000f, 0.613281f, 0.066406f, 0.640625f, 0.101563f, 2, new kerning_t[]{ new kerning_t('(', -0.541992f), new kerning_t('y', -0.537109f)} ),
new texture_glyph_t('r', 6, 8, 0, 7, 6.062500f, 0.000000f, 0.503906f, 0.066406f, 0.527344f, 0.097656f, 0, new kerning_t[0] ),
new texture_glyph_t('s', 6, 7, 0, 7, 5.312500f, 0.000000f, 0.570313f, 0.066406f, 0.593750f, 0.093750f, 0, new kerning_t[0] ),
new texture_glyph_t('t', 6, 7, 0, 7, 5.453125f, 0.000000f, 0.398438f, 0.066406f, 0.421875f, 0.093750f, 6, new kerning_t[]{ new kerning_t('&', -0.537109f), new kerning_t('A', -0.600586f), new kerning_t('L', -0.776367f), new kerning_t('\\', -0.791016f), new kerning_t('a', -0.600586f), new kerning_t('l', -0.776367f)} ),
new texture_glyph_t('u', 7, 7, 0, 6, 6.109375f, 0.000000f, 0.898438f, 0.066406f, 0.925781f, 0.093750f, 0, new kerning_t[0] ),
new texture_glyph_t('v', 8, 7, -1, 7, 6.140625f, 0.000000f, 0.929688f, 0.066406f, 0.960938f, 0.093750f, 5, new kerning_t[]{ new kerning_t('A', -0.537109f), new kerning_t('L', -0.610352f), new kerning_t('\\', -0.839844f), new kerning_t('a', -0.537109f), new kerning_t('l', -0.668945f)} ),
new texture_glyph_t('w', 10, 7, 0, 7, 9.093750f, 0.000000f, 0.644531f, 0.066406f, 0.683594f, 0.093750f, 1, new kerning_t[]{ new kerning_t('\\', -0.595703f)} ),
new texture_glyph_t('x', 8, 7, -1, 7, 5.953125f, 0.000000f, 0.687500f, 0.066406f, 0.718750f, 0.093750f, 0, new kerning_t[0] ),
new texture_glyph_t('y', 8, 8, -1, 8, 6.062500f, 0.000000f, 0.531250f, 0.070313f, 0.562500f, 0.101563f, 6, new kerning_t[]{ new kerning_t('&', -0.561523f), new kerning_t('A', -0.595703f), new kerning_t('L', -0.776367f), new kerning_t('\\', -0.786133f), new kerning_t('a', -0.595703f), new kerning_t('l', -0.776367f)} ),
new texture_glyph_t('z', 5, 7, 0, 7, 4.953125f, 0.000000f, 0.175781f, 0.050781f, 0.195313f, 0.078125f, 0, new kerning_t[0] ),
new texture_glyph_t('{', 5, 10, 0, 9, 4.109375f, 0.000000f, 0.964844f, 0.066406f, 0.984375f, 0.105469f, 0, new kerning_t[0] ),
new texture_glyph_t('|', 3, 8, 0, 7, 2.875000f, 0.000000f, 0.355469f, 0.042969f, 0.367188f, 0.074219f, 0, new kerning_t[0] ),
new texture_glyph_t('}', 6, 9, -1, 8, 4.031250f, 0.000000f, 0.425781f, 0.066406f, 0.449219f, 0.101563f, 0, new kerning_t[0] ),
new texture_glyph_t('~', 6, 4, 0, 6, 5.765625f, 0.000000f, 0.789063f, 0.070313f, 0.812500f, 0.085938f, 0, new kerning_t[0] ), 
            };
        }

        private static void InitTex_data()
        {
            int count = 0;
            foreach (var line in ManifestResourceLoader.GetLines("LuckiestGuy.tex_data"))
            {
                string[] parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                foreach (var part in parts)
                {
                    char c = char.Parse(part);
                    qqFont.tex_data[count++] = c;
                }
            }
            if (count != texture_font_t.tex_data_count)
            { throw new Exception(); }
        }

        static readonly char[] separator = new char[] { ',', ' ' };
    }
}
