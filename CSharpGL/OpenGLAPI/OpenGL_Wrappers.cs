using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Translate(double x, double y, double z)
        {
            OpenGL.Translated(x, y, z);
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
            OpenGL.Translatef(x, y, z);
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
            OpenGL.Rotated(angle, x, y, z);
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
            OpenGL.Rotatef(angle, x, y, z);
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
            OpenGL.Scaled(x, y, z);
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
            OpenGL.Scalef(x, y, z);
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
            OpenGL.Color3ub(red, green, blue);
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
            OpenGL.Color4ub(red, green, blue, alpha);
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
            OpenGL.Color3d(red, green, blue);
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
            OpenGL.Color4d(red, green, blue, alpha);
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
            OpenGL.Color3f(red, green, blue);
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
            if (length == 3) { OpenGL.Color3fv(v); }
            else if (length == 4) { OpenGL.Color4fv(v); }
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
            if (length == 3) { OpenGL.Color3iv(v); }
            else if (length == 4) { OpenGL.Color4iv(v); }
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
            if (length == 3) { OpenGL.Color3sv(v); }
            else if (length == 4) { OpenGL.Color4sv(v); }
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
            if (length == 3) { OpenGL.Color3dv(v); }
            else if (length == 4) { OpenGL.Color4dv(v); }
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
            if (length == 3) { OpenGL.Color3bv(v); }
            else if (length == 4) { OpenGL.Color4bv(v); }
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
            if (length == 3) { OpenGL.Color3uiv(v); }
            else if (length == 4) { OpenGL.Color4uiv(v); }
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
            if (length == 3) { OpenGL.Color3usv(v); }
            else if (length == 4) { OpenGL.Color4usv(v); }
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
            OpenGL.Color3i(red, green, blue);
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
            OpenGL.Color4i(red, green, blue, alpha);
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
            OpenGL.Color3s(red, green, blue);
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
            OpenGL.Color4s(red, green, blue, alpha);
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
            OpenGL.Color3ui(red, green, blue);
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
            OpenGL.Color4ui(red, green, blue, alpha);
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
            OpenGL.Color3us(red, green, blue);
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
            OpenGL.Color4us(red, green, blue, alpha);
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
            OpenGL.Color4f(red, green, blue, alpha);
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
            OpenGL.Vertex2d(x, y);
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
            if (length == 2) { OpenGL.Vertex2dv(v); }
            else if (length == 3) { OpenGL.Vertex3dv(v); }
            else if (length == 4) { OpenGL.Vertex4dv(v); }
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
            OpenGL.Vertex2f(x, y);
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
            OpenGL.Vertex2i(x, y);
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
            if (length == 2) { OpenGL.Vertex2iv(v); }
            else if (length == 3) { OpenGL.Vertex3iv(v); }
            else if (length == 4) { OpenGL.Vertex4iv(v); }
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
            OpenGL.Vertex2s(x, y);
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
            if (length == 2) { OpenGL.Vertex2sv(v); }
            else if (length == 3) { OpenGL.Vertex3sv(v); }
            else if (length == 4) { OpenGL.Vertex4sv(v); }
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
            OpenGL.Vertex3d(x, y, z);
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
            OpenGL.Vertex3f(x, y, z);
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
            if (length == 2) { OpenGL.Vertex2fv(v); }
            else if (length == 3) { OpenGL.Vertex3fv(v); }
            else if (length == 4) { OpenGL.Vertex4fv(v); }
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
            OpenGL.Vertex3i(x, y, z);
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
            OpenGL.Vertex3s(x, y, z);
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
            OpenGL.Vertex4d(x, y, z, w);
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
            OpenGL.Vertex4f(x, y, z, w);
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
            OpenGL.Vertex4i(x, y, z, w);
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
            OpenGL.Vertex4s(x, y, z, w);
        }

        #endregion GL.Vertex

        #region GL.TexCoord


        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        public static void TexCoord(double s)
        {
            OpenGL.TexCoord1d(s);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        public static void TexCoord(double[] v)
        {
            if (v.Length == 1)
                OpenGL.TexCoord1dv(v);
            else if (v.Length == 2)
                OpenGL.TexCoord2dv(v);
            else if (v.Length == 3)
                OpenGL.TexCoord3dv(v);
            else if (v.Length == 4)
                OpenGL.TexCoord4dv(v);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        public static void TexCoord(float s)
        {
            OpenGL.TexCoord1f(s);
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
                OpenGL.TexCoord1fv(v);
            else if (v.Length == 2)
                OpenGL.TexCoord2fv(v);
            else if (v.Length == 3)
                OpenGL.TexCoord3fv(v);
            else if (v.Length == 4)
                OpenGL.TexCoord4fv(v);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        public static void TexCoord(int s)
        {
            OpenGL.TexCoord1i(s);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        public static void TexCoord(int[] v)
        {
            if (v.Length == 1)
                OpenGL.TexCoord1iv(v);
            else if (v.Length == 2)
                OpenGL.TexCoord2iv(v);
            else if (v.Length == 3)
                OpenGL.TexCoord3iv(v);
            else if (v.Length == 4)
                OpenGL.TexCoord4iv(v);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        public static void TexCoord(short s)
        {
            OpenGL.TexCoord1s(s);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="v">Array of 1,2,3 or 4 Texture Coordinates.</param>
        public static void TexCoord(short[] v)
        {
            if (v.Length == 1)
                OpenGL.TexCoord1sv(v);
            else if (v.Length == 2)
                OpenGL.TexCoord2sv(v);
            else if (v.Length == 3)
                OpenGL.TexCoord3sv(v);
            else if (v.Length == 4)
                OpenGL.TexCoord4sv(v);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        public static void TexCoord(double s, double t)
        {
            OpenGL.TexCoord2d(s, t);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        public static void TexCoord(float s, float t)
        {
            OpenGL.TexCoord2f(s, t);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        public static void TexCoord(int s, int t)
        {
            OpenGL.TexCoord2i(s, t);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        public static void TexCoord(short s, short t)
        {
            OpenGL.TexCoord2s(s, t);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        public static void TexCoord(double s, double t, double r)
        {
            OpenGL.TexCoord3d(s, t, r);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        public static void TexCoord(float s, float t, float r)
        {
            OpenGL.TexCoord3f(s, t, r);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        public static void TexCoord(int s, int t, int r)
        {
            OpenGL.TexCoord3i(s, t, r);
        }

        /// <summary>
        /// This function sets the current texture coordinates.
        /// </summary>
        /// <param name="s">Texture Coordinate.</param>
        /// <param name="t">Texture Coordinate.</param>
        /// <param name="r">Texture Coordinate.</param>
        public static void TexCoord(short s, short t, short r)
        {
            OpenGL.TexCoord3s(s, t, r);
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
            OpenGL.TexCoord4d(s, t, r, q);
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
            OpenGL.TexCoord4f(s, t, r, q);
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
            OpenGL.TexCoord4i(s, t, r, q);
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
            OpenGL.TexCoord4s(s, t, r, q);
        }


        #endregion GL.TexCoord

        [Obsolete(fixedPipelineIsNotGood, error)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Begin(DrawMode mode)
        {
            OpenGL.Begin((uint)mode);
        }

        #region Draw vertex array object

        /// <summary>
        /// Render	primitives from	array data.
        /// </summary>
        /// <param name="mode">Specifies what kind of primitives to render. Symbolic constants OpenGL.POINTS, OpenGL.LINE_STRIP, OpenGL.LINE_LOOP, OpenGL.LINES, OpenGL.TRIANGLE_STRIP, OpenGL.TRIANGLE_FAN, OpenGL.TRIANGLES, OpenGL.QUAD_STRIP, OpenGL.QUADS, and OpenGL.POLYGON are accepted.</param>
        /// <param name="first">Specifies the starting	index in the enabled arrays.</param>
        /// <param name="count">Specifies the number of indices to be rendered.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawArrays(DrawMode mode, int first, int count)
        {
            OpenGL.DrawArrays((uint)mode, first, count);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultiDrawArrays(DrawMode mode, int[] first, int[] count, int primcount)
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
        public static void DrawElements(DrawMode mode, int count, uint type, IntPtr indices)
        {
            OpenGL.DrawElements((uint)mode, count, type, indices);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultiDrawElements(DrawMode mode, int[] count, uint type, IntPtr indices, int primcount)
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
        public static void DrawElements(DrawMode mode, int count, uint type, uint[] indices)
        {
            OpenGL.DrawElements((uint)mode, count, type, indices);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawRangeElements(DrawMode mode, uint start, uint end, int count, uint type, IntPtr indices)
        {
            GetDelegateFor<glDrawRangeElements>()((uint)mode, start, end, count, type, indices);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawArraysInstanced(DrawMode mode, int first, int count, int primcount)
        {
            GetDelegateFor<glDrawArraysInstanced>()((uint)mode, first, count, primcount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawElementsInstanced(DrawMode mode, int count, uint type, IntPtr indices, int primcount)
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
            OpenGL.Hint((uint)target, (uint)mode);
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
            OpenGL.GetIntegerv((uint)pname, parameters);
        }

        /// <summary>
        /// This this function to query OpenGL values.
        /// </summary>
        /// <param name="pname">The parameter to query.</param>
        /// <param name="parameters">The parameters</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetFloat(GetTarget pname, float[] parameters)
        {
            OpenGL.GetFloatv((uint)pname, parameters);
        }

        /// <summary>
        /// This function queries OpenGL for data, and puts it in the buffer supplied.
        /// </summary>
        /// <param name="pname">The parameter to query.</param>
        /// <param name="parameters">The buffer to put that data into.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetDouble(GetTarget pname, double[] parameters)
        {
            OpenGL.GetDoublev((uint)pname, parameters);
        }

        /// <summary>
        /// This function queries OpenGL for data, and puts it in the buffer supplied.
        /// </summary>
        /// <param name="pname">The parameter to query.</param>
        /// <param name="parameters"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetBoolean(GetTarget pname, byte[] parameters)
        {
            OpenGL.GetBooleanv((uint)pname, parameters);
        }

        #endregion GetTarget

        /// <summary>
        /// Select flat or smooth shading.
        /// </summary>
        /// <param name="mode">Specifies a symbolic value representing a shading technique. Accepted values are OpenGL.FLAT and OpenGL.SMOOTH. The default is OpenGL.SMOOTH.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ShadeModel(ShadeModel mode)
        {
            OpenGL.ShadeModel((uint)mode);
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
            OpenGL.GetDelegateFor<OpenGL.glBindBuffer>()((uint)target, id);
        }


        /// <summary>
        /// 把服务端（GPU）上的当前Buffer Object映射到客户端（CPU）的内存上。
        /// </summary>
        /// <param name="target"></param>
        /// <param name="access"></param>
        /// <returns></returns>
        public static IntPtr MapBuffer(BufferTarget target, MapBufferAccess access)
        {
            return GetDelegateFor<glMapBuffer>()((uint)target, (uint)access);
        }

        /// <summary>
        /// 把客户端（CPU）上的当前Buffer Object映射到服务端（GPU）的内存上。
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool UnmapBuffer(BufferTarget target)
        {
            return GetDelegateFor<glUnmapBuffer>()((uint)target);
        }

        public static IntPtr MapBufferRange(BufferTarget target, int offset, int length, MapBufferRangeAccess access)
        {
            return GetDelegateFor<OpenGL.glMapBufferRange>()((uint)target, offset, length, (uint)access);
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
            OpenGL.TexImage2D((uint)target, level, (uint)internalformat, width, height, border, (uint)format, (uint)type, pixels);
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
            OpenGL.TexSubImage2D((uint)target, level, xoffset, yoffset, width, height, (uint)format, (uint)type, pixels);
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
            OpenGL.GetTexImage((uint)target, level, (uint)format, (uint)type, pixels.Header);
        }

        public static void TexImage3D(uint target, int level, int internalformat, int width, int height, int depth, int border, uint format, uint type, IntPtr pixels)
        {
            OpenGL.GetDelegateFor<OpenGL.glTexImage3D>()(target, level, internalformat, width, height, depth, border, format, type, pixels);
        }

        /// <summary>
        /// This sets the current drawing mode of polygons (points, lines, filled).
        /// </summary>
        /// <param name="face">The faces this applies to (front, back or both).</param>
        /// <param name="mode">The mode to set to (points, lines, or filled).</param>
        public static void PolygonMode(PolygonModeFaces face, PolygonModes mode)
        {
            OpenGL.PolygonMode((uint)face, (uint)mode);
        }

        #region debugging and profiling

        // TODO: 此函数的'try to remove unused items from rc2ProcDict'部分尚需检测。
        /// <summary>
        /// 设置Debug模式的回调函数。
        /// <para>此函数的'try to remove unused items from rc2ProcDict'部分尚需检测。</para>
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="userParam">建议使用<see cref="UnmanagedArray.Header"/></param>
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

            GetDelegateFor<glDebugMessageCallback>()(innerCallbackProc, userParam);
        }

        static int debugProcDictCount = 0;
        static int maxDebugProcDictCount = 100;
        static readonly Dictionary<IntPtr, DebugProc> rc2ProcDict = new Dictionary<IntPtr, DebugProc>();
        static readonly Dictionary<IntPtr, IntPtr> rc2dcDict = new Dictionary<IntPtr, IntPtr>();
        static DEBUGPROC innerCallbackProc;

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

        public delegate void DebugProc(
            CSharpGL.DebugSource source,
            CSharpGL.DebugType type,
            uint id,
            CSharpGL.DebugSeverity severity,
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
            CSharpGL.DebugMessageControlSource source,
            CSharpGL.DebugMessageControlType type,
            CSharpGL.DebugMessageControlSeverity severity,
            int count,
            int[] ids,
            bool enabled)
        {
            OpenGL.GetDelegateFor<OpenGL.glDebugMessageControl>()((uint)source, (uint)type, (uint)severity, count, ids, enabled);
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
            CSharpGL.DebugSource source,
            CSharpGL.DebugType type,
            uint id,
            CSharpGL.DebugSeverity severity,
            int length,
            StringBuilder buf)
        {
            OpenGL.GetDelegateFor<OpenGL.glDebugMessageInsert>()((uint)source, (uint)type, id, (uint)severity, length, buf);
        }

        #endregion debugging and profiling

        #region transform feedback

        public static void BindTransformFeedback(TransformFeedbackTarget target, uint id)
        {
            OpenGL.GetDelegateFor<OpenGL.glBindTransformFeedback>()((uint)target, id);
        }

        /// <summary>
        /// 用于transform feedback。
        /// <para>bind a buffer object to an indexed buffer target.</para>
        /// </summary>
        /// <param name="target">Specifies the target buffer object.</param>
        /// <param name="index">Specify the index of the binding point within the array specified by <paramref name="target"/></param>
        /// <param name="buffer">The name of a buffer object to bind to the specified binding point.</param>
        public static void BindBufferBase(TransformFeedbackBufferTarget target, uint index, uint buffer)
        {
            OpenGL.GetDelegateFor<OpenGL.glBindBufferBase>()((uint)target, index, buffer);
        }
        /// <summary>
        /// bind a range within a buffer object to an indexed buffer target
        /// </summary>
        /// <param name="target">Specifies the target buffer object.</param>
        /// <param name="index">Specify the index of the binding point within the array specified by <paramref name="target"/></param>
        /// <param name="buffer">The name of a buffer object to bind to the specified binding point.</param>
        /// <param name="offset">The starting offset in basic machine units into the buffer object <paramref name="buffer"/>​.</param>
        /// <param name="size">The amount of data in machine units that can be read from the buffer object while used as an indexed target.</param>
        public static void BindBufferRange(TransformFeedbackBufferTarget target, uint index, uint buffer, int offset, int size)
        {
            OpenGL.GetDelegateFor<OpenGL.glBindBufferRange>()((uint)target, index, buffer, offset, size);
        }
        public static void BeginTransformFeedback(BeginTransformFeedbackPrimitiveMode primitiveMode)
        {
            OpenGL.GetDelegateFor<OpenGL.glBeginTransformFeedback>()((uint)primitiveMode);
        }


        #endregion transform feedback


        #region patch

        /// <summary>
        /// specifies the parameters for patch primitives
        /// </summary>
        /// <param name="pname">Specifies the name of the parameter to set.</param>
        /// <param name="value">Specifies the new value for the parameter given by <paramref name="pname"/>​.</param>
        public static void PatchParameter(PatchParameterName pname, int value)
        {
            OpenGL.GetDelegateFor<OpenGL.glPatchParameteri>()((uint)pname, value);
        }

        /// <summary>
        /// specifies the parameters for patch primitives
        /// </summary>
        /// <param name="pname">Specifies the name of the parameter to set.</param>
        /// <param name="values">Specifies the address of an array containing the new values for the parameter given by <paramref name="pname"/>​.</param>
        public static void PatchParameter(PatchParameterName pname, float[] values)
        {
            OpenGL.GetDelegateFor<OpenGL.glPatchParameterfv>()((uint)pname, values);
        }

        #endregion patch

        #region texture

        /// <summary>
        /// defines a barrier ordering memory transactions
        /// </summary>
        /// <param name="barriers">Specifies the barriers to insert.</param>
        public static void MemoryBarrier(MemoryBarrierFlags barriers)
        {
            OpenGL.GetDelegateFor<OpenGL.glMemoryBarrier>()((uint)barriers);
        }

        // https://www.opengl.org/wiki/GLAPI/glTexStorage1D
        /// <summary>
        /// simultaneously specify storage for all levels of a one-dimensional texture
        /// </summary>
        /// <param name="target"></param>
        /// <param name="levels"></param>
        /// <param name="internalformat"></param>
        /// <param name="width"></param>
        public static void TexStorage1D(TexStorage1DTarget target, int levels, uint internalformat, int width)
        {
            OpenGL.GetDelegateFor<OpenGL.glTexStorage1D>()((uint)target, levels, internalformat, width);
        }

        // https://www.opengl.org/wiki/GLAPI/glTexStorage2D
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
            OpenGL.GetDelegateFor<OpenGL.glTexStorage2D>()((uint)target, levels, internalformat, width, height);
        }

        // https://www.opengl.org/wiki/GLAPI/glTexStorage3D
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
            OpenGL.GetDelegateFor<OpenGL.glTexStorage3D>()((uint)target, levels, internalformat, width, height, depth);
        }
        #endregion texture

        #region Blend

        public static void BlendFunc(BlendingSourceFactor sfactor, BlendingDestinationFactor dfactor)
        {
            BlendFunc((uint)sfactor, (uint)dfactor);
        }


        #endregion Blend

        #region TexEnv

        /// <summary>
        /// Set texture environment parameters.
        /// </summary>
        /// <param name="target">Specifies a texture environment. Must be OpenGL.TEXTURE_ENV.</param>
        /// <param name="pname">Specifies the symbolic name of a single-valued texture environment parameter. Must be OpenGL.TEXTURE_ENV_MODE.</param>
        /// <param name="param">Specifies a single symbolic constant, one of OpenGL.MODULATE, OpenGL.DECAL, OpenGL.BLEND, or OpenGL.REPLACE.</param>
        public static void TexEnv(uint target, uint pname, float param)
        {
            TexEnvf(target, pname, param);
        }

        /// <summary>
        /// Set texture environment parameters.
        /// </summary>
        /// <param name="target">Specifies a texture environment. Must be OpenGL.TEXTURE_ENV.</param>
        /// <param name="pname">Specifies the symbolic name of a texture environment parameter. Accepted values are OpenGL.TEXTURE_ENV_MODE and OpenGL.TEXTURE_ENV_COLOR.</param>
        /// <param name="parameters">Specifies a pointer to a parameter array that contains either a single symbolic constant or an RGBA color.</param>
        public static void TexEnv(uint target, uint pname, float[] parameters)
        {
            TexEnvfv(target, pname, parameters);
        }

        /// <summary>
        /// Set texture environment parameters.
        /// </summary>
        /// <param name="target">Specifies a texture environment. Must be OpenGL.TEXTURE_ENV.</param>
        /// <param name="pname">Specifies the symbolic name of a single-valued texture environment parameter. Must be OpenGL.TEXTURE_ENV_MODE.</param>
        /// <param name="param">Specifies a single symbolic constant, one of OpenGL.MODULATE, OpenGL.DECAL, OpenGL.BLEND, or OpenGL.REPLACE.</param>
        public static void TexEnv(uint target, uint pname, int param)
        {
            TexEnvi(target, pname, param);
        }

        /// <summary>
        /// Set texture environment parameters.
        /// </summary>
        /// <param name="target">Specifies a texture environment. Must be OpenGL.TEXTURE_ENV.</param>
        /// <param name="pname">Specifies the symbolic name of a texture environment parameter. Accepted values are OpenGL.TEXTURE_ENV_MODE and OpenGL.TEXTURE_ENV_COLOR.</param>
        /// <param name="parameters">Specifies a pointer to a parameter array that contains either a single symbolic constant or an RGBA color.</param>
        public static void TexEnv(uint target, uint pname, int[] parameters)
        {
            TexGeniv(target, pname, parameters);
        }

        #endregion TexEnv

        /// <summary>
        /// Return a string	describing the current GL connection.
        /// </summary>
        /// <param name="name">Specifies a symbolic constant, one of OpenGL.VENDOR, OpenGL.RENDERER, OpenGL.VERSION, or OpenGL.EXTENSIONS.</param>
        /// <returns>Pointer to the specified string.</returns>
        public static unsafe string GetString(uint name)
        {
            sbyte* pStr = OpenGL.glGetString(name);
            var str = new string(pStr);

            return str;
        }

        /// <summary>
        /// 读取某一点的颜色
        /// </summary>
        /// <param name="x">以左下角为(0, 0)</param>
        /// <param name="y">以左下角为(0, 0)</param>
        /// <returns></returns>
        public static Color ReadPixel(int x, int y)
        {
            using (var pdata = new UnmanagedArray<Pixel>(1))
            {
                OpenGL.ReadPixels(x, y, 1, 1, OpenGL.GL_RGBA, OpenGL.GL_UNSIGNED_BYTE, pdata.Header);
                unsafe
                {
                    var array = (Pixel*)pdata.Header.ToPointer();
                    Color c = array[0].ToColor();
                    return c;
                }
            }
        }

        #region Text

        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="r">The r.</param>
        /// <param name="g">The g.</param>
        /// <param name="b">The b.</param>
        /// <param name="faceName">Name of the face.</param>
        /// <param name="fontSize">Size of the font.</param>
        /// <param name="text">The text.</param>
        public static void DrawText(int x, int y, Color color,
            string faceName, float fontSize, string text)
        {
            //  Use the font bitmaps object to render the text.
            FontBitmaps.DrawText(x, y, color, faceName, fontSize, text);
        }

        #endregion

        public static int[] GetViewport()
        {
            var viewport = new int[4];
            OpenGL.GetInteger(GetTarget.Viewport, viewport);

            return viewport;
        }

        public static void GetViewport(out int x, out int y, out int width, out int height)
        {
            var viewport = new int[4];
            OpenGL.GetInteger(GetTarget.Viewport, viewport);

            x = viewport[0]; y = viewport[1];
            width = viewport[2]; height = viewport[3];
        }

        public static void GetDepthRange(out float near, out float far)
        {
            var depthRange = new float[2];
            OpenGL.GetFloat(GetTarget.DepthRange, depthRange);

            near = depthRange[0]; far = depthRange[1];
        }

        public static void LineWidthRange(out float min, out float max)
        {
            float[] lineWidthRange = new float[2];
            OpenGL.GetFloat(GetTarget.LineWidthRange, lineWidthRange);
            min = lineWidthRange[0];
            max = lineWidthRange[1];
        }

        public static void PointSizeRange(out float min, out float max)
        {
            float[] pointSizeRange = new float[2];
            OpenGL.GetFloat(GetTarget.PointSizeRange, pointSizeRange);
            min = pointSizeRange[0];
            max = pointSizeRange[1];
        }
    }
}
