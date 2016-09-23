namespace CSharpGL.Demos
{
    internal class UpdateBillboardPosition : Script
    {
        private IModelSpace renderer;
        public IModelSpace TargetRenderer { get; set; }

        public UpdateBillboardPosition(SceneObject obj = null)
            : this(null, obj) { }

        public UpdateBillboardPosition(IModelSpace targetRenderer, SceneObject obj = null)
            : base(obj)
        {
            this.TargetRenderer = targetRenderer;
        }

        protected override void DoUpdate()
        {
            if (this.renderer == null)
            {
                this.renderer = this.BindingObject.Renderer as IModelSpace;
            }
            //this.transform.Position = this.TargetTransform.Position + new vec3(0, 1, 0);
            this.renderer.WorldPosition = this.TargetRenderer.WorldPosition + new vec3(0, 0.3f, 0);
        }
    }
}