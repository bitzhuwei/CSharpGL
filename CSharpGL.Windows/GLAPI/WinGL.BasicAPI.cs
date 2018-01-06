using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public partial class WinGL
    {

        #region The GL DLL Functions.

        /// <summary>
        /// Set the Accumulation Buffer operation.
        /// </summary>
        /// <param name="op">Operation of the buffer.</param>
        /// <param name="value">Reference value.</param>
        public override void Accum(uint op, float value) { glAccum(op, value); }

        /// <summary>
        /// Specify the Alpha Test function.
        /// </summary>
        /// <param name="func">Specifies the alpha comparison function. Symbolic constants GL.NEVER, GL.LESS, GL.EQUAL, GL.LEQUAL, GL.GREATER, GL.NOTEQUAL, GL.GEQUAL and GL.ALWAYS are accepted. The initial value is GL.ALWAYS.</param>
        /// <param name="ref_notkeword">Specifies the reference	value that incoming alpha values are compared to. This value is clamped to the range 0	through	1, where 0 represents the lowest possible alpha value and 1 the highest possible value. The initial reference value is 0.</param>
        public override void AlphaFunc(uint func, float ref_notkeword) { glAlphaFunc(func, ref_notkeword); }

        /// <summary>
        /// Determine if textures are loaded in texture memory.
        /// </summary>
        /// <param name="n">Specifies the number of textures to be queried.</param>
        /// <param name="textures">Specifies an array containing the names of the textures to be queried.</param>
        /// <param name="residences">Specifies an array in which the texture residence status is returned. The residence status of a texture named by an element of textures is returned in the corresponding element of residences.</param>
        /// <returns></returns>
        public override byte AreTexturesResident(int n, uint[] textures, byte[] residences) { return glAreTexturesResident(n, textures, residences); }

        /// <summary>
        /// Render a vertex using the specified vertex array element.
        /// </summary>
        /// <param name="i">Specifies an index	into the enabled vertex	data arrays.</param>
        public override void ArrayElement(int i) { glArrayElement(i); }

        /// <summary>
        ///
        /// </summary>
        /// <param name="mode"></param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Begin(uint mode) { glBegin(mode); }

        /// <summary>
        /// Call this function after creating a texture to finalise creation of it,
        /// or to make an existing texture current.
        /// </summary>
        /// <param name="target">The target type, e.g TEXTURE_2D.</param>
        /// <param name="texture">The GL texture object.</param>
        public override void BindTexture(uint target, uint texture) { glBindTexture(target, texture); }

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
        public override void Bitmap(int width, int height, float xorig, float yorig, float xmove, float ymove, byte[] bitmap) { glBitmap(width, height, xorig, yorig, xmove, ymove, bitmap); }

        /// <summary>
        /// This function sets the current blending function.
        /// </summary>
        /// <param name="sfactor">Source factor.</param>
        /// <param name="dfactor">Destination factor.</param>
        public override void BlendFunc(uint sfactor, uint dfactor) { glBlendFunc(sfactor, dfactor); }

        /// <summary>
        /// This function calls a certain display list.
        /// </summary>
        /// <param name="list">The display list to call.</param>
        public override void CallList(uint list) { glCallList(list); }

        /// <summary>
        /// Execute	a list of display lists.
        /// </summary>
        /// <param name="n">Specifies the number of display lists to be executed.</param>
        /// <param name="type">Specifies the type of values in lists. Symbolic constants GL.BYTE, GL.UNSIGNED_BYTE, GL.SHORT, GL.UNSIGNED_SHORT, GL.INT, GL.UNSIGNED_INT, GL.FLOAT, GL.2_BYTES, GL.3_BYTES and GL.4_BYTES are accepted.</param>
        /// <param name="lists">Specifies the address of an array of name offsets in the display list. The pointer type is void because the offsets can be bytes, shorts, ints, or floats, depending on the value of type.</param>
        public override void CallLists(int n, uint type, IntPtr lists) { glCallLists(n, type, lists); }

        /// <summary>
        /// Execute	a list of display lists. Automatically uses the GL_UNSIGNED_INT version of the function.
        /// </summary>
        /// <param name="n">The number of lists.</param>
        /// <param name="type"></param>
        /// <param name="lists">The lists.</param>
        public override void CallLists(int n, uint type, uint[] lists) { glCallLists(n, type, lists); }

        /// <summary>
        /// Execute	a list of display lists. Automatically uses the GL_UNSIGNED_BYTE version of the function.
        /// </summary>
        /// <param name="n">The number of lists.</param>
        /// <param name="type"></param>
        /// <param name="lists">The lists.</param>
        public override void CallLists(int n, uint type, byte[] lists) { glCallLists(n, type, lists); }

        /// <summary>
        /// This function clears the buffers specified by mask.
        /// </summary>
        /// <param name="mask">Which buffers to clear.</param>
        public override void Clear(uint mask) { glClear(mask); }

        /// <summary>
        /// Specify clear values for the accumulation buffer.
        /// </summary>
        /// <param name="red">Specify the red, green, blue and alpha values used when the accumulation buffer is cleared. The initial values are all 0.</param>
        /// <param name="green">Specify the red, green, blue and alpha values used when the accumulation buffer is cleared. The initial values are all 0.</param>
        /// <param name="blue">Specify the red, green, blue and alpha values used when the accumulation buffer is cleared. The initial values are all 0.</param>
        /// <param name="alpha">Specify the red, green, blue and alpha values used when the accumulation buffer is cleared. The initial values are all 0.</param>
        public override void ClearAccum(float red, float green, float blue, float alpha) { glClearAccum(red, green, blue, alpha); }

        /// <summary>
        /// This function sets the color that the drawing buffer is 'cleared' to.
        /// </summary>
        /// <param name="red">Red component of the color (between 0 and 1).</param>
        /// <param name="green">Green component of the color (between 0 and 1).</param>
        /// <param name="blue">Blue component of the color (between 0 and 1)./</param>
        /// <param name="alpha">Alpha component of the color (between 0 and 1).</param>
        public override void ClearColor(float red, float green, float blue, float alpha) { glClearColor(red, green, blue, alpha); }

        /// <summary>
        /// Specify the clear value for the depth buffer.
        /// </summary>
        /// <param name="depth">Specifies the depth value used	when the depth buffer is cleared. The initial value is 1.</param>
        public override void ClearDepth(double depth) { glClearDepth(depth); }

        /// <summary>
        /// Specify the clear value for the color index buffers.
        /// </summary>
        /// <param name="c">Specifies the index used when the color index buffers are cleared. The initial value is 0.</param>
        public override void ClearIndex(float c) { glClearIndex(c); }

        /// <summary>
        /// Specify the clear value for the stencil buffer.
        /// </summary>
        /// <param name="s">Specifies the index used when the stencil buffer is cleared. The initial value is 0.</param>
        public override void ClearStencil(int s) { glClearStencil(s); }

        /// <summary>
        /// Specify a plane against which all geometry is clipped.
        /// <para>https://www.GL.org/sdk/docs/man2/xhtml/glClipPlane.xml</para>
        /// </summary>
        /// <param name="plane">Specifies which clipping plane is being positioned. Symbolic names of the form GL.CLIP_PLANEi, where i is an integer between 0 and GL.MAX_CLIP_PLANES -1, are accepted.</param>
        /// <param name="equation">Specifies the address of an	array of four double-precision floating-point values. These values are interpreted as a plane equation.</param>
        public override void ClipPlane(uint plane, double[] equation) { glClipPlane(plane, equation); }

        /// <summary>
        ///
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        public override void Color3b(byte red, byte green, byte blue) { glColor3b(red, green, blue); }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 byte values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color3bv(byte[] v) { glColor3bv(v); }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color3d(double red, double green, double blue) { glColor3d(red, green, blue); }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 double values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color3dv(double[] v) { glColor3dv(v); }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color3f(float red, float green, float blue) { glColor3f(red, green, blue); }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 float values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color3fv(float[] v) { glColor3fv(v); }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color3i(int red, int green, int blue) { glColor3i(red, green, blue); }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 int values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color3iv(int[] v) { glColor3iv(v); }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color3s(short red, short green, short blue) { glColor3s(red, green, blue); }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 int values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color3sv(short[] v) { glColor3sv(v); }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 255).</param>
        /// <param name="green">Green color component (between 0 and 255).</param>
        /// <param name="blue">Blue color component (between 0 and 255).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color3ub(byte red, byte green, byte blue) { glColor3ub(red, green, blue); }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 int values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color3ubv(byte[] v) { glColor3ubv(v); }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color3ui(uint red, uint green, uint blue) { glColor3ui(red, green, blue); }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 unsigned int values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color3uiv(uint[] v) { glColor3uiv(v); }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color3us(ushort red, ushort green, ushort blue) { glColor3us(red, green, blue); }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 unsigned short values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color3usv(ushort[] v) { glColor3usv(v); }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 255).</param>
        /// <param name="green">Green color component (between 0 and 255).</param>
        /// <param name="blue">Blue color component (between 0 and 255).</param>
        /// <param name="alpha">Alpha color component (between 0 and 255).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color4b(byte red, byte green, byte blue, byte alpha) { glColor4b(red, green, blue, alpha); }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 byte values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color4bv(byte[] v) { glColor4bv(v); }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component (between 0 and 255).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color4d(double red, double green, double blue, double alpha) { glColor4d(red, green, blue, alpha); }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 double values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color4dv(double[] v) { glColor4dv(v); }

        ///<summary>
        ///Sets the current color.
        ///</summary>
        ///<param name="red">Red color component (between 0 and 1).</param>
        ///<param name="green">Green color component (between 0 and 1).</param>
        ///<param name="blue">Blue color component (between 0 and 1).</param>
        ///<param name="alpha">Alpha color component (between 0 and 1).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color4f(float red, float green, float blue, float alpha) { glColor4f(red, green, blue, alpha); }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 float values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color4fv(float[] v) { glColor4fv(v); }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color4i(int red, int green, int blue, int alpha) { glColor4i(red, green, blue, alpha); }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 int values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color4iv(int[] v) { glColor4iv(v); }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color4s(short red, short green, short blue, short alpha) { glColor4s(red, green, blue, alpha); }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 int values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color4sv(short[] v) { glColor4sv(v); }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 255).</param>
        /// <param name="green">Green color component (between 0 and 255).</param>
        /// <param name="blue">Blue color component (between 0 and 255).</param>
        /// <param name="alpha">Alpha color component (between 0 and 255).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color4ub(byte red, byte green, byte blue, byte alpha) { glColor4ub(red, green, blue, alpha); }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 int values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color4ubv(byte[] v) { glColor4ubv(v); }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color4ui(uint red, uint green, uint blue, uint alpha) { glColor4ui(red, green, blue, alpha); }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 unsigned int values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color4uiv(uint[] v) { glColor4uiv(v); }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color4us(ushort red, ushort green, ushort blue, ushort alpha) { glColor4us(red, green, blue, alpha); }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 unsigned short values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Color4usv(ushort[] v) { glColor4usv(v); }

        /// <summary>
        /// enable and disable writing of frame buffer color components.
        /// <para>Specify whether red, green, blue, and alpha can or cannot be written into the frame buffer. The initial values are all GL_TRUE, indicating that the color components can be written.</para>
        /// <para>glGet with argument GL_COLOR_WRITEMASK.</para>
        /// </summary>
        /// <param name="redWritable">Red component mask.</param>
        /// <param name="greenWritable">Green component mask.</param>
        /// <param name="blueWritable">Blue component mask.</param>
        /// <param name="alphaWritable">Alpha component mask.</param>
        public override void ColorMask(bool redWritable, bool greenWritable, bool blueWritable, bool alphaWritable) { glColorMask(redWritable, greenWritable, blueWritable, alphaWritable); }

        /// <summary>
        /// Cause a material color to track the current color.
        /// </summary>
        /// <param name="face">Specifies whether front, back, or both front and back material parameters should track the current color. Accepted values are GL.FRONT, GL.BACK, and GL.FRONT_AND_BACK. The initial value is GL.FRONT_AND_BACK.</param>
        /// <param name="mode">Specifies which	of several material parameters track the current color. Accepted values are	GL.EMISSION, GL.AMBIENT, GL.DIFFUSE, GL.SPECULAR and GL.AMBIENT_AND_DIFFUSE. The initial value is GL.AMBIENT_AND_DIFFUSE.</param>
        public override void ColorMaterial(uint face, uint mode) { glColorMaterial(face, mode); }

        /// <summary>
        /// Define an array of colors.
        /// </summary>
        /// <param name="size">Specifies the number	of components per color. Must be 3	or 4.</param>
        /// <param name="type">Specifies the data type of each color component in the array. Symbolic constants GL.BYTE, GL.UNSIGNED_BYTE, GL.SHORT, GL.UNSIGNED_SHORT, GL.INT, GL.UNSIGNED_INT, GL.FLOAT and GL.DOUBLE are accepted.</param>
        /// <param name="stride">Specifies the byte offset between consecutive colors. If stride is 0, (the initial value), the colors are understood to be tightly packed in the array.</param>
        /// <param name="pointer">Specifies a pointer to the first component of the first color element in the array.</param>
        public override void ColorPointer(int size, uint type, int stride, IntPtr pointer) { glColorPointer(size, type, stride, pointer); }

        /// <summary>
        /// Copy pixels in	the frame buffer.
        /// </summary>
        /// <param name="x">Specify the window coordinates of the lower left corner of the rectangular region of pixels to be copied.</param>
        /// <param name="y">Specify the window coordinates of the lower left corner of the rectangular region of pixels to be copied.</param>
        /// <param name="width">Specify the dimensions of the rectangular region of pixels to be copied. Both must be nonnegative.</param>
        /// <param name="height">Specify the dimensions of the rectangular region of pixels to be copied. Both must be nonnegative.</param>
        /// <param name="type">Specifies whether color values, depth values, or stencil values are to be copied. Symbolic constants GL.COLOR, GL.DEPTH, and GL.STENCIL are accepted.</param>
        public override void CopyPixels(int x, int y, int width, int height, uint type) { glCopyPixels(x, y, width, height, type); }

        /// <summary>
        /// Copy pixels into a 1D texture image.
        /// </summary>
        /// <param name="target">Specifies the target texture. Must be GL.TEXTURE_1D.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="internalFormat">Specifies the internal format of the texture.</param>
        /// <param name="x">Specify the window coordinates of the left corner of the row of pixels to be copied.</param>
        /// <param name="y">Specify the window coordinates of the left corner of the row of pixels to be copied.</param>
        /// <param name="width">Specifies the width of the texture image. Must be 0 or 2^n = (2 * border) for some integer n. The height of the texture image is 1.</param>
        /// <param name="border">Specifies the width of the border. Must be either 0 or 1.</param>
        public override void CopyTexImage1D(uint target, int level, uint internalFormat, int x, int y, int width, int border) { glCopyTexImage1D(target, level, internalFormat, x, y, width, border); }

        /// <summary>
        /// Copy pixels into a	2D texture image.
        /// </summary>
        /// <param name="target">Specifies the target texture. Must be GL.TEXTURE_2D.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="internalFormat">Specifies the internal format of the texture.</param>
        /// <param name="x">Specify the window coordinates of the left corner of the row of pixels to be copied.</param>
        /// <param name="y">Specify the window coordinates of the left corner of the row of pixels to be copied.</param>
        /// <param name="width">Specifies the width of the texture image.</param>
        /// <param name="height">Specifies the height of the texture image.</param>
        /// <param name="border">Specifies the width of the border. Must be either 0 or 1.</param>
        public override void CopyTexImage2D(uint target, int level, uint internalFormat, int x, int y, int width, int height, int border) { glCopyTexImage2D(target, level, internalFormat, x, y, width, height, border); }

        /// <summary>
        /// Copy a one-dimensional texture subimage.
        /// </summary>
        /// <param name="target">Specifies the target texture. Must be GL.TEXTURE_1D.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xoffset">Specifies the texel offset within the texture array.</param>
        /// <param name="x">Specify the window coordinates of the left corner of the row of pixels to be copied.</param>
        /// <param name="y">Specify the window coordinates of the left corner of the row of pixels to be copied.</param>
        /// <param name="width">Specifies the width of the texture image.</param>
        public override void CopyTexSubImage1D(uint target, int level, int xoffset, int x, int y, int width) { glCopyTexSubImage1D(target, level, xoffset, x, y, width); }

        /// <summary>
        /// Copy a two-dimensional texture subimage.
        /// </summary>
        /// <param name="target">Specifies the target texture. Must be GL.TEXTURE_2D.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xoffset">Specifies the texel offset within the texture array.</param>
        /// <param name="yoffset">Specifies the texel offset within the texture array.</param>
        /// <param name="x">Specify the window coordinates of the left corner of the row of pixels to be copied.</param>
        /// <param name="y">Specify the window coordinates of the left corner of the row of pixels to be copied.</param>
        /// <param name="width">Specifies the width of the texture image.</param>
        /// <param name="height">Specifies the height of the texture image.</param>
        public override void CopyTexSubImage2D(uint target, int level, int xoffset, int yoffset, int x, int y, int width, int height) { glCopyTexSubImage2D(target, level, xoffset, yoffset, x, y, width, height); }

        /// <summary>
        /// Specify whether front- or back-facing facets can be culled.
        /// </summary>
        /// <param name="mode">Specifies whether front- or back-facing facets are candidates for culling. Symbolic constants GL.FRONT, GL.BACK, and GL.FRONT_AND_BACK are accepted. The initial	value is GL.BACK.</param>
        public override void CullFace(uint mode) { glCullFace(mode); }

        /// <summary>
        /// This function deletes a list, or a range of lists.
        /// </summary>
        /// <param name="list">The list to delete.</param>
        /// <param name="range">The range of lists (often just 1).</param>
        public override void DeleteLists(uint list, int range) { glDeleteLists(list, range); }

        /// <summary>
        /// This function deletes a set of Texture objects.
        /// </summary>
        /// <param name="n">Number of textures to delete.</param>
        /// <param name="textures">The array containing the names of the textures to delete.</param>
        public override void DeleteTextures(int n, uint[] textures) { glDeleteTextures(n, textures); }

        /// <summary>
        /// This function sets the current depth buffer comparison function, the default it LESS.
        /// </summary>
        /// <param name="func">The comparison function to set.</param>
        public override void DepthFunc(uint func) { glDepthFunc(func); }

        /// <summary>
        /// enable or disable writing into the depth buffer
        /// <para>允许或禁止向深度缓冲区写入数据</para>
        /// <para>glGet with argument GL_DEPTH_WRITEMASK</para>
        /// </summary>
        /// <param name="writable">Specifies whether the depth buffer is enabled for writing.If flag is GL_FALSE,depth buffer writing is disabled.Otherwise, it is enabled.Initially, depth buffer writing is enabled.
        /// <para>指定是否允许向深度缓冲区写入数据。如果flag是GL_FLASE，那么向深度缓冲区写入是禁止的。否则，就是允许的。初始时，是允许向深度缓冲区写入数据的。</para></param>
        public override void DepthMask(bool writable) { glDepthMask(writable); }

        /// <summary>
        /// Specify mapping of depth values from normalized device coordinates	to window coordinates.
        /// </summary>
        /// <param name="zNear">Specifies the mapping of the near clipping plane to window coordinates. The initial value is 0.</param>
        /// <param name="zFar">Specifies the mapping of the near clipping plane to window coordinates. The initial value is 1.</param>
        public override void DepthRange(double zNear, double zFar) { glDepthRange(zNear, zFar); }

        /// <summary>
        /// Call this function to disable an GL capability.
        /// </summary>
        /// <param name="cap">The capability to disable.</param>
        public override void Disable(uint cap) { glDisable(cap); }

        /// <summary>
        /// This function disables a client state array, such as a vertex array.
        /// </summary>
        /// <param name="array">The array to disable.</param>
        public override void DisableClientState(uint array) { glDisableClientState(array); }

        /// <summary>
        /// Render	primitives from	array data.
        /// </summary>
        /// <param name="mode">Specifies what kind of primitives to render. Symbolic constants GL.POINTS, GL.LINE_STRIP, GL.LINE_LOOP, GL.LINES, GL.TRIANGLE_STRIP, GL.TRIANGLE_FAN, GL.TRIANGLES, GL.QUAD_STRIP, GL.QUADS, and GL.POLYGON are accepted.</param>
        /// <param name="first">Specifies the starting	index in the enabled arrays.</param>
        /// <param name="count">Specifies the number of vertexes to be rendered.</param>
        public override void DrawArrays(uint mode, int first, int count) { glDrawArrays(mode, first, count); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="first"></param>
        /// <param name="count"></param>
        /// <param name="drawcount"></param>
        public override void MultiDrawArrays(uint mode, int[] first, int[] count, int drawcount) { glMultiDrawArrays(mode, first, count, drawcount); }

        /// <summary>
        /// Specify which color buffers are to be drawn into.
        /// </summary>
        /// <param name="mode">Specifies up to	four color buffers to be drawn into. Symbolic constants GL.NONE, GL.FRONT_LEFT, GL.FRONT_RIGHT,	GL.BACK_LEFT, GL.BACK_RIGHT, GL.FRONT, GL.BACK, GL.LEFT, GL.RIGHT, GL.FRONT_AND_BACK, and GL.AUXi, where i is between 0 and (GL.AUX_BUFFERS - 1), are accepted (GL.AUX_BUFFERS is not the upper limit{} use glGet to query the number of	available aux buffers.)  The initial value is GL.FRONT for single- buffered contexts, and GL.BACK for double-buffered contexts.</param>
        public override void DrawBuffer(uint mode) { glDrawBuffer(mode); }

        /// <summary>
        /// Render primitives from array data.
        /// </summary>
        /// <param name="mode">Specifies what kind of primitives to	render. Symbolic constants GL.POINTS, GL.LINE_STRIP, GL.LINE_LOOP, GL.LINES, GL.TRIANGLE_STRIP, GL.TRIANGLE_FAN, GL.TRIANGLES, GL.QUAD_STRIP, GL.QUADS, and GL.POLYGON are accepted.</param>
        /// <param name="count">Specifies the number of elements to be rendered.</param>
        /// <param name="type">Specifies the type of the values in indices.	Must be one of GL.UNSIGNED_BYTE, GL.UNSIGNED_SHORT, or GL.UNSIGNED_INT.</param>
        /// <param name="indices">Specifies a pointer to the location where the indices are stored.</param>
        public override void DrawElements(uint mode, int count, uint type, IntPtr indices) { glDrawElements(mode, count, type, indices); }

        /// <summary>
        /// Render primitives from array data.
        /// </summary>
        /// <param name="mode">Specifies what kind of primitives to	render. Symbolic constants GL.POINTS, GL.LINE_STRIP, GL.LINE_LOOP, GL.LINES, GL.TRIANGLE_STRIP, GL.TRIANGLE_FAN, GL.TRIANGLES, GL.QUAD_STRIP, GL.QUADS, and GL.POLYGON are accepted.</param>
        /// <param name="count">Specifies the number of elements to be rendered.</param>
        /// <param name="type"></param>
        /// <param name="indices">Specifies a pointer to the location where the indices are stored.</param>
        public override void DrawElements(uint mode, int count, uint[] indices) { glDrawElements(mode, count, GL.GL_UNSIGNED_INT, indices); }

        /// <summary>
        /// Render primitives from array data.
        /// </summary>
        /// <param name="mode">Specifies what kind of primitives to	render. Symbolic constants GL.POINTS, GL.LINE_STRIP, GL.LINE_LOOP, GL.LINES, GL.TRIANGLE_STRIP, GL.TRIANGLE_FAN, GL.TRIANGLES, GL.QUAD_STRIP, GL.QUADS, and GL.POLYGON are accepted.</param>
        /// <param name="count">Specifies the number of elements to be rendered.</param>
        /// <param name="type"></param>
        /// <param name="indices">Specifies a pointer to the location where the indices are stored.</param>
        public override void DrawElements(uint mode, int count, ushort[] indices) { glDrawElements(mode, count, GL.GL_UNSIGNED_SHORT, indices); }

        /// <summary>
        /// Render primitives from array data.
        /// </summary>
        /// <param name="mode">Specifies what kind of primitives to	render. Symbolic constants GL.POINTS, GL.LINE_STRIP, GL.LINE_LOOP, GL.LINES, GL.TRIANGLE_STRIP, GL.TRIANGLE_FAN, GL.TRIANGLES, GL.QUAD_STRIP, GL.QUADS, and GL.POLYGON are accepted.</param>
        /// <param name="count">Specifies the number of elements to be rendered.</param>
        /// <param name="type"></param>
        /// <param name="indices">Specifies a pointer to the location where the indices are stored.</param>
        public override void DrawElements(uint mode, int count, byte[] indices) { glDrawElements(mode, count, GL.GL_UNSIGNED_BYTE, indices); }

        /// <summary>
        /// Draws a rectangle of pixel data at the current raster position.
        /// </summary>
        /// <param name="width">Width of pixel data.</param>
        /// <param name="height">Height of pixel data.</param>
        /// <param name="format">Format of pixel data.</param>
        /// <param name="type"></param>
        /// <param name="pixels">Pixel data buffer.</param>
        public override void DrawPixels(int width, int height, uint format, uint type, float[] pixels) { glDrawPixels(width, height, format, type, pixels); }

        /// <summary>
        /// Draws a rectangle of pixel data at the current raster position.
        /// </summary>
        /// <param name="width">Width of pixel data.</param>
        /// <param name="height">Height of pixel data.</param>
        /// <param name="format">Format of pixel data.</param>
        /// <param name="type"></param>
        /// <param name="pixels">Pixel data buffer.</param>
        public override void DrawPixels(int width, int height, uint format, uint type, uint[] pixels) { glDrawPixels(width, height, format, type, pixels); }

        /// <summary>
        /// Draws a rectangle of pixel data at the current raster position.
        /// </summary>
        /// <param name="width">Width of pixel data.</param>
        /// <param name="height">Height of pixel data.</param>
        /// <param name="format">Format of pixel data.</param>
        /// <param name="type"></param>
        /// <param name="pixels">Pixel data buffer.</param>
        public override void DrawPixels(int width, int height, uint format, uint type, ushort[] pixels) { glDrawPixels(width, height, format, type, pixels); }

        /// <summary>
        /// Draws a rectangle of pixel data at the current raster position.
        /// </summary>
        /// <param name="width">Width of pixel data.</param>
        /// <param name="height">Height of pixel data.</param>
        /// <param name="format">Format of pixel data.</param>
        /// <param name="type"></param>
        /// <param name="pixels">Pixel data buffer.</param>
        public override void DrawPixels(int width, int height, uint format, uint type, byte[] pixels) { glDrawPixels(width, height, format, type, pixels); }

        /// <summary>
        /// Draws a rectangle of pixel data at the current raster position.
        /// </summary>
        /// <param name="width">Width of pixel data.</param>
        /// <param name="height">Height of pixel data.</param>
        /// <param name="format">Format of pixel data.</param>
        /// <param name="type">The GL data type.</param>
        /// <param name="pixels">Pixel data buffer.</param>
        public override void DrawPixels(int width, int height, uint format, uint type, IntPtr pixels) { glDrawPixels(width, height, format, type, pixels); }

        /// <summary>
        /// Flag edges as either boundary or nonboundary.
        /// </summary>
        /// <param name="flag">Specifies the current edge flag	value, either GL.TRUE or GL.FALSE. The initial value is GL.TRUE.</param>
        public override void EdgeFlag(byte flag) { glEdgeFlag(flag); }

        /// <summary>
        /// Define an array of edge flags.
        /// </summary>
        /// <param name="stride">Specifies the byte offset between consecutive edge flags. If stride is	0 (the initial value), the edge	flags are understood to	be tightly packed in the array.</param>
        /// <param name="pointer">Specifies a pointer to the first edge flag in the array.</param>
        public override void EdgeFlagPointer(int stride, int[] pointer) { glEdgeFlagPointer(stride, pointer); }

        /// <summary>
        /// Flag edges as either boundary or nonboundary.
        /// </summary>
        /// <param name="flag">Specifies a pointer to an array that contains a single boolean element,	which replaces the current edge	flag value.</param>
        public override void EdgeFlagv(byte[] flag) { glEdgeFlagv(flag); }

        /// <summary>
        /// Call this function to enable an GL capability.
        /// </summary>
        /// <param name="cap">The capability you wish to enable.</param>
        public override void Enable(uint cap) { glEnable(cap); }

        /// <summary>
        /// This function enables one of the client state arrays, such as a vertex array.
        /// </summary>
        /// <param name="array">The array to enable.</param>
        public override void EnableClientState(uint array) { glEnableClientState(array); }

        /// <summary>
        ///
        /// </summary>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void End() { glEnd(); }

        /// <summary>
        /// Ends the current display list compilation.
        /// </summary>
        public override void EndList() { glEndList(); }

        /// <summary>
        /// Evaluate from the current evaluator.
        /// <para>Calls glVertex() inside.</para>
        /// </summary>
        /// <param name="u">Domain coordinate.</param>

        public override void EvalCoord1d(double u) { glEvalCoord1d(u); }

        /// <summary>
        /// Evaluate from the current evaluator.
        /// <para>Calls glVertex() inside.</para>
        /// </summary>
        /// <param name="u">Domain coordinate.</param>
        public override void EvalCoord1dv(double[] u) { glEvalCoord1dv(u); }

        /// <summary>
        /// Evaluate from the current evaluator.
        /// <para>Calls glVertex() inside.</para>
        /// </summary>
        /// <param name="u">Domain coordinate.</param>
        public override void EvalCoord1f(float u) { glEvalCoord1f(u); }

        /// <summary>
        /// Evaluate from the current evaluator.
        /// <para>Calls glVertex() inside.</para>
        /// </summary>
        /// <param name="u">Domain coordinate.</param>
        public override void EvalCoord1fv(float[] u) { glEvalCoord1fv(u); }

        /// <summary>
        /// Evaluate from the current evaluator.
        /// <para>Calls glVertex() inside.</para>
        /// </summary>
        /// <param name="u">Domain coordinate.</param>
        /// <param name="v">Domain coordinate.</param>
        public override void EvalCoord2d(double u, double v) { glEvalCoord2d(u, v); }

        /// <summary>
        /// Evaluate from the current evaluator.
        /// <para>Calls glVertex() inside.</para>
        /// </summary>
        /// <param name="u">Domain coordinate.</param>
        public override void EvalCoord2dv(double[] u) { glEvalCoord2dv(u); }

        /// <summary>
        /// Evaluate from the current evaluator.
        /// <para>Calls glVertex() inside.</para>
        /// </summary>
        /// <param name="u">Domain coordinate.</param>
        /// <param name="v">Domain coordinate.</param>
        public override void EvalCoord2f(float u, float v) { glEvalCoord2f(u, v); }

        /// <summary>
        /// Evaluate from the current evaluator.
        /// <para>Calls glVertex() inside.</para>
        /// </summary>
        /// <param name="u">Domain coordinate.</param>
        public override void EvalCoord2fv(float[] u) { glEvalCoord2fv(u); }

        /// <summary>
        /// Evaluates a 'mesh' from the current evaluators.
        /// </summary>
        /// <param name="mode">Drawing mode, can be POINT or LINE.</param>
        /// <param name="i1">Beginning of range.</param>
        /// <param name="i2">End of range.</param>
        public override void EvalMesh1(uint mode, int i1, int i2) { glEvalMesh1(mode, i1, i2); }

        /// <summary>
        /// Evaluates a 'mesh' from the current evaluators.
        /// </summary>
        /// <param name="mode">Drawing mode, fill, point or line.</param>
        /// <param name="i1">Beginning of range.</param>
        /// <param name="i2">End of range.</param>
        /// <param name="j1">Beginning of range.</param>
        /// <param name="j2">End of range.</param>
        public override void EvalMesh2(uint mode, int i1, int i2, int j1, int j2) { glEvalMesh2(mode, i1, i2, j1, j2); }

        /// <summary>
        /// Generate and evaluate a single point in a mesh.
        /// </summary>
        /// <param name="i">The integer value for grid domain variable i.</param>
        public override void EvalPoint1(int i) { glEvalPoint1(i); }

        /// <summary>
        /// Generate and evaluate a single point in a mesh.
        /// </summary>
        /// <param name="i">The integer value for grid domain variable i.</param>
        /// <param name="j">The integer value for grid domain variable j.</param>
        public override void EvalPoint2(int i, int j) { glEvalPoint2(i, j); }

        /// <summary>
        /// This function sets the feedback buffer, that will receive feedback data.
        /// </summary>
        /// <param name="size">Size of the buffer.</param>
        /// <param name="type">Type of data in the buffer.</param>
        /// <param name="buffer">The buffer itself.</param>
        public override void FeedbackBuffer(int size, uint type, float[] buffer) { glFeedbackBuffer(size, type, buffer); }

        /// <summary>
        /// This function is similar to flush, but in a sense does it more, as it
        /// executes all commands aon both the client and the server.
        /// </summary>

        public override void Finish() { glFinish(); }

        /// <summary>
        /// This forces GL to execute any commands you have given it.
        /// </summary>
        public override void Flush() { glFlush(); }

        /// <summary>
        /// Sets a fog parameter.
        /// </summary>
        /// <param name="pname">The parameter to set.</param>
        /// <param name="param">The value to set it to.</param>
        public override void Fogf(uint pname, float param) { glFogf(pname, param); }

        /// <summary>
        /// Sets a fog parameter.
        /// </summary>
        /// <param name="pname">The parameter to set.</param>
        /// <param name="parameters">The values to set it to.</param>
        public override void Fogfv(uint pname, float[] parameters) { glFogfv(pname, parameters); }

        /// <summary>
        /// Sets a fog parameter.
        /// </summary>
        /// <param name="pname">The parameter to set.</param>
        /// <param name="param">The value to set it to.</param>
        public override void Fogi(uint pname, int param) { glFogi(pname, param); }

        /// <summary>
        /// Sets a fog parameter.
        /// </summary>
        /// <param name="pname">The parameter to set.</param>
        /// <param name="parameters">The values to set it to.</param>
        public override void Fogiv(uint pname, int[] parameters) { glFogiv(pname, parameters); }

        /// <summary>
        /// This function sets what defines a front face. Counter ClockWise by default.
        /// <para>作用是控制多边形的正面是如何决定的。在默认情况下，mode是GL_CCW。</para>
        /// </summary>
        /// <param name="mode">Winding mode, counter clockwise by default.
        /// <para>GL_CCW 表示窗口坐标上投影多边形的顶点顺序为逆时针方向的表面为正面。</para>
        /// <para>GL_CW 表示顶点顺序为顺时针方向的表面为正面。</para></param>
        public override void FrontFace(uint mode) { glFrontFace(mode); }

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
        public override void Frustum(double left, double right, double bottom, double top, double zNear, double zFar) { glFrustum(left, right, bottom, top, zNear, zFar); }

        /// <summary>
        /// This function generates 'range' number of contiguos display list indices.
        /// </summary>
        /// <param name="range">The number of lists to generate.</param>
        /// <returns>The first list.</returns>
        public override uint GenLists(int range) { return glGenLists(range); }

        /// <summary>
        /// Create a set of unique texture names.
        /// </summary>
        /// <param name="n">Number of names to create.</param>
        /// <param name="textures">Array to store the texture names.</param>
        public override void GenTextures(int n, uint[] textures) { glGenTextures(n, textures); }

        /// <summary>
        /// This function queries GL for data, and puts it in the buffer supplied.
        /// </summary>
        /// <param name="pname">The parameter to query.</param>
        /// <param name="parameters"></param>
        public override void GetBooleanv(uint pname, byte[] parameters) { glGetBooleanv(pname, parameters); }

        /// <summary>
        /// Return the coefficients of the specified clipping plane.
        /// </summary>
        /// <param name="plane">Specifies a	clipping plane.	 The number of clipping planes depends on the implementation, but at least six clipping planes are supported. They are identified by symbolic names of the form GL.CLIP_PLANEi where 0 Less Than i Less Than GL.MAX_CLIP_PLANES.</param>
        /// <param name="equation">Returns four double-precision values that are the coefficients of the plane equation of plane in eye coordinates. The initial value is (0, 0, 0, 0).</param>
        public override void GetClipPlane(uint plane, double[] equation) { glGetClipPlane(plane, equation); }

        /// <summary>
        /// This function queries GL for data, and puts it in the buffer supplied.
        /// </summary>
        /// <param name="pname">The parameter to query.</param>
        /// <param name="parameters">The buffer to put that data into.</param>
        public override void GetDoublev(uint pname, double[] parameters) { glGetDoublev(pname, parameters); }

        /// <summary>
        /// Get the current GL error code.
        /// </summary>
        /// <returns>The current GL error code.</returns>
        public override uint GetError() { return glGetError(); }

        /// <summary>
        /// This this function to query GL values.
        /// </summary>
        /// <param name="pname">The parameter to query.</param>
        /// <param name="parameters">The parameters</param>
        public override void GetFloatv(uint pname, float[] parameters) { glGetFloatv(pname, parameters); }

        /// <summary>
        /// Use this function to query GL parameter values.
        /// </summary>
        /// <param name="pname">The Parameter to query</param>
        /// <param name="parameters">An array to put the values into.</param>
        public override void GetIntegerv(uint pname, int[] parameters) { glGetIntegerv(pname, parameters); }

        /// <summary>
        /// Return light source parameter values.
        /// </summary>
        /// <param name="light">Specifies a light source. The number of possible lights depends on the implementation, but at least eight lights are supported. They are identified by symbolic names of the form GL.LIGHTi where i ranges from 0 to the value of GL.GL_MAX_LIGHTS - 1.</param>
        /// <param name="pname">Specifies a light source parameter for light.</param>
        /// <param name="parameters">Returns the requested data.</param>
        public override void GetLightfv(uint light, uint pname, float[] parameters) { glGetLightfv(light, pname, parameters); }

        /// <summary>
        /// Return light source parameter values.
        /// </summary>
        /// <param name="light">Specifies a light source. The number of possible lights depends on the implementation, but at least eight lights are supported. They are identified by symbolic names of the form GL.LIGHTi where i ranges from 0 to the value of GL.GL_MAX_LIGHTS - 1.</param>
        /// <param name="pname">Specifies a light source parameter for light.</param>
        /// <param name="parameters">Returns the requested data.</param>
        public override void GetLightiv(uint light, uint pname, int[] parameters) { glGetLightiv(light, pname, parameters); }

        /// <summary>
        /// Return evaluator parameters.
        /// </summary>
        /// <param name="target">Specifies the symbolic name of a map.</param>
        /// <param name="query">Specifies which parameter to return.</param>
        /// <param name="v">Returns the requested data.</param>
        public override void GetMapdv(uint target, uint query, double[] v) { glGetMapdv(target, query, v); }

        /// <summary>
        /// Return evaluator parameters.
        /// </summary>
        /// <param name="target">Specifies the symbolic name of a map.</param>
        /// <param name="query">Specifies which parameter to return.</param>
        /// <param name="v">Returns the requested data.</param>
        public override void GetMapfv(uint target, uint query, float[] v) { glGetMapfv(target, query, v); }

        /// <summary>
        /// Return evaluator parameters.
        /// </summary>
        /// <param name="target">Specifies the symbolic name of a map.</param>
        /// <param name="query">Specifies which parameter to return.</param>
        /// <param name="v">Returns the requested data.</param>
        public override void GetMapiv(uint target, uint query, int[] v) { glGetMapiv(target, query, v); }

        /// <summary>
        /// Return material parameters.
        /// </summary>
        /// <param name="face">Specifies which of the two materials is being queried. GL.FRONT or GL.BACK are accepted, representing the front and back materials, respectively.</param>
        /// <param name="pname">Specifies the material parameter to return.</param>
        /// <param name="parameters">Returns the requested data.</param>
        public override void GetMaterialfv(uint face, uint pname, float[] parameters) { glGetMaterialfv(face, pname, parameters); }

        /// <summary>
        /// Return material parameters.
        /// </summary>
        /// <param name="face">Specifies which of the two materials is being queried. GL.FRONT or GL.BACK are accepted, representing the front and back materials, respectively.</param>
        /// <param name="pname">Specifies the material parameter to return.</param>
        /// <param name="parameters">Returns the requested data.</param>
        public override void GetMaterialiv(uint face, uint pname, int[] parameters) { glGetMaterialiv(face, pname, parameters); }

        /// <summary>
        /// Return the specified pixel map.
        /// </summary>
        /// <param name="map">Specifies the	name of	the pixel map to return.</param>
        /// <param name="values">Returns the pixel map	contents.</param>
        public override void GetPixelMapfv(uint map, float[] values) { glGetPixelMapfv(map, values); }

        /// <summary>
        /// Return the specified pixel map.
        /// </summary>
        /// <param name="map">Specifies the	name of	the pixel map to return.</param>
        /// <param name="values">Returns the pixel map	contents.</param>
        public override void GetPixelMapuiv(uint map, uint[] values) { glGetPixelMapuiv(map, values); }

        /// <summary>
        /// Return the specified pixel map.
        /// </summary>
        /// <param name="map">Specifies the	name of	the pixel map to return.</param>
        /// <param name="values">Returns the pixel map	contents.</param>
        public override void GetPixelMapusv(uint map, ushort[] values) { glGetPixelMapusv(map, values); }

        /// <summary>
        /// Return the address of the specified pointer.
        /// </summary>
        /// <param name="pname">Specifies the array or buffer pointer to be returned.</param>
        /// <param name="parameters">Returns the pointer value specified by parameters.</param>
        public override void GetPointerv(uint pname, int[] parameters) { glGetPointerv(pname, parameters); }

        /// <summary>
        /// Return the polygon stipple pattern.
        /// </summary>
        /// <param name="mask">Returns the stipple pattern. The initial value is all 1's.</param>
        public override void GetPolygonStipple(byte[] mask) { glGetPolygonStipple(mask); }

        /// <summary>
        /// Return a string	describing the current GL connection.
        /// </summary>
        /// <param name="name">Specifies a symbolic constant, one of GL.VENDOR, GL.RENDERER, GL.VERSION, or GL.EXTENSIONS.</param>
        /// <returns>Pointer to the specified string.</returns>
        public override string GetString(uint name) { unsafe { return new string(glGetString(name)); } }

        /// <summary>
        /// Return texture environment parameters.
        /// </summary>
        /// <param name="target">Specifies a texture environment.  Must be GL.TEXTURE_ENV.</param>
        /// <param name="pname">Specifies the	symbolic name of a texture environment parameter.  Accepted values are GL.TEXTURE_ENV_MODE, and GL.TEXTURE_ENV_COLOR.</param>
        /// <param name="parameters">Returns the requested	data.</param>
        public override void GetTexEnvfv(uint target, uint pname, float[] parameters) { glGetTexEnvfv(target, pname, parameters); }

        /// <summary>
        /// Return texture environment parameters.
        /// </summary>
        /// <param name="target">Specifies a texture environment.  Must be GL.TEXTURE_ENV.</param>
        /// <param name="pname">Specifies the	symbolic name of a texture environment parameter.  Accepted values are GL.TEXTURE_ENV_MODE, and GL.TEXTURE_ENV_COLOR.</param>
        /// <param name="parameters">Returns the requested	data.</param>
        public override void GetTexEnviv(uint target, uint pname, int[] parameters) { glGetTexEnviv(target, pname, parameters); }

        /// <summary>
        /// Control the generation of texture coordinates.
        /// </summary>
        /// <param name="coord">Specifies a texture coordinate. Must be one of GL.S, GL.T, GL.R, or GL.Q.</param>
        /// <param name="pname">Specifies the symbolic name of the texture-coordinate generation function. Must be GL.TEXTURE_GEN_MODE.</param>
        /// <param name="parameters">Specifies a single-valued texture generation parameter, one of GL.OBJECT_LINEAR, GL.EYE_LINEAR, or GL.SPHERE_MAP.</param>
        public override void GetTexGendv(uint coord, uint pname, double[] parameters) { glGetTexGendv(coord, pname, parameters); }

        /// <summary>
        /// Control the generation of texture coordinates.
        /// </summary>
        /// <param name="coord">Specifies a texture coordinate. Must be one of GL.S, GL.T, GL.R, or GL.Q.</param>
        /// <param name="pname">Specifies the symbolic name of the texture-coordinate generation function. Must be GL.TEXTURE_GEN_MODE.</param>
        /// <param name="parameters">Specifies a single-valued texture generation parameter, one of GL.OBJECT_LINEAR, GL.EYE_LINEAR, or GL.SPHERE_MAP.</param>
        public override void GetTexGenfv(uint coord, uint pname, float[] parameters) { glGetTexGenfv(coord, pname, parameters); }

        /// <summary>
        /// Control the generation of texture coordinates.
        /// </summary>
        /// <param name="coord">Specifies a texture coordinate. Must be one of GL.S, GL.T, GL.R, or GL.Q.</param>
        /// <param name="pname">Specifies the symbolic name of the texture-coordinate generation function. Must be GL.TEXTURE_GEN_MODE.</param>
        /// <param name="parameters">Specifies a single-valued texture generation parameter, one of GL.OBJECT_LINEAR, GL.EYE_LINEAR, or GL.SPHERE_MAP.</param>
        public override void GetTexGeniv(uint coord, uint pname, int[] parameters) { glGetTexGeniv(coord, pname, parameters); }

        /// <summary>
        /// Return a texture image.
        /// </summary>
        /// <param name="target">Specifies which texture is to	be obtained. GL.TEXTURE_1D and GL.TEXTURE_2D are accepted.</param>
        /// <param name="level">Specifies the level-of-detail number of the desired image.  Level	0 is the base image level.  Level n is the nth mipmap reduction image.</param>
        /// <param name="format">Specifies a pixel format for the returned data.</param>
        /// <param name="type">Specifies a pixel type for the returned data.</param>
        /// <param name="pixels">Returns the texture image.  Should be	a pointer to an array of the type specified by type.</param>
        public override void GetTexImage(uint target, int level, uint format, uint type, IntPtr pixels) { glGetTexImage(target, level, format, type, pixels); }

        /// <summary>
        /// Return texture parameter values for a specific level of detail.
        /// </summary>
        /// <param name="target">Specifies the	symbolic name of the target texture.</param>
        /// <param name="level">Specifies the level-of-detail	number of the desired image.  Level	0 is the base image level.  Level n is the nth mipmap reduction image.</param>
        /// <param name="pname">Specifies the symbolic name of a texture parameter.</param>
        /// <param name="parameters">Returns the requested	data.</param>
        public override void GetTexLevelParameterfv(uint target, int level, uint pname, float[] parameters) { glGetTexLevelParameterfv(target, level, pname, parameters); }

        /// <summary>
        /// Return texture parameter values for a specific level of detail.
        /// </summary>
        /// <param name="target">Specifies the	symbolic name of the target texture.</param>
        /// <param name="level">Specifies the level-of-detail	number of the desired image.  Level	0 is the base image level.  Level n is the nth mipmap reduction image.</param>
        /// <param name="pname">Specifies the symbolic name of a texture parameter.</param>
        /// <param name="parameters">Returns the requested	data.</param>
        public override void GetTexLevelParameteriv(uint target, int level, uint pname, int[] parameters) { glGetTexLevelParameteriv(target, level, pname, parameters); }

        /// <summary>
        /// Return texture parameter values.
        /// </summary>
        /// <param name="target">Specifies the symbolic name of the target texture.</param>
        /// <param name="pname">Specifies the symbolic name of a texture parameter.</param>
        /// <param name="parameters">Returns the texture parameters.</param>
        public override void GetTexParameterfv(uint target, uint pname, float[] parameters) { glGetTexParameterfv(target, pname, parameters); }

        /// <summary>
        /// Return texture parameter values.
        /// </summary>
        /// <param name="target">Specifies the symbolic name of the target texture.</param>
        /// <param name="pname">Specifies the symbolic name of a texture parameter.</param>
        /// <param name="parameters">Returns the texture parameters.</param>
        public override void GetTexParameteriv(uint target, uint pname, int[] parameters) { glGetTexParameteriv(target, pname, parameters); }

        /// <summary>
        /// Specify implementation-specific hints.
        /// </summary>
        /// <param name="target">Specifies a symbolic constant indicating the behavior to be controlled.</param>
        /// <param name="mode">Specifies a symbolic constant indicating the desired behavior.</param>
        public override void Hint(uint target, uint mode) { glHint(target, mode); }

        /// <summary>
        /// Control	the writing of individual bits in the color	index buffers.
        /// </summary>
        /// <param name="mask">Specifies a bit	mask to	enable and disable the writing of individual bits in the color index buffers. Initially, the mask is all 1's.</param>
        public override void IndexMask(uint mask) { glIndexMask(mask); }

        /// <summary>
        /// Define an array of color indexes.
        /// </summary>
        /// <param name="type">Specifies the data type of each color index in the array.  Symbolic constants GL.UNSIGNED_BYTE, GL.SHORT, GL.INT, GL.FLOAT, and GL.DOUBLE are accepted.</param>
        /// <param name="stride">Specifies the byte offset between consecutive color indexes.  If stride is 0 (the initial value), the color indexes are understood	to be tightly packed in the array.</param>
        /// <param name="pointer">Specifies a pointer to the first index in the array.</param>
        public override void IndexPointer(uint type, int stride, int[] pointer) { glIndexPointer(type, stride, pointer); }

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        public override void Indexd(double c) { glIndexd(c); }

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        public override void Indexdv(double[] c) { glIndexdv(c); }

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        public override void Indexf(float c) { glIndexf(c); }

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        public override void Indexfv(float[] c) { glIndexfv(c); }

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        public override void Indexi(int c) { glIndexi(c); }

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        public override void Indexiv(int[] c) { glIndexiv(c); }

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        public override void Indexs(short c) { glIndexs(c); }

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        public override void Indexsv(short[] c) { glIndexsv(c); }

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        public override void Indexub(byte c) { glIndexub(c); }

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        public override void Indexubv(byte[] c) { glIndexubv(c); }

        /// <summary>
        /// This function initialises the select buffer names.
        /// </summary>
        public override void InitNames() { glInitNames(); }

        /// <summary>
        /// Simultaneously specify and enable several interleaved arrays.
        /// </summary>
        /// <param name="format">Specifies the type of array to enable.</param>
        /// <param name="stride">Specifies the offset in bytes between each aggregate array element.</param>
        /// <param name="pointer">The array.</param>
        public override void InterleavedArrays(uint format, int stride, int[] pointer) { glInterleavedArrays(format, stride, pointer); }

        /// <summary>
        /// Use this function to query if a certain GL function is enabled or not.
        /// </summary>
        /// <param name="cap">The capability to test.</param>
        /// <returns>True if the capability is enabled, otherwise, false.</returns>
        public override byte IsEnabled(uint cap) { return glIsEnabled(cap); }

        /// <summary>
        /// This function determines whether a specified value is a display list.
        /// </summary>
        /// <param name="list">The value to test.</param>
        /// <returns>TRUE if it is a list, FALSE otherwise.</returns>
        public override byte IsList(uint list) { return glIsList(list); }

        /// <summary>
        /// Determine if a name corresponds	to a texture.
        /// </summary>
        /// <param name="texture">Specifies a value that may be the name of a texture.</param>
        /// <returns>True if texture is a texture object.</returns>
        public override byte IsTexture(uint texture) { return glIsTexture(texture); }

        /// <summary>
        /// This function sets a parameter of the lighting model.
        /// </summary>
        /// <param name="pname">The name of the parameter.</param>
        /// <param name="param">The parameter to set it to.</param>
        public override void LightModelf(uint pname, float param) { glLightModelf(pname, param); }

        /// <summary>
        /// This function sets a parameter of the lighting model.
        /// </summary>
        /// <param name="pname">The name of the parameter.</param>
        /// <param name="parameters">The parameter to set it to.</param>
        public override void LightModelfv(uint pname, float[] parameters) { glLightModelfv(pname, parameters); }

        /// <summary>
        /// This function sets a parameter of the lighting model.
        /// </summary>
        /// <param name="pname">The name of the parameter.</param>
        /// <param name="param">The parameter to set it to.</param>
        public override void LightModeli(uint pname, int param) { glLightModeli(pname, param); }

        /// <summary>
        /// This function sets a parameter of the lighting model.
        /// </summary>
        /// <param name="pname">The name of the parameter.</param>
        /// <param name="parameters">The parameter to set it to.</param>
        public override void LightModeliv(uint pname, int[] parameters) { glLightModeliv(pname, parameters); }

        /// <summary>
        /// Set the parameter (pname) of the light 'light'.
        /// </summary>
        /// <param name="light">The light you wish to set parameters for.</param>
        /// <param name="pname">The parameter you want to set.</param>
        /// <param name="param">The value that you want to set the parameter to.</param>
        public override void Lightf(uint light, uint pname, float param) { glLightf(light, pname, param); }

        /// <summary>
        /// Set the parameter (pname) of the light 'light'.
        /// </summary>
        /// <param name="light">The light you wish to set parameters for.</param>
        /// <param name="pname">The parameter you want to set.</param>
        /// <param name="parameters">The value that you want to set the parameter to.</param>
        public override void Lightfv(uint light, uint pname, float[] parameters) { glLightfv(light, pname, parameters); }

        /// <summary>
        /// Set the parameter (pname) of the light 'light'.
        /// </summary>
        /// <param name="light">The light you wish to set parameters for.</param>
        /// <param name="pname">The parameter you want to set.</param>
        /// <param name="param">The value that you want to set the parameter to.</param>
        public override void Lighti(uint light, uint pname, int param) { glLighti(light, pname, param); }

        /// <summary>
        /// Set the parameter (pname) of the light 'light'.
        /// </summary>
        /// <param name="light">The light you wish to set parameters for.</param>
        /// <param name="pname">The parameter you want to set.</param>
        /// <param name="parameters">The parameters.</param>
        public override void Lightiv(uint light, uint pname, int[] parameters) { glLightiv(light, pname, parameters); }

        /// <summary>
        /// Specify the line stipple pattern.
        /// </summary>
        /// <param name="factor">Specifies a multiplier for each bit in the line stipple pattern.  If factor is 3, for example, each bit in the pattern is used three times before the next	bit in the pattern is used. factor is clamped to the range	[1, 256] and defaults to 1.</param>
        /// <param name="pattern">Specifies a 16-bit integer whose bit	pattern determines which fragments of a line will be drawn when	the line is rasterized.	 Bit zero is used first{} the default pattern is all 1's.</param>
        public override void LineStipple(int factor, ushort pattern) { glLineStipple(factor, pattern); }

        /// <summary>
        /// Set's the current width of lines.
        /// </summary>
        /// <param name="width">New line width to set.</param>
        public override void LineWidth(float width) { glLineWidth(width); }

        /// <summary>
        /// Set the display-list base for glCallLists.
        /// </summary>
        /// <param name="listbase">Specifies an integer offset that will be added to glCallLists offsets to generate display-list names. The initial value is 0.</param>
        public override void ListBase(uint listbase) { glListBase(listbase); }

        /// <summary>
        /// Call this function to load the identity matrix into the current matrix stack.
        /// </summary>
        public override void LoadIdentity() { glLoadIdentity(); }

        /// <summary>
        /// Replace the current matrix with the specified matrix.
        /// </summary>
        /// <param name="m">Specifies a pointer to 16 consecutive values, which are used as the elements of a 4x4 column-major matrix.</param>
        public override void LoadMatrixd(double[] m) { glLoadMatrixd(m); }

        /// <summary>
        /// Replace the current matrix with the specified matrix.
        /// </summary>
        /// <param name="m">Specifies a pointer to 16 consecutive values, which are used as the elements of a 4x4 column-major matrix.</param>
        public override void LoadMatrixf(float[] m) { glLoadMatrixf(m); }

        /// <summary>
        /// This function replaces the name at the top of the selection names stack
        /// with 'name'.
        /// </summary>
        /// <param name="name">The name to replace it with.</param>
        public override void LoadName(uint name) { glLoadName(name); }

        /// <summary>
        /// Specify a logical pixel operation for color index rendering.
        /// </summary>
        /// <param name="opcode">Specifies a symbolic constant	that selects a logical operation.</param>
        public override void LogicOp(uint opcode) { glLogicOp(opcode); }

        /// <summary>
        /// Defines a 1D evaluator.
        /// </summary>
        /// <param name="target">What the control points represent (e.g. MAP1_VERTEX_3).</param>
        /// <param name="u1">Range of the variable 'u'.</param>
        /// <param name="u2">Range of the variable 'u'.</param>
        /// <param name="stride">Offset between beginning of one control point, and beginning of next.</param>
        /// <param name="order">The degree plus one, should agree with the number of control points.</param>
        /// <param name="points">The data for the points.</param>
        public override void Map1d(uint target, double u1, double u2, int stride, int order, IntPtr points) { glMap1d(target, u1, u2, stride, order, points); }

        /// <summary>
        /// Defines a 1D evaluator.
        /// </summary>
        /// <param name="target">What the control points represent (e.g. MAP1_VERTEX_3).</param>
        /// <param name="u1">Range of the variable 'u'.</param>
        /// <param name="u2">Range of the variable 'u'.</param>
        /// <param name="stride">Offset between beginning of one control point, and beginning of next.</param>
        /// <param name="order">The degree plus one, should agree with the number of control points.</param>
        /// <param name="points">The data for the points.</param>
        public override void Map1f(uint target, float u1, float u2, int stride, int order, IntPtr points) { glMap1f(target, u1, u2, stride, order, points); }

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
        public override void Map2d(uint target, double u1, double u2, int ustride, int uorder, double v1, double v2, int vstride, int vorder, IntPtr points) { glMap2d(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, points); }

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
        public override void Map2f(uint target, float u1, float u2, int ustride, int uorder, float v1, float v2, int vstride, int vorder, IntPtr points) { glMap2f(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, points); }

        /// <summary>
        /// This function defines a grid that goes from u1 to u1 in n steps, evenly spaced.
        /// </summary>
        /// <param name="un">Number of steps.</param>
        /// <param name="u1">Range of variable 'u'.</param>
        /// <param name="u2">Range of variable 'u'.</param>
        public override void MapGrid1d(int un, double u1, double u2) { glMapGrid1d(un, u1, u2); }

        /// <summary>
        ///
        /// </summary>
        /// <param name="un"></param>
        /// <param name="u1"></param>
        /// <param name="u2"></param>
        public override void MapGrid1f(int un, float u1, float u2) { glMapGrid1f(un, u1, u2); }

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
        public override void MapGrid2d(int un, double u1, double u2, int vn, double v1, double v2) { glMapGrid2d(un, u1, u2, vn, v1, v2); }

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
        public override void MapGrid2f(int un, float u1, float u2, int vn, float v1, float v2) { glMapGrid2f(un, u1, u2, vn, v1, v2); }

        /// <summary>
        /// This function sets a material parameter.
        /// </summary>
        /// <param name="face">What faces is this parameter for (i.e front/back etc).</param>
        /// <param name="pname">What parameter you want to set.</param>
        /// <param name="param">The value to set 'pname' to.</param>
        public override void Materialf(uint face, uint pname, float param) { glMaterialf(face, pname, param); }

        /// <summary>
        /// This function sets a material parameter.
        /// </summary>
        /// <param name="face">What faces is this parameter for (i.e front/back etc).</param>
        /// <param name="pname">What parameter you want to set.</param>
        /// <param name="parameters">The value to set 'pname' to.</param>
        public override void Materialfv(uint face, uint pname, float[] parameters) { glMaterialfv(face, pname, parameters); }

        /// <summary>
        /// This function sets a material parameter.
        /// </summary>
        /// <param name="face">What faces is this parameter for (i.e front/back etc).</param>
        /// <param name="pname">What parameter you want to set.</param>
        /// <param name="param">The value to set 'pname' to.</param>
        public override void Materiali(uint face, uint pname, int param) { glMateriali(face, pname, param); }

        /// <summary>
        /// This function sets a material parameter.
        /// </summary>
        /// <param name="face">What faces is this parameter for (i.e front/back etc).</param>
        /// <param name="pname">What parameter you want to set.</param>
        /// <param name="parameters">The value to set 'pname' to.</param>
        public override void Materialiv(uint face, uint pname, int[] parameters) { glMaterialiv(face, pname, parameters); }

        /// <summary>
        /// Set the current matrix mode (the matrix that matrix operations will be
        /// performed on).
        /// </summary>
        /// <param name="mode">The mode, normally PROJECTION or MODELVIEW.</param>
        public override void MatrixMode(uint mode) { glMatrixMode(mode); }

        /// <summary>
        /// Multiply the current matrix with the specified matrix.
        /// </summary>
        /// <param name="m">Points to 16 consecutive values that are used as the elements of a 4x4 column-major matrix.</param>
        public override void MultMatrixd(double[] m) { glMultMatrixd(m); }

        /// <summary>
        /// Multiply the current matrix with the specified matrix.
        /// </summary>
        /// <param name="m">Points to 16 consecutive values that are used as the elements of a 4x4 column-major matrix.</param>
        public override void MultMatrixf(float[] m) { glMultMatrixf(m); }

        /// <summary>
        /// This function starts compiling a new display list.
        /// </summary>
        /// <param name="list">The list to compile.</param>
        /// <param name="mode">Either COMPILE or COMPILE_AND_EXECUTE.</param>
        public override void NewList(uint list, uint mode) { glNewList(list, mode); }

        /// <summary>
        /// Set the current normal.
        /// </summary>
        /// <param name="nx">Normal Coordinate.</param>
        /// <param name="ny">Normal Coordinate.</param>
        /// <param name="nz">Normal Coordinate.</param>
        public override void Normal3b(byte nx, byte ny, byte nz) { glNormal3b(nx, ny, nz); }

        /// <summary>
        /// This function sets the current normal.
        /// </summary>
        /// <param name="v">The normal.</param>
        public override void Normal3bv(byte[] v) { glNormal3bv(v); }

        /// <summary>
        /// Set the current normal.
        /// </summary>
        /// <param name="nx">Normal Coordinate.</param>
        /// <param name="ny">Normal Coordinate.</param>
        /// <param name="nz">Normal Coordinate.</param>
        public override void Normal3d(double nx, double ny, double nz) { glNormal3d(nx, ny, nz); }

        /// <summary>
        /// This function sets the current normal.
        /// </summary>
        /// <param name="v">The normal.</param>
        public override void Normal3dv(double[] v) { glNormal3dv(v); }

        /// <summary>
        /// Set the current normal.
        /// </summary>
        /// <param name="nx">Normal Coordinate.</param>
        /// <param name="ny">Normal Coordinate.</param>
        /// <param name="nz">Normal Coordinate.</param>
        public override void Normal3f(float nx, float ny, float nz) { glNormal3f(nx, ny, nz); }

        /// <summary>
        /// This function sets the current normal.
        /// </summary>
        /// <param name="v">The normal.</param>
        public override void Normal3fv(float[] v) { glNormal3fv(v); }

        /// <summary>
        /// Set the current normal.
        /// </summary>
        /// <param name="nx">Normal Coordinate.</param>
        /// <param name="ny">Normal Coordinate.</param>
        /// <param name="nz">Normal Coordinate.</param>
        public override void Normal3i(int nx, int ny, int nz) { glNormal3i(nx, ny, nz); }

        /// <summary>
        /// This function sets the current normal.
        /// </summary>
        /// <param name="v">The normal.</param>
        public override void Normal3iv(int[] v) { glNormal3iv(v); }

        /// <summary>
        /// Set the current normal.
        /// </summary>
        /// <param name="nx">Normal Coordinate.</param>
        /// <param name="ny">Normal Coordinate.</param>
        /// <param name="nz">Normal Coordinate.</param>
        public override void Normal3s(short nx, short ny, short nz) { glNormal3s(nx, ny, nz); }

        /// <summary>
        /// This function sets the current normal.
        /// </summary>
        /// <param name="v">The normal.</param>
        public override void Normal3sv(short[] v) { glNormal3sv(v); }

        /// <summary>
        /// Set's the pointer to the normal array.
        /// </summary>
        /// <param name="type">The type of data.</param>
        /// <param name="stride">The space in bytes between each normal.</param>
        /// <param name="pointer">The normals.</param>
        public override void NormalPointer(uint type, int stride, IntPtr pointer) { glNormalPointer(type, stride, pointer); }

        /// <summary>
        /// Set's the pointer to the normal array.
        /// </summary>
        /// <param name="type">The type of data.</param>
        /// <param name="stride">The space in bytes between each normal.</param>
        /// <param name="pointer">The normals.</param>
        public override void NormalPointer(uint type, int stride, float[] pointer) { glNormalPointer(type, stride, pointer); }

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
        public override void Ortho(double left, double right, double bottom, double top, double zNear, double zFar) { glOrtho(left, right, bottom, top, zNear, zFar); }

        /// <summary>
        /// Place a marker in the feedback buffer.
        /// </summary>
        /// <param name="token">Specifies a marker value to be placed in the feedback buffer following a GL.PASS_THROUGH_TOKEN.</param>
        public override void PassThrough(float token) { glPassThrough(token); }

        /// <summary>
        /// Set up pixel transfer maps.
        /// </summary>
        /// <param name="map">Specifies a symbolic	map name.</param>
        /// <param name="mapsize">Specifies the size of the map being defined.</param>
        /// <param name="values">Specifies an	array of mapsize values.</param>
        public override void PixelMapfv(uint map, int mapsize, float[] values) { glPixelMapfv(map, mapsize, values); }

        /// <summary>
        /// Set up pixel transfer maps.
        /// </summary>
        /// <param name="map">Specifies a symbolic	map name.</param>
        /// <param name="mapsize">Specifies the size of the map being defined.</param>
        /// <param name="values">Specifies an	array of mapsize values.</param>
        public override void PixelMapuiv(uint map, int mapsize, uint[] values) { glPixelMapuiv(map, mapsize, values); }

        /// <summary>
        /// Set up pixel transfer maps.
        /// </summary>
        /// <param name="map">Specifies a symbolic	map name.</param>
        /// <param name="mapsize">Specifies the size of the map being defined.</param>
        /// <param name="values">Specifies an	array of mapsize values.</param>
        public override void PixelMapusv(uint map, int mapsize, ushort[] values) { glPixelMapusv(map, mapsize, values); }

        /// <summary>
        /// Set pixel storage modes.
        /// </summary>
        /// <param name="pname">Specifies the symbolic	name of	the parameter to be set.</param>
        /// <param name="param">Specifies the value that pname	is set to.</param>
        public override void PixelStoref(uint pname, float param) { glPixelStoref(pname, param); }

        /// <summary>
        /// Set pixel storage modes.
        /// </summary>
        /// <param name="pname">Specifies the symbolic	name of	the parameter to be set.</param>
        /// <param name="param">Specifies the value that pname	is set to.</param>
        public override void PixelStorei(uint pname, int param) { glPixelStorei(pname, param); }

        /// <summary>
        /// Set pixel transfer modes.
        /// </summary>
        /// <param name="pname">Specifies the symbolic name of the pixel transfer parameter to be set.</param>
        /// <param name="param">Specifies the value that pname is set to.</param>
        public override void PixelTransferf(uint pname, float param) { glPixelTransferf(pname, param); }

        /// <summary>
        /// Set pixel transfer modes.
        /// </summary>
        /// <param name="pname">Specifies the symbolic name of the pixel transfer parameter to be set.</param>
        /// <param name="param">Specifies the value that pname is set to.</param>
        public override void PixelTransferi(uint pname, int param) { glPixelTransferi(pname, param); }

        /// <summary>
        /// Specify	the pixel zoom factors.
        /// </summary>
        /// <param name="xfactor">Specify the x and y zoom factors for pixel write operations.</param>
        /// <param name="yfactor">Specify the x and y zoom factors for pixel write operations.</param>
        public override void PixelZoom(float xfactor, float yfactor) { glPixelZoom(xfactor, yfactor); }

        /// <summary>
        /// The size of points to be rasterised.
        /// </summary>
        /// <param name="size">Size in pixels.</param>
        public override void PointSize(float size) { glPointSize(size); }

        /// <summary>
        /// This sets the current drawing mode of polygons (points, lines, filled).
        /// </summary>
        /// <param name="face">The faces this applies to (front, back or both).</param>
        /// <param name="mode">The mode to set to (points, lines, or filled).</param>
        public override void PolygonMode(uint face, uint mode) { glPolygonMode(face, mode); }

        /// <summary>
        /// Set	the scale and units used to calculate depth	values.
        /// </summary>
        /// <param name="factor">Specifies a scale factor that	is used	to create a variable depth offset for each polygon. The initial value is 0.</param>
        /// <param name="units">Is multiplied by an implementation-specific value to create a constant depth offset. The initial value is 0.</param>
        public override void PolygonOffset(float factor, float units) { glPolygonOffset(factor, units); }

        /// <summary>
        /// Set the polygon stippling pattern.
        /// <para>https://www.GL.org/sdk/docs/man2/xhtml/glPolygonStipple.xml</para>
        /// </summary>
        /// <param name="mask">Specifies a pointer to a 32x32 stipple pattern that will be unpacked from memory in the same way that glDrawPixels unpacks pixels.</param>
        public override void PolygonStipple(byte[] mask) { glPolygonStipple(mask); }

        /// <summary>
        /// This function restores the attribute stack to the state it was when
        /// PushAttrib was called.
        /// </summary>
        public override void PopAttrib() { glPopAttrib(); }

        /// <summary>
        /// Pop the client attribute stack.
        /// </summary>
        public override void PopClientAttrib() { glPopClientAttrib(); }

        /// <summary>
        /// Restore the previously saved state of the current matrix stack.
        /// </summary>
        public override void PopMatrix() { glPopMatrix(); }

        /// <summary>
        /// This takes the top name off the selection names stack.
        /// </summary>
        public override void PopName() { glPopName(); }

        /// <summary>
        /// Set texture residence priority.
        /// </summary>
        /// <param name="n">Specifies the number of textures to be prioritized.</param>
        /// <param name="textures">Specifies an array containing the names of the textures to be prioritized.</param>
        /// <param name="priorities">Specifies	an array containing the	texture priorities. A priority given in an element of priorities applies to the	texture	named by the corresponding element of textures.</param>
        public override void PrioritizeTextures(int n, uint[] textures, float[] priorities) { glPrioritizeTextures(n, textures, priorities); }

        /// <summary>
        /// Save the current state of the attribute groups specified by 'mask'.
        /// </summary>
        /// <param name="mask">The attibute groups to save.</param>
        public override void PushAttrib(uint mask) { glPushAttrib(mask); }

        /// <summary>
        /// Push the client attribute stack.
        /// </summary>
        /// <param name="mask">Specifies a mask that indicates	which attributes to save.</param>
        public override void PushClientAttrib(uint mask) { glPushClientAttrib(mask); }

        /// <summary>
        /// Save the current state of the current matrix stack.
        /// </summary>
        public override void PushMatrix() { glPushMatrix(); }

        /// <summary>
        /// This function adds a new name to the selection buffer.
        /// </summary>
        /// <param name="name">The name to add.</param>
        public override void PushName(uint name) { glPushName(name); }

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        public override void RasterPos2d(double x, double y) { glRasterPos2d(x, y); }

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        public override void RasterPos2dv(double[] v) { glRasterPos2dv(v); }

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        public override void RasterPos2f(float x, float y) { glRasterPos2f(x, y); }

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        public override void RasterPos2fv(float[] v) { glRasterPos2fv(v); }

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        public override void RasterPos2i(int x, int y) { glRasterPos2i(x, y); }

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        public override void RasterPos2iv(int[] v) { glRasterPos2iv(v); }

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        public override void RasterPos2s(short x, short y) { glRasterPos2s(x, y); }

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        public override void RasterPos2sv(short[] v) { glRasterPos2sv(v); }

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        public override void RasterPos3d(double x, double y, double z) { glRasterPos3d(x, y, z); }

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        public override void RasterPos3dv(double[] v) { glRasterPos3dv(v); }

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        public override void RasterPos3f(float x, float y, float z) { glRasterPos3f(x, y, z); }

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        public override void RasterPos3fv(float[] v) { glRasterPos3fv(v); }

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        public override void RasterPos3i(int x, int y, int z) { glRasterPos3i(x, y, z); }

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        public override void RasterPos3iv(int[] v) { glRasterPos3iv(v); }

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        public override void RasterPos3s(short x, short y, short z) { glRasterPos3s(x, y, z); }

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        public override void RasterPos3sv(short[] v) { glRasterPos3sv(v); }

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        /// <param name="w">W coordinate.</param>
        public override void RasterPos4d(double x, double y, double z, double w) { glRasterPos4d(x, y, z, w); }

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        public override void RasterPos4dv(double[] v) { glRasterPos4dv(v); }

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        /// <param name="w">W coordinate.</param>
        public override void RasterPos4f(float x, float y, float z, float w) { glRasterPos4f(x, y, z, w); }

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        public override void RasterPos4fv(float[] v) { glRasterPos4fv(v); }

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        /// <param name="w">W coordinate.</param>
        public override void RasterPos4i(int x, int y, int z, int w) { glRasterPos4i(x, y, z, w); }

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        public override void RasterPos4iv(int[] v) { glRasterPos4iv(v); }

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        /// <param name="w">W coordinate.</param>
        public override void RasterPos4s(short x, short y, short z, short w) { glRasterPos4s(x, y, z, w); }

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        public override void RasterPos4sv(short[] v) { glRasterPos4sv(v); }

        /// <summary>
        /// Select	a color	buffer source for pixels.
        /// </summary>
        /// <param name="mode">Specifies a color buffer.  Accepted values are GL.FRONT_LEFT, GL.FRONT_RIGHT, GL.BACK_LEFT, GL.BACK_RIGHT, GL.FRONT, GL.BACK, GL.LEFT, GL.GL_RIGHT, and GL.AUXi, where i is between 0 and GL.AUX_BUFFERS - 1.</param>
        public override void ReadBuffer(uint mode) { glReadBuffer(mode); }

        /// <summary>
        /// Reads a block of pixels from the frame buffer.
        /// </summary>
        /// <param name="x">Top-Left X value.</param>
        /// <param name="y">Top-Left Y value.</param>
        /// <param name="width">Width of block to read.</param>
        /// <param name="height">Height of block to read.</param>
        /// <param name="format">Specifies the format of the pixel data. The following symbolic values are accepted: GL.COLOR_INDEX, GL.STENCIL_INDEX, GL.DEPTH_COMPONENT, GL.RED, GL.GREEN, GL.BLUE, GL.ALPHA, GL.RGB, GL.RGBA, GL.LUMINANCE and GL.LUMINANCE_ALPHA.</param>
        /// <param name="type">Specifies the data type of the pixel data.Must be one of GL.UNSIGNED_BYTE, GL.BYTE, GL.BITMAP, GL.UNSIGNED_SHORT, GL.SHORT, GL.UNSIGNED_INT, GL.INT or GL.FLOAT.</param>
        /// <param name="pixels">Storage for the pixel data received.</param>
        public override void ReadPixels(int x, int y, int width, int height, uint format, uint type, byte[] pixels) { glReadPixels(x, y, width, height, format, type, pixels); }

        /// <summary>
        /// Reads a block of pixels from the frame buffer.
        /// </summary>
        /// <param name="x">Top-Left X value.</param>
        /// <param name="y">Top-Left Y value.</param>
        /// <param name="width">Width of block to read.</param>
        /// <param name="height">Height of block to read.</param>
        /// <param name="format">Specifies the format of the pixel data. The following symbolic values are accepted: GL.COLOR_INDEX, GL.STENCIL_INDEX, GL.DEPTH_COMPONENT, GL.RED, GL.GREEN, GL.BLUE, GL.ALPHA, GL.RGB, GL.RGBA, GL.LUMINANCE and GL.LUMINANCE_ALPHA.</param>
        /// <param name="type">Specifies the data type of the pixel data.Must be one of GL.UNSIGNED_BYTE, GL.BYTE, GL.BITMAP, GL.UNSIGNED_SHORT, GL.SHORT, GL.UNSIGNED_INT, GL.INT or GL.FLOAT.</param>
        /// <param name="pixels">Storage for the pixel data received.</param>
        public override void ReadPixels(int x, int y, int width, int height, uint format, uint type, IntPtr pixels) { glReadPixels(x, y, width, height, format, type, pixels); }

        /// <summary>
        /// Draw a rectangle from two coordinates (top-left and bottom-right).
        /// </summary>
        /// <param name="x1">Top-Left X value.</param>
        /// <param name="y1">Top-Left Y value.</param>
        /// <param name="x2">Bottom-Right X Value.</param>
        /// <param name="y2">Bottom-Right Y Value.</param>
        public override void Rectd(double x1, double y1, double x2, double y2) { glRectd(x1, y1, x2, y2); }

        /// <summary>
        /// Draw a rectangle from two coordinates, expressed as arrays, e.g
        /// Rect(new float[] {0, 0}, new float[] {10, 10}){}
        /// </summary>
        /// <param name="v1">Top-Left point.</param>
        /// <param name="v2">Bottom-Right point.</param>
        public override void Rectdv(double[] v1, double[] v2) { glRectdv(v1, v2); }

        /// <summary>
        ///
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public override void Rectf(float x1, float y1, float x2, float y2) { glRectf(x1, y1, x2, y2); }

        /// <summary>
        /// Draw a rectangle from two coordinates, expressed as arrays, e.g
        /// Rect(new float[] {0, 0}, new float[] {10, 10}){}
        /// </summary>
        /// <param name="v1">Top-Left point.</param>
        /// <param name="v2">Bottom-Right point.</param>
        public override void Rectfv(float[] v1, float[] v2) { glRectfv(v1, v2); }

        /// <summary>
        /// Draw a rectangle from two coordinates (top-left and bottom-right).
        /// </summary>
        /// <param name="x1">Top-Left X value.</param>
        /// <param name="y1">Top-Left Y value.</param>
        /// <param name="x2">Bottom-Right X Value.</param>
        /// <param name="y2">Bottom-Right Y Value.</param>
        public override void Recti(int x1, int y1, int x2, int y2) { glRecti(x1, y1, x2, y2); }

        /// <summary>
        /// Draw a rectangle from two coordinates, expressed as arrays, e.g
        /// Rect(new float[] {0, 0}, new float[] {10, 10}){}
        /// </summary>
        /// <param name="v1">Top-Left point.</param>
        /// <param name="v2">Bottom-Right point.</param>
        public override void Rectiv(int[] v1, int[] v2) { glRectiv(v1, v2); }

        /// <summary>
        /// Draw a rectangle from two coordinates (top-left and bottom-right).
        /// </summary>
        /// <param name="x1">Top-Left X value.</param>
        /// <param name="y1">Top-Left Y value.</param>
        /// <param name="x2">Bottom-Right X Value.</param>
        /// <param name="y2">Bottom-Right Y Value.</param>
        public override void Rects(short x1, short y1, short x2, short y2) { glRects(x1, y1, x2, y2); }

        /// <summary>
        /// Draw a rectangle from two coordinates, expressed as arrays, e.g
        /// Rect(new float[] {0, 0}, new float[] {10, 10}){}
        /// </summary>
        /// <param name="v1">Top-Left point.</param>
        /// <param name="v2">Bottom-Right point.</param>
        public override void Rectsv(short[] v1, short[] v2) { glRectsv(v1, v2); }

        /// <summary>
        /// This function sets the current render mode (render, feedback or select).
        /// </summary>
        /// <param name="mode">The Render mode (RENDER, SELECT or FEEDBACK).</param>
        /// <returns>The hits that selection or feedback caused..</returns>
        public override int RenderMode(uint mode) { return glRenderMode(mode); }

        /// <summary>
        /// This function applies a rotation transformation to the current matrix.
        /// </summary>
        /// <param name="angle">The angle to rotate.</param>
        /// <param name="x">Amount along x.</param>
        /// <param name="y">Amount along y.</param>
        /// <param name="z">Amount along z.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Rotated(double angle, double x, double y, double z) { glRotated(angle, x, y, z); }

        /// <summary>
        /// This function applies a rotation transformation to the current matrix.
        /// </summary>
        /// <param name="angle">The angle to rotate.</param>
        /// <param name="x">Amount along x.</param>
        /// <param name="y">Amount along y.</param>
        /// <param name="z">Amount along z.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Rotatef(float angle, float x, float y, float z) { glRotatef(angle, x, y, z); }

        /// <summary>
        /// This function applies a scale transformation to the current matrix.
        /// </summary>
        /// <param name="x">The amount to scale along x.</param>
        /// <param name="y">The amount to scale along y.</param>
        /// <param name="z">The amount to scale along z.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Scaled(double x, double y, double z) { glScaled(x, y, z); }

        /// <summary>
        /// This function applies a scale transformation to the current matrix.
        /// </summary>
        /// <param name="x">The amount to scale along x.</param>
        /// <param name="y">The amount to scale along y.</param>
        /// <param name="z">The amount to scale along z.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Scalef(float x, float y, float z) { glScalef(x, y, z); }

        /// <summary>
        /// Define the scissor box.
        /// https://www.khronos.org/GLes/sdk/docs/man/xhtml/glScissor.xml
        /// </summary>
        /// <param name="x">Specify the lower left corner of the scissor box. Initially (0, 0).</param>
        /// <param name="y">Specify the lower left corner of the scissor box. Initially (0, 0).</param>
        /// <param name="width">Specify the width and height of the scissor box. When a GL context is first attached to a window, width and height are set to the dimensions of that window.</param>
        /// <param name="height">Specify the width and height of the scissor box. When a GL context is first attached to a window, width and height are set to the dimensions of that window.</param>
        public override void Scissor(int x, int y, int width, int height) { glScissor(x, y, width, height); }

        /// <summary>
        /// This function sets the current select buffer.
        /// </summary>
        /// <param name="size">The size of the buffer you are passing.</param>
        /// <param name="buffer">The buffer itself.</param>
        public override void SelectBuffer(int size, uint[] buffer) { glSelectBuffer(size, buffer); }

        /// <summary>
        /// Select flat or smooth shading.
        /// </summary>
        /// <param name="mode">Specifies a symbolic value representing a shading technique. Accepted values are GL.FLAT and GL.SMOOTH. The default is GL.SMOOTH.</param>
        public override void ShadeModel(uint mode) { glShadeModel(mode); }

        /// <summary>
        /// This function sets the current stencil buffer function.
        /// </summary>
        /// <param name="func">The function type.</param>
        /// <param name="reference">The function reference.</param>
        /// <param name="mask">The function mask.</param>
        public override void StencilFunc(uint func, int reference, uint mask) { glStencilFunc(func, reference, mask); }

        /// <summary>
        /// control the front and back writing of individual bits in the stencil planes
        /// <para>glStencilMask controls the writing of individual bits in the stencil planes. The least significant n bits of mask, where n is the number of bits in the stencil buffer, specify a mask. Where a 1 appears in the mask, it's possible to write to the corresponding bit in the stencil buffer. Where a 0 appears, the corresponding bit is write-protected. Initially, all bits are enabled for writing.
        /// There can be two separate mask writemasks{} one affects back-facing polygons, and the other affects front-facing polygons as well as other non-polygon primitives. glStencilMask sets both front and back stencil writemasks to the same values. Use glStencilMaskSeparate to set front and back stencil writemasks to different values.</para>
        /// <para>glStencilMask is the same as calling glStencilMaskSeparate with face set to GL_FRONT_AND_BACK.</para>
        /// <para>glGet with argument GL_STENCIL_WRITEMASK, GL_STENCIL_BACK_WRITEMASK, or GL_STENCIL_BITS</para>
        /// <para>See Also glColorMask, glDepthMask, glStencilFunc, glStencilFuncSeparate, glStencilMaskSeparate, glStencilOp, glStencilOpSeparate</para>
        /// </summary>
        /// <param name="mask">Specifies a bit mask to enable and disable writing of individual bits in the stencil planes. Initially, the mask is all 1's.</param>
        public override void StencilMask(uint mask) { glStencilMask(mask); }

        /// <summary>
        /// This function sets the stencil buffer operation.
        /// </summary>
        /// <param name="fail">Fail operation.</param>
        /// <param name="zfail">Depth fail component.</param>
        /// <param name="zpass">Depth pass component.</param>
        public override void StencilOp(uint fail, uint zfail, uint zpass) { glStencilOp(fail, zfail, zpass); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        public override void TexCoord1d(double s) { glTexCoord1d(s); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        public override void TexCoord1dv(double[] v) { glTexCoord1dv(v); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        public override void TexCoord1f(float s) { glTexCoord1f(s); }

        /// <summary>
        /// This function sets the current texture coordinates. WARNING: if you
        /// can call something more explicit, like TexCoord2f then call that, it's
        /// much faster.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        public override void TexCoord1fv(float[] v) { glTexCoord1fv(v); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        public override void TexCoord1i(int s) { glTexCoord1i(s); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        public override void TexCoord1iv(int[] v) { glTexCoord1iv(v); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        public override void TexCoord1s(short s) { glTexCoord1s(s); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        public override void TexCoord1sv(short[] v) { glTexCoord1sv(v); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        public override void TexCoord2d(double s, double t) { glTexCoord2d(s, t); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        public override void TexCoord2dv(double[] v) { glTexCoord2dv(v); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        public override void TexCoord2f(float s, float t) { glTexCoord2f(s, t); }

        /// <summary>
        /// This function sets the current texture coordinates. WARNING: if you
        /// can call something more explicit, like TexCoord2f then call that, it's
        /// much faster.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        public override void TexCoord2fv(float[] v) { glTexCoord2fv(v); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        public override void TexCoord2i(int s, int t) { glTexCoord2i(s, t); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        public override void TexCoord2iv(int[] v) { glTexCoord2iv(v); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        public override void TexCoord2s(short s, short t) { glTexCoord2s(s, t); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        public override void TexCoord2sv(short[] v) { glTexCoord2sv(v); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        public override void TexCoord3d(double s, double t, double r) { glTexCoord3d(s, t, r); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        public override void TexCoord3dv(double[] v) { glTexCoord3dv(v); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        public override void TexCoord3f(float s, float t, float r) { glTexCoord3f(s, t, r); }

        /// <summary>
        /// This function sets the current texture coordinates. WARNING: if you
        /// can call something more explicit, like TexCoord2f then call that, it's
        /// much faster.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        public override void TexCoord3fv(float[] v) { glTexCoord3fv(v); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        public override void TexCoord3i(int s, int t, int r) { glTexCoord3i(s, t, r); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        public override void TexCoord3iv(int[] v) { glTexCoord3iv(v); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        public override void TexCoord3s(short s, short t, short r) { glTexCoord3s(s, t, r); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        public override void TexCoord3sv(short[] v) { glTexCoord3sv(v); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        /// <param name="q">Texture Coordinate.</param>
        public override void TexCoord4d(double s, double t, double r, double q) { glTexCoord4d(s, t, r, q); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        public override void TexCoord4dv(double[] v) { glTexCoord4dv(v); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        /// <param name="q">Texture Coordinate.</param>
        public override void TexCoord4f(float s, float t, float r, float q) { glTexCoord4f(s, t, r, q); }

        /// <summary>
        /// This function sets the current texture coordinates. WARNING: if you
        /// can call something more explicit, like TexCoord2f then call that, it's
        /// much faster.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        public override void TexCoord4fv(float[] v) { glTexCoord4fv(v); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        /// <param name="q">Texture Coordinate.</param>
        public override void TexCoord4i(int s, int t, int r, int q) { glTexCoord4i(s, t, r, q); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        public override void TexCoord4iv(int[] v) { glTexCoord4iv(v); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        /// <param name="q">Texture Coordinate.</param>
        public override void TexCoord4s(short s, short t, short r, short q) { glTexCoord4s(s, t, r, q); }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        public override void TexCoord4sv(short[] v) { glTexCoord4sv(v); }

        /// <summary>
        /// This function sets the texture coord array.
        /// </summary>
        /// <param name="size">The number of coords per set.</param>
        /// <param name="type">The type of data.</param>
        /// <param name="stride">The number of bytes between coords.</param>
        /// <param name="pointer">The coords.</param>
        public override void TexCoordPointer(int size, uint type, int stride, IntPtr pointer) { glTexCoordPointer(size, type, stride, pointer); }

        /// <summary>
        /// This function sets the texture coord array.
        /// </summary>
        /// <param name="size">The number of coords per set.</param>
        /// <param name="type">The type of data.</param>
        /// <param name="stride">The number of bytes between coords.</param>
        /// <param name="pointer">The coords.</param>
        public override void TexCoordPointer(int size, uint type, int stride, float[] pointer) { glTexCoordPointer(size, type, stride, pointer); }

        /// <summary>
        /// Set texture environment parameters.
        /// </summary>
        /// <param name="target">Specifies a texture environment. Must be GL.TEXTURE_ENV.</param>
        /// <param name="pname">Specifies the symbolic name of a single-valued texture environment parameter. Must be GL.TEXTURE_ENV_MODE.</param>
        /// <param name="param">Specifies a single symbolic constant, one of GL.MODULATE, GL.DECAL, GL.BLEND, or GL.REPLACE.</param>
        public override void TexEnvf(uint target, uint pname, float param) { glTexEnvf(target, pname, param); }

        /// <summary>
        /// Set texture environment parameters.
        /// </summary>
        /// <param name="target">Specifies a texture environment. Must be GL.TEXTURE_ENV.</param>
        /// <param name="pname">Specifies the symbolic name of a texture environment parameter. Accepted values are GL.TEXTURE_ENV_MODE and GL.TEXTURE_ENV_COLOR.</param>
        /// <param name="parameters">Specifies a pointer to a parameter array that contains either a single symbolic constant or an RGBA color.</param>
        public override void TexEnvfv(uint target, uint pname, float[] parameters) { glTexEnvfv(target, pname, parameters); }

        /// <summary>
        /// Set texture environment parameters.
        /// </summary>
        /// <param name="target">Specifies a texture environment. Must be GL.TEXTURE_ENV.</param>
        /// <param name="pname">Specifies the symbolic name of a single-valued texture environment parameter. Must be GL.TEXTURE_ENV_MODE.</param>
        /// <param name="param">Specifies a single symbolic constant, one of GL.MODULATE, GL.DECAL, GL.BLEND, or GL.REPLACE.</param>
        public override void TexEnvi(uint target, uint pname, int param) { glTexEnvi(target, pname, param); }

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <param name="pname"></param>
        /// <param name="parameters"></param>
        public override void TexEnviv(uint target, uint pname, int[] parameters) { glTexEnviv(target, pname, parameters); }

        /// <summary>
        /// Control the generation of texture coordinates.
        /// </summary>
        /// <param name="coord">Specifies a texture coordinate. Must be one of GL.S, GL.T, GL.R, or GL.Q.</param>
        /// <param name="pname">Specifies the symbolic name of the texture-coordinate generation function. Must be GL.TEXTURE_GEN_MODE.</param>
        /// <param name="param">Specifies a single-valued texture generation parameter, one of GL.OBJECT_LINEAR, GL.GL_EYE_LINEAR, or GL.SPHERE_MAP.</param>
        public override void TexGend(uint coord, uint pname, double param) { glTexGend(coord, pname, param); }

        /// <summary>
        /// Control the generation of texture coordinates.
        /// </summary>
        /// <param name="coord">Specifies a texture coordinate. Must be one of GL.S, GL.T, GL.R, or GL.Q.</param>
        /// <param name="pname">Specifies the symbolic name of the texture-coordinate generation function or function parameters. Must be GL.TEXTURE_GEN_MODE, GL.OBJECT_PLANE, or GL.EYE_PLANE.</param>
        /// <param name="parameters">Specifies a pointer to an array of texture generation parameters. If pname is GL.TEXTURE_GEN_MODE, then the array must contain a single symbolic constant, one of GL.OBJECT_LINEAR, GL.EYE_LINEAR, or GL.SPHERE_MAP. Otherwise, params holds the coefficients for the texture-coordinate generation function specified by pname.</param>
        public override void TexGendv(uint coord, uint pname, double[] parameters) { glTexGendv(coord, pname, parameters); }

        /// <summary>
        /// Control the generation of texture coordinates.
        /// </summary>
        /// <param name="coord">Specifies a texture coordinate. Must be one of GL.S, GL.T, GL.R, or GL.Q.</param>
        /// <param name="pname">Specifies the symbolic name of the texture-coordinate generation function. Must be GL.TEXTURE_GEN_MODE.</param>
        /// <param name="param">Specifies a single-valued texture generation parameter, one of GL.OBJECT_LINEAR, GL.GL_EYE_LINEAR, or GL.SPHERE_MAP.</param>
        public override void TexGenf(uint coord, uint pname, float param) { glTexGenf(coord, pname, param); }

        /// <summary>
        /// Control the generation of texture coordinates.
        /// </summary>
        /// <param name="coord">Specifies a texture coordinate. Must be one of GL.S, GL.T, GL.R, or GL.Q.</param>
        /// <param name="pname">Specifies the symbolic name of the texture-coordinate generation function or function parameters. Must be GL.TEXTURE_GEN_MODE, GL.OBJECT_PLANE, or GL.EYE_PLANE.</param>
        /// <param name="parameters">Specifies a pointer to an array of texture generation parameters. If pname is GL.TEXTURE_GEN_MODE, then the array must contain a single symbolic constant, one of GL.OBJECT_LINEAR, GL.EYE_LINEAR, or GL.SPHERE_MAP. Otherwise, params holds the coefficients for the texture-coordinate generation function specified by pname.</param>
        public override void TexGenfv(uint coord, uint pname, float[] parameters) { glTexGenfv(coord, pname, parameters); }

        /// <summary>
        /// Control the generation of texture coordinates.
        /// </summary>
        /// <param name="coord">Specifies a texture coordinate. Must be one of GL.S, GL.T, GL.R, or GL.Q.</param>
        /// <param name="pname">Specifies the symbolic name of the texture-coordinate generation function. Must be GL.TEXTURE_GEN_MODE.</param>
        /// <param name="param">Specifies a single-valued texture generation parameter, one of GL.OBJECT_LINEAR, GL.GL_EYE_LINEAR, or GL.SPHERE_MAP.</param>
        public override void TexGeni(uint coord, uint pname, int param) { glTexGeni(coord, pname, param); }

        ///// <summary>
        ///// Set texture environment parameters.
        ///// </summary>
        ///// <param name="target">Specifies a texture environment. Must be GL.TEXTURE_ENV.</param>
        ///// <param name="pname">Specifies the symbolic name of a texture environment parameter. Accepted values are GL.TEXTURE_ENV_MODE and GL.TEXTURE_ENV_COLOR.</param>
        ///// <param name="parameters">Specifies a pointer to a parameter array that contains either a single symbolic constant or an RGBA color.</param>
        ////
        /// <summary>
        /// Control the generation of texture coordinates.
        /// </summary>
        /// <param name="coord">Specifies a texture coordinate. Must be one of GL.S, GL.T, GL.R, or GL.Q.</param>
        /// <param name="pname">Specifies the symbolic name of the texture-coordinate generation function or function parameters. Must be GL.TEXTURE_GEN_MODE, GL.OBJECT_PLANE, or GL.EYE_PLANE.</param>
        /// <param name="parameters">Specifies a pointer to an array of texture generation parameters. If pname is GL.TEXTURE_GEN_MODE, then the array must contain a single symbolic constant, one of GL.OBJECT_LINEAR, GL.EYE_LINEAR, or GL.SPHERE_MAP. Otherwise, params holds the coefficients for the texture-coordinate generation function specified by pname.</param>
        public override void TexGeniv(uint coord, uint pname, int[] parameters) { glTexGeniv(coord, pname, parameters); }

        /// <summary>
        /// This function sets the image for the currently binded texture.
        /// </summary>
        /// <param name="target">The type of texture, TEXTURE_2D or PROXY_TEXTURE_2D.</param>
        /// <param name="level">For mip-map textures, ordinary textures should be '0'.</param>
        /// <param name="internalformat">The format of the data you are want GL to create, e.g  RGB16.</param>
        /// <param name="width">The width of the texture image (must be a power of 2, e.g 64).</param>
        /// <param name="border">The width of the border (0 or 1).</param>
        /// <param name="format">The format of the data you are passing, e.g. RGBA.</param>
        /// <param name="type">The type of data you are passing, e.g GL_BYTE.</param>
        /// <param name="pixels">The actual pixel data.</param>

        public override void TexImage1D(uint target, int level, uint internalformat, int width, int border, uint format, uint type, IntPtr pixels) { glTexImage1D(target, level, internalformat, width, border, format, type, pixels); }

        /// <summary>
        /// This function sets the image for the currently binded texture.
        /// </summary>
        /// <param name="target">The type of texture, TEXTURE_2D or PROXY_TEXTURE_2D.</param>
        /// <param name="level">For mip-map textures, ordinary textures should be '0'.</param>
        /// <param name="internalformat">The format of the data you are want GL to create, e.g  RGB16.</param>
        /// <param name="width">The width of the texture image (must be a power of 2, e.g 64).</param>
        /// <param name="height">The height of the texture image (must be a power of 2, e.g 32).</param>
        /// <param name="border">The width of the border (0 or 1).</param>
        /// <param name="format">The format of the data you are passing, e.g. RGBA.</param>
        /// <param name="type">The type of data you are passing, e.g GL_BYTE.</param>
        /// <param name="pixels">The actual pixel data.</param>
        public override void TexImage2D(uint target, int level, uint internalformat, int width, int height, int border, uint format, uint type, IntPtr pixels) { glTexImage2D(target, level, internalformat, width, height, border, format, type, pixels); }

        /// <summary>
        ///	This function sets the parameters for the currently binded texture object.
        /// </summary>
        /// <param name="target">The type of texture you are setting the parameter to, e.g. TEXTURE_2D</param>
        /// <param name="pname">The parameter to set.</param>
        /// <param name="param">The value to set it to.</param>
        public override void TexParameterf(uint target, uint pname, float param) { glTexParameterf(target, pname, param); }

        /// <summary>
        ///	This function sets the parameters for the currently binded texture object.
        /// </summary>
        /// <param name="target">The type of texture you are setting the parameter to, e.g. TEXTURE_2D</param>
        /// <param name="pname">The parameter to set.</param>
        /// <param name="parameters">The value to set it to.</param>
        public override void TexParameterfv(uint target, uint pname, float[] parameters) { glTexParameterfv(target, pname, parameters); }

        /// <summary>
        ///	This function sets the parameters for the currently binded texture object.
        /// </summary>
        /// <param name="target">The type of texture you are setting the parameter to, e.g. TEXTURE_2D</param>
        /// <param name="pname">The parameter to set.</param>
        /// <param name="param">The value to set it to.</param>
        public override void TexParameteri(uint target, uint pname, int param) { glTexParameteri(target, pname, param); }

        /// <summary>
        ///	This function sets the parameters for the currently binded texture object.
        /// </summary>
        /// <param name="target">The type of texture you are setting the parameter to, e.g. TEXTURE_2D</param>
        /// <param name="pname">The parameter to set.</param>
        /// <param name="parameters">The value to set it to.</param>
        public override void TexParameteriv(uint target, uint pname, int[] parameters) { glTexParameteriv(target, pname, parameters); }

        /// <summary>
        /// Specify a two-dimensional texture subimage.
        /// </summary>
        /// <param name="target">Specifies the target texture. Must be GL.TEXTURE_1D.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xoffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel	data.</param>
        /// <param name="pixels">Specifies a pointer to the image data in memory.</param>
        public override void TexSubImage1D(uint target, int level, int xoffset, int width, uint format, uint type, int[] pixels) { glTexSubImage1D(target, level, xoffset, width, format, type, pixels); }

        /// <summary>
        /// Specify a two-dimensional texture subimage.
        /// </summary>
        /// <param name="target">Specifies the target texture. Must be GL.TEXTURE_1D.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xoffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel	data.</param>
        /// <param name="pixels">Specifies a pointer to the image data in memory.</param>
        public override void TexSubImage1D(uint target, int level, int xoffset, int width, uint format, uint type, IntPtr pixels) { glTexSubImage1D(target, level, xoffset, width, format, type, pixels); }

        /// <summary>
        /// Specify a two-dimensional texture subimage.
        /// </summary>
        /// <param name="target">Specifies the target texture. Must be GL.TEXTURE_1D.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xoffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yoffset">Specifies a texel offset in the y direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="height">Specifies the height of the texture subimage.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel	data.</param>
        /// <param name="pixels">Specifies a pointer to the image data in memory.</param>
        public override void TexSubImage2D(uint target, int level, int xoffset, int yoffset, int width, int height, uint format, uint type, int[] pixels) { glTexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, pixels); }

        /// <summary>
        /// Specify a two-dimensional texture subimage.
        /// </summary>
        /// <param name="target">Specifies the target texture. Must be GL.TEXTURE_1D.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xoffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yoffset">Specifies a texel offset in the y direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="height">Specifies the height of the texture subimage.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel	data.</param>
        /// <param name="pixels">Specifies a pointer to the image data in memory.</param>
        public override void TexSubImage2D(uint target, int level, int xoffset, int yoffset, int width, int height, uint format, uint type, IntPtr pixels) { glTexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, pixels); }

        /// <summary>
        /// This function applies a translation transformation to the current matrix.
        /// </summary>
        /// <param name="x">The amount to translate along the x axis.</param>
        /// <param name="y">The amount to translate along the y axis.</param>
        /// <param name="z">The amount to translate along the z axis.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Translated(double x, double y, double z) { glTranslated(x, y, z); }

        /// <summary>
        /// This function applies a translation transformation to the current matrix.
        /// </summary>
        /// <param name="x">The amount to translate along the x axis.</param>
        /// <param name="y">The amount to translate along the y axis.</param>
        /// <param name="z">The amount to translate along the z axis.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Translatef(float x, float y, float z) { glTranslatef(x, y, z); }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Vertex2d(double x, double y) { glVertex2d(x, y); }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Vertex2dv(double[] v) { glVertex2dv(v); }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Vertex2f(float x, float y) { glVertex2f(x, y); }

        /// <summary>
        /// Sets the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">An array of 2, 3 or 4 floats.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Vertex2fv(float[] v) { glVertex2fv(v); }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Vertex2i(int x, int y) { glVertex2i(x, y); }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Vertex2iv(int[] v) { glVertex2iv(v); }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Vertex2s(short x, short y) { glVertex2s(x, y); }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Vertex2sv(short[] v) { glVertex2sv(v); }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Vertex3d(double x, double y, double z) { glVertex3d(x, y, z); }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Vertex3dv(double[] v) { glVertex3dv(v); }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Vertex3f(float x, float y, float z) { glVertex3f(x, y, z); }

        /// <summary>
        /// Sets the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">An array of 2, 3 or 4 floats.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Vertex3fv(float[] v) { glVertex3fv(v); }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Vertex3i(int x, int y, int z) { glVertex3i(x, y, z); }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Vertex3iv(int[] v) { glVertex3iv(v); }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Vertex3s(short x, short y, short z) { glVertex3s(x, y, z); }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Vertex3sv(short[] v) { glVertex3sv(v); }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        /// <param name="w">W Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Vertex4d(double x, double y, double z, double w) { glVertex4d(x, y, z, w); }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Vertex4dv(double[] v) { glVertex4dv(v); }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        /// <param name="w">W Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Vertex4f(float x, float y, float z, float w) { glVertex4f(x, y, z, w); }

        /// <summary>
        /// Sets the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">An array of 2, 3 or 4 floats.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Vertex4fv(float[] v) { glVertex4fv(v); }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        /// <param name="w">W Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Vertex4i(int x, int y, int z, int w) { glVertex4i(x, y, z, w); }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Vertex4iv(int[] v) { glVertex4iv(v); }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        /// <param name="w">W Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Vertex4s(short x, short y, short z, short w) { glVertex4s(x, y, z, w); }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        public override void Vertex4sv(short[] v) { glVertex4sv(v); }

        /// <summary>
        /// This function sets the address of the vertex pointer array.
        /// </summary>
        /// <param name="size">The number of coords per vertex.</param>
        /// <param name="type">The data type.</param>
        /// <param name="stride">The byte offset between vertices.</param>
        /// <param name="pointer">The array.</param>
        public override void VertexPointer(int size, uint type, int stride, IntPtr pointer) { glVertexPointer(size, type, stride, pointer); }

        /// <summary>
        /// This function sets the address of the vertex pointer array.
        /// </summary>
        /// <param name="size">The number of coords per vertex.</param>
        /// <param name="type"></param>
        /// <param name="stride">The byte offset between vertices.</param>
        /// <param name="pointer">The array.</param>
        public override void VertexPointer(int size, uint type, int stride, short[] pointer) { glVertexPointer(size, type, stride, pointer); }

        /// <summary>
        /// This function sets the address of the vertex pointer array.
        /// </summary>
        /// <param name="size">The number of coords per vertex.</param>
        /// <param name="type"></param>
        /// <param name="stride">The byte offset between vertices.</param>
        /// <param name="pointer">The array.</param>
        public override void VertexPointer(int size, uint type, int stride, int[] pointer) { glVertexPointer(size, type, stride, pointer); }

        /// <summary>
        /// This function sets the address of the vertex pointer array.
        /// </summary>
        /// <param name="size">The number of coords per vertex.</param>
        /// <param name="type"></param>
        /// <param name="stride">The byte offset between vertices.</param>
        /// <param name="pointer">The array.</param>
        public override void VertexPointer(int size, uint type, int stride, float[] pointer) { glVertexPointer(size, type, stride, pointer); }

        /// <summary>
        /// This function sets the address of the vertex pointer array.
        /// </summary>
        /// <param name="size">The number of coords per vertex.</param>
        /// <param name="type"></param>
        /// <param name="stride">The byte offset between vertices.</param>
        /// <param name="pointer">The array.</param>
        public override void VertexPointer(int size, uint type, int stride, double[] pointer) { glVertexPointer(size, type, stride, pointer); }

        /// <summary>
        /// This sets the viewport of the current Render Context. Normally x and y are 0
        /// and the width and height are just those of the control/graphics you are drawing
        /// to.
        /// </summary>
        /// <param name="x">Top-Left point of the viewport.</param>
        /// <param name="y">Top-Left point of the viewport.</param>
        /// <param name="width">Width of the viewport.</param>
        /// <param name="height">Height of the viewport.</param>
        public override void Viewport(int x, int y, int width, int height) { glViewport(x, y, width, height); }

        #endregion The GL DLL Functions.
    }
}