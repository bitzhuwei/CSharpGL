namespace CSharpGL {
    public unsafe partial class GLTFProgram : IDisposable {
        public readonly uint programId;

        public GLTFProgram(uint programId) {
            this.programId = programId;
        }
    }
}