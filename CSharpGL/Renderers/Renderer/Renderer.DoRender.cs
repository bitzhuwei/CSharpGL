using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;


namespace CSharpGL
{
    public partial class Renderer
    {

        private Stack<UniformVariable> uniformVariableStack = new Stack<UniformVariable>();
        //private Stack<UniformArrayVariable> uniformArrayVariableStack = new Stack<UniformArrayVariable>();

        protected override void DoRender(RenderEventArgs arg)
        {
            ShaderProgram program = this.shaderProgram;
            if (program == null) { return; }

            // 绑定shader
            program.Bind();

            SetUniformValues(program);

            SwitchesOn();

            IndexBufferPtr indexBufferPtr = this.indexBufferPtr;
            if (this.vertexArrayObject == null)
            {
                PropertyBufferPtr[] propertyBufferPtrs = this.propertyBufferPtrs;
                if (indexBufferPtr != null && propertyBufferPtrs != null)
                {
                    var vertexArrayObject = new VertexArrayObject(
                        indexBufferPtr, propertyBufferPtrs);
                    vertexArrayObject.Create(arg, program);

                    this.vertexArrayObject = vertexArrayObject;
                }
            }
            {
                VertexArrayObject vertexArrayObject = this.vertexArrayObject;
                if (vertexArrayObject != null)
                {
                    if (vertexArrayObject.IndexBufferPtr != indexBufferPtr)
                    { vertexArrayObject.IndexBufferPtr = indexBufferPtr; }
                    vertexArrayObject.Render(arg, program);
                }
            }

            SwithesOff();

            ResetUniformValues(program);

            // 解绑shader
            program.Unbind();
        }

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SwitchesOn()
        {
            int count = this.switchList.Count;
            for (int i = 0; i < count; i++)
            {
                this.switchList[i].On();
            }
        }

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SwithesOff()
        {
            int count = this.switchList.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                this.switchList[i].Off();
            }
        }

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ResetUniformValues(ShaderProgram program)
        {
            //while (uniformArrayVariableStack.Count > 0)
            //{
            //    UniformArrayVariable item = uniformArrayVariableStack.Pop();
            //    item.ResetUniform(program);
            //}

            while (uniformVariableStack.Count > 0)
            {
                UniformVariable item = uniformVariableStack.Pop();
                item.ResetUniform(program);
            }
        }

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SetUniformValues(ShaderProgram program)
        {
            var updatedUniforms = (from item in this.uniformVariables where item.Updated select item).ToArray();
            foreach (var item in updatedUniforms) { item.SetUniform(program); uniformVariableStack.Push(item); }
        }

        public IndexBufferPtr IndexBufferPtr
        {
            get
            {
                return this.indexBufferPtr;
            }
        }
    }
}
