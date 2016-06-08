using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.EarthMoonSystem
{
    class CameraTracer : ITimeElapse
    {

        private ICamera camera;
        private Earth earth;
        private Sun sun;

        public CameraTracer(ICamera camera, Earth earth, Sun sun)
        {
            this.camera = camera;
            this.earth = earth;
            this.sun = sun;
        }

        double totalInterval = 0.0;

        private double angleSpeed = 0.01 / 1000;//10°每毫秒

        public double AngleSpeed
        {
            get { return angleSpeed; }
            set { angleSpeed = value; }
        }

        public void Elapse(double interval)
        {
            float earthRadius = this.earth.GetRadius();
            vec3 position = this.earth.GetPosition() - this.sun.GetPosition();
            position *= (1.0f + (earthRadius *5 / position.Magnitude()));
            totalInterval += interval;
            //vec3 satellite = new vec3(
            //    (float)(earthRadius * 2 * Math.Cos(this.AngleSpeed * Math.PI / 180.0 * totalInterval)),
            //    earthRadius,
            //    (float)(earthRadius * 2 * Math.Sin(this.AngleSpeed * Math.PI / 180.0 * totalInterval))
            //    );
            vec3 satellite = camera.UpVector.cross(position).normalize() * earthRadius*2;

            this.camera.Position = position + satellite;

            if (totalInterval > Math.PI * 2)
            {
                totalInterval -= (Math.PI * 2);
            }
        }
    }
}
