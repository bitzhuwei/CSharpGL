using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Helps in shadow mapping algorithm.
    /// </summary>
    public static class __LightToMatrixHelper
    {
        /// <summary>
        /// Helps in shadow mapping algorithm.
        /// </summary>
        /// <param name="light"></param>
        /// <returns></returns>
        public static mat4 GetProjectionMatrix(this LightBase light)
        {
            if (light is TSpotLight)
            {
                return GetProjectionMatrix(light as TSpotLight);
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

        private static mat4 GetProjectionMatrix(this TSpotLight light)
        {
            const double angle = 90.0 / 180.0 * Math.PI; // in radians
            const float aspectRatio = 1.0f;

            // TODO: how to get a precise projection?
            mat4 projection = glm.perspective((float)angle, aspectRatio, 0.1f, 50);

            return projection;
        }

        private static mat4 GetProjectionMatrix(this DirectionalLight light)
        {
            // TODO: try this one.
            //var viewport = new int[4];
            //GL.Instance.GetIntegerv(GL.GL_VIEWPORT, viewport);
            //int width = viewport[2], height = viewport[3];
            //mat4 projection = glm.ortho(-width / 2.0f, width / 2.0f, -height / 2.0f, height / 2.0f);
            const int length = 10;
            mat4 projection = glm.ortho(-length, length, -length, length, -length, 0);//length * length);
            return projection;
        }

        private static mat4 GetProjectionMatrix(this SpotLight light)
        {
            var angle = Math.Acos(light.CutOff) * 2; // in radians
            const float aspectRatio = 1.0f;

            // TODO: how to get a precise projection?
            mat4 projection = glm.perspective((float)angle, aspectRatio, 0.1f, 50);

            return projection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="light"></param>
        /// <returns></returns>
        public static mat4 GetViewMatrix(this LightBase light)
        {
            if (light is TSpotLight)
            {
                return GetViewMatrix(light as TSpotLight);
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

        private static mat4 GetViewMatrix(this TSpotLight light)
        {
            vec3 direction, up;
            switch (light.Direction)
            {
                case TSpotLightDirection.X:
                    direction = new vec3(-1, 0, 0);
                    up = new vec3(0, 1, 0);
                    break;
                case TSpotLightDirection.NX:
                    direction = new vec3(1, 0, 0);
                    up = new vec3(0, 1, 0);
                    break;
                case TSpotLightDirection.Y:
                    direction = new vec3(0, -1, 0);
                    up = new vec3(0, 0, 1);
                    break;
                case TSpotLightDirection.NY:
                    direction = new vec3(0, 1, 0);
                    up = new vec3(0, 0, 1);
                    break;
                case TSpotLightDirection.Z:
                    direction = new vec3(0, 0, -1);
                    up = new vec3(0, 1, 0);
                    break;
                case TSpotLightDirection.NZ:
                    direction = new vec3(0, 0, 1);
                    up = new vec3(0, 1, 0);
                    break;
                default:
                    throw new NotDealWithNewEnumItemException(typeof(TSpotLightDirection));
            }

            mat4 view = glm.lookAt(light.Position, light.Position - direction, up);
            return view;
        }

        private static mat4 GetViewMatrix(this DirectionalLight light)
        {
            vec3 up = new vec3(0, 1, 0);
            mat4 view = glm.lookAt(new vec3(), -(light.Direction.normalize()), up);
            return view;
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
