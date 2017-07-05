using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Get picked geometry from a <see cref="PickableRenderer"/> with <see cref="ZeroIndexBuffer"/> as index buffer.
    /// </summary>
    partial class OneIndexPicker : PickerBase
    {
        /// <summary>
        /// Get picked geometry from a <see cref="PickableRenderer"/> with <see cref="ZeroIndexBuffer"/> as index buffer.
        /// </summary>
        /// <param name="renderer"></param>
        public OneIndexPicker(PickableRenderer renderer) : base(renderer) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="renderer"></param>
        /// <param name="arg"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override PickedGeometry GetPickedGeometry(PickingEventArgs arg, uint stageVertexId)
        {
            PickableRenderer renderer = this.Renderer;

            uint lastVertexId;
            if (!renderer.GetLastVertexIdOfPickedGeometry(stageVertexId, out lastVertexId))
            { return null; }

            // 找到 lastIndexId
            RecognizedPrimitiveInfo lastIndexId = this.GetLastIndexIdOfPickedGeometry(
                arg, lastVertexId);
            if (lastIndexId == null)
            {
                Debug.WriteLine(string.Format(
                    "Got lastVertexId[{0}] but no lastIndexId! Params are [{1}] [{2}] [{3}] [{4}]",
                    lastVertexId, arg, stageVertexId));
                { return null; }
            }

            PickingGeometryType geometryType = arg.GeometryType;
            DrawMode mode = renderer.IndexBuffer.Mode;
            PickingGeometryType typeOfMode = mode.ToGeometryType();

            if (geometryType == PickingGeometryType.Point)
            {
                // 获取pickedGeometry
                if (typeOfMode == PickingGeometryType.Point)
                { return PickWhateverItIs(arg, stageVertexId, lastIndexId, typeOfMode); }
                else if (typeOfMode == PickingGeometryType.Line)
                {
                    if (this.OnPrimitiveTest(lastVertexId, mode))
                    { return PickPoint(arg, stageVertexId, lastVertexId); }
                    else
                    { return null; }
                }
                else
                {
                    OneIndexPointSearcher searcher = GetPointSearcher(mode);
                    if (searcher != null)// line is from triangle, quad or polygon
                    { return SearchPoint(arg, stageVertexId, lastVertexId, lastIndexId, searcher); }
                    else
                    { throw new Exception(string.Format("Lack of searcher for [{0}]", mode)); }
                }
            }
            else if (geometryType == PickingGeometryType.Line)
            {
                // 获取pickedGeometry
                if (geometryType == typeOfMode)
                { return PickWhateverItIs(arg, stageVertexId, lastIndexId, typeOfMode); }
                else
                {
                    OneIndexLineSearcher searcher = GetLineSearcher(mode);
                    if (searcher != null)// line is from triangle, quad or polygon
                    { return SearchLine(arg, stageVertexId, lastIndexId, searcher); }
                    else if (mode == DrawMode.Points)// want a line when rendering GL_POINTS
                    { return null; }
                    else
                    { throw new Exception(string.Format("Lack of searcher for [{0}]", mode)); }
                }
            }
            else
            {
                if (typeOfMode == geometryType)// I want what it is
                { return PickWhateverItIs(arg, stageVertexId, lastIndexId, typeOfMode); }
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
        /// <param name="primitiveInfo"></param>
        /// <param name="searcher"></param>
        /// <returns></returns>
        private PickedGeometry SearchPoint(PickingEventArgs arg, uint stageVertexId, uint lastVertexId, RecognizedPrimitiveInfo primitiveInfo, OneIndexPointSearcher searcher)
        {
            var vertexIds = new uint[] { searcher.Search(arg, primitiveInfo, this), };
            vec3[] positions = FillPickedGeometrysPosition(vertexIds);
            var pickedGeometry = new PickedGeometry(PickingGeometryType.Point, positions, vertexIds, stageVertexId, this.Renderer);

            return pickedGeometry;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="x">mouse position(Left Down is (0, 0)).</param>
        /// <param name="y">mouse position(Left Down is (0, 0)).</param>
        /// <param name="lastVertexId"></param>
        /// <param name="primitiveInfo"></param>
        /// <param name="searcher"></param>
        /// <returns></returns>
        private PickedGeometry SearchLine(PickingEventArgs arg, uint stageVertexId, RecognizedPrimitiveInfo primitiveInfo, OneIndexLineSearcher searcher)
        {
            var vertexIds = searcher.Search(arg, primitiveInfo, this);
            vec3[] positions = FillPickedGeometrysPosition(vertexIds);
            var pickedGeometry = new PickedGeometry(PickingGeometryType.Line, positions, vertexIds, stageVertexId, this.Renderer);

            return pickedGeometry;
        }

        /// <summary>
        /// 是三角形，就pick一个三角形；是四边形，就pick一个四边形，是多边形，就pick一个多边形。
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="primitiveInfo"></param>
        /// <param name="typeOfMode"></param>
        /// <returns></returns>
        private PickedGeometry PickWhateverItIs(PickingEventArgs arg, uint stageVertexId, RecognizedPrimitiveInfo primitiveInfo, PickingGeometryType typeOfMode)
        {
            uint[] vertexIds = primitiveInfo.VertexIds;
            vec3[] positions = FillPickedGeometrysPosition(vertexIds);
            var pickedGeometry = new PickedGeometry(typeOfMode, positions, vertexIds, stageVertexId, this.Renderer);

            return pickedGeometry;
        }

        /// <summary>
        /// I don't know how to implement this method in a high effitiency way.
        /// So keep it like this.
        /// Also, why would someone use glDrawElements() when rendering GL_POINTS?
        /// </summary>
        /// <param name="lastVertexId"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        private bool OnPrimitiveTest(uint lastVertexId, DrawMode mode)
        {
            return true;
        }

        private PickedGeometry PickPoint(PickingEventArgs arg, uint stageVertexId, uint lastVertexId)
        {
            var vertexIds = new uint[] { lastVertexId, };
            vec3[] positions = FillPickedGeometrysPosition(vertexIds);
            var pickedGeometry = new PickedGeometry(PickingGeometryType.Point, positions, vertexIds, stageVertexId, this.Renderer);

            return pickedGeometry;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="lastVertexId"></param>
        /// <param name="x">mouse position(Left Down is (0, 0)).</param>
        /// <param name="y">mouse position(Left Down is (0, 0)).</param>
        /// <returns></returns>
        private RecognizedPrimitiveInfo GetLastIndexIdOfPickedGeometry(
            PickingEventArgs arg,
            uint lastVertexId)
        {
            List<RecognizedPrimitiveInfo> primitiveInfoList = GetLastIndexIdList(arg, lastVertexId);

            if (primitiveInfoList.Count == 0) { return null; }

            RecognizedPrimitiveInfo lastIndexId = GetLastIndexId(arg, primitiveInfoList);

            return lastIndexId;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="twoPrimitivesIndexBuffer"></param>
        /// <param name="x">mouse position(Left Down is (0, 0)).</param>
        /// <param name="y">mouse position(Left Down is (0, 0)).</param>
        /// <returns></returns>
        private uint Pick(PickingEventArgs arg, OneIndexBuffer twoPrimitivesIndexBuffer)
        {
            this.Renderer.Render4InnerPicking(arg, twoPrimitivesIndexBuffer);

            uint pickedIndex = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            return pickedIndex;
        }

        /// <summary>
        /// 遍历以<paramref name="lastVertexId"/>为最后一个顶点的图元，
        /// 瞄准每个图元的索引（例如1个三角形有3个索引）中的最后一个索引，
        /// 将此索引在<see cref="IndexBuffer"/>中的索引（位置）收集起来。
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="lastVertexId"></param>
        /// <returns></returns>
        private List<RecognizedPrimitiveInfo> GetLastIndexIdList(PickingEventArgs arg, uint lastVertexId)
        {
            var indexBuffer = this.Renderer.IndexBuffer;
            PrimitiveRecognizer recognizer = PrimitiveRecognizerFactory.Create(
                (arg.GeometryType == PickingGeometryType.Point
                && indexBuffer.Mode.ToGeometryType() == PickingGeometryType.Line) ?
                DrawMode.Points : indexBuffer.Mode);

            PrimitiveRestartState glState = GetPrimitiveRestartState();

            var buffer = indexBuffer as OneIndexBuffer;
            IntPtr pointer = buffer.MapBuffer(MapBufferAccess.ReadOnly);
            List<RecognizedPrimitiveInfo> primitiveInfoList = null;
            if (glState == null)
            { primitiveInfoList = recognizer.Recognize(lastVertexId, pointer, indexBuffer as OneIndexBuffer); }
            else
            { primitiveInfoList = recognizer.Recognize(lastVertexId, pointer, indexBuffer as OneIndexBuffer, glState.RestartIndex); }
            buffer.UnmapBuffer();

            return primitiveInfoList;
        }

        private PrimitiveRestartState GetPrimitiveRestartState()
        {
            foreach (GLState item in this.Renderer.StateList)
            {
                var target = item as PrimitiveRestartState;
                if (target != null)
                {
                    return target;
                }
            }

            return null;
        }
    }
}
