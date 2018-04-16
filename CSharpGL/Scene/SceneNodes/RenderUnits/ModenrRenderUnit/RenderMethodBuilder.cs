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
        protected GLSwitch[] switches;
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
        /// <param name="switches"></param>
        public RenderMethodBuilder(IShaderProgramProvider programProvider, AttributeMap map, params GLSwitch[] switches)
        {
            this.programProvider = programProvider;
            this.map = map;
            this.switches = switches;
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
                foreach (var buffer in model.GetVertexAttribute(item.NameInIBufferSource))
                {
                    if (buffer == null) { throw new Exception(string.Format("[{0}] returns null buffer pointer!", model)); }
                    allBlocks[index].Add(buffer);
                    allNames[index] = item.VarNameInShader;
                    blockCount++;
                }
                if (blockCount != allBlocks[0].Count) { throw new Exception("Not all vertex attribute buffers' block count are the same!"); }

                index++;
            }

            // init draw commands.
            var drawCmds = (from item in model.GetDrawCommand()
                            where (item != null)
                            select item).ToArray();
            int cmdCount = drawCmds.Length;
            if (attrCount > 0 && cmdCount != blockCount) { throw new Exception("Draw Commands count != vertex buffer block count."); }

            // init VAOs.
            var vaos = new VertexArrayObject[cmdCount];
            for (int c = 0; c < cmdCount; c++)
            {
                var vertexShaderAttributes = new VertexShaderAttribute[attrCount];
                for (int a = 0; a < attrCount; a++)
                {
                    List<VertexBuffer> vertexAttribute = allBlocks[a];
                    string varNameInShader = allNames[a];
                    vertexShaderAttributes[a] = new VertexShaderAttribute(vertexAttribute[c], varNameInShader);
                }
                vaos[c] = new VertexArrayObject(drawCmds[c], program, vertexShaderAttributes);
            }

            return new RenderMethod(program, vaos, this.switches);
        }
    }
}
