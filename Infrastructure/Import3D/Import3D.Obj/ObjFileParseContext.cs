

namespace Import3D.Obj {
    class ObjFileParseContext {
        public readonly ObjFileModel m_pModel;
        //! Current line (for debugging)
        //uint m_uiLine;
        //! Helper buffer
        //char m_buffer[Buffersize];
        /// End of buffer
        //const char* mEnd;
        /// Pointer to IO system instance.
        //IOSystem* m_pIO;
        //! Pointer to progress handler
        //ProgressHandler* m_progress;
        /// Path to the current model, name of the obj file where the buffer comes from
        public readonly string m_originalObjFileName;

        public ObjFileParseContext(ObjFileModel pModel, string originalObjFileName) {
            m_pModel = pModel;
            m_originalObjFileName = originalObjFileName;
        }

        public override string ToString() {
            return this.m_originalObjFileName;
        }
    }
}
