namespace Import3D.Obj {
    public class ObjMesh {
        public const uint NoMaterial = ~0u;

        public readonly string name;

        public List<ObjFace> m_Faces = new();
        public ObjMaterial? material;
        public uint m_uiNumIndices;
        public uint[] m_uiUVCoordinates = new uint[0x8];
        public uint materialIndex = NoMaterial;
        public bool m_hasNormals = false;

        public ObjMesh(string name) {
            this.name = name;
        }

    }
}