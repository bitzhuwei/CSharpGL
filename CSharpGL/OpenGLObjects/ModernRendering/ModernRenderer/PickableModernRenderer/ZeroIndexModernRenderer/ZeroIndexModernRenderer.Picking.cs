using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class ZeroIndexModernRenderer : PickableModernRenderer
    {

        public override PickedGeometry Pick(
            RenderEventArgs arg,
            uint stageVertexId,
            int x, int y)
        {
            uint lastVertexId;
            if (!this.GetLastVertexIdOfPickedGeometry(stageVertexId, out lastVertexId))
            { return null; }

            GeometryType geometryType = arg.PickingGeometryType;

            if (geometryType == GeometryType.Point)
            {
                //if (this.OnPrimitiveTest(e, x, y, canvasWidth, canvasHeight))
                DrawMode mode = this.GetIndexBufferPtr().Mode;
                if (this.OnPrimitiveTest(lastVertexId, mode))
                { return PickPoint(stageVertexId, lastVertexId); }
                else
                { return null; }
            }
            else if (geometryType == GeometryType.Line)
            {
                DrawMode mode = this.GetIndexBufferPtr().Mode;
                GeometryType typeOfMode = mode.ToGeometryType();
                if (geometryType == typeOfMode)
                { return PickWhateverItIs(stageVertexId, lastVertexId, mode, typeOfMode); }
                else
                {
                    ZeroIndexLineSearcher searcher = GetLineSearcher(mode);
                    if (searcher != null)// line is from triangle, quad or polygon
                    { return SearchLine(arg, stageVertexId, x, y, lastVertexId, searcher); }
                    else if (mode == DrawMode.Points)
                    { return null; }
                    else
                    { throw new Exception(string.Format("Lack of searcher for [{0}]", mode)); }
                }
            }
            else
            {
                DrawMode mode = this.GetIndexBufferPtr().Mode;
                GeometryType typeOfMode = mode.ToGeometryType();
                if (typeOfMode == geometryType)// I want what it is
                { return PickWhateverItIs(stageVertexId, lastVertexId, mode, typeOfMode); }
                else
                { return null; }
                //{ throw new Exception(string.Format("Lack of searcher for [{0}]", mode)); }
            }
        }

        private PickedGeometry PickWhateverItIs(uint stageVertexId, uint lastVertexId, DrawMode mode, GeometryType typeOfMode)
        {
            PickedGeometry pickedGeometry = new PickedGeometry();
            pickedGeometry.GeometryType = typeOfMode;
            pickedGeometry.StageVertexId = stageVertexId;
            pickedGeometry.From = this;
            // Fill primitive's position information.
            int vertexCount = typeOfMode.GetVertexCount();
            if (vertexCount == -1) { vertexCount = this.positionBufferPtr.Length; }
            if (lastVertexId == 0 && vertexCount == 2)
            {
                // This is when mode is GL_LINE_LOOP and picked last line(the loop back one)
                PickingLastLineInLineLoop(pickedGeometry);
                return pickedGeometry;
            }

            // Other conditions
            switch (typeOfMode)
            {
                case GeometryType.Line:
                    pickedGeometry.Indexes = new uint[] { lastVertexId - 1, lastVertexId, };
                    pickedGeometry.Positions = FillPickedGeometrysPosition(lastVertexId - 1, 2);
                    break;
                case GeometryType.Triangle:
                    if (mode == DrawMode.TriangleFan)
                    {
                        pickedGeometry.Indexes = new uint[] { 0, lastVertexId - 1, lastVertexId, };
                        pickedGeometry.Positions = FillPickedGeometrysPosition(pickedGeometry.Indexes);
                    }
                    else if (mode == DrawMode.TrianglesAdjacency || mode == DrawMode.TriangleStripAdjacency)
                    {
                        pickedGeometry.Indexes = new uint[] { lastVertexId - 4, lastVertexId - 2, lastVertexId, };
                        pickedGeometry.Positions = FillPickedGeometrysPosition(pickedGeometry.Indexes);
                    }
                    else
                    {
                        pickedGeometry.Indexes = new uint[] { lastVertexId - 2, lastVertexId - 1, lastVertexId, };
                        pickedGeometry.Positions = FillPickedGeometrysPosition(lastVertexId - 2, 3);
                    }
                    break;
                case GeometryType.Quad:
                    pickedGeometry.Indexes = new uint[] { lastVertexId - 3, lastVertexId - 2, lastVertexId - 1, lastVertexId, };
                    pickedGeometry.Positions = FillPickedGeometrysPosition(lastVertexId - 3, 4);
                    break;
                case GeometryType.Polygon:
                    pickedGeometry.Indexes = new uint[vertexCount];
                    for (uint i = 0; i < vertexCount; i++)
                    { pickedGeometry.Indexes[i] = lastVertexId + i; }
                    pickedGeometry.Positions = FillPickedGeometrysPosition(0, vertexCount);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return pickedGeometry;
        }

        private PickedGeometry PickPoint(uint stageVertexId, uint lastVertexId)
        {
            PickedGeometry pickedGeometry = new PickedGeometry();
            pickedGeometry.GeometryType = GeometryType.Point;
            pickedGeometry.StageVertexId = stageVertexId;
            pickedGeometry.From = this;
            //int vertexCount = 1;
            pickedGeometry.Indexes = new uint[] { lastVertexId, };
            pickedGeometry.Positions = FillPickedGeometrysPosition(pickedGeometry.Indexes);
            //ContinuousBufferRange(lastVertexId, vertexCount, pickedGeometry);
            return pickedGeometry;
        }

        private PickedGeometry SearchLine(RenderEventArgs arg, uint stageVertexId,
            int x, int y, uint lastVertexId, ZeroIndexLineSearcher searcher)
        {
            PickedGeometry pickedGeometry = new PickedGeometry();
            pickedGeometry.From = this;
            pickedGeometry.GeometryType = GeometryType.Line;
            pickedGeometry.StageVertexId = stageVertexId;
            pickedGeometry.Indexes = searcher.Search(arg,
                x, y, lastVertexId, this);
            GL.BindBuffer(BufferTarget.ArrayBuffer, this.positionBufferPtr.BufferId);
            IntPtr pointer = GL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadWrite);
            unsafe
            {
                var array = (vec3*)pointer.ToPointer();
                var positions = new vec3[2];
                positions[0] = array[pickedGeometry.Indexes[0]];
                positions[1] = array[pickedGeometry.Indexes[1]];
                pickedGeometry.Positions = positions;
            }
            GL.UnmapBuffer(BufferTarget.ArrayBuffer);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            return pickedGeometry;
        }

        /// <summary>
        /// 现在，已经判定了鼠标在某个点上。
        /// 我需要判定此点是否出现在图元上。
        /// now that I know the mouse is picking on some point,
        /// I need to make sure that point should appear.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="canvasWidth"></param>
        /// <param name="canvasHeight"></param>
        /// <returns></returns>
        private bool OnPrimitiveTest(uint lastVertexId, DrawMode mode)
        {
            bool result = false;
            int first = this.zeroIndexBufferPtr.FirstVertex;
            if (first < 0) { return false; }
            int vertexCount = this.zeroIndexBufferPtr.VertexCount;
            if (vertexCount <= 0) { return false; }
            int last = first + vertexCount - 1;
            switch (mode)
            {
                case DrawMode.Points:
                    result = true;
                    break;
                case DrawMode.LineStrip:
                    result = vertexCount > 1;
                    break;
                case DrawMode.LineLoop:
                    result = vertexCount > 1;
                    break;
                case DrawMode.Lines:
                    if (vertexCount > 1)
                    {
                        if (vertexCount % 2 == 0)
                        {
                            result = (first <= lastVertexId && lastVertexId <= last);
                        }
                        else
                        {
                            result = (first <= lastVertexId && lastVertexId <= last - 1);
                        }
                    }
                    break;
                case DrawMode.LineStripAdjacency:
                    if (vertexCount > 3)
                    {
                        result = (first < lastVertexId && lastVertexId < last);
                    }
                    break;
                case DrawMode.LinesAdjacency:
                    if (vertexCount > 3)
                    {
                        var lastPart = last - (last + 1 - first) % 4;
                        if (first <= lastVertexId && lastVertexId <= lastPart)
                        {
                            var m = (lastVertexId - first) % 4;
                            result = (m == 1 || m == 2);
                        }
                    }
                    break;
                case DrawMode.TriangleStrip:
                    if (vertexCount > 2)
                    {
                        result = vertexCount > 2;
                    }
                    break;
                case DrawMode.TriangleFan:
                    if (vertexCount > 2)
                    {
                        result = vertexCount > 2;
                    }
                    break;
                case DrawMode.Triangles:
                    if (vertexCount > 2)
                    {
                        if (first <= lastVertexId)
                        {
                            result = ((vertexCount % 3 == 0) && (lastVertexId <= last))
                                || ((vertexCount % 3 == 1) && (lastVertexId < last))
                                || ((vertexCount % 3 == 2) && (lastVertexId + 1 < last));
                        }
                    }
                    break;
                case DrawMode.TriangleStripAdjacency:
                    if (vertexCount > 5)
                    {
                        var lastPart = last - (last + 1 - first) % 2;
                        if (first <= lastVertexId && lastVertexId <= lastPart)
                        {
                            result = (lastVertexId - first) % 2 == 0;
                        }
                    }
                    break;
                case DrawMode.TrianglesAdjacency:
                    if (vertexCount > 5)
                    {
                        var lastPart = last - (last + 1 - first) % 6;
                        if (first <= lastVertexId && lastVertexId <= lastPart)
                        {
                            result = (lastVertexId - first) % 2 == 0;
                        }
                    }
                    break;
                case DrawMode.Patches:
                    // not know what to do for now
                    break;
                case DrawMode.QuadStrip:
                    if (vertexCount > 3)
                    {
                        if (first <= lastVertexId && lastVertexId <= last)
                        {
                            result = (vertexCount % 2 == 0)
                                || (lastVertexId < last);
                        }
                    }
                    break;
                case DrawMode.Quads:
                    if (vertexCount > 3)
                    {
                        if (first <= lastVertexId && lastVertexId <= last)
                        {
                            var m = vertexCount % 4;
                            if (m == 0) { result = true; }
                            else if (m == 1) { result = lastVertexId + 0 < last; }
                            else if (m == 2) { result = lastVertexId + 1 < last; }
                            else if (m == 3) { result = lastVertexId + 2 < last; }
                            else { throw new Exception("This should never happen!"); }
                        }
                    }
                    break;
                case DrawMode.Polygon:
                    if (vertexCount > 2)
                    {
                        result = (first <= lastVertexId && lastVertexId <= last);
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }

            return result;
        }

        private void PickingLastLineInLineLoop(PickedGeometry pickedGeometry)
        {
            //const int lastVertexId = 0;
            const int vertexCount = 2;
            var offsets = new int[vertexCount] { (this.positionBufferPtr.Length - 1) * this.positionBufferPtr.DataSize * this.positionBufferPtr.DataTypeByteLength, 0, };
            pickedGeometry.Positions = new vec3[vertexCount];
            pickedGeometry.Indexes = new uint[vertexCount];
            for (int i = 0; i < vertexCount; i++)
            {
                GL.BindBuffer(BufferTarget.ArrayBuffer, this.positionBufferPtr.BufferId);
                //IntPtr pointer = GL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadOnly);
                IntPtr pointer = GL.MapBufferRange(BufferTarget.ArrayBuffer,
                    offsets[i],
                    1 * this.positionBufferPtr.DataSize * this.positionBufferPtr.DataTypeByteLength,
                    MapBufferRangeAccess.MapReadBit);
                if (pointer.ToInt32() != 0)
                {
                    unsafe
                    {
                        var array = (vec3*)pointer.ToPointer();
                        pickedGeometry.Positions[i] = array[0];
                    }
                }
                else
                {
                    ErrorCode error = (ErrorCode)GL.GetError();
                    Debug.WriteLine("Error:[{0}] MapBufferRange failed: buffer ID: [{1}]", error, this.positionBufferPtr.BufferId);
                }
                GL.UnmapBuffer(BufferTarget.ArrayBuffer);
                pickedGeometry.Indexes[i] = (uint)offsets[i] / (uint)(this.positionBufferPtr.DataSize * this.positionBufferPtr.DataTypeByteLength);
            }
        }

    }
}
