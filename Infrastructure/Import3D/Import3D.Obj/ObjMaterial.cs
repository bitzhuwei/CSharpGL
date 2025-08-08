namespace Import3D.Obj {
    public class ObjMaterial {
        public const string DEFAULT_MATERIAL = "DefaultMaterial";

        public readonly string materialName;

        //! Texture names
        public string? texture;
        public string? textureSpecular;
        public string? textureAmbient;
        public string? textureEmissive;
        public string? textureBump;
        public string? textureNormal;
        public string?[] textureReflection = new string[6];
        public string? textureSpecularity;
        public string? textureOpacity;
        public string? textureDisp;
        public string? textureRoughness;
        public string? textureMetallic;
        public string? textureSheen;
        public string? textureRMA;
        public enum TextureType {
            TextureDiffuseType = 0,
            TextureSpecularType,
            TextureAmbientType,
            TextureEmissiveType,
            TextureBumpType,
            TextureNormalType,
            TextureReflectionSphereType,
            TextureReflectionCubeTopType,
            TextureReflectionCubeBottomType,
            TextureReflectionCubeFrontType,
            TextureReflectionCubeBackType,
            TextureReflectionCubeLeftType,
            TextureReflectionCubeRightType,
            TextureSpecularityType,
            TextureOpacityType,
            TextureDispType,
            TextureRoughnessType,
            TextureMetallicType,
            TextureSheenType,
            TextureRMAType,
            TextureTypeCount
        }
        public bool[] clamp = new bool[(int)TextureType.TextureTypeCount];

        public vec3 ambient;
        public vec3 diffuse = new vec3(0.6f);
        public vec3 specular;
        public vec3 emissive;
        public float alpha = 1.0f;
        public float shineness;
        public int illumination_model = 1;
        /// <summary>
        /// Index of refraction
        /// </summary>
        public float ior = 1.0f;
        /// <summary>
        /// Transparency color
        /// </summary>
        public vec3 transparent = new vec3(1.0f, 1.0f, 1.0f);

        // PBR
        public float? roughness;
        public float? metallic;
        public vec3? sheen;
        public float? clearcoat_thickness;
        public float? clearcoat_roughness;
        public float anisotropy;
        public float bump_multiplier = 1.0f;

        public ObjMaterial() : this(DEFAULT_MATERIAL) { }

        public ObjMaterial(string name) {
            this.materialName = name;
        }
    }
}