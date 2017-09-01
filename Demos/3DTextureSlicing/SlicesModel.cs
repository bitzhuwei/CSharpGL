using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace _3DTextureSlicing
{
    class SlicesModel : IBufferSource
    {
        public const string position = "position";
        private VertexBuffer slicesBuffer;

        private IndexBuffer indexBuffer;

        const int MAX_SLICES = 512;
        private vec3[] vTextureSlices = new vec3[MAX_SLICES * 12];
        //total number of slices current used
        int num_slices = 256;

        //unit cube vertices
        vec3[] vertexList = new vec3[]
        {
            new vec3(-0.5f,-0.5f,-0.5f),
            new vec3( 0.5f,-0.5f,-0.5f),
            new vec3(0.5f, 0.5f,-0.5f),
            new vec3(-0.5f, 0.5f,-0.5f),
            new vec3(-0.5f,-0.5f, 0.5f),
            new vec3(0.5f,-0.5f, 0.5f),
            new vec3( 0.5f, 0.5f, 0.5f),
            new vec3(-0.5f, 0.5f, 0.5f)
        };

        //unit cube edges
        int[][] edgeList = new int[8][] 
        {
	        new int[12]{ 0,1,5,6,   4,8,11,9,  3,7,2,10 }, // v0 is front
	        new int[12]{ 0,4,3,11,  1,2,6,7,   5,9,8,10 }, // v1 is front
	        new int[12]{ 1,5,0,8,   2,3,7,4,   6,10,9,11}, // v2 is front
	        new int[12]{ 7,11,10,8, 2,6,1,9,   3,0,4,5  }, // v3 is front
	        new int[12]{ 8,5,9,1,   11,10,7,6, 4,3,0,2  }, // v4 is front
	        new int[12]{ 9,6,10,2,  8,11,4,7,  5,0,1,3  }, // v5 is front
	        new int[12]{ 9,8,5,4,   6,1,2,0,   10,7,11,3}, // v6 is front
	        new int[12]{ 10,9,6,5,  7,2,3,1,   11,4,8,0 }  // v7 is front
        };

        private static readonly int[][] edges = new int[12][] 
        {
            new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 3, 0 }, 
            new int[] { 0, 4 }, new int[] { 1, 5 }, new int[] { 2, 6 }, new int[] { 3, 7 }, 
            new int[] { 4, 5 }, new int[] { 5, 6 }, new int[] { 6, 7 }, new int[] { 7, 4 } 
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
