using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// A smallest unit that can render somthing.
    /// </summary>
    public class IPickableRenderMethodBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        protected GLState[] states;
        /// <summary>
        /// 
        /// </summary>
        protected IShaderProgramProvider programProvider;
        /// <summary>
        /// 
        /// </summary>
        private string positionNameInIBufferSource;

        /// <summary>
        /// A smallest unit that can render somthing.
        /// </summary>
        /// <param name="programProvider"></param>
        /// <param name="positionNameInIBufferSource"></param>
        /// <param name="states"></param>
        public IPickableRenderMethodBuilder(IShaderProgramProvider programProvider, string positionNameInIBufferSource, params GLState[] states)
        {
            this.programProvider = programProvider;
            this.positionNameInIBufferSource = positionNameInIBufferSource;
            this.states = states;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IPickableRenderMethod ToRenderMethod(IBufferSource model)
        {
            // init shader program.
            ShaderProgram pickProgram = this.programProvider.GetShaderProgram();

            // init vertex attribute buffer objects.
            VertexBuffer positionBuffer = model.GetVertexAttributeBuffer(this.positionNameInIBufferSource);

            // RULE: 由于picking.vert/frag只支持vec3的position buffer，所以有此硬性规定。
            if (positionBuffer == null || positionBuffer.Config != VBOConfig.Vec3)
            { throw new Exception(string.Format("Position buffer must use a type composed of 3 float as PropertyBuffer<T>'s T!")); }


            // init draw command.
            IDrawCommand cmd = model.GetDrawCommand();

            // init VAO.
            var pickingVAO = new VertexArrayObject(cmd, pickProgram, new VertexShaderAttribute(positionBuffer, PickingShaderHelper.in_Position));

            var renderUnit = new IPickableRenderMethod(pickProgram, pickingVAO, positionBuffer, this.states);

            // RULE: Renderer takes uint.MaxValue, ushort.MaxValue or byte.MaxValue as PrimitiveRestartIndex. So take care this rule when designing a model's index buffer.
            var ptr = cmd as DrawElementsCmd;
            if (ptr != null)
            {
                GLState glState = new PrimitiveRestartState(ptr.IndexBufferObject.ElementType);
                renderUnit.StateList.Add(glState);
            }

            return renderUnit;
        }
    }
}
