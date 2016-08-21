using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GridViewer
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

        public float SizeX
        {
            get
            {
                return this.max.x - this.min.x;
            }
        }

        public float SizeY
        {
            get
            {
                return this.max.y - this.min.y;
            }
        }

        public float SizeZ
        {
            get
            {
                return this.max.z - this.min.z;
            }
        }

        /// <summary>
        /// Rect3D 的中心点
        /// </summary>
        public vec3 Center
        {
            get
            {
                return (max / 2 + min / 2);
            }
        }

        public override string ToString()
        {
            return String.Format("min:{0}, max:{1}", this.min, this.max);
        }

        public Rectangle3D Union(vec3 point)
        {
            var result = new Rectangle3D(this.min, this.max);

            point.UpdateMax(ref result.max);
            point.UpdateMin(ref result.min);
            //if (result.min.x > point.x) { result.min.x = point.x; }
            //if (result.min.y > point.y) { result.min.y = point.y; }
            //if (result.min.z > point.z) { result.min.z = point.z; }
            //if (result.max.x < point.x) { result.max.x = point.x; }
            //if (result.max.y < point.y) { result.max.y = point.y; }
            //if (result.max.z < point.z) { result.max.z = point.z; }

            return result;
        }

        public Rectangle3D Union(Rectangle3D rect3D)
        {
            var result = new Rectangle3D(this.min, this.max);
            rect3D.min.UpdateMin(ref result.min);
            rect3D.max.UpdateMax(ref result.max);

            return result;
        }

    }
}
