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

        public UIRendererComponent(UIRoot uiRoot, SceneObject bindingObject)
            : base(bindingObject)
        { this.UIRoot = uiRoot; }

        public override void Render(RenderEventArgs arg)
        {
            UIRoot renderer = this.UIRoot;
            if (renderer != null)
            {
                renderer.Layout();
                RenderAllUIs(renderer, arg);
            }
        }

        private void RenderAllUIs(UIRenderer renderer, RenderEventArgs arg)
        {
            renderer.Render(arg);

            foreach (var item in renderer.Children)
            {
                RenderAllUIs(item, arg);
            }
        }

    }
}
