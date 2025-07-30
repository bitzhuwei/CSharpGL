﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c02d02_MultipleTextures {
    /// <summary>
    ///        Y
    ///        |
    ///        |___________
    ///       /|          /|
    ///      / |         / |
    ///     /--+--------/  |
    ///     |  |_ _ _ _ |_ |____ X
    ///     |  /        |  /
    ///     | /         | /
    ///     |/__________|/
    ///     /           
    ///    /
    ///   Z
    /// </summary>
    class CubeModel : IBufferSource {
        public const string strPosition = "position";
        private VertexBuffer positionBuffer;

        public const string strTexCoord = "texCoord";
        private VertexBuffer uvBuffer;

        private IDrawCommand drawCmd;

        #region IBufferable 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName) {
            if (bufferName == strPosition) {
                if (this.positionBuffer == null) {
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else if (bufferName == strTexCoord) {
                if (this.uvBuffer == null) {
                    this.uvBuffer = uvs.GenVertexBuffer(VBOConfig.Vec2, GLBuffer.Usage.StaticDraw);
                }

                yield return this.uvBuffer;
            }
            else {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand() {
            if (this.drawCmd == null) {
                this.drawCmd = new DrawArraysCmd(CSharpGL.DrawMode.Quads, positions.Length);
            }

            yield return this.drawCmd;
        }

        #endregion

        private const float xLength = 0.5f;
        private const float yLength = 0.5f;
        private const float zLength = 0.5f;
        /// <summary>
        /// six quads' vertexes.
        /// </summary>
        private static readonly vec3[] positions = new vec3[]
        {
            new vec3(-xLength, -yLength, +zLength),//  0
            new vec3(+xLength, -yLength, +zLength),//  1
            new vec3(+xLength, +yLength, +zLength),//  2
            new vec3(-xLength, +yLength, +zLength),//  3

            new vec3(+xLength, -yLength, +zLength),//  4
            new vec3(+xLength, -yLength, -zLength),//  5
            new vec3(+xLength, +yLength, -zLength),//  6
            new vec3(+xLength, +yLength, +zLength),//  7
            
            new vec3(-xLength, +yLength, +zLength),//  8
            new vec3(+xLength, +yLength, +zLength),//  9
            new vec3(+xLength, +yLength, -zLength),// 10
            new vec3(-xLength, +yLength, -zLength),// 11
            
            new vec3(+xLength, -yLength, -zLength),// 12
            new vec3(-xLength, -yLength, -zLength),// 13
            new vec3(-xLength, +yLength, -zLength),// 14
            new vec3(+xLength, +yLength, -zLength),// 15
            
            new vec3(-xLength, -yLength, -zLength),// 16
            new vec3(-xLength, -yLength, +zLength),// 17
            new vec3(-xLength, +yLength, +zLength),// 18
            new vec3(-xLength, +yLength, -zLength),// 19
            
            new vec3(+xLength, -yLength, -zLength),// 20
            new vec3(+xLength, -yLength, +zLength),// 21
            new vec3(-xLength, -yLength, +zLength),// 22
            new vec3(-xLength, -yLength, -zLength),// 23
        };

        /// <summary>
        /// six quads' uvs.
        /// </summary>
        private static readonly vec2[] uvs = new vec2[]
        {
            new vec2(0, 0),//  0
            new vec2(1, 0),//  1
            new vec2(1, 1),//  2
            new vec2(0, 1),//  3

            new vec2(0, 0),//  4
            new vec2(1, 0),//  5
            new vec2(1, 1),//  6
            new vec2(0, 1),//  7
            
            new vec2(0, 0),//  8
            new vec2(1, 0),//  9
            new vec2(1, 1),// 10
            new vec2(0, 1),// 11
            
            new vec2(0, 0),// 12
            new vec2(1, 0),// 13
            new vec2(1, 1),// 14
            new vec2(0, 1),// 15
            
            new vec2(0, 0),// 16
            new vec2(1, 0),// 17
            new vec2(1, 1),// 18
            new vec2(0, 1),// 19
            
            new vec2(0, 0),// 20
            new vec2(1, 0),// 21
            new vec2(1, 1),// 22
            new vec2(0, 1),// 23
        };
    }
}
