using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Get picked geometry from a <see cref="PickableNode"/> with <see cref="DrawArraysCmd"/> as index buffer.
    /// </summary>
    partial class DrawElementsPicker : PickerBase
    {
        /// <summary>
        /// 
        /// </summary>
        public DrawElementsCmd DrawCommand { get; private set; }

        /// <summary>
        /// Get picked geometry from a <see cref="PickableNode"/> with <see cref="DrawArraysCmd"/> as index buffer.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="positionBuffer"></param>
        /// <param name="drawCommand"></param>
        public DrawElementsPicker(PickableNode node, VertexBuffer positionBuffer, DrawElementsCmd drawCommand)
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
            uint lastVertexId = stageVertexId - baseId;
            if (this.PositionBuffer.Length <= lastVertexId) { return null; }

            PickableNode node = this.Node;

            // Find lastIndexId
            RecognizedPrimitiveInfo lastIndexId = this.GetLastIndexIdOfPickedGeometry(arg, lastVertexId);
            if (lastIndexId == null)
            {
                Debug.WriteLine(string.Format(
                    "Got lastVertexId[{0}] but no lastIndexId! Params are [{1}] [{2}]",
                    lastVertexId, arg, stageVertexId));
                { return null; }
            }

            PickingGeometryTypes geometryType = arg.GeometryType;
            DrawMode drawMode = this.DrawCommand.Mode;
            GeometryType typeOfMode = drawMode.ToGeometryType();

            if ((geometryType & PickingGeometryTypes.Point) == PickingGeometryTypes.Point)
            {
                // 获取pickedGeometry
                if (typeOfMode == GeometryType.Point)
                { return PickWhateverItIs(arg, stageVertexId, lastIndexId, typeOfMode); }
                else if (typeOfMode == GeometryType.Line)
                {
                    if (this.OnPrimitiveTest(lastVertexId, drawMode))
                    { return PickPoint(arg, stageVertexId, lastVertexId); }
                    else
                    { return null; }
                }
                else
                {
                    DrawElementsPointSearcher searcher = GetPointSearcher(drawMode);
                    if (searcher != null)// line is from triangle, quad or polygon
                    { return SearchPoint(arg, stageVertexId, lastVertexId, lastIndexId, searcher); }
                    else
                    { throw new Exception(string.Format("Lack of searcher for [{0}]", drawMode)); }
                }
            }
            else if ((geometryType & PickingGeometryTypes.Line) == PickingGeometryTypes.Line)
            {
                // 获取pickedGeometry
                if (typeOfMode == GeometryType.Point) // want a line when rendering GL_POINTS
                { return null; }
                if (typeOfMode == GeometryType.Line)
                { return PickWhateverItIs(arg, stageVertexId, lastIndexId, typeOfMode); }
                else
                {
                    DrawElementsLineSearcher searcher = GetLineSearcher(drawMode);
                    if (searcher != null)// line is from triangle, quad or polygon
                    { return SearchLine(arg, stageVertexId, lastIndexId, searcher); }
                    else
                    { throw new Exception(string.Format("Lack of searcher for [{0}]", drawMode)); }
                }
            }
            else
            {
                if (geometryType.Contains(typeOfMode)) // I want what it is
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
        /// <param name="lastVertexId"></param>
        /// <param name="primitiveInfo"></param>
        /// <param name="searcher"></param>
        /// <returns></returns>
        private PickedGeometry SearchPoint(PickingEventArgs arg, uint stageVertexId, uint lastVertexId, RecognizedPrimitiveInfo primitiveInfo, DrawElementsPointSearcher searcher)
        {
            var vertexIds = new uint[] { searcher.Search(arg, primitiveInfo, this), };
            vec3[] positions = FillPickedGeometrysPosition(vertexIds);
            var pickedGeometry = new PickedGeometry(GeometryType.Point, positions, vertexIds, stageVertexId, this.Node);

            return pickedGeometry;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="primitiveInfo"></param>
        /// <param name="searcher"></param>
        /// <returns></returns>
        private PickedGeometry SearchLine(PickingEventArgs arg, uint stageVertexId, RecognizedPrimitiveInfo primitiveInfo, DrawElementsLineSearcher searcher)
        {
            var vertexIds = searcher.Search(arg, primitiveInfo, this);
            vec3[] positions = FillPickedGeometrysPosition(vertexIds);
            var pickedGeometry = new PickedGeometry(GeometryType.Line, positions, vertexIds, stageVertexId, this.Node);

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
        private PickedGeometry PickWhateverItIs(PickingEventArgs arg, uint stageVertexId, RecognizedPrimitiveInfo primitiveInfo, GeometryType typeOfMode)
        {
            uint[] vertexIds = primitiveInfo.VertexIds;
            vec3[] positions = FillPickedGeometrysPosition(vertexIds);
            var pickedGeometry = new PickedGeometry(typeOfMode, positions, vertexIds, stageVertexId, this.Node);

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
            var pickedGeometry = new PickedGeometry(GeometryType.Point, positions, vertexIds, stageVertexId, this.Node);

            return pickedGeometry;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="lastVertexId"></param>
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
        /// <returns></returns>
        private uint Pick(PickingEventArgs arg, DrawElementsCmd twoPrimitivesIndexBuffer)
        {
            this.Node.Render4InnerPicking(arg, ControlMode.ByFrame, twoPrimitivesIndexBuffer);

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
            var drawCmd = this.DrawCommand;
            DrawMode mode = drawCmd.Mode;
            PrimitiveRecognizer recognizer = PrimitiveRecognizerFactory.Create(
                (arg.GeometryType.Contains(GeometryType.Point)
                && mode.ToGeometryType() == GeometryType.Line) ?
                DrawMode.Points : mode);

            PrimitiveRestartSwitch glState = GetPrimitiveRestartState();

            List<RecognizedPrimitiveInfo> primitiveInfoList = null;
            if (glState == null)
            { primitiveInfoList = recognizer.Recognize(lastVertexId, drawCmd); }
            else
            { primitiveInfoList = recognizer.Recognize(lastVertexId, drawCmd, glState.RestartIndex); }

            return primitiveInfoList;
        }

        // TODO: encapsulate primitive restart index switch into DrawElementsState.
        private PrimitiveRestartSwitch GetPrimitiveRestartState()
        {
            foreach (GLSwitch item in this.Node.PickingRenderUnit.SwitchList)
            {
                var target = item as PrimitiveRestartSwitch;
                if (target != null)
                {
                    return target;
                }
            }

            return null;
        }
    }
}
