using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// A smallest unit that can render somthing.
    /// </summary>
    public class IPickableRenderUnitBuilder
    {
        protected GLState[] states;
        protected IShaderProgramProvider programProvider;
        protected string positionNameInIBufferable;

        /// <summary>
        /// A smallest unit that can render somthing.
        /// </summary>
        /// <param name="programProvider"></param>
        /// <param name="map"></param>
        /// <param name="states"></param>
        public IPickableRenderUnitBuilder(IShaderProgramProvider programProvider, string positionNameInIBufferable, params GLState[] states)
        {
            this.programProvider = programProvider;
            this.positionNameInIBufferable = positionNameInIBufferable;
            this.states = states;
        }

        public IPickableRenderUnit ToRenderUnit(IBufferSource model)
        {
            // init shader program.
            ShaderProgram pickProgram = this.programProvider.GetShaderProgram();

            // init vertex attribute buffer objects.
            VertexBuffer positionBuffer = model.GetVertexAttributeBuffer(this.positionNameInIBufferable);

            // RULE: 由于picking.vert/frag只支持vec3的position buffer，所以有此硬性规定。
            if (positionBuffer == null || positionBuffer.Config != VBOConfig.Vec3)
            { throw new Exception(string.Format("Position buffer must use a type composed of 3 float as PropertyBuffer<T>'s T!")); }


            // init index buffer.
            IndexBuffer indexBuffer = model.GetIndexBuffer();

            // init VAO.
            var pickingVAO = new VertexArrayObject(indexBuffer, new VertexShaderAttribute(positionBuffer, "in_Position"));
            pickingVAO.Initialize(pickProgram);

            var renderUnit = new IPickableRenderUnit(pickProgram, pickingVAO, positionBuffer, this.states);

            // RULE: Renderer takes uint.MaxValue, ushort.MaxValue or byte.MaxValue as PrimitiveRestartIndex. So take care this rule when designing a model's index buffer.
            var ptr = indexBuffer as OneIndexBuffer;
            if (ptr != null)
            {
                GLState glState = new PrimitiveRestartState(ptr.ElementType);
                renderUnit.StateList.Add(glState);
            }

            return renderUnit;
        }
    }
}
