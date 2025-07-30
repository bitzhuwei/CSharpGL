using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    partial class CodeBase {

        public static ivec2 ivec2(int v) {
            return new ivec2(v, v);
        }

        public static ivec2 ivec2(int x, int y) {
            return new ivec2(x, y);
        }

        public static ivec2 ivec2(uvec2 v) {
            return new ivec2((int)v.x, (int)v.y);
        }

        public static ivec2 ivec2(ivec3 v) {
            return new ivec2(v.x, v.y);
        }

        public static ivec2 ivec2(ivec4 v) {
            return new ivec2(v.x, v.y);
        }

        public static ivec3 ivec3(int v) {
            return new ivec3(v, v, v);
        }

        public static ivec3 ivec3(int x, int y, int z) {
            return new ivec3(x, y, z);
        }

        public static ivec3 ivec3(ivec2 xy, int z) {
            return new ivec3(xy.x, xy.y, z);
        }

        public static ivec3 ivec3(int x, ivec2 yz) {
            return new ivec3(x, yz.x, yz.y);
        }

        public static ivec3 ivec3(ivec4 v) {
            return new ivec3(v.x, v.y, v.z);
        }

        public static ivec4 ivec4(int v) {
            return new ivec4(v, v, v, v);
        }

        public static ivec4 ivec4(int x, int y, int z, int w) {
            return new ivec4(x, y, z, w);
        }

        public static ivec4 ivec4(ivec2 xy, ivec2 zw) {
            return new ivec4(xy.x, xy.y, zw.x, zw.y);
        }

        public static ivec4 ivec4(int x, int y, ivec2 zw) {
            return new ivec4(x, y, zw.x, zw.y);
        }

        public static ivec4 ivec4(ivec2 xy, int z, int w) {
            return new ivec4(xy.x, xy.y, z, w);
        }

        public static ivec4 ivec4(ivec3 xyz, int w) {
            return new ivec4(xyz, w);
        }

        public static ivec4 ivec4(int x, ivec3 yzw) {
            return new ivec4(x, yzw.x, yzw.y, yzw.z);
        }


        public static ivec2 ivec2(uint v) {
            return new ivec2((int)v, (int)v);
        }

        public static ivec2 ivec2(uint x, uint y) {
            return new ivec2((int)x, (int)y);
        }

        public static ivec2 ivec2(uvec3 v) {
            return new ivec2((int)v.x, (int)v.y);
        }

        public static ivec2 ivec2(uvec4 v) {
            return new ivec2((int)v.x, (int)v.y);
        }

        public static ivec3 ivec3(uint v) {
            return new ivec3((int)v, (int)v, (int)v);
        }

        public static ivec3 ivec3(uint x, uint y, uint z) {
            return new ivec3((int)x, (int)y, (int)z);
        }

        public static ivec3 ivec3(uvec2 xy, uint z) {
            return new ivec3((int)xy.x, (int)xy.y, (int)z);
        }

        public static ivec3 ivec3(uint x, uvec2 yz) {
            return new ivec3((int)x, (int)yz.x, (int)yz.y);
        }

        public static ivec3 ivec3(uvec4 v) {
            return new ivec3((int)v.x, (int)v.y, (int)v.z);
        }

        public static ivec4 ivec4(uint v) {
            return new ivec4((int)v, (int)v, (int)v, (int)v);
        }

        public static ivec4 ivec4(uint x, uint y, uint z, uint w) {
            return new ivec4((int)x, (int)y, (int)z, (int)w);
        }

        public static ivec4 ivec4(uvec2 xy, uvec2 zw) {
            return new ivec4((int)xy.x, (int)xy.y, (int)zw.x, (int)zw.y);
        }

        public static ivec4 ivec4(uint x, uint y, uvec2 zw) {
            return new ivec4((int)x, (int)y, (int)zw.x, (int)zw.y);
        }

        public static ivec4 ivec4(uvec2 xy, uint z, uint w) {
            return new ivec4((int)xy.x, (int)xy.y, (int)z, (int)w);
        }

        public static ivec4 ivec4(uvec3 xyz, uint w) {
            return new ivec4((int)xyz.x, (int)xyz.y, (int)xyz.z, (int)w);
        }

        public static ivec4 ivec4(uint x, uvec3 yzw) {
            return new ivec4((int)x, (int)yzw.x, (int)yzw.y, (int)yzw.z);
        }
    }
}
