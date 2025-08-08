namespace Import3D.Obj {
    public class ObjFace {
        //! Primitive type
        public readonly aiPrimitiveType mPrimitiveType;
        //! Vertex indices
        public readonly List<int> m_vertices = new();
        //! Normal indices
        public readonly List<int> m_normals = new();
        //! Texture coordinates indices
        public readonly List<int> m_texturCoords = new();
        //! Pointer to assigned material
        public ObjMaterial? m_pMaterial;

        public ObjFace(aiPrimitiveType mPrimitiveType) {
            this.mPrimitiveType = mPrimitiveType;
        }

        public override string ToString() {
            return $"{mPrimitiveType}";
        }
    }
}