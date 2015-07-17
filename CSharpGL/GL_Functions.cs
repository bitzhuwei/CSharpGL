using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public static partial class GL
    {

        #region The OpenGL DLL Functions (Exactly the same naming).

        /// <summary>
        /// Set the Accumulation Buffer operation.
        /// </summary>
        /// <param name="op">Operation of the buffer.</param>
        /// <param name="value">Reference value.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glAccum(uint op, float value);

        /// <summary>
        /// Specify the Alpha Test function.
        /// </summary>
        /// <param name="func">Specifies the alpha comparison function. Symbolic constants OpenGL.NEVER, OpenGL.LESS, OpenGL.EQUAL, OpenGL.LEQUAL, OpenGL.GREATER, OpenGL.NOTEQUAL, OpenGL.GEQUAL and OpenGL.ALWAYS are accepted. The initial value is OpenGL.ALWAYS.</param>
        /// <param name="ref_notkeword">Specifies the reference	value that incoming alpha values are compared to. This value is clamped to the range 0	through	1, where 0 represents the lowest possible alpha value and 1 the highest possible value. The initial reference value is 0.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glAlphaFunc(uint func, float ref_notkeword);

        /// <summary>
        /// Determine if textures are loaded in texture memory.
        /// </summary>
        /// <param name="n">Specifies the number of textures to be queried.</param>
        /// <param name="textures">Specifies an array containing the names of the textures to be queried.</param>
        /// <param name="residences">Specifies an array in which the texture residence status is returned. The residence status of a texture named by an element of textures is returned in the corresponding element of residences.</param>
        /// <returns></returns>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern byte glAreTexturesResident(int n, uint[] textures, byte[] residences);

        /// <summary>
        /// Render a vertex using the specified vertex array element.
        /// </summary>
        /// <param name="i">Specifies an index	into the enabled vertex	data arrays.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glArrayElement(int i);
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glBegin(uint mode);

        /// <summary>
        /// Call this function after creating a texture to finalise creation of it, 
        /// or to make an existing texture current.
        /// </summary>
        /// <param name="target">The target type, e.g TEXTURE_2D.</param>
        /// <param name="texture">The OpenGL texture object.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glBindTexture(uint target, uint texture);

        /// <summary>
        /// Draw a bitmap.
        /// </summary>
        /// <param name="width">Specify the pixel width	of the bitmap image.</param>
        /// <param name="height">Specify the pixel height of the bitmap image.</param>
        /// <param name="xorig">Specify	the location of	the origin in the bitmap image. The origin is measured from the lower left corner of the bitmap, with right and up being the positive axes.</param>
        /// <param name="yorig">Specify	the location of	the origin in the bitmap image. The origin is measured from the lower left corner of the bitmap, with right and up being the positive axes.</param>
        /// <param name="xmove">Specify	the x and y offsets to be added	to the current	raster position	after the bitmap is drawn.</param>
        /// <param name="ymove">Specify	the x and y offsets to be added	to the current	raster position	after the bitmap is drawn.</param>
        /// <param name="bitmap">Specifies the address of the bitmap image.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glBitmap(int width, int height, float xorig, float yorig, float xmove, float ymove, byte[] bitmap);

        /// <summary>
        /// This function sets the current blending function.
        /// </summary>
        /// <param name="sfactor">Source factor.</param>
        /// <param name="dfactor">Destination factor.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glBlendFunc(uint sfactor, uint dfactor);

        /// <summary>
        /// This function calls a certain display list.
        /// </summary>
        /// <param name="list">The display list to call.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glCallList(uint list);

        /// <summary>
        /// Execute	a list of display lists.
        /// </summary>
        /// <param name="n">Specifies the number of display lists to be executed.</param>
        /// <param name="type">Specifies the type of values in lists. Symbolic constants OpenGL.BYTE, OpenGL.UNSIGNED_BYTE, OpenGL.SHORT, OpenGL.UNSIGNED_SHORT, OpenGL.INT, OpenGL.UNSIGNED_INT, OpenGL.FLOAT, OpenGL.2_BYTES, OpenGL.3_BYTES and OpenGL.4_BYTES are accepted.</param>
        /// <param name="lists">Specifies the address of an array of name offsets in the display list. The pointer type is void because the offsets can be bytes, shorts, ints, or floats, depending on the value of type.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glCallLists(int n, uint type, IntPtr lists);

        /// <summary>
        /// Execute	a list of display lists. Automatically uses the GL_UNSIGNED_INT version of the function.
        /// </summary>
        /// <param name="n">The number of lists.</param>
        /// <param name="lists">The lists.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glCallLists(int n, uint type, uint[] lists);

        /// <summary>
        /// Execute	a list of display lists. Automatically uses the GL_UNSIGNED_BYTE version of the function.
        /// </summary>
        /// <param name="n">The number of lists.</param>
        /// <param name="lists">The lists.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glCallLists(int n, uint type, byte[] lists);

        /// <summary>
        /// This function clears the buffers specified by mask.
        /// </summary>
        /// <param name="mask">Which buffers to clear.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glClear(uint mask);

        /// <summary>
        /// Specify clear values for the accumulation buffer.
        /// </summary>
        /// <param name="red">Specify the red, green, blue and alpha values used when the accumulation buffer is cleared. The initial values are all 0.</param>
        /// <param name="green">Specify the red, green, blue and alpha values used when the accumulation buffer is cleared. The initial values are all 0.</param>
        /// <param name="blue">Specify the red, green, blue and alpha values used when the accumulation buffer is cleared. The initial values are all 0.</param>
        /// <param name="alpha">Specify the red, green, blue and alpha values used when the accumulation buffer is cleared. The initial values are all 0.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glClearAccum(float red, float green, float blue, float alpha);

        /// <summary>
        /// This function sets the color that the drawing buffer is 'cleared' to.
        /// </summary>
        /// <param name="red">Red component of the color (between 0 and 1).</param>
        /// <param name="green">Green component of the color (between 0 and 1).</param>
        /// <param name="blue">Blue component of the color (between 0 and 1)./</param>
        /// <param name="alpha">Alpha component of the color (between 0 and 1).</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glClearColor(float red, float green, float blue, float alpha);

        /// <summary>
        /// Specify the clear value for the depth buffer.
        /// </summary>
        /// <param name="depth">Specifies the depth value used	when the depth buffer is cleared. The initial value is 1.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glClearDepth(double depth);

        /// <summary>
        /// Specify the clear value for the color index buffers.
        /// </summary>
        /// <param name="c">Specifies the index used when the color index buffers are cleared. The initial value is 0.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glClearIndex(float c);

        /// <summary>
        /// Specify the clear value for the stencil buffer.
        /// </summary>
        /// <param name="s">Specifies the index used when the stencil buffer is cleared. The initial value is 0.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glClearStencil(int s);

        /// <summary>
        /// Specify a plane against which all geometry is clipped.
        /// </summary>
        /// <param name="plane">Specifies which clipping plane is being positioned. Symbolic names of the form OpenGL.CLIP_PLANEi, where i is an integer between 0 and OpenGL.MAX_CLIP_PLANES -1, are accepted.</param>
        /// <param name="equation">Specifies the address of an	array of four double-precision floating-point values. These values are interpreted as a plane equation.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glClipPlane(uint plane, double[] equation);
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor3b(byte red, byte green, byte blue);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 byte values.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor3bv(byte[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor3d(double red, double green, double blue);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 double values.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor3dv(double[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor3f(float red, float green, float blue);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 float values.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor3fv(float[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor3i(int red, int green, int blue);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 int values.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor3iv(int[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor3s(short red, short green, short blue);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 int values.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor3sv(short[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 255).</param>
        /// <param name="green">Green color component (between 0 and 255).</param>
        /// <param name="blue">Blue color component (between 0 and 255).</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor3ub(byte red, byte green, byte blue);
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor3ubv(byte[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor3ui(uint red, uint green, uint blue);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 unsigned int values.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor3uiv(uint[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor3us(ushort red, ushort green, ushort blue);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 unsigned short values.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor3usv(ushort[] v);
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor4b(byte red, byte green, byte blue, byte alpha);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 byte values.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor4bv(byte[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor4d(double red, double green, double blue, double alpha);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 double values.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor4dv(double[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component (between 0 and 1).</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor4f(float red, float green, float blue, float alpha);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 float values.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor4fv(float[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor4i(int red, int green, int blue, int alpha);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 int values.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor4iv(int[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor4s(short red, short green, short blue, short alpha);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 int values.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor4sv(short[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 255).</param>
        /// <param name="green">Green color component (between 0 and 255).</param>
        /// <param name="blue">Blue color component (between 0 and 255).</param>
        /// <param name="alpha">Alpha color component (between 0 and 255).</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor4ub(byte red, byte green, byte blue, byte alpha);
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor4ubv(byte[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor4ui(uint red, uint green, uint blue, uint alpha);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 unsigned int values.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor4uiv(uint[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor4us(ushort red, ushort green, ushort blue, ushort alpha);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 unsigned short values.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColor4usv(ushort[] v);

        /// <summary>
        /// This function sets the current colour mask.
        /// </summary>
        /// <param name="red">Red component mask.</param>
        /// <param name="green">Green component mask.</param>
        /// <param name="blue">Blue component mask.</param>
        /// <param name="alpha">Alpha component mask.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColorMask(byte red, byte green, byte blue, byte alpha);

        /// <summary>
        /// Cause a material color to track the current color.
        /// </summary>
        /// <param name="face">Specifies whether front, back, or both front and back material parameters should track the current color. Accepted values are OpenGL.FRONT, OpenGL.BACK, and OpenGL.FRONT_AND_BACK. The initial value is OpenGL.FRONT_AND_BACK.</param>
        /// <param name="mode">Specifies which	of several material parameters track the current color. Accepted values are	OpenGL.EMISSION, OpenGL.AMBIENT, OpenGL.DIFFUSE, OpenGL.SPECULAR and OpenGL.AMBIENT_AND_DIFFUSE. The initial value is OpenGL.AMBIENT_AND_DIFFUSE.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColorMaterial(uint face, uint mode);

        /// <summary>
        /// Define an array of colors.
        /// </summary>
        /// <param name="size">Specifies the number	of components per color. Must be 3	or 4.</param>
        /// <param name="type">Specifies the data type of each color component in the array. Symbolic constants OpenGL.BYTE, OpenGL.UNSIGNED_BYTE, OpenGL.SHORT, OpenGL.UNSIGNED_SHORT, OpenGL.INT, OpenGL.UNSIGNED_INT, OpenGL.FLOAT and OpenGL.DOUBLE are accepted.</param>
        /// <param name="stride">Specifies the byte offset between consecutive colors. If stride is 0, (the initial value), the colors are understood to be tightly packed in the array.</param>
        /// <param name="pointer">Specifies a pointer to the first component of the first color element in the array.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glColorPointer(int size, uint type, int stride, IntPtr pointer);

        /// <summary>
        /// Copy pixels in	the frame buffer.
        /// </summary>
        /// <param name="x">Specify the window coordinates of the lower left corner of the rectangular region of pixels to be copied.</param>
        /// <param name="y">Specify the window coordinates of the lower left corner of the rectangular region of pixels to be copied.</param>
        /// <param name="width">Specify the dimensions of the rectangular region of pixels to be copied. Both must be nonnegative.</param>
        /// <param name="height">Specify the dimensions of the rectangular region of pixels to be copied. Both must be nonnegative.</param>
        /// <param name="type">Specifies whether color values, depth values, or stencil values are to be copied. Symbolic constants OpenGL.COLOR, OpenGL.DEPTH, and OpenGL.STENCIL are accepted.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glCopyPixels(int x, int y, int width, int height, uint type);

        /// <summary>
        /// Copy pixels into a 1D texture image.
        /// </summary>
        /// <param name="target">Specifies the target texture. Must be OpenGL.TEXTURE_1D.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="internalFormat">Specifies the internal format of the texture.</param>
        /// <param name="x">Specify the window coordinates of the left corner of the row of pixels to be copied.</param>
        /// <param name="y">Specify the window coordinates of the left corner of the row of pixels to be copied.</param>
        /// <param name="width">Specifies the width of the texture image. Must be 0 or 2^n = (2 * border) for some integer n. The height of the texture image is 1.</param>
        /// <param name="border">Specifies the width of the border. Must be either 0 or 1.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glCopyTexImage1D(uint target, int level, uint internalFormat, int x, int y, int width, int border);

        /// <summary>
        /// Copy pixels into a	2D texture image.
        /// </summary>
        /// <param name="target">Specifies the target texture. Must be OpenGL.TEXTURE_2D.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="internalFormat">Specifies the internal format of the texture.</param>
        /// <param name="x">Specify the window coordinates of the left corner of the row of pixels to be copied.</param>
        /// <param name="y">Specify the window coordinates of the left corner of the row of pixels to be copied.</param>
        /// <param name="width">Specifies the width of the texture image.</param>
        /// <param name="height">Specifies the height of the texture image.</param>
        /// <param name="border">Specifies the width of the border. Must be either 0 or 1.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glCopyTexImage2D(uint target, int level, uint internalFormat, int x, int y, int width, int height, int border);

        /// <summary>
        /// Copy a one-dimensional texture subimage.
        /// </summary>
        /// <param name="target">Specifies the target texture. Must be OpenGL.TEXTURE_1D.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xoffset">Specifies the texel offset within the texture array.</param>
        /// <param name="x">Specify the window coordinates of the left corner of the row of pixels to be copied.</param>
        /// <param name="y">Specify the window coordinates of the left corner of the row of pixels to be copied.</param>
        /// <param name="width">Specifies the width of the texture image.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glCopyTexSubImage1D(uint target, int level, int xoffset, int x, int y, int width);

        /// <summary>
        /// Copy a two-dimensional texture subimage.
        /// </summary>
        /// <param name="target">Specifies the target texture. Must be OpenGL.TEXTURE_2D.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xoffset">Specifies the texel offset within the texture array.</param>
        /// <param name="yoffset">Specifies the texel offset within the texture array.</param>
        /// <param name="x">Specify the window coordinates of the left corner of the row of pixels to be copied.</param>
        /// <param name="y">Specify the window coordinates of the left corner of the row of pixels to be copied.</param>
        /// <param name="width">Specifies the width of the texture image.</param>
        /// <param name="height">Specifies the height of the texture image.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glCopyTexSubImage2D(uint target, int level, int xoffset, int yoffset, int x, int y, int width, int height);

        /// <summary>
        /// Specify whether front- or back-facing facets can be culled.
        /// </summary>
        /// <param name="mode">Specifies whether front- or back-facing facets are candidates for culling. Symbolic constants OpenGL.FRONT, OpenGL.BACK, and OpenGL.FRONT_AND_BACK are accepted. The initial	value is OpenGL.BACK.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glCullFace(uint mode);

        /// <summary>
        /// This function deletes a list, or a range of lists.
        /// </summary>
        /// <param name="list">The list to delete.</param>
        /// <param name="range">The range of lists (often just 1).</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glDeleteLists(uint list, int range);

        /// <summary>
        /// This function deletes a set of Texture objects.
        /// </summary>
        /// <param name="n">Number of textures to delete.</param>
        /// <param name="textures">The array containing the names of the textures to delete.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glDeleteTextures(int n, uint[] textures);

        /// <summary>
        /// This function sets the current depth buffer comparison function, the default it LESS.
        /// </summary>
        /// <param name="func">The comparison function to set.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glDepthFunc(uint func);

        /// <summary>
        /// This function sets the depth mask.
        /// </summary>
        /// <param name="flag">The depth mask flag, normally 1.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glDepthMask(byte flag);

        /// <summary>
        /// Specify mapping of depth values from normalized device coordinates	to window coordinates.
        /// </summary>
        /// <param name="zNear">Specifies the mapping of the near clipping plane to window coordinates. The initial value is 0.</param>
        /// <param name="zFar">Specifies the mapping of the near clipping plane to window coordinates. The initial value is 1.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glDepthRange(double zNear, double zFar);

        /// <summary>
        /// Call this function to disable an OpenGL capability.
        /// </summary>
        /// <param name="cap">The capability to disable.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glDisable(uint cap);

        /// <summary>
        /// This function disables a client state array, such as a vertex array.
        /// </summary>
        /// <param name="array">The array to disable.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glDisableClientState(uint array);

        /// <summary>
        /// Render	primitives from	array data.
        /// </summary>
        /// <param name="mode">Specifies what kind of primitives to render. Symbolic constants OpenGL.POINTS, OpenGL.LINE_STRIP, OpenGL.LINE_LOOP, OpenGL.LINES, OpenGL.TRIANGLE_STRIP, OpenGL.TRIANGLE_FAN, OpenGL.TRIANGLES, OpenGL.QUAD_STRIP, OpenGL.QUADS, and OpenGL.POLYGON are accepted.</param>
        /// <param name="first">Specifies the starting	index in the enabled arrays.</param>
        /// <param name="count">Specifies the number of indices to be rendered.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glDrawArrays(uint mode, int first, int count);

        /// <summary>
        /// Specify which color buffers are to be drawn into.
        /// </summary>
        /// <param name="mode">Specifies up to	four color buffers to be drawn into. Symbolic constants OpenGL.NONE, OpenGL.FRONT_LEFT, OpenGL.FRONT_RIGHT,	OpenGL.BACK_LEFT, OpenGL.BACK_RIGHT, OpenGL.FRONT, OpenGL.BACK, OpenGL.LEFT, OpenGL.RIGHT, OpenGL.FRONT_AND_BACK, and OpenGL.AUXi, where i is between 0 and (OpenGL.AUX_BUFFERS - 1), are accepted (OpenGL.AUX_BUFFERS is not the upper limit; use glGet to query the number of	available aux buffers.)  The initial value is OpenGL.FRONT for single- buffered contexts, and OpenGL.BACK for double-buffered contexts.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glDrawBuffer(uint mode);

        /// <summary>
        /// Render primitives from array data.
        /// </summary>
        /// <param name="mode">Specifies what kind of primitives to	render. Symbolic constants OpenGL.POINTS, OpenGL.LINE_STRIP, OpenGL.LINE_LOOP, OpenGL.LINES, OpenGL.TRIANGLE_STRIP, OpenGL.TRIANGLE_FAN, OpenGL.TRIANGLES, OpenGL.QUAD_STRIP, OpenGL.QUADS, and OpenGL.POLYGON are accepted.</param>
        /// <param name="count">Specifies the number of elements to be rendered.</param>
        /// <param name="type">Specifies the type of the values in indices.	Must be one of OpenGL.UNSIGNED_BYTE, OpenGL.UNSIGNED_SHORT, or OpenGL.UNSIGNED_INT.</param>
        /// <param name="indices">Specifies a pointer to the location where the indices are stored.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glDrawElements(uint mode, int count, uint type, IntPtr indices);

        /// <summary>
        /// Render primitives from array data.
        /// </summary>
        /// <param name="mode">Specifies what kind of primitives to	render. Symbolic constants OpenGL.POINTS, OpenGL.LINE_STRIP, OpenGL.LINE_LOOP, OpenGL.LINES, OpenGL.TRIANGLE_STRIP, OpenGL.TRIANGLE_FAN, OpenGL.TRIANGLES, OpenGL.QUAD_STRIP, OpenGL.QUADS, and OpenGL.POLYGON are accepted.</param>
        /// <param name="count">Specifies the number of elements to be rendered.</param>
        /// <param name="indices">Specifies a pointer to the location where the indices are stored.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glDrawElements(uint mode, int count, uint type, uint[] indices);

        /// <summary>
        /// Draws a rectangle of pixel data at the current raster position.
        /// </summary>
        /// <param name="width">Width of pixel data.</param>
        /// <param name="height">Height of pixel data.</param>
        /// <param name="format">Format of pixel data.</param>
        /// <param name="pixels">Pixel data buffer.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glDrawPixels(int width, int height, uint format, uint type, float[] pixels);

        /// <summary>
        /// Draws a rectangle of pixel data at the current raster position.
        /// </summary>
        /// <param name="width">Width of pixel data.</param>
        /// <param name="height">Height of pixel data.</param>
        /// <param name="format">Format of pixel data.</param>
        /// <param name="pixels">Pixel data buffer.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glDrawPixels(int width, int height, uint format, uint type, uint[] pixels);

        /// <summary>
        /// Draws a rectangle of pixel data at the current raster position.
        /// </summary>
        /// <param name="width">Width of pixel data.</param>
        /// <param name="height">Height of pixel data.</param>
        /// <param name="format">Format of pixel data.</param>
        /// <param name="pixels">Pixel data buffer.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glDrawPixels(int width, int height, uint format, uint type, ushort[] pixels);

        /// <summary>
        /// Draws a rectangle of pixel data at the current raster position.
        /// </summary>
        /// <param name="width">Width of pixel data.</param>
        /// <param name="height">Height of pixel data.</param>
        /// <param name="format">Format of pixel data.</param>
        /// <param name="pixels">Pixel data buffer.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glDrawPixels(int width, int height, uint format, uint type, byte[] pixels);

        /// <summary>
        /// Draws a rectangle of pixel data at the current raster position.
        /// </summary>
        /// <param name="width">Width of pixel data.</param>
        /// <param name="height">Height of pixel data.</param>
        /// <param name="format">Format of pixel data.</param>
        /// <param name="type">The GL data type.</param>
        /// <param name="pixels">Pixel data buffer.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glDrawPixels(int width, int height, uint format, uint type, IntPtr pixels);

        /// <summary>
        /// Flag edges as either boundary or nonboundary.
        /// </summary>
        /// <param name="flag">Specifies the current edge flag	value, either OpenGL.TRUE or OpenGL.FALSE. The initial value is OpenGL.TRUE.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glEdgeFlag(byte flag);

        /// <summary>
        /// Define an array of edge flags.
        /// </summary>
        /// <param name="stride">Specifies the byte offset between consecutive edge flags. If stride is	0 (the initial value), the edge	flags are understood to	be tightly packed in the array.</param>
        /// <param name="pointer">Specifies a pointer to the first edge flag in the array.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glEdgeFlagPointer(int stride, int[] pointer);

        /// <summary>
        /// Flag edges as either boundary or nonboundary.
        /// </summary>
        /// <param name="flag">Specifies a pointer to an array that contains a single boolean element,	which replaces the current edge	flag value.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glEdgeFlagv(byte[] flag);

        /// <summary>
        /// Call this function to enable an OpenGL capability.
        /// </summary>
        /// <param name="cap">The capability you wish to enable.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glEnable(uint cap);

        /// <summary>
        /// This function enables one of the client state arrays, such as a vertex array.
        /// </summary>
        /// <param name="array">The array to enable.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glEnableClientState(uint array);
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glEnd();

        /// <summary>
        /// Ends the current display list compilation.
        /// </summary>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glEndList();

        /// <summary>
        /// Evaluate from the current evaluator.
        /// </summary>
        /// <param name="u">Domain coordinate.</param>

        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glEvalCoord1d(double u);

        /// <summary>
        /// Evaluate from the current evaluator.
        /// </summary>
        /// <param name="u">Domain coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glEvalCoord1dv(double[] u);

        /// <summary>
        /// Evaluate from the current evaluator.
        /// </summary>
        /// <param name="u">Domain coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glEvalCoord1f(float u);

        /// <summary>
        /// Evaluate from the current evaluator.
        /// </summary>
        /// <param name="u">Domain coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glEvalCoord1fv(float[] u);

        /// <summary>
        /// Evaluate from the current evaluator.
        /// </summary>
        /// <param name="u">Domain coordinate.</param>
        /// <param name="v">Domain coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glEvalCoord2d(double u, double v);

        /// <summary>
        /// Evaluate from the current evaluator.
        /// </summary>
        /// <param name="u">Domain coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glEvalCoord2dv(double[] u);

        /// <summary>
        /// Evaluate from the current evaluator.
        /// </summary>
        /// <param name="u">Domain coordinate.</param>
        /// <param name="v">Domain coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glEvalCoord2f(float u, float v);

        /// <summary>
        /// Evaluate from the current evaluator.
        /// </summary>
        /// <param name="u">Domain coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glEvalCoord2fv(float[] u);

        /// <summary>
        /// Evaluates a 'mesh' from the current evaluators.
        /// </summary>
        /// <param name="mode">Drawing mode, can be POINT or LINE.</param>
        /// <param name="i1">Beginning of range.</param>
        /// <param name="i2">End of range.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glEvalMesh1(uint mode, int i1, int i2);

        /// <summary>
        /// Evaluates a 'mesh' from the current evaluators.
        /// </summary>
        /// <param name="mode">Drawing mode, fill, point or line.</param>
        /// <param name="i1">Beginning of range.</param>
        /// <param name="i2">End of range.</param>
        /// <param name="j1">Beginning of range.</param>
        /// <param name="j2">End of range.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glEvalMesh2(uint mode, int i1, int i2, int j1, int j2);

        /// <summary>
        /// Generate and evaluate a single point in a mesh.
        /// </summary>
        /// <param name="i">The integer value for grid domain variable i.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glEvalPoint1(int i);

        /// <summary>
        /// Generate and evaluate a single point in a mesh.
        /// </summary>
        /// <param name="i">The integer value for grid domain variable i.</param>
        /// <param name="j">The integer value for grid domain variable j.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glEvalPoint2(int i, int j);

        /// <summary>
        /// This function sets the feedback buffer, that will receive feedback data.
        /// </summary>
        /// <param name="size">Size of the buffer.</param>
        /// <param name="type">Type of data in the buffer.</param>
        /// <param name="buffer">The buffer itself.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glFeedbackBuffer(int size, uint type, float[] buffer);

        /// <summary>
        /// This function is similar to flush, but in a sense does it more, as it
        /// executes all commands aon both the client and the server.
        /// </summary>

        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glFinish();

        /// <summary>
        /// This forces OpenGL to execute any commands you have given it.
        /// </summary>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glFlush();

        /// <summary>
        /// Sets a fog parameter.
        /// </summary>
        /// <param name="pname">The parameter to set.</param>
        /// <param name="param">The value to set it to.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glFogf(uint pname, float param);

        /// <summary>
        /// Sets a fog parameter.
        /// </summary>
        /// <param name="pname">The parameter to set.</param>
        /// <param name="parameters">The values to set it to.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glFogfv(uint pname, float[] params_notkeyword);

        /// <summary>
        /// Sets a fog parameter.
        /// </summary>
        /// <param name="pname">The parameter to set.</param>
        /// <param name="param">The value to set it to.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glFogi(uint pname, int param);

        /// <summary>
        /// Sets a fog parameter.
        /// </summary>
        /// <param name="pname">The parameter to set.</param>
        /// <param name="parameters">The values to set it to.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glFogiv(uint pname, int[] params_notkeyword);

        /// <summary>
        /// This function sets what defines a front face.
        /// </summary>
        /// <param name="mode">Winding mode, counter clockwise by default.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glFrontFace(uint mode);

        /// <summary>
        /// This function creates a frustrum transformation and mulitplies it to the current
        /// matrix (which in most cases should be the projection matrix).
        /// </summary>
        /// <param name="left">Left clip position.</param>
        /// <param name="right">Right clip position.</param>
        /// <param name="bottom">Bottom clip position.</param>
        /// <param name="top">Top clip position.</param>
        /// <param name="zNear">Near clip position.</param>
        /// <param name="zFar">Far clip position.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glFrustum(double left, double right, double bottom, double top, double zNear, double zFar);

        /// <summary>
        /// This function generates 'range' number of contiguos display list indices.
        /// </summary>
        /// <param name="range">The number of lists to generate.</param>
        /// <returns>The first list.</returns>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern uint glGenLists(int range);

        /// <summary>
        /// Create a set of unique texture names.
        /// </summary>
        /// <param name="n">Number of names to create.</param>
        /// <param name="textures">Array to store the texture names.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGenTextures(int n, uint[] textures);

        /// <summary>
        /// This function queries OpenGL for data, and puts it in the buffer supplied.
        /// </summary>
        /// <param name="pname">The parameter to query.</param>
        /// <param name="parameters"></param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGetBooleanv(uint pname, byte[] params_notkeyword);

        /// <summary>
        /// Return the coefficients of the specified clipping plane.
        /// </summary>
        /// <param name="plane">Specifies a	clipping plane.	 The number of clipping planes depends on the implementation, but at least six clipping planes are supported. They are identified by symbolic names of the form OpenGL.CLIP_PLANEi where 0 Less Than i Less Than OpenGL.MAX_CLIP_PLANES.</param>
        /// <param name="equation">Returns four double-precision values that are the coefficients of the plane equation of plane in eye coordinates. The initial value is (0, 0, 0, 0).</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGetClipPlane(uint plane, double[] equation);

        /// <summary>
        /// This function queries OpenGL for data, and puts it in the buffer supplied.
        /// </summary>
        /// <param name="pname">The parameter to query.</param>
        /// <param name="parameters">The buffer to put that data into.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGetDoublev(uint pname, double[] params_notkeyword);

        /// <summary>
        /// Get the current OpenGL error code.
        /// </summary>
        /// <returns>The current OpenGL error code.</returns>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern uint glGetError();

        /// <summary>
        /// This this function to query OpenGL values.
        /// </summary>
        /// <param name="pname">The parameter to query.</param>
        /// <param name="parameters">The parameters</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGetFloatv(uint pname, float[] params_notkeyword);

        /// <summary>
        /// Use this function to query OpenGL parameter values.
        /// </summary>
        /// <param name="pname">The Parameter to query</param>
        /// <param name="parameters">An array to put the values into.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGetIntegerv(uint pname, int[] params_notkeyword);

        /// <summary>
        /// Return light source parameter values.
        /// </summary>
        /// <param name="light">Specifies a light source. The number of possible lights depends on the implementation, but at least eight lights are supported. They are identified by symbolic names of the form OpenGL.LIGHTi where i ranges from 0 to the value of OpenGL.GL_MAX_LIGHTS - 1.</param>
        /// <param name="pname">Specifies a light source parameter for light.</param>
        /// <param name="parameters">Returns the requested data.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGetLightfv(uint light, uint pname, float[] params_notkeyword);

        /// <summary>
        /// Return light source parameter values.
        /// </summary>
        /// <param name="light">Specifies a light source. The number of possible lights depends on the implementation, but at least eight lights are supported. They are identified by symbolic names of the form OpenGL.LIGHTi where i ranges from 0 to the value of OpenGL.GL_MAX_LIGHTS - 1.</param>
        /// <param name="pname">Specifies a light source parameter for light.</param>
        /// <param name="parameters">Returns the requested data.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGetLightiv(uint light, uint pname, int[] params_notkeyword);

        /// <summary>
        /// Return evaluator parameters.
        /// </summary>
        /// <param name="target">Specifies the symbolic name of a map.</param>
        /// <param name="query">Specifies which parameter to return.</param>
        /// <param name="v">Returns the requested data.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGetMapdv(uint target, uint query, double[] v);

        /// <summary>
        /// Return evaluator parameters.
        /// </summary>
        /// <param name="target">Specifies the symbolic name of a map.</param>
        /// <param name="query">Specifies which parameter to return.</param>
        /// <param name="v">Returns the requested data.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGetMapfv(uint target, uint query, float[] v);

        /// <summary>
        /// Return evaluator parameters.
        /// </summary>
        /// <param name="target">Specifies the symbolic name of a map.</param>
        /// <param name="query">Specifies which parameter to return.</param>
        /// <param name="v">Returns the requested data.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGetMapiv(uint target, uint query, int[] v);

        /// <summary>
        /// Return material parameters.
        /// </summary>
        /// <param name="face">Specifies which of the two materials is being queried. OpenGL.FRONT or OpenGL.BACK are accepted, representing the front and back materials, respectively.</param>
        /// <param name="pname">Specifies the material parameter to return.</param>
        /// <param name="parameters">Returns the requested data.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGetMaterialfv(uint face, uint pname, float[] params_notkeyword);

        /// <summary>
        /// Return material parameters.
        /// </summary>
        /// <param name="face">Specifies which of the two materials is being queried. OpenGL.FRONT or OpenGL.BACK are accepted, representing the front and back materials, respectively.</param>
        /// <param name="pname">Specifies the material parameter to return.</param>
        /// <param name="parameters">Returns the requested data.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGetMaterialiv(uint face, uint pname, int[] params_notkeyword);

        /// <summary>
        /// Return the specified pixel map.
        /// </summary>
        /// <param name="map">Specifies the	name of	the pixel map to return.</param>
        /// <param name="values">Returns the pixel map	contents.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGetPixelMapfv(uint map, float[] values);

        /// <summary>
        /// Return the specified pixel map.
        /// </summary>
        /// <param name="map">Specifies the	name of	the pixel map to return.</param>
        /// <param name="values">Returns the pixel map	contents.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGetPixelMapuiv(uint map, uint[] values);

        /// <summary>
        /// Return the specified pixel map.
        /// </summary>
        /// <param name="map">Specifies the	name of	the pixel map to return.</param>
        /// <param name="values">Returns the pixel map	contents.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGetPixelMapusv(uint map, ushort[] values);

        /// <summary>
        /// Return the address of the specified pointer.
        /// </summary>
        /// <param name="pname">Specifies the array or buffer pointer to be returned.</param>
        /// <param name="parameters">Returns the pointer value specified by parameters.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGetPointerv(uint pname, int[] params_notkeyword);

        /// <summary>
        /// Return the polygon stipple pattern.
        /// </summary>
        /// <param name="mask">Returns the stipple pattern. The initial value is all 1's.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGetPolygonStipple(byte[] mask);

        /// <summary>
        /// Return a string	describing the current GL connection.
        /// </summary>
        /// <param name="name">Specifies a symbolic constant, one of OpenGL.VENDOR, OpenGL.RENDERER, OpenGL.VERSION, or OpenGL.EXTENSIONS.</param>
        /// <returns>Pointer to the specified string.</returns>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        private unsafe static extern sbyte* glGetString(uint name);

        /// <summary>
        /// Return texture environment parameters.
        /// </summary>
        /// <param name="target">Specifies a texture environment.  Must be OpenGL.TEXTURE_ENV.</param>
        /// <param name="pname">Specifies the	symbolic name of a texture environment parameter.  Accepted values are OpenGL.TEXTURE_ENV_MODE, and OpenGL.TEXTURE_ENV_COLOR.</param>
        /// <param name="parameters">Returns the requested	data.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGetTexEnvfv(uint target, uint pname, float[] params_notkeyword);

        /// <summary>
        /// Return texture environment parameters.
        /// </summary>
        /// <param name="target">Specifies a texture environment.  Must be OpenGL.TEXTURE_ENV.</param>
        /// <param name="pname">Specifies the	symbolic name of a texture environment parameter.  Accepted values are OpenGL.TEXTURE_ENV_MODE, and OpenGL.TEXTURE_ENV_COLOR.</param>
        /// <param name="parameters">Returns the requested	data.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGetTexEnviv(uint target, uint pname, int[] params_notkeyword);

        /// <summary>
        /// Control the generation of texture coordinates.
        /// </summary>
        /// <param name="coord">Specifies a texture coordinate. Must be one of OpenGL.S, OpenGL.T, OpenGL.R, or OpenGL.Q.</param>
        /// <param name="pname">Specifies the symbolic name of the texture-coordinate generation function. Must be OpenGL.TEXTURE_GEN_MODE.</param>
        /// <param name="parameters">Specifies a single-valued texture generation parameter, one of OpenGL.OBJECT_LINEAR, OpenGL.EYE_LINEAR, or OpenGL.SPHERE_MAP.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGetTexGendv(uint coord, uint pname, double[] params_notkeyword);

        /// <summary>
        /// Control the generation of texture coordinates.
        /// </summary>
        /// <param name="coord">Specifies a texture coordinate. Must be one of OpenGL.S, OpenGL.T, OpenGL.R, or OpenGL.Q.</param>
        /// <param name="pname">Specifies the symbolic name of the texture-coordinate generation function. Must be OpenGL.TEXTURE_GEN_MODE.</param>
        /// <param name="parameters">Specifies a single-valued texture generation parameter, one of OpenGL.OBJECT_LINEAR, OpenGL.EYE_LINEAR, or OpenGL.SPHERE_MAP.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGetTexGenfv(uint coord, uint pname, float[] params_notkeyword);

        /// <summary>
        /// Control the generation of texture coordinates.
        /// </summary>
        /// <param name="coord">Specifies a texture coordinate. Must be one of OpenGL.S, OpenGL.T, OpenGL.R, or OpenGL.Q.</param>
        /// <param name="pname">Specifies the symbolic name of the texture-coordinate generation function. Must be OpenGL.TEXTURE_GEN_MODE.</param>
        /// <param name="parameters">Specifies a single-valued texture generation parameter, one of OpenGL.OBJECT_LINEAR, OpenGL.EYE_LINEAR, or OpenGL.SPHERE_MAP.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGetTexGeniv(uint coord, uint pname, int[] params_notkeyword);

        /// <summary>
        /// Return a texture image.
        /// </summary>
        /// <param name="target">Specifies which texture is to	be obtained. OpenGL.TEXTURE_1D and OpenGL.TEXTURE_2D are accepted.</param>
        /// <param name="level">Specifies the level-of-detail number of the desired image.  Level	0 is the base image level.  Level n is the nth mipmap reduction image.</param>
        /// <param name="format">Specifies a pixel format for the returned data.</param>
        /// <param name="type">Specifies a pixel type for the returned data.</param>
        /// <param name="pixels">Returns the texture image.  Should be	a pointer to an array of the type specified by type.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGetTexImage(uint target, int level, uint format, uint type, int[] pixels);

        /// <summary>
        /// Return texture parameter values for a specific level of detail.
        /// </summary>
        /// <param name="target">Specifies the	symbolic name of the target texture.</param>
        /// <param name="level">Specifies the level-of-detail	number of the desired image.  Level	0 is the base image level.  Level n is the nth mipmap reduction image.</param>
        /// <param name="pname">Specifies the symbolic name of a texture parameter.</param>
        /// <param name="parameters">Returns the requested	data.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGetTexLevelParameterfv(uint target, int level, uint pname, float[] params_notkeyword);

        /// <summary>
        /// Return texture parameter values for a specific level of detail.
        /// </summary>
        /// <param name="target">Specifies the	symbolic name of the target texture.</param>
        /// <param name="level">Specifies the level-of-detail	number of the desired image.  Level	0 is the base image level.  Level n is the nth mipmap reduction image.</param>
        /// <param name="pname">Specifies the symbolic name of a texture parameter.</param>
        /// <param name="parameters">Returns the requested	data.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGetTexLevelParameteriv(uint target, int level, uint pname, int[] params_notkeyword);

        /// <summary>
        /// Return texture parameter values.
        /// </summary>
        /// <param name="target">Specifies the symbolic name of the target texture.</param>
        /// <param name="pname">Specifies the symbolic name of a texture parameter.</param>
        /// <param name="parameters">Returns the texture parameters.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGetTexParameterfv(uint target, uint pname, float[] params_notkeyword);

        /// <summary>
        /// Return texture parameter values.
        /// </summary>
        /// <param name="target">Specifies the symbolic name of the target texture.</param>
        /// <param name="pname">Specifies the symbolic name of a texture parameter.</param>
        /// <param name="parameters">Returns the texture parameters.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glGetTexParameteriv(uint target, uint pname, int[] params_notkeyword);

        /// <summary>
        /// Specify implementation-specific hints.
        /// </summary>
        /// <param name="target">Specifies a symbolic constant indicating the behavior to be controlled.</param>
        /// <param name="mode">Specifies a symbolic constant indicating the desired behavior.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glHint(uint target, uint mode);

        /// <summary>
        /// Control	the writing of individual bits in the color	index buffers.
        /// </summary>
        /// <param name="mask">Specifies a bit	mask to	enable and disable the writing of individual bits in the color index buffers. Initially, the mask is all 1's.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glIndexMask(uint mask);

        /// <summary>
        /// Define an array of color indexes.
        /// </summary>
        /// <param name="type">Specifies the data type of each color index in the array.  Symbolic constants OpenGL.UNSIGNED_BYTE, OpenGL.SHORT, OpenGL.INT, OpenGL.FLOAT, and OpenGL.DOUBLE are accepted.</param>
        /// <param name="stride">Specifies the byte offset between consecutive color indexes.  If stride is 0 (the initial value), the color indexes are understood	to be tightly packed in the array.</param>
        /// <param name="pointer">Specifies a pointer to the first index in the array.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glIndexPointer(uint type, int stride, int[] pointer);

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glIndexd(double c);

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glIndexdv(double[] c);

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glIndexf(float c);

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glIndexfv(float[] c);

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glIndexi(int c);

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glIndexiv(int[] c);

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glIndexs(short c);

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glIndexsv(short[] c);

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glIndexub(byte c);

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glIndexubv(byte[] c);

        /// <summary>
        /// This function initialises the select buffer names.
        /// </summary>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glInitNames();

        /// <summary>
        /// Simultaneously specify and enable several interleaved arrays.
        /// </summary>
        /// <param name="format">Specifies the type of array to enable.</param>
        /// <param name="stride">Specifies the offset in bytes between each aggregate array element.</param>
        /// <param name="pointer">The array.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glInterleavedArrays(uint format, int stride, int[] pointer);

        /// <summary>
        /// Use this function to query if a certain OpenGL function is enabled or not.
        /// </summary>
        /// <param name="cap">The capability to test.</param>
        /// <returns>True if the capability is enabled, otherwise, false.</returns>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern byte glIsEnabled(uint cap);

        /// <summary>
        /// This function determines whether a specified value is a display list.
        /// </summary>
        /// <param name="list">The value to test.</param>
        /// <returns>TRUE if it is a list, FALSE otherwise.</returns>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern byte glIsList(uint list);

        /// <summary>
        /// Determine if a name corresponds	to a texture.
        /// </summary>
        /// <param name="texture">Specifies a value that may be the name of a texture.</param>
        /// <returns>True if texture is a texture object.</returns>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern byte glIsTexture(uint texture);

        /// <summary>
        /// This function sets a parameter of the lighting model.
        /// </summary>
        /// <param name="pname">The name of the parameter.</param>
        /// <param name="param">The parameter to set it to.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glLightModelf(uint pname, float param);

        /// <summary>
        /// This function sets a parameter of the lighting model.
        /// </summary>
        /// <param name="pname">The name of the parameter.</param>
        /// <param name="parameters">The parameter to set it to.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glLightModelfv(uint pname, float[] params_notkeyword);

        /// <summary>
        /// This function sets a parameter of the lighting model.
        /// </summary>
        /// <param name="pname">The name of the parameter.</param>
        /// <param name="param">The parameter to set it to.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glLightModeli(uint pname, int param);

        /// <summary>
        /// This function sets a parameter of the lighting model.
        /// </summary>
        /// <param name="pname">The name of the parameter.</param>
        /// <param name="parameters">The parameter to set it to.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glLightModeliv(uint pname, int[] params_notkeyword);

        /// <summary>
        /// Set the parameter (pname) of the light 'light'.
        /// </summary>
        /// <param name="light">The light you wish to set parameters for.</param>
        /// <param name="pname">The parameter you want to set.</param>
        /// <param name="param">The value that you want to set the parameter to.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glLightf(uint light, uint pname, float param);

        /// <summary>
        /// Set the parameter (pname) of the light 'light'.
        /// </summary>
        /// <param name="light">The light you wish to set parameters for.</param>
        /// <param name="pname">The parameter you want to set.</param>
        /// <param name="parameters">The value that you want to set the parameter to.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glLightfv(uint light, uint pname, float[] params_notkeyword);

        /// <summary>
        /// Set the parameter (pname) of the light 'light'.
        /// </summary>
        /// <param name="light">The light you wish to set parameters for.</param>
        /// <param name="pname">The parameter you want to set.</param>
        /// <param name="param">The value that you want to set the parameter to.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glLighti(uint light, uint pname, int param);

        /// <summary>
        /// Set the parameter (pname) of the light 'light'.
        /// </summary>
        /// <param name="light">The light you wish to set parameters for.</param>
        /// <param name="pname">The parameter you want to set.</param>
        /// <param name="parameters">The parameters.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glLightiv(uint light, uint pname, int[] params_notkeyword);

        /// <summary>
        /// Specify the line stipple pattern.
        /// </summary>
        /// <param name="factor">Specifies a multiplier for each bit in the line stipple pattern.  If factor is 3, for example, each bit in the pattern is used three times before the next	bit in the pattern is used. factor is clamped to the range	[1, 256] and defaults to 1.</param>
        /// <param name="pattern">Specifies a 16-bit integer whose bit	pattern determines which fragments of a line will be drawn when	the line is rasterized.	 Bit zero is used first; the default pattern is all 1's.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glLineStipple(int factor, ushort pattern);

        /// <summary>
        /// Set's the current width of lines.
        /// </summary>
        /// <param name="width">New line width to set.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glLineWidth(float width);

        /// <summary>
        /// Set the display-list base for glCallLists.
        /// </summary>
        /// <param name="listbase">Specifies an integer offset that will be added to glCallLists offsets to generate display-list names. The initial value is 0.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glListBase(uint base_notkeyword);

        /// <summary>
        /// Call this function to load the identity matrix into the current matrix stack.
        /// </summary>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glLoadIdentity();

        /// <summary>
        /// Replace the current matrix with the specified matrix.
        /// </summary>
        /// <param name="m">Specifies a pointer to 16 consecutive values, which are used as the elements of a 4x4 column-major matrix.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glLoadMatrixd(double[] m);

        /// <summary>
        /// Replace the current matrix with the specified matrix.
        /// </summary>
        /// <param name="m">Specifies a pointer to 16 consecutive values, which are used as the elements of a 4x4 column-major matrix.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glLoadMatrixf(float[] m);

        /// <summary>
        /// This function replaces the name at the top of the selection names stack
        /// with 'name'.
        /// </summary>
        /// <param name="name">The name to replace it with.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glLoadName(uint name);

        /// <summary>
        /// Specify a logical pixel operation for color index rendering.
        /// </summary>
        /// <param name="opcode">Specifies a symbolic constant	that selects a logical operation.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glLogicOp(uint opcode);

        /// <summary>
        /// Defines a 1D evaluator.
        /// </summary>
        /// <param name="target">What the control points represent (e.g. MAP1_VERTEX_3).</param>
        /// <param name="u1">Range of the variable 'u'.</param>
        /// <param name="u2">Range of the variable 'u'.</param>
        /// <param name="stride">Offset between beginning of one control point, and beginning of next.</param>
        /// <param name="order">The degree plus one, should agree with the number of control points.</param>
        /// <param name="points">The data for the points.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glMap1d(uint target, double u1, double u2, int stride, int order, double[] points);

        /// <summary>
        /// Defines a 1D evaluator.
        /// </summary>
        /// <param name="target">What the control points represent (e.g. MAP1_VERTEX_3).</param>
        /// <param name="u1">Range of the variable 'u'.</param>
        /// <param name="u2">Range of the variable 'u'.</param>
        /// <param name="stride">Offset between beginning of one control point, and beginning of next.</param>
        /// <param name="order">The degree plus one, should agree with the number of control points.</param>
        /// <param name="points">The data for the points.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glMap1f(uint target, float u1, float u2, int stride, int order, float[] points);

        /// <summary>
        /// Defines a 2D evaluator.
        /// </summary>
        /// <param name="target">What the control points represent (e.g. MAP2_VERTEX_3).</param>
        /// <param name="u1">Range of the variable 'u'.</param>
        /// <param name="u2">Range of the variable 'u.</param>
        /// <param name="ustride">Offset between beginning of one control point and the next.</param>
        /// <param name="uorder">The degree plus one.</param>
        /// <param name="v1">Range of the variable 'v'.</param>
        /// <param name="v2">Range of the variable 'v'.</param>
        /// <param name="vstride">Offset between beginning of one control point and the next.</param>
        /// <param name="vorder">The degree plus one.</param>
        /// <param name="points">The data for the points.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glMap2d(uint target, double u1, double u2, int ustride, int uorder, double v1, double v2, int vstride, int vorder, double[] points);

        /// <summary>
        /// Defines a 2D evaluator.
        /// </summary>
        /// <param name="target">What the control points represent (e.g. MAP2_VERTEX_3).</param>
        /// <param name="u1">Range of the variable 'u'.</param>
        /// <param name="u2">Range of the variable 'u.</param>
        /// <param name="ustride">Offset between beginning of one control point and the next.</param>
        /// <param name="uorder">The degree plus one.</param>
        /// <param name="v1">Range of the variable 'v'.</param>
        /// <param name="v2">Range of the variable 'v'.</param>
        /// <param name="vstride">Offset between beginning of one control point and the next.</param>
        /// <param name="vorder">The degree plus one.</param>
        /// <param name="points">The data for the points.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glMap2f(uint target, float u1, float u2, int ustride, int uorder, float v1, float v2, int vstride, int vorder, float[] points);

        /// <summary>
        /// This function defines a grid that goes from u1 to u1 in n steps, evenly spaced.
        /// </summary>
        /// <param name="un">Number of steps.</param>
        /// <param name="u1">Range of variable 'u'.</param>
        /// <param name="u2">Range of variable 'u'.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glMapGrid1d(int un, double u1, double u2);
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glMapGrid1f(int un, float u1, float u2);

        /// <summary>
        /// This function defines a grid that goes from u1 to u1 in n steps, evenly spaced,
        /// and the same for v.
        /// </summary>
        /// <param name="un">Number of steps.</param>
        /// <param name="u1">Range of variable 'u'.</param>
        /// <param name="u2">Range of variable 'u'.</param>
        /// <param name="vn">Number of steps.</param>
        /// <param name="v1">Range of variable 'v'.</param>
        /// <param name="v2">Range of variable 'v'.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glMapGrid2d(int un, double u1, double u2, int vn, double v1, double v2);

        /// <summary>
        /// This function defines a grid that goes from u1 to u1 in n steps, evenly spaced,
        /// and the same for v.
        /// </summary>
        /// <param name="un">Number of steps.</param>
        /// <param name="u1">Range of variable 'u'.</param>
        /// <param name="u2">Range of variable 'u'.</param>
        /// <param name="vn">Number of steps.</param>
        /// <param name="v1">Range of variable 'v'.</param>
        /// <param name="v2">Range of variable 'v'.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glMapGrid2f(int un, float u1, float u2, int vn, float v1, float v2);

        /// <summary>
        /// This function sets a material parameter.
        /// </summary>
        /// <param name="face">What faces is this parameter for (i.e front/back etc).</param>
        /// <param name="pname">What parameter you want to set.</param>
        /// <param name="param">The value to set 'pname' to.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glMaterialf(uint face, uint pname, float param);

        /// <summary>
        /// This function sets a material parameter.
        /// </summary>
        /// <param name="face">What faces is this parameter for (i.e front/back etc).</param>
        /// <param name="pname">What parameter you want to set.</param>
        /// <param name="parameters">The value to set 'pname' to.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glMaterialfv(uint face, uint pname, float[] params_notkeyword);

        /// <summary>
        /// This function sets a material parameter.
        /// </summary>
        /// <param name="face">What faces is this parameter for (i.e front/back etc).</param>
        /// <param name="pname">What parameter you want to set.</param>
        /// <param name="param">The value to set 'pname' to.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glMateriali(uint face, uint pname, int param);

        /// <summary>
        /// This function sets a material parameter.
        /// </summary>
        /// <param name="face">What faces is this parameter for (i.e front/back etc).</param>
        /// <param name="pname">What parameter you want to set.</param>
        /// <param name="parameters">The value to set 'pname' to.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glMaterialiv(uint face, uint pname, int[] params_notkeyword);

        /// <summary>
        /// Set the current matrix mode (the matrix that matrix operations will be 
        /// performed on).
        /// </summary>
        /// <param name="mode">The mode, normally PROJECTION or MODELVIEW.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glMatrixMode(uint mode);

        /// <summary>
        /// Multiply the current matrix with the specified matrix.
        /// </summary>
        /// <param name="m">Points to 16 consecutive values that are used as the elements of a 4x4 column-major matrix.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glMultMatrixd(double[] m);

        /// <summary>
        /// Multiply the current matrix with the specified matrix.
        /// </summary>
        /// <param name="m">Points to 16 consecutive values that are used as the elements of a 4x4 column-major matrix.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glMultMatrixf(float[] m);

        /// <summary>
        /// This function starts compiling a new display list.
        /// </summary>
        /// <param name="list">The list to compile.</param>
        /// <param name="mode">Either COMPILE or COMPILE_AND_EXECUTE.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glNewList(uint list, uint mode);

        /// <summary>
        /// Set the current normal.
        /// </summary>
        /// <param name="nx">Normal Coordinate.</param>
        /// <param name="ny">Normal Coordinate.</param>
        /// <param name="nz">Normal Coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glNormal3b(byte nx, byte ny, byte nz);

        /// <summary>
        /// This function sets the current normal.
        /// </summary>
        /// <param name="v">The normal.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glNormal3bv(byte[] v);

        /// <summary>
        /// Set the current normal.
        /// </summary>
        /// <param name="nx">Normal Coordinate.</param>
        /// <param name="ny">Normal Coordinate.</param>
        /// <param name="nz">Normal Coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glNormal3d(double nx, double ny, double nz);

        /// <summary>
        /// This function sets the current normal.
        /// </summary>
        /// <param name="v">The normal.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glNormal3dv(double[] v);

        /// <summary>
        /// Set the current normal.
        /// </summary>
        /// <param name="nx">Normal Coordinate.</param>
        /// <param name="ny">Normal Coordinate.</param>
        /// <param name="nz">Normal Coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glNormal3f(float nx, float ny, float nz);

        /// <summary>
        /// This function sets the current normal.
        /// </summary>
        /// <param name="v">The normal.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glNormal3fv(float[] v);

        /// <summary>
        /// Set the current normal.
        /// </summary>
        /// <param name="nx">Normal Coordinate.</param>
        /// <param name="ny">Normal Coordinate.</param>
        /// <param name="nz">Normal Coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glNormal3i(int nx, int ny, int nz);

        /// <summary>
        /// This function sets the current normal.
        /// </summary>
        /// <param name="v">The normal.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glNormal3iv(int[] v);

        /// <summary>
        /// Set the current normal.
        /// </summary>
        /// <param name="nx">Normal Coordinate.</param>
        /// <param name="ny">Normal Coordinate.</param>
        /// <param name="nz">Normal Coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glNormal3s(short nx, short ny, short nz);

        /// <summary>
        /// This function sets the current normal.
        /// </summary>
        /// <param name="v">The normal.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glNormal3sv(short[] v);

        /// <summary>
        /// Set's the pointer to the normal array.
        /// </summary>
        /// <param name="type">The type of data.</param>
        /// <param name="stride">The space in bytes between each normal.</param>
        /// <param name="pointer">The normals.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glNormalPointer(uint type, int stride, IntPtr pointer);

        /// <summary>
        /// Set's the pointer to the normal array.
        /// </summary>
        /// <param name="type">The type of data.</param>
        /// <param name="stride">The space in bytes between each normal.</param>
        /// <param name="pointer">The normals.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glNormalPointer(uint type, int stride, float[] pointer);

        /// <summary>
        /// This function creates an orthographic projection matrix (i.e one with no 
        /// perspective) and multiplies it to the current matrix stack, which would
        /// normally be 'PROJECTION'.
        /// </summary>
        /// <param name="left">Left clipping plane.</param>
        /// <param name="right">Right clipping plane.</param>
        /// <param name="bottom">Bottom clipping plane.</param>
        /// <param name="top">Top clipping plane.</param>
        /// <param name="zNear">Near clipping plane.</param>
        /// <param name="zFar">Far clipping plane.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glOrtho(double left, double right, double bottom, double top, double zNear, double zFar);

        /// <summary>
        /// Place a marker in the feedback buffer.
        /// </summary>
        /// <param name="token">Specifies a marker value to be placed in the feedback buffer following a OpenGL.PASS_THROUGH_TOKEN.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glPassThrough(float token);

        /// <summary>
        /// Set up pixel transfer maps.
        /// </summary>
        /// <param name="map">Specifies a symbolic	map name.</param>
        /// <param name="mapsize">Specifies the size of the map being defined.</param>
        /// <param name="values">Specifies an	array of mapsize values.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glPixelMapfv(uint map, int mapsize, float[] values);

        /// <summary>
        /// Set up pixel transfer maps.
        /// </summary>
        /// <param name="map">Specifies a symbolic	map name.</param>
        /// <param name="mapsize">Specifies the size of the map being defined.</param>
        /// <param name="values">Specifies an	array of mapsize values.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glPixelMapuiv(uint map, int mapsize, uint[] values);

        /// <summary>
        /// Set up pixel transfer maps.
        /// </summary>
        /// <param name="map">Specifies a symbolic	map name.</param>
        /// <param name="mapsize">Specifies the size of the map being defined.</param>
        /// <param name="values">Specifies an	array of mapsize values.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glPixelMapusv(uint map, int mapsize, ushort[] values);

        /// <summary>
        /// Set pixel storage modes.
        /// </summary>
        /// <param name="pname">Specifies the symbolic	name of	the parameter to be set.</param>
        /// <param name="param">Specifies the value that pname	is set to.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glPixelStoref(uint pname, float param);

        /// <summary>
        /// Set pixel storage modes.
        /// </summary>
        /// <param name="pname">Specifies the symbolic	name of	the parameter to be set.</param>
        /// <param name="param">Specifies the value that pname	is set to.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glPixelStorei(uint pname, int param);

        /// <summary>
        /// Set pixel transfer modes.
        /// </summary>
        /// <param name="pname">Specifies the symbolic name of the pixel transfer parameter to be set.</param>
        /// <param name="param">Specifies the value that pname is set to.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glPixelTransferf(uint pname, float param);

        /// <summary>
        /// Set pixel transfer modes.
        /// </summary>
        /// <param name="pname">Specifies the symbolic name of the pixel transfer parameter to be set.</param>
        /// <param name="param">Specifies the value that pname is set to.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glPixelTransferi(uint pname, int param);

        /// <summary>
        /// Specify	the pixel zoom factors.
        /// </summary>
        /// <param name="xfactor">Specify the x and y zoom factors for pixel write operations.</param>
        /// <param name="yfactor">Specify the x and y zoom factors for pixel write operations.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glPixelZoom(float xfactor, float yfactor);

        /// <summary>
        /// The size of points to be rasterised.
        /// </summary>
        /// <param name="size">Size in pixels.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glPointSize(float size);

        /// <summary>
        /// This sets the current drawing mode of polygons (points, lines, filled).
        /// </summary>
        /// <param name="face">The faces this applies to (front, back or both).</param>
        /// <param name="mode">The mode to set to (points, lines, or filled).</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glPolygonMode(uint face, uint mode);

        /// <summary>
        /// Set	the scale and units used to calculate depth	values.
        /// </summary>
        /// <param name="factor">Specifies a scale factor that	is used	to create a variable depth offset for each polygon. The initial value is 0.</param>
        /// <param name="units">Is multiplied by an implementation-specific value to create a constant depth offset. The initial value is 0.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glPolygonOffset(float factor, float units);

        /// <summary>
        /// Set the polygon stippling pattern.
        /// </summary>
        /// <param name="mask">Specifies a pointer to a 32x32 stipple pattern that will be unpacked from memory in the same way that glDrawPixels unpacks pixels.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glPolygonStipple(byte[] mask);

        /// <summary>
        /// This function restores the attribute stack to the state it was when
        /// PushAttrib was called.
        /// </summary>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glPopAttrib();

        /// <summary>
        /// Pop the client attribute stack.
        /// </summary>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glPopClientAttrib();

        /// <summary>
        /// Restore the previously saved state of the current matrix stack.
        /// </summary>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glPopMatrix();

        /// <summary>
        /// This takes the top name off the selection names stack.
        /// </summary>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glPopName();

        /// <summary>
        /// Set texture residence priority.
        /// </summary>
        /// <param name="n">Specifies the number of textures to be prioritized.</param>
        /// <param name="textures">Specifies an array containing the names of the textures to be prioritized.</param>
        /// <param name="priorities">Specifies	an array containing the	texture priorities. A priority given in an element of priorities applies to the	texture	named by the corresponding element of textures.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glPrioritizeTextures(int n, uint[] textures, float[] priorities);

        /// <summary>
        /// Save the current state of the attribute groups specified by 'mask'.
        /// </summary>
        /// <param name="mask">The attibute groups to save.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glPushAttrib(uint mask);

        /// <summary>
        /// Push the client attribute stack.
        /// </summary>
        /// <param name="mask">Specifies a mask that indicates	which attributes to save.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glPushClientAttrib(uint mask);

        /// <summary>
        /// Save the current state of the current matrix stack.
        /// </summary>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glPushMatrix();

        /// <summary>
        /// This function adds a new name to the selection buffer.
        /// </summary>
        /// <param name="name">The name to add.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glPushName(uint name);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRasterPos2d(double x, double y);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRasterPos2dv(double[] v);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRasterPos2f(float x, float y);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRasterPos2fv(float[] v);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRasterPos2i(int x, int y);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRasterPos2iv(int[] v);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRasterPos2s(short x, short y);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRasterPos2sv(short[] v);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRasterPos3d(double x, double y, double z);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRasterPos3dv(double[] v);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRasterPos3f(float x, float y, float z);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRasterPos3fv(float[] v);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRasterPos3i(int x, int y, int z);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRasterPos3iv(int[] v);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRasterPos3s(short x, short y, short z);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRasterPos3sv(short[] v);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        /// <param name="w">W coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRasterPos4d(double x, double y, double z, double w);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRasterPos4dv(double[] v);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        /// <param name="w">W coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRasterPos4f(float x, float y, float z, float w);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRasterPos4fv(float[] v);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        /// <param name="w">W coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRasterPos4i(int x, int y, int z, int w);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRasterPos4iv(int[] v);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        /// <param name="w">W coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRasterPos4s(short x, short y, short z, short w);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRasterPos4sv(short[] v);

        /// <summary>
        /// Select	a color	buffer source for pixels.
        /// </summary>
        /// <param name="mode">Specifies a color buffer.  Accepted values are OpenGL.FRONT_LEFT, OpenGL.FRONT_RIGHT, OpenGL.BACK_LEFT, OpenGL.BACK_RIGHT, OpenGL.FRONT, OpenGL.BACK, OpenGL.LEFT, OpenGL.GL_RIGHT, and OpenGL.AUXi, where i is between 0 and OpenGL.AUX_BUFFERS - 1.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glReadBuffer(uint mode);

        /// <summary>
        /// Reads a block of pixels from the frame buffer.
        /// </summary>
        /// <param name="x">Top-Left X value.</param>
        /// <param name="y">Top-Left Y value.</param>
        /// <param name="width">Width of block to read.</param>
        /// <param name="height">Height of block to read.</param>
        /// <param name="format">Specifies the format of the pixel data. The following symbolic values are accepted: OpenGL.COLOR_INDEX, OpenGL.STENCIL_INDEX, OpenGL.DEPTH_COMPONENT, OpenGL.RED, OpenGL.GREEN, OpenGL.BLUE, OpenGL.ALPHA, OpenGL.RGB, OpenGL.RGBA, OpenGL.LUMINANCE and OpenGL.LUMINANCE_ALPHA.</param>
        /// <param name="type">Specifies the data type of the pixel data.Must be one of OpenGL.UNSIGNED_BYTE, OpenGL.BYTE, OpenGL.BITMAP, OpenGL.UNSIGNED_SHORT, OpenGL.SHORT, OpenGL.UNSIGNED_INT, OpenGL.INT or OpenGL.FLOAT.</param>
        /// <param name="pixels">Storage for the pixel data received.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glReadPixels(int x, int y, int width, int height, uint format, uint type, byte[] pixels);

        /// <summary>
        /// Reads a block of pixels from the frame buffer.
        /// </summary>
        /// <param name="x">Top-Left X value.</param>
        /// <param name="y">Top-Left Y value.</param>
        /// <param name="width">Width of block to read.</param>
        /// <param name="height">Height of block to read.</param>
        /// <param name="format">Specifies the format of the pixel data. The following symbolic values are accepted: OpenGL.COLOR_INDEX, OpenGL.STENCIL_INDEX, OpenGL.DEPTH_COMPONENT, OpenGL.RED, OpenGL.GREEN, OpenGL.BLUE, OpenGL.ALPHA, OpenGL.RGB, OpenGL.RGBA, OpenGL.LUMINANCE and OpenGL.LUMINANCE_ALPHA.</param>
        /// <param name="type">Specifies the data type of the pixel data.Must be one of OpenGL.UNSIGNED_BYTE, OpenGL.BYTE, OpenGL.BITMAP, OpenGL.UNSIGNED_SHORT, OpenGL.SHORT, OpenGL.UNSIGNED_INT, OpenGL.INT or OpenGL.FLOAT.</param>
        /// <param name="pixels">Storage for the pixel data received.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glReadPixels(int x, int y, int width, int height, uint format, uint type, IntPtr pixels);

        /// <summary>
        /// Draw a rectangle from two coordinates (top-left and bottom-right).
        /// </summary>
        /// <param name="x1">Top-Left X value.</param>
        /// <param name="y1">Top-Left Y value.</param>
        /// <param name="x2">Bottom-Right X Value.</param>
        /// <param name="y2">Bottom-Right Y Value.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRectd(double x1, double y1, double x2, double y2);

        /// <summary>
        /// Draw a rectangle from two coordinates, expressed as arrays, e.g
        /// Rect(new float[] {0, 0}, new float[] {10, 10});
        /// </summary>
        /// <param name="v1">Top-Left point.</param>
        /// <param name="v2">Bottom-Right point.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRectdv(double[] v1, double[] v2);
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRectf(float x1, float y1, float x2, float y2);

        /// <summary>
        /// Draw a rectangle from two coordinates, expressed as arrays, e.g
        /// Rect(new float[] {0, 0}, new float[] {10, 10});
        /// </summary>
        /// <param name="v1">Top-Left point.</param>
        /// <param name="v2">Bottom-Right point.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRectfv(float[] v1, float[] v2);

        /// <summary>
        /// Draw a rectangle from two coordinates (top-left and bottom-right).
        /// </summary>
        /// <param name="x1">Top-Left X value.</param>
        /// <param name="y1">Top-Left Y value.</param>
        /// <param name="x2">Bottom-Right X Value.</param>
        /// <param name="y2">Bottom-Right Y Value.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRecti(int x1, int y1, int x2, int y2);

        /// <summary>
        /// Draw a rectangle from two coordinates, expressed as arrays, e.g
        /// Rect(new float[] {0, 0}, new float[] {10, 10});
        /// </summary>
        /// <param name="v1">Top-Left point.</param>
        /// <param name="v2">Bottom-Right point.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRectiv(int[] v1, int[] v2);

        /// <summary>
        /// Draw a rectangle from two coordinates (top-left and bottom-right).
        /// </summary>
        /// <param name="x1">Top-Left X value.</param>
        /// <param name="y1">Top-Left Y value.</param>
        /// <param name="x2">Bottom-Right X Value.</param>
        /// <param name="y2">Bottom-Right Y Value.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRects(short x1, short y1, short x2, short y2);

        /// <summary>
        /// Draw a rectangle from two coordinates, expressed as arrays, e.g
        /// Rect(new float[] {0, 0}, new float[] {10, 10});
        /// </summary>
        /// <param name="v1">Top-Left point.</param>
        /// <param name="v2">Bottom-Right point.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRectsv(short[] v1, short[] v2);

        /// <summary>
        /// This function sets the current render mode (render, feedback or select).
        /// </summary>
        /// <param name="mode">The Render mode (RENDER, SELECT or FEEDBACK).</param>
        /// <returns>The hits that selection or feedback caused..</returns>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern int glRenderMode(uint mode);

        /// <summary>
        /// This function applies a rotation transformation to the current matrix.
        /// </summary>
        /// <param name="angle">The angle to rotate.</param>
        /// <param name="x">Amount along x.</param>
        /// <param name="y">Amount along y.</param>
        /// <param name="z">Amount along z.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRotated(double angle, double x, double y, double z);

        /// <summary>
        /// This function applies a rotation transformation to the current matrix.
        /// </summary>
        /// <param name="angle">The angle to rotate.</param>
        /// <param name="x">Amount along x.</param>
        /// <param name="y">Amount along y.</param>
        /// <param name="z">Amount along z.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glRotatef(float angle, float x, float y, float z);

        /// <summary>
        /// This function applies a scale transformation to the current matrix.
        /// </summary>
        /// <param name="x">The amount to scale along x.</param>
        /// <param name="y">The amount to scale along y.</param>
        /// <param name="z">The amount to scale along z.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glScaled(double x, double y, double z);

        /// <summary>
        /// This function applies a scale transformation to the current matrix.
        /// </summary>
        /// <param name="x">The amount to scale along x.</param>
        /// <param name="y">The amount to scale along y.</param>
        /// <param name="z">The amount to scale along z.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glScalef(float x, float y, float z);

        /// <summary>
        /// Define the scissor box.
        /// </summary>
        /// <param name="x">Specify the lower left corner of the scissor box. Initially (0, 0).</param>
        /// <param name="y">Specify the lower left corner of the scissor box. Initially (0, 0).</param>
        /// <param name="width">Specify the width and height of the scissor box. When a GL context is first attached to a window, width and height are set to the dimensions of that window.</param>
        /// <param name="height">Specify the width and height of the scissor box. When a GL context is first attached to a window, width and height are set to the dimensions of that window.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glScissor(int x, int y, int width, int height);

        /// <summary>
        /// This function sets the current select buffer.
        /// </summary>
        /// <param name="size">The size of the buffer you are passing.</param>
        /// <param name="buffer">The buffer itself.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glSelectBuffer(int size, uint[] buffer);

        /// <summary>
        /// Select flat or smooth shading.
        /// </summary>
        /// <param name="mode">Specifies a symbolic value representing a shading technique. Accepted values are OpenGL.FLAT and OpenGL.SMOOTH. The default is OpenGL.SMOOTH.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glShadeModel(uint mode);

        /// <summary>
        /// This function sets the current stencil buffer function.
        /// </summary>
        /// <param name="func">The function type.</param>
        /// <param name="reference">The function reference.</param>
        /// <param name="mask">The function mask.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glStencilFunc(uint func, int ref_notkeword, uint mask);

        /// <summary>
        /// This function sets the stencil buffer mask.
        /// </summary>
        /// <param name="mask">The mask.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glStencilMask(uint mask);

        /// <summary>
        /// This function sets the stencil buffer operation.
        /// </summary>
        /// <param name="fail">Fail operation.</param>
        /// <param name="zfail">Depth fail component.</param>
        /// <param name="zpass">Depth pass component.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glStencilOp(uint fail, uint zfail, uint zpass);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord1d(double s);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord1dv(double[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord1f(float s);

        /// <summary>
        /// This function sets the current texture coordinates. WARNING: if you
        /// can call something more explicit, like TexCoord2f then call that, it's
        /// much faster.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord1fv(float[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord1i(int s);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord1iv(int[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord1s(short s);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord1sv(short[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord2d(double s, double t);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord2dv(double[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord2f(float s, float t);

        /// <summary>
        /// This function sets the current texture coordinates. WARNING: if you
        /// can call something more explicit, like TexCoord2f then call that, it's
        /// much faster.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord2fv(float[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord2i(int s, int t);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord2iv(int[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord2s(short s, short t);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord2sv(short[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord3d(double s, double t, double r);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord3dv(double[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord3f(float s, float t, float r);

        /// <summary>
        /// This function sets the current texture coordinates. WARNING: if you
        /// can call something more explicit, like TexCoord2f then call that, it's
        /// much faster.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord3fv(float[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord3i(int s, int t, int r);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord3iv(int[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord3s(short s, short t, short r);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord3sv(short[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        /// <param name="q">Texture Coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord4d(double s, double t, double r, double q);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord4dv(double[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        /// <param name="q">Texture Coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord4f(float s, float t, float r, float q);

        /// <summary>
        /// This function sets the current texture coordinates. WARNING: if you
        /// can call something more explicit, like TexCoord2f then call that, it's
        /// much faster.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord4fv(float[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        /// <param name="q">Texture Coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord4i(int s, int t, int r, int q);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord4iv(int[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        /// <param name="q">Texture Coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord4s(short s, short t, short r, short q);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoord4sv(short[] v);

        /// <summary>
        /// This function sets the texture coord array.
        /// </summary>
        /// <param name="size">The number of coords per set.</param>
        /// <param name="type">The type of data.</param>
        /// <param name="stride">The number of bytes between coords.</param>
        /// <param name="pointer">The coords.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoordPointer(int size, uint type, int stride, IntPtr pointer);

        /// <summary>
        /// This function sets the texture coord array.
        /// </summary>
        /// <param name="size">The number of coords per set.</param>
        /// <param name="type">The type of data.</param>
        /// <param name="stride">The number of bytes between coords.</param>
        /// <param name="pointer">The coords.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexCoordPointer(int size, uint type, int stride, float[] pointer);

        /// <summary>
        /// Set texture environment parameters.
        /// </summary>
        /// <param name="target">Specifies a texture environment. Must be OpenGL.TEXTURE_ENV.</param>
        /// <param name="pname">Specifies the symbolic name of a single-valued texture environment parameter. Must be OpenGL.TEXTURE_ENV_MODE.</param>
        /// <param name="param">Specifies a single symbolic constant, one of OpenGL.MODULATE, OpenGL.DECAL, OpenGL.BLEND, or OpenGL.REPLACE.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexEnvf(uint target, uint pname, float param);

        /// <summary>
        /// Set texture environment parameters.
        /// </summary>
        /// <param name="target">Specifies a texture environment. Must be OpenGL.TEXTURE_ENV.</param>
        /// <param name="pname">Specifies the symbolic name of a texture environment parameter. Accepted values are OpenGL.TEXTURE_ENV_MODE and OpenGL.TEXTURE_ENV_COLOR.</param>
        /// <param name="parameters">Specifies a pointer to a parameter array that contains either a single symbolic constant or an RGBA color.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexEnvfv(uint target, uint pname, float[] params_notkeyword);

        /// <summary>
        /// Set texture environment parameters.
        /// </summary>
        /// <param name="target">Specifies a texture environment. Must be OpenGL.TEXTURE_ENV.</param>
        /// <param name="pname">Specifies the symbolic name of a single-valued texture environment parameter. Must be OpenGL.TEXTURE_ENV_MODE.</param>
        /// <param name="param">Specifies a single symbolic constant, one of OpenGL.MODULATE, OpenGL.DECAL, OpenGL.BLEND, or OpenGL.REPLACE.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexEnvi(uint target, uint pname, int param);
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexEnviv(uint target, uint pname, int[] params_notkeyword);

        /// <summary>
        /// Control the generation of texture coordinates.
        /// </summary>
        /// <param name="coord">Specifies a texture coordinate. Must be one of OpenGL.S, OpenGL.T, OpenGL.R, or OpenGL.Q.</param>
        /// <param name="pname">Specifies the symbolic name of the texture-coordinate generation function. Must be OpenGL.TEXTURE_GEN_MODE.</param>
        /// <param name="param">Specifies a single-valued texture generation parameter, one of OpenGL.OBJECT_LINEAR, OpenGL.GL_EYE_LINEAR, or OpenGL.SPHERE_MAP.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexGend(uint coord, uint pname, double param);

        /// <summary>
        /// Control the generation of texture coordinates.
        /// </summary>
        /// <param name="coord">Specifies a texture coordinate. Must be one of OpenGL.S, OpenGL.T, OpenGL.R, or OpenGL.Q.</param>
        /// <param name="pname">Specifies the symbolic name of the texture-coordinate generation function or function parameters. Must be OpenGL.TEXTURE_GEN_MODE, OpenGL.OBJECT_PLANE, or OpenGL.EYE_PLANE.</param>
        /// <param name="parameters">Specifies a pointer to an array of texture generation parameters. If pname is OpenGL.TEXTURE_GEN_MODE, then the array must contain a single symbolic constant, one of OpenGL.OBJECT_LINEAR, OpenGL.EYE_LINEAR, or OpenGL.SPHERE_MAP. Otherwise, params holds the coefficients for the texture-coordinate generation function specified by pname.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexGendv(uint coord, uint pname, double[] params_notkeyword);

        /// <summary>
        /// Control the generation of texture coordinates.
        /// </summary>
        /// <param name="coord">Specifies a texture coordinate. Must be one of OpenGL.S, OpenGL.T, OpenGL.R, or OpenGL.Q.</param>
        /// <param name="pname">Specifies the symbolic name of the texture-coordinate generation function. Must be OpenGL.TEXTURE_GEN_MODE.</param>
        /// <param name="param">Specifies a single-valued texture generation parameter, one of OpenGL.OBJECT_LINEAR, OpenGL.GL_EYE_LINEAR, or OpenGL.SPHERE_MAP.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexGenf(uint coord, uint pname, float param);

        /// <summary>
        /// Control the generation of texture coordinates.
        /// </summary>
        /// <param name="coord">Specifies a texture coordinate. Must be one of OpenGL.S, OpenGL.T, OpenGL.R, or OpenGL.Q.</param>
        /// <param name="pname">Specifies the symbolic name of the texture-coordinate generation function or function parameters. Must be OpenGL.TEXTURE_GEN_MODE, OpenGL.OBJECT_PLANE, or OpenGL.EYE_PLANE.</param>
        /// <param name="parameters">Specifies a pointer to an array of texture generation parameters. If pname is OpenGL.TEXTURE_GEN_MODE, then the array must contain a single symbolic constant, one of OpenGL.OBJECT_LINEAR, OpenGL.EYE_LINEAR, or OpenGL.SPHERE_MAP. Otherwise, params holds the coefficients for the texture-coordinate generation function specified by pname.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexGenfv(uint coord, uint pname, float[] params_notkeyword);

        /// <summary>
        /// Control the generation of texture coordinates.
        /// </summary>
        /// <param name="coord">Specifies a texture coordinate. Must be one of OpenGL.S, OpenGL.T, OpenGL.R, or OpenGL.Q.</param>
        /// <param name="pname">Specifies the symbolic name of the texture-coordinate generation function. Must be OpenGL.TEXTURE_GEN_MODE.</param>
        /// <param name="param">Specifies a single-valued texture generation parameter, one of OpenGL.OBJECT_LINEAR, OpenGL.GL_EYE_LINEAR, or OpenGL.SPHERE_MAP.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexGeni(uint coord, uint pname, int param);

        ///// <summary>
        ///// Set texture environment parameters.
        ///// </summary>
        ///// <param name="target">Specifies a texture environment. Must be OpenGL.TEXTURE_ENV.</param>
        ///// <param name="pname">Specifies the symbolic name of a texture environment parameter. Accepted values are OpenGL.TEXTURE_ENV_MODE and OpenGL.TEXTURE_ENV_COLOR.</param>
        ///// <param name="parameters">Specifies a pointer to a parameter array that contains either a single symbolic constant or an RGBA color.</param>
        ////
        /// <summary>
        /// Control the generation of texture coordinates.
        /// </summary>
        /// <param name="coord">Specifies a texture coordinate. Must be one of OpenGL.S, OpenGL.T, OpenGL.R, or OpenGL.Q.</param>
        /// <param name="pname">Specifies the symbolic name of the texture-coordinate generation function or function parameters. Must be OpenGL.TEXTURE_GEN_MODE, OpenGL.OBJECT_PLANE, or OpenGL.EYE_PLANE.</param>
        /// <param name="parameters">Specifies a pointer to an array of texture generation parameters. If pname is OpenGL.TEXTURE_GEN_MODE, then the array must contain a single symbolic constant, one of OpenGL.OBJECT_LINEAR, OpenGL.EYE_LINEAR, or OpenGL.SPHERE_MAP. Otherwise, params holds the coefficients for the texture-coordinate generation function specified by pname.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexGeniv(uint coord, uint pname, int[] params_notkeyword);

        /// <summary>
        /// This function sets the image for the currently binded texture.
        /// </summary>
        /// <param name="target">The type of texture, TEXTURE_2D or PROXY_TEXTURE_2D.</param>
        /// <param name="level">For mip-map textures, ordinary textures should be '0'.</param>
        /// <param name="internalformat">The format of the data you are want OpenGL to create, e.g  RGB16.</param>
        /// <param name="width">The width of the texture image (must be a power of 2, e.g 64).</param>
        /// <param name="border">The width of the border (0 or 1).</param>
        /// <param name="format">The format of the data you are passing, e.g. RGBA.</param>
        /// <param name="type">The type of data you are passing, e.g GL_BYTE.</param>
        /// <param name="pixels">The actual pixel data.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexImage1D(uint target, int level, uint internalformat, int width, int border, uint format, uint type, byte[] pixels);

        /// <summary>
        /// This function sets the image for the currently binded texture.
        /// </summary>
        /// <param name="target">The type of texture, TEXTURE_2D or PROXY_TEXTURE_2D.</param>
        /// <param name="level">For mip-map textures, ordinary textures should be '0'.</param>
        /// <param name="internalformat">The format of the data you are want OpenGL to create, e.g  RGB16.</param>
        /// <param name="width">The width of the texture image (must be a power of 2, e.g 64).</param>
        /// <param name="height">The height of the texture image (must be a power of 2, e.g 32).</param>
        /// <param name="border">The width of the border (0 or 1).</param>
        /// <param name="format">The format of the data you are passing, e.g. RGBA.</param>
        /// <param name="type">The type of data you are passing, e.g GL_BYTE.</param>
        /// <param name="pixels">The actual pixel data.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexImage2D(uint target, int level, uint internalformat, int width, int height, int border, uint format, uint type, byte[] pixels);

        /// <summary>
        /// This function sets the image for the currently binded texture.
        /// </summary>
        /// <param name="target">The type of texture, TEXTURE_2D or PROXY_TEXTURE_2D.</param>
        /// <param name="level">For mip-map textures, ordinary textures should be '0'.</param>
        /// <param name="internalformat">The format of the data you are want OpenGL to create, e.g  RGB16.</param>
        /// <param name="width">The width of the texture image (must be a power of 2, e.g 64).</param>
        /// <param name="height">The height of the texture image (must be a power of 2, e.g 32).</param>
        /// <param name="border">The width of the border (0 or 1).</param>
        /// <param name="format">The format of the data you are passing, e.g. RGBA.</param>
        /// <param name="type">The type of data you are passing, e.g GL_BYTE.</param>
        /// <param name="pixels">The actual pixel data.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexImage2D(uint target, int level, uint internalformat, int width, int height, int border, uint format, uint type, IntPtr pixels);

        /// <summary>
        ///	This function sets the parameters for the currently binded texture object.
        /// </summary>
        /// <param name="target">The type of texture you are setting the parameter to, e.g. TEXTURE_2D</param>
        /// <param name="pname">The parameter to set.</param>
        /// <param name="param">The value to set it to.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexParameterf(uint target, uint pname, float param);

        /// <summary>
        ///	This function sets the parameters for the currently binded texture object.
        /// </summary>
        /// <param name="target">The type of texture you are setting the parameter to, e.g. TEXTURE_2D</param>
        /// <param name="pname">The parameter to set.</param>
        /// <param name="parameters">The value to set it to.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexParameterfv(uint target, uint pname, float[] params_notkeyword);

        /// <summary>
        ///	This function sets the parameters for the currently binded texture object.
        /// </summary>
        /// <param name="target">The type of texture you are setting the parameter to, e.g. TEXTURE_2D</param>
        /// <param name="pname">The parameter to set.</param>
        /// <param name="param">The value to set it to.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexParameteri(uint target, uint pname, int param);

        /// <summary>
        ///	This function sets the parameters for the currently binded texture object.
        /// </summary>
        /// <param name="target">The type of texture you are setting the parameter to, e.g. TEXTURE_2D</param>
        /// <param name="pname">The parameter to set.</param>
        /// <param name="parameters">The value to set it to.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexParameteriv(uint target, uint pname, int[] params_notkeyword);

        /// <summary>
        /// Specify a two-dimensional texture subimage.
        /// </summary>
        /// <param name="target">Specifies the target texture. Must be OpenGL.TEXTURE_1D.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xoffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel	data.</param>
        /// <param name="pixels">Specifies a pointer to the image data in memory.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexSubImage1D(uint target, int level, int xoffset, int width, uint format, uint type, int[] pixels);

        /// <summary>
        /// Specify a two-dimensional texture subimage.
        /// </summary>
        /// <param name="target">Specifies the target texture. Must be OpenGL.TEXTURE_1D.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xoffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yoffset">Specifies a texel offset in the y direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="height">Specifies the height of the texture subimage.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel	data.</param>
        /// <param name="pixels">Specifies a pointer to the image data in memory.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTexSubImage2D(uint target, int level, int xoffset, int yoffset, int width, int height, uint format, uint type, int[] pixels);

        /// <summary>
        /// This function applies a translation transformation to the current matrix.
        /// </summary>
        /// <param name="x">The amount to translate along the x axis.</param>
        /// <param name="y">The amount to translate along the y axis.</param>
        /// <param name="z">The amount to translate along the z axis.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTranslated(double x, double y, double z);

        /// <summary>
        /// This function applies a translation transformation to the current matrix.
        /// </summary>
        /// <param name="x">The amount to translate along the x axis.</param>
        /// <param name="y">The amount to translate along the y axis.</param>
        /// <param name="z">The amount to translate along the z axis.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glTranslatef(float x, float y, float z);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertex2d(double x, double y);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertex2dv(double[] v);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertex2f(float x, float y);

        /// <summary>
        /// Sets the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">An array of 2, 3 or 4 floats.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertex2fv(float[] v);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertex2i(int x, int y);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertex2iv(int[] v);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertex2s(short x, short y);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertex2sv(short[] v);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertex3d(double x, double y, double z);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertex3dv(double[] v);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertex3f(float x, float y, float z);

        /// <summary>
        /// Sets the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">An array of 2, 3 or 4 floats.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertex3fv(float[] v);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertex3i(int x, int y, int z);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertex3iv(int[] v);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertex3s(short x, short y, short z);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertex3sv(short[] v);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        /// <param name="w">W Value.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertex4d(double x, double y, double z, double w);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertex4dv(double[] v);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        /// <param name="w">W Value.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertex4f(float x, float y, float z, float w);

        /// <summary>
        /// Sets the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">An array of 2, 3 or 4 floats.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertex4fv(float[] v);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        /// <param name="w">W Value.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertex4i(int x, int y, int z, int w);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertex4iv(int[] v);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        /// <param name="w">W Value.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertex4s(short x, short y, short z, short w);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertex4sv(short[] v);

        /// <summary>
        /// This function sets the address of the vertex pointer array.
        /// </summary>
        /// <param name="size">The number of coords per vertex.</param>
        /// <param name="type">The data type.</param>
        /// <param name="stride">The byte offset between vertices.</param>
        /// <param name="pointer">The array.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertexPointer(int size, uint type, int stride, IntPtr pointer);

        /// <summary>
        /// This function sets the address of the vertex pointer array.
        /// </summary>
        /// <param name="size">The number of coords per vertex.</param>
        /// <param name="stride">The byte offset between vertices.</param>
        /// <param name="pointer">The array.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertexPointer(int size, uint type, int stride, short[] pointer);

        /// <summary>
        /// This function sets the address of the vertex pointer array.
        /// </summary>
        /// <param name="size">The number of coords per vertex.</param>
        /// <param name="stride">The byte offset between vertices.</param>
        /// <param name="pointer">The array.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertexPointer(int size, uint type, int stride, int[] pointer);

        /// <summary>
        /// This function sets the address of the vertex pointer array.
        /// </summary>
        /// <param name="size">The number of coords per vertex.</param>
        /// <param name="stride">The byte offset between vertices.</param>
        /// <param name="pointer">The array.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertexPointer(int size, uint type, int stride, float[] pointer);

        /// <summary>
        /// This function sets the address of the vertex pointer array.
        /// </summary>
        /// <param name="size">The number of coords per vertex.</param>
        /// <param name="stride">The byte offset between vertices.</param>
        /// <param name="pointer">The array.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glVertexPointer(int size, uint type, int stride, double[] pointer);

        /// <summary>
        /// This sets the viewport of the current Render Context. Normally x and y are 0
        /// and the width and height are just those of the control/graphics you are drawing
        /// to.
        /// </summary>
        /// <param name="x">Top-Left point of the viewport.</param>
        /// <param name="y">Top-Left point of the viewport.</param>
        /// <param name="width">Width of the viewport.</param>
        /// <param name="height">Height of the viewport.</param>
        [DllImport(Win32.OpenGL32, SetLastError = true)]
        public static extern void glViewport(int x, int y, int width, int height);

        #endregion

    }
}
