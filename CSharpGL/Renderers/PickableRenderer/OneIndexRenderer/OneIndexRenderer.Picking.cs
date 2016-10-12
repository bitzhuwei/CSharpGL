using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CSharpGL
{
    // check http://www.cnblogs.com/bitzhuwei/p/CSharpGL-18-Picking-of-OneIndexBuffer.html
    partial class OneIndexRenderer
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

            // 找到 lastIndexId
            RecognizedPrimitiveInfo lastIndexId = this.GetLastIndexIdOfPickedGeometry(
                arg, lastVertexId, x, y);
            if (lastIndexId == null)
            {
                Debug.WriteLine(string.Format(
                    "Got lastVertexId[{0}] but no lastIndexId! Params are [{1}] [{2}] [{3}] [{4}]",
                    lastVertexId, arg, stageVertexId, x, y));
                { return null; }
            }

            GeometryType geometryType = arg.PickingGeometryType;
            DrawMode mode = this.indexBufferPtr.Mode;
            GeometryType typeOfMode = mode.ToGeometryType();

            if (geometryType == GeometryType.Point)
            {
                // 获取pickedGeometry
                if (typeOfMode == GeometryType.Point)
                { return PickWhateverItIs(stageVertexId, lastIndexId, typeOfMode); }
                else if (typeOfMode == GeometryType.Line)
                {
                    if (this.OnPrimitiveTest(lastVertexId, mode))
                    { return PickPoint(stageVertexId, lastVertexId); }
                    else
                    { return null; }
                }
                else
                {
                    OneIndexPointSearcher searcher = GetPointSearcher(mode);
                    if (searcher != null)// line is from triangle, quad or polygon
                    { return SearchPoint(arg, stageVertexId, x, y, lastVertexId, lastIndexId, searcher); }
                    else
                    { throw new Exception(string.Format("Lack of searcher for [{0}]", mode)); }
                }
            }
            else if (geometryType == GeometryType.Line)
            {
                // 获取pickedGeometry
                if (geometryType == typeOfMode)
                { return PickWhateverItIs(stageVertexId, lastIndexId, typeOfMode); }
                else
                {
                    OneIndexLineSearcher searcher = GetLineSearcher(mode);
                    if (searcher != null)// line is from triangle, quad or polygon
                    { return SearchLine(arg, stageVertexId, x, y, lastVertexId, lastIndexId, searcher); }
                    else if (mode == DrawMode.Points)// want a line when rendering GL_POINTS
                    { return null; }
                    else
                    { throw new Exception(string.Format("Lack of searcher for [{0}]", mode)); }
                }
            }
            else
            {
                if (typeOfMode == geometryType)// I want what it is
                { return PickWhateverItIs(stageVertexId, lastIndexId, typeOfMode); }
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
        private PickedGeometry SearchPoint(RenderEventArgs arg, uint stageVertexId, int x, int y, uint lastVertexId, RecognizedPrimitiveInfo primitiveInfo, OneIndexPointSearcher searcher)
        {
            PickedGeometry pickedGeometry = new PickedGeometry();
            pickedGeometry.From = this;
            pickedGeometry.GeometryType = GeometryType.Point;
            pickedGeometry.StageVertexId = stageVertexId;
            pickedGeometry.VertexIds = new uint[] { searcher.Search(arg, x, y, primitiveInfo, this), };
            pickedGeometry.Positions = FillPickedGeometrysPosition(pickedGeometry.VertexIds);

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
        private PickedGeometry SearchLine(RenderEventArgs arg, uint stageVertexId, int x, int y, uint lastVertexId, RecognizedPrimitiveInfo primitiveInfo, OneIndexLineSearcher searcher)
        {
            PickedGeometry pickedGeometry = new PickedGeometry();
            pickedGeometry.From = this;
            pickedGeometry.GeometryType = GeometryType.Line;
            pickedGeometry.StageVertexId = stageVertexId;
            pickedGeometry.VertexIds = searcher.Search(arg, x, y, primitiveInfo, this);
            pickedGeometry.Positions = FillPickedGeometrysPosition(pickedGeometry.VertexIds);

            return pickedGeometry;
        }

        /// <summary>
        /// 是三角形，就pick一个三角形；是四边形，就pick一个四边形，是多边形，就pick一个多边形。
        /// </summary>
        /// <param name="stageVertexId"></param>
        /// <param name="primitiveInfo"></param>
        /// <param name="typeOfMode"></param>
        /// <returns></returns>
        private PickedGeometry PickWhateverItIs(uint stageVertexId, RecognizedPrimitiveInfo primitiveInfo, GeometryType typeOfMode)
        {
            PickedGeometry pickedGeometry = new PickedGeometry();
            pickedGeometry.GeometryType = typeOfMode;
            pickedGeometry.StageVertexId = stageVertexId;
            pickedGeometry.From = this;
            pickedGeometry.VertexIds = primitiveInfo.VertexIds;
            pickedGeometry.Positions = FillPickedGeometrysPosition(pickedGeometry.VertexIds);

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

        private PickedGeometry PickPoint(uint stageVertexId, uint lastVertexId)
        {
            PickedGeometry pickedGeometry = new PickedGeometry();
            pickedGeometry.GeometryType = GeometryType.Point;
            pickedGeometry.StageVertexId = stageVertexId;
            pickedGeometry.From = this;
            pickedGeometry.VertexIds = new uint[] { lastVertexId, };
            pickedGeometry.Positions = FillPickedGeometrysPosition(pickedGeometry.VertexIds);

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
            RenderEventArgs arg,
            uint lastVertexId, int x, int y)
        {
            List<RecognizedPrimitiveInfo> primitiveInfoList = GetLastIndexIdList(arg, lastVertexId);

            if (primitiveInfoList.Count == 0) { return null; }

            RecognizedPrimitiveInfo lastIndexId = GetLastIndexId(arg, primitiveInfoList, x, y);

            return lastIndexId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="twoPrimitivesIndexBufferPtr"></param>
        /// <param name="x">mouse position(Left Down is (0, 0)).</param>
        /// <param name="y">mouse position(Left Down is (0, 0)).</param>
        /// <returns></returns>
        private uint Pick(RenderEventArgs arg, OneIndexBufferPtr twoPrimitivesIndexBufferPtr,
            int x, int y)
        {
            Render4InnerPicking(arg, twoPrimitivesIndexBufferPtr);

            uint pickedIndex = ColorCodedPicking.ReadPixel(x, arg.CanvasRect.Height - y - 1);

            return pickedIndex;
        }

        /// <summary>
        /// 遍历以<paramref name="lastVertexId"/>为最后一个顶点的图元，
        /// 瞄准每个图元的索引（例如1个三角形有3个索引）中的最后一个索引，
        /// 将此索引在<see cref="IndexBufferPtr"/>中的索引（位置）收集起来。
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="lastVertexId"></param>
        /// <returns></returns>
        private List<RecognizedPrimitiveInfo> GetLastIndexIdList(RenderEventArgs arg, uint lastVertexId)
        {
            PrimitiveRecognizer recognizer = PrimitiveRecognizerFactory.Create(
                (arg.RenderMode == RenderModes.ColorCodedPicking
                && arg.PickingGeometryType == GeometryType.Point
                && this.indexBufferPtr.Mode.ToGeometryType() == GeometryType.Line) ?
                DrawMode.Points : this.indexBufferPtr.Mode);

            PrimitiveRestartSwitch glSwitch = GetPrimitiveRestartSwitch();

            var bufferPtr = this.indexBufferPtr as OneIndexBufferPtr;
            IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.ReadOnly);
            List<RecognizedPrimitiveInfo> primitiveInfoList = null;
            if (glSwitch == null)
            { primitiveInfoList = recognizer.Recognize(lastVertexId, pointer, this.indexBufferPtr as OneIndexBufferPtr); }
            else
            { primitiveInfoList = recognizer.Recognize(lastVertexId, pointer, this.indexBufferPtr as OneIndexBufferPtr, glSwitch.RestartIndex); }
            bufferPtr.UnmapBuffer();

            return primitiveInfoList;
        }
    }
}