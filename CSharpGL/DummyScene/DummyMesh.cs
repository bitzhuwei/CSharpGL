
namespace CSharpGL {
    public class DummyMesh {
        internal IDrawCommand GetCmd() {
            throw new NotImplementedException();
        }

        internal bool TryGet(string bufferName, out VertexBuffer buffer) {
            throw new NotImplementedException();
        }
    }
}