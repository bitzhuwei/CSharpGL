using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    class UpdateBillboardPosition : ScriptComponent
    {
        private IWorldPosition renderer;
        public IWorldPosition TargetRenderer { get; set; }

        public UpdateBillboardPosition(SceneObject obj = null)
            : this(null, obj) { }

        public UpdateBillboardPosition(IWorldPosition targetRenderer, SceneObject obj = null)
            : base(obj)
        {
            this.TargetRenderer = targetRenderer;
        }

        protected override void DoUpdate(double elapsedTime)
        {
            if (this.renderer == null)
            {
                this.renderer = this.BindingObject.Renderer as IWorldPosition;
            }
            //this.transform.Position = this.TargetTransform.Position + new vec3(0, 1, 0);
            this.renderer.Position = this.TargetRenderer.Position + new vec3(0, 0.3f, 0);
        }

    }
}
