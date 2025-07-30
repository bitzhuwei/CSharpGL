using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EZMFileViewer {
    class NodeLineModel : IBufferSource {
        public readonly EZMBone[] bones;
        private vec3[] positions;
        private vec3[] colors;

        public NodeLineModel(EZMBone[] bones) {
            this.bones = bones;
            this.positions = GetPositions(bones);
            this.colors = GetColors(bones);
        }

        private vec3[] GetColors(EZMBone[] bones) {
            var list = new List<vec3>();
            for (uint i = 0; i < bones.Length; i++) {
                EZMBone bone = bones[i];
                EZMBone parent = bone.Parent;
                if (parent != null) {
                    // a line from parent to child.
                    list.Add(new vec3(1, 0, 0));
                    list.Add(new vec3(1, 1, 1));
                }
            }

            return list.ToArray();
        }

        private vec3[] GetPositions(EZMBone[] bones) {
            var list = new List<vec3>();
            for (uint i = 0; i < bones.Length; i++) {
                EZMBone bone = bones[i];
                EZMBone parent = bone.Parent;
                if (parent != null) {
                    // a line from parent to child.
                    list.Add(new vec3(parent.combinedMat * new vec4(0, 0, 0, 1)));
                    list.Add(new vec3(bone.combinedMat * new vec4(0, 0, 0, 1)));
                }
            }

            return list.ToArray();
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strColor = "color";
        private VertexBuffer colorBuffer;

        private IDrawCommand drawCommand;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName) {
            if (strPosition == bufferName) {
                if (this.positionBuffer == null) {
                    this.positionBuffer = this.positions.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else if (strColor == bufferName) {
                if (this.colorBuffer == null) {
                    this.colorBuffer = this.colors.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
                }

                yield return this.colorBuffer;
            }
            else {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand() {
            if (this.drawCommand == null) {
                this.drawCommand = new DrawArraysCmd(CSharpGL.DrawMode.Lines, positions.Length);

                yield return this.drawCommand;
            }
        }

        #endregion
    }
}
