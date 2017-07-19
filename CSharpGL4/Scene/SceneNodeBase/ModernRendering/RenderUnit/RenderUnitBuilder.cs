using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// A smallest unit that can render somthing.
    /// </summary>
    public class RenderUnitBuilder
    {
        protected GLState[] states;
        protected IBufferable model;
        protected IShaderProgramProvider programProvider;
        protected AttributeMap map;

        /// <summary>
        /// A smallest unit that can render somthing.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="programProvider"></param>
        /// <param name="map"></param>
        /// <param name="states"></param>
        public RenderUnitBuilder(IBufferable model, IShaderProgramProvider programProvider, AttributeMap map, params GLState[] states)
        {
            this.model = model;
            this.programProvider = programProvider;
            this.map = map;
            this.states = states;
        }

        public virtual RenderUnit ToRenderUnit()
        {
            // init shader program.
            ShaderProgram program = this.programProvider.GetShaderProgram();

            // init vertex attribute buffer objects.
            IBufferable model = this.model;
            VertexShaderAttribute[] vertexAttributeBuffers;
            {
                var list = new List<VertexShaderAttribute>();
                foreach (AttributeMap.NamePair item in this.map)
                {
                    VertexBuffer buffer = model.GetVertexAttributeBuffer(item.NameInIBufferable);
                    if (buffer == null) { throw new Exception(string.Format("[{0}] returns null buffer pointer!", model)); }
                    list.Add(new VertexShaderAttribute(buffer, item.VarNameInShader));
                }
                vertexAttributeBuffers = list.ToArray();
            }

            // init index buffer.
            IndexBuffer indexBuffer = model.GetIndexBuffer();

            // init VAO.
            var vertexArrayObject = new VertexArrayObject(indexBuffer, vertexAttributeBuffers);
            vertexArrayObject.Initialize(program);

            var result = new RenderUnit(program, vertexArrayObject, this.states);

            // RULE: Renderer takes uint.MaxValue, ushort.MaxValue or byte.MaxValue as PrimitiveRestartIndex. So take care of this rule when designing a model's index buffer.
            var ptr = indexBuffer as OneIndexBuffer;
            if (ptr != null)
            {
                GLState glState = new PrimitiveRestartState(ptr.ElementType);
                result.StateList.Add(glState);
            }

            return result;
        }
    }
}
