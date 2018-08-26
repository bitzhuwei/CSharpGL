using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Get picked geometry from a <see cref="PickableNode"/> with <see cref="DrawArraysCmd"/> and <see cref="MultiDrawArraysCmd"/> as index buffer.
    /// </summary>
    partial class DrawArraysPicker : PickerBase
    {
        /// <summary>
        /// 
        /// </summary>
        public DrawArraysCmd DrawCommand { get; private set; }

        /// <summary>
        /// Get picked geometry from a <see cref="PickableNode"/> with <see cref="DrawArraysCmd"/> as index buffer.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="positionBuffer"></param>
        /// <param name="drawCommand"></param>
        public DrawArraysPicker(PickableNode node, VertexBuffer positionBuffer, DrawArraysCmd drawCommand)
            : base(node, positionBuffer)
        {
            this.DrawCommand = drawCommand;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="stageVertexId">The last vertex's id that constructs the picked primitive.
        /// <para>This id is in scene's all <see cref="IPickable"/>s' order.</para></param>
        /// <param name="baseId">Index of first vertex of the buffer that The geometry belongs to.
        /// <para>This id is in scene's all <see cref="IPickable"/>s' order.</para></param>
        /// <returns></returns>
        public override PickedGeometry GetPickedGeometry(PickingEventArgs arg, uint stageVertexId, uint baseId)
        {
            if (stageVertexId < baseId) { return null; }
            uint singleNodeVertexId = stageVertexId - baseId;
            if (this.PositionBuffer.Length <= singleNodeVertexId) { return null; }

            PickingGeometryTypes pickingType = arg.GeometryType;

            if ((pickingType & PickingGeometryTypes.Point) == PickingGeometryTypes.Point)
            {
                DrawMode mode = this.DrawCommand.CurrentMode;
                GeometryType typeOfMode = mode.ToGeometryType();
                if (typeOfMode == GeometryType.Point)
                { return PickWhateverItIs(arg, stageVertexId, singleNodeVertexId, mode, typeOfMode); }
                else if (typeOfMode == GeometryType.Line)
                {
                    if (this.OnPrimitiveTest(singleNodeVertexId, mode))
                    { return PickPoint(arg, stageVertexId, singleNodeVertexId); }
                    else
                    { return null; }
                }
                else
                {
                    DrawArraysPointSearcher searcher = GetPointSearcher(mode);
                    if (searcher != null)// point is from triangle, quad or polygon
                    { return SearchPoint(arg, stageVertexId, singleNodeVertexId, searcher); }
                    else
                    { throw new Exception(string.Format("Lack of searcher for [{0}]", mode)); }
                }
            }
            else if ((pickingType & PickingGeometryTypes.Line) == PickingGeometryTypes.Line)
            {
                DrawMode mode = this.DrawCommand.CurrentMode;
                GeometryType typeOfMode = mode.ToGeometryType();
                if (pickingType.Contains(typeOfMode))
                { return PickWhateverItIs(arg, stageVertexId, singleNodeVertexId, mode, typeOfMode); }
                else
                {
                    DrawArraysLineSearcher searcher = GetLineSearcher(mode);
                    if (searcher != null)// line is from triangle, quad or polygon
                    { return SearchLine(arg, stageVertexId, singleNodeVertexId, searcher); }
                    else if (mode == DrawMode.Points)// want a line when rendering GL_POINTS
                    { return null; }
                    else
                    { throw new Exception(string.Format("Lack of searcher for [{0}]", mode)); }
                }
            }
            else
            {
                DrawMode mode = this.DrawCommand.CurrentMode;
                GeometryType typeOfMode = mode.ToGeometryType();
                if (pickingType.Contains(typeOfMode)) // I want what it is
                { return PickWhateverItIs(arg, stageVertexId, singleNodeVertexId, mode, typeOfMode); }
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
        /// <param name="singleNodeVertexId"></param>
        /// <param name="searcher"></param>
        /// <returns></returns>
        private PickedGeometry SearchPoint(PickingEventArgs arg, uint stageVertexId, uint singleNodeVertexId, DrawArraysPointSearcher searcher)
        {
            uint baseId = stageVertexId - singleNodeVertexId;
            var vertexIds = new uint[] { searcher.Search(arg, singleNodeVertexId, stageVertexId, this) - baseId };
            vec3[] positions = FillPickedGeometrysPosition(vertexIds);
            var pickedGeometry = new PickedGeometry(GeometryType.Point, positions, vertexIds, stageVertexId, this.Node);

            return pickedGeometry;
        }

        private PickedGeometry PickWhateverItIs(PickingEventArgs arg, uint stageVertexId, uint singleNodeVertexId, DrawMode mode, GeometryType typeOfMode)
        {
            //PickedGeometry pickedGeometry = new PickedGeometry();
            //pickedGeometry.GeometryType = typeOfMode;
            //pickedGeometry.StageVertexId = stageVertexId;
            //pickedGeometry.FromRenderer = this;

            // Fill primitive's position information.
            int vertexCount = typeOfMode.GetVertexCount();
            if (vertexCount == -1) { vertexCount = (from item in this.Node.PickingRenderMethod.PositionBuffers select item.Length).Sum(); }

            uint[] vertexIds; vec3[] positions;

            if (singleNodeVertexId == 0 && vertexCount == 2)
            {
                // This is when mode is GL_LINE_LOOP and picked last line(the loop back one)
                PickingLastLineInLineLoop(out vertexIds, out positions);
            }
            else
            {
                // Other conditions
                switch (typeOfMode)
                {
                    case GeometryType.Point:
                        vertexIds = new uint[] { singleNodeVertexId, };
                        positions = FillPickedGeometrysPosition(singleNodeVertexId, 1);
                        break;

                    case GeometryType.Line:
                        vertexIds = new uint[] { singleNodeVertexId - 1, singleNodeVertexId, };
                        positions = FillPickedGeometrysPosition(singleNodeVertexId - 1, 2);
                        break;

                    case GeometryType.Triangle:
                        if (mode == DrawMode.TriangleFan)
                        {
                            vertexIds = new uint[] { 0, singleNodeVertexId - 1, singleNodeVertexId, };
                            positions = FillPickedGeometrysPosition(vertexIds);
                        }
                        else if (mode == DrawMode.TrianglesAdjacency || mode == DrawMode.TriangleStripAdjacency)
                        {
                            vertexIds = new uint[] { singleNodeVertexId - 4, singleNodeVertexId - 2, singleNodeVertexId, };
                            positions = FillPickedGeometrysPosition(vertexIds);
                        }
                        else
                        {
                            vertexIds = new uint[] { singleNodeVertexId - 2, singleNodeVertexId - 1, singleNodeVertexId, };
                            positions = FillPickedGeometrysPosition(singleNodeVertexId - 2, 3);
                        }
                        break;

                    case GeometryType.Quad:
                        vertexIds = new uint[] { singleNodeVertexId - 3, singleNodeVertexId - 2, singleNodeVertexId - 1, singleNodeVertexId, };
                        positions = FillPickedGeometrysPosition(singleNodeVertexId - 3, 4);
                        break;

                    case GeometryType.Polygon:
                        vertexIds = new uint[vertexCount];
                        for (uint i = 0; i < vertexCount; i++)
                        { vertexIds[i] = singleNodeVertexId + i; }
                        positions = FillPickedGeometrysPosition(0, vertexCount);
                        break;

                    default:
                        throw new NotDealWithNewEnumItemException(typeof(GeometryType));
                }
            }

            PickedGeometry pickedGeometry = new PickedGeometry(typeOfMode, positions, vertexIds, stageVertexId, this.Node);
            return pickedGeometry;
        }

        private PickedGeometry PickPoint(PickingEventArgs arg, uint stageVertexId, uint singleNodeVertexId)
        {
            var vertexIds = new uint[] { singleNodeVertexId, };
            var positions = FillPickedGeometrysPosition(vertexIds);
            var pickedGeometry = new PickedGeometry(GeometryType.Point, positions, vertexIds, stageVertexId, this.Node);

            return pickedGeometry;
        }

        /// <summary>
        /// Search line in triangles/triangle_strip/triangle_fan/
        /// triangles_adjacency/triangle_strip_adjacency/
        /// quads/quad_strip/polygon
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="singleNodeVertexId"></param>
        /// <param name="searcher"></param>
        /// <returns></returns>
        private PickedGeometry SearchLine(PickingEventArgs arg, uint stageVertexId,
            uint singleNodeVertexId, DrawArraysLineSearcher searcher)
        {
            var vertexIds = searcher.Search(arg, singleNodeVertexId, stageVertexId, this);
            var positions = FillPickedGeometrysPosition(vertexIds);
            var pickedGeometry = new PickedGeometry(GeometryType.Line, positions, vertexIds, stageVertexId, this.Node);

            return pickedGeometry;
        }

        /// <summary>
        /// 现在，已经判定了鼠标在某个点上。
        /// 我需要判定此点是否应该出现在图元上。
        /// now that I know the mouse is picking on some point,
        /// I need to make sure that point should appear.
        /// </summary>
        /// <param name="singleNodeVertexId"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        private bool OnPrimitiveTest(uint singleNodeVertexId, DrawMode mode)
        {
            bool result = false;
            var drawCmd = this.DrawCommand as DrawArraysCmd;
            int first = drawCmd.FirstVertex;
            if (first < 0) { return false; }
            int vertexCount = drawCmd.VertexCount;
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
                            result = (first <= singleNodeVertexId && singleNodeVertexId <= last);
                        }
                        else
                        {
                            result = (first <= singleNodeVertexId && singleNodeVertexId <= last - 1);
                        }
                    }
                    break;

                case DrawMode.LineStripAdjacency:
                    if (vertexCount > 3)
                    {
                        result = (first < singleNodeVertexId && singleNodeVertexId < last);
                    }
                    break;

                case DrawMode.LinesAdjacency:
                    if (vertexCount > 3)
                    {
                        var lastPart = last - (last + 1 - first) % 4;
                        if (first <= singleNodeVertexId && singleNodeVertexId <= lastPart)
                        {
                            var m = (singleNodeVertexId - first) % 4;
                            result = (m == 1 || m == 2);
                        }
                    }
                    break;

                case DrawMode.TriangleStrip:
                    if (vertexCount > 2)
                    {
                        result = true;
                    }
                    break;

                case DrawMode.TriangleFan:
                    if (vertexCount > 2)
                    {
                        result = true;
                    }
                    break;

                case DrawMode.Triangles:
                    if (vertexCount > 2)
                    {
                        if (first <= singleNodeVertexId)
                        {
                            result = ((vertexCount % 3 == 0) && (singleNodeVertexId <= last))
                                || ((vertexCount % 3 == 1) && (singleNodeVertexId < last))
                                || ((vertexCount % 3 == 2) && (singleNodeVertexId + 1 < last));
                        }
                    }
                    break;

                case DrawMode.TriangleStripAdjacency:
                    if (vertexCount > 5)
                    {
                        var lastPart = last - (last + 1 - first) % 2;
                        if (first <= singleNodeVertexId && singleNodeVertexId <= lastPart)
                        {
                            result = (singleNodeVertexId - first) % 2 == 0;
                        }
                    }
                    break;

                case DrawMode.TrianglesAdjacency:
                    if (vertexCount > 5)
                    {
                        var lastPart = last - (last + 1 - first) % 6;
                        if (first <= singleNodeVertexId && singleNodeVertexId <= lastPart)
                        {
                            result = (singleNodeVertexId - first) % 2 == 0;
                        }
                    }
                    break;

                case DrawMode.Patches:
                    // TODO: not know what to do for now
                    break;

                case DrawMode.QuadStrip:
                    if (vertexCount > 3)
                    {
                        if (first <= singleNodeVertexId && singleNodeVertexId <= last)
                        {
                            result = (vertexCount % 2 == 0)
                                || (singleNodeVertexId < last);
                        }
                    }
                    break;

                case DrawMode.Quads:
                    if (vertexCount > 3)
                    {
                        if (first <= singleNodeVertexId && singleNodeVertexId <= last)
                        {
                            var m = vertexCount % 4;
                            if (m == 0) { result = true; }
                            else if (m == 1) { result = singleNodeVertexId + 0 < last; }
                            else if (m == 2) { result = singleNodeVertexId + 1 < last; }
                            else if (m == 3) { result = singleNodeVertexId + 2 < last; }
                            else { throw new Exception("This should never happen!"); }
                        }
                    }
                    break;

                case DrawMode.Polygon:
                    if (vertexCount > 2)
                    {
                        result = (first <= singleNodeVertexId && singleNodeVertexId <= last);
                    }
                    break;

                default:
                    throw new NotDealWithNewEnumItemException(typeof(DrawMode));
            }

            return result;
        }

        private void PickingLastLineInLineLoop(out uint[] vertexIds, out vec3[] positions)
        {
            const int vertexCount = 2;
            VertexBuffer[] buffers = this.Node.PickingRenderMethod.PositionBuffers;
            int sum = (from item in buffers select item.Length).Sum();
            vertexIds = new uint[vertexCount] { (uint)(sum - 1), 0 };
            IEnumerable<IndexesInBuffer> workItems = buffers.GetWorkItems(vertexIds);
            var positionList = new List<vec3>();
            foreach (var item in workItems)
            {
                VertexBuffer buffer = buffers[item.whichBuffer];
                IntPtr pointer = buffer.MapBuffer(MapBufferAccess.ReadOnly);
                unsafe
                {
                    var array = (vec3*)pointer.ToPointer();
                    foreach (var indexInBuffer in item.indexesInBuffer)
                    {
                        positionList.Add(array[indexInBuffer]);
                    }
                }
                buffer.UnmapBuffer();
            }

            if (positionList.Count != vertexCount) { throw new Exception(); }

            positions = positionList.ToArray();
        }
    }
}
