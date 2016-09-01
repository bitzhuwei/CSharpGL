using System;

namespace CSharpGL.SceneEditor.Scripts
{
    internal class Satellite : Script
    {
        private IModelSpace planetTransform;
        private double currentAngle;
        private BuildInRenderer renderer;

        /// <summary>
        /// 公转半径
        /// </summary>
        public double RevolutionRadius { get; set; }

        /// <summary>
        /// 公转周期
        /// </summary>
        public double RevolutionPeriod { get; set; }

        protected override void DoUpdate(double elapsedTime)
        {
            if (this.renderer == null)
            {
                this.renderer = this.BindingObject.Renderer as BuildInRenderer;
                this.planetTransform = this.BindingObject.Parent.Renderer as IModelSpace;
            }

            double deltaAngle = elapsedTime * Math.PI * 2 / this.RevolutionPeriod;
            double newAngle = this.currentAngle + deltaAngle;
            var position = new vec3(
                (float)(this.RevolutionRadius * Math.Cos(newAngle)),
                0,
                (float)(this.RevolutionRadius * Math.Sin(newAngle)))
                + this.planetTransform.WorldPosition;
            this.currentAngle = newAngle;

            this.renderer.WorldPosition = position;
        }
    }
}