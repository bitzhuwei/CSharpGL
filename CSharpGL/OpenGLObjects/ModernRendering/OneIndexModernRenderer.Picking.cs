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

        public override IPickedGeometry Pick(ICamera camera, uint stageVertexID,
            int x, int y, int canvasWidth, int canvasHeight)
        {
            uint lastVertexID;
            PickedGeometry pickedGeometry = null;
            if (this.GetLastVertexIDOfPickedGeometry(stageVertexID, out lastVertexID))
            {
                // 找到 lastIndexID
                RecognizedPrimitiveIndex lastIndexID = this.GetLastIndexIDOfPickedGeometry(
                    camera, lastVertexID, x, y, canvasWidth, canvasHeight);
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
            ICamera camera,
            uint lastVertexID, int x, int y, int canvasWidth, int canvasHeight)
        {
            List<RecognizedPrimitiveIndex> lastIndexIDList = GetLastIndexIDList(lastVertexID);

            RecognizedPrimitiveIndex lastIndexID = GetLastIndexID(
                camera, lastIndexIDList, x, y, canvasWidth, canvasHeight);

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
            ICamera camera,
            List<RecognizedPrimitiveIndex> lastIndexIDList,
            int x, int y, int canvasWidth, int canvasHeight)
        {
            if (lastIndexIDList.Count == 0) { throw new ArgumentException(); }

            int current = 0;
            for (int i = 1; i < lastIndexIDList.Count; i++)
            {
                OneIndexBufferPtr twoPrimitivesIndexBufferPtr = AssembleIndexBuffer(
                    lastIndexIDList[current], lastIndexIDList[i], this.indexBufferPtr.Mode);
                uint pickedIndex = Pick(camera, twoPrimitivesIndexBufferPtr, x, y, canvasWidth, canvasHeight);
                if (pickedIndex == 1)
                { current++; }
            }

            return lastIndexIDList[current];
        }

        private uint Pick(ICamera camera, OneIndexBufferPtr twoPrimitivesIndexBufferPtr, int x, int y, int canvasWidth, int canvasHeight)
        {
            // 暂存clear color
            var originalClearColor = new float[4];
            GL.GetFloat(GetTarget.ColorClearValue, originalClearColor);

            GL.ClearColor(1.0f, 1.0f, 1.0f, 1.0f);// 白色意味着没有拾取到任何对象
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

            // 恢复clear color
            GL.ClearColor(originalClearColor[0], originalClearColor[1], originalClearColor[2], originalClearColor[3]);

            //this.positionBufferPtr.Render()
            var arg = new RenderEventArgs(RenderModes.ColorCodedPicking, camera);

            GL.Flush();
            throw new NotImplementedException();
        }

        private OneIndexBufferPtr AssembleIndexBuffer(
            RecognizedPrimitiveIndex recognizedPrimitiveIndex1,
            RecognizedPrimitiveIndex recognizedPrimitiveIndex2,
            DrawMode drawMode)
        {
            List<uint> indexArray = ArrangeIndexes(recognizedPrimitiveIndex1, recognizedPrimitiveIndex1);
            if (indexArray.Count !=
                recognizedPrimitiveIndex1.IndexIDList.Count
                + 1
                + recognizedPrimitiveIndex2.IndexIDList.Count)
            { throw new Exception(); }

            using (var indexBuffer = new OneIndexBuffer<uint>(drawMode, BufferUsage.StaticDraw))
            {
                indexBuffer.Alloc(
                    recognizedPrimitiveIndex1.IndexIDList.Count
                    + 1
                    + recognizedPrimitiveIndex2.IndexIDList.Count);
                unsafe
                {
                    var array = (uint*)indexBuffer.FirstElement();
                    for (int i = 0; i < indexArray.Count; i++)
                    {
                        array[i] = indexArray[i];
                    }
                }

                return indexBuffer.GetBufferPtr() as OneIndexBufferPtr;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recognizedPrimitiveIndex11"></param>
        /// <param name="recognizedPrimitiveIndex12"></param>
        /// <returns></returns>
        private List<uint> ArrangeIndexes(RecognizedPrimitiveIndex recognizedPrimitiveIndex11, RecognizedPrimitiveIndex recognizedPrimitiveIndex12)
        {
            List<uint> sameIndexList = new List<uint>();
            List<uint> array1 = new List<uint>(recognizedPrimitiveIndex11.IndexIDList);
            List<uint> array2 = new List<uint>(recognizedPrimitiveIndex12.IndexIDList);
            array1.Sort(); array2.Sort();
            int p1 = 0, p2 = 0;
            while (p1 < array1.Count && p2 < array2.Count)
            {
                if (array1[p1] < array2[p2])
                { p1++; }
                else if (array1[p1] > array1[p2])
                { p2++; }
                else
                {
                    sameIndexList.Add(array1[p1]);
                    array1.RemoveAt(p1);
                    array2.RemoveAt(p2);
                }
            }

            if (array1.Last() == array2.Last()) { throw new Exception(); }

            List<uint> result = new List<uint>();
            result.AddRange(sameIndexList);
            result.AddRange(array1);
            result.Add(uint.MaxValue);// primitive restart index
            result.AddRange(sameIndexList);
            result.AddRange(array2);

            return result;
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
