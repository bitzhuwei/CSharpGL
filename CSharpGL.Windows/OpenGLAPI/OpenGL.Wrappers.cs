using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL
{
    // 用重载和枚举来简化GL编程。
    public static partial class OpenGL
    {
        #region translate, rotate, scale

        /// <summary>
        /// This function applies a translation transformation to the current matrix.
        /// </summary>
        /// <param name="x">The amount to translate along the x axis.</param>
        /// <param name="y">The amount to translate along the y axis.</param>
        /// <param name="z">The amount to translate along the z axis.</param>
        ////[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Translate(double x, double y, double z)
        {
            WinGL.Instance.Translated(x, y, z);
        }

        /// <summary>
        /// This function applies a translation transformation to the current matrix.
        /// </summary>
        /// <param name="x">The amount to translate along the x axis.</param>
        /// <param name="y">The amount to translate along the y axis.</param>
        /// <param name="z">The amount to translate along the z axis.</param>
        ////[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Translate(float x, float y, float z)
        {
            WinGL.Instance.Translatef(x, y, z);
        }

        /// <summary>
        /// This function applies a rotation transformation to the current matrix.
        /// </summary>
        /// <param name="angle">The angle to rotate.</param>
        /// <param name="x">Amount along x.</param>
        /// <param name="y">Amount along y.</param>
        /// <param name="z">Amount along z.</param>
        ////[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Rotate(double angle, double x, double y, double z)
        {
            WinGL.Instance.Rotated(angle, x, y, z);
        }

        /// <summary>
        /// This function applies a rotation transformation to the current matrix.
        /// </summary>
        /// <param name="angle">The angle to rotate.</param>
        /// <param name="x">Amount along x.</param>
        /// <param name="y">Amount along y.</param>
        /// <param name="z">Amount along z.</param>
        ////[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Rotate(float angle, float x, float y, float z)
        {
            WinGL.Instance.Rotatef(angle, x, y, z);
        }

        /// <summary>
        /// This function applies a translation transformation to the current matrix.
        /// </summary>
        /// <param name="x">The amount to translate along the x axis.</param>
        /// <param name="y">The amount to translate along the y axis.</param>
        /// <param name="z">The amount to translate along the z axis.</param>
        ////[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Scale(double x, double y, double z)
        {
            WinGL.Instance.Scaled(x, y, z);
        }

        /// <summary>
        /// This function applies a translation transformation to the current matrix.
        /// </summary>
        /// <param name="x">The amount to translate along the x axis.</param>
        /// <param name="y">The amount to translate along the y axis.</param>
        /// <param name="z">The amount to translate along the z axis.</param>
        ////[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Scale(float x, float y, float z)
        {
            WinGL.Instance.Scalef(x, y, z);
        }

        #endregion translate, rotate, scale

        #region WinGL.Instance.Color

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 255).</param>
        /// <param name="green">Green color component (between 0 and 255).</param>
        /// <param name="blue">Blue color component (between 0 and 255).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(byte red, byte green, byte blue)
        {
            WinGL.Instance.Color3ub(red, green, blue);
        }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 255).</param>
        /// <param name="green">Green color component (between 0 and 255).</param>
        /// <param name="blue">Blue color component (between 0 and 255).</param>
        /// <param name="alpha">Alpha color component (between 0 and 255).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(byte red, byte green, byte blue, byte alpha)
        {
            WinGL.Instance.Color4ub(red, green, blue, alpha);
        }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(double red, double green, double blue)
        {
            WinGL.Instance.Color3d(red, green, blue);
        }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(double red, double green, double blue, double alpha)
        {
            WinGL.Instance.Color4d(red, green, blue, alpha);
        }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(float red, float green, float blue)
        {
            WinGL.Instance.Color3f(red, green, blue);
        }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 float values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(float[] v)
        {
            int length = v.Length;
            if (length == 3) { WinGL.Instance.Color3fv(v); }
            else if (length == 4) { WinGL.Instance.Color4fv(v); }
            else { throw new ArgumentOutOfRangeException(); }
        }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 int values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(int[] v)
        {
            int length = v.Length;
            if (length == 3) { WinGL.Instance.Color3iv(v); }
            else if (length == 4) { WinGL.Instance.Color4iv(v); }
            else { throw new ArgumentOutOfRangeException(); }
        }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 int values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(short[] v)
        {
            int length = v.Length;
            if (length == 3) { WinGL.Instance.Color3sv(v); }
            else if (length == 4) { WinGL.Instance.Color4sv(v); }
            else { throw new ArgumentOutOfRangeException(); }
        }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 double values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(double[] v)
        {
            int length = v.Length;
            if (length == 3) { WinGL.Instance.Color3dv(v); }
            else if (length == 4) { WinGL.Instance.Color4dv(v); }
            else { throw new ArgumentOutOfRangeException(); }
        }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 byte values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(byte[] v)
        {
            int length = v.Length;
            if (length == 3) { WinGL.Instance.Color3bv(v); }
            else if (length == 4) { WinGL.Instance.Color4bv(v); }
            else { throw new ArgumentOutOfRangeException(); }
        }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 unsigned int values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(uint[] v)
        {
            int length = v.Length;
            if (length == 3) { WinGL.Instance.Color3uiv(v); }
            else if (length == 4) { WinGL.Instance.Color4uiv(v); }
            else { throw new ArgumentOutOfRangeException(); }
        }

        /// <summary>
        /// Sets the current color to 'v'.
        /// </summary>
        /// <param name="v">An array of either 3 or 4 unsigned short values.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(ushort[] v)
        {
            int length = v.Length;
            if (length == 3) { WinGL.Instance.Color3usv(v); }
            else if (length == 4) { WinGL.Instance.Color4usv(v); }
            else { throw new ArgumentOutOfRangeException(); }
        }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(int red, int green, int blue)
        {
            WinGL.Instance.Color3i(red, green, blue);
        }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(int red, int green, int blue, int alpha)
        {
            WinGL.Instance.Color4i(red, green, blue, alpha);
        }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(short red, short green, short blue)
        {
            WinGL.Instance.Color3s(red, green, blue);
        }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(short red, short green, short blue, short alpha)
        {
            WinGL.Instance.Color4s(red, green, blue, alpha);
        }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(uint red, uint green, uint blue)
        {
            WinGL.Instance.Color3ui(red, green, blue);
        }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(uint red, uint green, uint blue, uint alpha)
        {
            WinGL.Instance.Color4ui(red, green, blue, alpha);
        }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(ushort red, ushort green, ushort blue)
        {
            WinGL.Instance.Color3us(red, green, blue);
        }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(ushort red, ushort green, ushort blue, ushort alpha)
        {
            WinGL.Instance.Color4us(red, green, blue, alpha);
        }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="red">Red color component (between 0 and 1).</param>
        /// <param name="green">Green color component (between 0 and 1).</param>
        /// <param name="blue">Blue color component (between 0 and 1).</param>
        /// <param name="alpha">Alpha color component (between 0 and 1).</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color(float red, float green, float blue, float alpha)
        {
            WinGL.Instance.Color4f(red, green, blue, alpha);
        }

        #endregion WinGL.Instance.Color

        #region WinGL.Instance.Vertex

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(double x, double y)
        {
            WinGL.Instance.Vertex2d(x, y);
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(double[] v)
        {
            int length = v.Length;
            if (length == 2) { WinGL.Instance.Vertex2dv(v); }
            else if (length == 3) { WinGL.Instance.Vertex3dv(v); }
            else if (length == 4) { WinGL.Instance.Vertex4dv(v); }
            else { throw new ArgumentOutOfRangeException(); }
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(float x, float y)
        {
            WinGL.Instance.Vertex2f(x, y);
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(int x, int y)
        {
            WinGL.Instance.Vertex2i(x, y);
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(int[] v)
        {
            int length = v.Length;
            if (length == 2) { WinGL.Instance.Vertex2iv(v); }
            else if (length == 3) { WinGL.Instance.Vertex3iv(v); }
            else if (length == 4) { WinGL.Instance.Vertex4iv(v); }
            else { throw new ArgumentOutOfRangeException(); }
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(short x, short y)
        {
            WinGL.Instance.Vertex2s(x, y);
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">Specifies the coordinate.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(short[] v)
        {
            int length = v.Length;
            if (length == 2) { WinGL.Instance.Vertex2sv(v); }
            else if (length == 3) { WinGL.Instance.Vertex3sv(v); }
            else if (length == 4) { WinGL.Instance.Vertex4sv(v); }
            else { throw new ArgumentOutOfRangeException(); }
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(double x, double y, double z)
        {
            WinGL.Instance.Vertex3d(x, y, z);
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(float x, float y, float z)
        {
            WinGL.Instance.Vertex3f(x, y, z);
        }

        /// <summary>
        /// Sets the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="v">An array of 2, 3 or 4 floats.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(float[] v)
        {
            int length = v.Length;
            if (length == 2) { WinGL.Instance.Vertex2fv(v); }
            else if (length == 3) { WinGL.Instance.Vertex3fv(v); }
            else if (length == 4) { WinGL.Instance.Vertex4fv(v); }
            else { throw new ArgumentOutOfRangeException(); }
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(int x, int y, int z)
        {
            WinGL.Instance.Vertex3i(x, y, z);
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(short x, short y, short z)
        {
            WinGL.Instance.Vertex3s(x, y, z);
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        /// <param name="w">W Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(double x, double y, double z, double w)
        {
            WinGL.Instance.Vertex4d(x, y, z, w);
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        /// <param name="w">W Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(float x, float y, float z, float w)
        {
            WinGL.Instance.Vertex4f(x, y, z, w);
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        /// <param name="w">W Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(int x, int y, int z, int w)
        {
            WinGL.Instance.Vertex4i(x, y, z, w);
        }

        /// <summary>
        /// Set the current vertex (must be called between 'Begin' and 'End').
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <param name="y">Y Value.</param>
        /// <param name="z">Z Value.</param>
        /// <param name="w">W Value.</param>
        //[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex(short x, short y, short z, short w)
        {
            WinGL.Instance.Vertex4s(x, y, z, w);
        }

        #endregion WinGL.Instance.Vertex

        #region WinGL.Instance.TexCoord

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        public static void TexCoord(double s)
        {
            WinGL.Instance.TexCoord1d(s);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        public static void TexCoord(double[] v)
        {
            if (v.Length == 1)
                WinGL.Instance.TexCoord1dv(v);
            else if (v.Length == 2)
                WinGL.Instance.TexCoord2dv(v);
            else if (v.Length == 3)
                WinGL.Instance.TexCoord3dv(v);
            else if (v.Length == 4)
                WinGL.Instance.TexCoord4dv(v);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        public static void TexCoord(float s)
        {
            WinGL.Instance.TexCoord1f(s);
        }

        /// <summary>
        /// This function sets the current texture coordinates. WARNING: if you
        /// can call something more explicit, like TexCoord2f then call that, it's
        /// much faster.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        public static void TexCoord(float[] v)
        {
            if (v.Length == 1)
                WinGL.Instance.TexCoord1fv(v);
            else if (v.Length == 2)
                WinGL.Instance.TexCoord2fv(v);
            else if (v.Length == 3)
                WinGL.Instance.TexCoord3fv(v);
            else if (v.Length == 4)
                WinGL.Instance.TexCoord4fv(v);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        public static void TexCoord(int s)
        {
            WinGL.Instance.TexCoord1i(s);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        public static void TexCoord(int[] v)
        {
            if (v.Length == 1)
                WinGL.Instance.TexCoord1iv(v);
            else if (v.Length == 2)
                WinGL.Instance.TexCoord2iv(v);
            else if (v.Length == 3)
                WinGL.Instance.TexCoord3iv(v);
            else if (v.Length == 4)
                WinGL.Instance.TexCoord4iv(v);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        public static void TexCoord(short s)
        {
            WinGL.Instance.TexCoord1s(s);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        public static void TexCoord(short[] v)
        {
            if (v.Length == 1)
                WinGL.Instance.TexCoord1sv(v);
            else if (v.Length == 2)
                WinGL.Instance.TexCoord2sv(v);
            else if (v.Length == 3)
                WinGL.Instance.TexCoord3sv(v);
            else if (v.Length == 4)
                WinGL.Instance.TexCoord4sv(v);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        public static void TexCoord(double s, double t)
        {
            WinGL.Instance.TexCoord2d(s, t);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        public static void TexCoord(float s, float t)
        {
            WinGL.Instance.TexCoord2f(s, t);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        public static void TexCoord(int s, int t)
        {
            WinGL.Instance.TexCoord2i(s, t);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        public static void TexCoord(short s, short t)
        {
            WinGL.Instance.TexCoord2s(s, t);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        public static void TexCoord(double s, double t, double r)
        {
            WinGL.Instance.TexCoord3d(s, t, r);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        public static void TexCoord(float s, float t, float r)
        {
            WinGL.Instance.TexCoord3f(s, t, r);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        public static void TexCoord(int s, int t, int r)
        {
            WinGL.Instance.TexCoord3i(s, t, r);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        public static void TexCoord(short s, short t, short r)
        {
            WinGL.Instance.TexCoord3s(s, t, r);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        /// <param name="q">Texture Coordinate.</param>
        public static void TexCoord(double s, double t, double r, double q)
        {
            WinGL.Instance.TexCoord4d(s, t, r, q);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        /// <param name="q">Texture Coordinate.</param>
        public static void TexCoord(float s, float t, float r, float q)
        {
            WinGL.Instance.TexCoord4f(s, t, r, q);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        /// <param name="q">Texture Coordinate.</param>
        public static void TexCoord(int s, int t, int r, int q)
        {
            WinGL.Instance.TexCoord4i(s, t, r, q);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        /// <param name="q">Texture Coordinate.</param>
        public static void TexCoord(short s, short t, short r, short q)
        {
            WinGL.Instance.TexCoord4s(s, t, r, q);
        }

        #endregion WinGL.Instance.TexCoord

        /// <summary>
        ///
        /// </summary>
        /// <param name="mode"></param>
        ////[Obsolete(fixedPipelineIsNotGood, error)]
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Begin(DrawMode mode)
        {
            WinGL.Instance.Begin((uint)mode);
        }

        #region Draw vertex array object

        /// <summary>
        /// Render	primitives from	array data.
        /// </summary>
        /// <param name="mode">Specifies what kind of primitives to render. Symbolic constants WinGL.Instance.POINTS, WinGL.Instance.LINE_STRIP, WinGL.Instance.LINE_LOOP, WinGL.Instance.LINES, WinGL.Instance.TRIANGLE_STRIP, WinGL.Instance.TRIANGLE_FAN, WinGL.Instance.TRIANGLES, WinGL.Instance.QUAD_STRIP, WinGL.Instance.QUADS, and WinGL.Instance.POLYGON are accepted.</param>
        /// <param name="first">Specifies the starting	index in the enabled arrays.</param>
        /// <param name="count">Specifies the number of indices to be rendered.</param>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawArrays(DrawMode mode, int first, int count)
        {
            WinGL.Instance.DrawArrays((uint)mode, first, count);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="first"></param>
        /// <param name="count"></param>
        /// <param name="primcount"></param>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultiDrawArrays(DrawMode mode, int[] first, int[] count, int primcount)
        {
            var function = WinGL.Instance.GetDelegateFor("glMultiDrawArrays", GLDelegates.typeof_void_uint_intN_intN_int) as GLDelegates.void_uint_intN_intN_int;
            function((uint)mode, first, count, primcount);
        }

        /// <summary>
        /// Render primitives from array data.
        /// </summary>
        /// <param name="mode">Specifies what kind of primitives to	render. Symbolic constants WinGL.Instance.POINTS, WinGL.Instance.LINE_STRIP, WinGL.Instance.LINE_LOOP, WinGL.Instance.LINES, WinGL.Instance.TRIANGLE_STRIP, WinGL.Instance.TRIANGLE_FAN, WinGL.Instance.TRIANGLES, WinGL.Instance.QUAD_STRIP, WinGL.Instance.QUADS, and WinGL.Instance.POLYGON are accepted.</param>
        /// <param name="count">Specifies the number of elements to be rendered.</param>
        /// <param name="type">Specifies the type of the values in indices.	Must be one of WinGL.Instance.UNSIGNED_BYTE, WinGL.Instance.UNSIGNED_SHORT, or WinGL.Instance.UNSIGNED_INT.</param>
        /// <param name="indices">Specifies a pointer to the location where the indices are stored.</param>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawElements(DrawMode mode, int count, uint type, IntPtr indices)
        {
            WinGL.Instance.DrawElements((uint)mode, count, type, indices);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="count"></param>
        /// <param name="type"></param>
        /// <param name="indices"></param>
        /// <param name="primcount"></param>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultiDrawElements(DrawMode mode, int[] count, uint type, IntPtr indices, int primcount)
        {
            var function = WinGL.Instance.GetDelegateFor("glMultiDrawElements", GLDelegates.typeof_void_uint_intN_uint_IntPtr_int) as GLDelegates.void_uint_intN_uint_IntPtr_int;
            function((uint)mode, count, type, indices, primcount);
        }

        ///// <summary>
        ///// Render primitives from array data.
        ///// </summary>
        ///// <param name="mode">Specifies what kind of primitives to	render. Symbolic constants WinGL.Instance.POINTS, WinGL.Instance.LINE_STRIP, WinGL.Instance.LINE_LOOP, WinGL.Instance.LINES, WinGL.Instance.TRIANGLE_STRIP, WinGL.Instance.TRIANGLE_FAN, WinGL.Instance.TRIANGLES, WinGL.Instance.QUAD_STRIP, WinGL.Instance.QUADS, and WinGL.Instance.POLYGON are accepted.</param>
        ///// <param name="count">Specifies the number of elements to be rendered.</param>
        ///// <param name="indices">Specifies a pointer to the location where the indices are stored.</param>
        ////[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static void DrawElements(DrawMode mode, int count, uint type, uint[] indices)
        //{
        //    WinGL.Instance.DrawElements((uint)mode, count, type, indices);
        //}

        /// <summary>
        ///
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="count"></param>
        /// <param name="type"></param>
        /// <param name="indices"></param>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawRangeElements(DrawMode mode, uint start, uint end, int count, uint type, IntPtr indices)
        {
            var function = WinGL.Instance.GetDelegateFor("glDrawRangeElements", GLDelegates.typeof_void_uint_uint_uint_int_uint_IntPtr) as GLDelegates.void_uint_uint_uint_int_uint_IntPtr;
            function((uint)mode, start, end, count, type, indices);
        }

        #endregion Draw vertex array object

        /// <summary>
        /// Specify implementation-specific hints.
        /// </summary>
        /// <param name="target">Specifies a symbolic constant indicating the behavior to be controlled.</param>
        /// <param name="mode">Specifies a symbolic constant indicating the desired behavior.</param>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Hint(HintTarget target, HintMode mode)
        {
            WinGL.Instance.Hint((uint)target, (uint)mode);
        }

        #region GetTarget

        /// <summary>
        /// Use this function to query OpenGL parameter values.
        /// </summary>
        /// <param name="pname">The Parameter to query</param>
        /// <param name="parameters">An array to put the values into.</param>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetInteger(GetTarget pname, int[] parameters)
        {
            WinGL.Instance.GetIntegerv((uint)pname, parameters);
        }

        /// <summary>
        /// Use this function to query OpenGL parameter values.
        /// </summary>
        /// <param name="pname">The Parameter to query</param>
        /// <param name="parameters">An array to put the values into.</param>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetInteger(uint pname, int[] parameters)
        {
            WinGL.Instance.GetIntegerv(pname, parameters);
        }

        /// <summary>
        /// This this function to query OpenGL values.
        /// </summary>
        /// <param name="pname">The parameter to query.</param>
        /// <param name="parameters">The parameters</param>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetFloat(GetTarget pname, float[] parameters)
        {
            WinGL.Instance.GetFloatv((uint)pname, parameters);
        }

        /// <summary>
        /// This function queries OpenGL for data, and puts it in the buffer supplied.
        /// </summary>
        /// <param name="pname">The parameter to query.</param>
        /// <param name="parameters">The buffer to put that data into.</param>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetDouble(GetTarget pname, double[] parameters)
        {
            WinGL.Instance.GetDoublev((uint)pname, parameters);
        }

        /// <summary>
        /// This function queries OpenGL for data, and puts it in the buffer supplied.
        /// </summary>
        /// <param name="pname">The parameter to query.</param>
        /// <param name="parameters"></param>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetBoolean(GetTarget pname, byte[] parameters)
        {
            WinGL.Instance.GetBooleanv((uint)pname, parameters);
        }

        #endregion GetTarget

        /// <summary>
        /// Select flat or smooth shading.
        /// </summary>
        /// <param name="mode">Specifies a symbolic value representing a shading technique. Accepted values are WinGL.Instance.FLAT and WinGL.Instance.SMOOTH. The default is WinGL.Instance.SMOOTH.</param>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ShadeModel(ShadeModel mode)
        {
            WinGL.Instance.ShadeModel((uint)mode);
        }

        private static GLDelegates.void_uint_int_IntPtr_uint glBufferData;

        /// <summary>
        /// 设置当前VBO的数据。
        /// </summary>
        /// <param name="target"></param>
        /// <param name="data"></param>
        /// <param name="usage"></param>
        public static void BufferData(BufferTarget target, UnmanagedArrayBase data, BufferUsage usage)
        {
            if (glBufferData == null)
            {
                glBufferData = WinGL.Instance.GetDelegateFor("glBufferData", GLDelegates.typeof_void_uint_int_IntPtr_uint) as GLDelegates.void_uint_int_IntPtr_uint;
            }
            glBufferData((uint)target, data.ByteLength, data.Header, (uint)usage);
        }

        /// <summary>
        /// 设置当前VBO的数据。
        /// </summary>
        /// <param name="target"></param>
        /// <param name="data"></param>
        /// <param name="usage"></param>
        public static void BufferData(uint target, UnmanagedArrayBase data, BufferUsage usage)
        {
            if (glBufferData == null)
            {
                glBufferData = WinGL.Instance.GetDelegateFor("glBufferData", GLDelegates.typeof_void_uint_int_IntPtr_uint) as GLDelegates.void_uint_int_IntPtr_uint;
            }
            glBufferData((uint)target, data.ByteLength, data.Header, (uint)usage);
        }

        //private static WinGL.Instance.glBindBuffer bindBuffer;
        ///// <summary>
        ///// 选择一个VBO作为当前VBO。
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="id"></param>
        //public static void BindBuffer(BufferTarget target, uint id)
        //{
        //    if (bindBuffer == null)
        //    { bindBuffer = WinGL.Instance.GetDelegateFor<WinGL.Instance.glBindBuffer>(); }
        //    bindBuffer((uint)target, id);
        //}

        ///// <summary>
        ///// 选择一个VBO作为当前VBO。
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="id"></param>
        //public static void BindBuffer(uint target, uint id)
        //{
        //    if (bindBuffer == null)
        //    { bindBuffer = WinGL.Instance.GetDelegateFor<WinGL.Instance.glBindBuffer>(); }
        //    bindBuffer(target, id);
        //}

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
            WinGL.Instance.TexImage2D((uint)target, level, (uint)internalformat, width, height, border, (uint)format, (uint)type, pixels);
        }

        /// <summary>
        /// Specify a two-dimensional texture subimage.
        /// Update texture's content.
        /// https://www.khronos.org/opengles/sdk/docs/man/xhtml/glTexSubImage2D.xml
        /// </summary>
        /// <param name="target">Specifies the target texture. Must be WinGL.Instance.TEXTURE_2D.</param>
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
            WinGL.Instance.TexSubImage2D((uint)target, level, xoffset, yoffset, width, height, (uint)format, (uint)type, pixels);
        }

        /// <summary>
        /// Return a texture image.
        /// </summary>
        /// <param name="target">Specifies which texture is to	be obtained. WinGL.Instance.TEXTURE_1D and WinGL.Instance.TEXTURE_2D are accepted.</param>
        /// <param name="level">Specifies the level-of-detail number of the desired image.  Level	0 is the base image level.  Level n is the nth mipmap reduction image.</param>
        /// <param name="format">Specifies a pixel format for the returned data.</param>
        /// <param name="type">Specifies a pixel type for the returned data.</param>
        /// <param name="pixels">Returns the texture image.  Should be	a pointer to an array of the type specified by type.</param>
        public static void GetTexImage(GetTexImageTargets target, int level, GetTexImageFormats format, GetTexImageTypes type, UnmanagedArrayBase pixels)
        {
            WinGL.Instance.GetTexImage((uint)target, level, (uint)format, (uint)type, pixels.Header);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="internalformat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="depth"></param>
        /// <param name="border"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="pixels"></param>
        public static void TexImage3D(uint target, int level, int internalformat, int width, int height, int depth, int border, uint format, uint type, IntPtr pixels)
        {
            var function = WinGL.Instance.GetDelegateFor("glTexImage3D", GLDelegates.typeof_void_uint_int_int_int_int_int_int_uint_uint_IntPtr) as GLDelegates.void_uint_int_int_int_int_int_int_uint_uint_IntPtr;
            function(target, level, internalformat, width, height, depth, border, format, type, pixels);
        }

        /// <summary>
        /// This sets the current drawing mode of polygons (points, lines, filled).
        /// </summary>
        /// <param name="face">The faces this applies to (front, back or both).</param>
        /// <param name="mode">The mode to set to (points, lines, or filled).</param>
        public static void PolygonMode(PolygonModeFaces face, PolygonMode mode)
        {
            WinGL.Instance.PolygonMode((uint)face, (uint)mode);
        }

        #region debugging and profiling

        // TODO: 此函数的'try to remove unused items from rc2ProcDict'部分尚需检测。
        /// <summary>
        /// 设置Debug模式的回调函数。
        /// <para>此函数的'try to remove unused items from rc2ProcDict'部分尚需检测。</para>
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="userParam">建议使用UnmanagedArray.Header</param>
        public static void DebugMessageCallback(DebugProc callback, IntPtr userParam)
        {
            if (innerCallbackProc == null)
            {
                innerCallbackProc = new DEBUGPROC(innerCallback);
            }

            IntPtr renderContext = Win32.wglGetCurrentContext();
            IntPtr deviceContext = Win32.wglGetCurrentDC();
            if (rc2ProcDict.ContainsKey(renderContext))
            {
                rc2ProcDict[renderContext] = callback;
                rc2dcDict[renderContext] = deviceContext;
            }
            else
            {
                rc2ProcDict.Add(renderContext, callback);
                rc2dcDict.Add(renderContext, deviceContext);
                debugProcDictCount++;
                // try to remove unused items from rc2ProcDict
                if (debugProcDictCount > maxDebugProcDictCount)
                {
                    List<IntPtr> unusedRCList = new List<IntPtr>();
                    foreach (var item in rc2dcDict)
                    {
                        if (!Win32.wglMakeCurrent(item.Value, item.Key))// 这种检测方式可行吗？
                        {
                            unusedRCList.Add(item.Key);
                        }
                    }
                    foreach (var item in unusedRCList)
                    {
                        rc2ProcDict.Remove(item);
                        rc2dcDict.Remove(item);
                    }

                    debugProcDictCount -= unusedRCList.Count;

                    maxDebugProcDictCount = debugProcDictCount + 100;

                    Win32.wglMakeCurrent(renderContext, deviceContext);
                }
            }

            var function = WinGL.Instance.GetDelegateFor("glDebugMessageCallback", typeof(glDebugMessageCallback)) as glDebugMessageCallback;
            function(innerCallbackProc, userParam);
        }

        private static int debugProcDictCount = 0;
        private static int maxDebugProcDictCount = 100;
        private static readonly Dictionary<IntPtr, DebugProc> rc2ProcDict = new Dictionary<IntPtr, DebugProc>();
        private static readonly Dictionary<IntPtr, IntPtr> rc2dcDict = new Dictionary<IntPtr, IntPtr>();
        private static DEBUGPROC innerCallbackProc;
        #region debugging and profiling

        // https://www.WinGL.Instance.org/registry/specs/ARB/debug_output.txt
        // https://www.WinGL.Instance.org/wiki/Debug_Output
        /// <summary>
        /// 设置Debug模式的回调函数。
        /// </summary>
        /// <param name="callback">使用一个字段来持有
        /// <para>callback = new WinGL.Instance.DEBUGPROC(this.callbackProc);</para>
        /// 这样就可以避免垃圾回收的问题。
        /// </param>
        /// <param name="userParam">建议使用UnmanagedArray.Header</param>
        public delegate void glDebugMessageCallback(DEBUGPROC callback, IntPtr userParam);

        /// <summary>
        ///
        /// </summary>
        /// <param name="source"></param>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <param name="severity"></param>
        /// <param name="length"></param>
        /// <param name="message"></param>
        /// <param name="userParam"></param>
        public delegate void DEBUGPROC(
            uint source, uint type, uint id, uint severity, int length, StringBuilder message, IntPtr userParam);
        /// <summary>
        /// 设置哪些属性的消息能够/不能被传入callback函数。
        /// </summary>
        /// <param name="source"></param>
        /// <param name="type"></param>
        /// <param name="severity"></param>
        /// <param name="count"></param>
        /// <param name="ids"></param>
        /// <param name="enabled"></param>
        public delegate void glDebugMessageControl(uint source, uint type, uint severity, int count, int[] ids, bool enabled);

        /// <summary>
        /// 用户App或工具用此函数可向Debug流写入一条消息。
        /// </summary>
        /// <param name="source"></param>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <param name="severity"></param>
        /// <param name="length">用-1即可。</param>
        /// <param name="buf"></param>
        public delegate void glDebugMessageInsert(uint source, uint type, uint id, uint severity, int length, StringBuilder buf);

        #endregion debugging and profiling
        private static void innerCallback(
            uint source, uint type, uint id, uint severity, int length, StringBuilder message, IntPtr userParam)
        {
            IntPtr context = Win32.wglGetCurrentContext();
            DebugProc proc = rc2ProcDict[context];

            if (proc != null)
            {
                proc(
                    (DebugSource)source,
                    (DebugType)type,
                    id,
                    (DebugSeverity)severity,
                    length,
                    message,
                    userParam);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="source"></param>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <param name="severity"></param>
        /// <param name="length"></param>
        /// <param name="message"></param>
        /// <param name="userParam"></param>
        public delegate void DebugProc(
            DebugSource source,
            DebugType type,
            uint id,
            DebugSeverity severity,
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
            DebugMessageControlSource source,
            DebugMessageControlType type,
            DebugMessageControlSeverity severity,
            int count,
            int[] ids,
            bool enabled)
        {
            var function = WinGL.Instance.GetDelegateFor("glDebugMessageControl", GLDelegates.typeof_void_uint_uint_uint_int_intN_bool) as GLDelegates.void_uint_uint_uint_int_intN_bool;
            function((uint)source, (uint)type, (uint)severity, count, ids, enabled);
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
            DebugSource source,
            DebugType type,
            uint id,
            DebugSeverity severity,
            int length,
            StringBuilder buf)
        {
            var function = WinGL.Instance.GetDelegateFor("glDebugMessageInsert", GLDelegates.typeof_void_uint_uint_uint_uint_int_StringBuilder) as GLDelegates.void_uint_uint_uint_uint_int_StringBuilder;
            function((uint)source, (uint)type, id, (uint)severity, length, buf);
        }

        #endregion debugging and profiling

        #region transform feedback

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <param name="id"></param>
        public static void BindTransformFeedback(TransformFeedbackTarget target, uint id)
        {
            var function = WinGL.Instance.GetDelegateFor("glBindTransformFeedback", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
            function((uint)target, id);
        }

        private static GLDelegates.void_uint_uint_uint glBindBufferBase;

        /// <summary>
        /// 用于transform feedback。
        /// <para>bind a buffer object to an indexed buffer target.</para>
        /// </summary>
        /// <param name="target">Specifies the target buffer object.</param>
        /// <param name="index">Specify the index of the binding point within the array specified by <paramref name="target"/></param>
        /// <param name="buffer">The name of a buffer object to bind to the specified binding point.</param>
        public static void BindBufferBase(BindBufferBaseTarget target, uint index, uint buffer)
        {
            if (glBindBufferBase == null)
            {
                glBindBufferBase = WinGL.Instance.GetDelegateFor("glBindBufferBase", GLDelegates.typeof_void_uint_uint_uint) as GLDelegates.void_uint_uint_uint;
            }
            glBindBufferBase((uint)target, index, buffer);
        }

        private static GLDelegates.void_uint_uint_uint_int_int glBindBufferRange;

        /// <summary>
        /// bind a range within a buffer object to an indexed buffer target
        /// </summary>
        /// <param name="target">Specifies the target buffer object.</param>
        /// <param name="index">Specify the index of the binding point within the array specified by <paramref name="target"/></param>
        /// <param name="buffer">The name of a buffer object to bind to the specified binding point.</param>
        /// <param name="offset">The starting offset in basic machine units into the buffer object <paramref name="buffer"/>​.</param>
        /// <param name="size">The amount of data in machine units that can be read from the buffer object while used as an indexed target.</param>
        public static void BindBufferRange(BindBufferBaseTarget target, uint index, uint buffer, int offset, int size)
        {
            if (glBindBufferRange == null)
            {
                glBindBufferRange = WinGL.Instance.GetDelegateFor("glBindBufferRange", GLDelegates.typeof_void_uint_uint_uint_int_int) as GLDelegates.void_uint_uint_uint_int_int;
            }
            glBindBufferRange((uint)target, index, buffer, offset, size);
        }

        /// <summary>
        /// bind a range within a buffer object to an indexed buffer target
        /// </summary>
        /// <param name="target">Specifies the target buffer object.</param>
        /// <param name="index">Specify the index of the binding point within the array specified by <paramref name="target"/></param>
        /// <param name="buffer">The name of a buffer object to bind to the specified binding point.</param>
        /// <param name="offset">The starting offset in basic machine units into the buffer object <paramref name="buffer"/>​.</param>
        /// <param name="size">The amount of data in machine units that can be read from the buffer object while used as an indexed target.</param>
        public static void BindBufferRange(uint target, uint index, uint buffer, int offset, int size)
        {
            if (glBindBufferRange == null)
            {
                glBindBufferRange = WinGL.Instance.GetDelegateFor("glBindBufferRange", GLDelegates.typeof_void_uint_uint_uint_int_int) as GLDelegates.void_uint_uint_uint_int_int;
            }
            glBindBufferRange(target, index, buffer, offset, size);
        }

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="primitiveMode"></param>
        //public static void BeginTransformFeedback(BeginTransformFeedbackPrimitiveMode primitiveMode)
        //{
        //    WinGL.Instance.GetDelegateFor<WinGL.Instance.glBeginTransformFeedback>()((uint)primitiveMode);
        //}

        #endregion transform feedback

        #region patch

        /// <summary>
        /// specifies the parameters for patch primitives
        /// </summary>
        /// <param name="pname">Specifies the name of the parameter to set.</param>
        /// <param name="value">Specifies the new value for the parameter given by <paramref name="pname"/>​.</param>
        public static void PatchParameter(PatchParameterName pname, int value)
        {
            var function = WinGL.Instance.GetDelegateFor("glPatchParameteri", GLDelegates.typeof_void_uint_int) as GLDelegates.void_uint_int;
            function((uint)pname, value);
        }

        /// <summary>
        /// specifies the parameters for patch primitives
        /// </summary>
        /// <param name="pname">Specifies the name of the parameter to set.</param>
        /// <param name="values">Specifies the address of an array containing the new values for the parameter given by <paramref name="pname"/>​.</param>
        public static void PatchParameter(PatchParameterName pname, float[] values)
        {
            var function = WinGL.Instance.GetDelegateFor("glPatchParameterfv", GLDelegates.typeof_void_uint_floatN) as GLDelegates.void_uint_floatN;
            function((uint)pname, values);
        }

        #endregion patch

        #region texture

        /// <summary>
        /// defines a barrier ordering memory transactions
        /// </summary>
        /// <param name="barriers">Specifies the barriers to insert.</param>
        public static void MemoryBarrier(MemoryBarrierFlags barriers)
        {
            var function = WinGL.Instance.GetDelegateFor("glMemoryBarrier", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            function((uint)barriers);
        }

        // https://www.WinGL.Instance.org/wiki/GLAPI/glTexStorage1D
        /// <summary>
        /// simultaneously specify storage for all levels of a one-dimensional texture
        /// </summary>
        /// <param name="target"></param>
        /// <param name="levels"></param>
        /// <param name="internalformat"></param>
        /// <param name="width"></param>
        public static void TexStorage1D(TexStorage1DTarget target, int levels, uint internalformat, int width)
        {
            var function = WinGL.Instance.GetDelegateFor("glTexStorage1D", GLDelegates.typeof_void_uint_int_uint_int) as GLDelegates.void_uint_int_uint_int;
            function((uint)target, levels, internalformat, width);
        }

        // https://www.WinGL.Instance.org/wiki/GLAPI/glTexStorage2D
        /// <summary>
        /// simultaneously specify storage for all levels of a two-dimensional or one-dimensional array texture
        /// </summary>
        /// <param name="target"></param>
        /// <param name="levels"></param>
        /// <param name="internalformat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void TexStorage2D(TexStorage2DTarget target, int levels, uint internalformat, int width, int height)
        {
            var function = WinGL.Instance.GetDelegateFor("glTexStorage2D", GLDelegates.typeof_void_uint_int_uint_int_int) as GLDelegates.void_uint_int_uint_int_int;
            function((uint)target, levels, internalformat, width, height);
        }

        // https://www.WinGL.Instance.org/wiki/GLAPI/glTexStorage3D
        /// <summary>
        /// simultaneously specify storage for all levels of a three-dimensional, two-dimensional array or cube-map array texture
        /// </summary>
        /// <param name="target"></param>
        /// <param name="levels"></param>
        /// <param name="internalformat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="depth"></param>
        public static void TexStorage3D(TexStorage3DTarget target, int levels, uint internalformat, int width, int height, int depth)
        {
            var function = WinGL.Instance.GetDelegateFor("glTexStorage3D", GLDelegates.typeof_void_uint_int_uint_int_int_int) as GLDelegates.void_uint_int_uint_int_int_int;
            function((uint)target, levels, internalformat, width, height, depth);
        }

        #endregion texture

        #region Blend

        /// <summary>
        ///
        /// </summary>
        /// <param name="sfactor"></param>
        /// <param name="dfactor"></param>
        public static void BlendFunc(BlendingSourceFactor sfactor, BlendingDestinationFactor dfactor)
        {
            BlendFunc((uint)sfactor, (uint)dfactor);
        }

        #endregion Blend

        #region TexEnv

        /// <summary>
        /// Set texture environment parameters.
        /// </summary>
        /// <param name="target">Specifies a texture environment. Must be WinGL.Instance.TEXTURE_ENV.</param>
        /// <param name="pname">Specifies the symbolic name of a single-valued texture environment parameter. Must be WinGL.Instance.TEXTURE_ENV_MODE.</param>
        /// <param name="param">Specifies a single symbolic constant, one of WinGL.Instance.MODULATE, WinGL.Instance.DECAL, WinGL.Instance.BLEND, or WinGL.Instance.REPLACE.</param>
        public static void TexEnv(uint target, uint pname, float param)
        {
            TexEnvf(target, pname, param);
        }

        /// <summary>
        /// Set texture environment parameters.
        /// </summary>
        /// <param name="target">Specifies a texture environment. Must be WinGL.Instance.TEXTURE_ENV.</param>
        /// <param name="pname">Specifies the symbolic name of a texture environment parameter. Accepted values are WinGL.Instance.TEXTURE_ENV_MODE and WinGL.Instance.TEXTURE_ENV_COLOR.</param>
        /// <param name="parameters">Specifies a pointer to a parameter array that contains either a single symbolic constant or an RGBA color.</param>
        public static void TexEnv(uint target, uint pname, float[] parameters)
        {
            TexEnvfv(target, pname, parameters);
        }

        /// <summary>
        /// Set texture environment parameters.
        /// </summary>
        /// <param name="target">Specifies a texture environment. Must be WinGL.Instance.TEXTURE_ENV.</param>
        /// <param name="pname">Specifies the symbolic name of a single-valued texture environment parameter. Must be WinGL.Instance.TEXTURE_ENV_MODE.</param>
        /// <param name="param">Specifies a single symbolic constant, one of WinGL.Instance.MODULATE, WinGL.Instance.DECAL, WinGL.Instance.BLEND, or WinGL.Instance.REPLACE.</param>
        public static void TexEnv(uint target, uint pname, int param)
        {
            TexEnvi(target, pname, param);
        }

        /// <summary>
        /// Set texture environment parameters.
        /// </summary>
        /// <param name="target">Specifies a texture environment. Must be WinGL.Instance.TEXTURE_ENV.</param>
        /// <param name="pname">Specifies the symbolic name of a texture environment parameter. Accepted values are WinGL.Instance.TEXTURE_ENV_MODE and WinGL.Instance.TEXTURE_ENV_COLOR.</param>
        /// <param name="parameters">Specifies a pointer to a parameter array that contains either a single symbolic constant or an RGBA color.</param>
        public static void TexEnv(uint target, uint pname, int[] parameters)
        {
            TexGeniv(target, pname, parameters);
        }

        #endregion TexEnv

        ///// <summary>
        ///// Return a string	describing the current GL connection.
        ///// </summary>
        ///// <param name="name">Specifies a symbolic constant, one of WinGL.Instance.VENDOR, WinGL.Instance.RENDERER, WinGL.Instance.VERSION, or WinGL.Instance.EXTENSIONS.</param>
        ///// <returns>Pointer to the specified string.</returns>
        //public static unsafe string GetString(StringName name)
        //{
        //    sbyte* pStr = WinGL.Instance.GetString((uint)name);
        //    var str = new string(pStr);

        //    return str;
        //}

        /// <summary>
        /// 读取某一点的颜色
        /// </summary>
        /// <param name="x">以左下角为(0, 0)</param>
        /// <param name="y">以左下角为(0, 0)</param>
        /// <returns></returns>
        public static Color ReadPixel(int x, int y)
        {
            var pixel = new Pixel[1];
            GCHandle pinned = GCHandle.Alloc(pixel, GCHandleType.Pinned);
            IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(pixel, 0);
            WinGL.Instance.ReadPixels(x, y, 1, 1, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, header);
            pinned.Free();
            Color c = pixel[0].ToColor();
            return c;
        }

        //#region Text

        ///// <summary>
        ///// Draws the text.
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="color"></param>
        ///// <param name="faceName"></param>
        ///// <param name="fontSize"></param>
        ///// <param name="text"></param>
        //public static void DrawText(int x, int y, Color color,
        //    string faceName, float fontSize, string text)
        //{
        //    //  Use the font bitmaps object to render the text.
        //    FontBitmaps.DrawText(x, y, color, faceName, fontSize, text);
        //}

        //#endregion Text

        ///// <summary>
        /////
        ///// </summary>
        ///// <returns></returns>
        //public static int[] GetViewport()
        //{
        //    var viewport = new int[4];
        //    WinGL.Instance.GetInteger(GetTarget.Viewport, viewport);

        //    return viewport;
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        //public static void GetViewport(out int x, out int y, out int width, out int height)
        //{
        //    var viewport = new int[4];
        //    WinGL.Instance.GetInteger(GetTarget.Viewport, viewport);

        //    x = viewport[0]; y = viewport[1];
        //    width = viewport[2]; height = viewport[3];
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="near"></param>
        ///// <param name="far"></param>
        //public static void GetDepthRange(out float near, out float far)
        //{
        //    var depthRange = new float[2];
        //    WinGL.Instance.GetFloat(GetTarget.DepthRange, depthRange);

        //    near = depthRange[0]; far = depthRange[1];
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="min"></param>
        ///// <param name="max"></param>
        //public static void LineWidthRange(out float min, out float max)
        //{
        //    float[] lineWidthRange = new float[2];
        //    WinGL.Instance.GetFloat(GetTarget.LineWidthRange, lineWidthRange);
        //    min = lineWidthRange[0];
        //    max = lineWidthRange[1];
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="min"></param>
        ///// <param name="max"></param>
        //public static void PointSizeRange(out float min, out float max)
        //{
        //    float[] pointSizeRange = new float[2];
        //    WinGL.Instance.GetFloat(GetTarget.PointSizeRange, pointSizeRange);
        //    min = pointSizeRange[0];
        //    max = pointSizeRange[1];
        //}

        ///// <summary>
        ///// bind a named texture to a texturing target
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="textureId"></param>
        //public static void BindTexture(TextureTarget target, uint textureId)
        //{
        //    WinGL.Instance.BindTexture((uint)target, textureId);
        //}
    }
}