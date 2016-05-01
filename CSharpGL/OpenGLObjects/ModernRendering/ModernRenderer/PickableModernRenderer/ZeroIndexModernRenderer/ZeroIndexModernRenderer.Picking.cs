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
        static Dictionary<DrawMode, ZeroIndexLineSearcher> lineSearchDict;

        static ZeroIndexLineSearcher GetLineSearcher(DrawMode mode)
        {
            if (lineSearchDict == null)
            {
                var dict = new Dictionary<DrawMode, ZeroIndexLineSearcher>();
                dict.Add(DrawMode.Triangles, new ZeroIndexLineInTriangleSearcher());
                dict.Add(DrawMode.TriangleStrip, new ZeroIndexLineInTriangleStripSearcher());
                dict.Add(DrawMode.TriangleFan, new ZeroIndexLineInTriangleFanSearcher());
                dict.Add(DrawMode.Quads, new ZeroIndexLineInQuadSearcher());
                dict.Add(DrawMode.QuadStrip, new ZeroIndexLineInQuadStripSearcher());
                dict.Add(DrawMode.Polygon, new ZeroIndexLineInPolygonSearcher());

                lineSearchDict = dict;
            }

            ZeroIndexLineSearcher result = null;
            if (lineSearchDict.TryGetValue(mode, out result))
            { return result; }
            else
            { return null; }
        }

        public override PickedGeometry Pick(
            RenderEventArgs e,
            uint stageVertexId,
            int x, int y, int canvasWidth, int canvasHeight)
        {
            uint lastVertexId;
            if (!this.GetLastVertexIdOfPickedGeometry(stageVertexId, out lastVertexId))
            { return null; }

            GeometryType geometryType = e.PickingGeometryType;
            DrawMode mode = this.GetIndexBufferPtr().Mode;
            if (geometryType == GeometryType.Line)// I want a line
            {
                ZeroIndexLineSearcher searcher = GetLineSearcher(mode);
                if (searcher != null)// line is from triangle, quad or polygon
                {
                    return SearchLine(e, stageVertexId, x, y, canvasWidth, canvasHeight, lastVertexId, searcher);
                }
            }

            if (geometryType == GeometryType.Point)// I want a point
            {
                if (this.OnPrimitiveTest(e, x, y, canvasWidth, canvasHeight))
                {
                    return PickPoint(stageVertexId, lastVertexId);
                }
            }
            else
            {
                GeometryType typeOfMode = mode.ToGeometryType();
                if (typeOfMode == geometryType)// I want what it is
                {
                    return PickWhateverItIs(stageVertexId, lastVertexId, mode, typeOfMode);
                }
            }

            return null;
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

        private PickedGeometry SearchLine(RenderEventArgs e, uint stageVertexId, int x, int y, int canvasWidth, int canvasHeight, uint lastVertexId, ZeroIndexLineSearcher searcher)
        {
            PickedGeometry pickedGeometry = new PickedGeometry();
            pickedGeometry.From = this;
            pickedGeometry.GeometryType = GeometryType.Line;
            pickedGeometry.StageVertexId = stageVertexId;
            pickedGeometry.Indexes = searcher.Search(e,
                x, y, canvasWidth, canvasHeight, lastVertexId, this);
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
        private bool OnPrimitiveTest(RenderEventArgs e, int x, int y, int canvasWidth, int canvasHeight)
        {
            var arg = new RenderEventArgs(RenderModes.ColorCodedPicking, e.Camera, GeometryType.Line);
            this.Render4Picking(arg, this.zeroIndexBufferPtr);
            var stageVertexId = this.ReadPixel(x, y, canvasHeight);
            return stageVertexId != uint.MaxValue;
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

        private void ContinuousBufferRange(uint lastVertexId, int vertexCount, PickedGeometry pickedGeometry)
        {
            int offset = (int)((lastVertexId - (vertexCount - 1)) * this.positionBufferPtr.DataSize * this.positionBufferPtr.DataTypeByteLength);
            GL.BindBuffer(BufferTarget.ArrayBuffer, this.positionBufferPtr.BufferId);
            //IntPtr pointer = GL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadOnly);
            IntPtr pointer = GL.MapBufferRange(BufferTarget.ArrayBuffer,
                offset,
                vertexCount * this.positionBufferPtr.DataSize * this.positionBufferPtr.DataTypeByteLength,
                MapBufferRangeAccess.MapReadBit);
            pickedGeometry.Positions = new vec3[vertexCount];
            pickedGeometry.Indexes = new uint[vertexCount];
            if (pointer.ToInt32() != 0)
            {
                unsafe
                {
                    var array = (vec3*)pointer.ToPointer();
                    for (uint i = 0; i < vertexCount; i++)
                    {
                        pickedGeometry.Positions[i] = array[i];
                        pickedGeometry.Indexes[i] = lastVertexId - ((uint)vertexCount - 1) + i;
                    }
                }
            }
            else
            {
                ErrorCode error = (ErrorCode)GL.GetError();
                throw new Exception(string.Format(
                    "Error:[{0}] MapBufferRange failed: buffer ID: [{1}]", error, this.positionBufferPtr.BufferId));
            }
            GL.UnmapBuffer(BufferTarget.ArrayBuffer);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

    }
}
