using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 高亮显示某些图元
    /// </summary>
    public partial class HighlightModernRenderer
    {

        protected override void DoInitialize()
        {
            // init index buffer object's renderer
            this.oneIndexBufferPtr = this.bufferable.GetIndex() as OneIndexBufferPtr;
            if (this.oneIndexBufferPtr == null) { throw new Exception(); }

            // init shader program
            ShaderProgram program = new ShaderProgram();
            var shaders = (from item in shaderCode select item.CreateShader()).ToArray();
            program.Create(shaders);
            this.shaderProgram = program;
            foreach (var item in shaders) { item.Delete(); }

            // init property buffer objects
            var propertyBufferPtrs = new PropertyBufferPtr[propertyNameMap.Count()];
            int index = 0;
            foreach (var item in propertyNameMap)
            {
                PropertyBufferPtr bufferPtr = this.bufferable.GetProperty(
                    item.nameInIBufferable, item.VarNameInShader);
                if (bufferPtr == null) { throw new Exception(); }

                if (item.nameInIBufferable == positionNameInIBufferable)
                {
                    if (bufferPtr.DataSize != 3 || bufferPtr.DataType != GL.GL_FLOAT)
                    { throw new Exception(string.Format("Position buffer must use a type composed of 3 float as PropertyBuffer<T>'s T!")); }
                    this.positionBufferPtr = new PropertyBufferPtr(
                        "in_Position",// in_Postion same with in the PickingShader.vert shader
                        bufferPtr.BufferId,
                        bufferPtr.DataSize,
                        bufferPtr.DataType,
                        bufferPtr.Length,
                        bufferPtr.ByteLength);
                    // 只需要1个position buffer，其他的property buffer都不需要
                    propertyBufferPtrs[index++] = bufferPtr;
                }
            }
            this.propertyBufferPtrs = propertyBufferPtrs;

            this.bufferable = null;
            this.shaderCode = null;
            this.propertyNameMap = null;
        }


    }


}
