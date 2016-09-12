using System.Collections.Generic;
using System.Linq;

namespace CSharpGL
{
    public partial class ComputeRenderer
    {
        private Stack<UniformVariable> uniformVariableStack = new Stack<UniformVariable>();

        //private Stack<UniformArrayVariable> uniformArrayVariableStack = new Stack<UniformArrayVariable>();
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            ShaderProgram program = this.Program;
            if (program == null) { return; }

            // 绑定shader
            program.Bind();

            SetUniformValues(program);

            //TODO: not implemented parameters.
            OpenGL.GetDelegateFor<OpenGL.glDispatchCompute>()(1, 1, 1);

            ResetUniformValues(program);

            // 解绑shader
            program.Unbind();
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
    }
}