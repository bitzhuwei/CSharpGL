using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public static class __LightToMatrixHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="light"></param>
        /// <returns></returns>
        public static mat4 GetProjectionMatrix(this LightBase light)
        {
            if (light is PointLight)
            {
                return GetProjectionMatrix(light as PointLight);
            }
            else if (light is DirectionalLight)
            {
                return GetProjectionMatrix(light as DirectionalLight);
            }
            else if (light is SpotLight)
            {
                return GetProjectionMatrix(light as SpotLight);
            }
            else
            {
                throw new System.Exception(string.Format("Not expected light type:[{0}].", light.GetType()));
            }
        }

        private static mat4 GetProjectionMatrix(this PointLight light)
        {

            throw new NotImplementedException();
        }

        private static mat4 GetProjectionMatrix(this DirectionalLight light)
        {

            throw new NotImplementedException();
        }

        private static mat4 GetProjectionMatrix(this SpotLight light)
        {
            var angle = Math.Acos(light.CutOff); // in radians
            const float aspectRatio = 1.0f;

            // TODO: how to get a precise projection?
            mat4 projection = glm.perspective((float)angle, aspectRatio, 1f, 500);

            return projection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="light"></param>
        /// <returns></returns>
        public static mat4 GetViewMatrix(this LightBase light)
        {
            if (light is PointLight)
            {
                return GetViewMatrix(light as PointLight);
            }
            else if (light is DirectionalLight)
            {
                return GetViewMatrix(light as DirectionalLight);
            }
            else if (light is SpotLight)
            {
                return GetViewMatrix(light as SpotLight);
            }
            else
            {
                throw new System.Exception(string.Format("Not expected light type:[{0}].", light.GetType()));
            }
        }

        private static mat4 GetViewMatrix(this PointLight light)
        {

            throw new NotImplementedException();
        }

        private static mat4 GetViewMatrix(this DirectionalLight light)
        {

            throw new NotImplementedException();
        }

        private static mat4 GetViewMatrix(this SpotLight light)
        {
            vec3 up = new vec3(0, 1, 0);
            //if(light.Direction.dot(up) < 0.01f)
            {
                //up = 
            }
            mat4 view = glm.lookAt(light.Position, light.Target, up);

            return view;
        }

    }
}
