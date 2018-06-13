//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using CSharpGL;

//namespace VolumeRendering.Slicing
//{
//    partial class SlicesNode
//    {
//        private unsafe void SliceVolume(vec3 cameraFront, int num_slices)
//        {
//            int maxCosIndex, minCosIndex;
//            FindMaxMin(out maxCosIndex, out minCosIndex);
//            // Ax + By + Cz + D = 0;
//            float A = cameraFront.x, B = cameraFront.y, C = cameraFront.z;
//            vec3 maxVertex = vertexList[maxCosIndex];
//            float D0 = -(A * maxVertex.x + B * maxVertex.y + C * maxVertex.z);
//            vec3 minVertex = vertexList[minCosIndex];
//            float D1 = -(A * minVertex.x + B * minVertex.y + C * minVertex.z);
//            for (int i = 0; i < num_slices; i++)
//            {
//                float D = D0 + (D1 - D0) * (float)i / (float)(num_slices - 1);
//                for (int eIndex = 0; eIndex < edgeList.Length; eIndex++)
//                {
//                    int[] edge = edgeList[eIndex];

//                }
//            }

//            int count = 0;
//            vec3* vTextureSlices = (vec3*)this.vVertexBuffer.MapBuffer(MapBufferAccess.WriteOnly);
//            //loop through all slices
//            for (int i = num_slices - 1; i >= 0; i--)
//            {
//                //vTextureSlices[count++] = ...
//            }

//            ////update buffer object with the new vertices
//            this.vVertexBuffer.UnmapBuffer();
//        }

//        private void FindMaxMin(out int maxCosIndex, out int minCosIndex)
//        {
//            //get the max and min distance of each vertex of the unit cube
//            //in the viewing direction
//            float maxCos = cameraFront.dot(vertexList[0]);
//            float minCos = maxCos;
//            maxCosIndex = 0; minCosIndex = 0;

//            for (int i = 1; i < 8; i++)
//            {
//                //get the distance between the current unit cube vertex and 
//                //the view vector by dot product
//                float dist = cameraFront.dot(vertexList[i]);

//                //if distance is > maxCos, store the value and index
//                if (dist > maxCos)
//                {
//                    maxCos = dist;
//                    maxCosIndex = i;
//                }

//                //if distance is < minCos, store the value 
//                if (dist < minCos)
//                {
//                    minCos = dist;
//                    minCosIndex = i;
//                }
//            };
//        }

//        class Node
//        {
//            public readonly vec3 position;

//            public Node previous;
//            public Node next;

//            public override string ToString()
//            {
//                return string.Format("{0}, pre:{1}, next:{2}", position, previous, next);
//            }
//        }
//    }
//}
