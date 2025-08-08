

using System.Diagnostics;
using System.IO;
using System.Reflection.Emit;
using System.Runtime.InteropServices.Marshalling;

namespace Import3D.Obj {
    public class ObjFileParser {

        public static ObjFileModel Parse(string filePath, string modelName) {
            using (var reader = new StreamReader(filePath)) {
                return Parse(reader, filePath, modelName);
            }
        }

        public static ObjFileModel Parse(StreamReader reader, string filePath, string modelName) {
            var preprocessed = ObjFilePreprocessor.Preprocess(reader);

            var model = new ObjFileModel(modelName);
            var context = new ObjFileParseContext(model, filePath);

            // void ObjFileParser::parseFile(IOStreamBuffer<char> & streamBuffer) {
            bool insideBlock = false;
            foreach (var line in preprocessed.lines) {
                if (line.Length == 0) { continue; }

                // handle c-stype section end (http://paulbourke.net/dataformats/obj/)
                if (insideBlock) {
                    insideBlock = line.Trim() != "end";
                    continue;
                }
                var m_DataIt = line[0];
                // parse line
                switch (m_DataIt) {
                case 'v': // Parse a vertex texture coordinate
                if (false) { }
                else if (line.StartsWith("v ") || line.StartsWith("v\t")) {
                    ParseV(line, context);
                }
                else if (line.StartsWith("vt")) {
                    // read in texture coordinate ( 2D or 3D )
                    ParseVT(line, context);
                }
                else if (line.StartsWith("vn")) {
                    // Read in normal vector definition
                    ParseVN(line, context);
                }
                break;
                case 'p': // Parse a face, line or point statement
                getFace(aiPrimitiveType.aiPrimitiveType_POINT, line, context);
                break;
                case 'l':
                getFace(aiPrimitiveType.aiPrimitiveType_LINE, line, context);
                break;
                case 'f':
                getFace(aiPrimitiveType.aiPrimitiveType_POLYGON, line, context);
                break;
                case '#': // Parse a comment
                          //getComment();
                          // nothing to do.
                break;
                case 'u': // Parse a material desc. setter
                if (line.StartsWith("usemtl")) {
                    GetMaterialDesc(line, context);
                }
                break;
                case 'm': // Parse a material library or merging group ('mg')
                if (line.StartsWith("mg")) {
                    GetGroupNumberAndResolution(line, context);
                }
                else if (line.StartsWith("mtllib")) {
                    GetMaterialLib(line, context);
                }
                break;
                case 'g': // Parse group name
                GetGroupName(line, context);
                break;
                case 's': // Parse group number
                if (line.StartsWith("surf")) { insideBlock = true; }
                else { GetGroupNumber(line, context); }
                break;
                case 'o': // Parse object name
                GetObjectName(line, context);
                break;
                case 'c': // handle cstype section start
                insideBlock = line.StartsWith("cstype") || line.StartsWith("curv");
                //|| line.StartsWith("curv2");
                break;
                default:// nothing to do.
                break;
                }

            }


            // }
            return context.m_pModel;
        }

        //  Stores values for a new object instance, name will be used to identify it.
        private static void GetObjectName(string line, ObjFileParseContext context) {
            string? objName = null;
            {
                var parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 1) { objName = parts[1]; }
            }
            if (objName != null) {
                // Reset current object
                context.m_pModel.currentObject = null;

                // Search for actual object
                for (int i = 0; i < context.m_pModel.objects.Count; i++) {
                    var obj = context.m_pModel.objects[i];
                    if (obj.objName == objName) {
                        context.m_pModel.currentObject = obj;
                        break;
                    }
                }

                // Allocate a new object, if current one was not found before
                if (context.m_pModel.currentObject == null) {
                    CreateObject(objName, context);
                }
            }
        }

        //  Not supported
        //s 'integer' // the smoothing group for the elements that follow it.
        private static void GetGroupNumber(string line, ObjFileParseContext context) {
        }

        //  Getter for a group name.
        // g group name
        private static void GetGroupName(string line, ObjFileParseContext context) {
            string groupName = "";
            if (line.Length > 2) { groupName = line.Substring(2).Trim(); }

            // Change active group, if necessary
            if (context.m_pModel.activeGroup != groupName) {
                // We are mapping groups into the object structure
                CreateObject(groupName, context);

                // Search for already existing entry
                if (context.m_pModel.groups.TryGetValue(groupName, out var it)) {
                    context.m_pModel.groupFaceIDs = it;
                }
                else {
                    // New group name, creating a new entry
                    var array = new List<uint>();
                    context.m_pModel.groups.Add(groupName, array);
                    context.m_pModel.groupFaceIDs = array;
                }

                context.m_pModel.activeGroup = groupName;
            }
        }

        //  Get material library from file.
        // mtllib filename filename ..
        private static void GetMaterialLib(string line, ObjFileParseContext context) {
            var filename = "";
            if (line.Length > 7) { filename = line.Substring(7).Trim(); }

            // Check if directive is valid.
            if (filename == "") {
                Log.WriteLine("OBJ: no name for material library specified.");
                return;
            }

            var dir = Directory.GetParent(context.m_originalObjFileName);
            Debug.Assert(dir != null);
            var absPath = Path.Combine(dir.FullName, filename);

            if (!File.Exists(absPath)) {
                Log.WriteLine($"OBJ: Unable to locate material file {absPath}");
                var strMatFallbackName = context.m_originalObjFileName.Substring(0,
                    context.m_originalObjFileName.Length - 3) + "mtl";
                Log.WriteLine($"OBJ: Opening fallback material file {strMatFallbackName}");
                if (!File.Exists(strMatFallbackName)) {
                    Log.WriteLine($"OBJ: Unable to locate fallback material file {strMatFallbackName}");
                    return;
                }
                else { absPath = strMatFallbackName; }
            }

            // Import material library data from file.
            // Some exporters (e.g. Silo) will happily write out empty
            // material files if the model doesn't use any materials, so we
            // allow that.

            // Importing the material library
            ObjFileMtlImporter.Load(absPath, context.m_pModel);
        }

        //  Not supported
        private static void GetGroupNumberAndResolution(string line, ObjFileParseContext context) {
            // skip this line
        }

        // usemtl filename
        private static void GetMaterialDesc(string line, ObjFileParseContext context) {
            string? filename = null;
            if (line.Length > 7) { filename = line.Substring(7).Trim(); }

            // In some cases we should ignore this 'usemtl' command, this variable helps us to do so
            bool skip = false;

            // Get name
            if (filename == null) { skip = true; }

            // If the current mesh has the same material, we will ignore that 'usemtl' command
            // There is no need to create another object or even mesh here
            if (!skip) {
                if (context.m_pModel.currentMaterial != null
                    && context.m_pModel.currentMaterial.materialName == filename) {
                    skip = true;
                }
            }

            if (!skip) {
                // Search for material
                if (context.m_pModel.materialMap.TryGetValue(filename, out var material)) {
                    // Found, using detected material
                    context.m_pModel.currentMaterial = material;
                }
                else {
                    // Not found, so we don't know anything about the material except for its name.
                    // This may be the case if the material library is missing. We don't want to lose all
                    // materials if that happens, so create a new named material instead of discarding it
                    // completely.
                    Log.WriteLine($"OBJ: failed to locate material {filename}, creating new material");
                    material = new ObjMaterial(filename);
                    context.m_pModel.currentMaterial = material;
                    context.m_pModel.materialLib.Add(filename);
                    context.m_pModel.materialMap.Add(filename, material);
                }

                if (NeedNewMesh(filename, context)) {
                    var newMeshName = context.m_pModel.activeGroup == null ? filename : context.m_pModel.activeGroup;
                    CreateMesh(newMeshName, context);
                }

                Debug.Assert(context.m_pModel.currentMesh != null);
                context.m_pModel.currentMesh.materialIndex = GetMaterialIndex(filename, context);
            }
        }

        //  Returns true, if a new mesh must be created.
        private static bool NeedNewMesh(string materialName, ObjFileParseContext context) {
            // If no mesh data yet
            if (context.m_pModel.currentMesh == null) {
                return true;
            }

            bool need = false;
            var index = GetMaterialIndex(materialName, context);
            var currentIndex = context.m_pModel.currentMesh.materialIndex;
            if (currentIndex != ObjMesh.NoMaterial && currentIndex != index
                    // no need create a new mesh if no faces in current
                    // lets say 'usemtl' goes straight after 'g'
                    && context.m_pModel.currentMesh.m_Faces.Count > 0) {
                // New material -> only one material per mesh, so we need to create a new
                // material
                need = true;
            }

            return need;
        }

        private static void getFace(aiPrimitiveType type, string line, ObjFileParseContext context) {
            var face = new ObjFace(type);
            bool hasNormal = false;
            var vSize = context.m_pModel.mVertices.Count;
            var vtSize = context.m_pModel.mTextureCoord.Count;
            var vnSize = context.m_pModel.mNormals.Count;
            var parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 1; i < parts.Length; i++) {
                var vvtvn = parts[i].Split('/');
                switch (vvtvn.Length) {
                case 1: {// v
                    var index = int.Parse(vvtvn[0]);
                    if (index < 0) { index = vSize + index; }
                    else { index--; }
                    face.m_vertices.Add(index);
                }
                break;
                case 2: {// v/vt
                    {
                        var index = int.Parse(vvtvn[0]);
                        if (index < 0) { index = vSize + index; }
                        else { index--; }
                        face.m_vertices.Add(index);
                    }
                    if (vvtvn[1] != "") {
                        var index = int.Parse(vvtvn[1]);
                        if (index < 0) { index = vtSize + index; }
                        else { index--; }
                        face.m_texturCoords.Add(index);
                    }
                }
                break;
                case 3: {// v/vt/vn
                    {
                        var index = int.Parse(vvtvn[0]);
                        if (index < 0) { index = vSize + index; }
                        else { index--; }
                        face.m_vertices.Add(index);
                    }
                    if (vvtvn[1] != "") {
                        var index = int.Parse(vvtvn[1]);
                        if (index < 0) { index = vtSize + index; }
                        else { index--; }
                        face.m_texturCoords.Add(index);
                    }
                    if (vvtvn[2] != "") {
                        var index = int.Parse(vvtvn[2]);
                        if (index < 0) { index = vnSize + index; }
                        else { index--; }
                        face.m_normals.Add(index);
                        hasNormal = true;
                    }
                }
                break;
                default: throw new NotImplementedException();
                }
            }

            // Set active material, if one set
            if (context.m_pModel.currentMaterial != null) {
                face.m_pMaterial = context.m_pModel.currentMaterial;
            }
            else {
                face.m_pMaterial = context.m_pModel.defaultMaterial;
            }

            // Create a default object, if nothing is there
            if (context.m_pModel.currentObject == null) {
                CreateObject(ObjObject.DefaultObjName, context);
            }

            // Assign face to mesh
            if (context.m_pModel.currentMesh == null) {
                CreateMesh(ObjObject.DefaultObjName, context);
            }

            // Store the face
            var mesh = context.m_pModel.currentMesh; Debug.Assert(mesh != null);
            mesh.m_Faces.Add(face);
            mesh.m_uiNumIndices += (uint)face.m_vertices.Count;
            mesh.m_uiUVCoordinates[0] += (uint)face.m_texturCoords.Count;
            if (!mesh.m_hasNormals && hasNormal) {
                mesh.m_hasNormals = true;
            }
        }

        private static void CreateObject(string objName, ObjFileParseContext context) {
            var obj = new ObjObject(objName);
            context.m_pModel.currentObject = obj;
            context.m_pModel.objects.Add(obj);

            CreateMesh(objName, context);

            if (context.m_pModel.currentMaterial != null) {
                Debug.Assert(context.m_pModel.currentMesh != null);
                context.m_pModel.currentMesh.materialIndex =
                    GetMaterialIndex(context.m_pModel.currentMaterial.materialName, context);
                context.m_pModel.currentMesh.material = context.m_pModel.currentMaterial;
            }
        }

        private static void CreateMesh(string objName, ObjFileParseContext context) {
            var mesh = new ObjMesh(objName);
            context.m_pModel.currentMesh = mesh;
            context.m_pModel.meshes.Add(mesh);
            var meshId = context.m_pModel.meshes.Count - 1;
            if (context.m_pModel.currentObject != null) {
                context.m_pModel.currentObject.meshes.Add(meshId);
            }
            else {
                throw new Exception("OBJ: No object detected to attach a new mesh instance.");
            }
        }

        private static uint GetMaterialIndex(string materialName, ObjFileParseContext context) {
            for (int index = 0; index < context.m_pModel.materialLib.Count; index++) {
                if (materialName == context.m_pModel.materialLib[index]) {
                    return (uint)index;
                }
            }

            //return unchecked((uint)(-1));
            return ObjMesh.NoMaterial;
        }

        private static void ParseVN(string line, ObjFileParseContext context) {
            var parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            if (false) { }
            else if (parts.Length == 4) {// v x y z
                var x = float.Parse(parts[1]);
                var y = float.Parse(parts[2]);
                var z = float.Parse(parts[3]);
                context.m_pModel.mNormals.Add(new vec3(x, y, z));
            }
            else { throw new Exception("Obj file format error!"); }
        }

        private static void ParseVT(string line, ObjFileParseContext context) {
            var parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            var dim = parts.Length - 1;
            if (false) { }
            else if (parts.Length == 3) {// vt x y
                var x = float.Parse(parts[1]);
                var y = float.Parse(parts[2]);
                var z = 0.0f;
                context.m_pModel.mTextureCoord.Add(new vec3(x, y, z));
            }
            else if (parts.Length == 4) {// vt x y z
                var x = float.Parse(parts[1]);
                var y = float.Parse(parts[2]);
                var z = float.Parse(parts[3]);
                context.m_pModel.mTextureCoord.Add(new vec3(x, y, z));
            }
            if (context.m_pModel.mTextureCoordDim < dim) {
                context.m_pModel.mTextureCoordDim = (uint)dim;
            }
        }

        private static void ParseV(string line, ObjFileParseContext context) {
            var parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            if (false) { }
            else if (parts.Length == 4) {// v x y z
                var x = float.Parse(parts[1]);
                var y = float.Parse(parts[2]);
                var z = float.Parse(parts[3]);
                context.m_pModel.mVertices.Add(new vec3(x, y, z));
            }
            else if (parts.Length == 5) {// v x y z w
                var x = float.Parse(parts[1]);
                var y = float.Parse(parts[2]);
                var z = float.Parse(parts[3]);
                var w = float.Parse(parts[4]);

                if (w == 0) { throw new Exception("OBJ: Invalid component in homogeneous vector (Division by zero)"); }

                context.m_pModel.mVertices.Add(new vec3(x / w, y / w, z / w));
            }
            else if (parts.Length == 7) {// v x y z r g b
                var diff = context.m_pModel.mVertices.Count - context.m_pModel.mVertexColors.Count;
                // fill previous omitted vertex-colors by default
                for (int i = 0; i < diff; i++) {
                    context.m_pModel.mVertexColors.Add(new vec3(0));
                }
                // read vertex and vertex-color
                {
                    var x = float.Parse(parts[1]);
                    var y = float.Parse(parts[2]);
                    var z = float.Parse(parts[3]);
                    context.m_pModel.mVertices.Add(new vec3(x, y, z));
                }
                {
                    var x = float.Parse(parts[4]);
                    var y = float.Parse(parts[5]);
                    var z = float.Parse(parts[6]);
                    context.m_pModel.mVertexColors.Add(new vec3(x, y, z));
                }
            }

            // append omitted vertex-colors as default for the end if any vertex-color exists
            if (context.m_pModel.mVertexColors.Count > 0) {
                var diff = context.m_pModel.mVertices.Count - context.m_pModel.mVertexColors.Count;
                for (int i = 0; i < diff; i++) {
                    context.m_pModel.mVertexColors.Add(new vec3(0));
                }
            }
        }

        //private static string getNameNoSpace(string line) {
        //    var parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        //    if (parts.Length > 0) { return parts[0]; }
        //    else { return ""; }
        //}
        static readonly char[] separator = { ' ', '\t' };
    }
}
