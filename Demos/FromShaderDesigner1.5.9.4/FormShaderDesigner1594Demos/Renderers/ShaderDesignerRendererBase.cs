using GLM;
using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpGL.Objects.VertexBuffers;
using CSharpGL.Objects.Models;
using CSharpGL;

namespace FormShaderDesigner1594Demos.Renderers
{
    public abstract class ShaderDesignerRendererBase : CSharpGL.Objects.RendererBase
    {
        protected IndexBufferPointerBase indexBufferRenderer;
        protected int indexCount;
        public PolygonModes polygonMode = PolygonModes.Filled;

        protected const string strmodelMatrix = "modelMatrix";
        public mat4 modelMatrix;

        protected const string strviewMatrix = "viewMatrix";
        public mat4 viewMatrix;

        protected const string strprojectionMatrix = "projectionMatrix";
        public mat4 projectionMatrix;


        public void DecreaseVertexCount()
        {
            {
                IndexBufferPointer renderer = this.indexBufferRenderer as IndexBufferPointer;
                if (renderer != null)
                {
                    if (renderer.ElementCount > 0)
                    {
                        renderer.ElementCount--;
                    }

                    return;
                }
            }
            {
                ZeroIndexBufferPointer renderer = this.indexBufferRenderer as ZeroIndexBufferPointer;
                if (renderer != null)
                {
                    if (renderer.VertexCount > 0)
                    {
                        renderer.VertexCount--;
                    }

                    return;
                }
            }

        }

        public void IncreaseVertexCount()
        {
            {
                IndexBufferPointer renderer = this.indexBufferRenderer as IndexBufferPointer;
                if (renderer != null)
                {
                    if (renderer.ElementCount < this.indexCount)
                    {
                        renderer.ElementCount++;
                    }

                    return;
                }
            }
            {
                ZeroIndexBufferPointer renderer = this.indexBufferRenderer as ZeroIndexBufferPointer;
                if (renderer != null)
                {
                    if (renderer.VertexCount < this.indexCount)
                    {
                        renderer.VertexCount++;
                    }

                    return;
                }
            }
        }

    }

}
