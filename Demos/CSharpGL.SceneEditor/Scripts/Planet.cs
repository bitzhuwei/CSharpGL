using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL.SceneEditor.Scripts
{
    class Planet : ScriptComponent
    {

        private TransformComponent transform;
        private double currentAngle;

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
            this.transform = this.BindingObject.Transform;
        }

        protected override void DoUpdate(double elapsedTime)
        {
            double deltaAngle = elapsedTime * Math.PI * 2 / this.RevolutionPeriod;
            double newAngle = this.currentAngle + deltaAngle;
            this.transform.Position = new vec3(
                (float)(this.RevolutionRadius * Math.Cos(newAngle)),
                0,
                (float)(this.RevolutionRadius * Math.Sin(newAngle)));
            this.currentAngle = newAngle;
        }

    }
}
