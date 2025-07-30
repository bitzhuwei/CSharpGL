using bitzhuwei.GLTF2;
using System.Diagnostics;
using System.Globalization;

namespace CSharpGL {
    unsafe partial class DummyRenderer {

        public static DummyRenderer Read(glTFile glTFile) {
            var renderer = new DummyRenderer();
            if (glTFile.buffers != null) {
                var length = glTFile.buffers.Length;
                if (length > 0) {
                    renderer.glBuffers = new GLTFBuffer[length];
                    //var vbos = new GLuint[length];
                    //var gl = GL.Current; Debug.Assert(gl != null);
                    //gl.glGenBuffers((GLsizei)length, vbos);
                    for (int i = 0; i < length; i++) {
                        renderer.glBuffers[i] = GLTFBuffer.Read(glTFile.buffers[i]/*, vbos[i]*/);
                    }
                }
            }
            if (glTFile.bufferViews != null) {
                var length = glTFile.bufferViews.Length;
                renderer.glBufferViews = new GLTFBufferView[length];
                for (int i = 0; i < length; i++) {
                    renderer.glBufferViews[i] = GLTFBufferView.Read(glTFile.bufferViews[i], renderer.glBuffers);
                }
            }
            if (glTFile.accessors != null) {
                renderer.accessors = new GLTFAccessor[glTFile.accessors.Length];
                for (int i = 0; i < renderer.accessors.Length; i++) {
                    renderer.accessors[i] = GLTFAccessor.Read(glTFile.accessors[i], renderer.glBufferViews);
                }
            }
            if (glTFile.meshes != null) {
                renderer.glMeshes = new GLTFMesh[glTFile.meshes.Length];
                for (int i = 0; i < renderer.glMeshes.Length; i++) {
                    renderer.glMeshes[i] = GLTFMesh.Read(glTFile.meshes[i], renderer);
                }
            }
            if (glTFile.nodes != null) {
                renderer.glNodes = new GLTFNode[glTFile.nodes.Length];
                for (int i = 0; i < renderer.glNodes.Length; i++) {
                    renderer.glNodes[i] = GLTFNode.Read(glTFile.nodes[i], renderer);
                }
                for (int i = 0; i < renderer.glNodes.Length; i++) {
                    var glNode = renderer.glNodes[i];
                    var tfNode = glTFile.nodes[i];
                    if (tfNode.children != null) {// assign children & parent
                        foreach (var childIndex in tfNode.children) {
                            var child = renderer.glNodes[childIndex];
                            glNode.children.Add(child);
                            child.parent = glNode;
                        }
                    }
                }
            }
            if (glTFile.scenes != null) {
                renderer.glScenes = new GLTFScene[glTFile.scenes.Length];
                for (int i = 0; i < renderer.glScenes.Length; i++) {
                    renderer.glScenes[i] = GLTFScene.Read(glTFile.scenes[i], renderer.glNodes);
                }
            }
            renderer.scene = glTFile.scene;

            //{
            //    // make sure if a GLBuffer should bind to only 1 kind of target
            //    var report = AboutBufferBind(renderer.accessors);
            //    foreach (var item in report) {
            //        var buffer = item.Key; var list = item.Value;
            //        if (list.Count == 1) { buffer.onlyTarget = list[0]; }
            //    }
            //}
            // init VBO/SSBO etc.
            foreach (var accessor in renderer.accessors) {
                accessor.InitGLObjects();
            }


            return renderer;
        }

        private static Dictionary<GLTFBuffer, List<uint>> AboutBufferBind(GLTFAccessor[] accessors) {
            var report = new Dictionary<GLTFBuffer, List<GLenum>>();
            foreach (var accessor in accessors) {
                {
                    GLenum target = accessor.bufferView.target ?? 0;
                    var buffer = accessor.bufferView.buffer;
                    if (!report.TryGetValue(buffer, out var list)) {
                        list = new List<GLenum>(); list.Add(target);
                    }
                    else {
                        if (!list.Contains(target)) { list.Add(target); }
                    }
                }
                if (accessor.sparse != null) {
                    var sparse = accessor.sparse;
                    {
                        var buffer = sparse.indices.bufferView.buffer;
                        const GLenum target = 0x8893/*GL_ELEMENT_ARRAY_BUFFER*/;
                        if (!report.TryGetValue(buffer, out var list)) {
                            list = new List<GLenum>(); list.Add(target);
                        }
                        else {
                            if (!list.Contains(target)) { list.Add(target); }
                        }
                    }
                    {
                        var buffer = sparse.values.bufferView.buffer;
                        const GLenum target = 0x8892/*GL_ARRAY_BUFFER*/;
                        if (!report.TryGetValue(buffer, out var list)) {
                            list = new List<GLenum>(); list.Add(target);
                        }
                        else {
                            if (!list.Contains(target)) { list.Add(target); }
                        }
                    }
                }
            }
            return report;
        }
    }
}
