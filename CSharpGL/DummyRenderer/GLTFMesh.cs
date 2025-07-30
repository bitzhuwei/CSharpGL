using bitzhuwei.GLTF2;

namespace CSharpGL {
    public class GLTFMesh {
        public GLTFPrimitive[] primitives = new GLTFPrimitive[0];

        internal static GLTFMesh Read(glTFmesh mesh, DummyRenderer renderer) {
            var glMesh = new GLTFMesh();
            var length = mesh.primitives.Length;
            glMesh.primitives = new GLTFPrimitive[length];
            for (int i = 0; i < length; i++) {
                glMesh.primitives[i] = GLTFPrimitive.Read(mesh.primitives[i], renderer);
            }

            return glMesh;
        }
    }
}