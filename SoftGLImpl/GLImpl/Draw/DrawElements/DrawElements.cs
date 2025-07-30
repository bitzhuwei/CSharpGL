using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial class SoftGL {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="count">Specifies the number of elements to be rendered.</param>
        /// <param name="type"></param>
        /// <param name="indices">Specifies an offset of the first index in the array in the data store of the buffer currently bound to the GL_ELEMENT_ARRAY_BUFFER target.</param>
        /// <exception cref="Exception"></exception>
        public static void glDrawElements(GLenum mode, GLsizei count, GLenum type, IntPtr indices) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (!Enum.IsDefined(typeof(DrawTarget), mode) || !Enum.IsDefined(typeof(DrawElementsType), type)) { context.ErrorCode = (uint)(ErrorCode.InvalidEnum); return; }
            if (count < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }
            // TODO: GL_INVALID_OPERATION is generated if a geometry shader is active and mode​ is incompatible with the input primitive type of the geometry shader in the currently installed program object.
            // TODO: GL_INVALID_OPERATION is generated if a non-zero buffer object name is bound to an enabled array or the element array and the buffer object's data store is currently mapped.

            if (count == 0) { return; }
            var vao = context.currentVertexArrayObject; // data structure.
            if (vao == null) { return; }
            var program = context.currentShaderProgram; // algorithm.
            if (program == null) { return; }
            var indexBuffer = context.target2CurrentBuffer[(GLenum)BindBufferTarget.ElementArrayBuffer];
            if (indexBuffer == null) { return; }
            // FPS: 55
            //return;

            // execute vertex shader for each vertex!
            // This is a low effetient implementation.
            Dictionary<uint, VertexCodeBase> vertexID2Shader = VertexShaderStage(count, (DrawElementsType)type, indices, vao, program, indexBuffer);
            // FPS: 55
            //return;

            var framebuffer = context.target2CurrentFramebuffer[(GLenum)BindFramebufferTarget.Framebuffer];// context.currentFramebuffer;
            if (framebuffer == null) { throw new Exception("something is wrong with this implementation(no current framebuffer)!"); }

            ClipSpace2NormalDeviceSpace(vertexID2Shader);
            // FPS: 55
            //return;

            // linear interpolation and execute fargment shader for each fragment!
            //if (vertexID2Shader.Count == 0) { return; }
            //var fs = program.FragmentShader; if (fs == null || fs.codeType == null) { return; }
            //var vs = program.VertexShader; if (vs == null || vs.codeType == null) { return; }
            //const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
            //var x = fs.codeType.GetFields(flags);
            //var inFieldInfos = (from item in fs.codeType.GetFields(flags)
            //                    where item.IsDefined(typeof(InAttribute), true)
            //                    select item).ToArray();
            //var array = (from item in fs.name2inVar select item.Value.fieldInfo).ToArray();
            //var name2fielfInfo = new Dictionary<string, FieldInfo>();
            //foreach (var item in vertexID2Shader.First().Value.GetType().GetFields(flags)) {
            //    name2fielfInfo.Add(item.Name, item);
            //}
            ConcurrentBag<FragmentCodeBase[]> primitiveList = LinearInterpolationAndFragmentShaderStage(
                context, (DrawTarget)mode, count, (DrawElementsType)type, indices,
                vao, program, indexBuffer, vertexID2Shader);
            // FPS: 35
            //return;

            // Scissor test

            // Multisampel fragment operations

            // Stencil test

            // Depth test
            DepthTest(context, primitiveList);
            // FPS : 35
            //return;

            // Blending

            // Dithering

            // Logical operations

            // write fragments to framebuffer's colorbuffer attachment(s).
            WriteFragments2Framebuffer(context, framebuffer, primitiveList);
            // FPS : 30

            foreach (var pair in vertexID2Shader) {
                program?.VertexShader?.scriptPool?.Return(pair.Value);
            }
            foreach (var primitive in primitiveList) {
                foreach (var fragmentCode in primitive) {
                    program?.FragmentShader?.scriptPool?.Return(fragmentCode);
                }
            }
        }

        private static int ByteLength(DrawElementsType type) {
            int result = 0;
            switch (type) {
            case DrawElementsType.UnsignedByte: result = sizeof(byte); break;
            case DrawElementsType.UnsignedShort: result = sizeof(ushort); break;
            case DrawElementsType.UnsignedInt: result = sizeof(uint); break;
            default: throw new NotDealWithNewEnumItemException(typeof(DrawElementsType));
            }

            return result;
        }
    }
}
