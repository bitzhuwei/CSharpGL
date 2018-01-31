using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Spot light.
    /// </summary>
    sealed class TSpotLight : LightBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="position">light's position.</param>
        /// <param name="direction">Direction to the light's position.</param>
        /// <param name="attenuation"></param>
        public TSpotLight(vec3 position, TSpotLightDirection direction, Attenuation attenuation = null)
            : base(attenuation == null ? new Attenuation(1.0f, 0.0f, 0.0f) : attenuation)
        {
            this.Position = position;
            this.Direction = direction;
        }

        public TSpotLightDirection Direction { get; set; }
    }

    // 0: PointLight;  1: DirectionalLight; 
    // 2: SpotLight;
    // 3: XSpotLight;  4: NXSpotLight;
    // 5: YSpotLight;  6: NYSpotLight;
    // 7: ZSpotLight;  8: NZSpotLight;
    enum TSpotLightDirection
    {
        X = 3, NX = 4, Y = 5, NY = 6, Z = 7, NZ = 8,
    }

    internal static class TSpotLightDirectionHelper
    {
        public static vec3 ToVec3(this TSpotLightDirection direction)
        {
            vec3 result;
            switch (direction)
            {
                case TSpotLightDirection.X:
                    result = new vec3(-1, 0, 0);
                    break;
                case TSpotLightDirection.NX:
                    result = new vec3(1, 0, 0);
                    break;
                case TSpotLightDirection.Y:
                    result = new vec3(0, -1, 0);
                    break;
                case TSpotLightDirection.NY:
                    result = new vec3(0, 1, 0);
                    break;
                case TSpotLightDirection.Z:
                    result = new vec3(0, 0, -1);
                    break;
                case TSpotLightDirection.NZ:
                    result = new vec3(0, 0, 1);
                    break;
                default:
                    throw new NotDealWithNewEnumItemException(typeof(TSpotLightDirection));
            }

            return result;
        }
    }
}
