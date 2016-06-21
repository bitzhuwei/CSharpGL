using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimLab
{
    public struct Rectangle3D
    {
        private vec3 min;
        private vec3 max;

        public Rectangle3D(vec3 min, vec3 max)
        {
            vec3 realMin, realMax;
            MakesureMinMax(min, max, out realMin, out realMax);
            this.min = realMin;
            this.max = realMax;
        }

        private static void MakesureMinMax(vec3 possibleMin, vec3 possibleMax, out vec3 realMin, out vec3 realMax)
        {
            realMin = new vec3();
            realMax = new vec3();
            realMin = possibleMin;
            realMax = possibleMax;

            if (possibleMin.x > possibleMax.x)
            {
                realMin.x = possibleMax.x;
                realMax.x = possibleMin.x;
            }
            if (possibleMin.y > possibleMax.y)
            {
                realMin.y = possibleMax.y;
                realMax.y = possibleMin.y;
            }
            if (possibleMin.z > possibleMax.z)
            {
                realMin.z = possibleMax.z;
                realMax.z = possibleMin.z;
            }
        }

        public vec3 Min
        {
            get { return this.min; }
        }

        public vec3 Max
        {
            get { return this.max; }
        }

        public vec3 Location
        {
            get
            {
                return this.min;
            }
        }

        /// <summary>
        /// Rect3D 的中心点
        /// </summary>
        public vec3 Center
        {
            get
            {
                vec3 distanceVector = this.max - this.min;
                double length = distanceVector.length();
                vec3 normVector = distanceVector.normalize();
                float half = (float)(length / 2.0);
                vec3 center = this.min + normVector * half;
                return center;
            }
        }

        public override string ToString()
        {
            return String.Format("({0}),({1})", this.Min, this.Max);
        }

        public void Union(vec3 point)
        {
            if (this.min.x > point.x)
                this.min.x = point.x;
            if (this.min.y > point.y)
                this.min.y = point.y;
            if (this.min.z > point.z)
                this.min.z = point.z;
            if (this.max.x < point.x)
                this.max.x = point.x;
            if (this.max.y < point.y)
                this.max.y = point.y;
            if (this.max.z < point.z)
                this.max.z = point.z;
        }

        public void Union(Rectangle3D rect3D)
        {
            this.Union(rect3D.min);
            this.Union(rect3D.max);
        }

    }
}
