using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSharpGL
{
    class UIRootRendererComponent : RendererComponent
    {

        public UIRoot Root { get; private set; }

        public UIRootRendererComponent()
        {
            this.Root = new UIRoot();
        }

        public override void Render(RenderEventArgs arg)
        {
            this.Root.Layout();
            RenderAllUIs(this.Root, arg);
        }

        private void RenderAllUIs(UIRenderer uiRenderer, RenderEventArgs arg)
        {
            uiRenderer.Render(arg);
            foreach (var item in uiRenderer.Children)
            {
                RenderAllUIs(item, arg);
            }
        }
    }
}
