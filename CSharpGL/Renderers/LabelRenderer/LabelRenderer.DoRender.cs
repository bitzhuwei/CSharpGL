using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// Renders a label that always faces camera in 3D space.
    /// </summary>
    public partial class LabelRenderer
    {

        protected override void DoRender(RenderEventArgs arg)
        {
            this.SetUniform("billboardCenter_worldspace", this.WorldPosition);
            int[] viewport = OpenGL.GetViewport();
            this.SetUniform("viewportSize", new vec2(viewport[2], viewport[3]));
            mat4 projection = arg.Camera.GetProjectionMat4();
            mat4 view = arg.Camera.GetViewMat4();
            this.SetUniform("projection", projection);
            this.SetUniform("view", view);

            base.DoRender(arg);
        }
        
    }
}
