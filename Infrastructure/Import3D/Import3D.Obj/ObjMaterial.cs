

namespace Import3D.Obj {
    public class ObjMaterial {
        public const string DEFAULT_MATERIAL = "DefaultMaterial";

        public readonly string materialName;

        // Material specific token (case insensitive compare)
        private const string DiffuseTexture = "map_Kd";
        private const string AmbientTexture = "map_Ka";
        private const string SpecularTexture = "map_Ks";
        private const string OpacityTexture = "map_d";
        private const string EmissiveTexture1 = "map_emissive";
        private const string EmissiveTexture2 = "map_Ke";
        private const string BumpTexture1 = "map_bump";
        private const string BumpTexture2 = "bump";
        private const string NormalTextureV1 = "map_Kn";
        private const string NormalTextureV2 = "norm";
        private const string ReflectionTexture = "refl";
        private const string DisplacementTexture1 = "map_disp";
        private const string DisplacementTexture2 = "disp";
        private const string SpecularityTexture = "map_ns";
        private const string RoughnessTexture = "map_Pr";
        private const string MetallicTexture = "map_Pm";
        private const string SheenTexture = "map_Ps";
        private const string RMATexture = "map_Ps";
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

        internal TextureType GetClampIndex(string line) {
            var clampIndex = TextureType.TextureTypeCount;
            if (false) { }
            else if (line.StartsWith(DiffuseTexture)) {
                // Diffuse texture
                clampIndex = ObjMaterial.TextureType.TextureDiffuseType;
            }
            else if (line.StartsWith(AmbientTexture)) {
                // Ambient texture
                clampIndex = ObjMaterial.TextureType.TextureAmbientType;
            }
            else if (line.StartsWith(SpecularTexture)) {
                // Specular texture
                clampIndex = ObjMaterial.TextureType.TextureSpecularType;
            }
            else if (line.StartsWith(DisplacementTexture1) || line.StartsWith(DisplacementTexture2)) {
                // Displacement texture
                clampIndex = ObjMaterial.TextureType.TextureDispType;
            }
            else if (line.StartsWith(OpacityTexture)) {
                // Opacity texture
                clampIndex = ObjMaterial.TextureType.TextureOpacityType;
            }
            else if (line.StartsWith(EmissiveTexture1) || line.StartsWith(EmissiveTexture2)) {
                // Emissive texture
                clampIndex = ObjMaterial.TextureType.TextureEmissiveType;
            }
            else if (line.StartsWith(BumpTexture1) || line.StartsWith(BumpTexture2)) {
                // Bump texture
                clampIndex = ObjMaterial.TextureType.TextureBumpType;
            }
            else if (line.StartsWith(NormalTextureV1) || line.StartsWith(NormalTextureV2)) {
                // Normal map
                clampIndex = ObjMaterial.TextureType.TextureNormalType;
            }
            else if (line.StartsWith(ReflectionTexture)) {
                // Reflection texture(s)
                // Do nothing here
            }
            else if (line.StartsWith(SpecularityTexture)) {
                // Specularity scaling (glossiness)
                clampIndex = ObjMaterial.TextureType.TextureSpecularityType;
            }
            else if (line.StartsWith(RoughnessTexture)) {
                // PBR Roughness texture
                clampIndex = ObjMaterial.TextureType.TextureRoughnessType;
            }
            else if (line.StartsWith(MetallicTexture)) {
                // PBR Metallic texture
                clampIndex = ObjMaterial.TextureType.TextureMetallicType;
            }
            else if (line.StartsWith(SheenTexture)) {
                // PBR Sheen (reflectance) texture
                clampIndex = ObjMaterial.TextureType.TextureSheenType;
            }
            else if (line.StartsWith(RMATexture)) {
                // PBR Rough/Metal/AO texture
                clampIndex = ObjMaterial.TextureType.TextureRMAType;
            }
            else {
                Log.WriteLine("OBJ/MTL: Encountered unknown texture type");
            }
            return clampIndex;
        }

        internal void SetTexture(ObjMaterial.TextureType clampIndex, string fullname) {
            switch (clampIndex) {
            case TextureType.TextureDiffuseType:
            this.texture = fullname;
            break;
            case TextureType.TextureSpecularType:
            this.textureSpecular = fullname;
            break;
            case TextureType.TextureAmbientType:
            this.textureAmbient = fullname;
            break;
            case TextureType.TextureEmissiveType:
            this.textureEmissive = fullname;
            break;
            case TextureType.TextureBumpType:
            this.textureBump = fullname;
            break;
            case TextureType.TextureNormalType:
            this.textureNormal = fullname;
            break;
            case TextureType.TextureReflectionSphereType:
            this.textureReflection[0] = fullname;
            break;
            case TextureType.TextureReflectionCubeTopType:
            this.textureReflection[0] = fullname;
            break;
            case TextureType.TextureReflectionCubeBottomType:
            this.textureReflection[1] = fullname;
            break;
            case TextureType.TextureReflectionCubeFrontType:
            this.textureReflection[2] = fullname;
            break;
            case TextureType.TextureReflectionCubeBackType:
            this.textureReflection[3] = fullname;
            break;
            case TextureType.TextureReflectionCubeLeftType:
            this.textureReflection[4] = fullname;
            break;
            case TextureType.TextureReflectionCubeRightType:
            this.textureReflection[5] = fullname;
            break;
            case TextureType.TextureSpecularityType:
            this.textureSpecularity = fullname;
            break;
            case TextureType.TextureOpacityType:
            this.textureOpacity = fullname;
            break;
            case TextureType.TextureDispType:
            this.textureDisp = fullname;
            break;
            case TextureType.TextureRoughnessType:
            this.textureRoughness = fullname;
            break;
            case TextureType.TextureMetallicType:
            this.textureMetallic = fullname;
            break;
            case TextureType.TextureSheenType:
            this.textureSheen = fullname;
            break;
            case TextureType.TextureRMAType:
            this.textureRMA = fullname;
            break;
            case TextureType.TextureTypeCount:
            Log.WriteLine("OBJ/MTL: Encountered unknown texture type");
            break;
            default:
            Log.WriteLine("OBJ/MTL: Encountered unknown texture type");
            break;
            }
        }
    }
}