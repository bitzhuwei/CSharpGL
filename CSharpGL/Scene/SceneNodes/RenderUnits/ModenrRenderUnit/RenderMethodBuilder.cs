using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// A smallest unit that can render somthing.
    /// </summary>
    public class RenderMethodBuilder
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
        protected AttributeMap map;

        /// <summary>
        /// A smallest unit that can render somthing.
        /// </summary>
        /// <param name="programProvider"></param>
        /// <param name="map"></param>
        /// <param name="states"></param>
        public RenderMethodBuilder(IShaderProgramProvider programProvider, AttributeMap map, params GLState[] states)
        {
            this.programProvider = programProvider;
            this.map = map;
            this.states = states;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RenderMethod ToRenderMethod(IBufferSource model)
        {
            // init shader program.
            ShaderProgram program = this.programProvider.GetShaderProgram();

            // init vertex attribute buffer objects.
            VertexShaderAttribute[] vertexAttributeBuffers;
            {
                var list = new List<VertexShaderAttribute>();
                foreach (AttributeMap.NamePair item in this.map)
                {
                    VertexBuffer buffer = model.GetVertexAttributeBuffer(item.NameInIBufferSource);
                    if (buffer == null) { throw new Exception(string.Format("[{0}] returns null buffer pointer!", model)); }
                    list.Add(new VertexShaderAttribute(buffer, item.VarNameInShader));
                }
                vertexAttributeBuffers = list.ToArray();
            }

            // init draw command.
            IDrawCommand cmd = model.GetDrawCommand();

            // init VAO.
            var vertexArrayObject = new VertexArrayObject(cmd, program, vertexAttributeBuffers);

            var result = new RenderMethod(program, vertexArrayObject, this.states);

            // RULE: Renderer takes uint.MaxValue, ushort.MaxValue or byte.MaxValue as PrimitiveRestartIndex. So take care of this rule when designing a model's index buffer.
            var ptr = cmd as DrawElementsCmd;
            if (ptr != null)
            {
                GLState glState = new PrimitiveRestartState(ptr.ElementType);
                result.StateList.Add(glState);
            }

            return result;
        }
    }
}
