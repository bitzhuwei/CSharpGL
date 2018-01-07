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
            var attrCount = this.map.Count(); // how many kinds of vertex attributes?
            var allBlocks = new List<VertexBuffer>[attrCount];
            var allNames = new string[attrCount];
            int blockCount = 0; // how many blocks an attribute is divided into?
            int index = 0;
            foreach (AttributeMap.NamePair item in this.map)
            {
                blockCount = 0;
                allBlocks[index] = new List<VertexBuffer>();
                foreach (var buffer in model.GetVertexAttributeBuffer(item.NameInIBufferSource))
                {
                    if (buffer == null) { throw new Exception(string.Format("[{0}] returns null buffer pointer!", model)); }
                    allBlocks[index].Add(buffer);
                    allNames[index] = item.VarNameInShader;
                    blockCount++;
                }
                if (blockCount != allBlocks[0].Count) { throw new Exception("Not all vertex attribute buffers' block count are the same!"); }

                index++;
            }

            // init draw command.
            var allDrawCommands = (from item in model.GetDrawCommand()
                                   where (item != null)
                                   select item).ToArray();
            if (attrCount > 0 && allDrawCommands.Length != blockCount) { throw new Exception("Draw Commands count != vertex buffer block count."); }

            // init VAO.
            var vaos = new VertexArrayObject[blockCount];
            for (int b = 0; b < blockCount; b++)
            {
                var vertexAttributeBuffers = new VertexShaderAttribute[attrCount];
                for (int a = 0; a < attrCount; a++)
                {
                    vertexAttributeBuffers[a] = new VertexShaderAttribute(allBlocks[a][b], allNames[a]);
                }
                vaos[b] = new VertexArrayObject(allDrawCommands[b], program, vertexAttributeBuffers);
            }

            var renderUnit = new RenderMethod(program, vaos, this.states);

            // RULE: Renderer takes uint.MaxValue, ushort.MaxValue or byte.MaxValue as PrimitiveRestartIndex. So take care of this rule when designing a model's index buffer.
            foreach (var cmd in allDrawCommands)
            {
                var ptr = cmd as IHasIndexBuffer;
                if (ptr != null)
                {
                    GLState glState = new PrimitiveRestartState(ptr.IndexBufferObject.ElementType);
                    renderUnit.StateList.Add(glState);
                    break;
                }
            }

            return renderUnit;
        }
    }
}
