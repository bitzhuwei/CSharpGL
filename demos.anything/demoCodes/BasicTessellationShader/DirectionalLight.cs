using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicTessellationShader {
    class DirectionalLight : BaseLight {
        public vec3 direction;

        public DirectionalLight() {
            this.direction = new vec3(0, 0, 0);
        }

        public struct StructDirectionalLight : IEquatable<StructDirectionalLight> {
            public vec3 Color;
            public float AmbientIntensity;
            public float DiffuseIntensity;
            public vec3 direciton;

            #region IEquatable<StructDirectionalLight> 成员

            public bool Equals(StructDirectionalLight other) {
                if (this.Color != other.Color) { return false; }
                if (this.AmbientIntensity != other.AmbientIntensity) { return false; }
                if (this.DiffuseIntensity != other.DiffuseIntensity) { return false; }
                if (this.direciton != other.direciton) { return false; }

                return true;
            }

            #endregion
        }

        public StructDirectionalLight ToStruct() {
            var result = new StructDirectionalLight();
            result.Color = this.Color;
            result.AmbientIntensity = this.AmbientIntensity;
            result.DiffuseIntensity = this.DiffuseIntensity;
            result.direciton = this.direction;

            return result;
        }
    }
}
