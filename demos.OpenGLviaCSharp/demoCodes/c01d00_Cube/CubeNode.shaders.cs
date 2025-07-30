using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c01d00_Cube {
    partial class CubeNode {
        public const string vertexCode = @"
        #version 430 core

        layout(std430) buffer SSBO {
            vec4 positions[];
        };
        layout(std430) buffer SSBO2 {
            vec4 colors[];
        };
        uniform mat4 mvpMatrix;

        out vec3 passColor;

        void main()
        {
            int primitiveStartIndex = 0; // should be a uniform var
            vec3 pos = positions[primitiveStartIndex + gl_VertexID].xyz;
            vec3 color = colors[primitiveStartIndex + gl_VertexID].rgb;
            gl_Position = mvpMatrix * vec4(pos, 1.0); 
            passColor = color;
        }";
        //        private const string vertexCode = @"
        //        #version 150

        //        // element in vertex buffer. Vertex' position in model space.
        //        in vec3 inPosition;
        //        in vec3 inColor;

        //out vec3 passColor;

        //        uniform mat4 mvpMatrix;

        //        void main() {
        //            // transform vertex' position from model space to clip space.
        //            gl_Position = mvpMatrix * vec4(inPosition, 1.0); 
        //passColor = inColor;
        //        }
        //        ";

        public const string fragmentCode = @"
#version 430 core

        //uniform vec4 color = vec4(1, 0, 0, 1); // default: red color.
in vec3 passColor;

        out vec4 outColor;

        void main() {
            outColor = vec4(passColor, 1.0);// color; // fill the fragment with specified color.
        }
        ";
    }
}
