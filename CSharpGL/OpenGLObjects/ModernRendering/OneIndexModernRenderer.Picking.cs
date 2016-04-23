using GLM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    //TODO:  copyed from ModernRenderer, need to update(This is complex)
    public partial class OneIndexModernRenderer
    {

        public override IPickedGeometry Pick(uint stageVertexID, int x, int y, int canvasWidth, int canvasHeight)
        {
            uint lastVertexID;
            PickedGeometry pickedGeometry = null;
            if (this.GetLastVertexIDOfPickedGeometry(stageVertexID, out lastVertexID))
            {
                // 找到 lastIndexID
                RecognizedPrimitiveIndex lastIndexID = this.GetLastIndexIDOfPickedGeometry(
                    lastVertexID, x, y, canvasWidth, canvasHeight);
                // 获取pickedGeometry
                pickedGeometry = this.GetGeometry(lastIndexID, stageVertexID);
            }

            return pickedGeometry;
        }

        private PickedGeometry GetGeometry(RecognizedPrimitiveIndex lastIndexID, uint stageVertexID)
        {
            var pickedGeometry = new PickedGeometry();
            pickedGeometry.GeometryType = this.indexBufferPtr.Mode.ToPrimitiveMode().ToGeometryType();
            pickedGeometry.StageVertexID = stageVertexID;
            pickedGeometry.From = this;
            //TODO: 
            //pickedGeometry.Positions = ?
            pickedGeometry.Indexes = lastIndexID.IndexIDList.ToArray();

            return pickedGeometry;
        }

        private RecognizedPrimitiveIndex GetLastIndexIDOfPickedGeometry(
            uint lastVertexID, int x, int y, int canvasWidth, int canvasHeight)
        {
            List<RecognizedPrimitiveIndex> lastIndexIDList = GetLastIndexIDList(lastVertexID);

            RecognizedPrimitiveIndex lastIndexID = GetLastIndexID(
                lastIndexIDList, x, y, canvasWidth, canvasHeight);

            return lastIndexID;
        }

        /// <summary>
        /// 在所有可能的图元（<see cref="lastVertexID"/>匹配）中，
        /// 逐个测试，找到最接近摄像机的那个图元，
        /// 返回此图元的最后一个索引在<see cref="indexBufferPtr"/>中的索引（位置）。
        /// </summary>
        /// <param name="lastIndexIDList"></param>
        /// <returns></returns>
        private RecognizedPrimitiveIndex GetLastIndexID(
            List<RecognizedPrimitiveIndex> lastIndexIDList,
            int x, int y, int canvasWidth, int canvasHeight)
        {
            if (lastIndexIDList.Count == 0) { throw new ArgumentException(); }

            GL.BindBuffer(BufferTarget.ArrayBuffer, this.positionBufferPtr.BufferID);
            IntPtr pointer = GL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadOnly);

            int current = 0;
            for (int i = 1; i < lastIndexIDList.Count; i++)
            {
                OneIndexBuffer<uint> twoPrimitivesIndexBuffer = AssembleIndexBuffer(
                    lastIndexIDList[i - 1], lastIndexIDList[i], this.indexBufferPtr.Mode);

            }

            GL.UnmapBuffer(BufferTarget.ArrayBuffer);

            return lastIndexIDList[current];
        }

        private OneIndexBuffer<uint> AssembleIndexBuffer(RecognizedPrimitiveIndex recognizedPrimitiveIndex1, RecognizedPrimitiveIndex recognizedPrimitiveIndex2, DrawMode drawMode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 遍历以<see cref="lastVerteID"/>为最后一个顶点的图元，
        /// 瞄准每个图元的索引（例如1个三角形有3个索引）中的最后一个索引，
        /// 将此索引在<see cref="indexBufferPtr"/>中的索引（位置）收集起来。
        /// </summary>
        /// <param name="lastVertexID"></param>
        /// <returns></returns>
        private List<RecognizedPrimitiveIndex> GetLastIndexIDList(uint lastVertexID)
        {
            List<RecognizedPrimitiveIndex> lastIndexIDList = null;
            PrimitiveRecognizer recognizer = PrimitiveRecognizerFactory.Create(this.indexBufferPtr.Mode);
            PrimitiveRestartSwitch glSwitch = null;
            foreach (var item in this.switchList)
            {
                if (item is PrimitiveRestartSwitch)
                {
                    glSwitch = item as PrimitiveRestartSwitch;
                    break;
                }
            }
            GL.BindBuffer(BufferTarget.ArrayBuffer, this.oneIndexBufferPtr.BufferID);
            IntPtr pointer = GL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadOnly);

            if (glSwitch == null)
            { lastIndexIDList = recognizer.Recognize(lastVertexID, pointer, this.indexBufferPtr.Length); }
            else
            { lastIndexIDList = recognizer.Recognize(lastVertexID, pointer, this.indexBufferPtr.Length, glSwitch.RestartIndex); }

            GL.UnmapBuffer(BufferTarget.ArrayBuffer);

            return lastIndexIDList;
        }
    }
}
