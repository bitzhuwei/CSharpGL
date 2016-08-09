using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    class UpdateLabelPosition : ScriptComponent
    {
        private LabelRenderer renderer;
        public IWorldPosition TargetRenderer { get; set; }

        public UpdateLabelPosition(SceneObject obj = null)
            : this(null, obj) { }

        public UpdateLabelPosition(IWorldPosition targetRenderer, SceneObject obj = null)
            : base(obj)
        {
            this.TargetRenderer = targetRenderer;
        }

        protected override void DoInitialize()
        {
            //this.transform = this.BindingObject.GetScript<TransformScript>();
            this.renderer = this.BindingObject.Renderer as LabelRenderer;
        }

        protected override void DoUpdate(double elapsedTime)
        {
            //this.transform.Position = this.TargetTransform.Position + new vec3(0, 1, 0);
            this.renderer.WorldPosition = this.TargetRenderer.Position + new vec3(0, 0.3f, 0);
        }

    }
}
