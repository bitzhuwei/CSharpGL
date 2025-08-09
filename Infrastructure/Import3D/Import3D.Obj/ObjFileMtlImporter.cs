
using System.Diagnostics;

namespace Import3D.Obj {
    public class ObjFileMtlImporter {

        public static void Load(string materialFullname, ObjFileModel model) {
            if (model.defaultMaterial == null) {
                model.defaultMaterial = new ObjMaterial("default");
            }
            using (var reader = new StreamReader(materialFullname)) {
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
                        GetTexture(line, materialFullname, model);
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
                        GetTexture(line, materialFullname, model);
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
                        GetTexture(line, materialFullname, model);
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

        private static void GetTexture(string line, string materialFullname, ObjFileModel model) {
            string? strOut = null;
            ObjMaterial.TextureType clampIndex;

            if (model.currentMaterial == null) {
                var material = new ObjMaterial("Empty_Material");
                model.currentMaterial = material;
                model.materialMap.Add("Empty_Material", material);
            }

            clampIndex = model.currentMaterial.GetClampIndex(line);
            bool clamp = false; ObjMaterial.TextureType clampIndex2 = clampIndex;
            GetTextureOption(line, model, out clamp, out clampIndex2);
            if (clampIndex2 == 0) { clampIndex2 = clampIndex; }

            model.currentMaterial.clamp[(int)clampIndex2] = clamp;

            string texture = "";
            {
                var parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 0) { texture = parts[parts.Length - 1]; }
                else { throw new Exception("empty texture filename!"); }
            }
            if (clampIndex2 != ObjMaterial.TextureType.TextureTypeCount) {
                var fileInfo = new FileInfo(materialFullname);
                var dir = fileInfo.DirectoryName; Debug.Assert(dir != null);
                var fullname = Path.Combine(dir, texture);
                model.currentMaterial.SetTexture(clampIndex2, fullname);
            }
        }

        private static void GetTextureOption(string line, ObjFileModel model, out bool clamp, out ObjMaterial.TextureType clampIndex) {
            clamp = false; clampIndex = 0;

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
                        //strOut = model.currentMaterial?.textureReflection[0];
                    }
                    else if (value == "cube_bottom") {
                        clampIndex = ObjMaterial.TextureType.TextureReflectionCubeBottomType;
                        //strOut = model.currentMaterial?.textureReflection[1];
                    }
                    else if (value == "cube_front") {
                        clampIndex = ObjMaterial.TextureType.TextureReflectionCubeFrontType;
                        //strOut = model.currentMaterial?.textureReflection[2];
                    }
                    else if (value == "cube_back") {
                        clampIndex = ObjMaterial.TextureType.TextureReflectionCubeBackType;
                        //strOut = model.currentMaterial?.textureReflection[3];
                    }
                    else if (value == "cube_left") {
                        clampIndex = ObjMaterial.TextureType.TextureReflectionCubeLeftType;
                        //strOut = model.currentMaterial?.textureReflection[4];
                    }
                    else if (value == "cube_right") {
                        clampIndex = ObjMaterial.TextureType.TextureReflectionCubeRightType;
                        //strOut = model.currentMaterial?.textureReflection[5];
                    }
                    else if (value == "sphere") {
                        clampIndex = ObjMaterial.TextureType.TextureReflectionSphereType;
                        //strOut = model.currentMaterial?.textureReflection[0];
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
