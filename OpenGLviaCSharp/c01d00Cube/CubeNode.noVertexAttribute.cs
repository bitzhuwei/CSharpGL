//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using CSharpGL;

//namespace c01d00_Cube
//{
//    partial class CubeNode
//    {
//        private const string vertexCode = @"
//#version 150
//
//// element in vertex buffer. Vertex' position in model space.
////in vec3 inPosition;
//
//uniform mat4 mvpMatrix;
//
//	vec2 texCoord[4] = vec2[4](vec2(0.0, 0.0), vec2(1.0, 0.0), vec2(0.0, 1.0), vec2(1.0, 1.0));
//
//const float halfLength = 0.5f;
//vec3 positions[8] = vec3[8]
//        (
//            vec3(+halfLength, +halfLength, +halfLength), // 0
//            vec3(+halfLength, +halfLength, -halfLength), // 1
//            vec3(+halfLength, -halfLength, +halfLength), // 2
//            vec3(+halfLength, -halfLength, -halfLength), // 3 
//            vec3(-halfLength, +halfLength, +halfLength), // 4 
//            vec3(-halfLength, +halfLength, -halfLength), // 5
//            vec3(-halfLength, -halfLength, +halfLength), // 6
//            vec3(-halfLength, -halfLength, -halfLength) // 7
//        );
//void main() {
//    // transform vertex' position from model space to clip space.
//    //gl_Position = mvpMatrix * vec4(inPosition, 1.0); 
//    gl_Position = mvpMatrix * vec4(positions[gl_VertexID], 1.0); 
//}
//";

//        private const string fragmentCode = @"
//#version 150
//
//uniform vec4 color = vec4(1, 0, 0, 1); // default: red color.
//
//out vec4 outColor;
//
//void main() {
//    outColor = color; // fill the fragment with specified color.
//}
//";
//    }
//}
