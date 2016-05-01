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
            PickedGeometry pickedGeometry = null;
            if (this.GetLastVertexIdOfPickedGeometry(stageVertexId, out lastVertexId))
            {
                GeometryType geometryType = e.PickingGeometryType;
                DrawMode mode = this.GetIndexBufferPtr().Mode;
                if (geometryType == GeometryType.Line)// I want a line
                {
                    ZeroIndexLineSearcher searcher = GetLineSearcher(mode);
                    if (searcher != null)// line is from triangle, quad or polygon
                    {
                        pickedGeometry = new PickedGeometry();
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
                }

                if (geometryType == GeometryType.Point)// I want a point
                {
                    pickedGeometry = new PickedGeometry();
                    pickedGeometry.GeometryType = GeometryType.Point;
                    pickedGeometry.StageVertexId = stageVertexId;
                    pickedGeometry.From = this;
                    int vertexCount = 1;
                    ContinuousBufferRange(lastVertexId, vertexCount, pickedGeometry);
                    return pickedGeometry;
                }
                else
                {
                    GeometryType typeOfMode = mode.ToGeometryType();
                    if (typeOfMode == geometryType)// I want is what it is
                    {
                        pickedGeometry = new PickedGeometry();
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
                        }
                        else
                        {
                            // Other conditions
                            ContinuousBufferRange(lastVertexId, vertexCount, pickedGeometry);
                        }
                    }
                }
            }

            return pickedGeometry;
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
