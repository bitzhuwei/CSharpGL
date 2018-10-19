using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace EZMFileViewer
{
    class BoneModel : IBufferSource
    {
        private vec3[] positions;
        private vec3[] colors;
        public BoneModel(EZMBone[] bones)
        {
            this.bones = bones;
            {
                var list = new List<vec3>();
                for (uint i = 0; i < this.bones.Length; i++)
                {
                    EZMBone bone = this.bones[i];
                    EZMBone parent = bone.Parent;
                    if (parent != null)
                    {
                        list.Add(GetPosition(parent));
                        list.Add(GetPosition(bone));
                        //list.Add(parent.state.position);
                        //list.Add(bone.state.position);
                    }
                }
                this.positions = list.ToArray();
            }
            //{
            //    var positions = new vec3[bones.Length];
            //    for (int i = 0; i < positions.Length; i++)
            //    {
            //        EZMBone parent = bones[i].Parent;
            //        if (parent != null)
            //        {
            //            positions[i] = new vec3(parent.combinedMat * bones[i].combinedMat * new vec4(bones[i].state.position, 1.0f));
            //        }
            //        else
            //        {
            //            positions[i] = new vec3(bones[i].combinedMat * new vec4(bones[i].state.position, 1.0f));
            //        }
            //    }
            //    this.positions = positions;
            //}
            {
                var random = new Random();
                var colors = new vec3[this.positions.Length];
                for (int i = 0; i * 2 < colors.Length; i++)
                {
                    vec3 c = new vec3(
                        (float)random.NextDouble(),
                        (float)random.NextDouble(),
                        (float)random.NextDouble()
                        );
                    colors[i * 2 + 0] = c;
                    colors[i * 2 + 1] = c;
                }
                this.colors = colors;
            }
            //{
            //    var colors = new vec3[bones.Length];
            //    if (colors.Length > 0)
            //    {
            //        colors[0] = new vec3(1, 0, 0);
            //    }
            //    for (int i = 1; i < colors.Length - 1; i++)
            //    {
            //        colors[i] = new vec3(1, 1, 1);
            //    }
            //    if (colors.Length > 1)
            //    {
            //        colors[colors.Length - 1] = new vec3(0, 0, 1);
            //    }
            //    this.colors = colors;
            //}
        }

        private vec3 GetPosition(EZMBone bone)
        {
            vec3 result = new vec3();
            EZMBone parent = bone.Parent;
            if (parent != null)
            {
                result = new vec3(parent.combinedMat * bone.combinedMat * new vec4(bone.state.position, 1.0f));
            }
            else
            {
                result = new vec3(bone.combinedMat * new vec4(bone.state.position, 1.0f));
            }

            return result;
        }
        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strColor = "color";
        private VertexBuffer colorBuffer;

        private IDrawCommand drawCommand;
        private EZMBone[] bones;

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
            else if (strColor == bufferName)
            {
                if (this.colorBuffer == null)
                {
                    this.colorBuffer = this.colors.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.colorBuffer;
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
                this.drawCommand = new DrawArraysCmd(DrawMode.Lines, this.positions.Length);
            }

            yield return this.drawCommand;
        }

        #endregion
    }
}
