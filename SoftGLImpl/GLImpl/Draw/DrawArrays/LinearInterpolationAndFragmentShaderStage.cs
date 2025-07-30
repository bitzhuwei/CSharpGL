using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial class SoftGL {

        private static ConcurrentBag<FragmentCodeBase[]> LinearInterpolationAndFragmentShaderStage(
            RenderContext context, DrawTarget mode, int count,
            GLVertexArrayObject vao, GLProgram program,
            Dictionary<uint, VertexCodeBase> vertexID2Shader,
            System.Reflection.FieldInfo[] inFieldInfos, Dictionary<string, System.Reflection.FieldInfo> name2fielfInfo) {
            ConcurrentBag<FragmentCodeBase[]> result;
            switch (mode) {
            case DrawTarget.Points: result = LinearInterpolationAndFragmentShaderStage4Points(context, count, vao, program, vertexID2Shader); break;
            case DrawTarget.Lines: result = LinearInterpolationAndFragmentShaderStage4Lines(context, count, vao, program, vertexID2Shader); break;
            case DrawTarget.LineLoop: result = LinearInterpolationAndFragmentShaderStage4LineLoop(context, count, vao, program, vertexID2Shader); break;
            case DrawTarget.LineStrip: result = LinearInterpolationAndFragmentShaderStage4LineStrip(context, count, vao, program, vertexID2Shader); break;
            case DrawTarget.Triangles: result = LinearInterpolationAndFragmentShaderStage4Triangles(context, count, vao, program, vertexID2Shader); break;
            case DrawTarget.TriangleStrip: result = LinearInterpolationAndFragmentShaderStage4TriangleStrip(context, count, vao, program, vertexID2Shader); break;
            case DrawTarget.TriangleFan: result = LinearInterpolationAndFragmentShaderStage4TriangleFan(context, count, vao, program, vertexID2Shader); break;
            case DrawTarget.Quads: result = LinearInterpolationAndFragmentShaderStage4Quads(context, count, vao, program, vertexID2Shader); break;
            case DrawTarget.QuadStrip: result = LinearInterpolationAndFragmentShaderStage4QuadStrip(context, count, vao, program, vertexID2Shader); break;
            case DrawTarget.Polygon: result = LinearInterpolationAndFragmentShaderStage4Polygon(context, count, vao, program, vertexID2Shader); break;
            case DrawTarget.LinesAdjacency: result = LinearInterpolationAndFragmentShaderStage4LinesAdjacency(context, count, vao, program, vertexID2Shader); break;
            case DrawTarget.LineStripAdjacency: result = LinearInterpolationAndFragmentShaderStage4LineStripAdjacency(context, count, vao, program, vertexID2Shader); break;
            case DrawTarget.TrianglesAdjacency: result = LinearInterpolationAndFragmentShaderStage4TrianglesAdjacency(context, count, vao, program, vertexID2Shader); break;
            case DrawTarget.TriangleStripAdjacency: result = LinearInterpolationAndFragmentShaderStage4TriangleStripAdjacency(context, count, vao, program, vertexID2Shader); break;
            case DrawTarget.Patches: result = LinearInterpolationAndFragmentShaderStage4Patches(context, count, vao, program, vertexID2Shader); break;
            default: throw new NotDealWithNewEnumItemException(typeof(DrawTarget));
            }

            return result;
        }


    }
}
