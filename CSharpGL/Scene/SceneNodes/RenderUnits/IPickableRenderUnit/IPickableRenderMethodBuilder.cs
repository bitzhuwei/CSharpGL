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
        protected GLSwitch[] switches;
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
        /// <param name="switches"></param>
        public IPickableRenderMethodBuilder(IShaderProgramProvider programProvider, string positionNameInIBufferSource, params GLSwitch[] switches)
        {
            this.programProvider = programProvider;
            this.positionNameInIBufferSource = positionNameInIBufferSource;
            this.switches = switches;
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
            var positionBuffers = new List<VertexBuffer>(); // position attribute is divided into blocks.
            // we only care about the position attribute.
            foreach (var buffer in model.GetVertexAttribute(this.positionNameInIBufferSource))
            {
                if (buffer == null) { throw new Exception(string.Format("[{0}] returns null buffer pointer!", model)); }
                positionBuffers.Add(buffer);
            }
            int blockCount = positionBuffers.Count;


            // RULE: 由于picking.vert/frag只支持vec3的position buffer，所以有此硬性规定。
            foreach (var buffer in positionBuffers)
            {
                if (buffer == null || buffer.Config != VBOConfig.Vec3)
                { throw new Exception(string.Format("Position buffer must use a type composed of 3 float as PropertyBuffer<T>'s T!")); }
            }

            // init draw command.
            var allDrawCommands = (from item in model.GetDrawCommand()
                                   where (item != null)
                                   select item).ToArray();
            int cmdCount = allDrawCommands.Length;
            if (cmdCount != blockCount) { throw new Exception("Draw Commands count != vertex buffer block count."); }

            // init VAO.
            var pickingVAOs = new VertexArrayObject[cmdCount];
            for (int b = 0; b < cmdCount; b++)
            {
                var vertexAttributeBuffers = new VertexShaderAttribute(positionBuffers[b], PickingShaderHelper.inPosition);
                pickingVAOs[b] = new VertexArrayObject(allDrawCommands[b], pickProgram, vertexAttributeBuffers);
            }

            return new IPickableRenderMethod(pickProgram, pickingVAOs, positionBuffers.ToArray(), this.switches);
        }
    }
}
