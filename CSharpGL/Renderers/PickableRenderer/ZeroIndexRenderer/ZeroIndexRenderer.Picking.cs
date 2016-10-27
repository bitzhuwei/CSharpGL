using System;

namespace CSharpGL
{
    partial class ZeroIndexRenderer
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="x">mouse position(Left Down is (0, 0)).</param>
        /// <param name="y">mouse position(Left Down is (0, 0)).</param>
        /// <returns></returns>
        public override PickedGeometry GetPickedGeometry(RenderEventArgs arg, uint stageVertexId,
            int x, int y)
        {
            uint lastVertexId;
            if (!this.GetLastVertexIdOfPickedGeometry(stageVertexId, out lastVertexId))
            { return null; }

            PickingGeometryType geometryType = arg.PickingGeometryType;

            if (geometryType == PickingGeometryType.Point)
            {
                DrawMode mode = this.indexBufferPtr.Mode;
                PickingGeometryType typeOfMode = mode.ToGeometryType();
                if (typeOfMode == PickingGeometryType.Point)
                { return PickWhateverItIs(arg, stageVertexId, lastVertexId, mode, typeOfMode); }
                else if (typeOfMode == PickingGeometryType.Line)
                {
                    if (this.OnPrimitiveTest(lastVertexId, mode))
                    { return PickPoint(arg, stageVertexId, lastVertexId); }
                    else
                    { return null; }
                }
                else
                {
                    ZeroIndexPointSearcher searcher = GetPointSearcher(mode);
                    if (searcher != null)// point is from triangle, quad or polygon
                    { return SearchPoint(arg, stageVertexId, x, y, lastVertexId, searcher); }
                    else
                    { throw new Exception(string.Format("Lack of searcher for [{0}]", mode)); }
                }
            }
            else if (geometryType == PickingGeometryType.Line)
            {
                DrawMode mode = this.indexBufferPtr.Mode;
                PickingGeometryType typeOfMode = mode.ToGeometryType();
                if (geometryType == typeOfMode)
                { return PickWhateverItIs(arg, stageVertexId, lastVertexId, mode, typeOfMode); }
                else
                {
                    ZeroIndexLineSearcher searcher = GetLineSearcher(mode);
                    if (searcher != null)// line is from triangle, quad or polygon
                    { return SearchLine(arg, stageVertexId, x, y, lastVertexId, searcher); }
                    else if (mode == DrawMode.Points)// want a line when rendering GL_POINTS
                    { return null; }
                    else
                    { throw new Exception(string.Format("Lack of searcher for [{0}]", mode)); }
                }
            }
            else
            {
                DrawMode mode = this.indexBufferPtr.Mode;
                PickingGeometryType typeOfMode = mode.ToGeometryType();
                if (typeOfMode == geometryType)// I want what it is
                { return PickWhateverItIs(arg, stageVertexId, lastVertexId, mode, typeOfMode); }
                else
                { return null; }
                //{ throw new Exception(string.Format("Lack of searcher for [{0}]", mode)); }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="x">mouse position(Left Down is (0, 0)).</param>
        /// <param name="y">mouse position(Left Down is (0, 0)).</param>
        /// <param name="lastVertexId"></param>
        /// <param name="searcher"></param>
        /// <returns></returns>
        private PickedGeometry SearchPoint(RenderEventArgs arg, uint stageVertexId, int x, int y, uint lastVertexId, ZeroIndexPointSearcher searcher)
        {
            var vertexIds = new uint[] { searcher.Search(arg, x, y, lastVertexId, this), };
            vec3[] positions = FillPickedGeometrysPosition(vertexIds);
            var pickedGeometry = new PickedGeometry(arg.UsingViewPort, PickingGeometryType.Line, positions, vertexIds, stageVertexId, this);

            return pickedGeometry;
        }

        private PickedGeometry PickWhateverItIs(RenderEventArgs arg, uint stageVertexId, uint lastVertexId, DrawMode mode, PickingGeometryType typeOfMode)
        {
            //PickedGeometry pickedGeometry = new PickedGeometry();
            //pickedGeometry.GeometryType = typeOfMode;
            //pickedGeometry.StageVertexId = stageVertexId;
            //pickedGeometry.FromRenderer = this;

            // Fill primitive's position information.
            int vertexCount = typeOfMode.GetVertexCount();
            if (vertexCount == -1) { vertexCount = this.PositionBufferPtr.Length; }

            uint[] vertexIds; vec3[] positions;

            if (lastVertexId == 0 && vertexCount == 2)
            {
                // This is when mode is GL_LINE_LOOP and picked last line(the loop back one)
                PickingLastLineInLineLoop(out vertexIds, out positions);
            }
            else
            {
                // Other conditions
                switch (typeOfMode)
                {
                    case PickingGeometryType.Point:
                        vertexIds = new uint[] { lastVertexId, };
                        positions = FillPickedGeometrysPosition(lastVertexId, 1);
                        break;

                    case PickingGeometryType.Line:
                        vertexIds = new uint[] { lastVertexId - 1, lastVertexId, };
                        positions = FillPickedGeometrysPosition(lastVertexId - 1, 2);
                        break;

                    case PickingGeometryType.Triangle:
                        if (mode == DrawMode.TriangleFan)
                        {
                            vertexIds = new uint[] { 0, lastVertexId - 1, lastVertexId, };
                            positions = FillPickedGeometrysPosition(vertexIds);
                        }
                        else if (mode == DrawMode.TrianglesAdjacency || mode == DrawMode.TriangleStripAdjacency)
                        {
                            vertexIds = new uint[] { lastVertexId - 4, lastVertexId - 2, lastVertexId, };
                            positions = FillPickedGeometrysPosition(vertexIds);
                        }
                        else
                        {
                            vertexIds = new uint[] { lastVertexId - 2, lastVertexId - 1, lastVertexId, };
                            positions = FillPickedGeometrysPosition(lastVertexId - 2, 3);
                        }
                        break;

                    case PickingGeometryType.Quad:
                        vertexIds = new uint[] { lastVertexId - 3, lastVertexId - 2, lastVertexId - 1, lastVertexId, };
                        positions = FillPickedGeometrysPosition(lastVertexId - 3, 4);
                        break;

                    case PickingGeometryType.Polygon:
                        vertexIds = new uint[vertexCount];
                        for (uint i = 0; i < vertexCount; i++)
                        { vertexIds[i] = lastVertexId + i; }
                        positions = FillPickedGeometrysPosition(0, vertexCount);
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }

            PickedGeometry pickedGeometry = new PickedGeometry(arg.UsingViewPort, typeOfMode, positions, vertexIds, stageVertexId, this);
            return pickedGeometry;
        }

        private PickedGeometry PickPoint(RenderEventArgs arg, uint stageVertexId, uint lastVertexId)
        {
            var vertexIds = new uint[] { lastVertexId, };
            var positions = FillPickedGeometrysPosition(vertexIds);
            var pickedGeometry = new PickedGeometry(arg.UsingViewPort, PickingGeometryType.Point, positions, vertexIds, stageVertexId, this);

            return pickedGeometry;
        }

        /// <summary>
        /// Search line in triangles/triangle_strip/triangle_fan/
        /// triangles_adjacency/triangle_strip_adjacency/
        /// quads/quad_strip/polygon
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="x">mouse position(Left Down is (0, 0)).</param>
        /// <param name="y">mouse position(Left Down is (0, 0)).</param>
        /// <param name="lastVertexId"></param>
        /// <param name="searcher"></param>
        /// <returns></returns>
        private PickedGeometry SearchLine(RenderEventArgs arg, uint stageVertexId,
            int x, int y, uint lastVertexId, ZeroIndexLineSearcher searcher)
        {
            var vertexIds = searcher.Search(arg, x, y, lastVertexId, this);
            var positions = FillPickedGeometrysPosition(vertexIds);
            var pickedGeometry = new PickedGeometry(arg.UsingViewPort, PickingGeometryType.Line, positions, vertexIds, stageVertexId, this);

            return pickedGeometry;
        }

        /// <summary>
        /// 现在，已经判定了鼠标在某个点上。
        /// 我需要判定此点是否出现在图元上。
        /// now that I know the mouse is picking on some point,
        /// I need to make sure that point should appear.
        /// </summary>
        /// <param name="lastVertexId"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        private bool OnPrimitiveTest(uint lastVertexId, DrawMode mode)
        {
            bool result = false;
            var indexBufferPtr = this.indexBufferPtr as ZeroIndexBufferPtr;
            int first = indexBufferPtr.FirstVertex;
            if (first < 0) { return false; }
            int vertexCount = indexBufferPtr.RenderingVertexCount;
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
                    // TODO: not know what to do for now
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

        private void PickingLastLineInLineLoop(out uint[] vertexIds, out vec3[] positions)
        {
            const int vertexCount = 2;
            var offsets = new int[vertexCount] { (this.PositionBufferPtr.Length - 1) * this.PositionBufferPtr.DataSize * this.PositionBufferPtr.DataTypeByteLength, 0, };
            vertexIds = new uint[vertexCount];
            positions = new vec3[vertexCount];
            this.PositionBufferPtr.Bind();
            for (int i = 0; i < vertexCount; i++)
            {
                IntPtr pointer = this.PositionBufferPtr.MapBufferRange(
                    offsets[i],
                    1 * this.PositionBufferPtr.DataSize * this.PositionBufferPtr.DataTypeByteLength,
                    MapBufferRangeAccess.MapReadBit, false);
                unsafe
                {
                    var array = (vec3*)pointer.ToPointer();
                    positions[i] = array[0];
                }
                this.PositionBufferPtr.UnmapBuffer(false);
                vertexIds[i] = (uint)offsets[i] / (uint)(this.PositionBufferPtr.DataSize * this.PositionBufferPtr.DataTypeByteLength);
            }
            this.PositionBufferPtr.Unbind();
        }
    }
}