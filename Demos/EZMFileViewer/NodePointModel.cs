using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EZMFileViewer
{
    class NodePointModel : IBufferSource
    {
        public readonly EZMBone[] bones;
        private vec3[] positions;

        public NodePointModel(EZMBone[] bones)
        {
            this.bones = bones;
            this.positions = GetPositions(bones);
        }

        private vec3[] GetPositions(EZMBone[] bones)
        {
            var positions = new vec3[bones.Length];
            for (int i = 0; i < bones.Length; i++)
            {
                EZMBone bone = bones[i];
                EZMBone parent = bone.Parent;
                if (parent != null)
                {
                    positions[i] = new vec3(parent.state.matrix * bone.state.matrix * new vec4(0, 0, 0, 1));
                }
                else
                {
                    positions[i] = new vec3(bone.state.matrix * new vec4(0, 0, 0, 1));
                }
            }

            return positions;
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;

        private IDrawCommand drawCommand;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            if (strPosition == bufferName)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = this.positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.drawCommand == null)
            {
                this.drawCommand = new DrawArraysCmd(DrawMode.Points, this.positions.Length);
            }

            yield return this.drawCommand;
        }

        #endregion
    }
}
