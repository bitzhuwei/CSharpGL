using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public partial class SoftGL : GL
    {
        public override void Accum(uint op, float value)
        {
            //throw new NotImplementedException();
        }

        public override void AlphaFunc(uint func, float ref_notkeword)
        {
            //throw new NotImplementedException();
        }

        public override byte AreTexturesResident(int n, uint[] textures, byte[] residences)
        {
            return 0;
            //throw new NotImplementedException();
        }

        public override void ArrayElement(int i)
        {
            //throw new NotImplementedException();
        }

        public override void Begin(uint mode)
        {
            //throw new NotImplementedException();
        }

        public override void BindTexture(uint target, uint texture)
        {
            //throw new NotImplementedException();
        }

        public override void Bitmap(int width, int height, float xorig, float yorig, float xmove, float ymove, byte[] bitmap)
        {
            //throw new NotImplementedException();
        }

        public override void BlendFunc(uint sfactor, uint dfactor)
        {
            //throw new NotImplementedException();
        }

        public override void CallList(uint list)
        {
            //throw new NotImplementedException();
        }

        public override void CallLists(int n, uint type, IntPtr lists)
        {
            //throw new NotImplementedException();
        }

        public override void CallLists(int n, uint type, uint[] lists)
        {
            //throw new NotImplementedException();
        }

        public override void CallLists(int n, uint type, byte[] lists)
        {
            //throw new NotImplementedException();
        }

        public override void Clear(uint mask)
        {
            //throw new NotImplementedException();
        }

        public override void ClearAccum(float red, float green, float blue, float alpha)
        {
            //throw new NotImplementedException();
        }

        public override void ClearColor(float red, float green, float blue, float alpha)
        {
            //throw new NotImplementedException();
        }

        public override void ClearDepth(double depth)
        {
            //throw new NotImplementedException();
        }

        public override void ClearIndex(float c)
        {
            //throw new NotImplementedException();
        }

        public override void ClearStencil(int s)
        {
            //throw new NotImplementedException();
        }

        public override void ClipPlane(uint plane, double[] equation)
        {
            //throw new NotImplementedException();
        }

        public override void Color3b(byte red, byte green, byte blue)
        {
            //throw new NotImplementedException();
        }

        public override void Color3bv(byte[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Color3d(double red, double green, double blue)
        {
            //throw new NotImplementedException();
        }

        public override void Color3dv(double[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Color3f(float red, float green, float blue)
        {
            //throw new NotImplementedException();
        }

        public override void Color3fv(float[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Color3i(int red, int green, int blue)
        {
            //throw new NotImplementedException();
        }

        public override void Color3iv(int[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Color3s(short red, short green, short blue)
        {
            //throw new NotImplementedException();
        }

        public override void Color3sv(short[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Color3ub(byte red, byte green, byte blue)
        {
            //throw new NotImplementedException();
        }

        public override void Color3ubv(byte[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Color3ui(uint red, uint green, uint blue)
        {
            //throw new NotImplementedException();
        }

        public override void Color3uiv(uint[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Color3us(ushort red, ushort green, ushort blue)
        {
            //throw new NotImplementedException();
        }

        public override void Color3usv(ushort[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Color4b(byte red, byte green, byte blue, byte alpha)
        {
            //throw new NotImplementedException();
        }

        public override void Color4bv(byte[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Color4d(double red, double green, double blue, double alpha)
        {
            //throw new NotImplementedException();
        }

        public override void Color4dv(double[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Color4f(float red, float green, float blue, float alpha)
        {
            //throw new NotImplementedException();
        }

        public override void Color4fv(float[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Color4i(int red, int green, int blue, int alpha)
        {
            //throw new NotImplementedException();
        }

        public override void Color4iv(int[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Color4s(short red, short green, short blue, short alpha)
        {
            //throw new NotImplementedException();
        }

        public override void Color4sv(short[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Color4ub(byte red, byte green, byte blue, byte alpha)
        {
            //throw new NotImplementedException();
        }

        public override void Color4ubv(byte[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Color4ui(uint red, uint green, uint blue, uint alpha)
        {
            //throw new NotImplementedException();
        }

        public override void Color4uiv(uint[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Color4us(ushort red, ushort green, ushort blue, ushort alpha)
        {
            //throw new NotImplementedException();
        }

        public override void Color4usv(ushort[] v)
        {
            //throw new NotImplementedException();
        }

        public override void ColorMask(bool redWritable, bool greenWritable, bool blueWritable, bool alphaWritable)
        {
            //throw new NotImplementedException();
        }

        public override void ColorMaterial(uint face, uint mode)
        {
            //throw new NotImplementedException();
        }

        public override void ColorPointer(int size, uint type, int stride, IntPtr pointer)
        {
            //throw new NotImplementedException();
        }

        public override void CopyPixels(int x, int y, int width, int height, uint type)
        {
            //throw new NotImplementedException();
        }

        public override void CopyTexImage1D(uint target, int level, uint internalFormat, int x, int y, int width, int border)
        {
            //throw new NotImplementedException();
        }

        public override void CopyTexImage2D(uint target, int level, uint internalFormat, int x, int y, int width, int height, int border)
        {
            //throw new NotImplementedException();
        }

        public override void CopyTexSubImage1D(uint target, int level, int xoffset, int x, int y, int width)
        {
            //throw new NotImplementedException();
        }

        public override void CopyTexSubImage2D(uint target, int level, int xoffset, int yoffset, int x, int y, int width, int height)
        {
            //throw new NotImplementedException();
        }

        public override void CullFace(uint mode)
        {
            //throw new NotImplementedException();
        }

        public override void DeleteLists(uint list, int range)
        {
            //throw new NotImplementedException();
        }

        public override void DeleteTextures(int n, uint[] textures)
        {
            //throw new NotImplementedException();
        }

        public override void DepthFunc(uint func)
        {
            //throw new NotImplementedException();
        }

        public override void DepthMask(bool writable)
        {
            //throw new NotImplementedException();
        }

        public override void DepthRange(double zNear, double zFar)
        {
            //throw new NotImplementedException();
        }

        public override void Disable(uint cap)
        {
            //throw new NotImplementedException();
        }

        public override void DisableClientState(uint array)
        {
            //throw new NotImplementedException();
        }

        public override void DrawArrays(uint mode, int first, int count)
        {
            //throw new NotImplementedException();
        }

        public override void MultiDrawArrays(uint mode, int[] first, int[] count, int drawcount)
        {
            //throw new NotImplementedException();
        }

        public override void DrawBuffer(uint mode)
        {
            //throw new NotImplementedException();
        }

        public override void DrawElements(uint mode, int count, uint type, IntPtr indices)
        {
            //throw new NotImplementedException();
        }

        public override void DrawElements(uint mode, int count, uint[] indices)
        {
            //throw new NotImplementedException();
        }

        public override void DrawElements(uint mode, int count, ushort[] indices)
        {
            //throw new NotImplementedException();
        }

        public override void DrawElements(uint mode, int count, byte[] indices)
        {
            //throw new NotImplementedException();
        }

        public override void DrawPixels(int width, int height, uint format, uint type, float[] pixels)
        {
            //throw new NotImplementedException();
        }

        public override void DrawPixels(int width, int height, uint format, uint type, uint[] pixels)
        {
            //throw new NotImplementedException();
        }

        public override void DrawPixels(int width, int height, uint format, uint type, ushort[] pixels)
        {
            //throw new NotImplementedException();
        }

        public override void DrawPixels(int width, int height, uint format, uint type, byte[] pixels)
        {
            //throw new NotImplementedException();
        }

        public override void DrawPixels(int width, int height, uint format, uint type, IntPtr pixels)
        {
            //throw new NotImplementedException();
        }

        public override void EdgeFlag(byte flag)
        {
            //throw new NotImplementedException();
        }

        public override void EdgeFlagPointer(int stride, int[] pointer)
        {
            //throw new NotImplementedException();
        }

        public override void EdgeFlagv(byte[] flag)
        {
            //throw new NotImplementedException();
        }

        public override void Enable(uint cap)
        {
            //throw new NotImplementedException();
        }

        public override void EnableClientState(uint array)
        {
            //throw new NotImplementedException();
        }

        public override void End()
        {
            //throw new NotImplementedException();
        }

        public override void EndList()
        {
            //throw new NotImplementedException();
        }

        public override void EvalCoord1d(double u)
        {
            //throw new NotImplementedException();
        }

        public override void EvalCoord1dv(double[] u)
        {
            //throw new NotImplementedException();
        }

        public override void EvalCoord1f(float u)
        {
            //throw new NotImplementedException();
        }

        public override void EvalCoord1fv(float[] u)
        {
            //throw new NotImplementedException();
        }

        public override void EvalCoord2d(double u, double v)
        {
            //throw new NotImplementedException();
        }

        public override void EvalCoord2dv(double[] u)
        {
            //throw new NotImplementedException();
        }

        public override void EvalCoord2f(float u, float v)
        {
            //throw new NotImplementedException();
        }

        public override void EvalCoord2fv(float[] u)
        {
            //throw new NotImplementedException();
        }

        public override void EvalMesh1(uint mode, int i1, int i2)
        {
            //throw new NotImplementedException();
        }

        public override void EvalMesh2(uint mode, int i1, int i2, int j1, int j2)
        {
            //throw new NotImplementedException();
        }

        public override void EvalPoint1(int i)
        {
            //throw new NotImplementedException();
        }

        public override void EvalPoint2(int i, int j)
        {
            //throw new NotImplementedException();
        }

        public override void FeedbackBuffer(int size, uint type, float[] buffer)
        {
            //throw new NotImplementedException();
        }

        public override void Finish()
        {
            //throw new NotImplementedException();
        }

        public override void Flush()
        {
            //throw new NotImplementedException();
        }

        public override void Fogf(uint pname, float param)
        {
            //throw new NotImplementedException();
        }

        public override void Fogfv(uint pname, float[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void Fogi(uint pname, int param)
        {
            //throw new NotImplementedException();
        }

        public override void Fogiv(uint pname, int[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void FrontFace(uint mode)
        {
            //throw new NotImplementedException();
        }

        public override void Frustum(double left, double right, double bottom, double top, double zNear, double zFar)
        {
            //throw new NotImplementedException();
        }

        public override uint GenLists(int range)
        {
            return 0;
            //throw new NotImplementedException();
        }

        public override void GenTextures(int n, uint[] textures)
        {
            //throw new NotImplementedException();
        }

        public override void GetBooleanv(uint pname, byte[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void GetClipPlane(uint plane, double[] equation)
        {
            //throw new NotImplementedException();
        }

        public override void GetDoublev(uint pname, double[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override uint GetError()
        {
            return 0;
            //throw new NotImplementedException();
        }

        public override void GetFloatv(uint pname, float[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void GetIntegerv(uint pname, int[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void GetLightfv(uint light, uint pname, float[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void GetLightiv(uint light, uint pname, int[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void GetMapdv(uint target, uint query, double[] v)
        {
            //throw new NotImplementedException();
        }

        public override void GetMapfv(uint target, uint query, float[] v)
        {
            //throw new NotImplementedException();
        }

        public override void GetMapiv(uint target, uint query, int[] v)
        {
            //throw new NotImplementedException();
        }

        public override void GetMaterialfv(uint face, uint pname, float[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void GetMaterialiv(uint face, uint pname, int[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void GetPixelMapfv(uint map, float[] values)
        {
            //throw new NotImplementedException();
        }

        public override void GetPixelMapuiv(uint map, uint[] values)
        {
            //throw new NotImplementedException();
        }

        public override void GetPixelMapusv(uint map, ushort[] values)
        {
            //throw new NotImplementedException();
        }

        public override void GetPointerv(uint pname, int[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void GetPolygonStipple(byte[] mask)
        {
            //throw new NotImplementedException();
        }

        public override string GetString(uint name)
        {
            return string.Empty;
            //throw new NotImplementedException();
        }

        public override void GetTexEnvfv(uint target, uint pname, float[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void GetTexEnviv(uint target, uint pname, int[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void GetTexGendv(uint coord, uint pname, double[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void GetTexGenfv(uint coord, uint pname, float[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void GetTexGeniv(uint coord, uint pname, int[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void GetTexImage(uint target, int level, uint format, uint type, IntPtr pixels)
        {
            //throw new NotImplementedException();
        }

        public override void GetTexLevelParameterfv(uint target, int level, uint pname, float[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void GetTexLevelParameteriv(uint target, int level, uint pname, int[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void GetTexParameterfv(uint target, uint pname, float[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void GetTexParameteriv(uint target, uint pname, int[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void Hint(uint target, uint mode)
        {
            //throw new NotImplementedException();
        }

        public override void IndexMask(uint mask)
        {
            //throw new NotImplementedException();
        }

        public override void IndexPointer(uint type, int stride, int[] pointer)
        {
            //throw new NotImplementedException();
        }

        public override void Indexd(double c)
        {
            //throw new NotImplementedException();
        }

        public override void Indexdv(double[] c)
        {
            //throw new NotImplementedException();
        }

        public override void Indexf(float c)
        {
            //throw new NotImplementedException();
        }

        public override void Indexfv(float[] c)
        {
            //throw new NotImplementedException();
        }

        public override void Indexi(int c)
        {
            //throw new NotImplementedException();
        }

        public override void Indexiv(int[] c)
        {
            //throw new NotImplementedException();
        }

        public override void Indexs(short c)
        {
            //throw new NotImplementedException();
        }

        public override void Indexsv(short[] c)
        {
            //throw new NotImplementedException();
        }

        public override void Indexub(byte c)
        {
            //throw new NotImplementedException();
        }

        public override void Indexubv(byte[] c)
        {
            //throw new NotImplementedException();
        }

        public override void InitNames()
        {
            //throw new NotImplementedException();
        }

        public override void InterleavedArrays(uint format, int stride, int[] pointer)
        {
            //throw new NotImplementedException();
        }

        public override byte IsEnabled(uint cap)
        {
            return 0;
            //throw new NotImplementedException();
        }

        public override byte IsList(uint list)
        {
            return 0;
            //throw new NotImplementedException();
        }

        public override byte IsTexture(uint texture)
        {
            return 0;
            //throw new NotImplementedException();
        }

        public override void LightModelf(uint pname, float param)
        {
            //throw new NotImplementedException();
        }

        public override void LightModelfv(uint pname, float[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void LightModeli(uint pname, int param)
        {
            //throw new NotImplementedException();
        }

        public override void LightModeliv(uint pname, int[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void Lightf(uint light, uint pname, float param)
        {
            //throw new NotImplementedException();
        }

        public override void Lightfv(uint light, uint pname, float[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void Lighti(uint light, uint pname, int param)
        {
            //throw new NotImplementedException();
        }

        public override void Lightiv(uint light, uint pname, int[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void LineStipple(int factor, ushort pattern)
        {
            //throw new NotImplementedException();
        }

        public override void LineWidth(float width)
        {
            //throw new NotImplementedException();
        }

        public override void ListBase(uint listbase)
        {
            //throw new NotImplementedException();
        }

        public override void LoadIdentity()
        {
            //throw new NotImplementedException();
        }

        public override void LoadMatrixd(double[] m)
        {
            //throw new NotImplementedException();
        }

        public override void LoadMatrixf(float[] m)
        {
            //throw new NotImplementedException();
        }

        public override void LoadName(uint name)
        {
            //throw new NotImplementedException();
        }

        public override void LogicOp(uint opcode)
        {
            //throw new NotImplementedException();
        }

        public override void Map1d(uint target, double u1, double u2, int stride, int order, IntPtr points)
        {
            //throw new NotImplementedException();
        }

        public override void Map1f(uint target, float u1, float u2, int stride, int order, IntPtr points)
        {
            //throw new NotImplementedException();
        }

        public override void Map2d(uint target, double u1, double u2, int ustride, int uorder, double v1, double v2, int vstride, int vorder, IntPtr points)
        {
            //throw new NotImplementedException();
        }

        public override void Map2f(uint target, float u1, float u2, int ustride, int uorder, float v1, float v2, int vstride, int vorder, IntPtr points)
        {
            //throw new NotImplementedException();
        }

        public override void MapGrid1d(int un, double u1, double u2)
        {
            //throw new NotImplementedException();
        }

        public override void MapGrid1f(int un, float u1, float u2)
        {
            //throw new NotImplementedException();
        }

        public override void MapGrid2d(int un, double u1, double u2, int vn, double v1, double v2)
        {
            //throw new NotImplementedException();
        }

        public override void MapGrid2f(int un, float u1, float u2, int vn, float v1, float v2)
        {
            //throw new NotImplementedException();
        }

        public override void Materialf(uint face, uint pname, float param)
        {
            //throw new NotImplementedException();
        }

        public override void Materialfv(uint face, uint pname, float[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void Materiali(uint face, uint pname, int param)
        {
            //throw new NotImplementedException();
        }

        public override void Materialiv(uint face, uint pname, int[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void MatrixMode(uint mode)
        {
            //throw new NotImplementedException();
        }

        public override void MultMatrixd(double[] m)
        {
            //throw new NotImplementedException();
        }

        public override void MultMatrixf(float[] m)
        {
            //throw new NotImplementedException();
        }

        public override void NewList(uint list, uint mode)
        {
            //throw new NotImplementedException();
        }

        public override void Normal3b(byte nx, byte ny, byte nz)
        {
            //throw new NotImplementedException();
        }

        public override void Normal3bv(byte[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Normal3d(double nx, double ny, double nz)
        {
            //throw new NotImplementedException();
        }

        public override void Normal3dv(double[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Normal3f(float nx, float ny, float nz)
        {
            //throw new NotImplementedException();
        }

        public override void Normal3fv(float[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Normal3i(int nx, int ny, int nz)
        {
            //throw new NotImplementedException();
        }

        public override void Normal3iv(int[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Normal3s(short nx, short ny, short nz)
        {
            //throw new NotImplementedException();
        }

        public override void Normal3sv(short[] v)
        {
            //throw new NotImplementedException();
        }

        public override void NormalPointer(uint type, int stride, IntPtr pointer)
        {
            //throw new NotImplementedException();
        }

        public override void NormalPointer(uint type, int stride, float[] pointer)
        {
            //throw new NotImplementedException();
        }

        public override void Ortho(double left, double right, double bottom, double top, double zNear, double zFar)
        {
            //throw new NotImplementedException();
        }

        public override void PassThrough(float token)
        {
            //throw new NotImplementedException();
        }

        public override void PixelMapfv(uint map, int mapsize, float[] values)
        {
            //throw new NotImplementedException();
        }

        public override void PixelMapuiv(uint map, int mapsize, uint[] values)
        {
            //throw new NotImplementedException();
        }

        public override void PixelMapusv(uint map, int mapsize, ushort[] values)
        {
            //throw new NotImplementedException();
        }

        public override void PixelStoref(uint pname, float param)
        {
            //throw new NotImplementedException();
        }

        public override void PixelStorei(uint pname, int param)
        {
            //throw new NotImplementedException();
        }

        public override void PixelTransferf(uint pname, float param)
        {
            //throw new NotImplementedException();
        }

        public override void PixelTransferi(uint pname, int param)
        {
            //throw new NotImplementedException();
        }

        public override void PixelZoom(float xfactor, float yfactor)
        {
            //throw new NotImplementedException();
        }

        public override void PointSize(float size)
        {
            //throw new NotImplementedException();
        }

        public override void PolygonMode(uint face, uint mode)
        {
            //throw new NotImplementedException();
        }

        public override void PolygonOffset(float factor, float units)
        {
            //throw new NotImplementedException();
        }

        public override void PolygonStipple(byte[] mask)
        {
            //throw new NotImplementedException();
        }

        public override void PopAttrib()
        {
            //throw new NotImplementedException();
        }

        public override void PopClientAttrib()
        {
            //throw new NotImplementedException();
        }

        public override void PopMatrix()
        {
            //throw new NotImplementedException();
        }

        public override void PopName()
        {
            //throw new NotImplementedException();
        }

        public override void PrioritizeTextures(int n, uint[] textures, float[] priorities)
        {
            //throw new NotImplementedException();
        }

        public override void PushAttrib(uint mask)
        {
            //throw new NotImplementedException();
        }

        public override void PushClientAttrib(uint mask)
        {
            //throw new NotImplementedException();
        }

        public override void PushMatrix()
        {
            //throw new NotImplementedException();
        }

        public override void PushName(uint name)
        {
            //throw new NotImplementedException();
        }

        public override void RasterPos2d(double x, double y)
        {
            //throw new NotImplementedException();
        }

        public override void RasterPos2dv(double[] v)
        {
            //throw new NotImplementedException();
        }

        public override void RasterPos2f(float x, float y)
        {
            //throw new NotImplementedException();
        }

        public override void RasterPos2fv(float[] v)
        {
            //throw new NotImplementedException();
        }

        public override void RasterPos2i(int x, int y)
        {
            //throw new NotImplementedException();
        }

        public override void RasterPos2iv(int[] v)
        {
            //throw new NotImplementedException();
        }

        public override void RasterPos2s(short x, short y)
        {
            //throw new NotImplementedException();
        }

        public override void RasterPos2sv(short[] v)
        {
            //throw new NotImplementedException();
        }

        public override void RasterPos3d(double x, double y, double z)
        {
            //throw new NotImplementedException();
        }

        public override void RasterPos3dv(double[] v)
        {
            //throw new NotImplementedException();
        }

        public override void RasterPos3f(float x, float y, float z)
        {
            //throw new NotImplementedException();
        }

        public override void RasterPos3fv(float[] v)
        {
            //throw new NotImplementedException();
        }

        public override void RasterPos3i(int x, int y, int z)
        {
            //throw new NotImplementedException();
        }

        public override void RasterPos3iv(int[] v)
        {
            //throw new NotImplementedException();
        }

        public override void RasterPos3s(short x, short y, short z)
        {
            //throw new NotImplementedException();
        }

        public override void RasterPos3sv(short[] v)
        {
            //throw new NotImplementedException();
        }

        public override void RasterPos4d(double x, double y, double z, double w)
        {
            //throw new NotImplementedException();
        }

        public override void RasterPos4dv(double[] v)
        {
            //throw new NotImplementedException();
        }

        public override void RasterPos4f(float x, float y, float z, float w)
        {
            //throw new NotImplementedException();
        }

        public override void RasterPos4fv(float[] v)
        {
            //throw new NotImplementedException();
        }

        public override void RasterPos4i(int x, int y, int z, int w)
        {
            //throw new NotImplementedException();
        }

        public override void RasterPos4iv(int[] v)
        {
            //throw new NotImplementedException();
        }

        public override void RasterPos4s(short x, short y, short z, short w)
        {
            //throw new NotImplementedException();
        }

        public override void RasterPos4sv(short[] v)
        {
            //throw new NotImplementedException();
        }

        public override void ReadBuffer(uint mode)
        {
            //throw new NotImplementedException();
        }

        public override void ReadPixels(int x, int y, int width, int height, uint format, uint type, byte[] pixels)
        {
            //throw new NotImplementedException();
        }

        public override void ReadPixels(int x, int y, int width, int height, uint format, uint type, IntPtr pixels)
        {
            //throw new NotImplementedException();
        }

        public override void Rectd(double x1, double y1, double x2, double y2)
        {
            //throw new NotImplementedException();
        }

        public override void Rectdv(double[] v1, double[] v2)
        {
            //throw new NotImplementedException();
        }

        public override void Rectf(float x1, float y1, float x2, float y2)
        {
            //throw new NotImplementedException();
        }

        public override void Rectfv(float[] v1, float[] v2)
        {
            //throw new NotImplementedException();
        }

        public override void Recti(int x1, int y1, int x2, int y2)
        {
            //throw new NotImplementedException();
        }

        public override void Rectiv(int[] v1, int[] v2)
        {
            //throw new NotImplementedException();
        }

        public override void Rects(short x1, short y1, short x2, short y2)
        {
            //throw new NotImplementedException();
        }

        public override void Rectsv(short[] v1, short[] v2)
        {
            //throw new NotImplementedException();
        }

        public override int RenderMode(uint mode)
        {
            return 0;
            //throw new NotImplementedException();
        }

        public override void Rotated(double angle, double x, double y, double z)
        {
            //throw new NotImplementedException();
        }

        public override void Rotatef(float angle, float x, float y, float z)
        {
            //throw new NotImplementedException();
        }

        public override void Scaled(double x, double y, double z)
        {
            //throw new NotImplementedException();
        }

        public override void Scalef(float x, float y, float z)
        {
            //throw new NotImplementedException();
        }

        public override void Scissor(int x, int y, int width, int height)
        {
            //throw new NotImplementedException();
        }

        public override void SelectBuffer(int size, uint[] buffer)
        {
            //throw new NotImplementedException();
        }

        public override void ShadeModel(uint mode)
        {
            //throw new NotImplementedException();
        }

        public override void StencilFunc(uint func, int reference, uint mask)
        {
            //throw new NotImplementedException();
        }

        public override void StencilMask(uint mask)
        {
            //throw new NotImplementedException();
        }

        public override void StencilOp(uint fail, uint zfail, uint zpass)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord1d(double s)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord1dv(double[] v)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord1f(float s)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord1fv(float[] v)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord1i(int s)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord1iv(int[] v)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord1s(short s)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord1sv(short[] v)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord2d(double s, double t)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord2dv(double[] v)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord2f(float s, float t)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord2fv(float[] v)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord2i(int s, int t)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord2iv(int[] v)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord2s(short s, short t)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord2sv(short[] v)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord3d(double s, double t, double r)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord3dv(double[] v)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord3f(float s, float t, float r)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord3fv(float[] v)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord3i(int s, int t, int r)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord3iv(int[] v)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord3s(short s, short t, short r)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord3sv(short[] v)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord4d(double s, double t, double r, double q)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord4dv(double[] v)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord4f(float s, float t, float r, float q)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord4fv(float[] v)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord4i(int s, int t, int r, int q)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord4iv(int[] v)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord4s(short s, short t, short r, short q)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoord4sv(short[] v)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoordPointer(int size, uint type, int stride, IntPtr pointer)
        {
            //throw new NotImplementedException();
        }

        public override void TexCoordPointer(int size, uint type, int stride, float[] pointer)
        {
            //throw new NotImplementedException();
        }

        public override void TexEnvf(uint target, uint pname, float param)
        {
            //throw new NotImplementedException();
        }

        public override void TexEnvfv(uint target, uint pname, float[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void TexEnvi(uint target, uint pname, int param)
        {
            //throw new NotImplementedException();
        }

        public override void TexEnviv(uint target, uint pname, int[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void TexGend(uint coord, uint pname, double param)
        {
            //throw new NotImplementedException();
        }

        public override void TexGendv(uint coord, uint pname, double[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void TexGenf(uint coord, uint pname, float param)
        {
            //throw new NotImplementedException();
        }

        public override void TexGenfv(uint coord, uint pname, float[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void TexGeni(uint coord, uint pname, int param)
        {
            //throw new NotImplementedException();
        }

        public override void TexGeniv(uint coord, uint pname, int[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void TexImage1D(uint target, int level, uint internalformat, int width, int border, uint format, uint type, IntPtr pixels)
        {
            //throw new NotImplementedException();
        }

        public override void TexImage2D(uint target, int level, uint internalformat, int width, int height, int border, uint format, uint type, IntPtr pixels)
        {
            //throw new NotImplementedException();
        }

        public override void TexParameterf(uint target, uint pname, float param)
        {
            //throw new NotImplementedException();
        }

        public override void TexParameterfv(uint target, uint pname, float[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void TexParameteri(uint target, uint pname, int param)
        {
            //throw new NotImplementedException();
        }

        public override void TexParameteriv(uint target, uint pname, int[] parameters)
        {
            //throw new NotImplementedException();
        }

        public override void TexSubImage1D(uint target, int level, int xoffset, int width, uint format, uint type, int[] pixels)
        {
            //throw new NotImplementedException();
        }

        public override void TexSubImage1D(uint target, int level, int xoffset, int width, uint format, uint type, IntPtr pixels)
        {
            //throw new NotImplementedException();
        }

        public override void TexSubImage2D(uint target, int level, int xoffset, int yoffset, int width, int height, uint format, uint type, int[] pixels)
        {
            //throw new NotImplementedException();
        }

        public override void TexSubImage2D(uint target, int level, int xoffset, int yoffset, int width, int height, uint format, uint type, IntPtr pixels)
        {
            //throw new NotImplementedException();
        }

        public override void Translated(double x, double y, double z)
        {
            //throw new NotImplementedException();
        }

        public override void Translatef(float x, float y, float z)
        {
            //throw new NotImplementedException();
        }

        public override void Vertex2d(double x, double y)
        {
            //throw new NotImplementedException();
        }

        public override void Vertex2dv(double[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Vertex2f(float x, float y)
        {
            //throw new NotImplementedException();
        }

        public override void Vertex2fv(float[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Vertex2i(int x, int y)
        {
            //throw new NotImplementedException();
        }

        public override void Vertex2iv(int[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Vertex2s(short x, short y)
        {
            //throw new NotImplementedException();
        }

        public override void Vertex2sv(short[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Vertex3d(double x, double y, double z)
        {
            //throw new NotImplementedException();
        }

        public override void Vertex3dv(double[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Vertex3f(float x, float y, float z)
        {
            //throw new NotImplementedException();
        }

        public override void Vertex3fv(float[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Vertex3i(int x, int y, int z)
        {
            //throw new NotImplementedException();
        }

        public override void Vertex3iv(int[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Vertex3s(short x, short y, short z)
        {
            //throw new NotImplementedException();
        }

        public override void Vertex3sv(short[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Vertex4d(double x, double y, double z, double w)
        {
            //throw new NotImplementedException();
        }

        public override void Vertex4dv(double[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Vertex4f(float x, float y, float z, float w)
        {
            //throw new NotImplementedException();
        }

        public override void Vertex4fv(float[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Vertex4i(int x, int y, int z, int w)
        {
            //throw new NotImplementedException();
        }

        public override void Vertex4iv(int[] v)
        {
            //throw new NotImplementedException();
        }

        public override void Vertex4s(short x, short y, short z, short w)
        {
            //throw new NotImplementedException();
        }

        public override void Vertex4sv(short[] v)
        {
            //throw new NotImplementedException();
        }

        public override void VertexPointer(int size, uint type, int stride, IntPtr pointer)
        {
            //throw new NotImplementedException();
        }

        public override void VertexPointer(int size, uint type, int stride, short[] pointer)
        {
            //throw new NotImplementedException();
        }

        public override void VertexPointer(int size, uint type, int stride, int[] pointer)
        {
            //throw new NotImplementedException();
        }

        public override void VertexPointer(int size, uint type, int stride, float[] pointer)
        {
            //throw new NotImplementedException();
        }

        public override void VertexPointer(int size, uint type, int stride, double[] pointer)
        {
            //throw new NotImplementedException();
        }

        public override void Viewport(int x, int y, int width, int height)
        {
            //throw new NotImplementedException();
        }
    }
}