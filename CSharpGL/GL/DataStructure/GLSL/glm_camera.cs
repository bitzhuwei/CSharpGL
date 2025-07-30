﻿using System;
using System.Diagnostics;

namespace CSharpGL {
    public static partial class glm {
        /// <summary>
        /// Creates a frustrum projection matrix.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <param name="bottom">The bottom.</param>
        /// <param name="top">The top.</param>
        /// <param name="nearVal">The near val.</param>
        /// <param name="farVal">The far val.</param>
        /// <returns></returns>
        public static mat4 frustum(float left, float right, float bottom, float top, float nearVal, float farVal) {
            var result = mat4.identity();

            result[0, 0] = (2.0f * nearVal) / (right - left);
            result[1, 1] = (2.0f * nearVal) / (top - bottom);
            result[2, 0] = (right + left) / (right - left);
            result[2, 1] = (top + bottom) / (top - bottom);
            result[2, 2] = -(farVal + nearVal) / (farVal - nearVal);
            result[2, 3] = -1.0f;
            result[3, 2] = -(2.0f * farVal * nearVal) / (farVal - nearVal);
            result[3, 3] = 0.0f;

            return result;
        }

        /// <summary>
        /// Creates a matrix for a symmetric perspective-view frustum with far plane at infinite.
        /// </summary>
        /// <param name="fovy">The fovy.</param>
        /// <param name="aspect">The aspect.</param>
        /// <param name="zNear">The z near.</param>
        /// <returns></returns>
        public static mat4 infinitePerspective(float fovy, float aspect, float zNear) {
            float range = tan(fovy / (2f)) * zNear;

            float left = -range * aspect;
            float right = range * aspect;
            float bottom = -range;
            float top = range;

            var result = new mat4(0);
            result[0, 0] = ((2f) * zNear) / (right - left);
            result[1, 1] = ((2f) * zNear) / (top - bottom);
            result[2, 2] = -(1f);
            result[2, 3] = -(1f);
            result[3, 2] = -(2f) * zNear;
            return result;
        }

        /// <summary>
        /// Build a look at view matrix.
        /// transform object's coordinate from world's space to camera's space.
        /// </summary>
        /// <param name="eye">The eye.</param>
        /// <param name="center">The center.</param>
        /// <param name="up">Up.</param>
        /// <returns></returns>
        public static mat4 lookAt(vec3 eye, vec3 center, vec3 up) {
            // camera's back in world space coordinate system
            vec3 back = (eye - center).normalize();
            // camera's right in world space coordinate system
            vec3 right = up.cross(back).normalize();
            // camera's up in world space coordinate system
            vec3 standardUp = back.cross(right);

            mat4 viewMat = new mat4(1);
            viewMat.col0.x = right.x;
            viewMat.col1.x = right.y;
            viewMat.col2.x = right.z;
            viewMat.col0.y = standardUp.x;
            viewMat.col1.y = standardUp.y;
            viewMat.col2.y = standardUp.z;
            viewMat.col0.z = back.x;
            viewMat.col1.z = back.y;
            viewMat.col2.z = back.z;

            // Translation in world space coordinate system
            viewMat.col3.x = -eye.dot(right);
            viewMat.col3.y = -eye.dot(standardUp);
            viewMat.col3.z = -eye.dot(back);

            return viewMat;
        }

        /// <summary>
        /// Creates a matrix for an orthographic parallel viewing volume.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <param name="bottom">The bottom.</param>
        /// <param name="top">The top.</param>
        /// <param name="zNear">The z near.</param>
        /// <param name="zFar">The z far.</param>
        /// <returns></returns>
        public static mat4 ortho(float left, float right, float bottom, float top, float zNear, float zFar) {
            var result = mat4.identity();
            result[0, 0] = (2f) / (right - left);
            result[1, 1] = (2f) / (top - bottom);
            result[2, 2] = -(2f) / (zFar - zNear);
            result[3, 0] = -(right + left) / (right - left);
            result[3, 1] = -(top + bottom) / (top - bottom);
            result[3, 2] = -(zFar + zNear) / (zFar - zNear);
            return result;
        }

        /// <summary>
        /// Creates a matrix for projecting two-dimensional coordinates onto the screen.
        /// <para>this equals ortho(left, right, bottom, top, -1, 1)</para>
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <param name="bottom">The bottom.</param>
        /// <param name="top">The top.</param>
        /// <returns></returns>
        public static mat4 ortho(float left, float right, float bottom, float top) {
            var result = mat4.identity();
            result[0, 0] = (2f) / (right - left);
            result[1, 1] = (2f) / (top - bottom);
            result[2, 2] = -(1f);
            result[3, 0] = -(right + left) / (right - left);
            result[3, 1] = -(top + bottom) / (top - bottom);
            return result;
        }

        /// <summary>
        /// Creates a perspective transformation matrix.
        /// </summary>
        /// <param name="fovy">The field of view angle, in radians.</param>
        /// <param name="aspect">The aspect ratio.</param>
        /// <param name="zNear">The near depth clipping plane.</param>
        /// <param name="zFar">The far depth clipping plane.</param>
        /// <returns>A <see cref="mat4"/> that contains the projection matrix for the perspective transformation.</returns>
        public static mat4 perspective(float fovy, float aspect, float zNear, float zFar) {
            float tangent = (float)Math.Tan(fovy / 2.0f);
            float height = zNear * tangent;
            float width = height * aspect;

            float left = -width, right = width, bottom = -height, top = height, near = zNear, far = zFar;

            mat4 result = frustum(left, right, bottom, top, near, far);

            return result;
        }

        /// <summary>
        /// Builds a perspective projection matrix based on a field of view.
        /// </summary>
        /// <param name="fov">The fov (in radians).</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="zNear">The z near.</param>
        /// <param name="zFar">The z far.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static mat4 perspectiveFov(float fov, float width, float height, float zNear, float zFar) {
            if (width <= 0 || height <= 0 || fov <= 0)
                throw new ArgumentOutOfRangeException();

            var rad = fov;

            var h = glm.cos((0.5f) * rad) / glm.sin((0.5f) * rad);
            var w = h * height / width;

            var result = new mat4(0);
            result[0, 0] = w;
            result[1, 1] = h;
            result[2, 2] = -(zFar + zNear) / (zFar - zNear);
            result[2, 3] = -(1f);
            result[3, 2] = -((2f) * zFar * zNear) / (zFar - zNear);
            return result;
        }

        /// <summary>
        /// Define a picking region.
        /// </summary>
        /// <param name="center">The center.</param>
        /// <param name="delta">The delta.</param>
        /// <param name="viewport">The viewport.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static mat4 pickMatrix(ivec2 center, ivec2 delta, ivec4 viewport) {
            if (delta.x <= 0 || delta.y <= 0)
                throw new ArgumentOutOfRangeException();
            var Result = new mat4(1.0f);

            if (!(delta.x > (0f) && delta.y > (0f)))
                return Result; // Error

            vec3 Temp = new vec3(
                ((viewport[2]) - (2f) * (center.x - (viewport[0]))) / delta.x,
                ((viewport[3]) - (2f) * (center.y - (viewport[1]))) / delta.y,
                (0f));

            // Translate and scale the picked region to the entire window
            Result = translate(Temp);
            return Result * scale(new vec3((float)(viewport[2]) / delta.x, (float)(viewport[3]) / delta.y, (1)));
        }

        /// <summary>
        /// Map the specified object coordinates (obj.x, obj.y, obj.z) into window coordinates.
        /// </summary>
        /// <param name="modelPosition">The object.</param>
        /// <param name="view">The view.</param>
        /// <param name="proj">The proj.</param>
        /// <param name="viewport">The viewport.</param>
        /// <returns></returns>
        public static vec3 project(vec3 modelPosition, mat4 view, mat4 proj, vec4 viewport) {
            vec4 tmp = new vec4(modelPosition, (1f));
            tmp = view * tmp;
            tmp = proj * tmp;// this is gl_Position

            tmp /= tmp.w;// after this, tmp is normalized device coordinate.

            tmp = tmp * 0.5f + new vec4(0.5f, 0.5f, 0.5f, 0.5f);
            tmp[0] = tmp[0] * viewport[2] + viewport[0];
            tmp[1] = tmp[1] * viewport[3] + viewport[1];// after this, tmp is window coordinate.

            return new vec3(tmp.x, tmp.y, tmp.z);
        }
        ///// <summary>
        ///// Builds a rotation 4 * 4 matrix created from an axis vector and an angle.
        ///// </summary>
        ///// <param name="m">The m.</param>
        ///// <param name="angleDegree">Angle in Degree.</param>
        ///// <param name="v">The v.</param>
        ///// <returns></returns>
        //public static mat4 rotate(mat4 m, float angleDegree, float x, float y, float z) {
        //    return rotate(m, angleDegree, new vec3(x, y, z));
        //}
        public static mat4 rotate(float angle_x, float angle_y, float angle_z) {
            return rotate(angle_z, 0.0f, 0.0f, 1.0f)
                * rotate(angle_y, 0.0f, 1.0f, 0.0f)
                * rotate(angle_x, 1.0f, 0.0f, 0.0f);
        }
        public static mat4 rotate(float angleDegree, float x, float y, float z) {
            return rotate(angleDegree, new vec3(x, y, z));
        }
        public static mat4 rotate(float angleDegree, vec3 v) {
            float c = (float)Math.Cos(angleDegree * Math.PI / 180.0);
            float s = (float)Math.Sin(angleDegree * Math.PI / 180.0);

            vec3 axis = v.normalize();
            vec3 temp = (1.0f - c) * axis;

            mat4 rotate_ = mat4.identity();
            rotate_[0, 0] = c + temp[0] * axis[0];
            rotate_[0, 1] = 0 + temp[0] * axis[1] + s * axis[2];
            rotate_[0, 2] = 0 + temp[0] * axis[2] - s * axis[1];

            rotate_[1, 0] = 0 + temp[1] * axis[0] - s * axis[2];
            rotate_[1, 1] = c + temp[1] * axis[1];
            rotate_[1, 2] = 0 + temp[1] * axis[2] + s * axis[0];

            rotate_[2, 0] = 0 + temp[2] * axis[0] + s * axis[1];
            rotate_[2, 1] = 0 + temp[2] * axis[1] - s * axis[0];
            rotate_[2, 2] = c + temp[2] * axis[2];
            return rotate_;
        }
        ///// <summary>
        ///// Builds a rotation 4 * 4 matrix created from an axis vector and an angle.
        ///// </summary>
        ///// <param name="m">The m.</param>
        ///// <param name="angleDegree">Angle in Degree.</param>
        ///// <param name="v">The v.</param>
        ///// <returns></returns>
        //public static mat4 rotate(mat4 m, float angleDegree, vec3 v) {
        //    var rotate_ = rotate(angleDegree, v);
        //    //mat4 result = mat4.identity();
        //    //result[0] = m[0] * rotate[0][0] + m[1] * rotate[0][1] + m[2] * rotate[0][2];
        //    //result[1] = m[0] * rotate[1][0] + m[1] * rotate[1][1] + m[2] * rotate[1][2];
        //    //result[2] = m[0] * rotate[2][0] + m[1] * rotate[2][1] + m[2] * rotate[2][2];
        //    //result[3] = m[3];
        //    //{
        //    //    var multiply = rotate * m;
        //    //    for (int i = 0; i < 4; i++) {
        //    //        var left = multiply[i]; var right = result[i];
        //    //        if (Math.Abs(left.x - right.x) > 0.9) { Console.WriteLine("error"); }
        //    //        if (Math.Abs(left.y - right.y) > 0.9) { Console.WriteLine("error"); }
        //    //        if (Math.Abs(left.z - right.z) > 0.9) { Console.WriteLine("error"); }
        //    //        if (Math.Abs(left.w - right.w) > 0.9) { Console.WriteLine("error"); }
        //    //    }
        //    //}
        //    mat4 result = m * rotate_;
        //    return result;
        //}

        public static mat4 scale(float factor) {
            return scale(factor, factor, factor);
        }
        /// <summary>
        /// Applies a scale transformation to matrix <paramref name="m"/> by vector <paramref name="v"/>.
        /// </summary>
        /// <param name="m">The matrix to transform.</param>
        /// <param name="v">The vector to scale by.</param>
        /// <returns><paramref name="m"/> scaled by <paramref name="v"/>.</returns>
        public static mat4 scale(float x, float y, float z) {
            return scale(new vec3(x, y, z));
        }
        public static mat4 scale(vec3 v) {
            var scale_ = new mat4(
                col0: new vec4(v.x, 0, 0, 0),
                col1: new vec4(0, v.y, 0, 0),
                col2: new vec4(0, 0, v.z, 0),
                col3: new vec4(0, 0, 0, 1)
                );
            return scale_;
        }

        ///// <summary>
        ///// Applies a scale transformation to matrix <paramref name="m"/> by vector <paramref name="v"/>.
        ///// </summary>
        ///// <param name="m">The matrix to transform.</param>
        ///// <param name="v">The vector to scale by.</param>
        ///// <returns><paramref name="m"/> scaled by <paramref name="v"/>.</returns>
        //public static mat4 scale(mat4 m, float factor) {
        //    return scale(m, new vec3(factor, factor, factor));
        //}

        ///// <summary>
        ///// Applies a scale transformation to matrix <paramref name="m"/> by vector <paramref name="v"/>.
        ///// </summary>
        ///// <param name="m">The matrix to transform.</param>
        ///// <param name="v">The vector to scale by.</param>
        ///// <returns><paramref name="m"/> scaled by <paramref name="v"/>.</returns>
        //public static mat4 scale(mat4 m, float x, float y, float z) {
        //    return scale(m, new vec3(x, y, z));
        //}
        ///// <summary>
        ///// Applies a scale transformation to matrix <paramref name="m"/> by vector <paramref name="v"/>.
        ///// </summary>
        ///// <param name="m">The matrix to transform.</param>
        ///// <param name="v">The vector to scale by.</param>
        ///// <returns><paramref name="m"/> scaled by <paramref name="v"/>.</returns>
        //public static mat4 scale(mat4 m, vec3 v) {
        //    var scale_ = new mat4(
        //        col0: new vec4(v.x, 0, 0, 0),
        //        col1: new vec4(0, v.y, 0, 0),
        //        col2: new vec4(0, 0, v.z, 0),
        //        col3: new vec4(0, 0, 0, 1)
        //        );
        //    mat4 result = scale_ * m;
        //    //result[0] = m[0] * v[0];
        //    //result[1] = m[1] * v[1];
        //    //result[2] = m[2] * v[2];
        //    //result[3] = m[3];
        //    return result;
        //}

        public static mat4 translate(float x, float y, float z) {
            return translate(new vec3(x, y, z));
        }
        /// <summary>
        /// Applies a translation transformation to matrix <paramref name="m"/> by vector <paramref name="v"/>.
        /// </summary>
        /// <param name="m">The matrix to transform.</param>
        /// <param name="v">The vector to translate by.</param>
        /// <returns><paramref name="m"/> translated by <paramref name="v"/>.</returns>
        public static mat4 translate(vec3 v) {
            var result = mat4.identity(); result.col3 = new vec4(v, 1);
            return result;
        }

        ///// <summary>
        ///// Applies a translation transformation to matrix <paramref name="m"/> by vector <paramref name="v"/>.
        ///// </summary>
        ///// <param name="m">The matrix to transform.</param>
        ///// <param name="v">The vector to translate by.</param>
        ///// <returns><paramref name="m"/> translated by <paramref name="v"/>.</returns>
        //public static mat4 translate(mat4 m, vec3 v) {
        //    var translate_ = mat4.identity(); translate_.col3 = new vec4(v, 1);
        //    mat4 result = m * translate_;
        //    //{
        //    //    var another = m;
        //    //    another.col3 = m.col0 * v.x + m.col1 * v.y + m.col2 * v.z + m.col3;
        //    //    Debug.Assert(another == result);
        //    //}
        //    //{
        //    //    var another = m;
        //    //    another.col3 = m.col0 * v.x + m.col1 * v.y + m.col2 * v.z + m.col3;
        //    //    var reverse = m * translate_;
        //    //    Debug.Assert(another == reverse);
        //    //}
        //    return result;
        //}

        ///// <summary>
        ///// Applies a translation transformation to matrix <paramref name="m"/> by vector <paramref name="v"/>.
        ///// </summary>
        ///// <param name="m">The matrix to transform.</param>
        ///// <param name="x">The vector.x to translate by.</param>
        ///// <param name="y">The vector.y to translate by.</param>
        ///// <param name="z">The vector.z to translate by.</param>
        ///// <returns><paramref name="m"/> translated by <paramref name="v"/>.</returns>
        //public static mat4 translate(mat4 m, float x, float y, float z) {
        //    //mat4 result = m;
        //    //result.col3 = m.col0 * x + m.col1 * y + m.col2 * z + m.col3;
        //    //return result;
        //    return translate(m, new vec3(x, y, z));
        //}

        /// <summary>
        /// Creates a matrix for a symmetric perspective-view frustum with far plane
        /// at infinite for graphics hardware that doesn't support depth clamping.
        /// </summary>
        /// <param name="fovy">The fovy.</param>
        /// <param name="aspect">The aspect.</param>
        /// <param name="zNear">The z near.</param>
        /// <returns></returns>
        public static mat4 tweakedInfinitePerspective(float fovy, float aspect, float zNear) {
            float range = tan(fovy / (2)) * zNear;
            float left = -range * aspect;
            float right = range * aspect;
            float bottom = -range;
            float top = range;

            mat4 Result = new mat4((0f));
            Result[0, 0] = ((2) * zNear) / (right - left);
            Result[1, 1] = ((2) * zNear) / (top - bottom);
            Result[2, 2] = (0.0001f) - (1f);
            Result[2, 3] = (-1);
            Result[3, 2] = -((0.0001f) - (2)) * zNear;
            return Result;
        }

        /// <summary>
        /// Map the specified window coordinates (win.x, win.y, win.z) into object coordinates.
        /// </summary>
        /// <param name="windowPos">The win.</param>
        /// <param name="view">The view.</param>
        /// <param name="proj">The proj.</param>
        /// <param name="viewport">The viewport.</param>
        /// <returns></returns>
        public static vec3 unProject(vec3 windowPos, mat4 view, mat4 proj, vec4 viewport) {
            mat4 Inverse = glm.inverse(proj * view);

            vec4 tmp = new vec4(windowPos, (1f));
            tmp.x = (tmp.x - (viewport[0])) / (viewport[2]);
            tmp.y = (tmp.y - (viewport[1])) / (viewport[3]);
            tmp = tmp * (2f) - new vec4(1, 1, 1, 1);// after this, tmp is normalized device coordinate.

            vec4 obj = Inverse * tmp;
            obj /= obj.w;// after this, tmp is model coordinate.

            return new vec3(obj);
        }
    }
}