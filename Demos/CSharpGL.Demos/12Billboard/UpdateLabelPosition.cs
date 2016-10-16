namespace CSharpGL.Demos
{
    internal class UpdateLabelPosition : Script
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

        protected override void DoUpdate()
        {
            if (this.renderer == null)
            {
                this.renderer = this.BindingObject.Renderer as LabelRenderer;
            }

            //this.transform.Position = this.TargetTransform.Position + new vec3(0, 1, 0);
            vec3 worldPosition = this.TargetRenderer.WorldPosition + new vec3(0, 0.3f, 0);
            this.renderer.WorldPosition = worldPosition;
        }
    }
}