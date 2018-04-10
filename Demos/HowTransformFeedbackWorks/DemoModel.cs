using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace HowTransformFeedbackWorks
{
    partial class DemoModel : IBufferSource
    {
        public const string inPosition = "inPosition";
        public const string inPosition2 = "inPosition2";
        public const string inVelocity = "inVelocity";
        public const string inVelocity2 = "inVelocity2";
        private VertexBuffer positionBuffer;
        private VertexBuffer positionBuffer2;
        private VertexBuffer velocityBuffer;
        private VertexBuffer velocityBuffer2;

        private IDrawCommand drawCmd;

        private static readonly vec3[] positions = new vec3[3];
        //{
        //new vec3(1, 0, 0), new vec3(0, 0, 1), new vec3(-1, 0, 0),
        //new vec3(0, 0, -1),
        //};
        private static readonly vec3[] velocitys = new vec3[3]
        {
            new vec3(1, 0, 0), new vec3(0, 1, 0), new vec3(0, 0, 1), 
            //new vec3(0, 0, -1),
        };


        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            if (bufferName == inPosition)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.DynamicCopy);
                }

                yield return this.positionBuffer;
            }
            else if (bufferName == inPosition2)
            {
                if (this.positionBuffer2 == null)
                {
                    this.positionBuffer2 = positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.DynamicCopy);
                }

                yield return this.positionBuffer2;
            }
            else if (bufferName == inVelocity)
            {
                if (this.velocityBuffer == null)
                {
                    this.velocityBuffer = velocitys.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.DynamicCopy);
                }

                yield return this.velocityBuffer;
            }
            else if (bufferName == inVelocity2)
            {
                if (this.velocityBuffer2 == null)
                {
                    this.velocityBuffer2 = velocitys.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.DynamicCopy);
                }

                yield return this.velocityBuffer2;
            }
            else
            {
                throw new ArgumentException("bufferName");
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.drawCmd == null)
            {
                this.drawCmd = new DrawArraysCmd(DrawMode.Triangles, 0, positions.Length);
            }

            yield return this.drawCmd;
        }

        #endregion
    }
}
