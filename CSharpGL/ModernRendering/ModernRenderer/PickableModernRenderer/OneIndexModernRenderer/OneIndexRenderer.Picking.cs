
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
                DrawMode mode = this.GetIndexBufferPtr().Mode;
                if (this.OnPrimitiveTest(lastVertexId, mode))
                { return PickPoint(stageVertexId, lastVertexId); }
                else
                { return null; }
            }
            return null;
            //else if (geometryType == GeometryType.Line)
            //{
            //    DrawMode mode = this.GetIndexBufferPtr().Mode;
            //    GeometryType typeOfMode = mode.ToGeometryType();
            //    if (geometryType == typeOfMode)
            //    { return PickWhateverItIs(stageVertexId, lastVertexId, mode, typeOfMode); }
            //    else
            //    {
            //        ZeroIndexLineSearcher searcher = GetLineSearcher(mode);
            //        if (searcher != null)// line is from triangle, quad or polygon
            //        { return SearchLine(arg, stageVertexId, x, y, lastVertexId, searcher); }
            //        else if (mode == DrawMode.Points)
            //        { return null; }
            //        else
            //        { throw new Exception(string.Format("Lack of searcher for [{0}]", mode)); }
            //    }
            //}
            //else
            //{
            //    DrawMode mode = this.GetIndexBufferPtr().Mode;
            //    GeometryType typeOfMode = mode.ToGeometryType();
            //    if (typeOfMode == geometryType)// I want what it is
            //    { return PickWhateverItIs(stageVertexId, lastVertexId, mode, typeOfMode); }
            //    else
            //    { return null; }
            //    //{ throw new Exception(string.Format("Lack of searcher for [{0}]", mode)); }
            //}
            //PickedGeometry pickedGeometry = null;
            //// 找到 lastIndexId
            //RecognizedPrimitiveIndex lastIndexId = this.GetLastIndexIdOfPickedGeometry(
            //    arg, lastVertexId, x, y);
            //if (lastIndexId == null)
            //{
            //    Debug.WriteLine(
            //        "Got lastVertexId[{0}] but no lastIndexId! Params are [{1}] [{2}] [{3}] [{4}]",
            //        lastVertexId, arg, stageVertexId, x, y);
            //}
            //else
            //{
            //    // 获取pickedGeometry
            //    pickedGeometry = this.GetGeometry(arg, lastIndexId, stageVertexId);
            //}

            //return pickedGeometry;
        }

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

        private PickedGeometry GetGeometry(RenderEventArgs arg,
            RecognizedPrimitiveIndex lastIndexId, uint stageVertexId)
        {
            GeometryType targetType = arg.PickingGeometryType;
            PickedGeometry pickedGeometry = null;
            if (targetType == GeometryType.Point)
            {
                pickedGeometry = new PickedGeometry();
                pickedGeometry.GeometryType = GeometryType.Point;
                pickedGeometry.StageVertexId = stageVertexId;
                pickedGeometry.From = this;
                pickedGeometry.Indexes = new uint[] { lastIndexId.LastIndexId, };
                pickedGeometry.Positions = FillPickedGeometrysPosition(pickedGeometry.Indexes);
            }
            else if (targetType == GeometryType.Line)
            {

            }
            else
            {
                DrawMode mode = this.GetIndexBufferPtr().Mode;
                if (mode.ToGeometryType() == GeometryType.Triangle)
                {
                    pickedGeometry = new PickedGeometry();
                    pickedGeometry.GeometryType = GeometryType.Triangle;
                    pickedGeometry.StageVertexId = stageVertexId;
                    pickedGeometry.From = this;
                    pickedGeometry.Indexes = lastIndexId.IndexIdList.ToArray();
                    pickedGeometry.Positions = FillPickedGeometrysPosition(pickedGeometry.Indexes);
                }
            }

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
                this.GetIndexBufferPtr().Mode);

            PrimitiveRestartSwitch glSwitch = GetPrimitiveRestartSwitch();

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, this.oneIndexBufferPtr.BufferId);
            IntPtr pointer = GL.MapBuffer(BufferTarget.ElementArrayBuffer, MapBufferAccess.ReadOnly);
            List<RecognizedPrimitiveIndex> lastIndexIdList = null;
            if (glSwitch == null)
            { lastIndexIdList = recognizer.Recognize(lastVertexId, pointer, this.oneIndexBufferPtr); }
            else
            { lastIndexIdList = recognizer.Recognize(lastVertexId, pointer, this.oneIndexBufferPtr, glSwitch.RestartIndex); }
            GL.UnmapBuffer(BufferTarget.ElementArrayBuffer);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);

            return lastIndexIdList;
        }

    }
}
