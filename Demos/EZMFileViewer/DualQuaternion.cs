using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EZMFileViewer
{
    public struct DualQuaternion
    {
        public Quaternion ordinary;
        public Quaternion dual;

        public DualQuaternion(Quaternion q0, vec3 translate)
        {
            this.ordinary = q0;
            float w = -0.5f * (translate.x * q0.x + translate.y * q0.y + translate.z * q0.z);
            float x = 0.5f * (translate.x * q0.w + translate.y * q0.z - translate.z * q0.y);
            float y = 0.5f * (-translate.x * q0.z + translate.y * q0.w + translate.z * q0.x);
            float z = 0.5f * (translate.x * q0.y - translate.y * q0.x + translate.z * q0.w);
            this.dual = new Quaternion(w, x, y, z);
        }

        /// <summary>
        /// converts the dual quaternion to a matrix.
        /// </summary>
        /// <returns></returns>
        public mat4 UDQToMatrix()
        {
            float len2 = ordinary.dot(ordinary);
            float w = ordinary.w, x = ordinary.x, y = ordinary.y, z = ordinary.z;
            float t0 = dual.w, t1 = dual.x, t2 = dual.y, t3 = dual.z;
            vec4 col0 = new vec4(w * w + x * x - y * y - z * z,
                2 * x * y + 2 * w * z,
                2 * x * z - 2 * w * y,
                0) / len2;
            vec4 col1 = new vec4(2 * x * y - 2 * w * z,
                w * w + y * y - x * x - z * z,
                2 * y * z + 2 * w * x,
                0) / len2;
            vec4 col2 = new vec4(2 * x * z + 2 * w * y,
                2 * y * z - 2 * w * x,
                w * w + z * z - x * x - y * y,
                0) / len2;
            vec4 col3 = new vec4(-2 * t0 * x + 2 * w * t1 - 2 * t2 * z + 2 * y * t3,
                -2 * t0 * y + 2 * t1 * z - 2 * x * t3 + 2 * w * t2,
                -2 * t0 * z + 2 * x * t2 + 2 * w * t3 - 2 * t1 * y,
                len2) / len2;
            mat4 m = new mat4(col0, col1, col2, col3);

            return m;
        }
    }
}
