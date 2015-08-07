using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects
{
    public abstract class ShaderVAOElement : SceneElementBase
    {
        protected uint[] vao = new uint[1];

        public abstract void BeforeRendering(RenderModes renderMode);

        public override void Render(RenderModes renderMode)
        {
            BeforeRendering(renderMode);

            GL.BindVertexArray(vao[0]);

            GL.BindVertexArray(0);

            AfterRendering(renderMode);
        }

        public abstract void AfterRendering(RenderModes renderMode);
    }
}
