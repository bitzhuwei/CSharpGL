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
        public static void Begin(PrimitiveModes primitiveMode)
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
        public static void DrawArrays(PrimitiveModes mode, int first, int count)
        {
            GL.DrawArrays((uint)mode, first, count);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultiDrawArrays(PrimitiveModes mode, int[] first, int[] count, int primcount)
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
        public static void DrawElements(PrimitiveModes mode, int count, uint type, IntPtr indices)
        {
            GL.DrawElements((uint)mode, count, type, indices);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultiDrawElements(PrimitiveModes mode, int[] count, uint type, IntPtr indices, int primcount)
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
        public static void DrawElements(PrimitiveModes mode, int count, uint type, uint[] indices)
        {
            GL.DrawElements((uint)mode, count, type, indices);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawRangeElements(PrimitiveModes mode, uint start, uint end, int count, uint type, IntPtr indices)
        {
            GetDelegateFor<glDrawRangeElements>()((uint)mode, start, end, count, type, indices);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawArraysInstanced(PrimitiveModes mode, int first, int count, int primcount)
        {
            GetDelegateFor<glDrawArraysInstanced>()((uint)mode, first, count, primcount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawElementsInstanced(PrimitiveModes mode, int count, uint type, IntPtr indices, int primcount)
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
        public static void TexImage2D(TexImage2DTargets target, int level, TexImage2DFormats internalformat, int width, int height, int border, TexImage2DFormats format, TexImage2DTypes type, IntPtr pixels)
        {
            GL.TexImage2D((uint)target, level, (uint)internalformat, width, height, border, (uint)format, (uint)type, pixels);
        }

        /// <summary>
        /// Specify a two-dimensional texture subimage.
        /// </summary>
        /// <param name="target">Specifies the target texture. Must be OpenGL.TEXTURE_2D.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xoffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yoffset">Specifies a texel offset in the y direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="height">Specifies the height of the texture subimage.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel	data.</param>
        /// <param name="pixels">Specifies a pointer to the image data in memory.</param>
        public static void TexSubImage2D(TexSubImage2DTarget target, int level, int xoffset, int yoffset, int width, int height, TexSubImage2DFormats format, TexSubImage2DType type, IntPtr pixels)
        {
            GL.TexSubImage2D((uint)target, level, xoffset, yoffset, width, height, (uint)format, (uint)type, pixels);
        }

        /// <summary>
        /// Return a texture image.
        /// </summary>
        /// <param name="target">Specifies which texture is to	be obtained. OpenGL.TEXTURE_1D and OpenGL.TEXTURE_2D are accepted.</param>
        /// <param name="level">Specifies the level-of-detail number of the desired image.  Level	0 is the base image level.  Level n is the nth mipmap reduction image.</param>
        /// <param name="format">Specifies a pixel format for the returned data.</param>
        /// <param name="type">Specifies a pixel type for the returned data.</param>
        /// <param name="pixels">Returns the texture image.  Should be	a pointer to an array of the type specified by type.</param>
        public static void GetTexImage(GetTexImageTargets target, int level, GetTexImageFormats format, GetTexImageTypes type, UnmanagedArrayBase pixels)
        {
            GL.GetTexImage((uint)target, level, (uint)format, (uint)type, pixels.Header);
        }

        /// <summary>
        /// This sets the current drawing mode of polygons (points, lines, filled).
        /// </summary>
        /// <param name="face">The faces this applies to (front, back or both).</param>
        /// <param name="mode">The mode to set to (points, lines, or filled).</param>
        public static void PolygonMode(PolygonModeFaces face, PolygonModes mode)
        {
            GL.PolygonMode((uint)face, (uint)mode);
        }

        #region debugging and profiling

        /// <summary>
        /// 设置Debug模式的回调函数。
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="userParam">建议使用<see cref="UnmanagedArray.Header"/></param>
        public static void DebugMessageCallback(DebugProc callback, IntPtr userParam)
        {
            if (innerCallbackProc == null)
            {
                innerCallbackProc = new DEBUGPROC(innerCallback);
            }

            IntPtr context = Win32.wglGetCurrentContext();
            if (debugProcDict.ContainsKey(context))
            {
                debugProcDict[context] = callback;
            }
            else
            {
                debugProcDict.Add(context, callback);
            }

            GetDelegateFor<glDebugMessageCallback>()(innerCallbackProc, userParam);
        }

        static readonly Dictionary<IntPtr, DebugProc> debugProcDict = new Dictionary<IntPtr, DebugProc>();
        static DEBUGPROC innerCallbackProc;

        private static void innerCallback(
            uint source, uint type, uint id, uint severity, int length, StringBuilder message, IntPtr userParam)
        {
            IntPtr context = Win32.wglGetCurrentContext();
            DebugProc proc = debugProcDict[context];

            if (proc != null)
            {
                proc(
                    (Enumerations.DebugSource)source,
                    (Enumerations.DebugType)type,
                    id,
                    (Enumerations.DebugSeverity)severity,
                    length,
                    message,
                    userParam);
            }
        }

        public delegate void DebugProc(
            CSharpGL.Enumerations.DebugSource source,
            CSharpGL.Enumerations.DebugType type,
            uint id,
            CSharpGL.Enumerations.DebugSeverity severity,
            int length,
            StringBuilder message,
            IntPtr userParam);

        /// <summary>
        /// 设置哪些属性的消息能够/不能被传入callback函数。
        /// </summary>
        /// <param name="source"></param>
        /// <param name="type"></param>
        /// <param name="severity"></param>
        /// <param name="count"></param>
        /// <param name="ids"></param>
        /// <param name="enabled"></param>
        public static void DebugMessageControl(
            CSharpGL.Enumerations.DebugMessageControlSource source,
            CSharpGL.Enumerations.DebugMessageControlType type,
            CSharpGL.Enumerations.DebugMessageControlSeverity severity,
            int count,
            int[] ids,
            bool enabled)
        {
            DebugMessageControl((uint)source, (uint)type, (uint)severity, count, ids, enabled);
        }

        /// <summary>
        /// 用户App或工具用此函数可向Debug流写入一条消息。
        /// </summary>
        /// <param name="source"></param>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <param name="severity"></param>
        /// <param name="length">用-1即可。</param>
        /// <param name="buf"></param>
        public static void DebugMessageInsert(
            CSharpGL.Enumerations.DebugSource source,
            CSharpGL.Enumerations.DebugType type,
            uint id,
            CSharpGL.Enumerations.DebugSeverity severity,
            int length,
            StringBuilder buf)
        {
            DebugMessageInsert((uint)source, (uint)type, id, (uint)severity, length, buf);
        }

        #endregion debugging and profiling

        #region transform feedback

        public static void BindTransformFeedback(TransformFeedbackTarget target, uint id)
        {
            BindTransformFeedback((uint)target, id);
        }
        public static void BindBufferBase(BindBufferBaseTarget target, uint index, uint buffer)
        {
            GetDelegateFor<glBindBufferBase>()((uint)target, index, buffer);
        }
        public static void BeginTransformFeedback(BeginTransformFeedbackPrimitiveMode primitiveMode)
        {
            BeginTransformFeedback((uint)primitiveMode);
        }


        #endregion transform feedback
    }
}
