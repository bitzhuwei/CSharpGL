
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class PickableRenderer : IColorCodedPicking
    {
        // Color Coded Picking
        protected VertexArrayObject vertexArrayObject4Picking;

        /// <summary>
        /// uniform mat4 VMP; (in shader)
        /// </summary>
        protected UniformMat4 uniformmMVP4Picking = new UniformMat4("MVP");

        protected ShaderProgram pickingShaderProgram;
        protected ShaderProgram PickingShaderProgram
        {
            get
            {
                if (pickingShaderProgram == null)
                { pickingShaderProgram = PickingShaderHelper.GetPickingShaderProgram(); }

                return pickingShaderProgram;
            }
        }

        /// <summary>
        /// uniform mat4 VMP; (in shader)
        /// </summary>
        public mat4 MVP
        {
            get
            {
                InnerPickableRenderer renderer = this.innerPickableRenderer;
                if (renderer != null)
                { return this.innerPickableRenderer.MVP; }
                else
                { return mat4.identity(); }
            }
            set
            {
                InnerPickableRenderer renderer = this.innerPickableRenderer;
                if (renderer != null)
                { this.innerPickableRenderer.MVP = value; }
            }
        }

        public uint PickingBaseId
        {
            get
            {
                InnerPickableRenderer renderer = this.innerPickableRenderer;
                if (renderer != null)
                { return this.innerPickableRenderer.PickingBaseId; }
                else
                { return 0; }
            }
            internal set
            {
                InnerPickableRenderer renderer = this.innerPickableRenderer;
                if (renderer != null)
                { this.innerPickableRenderer.PickingBaseId = value; }
            }
        }

        public uint GetVertexCount()
        {
            InnerPickableRenderer renderer = this.innerPickableRenderer;
            if (renderer != null)
            { return this.innerPickableRenderer.GetVertexCount(); }
            else
            { return 0; }
        }

        public PickedGeometry Pick(
            RenderEventArgs arg,
            uint stageVertexId,
            int x, int y)
        {
            InnerPickableRenderer renderer = this.innerPickableRenderer;
            if (renderer != null)
            { return this.innerPickableRenderer.Pick(arg, stageVertexId, x, y); }
            else
            { return null; }
        }

    }
}
