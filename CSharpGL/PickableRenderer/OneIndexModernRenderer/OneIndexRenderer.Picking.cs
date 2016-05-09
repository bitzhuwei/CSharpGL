
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    // check http://www.cnblogs.com/bitzhuwei/p/CSharpGL-18-Picking-of-OneIndexBuffer.html
    public partial class OneIndexRenderer
    {

        public override PickedGeometry Pick(RenderEventArgs arg, uint stageVertexId,
            int x, int y)
        {
            uint lastVertexId;
            if (!this.GetLastVertexIdOfPickedGeometry(stageVertexId, out lastVertexId))
            { return null; }

            // 找到 lastIndexId
            RecognizedPrimitiveIndex lastIndexId = this.GetLastIndexIdOfPickedGeometry(
                arg, lastVertexId, x, y);
            if (lastIndexId == null)
            {
                Debug.WriteLine(
                    "Got lastVertexId[{0}] but no lastIndexId! Params are [{1}] [{2}] [{3}] [{4}]",
                    lastVertexId, arg, stageVertexId, x, y);
                { return null; }
            }

            GeometryType geometryType = arg.PickingGeometryType;
            DrawMode mode = this.GetIndexBufferPtr().Mode;
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

        private PickedGeometry SearchPoint(RenderEventArgs arg, uint stageVertexId, int x, int y, uint lastVertexId, RecognizedPrimitiveIndex lastIndexId, OneIndexPointSearcher searcher)
        {
            PickedGeometry pickedGeometry = new PickedGeometry();
            pickedGeometry.From = this;
            pickedGeometry.GeometryType = GeometryType.Line;
            pickedGeometry.StageVertexId = stageVertexId;
            pickedGeometry.Indexes = new uint[] { searcher.Search(arg, x, y, lastIndexId, this), };
            pickedGeometry.Positions = FillPickedGeometrysPosition(pickedGeometry.Indexes);

            return pickedGeometry;
        }

        private PickedGeometry SearchLine(RenderEventArgs arg, uint stageVertexId, int x, int y, uint lastVertexId, RecognizedPrimitiveIndex lastIndexId, OneIndexLineSearcher searcher)
        {
            PickedGeometry pickedGeometry = new PickedGeometry();
            pickedGeometry.From = this;
            pickedGeometry.GeometryType = GeometryType.Line;
            pickedGeometry.StageVertexId = stageVertexId;
            pickedGeometry.Indexes = searcher.Search(arg, x, y, lastIndexId, this);
            pickedGeometry.Positions = FillPickedGeometrysPosition(pickedGeometry.Indexes);

            return pickedGeometry;
        }

        /// <summary>
        /// 是三角形，就pick一个三角形；是四边形，就pick一个四边形，是多边形，就pick一个多边形。
        /// </summary>
        /// <param name="stageVertexId"></param>
        /// <param name="lastIndexId"></param>
        /// <param name="typeOfMode"></param>
        /// <returns></returns>
        private PickedGeometry PickWhateverItIs(uint stageVertexId, RecognizedPrimitiveIndex lastIndexId, GeometryType typeOfMode)
        {
            PickedGeometry pickedGeometry = new PickedGeometry();
            pickedGeometry.GeometryType = typeOfMode;
            pickedGeometry.StageVertexId = stageVertexId;
            pickedGeometry.From = this;
            pickedGeometry.Indexes = lastIndexId.IndexIdList.ToArray();
            pickedGeometry.Positions = FillPickedGeometrysPosition(pickedGeometry.Indexes);

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
            pickedGeometry.Indexes = new uint[] { lastVertexId, };
            pickedGeometry.Positions = FillPickedGeometrysPosition(pickedGeometry.Indexes);

            return pickedGeometry;
        }

        private RecognizedPrimitiveIndex GetLastIndexIdOfPickedGeometry(
            RenderEventArgs arg,
            uint lastVertexId, int x, int y)
        {
            List<RecognizedPrimitiveIndex> lastIndexIdList = GetLastIndexIdList(arg, lastVertexId);

            if (lastIndexIdList.Count == 0) { return null; }

            RecognizedPrimitiveIndex lastIndexId = GetLastIndexId(
                arg, lastIndexIdList, x, y);

            return lastIndexId;
        }

        private uint Pick(RenderEventArgs arg, OneIndexBufferPtr twoPrimitivesIndexBufferPtr,
            int x, int y)
        {
            Render4InnerPicking(arg, twoPrimitivesIndexBufferPtr);

            uint pickedIndex = ColorCodedPicking.ReadPixel(x, y, arg.CanvasRect.Height);

            return pickedIndex;
        }

        /// <summary>
        /// 遍历以<see cref="lastVerteID"/>为最后一个顶点的图元，
        /// 瞄准每个图元的索引（例如1个三角形有3个索引）中的最后一个索引，
        /// 将此索引在<see cref="indexBufferPtr"/>中的索引（位置）收集起来。
        /// </summary>
        /// <param name="lastVertexId"></param>
        /// <returns></returns>
        private List<RecognizedPrimitiveIndex> GetLastIndexIdList(RenderEventArgs arg, uint lastVertexId)
        {
            PrimitiveRecognizer recognizer = PrimitiveRecognizerFactory.Create(
                (arg.RenderMode == RenderModes.ColorCodedPicking
                && arg.PickingGeometryType == GeometryType.Point
                && this.Mode.ToGeometryType() == GeometryType.Line) ?
                DrawMode.Points : this.GetIndexBufferPtr().Mode);

            PrimitiveRestartSwitch glSwitch = GetPrimitiveRestartSwitch();

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, this.indexBufferPtr.BufferId);
            IntPtr pointer = GL.MapBuffer(BufferTarget.ElementArrayBuffer, MapBufferAccess.ReadOnly);
            List<RecognizedPrimitiveIndex> lastIndexIdList = null;
            if (glSwitch == null)
            { lastIndexIdList = recognizer.Recognize(lastVertexId, pointer, this.indexBufferPtr as OneIndexBufferPtr); }
            else
            { lastIndexIdList = recognizer.Recognize(lastVertexId, pointer, this.indexBufferPtr as OneIndexBufferPtr, glSwitch.RestartIndex); }
            GL.UnmapBuffer(BufferTarget.ElementArrayBuffer);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);

            return lastIndexIdList;
        }

    }
}
