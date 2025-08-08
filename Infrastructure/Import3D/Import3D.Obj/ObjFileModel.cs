namespace Import3D.Obj {
    public class ObjFileModel {

        public string modelName;
        public List<ObjObject> objects = new List<ObjObject>();
        public ObjObject? currentObject;
        public ObjMaterial? currentMaterial;
        public ObjMaterial defaultMaterial = new ObjMaterial();
        public List<string> materialLib = new List<string>();
        public List<vec3> mVertices = new List<vec3>();
        public List<vec3> mNormals = new List<vec3>();
        public List<vec3> mVertexColors = new List<vec3>();
        public Dictionary<string, List<uint>> groups = new Dictionary<string, List<uint>>();
        public List<uint> groupFaceIDs = new List<uint>();
        public string? activeGroup;
        public List<vec3> mTextureCoord = new List<vec3>();
        /// <summary>
        /// Maximum dimension of texture coordinates
        /// </summary>
        public uint mTextureCoordDim;
        public ObjMesh? currentMesh;
        public List<ObjMesh> meshes = new List<ObjMesh>();
        public Dictionary<string, ObjMaterial> materialMap = new Dictionary<string, ObjMaterial>();

        public ObjFileModel(string modelName) {
            this.modelName = modelName;
            this.materialLib.Add(ObjMaterial.DEFAULT_MATERIAL);
            this.materialMap.Add(ObjMaterial.DEFAULT_MATERIAL, this.defaultMaterial);
        }
    }
}
