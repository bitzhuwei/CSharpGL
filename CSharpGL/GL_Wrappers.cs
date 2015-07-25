using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    // 用重载和枚举来简化GL编程。
    public static partial class GL
    {
        #region translate, rotate, scale

        /// <summary>
        /// This function applies a translation transformation to the current matrix.
        /// </summary>
        /// <param name="x">The amount to translate along the x axis.</param>
        /// <param name="y">The amount to translate along the y axis.</param>
        /// <param name="z">The amount to translate along the z axis.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Translate(double x, double y, double z)
        {
            GL.Translated(x, y, z);
        }

        /// <summary>
        /// This function applies a translation transformation to the current matrix.
        /// </summary>
        /// <param name="x">The amount to translate along the x axis.</param>
        /// <param name="y">The amount to translate along the y axis.</param>
        /// <param name="z">The amount to translate along the z axis.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Translate(float x, float y, float z)
        {
            GL.Translatef(x, y, z);
        }

        /// <summary>
        /// This function applies a rotation transformation to the current matrix.
        /// </summary>
        /// <param name="angle">The angle to rotate.</param>
        /// <param name="x">Amount along x.</param>
        /// <param name="y">Amount along y.</param>
        /// <param name="z">Amount along z.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Rotate(double angle, double x, double y, double z)
        {
            GL.Rotated(angle, x, y, z);
        }

        /// <summary>
        /// This function applies a rotation transformation to the current matrix.
        /// </summary>
        /// <param name="angle">The angle to rotate.</param>
        /// <param name="x">Amount along x.</param>
        /// <param name="y">Amount along y.</param>
        /// <param name="z">Amount along z.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Rotate(float angle, float x, float y, float z)
        {
            GL.Rotatef(angle, x, y, z);
        }

        /// <summary>
        /// This function applies a translation transformation to the current matrix.
        /// </summary>
        /// <param name="x">The amount to translate along the x axis.</param>
        /// <param name="y">The amount to translate along the y axis.</param>
        /// <param name="z">The amount to translate along the z axis.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Scale(double x, double y, double z)
        {
            GL.Scaled(x, y, z);
        }

        /// <summary>
        /// This function applies a translation transformation to the current matrix.
        /// </summary>
        /// <param name="x">The amount to translate along the x axis.</param>
        /// <param name="y">The amount to translate along the y axis.</param>
        /// <param name="z">The amount to translate along the z axis.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Scale(float x, float y, float z)
        {
            GL.Scalef(x, y, z);
        }

        #endregion translate, rotate, scale

        #region GL.Color

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 255).</param>
        /// <param name="green">Green color component (between 0 and 255).</param>
        /// <param name="blue">Blue color component (between 0 and 255).</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(byte red, byte green, byte blue)
        {
            GL.Color3ub(red, green, blue);
        }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 255).</param>
        /// <param name="green">Green color component (between 0 and 255).</param>
        /// <param name="blue">Blue color component (between 0 and 255).</param>
        /// <param name="alpha">Alpha color component (between 0 and 255).</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(byte red, byte green, byte blue, byte alpha)
        {
            GL.Color4ub(red, green, blue, alpha);
        }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(double red, double green, double blue)
        {
            GL.Color3d(red, green, blue);
        }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(double red, double green, double blue, double alpha)
        {
            GL.Color4d(red, green, blue, alpha);
        }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(float red, float green, float blue)
        {
            GL.Color3f(red, green, blue);
        }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 float values.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(float[] v)
        {
            int length = v.Length;
            if (length == 3) { GL.Color3fv(v); }
            else if (length == 4) { GL.Color4fv(v); }
            else { throw new ArgumentOutOfRangeException(); }
        }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 int values.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(int[] v)
        {
            int length = v.Length;
            if (length == 3) { GL.Color3iv(v); }
            else if (length == 4) { GL.Color4iv(v); }
            else { throw new ArgumentOutOfRangeException(); }
        }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 int values.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(short[] v)
        {
            int length = v.Length;
            if (length == 3) { GL.Color3sv(v); }
            else if (length == 4) { GL.Color4sv(v); }
            else { throw new ArgumentOutOfRangeException(); }
        }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 double values.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(double[] v)
        {
            int length = v.Length;
            if (length == 3) { GL.Color3dv(v); }
            else if (length == 4) { GL.Color4dv(v); }
            else { throw new ArgumentOutOfRangeException(); }
        }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 byte values.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(byte[] v)
        {
            int length = v.Length;
            if (length == 3) { GL.Color3bv(v); }
            else if (length == 4) { GL.Color4bv(v); }
            else { throw new ArgumentOutOfRangeException(); }
        }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 unsigned int values.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(uint[] v)
        {
            int length = v.Length;
            if (length == 3) { GL.Color3uiv(v); }
            else if (length == 4) { GL.Color4uiv(v); }
            else { throw new ArgumentOutOfRangeException(); }
        }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 unsigned short values.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(ushort[] v)
        {
            int length = v.Length;
            if (length == 3) { GL.Color3usv(v); }
            else if (length == 4) { GL.Color4usv(v); }
            else { throw new ArgumentOutOfRangeException(); }
        }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(int red, int green, int blue)
        {
            GL.Color3i(red, green, blue);
        }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(int red, int green, int blue, int alpha)
        {
            GL.Color4i(red, green, blue, alpha);
        }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(short red, short green, short blue)
        {
            GL.Color3s(red, green, blue);
        }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(short red, short green, short blue, short alpha)
        {
            GL.Color4s(red, green, blue, alpha);
        }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(uint red, uint green, uint blue)
        {
            GL.Color3ui(red, green, blue);
        }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(uint red, uint green, uint blue, uint alpha)
        {
            GL.Color4ui(red, green, blue, alpha);
        }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(ushort red, ushort green, ushort blue)
        {
            GL.Color3us(red, green, blue);
        }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(ushort red, ushort green, ushort blue, ushort alpha)
        {
            GL.Color4us(red, green, blue, alpha);
        }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component (between 0 and 1).</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(float red, float green, float blue, float alpha)
        {
            GL.Color4f(red, green, blue, alpha);
        }

        #endregion GL.Color

        #region GL.Vertex

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(double x, double y)
        {
            GL.Vertex2d(x, y);
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(double[] v)
        {
            int length = v.Length;
            if (length == 2) { GL.Vertex2dv(v); }
            else if (length == 3) { GL.Vertex3dv(v); }
            else if (length == 4) { GL.Vertex4dv(v); }
            else { throw new ArgumentOutOfRangeException(); }
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(float x, float y)
        {
            GL.Vertex2f(x, y);
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(int x, int y)
        {
            GL.Vertex2i(x, y);
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(int[] v)
        {
            int length = v.Length;
            if (length == 2) { GL.Vertex2iv(v); }
            else if (length == 3) { GL.Vertex3iv(v); }
            else if (length == 4) { GL.Vertex4iv(v); }
            else { throw new ArgumentOutOfRangeException(); }
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(short x, short y)
        {
            GL.Vertex2s(x, y);
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(short[] v)
        {
            int length = v.Length;
            if (length == 2) { GL.Vertex2sv(v); }
            else if (length == 3) { GL.Vertex3sv(v); }
            else if (length == 4) { GL.Vertex4sv(v); }
            else { throw new ArgumentOutOfRangeException(); }
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(double x, double y, double z)
        {
            GL.Vertex3d(x, y, z);
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(float x, float y, float z)
        {
            GL.Vertex3f(x, y, z);
        }

        /// <summary>
        /// Sets the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">An array of 2, 3 or 4 floats.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(float[] v)
        {
            int length = v.Length;
            if (length == 2) { GL.Vertex2fv(v); }
            else if (length == 3) { GL.Vertex3fv(v); }
            else if (length == 4) { GL.Vertex4fv(v); }
            else { throw new ArgumentOutOfRangeException(); }
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(int x, int y, int z)
        {
            GL.Vertex3i(x, y, z);
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(short x, short y, short z)
        {
            GL.Vertex3s(x, y, z);
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        /// <param name="w">W Value.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(double x, double y, double z, double w)
        {
            GL.Vertex4d(x, y, z, w);
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        /// <param name="w">W Value.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(float x, float y, float z, float w)
        {
            GL.Vertex4f(x, y, z, w);
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        /// <param name="w">W Value.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(int x, int y, int z, int w)
        {
            GL.Vertex4i(x, y, z, w);
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        /// <param name="w">W Value.</param>
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(short x, short y, short z, short w)
        {
            GL.Vertex4s(x, y, z, w);
        }

        #endregion GL.Vertex

        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Begin(PrimitiveMode primitiveMode)
        {
            GL.Begin((uint)primitiveMode);
        }

        #region Draw vertex array object

        /// <summary>
        /// Render	primitives from	array data.
        /// </summary>
        /// <param name="mode">Specifies what kind of primitives to render. Symbolic constants OpenGL.POINTS, OpenGL.LINE_STRIP, OpenGL.LINE_LOOP, OpenGL.LINES, OpenGL.TRIANGLE_STRIP, OpenGL.TRIANGLE_FAN, OpenGL.TRIANGLES, OpenGL.QUAD_STRIP, OpenGL.QUADS, and OpenGL.POLYGON are accepted.</param>
        /// <param name="first">Specifies the starting	index in the enabled arrays.</param>
        /// <param name="count">Specifies the number of indices to be rendered.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawArrays(PrimitiveMode mode, int first, int count)
        {
            GL.DrawArrays((uint)mode, first, count);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultiDrawArrays(PrimitiveMode mode, int[] first, int[] count, int primcount)
        {
            GetDelegateFor<glMultiDrawArrays>()((uint)mode, first, count, primcount);
        }

        /// <summary>
        /// Render primitives from array data.
        /// </summary>
        /// <param name="mode">Specifies what kind of primitives to	render. Symbolic constants OpenGL.POINTS, OpenGL.LINE_STRIP, OpenGL.LINE_LOOP, OpenGL.LINES, OpenGL.TRIANGLE_STRIP, OpenGL.TRIANGLE_FAN, OpenGL.TRIANGLES, OpenGL.QUAD_STRIP, OpenGL.QUADS, and OpenGL.POLYGON are accepted.</param>
        /// <param name="count">Specifies the number of elements to be rendered.</param>
        /// <param name="type">Specifies the type of the values in indices.	Must be one of OpenGL.UNSIGNED_BYTE, OpenGL.UNSIGNED_SHORT, or OpenGL.UNSIGNED_INT.</param>
        /// <param name="indices">Specifies a pointer to the location where the indices are stored.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawElements(PrimitiveMode mode, int count, uint type, IntPtr indices)
        {
            GL.DrawElements((uint)mode, count, type, indices);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultiDrawElements(PrimitiveMode mode, int[] count, uint type, IntPtr indices, int primcount)
        {
            GetDelegateFor<glMultiDrawElements>()((uint)mode, count, type, indices, primcount);
        }

        /// <summary>
        /// Render primitives from array data.
        /// </summary>
        /// <param name="mode">Specifies what kind of primitives to	render. Symbolic constants OpenGL.POINTS, OpenGL.LINE_STRIP, OpenGL.LINE_LOOP, OpenGL.LINES, OpenGL.TRIANGLE_STRIP, OpenGL.TRIANGLE_FAN, OpenGL.TRIANGLES, OpenGL.QUAD_STRIP, OpenGL.QUADS, and OpenGL.POLYGON are accepted.</param>
        /// <param name="count">Specifies the number of elements to be rendered.</param>
        /// <param name="indices">Specifies a pointer to the location where the indices are stored.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawElements(PrimitiveMode mode, int count, uint type, uint[] indices)
        {
            GL.DrawElements((uint)mode, count, type, indices);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawRangeElements(PrimitiveMode mode, uint start, uint end, int count, uint type, IntPtr indices)
        {
            GetDelegateFor<glDrawRangeElements>()((uint)mode, start, end, count, type, indices);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawArraysInstanced(PrimitiveMode mode, int first, int count, int primcount)
        {
            GetDelegateFor<glDrawArraysInstanced>()((uint)mode, first, count, primcount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawElementsInstanced(PrimitiveMode mode, int count, uint type, IntPtr indices, int primcount)
        {
            GetDelegateFor<glDrawElementsInstanced>()((uint)mode, count, type, indices, primcount);
        }

        #endregion Draw vertex array object

        /// <summary>
        /// Specify implementation-specific hints.
        /// </summary>
        /// <param name="target">Specifies a symbolic constant indicating the behavior to be controlled.</param>
        /// <param name="mode">Specifies a symbolic constant indicating the desired behavior.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Hint(HintTarget target, HintMode mode)
        {
            GL.Hint((uint)target, (uint)mode);
        }

        #region GetTarget

        /// <summary>
        /// Use this function to query OpenGL parameter values.
        /// </summary>
        /// <param name="pname">The Parameter to query</param>
        /// <param name="parameters">An array to put the values into.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetInteger(GetTarget pname, int[] parameters)
        {
            GL.GetIntegerv((uint)pname, parameters);
        }

        /// <summary>
        /// This this function to query OpenGL values.
        /// </summary>
        /// <param name="pname">The parameter to query.</param>
        /// <param name="parameters">The parameters</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetFloat(GetTarget pname, float[] parameters)
        {
            GL.GetFloatv((uint)pname, parameters);
        }

        /// <summary>
        /// This function queries OpenGL for data, and puts it in the buffer supplied.
        /// </summary>
        /// <param name="pname">The parameter to query.</param>
        /// <param name="parameters">The buffer to put that data into.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetDouble(GetTarget pname, double[] parameters)
        {
            GL.GetDoublev((uint)pname, parameters);
        }

        /// <summary>
        /// This function queries OpenGL for data, and puts it in the buffer supplied.
        /// </summary>
        /// <param name="pname">The parameter to query.</param>
        /// <param name="parameters"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetBoolean(GetTarget pname, byte[] parameters)
        {
            GL.GetBooleanv((uint)pname, parameters);
        }

        #endregion GetTarget

        /// <summary>
        /// Select flat or smooth shading.
        /// </summary>
        /// <param name="mode">Specifies a symbolic value representing a shading technique. Accepted values are OpenGL.FLAT and OpenGL.SMOOTH. The default is OpenGL.SMOOTH.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ShadeModel(ShadeModel mode)
        {
            GL.ShadeModel((uint)mode);
        }

        /// <summary>
        /// 设置当前VBO的数据。
        /// </summary>
        /// <param name="target"></param>
        /// <param name="data"></param>
        /// <param name="usage"></param>
        public static void BufferData(BufferTarget target, UnmanagedArrayBase data, BufferUsage usage)
        {
            GetDelegateFor<glBufferData>()((uint)target, data.ByteLength, data.Header, (uint)usage);
        }

        /// <summary>
        /// 选择一个VBO作为当前VBO。
        /// </summary>
        /// <param name="target"></param>
        /// <param name="id"></param>
        public static void BindBuffer(BufferTarget target, uint id)
        {
            GL.BindBuffer((uint)target, id);
        }
    }
}
