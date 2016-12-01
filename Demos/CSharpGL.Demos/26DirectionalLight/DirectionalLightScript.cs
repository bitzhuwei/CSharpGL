using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL.Demos
{
    class DirectionalLightScript : PickingScript
    {
        private ICanvas canvas;
        private ICamera camera;
        private TranslateManipulater manipulater;

        public DirectionalLightScript(ICanvas canvas, ICamera camera, RendererBase renderer)
        {
            this.canvas = canvas;
            this.camera = camera;
            this.manipulater = new TranslateManipulater(renderer);
        }

        public override void Bind()
        {
            this.manipulater.Bind(this.camera, this.canvas);
        }

        public override void Unbind()
        {
            this.manipulater.Unbind();
        }

    }
}
