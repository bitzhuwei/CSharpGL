using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL.Demos
{
    class ModelScript : PickingScript
    {
        private ArcBallManipulater manipulater = new ArcBallManipulater(System.Windows.Forms.MouseButtons.Left);

        public ArcBallManipulater Manipulater
        {
            get { return manipulater; }
        }
        private ICanvas canvas;
        private ICamera camera;

        public ModelScript(ICanvas canvas, ICamera camera)
        {
            this.canvas = canvas;
            this.camera = camera;
        }

        public override void Bind()
        {
            this.manipulater.Bind(camera, canvas);
        }

        public override void Unbind()
        {
            this.manipulater.Unbind();
        }

        protected override void DoUpdate()
        {
            mat4 model = this.manipulater.GetRotationMatrix();
            Quaternion quaternion = model.ToQuaternion();
            float angleDegree;
            vec3 axis;
            quaternion.Parse(out angleDegree, out axis);

            RendererBase renderer = this.BindingObject.Renderer;
            renderer.RotationAngleDegree = angleDegree;
            renderer.RotationAxis = axis;
        }
    }
}
