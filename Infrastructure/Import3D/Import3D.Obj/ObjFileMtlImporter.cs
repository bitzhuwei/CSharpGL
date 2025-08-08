
using System.Diagnostics;

namespace Import3D.Obj {
    public class ObjFileMtlImporter {

        public static void Load(string absPath, ObjFileModel model) {
            if (model.defaultMaterial == null) {
                model.defaultMaterial = new ObjMaterial("default");
            }
            using (var reader = new StreamReader(absPath)) {
                var lines = ObjFileMtlPreprocessor.Preprocess(reader);
                foreach (var line in lines) {
                    if (false) { }
                    else if (line.StartsWith("Ka") || line.StartsWith("ka")) {
                        if (model.currentMaterial != null) {
                            model.currentMaterial.ambient = GetColorRGB(line);
                        }
                    }
                    else if (line.StartsWith("Kd") || line.StartsWith("kd")) {
                        if (model.currentMaterial != null) {
                            model.currentMaterial.diffuse = GetColorRGB(line);
                        }
                    }
                    else if (line.StartsWith("Ks") || line.StartsWith("ks")) {
                        if (model.currentMaterial != null) {
                            model.currentMaterial.specular = GetColorRGB(line);
                        }
                    }
                    else if (line.StartsWith("Ke") || line.StartsWith("ke")) {
                        if (model.currentMaterial != null) {
                            model.currentMaterial.emissive = GetColorRGB(line);
                        }
                    }
                    else if (line.StartsWith("Tf")) {
                        // Material transmission color
                        if (model.currentMaterial != null) {
                            model.currentMaterial.transparent = GetColorRGB(line);
                        }
                    }
                    else if (line.StartsWith("Tr")) {
                        // Material transmission alpha value
                        float d = GetFloatValue(line);
                        if (model.currentMaterial != null) {
                            model.currentMaterial.alpha = 1.0f - d;
                        }
                    }
                    else if (line.StartsWith("disp")) {
                        // A displacement map
                        GetTexture(line, absPath, model);
                    }
                    else if (line.StartsWith("d")) {
                        // Alpha value
                        float a = GetFloatValue(line);
                        if (model.currentMaterial != null) {
                            model.currentMaterial.alpha = a;
                        }
                    }
                    else if (line.StartsWith("Ns") || line.StartsWith("ns")) {
                        float s = GetFloatValue(line);
                        if (model.currentMaterial != null) {
                            model.currentMaterial.shineness = s;
                        }
                    }
                    else if (line.StartsWith("Ni") || line.StartsWith("ni")) {
                        float ior = GetFloatValue(line);
                        if (model.currentMaterial != null) {
                            model.currentMaterial.ior = ior;
                        }
                    }
                    else if (line.StartsWith("Ne") || line.StartsWith("ne")) {
                        CreateMaterial(line, model);
                    }
                    else if (line.StartsWith("No") || line.StartsWith("no")) {
                        GetTexture(line, absPath, model);
                    }
                    else if (line.StartsWith("Pr")) {
                        var value = GetFloatValue(line);
                        if (model.currentMaterial != null) {
                            model.currentMaterial.roughness = value;
                        }
                    }
                    else if (line.StartsWith("Pm")) {
                        var value = GetFloatValue(line);
                        if (model.currentMaterial != null) {
                            model.currentMaterial.metallic = value;
                        }
                    }
                    else if (line.StartsWith("Ps")) {
                        var value = GetColorRGB(line);
                        if (model.currentMaterial != null) {
                            model.currentMaterial.sheen = value;
                        }
                    }
                    else if (line.StartsWith("Pc")) {
                        if (line.StartsWith("Pcr")) {
                            var value = GetFloatValue(line);
                            if (model.currentMaterial != null) {
                                model.currentMaterial.clearcoat_roughness = value;
                            }
                        }
                        else {
                            var value = GetFloatValue(line);
                            if (model.currentMaterial != null) {
                                model.currentMaterial.clearcoat_thickness = value;
                            }
                        }
                    }
                    else if (line.StartsWith("m") || line.StartsWith("b") || line.StartsWith("r")) {
                        // Texture || quick'n'dirty - for 'bump' sections || quick'n'dirty - for 'refl' sections
                        GetTexture(line, absPath, model);
                    }
                    else if (line.StartsWith("i")) {// Illumination model
                        var value = GetIntegerValue(line);
                        if (model.currentMaterial != null) {
                            model.currentMaterial.illumination_model = value;
                        }
                    }
                    else if (line.StartsWith("a")) {
                        var value = GetFloatValue(line);
                        if (model.currentMaterial != null) {
                            model.currentMaterial.anisotropy = value;
                        }
                    }
                }
            }
        }

        private static int GetIntegerValue(string line) {
            var parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 2) { return int.Parse(parts[1]); }
            else { return 0; }
        }

        // newmtl name
        private static void CreateMaterial(string line, ObjFileModel model) {
            string name;
            {
                var parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 2) { name = parts[1]; }
                else { name = ObjMaterial.DEFAULT_MATERIAL; }
            }

            if (model.materialMap.TryGetValue(name, out var material)) {
                // Use older material
                model.currentMaterial = material;
            }
            else {
                // New Material created
                material = new ObjMaterial(name);
                model.currentMaterial = material;
                model.materialLib.Add(name);
                model.materialMap.Add(name, material);

                if (model.currentMesh != null) {
                    model.currentMesh.materialIndex = (uint)(model.materialLib.Count - 1);
                }
            }
        }

        private static void GetTexture(string line, string absPath, ObjFileModel model) {
            string? strOut = null;
            ObjMaterial.TextureType clampIndex;

            if (model.currentMaterial == null) {
                var material = new ObjMaterial("Empty_Material");
                model.currentMaterial = material;
                model.materialMap.Add("Empty_Material", material);
            }

            if (false) { }
            else if (line.StartsWith(DiffuseTexture)) {
                // Diffuse texture
                strOut = model.currentMaterial.texture;
                clampIndex = ObjMaterial.TextureType.TextureDiffuseType;
            }
            else if (line.StartsWith(AmbientTexture)) {
                // Ambient texture
                strOut = model.currentMaterial.textureAmbient;
                clampIndex = ObjMaterial.TextureType.TextureAmbientType;
            }
            else if (line.StartsWith(SpecularTexture)) {
                // Specular texture
                strOut = model.currentMaterial.textureSpecular;
                clampIndex = ObjMaterial.TextureType.TextureSpecularType;
            }
            else if (line.StartsWith(DisplacementTexture1) || line.StartsWith(DisplacementTexture2)) {
                // Displacement texture
                strOut = model.currentMaterial.textureDisp;
                clampIndex = ObjMaterial.TextureType.TextureDispType;
            }
            else if (line.StartsWith(OpacityTexture)) {
                // Opacity texture
                strOut = model.currentMaterial.textureOpacity;
                clampIndex = ObjMaterial.TextureType.TextureOpacityType;
            }
            else if (line.StartsWith(EmissiveTexture1) || line.StartsWith(EmissiveTexture2)) {
                // Emissive texture
                strOut = model.currentMaterial.textureEmissive;
                clampIndex = ObjMaterial.TextureType.TextureEmissiveType;
            }
            else if (line.StartsWith(BumpTexture1) || line.StartsWith(BumpTexture2)) {
                // Bump texture
                strOut = model.currentMaterial.textureBump;
                clampIndex = ObjMaterial.TextureType.TextureBumpType;
            }
            else if (line.StartsWith(NormalTextureV1) || line.StartsWith(NormalTextureV2)) {
                // Normal map
                strOut = model.currentMaterial.textureNormal;
                clampIndex = ObjMaterial.TextureType.TextureNormalType;
            }
            else if (line.StartsWith(ReflectionTexture)) {
                // Reflection texture(s)
                // Do nothing here
                return;
            }
            else if (line.StartsWith(SpecularityTexture)) {
                // Specularity scaling (glossiness)
                strOut = model.currentMaterial.textureSpecularity;
                clampIndex = ObjMaterial.TextureType.TextureSpecularityType;
            }
            else if (line.StartsWith(RoughnessTexture)) {
                // PBR Roughness texture
                strOut = model.currentMaterial.textureRoughness;
                clampIndex = ObjMaterial.TextureType.TextureRoughnessType;
            }
            else if (line.StartsWith(MetallicTexture)) {
                // PBR Metallic texture
                strOut = model.currentMaterial.textureMetallic;
                clampIndex = ObjMaterial.TextureType.TextureMetallicType;
            }
            else if (line.StartsWith(SheenTexture)) {
                // PBR Sheen (reflectance) texture
                strOut = model.currentMaterial.textureSheen;
                clampIndex = ObjMaterial.TextureType.TextureSheenType;
            }
            else if (line.StartsWith(RMATexture)) {
                // PBR Rough/Metal/AO texture
                strOut = model.currentMaterial.textureRMA;
                clampIndex = ObjMaterial.TextureType.TextureRMAType;
            }
            else {
                Log.WriteLine("OBJ/MTL: Encountered unknown texture type");
                return;
            }

            bool clamp = false;
            GetTextureOption(line, model, out clamp, out clampIndex, out strOut);
            model.currentMaterial.clamp[(int)clampIndex] = clamp;

            string texture = "";
            {
                var parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 0) { texture = parts[parts.Length - 1]; }
            }
            if (strOut != null) {
                strOut = (absPath + texture);
            }
        }

        private static void GetTextureOption(string line, ObjFileModel model, out bool clamp, out ObjMaterial.TextureType clampIndex, out string? strOut) {
            clamp = false; clampIndex = 0; strOut = null;

            var parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            var index = 1;
            while (index < parts.Length) {
                // If there is any more texture option
                var item = parts[index];
                if (item.Length == 0 || item[0] != '-') { break; }
                // skip option key and value
                int skipToken = 1;

                if (item.StartsWith(ClampOption)) {
                    var value = parts[index + 1];
                    if (value == "on") { clamp = true; }

                    skipToken = 2;
                }
                else if (item.StartsWith(TypeOption)) {
                    var value = parts[index + 1];
                    if (value == "cube_top") {
                        clampIndex = ObjMaterial.TextureType.TextureReflectionCubeTopType;
                        strOut = model.currentMaterial?.textureReflection[0];
                    }
                    else if (value == "cube_bottom") {
                        clampIndex = ObjMaterial.TextureType.TextureReflectionCubeBottomType;
                        strOut = model.currentMaterial?.textureReflection[1];
                    }
                    else if (value == "cube_front") {
                        clampIndex = ObjMaterial.TextureType.TextureReflectionCubeFrontType;
                        strOut = model.currentMaterial?.textureReflection[2];
                    }
                    else if (value == "cube_back") {
                        clampIndex = ObjMaterial.TextureType.TextureReflectionCubeBackType;
                        strOut = model.currentMaterial?.textureReflection[3];
                    }
                    else if (value == "cube_left") {
                        clampIndex = ObjMaterial.TextureType.TextureReflectionCubeLeftType;
                        strOut = model.currentMaterial?.textureReflection[4];
                    }
                    else if (value == "cube_right") {
                        clampIndex = ObjMaterial.TextureType.TextureReflectionCubeRightType;
                        strOut = model.currentMaterial?.textureReflection[5];
                    }
                    else if (value == "sphere") {
                        clampIndex = ObjMaterial.TextureType.TextureReflectionSphereType;
                        strOut = model.currentMaterial?.textureReflection[0];
                    }

                    skipToken = 2;
                }
                else if (item.StartsWith(BumpOption)) {
                    var value = parts[index + 1];
                    Debug.Assert(model.currentMaterial != null);
                    model.currentMaterial.bump_multiplier = float.Parse(value);
                    skipToken = 2;
                }
                else if (item.StartsWith(BlendUOption) ||
                         item.StartsWith(BlendVOption) ||
                         item.StartsWith(BoostOption) ||
                         item.StartsWith(ResolutionOption) ||
                         item.StartsWith(ChannelOption)) {
                    skipToken = 2;
                }
                else if (item.StartsWith(ModifyMapOption)) {
                    skipToken = 3;
                }
                else if (item.StartsWith(OffsetOption) ||
                         item.StartsWith(ScaleOption) ||
                         item.StartsWith(TurbulenceOption)) {
                    skipToken = 4;
                }

                index += skipToken;
            }
        }

        private static float GetFloatValue(string line) {
            var parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 2) { return float.Parse(parts[1]); }
            else { return 0; }
        }

        static readonly char[] separator = { ' ', '\t' };
        private static vec3 GetColorRGB(string line) {
            var parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            var r = float.Parse(parts[1]); float g = 0, b = 0;
            if (parts.Length >= 4) {
                g = float.Parse(parts[2]);
                b = float.Parse(parts[3]);
            }
            return new vec3(r, g, b);
        }


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

        // texture option specific token
        private const string BlendUOption = "-blendu";
        private const string BlendVOption = "-blendv";
        private const string BoostOption = "-boost";
        private const string ModifyMapOption = "-mm";
        private const string OffsetOption = "-o";
        private const string ScaleOption = "-s";
        private const string TurbulenceOption = "-t";
        private const string ResolutionOption = "-texres";
        private const string ClampOption = "-clamp";
        private const string BumpOption = "-bm";
        private const string ChannelOption = "-imfchan";
        private const string TypeOption = "-type";

    }
}
