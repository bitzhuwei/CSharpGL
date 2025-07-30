﻿using System;
using System.Diagnostics;

namespace CSharpGL {
    /// <summary>
    /// Quaternion
    /// </summary>
    public struct Quaternion {
        /// <summary>
        ///
        /// </summary>
        public float w;

        /// <summary>
        ///
        /// </summary>
        public float x;

        /// <summary>
        ///
        /// </summary>
        public float y;

        /// <summary>
        ///
        /// </summary>
        public float z;

        /// <summary>
        /// Quaternion
        /// </summary>
        /// <param name="w"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Quaternion(float w, float x, float y, float z) {
            this.w = w;
            if (x == 0.0f && y == 0.0f && z == 0.0f) {
                Debug.WriteLine("Quaternion with axis not well defined!");
            }
            this.x = x; this.y = y; this.z = z;
        }
        /// <summary>
        /// Quaternion
        /// </summary>
        /// <param name="xyzw"></param>
        public Quaternion(float[] xyzw) {
            this.w = xyzw[3];
            if (x == 0.0f && y == 0.0f && z == 0.0f) {
                Debug.WriteLine("Quaternion with axis not well defined!");
            }
            this.x = xyzw[0]; this.y = xyzw[1]; this.z = xyzw[2];
        }

        /// <summary>
        /// Quaternion from a rotation angle and axis.
        /// </summary>
        /// <param name="angleDegree"></param>
        /// <param name="axis"></param>
        public Quaternion(float angleDegree, vec3 axis) {
            if (axis.x == 0.0f && axis.y == 0.0f && axis.z == 0.0f) {
                Debug.WriteLine("Quaternion with axis not well defined!");
            }

            vec3 normalized = axis.normalize();
            double radian = angleDegree * Math.PI / 180.0;
            double halfRadian = radian / 2.0;
            this.w = (float)Math.Cos(halfRadian);
            float sin = (float)Math.Sin(halfRadian);
            this.x = sin * normalized.x;
            this.y = sin * normalized.y;
            this.z = sin * normalized.z;
        }

        /// <summary>
        /// Transform this quaternion to equivalent matrix.
        /// </summary>
        /// <returns></returns>
        public mat4 ToMat4() {
            float x = this.x;
            float y = this.y;
            float z = this.z;
            float w = this.w;

            float xx = x * x;
            float xy = x * y;
            float xz = x * z;
            float xw = x * w;
            float yy = y * y;
            float yz = y * z;
            float yw = y * w;
            float zz = z * z;
            float zw = z * w;
            vec4 col0 = new vec4(1 - 2 * (yy + zz), 2 * (xy - zw), 2 * (xz + yw), 0);
            vec4 col1 = new vec4(2 * (xy + zw), 1 - 2 * (xx + zz), 2 * (yz - xw), 0);
            vec4 col2 = new vec4(2 * (xz - yw), 2 * (yz + xw), 1 - 2 * (xx + yy), 0);
            vec4 col3 = new vec4(0, 0, 0, 1);

            return new mat4(col0, col1, col2, col3);
        }

        /// <summary>
        /// Transform this quaternion to equivalent matrix.
        /// </summary>
        /// <returns></returns>
        public mat3 ToRotationMatrix() {
            float x = this.x;
            float y = this.y;
            float z = this.z;
            float w = this.w;

            float xx = x * x;
            float xy = x * y;
            float xz = x * z;
            float xw = x * w;
            float yy = y * y;
            float yz = y * z;
            float yw = y * w;
            float zz = z * z;
            float zw = z * w;
            vec3 col0 = new vec3(1 - 2 * (yy + zz), 2 * (xy - zw), 2 * (xz + yw));
            vec3 col1 = new vec3(2 * (xy + zw), 1 - 2 * (xx + zz), 2 * (yz - xw));
            vec3 col2 = new vec3(2 * (xz - yw), 2 * (yz + xw), 1 - 2 * (xx + yy));

            return new mat3(col0, col1, col2);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="angleInDegree"></param>
        /// <param name="axis"></param>
        public void Parse(out float angleInDegree, out vec3 axis) {
            angleInDegree = (float)(Math.Acos(w) * 2 * 180.0 / Math.PI);
            axis = (new vec3(x, y, z)).normalize();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="right"></param>
        /// <returns></returns>
        public float dot(Quaternion right) {
            return (this.w * right.w + this.x * right.x + this.y * right.y + this.z * right.z);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("{0}°, <{1}, {2}, {3}>", Math.Acos(w) * 2 * 180.0f / Math.PI, x, y, z);
        }
    }
}