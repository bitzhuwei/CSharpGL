using CSharpGL.Objects.VertexArrayObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Winforms
{
    class PyramidVAOElement : VAOElement
    {

        protected override void InitializeShader(out Objects.Shader.ShaderProgram shader)
        {
            throw new NotImplementedException();
        }

        protected override void InitializeVAO(out uint[] vao, out PrimitiveMode primitiveMode, out int vertexCount)
        {
            throw new NotImplementedException();
        }

        protected override void BeforeRendering(Objects.RenderModes renderMode)
        {
            throw new NotImplementedException();
        }

        protected override void AfterRendering(Objects.RenderModes renderMode)
        {
            throw new NotImplementedException();
        }
    }
}
