using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class UIRendererComponent : RendererComponent
    {

        const string strprojection = "projection";
        const string strview = "view";
        const string strmodel = "model";
        //uint projectionLocation;
        //uint viewLocation;
        //uint modelLocation;

        [Description("Root renderer of UI controls.")]
        public UIRoot UIRoot { get; private set; }

        public UIRendererComponent(UIRoot uiRoot, SceneObject bindingObject = null)
            : base(bindingObject)
        { this.UIRoot = uiRoot; }

        public override void Render(RenderEventArgs arg)
        {
            UIRoot renderer = this.UIRoot;
            if (renderer != null)
            {
                renderer.Render(arg);
            }
        }

    }
}
