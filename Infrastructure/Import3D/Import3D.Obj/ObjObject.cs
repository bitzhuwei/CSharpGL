namespace Import3D.Obj {
    public class ObjObject {
        public const string DefaultObjName = "defaultobject";

        public enum ObjectType {
            ObjType,
            GroupType
        }

        public string objName;
        public mat4 transformation;
        public List<ObjObject> subObjects = new();
        public List<int> meshes = new();

        public ObjObject(string objName) {
            this.objName = objName;
        }

    }
}