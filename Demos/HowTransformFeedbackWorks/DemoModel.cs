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
        public const string inVelocity = "inVelocity";
        public const string outPosition = "outPosition";
        public const string outVelocity = "outVelocity";
        private VertexBuffer[] positionBuffers = new VertexBuffer[2];
        private VertexBuffer[] velocityBuffers = new VertexBuffer[2];
        private IndexBuffer[] indexBuffers = new IndexBuffer[2];
        private VertexArrayObject[] updateVAOs = new VertexArrayObject[2];
        private VertexArrayObject[] renderVAOs = new VertexArrayObject[2];
        private int currentIndex = 0;

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

        public VertexBuffer GetVertexAttributeBuffer(string bufferName)
        {
            throw new NotImplementedException();
        }

        public IndexBuffer GetIndexBuffer()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
