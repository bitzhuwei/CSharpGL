using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL.SceneEditor.Scripts
{
    class Satellite : ScriptComponent
    {

        private TransformScript transform;
        private TransformScript planetTransform;
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

        protected override void DoInitialize()
        {
            {
                this.transform = this.BindingObject.GetScript<TransformScript>();
                this.planetTransform = this.BindingObject.Parent.GetScript<TransformScript>(); ;
            }
            {
                this.renderer = this.BindingObject.Renderer as BuildInRenderer;
            }
        }

        protected override void DoUpdate(double elapsedTime)
        {
            double deltaAngle = elapsedTime * Math.PI * 2 / this.RevolutionPeriod;
            double newAngle = this.currentAngle + deltaAngle;
            this.transform.Position = new vec3(
                (float)(this.RevolutionRadius * Math.Cos(newAngle)),
                0,
                (float)(this.RevolutionRadius * Math.Sin(newAngle)))
                + this.planetTransform.Position;
            this.currentAngle = newAngle;

            this.renderer.ModelMatrix = this.transform.GetModelMatrix();
        }

    }
}
