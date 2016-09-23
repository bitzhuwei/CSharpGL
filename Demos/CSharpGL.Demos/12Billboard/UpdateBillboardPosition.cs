namespace CSharpGL.Demos
{
    internal class UpdateBillboardPosition : Script
    {
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
            this.BindingObject.Renderer.WorldPosition = this.TargetRenderer.WorldPosition + new vec3(0, 0.3f, 0);
        }
    }
}