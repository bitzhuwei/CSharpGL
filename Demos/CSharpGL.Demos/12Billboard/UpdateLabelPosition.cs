using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    class UpdateLabelPosition : Script
    {
        private LabelRenderer renderer;
        public IModelSpace TargetRenderer { get; set; }

        public UpdateLabelPosition(SceneObject obj = null)
            : this(null, obj) { }

        public UpdateLabelPosition(IModelSpace targetRenderer, SceneObject obj = null)
            : base(obj)
        {
            this.TargetRenderer = targetRenderer;
        }

        protected override void DoUpdate(double elapsedTime)
        {
            if (this.renderer == null)
            {
                this.renderer = this.BindingObject.Renderer as LabelRenderer;
            }

            //this.transform.Position = this.TargetTransform.Position + new vec3(0, 1, 0);
            vec3 worldPosition = this.TargetRenderer.OriginalWorldPosition + new vec3(0, 0.3f, 0);
            this.renderer.OriginalWorldPosition = worldPosition;
        }

    }
}
