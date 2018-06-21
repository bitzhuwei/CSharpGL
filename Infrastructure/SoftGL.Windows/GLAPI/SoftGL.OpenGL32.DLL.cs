using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public partial class SoftGL
    {
        #region The OpenGL DLL Functions.

        /// <summary>
        /// Set the Accumulation Buffer operation.
        /// </summary>
        /// <param name="op">Operation of the buffer.</param>
        /// <param name="value">Reference value.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glAccum", SetLastError = true)]
        private static extern void glAccum(uint op, float value);

        /// <summary>
        /// Specify the Alpha Test function.
        /// </summary>
        /// <param name="func">Specifies the alpha comparison function. Symbolic constants GL.NEVER, GL.LESS, GL.EQUAL, GL.LEQUAL, GL.GREATER, GL.NOTEQUAL, GL.GEQUAL and GL.ALWAYS are accepted. The initial value is GL.ALWAYS.</param>
        /// <param name="ref_notkeword">Specifies the reference	value that incoming alpha values are compared to. This value is clamped to the range 0	through	1, where 0 represents the lowest possible alpha value and 1 the highest possible value. The initial reference value is 0.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glAlphaFunc", SetLastError = true)]
        private static extern void glAlphaFunc(uint func, float ref_notkeword);

        /// <summary>
        /// Determine if textures are loaded in texture memory.
        /// </summary>
        /// <param name="n">Specifies the number of textures to be queried.</param>
        /// <param name="textures">Specifies an array containing the names of the textures to be queried.</param>
        /// <param name="residences">Specifies an array in which the texture residence status is returned. The residence status of a texture named by an element of textures is returned in the corresponding element of residences.</param>
        /// <returns></returns>
        //[DllImport(Win32.opengl32, EntryPoint = "glAreTexturesResident", SetLastError = true)]
        private static extern byte glAreTexturesResident(int n, uint[] textures, byte[] residences);

        /// <summary>
        /// Render a vertex using the specified vertex array element.
        /// </summary>
        /// <param name="i">Specifies an index	into the enabled vertex	data arrays.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glArrayElement", SetLastError = true)]
        private static extern void glArrayElement(int i);

        /// <summary>
        ///
        /// </summary>
        /// <param name="mode"></param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glBegin", SetLastError = true)]
        private static extern void glBegin(uint mode);

        /// <summary>
        /// Call this function after creating a texture to finalise creation of it,
        /// or to make an existing texture current.
        /// </summary>
        /// <param name="target">The target type, e.g TEXTURE_2D.</param>
        /// <param name="texture">The OpenGL texture object.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glBindTexture", SetLastError = true)]
        private static extern void glBindTexture(uint target, uint texture);

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
        //[DllImport(Win32.opengl32, EntryPoint = "glBitmap", SetLastError = true)]
        private static extern void glBitmap(int width, int height, float xorig, float yorig, float xmove, float ymove, byte[] bitmap);

        /// <summary>
        /// This function sets the current blending function.
        /// </summary>
        /// <param name="sfactor">Source factor.</param>
        /// <param name="dfactor">Destination factor.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glBlendFunc", SetLastError = true)]
        private static extern void glBlendFunc(uint sfactor, uint dfactor);

        /// <summary>
        /// This function calls a certain display list.
        /// </summary>
        /// <param name="list">The display list to call.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glCallList", SetLastError = true)]
        private static extern void glCallList(uint list);

        /// <summary>
        /// Execute	a list of display lists.
        /// </summary>
        /// <param name="n">Specifies the number of display lists to be executed.</param>
        /// <param name="type">Specifies the type of values in lists. Symbolic constants GL.BYTE, GL.UNSIGNED_BYTE, GL.SHORT, GL.UNSIGNED_SHORT, GL.INT, GL.UNSIGNED_INT, GL.FLOAT, GL.2_BYTES, GL.3_BYTES and GL.4_BYTES are accepted.</param>
        /// <param name="lists">Specifies the address of an array of name offsets in the display list. The pointer type is void because the offsets can be bytes, shorts, ints, or floats, depending on the value of type.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glCallLists", SetLastError = true)]
        private static extern void glCallLists(int n, uint type, IntPtr lists);

        /// <summary>
        /// Execute	a list of display lists. Automatically uses the GL_UNSIGNED_INT version of the function.
        /// </summary>
        /// <param name="n">The number of lists.</param>
        /// <param name="type"></param>
        /// <param name="lists">The lists.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glCallLists", SetLastError = true)]
        private static extern void glCallLists(int n, uint type, uint[] lists);

        /// <summary>
        /// Execute	a list of display lists. Automatically uses the GL_UNSIGNED_BYTE version of the function.
        /// </summary>
        /// <param name="n">The number of lists.</param>
        /// <param name="type"></param>
        /// <param name="lists">The lists.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glCallLists", SetLastError = true)]
        private static extern void glCallLists(int n, uint type, byte[] lists);

        /// <summary>
        /// This function clears the buffers specified by mask.
        /// </summary>
        /// <param name="mask">Which buffers to clear.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glClear", SetLastError = true)]
        private static extern void glClear(uint mask);

        ///// <summary>
        ///// This function clears the buffers specified by mask.
        ///// </summary>
        ///// <param name="mask">Which buffers to clear.</param>
        //public static void Clear(ClearBufferMask mask)
        //{
        //    SoftGL.Instance.Clear((uint)mask);
        //}

        /// <summary>
        /// Specify clear values for the accumulation buffer.
        /// </summary>
        /// <param name="red">Specify the red, green, blue and alpha values used when the accumulation buffer is cleared. The initial values are all 0.</param>
        /// <param name="green">Specify the red, green, blue and alpha values used when the accumulation buffer is cleared. The initial values are all 0.</param>
        /// <param name="blue">Specify the red, green, blue and alpha values used when the accumulation buffer is cleared. The initial values are all 0.</param>
        /// <param name="alpha">Specify the red, green, blue and alpha values used when the accumulation buffer is cleared. The initial values are all 0.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glClearAccum", SetLastError = true)]
        private static extern void glClearAccum(float red, float green, float blue, float alpha);

        /// <summary>
        /// This function sets the color that the drawing buffer is 'cleared' to.
        /// </summary>
        /// <param name="red">Red component of the color (between 0 and 1).</param>
        /// <param name="green">Green component of the color (between 0 and 1).</param>
        /// <param name="blue">Blue component of the color (between 0 and 1)./</param>
        /// <param name="alpha">Alpha component of the color (between 0 and 1).</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glClearColor", SetLastError = true)]
        internal static extern void glClearColor(float red, float green, float blue, float alpha);

        /// <summary>
        /// Specify the clear value for the depth buffer.
        /// </summary>
        /// <param name="depth">Specifies the depth value used	when the depth buffer is cleared. The initial value is 1.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glClearDepth", SetLastError = true)]
        private static extern void glClearDepth(double depth);

        /// <summary>
        /// Specify the clear value for the color index buffers.
        /// </summary>
        /// <param name="c">Specifies the index used when the color index buffers are cleared. The initial value is 0.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glClearIndex", SetLastError = true)]
        private static extern void glClearIndex(float c);

        /// <summary>
        /// Specify the clear value for the stencil buffer.
        /// </summary>
        /// <param name="s">Specifies the index used when the stencil buffer is cleared. The initial value is 0.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glClearStencil", SetLastError = true)]
        private static extern void glClearStencil(int s);

        /// <summary>
        /// Specify a plane against which all geometry is clipped.
        /// <para>https://www.GL.org/sdk/docs/man2/xhtml/glClipPlane.xml</para>
        /// </summary>
        /// <param name="plane">Specifies which clipping plane is being positioned. Symbolic names of the form GL.CLIP_PLANEi, where i is an integer between 0 and GL.MAX_CLIP_PLANES -1, are accepted.</param>
        /// <param name="equation">Specifies the address of an	array of four double-precision floating-point values. These values are interpreted as a plane equation.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glClipPlane", SetLastError = true)]
        private static extern void glClipPlane(uint plane, double[] equation);

        /// <summary>
        ///
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        //[DllImport(Win32.opengl32, EntryPoint = "glColor3b", SetLastError = true)]
        private static extern void glColor3b(byte red, byte green, byte blue);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 byte values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor3bv", SetLastError = true)]
        private static extern void glColor3bv(byte[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor3d", SetLastError = true)]
        private static extern void glColor3d(double red, double green, double blue);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 double values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor3dv", SetLastError = true)]
        private static extern void glColor3dv(double[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor3f", SetLastError = true)]
        private static extern void glColor3f(float red, float green, float blue);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 float values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor3fv", SetLastError = true)]
        private static extern void glColor3fv(float[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor3i", SetLastError = true)]
        private static extern void glColor3i(int red, int green, int blue);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 int values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor3iv", SetLastError = true)]
        private static extern void glColor3iv(int[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor3s", SetLastError = true)]
        private static extern void glColor3s(short red, short green, short blue);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 int values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor3sv", SetLastError = true)]
        private static extern void glColor3sv(short[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 255).</param>
        /// <param name="green">Green color component (between 0 and 255).</param>
        /// <param name="blue">Blue color component (between 0 and 255).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor3ub", SetLastError = true)]
        private static extern void glColor3ub(byte red, byte green, byte blue);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 int values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor3ubv", SetLastError = true)]
        private static extern void glColor3ubv(byte[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor3ui", SetLastError = true)]
        private static extern void glColor3ui(uint red, uint green, uint blue);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 unsigned int values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor3uiv", SetLastError = true)]
        private static extern void glColor3uiv(uint[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor3us", SetLastError = true)]
        private static extern void glColor3us(ushort red, ushort green, ushort blue);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 unsigned short values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor3usv", SetLastError = true)]
        private static extern void glColor3usv(ushort[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 255).</param>
        /// <param name="green">Green color component (between 0 and 255).</param>
        /// <param name="blue">Blue color component (between 0 and 255).</param>
        /// <param name="alpha">Alpha color component (between 0 and 255).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor4b", SetLastError = true)]
        private static extern void glColor4b(byte red, byte green, byte blue, byte alpha);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 byte values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor4bv", SetLastError = true)]
        private static extern void glColor4bv(byte[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component (between 0 and 255).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor4d", SetLastError = true)]
        private static extern void glColor4d(double red, double green, double blue, double alpha);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 double values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor4dv", SetLastError = true)]
        private static extern void glColor4dv(double[] v);

        ///<summary>
        ///Sets the current color.
        ///</summary>
        ///<param name="red">Red color component (between 0 and 1).</param>
        ///<param name="green">Green color component (between 0 and 1).</param>
        ///<param name="blue">Blue color component (between 0 and 1).</param>
        ///<param name="alpha">Alpha color component (between 0 and 1).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor4f", SetLastError = true)]
        private static extern void glColor4f(float red, float green, float blue, float alpha);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 float values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor4fv", SetLastError = true)]
        private static extern void glColor4fv(float[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor4i", SetLastError = true)]
        private static extern void glColor4i(int red, int green, int blue, int alpha);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 int values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor4iv", SetLastError = true)]
        private static extern void glColor4iv(int[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor4s", SetLastError = true)]
        private static extern void glColor4s(short red, short green, short blue, short alpha);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 int values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor4sv", SetLastError = true)]
        private static extern void glColor4sv(short[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 255).</param>
        /// <param name="green">Green color component (between 0 and 255).</param>
        /// <param name="blue">Blue color component (between 0 and 255).</param>
        /// <param name="alpha">Alpha color component (between 0 and 255).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor4ub", SetLastError = true)]
        private static extern void glColor4ub(byte red, byte green, byte blue, byte alpha);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 int values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor4ubv", SetLastError = true)]
        private static extern void glColor4ubv(byte[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor4ui", SetLastError = true)]
        private static extern void glColor4ui(uint red, uint green, uint blue, uint alpha);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 unsigned int values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor4uiv", SetLastError = true)]
        private static extern void glColor4uiv(uint[] v);

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor4us", SetLastError = true)]
        private static extern void glColor4us(ushort red, ushort green, ushort blue, ushort alpha);

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 unsigned short values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glColor4usv", SetLastError = true)]
        private static extern void glColor4usv(ushort[] v);

        /// <summary>
        /// enable and disable writing of frame buffer color components.
        /// <para>Specify whether red, green, blue, and alpha can or cannot be written into the frame buffer. The initial values are all GL_TRUE, indicating that the color components can be written.</para>
        /// <para>glGet with argument GL_COLOR_WRITEMASK.</para>
        /// </summary>
        /// <param name="redWritable">Red component mask.</param>
        /// <param name="greenWritable">Green component mask.</param>
        /// <param name="blueWritable">Blue component mask.</param>
        /// <param name="alphaWritable">Alpha component mask.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glColorMask", SetLastError = true)]
        private static extern void glColorMask(bool redWritable, bool greenWritable, bool blueWritable, bool alphaWritable);

        /// <summary>
        /// Cause a material color to track the current color.
        /// </summary>
        /// <param name="face">Specifies whether front, back, or both front and back material parameters should track the current color. Accepted values are GL.FRONT, GL.BACK, and GL.FRONT_AND_BACK. The initial value is GL.FRONT_AND_BACK.</param>
        /// <param name="mode">Specifies which	of several material parameters track the current color. Accepted values are	GL.EMISSION, GL.AMBIENT, GL.DIFFUSE, GL.SPECULAR and GL.AMBIENT_AND_DIFFUSE. The initial value is GL.AMBIENT_AND_DIFFUSE.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glColorMaterial", SetLastError = true)]
        private static extern void glColorMaterial(uint face, uint mode);

        /// <summary>
        /// Define an array of colors.
        /// </summary>
        /// <param name="size">Specifies the number	of components per color. Must be 3	or 4.</param>
        /// <param name="type">Specifies the data type of each color component in the array. Symbolic constants GL.BYTE, GL.UNSIGNED_BYTE, GL.SHORT, GL.UNSIGNED_SHORT, GL.INT, GL.UNSIGNED_INT, GL.FLOAT and GL.DOUBLE are accepted.</param>
        /// <param name="stride">Specifies the byte offset between consecutive colors. If stride is 0, (the initial value), the colors are understood to be tightly packed in the array.</param>
        /// <param name="pointer">Specifies a pointer to the first component of the first color element in the array.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glColorPointer", SetLastError = true)]
        private static extern void glColorPointer(int size, uint type, int stride, IntPtr pointer);

        /// <summary>
        /// Copy pixels in	the frame buffer.
        /// </summary>
        /// <param name="x">Specify the window coordinates of the lower left corner of the rectangular region of pixels to be copied.</param>
        /// <param name="y">Specify the window coordinates of the lower left corner of the rectangular region of pixels to be copied.</param>
        /// <param name="width">Specify the dimensions of the rectangular region of pixels to be copied. Both must be nonnegative.</param>
        /// <param name="height">Specify the dimensions of the rectangular region of pixels to be copied. Both must be nonnegative.</param>
        /// <param name="type">Specifies whether color values, depth values, or stencil values are to be copied. Symbolic constants GL.COLOR, GL.DEPTH, and GL.STENCIL are accepted.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glCopyPixels", SetLastError = true)]
        private static extern void glCopyPixels(int x, int y, int width, int height, uint type);

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
        //[DllImport(Win32.opengl32, EntryPoint = "glCopyTexImage1D", SetLastError = true)]
        private static extern void glCopyTexImage1D(uint target, int level, uint internalFormat, int x, int y, int width, int border);

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
        //[DllImport(Win32.opengl32, EntryPoint = "glCopyTexImage2D", SetLastError = true)]
        private static extern void glCopyTexImage2D(uint target, int level, uint internalFormat, int x, int y, int width, int height, int border);

        /// <summary>
        /// Copy a one-dimensional texture subimage.
        /// </summary>
        /// <param name="target">Specifies the target texture. Must be GL.TEXTURE_1D.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xoffset">Specifies the texel offset within the texture array.</param>
        /// <param name="x">Specify the window coordinates of the left corner of the row of pixels to be copied.</param>
        /// <param name="y">Specify the window coordinates of the left corner of the row of pixels to be copied.</param>
        /// <param name="width">Specifies the width of the texture image.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glCopyTexSubImage1D", SetLastError = true)]
        private static extern void glCopyTexSubImage1D(uint target, int level, int xoffset, int x, int y, int width);

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
        //[DllImport(Win32.opengl32, EntryPoint = "glCopyTexSubImage2D", SetLastError = true)]
        private static extern void glCopyTexSubImage2D(uint target, int level, int xoffset, int yoffset, int x, int y, int width, int height);

        /// <summary>
        /// Specify whether front- or back-facing facets can be culled.
        /// </summary>
        /// <param name="mode">Specifies whether front- or back-facing facets are candidates for culling. Symbolic constants GL.FRONT, GL.BACK, and GL.FRONT_AND_BACK are accepted. The initial	value is GL.BACK.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glCullFace", SetLastError = true)]
        private static extern void glCullFace(uint mode);

        /// <summary>
        /// This function deletes a list, or a range of lists.
        /// </summary>
        /// <param name="list">The list to delete.</param>
        /// <param name="range">The range of lists (often just 1).</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glDeleteLists", SetLastError = true)]
        private static extern void glDeleteLists(uint list, int range);

        /// <summary>
        /// This function deletes a set of Texture objects.
        /// </summary>
        /// <param name="n">Number of textures to delete.</param>
        /// <param name="textures">The array containing the names of the textures to delete.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glDeleteTextures", SetLastError = true)]
        private static extern void glDeleteTextures(int n, uint[] textures);

        ///// <summary>
        ///// This function deletes a set of sampler objects.
        ///// </summary>
        ///// <param name="n">Number of textures to delete.</param>
        ///// <param name="samplers">The array containing the names of the textures to delete.</param>
        //internal delegate void glDeleteSamplers(int n, uint[] samplers);

        /// <summary>
        /// void glDeleteFramebuffers(uint n, uint[] framebuffers);
        /// </summary>
        private static GLDelegates.void_uint_uintN glDeleteFramebuffers;

        /// <summary>
        /// This function deletes a set of Texture objects.
        /// </summary>
        /// <param name="n">Number of textures to delete.</param>
        /// <param name="framebuffers">The array containing the names of the textures to delete.</param>
        public static void DeleteFramebuffers(uint n, uint[] framebuffers)
        {
            //IntPtr ptr = Win32.wglGetCurrentContext();
            //if (ptr != IntPtr.Zero)
            {
                if (glDeleteFramebuffers == null)
                {
                    glDeleteFramebuffers = SoftGL.Instance.GetDelegateFor("glDeleteFramebuffers", GLDelegates.typeof_void_uint_uintN) as GLDelegates.void_uint_uintN;
                }
                glDeleteFramebuffers(n, framebuffers);
            }
        }

        /// <summary>
        /// void glDeleteRenderbuffers(uint n, uint[] renderbuffers);
        /// </summary>
        private static GLDelegates.void_uint_uintN glDeleteRenderbuffers;

        /// <summary>
        /// This function deletes a set of Texture objects.
        /// </summary>
        /// <param name="n">Number of textures to delete.</param>
        /// <param name="renderbuffers">The array containing the names of the textures to delete.</param>
        public static void DeleteRenderbuffers(uint n, uint[] renderbuffers)
        {
            //IntPtr ptr = Win32.wglGetCurrentContext();
            //if (ptr != IntPtr.Zero)
            {
                if (glDeleteRenderbuffers == null)
                {
                    glDeleteRenderbuffers = SoftGL.Instance.GetDelegateFor("glDeleteRenderbuffers", GLDelegates.typeof_void_uint_uintN) as GLDelegates.void_uint_uintN;
                }
                glDeleteRenderbuffers(n, renderbuffers);
            }
        }

        /// <summary>
        /// This function deletes a set of vertex buffer objects.
        /// </summary>
        /// <param name="n">Number of textures to delete.</param>
        /// <param name="buffers">The array containing the names of the buffers to delete.</param>
        public static void DeleteBuffers(int n, uint[] buffers)
        {
            //IntPtr ptr = Win32.wglGetCurrentContext();
            //if (ptr != IntPtr.Zero)
            {
                var function = SoftGL.Instance.GetDelegateFor("glDeleteBuffers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
                function(n, buffers);
            }
        }

        /// <summary>
        /// This function sets the current depth buffer comparison function, the default it LESS.
        /// </summary>
        /// <param name="func">The comparison function to set.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glDepthFunc", SetLastError = true)]
        private static extern void glDepthFunc(uint func);

        /// <summary>
        /// enable or disable writing into the depth buffer
        /// <para>允许或禁止向深度缓冲区写入数据</para>
        /// <para>glGet with argument GL_DEPTH_WRITEMASK</para>
        /// </summary>
        /// <param name="writable">Specifies whether the depth buffer is enabled for writing.If flag is GL_FALSE,depth buffer writing is disabled.Otherwise, it is enabled.Initially, depth buffer writing is enabled.
        /// <para>指定是否允许向深度缓冲区写入数据。如果flag是GL_FLASE，那么向深度缓冲区写入是禁止的。否则，就是允许的。初始时，是允许向深度缓冲区写入数据的。</para></param>
        //[DllImport(Win32.opengl32, EntryPoint = "glDepthMask", SetLastError = true)]
        private static extern void glDepthMask(bool writable);

        /// <summary>
        /// Specify mapping of depth values from normalized device coordinates	to window coordinates.
        /// </summary>
        /// <param name="zNear">Specifies the mapping of the near clipping plane to window coordinates. The initial value is 0.</param>
        /// <param name="zFar">Specifies the mapping of the near clipping plane to window coordinates. The initial value is 1.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glDepthRange", SetLastError = true)]
        private static extern void glDepthRange(double zNear, double zFar);

        /// <summary>
        /// Call this function to disable an OpenGL capability.
        /// </summary>
        /// <param name="cap">The capability to disable.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glDisable", SetLastError = true)]
        private static extern void glDisable(uint cap);

        /// <summary>
        /// This function disables a client state array, such as a vertex array.
        /// </summary>
        /// <param name="array">The array to disable.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glDisableClientState", SetLastError = true)]
        private static extern void glDisableClientState(uint array);

        /// <summary>
        /// Render	primitives from	array data.
        /// </summary>
        /// <param name="mode">Specifies what kind of primitives to render. Symbolic constants GL.POINTS, GL.LINE_STRIP, GL.LINE_LOOP, GL.LINES, GL.TRIANGLE_STRIP, GL.TRIANGLE_FAN, GL.TRIANGLES, GL.QUAD_STRIP, GL.QUADS, and GL.POLYGON are accepted.</param>
        /// <param name="first">Specifies the starting	index in the enabled arrays.</param>
        /// <param name="count">Specifies the number of vertexes to be rendered.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glDrawArrays", SetLastError = true)]
        private static extern void glDrawArrays(uint mode, int first, int count);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="first"></param>
        /// <param name="count"></param>
        /// <param name="drawcount"></param>
        //[DllImport(Win32.opengl32, EntryPoint = "glMultiDrawArrays", SetLastError = true)]
        private static extern void glMultiDrawArrays(uint mode, int[] first, int[] count, int drawcount);

        /// <summary>
        /// Specify which color buffers are to be drawn into.
        /// </summary>
        /// <param name="mode">Specifies up to	four color buffers to be drawn into. Symbolic constants GL.NONE, GL.FRONT_LEFT, GL.FRONT_RIGHT,	GL.BACK_LEFT, GL.BACK_RIGHT, GL.FRONT, GL.BACK, GL.LEFT, GL.RIGHT, GL.FRONT_AND_BACK, and GL.AUXi, where i is between 0 and (GL.AUX_BUFFERS - 1), are accepted (GL.AUX_BUFFERS is not the upper limit; use glGet to query the number of	available aux buffers.)  The initial value is GL.FRONT for single- buffered contexts, and GL.BACK for double-buffered contexts.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glDrawBuffer", SetLastError = true)]
        private static extern void glDrawBuffer(uint mode);

        /// <summary>
        /// Render primitives from array data.
        /// </summary>
        /// <param name="mode">Specifies what kind of primitives to	render. Symbolic constants GL.POINTS, GL.LINE_STRIP, GL.LINE_LOOP, GL.LINES, GL.TRIANGLE_STRIP, GL.TRIANGLE_FAN, GL.TRIANGLES, GL.QUAD_STRIP, GL.QUADS, and GL.POLYGON are accepted.</param>
        /// <param name="count">Specifies the number of elements to be rendered.</param>
        /// <param name="type">Specifies the type of the values in indices.	Must be one of GL.UNSIGNED_BYTE, GL.UNSIGNED_SHORT, or GL.UNSIGNED_INT.</param>
        /// <param name="indices">Specifies a pointer to the location where the indices are stored.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glDrawElements", SetLastError = true)]
        private static extern void glDrawElements(uint mode, int count, uint type, IntPtr indices);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="count"></param>
        /// <param name="type"></param>
        /// <param name="indices"></param>
        /// <param name="drawcount"></param>
        //[DllImport(Win32.opengl32, EntryPoint = "glMultiDrawElements", SetLastError = true)]
        private static extern void glMultiDrawElements(uint mode, int[] count, uint type, IntPtr indices, int drawcount);

        /// <summary>
        /// Render primitives from array data.
        /// </summary>
        /// <param name="mode">Specifies what kind of primitives to	render. Symbolic constants GL.POINTS, GL.LINE_STRIP, GL.LINE_LOOP, GL.LINES, GL.TRIANGLE_STRIP, GL.TRIANGLE_FAN, GL.TRIANGLES, GL.QUAD_STRIP, GL.QUADS, and GL.POLYGON are accepted.</param>
        /// <param name="count">Specifies the number of elements to be rendered.</param>
        /// <param name="type"></param>
        /// <param name="indices">Specifies a pointer to the location where the indices are stored.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glDrawElements", SetLastError = true)]
        private static extern void glDrawElements(uint mode, int count, uint type, uint[] indices);

        /// <summary>
        /// Render primitives from array data.
        /// </summary>
        /// <param name="mode">Specifies what kind of primitives to	render. Symbolic constants GL.POINTS, GL.LINE_STRIP, GL.LINE_LOOP, GL.LINES, GL.TRIANGLE_STRIP, GL.TRIANGLE_FAN, GL.TRIANGLES, GL.QUAD_STRIP, GL.QUADS, and GL.POLYGON are accepted.</param>
        /// <param name="count">Specifies the number of elements to be rendered.</param>
        /// <param name="type"></param>
        /// <param name="indices">Specifies a pointer to the location where the indices are stored.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glDrawElements", SetLastError = true)]
        private static extern void glDrawElements(uint mode, int count, uint type, ushort[] indices);

        /// <summary>
        /// Render primitives from array data.
        /// </summary>
        /// <param name="mode">Specifies what kind of primitives to	render. Symbolic constants GL.POINTS, GL.LINE_STRIP, GL.LINE_LOOP, GL.LINES, GL.TRIANGLE_STRIP, GL.TRIANGLE_FAN, GL.TRIANGLES, GL.QUAD_STRIP, GL.QUADS, and GL.POLYGON are accepted.</param>
        /// <param name="count">Specifies the number of elements to be rendered.</param>
        /// <param name="type"></param>
        /// <param name="indices">Specifies a pointer to the location where the indices are stored.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glDrawElements", SetLastError = true)]
        private static extern void glDrawElements(uint mode, int count, uint type, byte[] indices);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="count"></param>
        /// <param name="type"></param>
        /// <param name="indices"></param>
        /// <param name="drawcount"></param>
        //[DllImport(Win32.opengl32, EntryPoint = "glMultiDrawElements", SetLastError = true)]
        private static extern void glMultiDrawElements(uint mode, int[] count, uint type, uint[] indices, int drawcount);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="count"></param>
        /// <param name="type"></param>
        /// <param name="indices"></param>
        /// <param name="drawcount"></param>
        //[DllImport(Win32.opengl32, EntryPoint = "glMultiDrawElements", SetLastError = true)]
        private static extern void glMultiDrawElements(uint mode, int[] count, uint type, ushort[] indices, int drawcount);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="count"></param>
        /// <param name="type"></param>
        /// <param name="indices"></param>
        /// <param name="drawcount"></param>
        //[DllImport(Win32.opengl32, EntryPoint = "glMultiDrawElements", SetLastError = true)]
        private static extern void glMultiDrawElements(uint mode, int[] count, uint type, byte[] indices, int drawcount);

        /// <summary>
        /// Draws a rectangle of pixel data at the current raster position.
        /// </summary>
        /// <param name="width">Width of pixel data.</param>
        /// <param name="height">Height of pixel data.</param>
        /// <param name="format">Format of pixel data.</param>
        /// <param name="type"></param>
        /// <param name="pixels">Pixel data buffer.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glDrawPixels", SetLastError = true)]
        private static extern void glDrawPixels(int width, int height, uint format, uint type, float[] pixels);

        /// <summary>
        /// Draws a rectangle of pixel data at the current raster position.
        /// </summary>
        /// <param name="width">Width of pixel data.</param>
        /// <param name="height">Height of pixel data.</param>
        /// <param name="format">Format of pixel data.</param>
        /// <param name="type"></param>
        /// <param name="pixels">Pixel data buffer.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glDrawPixels", SetLastError = true)]
        private static extern void glDrawPixels(int width, int height, uint format, uint type, uint[] pixels);

        /// <summary>
        /// Draws a rectangle of pixel data at the current raster position.
        /// </summary>
        /// <param name="width">Width of pixel data.</param>
        /// <param name="height">Height of pixel data.</param>
        /// <param name="format">Format of pixel data.</param>
        /// <param name="type"></param>
        /// <param name="pixels">Pixel data buffer.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glDrawPixels", SetLastError = true)]
        private static extern void glDrawPixels(int width, int height, uint format, uint type, ushort[] pixels);

        /// <summary>
        /// Draws a rectangle of pixel data at the current raster position.
        /// </summary>
        /// <param name="width">Width of pixel data.</param>
        /// <param name="height">Height of pixel data.</param>
        /// <param name="format">Format of pixel data.</param>
        /// <param name="type"></param>
        /// <param name="pixels">Pixel data buffer.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glDrawPixels", SetLastError = true)]
        private static extern void glDrawPixels(int width, int height, uint format, uint type, byte[] pixels);

        /// <summary>
        /// Draws a rectangle of pixel data at the current raster position.
        /// </summary>
        /// <param name="width">Width of pixel data.</param>
        /// <param name="height">Height of pixel data.</param>
        /// <param name="format">Format of pixel data.</param>
        /// <param name="type">The GL data type.</param>
        /// <param name="pixels">Pixel data buffer.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glDrawPixels", SetLastError = true)]
        private static extern void glDrawPixels(int width, int height, uint format, uint type, IntPtr pixels);

        /// <summary>
        /// Flag edges as either boundary or nonboundary.
        /// </summary>
        /// <param name="flag">Specifies the current edge flag	value, either GL.TRUE or GL.FALSE. The initial value is GL.TRUE.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glEdgeFlag", SetLastError = true)]
        private static extern void glEdgeFlag(byte flag);

        /// <summary>
        /// Define an array of edge flags.
        /// </summary>
        /// <param name="stride">Specifies the byte offset between consecutive edge flags. If stride is	0 (the initial value), the edge	flags are understood to	be tightly packed in the array.</param>
        /// <param name="pointer">Specifies a pointer to the first edge flag in the array.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glEdgeFlagPointer", SetLastError = true)]
        private static extern void glEdgeFlagPointer(int stride, int[] pointer);

        /// <summary>
        /// Flag edges as either boundary or nonboundary.
        /// </summary>
        /// <param name="flag">Specifies a pointer to an array that contains a single boolean element,	which replaces the current edge	flag value.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glEdgeFlagv", SetLastError = true)]
        private static extern void glEdgeFlagv(byte[] flag);

        /// <summary>
        /// Call this function to enable an OpenGL capability.
        /// </summary>
        /// <param name="cap">The capability you wish to enable.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glEnable", SetLastError = true)]
        private static extern void glEnable(uint cap);

        /// <summary>
        /// This function enables one of the client state arrays, such as a vertex array.
        /// </summary>
        /// <param name="array">The array to enable.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glEnableClientState", SetLastError = true)]
        private static extern void glEnableClientState(uint array);

        /// <summary>
        ///
        /// </summary>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glEnd", SetLastError = true)]
        private static extern void glEnd();

        /// <summary>
        /// Ends the current display list compilation.
        /// </summary>
        //[DllImport(Win32.opengl32, EntryPoint = "glEndList", SetLastError = true)]
        private static extern void glEndList();

        /// <summary>
        /// Evaluate from the current evaluator.
        /// <para>Calls glVertex() inside.</para>
        /// </summary>
        /// <param name="u">Domain coordinate.</param>

        //[DllImport(Win32.opengl32, EntryPoint = "glEvalCoord1d", SetLastError = true)]
        private static extern void glEvalCoord1d(double u);

        /// <summary>
        /// Evaluate from the current evaluator.
        /// <para>Calls glVertex() inside.</para>
        /// </summary>
        /// <param name="u">Domain coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glEvalCoord1dv", SetLastError = true)]
        private static extern void glEvalCoord1dv(double[] u);

        /// <summary>
        /// Evaluate from the current evaluator.
        /// <para>Calls glVertex() inside.</para>
        /// </summary>
        /// <param name="u">Domain coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glEvalCoord1f", SetLastError = true)]
        private static extern void glEvalCoord1f(float u);

        /// <summary>
        /// Evaluate from the current evaluator.
        /// <para>Calls glVertex() inside.</para>
        /// </summary>
        /// <param name="u">Domain coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glEvalCoord1fv", SetLastError = true)]
        private static extern void glEvalCoord1fv(float[] u);

        /// <summary>
        /// Evaluate from the current evaluator.
        /// <para>Calls glVertex() inside.</para>
        /// </summary>
        /// <param name="u">Domain coordinate.</param>
        /// <param name="v">Domain coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glEvalCoord2d", SetLastError = true)]
        private static extern void glEvalCoord2d(double u, double v);

        /// <summary>
        /// Evaluate from the current evaluator.
        /// <para>Calls glVertex() inside.</para>
        /// </summary>
        /// <param name="u">Domain coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glEvalCoord2dv", SetLastError = true)]
        private static extern void glEvalCoord2dv(double[] u);

        /// <summary>
        /// Evaluate from the current evaluator.
        /// <para>Calls glVertex() inside.</para>
        /// </summary>
        /// <param name="u">Domain coordinate.</param>
        /// <param name="v">Domain coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glEvalCoord2f", SetLastError = true)]
        private static extern void glEvalCoord2f(float u, float v);

        /// <summary>
        /// Evaluate from the current evaluator.
        /// <para>Calls glVertex() inside.</para>
        /// </summary>
        /// <param name="u">Domain coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glEvalCoord2fv", SetLastError = true)]
        private static extern void glEvalCoord2fv(float[] u);

        /// <summary>
        /// Evaluates a 'mesh' from the current evaluators.
        /// </summary>
        /// <param name="mode">Drawing mode, can be POINT or LINE.</param>
        /// <param name="i1">Beginning of range.</param>
        /// <param name="i2">End of range.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glEvalMesh1", SetLastError = true)]
        private static extern void glEvalMesh1(uint mode, int i1, int i2);

        /// <summary>
        /// Evaluates a 'mesh' from the current evaluators.
        /// </summary>
        /// <param name="mode">Drawing mode, fill, point or line.</param>
        /// <param name="i1">Beginning of range.</param>
        /// <param name="i2">End of range.</param>
        /// <param name="j1">Beginning of range.</param>
        /// <param name="j2">End of range.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glEvalMesh2", SetLastError = true)]
        private static extern void glEvalMesh2(uint mode, int i1, int i2, int j1, int j2);

        /// <summary>
        /// Generate and evaluate a single point in a mesh.
        /// </summary>
        /// <param name="i">The integer value for grid domain variable i.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glEvalPoint1", SetLastError = true)]
        private static extern void glEvalPoint1(int i);

        /// <summary>
        /// Generate and evaluate a single point in a mesh.
        /// </summary>
        /// <param name="i">The integer value for grid domain variable i.</param>
        /// <param name="j">The integer value for grid domain variable j.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glEvalPoint2", SetLastError = true)]
        private static extern void glEvalPoint2(int i, int j);

        /// <summary>
        /// This function sets the feedback buffer, that will receive feedback data.
        /// </summary>
        /// <param name="size">Size of the buffer.</param>
        /// <param name="type">Type of data in the buffer.</param>
        /// <param name="buffer">The buffer itself.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glFeedbackBuffer", SetLastError = true)]
        private static extern void glFeedbackBuffer(int size, uint type, float[] buffer);

        /// <summary>
        /// This function is similar to flush, but in a sense does it more, as it
        /// executes all commands aon both the client and the server.
        /// </summary>

        //[DllImport(Win32.opengl32, EntryPoint = "glFinish", SetLastError = true)]
        private static extern void glFinish();

        /// <summary>
        /// This forces OpenGL to execute any commands you have given it.
        /// </summary>
        //[DllImport(Win32.opengl32, EntryPoint = "glFlush", SetLastError = true)]
        private static extern void glFlush();

        /// <summary>
        /// Sets a fog parameter.
        /// </summary>
        /// <param name="pname">The parameter to set.</param>
        /// <param name="param">The value to set it to.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glFogf", SetLastError = true)]
        private static extern void glFogf(uint pname, float param);

        /// <summary>
        /// Sets a fog parameter.
        /// </summary>
        /// <param name="pname">The parameter to set.</param>
        /// <param name="parameters">The values to set it to.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glFogfv", SetLastError = true)]
        private static extern void glFogfv(uint pname, float[] parameters);

        /// <summary>
        /// Sets a fog parameter.
        /// </summary>
        /// <param name="pname">The parameter to set.</param>
        /// <param name="param">The value to set it to.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glFogi", SetLastError = true)]
        private static extern void glFogi(uint pname, int param);

        /// <summary>
        /// Sets a fog parameter.
        /// </summary>
        /// <param name="pname">The parameter to set.</param>
        /// <param name="parameters">The values to set it to.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glFogiv", SetLastError = true)]
        private static extern void glFogiv(uint pname, int[] parameters);

        /// <summary>
        /// This function sets what defines a front face. Counter ClockWise by default.
        /// <para>作用是控制多边形的正面是如何决定的。在默认情况下，mode是GL_CCW。</para>
        /// </summary>
        /// <param name="mode">Winding mode, counter clockwise by default.
        /// <para>GL_CCW 表示窗口坐标上投影多边形的顶点顺序为逆时针方向的表面为正面。</para>
        /// <para>GL_CW 表示顶点顺序为顺时针方向的表面为正面。</para></param>
        //[DllImport(Win32.opengl32, EntryPoint = "glFrontFace", SetLastError = true)]
        private static extern void glFrontFace(uint mode);

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
        //[DllImport(Win32.opengl32, EntryPoint = "glFrustum", SetLastError = true)]
        private static extern void glFrustum(double left, double right, double bottom, double top, double zNear, double zFar);

        /// <summary>
        /// This function generates 'range' number of contiguos display list indices.
        /// </summary>
        /// <param name="range">The number of lists to generate.</param>
        /// <returns>The first list.</returns>
        //[DllImport(Win32.opengl32, EntryPoint = "glGenLists", SetLastError = true)]
        private static extern uint glGenLists(int range);

        /// <summary>
        /// Create a set of unique texture names.
        /// </summary>
        /// <param name="n">Number of names to create.</param>
        /// <param name="textures">Array to store the texture names.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGenTextures", SetLastError = true)]
        private static extern void glGenTextures(int n, uint[] textures);

        ///// <summary>
        ///// </summary>
        ///// <param name="n"></param>
        ///// <param name="textures"></param>

        /// <summary>
        /// generate sampler object names
        /// void glGenSamplers(int n, uint[] textures);
        /// </summary>
        private static GLDelegates.void_int_uintN glGenSamplers;

        /// <summary>
        ///
        /// </summary>
        /// <param name="n"></param>
        /// <param name="textures"></param>
        public static void GenSamplers(int n, uint[] textures)
        {
            if (glGenSamplers == null)
            {
                glGenSamplers = SoftGL.Instance.GetDelegateFor("glGenSamplers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
            }
            glGenSamplers(n, textures);
        }

        /// <summary>
        /// This function queries OpenGL for data, and puts it in the buffer supplied.
        /// </summary>
        /// <param name="pname">The parameter to query.</param>
        /// <param name="parameters"></param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetBooleanv", SetLastError = true)]
        private static extern void glGetBooleanv(uint pname, byte[] parameters);

        /// <summary>
        /// Return the coefficients of the specified clipping plane.
        /// </summary>
        /// <param name="plane">Specifies a	clipping plane.	 The number of clipping planes depends on the implementation, but at least six clipping planes are supported. They are identified by symbolic names of the form GL.CLIP_PLANEi where 0 Less Than i Less Than GL.MAX_CLIP_PLANES.</param>
        /// <param name="equation">Returns four double-precision values that are the coefficients of the plane equation of plane in eye coordinates. The initial value is (0, 0, 0, 0).</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetClipPlane", SetLastError = true)]
        private static extern void glGetClipPlane(uint plane, double[] equation);

        /// <summary>
        /// This function queries OpenGL for data, and puts it in the buffer supplied.
        /// </summary>
        /// <param name="pname">The parameter to query.</param>
        /// <param name="parameters">The buffer to put that data into.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetDoublev", SetLastError = true)]
        private static extern void glGetDoublev(uint pname, double[] parameters);

        /// <summary>
        /// Get the current OpenGL error code.
        /// </summary>
        /// <returns>The current OpenGL error code.</returns>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetError", SetLastError = true)]
        private static extern uint glGetError();

        /// <summary>
        /// This this function to query OpenGL values.
        /// </summary>
        /// <param name="pname">The parameter to query.</param>
        /// <param name="parameters">The parameters</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetFloatv", SetLastError = true)]
        private static extern void glGetFloatv(uint pname, float[] parameters);

        /// <summary>
        /// Use this function to query OpenGL parameter values.
        /// </summary>
        /// <param name="pname">The Parameter to query</param>
        /// <param name="parameters">An array to put the values into.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetIntegerv", SetLastError = true)]
        private static extern void glGetIntegerv(uint pname, int[] parameters);

        /// <summary>
        /// Return light source parameter values.
        /// </summary>
        /// <param name="light">Specifies a light source. The number of possible lights depends on the implementation, but at least eight lights are supported. They are identified by symbolic names of the form GL.LIGHTi where i ranges from 0 to the value of GL.GL_MAX_LIGHTS - 1.</param>
        /// <param name="pname">Specifies a light source parameter for light.</param>
        /// <param name="parameters">Returns the requested data.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetLightfv", SetLastError = true)]
        private static extern void glGetLightfv(uint light, uint pname, float[] parameters);

        /// <summary>
        /// Return light source parameter values.
        /// </summary>
        /// <param name="light">Specifies a light source. The number of possible lights depends on the implementation, but at least eight lights are supported. They are identified by symbolic names of the form GL.LIGHTi where i ranges from 0 to the value of GL.GL_MAX_LIGHTS - 1.</param>
        /// <param name="pname">Specifies a light source parameter for light.</param>
        /// <param name="parameters">Returns the requested data.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetLightiv", SetLastError = true)]
        private static extern void glGetLightiv(uint light, uint pname, int[] parameters);

        /// <summary>
        /// Return evaluator parameters.
        /// </summary>
        /// <param name="target">Specifies the symbolic name of a map.</param>
        /// <param name="query">Specifies which parameter to return.</param>
        /// <param name="v">Returns the requested data.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetMapdv", SetLastError = true)]
        private static extern void glGetMapdv(uint target, uint query, double[] v);

        /// <summary>
        /// Return evaluator parameters.
        /// </summary>
        /// <param name="target">Specifies the symbolic name of a map.</param>
        /// <param name="query">Specifies which parameter to return.</param>
        /// <param name="v">Returns the requested data.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetMapfv", SetLastError = true)]
        private static extern void glGetMapfv(uint target, uint query, float[] v);

        /// <summary>
        /// Return evaluator parameters.
        /// </summary>
        /// <param name="target">Specifies the symbolic name of a map.</param>
        /// <param name="query">Specifies which parameter to return.</param>
        /// <param name="v">Returns the requested data.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetMapiv", SetLastError = true)]
        private static extern void glGetMapiv(uint target, uint query, int[] v);

        /// <summary>
        /// Return material parameters.
        /// </summary>
        /// <param name="face">Specifies which of the two materials is being queried. GL.FRONT or GL.BACK are accepted, representing the front and back materials, respectively.</param>
        /// <param name="pname">Specifies the material parameter to return.</param>
        /// <param name="parameters">Returns the requested data.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetMaterialfv", SetLastError = true)]
        private static extern void glGetMaterialfv(uint face, uint pname, float[] parameters);

        /// <summary>
        /// Return material parameters.
        /// </summary>
        /// <param name="face">Specifies which of the two materials is being queried. GL.FRONT or GL.BACK are accepted, representing the front and back materials, respectively.</param>
        /// <param name="pname">Specifies the material parameter to return.</param>
        /// <param name="parameters">Returns the requested data.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetMaterialiv", SetLastError = true)]
        private static extern void glGetMaterialiv(uint face, uint pname, int[] parameters);

        /// <summary>
        /// Return the specified pixel map.
        /// </summary>
        /// <param name="map">Specifies the	name of	the pixel map to return.</param>
        /// <param name="values">Returns the pixel map	contents.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetPixelMapfv", SetLastError = true)]
        private static extern void glGetPixelMapfv(uint map, float[] values);

        /// <summary>
        /// Return the specified pixel map.
        /// </summary>
        /// <param name="map">Specifies the	name of	the pixel map to return.</param>
        /// <param name="values">Returns the pixel map	contents.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetPixelMapuiv", SetLastError = true)]
        private static extern void glGetPixelMapuiv(uint map, uint[] values);

        /// <summary>
        /// Return the specified pixel map.
        /// </summary>
        /// <param name="map">Specifies the	name of	the pixel map to return.</param>
        /// <param name="values">Returns the pixel map	contents.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetPixelMapusv", SetLastError = true)]
        private static extern void glGetPixelMapusv(uint map, ushort[] values);

        /// <summary>
        /// Return the address of the specified pointer.
        /// </summary>
        /// <param name="pname">Specifies the array or buffer pointer to be returned.</param>
        /// <param name="parameters">Returns the pointer value specified by parameters.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetPointerv", SetLastError = true)]
        private static extern void glGetPointerv(uint pname, int[] parameters);

        /// <summary>
        /// Return the polygon stipple pattern.
        /// </summary>
        /// <param name="mask">Returns the stipple pattern. The initial value is all 1's.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetPolygonStipple", SetLastError = true)]
        private static extern void glGetPolygonStipple(byte[] mask);

        /// <summary>
        /// Return a string	describing the current GL connection.
        /// </summary>
        /// <param name="name">Specifies a symbolic constant, one of GL.VENDOR, GL.RENDERER, GL.VERSION, or GL.EXTENSIONS.</param>
        /// <returns>Pointer to the specified string.</returns>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetString", SetLastError = true)]
        private unsafe static extern sbyte* glGetString(uint name);

        /// <summary>
        /// Return texture environment parameters.
        /// </summary>
        /// <param name="target">Specifies a texture environment.  Must be GL.TEXTURE_ENV.</param>
        /// <param name="pname">Specifies the	symbolic name of a texture environment parameter.  Accepted values are GL.TEXTURE_ENV_MODE, and GL.TEXTURE_ENV_COLOR.</param>
        /// <param name="parameters">Returns the requested	data.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetTexEnvfv", SetLastError = true)]
        private static extern void glGetTexEnvfv(uint target, uint pname, float[] parameters);

        /// <summary>
        /// Return texture environment parameters.
        /// </summary>
        /// <param name="target">Specifies a texture environment.  Must be GL.TEXTURE_ENV.</param>
        /// <param name="pname">Specifies the	symbolic name of a texture environment parameter.  Accepted values are GL.TEXTURE_ENV_MODE, and GL.TEXTURE_ENV_COLOR.</param>
        /// <param name="parameters">Returns the requested	data.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetTexEnviv", SetLastError = true)]
        private static extern void glGetTexEnviv(uint target, uint pname, int[] parameters);

        /// <summary>
        /// Control the generation of texture coordinates.
        /// </summary>
        /// <param name="coord">Specifies a texture coordinate. Must be one of GL.S, GL.T, GL.R, or GL.Q.</param>
        /// <param name="pname">Specifies the symbolic name of the texture-coordinate generation function. Must be GL.TEXTURE_GEN_MODE.</param>
        /// <param name="parameters">Specifies a single-valued texture generation parameter, one of GL.OBJECT_LINEAR, GL.EYE_LINEAR, or GL.SPHERE_MAP.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetTexGendv", SetLastError = true)]
        private static extern void glGetTexGendv(uint coord, uint pname, double[] parameters);

        /// <summary>
        /// Control the generation of texture coordinates.
        /// </summary>
        /// <param name="coord">Specifies a texture coordinate. Must be one of GL.S, GL.T, GL.R, or GL.Q.</param>
        /// <param name="pname">Specifies the symbolic name of the texture-coordinate generation function. Must be GL.TEXTURE_GEN_MODE.</param>
        /// <param name="parameters">Specifies a single-valued texture generation parameter, one of GL.OBJECT_LINEAR, GL.EYE_LINEAR, or GL.SPHERE_MAP.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetTexGenfv", SetLastError = true)]
        private static extern void glGetTexGenfv(uint coord, uint pname, float[] parameters);

        /// <summary>
        /// Control the generation of texture coordinates.
        /// </summary>
        /// <param name="coord">Specifies a texture coordinate. Must be one of GL.S, GL.T, GL.R, or GL.Q.</param>
        /// <param name="pname">Specifies the symbolic name of the texture-coordinate generation function. Must be GL.TEXTURE_GEN_MODE.</param>
        /// <param name="parameters">Specifies a single-valued texture generation parameter, one of GL.OBJECT_LINEAR, GL.EYE_LINEAR, or GL.SPHERE_MAP.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetTexGeniv", SetLastError = true)]
        private static extern void glGetTexGeniv(uint coord, uint pname, int[] parameters);

        /// <summary>
        /// Return a texture image.
        /// </summary>
        /// <param name="target">Specifies which texture is to	be obtained. GL.TEXTURE_1D and GL.TEXTURE_2D are accepted.</param>
        /// <param name="level">Specifies the level-of-detail number of the desired image.  Level	0 is the base image level.  Level n is the nth mipmap reduction image.</param>
        /// <param name="format">Specifies a pixel format for the returned data.</param>
        /// <param name="type">Specifies a pixel type for the returned data.</param>
        /// <param name="pixels">Returns the texture image.  Should be	a pointer to an array of the type specified by type.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetTexImage", SetLastError = true)]
        private static extern void glGetTexImage(uint target, int level, uint format, uint type, IntPtr pixels);

        /// <summary>
        /// Return texture parameter values for a specific level of detail.
        /// </summary>
        /// <param name="target">Specifies the	symbolic name of the target texture.</param>
        /// <param name="level">Specifies the level-of-detail	number of the desired image.  Level	0 is the base image level.  Level n is the nth mipmap reduction image.</param>
        /// <param name="pname">Specifies the symbolic name of a texture parameter.</param>
        /// <param name="parameters">Returns the requested	data.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetTexLevelParameterfv", SetLastError = true)]
        private static extern void glGetTexLevelParameterfv(uint target, int level, uint pname, float[] parameters);

        /// <summary>
        /// Return texture parameter values for a specific level of detail.
        /// </summary>
        /// <param name="target">Specifies the	symbolic name of the target texture.</param>
        /// <param name="level">Specifies the level-of-detail	number of the desired image.  Level	0 is the base image level.  Level n is the nth mipmap reduction image.</param>
        /// <param name="pname">Specifies the symbolic name of a texture parameter.</param>
        /// <param name="parameters">Returns the requested	data.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetTexLevelParameteriv", SetLastError = true)]
        private static extern void glGetTexLevelParameteriv(uint target, int level, uint pname, int[] parameters);

        /// <summary>
        /// Return texture parameter values.
        /// </summary>
        /// <param name="target">Specifies the symbolic name of the target texture.</param>
        /// <param name="pname">Specifies the symbolic name of a texture parameter.</param>
        /// <param name="parameters">Returns the texture parameters.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetTexParameterfv", SetLastError = true)]
        private static extern void glGetTexParameterfv(uint target, uint pname, float[] parameters);

        /// <summary>
        /// Return texture parameter values.
        /// </summary>
        /// <param name="target">Specifies the symbolic name of the target texture.</param>
        /// <param name="pname">Specifies the symbolic name of a texture parameter.</param>
        /// <param name="parameters">Returns the texture parameters.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glGetTexParameteriv", SetLastError = true)]
        private static extern void glGetTexParameteriv(uint target, uint pname, int[] parameters);

        /// <summary>
        /// Specify implementation-specific hints.
        /// </summary>
        /// <param name="target">Specifies a symbolic constant indicating the behavior to be controlled.</param>
        /// <param name="mode">Specifies a symbolic constant indicating the desired behavior.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glHint", SetLastError = true)]
        private static extern void glHint(uint target, uint mode);

        /// <summary>
        /// Control	the writing of individual bits in the color	index buffers.
        /// </summary>
        /// <param name="mask">Specifies a bit	mask to	enable and disable the writing of individual bits in the color index buffers. Initially, the mask is all 1's.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glIndexMask", SetLastError = true)]
        private static extern void glIndexMask(uint mask);

        /// <summary>
        /// Define an array of color indexes.
        /// </summary>
        /// <param name="type">Specifies the data type of each color index in the array.  Symbolic constants GL.UNSIGNED_BYTE, GL.SHORT, GL.INT, GL.FLOAT, and GL.DOUBLE are accepted.</param>
        /// <param name="stride">Specifies the byte offset between consecutive color indexes.  If stride is 0 (the initial value), the color indexes are understood	to be tightly packed in the array.</param>
        /// <param name="pointer">Specifies a pointer to the first index in the array.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glIndexPointer", SetLastError = true)]
        private static extern void glIndexPointer(uint type, int stride, int[] pointer);

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glIndexd", SetLastError = true)]
        private static extern void glIndexd(double c);

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glIndexdv", SetLastError = true)]
        private static extern void glIndexdv(double[] c);

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glIndexf", SetLastError = true)]
        private static extern void glIndexf(float c);

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glIndexfv", SetLastError = true)]
        private static extern void glIndexfv(float[] c);

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glIndexi", SetLastError = true)]
        private static extern void glIndexi(int c);

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glIndexiv", SetLastError = true)]
        private static extern void glIndexiv(int[] c);

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glIndexs", SetLastError = true)]
        private static extern void glIndexs(short c);

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glIndexsv", SetLastError = true)]
        private static extern void glIndexsv(short[] c);

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glIndexub", SetLastError = true)]
        private static extern void glIndexub(byte c);

        /// <summary>
        /// Set the current color index.
        /// </summary>
        /// <param name="c">Specifies the new value for the current color index.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glIndexubv", SetLastError = true)]
        private static extern void glIndexubv(byte[] c);

        /// <summary>
        /// This function initialises the select buffer names.
        /// </summary>
        //[DllImport(Win32.opengl32, EntryPoint = "glInitNames", SetLastError = true)]
        private static extern void glInitNames();

        /// <summary>
        /// Simultaneously specify and enable several interleaved arrays.
        /// </summary>
        /// <param name="format">Specifies the type of array to enable.</param>
        /// <param name="stride">Specifies the offset in bytes between each aggregate array element.</param>
        /// <param name="pointer">The array.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glInterleavedArrays", SetLastError = true)]
        private static extern void glInterleavedArrays(uint format, int stride, int[] pointer);

        /// <summary>
        /// Use this function to query if a certain OpenGL function is enabled or not.
        /// </summary>
        /// <param name="cap">The capability to test.</param>
        /// <returns>True if the capability is enabled, otherwise, false.</returns>
        //[DllImport(Win32.opengl32, EntryPoint = "glIsEnabled", SetLastError = true)]
        private static extern byte glIsEnabled(uint cap);

        /// <summary>
        /// This function determines whether a specified value is a display list.
        /// </summary>
        /// <param name="list">The value to test.</param>
        /// <returns>TRUE if it is a list, FALSE otherwise.</returns>
        //[DllImport(Win32.opengl32, EntryPoint = "glIsList", SetLastError = true)]
        private static extern byte glIsList(uint list);

        /// <summary>
        /// Determine if a name corresponds	to a texture.
        /// </summary>
        /// <param name="texture">Specifies a value that may be the name of a texture.</param>
        /// <returns>True if texture is a texture object.</returns>
        //[DllImport(Win32.opengl32, EntryPoint = "glIsTexture", SetLastError = true)]
        private static extern byte glIsTexture(uint texture);

        /// <summary>
        /// This function sets a parameter of the lighting model.
        /// </summary>
        /// <param name="pname">The name of the parameter.</param>
        /// <param name="param">The parameter to set it to.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glLightModelf", SetLastError = true)]
        private static extern void glLightModelf(uint pname, float param);

        /// <summary>
        /// This function sets a parameter of the lighting model.
        /// </summary>
        /// <param name="pname">The name of the parameter.</param>
        /// <param name="parameters">The parameter to set it to.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glLightModelfv", SetLastError = true)]
        private static extern void glLightModelfv(uint pname, float[] parameters);

        /// <summary>
        /// This function sets a parameter of the lighting model.
        /// </summary>
        /// <param name="pname">The name of the parameter.</param>
        /// <param name="param">The parameter to set it to.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glLightModeli", SetLastError = true)]
        private static extern void glLightModeli(uint pname, int param);

        /// <summary>
        /// This function sets a parameter of the lighting model.
        /// </summary>
        /// <param name="pname">The name of the parameter.</param>
        /// <param name="parameters">The parameter to set it to.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glLightModeliv", SetLastError = true)]
        private static extern void glLightModeliv(uint pname, int[] parameters);

        /// <summary>
        /// Set the parameter (pname) of the light 'light'.
        /// </summary>
        /// <param name="light">The light you wish to set parameters for.</param>
        /// <param name="pname">The parameter you want to set.</param>
        /// <param name="param">The value that you want to set the parameter to.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glLightf", SetLastError = true)]
        private static extern void glLightf(uint light, uint pname, float param);

        /// <summary>
        /// Set the parameter (pname) of the light 'light'.
        /// </summary>
        /// <param name="light">The light you wish to set parameters for.</param>
        /// <param name="pname">The parameter you want to set.</param>
        /// <param name="parameters">The value that you want to set the parameter to.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glLightfv", SetLastError = true)]
        private static extern void glLightfv(uint light, uint pname, float[] parameters);

        /// <summary>
        /// Set the parameter (pname) of the light 'light'.
        /// </summary>
        /// <param name="light">The light you wish to set parameters for.</param>
        /// <param name="pname">The parameter you want to set.</param>
        /// <param name="param">The value that you want to set the parameter to.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glLighti", SetLastError = true)]
        private static extern void glLighti(uint light, uint pname, int param);

        /// <summary>
        /// Set the parameter (pname) of the light 'light'.
        /// </summary>
        /// <param name="light">The light you wish to set parameters for.</param>
        /// <param name="pname">The parameter you want to set.</param>
        /// <param name="parameters">The parameters.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glLightiv", SetLastError = true)]
        private static extern void glLightiv(uint light, uint pname, int[] parameters);

        /// <summary>
        /// Specify the line stipple pattern.
        /// </summary>
        /// <param name="factor">Specifies a multiplier for each bit in the line stipple pattern.  If factor is 3, for example, each bit in the pattern is used three times before the next	bit in the pattern is used. factor is clamped to the range	[1, 256] and defaults to 1.</param>
        /// <param name="pattern">Specifies a 16-bit integer whose bit	pattern determines which fragments of a line will be drawn when	the line is rasterized.	 Bit zero is used first; the default pattern is all 1's.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glLineStipple", SetLastError = true)]
        private static extern void glLineStipple(int factor, ushort pattern);

        /// <summary>
        /// Set's the current width of lines.
        /// </summary>
        /// <param name="width">New line width to set.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glLineWidth", SetLastError = true)]
        private static extern void glLineWidth(float width);

        /// <summary>
        /// Set the display-list base for glCallLists.
        /// </summary>
        /// <param name="listbase">Specifies an integer offset that will be added to glCallLists offsets to generate display-list names. The initial value is 0.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glListBase", SetLastError = true)]
        private static extern void glListBase(uint listbase);

        /// <summary>
        /// Call this function to load the identity matrix into the current matrix stack.
        /// </summary>
        //[DllImport(Win32.opengl32, EntryPoint = "glLoadIdentity", SetLastError = true)]
        private static extern void glLoadIdentity();

        /// <summary>
        /// Replace the current matrix with the specified matrix.
        /// </summary>
        /// <param name="m">Specifies a pointer to 16 consecutive values, which are used as the elements of a 4x4 column-major matrix.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glLoadMatrixd", SetLastError = true)]
        private static extern void glLoadMatrixd(double[] m);

        /// <summary>
        /// Replace the current matrix with the specified matrix.
        /// </summary>
        /// <param name="m">Specifies a pointer to 16 consecutive values, which are used as the elements of a 4x4 column-major matrix.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glLoadMatrixf", SetLastError = true)]
        private static extern void glLoadMatrixf(float[] m);

        /// <summary>
        /// This function replaces the name at the top of the selection names stack
        /// with 'name'.
        /// </summary>
        /// <param name="name">The name to replace it with.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glLoadName", SetLastError = true)]
        private static extern void glLoadName(uint name);

        /// <summary>
        /// Specify a logical pixel operation for color index rendering.
        /// </summary>
        /// <param name="opcode">Specifies a symbolic constant	that selects a logical operation.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glLogicOp", SetLastError = true)]
        private static extern void glLogicOp(uint opcode);

        /// <summary>
        /// Defines a 1D evaluator.
        /// </summary>
        /// <param name="target">What the control points represent (e.g. MAP1_VERTEX_3).</param>
        /// <param name="u1">Range of the variable 'u'.</param>
        /// <param name="u2">Range of the variable 'u'.</param>
        /// <param name="stride">Offset between beginning of one control point, and beginning of next.</param>
        /// <param name="order">The degree plus one, should agree with the number of control points.</param>
        /// <param name="points">The data for the points.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glMap1d", SetLastError = true)]
        private static extern void glMap1d(uint target, double u1, double u2, int stride, int order, IntPtr points);

        /// <summary>
        /// Defines a 1D evaluator.
        /// </summary>
        /// <param name="target">What the control points represent (e.g. MAP1_VERTEX_3).</param>
        /// <param name="u1">Range of the variable 'u'.</param>
        /// <param name="u2">Range of the variable 'u'.</param>
        /// <param name="stride">Offset between beginning of one control point, and beginning of next.</param>
        /// <param name="order">The degree plus one, should agree with the number of control points.</param>
        /// <param name="points">The data for the points.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glMap1f", SetLastError = true)]
        private static extern void glMap1f(uint target, float u1, float u2, int stride, int order, IntPtr points);

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
        //[DllImport(Win32.opengl32, EntryPoint = "glMap2d", SetLastError = true)]
        private static extern void glMap2d(uint target, double u1, double u2, int ustride, int uorder, double v1, double v2, int vstride, int vorder, IntPtr points);

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
        //[DllImport(Win32.opengl32, EntryPoint = "glMap2f", SetLastError = true)]
        private static extern void glMap2f(uint target, float u1, float u2, int ustride, int uorder, float v1, float v2, int vstride, int vorder, IntPtr points);

        /// <summary>
        /// This function defines a grid that goes from u1 to u1 in n steps, evenly spaced.
        /// </summary>
        /// <param name="un">Number of steps.</param>
        /// <param name="u1">Range of variable 'u'.</param>
        /// <param name="u2">Range of variable 'u'.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glMapGrid1d", SetLastError = true)]
        private static extern void glMapGrid1d(int un, double u1, double u2);

        /// <summary>
        ///
        /// </summary>
        /// <param name="un"></param>
        /// <param name="u1"></param>
        /// <param name="u2"></param>
        //[DllImport(Win32.opengl32, EntryPoint = "glMapGrid1f", SetLastError = true)]
        private static extern void glMapGrid1f(int un, float u1, float u2);

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
        //[DllImport(Win32.opengl32, EntryPoint = "glMapGrid2d", SetLastError = true)]
        private static extern void glMapGrid2d(int un, double u1, double u2, int vn, double v1, double v2);

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
        //[DllImport(Win32.opengl32, EntryPoint = "glMapGrid2f", SetLastError = true)]
        private static extern void glMapGrid2f(int un, float u1, float u2, int vn, float v1, float v2);

        /// <summary>
        /// This function sets a material parameter.
        /// </summary>
        /// <param name="face">What faces is this parameter for (i.e front/back etc).</param>
        /// <param name="pname">What parameter you want to set.</param>
        /// <param name="param">The value to set 'pname' to.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glMaterialf", SetLastError = true)]
        private static extern void glMaterialf(uint face, uint pname, float param);

        /// <summary>
        /// This function sets a material parameter.
        /// </summary>
        /// <param name="face">What faces is this parameter for (i.e front/back etc).</param>
        /// <param name="pname">What parameter you want to set.</param>
        /// <param name="parameters">The value to set 'pname' to.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glMaterialfv", SetLastError = true)]
        private static extern void glMaterialfv(uint face, uint pname, float[] parameters);

        /// <summary>
        /// This function sets a material parameter.
        /// </summary>
        /// <param name="face">What faces is this parameter for (i.e front/back etc).</param>
        /// <param name="pname">What parameter you want to set.</param>
        /// <param name="param">The value to set 'pname' to.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glMateriali", SetLastError = true)]
        private static extern void glMateriali(uint face, uint pname, int param);

        /// <summary>
        /// This function sets a material parameter.
        /// </summary>
        /// <param name="face">What faces is this parameter for (i.e front/back etc).</param>
        /// <param name="pname">What parameter you want to set.</param>
        /// <param name="parameters">The value to set 'pname' to.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glMaterialiv", SetLastError = true)]
        private static extern void glMaterialiv(uint face, uint pname, int[] parameters);

        /// <summary>
        /// Set the current matrix mode (the matrix that matrix operations will be
        /// performed on).
        /// </summary>
        /// <param name="mode">The mode, normally PROJECTION or MODELVIEW.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glMatrixMode", SetLastError = true)]
        private static extern void glMatrixMode(uint mode);

        /// <summary>
        /// Multiply the current matrix with the specified matrix.
        /// </summary>
        /// <param name="m">Points to 16 consecutive values that are used as the elements of a 4x4 column-major matrix.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glMultMatrixd", SetLastError = true)]
        private static extern void glMultMatrixd(double[] m);

        /// <summary>
        /// Multiply the current matrix with the specified matrix.
        /// </summary>
        /// <param name="m">Points to 16 consecutive values that are used as the elements of a 4x4 column-major matrix.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glMultMatrixf", SetLastError = true)]
        private static extern void glMultMatrixf(float[] m);

        /// <summary>
        /// This function starts compiling a new display list.
        /// </summary>
        /// <param name="list">The list to compile.</param>
        /// <param name="mode">Either COMPILE or COMPILE_AND_EXECUTE.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glNewList", SetLastError = true)]
        private static extern void glNewList(uint list, uint mode);

        /// <summary>
        /// Set the current normal.
        /// </summary>
        /// <param name="nx">Normal Coordinate.</param>
        /// <param name="ny">Normal Coordinate.</param>
        /// <param name="nz">Normal Coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glNormal3b", SetLastError = true)]
        private static extern void glNormal3b(byte nx, byte ny, byte nz);

        /// <summary>
        /// This function sets the current normal.
        /// </summary>
        /// <param name="v">The normal.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glNormal3bv", SetLastError = true)]
        private static extern void glNormal3bv(byte[] v);

        /// <summary>
        /// Set the current normal.
        /// </summary>
        /// <param name="nx">Normal Coordinate.</param>
        /// <param name="ny">Normal Coordinate.</param>
        /// <param name="nz">Normal Coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glNormal3d", SetLastError = true)]
        private static extern void glNormal3d(double nx, double ny, double nz);

        /// <summary>
        /// This function sets the current normal.
        /// </summary>
        /// <param name="v">The normal.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glNormal3dv", SetLastError = true)]
        private static extern void glNormal3dv(double[] v);

        /// <summary>
        /// Set the current normal.
        /// </summary>
        /// <param name="nx">Normal Coordinate.</param>
        /// <param name="ny">Normal Coordinate.</param>
        /// <param name="nz">Normal Coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glNormal3f", SetLastError = true)]
        private static extern void glNormal3f(float nx, float ny, float nz);

        /// <summary>
        /// This function sets the current normal.
        /// </summary>
        /// <param name="v">The normal.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glNormal3fv", SetLastError = true)]
        private static extern void glNormal3fv(float[] v);

        /// <summary>
        /// Set the current normal.
        /// </summary>
        /// <param name="nx">Normal Coordinate.</param>
        /// <param name="ny">Normal Coordinate.</param>
        /// <param name="nz">Normal Coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glNormal3i", SetLastError = true)]
        private static extern void glNormal3i(int nx, int ny, int nz);

        /// <summary>
        /// This function sets the current normal.
        /// </summary>
        /// <param name="v">The normal.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glNormal3iv", SetLastError = true)]
        private static extern void glNormal3iv(int[] v);

        /// <summary>
        /// Set the current normal.
        /// </summary>
        /// <param name="nx">Normal Coordinate.</param>
        /// <param name="ny">Normal Coordinate.</param>
        /// <param name="nz">Normal Coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glNormal3s", SetLastError = true)]
        private static extern void glNormal3s(short nx, short ny, short nz);

        /// <summary>
        /// This function sets the current normal.
        /// </summary>
        /// <param name="v">The normal.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glNormal3sv", SetLastError = true)]
        private static extern void glNormal3sv(short[] v);

        /// <summary>
        /// Set's the pointer to the normal array.
        /// </summary>
        /// <param name="type">The type of data.</param>
        /// <param name="stride">The space in bytes between each normal.</param>
        /// <param name="pointer">The normals.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glNormalPointer", SetLastError = true)]
        private static extern void glNormalPointer(uint type, int stride, IntPtr pointer);

        /// <summary>
        /// Set's the pointer to the normal array.
        /// </summary>
        /// <param name="type">The type of data.</param>
        /// <param name="stride">The space in bytes between each normal.</param>
        /// <param name="pointer">The normals.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glNormalPointer", SetLastError = true)]
        private static extern void glNormalPointer(uint type, int stride, float[] pointer);

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
        //[DllImport(Win32.opengl32, EntryPoint = "glOrtho", SetLastError = true)]
        private static extern void glOrtho(double left, double right, double bottom, double top, double zNear, double zFar);

        /// <summary>
        /// Place a marker in the feedback buffer.
        /// </summary>
        /// <param name="token">Specifies a marker value to be placed in the feedback buffer following a GL.PASS_THROUGH_TOKEN.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glPassThrough", SetLastError = true)]
        private static extern void glPassThrough(float token);

        /// <summary>
        /// Set up pixel transfer maps.
        /// </summary>
        /// <param name="map">Specifies a symbolic	map name.</param>
        /// <param name="mapsize">Specifies the size of the map being defined.</param>
        /// <param name="values">Specifies an	array of mapsize values.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glPixelMapfv", SetLastError = true)]
        private static extern void glPixelMapfv(uint map, int mapsize, float[] values);

        /// <summary>
        /// Set up pixel transfer maps.
        /// </summary>
        /// <param name="map">Specifies a symbolic	map name.</param>
        /// <param name="mapsize">Specifies the size of the map being defined.</param>
        /// <param name="values">Specifies an	array of mapsize values.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glPixelMapuiv", SetLastError = true)]
        private static extern void glPixelMapuiv(uint map, int mapsize, uint[] values);

        /// <summary>
        /// Set up pixel transfer maps.
        /// </summary>
        /// <param name="map">Specifies a symbolic	map name.</param>
        /// <param name="mapsize">Specifies the size of the map being defined.</param>
        /// <param name="values">Specifies an	array of mapsize values.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glPixelMapusv", SetLastError = true)]
        private static extern void glPixelMapusv(uint map, int mapsize, ushort[] values);

        /// <summary>
        /// Set pixel storage modes.
        /// </summary>
        /// <param name="pname">Specifies the symbolic	name of	the parameter to be set.</param>
        /// <param name="param">Specifies the value that pname	is set to.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glPixelStoref", SetLastError = true)]
        private static extern void glPixelStoref(uint pname, float param);

        /// <summary>
        /// Set pixel storage modes.
        /// </summary>
        /// <param name="pname">Specifies the symbolic	name of	the parameter to be set.</param>
        /// <param name="param">Specifies the value that pname	is set to.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glPixelStorei", SetLastError = true)]
        private static extern void glPixelStorei(uint pname, int param);

        /// <summary>
        /// Set pixel transfer modes.
        /// </summary>
        /// <param name="pname">Specifies the symbolic name of the pixel transfer parameter to be set.</param>
        /// <param name="param">Specifies the value that pname is set to.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glPixelTransferf", SetLastError = true)]
        private static extern void glPixelTransferf(uint pname, float param);

        /// <summary>
        /// Set pixel transfer modes.
        /// </summary>
        /// <param name="pname">Specifies the symbolic name of the pixel transfer parameter to be set.</param>
        /// <param name="param">Specifies the value that pname is set to.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glPixelTransferi", SetLastError = true)]
        private static extern void glPixelTransferi(uint pname, int param);

        /// <summary>
        /// Specify	the pixel zoom factors.
        /// </summary>
        /// <param name="xfactor">Specify the x and y zoom factors for pixel write operations.</param>
        /// <param name="yfactor">Specify the x and y zoom factors for pixel write operations.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glPixelZoom", SetLastError = true)]
        private static extern void glPixelZoom(float xfactor, float yfactor);

        /// <summary>
        /// The size of points to be rasterised.
        /// </summary>
        /// <param name="size">Size in pixels.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glPointSize", SetLastError = true)]
        private static extern void glPointSize(float size);

        /// <summary>
        /// This sets the current drawing mode of polygons (points, lines, filled).
        /// </summary>
        /// <param name="face">The faces this applies to (front, back or both).</param>
        /// <param name="mode">The mode to set to (points, lines, or filled).</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glPolygonMode", SetLastError = true)]
        private static extern void glPolygonMode(uint face, uint mode);

        /// <summary>
        /// Set	the scale and units used to calculate depth	values.
        /// </summary>
        /// <param name="factor">Specifies a scale factor that	is used	to create a variable depth offset for each polygon. The initial value is 0.</param>
        /// <param name="units">Is multiplied by an implementation-specific value to create a constant depth offset. The initial value is 0.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glPolygonOffset", SetLastError = true)]
        private static extern void glPolygonOffset(float factor, float units);

        /// <summary>
        /// Set the polygon stippling pattern.
        /// <para>https://www.GL.org/sdk/docs/man2/xhtml/glPolygonStipple.xml</para>
        /// </summary>
        /// <param name="mask">Specifies a pointer to a 32x32 stipple pattern that will be unpacked from memory in the same way that glDrawPixels unpacks pixels.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glPolygonStipple", SetLastError = true)]
        private static extern void glPolygonStipple(byte[] mask);

        /// <summary>
        /// This function restores the attribute stack to the state it was when
        /// PushAttrib was called.
        /// </summary>
        //[DllImport(Win32.opengl32, EntryPoint = "glPopAttrib", SetLastError = true)]
        private static extern void glPopAttrib();

        /// <summary>
        /// Pop the client attribute stack.
        /// </summary>
        //[DllImport(Win32.opengl32, EntryPoint = "glPopClientAttrib", SetLastError = true)]
        private static extern void glPopClientAttrib();

        /// <summary>
        /// Restore the previously saved state of the current matrix stack.
        /// </summary>
        //[DllImport(Win32.opengl32, EntryPoint = "glPopMatrix", SetLastError = true)]
        private static extern void glPopMatrix();

        /// <summary>
        /// This takes the top name off the selection names stack.
        /// </summary>
        //[DllImport(Win32.opengl32, EntryPoint = "glPopName", SetLastError = true)]
        private static extern void glPopName();

        /// <summary>
        /// Set texture residence priority.
        /// </summary>
        /// <param name="n">Specifies the number of textures to be prioritized.</param>
        /// <param name="textures">Specifies an array containing the names of the textures to be prioritized.</param>
        /// <param name="priorities">Specifies	an array containing the	texture priorities. A priority given in an element of priorities applies to the	texture	named by the corresponding element of textures.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glPrioritizeTextures", SetLastError = true)]
        private static extern void glPrioritizeTextures(int n, uint[] textures, float[] priorities);

        /// <summary>
        /// Save the current state of the attribute groups specified by 'mask'.
        /// </summary>
        /// <param name="mask">The attibute groups to save.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glPushAttrib", SetLastError = true)]
        private static extern void glPushAttrib(uint mask);

        /// <summary>
        /// Push the client attribute stack.
        /// </summary>
        /// <param name="mask">Specifies a mask that indicates	which attributes to save.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glPushClientAttrib", SetLastError = true)]
        private static extern void glPushClientAttrib(uint mask);

        /// <summary>
        /// Save the current state of the current matrix stack.
        /// </summary>
        //[DllImport(Win32.opengl32, EntryPoint = "glPushMatrix", SetLastError = true)]
        private static extern void glPushMatrix();

        /// <summary>
        /// This function adds a new name to the selection buffer.
        /// </summary>
        /// <param name="name">The name to add.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glPushName", SetLastError = true)]
        private static extern void glPushName(uint name);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRasterPos2d", SetLastError = true)]
        private static extern void glRasterPos2d(double x, double y);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRasterPos2dv", SetLastError = true)]
        private static extern void glRasterPos2dv(double[] v);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRasterPos2f", SetLastError = true)]
        private static extern void glRasterPos2f(float x, float y);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRasterPos2fv", SetLastError = true)]
        private static extern void glRasterPos2fv(float[] v);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRasterPos2i", SetLastError = true)]
        private static extern void glRasterPos2i(int x, int y);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRasterPos2iv", SetLastError = true)]
        private static extern void glRasterPos2iv(int[] v);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRasterPos2s", SetLastError = true)]
        private static extern void glRasterPos2s(short x, short y);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRasterPos2sv", SetLastError = true)]
        private static extern void glRasterPos2sv(short[] v);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRasterPos3d", SetLastError = true)]
        private static extern void glRasterPos3d(double x, double y, double z);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRasterPos3dv", SetLastError = true)]
        private static extern void glRasterPos3dv(double[] v);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRasterPos3f", SetLastError = true)]
        private static extern void glRasterPos3f(float x, float y, float z);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRasterPos3fv", SetLastError = true)]
        private static extern void glRasterPos3fv(float[] v);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRasterPos3i", SetLastError = true)]
        private static extern void glRasterPos3i(int x, int y, int z);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRasterPos3iv", SetLastError = true)]
        private static extern void glRasterPos3iv(int[] v);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRasterPos3s", SetLastError = true)]
        private static extern void glRasterPos3s(short x, short y, short z);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRasterPos3sv", SetLastError = true)]
        private static extern void glRasterPos3sv(short[] v);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        /// <param name="w">W coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRasterPos4d", SetLastError = true)]
        private static extern void glRasterPos4d(double x, double y, double z, double w);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRasterPos4dv", SetLastError = true)]
        private static extern void glRasterPos4dv(double[] v);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        /// <param name="w">W coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRasterPos4f", SetLastError = true)]
        private static extern void glRasterPos4f(float x, float y, float z, float w);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRasterPos4fv", SetLastError = true)]
        private static extern void glRasterPos4fv(float[] v);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        /// <param name="w">W coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRasterPos4i", SetLastError = true)]
        private static extern void glRasterPos4i(int x, int y, int z, int w);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRasterPos4iv", SetLastError = true)]
        private static extern void glRasterPos4iv(int[] v);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        /// <param name="w">W coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRasterPos4s", SetLastError = true)]
        private static extern void glRasterPos4s(short x, short y, short z, short w);

        /// <summary>
        /// This function sets the current raster position.
        /// </summary>
        /// <param name="v">The coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRasterPos4sv", SetLastError = true)]
        private static extern void glRasterPos4sv(short[] v);

        /// <summary>
        /// Select	a color	buffer source for pixels.
        /// </summary>
        /// <param name="mode">Specifies a color buffer.  Accepted values are GL.FRONT_LEFT, GL.FRONT_RIGHT, GL.BACK_LEFT, GL.BACK_RIGHT, GL.FRONT, GL.BACK, GL.LEFT, GL.GL_RIGHT, and GL.AUXi, where i is between 0 and GL.AUX_BUFFERS - 1.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glReadBuffer", SetLastError = true)]
        private static extern void glReadBuffer(uint mode);

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
        //[DllImport(Win32.opengl32, EntryPoint = "glReadPixels", SetLastError = true)]
        private static extern void glReadPixels(int x, int y, int width, int height, uint format, uint type, byte[] pixels);

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
        //[DllImport(Win32.opengl32, EntryPoint = "glReadPixels", SetLastError = true)]
        private static extern void glReadPixels(int x, int y, int width, int height, uint format, uint type, IntPtr pixels);

        /// <summary>
        /// Draw a rectangle from two coordinates (top-left and bottom-right).
        /// </summary>
        /// <param name="x1">Top-Left X value.</param>
        /// <param name="y1">Top-Left Y value.</param>
        /// <param name="x2">Bottom-Right X Value.</param>
        /// <param name="y2">Bottom-Right Y Value.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRectd", SetLastError = true)]
        private static extern void glRectd(double x1, double y1, double x2, double y2);

        /// <summary>
        /// Draw a rectangle from two coordinates, expressed as arrays, e.g
        /// Rect(new float[] {0, 0}, new float[] {10, 10});
        /// </summary>
        /// <param name="v1">Top-Left point.</param>
        /// <param name="v2">Bottom-Right point.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRectdv", SetLastError = true)]
        private static extern void glRectdv(double[] v1, double[] v2);

        /// <summary>
        ///
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRectf", SetLastError = true)]
        private static extern void glRectf(float x1, float y1, float x2, float y2);

        /// <summary>
        /// Draw a rectangle from two coordinates, expressed as arrays, e.g
        /// Rect(new float[] {0, 0}, new float[] {10, 10});
        /// </summary>
        /// <param name="v1">Top-Left point.</param>
        /// <param name="v2">Bottom-Right point.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRectfv", SetLastError = true)]
        private static extern void glRectfv(float[] v1, float[] v2);

        /// <summary>
        /// Draw a rectangle from two coordinates (top-left and bottom-right).
        /// </summary>
        /// <param name="x1">Top-Left X value.</param>
        /// <param name="y1">Top-Left Y value.</param>
        /// <param name="x2">Bottom-Right X Value.</param>
        /// <param name="y2">Bottom-Right Y Value.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRecti", SetLastError = true)]
        private static extern void glRecti(int x1, int y1, int x2, int y2);

        /// <summary>
        /// Draw a rectangle from two coordinates, expressed as arrays, e.g
        /// Rect(new float[] {0, 0}, new float[] {10, 10});
        /// </summary>
        /// <param name="v1">Top-Left point.</param>
        /// <param name="v2">Bottom-Right point.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRectiv", SetLastError = true)]
        private static extern void glRectiv(int[] v1, int[] v2);

        /// <summary>
        /// Draw a rectangle from two coordinates (top-left and bottom-right).
        /// </summary>
        /// <param name="x1">Top-Left X value.</param>
        /// <param name="y1">Top-Left Y value.</param>
        /// <param name="x2">Bottom-Right X Value.</param>
        /// <param name="y2">Bottom-Right Y Value.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRects", SetLastError = true)]
        private static extern void glRects(short x1, short y1, short x2, short y2);

        /// <summary>
        /// Draw a rectangle from two coordinates, expressed as arrays, e.g
        /// Rect(new float[] {0, 0}, new float[] {10, 10});
        /// </summary>
        /// <param name="v1">Top-Left point.</param>
        /// <param name="v2">Bottom-Right point.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glRectsv", SetLastError = true)]
        private static extern void glRectsv(short[] v1, short[] v2);

        /// <summary>
        /// This function sets the current render mode (render, feedback or select).
        /// </summary>
        /// <param name="mode">The Render mode (RENDER, SELECT or FEEDBACK).</param>
        /// <returns>The hits that selection or feedback caused..</returns>
        //[DllImport(Win32.opengl32, EntryPoint = "glRenderMode", SetLastError = true)]
        private static extern int glRenderMode(uint mode);

        /// <summary>
        /// This function applies a rotation transformation to the current matrix.
        /// </summary>
        /// <param name="angle">The angle to rotate.</param>
        /// <param name="x">Amount along x.</param>
        /// <param name="y">Amount along y.</param>
        /// <param name="z">Amount along z.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glRotated", SetLastError = true)]
        private static extern void glRotated(double angle, double x, double y, double z);

        /// <summary>
        /// This function applies a rotation transformation to the current matrix.
        /// </summary>
        /// <param name="angle">The angle to rotate.</param>
        /// <param name="x">Amount along x.</param>
        /// <param name="y">Amount along y.</param>
        /// <param name="z">Amount along z.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glRotatef", SetLastError = true)]
        private static extern void glRotatef(float angle, float x, float y, float z);

        /// <summary>
        /// This function applies a scale transformation to the current matrix.
        /// </summary>
        /// <param name="x">The amount to scale along x.</param>
        /// <param name="y">The amount to scale along y.</param>
        /// <param name="z">The amount to scale along z.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glScaled", SetLastError = true)]
        private static extern void glScaled(double x, double y, double z);

        /// <summary>
        /// This function applies a scale transformation to the current matrix.
        /// </summary>
        /// <param name="x">The amount to scale along x.</param>
        /// <param name="y">The amount to scale along y.</param>
        /// <param name="z">The amount to scale along z.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glScalef", SetLastError = true)]
        private static extern void glScalef(float x, float y, float z);

        /// <summary>
        /// Define the scissor box.
        /// https://www.khronos.org/opengles/sdk/docs/man/xhtml/glScissor.xml
        /// </summary>
        /// <param name="x">Specify the lower left corner of the scissor box. Initially (0, 0).</param>
        /// <param name="y">Specify the lower left corner of the scissor box. Initially (0, 0).</param>
        /// <param name="width">Specify the width and height of the scissor box. When a GL context is first attached to a window, width and height are set to the dimensions of that window.</param>
        /// <param name="height">Specify the width and height of the scissor box. When a GL context is first attached to a window, width and height are set to the dimensions of that window.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glScissor", SetLastError = true)]
        private static extern void glScissor(int x, int y, int width, int height);

        /// <summary>
        /// This function sets the current select buffer.
        /// </summary>
        /// <param name="size">The size of the buffer you are passing.</param>
        /// <param name="buffer">The buffer itself.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glSelectBuffer", SetLastError = true)]
        private static extern void glSelectBuffer(int size, uint[] buffer);

        /// <summary>
        /// Select flat or smooth shading.
        /// </summary>
        /// <param name="mode">Specifies a symbolic value representing a shading technique. Accepted values are GL.FLAT and GL.SMOOTH. The default is GL.SMOOTH.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glShadeModel", SetLastError = true)]
        private static extern void glShadeModel(uint mode);

        /// <summary>
        /// This function sets the current stencil buffer function.
        /// </summary>
        /// <param name="func">The function type.</param>
        /// <param name="reference">The function reference.</param>
        /// <param name="mask">The function mask.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glStencilFunc", SetLastError = true)]
        private static extern void glStencilFunc(uint func, int reference, uint mask);

        /// <summary>
        /// control the front and back writing of individual bits in the stencil planes
        /// <para>glStencilMask controls the writing of individual bits in the stencil planes. The least significant n bits of mask, where n is the number of bits in the stencil buffer, specify a mask. Where a 1 appears in the mask, it's possible to write to the corresponding bit in the stencil buffer. Where a 0 appears, the corresponding bit is write-protected. Initially, all bits are enabled for writing.
        /// There can be two separate mask writemasks; one affects back-facing polygons, and the other affects front-facing polygons as well as other non-polygon primitives. glStencilMask sets both front and back stencil writemasks to the same values. Use glStencilMaskSeparate to set front and back stencil writemasks to different values.</para>
        /// <para>glStencilMask is the same as calling glStencilMaskSeparate with face set to GL_FRONT_AND_BACK.</para>
        /// <para>glGet with argument GL_STENCIL_WRITEMASK, GL_STENCIL_BACK_WRITEMASK, or GL_STENCIL_BITS</para>
        /// <para>See Also glColorMask, glDepthMask, glStencilFunc, glStencilFuncSeparate, glStencilMaskSeparate, glStencilOp, glStencilOpSeparate</para>
        /// </summary>
        /// <param name="mask">Specifies a bit mask to enable and disable writing of individual bits in the stencil planes. Initially, the mask is all 1's.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glStencilMask", SetLastError = true)]
        private static extern void glStencilMask(uint mask);

        /// <summary>
        /// This function sets the stencil buffer operation.
        /// </summary>
        /// <param name="fail">Fail operation.</param>
        /// <param name="zfail">Depth fail component.</param>
        /// <param name="zpass">Depth pass component.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glStencilOp", SetLastError = true)]
        private static extern void glStencilOp(uint fail, uint zfail, uint zpass);

        ///// <summary>
        ///// set front and/or back stencil test actions.
        ///// </summary>
        ///// <param name="face">Specifies whether front and/or back stencil state is updated. Three symbolic constants are valid: GL_FRONT, GL_BACK, and GL_FRONT_AND_BACK.</param>
        ///// <param name="fail">Fail operation.</param>
        ///// <param name="zfail">Depth fail component.</param>
        ///// <param name="zpass">Depth pass component.</param>
        ////[DllImport(Win32.opengl32, EntryPoint = "glStencilOpSeparate", SetLastError = true)]
        //private static extern void glStencilOpSeparate(uint face, uint fail, uint zfail, uint zpass);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord1d", SetLastError = true)]
        private static extern void glTexCoord1d(double s);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord1dv", SetLastError = true)]
        private static extern void glTexCoord1dv(double[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord1f", SetLastError = true)]
        private static extern void glTexCoord1f(float s);

        /// <summary>
        /// This function sets the current texture coordinates. WARNING: if you
        /// can call something more explicit, like TexCoord2f then call that, it's
        /// much faster.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord1fv", SetLastError = true)]
        private static extern void glTexCoord1fv(float[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord1i", SetLastError = true)]
        private static extern void glTexCoord1i(int s);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord1iv", SetLastError = true)]
        private static extern void glTexCoord1iv(int[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord1s", SetLastError = true)]
        private static extern void glTexCoord1s(short s);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord1sv", SetLastError = true)]
        private static extern void glTexCoord1sv(short[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord2d", SetLastError = true)]
        private static extern void glTexCoord2d(double s, double t);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord2dv", SetLastError = true)]
        private static extern void glTexCoord2dv(double[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord2f", SetLastError = true)]
        private static extern void glTexCoord2f(float s, float t);

        /// <summary>
        /// This function sets the current texture coordinates. WARNING: if you
        /// can call something more explicit, like TexCoord2f then call that, it's
        /// much faster.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord2fv", SetLastError = true)]
        private static extern void glTexCoord2fv(float[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord2i", SetLastError = true)]
        private static extern void glTexCoord2i(int s, int t);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord2iv", SetLastError = true)]
        private static extern void glTexCoord2iv(int[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord2s", SetLastError = true)]
        private static extern void glTexCoord2s(short s, short t);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord2sv", SetLastError = true)]
        private static extern void glTexCoord2sv(short[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord3d", SetLastError = true)]
        private static extern void glTexCoord3d(double s, double t, double r);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord3dv", SetLastError = true)]
        private static extern void glTexCoord3dv(double[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord3f", SetLastError = true)]
        private static extern void glTexCoord3f(float s, float t, float r);

        /// <summary>
        /// This function sets the current texture coordinates. WARNING: if you
        /// can call something more explicit, like TexCoord2f then call that, it's
        /// much faster.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord3fv", SetLastError = true)]
        private static extern void glTexCoord3fv(float[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord3i", SetLastError = true)]
        private static extern void glTexCoord3i(int s, int t, int r);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord3iv", SetLastError = true)]
        private static extern void glTexCoord3iv(int[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord3s", SetLastError = true)]
        private static extern void glTexCoord3s(short s, short t, short r);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord3sv", SetLastError = true)]
        private static extern void glTexCoord3sv(short[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        /// <param name="q">Texture Coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord4d", SetLastError = true)]
        private static extern void glTexCoord4d(double s, double t, double r, double q);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord4dv", SetLastError = true)]
        private static extern void glTexCoord4dv(double[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        /// <param name="q">Texture Coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord4f", SetLastError = true)]
        private static extern void glTexCoord4f(float s, float t, float r, float q);

        /// <summary>
        /// This function sets the current texture coordinates. WARNING: if you
        /// can call something more explicit, like TexCoord2f then call that, it's
        /// much faster.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord4fv", SetLastError = true)]
        private static extern void glTexCoord4fv(float[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        /// <param name="q">Texture Coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord4i", SetLastError = true)]
        private static extern void glTexCoord4i(int s, int t, int r, int q);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord4iv", SetLastError = true)]
        private static extern void glTexCoord4iv(int[] v);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        /// <param name="q">Texture Coordinate.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord4s", SetLastError = true)]
        private static extern void glTexCoord4s(short s, short t, short r, short q);

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoord4sv", SetLastError = true)]
        private static extern void glTexCoord4sv(short[] v);

        /// <summary>
        /// This function sets the texture coord array.
        /// </summary>
        /// <param name="size">The number of coords per set.</param>
        /// <param name="type">The type of data.</param>
        /// <param name="stride">The number of bytes between coords.</param>
        /// <param name="pointer">The coords.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoordPointer", SetLastError = true)]
        private static extern void glTexCoordPointer(int size, uint type, int stride, IntPtr pointer);

        /// <summary>
        /// This function sets the texture coord array.
        /// </summary>
        /// <param name="size">The number of coords per set.</param>
        /// <param name="type">The type of data.</param>
        /// <param name="stride">The number of bytes between coords.</param>
        /// <param name="pointer">The coords.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexCoordPointer", SetLastError = true)]
        private static extern void glTexCoordPointer(int size, uint type, int stride, float[] pointer);

        /// <summary>
        /// Set texture environment parameters.
        /// </summary>
        /// <param name="target">Specifies a texture environment. Must be GL.TEXTURE_ENV.</param>
        /// <param name="pname">Specifies the symbolic name of a single-valued texture environment parameter. Must be GL.TEXTURE_ENV_MODE.</param>
        /// <param name="param">Specifies a single symbolic constant, one of GL.MODULATE, GL.DECAL, GL.BLEND, or GL.REPLACE.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexEnvf", SetLastError = true)]
        private static extern void glTexEnvf(uint target, uint pname, float param);

        /// <summary>
        /// Set texture environment parameters.
        /// </summary>
        /// <param name="target">Specifies a texture environment. Must be GL.TEXTURE_ENV.</param>
        /// <param name="pname">Specifies the symbolic name of a texture environment parameter. Accepted values are GL.TEXTURE_ENV_MODE and GL.TEXTURE_ENV_COLOR.</param>
        /// <param name="parameters">Specifies a pointer to a parameter array that contains either a single symbolic constant or an RGBA color.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexEnvfv", SetLastError = true)]
        private static extern void glTexEnvfv(uint target, uint pname, float[] parameters);

        /// <summary>
        /// Set texture environment parameters.
        /// </summary>
        /// <param name="target">Specifies a texture environment. Must be GL.TEXTURE_ENV.</param>
        /// <param name="pname">Specifies the symbolic name of a single-valued texture environment parameter. Must be GL.TEXTURE_ENV_MODE.</param>
        /// <param name="param">Specifies a single symbolic constant, one of GL.MODULATE, GL.DECAL, GL.BLEND, or GL.REPLACE.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexEnvi", SetLastError = true)]
        private static extern void glTexEnvi(uint target, uint pname, int param);

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <param name="pname"></param>
        /// <param name="parameters"></param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexEnviv", SetLastError = true)]
        private static extern void glTexEnviv(uint target, uint pname, int[] parameters);

        /// <summary>
        /// Control the generation of texture coordinates.
        /// </summary>
        /// <param name="coord">Specifies a texture coordinate. Must be one of GL.S, GL.T, GL.R, or GL.Q.</param>
        /// <param name="pname">Specifies the symbolic name of the texture-coordinate generation function. Must be GL.TEXTURE_GEN_MODE.</param>
        /// <param name="param">Specifies a single-valued texture generation parameter, one of GL.OBJECT_LINEAR, GL.GL_EYE_LINEAR, or GL.SPHERE_MAP.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexGend", SetLastError = true)]
        private static extern void glTexGend(uint coord, uint pname, double param);

        /// <summary>
        /// Control the generation of texture coordinates.
        /// </summary>
        /// <param name="coord">Specifies a texture coordinate. Must be one of GL.S, GL.T, GL.R, or GL.Q.</param>
        /// <param name="pname">Specifies the symbolic name of the texture-coordinate generation function or function parameters. Must be GL.TEXTURE_GEN_MODE, GL.OBJECT_PLANE, or GL.EYE_PLANE.</param>
        /// <param name="parameters">Specifies a pointer to an array of texture generation parameters. If pname is GL.TEXTURE_GEN_MODE, then the array must contain a single symbolic constant, one of GL.OBJECT_LINEAR, GL.EYE_LINEAR, or GL.SPHERE_MAP. Otherwise, params holds the coefficients for the texture-coordinate generation function specified by pname.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexGendv", SetLastError = true)]
        private static extern void glTexGendv(uint coord, uint pname, double[] parameters);

        /// <summary>
        /// Control the generation of texture coordinates.
        /// </summary>
        /// <param name="coord">Specifies a texture coordinate. Must be one of GL.S, GL.T, GL.R, or GL.Q.</param>
        /// <param name="pname">Specifies the symbolic name of the texture-coordinate generation function. Must be GL.TEXTURE_GEN_MODE.</param>
        /// <param name="param">Specifies a single-valued texture generation parameter, one of GL.OBJECT_LINEAR, GL.GL_EYE_LINEAR, or GL.SPHERE_MAP.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexGenf", SetLastError = true)]
        private static extern void glTexGenf(uint coord, uint pname, float param);

        /// <summary>
        /// Control the generation of texture coordinates.
        /// </summary>
        /// <param name="coord">Specifies a texture coordinate. Must be one of GL.S, GL.T, GL.R, or GL.Q.</param>
        /// <param name="pname">Specifies the symbolic name of the texture-coordinate generation function or function parameters. Must be GL.TEXTURE_GEN_MODE, GL.OBJECT_PLANE, or GL.EYE_PLANE.</param>
        /// <param name="parameters">Specifies a pointer to an array of texture generation parameters. If pname is GL.TEXTURE_GEN_MODE, then the array must contain a single symbolic constant, one of GL.OBJECT_LINEAR, GL.EYE_LINEAR, or GL.SPHERE_MAP. Otherwise, params holds the coefficients for the texture-coordinate generation function specified by pname.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexGenfv", SetLastError = true)]
        private static extern void glTexGenfv(uint coord, uint pname, float[] parameters);

        /// <summary>
        /// Control the generation of texture coordinates.
        /// </summary>
        /// <param name="coord">Specifies a texture coordinate. Must be one of GL.S, GL.T, GL.R, or GL.Q.</param>
        /// <param name="pname">Specifies the symbolic name of the texture-coordinate generation function. Must be GL.TEXTURE_GEN_MODE.</param>
        /// <param name="param">Specifies a single-valued texture generation parameter, one of GL.OBJECT_LINEAR, GL.GL_EYE_LINEAR, or GL.SPHERE_MAP.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexGeni", SetLastError = true)]
        private static extern void glTexGeni(uint coord, uint pname, int param);

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
        //[DllImport(Win32.opengl32, EntryPoint = "glTexGeniv", SetLastError = true)]
        private static extern void glTexGeniv(uint coord, uint pname, int[] parameters);

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

        //[DllImport(Win32.opengl32, EntryPoint = "glTexImage1D", SetLastError = true)]
        private static extern void glTexImage1D(uint target, int level, uint internalformat, int width, int border, uint format, uint type, IntPtr pixels);

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
        //[DllImport(Win32.opengl32, EntryPoint = "glTexImage2D", SetLastError = true)]
        private static extern void glTexImage2D(uint target, int level, uint internalformat, int width, int height, int border, uint format, uint type, IntPtr pixels);

        /// <summary>
        ///	This function sets the parameters for the currently binded texture object.
        /// </summary>
        /// <param name="target">The type of texture you are setting the parameter to, e.g. TEXTURE_2D</param>
        /// <param name="pname">The parameter to set.</param>
        /// <param name="param">The value to set it to.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexParameterf", SetLastError = true)]
        private static extern void glTexParameterf(uint target, uint pname, float param);

        /// <summary>
        ///	This function sets the parameters for the currently binded texture object.
        /// </summary>
        /// <param name="target">The type of texture you are setting the parameter to, e.g. TEXTURE_2D</param>
        /// <param name="pname">The parameter to set.</param>
        /// <param name="parameters">The value to set it to.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexParameterfv", SetLastError = true)]
        private static extern void glTexParameterfv(uint target, uint pname, float[] parameters);

        /// <summary>
        ///	This function sets the parameters for the currently binded texture object.
        /// </summary>
        /// <param name="target">The type of texture you are setting the parameter to, e.g. TEXTURE_2D</param>
        /// <param name="pname">The parameter to set.</param>
        /// <param name="param">The value to set it to.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexParameteri", SetLastError = true)]
        private static extern void glTexParameteri(uint target, uint pname, int param);

        /// <summary>
        /// void glSamplerParameteri(uint sampler, uint pname, int param);
        /// </summary>
        private static GLDelegates.void_uint_uint_int glSamplerParameteri;

        /// <summary>
        ///
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="pname"></param>
        /// <param name="param"></param>
        public static void SamplerParameteri(uint sampler, uint pname, int param)
        {
            if (glSamplerParameteri == null)
            {
                glSamplerParameteri = SoftGL.Instance.GetDelegateFor("glSamplerParameteri", GLDelegates.typeof_void_uint_uint_int) as GLDelegates.void_uint_uint_int;
            }
            glSamplerParameteri(sampler, pname, param);
        }

        /// <summary>
        ///	This function sets the parameters for the currently binded texture object.
        /// </summary>
        /// <param name="target">The type of texture you are setting the parameter to, e.g. TEXTURE_2D</param>
        /// <param name="pname">The parameter to set.</param>
        /// <param name="parameters">The value to set it to.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glTexParameteriv", SetLastError = true)]
        private static extern void glTexParameteriv(uint target, uint pname, int[] parameters);

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
        //[DllImport(Win32.opengl32, EntryPoint = "glTexSubImage1D", SetLastError = true)]
        private static extern void glTexSubImage1D(uint target, int level, int xoffset, int width, uint format, uint type, int[] pixels);

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
        //[DllImport(Win32.opengl32, EntryPoint = "glTexSubImage1D", SetLastError = true)]
        private static extern void glTexSubImage1D(uint target, int level, int xoffset, int width, uint format, uint type, IntPtr pixels);

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
        //[DllImport(Win32.opengl32, EntryPoint = "glTexSubImage2D", SetLastError = true)]
        private static extern void glTexSubImage2D(uint target, int level, int xoffset, int yoffset, int width, int height, uint format, uint type, int[] pixels);

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
        //[DllImport(Win32.opengl32, EntryPoint = "glTexSubImage2D", SetLastError = true)]
        private static extern void glTexSubImage2D(uint target, int level, int xoffset, int yoffset, int width, int height, uint format, uint type, IntPtr pixels);

        /// <summary>
        /// This function applies a translation transformation to the current matrix.
        /// </summary>
        /// <param name="x">The amount to translate along the x axis.</param>
        /// <param name="y">The amount to translate along the y axis.</param>
        /// <param name="z">The amount to translate along the z axis.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glTranslated", SetLastError = true)]
        private static extern void glTranslated(double x, double y, double z);

        /// <summary>
        /// This function applies a translation transformation to the current matrix.
        /// </summary>
        /// <param name="x">The amount to translate along the x axis.</param>
        /// <param name="y">The amount to translate along the y axis.</param>
        /// <param name="z">The amount to translate along the z axis.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glTranslatef", SetLastError = true)]
        private static extern void glTranslatef(float x, float y, float z);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glVertex2d", SetLastError = true)]
        private static extern void glVertex2d(double x, double y);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glVertex2dv", SetLastError = true)]
        private static extern void glVertex2dv(double[] v);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glVertex2f", SetLastError = true)]
        private static extern void glVertex2f(float x, float y);

        /// <summary>
        /// Sets the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">An array of 2, 3 or 4 floats.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glVertex2fv", SetLastError = true)]
        private static extern void glVertex2fv(float[] v);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glVertex2i", SetLastError = true)]
        private static extern void glVertex2i(int x, int y);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glVertex2iv", SetLastError = true)]
        private static extern void glVertex2iv(int[] v);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glVertex2s", SetLastError = true)]
        private static extern void glVertex2s(short x, short y);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glVertex2sv", SetLastError = true)]
        private static extern void glVertex2sv(short[] v);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glVertex3d", SetLastError = true)]
        private static extern void glVertex3d(double x, double y, double z);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glVertex3dv", SetLastError = true)]
        private static extern void glVertex3dv(double[] v);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glVertex3f", SetLastError = true)]
        private static extern void glVertex3f(float x, float y, float z);

        /// <summary>
        /// Sets the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">An array of 2, 3 or 4 floats.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glVertex3fv", SetLastError = true)]
        private static extern void glVertex3fv(float[] v);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glVertex3i", SetLastError = true)]
        private static extern void glVertex3i(int x, int y, int z);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glVertex3iv", SetLastError = true)]
        private static extern void glVertex3iv(int[] v);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glVertex3s", SetLastError = true)]
        private static extern void glVertex3s(short x, short y, short z);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glVertex3sv", SetLastError = true)]
        private static extern void glVertex3sv(short[] v);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        /// <param name="w">W Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glVertex4d", SetLastError = true)]
        private static extern void glVertex4d(double x, double y, double z, double w);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glVertex4dv", SetLastError = true)]
        private static extern void glVertex4dv(double[] v);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        /// <param name="w">W Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glVertex4f", SetLastError = true)]
        private static extern void glVertex4f(float x, float y, float z, float w);

        /// <summary>
        /// Sets the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">An array of 2, 3 or 4 floats.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glVertex4fv", SetLastError = true)]
        private static extern void glVertex4fv(float[] v);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        /// <param name="w">W Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glVertex4i", SetLastError = true)]
        private static extern void glVertex4i(int x, int y, int z, int w);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glVertex4iv", SetLastError = true)]
        private static extern void glVertex4iv(int[] v);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        /// <param name="w">W Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glVertex4s", SetLastError = true)]
        private static extern void glVertex4s(short x, short y, short z, short w);

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[DllImport(Win32.opengl32, EntryPoint = "glVertex4sv", SetLastError = true)]
        private static extern void glVertex4sv(short[] v);

        /// <summary>
        /// This function sets the address of the vertex pointer array.
        /// </summary>
        /// <param name="size">The number of coords per vertex.</param>
        /// <param name="type">The data type.</param>
        /// <param name="stride">The byte offset between vertices.</param>
        /// <param name="pointer">The array.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glVertexPointer", SetLastError = true)]
        private static extern void glVertexPointer(int size, uint type, int stride, IntPtr pointer);

        /// <summary>
        /// This function sets the address of the vertex pointer array.
        /// </summary>
        /// <param name="size">The number of coords per vertex.</param>
        /// <param name="type"></param>
        /// <param name="stride">The byte offset between vertices.</param>
        /// <param name="pointer">The array.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glVertexPointer", SetLastError = true)]
        private static extern void glVertexPointer(int size, uint type, int stride, short[] pointer);

        /// <summary>
        /// This function sets the address of the vertex pointer array.
        /// </summary>
        /// <param name="size">The number of coords per vertex.</param>
        /// <param name="type"></param>
        /// <param name="stride">The byte offset between vertices.</param>
        /// <param name="pointer">The array.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glVertexPointer", SetLastError = true)]
        private static extern void glVertexPointer(int size, uint type, int stride, int[] pointer);

        /// <summary>
        /// This function sets the address of the vertex pointer array.
        /// </summary>
        /// <param name="size">The number of coords per vertex.</param>
        /// <param name="type"></param>
        /// <param name="stride">The byte offset between vertices.</param>
        /// <param name="pointer">The array.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glVertexPointer", SetLastError = true)]
        private static extern void glVertexPointer(int size, uint type, int stride, float[] pointer);

        /// <summary>
        /// This function sets the address of the vertex pointer array.
        /// </summary>
        /// <param name="size">The number of coords per vertex.</param>
        /// <param name="type"></param>
        /// <param name="stride">The byte offset between vertices.</param>
        /// <param name="pointer">The array.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glVertexPointer", SetLastError = true)]
        private static extern void glVertexPointer(int size, uint type, int stride, double[] pointer);

        /// <summary>
        /// This sets the viewport of the current Render Context. Normally x and y are 0
        /// and the width and height are just those of the control/graphics you are drawing
        /// to.
        /// </summary>
        /// <param name="x">Top-Left point of the viewport.</param>
        /// <param name="y">Top-Left point of the viewport.</param>
        /// <param name="width">Width of the viewport.</param>
        /// <param name="height">Height of the viewport.</param>
        //[DllImport(Win32.opengl32, EntryPoint = "glViewport", SetLastError = true)]
        private static extern void glViewport(int x, int y, int width, int height);

        #endregion The OpenGL DLL Functions.
    }
}