namespace CSharpGL.Demos
{
    /// <summary>
    /// Manipulates renderer's rotation state with arcball.
    /// </summary>
    internal class ArcballScript : Script
    {
        private ArcBallManipulater arcballManipulater;

        /// <summary>
        /// Manipulates renderer's rotation state with arcball.
        /// </summary>
        /// <param name="arcballManipulater"></param>
        public ArcballScript(ArcBallManipulater arcballManipulater)
        {
            this.arcballManipulater = arcballManipulater;
        }

        protected override void DoUpdate()
        {
            mat4 model = this.arcballManipulater.GetRotationMatrix();
            Quaternion quaternion = model.ToQuaternion();
            float angleDegree;
            vec3 axis;
            quaternion.Parse(out angleDegree, out axis);

            RendererBase renderer = this.BindingObject.Renderer;
            renderer.RotationAngleDegree = angleDegree;
            renderer.SetRotationAxis(axis);
        }
    }
}