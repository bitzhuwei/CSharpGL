using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL {
    unsafe partial class GL {
        // generated according to https://gitee.com/bitzhuwei/OpenGL-Registry/blob/335-docs/gl.commands.xml
        /// <summary>void glAccum(GLenum op, GLfloat value);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, void> glAccum;
        /// <summary>void glAccumxOES(GLenum op, GLfixed value);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed, void> glAccumxOES;
        /// <summary>void glActiveProgramEXT(GLuint program);</summary>
        public readonly delegate* unmanaged<GLuint, void> glActiveProgramEXT;
        /// <summary>void glActiveShaderProgram(GLuint pipeline, GLuint program);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, void> glActiveShaderProgram;
        /// <summary>void glActiveShaderProgramEXT(GLuint pipeline, GLuint program);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, void> glActiveShaderProgramEXT;
        /// <summary>void glActiveStencilFaceEXT(GLenum face);</summary>
        public readonly delegate* unmanaged<GLenum, void> glActiveStencilFaceEXT;
        /// <summary>void glActiveTexture(GLenum texture);</summary>
        public readonly delegate* unmanaged<GLenum, void> glActiveTexture;
        /// <summary>void glActiveTextureARB(GLenum texture);</summary>
        public readonly delegate* unmanaged<GLenum, void> glActiveTextureARB;
        /// <summary>void glActiveVaryingNV(GLuint program, string name);</summary>
        public readonly delegate* unmanaged<GLuint, string, void> glActiveVaryingNV;
        /// <summary>void glAlphaFragmentOp1ATI(GLenum op, GLuint dst, GLuint dstMod, GLuint arg1, GLuint arg1Rep, GLuint arg1Mod);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLuint, GLuint, GLuint, void> glAlphaFragmentOp1ATI;
        /// <summary>void glAlphaFragmentOp2ATI(GLenum op, GLuint dst, GLuint dstMod, GLuint arg1, GLuint arg1Rep, GLuint arg1Mod, GLuint arg2, GLuint arg2Rep, GLuint arg2Mod);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, void> glAlphaFragmentOp2ATI;
        /// <summary>void glAlphaFragmentOp3ATI(GLenum op, GLuint dst, GLuint dstMod, GLuint arg1, GLuint arg1Rep, GLuint arg1Mod, GLuint arg2, GLuint arg2Rep, GLuint arg2Mod, GLuint arg3, GLuint arg3Rep, GLuint arg3Mod);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, void> glAlphaFragmentOp3ATI;
        /// <summary>void glAlphaFunc(GLenum func, GLfloat ref);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, void> glAlphaFunc;
        /// <summary>void glAlphaFuncQCOM(GLenum func, GLclampf ref);</summary>
        public readonly delegate* unmanaged<GLenum, GLclampf, void> glAlphaFuncQCOM;
        /// <summary>void glAlphaFuncx(GLenum func, GLfixed ref);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed, void> glAlphaFuncx;
        /// <summary>void glAlphaFuncxOES(GLenum func, GLfixed ref);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed, void> glAlphaFuncxOES;
        /// <summary>void glAlphaToCoverageDitherControlNV(GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, void> glAlphaToCoverageDitherControlNV;
        /// <summary>void glApplyFramebufferAttachmentCMAAINTEL();</summary>
        public readonly delegate* unmanaged<void> glApplyFramebufferAttachmentCMAAINTEL;
        /// <summary>void glApplyTextureEXT(GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, void> glApplyTextureEXT;
        /// <summary>GLboolean glAcquireKeyedMutexWin32EXT(GLuint memory, GLuint64 key, GLuint timeout);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint64, GLuint, GLboolean> glAcquireKeyedMutexWin32EXT;
        /// <summary>GLboolean glAreProgramsResidentNV(GLsizei n, GLuint[] programs, GLboolean[] residences);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], GLboolean[], GLboolean> glAreProgramsResidentNV;
        /// <summary>GLboolean glAreTexturesResident(GLsizei n, GLuint[] textures, GLboolean[] residences);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], GLboolean[], GLboolean> glAreTexturesResident;
        /// <summary>GLboolean glAreTexturesResidentEXT(GLsizei n, GLuint[] textures, GLboolean[] residences);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], GLboolean[], GLboolean> glAreTexturesResidentEXT;
        /// <summary>void glArrayElement(GLint i);</summary>
        public readonly delegate* unmanaged<GLint, void> glArrayElement;
        /// <summary>void glArrayElementEXT(GLint i);</summary>
        public readonly delegate* unmanaged<GLint, void> glArrayElementEXT;
        /// <summary>void glArrayObjectATI(GLenum array, GLint size, GLenum type, GLsizei stride, GLuint buffer, GLuint offset);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLenum, GLsizei, GLuint, GLuint, void> glArrayObjectATI;
        /// <summary>GLuint glAsyncCopyBufferSubDataNVX(GLsizei waitSemaphoreCount, GLuint[] waitSemaphoreArray, GLuint64[] fenceValueArray, GLuint readGpu, GLbitfield writeGpuMask, GLuint readBuffer, GLuint writeBuffer, GLintptr readOffset, GLintptr writeOffset, GLsizeiptr size, GLsizei signalSemaphoreCount, GLuint[] signalSemaphoreArray, GLuint64[] signalValueArray);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], GLuint64[], GLuint, GLbitfield, GLuint, GLuint, GLintptr, GLintptr, GLsizeiptr, GLsizei, GLuint[], GLuint64[], GLuint> glAsyncCopyBufferSubDataNVX;
        /// <summary>GLuint glAsyncCopyImageSubDataNVX(GLsizei waitSemaphoreCount, GLuint[] waitSemaphoreArray, GLuint64[] waitValueArray, GLuint srcGpu, GLbitfield dstGpuMask, GLuint srcName, GLenum srcTarget, GLint srcLevel, GLint srcX, GLint srcY, GLint srcZ, GLuint dstName, GLenum dstTarget, GLint dstLevel, GLint dstX, GLint dstY, GLint dstZ, GLsizei srcWidth, GLsizei srcHeight, GLsizei srcDepth, GLsizei signalSemaphoreCount, GLuint[] signalSemaphoreArray, GLuint64[] signalValueArray);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], GLuint64[], GLuint, GLbitfield, GLuint, GLenum, GLint, GLint, GLint, GLint, GLuint, GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLsizei, GLuint[], GLuint64[], GLuint> glAsyncCopyImageSubDataNVX;
        /// <summary>void glAsyncMarkerSGIX(GLuint marker);</summary>
        public readonly delegate* unmanaged<GLuint, void> glAsyncMarkerSGIX;
        /// <summary>void glAttachObjectARB(GLhandleARB containerObj, GLhandleARB obj);</summary>
        public readonly delegate* unmanaged<GLhandleARB, GLhandleARB, void> glAttachObjectARB;
        /// <summary>void glAttachShader(GLuint program, GLuint shader);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, void> glAttachShader;
        /// <summary>void glBegin(GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, void> glBegin;
        /// <summary>void glBeginConditionalRender(GLuint id, GLenum mode);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, void> glBeginConditionalRender;
        /// <summary>void glBeginConditionalRenderNV(GLuint id, GLenum mode);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, void> glBeginConditionalRenderNV;
        /// <summary>void glBeginConditionalRenderNVX(GLuint id);</summary>
        public readonly delegate* unmanaged<GLuint, void> glBeginConditionalRenderNVX;
        /// <summary>void glBeginFragmentShaderATI();</summary>
        public readonly delegate* unmanaged<void> glBeginFragmentShaderATI;
        /// <summary>void glBeginOcclusionQueryNV(GLuint id);</summary>
        public readonly delegate* unmanaged<GLuint, void> glBeginOcclusionQueryNV;
        /// <summary>void glBeginPerfMonitorAMD(GLuint monitor);</summary>
        public readonly delegate* unmanaged<GLuint, void> glBeginPerfMonitorAMD;
        /// <summary>void glBeginPerfQueryINTEL(GLuint queryHandle);</summary>
        public readonly delegate* unmanaged<GLuint, void> glBeginPerfQueryINTEL;
        /// <summary>void glBeginQuery(GLenum target, GLuint id);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glBeginQuery;
        /// <summary>void glBeginQueryARB(GLenum target, GLuint id);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glBeginQueryARB;
        /// <summary>void glBeginQueryEXT(GLenum target, GLuint id);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glBeginQueryEXT;
        /// <summary>void glBeginQueryIndexed(GLenum target, GLuint index, GLuint id);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, void> glBeginQueryIndexed;
        /// <summary>void glBeginTransformFeedback(GLenum primitiveMode);</summary>
        public readonly delegate* unmanaged<GLenum, void> glBeginTransformFeedback;
        /// <summary>void glBeginTransformFeedbackEXT(GLenum primitiveMode);</summary>
        public readonly delegate* unmanaged<GLenum, void> glBeginTransformFeedbackEXT;
        /// <summary>void glBeginTransformFeedbackNV(GLenum primitiveMode);</summary>
        public readonly delegate* unmanaged<GLenum, void> glBeginTransformFeedbackNV;
        /// <summary>void glBeginVertexShaderEXT();</summary>
        public readonly delegate* unmanaged<void> glBeginVertexShaderEXT;
        /// <summary>void glBeginVideoCaptureNV(GLuint video_capture_slot);</summary>
        public readonly delegate* unmanaged<GLuint, void> glBeginVideoCaptureNV;
        /// <summary>void glBindAttribLocation(GLuint program, GLuint index, string name);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, string, void> glBindAttribLocation;
        /// <summary>void glBindAttribLocationARB(GLhandleARB programObj, GLuint index, string name);</summary>
        public readonly delegate* unmanaged<GLhandleARB, GLuint, string, void> glBindAttribLocationARB;
        /// <summary>void glBindBuffer(GLenum target, GLuint buffer);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glBindBuffer;
        /// <summary>void glBindBufferARB(GLenum target, GLuint buffer);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glBindBufferARB;
        /// <summary>void glBindBufferBase(GLenum target, GLuint index, GLuint buffer);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, void> glBindBufferBase;
        /// <summary>void glBindBufferBaseEXT(GLenum target, GLuint index, GLuint buffer);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, void> glBindBufferBaseEXT;
        /// <summary>void glBindBufferBaseNV(GLenum target, GLuint index, GLuint buffer);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, void> glBindBufferBaseNV;
        /// <summary>void glBindBufferOffsetEXT(GLenum target, GLuint index, GLuint buffer, GLintptr offset);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLintptr, void> glBindBufferOffsetEXT;
        /// <summary>void glBindBufferOffsetNV(GLenum target, GLuint index, GLuint buffer, GLintptr offset);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLintptr, void> glBindBufferOffsetNV;
        /// <summary>void glBindBufferRange(GLenum target, GLuint index, GLuint buffer, GLintptr offset, GLsizeiptr size);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLintptr, GLsizeiptr, void> glBindBufferRange;
        /// <summary>void glBindBufferRangeEXT(GLenum target, GLuint index, GLuint buffer, GLintptr offset, GLsizeiptr size);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLintptr, GLsizeiptr, void> glBindBufferRangeEXT;
        /// <summary>void glBindBufferRangeNV(GLenum target, GLuint index, GLuint buffer, GLintptr offset, GLsizeiptr size);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLintptr, GLsizeiptr, void> glBindBufferRangeNV;
        /// <summary>void glBindBuffersBase(GLenum target, GLuint first, GLsizei count, GLuint[] buffers);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLsizei, GLuint[], void> glBindBuffersBase;
        /// <summary>void glBindBuffersRange(GLenum target, GLuint first, GLsizei count, GLuint[] buffers, GLintptr[] offsets, GLsizeiptr[] sizes);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLsizei, GLuint[], GLintptr[], GLsizeiptr[], void> glBindBuffersRange;
        /// <summary>void glBindFragDataLocation(GLuint program, GLuint color, string name);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, string, void> glBindFragDataLocation;
        /// <summary>void glBindFragDataLocationEXT(GLuint program, GLuint color, string name);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, string, void> glBindFragDataLocationEXT;
        /// <summary>void glBindFragDataLocationIndexed(GLuint program, GLuint colorNumber, GLuint index, string name);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, string, void> glBindFragDataLocationIndexed;
        /// <summary>void glBindFragDataLocationIndexedEXT(GLuint program, GLuint colorNumber, GLuint index, string name);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, string, void> glBindFragDataLocationIndexedEXT;
        /// <summary>void glBindFragmentShaderATI(GLuint id);</summary>
        public readonly delegate* unmanaged<GLuint, void> glBindFragmentShaderATI;
        /// <summary>void glBindFramebuffer(GLenum target, GLuint framebuffer);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glBindFramebuffer;
        /// <summary>void glBindFramebufferEXT(GLenum target, GLuint framebuffer);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glBindFramebufferEXT;
        /// <summary>void glBindFramebufferOES(GLenum target, GLuint framebuffer);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glBindFramebufferOES;
        /// <summary>void glBindImageTexture(GLuint unit, GLuint texture, GLint level, GLboolean layered, GLint layer, GLenum access, GLenum format);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLint, GLboolean, GLint, GLenum, GLenum, void> glBindImageTexture;
        /// <summary>void glBindImageTextureEXT(GLuint index, GLuint texture, GLint level, GLboolean layered, GLint layer, GLenum access, GLint format);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLint, GLboolean, GLint, GLenum, GLint, void> glBindImageTextureEXT;
        /// <summary>void glBindImageTextures(GLuint first, GLsizei count, GLuint[] textures);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLuint[], void> glBindImageTextures;
        /// <summary>GLuint glBindLightParameterEXT(GLenum light, GLenum value);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint> glBindLightParameterEXT;
        /// <summary>GLuint glBindMaterialParameterEXT(GLenum face, GLenum value);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint> glBindMaterialParameterEXT;
        /// <summary>void glBindMultiTextureEXT(GLenum texunit, GLenum target, GLuint texture);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, void> glBindMultiTextureEXT;
        /// <summary>GLuint glBindParameterEXT(GLenum value);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint> glBindParameterEXT;
        /// <summary>void glBindProgramARB(GLenum target, GLuint program);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glBindProgramARB;
        /// <summary>void glBindProgramNV(GLenum target, GLuint id);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glBindProgramNV;
        /// <summary>void glBindProgramPipeline(GLuint pipeline);</summary>
        public readonly delegate* unmanaged<GLuint, void> glBindProgramPipeline;
        /// <summary>void glBindProgramPipelineEXT(GLuint pipeline);</summary>
        public readonly delegate* unmanaged<GLuint, void> glBindProgramPipelineEXT;
        /// <summary>void glBindRenderbuffer(GLenum target, GLuint renderbuffer);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glBindRenderbuffer;
        /// <summary>void glBindRenderbufferEXT(GLenum target, GLuint renderbuffer);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glBindRenderbufferEXT;
        /// <summary>void glBindRenderbufferOES(GLenum target, GLuint renderbuffer);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glBindRenderbufferOES;
        /// <summary>void glBindSampler(GLuint unit, GLuint sampler);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, void> glBindSampler;
        /// <summary>void glBindSamplers(GLuint first, GLsizei count, GLuint[] samplers);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLuint[], void> glBindSamplers;
        /// <summary>void glBindShadingRateImageNV(GLuint texture);</summary>
        public readonly delegate* unmanaged<GLuint, void> glBindShadingRateImageNV;
        /// <summary>GLuint glBindTexGenParameterEXT(GLenum unit, GLenum coord, GLenum value);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLuint> glBindTexGenParameterEXT;
        /// <summary>void glBindTexture(GLenum target, GLuint texture);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glBindTexture;
        /// <summary>void glBindTextureEXT(GLenum target, GLuint texture);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glBindTextureEXT;
        /// <summary>void glBindTextureUnit(GLuint unit, GLuint texture);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, void> glBindTextureUnit;
        /// <summary>GLuint glBindTextureUnitParameterEXT(GLenum unit, GLenum value);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint> glBindTextureUnitParameterEXT;
        /// <summary>void glBindTextures(GLuint first, GLsizei count, GLuint[] textures);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLuint[], void> glBindTextures;
        /// <summary>void glBindTransformFeedback(GLenum target, GLuint id);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glBindTransformFeedback;
        /// <summary>void glBindTransformFeedbackNV(GLenum target, GLuint id);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glBindTransformFeedbackNV;
        /// <summary>void glBindVertexArray(GLuint array);</summary>
        public readonly delegate* unmanaged<GLuint, void> glBindVertexArray;
        /// <summary>void glBindVertexArrayAPPLE(GLuint array);</summary>
        public readonly delegate* unmanaged<GLuint, void> glBindVertexArrayAPPLE;
        /// <summary>void glBindVertexArrayOES(GLuint array);</summary>
        public readonly delegate* unmanaged<GLuint, void> glBindVertexArrayOES;
        /// <summary>void glBindVertexBuffer(GLuint bindingindex, GLuint buffer, GLintptr offset, GLsizei stride);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLintptr, GLsizei, void> glBindVertexBuffer;
        /// <summary>void glBindVertexBuffers(GLuint first, GLsizei count, GLuint[] buffers, GLintptr[] offsets, GLsizei[] strides);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLuint[], GLintptr[], GLsizei[], void> glBindVertexBuffers;
        /// <summary>void glBindVertexShaderEXT(GLuint id);</summary>
        public readonly delegate* unmanaged<GLuint, void> glBindVertexShaderEXT;
        /// <summary>void glBindVideoCaptureStreamBufferNV(GLuint video_capture_slot, GLuint stream, GLenum frame_region, GLintptrARB offset);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLintptrARB, void> glBindVideoCaptureStreamBufferNV;
        /// <summary>void glBindVideoCaptureStreamTextureNV(GLuint video_capture_slot, GLuint stream, GLenum frame_region, GLenum target, GLuint texture);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLenum, GLuint, void> glBindVideoCaptureStreamTextureNV;
        /// <summary>void glBinormal3bEXT(GLbyte bx, GLbyte by, GLbyte bz);</summary>
        public readonly delegate* unmanaged<GLbyte, GLbyte, GLbyte, void> glBinormal3bEXT;
        /// <summary>void glBinormal3bvEXT(GLbyte[] v);</summary>
        public readonly delegate* unmanaged<GLbyte[], void> glBinormal3bvEXT;
        /// <summary>void glBinormal3dEXT(GLdouble bx, GLdouble by, GLdouble bz);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, GLdouble, void> glBinormal3dEXT;
        /// <summary>void glBinormal3dvEXT(GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glBinormal3dvEXT;
        /// <summary>void glBinormal3fEXT(GLfloat bx, GLfloat by, GLfloat bz);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, void> glBinormal3fEXT;
        /// <summary>void glBinormal3fvEXT(GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glBinormal3fvEXT;
        /// <summary>void glBinormal3iEXT(GLint bx, GLint by, GLint bz);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, void> glBinormal3iEXT;
        /// <summary>void glBinormal3ivEXT(GLint[] v);</summary>
        public readonly delegate* unmanaged<GLint[], void> glBinormal3ivEXT;
        /// <summary>void glBinormal3sEXT(GLshort bx, GLshort by, GLshort bz);</summary>
        public readonly delegate* unmanaged<GLshort, GLshort, GLshort, void> glBinormal3sEXT;
        /// <summary>void glBinormal3svEXT(GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLshort[], void> glBinormal3svEXT;
        /// <summary>void glBinormalPointerEXT(GLenum type, GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, IntPtr, void> glBinormalPointerEXT;
        /// <summary>void glBitmap(GLsizei width, GLsizei height, GLfloat xorig, GLfloat yorig, GLfloat xmove, GLfloat ymove, GLubyte[] bitmap);</summary>
        public readonly delegate* unmanaged<GLsizei, GLsizei, GLfloat, GLfloat, GLfloat, GLfloat, GLubyte[], void> glBitmap;
        /// <summary>void glBitmapxOES(GLsizei width, GLsizei height, GLfixed xorig, GLfixed yorig, GLfixed xmove, GLfixed ymove, GLubyte[] bitmap);</summary>
        public readonly delegate* unmanaged<GLsizei, GLsizei, GLfixed, GLfixed, GLfixed, GLfixed, GLubyte[], void> glBitmapxOES;
        /// <summary>void glBlendBarrier();</summary>
        public readonly delegate* unmanaged<void> glBlendBarrier;
        /// <summary>void glBlendBarrierKHR();</summary>
        public readonly delegate* unmanaged<void> glBlendBarrierKHR;
        /// <summary>void glBlendBarrierNV();</summary>
        public readonly delegate* unmanaged<void> glBlendBarrierNV;
        /// <summary>void glBlendColor(GLfloat red, GLfloat green, GLfloat blue, GLfloat alpha);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, void> glBlendColor;
        /// <summary>void glBlendColorEXT(GLfloat red, GLfloat green, GLfloat blue, GLfloat alpha);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, void> glBlendColorEXT;
        /// <summary>void glBlendColorxOES(GLfixed red, GLfixed green, GLfixed blue, GLfixed alpha);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, void> glBlendColorxOES;
        /// <summary>void glBlendEquation(GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, void> glBlendEquation;
        /// <summary>void glBlendEquationEXT(GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, void> glBlendEquationEXT;
        /// <summary>void glBlendEquationIndexedAMD(GLuint buf, GLenum mode);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, void> glBlendEquationIndexedAMD;
        /// <summary>void glBlendEquationOES(GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, void> glBlendEquationOES;
        /// <summary>void glBlendEquationSeparate(GLenum modeRGB, GLenum modeAlpha);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, void> glBlendEquationSeparate;
        /// <summary>void glBlendEquationSeparateEXT(GLenum modeRGB, GLenum modeAlpha);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, void> glBlendEquationSeparateEXT;
        /// <summary>void glBlendEquationSeparateIndexedAMD(GLuint buf, GLenum modeRGB, GLenum modeAlpha);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, void> glBlendEquationSeparateIndexedAMD;
        /// <summary>void glBlendEquationSeparateOES(GLenum modeRGB, GLenum modeAlpha);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, void> glBlendEquationSeparateOES;
        /// <summary>void glBlendEquationSeparatei(GLuint buf, GLenum modeRGB, GLenum modeAlpha);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, void> glBlendEquationSeparatei;
        /// <summary>void glBlendEquationSeparateiARB(GLuint buf, GLenum modeRGB, GLenum modeAlpha);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, void> glBlendEquationSeparateiARB;
        /// <summary>void glBlendEquationSeparateiEXT(GLuint buf, GLenum modeRGB, GLenum modeAlpha);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, void> glBlendEquationSeparateiEXT;
        /// <summary>void glBlendEquationSeparateiOES(GLuint buf, GLenum modeRGB, GLenum modeAlpha);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, void> glBlendEquationSeparateiOES;
        /// <summary>void glBlendEquationi(GLuint buf, GLenum mode);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, void> glBlendEquationi;
        /// <summary>void glBlendEquationiARB(GLuint buf, GLenum mode);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, void> glBlendEquationiARB;
        /// <summary>void glBlendEquationiEXT(GLuint buf, GLenum mode);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, void> glBlendEquationiEXT;
        /// <summary>void glBlendEquationiOES(GLuint buf, GLenum mode);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, void> glBlendEquationiOES;
        /// <summary>void glBlendFunc(GLenum sfactor, GLenum dfactor);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, void> glBlendFunc;
        /// <summary>void glBlendFuncIndexedAMD(GLuint buf, GLenum src, GLenum dst);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, void> glBlendFuncIndexedAMD;
        /// <summary>void glBlendFuncSeparate(GLenum sfactorRGB, GLenum dfactorRGB, GLenum sfactorAlpha, GLenum dfactorAlpha);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLenum, void> glBlendFuncSeparate;
        /// <summary>void glBlendFuncSeparateEXT(GLenum sfactorRGB, GLenum dfactorRGB, GLenum sfactorAlpha, GLenum dfactorAlpha);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLenum, void> glBlendFuncSeparateEXT;
        /// <summary>void glBlendFuncSeparateINGR(GLenum sfactorRGB, GLenum dfactorRGB, GLenum sfactorAlpha, GLenum dfactorAlpha);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLenum, void> glBlendFuncSeparateINGR;
        /// <summary>void glBlendFuncSeparateIndexedAMD(GLuint buf, GLenum srcRGB, GLenum dstRGB, GLenum srcAlpha, GLenum dstAlpha);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLenum, GLenum, void> glBlendFuncSeparateIndexedAMD;
        /// <summary>void glBlendFuncSeparateOES(GLenum srcRGB, GLenum dstRGB, GLenum srcAlpha, GLenum dstAlpha);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLenum, void> glBlendFuncSeparateOES;
        /// <summary>void glBlendFuncSeparatei(GLuint buf, GLenum srcRGB, GLenum dstRGB, GLenum srcAlpha, GLenum dstAlpha);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLenum, GLenum, void> glBlendFuncSeparatei;
        /// <summary>void glBlendFuncSeparateiARB(GLuint buf, GLenum srcRGB, GLenum dstRGB, GLenum srcAlpha, GLenum dstAlpha);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLenum, GLenum, void> glBlendFuncSeparateiARB;
        /// <summary>void glBlendFuncSeparateiEXT(GLuint buf, GLenum srcRGB, GLenum dstRGB, GLenum srcAlpha, GLenum dstAlpha);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLenum, GLenum, void> glBlendFuncSeparateiEXT;
        /// <summary>void glBlendFuncSeparateiOES(GLuint buf, GLenum srcRGB, GLenum dstRGB, GLenum srcAlpha, GLenum dstAlpha);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLenum, GLenum, void> glBlendFuncSeparateiOES;
        /// <summary>void glBlendFunci(GLuint buf, GLenum src, GLenum dst);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, void> glBlendFunci;
        /// <summary>void glBlendFunciARB(GLuint buf, GLenum src, GLenum dst);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, void> glBlendFunciARB;
        /// <summary>void glBlendFunciEXT(GLuint buf, GLenum src, GLenum dst);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, void> glBlendFunciEXT;
        /// <summary>void glBlendFunciOES(GLuint buf, GLenum src, GLenum dst);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, void> glBlendFunciOES;
        /// <summary>void glBlendParameteriNV(GLenum pname, GLint value);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, void> glBlendParameteriNV;
        /// <summary>void glBlitFramebuffer(GLint srcX0, GLint srcY0, GLint srcX1, GLint srcY1, GLint dstX0, GLint dstY0, GLint dstX1, GLint dstY1, GLbitfield mask, GLenum filter);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, GLint, GLint, GLint, GLint, GLint, GLbitfield, GLenum, void> glBlitFramebuffer;
        /// <summary>void glBlitFramebufferANGLE(GLint srcX0, GLint srcY0, GLint srcX1, GLint srcY1, GLint dstX0, GLint dstY0, GLint dstX1, GLint dstY1, GLbitfield mask, GLenum filter);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, GLint, GLint, GLint, GLint, GLint, GLbitfield, GLenum, void> glBlitFramebufferANGLE;
        /// <summary>void glBlitFramebufferEXT(GLint srcX0, GLint srcY0, GLint srcX1, GLint srcY1, GLint dstX0, GLint dstY0, GLint dstX1, GLint dstY1, GLbitfield mask, GLenum filter);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, GLint, GLint, GLint, GLint, GLint, GLbitfield, GLenum, void> glBlitFramebufferEXT;
        /// <summary>void glBlitFramebufferNV(GLint srcX0, GLint srcY0, GLint srcX1, GLint srcY1, GLint dstX0, GLint dstY0, GLint dstX1, GLint dstY1, GLbitfield mask, GLenum filter);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, GLint, GLint, GLint, GLint, GLint, GLbitfield, GLenum, void> glBlitFramebufferNV;
        /// <summary>void glBlitNamedFramebuffer(GLuint readFramebuffer, GLuint drawFramebuffer, GLint srcX0, GLint srcY0, GLint srcX1, GLint srcY1, GLint dstX0, GLint dstY0, GLint dstX1, GLint dstY1, GLbitfield mask, GLenum filter);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLint, GLint, GLint, GLint, GLint, GLint, GLint, GLint, GLbitfield, GLenum, void> glBlitNamedFramebuffer;
        /// <summary>void glBufferAddressRangeNV(GLenum pname, GLuint index, GLuint64EXT address, GLsizeiptr length);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint64EXT, GLsizeiptr, void> glBufferAddressRangeNV;
        /// <summary>void glBufferAttachMemoryNV(GLenum target, GLuint memory, GLuint64 offset);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint64, void> glBufferAttachMemoryNV;
        /// <summary>void glBufferData(GLenum target, GLsizeiptr size, IntPtr data, GLenum usage);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizeiptr, IntPtr, GLenum, void> glBufferData;
        /// <summary>void glBufferDataARB(GLenum target, GLsizeiptrARB size, IntPtr data, GLenum usage);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizeiptrARB, IntPtr, GLenum, void> glBufferDataARB;
        /// <summary>void glBufferPageCommitmentARB(GLenum target, GLintptr offset, GLsizeiptr size, GLboolean commit);</summary>
        public readonly delegate* unmanaged<GLenum, GLintptr, GLsizeiptr, GLboolean, void> glBufferPageCommitmentARB;
        /// <summary>void glBufferParameteriAPPLE(GLenum target, GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, void> glBufferParameteriAPPLE;
        /// <summary>void glBufferStorage(GLenum target, GLsizeiptr size, IntPtr data, GLbitfield flags);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizeiptr, IntPtr, GLbitfield, void> glBufferStorage;
        /// <summary>void glBufferStorageEXT(GLenum target, GLsizeiptr size, IntPtr data, GLbitfield flags);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizeiptr, IntPtr, GLbitfield, void> glBufferStorageEXT;
        /// <summary>void glBufferStorageExternalEXT(GLenum target, GLintptr offset, GLsizeiptr size, GLeglClientBufferEXT clientBuffer, GLbitfield flags);</summary>
        public readonly delegate* unmanaged<GLenum, GLintptr, GLsizeiptr, GLeglClientBufferEXT, GLbitfield, void> glBufferStorageExternalEXT;
        /// <summary>void glBufferStorageMemEXT(GLenum target, GLsizeiptr size, GLuint memory, GLuint64 offset);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizeiptr, GLuint, GLuint64, void> glBufferStorageMemEXT;
        /// <summary>void glBufferSubData(GLenum target, GLintptr offset, GLsizeiptr size, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLenum, GLintptr, GLsizeiptr, IntPtr, void> glBufferSubData;
        /// <summary>void glBufferSubDataARB(GLenum target, GLintptrARB offset, GLsizeiptrARB size, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLenum, GLintptrARB, GLsizeiptrARB, IntPtr, void> glBufferSubDataARB;
        /// <summary>void glCallCommandListNV(GLuint list);</summary>
        public readonly delegate* unmanaged<GLuint, void> glCallCommandListNV;
        /// <summary>void glCallList(GLuint list);</summary>
        public readonly delegate* unmanaged<GLuint, void> glCallList;
        /// <summary>void glCallLists(GLsizei n, GLenum type, IntPtr lists);</summary>
        public readonly delegate* unmanaged<GLsizei, GLenum, IntPtr, void> glCallLists;
        /// <summary>GLenum glCheckFramebufferStatus(GLenum target);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum> glCheckFramebufferStatus;
        /// <summary>GLenum glCheckFramebufferStatusEXT(GLenum target);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum> glCheckFramebufferStatusEXT;
        /// <summary>GLenum glCheckFramebufferStatusOES(GLenum target);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum> glCheckFramebufferStatusOES;
        /// <summary>GLenum glCheckNamedFramebufferStatus(GLuint framebuffer, GLenum target);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum> glCheckNamedFramebufferStatus;
        /// <summary>GLenum glCheckNamedFramebufferStatusEXT(GLuint framebuffer, GLenum target);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum> glCheckNamedFramebufferStatusEXT;
        /// <summary>void glClampColor(GLenum target, GLenum clamp);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, void> glClampColor;
        /// <summary>void glClampColorARB(GLenum target, GLenum clamp);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, void> glClampColorARB;
        /// <summary>void glClear(GLbitfield mask);</summary>
        public readonly delegate* unmanaged<GLbitfield, void> glClear;
        /// <summary>void glClearAccum(GLfloat red, GLfloat green, GLfloat blue, GLfloat alpha);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, void> glClearAccum;
        /// <summary>void glClearAccumxOES(GLfixed red, GLfixed green, GLfixed blue, GLfixed alpha);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, void> glClearAccumxOES;
        /// <summary>void glClearBufferData(GLenum target, GLenum internalformat, GLenum format, GLenum type, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLenum, IntPtr, void> glClearBufferData;
        /// <summary>void glClearBufferSubData(GLenum target, GLenum internalformat, GLintptr offset, GLsizeiptr size, GLenum format, GLenum type, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLintptr, GLsizeiptr, GLenum, GLenum, IntPtr, void> glClearBufferSubData;
        /// <summary>void glClearBufferfi(GLenum buffer, GLint drawbuffer, GLfloat depth, GLint stencil);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLfloat, GLint, void> glClearBufferfi;
        /// <summary>void glClearBufferfv(GLenum buffer, GLint drawbuffer, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLfloat*, void> glClearBufferfv;
        /// <summary>void glClearBufferiv(GLenum buffer, GLint drawbuffer, GLint[] value);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint[], void> glClearBufferiv;
        /// <summary>void glClearBufferuiv(GLenum buffer, GLint drawbuffer, GLuint[] value);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLuint[], void> glClearBufferuiv;
        /// <summary>void glClearColor(GLfloat red, GLfloat green, GLfloat blue, GLfloat alpha);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, void> glClearColor;
        /// <summary>void glClearColorIiEXT(GLint red, GLint green, GLint blue, GLint alpha);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, GLint, void> glClearColorIiEXT;
        /// <summary>void glClearColorIuiEXT(GLuint red, GLuint green, GLuint blue, GLuint alpha);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, GLuint, void> glClearColorIuiEXT;
        /// <summary>void glClearColorx(GLfixed red, GLfixed green, GLfixed blue, GLfixed alpha);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, void> glClearColorx;
        /// <summary>void glClearColorxOES(GLfixed red, GLfixed green, GLfixed blue, GLfixed alpha);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, void> glClearColorxOES;
        /// <summary>void glClearDepth(GLdouble depth);</summary>
        public readonly delegate* unmanaged<GLdouble, void> glClearDepth;
        /// <summary>void glClearDepthdNV(GLdouble depth);</summary>
        public readonly delegate* unmanaged<GLdouble, void> glClearDepthdNV;
        /// <summary>void glClearDepthf(GLfloat d);</summary>
        public readonly delegate* unmanaged<GLfloat, void> glClearDepthf;
        /// <summary>void glClearDepthfOES(GLclampf depth);</summary>
        public readonly delegate* unmanaged<GLclampf, void> glClearDepthfOES;
        /// <summary>void glClearDepthx(GLfixed depth);</summary>
        public readonly delegate* unmanaged<GLfixed, void> glClearDepthx;
        /// <summary>void glClearDepthxOES(GLfixed depth);</summary>
        public readonly delegate* unmanaged<GLfixed, void> glClearDepthxOES;
        /// <summary>void glClearIndex(GLfloat c);</summary>
        public readonly delegate* unmanaged<GLfloat, void> glClearIndex;
        /// <summary>void glClearNamedBufferData(GLuint buffer, GLenum internalformat, GLenum format, GLenum type, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLenum, IntPtr, void> glClearNamedBufferData;
        /// <summary>void glClearNamedBufferDataEXT(GLuint buffer, GLenum internalformat, GLenum format, GLenum type, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLenum, IntPtr, void> glClearNamedBufferDataEXT;
        /// <summary>void glClearNamedBufferSubData(GLuint buffer, GLenum internalformat, GLintptr offset, GLsizeiptr size, GLenum format, GLenum type, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLintptr, GLsizeiptr, GLenum, GLenum, IntPtr, void> glClearNamedBufferSubData;
        /// <summary>void glClearNamedBufferSubDataEXT(GLuint buffer, GLenum internalformat, GLsizeiptr offset, GLsizeiptr size, GLenum format, GLenum type, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLsizeiptr, GLsizeiptr, GLenum, GLenum, IntPtr, void> glClearNamedBufferSubDataEXT;
        /// <summary>void glClearNamedFramebufferfi(GLuint framebuffer, GLenum buffer, GLint drawbuffer, GLfloat depth, GLint stencil);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLfloat, GLint, void> glClearNamedFramebufferfi;
        /// <summary>void glClearNamedFramebufferfv(GLuint framebuffer, GLenum buffer, GLint drawbuffer, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLfloat[], void> glClearNamedFramebufferfv;
        /// <summary>void glClearNamedFramebufferiv(GLuint framebuffer, GLenum buffer, GLint drawbuffer, GLint[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLint[], void> glClearNamedFramebufferiv;
        /// <summary>void glClearNamedFramebufferuiv(GLuint framebuffer, GLenum buffer, GLint drawbuffer, GLuint[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLuint[], void> glClearNamedFramebufferuiv;
        /// <summary>void glClearPixelLocalStorageuiEXT(GLsizei offset, GLsizei n, GLuint[] values);</summary>
        public readonly delegate* unmanaged<GLsizei, GLsizei, GLuint[], void> glClearPixelLocalStorageuiEXT;
        /// <summary>void glClearStencil(GLint s);</summary>
        public readonly delegate* unmanaged<GLint, void> glClearStencil;
        /// <summary>void glClearTexImage(GLuint texture, GLint level, GLenum format, GLenum type, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLenum, GLenum, IntPtr, void> glClearTexImage;
        /// <summary>void glClearTexImageEXT(GLuint texture, GLint level, GLenum format, GLenum type, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLenum, GLenum, IntPtr, void> glClearTexImageEXT;
        /// <summary>void glClearTexSubImage(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void> glClearTexSubImage;
        /// <summary>void glClearTexSubImageEXT(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void> glClearTexSubImageEXT;
        /// <summary>void glClientActiveTexture(GLenum texture);</summary>
        public readonly delegate* unmanaged<GLenum, void> glClientActiveTexture;
        /// <summary>void glClientActiveTextureARB(GLenum texture);</summary>
        public readonly delegate* unmanaged<GLenum, void> glClientActiveTextureARB;
        /// <summary>void glClientActiveVertexStreamATI(GLenum stream);</summary>
        public readonly delegate* unmanaged<GLenum, void> glClientActiveVertexStreamATI;
        /// <summary>void glClientAttribDefaultEXT(GLbitfield mask);</summary>
        public readonly delegate* unmanaged<GLbitfield, void> glClientAttribDefaultEXT;
        /// <summary>void glClientWaitSemaphoreui64NVX(GLsizei fenceObjectCount, GLuint[] semaphoreArray, GLuint64[] fenceValueArray);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], GLuint64[], void> glClientWaitSemaphoreui64NVX;
        /// <summary>GLenum glClientWaitSync(GLsync sync, GLbitfield flags, GLuint64 timeout);</summary>
        public readonly delegate* unmanaged<GLsync, GLbitfield, GLuint64, GLenum> glClientWaitSync;
        /// <summary>GLenum glClientWaitSyncAPPLE(GLsync sync, GLbitfield flags, GLuint64 timeout);</summary>
        public readonly delegate* unmanaged<GLsync, GLbitfield, GLuint64, GLenum> glClientWaitSyncAPPLE;
        /// <summary>void glClipControl(GLenum origin, GLenum depth);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, void> glClipControl;
        /// <summary>void glClipControlEXT(GLenum origin, GLenum depth);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, void> glClipControlEXT;
        /// <summary>void glClipPlane(GLenum plane, GLdouble[] equation);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble[], void> glClipPlane;
        /// <summary>void glClipPlanef(GLenum p, GLfloat[] eqn);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glClipPlanef;
        /// <summary>void glClipPlanefIMG(GLenum p, GLfloat[] eqn);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glClipPlanefIMG;
        /// <summary>void glClipPlanefOES(GLenum plane, GLfloat[] equation);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glClipPlanefOES;
        /// <summary>void glClipPlanex(GLenum plane, GLfixed[] equation);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed[], void> glClipPlanex;
        /// <summary>void glClipPlanexIMG(GLenum p, GLfixed[] eqn);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed[], void> glClipPlanexIMG;
        /// <summary>void glClipPlanexOES(GLenum plane, GLfixed[] equation);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed[], void> glClipPlanexOES;
        /// <summary>void glColor3b(GLbyte red, GLbyte green, GLbyte blue);</summary>
        public readonly delegate* unmanaged<GLbyte, GLbyte, GLbyte, void> glColor3b;
        /// <summary>void glColor3bv(GLbyte[] v);</summary>
        public readonly delegate* unmanaged<GLbyte[], void> glColor3bv;
        /// <summary>void glColor3d(GLdouble red, GLdouble green, GLdouble blue);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, GLdouble, void> glColor3d;
        /// <summary>void glColor3dv(GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glColor3dv;
        /// <summary>void glColor3f(GLfloat red, GLfloat green, GLfloat blue);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, void> glColor3f;
        /// <summary>void glColor3fVertex3fSUN(GLfloat r, GLfloat g, GLfloat b, GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glColor3fVertex3fSUN;
        /// <summary>void glColor3fVertex3fvSUN(GLfloat[] c, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], GLfloat[], void> glColor3fVertex3fvSUN;
        /// <summary>void glColor3fv(GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glColor3fv;
        /// <summary>void glColor3hNV(GLhalfNV red, GLhalfNV green, GLhalfNV blue);</summary>
        public readonly delegate* unmanaged<GLhalfNV, GLhalfNV, GLhalfNV, void> glColor3hNV;
        /// <summary>void glColor3hvNV(GLhalfNV[] v);</summary>
        public readonly delegate* unmanaged<GLhalfNV[], void> glColor3hvNV;
        /// <summary>void glColor3i(GLint red, GLint green, GLint blue);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, void> glColor3i;
        /// <summary>void glColor3iv(GLint[] v);</summary>
        public readonly delegate* unmanaged<GLint[], void> glColor3iv;
        /// <summary>void glColor3s(GLshort red, GLshort green, GLshort blue);</summary>
        public readonly delegate* unmanaged<GLshort, GLshort, GLshort, void> glColor3s;
        /// <summary>void glColor3sv(GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLshort[], void> glColor3sv;
        /// <summary>void glColor3ub(GLubyte red, GLubyte green, GLubyte blue);</summary>
        public readonly delegate* unmanaged<GLubyte, GLubyte, GLubyte, void> glColor3ub;
        /// <summary>void glColor3ubv(GLubyte[] v);</summary>
        public readonly delegate* unmanaged<GLubyte[], void> glColor3ubv;
        /// <summary>void glColor3ui(GLuint red, GLuint green, GLuint blue);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, void> glColor3ui;
        /// <summary>void glColor3uiv(GLuint[] v);</summary>
        public readonly delegate* unmanaged<GLuint[], void> glColor3uiv;
        /// <summary>void glColor3us(GLushort red, GLushort green, GLushort blue);</summary>
        public readonly delegate* unmanaged<GLushort, GLushort, GLushort, void> glColor3us;
        /// <summary>void glColor3usv(GLushort[] v);</summary>
        public readonly delegate* unmanaged<GLushort[], void> glColor3usv;
        /// <summary>void glColor3xOES(GLfixed red, GLfixed green, GLfixed blue);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, GLfixed, void> glColor3xOES;
        /// <summary>void glColor3xvOES(GLfixed[] components);</summary>
        public readonly delegate* unmanaged<GLfixed[], void> glColor3xvOES;
        /// <summary>void glColor4b(GLbyte red, GLbyte green, GLbyte blue, GLbyte alpha);</summary>
        public readonly delegate* unmanaged<GLbyte, GLbyte, GLbyte, GLbyte, void> glColor4b;
        /// <summary>void glColor4bv(GLbyte[] v);</summary>
        public readonly delegate* unmanaged<GLbyte[], void> glColor4bv;
        /// <summary>void glColor4d(GLdouble red, GLdouble green, GLdouble blue, GLdouble alpha);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, GLdouble, GLdouble, void> glColor4d;
        /// <summary>void glColor4dv(GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glColor4dv;
        /// <summary>void glColor4f(GLfloat red, GLfloat green, GLfloat blue, GLfloat alpha);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, void> glColor4f;
        /// <summary>void glColor4fNormal3fVertex3fSUN(GLfloat r, GLfloat g, GLfloat b, GLfloat a, GLfloat nx, GLfloat ny, GLfloat nz, GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glColor4fNormal3fVertex3fSUN;
        /// <summary>void glColor4fNormal3fVertex3fvSUN(GLfloat[] c, GLfloat[] n, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], GLfloat[], GLfloat[], void> glColor4fNormal3fVertex3fvSUN;
        /// <summary>void glColor4fv(GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glColor4fv;
        /// <summary>void glColor4hNV(GLhalfNV red, GLhalfNV green, GLhalfNV blue, GLhalfNV alpha);</summary>
        public readonly delegate* unmanaged<GLhalfNV, GLhalfNV, GLhalfNV, GLhalfNV, void> glColor4hNV;
        /// <summary>void glColor4hvNV(GLhalfNV[] v);</summary>
        public readonly delegate* unmanaged<GLhalfNV[], void> glColor4hvNV;
        /// <summary>void glColor4i(GLint red, GLint green, GLint blue, GLint alpha);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, GLint, void> glColor4i;
        /// <summary>void glColor4iv(GLint[] v);</summary>
        public readonly delegate* unmanaged<GLint[], void> glColor4iv;
        /// <summary>void glColor4s(GLshort red, GLshort green, GLshort blue, GLshort alpha);</summary>
        public readonly delegate* unmanaged<GLshort, GLshort, GLshort, GLshort, void> glColor4s;
        /// <summary>void glColor4sv(GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLshort[], void> glColor4sv;
        /// <summary>void glColor4ub(GLubyte red, GLubyte green, GLubyte blue, GLubyte alpha);</summary>
        public readonly delegate* unmanaged<GLubyte, GLubyte, GLubyte, GLubyte, void> glColor4ub;
        /// <summary>void glColor4ubVertex2fSUN(GLubyte r, GLubyte g, GLubyte b, GLubyte a, GLfloat x, GLfloat y);</summary>
        public readonly delegate* unmanaged<GLubyte, GLubyte, GLubyte, GLubyte, GLfloat, GLfloat, void> glColor4ubVertex2fSUN;
        /// <summary>void glColor4ubVertex2fvSUN(GLubyte[] c, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLubyte[], GLfloat[], void> glColor4ubVertex2fvSUN;
        /// <summary>void glColor4ubVertex3fSUN(GLubyte r, GLubyte g, GLubyte b, GLubyte a, GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLubyte, GLubyte, GLubyte, GLubyte, GLfloat, GLfloat, GLfloat, void> glColor4ubVertex3fSUN;
        /// <summary>void glColor4ubVertex3fvSUN(GLubyte[] c, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLubyte[], GLfloat[], void> glColor4ubVertex3fvSUN;
        /// <summary>void glColor4ubv(GLubyte[] v);</summary>
        public readonly delegate* unmanaged<GLubyte[], void> glColor4ubv;
        /// <summary>void glColor4ui(GLuint red, GLuint green, GLuint blue, GLuint alpha);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, GLuint, void> glColor4ui;
        /// <summary>void glColor4uiv(GLuint[] v);</summary>
        public readonly delegate* unmanaged<GLuint[], void> glColor4uiv;
        /// <summary>void glColor4us(GLushort red, GLushort green, GLushort blue, GLushort alpha);</summary>
        public readonly delegate* unmanaged<GLushort, GLushort, GLushort, GLushort, void> glColor4us;
        /// <summary>void glColor4usv(GLushort[] v);</summary>
        public readonly delegate* unmanaged<GLushort[], void> glColor4usv;
        /// <summary>void glColor4x(GLfixed red, GLfixed green, GLfixed blue, GLfixed alpha);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, void> glColor4x;
        /// <summary>void glColor4xOES(GLfixed red, GLfixed green, GLfixed blue, GLfixed alpha);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, void> glColor4xOES;
        /// <summary>void glColor4xvOES(GLfixed[] components);</summary>
        public readonly delegate* unmanaged<GLfixed[], void> glColor4xvOES;
        /// <summary>void glColorFormatNV(GLint size, GLenum type, GLsizei stride);</summary>
        public readonly delegate* unmanaged<GLint, GLenum, GLsizei, void> glColorFormatNV;
        /// <summary>void glColorFragmentOp1ATI(GLenum op, GLuint dst, GLuint dstMask, GLuint dstMod, GLuint arg1, GLuint arg1Rep, GLuint arg1Mod);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, void> glColorFragmentOp1ATI;
        /// <summary>void glColorFragmentOp2ATI(GLenum op, GLuint dst, GLuint dstMask, GLuint dstMod, GLuint arg1, GLuint arg1Rep, GLuint arg1Mod, GLuint arg2, GLuint arg2Rep, GLuint arg2Mod);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, void> glColorFragmentOp2ATI;
        /// <summary>void glColorFragmentOp3ATI(GLenum op, GLuint dst, GLuint dstMask, GLuint dstMod, GLuint arg1, GLuint arg1Rep, GLuint arg1Mod, GLuint arg2, GLuint arg2Rep, GLuint arg2Mod, GLuint arg3, GLuint arg3Rep, GLuint arg3Mod);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, void> glColorFragmentOp3ATI;
        /// <summary>void glColorMask(GLboolean red, GLboolean green, GLboolean blue, GLboolean alpha);</summary>
        public readonly delegate* unmanaged<GLboolean, GLboolean, GLboolean, GLboolean, void> glColorMask;
        /// <summary>void glColorMaskIndexedEXT(GLuint index, GLboolean r, GLboolean g, GLboolean b, GLboolean a);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean, GLboolean, GLboolean, GLboolean, void> glColorMaskIndexedEXT;
        /// <summary>void glColorMaski(GLuint index, GLboolean r, GLboolean g, GLboolean b, GLboolean a);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean, GLboolean, GLboolean, GLboolean, void> glColorMaski;
        /// <summary>void glColorMaskiEXT(GLuint index, GLboolean r, GLboolean g, GLboolean b, GLboolean a);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean, GLboolean, GLboolean, GLboolean, void> glColorMaskiEXT;
        /// <summary>void glColorMaskiOES(GLuint index, GLboolean r, GLboolean g, GLboolean b, GLboolean a);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean, GLboolean, GLboolean, GLboolean, void> glColorMaskiOES;
        /// <summary>void glColorMaterial(GLenum face, GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, void> glColorMaterial;
        /// <summary>void glColorP3ui(GLenum type, GLuint color);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glColorP3ui;
        /// <summary>void glColorP3uiv(GLenum type, GLuint[] color);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint[], void> glColorP3uiv;
        /// <summary>void glColorP4ui(GLenum type, GLuint color);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glColorP4ui;
        /// <summary>void glColorP4uiv(GLenum type, GLuint[] color);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint[], void> glColorP4uiv;
        /// <summary>void glColorPointer(GLint size, GLenum type, GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLint, GLenum, GLsizei, IntPtr, void> glColorPointer;
        /// <summary>void glColorPointerEXT(GLint size, GLenum type, GLsizei stride, GLsizei count, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLint, GLenum, GLsizei, GLsizei, IntPtr, void> glColorPointerEXT;
        /// <summary>void glColorPointerListIBM(GLint size, GLenum type, GLint stride, IntPtr pointer, GLint ptrstride);</summary>
        public readonly delegate* unmanaged<GLint, GLenum, GLint, IntPtr, GLint, void> glColorPointerListIBM;
        /// <summary>void glColorPointervINTEL(GLint size, GLenum type, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLint, GLenum, IntPtr, void> glColorPointervINTEL;
        /// <summary>void glColorSubTable(GLenum target, GLsizei start, GLsizei count, GLenum format, GLenum type, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void> glColorSubTable;
        /// <summary>void glColorSubTableEXT(GLenum target, GLsizei start, GLsizei count, GLenum format, GLenum type, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void> glColorSubTableEXT;
        /// <summary>void glColorTable(GLenum target, GLenum internalformat, GLsizei width, GLenum format, GLenum type, IntPtr table);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLsizei, GLenum, GLenum, IntPtr, void> glColorTable;
        /// <summary>void glColorTableEXT(GLenum target, GLenum internalFormat, GLsizei width, GLenum format, GLenum type, IntPtr table);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLsizei, GLenum, GLenum, IntPtr, void> glColorTableEXT;
        /// <summary>void glColorTableParameterfv(GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glColorTableParameterfv;
        /// <summary>void glColorTableParameterfvSGI(GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glColorTableParameterfvSGI;
        /// <summary>void glColorTableParameteriv(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glColorTableParameteriv;
        /// <summary>void glColorTableParameterivSGI(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glColorTableParameterivSGI;
        /// <summary>void glColorTableSGI(GLenum target, GLenum internalformat, GLsizei width, GLenum format, GLenum type, IntPtr table);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLsizei, GLenum, GLenum, IntPtr, void> glColorTableSGI;
        /// <summary>void glCombinerInputNV(GLenum stage, GLenum portion, GLenum variable, GLenum input, GLenum mapping, GLenum componentUsage);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLenum, GLenum, GLenum, void> glCombinerInputNV;
        /// <summary>void glCombinerOutputNV(GLenum stage, GLenum portion, GLenum abOutput, GLenum cdOutput, GLenum sumOutput, GLenum scale, GLenum bias, GLboolean abDotProduct, GLboolean cdDotProduct, GLboolean muxSum);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLenum, GLenum, GLenum, GLenum, GLboolean, GLboolean, GLboolean, void> glCombinerOutputNV;
        /// <summary>void glCombinerParameterfNV(GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, void> glCombinerParameterfNV;
        /// <summary>void glCombinerParameterfvNV(GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glCombinerParameterfvNV;
        /// <summary>void glCombinerParameteriNV(GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, void> glCombinerParameteriNV;
        /// <summary>void glCombinerParameterivNV(GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLint[], void> glCombinerParameterivNV;
        /// <summary>void glCombinerStageParameterfvNV(GLenum stage, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glCombinerStageParameterfvNV;
        /// <summary>void glCommandListSegmentsNV(GLuint list, GLuint segments);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, void> glCommandListSegmentsNV;
        /// <summary>void glCompileCommandListNV(GLuint list);</summary>
        public readonly delegate* unmanaged<GLuint, void> glCompileCommandListNV;
        /// <summary>void glCompileShader(GLuint shader);</summary>
        public readonly delegate* unmanaged<GLuint, void> glCompileShader;
        /// <summary>void glCompileShaderARB(GLhandleARB shaderObj);</summary>
        public readonly delegate* unmanaged<GLhandleARB, void> glCompileShaderARB;
        /// <summary>void glCompileShaderIncludeARB(GLuint shader, GLsizei count, string[] path, GLint[] length);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, string[], GLint[], void> glCompileShaderIncludeARB;
        /// <summary>void glCompressedMultiTexImage1DEXT(GLenum texunit, GLenum target, GLint level, GLenum internalformat, GLsizei width, GLint border, GLsizei imageSize, IntPtr bits);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLenum, GLsizei, GLint, GLsizei, IntPtr, void> glCompressedMultiTexImage1DEXT;
        /// <summary>void glCompressedMultiTexImage2DEXT(GLenum texunit, GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLsizei imageSize, IntPtr bits);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLenum, GLsizei, GLsizei, GLint, GLsizei, IntPtr, void> glCompressedMultiTexImage2DEXT;
        /// <summary>void glCompressedMultiTexImage3DEXT(GLenum texunit, GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLsizei imageSize, IntPtr bits);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLenum, GLsizei, GLsizei, GLsizei, GLint, GLsizei, IntPtr, void> glCompressedMultiTexImage3DEXT;
        /// <summary>void glCompressedMultiTexSubImage1DEXT(GLenum texunit, GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLsizei imageSize, IntPtr bits);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLsizei, GLenum, GLsizei, IntPtr, void> glCompressedMultiTexSubImage1DEXT;
        /// <summary>void glCompressedMultiTexSubImage2DEXT(GLenum texunit, GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLsizei imageSize, IntPtr bits);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLint, GLsizei, GLsizei, GLenum, GLsizei, IntPtr, void> glCompressedMultiTexSubImage2DEXT;
        /// <summary>void glCompressedMultiTexSubImage3DEXT(GLenum texunit, GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLsizei imageSize, IntPtr bits);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLsizei, IntPtr, void> glCompressedMultiTexSubImage3DEXT;
        /// <summary>void glCompressedTexImage1D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLint border, GLsizei imageSize, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLenum, GLsizei, GLint, GLsizei, IntPtr, void> glCompressedTexImage1D;
        /// <summary>void glCompressedTexImage1DARB(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLint border, GLsizei imageSize, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLenum, GLsizei, GLint, GLsizei, IntPtr, void> glCompressedTexImage1DARB;
        /// <summary>void glCompressedTexImage2D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLsizei imageSize, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLenum, GLsizei, GLsizei, GLint, GLsizei, IntPtr, void> glCompressedTexImage2D;
        /// <summary>void glCompressedTexImage2DARB(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLsizei imageSize, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLenum, GLsizei, GLsizei, GLint, GLsizei, IntPtr, void> glCompressedTexImage2DARB;
        /// <summary>void glCompressedTexImage3D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLsizei imageSize, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLenum, GLsizei, GLsizei, GLsizei, GLint, GLsizei, IntPtr, void> glCompressedTexImage3D;
        /// <summary>void glCompressedTexImage3DARB(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLsizei imageSize, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLenum, GLsizei, GLsizei, GLsizei, GLint, GLsizei, IntPtr, void> glCompressedTexImage3DARB;
        /// <summary>void glCompressedTexImage3DOES(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLsizei imageSize, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLenum, GLsizei, GLsizei, GLsizei, GLint, GLsizei, IntPtr, void> glCompressedTexImage3DOES;
        /// <summary>void glCompressedTexSubImage1D(GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLsizei imageSize, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLsizei, GLenum, GLsizei, IntPtr, void> glCompressedTexSubImage1D;
        /// <summary>void glCompressedTexSubImage1DARB(GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLsizei imageSize, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLsizei, GLenum, GLsizei, IntPtr, void> glCompressedTexSubImage1DARB;
        /// <summary>void glCompressedTexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLsizei imageSize, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, GLsizei, GLsizei, GLenum, GLsizei, IntPtr, void> glCompressedTexSubImage2D;
        /// <summary>void glCompressedTexSubImage2DARB(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLsizei imageSize, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, GLsizei, GLsizei, GLenum, GLsizei, IntPtr, void> glCompressedTexSubImage2DARB;
        /// <summary>void glCompressedTexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLsizei imageSize, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLsizei, IntPtr, void> glCompressedTexSubImage3D;
        /// <summary>void glCompressedTexSubImage3DARB(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLsizei imageSize, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLsizei, IntPtr, void> glCompressedTexSubImage3DARB;
        /// <summary>void glCompressedTexSubImage3DOES(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLsizei imageSize, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLsizei, IntPtr, void> glCompressedTexSubImage3DOES;
        /// <summary>void glCompressedTextureImage1DEXT(GLuint texture, GLenum target, GLint level, GLenum internalformat, GLsizei width, GLint border, GLsizei imageSize, IntPtr bits);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLenum, GLsizei, GLint, GLsizei, IntPtr, void> glCompressedTextureImage1DEXT;
        /// <summary>void glCompressedTextureImage2DEXT(GLuint texture, GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLsizei imageSize, IntPtr bits);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLenum, GLsizei, GLsizei, GLint, GLsizei, IntPtr, void> glCompressedTextureImage2DEXT;
        /// <summary>void glCompressedTextureImage3DEXT(GLuint texture, GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLsizei imageSize, IntPtr bits);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLenum, GLsizei, GLsizei, GLsizei, GLint, GLsizei, IntPtr, void> glCompressedTextureImage3DEXT;
        /// <summary>void glCompressedTextureSubImage1D(GLuint texture, GLint level, GLint xoffset, GLsizei width, GLenum format, GLsizei imageSize, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLsizei, GLenum, GLsizei, IntPtr, void> glCompressedTextureSubImage1D;
        /// <summary>void glCompressedTextureSubImage1DEXT(GLuint texture, GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLsizei imageSize, IntPtr bits);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLsizei, GLenum, GLsizei, IntPtr, void> glCompressedTextureSubImage1DEXT;
        /// <summary>void glCompressedTextureSubImage2D(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLsizei imageSize, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLint, GLsizei, GLsizei, GLenum, GLsizei, IntPtr, void> glCompressedTextureSubImage2D;
        /// <summary>void glCompressedTextureSubImage2DEXT(GLuint texture, GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLsizei imageSize, IntPtr bits);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLint, GLsizei, GLsizei, GLenum, GLsizei, IntPtr, void> glCompressedTextureSubImage2DEXT;
        /// <summary>void glCompressedTextureSubImage3D(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLsizei imageSize, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLsizei, IntPtr, void> glCompressedTextureSubImage3D;
        /// <summary>void glCompressedTextureSubImage3DEXT(GLuint texture, GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLsizei imageSize, IntPtr bits);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLsizei, IntPtr, void> glCompressedTextureSubImage3DEXT;
        /// <summary>void glConservativeRasterParameterfNV(GLenum pname, GLfloat value);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, void> glConservativeRasterParameterfNV;
        /// <summary>void glConservativeRasterParameteriNV(GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, void> glConservativeRasterParameteriNV;
        /// <summary>void glConvolutionFilter1D(GLenum target, GLenum internalformat, GLsizei width, GLenum format, GLenum type, IntPtr image);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLsizei, GLenum, GLenum, IntPtr, void> glConvolutionFilter1D;
        /// <summary>void glConvolutionFilter1DEXT(GLenum target, GLenum internalformat, GLsizei width, GLenum format, GLenum type, IntPtr image);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLsizei, GLenum, GLenum, IntPtr, void> glConvolutionFilter1DEXT;
        /// <summary>void glConvolutionFilter2D(GLenum target, GLenum internalformat, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr image);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void> glConvolutionFilter2D;
        /// <summary>void glConvolutionFilter2DEXT(GLenum target, GLenum internalformat, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr image);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void> glConvolutionFilter2DEXT;
        /// <summary>void glConvolutionParameterf(GLenum target, GLenum pname, GLfloat params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat, void> glConvolutionParameterf;
        /// <summary>void glConvolutionParameterfEXT(GLenum target, GLenum pname, GLfloat params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat, void> glConvolutionParameterfEXT;
        /// <summary>void glConvolutionParameterfv(GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glConvolutionParameterfv;
        /// <summary>void glConvolutionParameterfvEXT(GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glConvolutionParameterfvEXT;
        /// <summary>void glConvolutionParameteri(GLenum target, GLenum pname, GLint params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, void> glConvolutionParameteri;
        /// <summary>void glConvolutionParameteriEXT(GLenum target, GLenum pname, GLint params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, void> glConvolutionParameteriEXT;
        /// <summary>void glConvolutionParameteriv(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glConvolutionParameteriv;
        /// <summary>void glConvolutionParameterivEXT(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glConvolutionParameterivEXT;
        /// <summary>void glConvolutionParameterxOES(GLenum target, GLenum pname, GLfixed param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed, void> glConvolutionParameterxOES;
        /// <summary>void glConvolutionParameterxvOES(GLenum target, GLenum pname, GLfixed[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed[], void> glConvolutionParameterxvOES;
        /// <summary>void glCopyBufferSubData(GLenum readTarget, GLenum writeTarget, GLintptr readOffset, GLintptr writeOffset, GLsizeiptr size);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLintptr, GLintptr, GLsizeiptr, void> glCopyBufferSubData;
        /// <summary>void glCopyBufferSubDataNV(GLenum readTarget, GLenum writeTarget, GLintptr readOffset, GLintptr writeOffset, GLsizeiptr size);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLintptr, GLintptr, GLsizeiptr, void> glCopyBufferSubDataNV;
        /// <summary>void glCopyColorSubTable(GLenum target, GLsizei start, GLint x, GLint y, GLsizei width);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLint, GLint, GLsizei, void> glCopyColorSubTable;
        /// <summary>void glCopyColorSubTableEXT(GLenum target, GLsizei start, GLint x, GLint y, GLsizei width);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLint, GLint, GLsizei, void> glCopyColorSubTableEXT;
        /// <summary>void glCopyColorTable(GLenum target, GLenum internalformat, GLint x, GLint y, GLsizei width);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLsizei, void> glCopyColorTable;
        /// <summary>void glCopyColorTableSGI(GLenum target, GLenum internalformat, GLint x, GLint y, GLsizei width);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLsizei, void> glCopyColorTableSGI;
        /// <summary>void glCopyConvolutionFilter1D(GLenum target, GLenum internalformat, GLint x, GLint y, GLsizei width);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLsizei, void> glCopyConvolutionFilter1D;
        /// <summary>void glCopyConvolutionFilter1DEXT(GLenum target, GLenum internalformat, GLint x, GLint y, GLsizei width);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLsizei, void> glCopyConvolutionFilter1DEXT;
        /// <summary>void glCopyConvolutionFilter2D(GLenum target, GLenum internalformat, GLint x, GLint y, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLsizei, GLsizei, void> glCopyConvolutionFilter2D;
        /// <summary>void glCopyConvolutionFilter2DEXT(GLenum target, GLenum internalformat, GLint x, GLint y, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLsizei, GLsizei, void> glCopyConvolutionFilter2DEXT;
        /// <summary>void glCopyImageSubData(GLuint srcName, GLenum srcTarget, GLint srcLevel, GLint srcX, GLint srcY, GLint srcZ, GLuint dstName, GLenum dstTarget, GLint dstLevel, GLint dstX, GLint dstY, GLint dstZ, GLsizei srcWidth, GLsizei srcHeight, GLsizei srcDepth);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLint, GLint, GLuint, GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, void> glCopyImageSubData;
        /// <summary>void glCopyImageSubDataEXT(GLuint srcName, GLenum srcTarget, GLint srcLevel, GLint srcX, GLint srcY, GLint srcZ, GLuint dstName, GLenum dstTarget, GLint dstLevel, GLint dstX, GLint dstY, GLint dstZ, GLsizei srcWidth, GLsizei srcHeight, GLsizei srcDepth);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLint, GLint, GLuint, GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, void> glCopyImageSubDataEXT;
        /// <summary>void glCopyImageSubDataNV(GLuint srcName, GLenum srcTarget, GLint srcLevel, GLint srcX, GLint srcY, GLint srcZ, GLuint dstName, GLenum dstTarget, GLint dstLevel, GLint dstX, GLint dstY, GLint dstZ, GLsizei width, GLsizei height, GLsizei depth);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLint, GLint, GLuint, GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, void> glCopyImageSubDataNV;
        /// <summary>void glCopyImageSubDataOES(GLuint srcName, GLenum srcTarget, GLint srcLevel, GLint srcX, GLint srcY, GLint srcZ, GLuint dstName, GLenum dstTarget, GLint dstLevel, GLint dstX, GLint dstY, GLint dstZ, GLsizei srcWidth, GLsizei srcHeight, GLsizei srcDepth);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLint, GLint, GLuint, GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, void> glCopyImageSubDataOES;
        /// <summary>void glCopyMultiTexImage1DEXT(GLenum texunit, GLenum target, GLint level, GLenum internalformat, GLint x, GLint y, GLsizei width, GLint border);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLenum, GLint, GLint, GLsizei, GLint, void> glCopyMultiTexImage1DEXT;
        /// <summary>void glCopyMultiTexImage2DEXT(GLenum texunit, GLenum target, GLint level, GLenum internalformat, GLint x, GLint y, GLsizei width, GLsizei height, GLint border);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLenum, GLint, GLint, GLsizei, GLsizei, GLint, void> glCopyMultiTexImage2DEXT;
        /// <summary>void glCopyMultiTexSubImage1DEXT(GLenum texunit, GLenum target, GLint level, GLint xoffset, GLint x, GLint y, GLsizei width);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLint, GLint, GLsizei, void> glCopyMultiTexSubImage1DEXT;
        /// <summary>void glCopyMultiTexSubImage2DEXT(GLenum texunit, GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint x, GLint y, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, void> glCopyMultiTexSubImage2DEXT;
        /// <summary>void glCopyMultiTexSubImage3DEXT(GLenum texunit, GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLint x, GLint y, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, void> glCopyMultiTexSubImage3DEXT;
        /// <summary>void glCopyNamedBufferSubData(GLuint readBuffer, GLuint writeBuffer, GLintptr readOffset, GLintptr writeOffset, GLsizeiptr size);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLintptr, GLintptr, GLsizeiptr, void> glCopyNamedBufferSubData;
        /// <summary>void glCopyPathNV(GLuint resultPath, GLuint srcPath);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, void> glCopyPathNV;
        /// <summary>void glCopyPixels(GLint x, GLint y, GLsizei width, GLsizei height, GLenum type);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLsizei, GLsizei, GLenum, void> glCopyPixels;
        /// <summary>void glCopyTexImage1D(GLenum target, GLint level, GLenum internalformat, GLint x, GLint y, GLsizei width, GLint border);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLenum, GLint, GLint, GLsizei, GLint, void> glCopyTexImage1D;
        /// <summary>void glCopyTexImage1DEXT(GLenum target, GLint level, GLenum internalformat, GLint x, GLint y, GLsizei width, GLint border);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLenum, GLint, GLint, GLsizei, GLint, void> glCopyTexImage1DEXT;
        /// <summary>void glCopyTexImage2D(GLenum target, GLint level, GLenum internalformat, GLint x, GLint y, GLsizei width, GLsizei height, GLint border);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLenum, GLint, GLint, GLsizei, GLsizei, GLint, void> glCopyTexImage2D;
        /// <summary>void glCopyTexImage2DEXT(GLenum target, GLint level, GLenum internalformat, GLint x, GLint y, GLsizei width, GLsizei height, GLint border);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLenum, GLint, GLint, GLsizei, GLsizei, GLint, void> glCopyTexImage2DEXT;
        /// <summary>void glCopyTexSubImage1D(GLenum target, GLint level, GLint xoffset, GLint x, GLint y, GLsizei width);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLsizei, void> glCopyTexSubImage1D;
        /// <summary>void glCopyTexSubImage1DEXT(GLenum target, GLint level, GLint xoffset, GLint x, GLint y, GLsizei width);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLsizei, void> glCopyTexSubImage1DEXT;
        /// <summary>void glCopyTexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint x, GLint y, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, void> glCopyTexSubImage2D;
        /// <summary>void glCopyTexSubImage2DEXT(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint x, GLint y, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, void> glCopyTexSubImage2DEXT;
        /// <summary>void glCopyTexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLint x, GLint y, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, void> glCopyTexSubImage3D;
        /// <summary>void glCopyTexSubImage3DEXT(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLint x, GLint y, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, void> glCopyTexSubImage3DEXT;
        /// <summary>void glCopyTexSubImage3DOES(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLint x, GLint y, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, void> glCopyTexSubImage3DOES;
        /// <summary>void glCopyTextureImage1DEXT(GLuint texture, GLenum target, GLint level, GLenum internalformat, GLint x, GLint y, GLsizei width, GLint border);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLenum, GLint, GLint, GLsizei, GLint, void> glCopyTextureImage1DEXT;
        /// <summary>void glCopyTextureImage2DEXT(GLuint texture, GLenum target, GLint level, GLenum internalformat, GLint x, GLint y, GLsizei width, GLsizei height, GLint border);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLenum, GLint, GLint, GLsizei, GLsizei, GLint, void> glCopyTextureImage2DEXT;
        /// <summary>void glCopyTextureLevelsAPPLE(GLuint destinationTexture, GLuint sourceTexture, GLint sourceBaseLevel, GLsizei sourceLevelCount);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLint, GLsizei, void> glCopyTextureLevelsAPPLE;
        /// <summary>void glCopyTextureSubImage1D(GLuint texture, GLint level, GLint xoffset, GLint x, GLint y, GLsizei width);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, GLsizei, void> glCopyTextureSubImage1D;
        /// <summary>void glCopyTextureSubImage1DEXT(GLuint texture, GLenum target, GLint level, GLint xoffset, GLint x, GLint y, GLsizei width);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLint, GLint, GLsizei, void> glCopyTextureSubImage1DEXT;
        /// <summary>void glCopyTextureSubImage2D(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint x, GLint y, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, void> glCopyTextureSubImage2D;
        /// <summary>void glCopyTextureSubImage2DEXT(GLuint texture, GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint x, GLint y, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, void> glCopyTextureSubImage2DEXT;
        /// <summary>void glCopyTextureSubImage3D(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLint x, GLint y, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, void> glCopyTextureSubImage3D;
        /// <summary>void glCopyTextureSubImage3DEXT(GLuint texture, GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLint x, GLint y, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, void> glCopyTextureSubImage3DEXT;
        /// <summary>void glCoverFillPathInstancedNV(GLsizei numPaths, GLenum pathNameType, IntPtr paths, GLuint pathBase, GLenum coverMode, GLenum transformType, GLfloat[] transformValues);</summary>
        public readonly delegate* unmanaged<GLsizei, GLenum, IntPtr, GLuint, GLenum, GLenum, GLfloat[], void> glCoverFillPathInstancedNV;
        /// <summary>void glCoverFillPathNV(GLuint path, GLenum coverMode);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, void> glCoverFillPathNV;
        /// <summary>void glCoverStrokePathInstancedNV(GLsizei numPaths, GLenum pathNameType, IntPtr paths, GLuint pathBase, GLenum coverMode, GLenum transformType, GLfloat[] transformValues);</summary>
        public readonly delegate* unmanaged<GLsizei, GLenum, IntPtr, GLuint, GLenum, GLenum, GLfloat[], void> glCoverStrokePathInstancedNV;
        /// <summary>void glCoverStrokePathNV(GLuint path, GLenum coverMode);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, void> glCoverStrokePathNV;
        /// <summary>void glCoverageMaskNV(GLboolean mask);</summary>
        public readonly delegate* unmanaged<GLboolean, void> glCoverageMaskNV;
        /// <summary>void glCoverageModulationNV(GLenum components);</summary>
        public readonly delegate* unmanaged<GLenum, void> glCoverageModulationNV;
        /// <summary>void glCoverageModulationTableNV(GLsizei n, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLsizei, GLfloat[], void> glCoverageModulationTableNV;
        /// <summary>void glCoverageOperationNV(GLenum operation);</summary>
        public readonly delegate* unmanaged<GLenum, void> glCoverageOperationNV;
        /// <summary>void glCreateBuffers(GLsizei n, GLuint[] buffers);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glCreateBuffers;
        /// <summary>void glCreateCommandListsNV(GLsizei n, GLuint[] lists);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glCreateCommandListsNV;
        /// <summary>void glCreateFramebuffers(GLsizei n, GLuint[] framebuffers);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glCreateFramebuffers;
        /// <summary>void glCreateMemoryObjectsEXT(GLsizei n, GLuint[] memoryObjects);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glCreateMemoryObjectsEXT;
        /// <summary>void glCreatePerfQueryINTEL(GLuint queryId, GLuint[] queryHandle);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint[], void> glCreatePerfQueryINTEL;
        /// <summary>GLuint glCreateProgram();</summary>
        public readonly delegate* unmanaged<GLuint> glCreateProgram;
        /// <summary>GLhandleARB glCreateProgramObjectARB();</summary>
        public readonly delegate* unmanaged<GLhandleARB> glCreateProgramObjectARB;
        /// <summary>void glCreateProgramPipelines(GLsizei n, GLuint[] pipelines);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glCreateProgramPipelines;
        /// <summary>GLuint glCreateProgressFenceNVX();</summary>
        public readonly delegate* unmanaged<GLuint> glCreateProgressFenceNVX;
        /// <summary>void glCreateQueries(GLenum target, GLsizei n, GLuint[] ids);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLuint[], void> glCreateQueries;
        /// <summary>void glCreateRenderbuffers(GLsizei n, GLuint[] renderbuffers);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glCreateRenderbuffers;
        /// <summary>void glCreateSamplers(GLsizei n, GLuint[] samplers);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glCreateSamplers;
        /// <summary>GLuint glCreateShader(GLenum type);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint> glCreateShader;
        /// <summary>GLhandleARB glCreateShaderObjectARB(GLenum shaderType);</summary>
        public readonly delegate* unmanaged<GLenum, GLhandleARB> glCreateShaderObjectARB;
        /// <summary>GLuint glCreateShaderProgramEXT(GLenum type, string string);</summary>
        public readonly delegate* unmanaged<GLenum, string, GLuint> glCreateShaderProgramEXT;
        /// <summary>GLuint glCreateShaderProgramv(GLenum type, GLsizei count, string[] strings);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, string[], GLuint> glCreateShaderProgramv;
        /// <summary>GLuint glCreateShaderProgramvEXT(GLenum type, GLsizei count, string[] strings);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, string[], GLuint> glCreateShaderProgramvEXT;
        /// <summary>void glCreateStatesNV(GLsizei n, GLuint[] states);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glCreateStatesNV;
        /// <summary>GLsync glCreateSyncFromCLeventARB(struct _cl_context[] context, struct _cl_event[] event, GLbitfield flags);</summary>
        public readonly delegate* unmanaged<IntPtr[], IntPtr[], GLbitfield, GLsync> glCreateSyncFromCLeventARB;
        /// <summary>void glCreateTextures(GLenum target, GLsizei n, GLuint[] textures);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLuint[], void> glCreateTextures;
        /// <summary>void glCreateTransformFeedbacks(GLsizei n, GLuint[] ids);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glCreateTransformFeedbacks;
        /// <summary>void glCreateVertexArrays(GLsizei n, GLuint[] arrays);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glCreateVertexArrays;
        /// <summary>void glCullFace(GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, void> glCullFace;
        /// <summary>void glCullParameterdvEXT(GLenum pname, GLdouble[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble[], void> glCullParameterdvEXT;
        /// <summary>void glCullParameterfvEXT(GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glCullParameterfvEXT;
        /// <summary>void glCurrentPaletteMatrixARB(GLint index);</summary>
        public readonly delegate* unmanaged<GLint, void> glCurrentPaletteMatrixARB;
        /// <summary>void glCurrentPaletteMatrixOES(GLuint matrixpaletteindex);</summary>
        public readonly delegate* unmanaged<GLuint, void> glCurrentPaletteMatrixOES;
        /// <summary>void glDebugMessageCallback(GLDEBUGPROC callback, IntPtr userParam);
        /// <para>typedef void (APIENTRY  *GLDEBUGPROC)(GLenum source, GLenum type, GLuint id, GLenum severity, GLsizei length, const GLchar* message, const void* userParam);</para></summary>
        public readonly delegate* unmanaged<delegate*<GLenum, GLenum, GLuint, GLenum, GLsizei, string, IntPtr>, IntPtr, void> glDebugMessageCallback;
        /// <summary>void glDebugMessageCallbackAMD(GLDEBUGPROCAMD callback, IntPtr userParam);
        /// <para>typedef void (APIENTRY  *GLDEBUGPROCAMD)(GLuint id, GLenum category, GLenum severity, GLsizei length, const GLchar* message, void* userParam);</para></summary>
        public readonly delegate* unmanaged<delegate*<GLuint, GLenum, GLenum, GLsizei, string, IntPtr>, IntPtr, void> glDebugMessageCallbackAMD;
        /// <summary>void glDebugMessageCallbackARB(GLDEBUGPROCARB callback, IntPtr userParam);
        /// <para>typedef void (APIENTRY  *GLDEBUGPROCARB)(GLenum source, GLenum type, GLuint id, GLenum severity, GLsizei length, const GLchar* message, const void* userParam);</para></summary>
        public readonly delegate* unmanaged<delegate*<GLenum, GLenum, GLuint, GLenum, GLsizei, string, IntPtr>, IntPtr, void> glDebugMessageCallbackARB;
        /* note: this prototype is provided by AI, check if it's wrong.
                typedef void (GLAPIENTRY *GLDEBUGPROCKHR)(
                    GLenum source,       // 调试消息来源（如GL_DEBUG_SOURCE_API）
                    GLenum type,         // 消息类型（如GL_DEBUG_TYPE_ERROR）
                    GLuint id,           // 消息的唯一标识符
                    GLenum severity,     // 严重程度（如GL_DEBUG_SEVERITY_HIGH）
                    GLsizei length,      // 消息字符串长度（通常为-1，表示以null结尾）
                    const GLchar* message, // 调试消息内容
                    const void* userParam  // 用户自定义参数（通过glDebugMessageCallback设置）
                );
                 */
        /// <summary>void glDebugMessageCallbackKHR(GLDEBUGPROCKHR callback, IntPtr userParam);
        /// <para>typedef void (APIENTRY *GLDEBUGPROCKHR)(GLenum source, GLenum type, GLuint id, GLenum severity, GLsizei length, const GLchar* message, void* userParam);</para></summary>
        public readonly delegate* unmanaged<delegate*<GLenum, GLenum, GLuint, GLenum, GLsizei, string, IntPtr>, IntPtr, void> glDebugMessageCallbackKHR;
        /// <summary>void glDebugMessageControl(GLenum source, GLenum type, GLenum severity, GLsizei count, GLuint[] ids, GLboolean enabled);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLsizei, GLuint[], GLboolean, void> glDebugMessageControl;
        /// <summary>void glDebugMessageControlARB(GLenum source, GLenum type, GLenum severity, GLsizei count, GLuint[] ids, GLboolean enabled);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLsizei, GLuint[], GLboolean, void> glDebugMessageControlARB;
        /// <summary>void glDebugMessageControlKHR(GLenum source, GLenum type, GLenum severity, GLsizei count, GLuint[] ids, GLboolean enabled);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLsizei, GLuint[], GLboolean, void> glDebugMessageControlKHR;
        /// <summary>void glDebugMessageEnableAMD(GLenum category, GLenum severity, GLsizei count, GLuint[] ids, GLboolean enabled);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLsizei, GLuint[], GLboolean, void> glDebugMessageEnableAMD;
        /// <summary>void glDebugMessageInsert(GLenum source, GLenum type, GLuint id, GLenum severity, GLsizei length, string buf);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, GLenum, GLsizei, string, void> glDebugMessageInsert;
        /// <summary>void glDebugMessageInsertAMD(GLenum category, GLenum severity, GLuint id, GLsizei length, string buf);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, GLsizei, string, void> glDebugMessageInsertAMD;
        /// <summary>void glDebugMessageInsertARB(GLenum source, GLenum type, GLuint id, GLenum severity, GLsizei length, string buf);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, GLenum, GLsizei, string, void> glDebugMessageInsertARB;
        /// <summary>void glDebugMessageInsertKHR(GLenum source, GLenum type, GLuint id, GLenum severity, GLsizei length, string buf);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, GLenum, GLsizei, string, void> glDebugMessageInsertKHR;
        /// <summary>void glDeformSGIX(GLbitfield mask);</summary>
        public readonly delegate* unmanaged<GLbitfield, void> glDeformSGIX;
        /// <summary>void glDeformationMap3dSGIX(GLenum target, GLdouble u1, GLdouble u2, GLint ustride, GLint uorder, GLdouble v1, GLdouble v2, GLint vstride, GLint vorder, GLdouble w1, GLdouble w2, GLint wstride, GLint worder, GLdouble[] points);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble, GLdouble, GLint, GLint, GLdouble, GLdouble, GLint, GLint, GLdouble, GLdouble, GLint, GLint, GLdouble[], void> glDeformationMap3dSGIX;
        /// <summary>void glDeformationMap3fSGIX(GLenum target, GLfloat u1, GLfloat u2, GLint ustride, GLint uorder, GLfloat v1, GLfloat v2, GLint vstride, GLint vorder, GLfloat w1, GLfloat w2, GLint wstride, GLint worder, GLfloat[] points);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, GLfloat, GLint, GLint, GLfloat, GLfloat, GLint, GLint, GLfloat, GLfloat, GLint, GLint, GLfloat[], void> glDeformationMap3fSGIX;
        /// <summary>void glDeleteAsyncMarkersSGIX(GLuint marker, GLsizei range);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, void> glDeleteAsyncMarkersSGIX;
        /// <summary>void glDeleteBuffers(GLsizei n, GLuint* buffers);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint*, void> glDeleteBuffers;
        /// <summary>void glDeleteBuffersARB(GLsizei n, GLuint[] buffers);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glDeleteBuffersARB;
        /// <summary>void glDeleteCommandListsNV(GLsizei n, GLuint[] lists);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glDeleteCommandListsNV;
        /// <summary>void glDeleteFencesAPPLE(GLsizei n, GLuint[] fences);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glDeleteFencesAPPLE;
        /// <summary>void glDeleteFencesNV(GLsizei n, GLuint[] fences);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glDeleteFencesNV;
        /// <summary>void glDeleteFragmentShaderATI(GLuint id);</summary>
        public readonly delegate* unmanaged<GLuint, void> glDeleteFragmentShaderATI;
        /// <summary>void glDeleteFramebuffers(GLsizei n, GLuint[] framebuffers);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint*, void> glDeleteFramebuffers;
        /// <summary>void glDeleteFramebuffersEXT(GLsizei n, GLuint[] framebuffers);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glDeleteFramebuffersEXT;
        /// <summary>void glDeleteFramebuffersOES(GLsizei n, GLuint[] framebuffers);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glDeleteFramebuffersOES;
        /// <summary>void glDeleteLists(GLuint list, GLsizei range);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, void> glDeleteLists;
        /// <summary>void glDeleteMemoryObjectsEXT(GLsizei n, GLuint[] memoryObjects);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glDeleteMemoryObjectsEXT;
        /// <summary>void glDeleteNamedStringARB(GLint namelen, string name);</summary>
        public readonly delegate* unmanaged<GLint, string, void> glDeleteNamedStringARB;
        /// <summary>void glDeleteNamesAMD(GLenum identifier, GLuint num, GLuint[] names);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint[], void> glDeleteNamesAMD;
        /// <summary>void glDeleteObjectARB(GLhandleARB obj);</summary>
        public readonly delegate* unmanaged<GLhandleARB, void> glDeleteObjectARB;
        /// <summary>void glDeleteOcclusionQueriesNV(GLsizei n, GLuint[] ids);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glDeleteOcclusionQueriesNV;
        /// <summary>void glDeletePathsNV(GLuint path, GLsizei range);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, void> glDeletePathsNV;
        /// <summary>void glDeletePerfMonitorsAMD(GLsizei n, GLuint[] monitors);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glDeletePerfMonitorsAMD;
        /// <summary>void glDeletePerfQueryINTEL(GLuint queryHandle);</summary>
        public readonly delegate* unmanaged<GLuint, void> glDeletePerfQueryINTEL;
        /// <summary>void glDeleteProgram(GLuint program);</summary>
        public readonly delegate* unmanaged<GLuint, void> glDeleteProgram;
        /// <summary>void glDeleteProgramPipelines(GLsizei n, GLuint[] pipelines);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glDeleteProgramPipelines;
        /// <summary>void glDeleteProgramPipelinesEXT(GLsizei n, GLuint[] pipelines);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glDeleteProgramPipelinesEXT;
        /// <summary>void glDeleteProgramsARB(GLsizei n, GLuint[] programs);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glDeleteProgramsARB;
        /// <summary>void glDeleteProgramsNV(GLsizei n, GLuint[] programs);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glDeleteProgramsNV;
        /// <summary>void glDeleteQueries(GLsizei n, GLuint[] ids);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint*, void> glDeleteQueries;
        /// <summary>void glDeleteQueriesARB(GLsizei n, GLuint[] ids);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glDeleteQueriesARB;
        /// <summary>void glDeleteQueriesEXT(GLsizei n, GLuint[] ids);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glDeleteQueriesEXT;
        /// <summary>void glDeleteQueryResourceTagNV(GLsizei n, GLint[] tagIds);</summary>
        public readonly delegate* unmanaged<GLsizei, GLint[], void> glDeleteQueryResourceTagNV;
        /// <summary>void glDeleteRenderbuffers(GLsizei n, GLuint* renderbuffers);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint*, void> glDeleteRenderbuffers;
        /// <summary>void glDeleteRenderbuffersEXT(GLsizei n, GLuint[] renderbuffers);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glDeleteRenderbuffersEXT;
        /// <summary>void glDeleteRenderbuffersOES(GLsizei n, GLuint[] renderbuffers);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glDeleteRenderbuffersOES;
        /// <summary>void glDeleteSamplers(GLsizei count, GLuint* samplers);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint*, void> glDeleteSamplers;
        /// <summary>void glDeleteSemaphoresEXT(GLsizei n, GLuint[] semaphores);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glDeleteSemaphoresEXT;
        /// <summary>void glDeleteShader(GLuint shader);</summary>
        public readonly delegate* unmanaged<GLuint, void> glDeleteShader;
        /// <summary>void glDeleteStatesNV(GLsizei n, GLuint[] states);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glDeleteStatesNV;
        /// <summary>void glDeleteSync(GLsync sync);</summary>
        public readonly delegate* unmanaged<GLsync, void> glDeleteSync;
        /// <summary>void glDeleteSyncAPPLE(GLsync sync);</summary>
        public readonly delegate* unmanaged<GLsync, void> glDeleteSyncAPPLE;
        /// <summary>void glDeleteTextures(GLsizei n, GLuint* textures);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint*, void> glDeleteTextures;
        /// <summary>void glDeleteTexturesEXT(GLsizei n, GLuint[] textures);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glDeleteTexturesEXT;
        /// <summary>void glDeleteTransformFeedbacks(GLsizei n, GLuint[] ids);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint*, void> glDeleteTransformFeedbacks;
        /// <summary>void glDeleteTransformFeedbacksNV(GLsizei n, GLuint[] ids);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glDeleteTransformFeedbacksNV;
        /// <summary>void glDeleteVertexArrays(GLsizei n, GLuint* arrays);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint*, void> glDeleteVertexArrays;
        /// <summary>void glDeleteVertexArraysAPPLE(GLsizei n, GLuint[] arrays);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glDeleteVertexArraysAPPLE;
        /// <summary>void glDeleteVertexArraysOES(GLsizei n, GLuint[] arrays);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glDeleteVertexArraysOES;
        /// <summary>void glDeleteVertexShaderEXT(GLuint id);</summary>
        public readonly delegate* unmanaged<GLuint, void> glDeleteVertexShaderEXT;
        /// <summary>void glDepthBoundsEXT(GLclampd zmin, GLclampd zmax);</summary>
        public readonly delegate* unmanaged<GLclampd, GLclampd, void> glDepthBoundsEXT;
        /// <summary>void glDepthBoundsdNV(GLdouble zmin, GLdouble zmax);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, void> glDepthBoundsdNV;
        /// <summary>void glDepthFunc(GLenum func);</summary>
        public readonly delegate* unmanaged<GLenum, void> glDepthFunc;
        /// <summary>void glDepthMask(GLboolean flag);</summary>
        public readonly delegate* unmanaged<GLboolean, void> glDepthMask;
        /// <summary>void glDepthRange(GLdouble n, GLdouble f);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, void> glDepthRange;
        /// <summary>void glDepthRangeArrayfvNV(GLuint first, GLsizei count, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLfloat[], void> glDepthRangeArrayfvNV;
        /// <summary>void glDepthRangeArrayfvOES(GLuint first, GLsizei count, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLfloat[], void> glDepthRangeArrayfvOES;
        /// <summary>void glDepthRangeArrayv(GLuint first, GLsizei count, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLdouble[], void> glDepthRangeArrayv;
        /// <summary>void glDepthRangeIndexed(GLuint index, GLdouble n, GLdouble f);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble, GLdouble, void> glDepthRangeIndexed;
        /// <summary>void glDepthRangeIndexedfNV(GLuint index, GLfloat n, GLfloat f);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat, GLfloat, void> glDepthRangeIndexedfNV;
        /// <summary>void glDepthRangeIndexedfOES(GLuint index, GLfloat n, GLfloat f);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat, GLfloat, void> glDepthRangeIndexedfOES;
        /// <summary>void glDepthRangedNV(GLdouble zNear, GLdouble zFar);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, void> glDepthRangedNV;
        /// <summary>void glDepthRangef(GLfloat n, GLfloat f);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, void> glDepthRangef;
        /// <summary>void glDepthRangefOES(GLclampf n, GLclampf f);</summary>
        public readonly delegate* unmanaged<GLclampf, GLclampf, void> glDepthRangefOES;
        /// <summary>void glDepthRangex(GLfixed n, GLfixed f);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, void> glDepthRangex;
        /// <summary>void glDepthRangexOES(GLfixed n, GLfixed f);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, void> glDepthRangexOES;
        /// <summary>void glDetachObjectARB(GLhandleARB containerObj, GLhandleARB attachedObj);</summary>
        public readonly delegate* unmanaged<GLhandleARB, GLhandleARB, void> glDetachObjectARB;
        /// <summary>void glDetachShader(GLuint program, GLuint shader);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, void> glDetachShader;
        /// <summary>void glDetailTexFuncSGIS(GLenum target, GLsizei n, GLfloat[] points);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLfloat[], void> glDetailTexFuncSGIS;
        /// <summary>void glDisable(GLenum cap);</summary>
        public readonly delegate* unmanaged<GLenum, void> glDisable;
        /// <summary>void glDisableClientState(GLenum array);</summary>
        public readonly delegate* unmanaged<GLenum, void> glDisableClientState;
        /// <summary>void glDisableClientStateIndexedEXT(GLenum array, GLuint index);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glDisableClientStateIndexedEXT;
        /// <summary>void glDisableClientStateiEXT(GLenum array, GLuint index);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glDisableClientStateiEXT;
        /// <summary>void glDisableDriverControlQCOM(GLuint driverControl);</summary>
        public readonly delegate* unmanaged<GLuint, void> glDisableDriverControlQCOM;
        /// <summary>void glDisableIndexedEXT(GLenum target, GLuint index);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glDisableIndexedEXT;
        /// <summary>void glDisableVariantClientStateEXT(GLuint id);</summary>
        public readonly delegate* unmanaged<GLuint, void> glDisableVariantClientStateEXT;
        /// <summary>void glDisableVertexArrayAttrib(GLuint vaobj, GLuint index);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, void> glDisableVertexArrayAttrib;
        /// <summary>void glDisableVertexArrayAttribEXT(GLuint vaobj, GLuint index);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, void> glDisableVertexArrayAttribEXT;
        /// <summary>void glDisableVertexArrayEXT(GLuint vaobj, GLenum array);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, void> glDisableVertexArrayEXT;
        /// <summary>void glDisableVertexAttribAPPLE(GLuint index, GLenum pname);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, void> glDisableVertexAttribAPPLE;
        /// <summary>void glDisableVertexAttribArray(GLuint index);</summary>
        public readonly delegate* unmanaged<GLuint, void> glDisableVertexAttribArray;
        /// <summary>void glDisableVertexAttribArrayARB(GLuint index);</summary>
        public readonly delegate* unmanaged<GLuint, void> glDisableVertexAttribArrayARB;
        /// <summary>void glDisablei(GLenum target, GLuint index);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glDisablei;
        /// <summary>void glDisableiEXT(GLenum target, GLuint index);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glDisableiEXT;
        /// <summary>void glDisableiNV(GLenum target, GLuint index);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glDisableiNV;
        /// <summary>void glDisableiOES(GLenum target, GLuint index);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glDisableiOES;
        /// <summary>void glDiscardFramebufferEXT(GLenum target, GLsizei numAttachments, GLenum[] attachments);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum[], void> glDiscardFramebufferEXT;
        /// <summary>void glDispatchCompute(GLuint num_groups_x, GLuint num_groups_y, GLuint num_groups_z);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, void> glDispatchCompute;
        /// <summary>void glDispatchComputeGroupSizeARB(GLuint num_groups_x, GLuint num_groups_y, GLuint num_groups_z, GLuint group_size_x, GLuint group_size_y, GLuint group_size_z);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, void> glDispatchComputeGroupSizeARB;
        /// <summary>void glDispatchComputeIndirect(GLintptr indirect);</summary>
        public readonly delegate* unmanaged<GLintptr, void> glDispatchComputeIndirect;
        /// <summary>void glDrawArrays(GLenum mode, GLint first, GLsizei count);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLsizei, void> glDrawArrays;
        /// <summary>void glDrawArraysEXT(GLenum mode, GLint first, GLsizei count);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLsizei, void> glDrawArraysEXT;
        /// <summary>void glDrawArraysIndirect(GLenum mode, IntPtr indirect);</summary>
        public readonly delegate* unmanaged<GLenum, IntPtr, void> glDrawArraysIndirect;
        /// <summary>void glDrawArraysInstanced(GLenum mode, GLint first, GLsizei count, GLsizei instancecount);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLsizei, GLsizei, void> glDrawArraysInstanced;
        /// <summary>void glDrawArraysInstancedANGLE(GLenum mode, GLint first, GLsizei count, GLsizei primcount);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLsizei, GLsizei, void> glDrawArraysInstancedANGLE;
        /// <summary>void glDrawArraysInstancedARB(GLenum mode, GLint first, GLsizei count, GLsizei primcount);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLsizei, GLsizei, void> glDrawArraysInstancedARB;
        /// <summary>void glDrawArraysInstancedBaseInstance(GLenum mode, GLint first, GLsizei count, GLsizei instancecount, GLuint baseinstance);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLsizei, GLsizei, GLuint, void> glDrawArraysInstancedBaseInstance;
        /// <summary>void glDrawArraysInstancedBaseInstanceEXT(GLenum mode, GLint first, GLsizei count, GLsizei instancecount, GLuint baseinstance);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLsizei, GLsizei, GLuint, void> glDrawArraysInstancedBaseInstanceEXT;
        /// <summary>void glDrawArraysInstancedEXT(GLenum mode, GLint start, GLsizei count, GLsizei primcount);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLsizei, GLsizei, void> glDrawArraysInstancedEXT;
        /// <summary>void glDrawArraysInstancedNV(GLenum mode, GLint first, GLsizei count, GLsizei primcount);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLsizei, GLsizei, void> glDrawArraysInstancedNV;
        /// <summary>void glDrawBuffer(GLenum buf);</summary>
        public readonly delegate* unmanaged<GLenum, void> glDrawBuffer;
        /// <summary>void glDrawBuffers(GLsizei n, GLenum* bufs);</summary>
        public readonly delegate* unmanaged<GLsizei, GLenum*, void> glDrawBuffers;
        /// <summary>void glDrawBuffersARB(GLsizei n, GLenum[] bufs);</summary>
        public readonly delegate* unmanaged<GLsizei, GLenum[], void> glDrawBuffersARB;
        /// <summary>void glDrawBuffersATI(GLsizei n, GLenum[] bufs);</summary>
        public readonly delegate* unmanaged<GLsizei, GLenum[], void> glDrawBuffersATI;
        /// <summary>void glDrawBuffersEXT(GLsizei n, GLenum[] bufs);</summary>
        public readonly delegate* unmanaged<GLsizei, GLenum[], void> glDrawBuffersEXT;
        /// <summary>void glDrawBuffersIndexedEXT(GLint n, GLenum[] location, GLint[] indices);</summary>
        public readonly delegate* unmanaged<GLint, GLenum[], GLint[], void> glDrawBuffersIndexedEXT;
        /// <summary>void glDrawBuffersNV(GLsizei n, GLenum[] bufs);</summary>
        public readonly delegate* unmanaged<GLsizei, GLenum[], void> glDrawBuffersNV;
        /// <summary>void glDrawCommandsAddressNV(GLenum primitiveMode, GLuint64[] indirects, GLsizei[] sizes, GLuint count);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint64[], GLsizei[], GLuint, void> glDrawCommandsAddressNV;
        /// <summary>void glDrawCommandsNV(GLenum primitiveMode, GLuint buffer, GLintptr[] indirects, GLsizei[] sizes, GLuint count);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLintptr[], GLsizei[], GLuint, void> glDrawCommandsNV;
        /// <summary>void glDrawCommandsStatesAddressNV(GLuint64[] indirects, GLsizei[] sizes, GLuint[] states, GLuint[] fbos, GLuint count);</summary>
        public readonly delegate* unmanaged<GLuint64[], GLsizei[], GLuint[], GLuint[], GLuint, void> glDrawCommandsStatesAddressNV;
        /// <summary>void glDrawCommandsStatesNV(GLuint buffer, GLintptr[] indirects, GLsizei[] sizes, GLuint[] states, GLuint[] fbos, GLuint count);</summary>
        public readonly delegate* unmanaged<GLuint, GLintptr[], GLsizei[], GLuint[], GLuint[], GLuint, void> glDrawCommandsStatesNV;
        /// <summary>void glDrawElementArrayAPPLE(GLenum mode, GLint first, GLsizei count);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLsizei, void> glDrawElementArrayAPPLE;
        /// <summary>void glDrawElementArrayATI(GLenum mode, GLsizei count);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, void> glDrawElementArrayATI;
        /// <summary>void glDrawElements(GLenum mode, GLsizei count, GLenum type, IntPtr indices);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, void> glDrawElements;
        /// <summary>void glDrawElementsBaseVertex(GLenum mode, GLsizei count, GLenum type, IntPtr indices, GLint basevertex);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLint, void> glDrawElementsBaseVertex;
        /// <summary>void glDrawElementsBaseVertexEXT(GLenum mode, GLsizei count, GLenum type, IntPtr indices, GLint basevertex);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLint, void> glDrawElementsBaseVertexEXT;
        /// <summary>void glDrawElementsBaseVertexOES(GLenum mode, GLsizei count, GLenum type, IntPtr indices, GLint basevertex);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLint, void> glDrawElementsBaseVertexOES;
        /// <summary>void glDrawElementsIndirect(GLenum mode, GLenum type, IntPtr indirect);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, IntPtr, void> glDrawElementsIndirect;
        /// <summary>void glDrawElementsInstanced(GLenum mode, GLsizei count, GLenum type, IntPtr indices, GLsizei instancecount);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLsizei, void> glDrawElementsInstanced;
        /// <summary>void glDrawElementsInstancedANGLE(GLenum mode, GLsizei count, GLenum type, IntPtr indices, GLsizei primcount);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLsizei, void> glDrawElementsInstancedANGLE;
        /// <summary>void glDrawElementsInstancedARB(GLenum mode, GLsizei count, GLenum type, IntPtr indices, GLsizei primcount);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLsizei, void> glDrawElementsInstancedARB;
        /// <summary>void glDrawElementsInstancedBaseInstance(GLenum mode, GLsizei count, GLenum type, IntPtr indices, GLsizei instancecount, GLuint baseinstance);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLsizei, GLuint, void> glDrawElementsInstancedBaseInstance;
        /// <summary>void glDrawElementsInstancedBaseInstanceEXT(GLenum mode, GLsizei count, GLenum type, IntPtr indices, GLsizei instancecount, GLuint baseinstance);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLsizei, GLuint, void> glDrawElementsInstancedBaseInstanceEXT;
        /// <summary>void glDrawElementsInstancedBaseVertex(GLenum mode, GLsizei count, GLenum type, IntPtr indices, GLsizei instancecount, GLint basevertex);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLsizei, GLint, void> glDrawElementsInstancedBaseVertex;
        /// <summary>void glDrawElementsInstancedBaseVertexBaseInstance(GLenum mode, GLsizei count, GLenum type, IntPtr indices, GLsizei instancecount, GLint basevertex, GLuint baseinstance);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLsizei, GLint, GLuint, void> glDrawElementsInstancedBaseVertexBaseInstance;
        /// <summary>void glDrawElementsInstancedBaseVertexBaseInstanceEXT(GLenum mode, GLsizei count, GLenum type, IntPtr indices, GLsizei instancecount, GLint basevertex, GLuint baseinstance);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLsizei, GLint, GLuint, void> glDrawElementsInstancedBaseVertexBaseInstanceEXT;
        /// <summary>void glDrawElementsInstancedBaseVertexEXT(GLenum mode, GLsizei count, GLenum type, IntPtr indices, GLsizei instancecount, GLint basevertex);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLsizei, GLint, void> glDrawElementsInstancedBaseVertexEXT;
        /// <summary>void glDrawElementsInstancedBaseVertexOES(GLenum mode, GLsizei count, GLenum type, IntPtr indices, GLsizei instancecount, GLint basevertex);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLsizei, GLint, void> glDrawElementsInstancedBaseVertexOES;
        /// <summary>void glDrawElementsInstancedEXT(GLenum mode, GLsizei count, GLenum type, IntPtr indices, GLsizei primcount);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLsizei, void> glDrawElementsInstancedEXT;
        /// <summary>void glDrawElementsInstancedNV(GLenum mode, GLsizei count, GLenum type, IntPtr indices, GLsizei primcount);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLsizei, void> glDrawElementsInstancedNV;
        /// <summary>void glDrawMeshArraysSUN(GLenum mode, GLint first, GLsizei count, GLsizei width);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLsizei, GLsizei, void> glDrawMeshArraysSUN;
        /// <summary>void glDrawMeshTasksNV(GLuint first, GLuint count);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, void> glDrawMeshTasksNV;
        /// <summary>void glDrawMeshTasksIndirectNV(GLintptr indirect);</summary>
        public readonly delegate* unmanaged<GLintptr, void> glDrawMeshTasksIndirectNV;
        /// <summary>void glDrawPixels(GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLsizei, GLsizei, GLenum, GLenum, IntPtr, void> glDrawPixels;
        /// <summary>void glDrawRangeElementArrayAPPLE(GLenum mode, GLuint start, GLuint end, GLint first, GLsizei count);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLint, GLsizei, void> glDrawRangeElementArrayAPPLE;
        /// <summary>void glDrawRangeElementArrayATI(GLenum mode, GLuint start, GLuint end, GLsizei count);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLsizei, void> glDrawRangeElementArrayATI;
        /// <summary>void glDrawRangeElements(GLenum mode, GLuint start, GLuint end, GLsizei count, GLenum type, IntPtr indices);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLsizei, GLenum, IntPtr, void> glDrawRangeElements;
        /// <summary>void glDrawRangeElementsBaseVertex(GLenum mode, GLuint start, GLuint end, GLsizei count, GLenum type, IntPtr indices, GLint basevertex);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLsizei, GLenum, IntPtr, GLint, void> glDrawRangeElementsBaseVertex;
        /// <summary>void glDrawRangeElementsBaseVertexEXT(GLenum mode, GLuint start, GLuint end, GLsizei count, GLenum type, IntPtr indices, GLint basevertex);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLsizei, GLenum, IntPtr, GLint, void> glDrawRangeElementsBaseVertexEXT;
        /// <summary>void glDrawRangeElementsBaseVertexOES(GLenum mode, GLuint start, GLuint end, GLsizei count, GLenum type, IntPtr indices, GLint basevertex);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLsizei, GLenum, IntPtr, GLint, void> glDrawRangeElementsBaseVertexOES;
        /// <summary>void glDrawRangeElementsEXT(GLenum mode, GLuint start, GLuint end, GLsizei count, GLenum type, IntPtr indices);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLsizei, GLenum, IntPtr, void> glDrawRangeElementsEXT;
        /// <summary>void glDrawTexfOES(GLfloat x, GLfloat y, GLfloat z, GLfloat width, GLfloat height);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glDrawTexfOES;
        /// <summary>void glDrawTexfvOES(GLfloat[] coords);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glDrawTexfvOES;
        /// <summary>void glDrawTexiOES(GLint x, GLint y, GLint z, GLint width, GLint height);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, GLint, GLint, void> glDrawTexiOES;
        /// <summary>void glDrawTexivOES(GLint[] coords);</summary>
        public readonly delegate* unmanaged<GLint[], void> glDrawTexivOES;
        /// <summary>void glDrawTexsOES(GLshort x, GLshort y, GLshort z, GLshort width, GLshort height);</summary>
        public readonly delegate* unmanaged<GLshort, GLshort, GLshort, GLshort, GLshort, void> glDrawTexsOES;
        /// <summary>void glDrawTexsvOES(GLshort[] coords);</summary>
        public readonly delegate* unmanaged<GLshort[], void> glDrawTexsvOES;
        /// <summary>void glDrawTextureNV(GLuint texture, GLuint sampler, GLfloat x0, GLfloat y0, GLfloat x1, GLfloat y1, GLfloat z, GLfloat s0, GLfloat t0, GLfloat s1, GLfloat t1);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glDrawTextureNV;
        /// <summary>void glDrawTexxOES(GLfixed x, GLfixed y, GLfixed z, GLfixed width, GLfixed height);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, GLfixed, void> glDrawTexxOES;
        /// <summary>void glDrawTexxvOES(GLfixed[] coords);</summary>
        public readonly delegate* unmanaged<GLfixed[], void> glDrawTexxvOES;
        /// <summary>void glDrawTransformFeedback(GLenum mode, GLuint id);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glDrawTransformFeedback;
        /// <summary>void glDrawTransformFeedbackEXT(GLenum mode, GLuint id);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glDrawTransformFeedbackEXT;
        /// <summary>void glDrawTransformFeedbackInstanced(GLenum mode, GLuint id, GLsizei instancecount);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLsizei, void> glDrawTransformFeedbackInstanced;
        /// <summary>void glDrawTransformFeedbackInstancedEXT(GLenum mode, GLuint id, GLsizei instancecount);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLsizei, void> glDrawTransformFeedbackInstancedEXT;
        /// <summary>void glDrawTransformFeedbackNV(GLenum mode, GLuint id);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glDrawTransformFeedbackNV;
        /// <summary>void glDrawTransformFeedbackStream(GLenum mode, GLuint id, GLuint stream);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, void> glDrawTransformFeedbackStream;
        /// <summary>void glDrawTransformFeedbackStreamInstanced(GLenum mode, GLuint id, GLuint stream, GLsizei instancecount);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLsizei, void> glDrawTransformFeedbackStreamInstanced;
        /// <summary>void glEGLImageTargetRenderbufferStorageOES(GLenum target, GLeglImageOES image);</summary>
        public readonly delegate* unmanaged<GLenum, GLeglImageOES, void> glEGLImageTargetRenderbufferStorageOES;
        /// <summary>void glEGLImageTargetTexStorageEXT(GLenum target, GLeglImageOES image, GLint[] attrib_list);</summary>
        public readonly delegate* unmanaged<GLenum, GLeglImageOES, GLint[], void> glEGLImageTargetTexStorageEXT;
        /// <summary>void glEGLImageTargetTexture2DOES(GLenum target, GLeglImageOES image);</summary>
        public readonly delegate* unmanaged<GLenum, GLeglImageOES, void> glEGLImageTargetTexture2DOES;
        /// <summary>void glEGLImageTargetTextureStorageEXT(GLuint texture, GLeglImageOES image, GLint[] attrib_list);</summary>
        public readonly delegate* unmanaged<GLuint, GLeglImageOES, GLint[], void> glEGLImageTargetTextureStorageEXT;
        /// <summary>void glEdgeFlag(GLboolean flag);</summary>
        public readonly delegate* unmanaged<GLboolean, void> glEdgeFlag;
        /// <summary>void glEdgeFlagFormatNV(GLsizei stride);</summary>
        public readonly delegate* unmanaged<GLsizei, void> glEdgeFlagFormatNV;
        /// <summary>void glEdgeFlagPointer(GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLsizei, IntPtr, void> glEdgeFlagPointer;
        /// <summary>void glEdgeFlagPointerEXT(GLsizei stride, GLsizei count, GLboolean[] pointer);</summary>
        public readonly delegate* unmanaged<GLsizei, GLsizei, GLboolean[], void> glEdgeFlagPointerEXT;
        /// <summary>void glEdgeFlagPointerListIBM(GLint stride, GLboolean[][] pointer, GLint ptrstride);</summary>
        public readonly delegate* unmanaged<GLint, GLboolean[][], GLint, void> glEdgeFlagPointerListIBM;
        /// <summary>void glEdgeFlagv(GLboolean[] flag);</summary>
        public readonly delegate* unmanaged<GLboolean[], void> glEdgeFlagv;
        /// <summary>void glElementPointerAPPLE(GLenum type, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLenum, IntPtr, void> glElementPointerAPPLE;
        /// <summary>void glElementPointerATI(GLenum type, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLenum, IntPtr, void> glElementPointerATI;
        /// <summary>void glEnable(GLenum cap);</summary>
        public readonly delegate* unmanaged<GLenum, void> glEnable;
        /// <summary>void glEnableClientState(GLenum array);</summary>
        public readonly delegate* unmanaged<GLenum, void> glEnableClientState;
        /// <summary>void glEnableClientStateIndexedEXT(GLenum array, GLuint index);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glEnableClientStateIndexedEXT;
        /// <summary>void glEnableClientStateiEXT(GLenum array, GLuint index);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glEnableClientStateiEXT;
        /// <summary>void glEnableDriverControlQCOM(GLuint driverControl);</summary>
        public readonly delegate* unmanaged<GLuint, void> glEnableDriverControlQCOM;
        /// <summary>void glEnableIndexedEXT(GLenum target, GLuint index);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glEnableIndexedEXT;
        /// <summary>void glEnableVariantClientStateEXT(GLuint id);</summary>
        public readonly delegate* unmanaged<GLuint, void> glEnableVariantClientStateEXT;
        /// <summary>void glEnableVertexArrayAttrib(GLuint vaobj, GLuint index);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, void> glEnableVertexArrayAttrib;
        /// <summary>void glEnableVertexArrayAttribEXT(GLuint vaobj, GLuint index);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, void> glEnableVertexArrayAttribEXT;
        /// <summary>void glEnableVertexArrayEXT(GLuint vaobj, GLenum array);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, void> glEnableVertexArrayEXT;
        /// <summary>void glEnableVertexAttribAPPLE(GLuint index, GLenum pname);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, void> glEnableVertexAttribAPPLE;
        /// <summary>void glEnableVertexAttribArray(GLuint index);</summary>
        public readonly delegate* unmanaged<GLuint, void> glEnableVertexAttribArray;
        /// <summary>void glEnableVertexAttribArrayARB(GLuint index);</summary>
        public readonly delegate* unmanaged<GLuint, void> glEnableVertexAttribArrayARB;
        /// <summary>void glEnablei(GLenum target, GLuint index);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glEnablei;
        /// <summary>void glEnableiEXT(GLenum target, GLuint index);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glEnableiEXT;
        /// <summary>void glEnableiNV(GLenum target, GLuint index);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glEnableiNV;
        /// <summary>void glEnableiOES(GLenum target, GLuint index);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glEnableiOES;
        /// <summary>void glEnd();</summary>
        public readonly delegate* unmanaged<void> glEnd;
        /// <summary>void glEndConditionalRender();</summary>
        public readonly delegate* unmanaged<void> glEndConditionalRender;
        /// <summary>void glEndConditionalRenderNV();</summary>
        public readonly delegate* unmanaged<void> glEndConditionalRenderNV;
        /// <summary>void glEndConditionalRenderNVX();</summary>
        public readonly delegate* unmanaged<void> glEndConditionalRenderNVX;
        /// <summary>void glEndFragmentShaderATI();</summary>
        public readonly delegate* unmanaged<void> glEndFragmentShaderATI;
        /// <summary>void glEndList();</summary>
        public readonly delegate* unmanaged<void> glEndList;
        /// <summary>void glEndOcclusionQueryNV();</summary>
        public readonly delegate* unmanaged<void> glEndOcclusionQueryNV;
        /// <summary>void glEndPerfMonitorAMD(GLuint monitor);</summary>
        public readonly delegate* unmanaged<GLuint, void> glEndPerfMonitorAMD;
        /// <summary>void glEndPerfQueryINTEL(GLuint queryHandle);</summary>
        public readonly delegate* unmanaged<GLuint, void> glEndPerfQueryINTEL;
        /// <summary>void glEndQuery(GLenum target);</summary>
        public readonly delegate* unmanaged<GLenum, void> glEndQuery;
        /// <summary>void glEndQueryARB(GLenum target);</summary>
        public readonly delegate* unmanaged<GLenum, void> glEndQueryARB;
        /// <summary>void glEndQueryEXT(GLenum target);</summary>
        public readonly delegate* unmanaged<GLenum, void> glEndQueryEXT;
        /// <summary>void glEndQueryIndexed(GLenum target, GLuint index);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glEndQueryIndexed;
        /// <summary>void glEndTilingQCOM(GLbitfield preserveMask);</summary>
        public readonly delegate* unmanaged<GLbitfield, void> glEndTilingQCOM;
        /// <summary>void glEndTransformFeedback();</summary>
        public readonly delegate* unmanaged<void> glEndTransformFeedback;
        /// <summary>void glEndTransformFeedbackEXT();</summary>
        public readonly delegate* unmanaged<void> glEndTransformFeedbackEXT;
        /// <summary>void glEndTransformFeedbackNV();</summary>
        public readonly delegate* unmanaged<void> glEndTransformFeedbackNV;
        /// <summary>void glEndVertexShaderEXT();</summary>
        public readonly delegate* unmanaged<void> glEndVertexShaderEXT;
        /// <summary>void glEndVideoCaptureNV(GLuint video_capture_slot);</summary>
        public readonly delegate* unmanaged<GLuint, void> glEndVideoCaptureNV;
        /// <summary>void glEvalCoord1d(GLdouble u);</summary>
        public readonly delegate* unmanaged<GLdouble, void> glEvalCoord1d;
        /// <summary>void glEvalCoord1dv(GLdouble[] u);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glEvalCoord1dv;
        /// <summary>void glEvalCoord1f(GLfloat u);</summary>
        public readonly delegate* unmanaged<GLfloat, void> glEvalCoord1f;
        /// <summary>void glEvalCoord1fv(GLfloat[] u);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glEvalCoord1fv;
        /// <summary>void glEvalCoord1xOES(GLfixed u);</summary>
        public readonly delegate* unmanaged<GLfixed, void> glEvalCoord1xOES;
        /// <summary>void glEvalCoord1xvOES(GLfixed[] coords);</summary>
        public readonly delegate* unmanaged<GLfixed[], void> glEvalCoord1xvOES;
        /// <summary>void glEvalCoord2d(GLdouble u, GLdouble v);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, void> glEvalCoord2d;
        /// <summary>void glEvalCoord2dv(GLdouble[] u);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glEvalCoord2dv;
        /// <summary>void glEvalCoord2f(GLfloat u, GLfloat v);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, void> glEvalCoord2f;
        /// <summary>void glEvalCoord2fv(GLfloat[] u);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glEvalCoord2fv;
        /// <summary>void glEvalCoord2xOES(GLfixed u, GLfixed v);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, void> glEvalCoord2xOES;
        /// <summary>void glEvalCoord2xvOES(GLfixed[] coords);</summary>
        public readonly delegate* unmanaged<GLfixed[], void> glEvalCoord2xvOES;
        /// <summary>void glEvalMapsNV(GLenum target, GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, void> glEvalMapsNV;
        /// <summary>void glEvalMesh1(GLenum mode, GLint i1, GLint i2);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, void> glEvalMesh1;
        /// <summary>void glEvalMesh2(GLenum mode, GLint i1, GLint i2, GLint j1, GLint j2);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, void> glEvalMesh2;
        /// <summary>void glEvalPoint1(GLint i);</summary>
        public readonly delegate* unmanaged<GLint, void> glEvalPoint1;
        /// <summary>void glEvalPoint2(GLint i, GLint j);</summary>
        public readonly delegate* unmanaged<GLint, GLint, void> glEvalPoint2;
        /// <summary>void glEvaluateDepthValuesARB();</summary>
        public readonly delegate* unmanaged<void> glEvaluateDepthValuesARB;
        /// <summary>void glExecuteProgramNV(GLenum target, GLuint id, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLfloat[], void> glExecuteProgramNV;
        /// <summary>void glExtGetBufferPointervQCOM(GLenum target, IntPtr params);</summary>
        public readonly delegate* unmanaged<GLenum, IntPtr, void> glExtGetBufferPointervQCOM;
        /// <summary>void glExtGetBuffersQCOM(GLuint[] buffers, GLint maxBuffers, GLint[] numBuffers);</summary>
        public readonly delegate* unmanaged<GLuint[], GLint, GLint[], void> glExtGetBuffersQCOM;
        /// <summary>void glExtGetFramebuffersQCOM(GLuint[] framebuffers, GLint maxFramebuffers, GLint[] numFramebuffers);</summary>
        public readonly delegate* unmanaged<GLuint[], GLint, GLint[], void> glExtGetFramebuffersQCOM;
        /// <summary>void glExtGetProgramBinarySourceQCOM(GLuint program, GLenum shadertype, string source, GLint[] length);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, string, GLint[], void> glExtGetProgramBinarySourceQCOM;
        /// <summary>void glExtGetProgramsQCOM(GLuint[] programs, GLint maxPrograms, GLint[] numPrograms);</summary>
        public readonly delegate* unmanaged<GLuint[], GLint, GLint[], void> glExtGetProgramsQCOM;
        /// <summary>void glExtGetRenderbuffersQCOM(GLuint[] renderbuffers, GLint maxRenderbuffers, GLint[] numRenderbuffers);</summary>
        public readonly delegate* unmanaged<GLuint[], GLint, GLint[], void> glExtGetRenderbuffersQCOM;
        /// <summary>void glExtGetShadersQCOM(GLuint[] shaders, GLint maxShaders, GLint[] numShaders);</summary>
        public readonly delegate* unmanaged<GLuint[], GLint, GLint[], void> glExtGetShadersQCOM;
        /// <summary>void glExtGetTexLevelParameterivQCOM(GLuint texture, GLenum face, GLint level, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLenum, GLint[], void> glExtGetTexLevelParameterivQCOM;
        /// <summary>void glExtGetTexSubImageQCOM(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, IntPtr texels);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void> glExtGetTexSubImageQCOM;
        /// <summary>void glExtGetTexturesQCOM(GLuint[] textures, GLint maxTextures, GLint[] numTextures);</summary>
        public readonly delegate* unmanaged<GLuint[], GLint, GLint[], void> glExtGetTexturesQCOM;
        /// <summary>GLboolean glExtIsProgramBinaryQCOM(GLuint program);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glExtIsProgramBinaryQCOM;
        /// <summary>void glExtTexObjectStateOverrideiQCOM(GLenum target, GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, void> glExtTexObjectStateOverrideiQCOM;
        /// <summary>void glExtractComponentEXT(GLuint res, GLuint src, GLuint num);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, void> glExtractComponentEXT;
        /// <summary>void glFeedbackBuffer(GLsizei size, GLenum type, GLfloat[] buffer);</summary>
        public readonly delegate* unmanaged<GLsizei, GLenum, GLfloat[], void> glFeedbackBuffer;
        /// <summary>void glFeedbackBufferxOES(GLsizei n, GLenum type, GLfixed[] buffer);</summary>
        public readonly delegate* unmanaged<GLsizei, GLenum, GLfixed[], void> glFeedbackBufferxOES;
        /// <summary>GLsync glFenceSync(GLenum condition, GLbitfield flags);</summary>
        public readonly delegate* unmanaged<GLenum, GLbitfield, GLsync> glFenceSync;
        /// <summary>GLsync glFenceSyncAPPLE(GLenum condition, GLbitfield flags);</summary>
        public readonly delegate* unmanaged<GLenum, GLbitfield, GLsync> glFenceSyncAPPLE;
        /// <summary>void glFinalCombinerInputNV(GLenum variable, GLenum input, GLenum mapping, GLenum componentUsage);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLenum, void> glFinalCombinerInputNV;
        /// <summary>void glFinish();</summary>
        public readonly delegate* unmanaged<void> glFinish;
        /// <summary>GLint glFinishAsyncSGIX(GLuint[] markerp);</summary>
        public readonly delegate* unmanaged<GLuint[], GLint> glFinishAsyncSGIX;
        /// <summary>void glFinishFenceAPPLE(GLuint fence);</summary>
        public readonly delegate* unmanaged<GLuint, void> glFinishFenceAPPLE;
        /// <summary>void glFinishFenceNV(GLuint fence);</summary>
        public readonly delegate* unmanaged<GLuint, void> glFinishFenceNV;
        /// <summary>void glFinishObjectAPPLE(GLenum object, GLint name);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, void> glFinishObjectAPPLE;
        /// <summary>void glFinishTextureSUNX();</summary>
        public readonly delegate* unmanaged<void> glFinishTextureSUNX;
        /// <summary>void glFlush();</summary>
        public readonly delegate* unmanaged<void> glFlush;
        /// <summary>void glFlushMappedBufferRange(GLenum target, GLintptr offset, GLsizeiptr length);</summary>
        public readonly delegate* unmanaged<GLenum, GLintptr, GLsizeiptr, void> glFlushMappedBufferRange;
        /// <summary>void glFlushMappedBufferRangeAPPLE(GLenum target, GLintptr offset, GLsizeiptr size);</summary>
        public readonly delegate* unmanaged<GLenum, GLintptr, GLsizeiptr, void> glFlushMappedBufferRangeAPPLE;
        /// <summary>void glFlushMappedBufferRangeEXT(GLenum target, GLintptr offset, GLsizeiptr length);</summary>
        public readonly delegate* unmanaged<GLenum, GLintptr, GLsizeiptr, void> glFlushMappedBufferRangeEXT;
        /// <summary>void glFlushMappedNamedBufferRange(GLuint buffer, GLintptr offset, GLsizeiptr length);</summary>
        public readonly delegate* unmanaged<GLuint, GLintptr, GLsizeiptr, void> glFlushMappedNamedBufferRange;
        /// <summary>void glFlushMappedNamedBufferRangeEXT(GLuint buffer, GLintptr offset, GLsizeiptr length);</summary>
        public readonly delegate* unmanaged<GLuint, GLintptr, GLsizeiptr, void> glFlushMappedNamedBufferRangeEXT;
        /// <summary>void glFlushPixelDataRangeNV(GLenum target);</summary>
        public readonly delegate* unmanaged<GLenum, void> glFlushPixelDataRangeNV;
        /// <summary>void glFlushRasterSGIX();</summary>
        public readonly delegate* unmanaged<void> glFlushRasterSGIX;
        /// <summary>void glFlushStaticDataIBM(GLenum target);</summary>
        public readonly delegate* unmanaged<GLenum, void> glFlushStaticDataIBM;
        /// <summary>void glFlushVertexArrayRangeAPPLE(GLsizei length, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLsizei, IntPtr, void> glFlushVertexArrayRangeAPPLE;
        /// <summary>void glFlushVertexArrayRangeNV();</summary>
        public readonly delegate* unmanaged<void> glFlushVertexArrayRangeNV;
        /// <summary>void glFogCoordFormatNV(GLenum type, GLsizei stride);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, void> glFogCoordFormatNV;
        /// <summary>void glFogCoordPointer(GLenum type, GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, IntPtr, void> glFogCoordPointer;
        /// <summary>void glFogCoordPointerEXT(GLenum type, GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, IntPtr, void> glFogCoordPointerEXT;
        /// <summary>void glFogCoordPointerListIBM(GLenum type, GLint stride, IntPtr pointer, GLint ptrstride);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, IntPtr, GLint, void> glFogCoordPointerListIBM;
        /// <summary>void glFogCoordd(GLdouble coord);</summary>
        public readonly delegate* unmanaged<GLdouble, void> glFogCoordd;
        /// <summary>void glFogCoorddEXT(GLdouble coord);</summary>
        public readonly delegate* unmanaged<GLdouble, void> glFogCoorddEXT;
        /// <summary>void glFogCoorddv(GLdouble[] coord);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glFogCoorddv;
        /// <summary>void glFogCoorddvEXT(GLdouble[] coord);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glFogCoorddvEXT;
        /// <summary>void glFogCoordf(GLfloat coord);</summary>
        public readonly delegate* unmanaged<GLfloat, void> glFogCoordf;
        /// <summary>void glFogCoordfEXT(GLfloat coord);</summary>
        public readonly delegate* unmanaged<GLfloat, void> glFogCoordfEXT;
        /// <summary>void glFogCoordfv(GLfloat[] coord);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glFogCoordfv;
        /// <summary>void glFogCoordfvEXT(GLfloat[] coord);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glFogCoordfvEXT;
        /// <summary>void glFogCoordhNV(GLhalfNV fog);</summary>
        public readonly delegate* unmanaged<GLhalfNV, void> glFogCoordhNV;
        /// <summary>void glFogCoordhvNV(GLhalfNV[] fog);</summary>
        public readonly delegate* unmanaged<GLhalfNV[], void> glFogCoordhvNV;
        /// <summary>void glFogFuncSGIS(GLsizei n, GLfloat[] points);</summary>
        public readonly delegate* unmanaged<GLsizei, GLfloat[], void> glFogFuncSGIS;
        /// <summary>void glFogf(GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, void> glFogf;
        /// <summary>void glFogfv(GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glFogfv;
        /// <summary>void glFogi(GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, void> glFogi;
        /// <summary>void glFogiv(GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLint[], void> glFogiv;
        /// <summary>void glFogx(GLenum pname, GLfixed param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed, void> glFogx;
        /// <summary>void glFogxOES(GLenum pname, GLfixed param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed, void> glFogxOES;
        /// <summary>void glFogxv(GLenum pname, GLfixed[] param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed[], void> glFogxv;
        /// <summary>void glFogxvOES(GLenum pname, GLfixed[] param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed[], void> glFogxvOES;
        /// <summary>void glFragmentColorMaterialSGIX(GLenum face, GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, void> glFragmentColorMaterialSGIX;
        /// <summary>void glFragmentCoverageColorNV(GLuint color);</summary>
        public readonly delegate* unmanaged<GLuint, void> glFragmentCoverageColorNV;
        /// <summary>void glFragmentLightModelfSGIX(GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, void> glFragmentLightModelfSGIX;
        /// <summary>void glFragmentLightModelfvSGIX(GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glFragmentLightModelfvSGIX;
        /// <summary>void glFragmentLightModeliSGIX(GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, void> glFragmentLightModeliSGIX;
        /// <summary>void glFragmentLightModelivSGIX(GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLint[], void> glFragmentLightModelivSGIX;
        /// <summary>void glFragmentLightfSGIX(GLenum light, GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat, void> glFragmentLightfSGIX;
        /// <summary>void glFragmentLightfvSGIX(GLenum light, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glFragmentLightfvSGIX;
        /// <summary>void glFragmentLightiSGIX(GLenum light, GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, void> glFragmentLightiSGIX;
        /// <summary>void glFragmentLightivSGIX(GLenum light, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glFragmentLightivSGIX;
        /// <summary>void glFragmentMaterialfSGIX(GLenum face, GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat, void> glFragmentMaterialfSGIX;
        /// <summary>void glFragmentMaterialfvSGIX(GLenum face, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glFragmentMaterialfvSGIX;
        /// <summary>void glFragmentMaterialiSGIX(GLenum face, GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, void> glFragmentMaterialiSGIX;
        /// <summary>void glFragmentMaterialivSGIX(GLenum face, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glFragmentMaterialivSGIX;
        /// <summary>void glFrameTerminatorGREMEDY();</summary>
        public readonly delegate* unmanaged<void> glFrameTerminatorGREMEDY;
        /// <summary>void glFrameZoomSGIX(GLint factor);</summary>
        public readonly delegate* unmanaged<GLint, void> glFrameZoomSGIX;
        /// <summary>void glFramebufferDrawBufferEXT(GLuint framebuffer, GLenum mode);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, void> glFramebufferDrawBufferEXT;
        /// <summary>void glFramebufferDrawBuffersEXT(GLuint framebuffer, GLsizei n, GLenum[] bufs);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLenum[], void> glFramebufferDrawBuffersEXT;
        /// <summary>void glFramebufferFetchBarrierEXT();</summary>
        public readonly delegate* unmanaged<void> glFramebufferFetchBarrierEXT;
        /// <summary>void glFramebufferFetchBarrierQCOM();</summary>
        public readonly delegate* unmanaged<void> glFramebufferFetchBarrierQCOM;
        /// <summary>void glFramebufferFoveationConfigQCOM(GLuint framebuffer, GLuint numLayers, GLuint focalPointsPerLayer, GLuint requestedFeatures, GLuint[] providedFeatures);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, GLuint, GLuint[], void> glFramebufferFoveationConfigQCOM;
        /// <summary>void glFramebufferFoveationParametersQCOM(GLuint framebuffer, GLuint layer, GLuint focalPoint, GLfloat focalX, GLfloat focalY, GLfloat gainX, GLfloat gainY, GLfloat foveaArea);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glFramebufferFoveationParametersQCOM;
        /// <summary>void glFramebufferParameteri(GLenum target, GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, void> glFramebufferParameteri;
        /// <summary>void glFramebufferPixelLocalStorageSizeEXT(GLuint target, GLsizei size);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, void> glFramebufferPixelLocalStorageSizeEXT;
        /// <summary>void glFramebufferReadBufferEXT(GLuint framebuffer, GLenum mode);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, void> glFramebufferReadBufferEXT;
        /// <summary>void glFramebufferRenderbuffer(GLenum target, GLenum attachment, GLenum renderbuffertarget, GLuint renderbuffer);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, void> glFramebufferRenderbuffer;
        /// <summary>void glFramebufferRenderbufferEXT(GLenum target, GLenum attachment, GLenum renderbuffertarget, GLuint renderbuffer);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, void> glFramebufferRenderbufferEXT;
        /// <summary>void glFramebufferRenderbufferOES(GLenum target, GLenum attachment, GLenum renderbuffertarget, GLuint renderbuffer);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, void> glFramebufferRenderbufferOES;
        /// <summary>void glFramebufferSampleLocationsfvARB(GLenum target, GLuint start, GLsizei count, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLsizei, GLfloat[], void> glFramebufferSampleLocationsfvARB;
        /// <summary>void glFramebufferSampleLocationsfvNV(GLenum target, GLuint start, GLsizei count, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLsizei, GLfloat[], void> glFramebufferSampleLocationsfvNV;
        /// <summary>void glFramebufferSamplePositionsfvAMD(GLenum target, GLuint numsamples, GLuint pixelindex, GLfloat[] values);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLfloat[], void> glFramebufferSamplePositionsfvAMD;
        /// <summary>void glFramebufferTexture(GLenum target, GLenum attachment, GLuint texture, GLint level);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, GLint, void> glFramebufferTexture;
        /// <summary>void glFramebufferTexture1D(GLenum target, GLenum attachment, GLenum textarget, GLuint texture, GLint level);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, GLint, void> glFramebufferTexture1D;
        /// <summary>void glFramebufferTexture1DEXT(GLenum target, GLenum attachment, GLenum textarget, GLuint texture, GLint level);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, GLint, void> glFramebufferTexture1DEXT;
        /// <summary>void glFramebufferTexture2D(GLenum target, GLenum attachment, GLenum textarget, GLuint texture, GLint level);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, GLint, void> glFramebufferTexture2D;
        /// <summary>void glFramebufferTexture2DEXT(GLenum target, GLenum attachment, GLenum textarget, GLuint texture, GLint level);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, GLint, void> glFramebufferTexture2DEXT;
        /// <summary>void glFramebufferTexture2DDownsampleIMG(GLenum target, GLenum attachment, GLenum textarget, GLuint texture, GLint level, GLint xscale, GLint yscale);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, GLint, GLint, GLint, void> glFramebufferTexture2DDownsampleIMG;
        /// <summary>void glFramebufferTexture2DMultisampleEXT(GLenum target, GLenum attachment, GLenum textarget, GLuint texture, GLint level, GLsizei samples);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, GLint, GLsizei, void> glFramebufferTexture2DMultisampleEXT;
        /// <summary>void glFramebufferTexture2DMultisampleIMG(GLenum target, GLenum attachment, GLenum textarget, GLuint texture, GLint level, GLsizei samples);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, GLint, GLsizei, void> glFramebufferTexture2DMultisampleIMG;
        /// <summary>void glFramebufferTexture2DOES(GLenum target, GLenum attachment, GLenum textarget, GLuint texture, GLint level);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, GLint, void> glFramebufferTexture2DOES;
        /// <summary>void glFramebufferTexture3D(GLenum target, GLenum attachment, GLenum textarget, GLuint texture, GLint level, GLint zoffset);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, GLint, GLint, void> glFramebufferTexture3D;
        /// <summary>void glFramebufferTexture3DEXT(GLenum target, GLenum attachment, GLenum textarget, GLuint texture, GLint level, GLint zoffset);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, GLint, GLint, void> glFramebufferTexture3DEXT;
        /// <summary>void glFramebufferTexture3DOES(GLenum target, GLenum attachment, GLenum textarget, GLuint texture, GLint level, GLint zoffset);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, GLint, GLint, void> glFramebufferTexture3DOES;
        /// <summary>void glFramebufferTextureARB(GLenum target, GLenum attachment, GLuint texture, GLint level);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, GLint, void> glFramebufferTextureARB;
        /// <summary>void glFramebufferTextureEXT(GLenum target, GLenum attachment, GLuint texture, GLint level);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, GLint, void> glFramebufferTextureEXT;
        /// <summary>void glFramebufferTextureFaceARB(GLenum target, GLenum attachment, GLuint texture, GLint level, GLenum face);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, GLint, GLenum, void> glFramebufferTextureFaceARB;
        /// <summary>void glFramebufferTextureFaceEXT(GLenum target, GLenum attachment, GLuint texture, GLint level, GLenum face);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, GLint, GLenum, void> glFramebufferTextureFaceEXT;
        /// <summary>void glFramebufferTextureLayer(GLenum target, GLenum attachment, GLuint texture, GLint level, GLint layer);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, GLint, GLint, void> glFramebufferTextureLayer;
        /// <summary>void glFramebufferTextureLayerARB(GLenum target, GLenum attachment, GLuint texture, GLint level, GLint layer);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, GLint, GLint, void> glFramebufferTextureLayerARB;
        /// <summary>void glFramebufferTextureLayerEXT(GLenum target, GLenum attachment, GLuint texture, GLint level, GLint layer);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, GLint, GLint, void> glFramebufferTextureLayerEXT;
        /// <summary>void glFramebufferTextureLayerDownsampleIMG(GLenum target, GLenum attachment, GLuint texture, GLint level, GLint layer, GLint xscale, GLint yscale);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, GLint, GLint, GLint, GLint, void> glFramebufferTextureLayerDownsampleIMG;
        /// <summary>void glFramebufferTextureMultisampleMultiviewOVR(GLenum target, GLenum attachment, GLuint texture, GLint level, GLsizei samples, GLint baseViewIndex, GLsizei numViews);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, GLint, GLsizei, GLint, GLsizei, void> glFramebufferTextureMultisampleMultiviewOVR;
        /// <summary>void glFramebufferTextureMultiviewOVR(GLenum target, GLenum attachment, GLuint texture, GLint level, GLint baseViewIndex, GLsizei numViews);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, GLint, GLint, GLsizei, void> glFramebufferTextureMultiviewOVR;
        /// <summary>void glFramebufferTextureOES(GLenum target, GLenum attachment, GLuint texture, GLint level);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, GLint, void> glFramebufferTextureOES;
        /// <summary>void glFreeObjectBufferATI(GLuint buffer);</summary>
        public readonly delegate* unmanaged<GLuint, void> glFreeObjectBufferATI;
        /// <summary>void glFrontFace(GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, void> glFrontFace;
        /// <summary>void glFrustum(GLdouble left, GLdouble right, GLdouble bottom, GLdouble top, GLdouble zNear, GLdouble zFar);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, GLdouble, GLdouble, GLdouble, GLdouble, void> glFrustum;
        /// <summary>void glFrustumf(GLfloat l, GLfloat r, GLfloat b, GLfloat t, GLfloat n, GLfloat f);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glFrustumf;
        /// <summary>void glFrustumfOES(GLfloat l, GLfloat r, GLfloat b, GLfloat t, GLfloat n, GLfloat f);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glFrustumfOES;
        /// <summary>void glFrustumx(GLfixed l, GLfixed r, GLfixed b, GLfixed t, GLfixed n, GLfixed f);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, GLfixed, GLfixed, void> glFrustumx;
        /// <summary>void glFrustumxOES(GLfixed l, GLfixed r, GLfixed b, GLfixed t, GLfixed n, GLfixed f);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, GLfixed, GLfixed, void> glFrustumxOES;
        /// <summary>GLuint glGenAsyncMarkersSGIX(GLsizei range);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint> glGenAsyncMarkersSGIX;
        /// <summary>void glGenBuffers(GLsizei n, GLuint* buffers);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint*, void> glGenBuffers;
        /// <summary>void glGenBuffersARB(GLsizei n, GLuint[] buffers);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glGenBuffersARB;
        /// <summary>void glGenFencesAPPLE(GLsizei n, GLuint[] fences);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glGenFencesAPPLE;
        /// <summary>void glGenFencesNV(GLsizei n, GLuint[] fences);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glGenFencesNV;
        /// <summary>GLuint glGenFragmentShadersATI(GLuint range);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint> glGenFragmentShadersATI;
        /// <summary>void glGenFramebuffers(GLsizei n, GLuint* framebuffers);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint*, void> glGenFramebuffers;
        /// <summary>void glGenFramebuffersEXT(GLsizei n, GLuint[] framebuffers);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glGenFramebuffersEXT;
        /// <summary>void glGenFramebuffersOES(GLsizei n, GLuint[] framebuffers);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glGenFramebuffersOES;
        /// <summary>GLuint glGenLists(GLsizei range);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint> glGenLists;
        /// <summary>void glGenNamesAMD(GLenum identifier, GLuint num, GLuint[] names);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint[], void> glGenNamesAMD;
        /// <summary>void glGenOcclusionQueriesNV(GLsizei n, GLuint[] ids);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glGenOcclusionQueriesNV;
        /// <summary>GLuint glGenPathsNV(GLsizei range);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint> glGenPathsNV;
        /// <summary>void glGenPerfMonitorsAMD(GLsizei n, GLuint[] monitors);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glGenPerfMonitorsAMD;
        /// <summary>void glGenProgramPipelines(GLsizei n, GLuint[] pipelines);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glGenProgramPipelines;
        /// <summary>void glGenProgramPipelinesEXT(GLsizei n, GLuint[] pipelines);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glGenProgramPipelinesEXT;
        /// <summary>void glGenProgramsARB(GLsizei n, GLuint[] programs);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glGenProgramsARB;
        /// <summary>void glGenProgramsNV(GLsizei n, GLuint[] programs);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glGenProgramsNV;
        /// <summary>void glGenQueries(GLsizei n, GLuint[] ids);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint*, void> glGenQueries;
        /// <summary>void glGenQueriesARB(GLsizei n, GLuint[] ids);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glGenQueriesARB;
        /// <summary>void glGenQueriesEXT(GLsizei n, GLuint[] ids);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glGenQueriesEXT;
        /// <summary>void glGenQueryResourceTagNV(GLsizei n, GLint[] tagIds);</summary>
        public readonly delegate* unmanaged<GLsizei, GLint[], void> glGenQueryResourceTagNV;
        /// <summary>void glGenRenderbuffers(GLsizei n, GLuint* renderbuffers);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint*, void> glGenRenderbuffers;
        /// <summary>void glGenRenderbuffersEXT(GLsizei n, GLuint[] renderbuffers);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glGenRenderbuffersEXT;
        /// <summary>void glGenRenderbuffersOES(GLsizei n, GLuint[] renderbuffers);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glGenRenderbuffersOES;
        /// <summary>void glGenSamplers(GLsizei count, GLuint* samplers);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint*, void> glGenSamplers;
        /// <summary>void glGenSemaphoresEXT(GLsizei n, GLuint[] semaphores);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glGenSemaphoresEXT;
        /// <summary>GLuint glGenSymbolsEXT(GLenum datatype, GLenum storagetype, GLenum range, GLuint components);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, GLuint> glGenSymbolsEXT;
        /// <summary>void glGenTextures(GLsizei n, GLuint* textures);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint*, void> glGenTextures;
        /// <summary>void glGenTexturesEXT(GLsizei n, GLuint[] textures);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glGenTexturesEXT;
        /// <summary>void glGenTransformFeedbacks(GLsizei n, GLuint[] ids);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint*, void> glGenTransformFeedbacks;
        /// <summary>void glGenTransformFeedbacksNV(GLsizei n, GLuint[] ids);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glGenTransformFeedbacksNV;
        /// <summary>void glGenVertexArrays(GLsizei n, GLuint* arrays);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint*, void> glGenVertexArrays;
        /// <summary>void glGenVertexArraysAPPLE(GLsizei n, GLuint[] arrays);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glGenVertexArraysAPPLE;
        /// <summary>void glGenVertexArraysOES(GLsizei n, GLuint[] arrays);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glGenVertexArraysOES;
        /// <summary>GLuint glGenVertexShadersEXT(GLuint range);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint> glGenVertexShadersEXT;
        /// <summary>void glGenerateMipmap(GLenum target);</summary>
        public readonly delegate* unmanaged<GLenum, void> glGenerateMipmap;
        /// <summary>void glGenerateMipmapEXT(GLenum target);</summary>
        public readonly delegate* unmanaged<GLenum, void> glGenerateMipmapEXT;
        /// <summary>void glGenerateMipmapOES(GLenum target);</summary>
        public readonly delegate* unmanaged<GLenum, void> glGenerateMipmapOES;
        /// <summary>void glGenerateMultiTexMipmapEXT(GLenum texunit, GLenum target);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, void> glGenerateMultiTexMipmapEXT;
        /// <summary>void glGenerateTextureMipmap(GLuint texture);</summary>
        public readonly delegate* unmanaged<GLuint, void> glGenerateTextureMipmap;
        /// <summary>void glGenerateTextureMipmapEXT(GLuint texture, GLenum target);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, void> glGenerateTextureMipmapEXT;
        /// <summary>void glGetActiveAtomicCounterBufferiv(GLuint program, GLuint bufferIndex, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLint[], void> glGetActiveAtomicCounterBufferiv;
        /// <summary>void glGetActiveAttrib(GLuint program, GLuint index, GLsizei bufSize, GLsizei[] length, GLint[] size, GLenum[] type, string name);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLsizei, GLsizei[], GLint[], GLenum[], string, void> glGetActiveAttrib;
        /// <summary>void glGetActiveAttribARB(GLhandleARB programObj, GLuint index, GLsizei maxLength, GLsizei[] length, GLint[] size, GLenum[] type, string name);</summary>
        public readonly delegate* unmanaged<GLhandleARB, GLuint, GLsizei, GLsizei[], GLint[], GLenum[], string, void> glGetActiveAttribARB;
        /// <summary>void glGetActiveSubroutineName(GLuint program, GLenum shadertype, GLuint index, GLsizei bufSize, GLsizei[] length, string name);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLsizei, GLsizei[], string, void> glGetActiveSubroutineName;
        /// <summary>void glGetActiveSubroutineUniformName(GLuint program, GLenum shadertype, GLuint index, GLsizei bufSize, GLsizei[] length, string name);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLsizei, GLsizei[], string, void> glGetActiveSubroutineUniformName;
        /// <summary>void glGetActiveSubroutineUniformiv(GLuint program, GLenum shadertype, GLuint index, GLenum pname, GLint[] values);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLenum, GLint[], void> glGetActiveSubroutineUniformiv;
        /// <summary>void glGetActiveUniform(GLuint program, GLuint index, GLsizei bufSize, GLsizei[] length, GLint[] size, GLenum[] type, string name);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLsizei, GLsizei[], GLint[], GLenum[], StringBuilder, void> glGetActiveUniform;
        /// <summary>void glGetActiveUniformARB(GLhandleARB programObj, GLuint index, GLsizei maxLength, GLsizei[] length, GLint[] size, GLenum[] type, string name);</summary>
        public readonly delegate* unmanaged<GLhandleARB, GLuint, GLsizei, GLsizei[], GLint[], GLenum[], string, void> glGetActiveUniformARB;
        /// <summary>void glGetActiveUniformBlockName(GLuint program, GLuint uniformBlockIndex, GLsizei bufSize, GLsizei[] length, string uniformBlockName);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLsizei, GLsizei[], string, void> glGetActiveUniformBlockName;
        /// <summary>void glGetActiveUniformBlockiv(GLuint program, GLuint uniformBlockIndex, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLint[], void> glGetActiveUniformBlockiv;
        /// <summary>void glGetActiveUniformName(GLuint program, GLuint uniformIndex, GLsizei bufSize, GLsizei[] length, string uniformName);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLsizei, GLsizei[], string, void> glGetActiveUniformName;
        /// <summary>void glGetActiveUniformsiv(GLuint program, GLsizei uniformCount, GLuint[] uniformIndices, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLuint[], GLenum, GLint[], void> glGetActiveUniformsiv;
        /// <summary>void glGetActiveVaryingNV(GLuint program, GLuint index, GLsizei bufSize, GLsizei[] length, GLsizei[] size, GLenum[] type, string name);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLsizei, GLsizei[], GLsizei[], GLenum[], string, void> glGetActiveVaryingNV;
        /// <summary>void glGetArrayObjectfvATI(GLenum array, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glGetArrayObjectfvATI;
        /// <summary>void glGetArrayObjectivATI(GLenum array, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetArrayObjectivATI;
        /// <summary>void glGetAttachedObjectsARB(GLhandleARB containerObj, GLsizei maxCount, GLsizei[] count, GLhandleARB[] obj);</summary>
        public readonly delegate* unmanaged<GLhandleARB, GLsizei, GLsizei[], GLhandleARB[], void> glGetAttachedObjectsARB;
        /// <summary>void glGetAttachedShaders(GLuint program, GLsizei maxCount, GLsizei[] count, GLuint[] shaders);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLsizei[], GLuint[], void> glGetAttachedShaders;
        /// <summary>GLint glGetAttribLocation(GLuint program, string name);</summary>
        public readonly delegate* unmanaged<GLuint, string, GLint> glGetAttribLocation;
        /// <summary>GLint glGetAttribLocationARB(GLhandleARB programObj, string name);</summary>
        public readonly delegate* unmanaged<GLhandleARB, string, GLint> glGetAttribLocationARB;
        /// <summary>void glGetBooleanIndexedvEXT(GLenum target, GLuint index, GLboolean[] data);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLboolean[], void> glGetBooleanIndexedvEXT;
        /// <summary>void glGetBooleani_v(GLenum target, GLuint index, GLboolean[] data);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLboolean[], void> glGetBooleani_v;
        /// <summary>void glGetBooleanv(GLenum pname, GLboolean[] data);</summary>
        public readonly delegate* unmanaged<GLenum, GLboolean[], void> glGetBooleanv;
        /// <summary>void glGetBufferParameteri64v(GLenum target, GLenum pname, GLint64[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint64[], void> glGetBufferParameteri64v;
        /// <summary>void glGetBufferParameteriv(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetBufferParameteriv;
        /// <summary>void glGetBufferParameterivARB(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetBufferParameterivARB;
        /// <summary>void glGetBufferParameterui64vNV(GLenum target, GLenum pname, GLuint64EXT[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint64EXT[], void> glGetBufferParameterui64vNV;
        /// <summary>void glGetBufferPointerv(GLenum target, GLenum pname, IntPtr params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, IntPtr, void> glGetBufferPointerv;
        /// <summary>void glGetBufferPointervARB(GLenum target, GLenum pname, IntPtr params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, IntPtr, void> glGetBufferPointervARB;
        /// <summary>void glGetBufferPointervOES(GLenum target, GLenum pname, IntPtr params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, IntPtr, void> glGetBufferPointervOES;
        /// <summary>void glGetBufferSubData(GLenum target, GLintptr offset, GLsizeiptr size, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLenum, GLintptr, GLsizeiptr, IntPtr, void> glGetBufferSubData;
        /// <summary>void glGetBufferSubDataARB(GLenum target, GLintptrARB offset, GLsizeiptrARB size, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLenum, GLintptrARB, GLsizeiptrARB, IntPtr, void> glGetBufferSubDataARB;
        /// <summary>void glGetClipPlane(GLenum plane, GLdouble[] equation);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble[], void> glGetClipPlane;
        /// <summary>void glGetClipPlanef(GLenum plane, GLfloat[] equation);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glGetClipPlanef;
        /// <summary>void glGetClipPlanefOES(GLenum plane, GLfloat[] equation);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glGetClipPlanefOES;
        /// <summary>void glGetClipPlanex(GLenum plane, GLfixed[] equation);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed[], void> glGetClipPlanex;
        /// <summary>void glGetClipPlanexOES(GLenum plane, GLfixed[] equation);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed[], void> glGetClipPlanexOES;
        /// <summary>void glGetColorTable(GLenum target, GLenum format, GLenum type, IntPtr table);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, IntPtr, void> glGetColorTable;
        /// <summary>void glGetColorTableEXT(GLenum target, GLenum format, GLenum type, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, IntPtr, void> glGetColorTableEXT;
        /// <summary>void glGetColorTableParameterfv(GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glGetColorTableParameterfv;
        /// <summary>void glGetColorTableParameterfvEXT(GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glGetColorTableParameterfvEXT;
        /// <summary>void glGetColorTableParameterfvSGI(GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glGetColorTableParameterfvSGI;
        /// <summary>void glGetColorTableParameteriv(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetColorTableParameteriv;
        /// <summary>void glGetColorTableParameterivEXT(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetColorTableParameterivEXT;
        /// <summary>void glGetColorTableParameterivSGI(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetColorTableParameterivSGI;
        /// <summary>void glGetColorTableSGI(GLenum target, GLenum format, GLenum type, IntPtr table);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, IntPtr, void> glGetColorTableSGI;
        /// <summary>void glGetCombinerInputParameterfvNV(GLenum stage, GLenum portion, GLenum variable, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLenum, GLfloat[], void> glGetCombinerInputParameterfvNV;
        /// <summary>void glGetCombinerInputParameterivNV(GLenum stage, GLenum portion, GLenum variable, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLenum, GLint[], void> glGetCombinerInputParameterivNV;
        /// <summary>void glGetCombinerOutputParameterfvNV(GLenum stage, GLenum portion, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLfloat[], void> glGetCombinerOutputParameterfvNV;
        /// <summary>void glGetCombinerOutputParameterivNV(GLenum stage, GLenum portion, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLint[], void> glGetCombinerOutputParameterivNV;
        /// <summary>void glGetCombinerStageParameterfvNV(GLenum stage, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glGetCombinerStageParameterfvNV;
        /// <summary>GLuint glGetCommandHeaderNV(GLenum tokenID, GLuint size);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint> glGetCommandHeaderNV;
        /// <summary>void glGetCompressedMultiTexImageEXT(GLenum texunit, GLenum target, GLint lod, IntPtr img);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, IntPtr, void> glGetCompressedMultiTexImageEXT;
        /// <summary>void glGetCompressedTexImage(GLenum target, GLint level, IntPtr img);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, IntPtr, void> glGetCompressedTexImage;
        /// <summary>void glGetCompressedTexImageARB(GLenum target, GLint level, IntPtr img);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, IntPtr, void> glGetCompressedTexImageARB;
        /// <summary>void glGetCompressedTextureImage(GLuint texture, GLint level, GLsizei bufSize, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, IntPtr, void> glGetCompressedTextureImage;
        /// <summary>void glGetCompressedTextureImageEXT(GLuint texture, GLenum target, GLint lod, IntPtr img);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, IntPtr, void> glGetCompressedTextureImageEXT;
        /// <summary>void glGetCompressedTextureSubImage(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLsizei bufSize, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLsizei, IntPtr, void> glGetCompressedTextureSubImage;
        /// <summary>void glGetConvolutionFilter(GLenum target, GLenum format, GLenum type, IntPtr image);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, IntPtr, void> glGetConvolutionFilter;
        /// <summary>void glGetConvolutionFilterEXT(GLenum target, GLenum format, GLenum type, IntPtr image);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, IntPtr, void> glGetConvolutionFilterEXT;
        /// <summary>void glGetConvolutionParameterfv(GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glGetConvolutionParameterfv;
        /// <summary>void glGetConvolutionParameterfvEXT(GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glGetConvolutionParameterfvEXT;
        /// <summary>void glGetConvolutionParameteriv(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetConvolutionParameteriv;
        /// <summary>void glGetConvolutionParameterivEXT(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetConvolutionParameterivEXT;
        /// <summary>void glGetConvolutionParameterxvOES(GLenum target, GLenum pname, GLfixed[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed[], void> glGetConvolutionParameterxvOES;
        /// <summary>void glGetCoverageModulationTableNV(GLsizei bufSize, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLsizei, GLfloat[], void> glGetCoverageModulationTableNV;
        /// <summary>GLuint glGetDebugMessageLog(GLuint count, GLsizei bufSize, GLenum[] sources, GLenum[] types, GLuint[] ids, GLenum[] severities, GLsizei[] lengths, string messageLog);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLenum[], GLenum[], GLuint[], GLenum[], GLsizei[], string, GLuint> glGetDebugMessageLog;
        /// <summary>GLuint glGetDebugMessageLogAMD(GLuint count, GLsizei bufSize, GLenum[] categories, GLuint[] severities, GLuint[] ids, GLsizei[] lengths, string message);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLenum[], GLuint[], GLuint[], GLsizei[], string, GLuint> glGetDebugMessageLogAMD;
        /// <summary>GLuint glGetDebugMessageLogARB(GLuint count, GLsizei bufSize, GLenum[] sources, GLenum[] types, GLuint[] ids, GLenum[] severities, GLsizei[] lengths, string messageLog);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLenum[], GLenum[], GLuint[], GLenum[], GLsizei[], string, GLuint> glGetDebugMessageLogARB;
        /// <summary>GLuint glGetDebugMessageLogKHR(GLuint count, GLsizei bufSize, GLenum[] sources, GLenum[] types, GLuint[] ids, GLenum[] severities, GLsizei[] lengths, string messageLog);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLenum[], GLenum[], GLuint[], GLenum[], GLsizei[], string, GLuint> glGetDebugMessageLogKHR;
        /// <summary>void glGetDetailTexFuncSGIS(GLenum target, GLfloat[] points);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glGetDetailTexFuncSGIS;
        /// <summary>void glGetDoubleIndexedvEXT(GLenum target, GLuint index, GLdouble[] data);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLdouble[], void> glGetDoubleIndexedvEXT;
        /// <summary>void glGetDoublei_v(GLenum target, GLuint index, GLdouble[] data);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLdouble[], void> glGetDoublei_v;
        /// <summary>void glGetDoublei_vEXT(GLenum pname, GLuint index, GLdouble[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLdouble[], void> glGetDoublei_vEXT;
        /// <summary>void glGetDoublev(GLenum pname, GLdouble[] data);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble*, void> glGetDoublev;
        /// <summary>void glGetDriverControlStringQCOM(GLuint driverControl, GLsizei bufSize, GLsizei[] length, string driverControlString);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLsizei[], string, void> glGetDriverControlStringQCOM;
        /// <summary>void glGetDriverControlsQCOM(GLint[] num, GLsizei size, GLuint[] driverControls);</summary>
        public readonly delegate* unmanaged<GLint[], GLsizei, GLuint[], void> glGetDriverControlsQCOM;
        /// <summary>GLenum glGetError();</summary>
        public readonly delegate* unmanaged<GLenum> glGetError;
        /// <summary>void glGetFenceivNV(GLuint fence, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetFenceivNV;
        /// <summary>void glGetFinalCombinerInputParameterfvNV(GLenum variable, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glGetFinalCombinerInputParameterfvNV;
        /// <summary>void glGetFinalCombinerInputParameterivNV(GLenum variable, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetFinalCombinerInputParameterivNV;
        /// <summary>void glGetFirstPerfQueryIdINTEL(GLuint[] queryId);</summary>
        public readonly delegate* unmanaged<GLuint[], void> glGetFirstPerfQueryIdINTEL;
        /// <summary>void glGetFixedv(GLenum pname, GLfixed[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed[], void> glGetFixedv;
        /// <summary>void glGetFixedvOES(GLenum pname, GLfixed[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed[], void> glGetFixedvOES;
        /// <summary>void glGetFloatIndexedvEXT(GLenum target, GLuint index, GLfloat[] data);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLfloat[], void> glGetFloatIndexedvEXT;
        /// <summary>void glGetFloati_v(GLenum target, GLuint index, GLfloat[] data);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLfloat[], void> glGetFloati_v;
        /// <summary>void glGetFloati_vEXT(GLenum pname, GLuint index, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLfloat[], void> glGetFloati_vEXT;
        /// <summary>void glGetFloati_vNV(GLenum target, GLuint index, GLfloat[] data);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLfloat[], void> glGetFloati_vNV;
        /// <summary>void glGetFloati_vOES(GLenum target, GLuint index, GLfloat[] data);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLfloat[], void> glGetFloati_vOES;
        /// <summary>void glGetFloatv(GLenum pname, GLfloat[] data);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat*, void> glGetFloatv;
        /// <summary>void glGetFogFuncSGIS(GLfloat[] points);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glGetFogFuncSGIS;
        /// <summary>GLint glGetFragDataIndex(GLuint program, string name);</summary>
        public readonly delegate* unmanaged<GLuint, string, GLint> glGetFragDataIndex;
        /// <summary>GLint glGetFragDataIndexEXT(GLuint program, string name);</summary>
        public readonly delegate* unmanaged<GLuint, string, GLint> glGetFragDataIndexEXT;
        /// <summary>GLint glGetFragDataLocation(GLuint program, string name);</summary>
        public readonly delegate* unmanaged<GLuint, string, GLint> glGetFragDataLocation;
        /// <summary>GLint glGetFragDataLocationEXT(GLuint program, string name);</summary>
        public readonly delegate* unmanaged<GLuint, string, GLint> glGetFragDataLocationEXT;
        /// <summary>void glGetFragmentLightfvSGIX(GLenum light, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glGetFragmentLightfvSGIX;
        /// <summary>void glGetFragmentLightivSGIX(GLenum light, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetFragmentLightivSGIX;
        /// <summary>void glGetFragmentMaterialfvSGIX(GLenum face, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glGetFragmentMaterialfvSGIX;
        /// <summary>void glGetFragmentMaterialivSGIX(GLenum face, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetFragmentMaterialivSGIX;
        /// <summary>void glGetFramebufferAttachmentParameteriv(GLenum target, GLenum attachment, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLint[], void> glGetFramebufferAttachmentParameteriv;
        /// <summary>void glGetFramebufferAttachmentParameterivEXT(GLenum target, GLenum attachment, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLint[], void> glGetFramebufferAttachmentParameterivEXT;
        /// <summary>void glGetFramebufferAttachmentParameterivOES(GLenum target, GLenum attachment, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLint[], void> glGetFramebufferAttachmentParameterivOES;
        /// <summary>void glGetFramebufferParameterfvAMD(GLenum target, GLenum pname, GLuint numsamples, GLuint pixelindex, GLsizei size, GLfloat[] values);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, GLuint, GLsizei, GLfloat[], void> glGetFramebufferParameterfvAMD;
        /// <summary>void glGetFramebufferParameteriv(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetFramebufferParameteriv;
        /// <summary>void glGetFramebufferParameterivEXT(GLuint framebuffer, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetFramebufferParameterivEXT;
        /// <summary>GLsizei glGetFramebufferPixelLocalStorageSizeEXT(GLuint target);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei> glGetFramebufferPixelLocalStorageSizeEXT;
        /// <summary>GLenum glGetGraphicsResetStatus();</summary>
        public readonly delegate* unmanaged<GLenum> glGetGraphicsResetStatus;
        /// <summary>GLenum glGetGraphicsResetStatusARB();</summary>
        public readonly delegate* unmanaged<GLenum> glGetGraphicsResetStatusARB;
        /// <summary>GLenum glGetGraphicsResetStatusEXT();</summary>
        public readonly delegate* unmanaged<GLenum> glGetGraphicsResetStatusEXT;
        /// <summary>GLenum glGetGraphicsResetStatusKHR();</summary>
        public readonly delegate* unmanaged<GLenum> glGetGraphicsResetStatusKHR;
        /// <summary>GLhandleARB glGetHandleARB(GLenum pname);</summary>
        public readonly delegate* unmanaged<GLenum, GLhandleARB> glGetHandleARB;
        /// <summary>void glGetHistogram(GLenum target, GLboolean reset, GLenum format, GLenum type, IntPtr values);</summary>
        public readonly delegate* unmanaged<GLenum, GLboolean, GLenum, GLenum, IntPtr, void> glGetHistogram;
        /// <summary>void glGetHistogramEXT(GLenum target, GLboolean reset, GLenum format, GLenum type, IntPtr values);</summary>
        public readonly delegate* unmanaged<GLenum, GLboolean, GLenum, GLenum, IntPtr, void> glGetHistogramEXT;
        /// <summary>void glGetHistogramParameterfv(GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glGetHistogramParameterfv;
        /// <summary>void glGetHistogramParameterfvEXT(GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glGetHistogramParameterfvEXT;
        /// <summary>void glGetHistogramParameteriv(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetHistogramParameteriv;
        /// <summary>void glGetHistogramParameterivEXT(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetHistogramParameterivEXT;
        /// <summary>void glGetHistogramParameterxvOES(GLenum target, GLenum pname, GLfixed[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed[], void> glGetHistogramParameterxvOES;
        /// <summary>GLuint64 glGetImageHandleARB(GLuint texture, GLint level, GLboolean layered, GLint layer, GLenum format);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLboolean, GLint, GLenum, GLuint64> glGetImageHandleARB;
        /// <summary>GLuint64 glGetImageHandleNV(GLuint texture, GLint level, GLboolean layered, GLint layer, GLenum format);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLboolean, GLint, GLenum, GLuint64> glGetImageHandleNV;
        /// <summary>void glGetImageTransformParameterfvHP(GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glGetImageTransformParameterfvHP;
        /// <summary>void glGetImageTransformParameterivHP(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetImageTransformParameterivHP;
        /// <summary>void glGetInfoLogARB(GLhandleARB obj, GLsizei maxLength, GLsizei[] length, string infoLog);</summary>
        public readonly delegate* unmanaged<GLhandleARB, GLsizei, GLsizei[], string, void> glGetInfoLogARB;
        /// <summary>GLint glGetInstrumentsSGIX();</summary>
        public readonly delegate* unmanaged<GLint> glGetInstrumentsSGIX;
        /// <summary>void glGetInteger64i_v(GLenum target, GLuint index, GLint64[] data);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLint64[], void> glGetInteger64i_v;
        /// <summary>void glGetInteger64v(GLenum pname, GLint64[] data);</summary>
        public readonly delegate* unmanaged<GLenum, GLint64[], void> glGetInteger64v;
        /// <summary>void glGetInteger64vAPPLE(GLenum pname, GLint64[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLint64[], void> glGetInteger64vAPPLE;
        /// <summary>void glGetInteger64vEXT(GLenum pname, GLint64[] data);</summary>
        public readonly delegate* unmanaged<GLenum, GLint64[], void> glGetInteger64vEXT;
        /// <summary>void glGetIntegerIndexedvEXT(GLenum target, GLuint index, GLint[] data);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLint[], void> glGetIntegerIndexedvEXT;
        /// <summary>void glGetIntegeri_v(GLenum target, GLuint index, GLint[] data);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLint[], void> glGetIntegeri_v;
        /// <summary>void glGetIntegeri_vEXT(GLenum target, GLuint index, GLint[] data);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLint[], void> glGetIntegeri_vEXT;
        /// <summary>void glGetIntegerui64i_vNV(GLenum value, GLuint index, GLuint64EXT[] result);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint64EXT[], void> glGetIntegerui64i_vNV;
        /// <summary>void glGetIntegerui64vNV(GLenum value, GLuint64EXT[] result);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint64EXT[], void> glGetIntegerui64vNV;
        /// <summary>void glGetIntegerv(GLenum pname, GLint[] data);</summary>
        public readonly delegate* unmanaged<GLenum, GLint*, void> glGetIntegerv;
        /// <summary>void glGetInternalformatSampleivNV(GLenum target, GLenum internalformat, GLsizei samples, GLenum pname, GLsizei count, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLsizei, GLenum, GLsizei, GLint[], void> glGetInternalformatSampleivNV;
        /// <summary>void glGetInternalformati64v(GLenum target, GLenum internalformat, GLenum pname, GLsizei count, GLint64[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLsizei, GLint64[], void> glGetInternalformati64v;
        /// <summary>void glGetInternalformativ(GLenum target, GLenum internalformat, GLenum pname, GLsizei count, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLsizei, GLint[], void> glGetInternalformativ;
        /// <summary>void glGetInvariantBooleanvEXT(GLuint id, GLenum value, GLboolean[] data);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLboolean[], void> glGetInvariantBooleanvEXT;
        /// <summary>void glGetInvariantFloatvEXT(GLuint id, GLenum value, GLfloat[] data);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLfloat[], void> glGetInvariantFloatvEXT;
        /// <summary>void glGetInvariantIntegervEXT(GLuint id, GLenum value, GLint[] data);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetInvariantIntegervEXT;
        /// <summary>void glGetLightfv(GLenum light, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glGetLightfv;
        /// <summary>void glGetLightiv(GLenum light, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetLightiv;
        /// <summary>void glGetLightxOES(GLenum light, GLenum pname, GLfixed[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed[], void> glGetLightxOES;
        /// <summary>void glGetLightxv(GLenum light, GLenum pname, GLfixed[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed[], void> glGetLightxv;
        /// <summary>void glGetLightxvOES(GLenum light, GLenum pname, GLfixed[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed[], void> glGetLightxvOES;
        /// <summary>void glGetListParameterfvSGIX(GLuint list, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLfloat[], void> glGetListParameterfvSGIX;
        /// <summary>void glGetListParameterivSGIX(GLuint list, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetListParameterivSGIX;
        /// <summary>void glGetLocalConstantBooleanvEXT(GLuint id, GLenum value, GLboolean[] data);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLboolean[], void> glGetLocalConstantBooleanvEXT;
        /// <summary>void glGetLocalConstantFloatvEXT(GLuint id, GLenum value, GLfloat[] data);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLfloat[], void> glGetLocalConstantFloatvEXT;
        /// <summary>void glGetLocalConstantIntegervEXT(GLuint id, GLenum value, GLint[] data);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetLocalConstantIntegervEXT;
        /// <summary>void glGetMapAttribParameterfvNV(GLenum target, GLuint index, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLenum, GLfloat[], void> glGetMapAttribParameterfvNV;
        /// <summary>void glGetMapAttribParameterivNV(GLenum target, GLuint index, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLenum, GLint[], void> glGetMapAttribParameterivNV;
        /// <summary>void glGetMapControlPointsNV(GLenum target, GLuint index, GLenum type, GLsizei ustride, GLsizei vstride, GLboolean packed, IntPtr points);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLenum, GLsizei, GLsizei, GLboolean, IntPtr, void> glGetMapControlPointsNV;
        /// <summary>void glGetMapParameterfvNV(GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glGetMapParameterfvNV;
        /// <summary>void glGetMapParameterivNV(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetMapParameterivNV;
        /// <summary>void glGetMapdv(GLenum target, GLenum query, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLdouble[], void> glGetMapdv;
        /// <summary>void glGetMapfv(GLenum target, GLenum query, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glGetMapfv;
        /// <summary>void glGetMapiv(GLenum target, GLenum query, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetMapiv;
        /// <summary>void glGetMapxvOES(GLenum target, GLenum query, GLfixed[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed[], void> glGetMapxvOES;
        /// <summary>void glGetMaterialfv(GLenum face, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glGetMaterialfv;
        /// <summary>void glGetMaterialiv(GLenum face, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetMaterialiv;
        /// <summary>void glGetMaterialxOES(GLenum face, GLenum pname, GLfixed param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed, void> glGetMaterialxOES;
        /// <summary>void glGetMaterialxv(GLenum face, GLenum pname, GLfixed[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed[], void> glGetMaterialxv;
        /// <summary>void glGetMaterialxvOES(GLenum face, GLenum pname, GLfixed[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed[], void> glGetMaterialxvOES;
        /// <summary>void glGetMemoryObjectDetachedResourcesuivNV(GLuint memory, GLenum pname, GLint first, GLsizei count, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLsizei, GLuint[], void> glGetMemoryObjectDetachedResourcesuivNV;
        /// <summary>void glGetMemoryObjectParameterivEXT(GLuint memoryObject, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetMemoryObjectParameterivEXT;
        /// <summary>void glGetMinmax(GLenum target, GLboolean reset, GLenum format, GLenum type, IntPtr values);</summary>
        public readonly delegate* unmanaged<GLenum, GLboolean, GLenum, GLenum, IntPtr, void> glGetMinmax;
        /// <summary>void glGetMinmaxEXT(GLenum target, GLboolean reset, GLenum format, GLenum type, IntPtr values);</summary>
        public readonly delegate* unmanaged<GLenum, GLboolean, GLenum, GLenum, IntPtr, void> glGetMinmaxEXT;
        /// <summary>void glGetMinmaxParameterfv(GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glGetMinmaxParameterfv;
        /// <summary>void glGetMinmaxParameterfvEXT(GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glGetMinmaxParameterfvEXT;
        /// <summary>void glGetMinmaxParameteriv(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetMinmaxParameteriv;
        /// <summary>void glGetMinmaxParameterivEXT(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetMinmaxParameterivEXT;
        /// <summary>void glGetMultiTexEnvfvEXT(GLenum texunit, GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLfloat[], void> glGetMultiTexEnvfvEXT;
        /// <summary>void glGetMultiTexEnvivEXT(GLenum texunit, GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLint[], void> glGetMultiTexEnvivEXT;
        /// <summary>void glGetMultiTexGendvEXT(GLenum texunit, GLenum coord, GLenum pname, GLdouble[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLdouble[], void> glGetMultiTexGendvEXT;
        /// <summary>void glGetMultiTexGenfvEXT(GLenum texunit, GLenum coord, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLfloat[], void> glGetMultiTexGenfvEXT;
        /// <summary>void glGetMultiTexGenivEXT(GLenum texunit, GLenum coord, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLint[], void> glGetMultiTexGenivEXT;
        /// <summary>void glGetMultiTexImageEXT(GLenum texunit, GLenum target, GLint level, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLenum, GLenum, IntPtr, void> glGetMultiTexImageEXT;
        /// <summary>void glGetMultiTexLevelParameterfvEXT(GLenum texunit, GLenum target, GLint level, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLenum, GLfloat[], void> glGetMultiTexLevelParameterfvEXT;
        /// <summary>void glGetMultiTexLevelParameterivEXT(GLenum texunit, GLenum target, GLint level, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLenum, GLint[], void> glGetMultiTexLevelParameterivEXT;
        /// <summary>void glGetMultiTexParameterIivEXT(GLenum texunit, GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLint[], void> glGetMultiTexParameterIivEXT;
        /// <summary>void glGetMultiTexParameterIuivEXT(GLenum texunit, GLenum target, GLenum pname, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLuint[], void> glGetMultiTexParameterIuivEXT;
        /// <summary>void glGetMultiTexParameterfvEXT(GLenum texunit, GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLfloat[], void> glGetMultiTexParameterfvEXT;
        /// <summary>void glGetMultiTexParameterivEXT(GLenum texunit, GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLint[], void> glGetMultiTexParameterivEXT;
        /// <summary>void glGetMultisamplefv(GLenum pname, GLuint index, GLfloat[] val);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLfloat[], void> glGetMultisamplefv;
        /// <summary>void glGetMultisamplefvNV(GLenum pname, GLuint index, GLfloat[] val);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLfloat[], void> glGetMultisamplefvNV;
        /// <summary>void glGetNamedBufferParameteri64v(GLuint buffer, GLenum pname, GLint64[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint64[], void> glGetNamedBufferParameteri64v;
        /// <summary>void glGetNamedBufferParameteriv(GLuint buffer, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetNamedBufferParameteriv;
        /// <summary>void glGetNamedBufferParameterivEXT(GLuint buffer, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetNamedBufferParameterivEXT;
        /// <summary>void glGetNamedBufferParameterui64vNV(GLuint buffer, GLenum pname, GLuint64EXT[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint64EXT[], void> glGetNamedBufferParameterui64vNV;
        /// <summary>void glGetNamedBufferPointerv(GLuint buffer, GLenum pname, IntPtr params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, IntPtr, void> glGetNamedBufferPointerv;
        /// <summary>void glGetNamedBufferPointervEXT(GLuint buffer, GLenum pname, IntPtr params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, IntPtr, void> glGetNamedBufferPointervEXT;
        /// <summary>void glGetNamedBufferSubData(GLuint buffer, GLintptr offset, GLsizeiptr size, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLuint, GLintptr, GLsizeiptr, IntPtr, void> glGetNamedBufferSubData;
        /// <summary>void glGetNamedBufferSubDataEXT(GLuint buffer, GLintptr offset, GLsizeiptr size, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLuint, GLintptr, GLsizeiptr, IntPtr, void> glGetNamedBufferSubDataEXT;
        /// <summary>void glGetNamedFramebufferParameterfvAMD(GLuint framebuffer, GLenum pname, GLuint numsamples, GLuint pixelindex, GLsizei size, GLfloat[] values);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLuint, GLsizei, GLfloat[], void> glGetNamedFramebufferParameterfvAMD;
        /// <summary>void glGetNamedFramebufferAttachmentParameteriv(GLuint framebuffer, GLenum attachment, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLint[], void> glGetNamedFramebufferAttachmentParameteriv;
        /// <summary>void glGetNamedFramebufferAttachmentParameterivEXT(GLuint framebuffer, GLenum attachment, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLint[], void> glGetNamedFramebufferAttachmentParameterivEXT;
        /// <summary>void glGetNamedFramebufferParameteriv(GLuint framebuffer, GLenum pname, GLint[] param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetNamedFramebufferParameteriv;
        /// <summary>void glGetNamedFramebufferParameterivEXT(GLuint framebuffer, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetNamedFramebufferParameterivEXT;
        /// <summary>void glGetNamedProgramLocalParameterIivEXT(GLuint program, GLenum target, GLuint index, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLint[], void> glGetNamedProgramLocalParameterIivEXT;
        /// <summary>void glGetNamedProgramLocalParameterIuivEXT(GLuint program, GLenum target, GLuint index, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLuint[], void> glGetNamedProgramLocalParameterIuivEXT;
        /// <summary>void glGetNamedProgramLocalParameterdvEXT(GLuint program, GLenum target, GLuint index, GLdouble[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLdouble[], void> glGetNamedProgramLocalParameterdvEXT;
        /// <summary>void glGetNamedProgramLocalParameterfvEXT(GLuint program, GLenum target, GLuint index, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLfloat[], void> glGetNamedProgramLocalParameterfvEXT;
        /// <summary>void glGetNamedProgramStringEXT(GLuint program, GLenum target, GLenum pname, IntPtr string);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, IntPtr, void> glGetNamedProgramStringEXT;
        /// <summary>void glGetNamedProgramivEXT(GLuint program, GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLint[], void> glGetNamedProgramivEXT;
        /// <summary>void glGetNamedRenderbufferParameteriv(GLuint renderbuffer, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetNamedRenderbufferParameteriv;
        /// <summary>void glGetNamedRenderbufferParameterivEXT(GLuint renderbuffer, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetNamedRenderbufferParameterivEXT;
        /// <summary>void glGetNamedStringARB(GLint namelen, string name, GLsizei bufSize, GLint[] stringlen, string string);</summary>
        public readonly delegate* unmanaged<GLint, string, GLsizei, GLint[], string, void> glGetNamedStringARB;
        /// <summary>void glGetNamedStringivARB(GLint namelen, string name, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLint, string, GLenum, GLint[], void> glGetNamedStringivARB;
        /// <summary>void glGetNextPerfQueryIdINTEL(GLuint queryId, GLuint[] nextQueryId);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint[], void> glGetNextPerfQueryIdINTEL;
        /// <summary>void glGetObjectBufferfvATI(GLuint buffer, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLfloat[], void> glGetObjectBufferfvATI;
        /// <summary>void glGetObjectBufferivATI(GLuint buffer, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetObjectBufferivATI;
        /// <summary>void glGetObjectLabel(GLenum identifier, GLuint name, GLsizei bufSize, GLsizei[] length, string label);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLsizei, GLsizei[], string, void> glGetObjectLabel;
        /// <summary>void glGetObjectLabelEXT(GLenum type, GLuint object, GLsizei bufSize, GLsizei[] length, string label);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLsizei, GLsizei[], string, void> glGetObjectLabelEXT;
        /// <summary>void glGetObjectLabelKHR(GLenum identifier, GLuint name, GLsizei bufSize, GLsizei[] length, string label);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLsizei, GLsizei[], string, void> glGetObjectLabelKHR;
        /// <summary>void glGetObjectParameterfvARB(GLhandleARB obj, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLhandleARB, GLenum, GLfloat[], void> glGetObjectParameterfvARB;
        /// <summary>void glGetObjectParameterivAPPLE(GLenum objectType, GLuint name, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLenum, GLint[], void> glGetObjectParameterivAPPLE;
        /// <summary>void glGetObjectParameterivARB(GLhandleARB obj, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLhandleARB, GLenum, GLint[], void> glGetObjectParameterivARB;
        /// <summary>void glGetObjectPtrLabel(IntPtr ptr, GLsizei bufSize, GLsizei[] length, string label);</summary>
        public readonly delegate* unmanaged<IntPtr, GLsizei, GLsizei[], string, void> glGetObjectPtrLabel;
        /// <summary>void glGetObjectPtrLabelKHR(IntPtr ptr, GLsizei bufSize, GLsizei[] length, string label);</summary>
        public readonly delegate* unmanaged<IntPtr, GLsizei, GLsizei[], string, void> glGetObjectPtrLabelKHR;
        /// <summary>void glGetOcclusionQueryivNV(GLuint id, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetOcclusionQueryivNV;
        /// <summary>void glGetOcclusionQueryuivNV(GLuint id, GLenum pname, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint[], void> glGetOcclusionQueryuivNV;
        /// <summary>void glGetPathColorGenfvNV(GLenum color, GLenum pname, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glGetPathColorGenfvNV;
        /// <summary>void glGetPathColorGenivNV(GLenum color, GLenum pname, GLint[] value);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetPathColorGenivNV;
        /// <summary>void glGetPathCommandsNV(GLuint path, GLubyte[] commands);</summary>
        public readonly delegate* unmanaged<GLuint, GLubyte[], void> glGetPathCommandsNV;
        /// <summary>void glGetPathCoordsNV(GLuint path, GLfloat[] coords);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat[], void> glGetPathCoordsNV;
        /// <summary>void glGetPathDashArrayNV(GLuint path, GLfloat[] dashArray);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat[], void> glGetPathDashArrayNV;
        /// <summary>GLfloat glGetPathLengthNV(GLuint path, GLsizei startSegment, GLsizei numSegments);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLsizei, GLfloat> glGetPathLengthNV;
        /// <summary>void glGetPathMetricRangeNV(GLbitfield metricQueryMask, GLuint firstPathName, GLsizei numPaths, GLsizei stride, GLfloat[] metrics);</summary>
        public readonly delegate* unmanaged<GLbitfield, GLuint, GLsizei, GLsizei, GLfloat[], void> glGetPathMetricRangeNV;
        /// <summary>void glGetPathMetricsNV(GLbitfield metricQueryMask, GLsizei numPaths, GLenum pathNameType, IntPtr paths, GLuint pathBase, GLsizei stride, GLfloat[] metrics);</summary>
        public readonly delegate* unmanaged<GLbitfield, GLsizei, GLenum, IntPtr, GLuint, GLsizei, GLfloat[], void> glGetPathMetricsNV;
        /// <summary>void glGetPathParameterfvNV(GLuint path, GLenum pname, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLfloat[], void> glGetPathParameterfvNV;
        /// <summary>void glGetPathParameterivNV(GLuint path, GLenum pname, GLint[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetPathParameterivNV;
        /// <summary>void glGetPathSpacingNV(GLenum pathListMode, GLsizei numPaths, GLenum pathNameType, IntPtr paths, GLuint pathBase, GLfloat advanceScale, GLfloat kerningScale, GLenum transformType, GLfloat[] returnedSpacing);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLuint, GLfloat, GLfloat, GLenum, GLfloat[], void> glGetPathSpacingNV;
        /// <summary>void glGetPathTexGenfvNV(GLenum texCoordSet, GLenum pname, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glGetPathTexGenfvNV;
        /// <summary>void glGetPathTexGenivNV(GLenum texCoordSet, GLenum pname, GLint[] value);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetPathTexGenivNV;
        /// <summary>void glGetPerfCounterInfoINTEL(GLuint queryId, GLuint counterId, GLuint counterNameLength, string counterName, GLuint counterDescLength, string counterDesc, GLuint[] counterOffset, GLuint[] counterDataSize, GLuint[] counterTypeEnum, GLuint[] counterDataTypeEnum, GLuint64[] rawCounterMaxValue);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, string, GLuint, string, GLuint[], GLuint[], GLuint[], GLuint[], GLuint64[], void> glGetPerfCounterInfoINTEL;
        /// <summary>void glGetPerfMonitorCounterDataAMD(GLuint monitor, GLenum pname, GLsizei dataSize, GLuint[] data, GLint[] bytesWritten);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLsizei, GLuint[], GLint[], void> glGetPerfMonitorCounterDataAMD;
        /// <summary>void glGetPerfMonitorCounterInfoAMD(GLuint group, GLuint counter, GLenum pname, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, IntPtr, void> glGetPerfMonitorCounterInfoAMD;
        /// <summary>void glGetPerfMonitorCounterStringAMD(GLuint group, GLuint counter, GLsizei bufSize, GLsizei[] length, string counterString);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLsizei, GLsizei[], string, void> glGetPerfMonitorCounterStringAMD;
        /// <summary>void glGetPerfMonitorCountersAMD(GLuint group, GLint[] numCounters, GLint[] maxActiveCounters, GLsizei counterSize, GLuint[] counters);</summary>
        public readonly delegate* unmanaged<GLuint, GLint[], GLint[], GLsizei, GLuint[], void> glGetPerfMonitorCountersAMD;
        /// <summary>void glGetPerfMonitorGroupStringAMD(GLuint group, GLsizei bufSize, GLsizei[] length, string groupString);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLsizei[], string, void> glGetPerfMonitorGroupStringAMD;
        /// <summary>void glGetPerfMonitorGroupsAMD(GLint[] numGroups, GLsizei groupsSize, GLuint[] groups);</summary>
        public readonly delegate* unmanaged<GLint[], GLsizei, GLuint[], void> glGetPerfMonitorGroupsAMD;
        /// <summary>void glGetPerfQueryDataINTEL(GLuint queryHandle, GLuint flags, GLsizei dataSize, IntPtr data, GLuint[] bytesWritten);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLsizei, IntPtr, GLuint[], void> glGetPerfQueryDataINTEL;
        /// <summary>void glGetPerfQueryIdByNameINTEL(string queryName, GLuint[] queryId);</summary>
        public readonly delegate* unmanaged<string, GLuint[], void> glGetPerfQueryIdByNameINTEL;
        /// <summary>void glGetPerfQueryInfoINTEL(GLuint queryId, GLuint queryNameLength, string queryName, GLuint[] dataSize, GLuint[] noCounters, GLuint[] noInstances, GLuint[] capsMask);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, string, GLuint[], GLuint[], GLuint[], GLuint[], void> glGetPerfQueryInfoINTEL;
        /// <summary>void glGetPixelMapfv(GLenum map, GLfloat[] values);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glGetPixelMapfv;
        /// <summary>void glGetPixelMapuiv(GLenum map, GLuint[] values);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint[], void> glGetPixelMapuiv;
        /// <summary>void glGetPixelMapusv(GLenum map, GLushort[] values);</summary>
        public readonly delegate* unmanaged<GLenum, GLushort[], void> glGetPixelMapusv;
        /// <summary>void glGetPixelMapxv(GLenum map, GLint size, GLfixed[] values);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLfixed[], void> glGetPixelMapxv;
        /// <summary>void glGetPixelTexGenParameterfvSGIS(GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glGetPixelTexGenParameterfvSGIS;
        /// <summary>void glGetPixelTexGenParameterivSGIS(GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLint[], void> glGetPixelTexGenParameterivSGIS;
        /// <summary>void glGetPixelTransformParameterfvEXT(GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glGetPixelTransformParameterfvEXT;
        /// <summary>void glGetPixelTransformParameterivEXT(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetPixelTransformParameterivEXT;
        /// <summary>void glGetPointerIndexedvEXT(GLenum target, GLuint index, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, IntPtr, void> glGetPointerIndexedvEXT;
        /// <summary>void glGetPointeri_vEXT(GLenum pname, GLuint index, IntPtr params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, IntPtr, void> glGetPointeri_vEXT;
        /// <summary>void glGetPointerv(GLenum pname, IntPtr params);</summary>
        public readonly delegate* unmanaged<GLenum, IntPtr, void> glGetPointerv;
        /// <summary>void glGetPointervEXT(GLenum pname, IntPtr params);</summary>
        public readonly delegate* unmanaged<GLenum, IntPtr, void> glGetPointervEXT;
        /// <summary>void glGetPointervKHR(GLenum pname, IntPtr params);</summary>
        public readonly delegate* unmanaged<GLenum, IntPtr, void> glGetPointervKHR;
        /// <summary>void glGetPolygonStipple(GLubyte[] mask);</summary>
        public readonly delegate* unmanaged<GLubyte[], void> glGetPolygonStipple;
        /// <summary>void glGetProgramBinary(GLuint program, GLsizei bufSize, GLsizei[] length, GLenum[] binaryFormat, IntPtr binary);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLsizei[], GLenum[], IntPtr, void> glGetProgramBinary;
        /// <summary>void glGetProgramBinaryOES(GLuint program, GLsizei bufSize, GLsizei[] length, GLenum[] binaryFormat, IntPtr binary);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLsizei[], GLenum[], IntPtr, void> glGetProgramBinaryOES;
        /// <summary>void glGetProgramEnvParameterIivNV(GLenum target, GLuint index, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLint[], void> glGetProgramEnvParameterIivNV;
        /// <summary>void glGetProgramEnvParameterIuivNV(GLenum target, GLuint index, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint[], void> glGetProgramEnvParameterIuivNV;
        /// <summary>void glGetProgramEnvParameterdvARB(GLenum target, GLuint index, GLdouble[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLdouble[], void> glGetProgramEnvParameterdvARB;
        /// <summary>void glGetProgramEnvParameterfvARB(GLenum target, GLuint index, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLfloat[], void> glGetProgramEnvParameterfvARB;
        /// <summary>void glGetProgramInfoLog(GLuint program, GLsizei bufSize, GLsizei[] length, string infoLog);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLsizei[], StringBuilder, void> glGetProgramInfoLog;
        /// <summary>void glGetProgramInterfaceiv(GLuint program, GLenum programInterface, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLint*, void> glGetProgramInterfaceiv;
        /// <summary>void glGetProgramLocalParameterIivNV(GLenum target, GLuint index, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLint[], void> glGetProgramLocalParameterIivNV;
        /// <summary>void glGetProgramLocalParameterIuivNV(GLenum target, GLuint index, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint[], void> glGetProgramLocalParameterIuivNV;
        /// <summary>void glGetProgramLocalParameterdvARB(GLenum target, GLuint index, GLdouble[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLdouble[], void> glGetProgramLocalParameterdvARB;
        /// <summary>void glGetProgramLocalParameterfvARB(GLenum target, GLuint index, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLfloat[], void> glGetProgramLocalParameterfvARB;
        /// <summary>void glGetProgramNamedParameterdvNV(GLuint id, GLsizei len, GLubyte[] name, GLdouble[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLubyte[], GLdouble[], void> glGetProgramNamedParameterdvNV;
        /// <summary>void glGetProgramNamedParameterfvNV(GLuint id, GLsizei len, GLubyte[] name, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLubyte[], GLfloat[], void> glGetProgramNamedParameterfvNV;
        /// <summary>void glGetProgramParameterdvNV(GLenum target, GLuint index, GLenum pname, GLdouble[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLenum, GLdouble[], void> glGetProgramParameterdvNV;
        /// <summary>void glGetProgramParameterfvNV(GLenum target, GLuint index, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLenum, GLfloat[], void> glGetProgramParameterfvNV;
        /// <summary>void glGetProgramPipelineInfoLog(GLuint pipeline, GLsizei bufSize, GLsizei[] length, string infoLog);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLsizei[], string, void> glGetProgramPipelineInfoLog;
        /// <summary>void glGetProgramPipelineInfoLogEXT(GLuint pipeline, GLsizei bufSize, GLsizei[] length, string infoLog);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLsizei[], string, void> glGetProgramPipelineInfoLogEXT;
        /// <summary>void glGetProgramPipelineiv(GLuint pipeline, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetProgramPipelineiv;
        /// <summary>void glGetProgramPipelineivEXT(GLuint pipeline, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetProgramPipelineivEXT;
        /// <summary>GLuint glGetProgramResourceIndex(GLuint program, GLenum programInterface, string name);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, string, GLuint> glGetProgramResourceIndex;
        /// <summary>GLint glGetProgramResourceLocation(GLuint program, GLenum programInterface, string name);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, string, GLint> glGetProgramResourceLocation;
        /// <summary>GLint glGetProgramResourceLocationIndex(GLuint program, GLenum programInterface, string name);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, string, GLint> glGetProgramResourceLocationIndex;
        /// <summary>GLint glGetProgramResourceLocationIndexEXT(GLuint program, GLenum programInterface, string name);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, string, GLint> glGetProgramResourceLocationIndexEXT;
        /// <summary>void glGetProgramResourceName(GLuint program, GLenum programInterface, GLuint index, GLsizei bufSize, GLsizei[] length, string name);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLsizei, GLsizei*, StringBuilder, void> glGetProgramResourceName;
        /// <summary>void glGetProgramResourcefvNV(GLuint program, GLenum programInterface, GLuint index, GLsizei propCount, GLenum[] props, GLsizei count, GLsizei[] length, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLsizei, GLenum[], GLsizei, GLsizei[], GLfloat[], void> glGetProgramResourcefvNV;
        /// <summary>void glGetProgramResourceiv(GLuint program, GLenum programInterface, GLuint index, GLsizei propCount, GLenum[] props, GLsizei count, GLsizei[] length, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLsizei, GLenum*, GLsizei, GLsizei*, GLint*, void> glGetProgramResourceiv;
        /// <summary>void glGetProgramStageiv(GLuint program, GLenum shadertype, GLenum pname, GLint[] values);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLint[], void> glGetProgramStageiv;
        /// <summary>void glGetProgramStringARB(GLenum target, GLenum pname, IntPtr string);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, IntPtr, void> glGetProgramStringARB;
        /// <summary>void glGetProgramStringNV(GLuint id, GLenum pname, GLubyte[] program);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLubyte[], void> glGetProgramStringNV;
        /// <summary>void glGetProgramSubroutineParameteruivNV(GLenum target, GLuint index, GLuint[] param);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint[], void> glGetProgramSubroutineParameteruivNV;
        /// <summary>void glGetProgramiv(GLuint program, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint*, void> glGetProgramiv;
        /// <summary>void glGetProgramivARB(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetProgramivARB;
        /// <summary>void glGetProgramivNV(GLuint id, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetProgramivNV;
        /// <summary>void glGetQueryBufferObjecti64v(GLuint id, GLuint buffer, GLenum pname, GLintptr offset);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLintptr, void> glGetQueryBufferObjecti64v;
        /// <summary>void glGetQueryBufferObjectiv(GLuint id, GLuint buffer, GLenum pname, GLintptr offset);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLintptr, void> glGetQueryBufferObjectiv;
        /// <summary>void glGetQueryBufferObjectui64v(GLuint id, GLuint buffer, GLenum pname, GLintptr offset);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLintptr, void> glGetQueryBufferObjectui64v;
        /// <summary>void glGetQueryBufferObjectuiv(GLuint id, GLuint buffer, GLenum pname, GLintptr offset);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLintptr, void> glGetQueryBufferObjectuiv;
        /// <summary>void glGetQueryIndexediv(GLenum target, GLuint index, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLenum, GLint[], void> glGetQueryIndexediv;
        /// <summary>void glGetQueryObjecti64v(GLuint id, GLenum pname, GLint64[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint64[], void> glGetQueryObjecti64v;
        /// <summary>void glGetQueryObjecti64vEXT(GLuint id, GLenum pname, GLint64[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint64[], void> glGetQueryObjecti64vEXT;
        /// <summary>void glGetQueryObjectiv(GLuint id, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint*, void> glGetQueryObjectiv;
        /// <summary>void glGetQueryObjectivARB(GLuint id, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetQueryObjectivARB;
        /// <summary>void glGetQueryObjectivEXT(GLuint id, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetQueryObjectivEXT;
        /// <summary>void glGetQueryObjectui64v(GLuint id, GLenum pname, GLuint64[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint64[], void> glGetQueryObjectui64v;
        /// <summary>void glGetQueryObjectui64vEXT(GLuint id, GLenum pname, GLuint64[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint64[], void> glGetQueryObjectui64vEXT;
        /// <summary>void glGetQueryObjectuiv(GLuint id, GLenum pname, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint[], void> glGetQueryObjectuiv;
        /// <summary>void glGetQueryObjectuivARB(GLuint id, GLenum pname, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint[], void> glGetQueryObjectuivARB;
        /// <summary>void glGetQueryObjectuivEXT(GLuint id, GLenum pname, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint[], void> glGetQueryObjectuivEXT;
        /// <summary>void glGetQueryiv(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetQueryiv;
        /// <summary>void glGetQueryivARB(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetQueryivARB;
        /// <summary>void glGetQueryivEXT(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetQueryivEXT;
        /// <summary>void glGetRenderbufferParameteriv(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetRenderbufferParameteriv;
        /// <summary>void glGetRenderbufferParameterivEXT(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetRenderbufferParameterivEXT;
        /// <summary>void glGetRenderbufferParameterivOES(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetRenderbufferParameterivOES;
        /// <summary>void glGetSamplerParameterIiv(GLuint sampler, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetSamplerParameterIiv;
        /// <summary>void glGetSamplerParameterIivEXT(GLuint sampler, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetSamplerParameterIivEXT;
        /// <summary>void glGetSamplerParameterIivOES(GLuint sampler, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetSamplerParameterIivOES;
        /// <summary>void glGetSamplerParameterIuiv(GLuint sampler, GLenum pname, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint[], void> glGetSamplerParameterIuiv;
        /// <summary>void glGetSamplerParameterIuivEXT(GLuint sampler, GLenum pname, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint[], void> glGetSamplerParameterIuivEXT;
        /// <summary>void glGetSamplerParameterIuivOES(GLuint sampler, GLenum pname, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint[], void> glGetSamplerParameterIuivOES;
        /// <summary>void glGetSamplerParameterfv(GLuint sampler, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLfloat[], void> glGetSamplerParameterfv;
        /// <summary>void glGetSamplerParameteriv(GLuint sampler, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetSamplerParameteriv;
        /// <summary>void glGetSemaphoreParameterui64vEXT(GLuint semaphore, GLenum pname, GLuint64[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint64[], void> glGetSemaphoreParameterui64vEXT;
        /// <summary>void glGetSeparableFilter(GLenum target, GLenum format, GLenum type, IntPtr row, IntPtr column, IntPtr span);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, IntPtr, IntPtr, IntPtr, void> glGetSeparableFilter;
        /// <summary>void glGetSeparableFilterEXT(GLenum target, GLenum format, GLenum type, IntPtr row, IntPtr column, IntPtr span);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, IntPtr, IntPtr, IntPtr, void> glGetSeparableFilterEXT;
        /// <summary>void glGetShaderInfoLog(GLuint shader, GLsizei bufSize, GLsizei[] length, string infoLog);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLsizei[], StringBuilder, void> glGetShaderInfoLog;
        /// <summary>void glGetShaderPrecisionFormat(GLenum shadertype, GLenum precisiontype, GLint[] range, GLint[] precision);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], GLint[], void> glGetShaderPrecisionFormat;
        /// <summary>void glGetShaderSource(GLuint shader, GLsizei bufSize, GLsizei[] length, string source);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLsizei[], string, void> glGetShaderSource;
        /// <summary>void glGetShaderSourceARB(GLhandleARB obj, GLsizei maxLength, GLsizei[] length, string source);</summary>
        public readonly delegate* unmanaged<GLhandleARB, GLsizei, GLsizei[], string, void> glGetShaderSourceARB;
        /// <summary>void glGetShaderiv(GLuint shader, GLenum pname, GLint* params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint*, void> glGetShaderiv;
        /// <summary>void glGetShadingRateImagePaletteNV(GLuint viewport, GLuint entry, GLenum[] rate);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum[], void> glGetShadingRateImagePaletteNV;
        /// <summary>void glGetShadingRateSampleLocationivNV(GLenum rate, GLuint samples, GLuint index, GLint[] location);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLint[], void> glGetShadingRateSampleLocationivNV;
        /// <summary>void glGetSharpenTexFuncSGIS(GLenum target, GLfloat[] points);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glGetSharpenTexFuncSGIS;
        /// <summary>GLushort glGetStageIndexNV(GLenum shadertype);</summary>
        public readonly delegate* unmanaged<GLenum, GLushort> glGetStageIndexNV;
        /// <summary>GLubyte glGetString(GLenum name);</summary>
        public readonly delegate* unmanaged<GLenum, string> glGetString;
        /// <summary>GLubyte glGetStringi(GLenum name, GLuint index);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, string> glGetStringi;
        /// <summary>GLuint glGetSubroutineIndex(GLuint program, GLenum shadertype, string name);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, string, GLuint> glGetSubroutineIndex;
        /// <summary>GLint glGetSubroutineUniformLocation(GLuint program, GLenum shadertype, string name);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, string, GLint> glGetSubroutineUniformLocation;
        /// <summary>void glGetSynciv(GLsync sync, GLenum pname, GLsizei count, GLsizei[] length, GLint[] values);</summary>
        public readonly delegate* unmanaged<GLsync, GLenum, GLsizei, GLsizei*, GLint*, void> glGetSynciv;
        /// <summary>void glGetSyncivAPPLE(GLsync sync, GLenum pname, GLsizei count, GLsizei[] length, GLint[] values);</summary>
        public readonly delegate* unmanaged<GLsync, GLenum, GLsizei, GLsizei[], GLint[], void> glGetSyncivAPPLE;
        /// <summary>void glGetTexBumpParameterfvATI(GLenum pname, GLfloat[] param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glGetTexBumpParameterfvATI;
        /// <summary>void glGetTexBumpParameterivATI(GLenum pname, GLint[] param);</summary>
        public readonly delegate* unmanaged<GLenum, GLint[], void> glGetTexBumpParameterivATI;
        /// <summary>void glGetTexEnvfv(GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glGetTexEnvfv;
        /// <summary>void glGetTexEnviv(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetTexEnviv;
        /// <summary>void glGetTexEnvxv(GLenum target, GLenum pname, GLfixed[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed[], void> glGetTexEnvxv;
        /// <summary>void glGetTexEnvxvOES(GLenum target, GLenum pname, GLfixed[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed[], void> glGetTexEnvxvOES;
        /// <summary>void glGetTexFilterFuncSGIS(GLenum target, GLenum filter, GLfloat[] weights);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glGetTexFilterFuncSGIS;
        /// <summary>void glGetTexGendv(GLenum coord, GLenum pname, GLdouble[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLdouble[], void> glGetTexGendv;
        /// <summary>void glGetTexGenfv(GLenum coord, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glGetTexGenfv;
        /// <summary>void glGetTexGenfvOES(GLenum coord, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glGetTexGenfvOES;
        /// <summary>void glGetTexGeniv(GLenum coord, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetTexGeniv;
        /// <summary>void glGetTexGenivOES(GLenum coord, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetTexGenivOES;
        /// <summary>void glGetTexGenxvOES(GLenum coord, GLenum pname, GLfixed[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed[], void> glGetTexGenxvOES;
        /// <summary>void glGetTexImage(GLenum target, GLint level, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLenum, GLenum, IntPtr, void> glGetTexImage;
        /// <summary>void glGetTexLevelParameterfv(GLenum target, GLint level, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLenum, GLfloat[], void> glGetTexLevelParameterfv;
        /// <summary>void glGetTexLevelParameteriv(GLenum target, GLint level, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLenum, GLint*, void> glGetTexLevelParameteriv;
        /// <summary>void glGetTexLevelParameterxvOES(GLenum target, GLint level, GLenum pname, GLfixed[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLenum, GLfixed[], void> glGetTexLevelParameterxvOES;
        /// <summary>void glGetTexParameterIiv(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetTexParameterIiv;
        /// <summary>void glGetTexParameterIivEXT(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetTexParameterIivEXT;
        /// <summary>void glGetTexParameterIivOES(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetTexParameterIivOES;
        /// <summary>void glGetTexParameterIuiv(GLenum target, GLenum pname, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint[], void> glGetTexParameterIuiv;
        /// <summary>void glGetTexParameterIuivEXT(GLenum target, GLenum pname, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint[], void> glGetTexParameterIuivEXT;
        /// <summary>void glGetTexParameterIuivOES(GLenum target, GLenum pname, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint[], void> glGetTexParameterIuivOES;
        /// <summary>void glGetTexParameterPointervAPPLE(GLenum target, GLenum pname, IntPtr params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, IntPtr, void> glGetTexParameterPointervAPPLE;
        /// <summary>void glGetTexParameterfv(GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glGetTexParameterfv;
        /// <summary>void glGetTexParameteriv(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetTexParameteriv;
        /// <summary>void glGetTexParameterxv(GLenum target, GLenum pname, GLfixed[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed[], void> glGetTexParameterxv;
        /// <summary>void glGetTexParameterxvOES(GLenum target, GLenum pname, GLfixed[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed[], void> glGetTexParameterxvOES;
        /// <summary>GLuint64 glGetTextureHandleARB(GLuint texture);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint64> glGetTextureHandleARB;
        /// <summary>GLuint64 glGetTextureHandleIMG(GLuint texture);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint64> glGetTextureHandleIMG;
        /// <summary>GLuint64 glGetTextureHandleNV(GLuint texture);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint64> glGetTextureHandleNV;
        /// <summary>void glGetTextureImage(GLuint texture, GLint level, GLenum format, GLenum type, GLsizei bufSize, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLenum, GLenum, GLsizei, IntPtr, void> glGetTextureImage;
        /// <summary>void glGetTextureImageEXT(GLuint texture, GLenum target, GLint level, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLenum, GLenum, IntPtr, void> glGetTextureImageEXT;
        /// <summary>void glGetTextureLevelParameterfv(GLuint texture, GLint level, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLenum, GLfloat[], void> glGetTextureLevelParameterfv;
        /// <summary>void glGetTextureLevelParameterfvEXT(GLuint texture, GLenum target, GLint level, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLenum, GLfloat[], void> glGetTextureLevelParameterfvEXT;
        /// <summary>void glGetTextureLevelParameteriv(GLuint texture, GLint level, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLenum, GLint[], void> glGetTextureLevelParameteriv;
        /// <summary>void glGetTextureLevelParameterivEXT(GLuint texture, GLenum target, GLint level, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLenum, GLint[], void> glGetTextureLevelParameterivEXT;
        /// <summary>void glGetTextureParameterIiv(GLuint texture, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetTextureParameterIiv;
        /// <summary>void glGetTextureParameterIivEXT(GLuint texture, GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLint[], void> glGetTextureParameterIivEXT;
        /// <summary>void glGetTextureParameterIuiv(GLuint texture, GLenum pname, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint[], void> glGetTextureParameterIuiv;
        /// <summary>void glGetTextureParameterIuivEXT(GLuint texture, GLenum target, GLenum pname, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLuint[], void> glGetTextureParameterIuivEXT;
        /// <summary>void glGetTextureParameterfv(GLuint texture, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLfloat[], void> glGetTextureParameterfv;
        /// <summary>void glGetTextureParameterfvEXT(GLuint texture, GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLfloat[], void> glGetTextureParameterfvEXT;
        /// <summary>void glGetTextureParameteriv(GLuint texture, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetTextureParameteriv;
        /// <summary>void glGetTextureParameterivEXT(GLuint texture, GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLint[], void> glGetTextureParameterivEXT;
        /// <summary>GLuint64 glGetTextureSamplerHandleARB(GLuint texture, GLuint sampler);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint64> glGetTextureSamplerHandleARB;
        /// <summary>GLuint64 glGetTextureSamplerHandleIMG(GLuint texture, GLuint sampler);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint64> glGetTextureSamplerHandleIMG;
        /// <summary>GLuint64 glGetTextureSamplerHandleNV(GLuint texture, GLuint sampler);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint64> glGetTextureSamplerHandleNV;
        /// <summary>void glGetTextureSubImage(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, GLsizei bufSize, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLenum, GLsizei, IntPtr, void> glGetTextureSubImage;
        /// <summary>void glGetTrackMatrixivNV(GLenum target, GLuint address, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLenum, GLint[], void> glGetTrackMatrixivNV;
        /// <summary>void glGetTransformFeedbackVarying(GLuint program, GLuint index, GLsizei bufSize, GLsizei[] length, GLsizei[] size, GLenum[] type, string name);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLsizei, GLsizei[], GLsizei[], GLenum[], string, void> glGetTransformFeedbackVarying;
        /// <summary>void glGetTransformFeedbackVaryingEXT(GLuint program, GLuint index, GLsizei bufSize, GLsizei[] length, GLsizei[] size, GLenum[] type, string name);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLsizei, GLsizei[], GLsizei[], GLenum[], string, void> glGetTransformFeedbackVaryingEXT;
        /// <summary>void glGetTransformFeedbackVaryingNV(GLuint program, GLuint index, GLint[] location);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLint[], void> glGetTransformFeedbackVaryingNV;
        /// <summary>void glGetTransformFeedbacki64_v(GLuint xfb, GLenum pname, GLuint index, GLint64[] param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLint64[], void> glGetTransformFeedbacki64_v;
        /// <summary>void glGetTransformFeedbacki_v(GLuint xfb, GLenum pname, GLuint index, GLint[] param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLint[], void> glGetTransformFeedbacki_v;
        /// <summary>void glGetTransformFeedbackiv(GLuint xfb, GLenum pname, GLint[] param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetTransformFeedbackiv;
        /// <summary>void glGetTranslatedShaderSourceANGLE(GLuint shader, GLsizei bufSize, GLsizei[] length, string source);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLsizei[], string, void> glGetTranslatedShaderSourceANGLE;
        /// <summary>GLuint glGetUniformBlockIndex(GLuint program, string uniformBlockName);</summary>
        public readonly delegate* unmanaged<GLuint, string, GLuint> glGetUniformBlockIndex;
        /// <summary>GLint glGetUniformBufferSizeEXT(GLuint program, GLint location);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint> glGetUniformBufferSizeEXT;
        /// <summary>void glGetUniformIndices(GLuint program, GLsizei uniformCount, string[] uniformNames, GLuint[] uniformIndices);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, string[], GLuint[], void> glGetUniformIndices;
        /// <summary>GLint glGetUniformLocation(GLuint program, string name);</summary>
        public readonly delegate* unmanaged<GLuint, string, GLint> glGetUniformLocation;
        /// <summary>GLint glGetUniformLocationARB(GLhandleARB programObj, string name);</summary>
        public readonly delegate* unmanaged<GLhandleARB, string, GLint> glGetUniformLocationARB;
        /// <summary>GLintptr glGetUniformOffsetEXT(GLuint program, GLint location);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLintptr> glGetUniformOffsetEXT;
        /// <summary>void glGetUniformSubroutineuiv(GLenum shadertype, GLint location, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLuint[], void> glGetUniformSubroutineuiv;
        /// <summary>void glGetUniformdv(GLuint program, GLint location, GLdouble[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLdouble[], void> glGetUniformdv;
        /// <summary>void glGetUniformfv(GLuint program, GLint location, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLfloat[], void> glGetUniformfv;
        /// <summary>void glGetUniformfvARB(GLhandleARB programObj, GLint location, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLhandleARB, GLint, GLfloat[], void> glGetUniformfvARB;
        /// <summary>void glGetUniformi64vARB(GLuint program, GLint location, GLint64[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint64[], void> glGetUniformi64vARB;
        /// <summary>void glGetUniformi64vNV(GLuint program, GLint location, GLint64EXT[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint64EXT[], void> glGetUniformi64vNV;
        /// <summary>void glGetUniformiv(GLuint program, GLint location, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint[], void> glGetUniformiv;
        /// <summary>void glGetUniformivARB(GLhandleARB programObj, GLint location, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLhandleARB, GLint, GLint[], void> glGetUniformivARB;
        /// <summary>void glGetUniformui64vARB(GLuint program, GLint location, GLuint64[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLuint64[], void> glGetUniformui64vARB;
        /// <summary>void glGetUniformui64vNV(GLuint program, GLint location, GLuint64EXT[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLuint64EXT[], void> glGetUniformui64vNV;
        /// <summary>void glGetUniformuiv(GLuint program, GLint location, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLuint[], void> glGetUniformuiv;
        /// <summary>void glGetUniformuivEXT(GLuint program, GLint location, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLuint[], void> glGetUniformuivEXT;
        /// <summary>void glGetUnsignedBytevEXT(GLenum pname, GLubyte[] data);</summary>
        public readonly delegate* unmanaged<GLenum, GLubyte[], void> glGetUnsignedBytevEXT;
        /// <summary>void glGetUnsignedBytei_vEXT(GLenum target, GLuint index, GLubyte[] data);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLubyte[], void> glGetUnsignedBytei_vEXT;
        /// <summary>void glGetVariantArrayObjectfvATI(GLuint id, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLfloat[], void> glGetVariantArrayObjectfvATI;
        /// <summary>void glGetVariantArrayObjectivATI(GLuint id, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetVariantArrayObjectivATI;
        /// <summary>void glGetVariantBooleanvEXT(GLuint id, GLenum value, GLboolean[] data);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLboolean[], void> glGetVariantBooleanvEXT;
        /// <summary>void glGetVariantFloatvEXT(GLuint id, GLenum value, GLfloat[] data);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLfloat[], void> glGetVariantFloatvEXT;
        /// <summary>void glGetVariantIntegervEXT(GLuint id, GLenum value, GLint[] data);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetVariantIntegervEXT;
        /// <summary>void glGetVariantPointervEXT(GLuint id, GLenum value, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, IntPtr, void> glGetVariantPointervEXT;
        /// <summary>GLint glGetVaryingLocationNV(GLuint program, string name);</summary>
        public readonly delegate* unmanaged<GLuint, string, GLint> glGetVaryingLocationNV;
        /// <summary>void glGetVertexArrayIndexed64iv(GLuint vaobj, GLuint index, GLenum pname, GLint64[] param);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLint64[], void> glGetVertexArrayIndexed64iv;
        /// <summary>void glGetVertexArrayIndexediv(GLuint vaobj, GLuint index, GLenum pname, GLint[] param);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLint[], void> glGetVertexArrayIndexediv;
        /// <summary>void glGetVertexArrayIntegeri_vEXT(GLuint vaobj, GLuint index, GLenum pname, GLint[] param);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLint[], void> glGetVertexArrayIntegeri_vEXT;
        /// <summary>void glGetVertexArrayIntegervEXT(GLuint vaobj, GLenum pname, GLint[] param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetVertexArrayIntegervEXT;
        /// <summary>void glGetVertexArrayPointeri_vEXT(GLuint vaobj, GLuint index, GLenum pname, IntPtr param);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, IntPtr, void> glGetVertexArrayPointeri_vEXT;
        /// <summary>void glGetVertexArrayPointervEXT(GLuint vaobj, GLenum pname, IntPtr param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, IntPtr, void> glGetVertexArrayPointervEXT;
        /// <summary>void glGetVertexArrayiv(GLuint vaobj, GLenum pname, GLint[] param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetVertexArrayiv;
        /// <summary>void glGetVertexAttribArrayObjectfvATI(GLuint index, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLfloat[], void> glGetVertexAttribArrayObjectfvATI;
        /// <summary>void glGetVertexAttribArrayObjectivATI(GLuint index, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetVertexAttribArrayObjectivATI;
        /// <summary>void glGetVertexAttribIiv(GLuint index, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetVertexAttribIiv;
        /// <summary>void glGetVertexAttribIivEXT(GLuint index, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetVertexAttribIivEXT;
        /// <summary>void glGetVertexAttribIuiv(GLuint index, GLenum pname, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint[], void> glGetVertexAttribIuiv;
        /// <summary>void glGetVertexAttribIuivEXT(GLuint index, GLenum pname, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint[], void> glGetVertexAttribIuivEXT;
        /// <summary>void glGetVertexAttribLdv(GLuint index, GLenum pname, GLdouble[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLdouble[], void> glGetVertexAttribLdv;
        /// <summary>void glGetVertexAttribLdvEXT(GLuint index, GLenum pname, GLdouble[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLdouble[], void> glGetVertexAttribLdvEXT;
        /// <summary>void glGetVertexAttribLi64vNV(GLuint index, GLenum pname, GLint64EXT[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint64EXT[], void> glGetVertexAttribLi64vNV;
        /// <summary>void glGetVertexAttribLui64vARB(GLuint index, GLenum pname, GLuint64EXT[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint64EXT[], void> glGetVertexAttribLui64vARB;
        /// <summary>void glGetVertexAttribLui64vNV(GLuint index, GLenum pname, GLuint64EXT[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint64EXT[], void> glGetVertexAttribLui64vNV;
        /// <summary>void glGetVertexAttribPointerv(GLuint index, GLenum pname, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, IntPtr, void> glGetVertexAttribPointerv;
        /// <summary>void glGetVertexAttribPointervARB(GLuint index, GLenum pname, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, IntPtr, void> glGetVertexAttribPointervARB;
        /// <summary>void glGetVertexAttribPointervNV(GLuint index, GLenum pname, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, IntPtr, void> glGetVertexAttribPointervNV;
        /// <summary>void glGetVertexAttribdv(GLuint index, GLenum pname, GLdouble[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLdouble[], void> glGetVertexAttribdv;
        /// <summary>void glGetVertexAttribdvARB(GLuint index, GLenum pname, GLdouble[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLdouble[], void> glGetVertexAttribdvARB;
        /// <summary>void glGetVertexAttribdvNV(GLuint index, GLenum pname, GLdouble[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLdouble[], void> glGetVertexAttribdvNV;
        /// <summary>void glGetVertexAttribfv(GLuint index, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLfloat[], void> glGetVertexAttribfv;
        /// <summary>void glGetVertexAttribfvARB(GLuint index, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLfloat[], void> glGetVertexAttribfvARB;
        /// <summary>void glGetVertexAttribfvNV(GLuint index, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLfloat[], void> glGetVertexAttribfvNV;
        /// <summary>void glGetVertexAttribiv(GLuint index, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetVertexAttribiv;
        /// <summary>void glGetVertexAttribivARB(GLuint index, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetVertexAttribivARB;
        /// <summary>void glGetVertexAttribivNV(GLuint index, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetVertexAttribivNV;
        /// <summary>void glGetVideoCaptureStreamdvNV(GLuint video_capture_slot, GLuint stream, GLenum pname, GLdouble[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLdouble[], void> glGetVideoCaptureStreamdvNV;
        /// <summary>void glGetVideoCaptureStreamfvNV(GLuint video_capture_slot, GLuint stream, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLfloat[], void> glGetVideoCaptureStreamfvNV;
        /// <summary>void glGetVideoCaptureStreamivNV(GLuint video_capture_slot, GLuint stream, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLint[], void> glGetVideoCaptureStreamivNV;
        /// <summary>void glGetVideoCaptureivNV(GLuint video_capture_slot, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetVideoCaptureivNV;
        /// <summary>void glGetVideoi64vNV(GLuint video_slot, GLenum pname, GLint64EXT[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint64EXT[], void> glGetVideoi64vNV;
        /// <summary>void glGetVideoivNV(GLuint video_slot, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glGetVideoivNV;
        /// <summary>void glGetVideoui64vNV(GLuint video_slot, GLenum pname, GLuint64EXT[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint64EXT[], void> glGetVideoui64vNV;
        /// <summary>void glGetVideouivNV(GLuint video_slot, GLenum pname, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint[], void> glGetVideouivNV;
        /// <summary>void glGetnColorTable(GLenum target, GLenum format, GLenum type, GLsizei bufSize, IntPtr table);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLsizei, IntPtr, void> glGetnColorTable;
        /// <summary>void glGetnColorTableARB(GLenum target, GLenum format, GLenum type, GLsizei bufSize, IntPtr table);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLsizei, IntPtr, void> glGetnColorTableARB;
        /// <summary>void glGetnCompressedTexImage(GLenum target, GLint lod, GLsizei bufSize, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLsizei, IntPtr, void> glGetnCompressedTexImage;
        /// <summary>void glGetnCompressedTexImageARB(GLenum target, GLint lod, GLsizei bufSize, IntPtr img);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLsizei, IntPtr, void> glGetnCompressedTexImageARB;
        /// <summary>void glGetnConvolutionFilter(GLenum target, GLenum format, GLenum type, GLsizei bufSize, IntPtr image);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLsizei, IntPtr, void> glGetnConvolutionFilter;
        /// <summary>void glGetnConvolutionFilterARB(GLenum target, GLenum format, GLenum type, GLsizei bufSize, IntPtr image);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLsizei, IntPtr, void> glGetnConvolutionFilterARB;
        /// <summary>void glGetnHistogram(GLenum target, GLboolean reset, GLenum format, GLenum type, GLsizei bufSize, IntPtr values);</summary>
        public readonly delegate* unmanaged<GLenum, GLboolean, GLenum, GLenum, GLsizei, IntPtr, void> glGetnHistogram;
        /// <summary>void glGetnHistogramARB(GLenum target, GLboolean reset, GLenum format, GLenum type, GLsizei bufSize, IntPtr values);</summary>
        public readonly delegate* unmanaged<GLenum, GLboolean, GLenum, GLenum, GLsizei, IntPtr, void> glGetnHistogramARB;
        /// <summary>void glGetnMapdv(GLenum target, GLenum query, GLsizei bufSize, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLsizei, GLdouble[], void> glGetnMapdv;
        /// <summary>void glGetnMapdvARB(GLenum target, GLenum query, GLsizei bufSize, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLsizei, GLdouble[], void> glGetnMapdvARB;
        /// <summary>void glGetnMapfv(GLenum target, GLenum query, GLsizei bufSize, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLsizei, GLfloat[], void> glGetnMapfv;
        /// <summary>void glGetnMapfvARB(GLenum target, GLenum query, GLsizei bufSize, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLsizei, GLfloat[], void> glGetnMapfvARB;
        /// <summary>void glGetnMapiv(GLenum target, GLenum query, GLsizei bufSize, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLsizei, GLint[], void> glGetnMapiv;
        /// <summary>void glGetnMapivARB(GLenum target, GLenum query, GLsizei bufSize, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLsizei, GLint[], void> glGetnMapivARB;
        /// <summary>void glGetnMinmax(GLenum target, GLboolean reset, GLenum format, GLenum type, GLsizei bufSize, IntPtr values);</summary>
        public readonly delegate* unmanaged<GLenum, GLboolean, GLenum, GLenum, GLsizei, IntPtr, void> glGetnMinmax;
        /// <summary>void glGetnMinmaxARB(GLenum target, GLboolean reset, GLenum format, GLenum type, GLsizei bufSize, IntPtr values);</summary>
        public readonly delegate* unmanaged<GLenum, GLboolean, GLenum, GLenum, GLsizei, IntPtr, void> glGetnMinmaxARB;
        /// <summary>void glGetnPixelMapfv(GLenum map, GLsizei bufSize, GLfloat[] values);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLfloat[], void> glGetnPixelMapfv;
        /// <summary>void glGetnPixelMapfvARB(GLenum map, GLsizei bufSize, GLfloat[] values);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLfloat[], void> glGetnPixelMapfvARB;
        /// <summary>void glGetnPixelMapuiv(GLenum map, GLsizei bufSize, GLuint[] values);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLuint[], void> glGetnPixelMapuiv;
        /// <summary>void glGetnPixelMapuivARB(GLenum map, GLsizei bufSize, GLuint[] values);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLuint[], void> glGetnPixelMapuivARB;
        /// <summary>void glGetnPixelMapusv(GLenum map, GLsizei bufSize, GLushort[] values);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLushort[], void> glGetnPixelMapusv;
        /// <summary>void glGetnPixelMapusvARB(GLenum map, GLsizei bufSize, GLushort[] values);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLushort[], void> glGetnPixelMapusvARB;
        /// <summary>void glGetnPolygonStipple(GLsizei bufSize, GLubyte[] pattern);</summary>
        public readonly delegate* unmanaged<GLsizei, GLubyte[], void> glGetnPolygonStipple;
        /// <summary>void glGetnPolygonStippleARB(GLsizei bufSize, GLubyte[] pattern);</summary>
        public readonly delegate* unmanaged<GLsizei, GLubyte[], void> glGetnPolygonStippleARB;
        /// <summary>void glGetnSeparableFilter(GLenum target, GLenum format, GLenum type, GLsizei rowBufSize, IntPtr row, GLsizei columnBufSize, IntPtr column, IntPtr span);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLsizei, IntPtr, GLsizei, IntPtr, IntPtr, void> glGetnSeparableFilter;
        /// <summary>void glGetnSeparableFilterARB(GLenum target, GLenum format, GLenum type, GLsizei rowBufSize, IntPtr row, GLsizei columnBufSize, IntPtr column, IntPtr span);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLsizei, IntPtr, GLsizei, IntPtr, IntPtr, void> glGetnSeparableFilterARB;
        /// <summary>void glGetnTexImage(GLenum target, GLint level, GLenum format, GLenum type, GLsizei bufSize, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLenum, GLenum, GLsizei, IntPtr, void> glGetnTexImage;
        /// <summary>void glGetnTexImageARB(GLenum target, GLint level, GLenum format, GLenum type, GLsizei bufSize, IntPtr img);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLenum, GLenum, GLsizei, IntPtr, void> glGetnTexImageARB;
        /// <summary>void glGetnUniformdv(GLuint program, GLint location, GLsizei bufSize, GLdouble[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLdouble[], void> glGetnUniformdv;
        /// <summary>void glGetnUniformdvARB(GLuint program, GLint location, GLsizei bufSize, GLdouble[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLdouble[], void> glGetnUniformdvARB;
        /// <summary>void glGetnUniformfv(GLuint program, GLint location, GLsizei bufSize, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLfloat[], void> glGetnUniformfv;
        /// <summary>void glGetnUniformfvARB(GLuint program, GLint location, GLsizei bufSize, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLfloat[], void> glGetnUniformfvARB;
        /// <summary>void glGetnUniformfvEXT(GLuint program, GLint location, GLsizei bufSize, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLfloat[], void> glGetnUniformfvEXT;
        /// <summary>void glGetnUniformfvKHR(GLuint program, GLint location, GLsizei bufSize, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLfloat[], void> glGetnUniformfvKHR;
        /// <summary>void glGetnUniformi64vARB(GLuint program, GLint location, GLsizei bufSize, GLint64[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLint64[], void> glGetnUniformi64vARB;
        /// <summary>void glGetnUniformiv(GLuint program, GLint location, GLsizei bufSize, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLint[], void> glGetnUniformiv;
        /// <summary>void glGetnUniformivARB(GLuint program, GLint location, GLsizei bufSize, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLint[], void> glGetnUniformivARB;
        /// <summary>void glGetnUniformivEXT(GLuint program, GLint location, GLsizei bufSize, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLint[], void> glGetnUniformivEXT;
        /// <summary>void glGetnUniformivKHR(GLuint program, GLint location, GLsizei bufSize, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLint[], void> glGetnUniformivKHR;
        /// <summary>void glGetnUniformui64vARB(GLuint program, GLint location, GLsizei bufSize, GLuint64[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLuint64[], void> glGetnUniformui64vARB;
        /// <summary>void glGetnUniformuiv(GLuint program, GLint location, GLsizei bufSize, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLuint[], void> glGetnUniformuiv;
        /// <summary>void glGetnUniformuivARB(GLuint program, GLint location, GLsizei bufSize, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLuint[], void> glGetnUniformuivARB;
        /// <summary>void glGetnUniformuivKHR(GLuint program, GLint location, GLsizei bufSize, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLuint[], void> glGetnUniformuivKHR;
        /// <summary>void glGlobalAlphaFactorbSUN(GLbyte factor);</summary>
        public readonly delegate* unmanaged<GLbyte, void> glGlobalAlphaFactorbSUN;
        /// <summary>void glGlobalAlphaFactordSUN(GLdouble factor);</summary>
        public readonly delegate* unmanaged<GLdouble, void> glGlobalAlphaFactordSUN;
        /// <summary>void glGlobalAlphaFactorfSUN(GLfloat factor);</summary>
        public readonly delegate* unmanaged<GLfloat, void> glGlobalAlphaFactorfSUN;
        /// <summary>void glGlobalAlphaFactoriSUN(GLint factor);</summary>
        public readonly delegate* unmanaged<GLint, void> glGlobalAlphaFactoriSUN;
        /// <summary>void glGlobalAlphaFactorsSUN(GLshort factor);</summary>
        public readonly delegate* unmanaged<GLshort, void> glGlobalAlphaFactorsSUN;
        /// <summary>void glGlobalAlphaFactorubSUN(GLubyte factor);</summary>
        public readonly delegate* unmanaged<GLubyte, void> glGlobalAlphaFactorubSUN;
        /// <summary>void glGlobalAlphaFactoruiSUN(GLuint factor);</summary>
        public readonly delegate* unmanaged<GLuint, void> glGlobalAlphaFactoruiSUN;
        /// <summary>void glGlobalAlphaFactorusSUN(GLushort factor);</summary>
        public readonly delegate* unmanaged<GLushort, void> glGlobalAlphaFactorusSUN;
        /// <summary>void glHint(GLenum target, GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, void> glHint;
        /// <summary>void glHintPGI(GLenum target, GLint mode);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, void> glHintPGI;
        /// <summary>void glHistogram(GLenum target, GLsizei width, GLenum internalformat, GLboolean sink);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, GLboolean, void> glHistogram;
        /// <summary>void glHistogramEXT(GLenum target, GLsizei width, GLenum internalformat, GLboolean sink);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, GLboolean, void> glHistogramEXT;
        /// <summary>void glIglooInterfaceSGIX(GLenum pname, IntPtr params);</summary>
        public readonly delegate* unmanaged<GLenum, IntPtr, void> glIglooInterfaceSGIX;
        /// <summary>void glImageTransformParameterfHP(GLenum target, GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat, void> glImageTransformParameterfHP;
        /// <summary>void glImageTransformParameterfvHP(GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glImageTransformParameterfvHP;
        /// <summary>void glImageTransformParameteriHP(GLenum target, GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, void> glImageTransformParameteriHP;
        /// <summary>void glImageTransformParameterivHP(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glImageTransformParameterivHP;
        /// <summary>void glImportMemoryFdEXT(GLuint memory, GLuint64 size, GLenum handleType, GLint fd);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint64, GLenum, GLint, void> glImportMemoryFdEXT;
        /// <summary>void glImportMemoryWin32HandleEXT(GLuint memory, GLuint64 size, GLenum handleType, IntPtr handle);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint64, GLenum, IntPtr, void> glImportMemoryWin32HandleEXT;
        /// <summary>void glImportMemoryWin32NameEXT(GLuint memory, GLuint64 size, GLenum handleType, IntPtr name);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint64, GLenum, IntPtr, void> glImportMemoryWin32NameEXT;
        /// <summary>void glImportSemaphoreFdEXT(GLuint semaphore, GLenum handleType, GLint fd);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, void> glImportSemaphoreFdEXT;
        /// <summary>void glImportSemaphoreWin32HandleEXT(GLuint semaphore, GLenum handleType, IntPtr handle);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, IntPtr, void> glImportSemaphoreWin32HandleEXT;
        /// <summary>void glImportSemaphoreWin32NameEXT(GLuint semaphore, GLenum handleType, IntPtr name);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, IntPtr, void> glImportSemaphoreWin32NameEXT;
        /// <summary>GLsync glImportSyncEXT(GLenum external_sync_type, GLintptr external_sync, GLbitfield flags);</summary>
        public readonly delegate* unmanaged<GLenum, GLintptr, GLbitfield, GLsync> glImportSyncEXT;
        /// <summary>void glIndexFormatNV(GLenum type, GLsizei stride);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, void> glIndexFormatNV;
        /// <summary>void glIndexFuncEXT(GLenum func, GLclampf ref);</summary>
        public readonly delegate* unmanaged<GLenum, GLclampf, void> glIndexFuncEXT;
        /// <summary>void glIndexMask(GLuint mask);</summary>
        public readonly delegate* unmanaged<GLuint, void> glIndexMask;
        /// <summary>void glIndexMaterialEXT(GLenum face, GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, void> glIndexMaterialEXT;
        /// <summary>void glIndexPointer(GLenum type, GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, IntPtr, void> glIndexPointer;
        /// <summary>void glIndexPointerEXT(GLenum type, GLsizei stride, GLsizei count, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLsizei, IntPtr, void> glIndexPointerEXT;
        /// <summary>void glIndexPointerListIBM(GLenum type, GLint stride, IntPtr pointer, GLint ptrstride);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, IntPtr, GLint, void> glIndexPointerListIBM;
        /// <summary>void glIndexd(GLdouble c);</summary>
        public readonly delegate* unmanaged<GLdouble, void> glIndexd;
        /// <summary>void glIndexdv(GLdouble[] c);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glIndexdv;
        /// <summary>void glIndexf(GLfloat c);</summary>
        public readonly delegate* unmanaged<GLfloat, void> glIndexf;
        /// <summary>void glIndexfv(GLfloat[] c);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glIndexfv;
        /// <summary>void glIndexi(GLint c);</summary>
        public readonly delegate* unmanaged<GLint, void> glIndexi;
        /// <summary>void glIndexiv(GLint[] c);</summary>
        public readonly delegate* unmanaged<GLint[], void> glIndexiv;
        /// <summary>void glIndexs(GLshort c);</summary>
        public readonly delegate* unmanaged<GLshort, void> glIndexs;
        /// <summary>void glIndexsv(GLshort[] c);</summary>
        public readonly delegate* unmanaged<GLshort[], void> glIndexsv;
        /// <summary>void glIndexub(GLubyte c);</summary>
        public readonly delegate* unmanaged<GLubyte, void> glIndexub;
        /// <summary>void glIndexubv(GLubyte[] c);</summary>
        public readonly delegate* unmanaged<GLubyte[], void> glIndexubv;
        /// <summary>void glIndexxOES(GLfixed component);</summary>
        public readonly delegate* unmanaged<GLfixed, void> glIndexxOES;
        /// <summary>void glIndexxvOES(GLfixed[] component);</summary>
        public readonly delegate* unmanaged<GLfixed[], void> glIndexxvOES;
        /// <summary>void glInitNames();</summary>
        public readonly delegate* unmanaged<void> glInitNames;
        /// <summary>void glInsertComponentEXT(GLuint res, GLuint src, GLuint num);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, void> glInsertComponentEXT;
        /// <summary>void glInsertEventMarkerEXT(GLsizei length, string marker);</summary>
        public readonly delegate* unmanaged<GLsizei, string, void> glInsertEventMarkerEXT;
        /// <summary>void glInstrumentsBufferSGIX(GLsizei size, GLint[] buffer);</summary>
        public readonly delegate* unmanaged<GLsizei, GLint[], void> glInstrumentsBufferSGIX;
        /// <summary>void glInterleavedArrays(GLenum format, GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, IntPtr, void> glInterleavedArrays;
        /// <summary>void glInterpolatePathsNV(GLuint resultPath, GLuint pathA, GLuint pathB, GLfloat weight);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, GLfloat, void> glInterpolatePathsNV;
        /// <summary>void glInvalidateBufferData(GLuint buffer);</summary>
        public readonly delegate* unmanaged<GLuint, void> glInvalidateBufferData;
        /// <summary>void glInvalidateBufferSubData(GLuint buffer, GLintptr offset, GLsizeiptr length);</summary>
        public readonly delegate* unmanaged<GLuint, GLintptr, GLsizeiptr, void> glInvalidateBufferSubData;
        /// <summary>void glInvalidateFramebuffer(GLenum target, GLsizei numAttachments, GLenum[] attachments);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum[], void> glInvalidateFramebuffer;
        /// <summary>void glInvalidateNamedFramebufferData(GLuint framebuffer, GLsizei numAttachments, GLenum[] attachments);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLenum[], void> glInvalidateNamedFramebufferData;
        /// <summary>void glInvalidateNamedFramebufferSubData(GLuint framebuffer, GLsizei numAttachments, GLenum[] attachments, GLint x, GLint y, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLenum[], GLint, GLint, GLsizei, GLsizei, void> glInvalidateNamedFramebufferSubData;
        /// <summary>void glInvalidateSubFramebuffer(GLenum target, GLsizei numAttachments, GLenum[] attachments, GLint x, GLint y, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum[], GLint, GLint, GLsizei, GLsizei, void> glInvalidateSubFramebuffer;
        /// <summary>void glInvalidateTexImage(GLuint texture, GLint level);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, void> glInvalidateTexImage;
        /// <summary>void glInvalidateTexSubImage(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, void> glInvalidateTexSubImage;
        /// <summary>GLboolean glIsAsyncMarkerSGIX(GLuint marker);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsAsyncMarkerSGIX;
        /// <summary>GLboolean glIsBuffer(GLuint buffer);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsBuffer;
        /// <summary>GLboolean glIsBufferARB(GLuint buffer);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsBufferARB;
        /// <summary>GLboolean glIsBufferResidentNV(GLenum target);</summary>
        public readonly delegate* unmanaged<GLenum, GLboolean> glIsBufferResidentNV;
        /// <summary>GLboolean glIsCommandListNV(GLuint list);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsCommandListNV;
        /// <summary>GLboolean glIsEnabled(GLenum cap);</summary>
        public readonly delegate* unmanaged<GLenum, GLboolean> glIsEnabled;
        /// <summary>GLboolean glIsEnabledIndexedEXT(GLenum target, GLuint index);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLboolean> glIsEnabledIndexedEXT;
        /// <summary>GLboolean glIsEnabledi(GLenum target, GLuint index);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLboolean> glIsEnabledi;
        /// <summary>GLboolean glIsEnablediEXT(GLenum target, GLuint index);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLboolean> glIsEnablediEXT;
        /// <summary>GLboolean glIsEnablediNV(GLenum target, GLuint index);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLboolean> glIsEnablediNV;
        /// <summary>GLboolean glIsEnablediOES(GLenum target, GLuint index);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLboolean> glIsEnablediOES;
        /// <summary>GLboolean glIsFenceAPPLE(GLuint fence);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsFenceAPPLE;
        /// <summary>GLboolean glIsFenceNV(GLuint fence);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsFenceNV;
        /// <summary>GLboolean glIsFramebuffer(GLuint framebuffer);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsFramebuffer;
        /// <summary>GLboolean glIsFramebufferEXT(GLuint framebuffer);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsFramebufferEXT;
        /// <summary>GLboolean glIsFramebufferOES(GLuint framebuffer);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsFramebufferOES;
        /// <summary>GLboolean glIsImageHandleResidentARB(GLuint64 handle);</summary>
        public readonly delegate* unmanaged<GLuint64, GLboolean> glIsImageHandleResidentARB;
        /// <summary>GLboolean glIsImageHandleResidentNV(GLuint64 handle);</summary>
        public readonly delegate* unmanaged<GLuint64, GLboolean> glIsImageHandleResidentNV;
        /// <summary>GLboolean glIsList(GLuint list);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsList;
        /// <summary>GLboolean glIsMemoryObjectEXT(GLuint memoryObject);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsMemoryObjectEXT;
        /// <summary>GLboolean glIsNameAMD(GLenum identifier, GLuint name);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLboolean> glIsNameAMD;
        /// <summary>GLboolean glIsNamedBufferResidentNV(GLuint buffer);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsNamedBufferResidentNV;
        /// <summary>GLboolean glIsNamedStringARB(GLint namelen, string name);</summary>
        public readonly delegate* unmanaged<GLint, string, GLboolean> glIsNamedStringARB;
        /// <summary>GLboolean glIsObjectBufferATI(GLuint buffer);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsObjectBufferATI;
        /// <summary>GLboolean glIsOcclusionQueryNV(GLuint id);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsOcclusionQueryNV;
        /// <summary>GLboolean glIsPathNV(GLuint path);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsPathNV;
        /// <summary>GLboolean glIsPointInFillPathNV(GLuint path, GLuint mask, GLfloat x, GLfloat y);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLfloat, GLfloat, GLboolean> glIsPointInFillPathNV;
        /// <summary>GLboolean glIsPointInStrokePathNV(GLuint path, GLfloat x, GLfloat y);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat, GLfloat, GLboolean> glIsPointInStrokePathNV;
        /// <summary>GLboolean glIsProgram(GLuint program);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsProgram;
        /// <summary>GLboolean glIsProgramARB(GLuint program);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsProgramARB;
        /// <summary>GLboolean glIsProgramNV(GLuint id);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsProgramNV;
        /// <summary>GLboolean glIsProgramPipeline(GLuint pipeline);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsProgramPipeline;
        /// <summary>GLboolean glIsProgramPipelineEXT(GLuint pipeline);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsProgramPipelineEXT;
        /// <summary>GLboolean glIsQuery(GLuint id);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsQuery;
        /// <summary>GLboolean glIsQueryARB(GLuint id);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsQueryARB;
        /// <summary>GLboolean glIsQueryEXT(GLuint id);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsQueryEXT;
        /// <summary>GLboolean glIsRenderbuffer(GLuint renderbuffer);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsRenderbuffer;
        /// <summary>GLboolean glIsRenderbufferEXT(GLuint renderbuffer);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsRenderbufferEXT;
        /// <summary>GLboolean glIsRenderbufferOES(GLuint renderbuffer);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsRenderbufferOES;
        /// <summary>GLboolean glIsSemaphoreEXT(GLuint semaphore);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsSemaphoreEXT;
        /// <summary>GLboolean glIsSampler(GLuint sampler);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsSampler;
        /// <summary>GLboolean glIsShader(GLuint shader);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsShader;
        /// <summary>GLboolean glIsStateNV(GLuint state);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsStateNV;
        /// <summary>GLboolean glIsSync(GLsync sync);</summary>
        public readonly delegate* unmanaged<GLsync, GLboolean> glIsSync;
        /// <summary>GLboolean glIsSyncAPPLE(GLsync sync);</summary>
        public readonly delegate* unmanaged<GLsync, GLboolean> glIsSyncAPPLE;
        /// <summary>GLboolean glIsTexture(GLuint texture);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsTexture;
        /// <summary>GLboolean glIsTextureEXT(GLuint texture);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsTextureEXT;
        /// <summary>GLboolean glIsTextureHandleResidentARB(GLuint64 handle);</summary>
        public readonly delegate* unmanaged<GLuint64, GLboolean> glIsTextureHandleResidentARB;
        /// <summary>GLboolean glIsTextureHandleResidentNV(GLuint64 handle);</summary>
        public readonly delegate* unmanaged<GLuint64, GLboolean> glIsTextureHandleResidentNV;
        /// <summary>GLboolean glIsTransformFeedback(GLuint id);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsTransformFeedback;
        /// <summary>GLboolean glIsTransformFeedbackNV(GLuint id);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsTransformFeedbackNV;
        /// <summary>GLboolean glIsVariantEnabledEXT(GLuint id, GLenum cap);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLboolean> glIsVariantEnabledEXT;
        /// <summary>GLboolean glIsVertexArray(GLuint array);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsVertexArray;
        /// <summary>GLboolean glIsVertexArrayAPPLE(GLuint array);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsVertexArrayAPPLE;
        /// <summary>GLboolean glIsVertexArrayOES(GLuint array);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glIsVertexArrayOES;
        /// <summary>GLboolean glIsVertexAttribEnabledAPPLE(GLuint index, GLenum pname);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLboolean> glIsVertexAttribEnabledAPPLE;
        /// <summary>void glLGPUCopyImageSubDataNVX(GLuint sourceGpu, GLbitfield destinationGpuMask, GLuint srcName, GLenum srcTarget, GLint srcLevel, GLint srcX, GLint srxY, GLint srcZ, GLuint dstName, GLenum dstTarget, GLint dstLevel, GLint dstX, GLint dstY, GLint dstZ, GLsizei width, GLsizei height, GLsizei depth);</summary>
        public readonly delegate* unmanaged<GLuint, GLbitfield, GLuint, GLenum, GLint, GLint, GLint, GLint, GLuint, GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, void> glLGPUCopyImageSubDataNVX;
        /// <summary>void glLGPUInterlockNVX();</summary>
        public readonly delegate* unmanaged<void> glLGPUInterlockNVX;
        /// <summary>void glLGPUNamedBufferSubDataNVX(GLbitfield gpuMask, GLuint buffer, GLintptr offset, GLsizeiptr size, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLbitfield, GLuint, GLintptr, GLsizeiptr, IntPtr, void> glLGPUNamedBufferSubDataNVX;
        /// <summary>void glLabelObjectEXT(GLenum type, GLuint object, GLsizei length, string label);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLsizei, string, void> glLabelObjectEXT;
        /// <summary>void glLightEnviSGIX(GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, void> glLightEnviSGIX;
        /// <summary>void glLightModelf(GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, void> glLightModelf;
        /// <summary>void glLightModelfv(GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glLightModelfv;
        /// <summary>void glLightModeli(GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, void> glLightModeli;
        /// <summary>void glLightModeliv(GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLint[], void> glLightModeliv;
        /// <summary>void glLightModelx(GLenum pname, GLfixed param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed, void> glLightModelx;
        /// <summary>void glLightModelxOES(GLenum pname, GLfixed param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed, void> glLightModelxOES;
        /// <summary>void glLightModelxv(GLenum pname, GLfixed[] param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed[], void> glLightModelxv;
        /// <summary>void glLightModelxvOES(GLenum pname, GLfixed[] param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed[], void> glLightModelxvOES;
        /// <summary>void glLightf(GLenum light, GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat, void> glLightf;
        /// <summary>void glLightfv(GLenum light, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glLightfv;
        /// <summary>void glLighti(GLenum light, GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, void> glLighti;
        /// <summary>void glLightiv(GLenum light, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glLightiv;
        /// <summary>void glLightx(GLenum light, GLenum pname, GLfixed param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed, void> glLightx;
        /// <summary>void glLightxOES(GLenum light, GLenum pname, GLfixed param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed, void> glLightxOES;
        /// <summary>void glLightxv(GLenum light, GLenum pname, GLfixed[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed[], void> glLightxv;
        /// <summary>void glLightxvOES(GLenum light, GLenum pname, GLfixed[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed[], void> glLightxvOES;
        /// <summary>void glLineStipple(GLint factor, GLushort pattern);</summary>
        public readonly delegate* unmanaged<GLint, GLushort, void> glLineStipple;
        /// <summary>void glLineWidth(GLfloat width);</summary>
        public readonly delegate* unmanaged<GLfloat, void> glLineWidth;
        /// <summary>void glLineWidthx(GLfixed width);</summary>
        public readonly delegate* unmanaged<GLfixed, void> glLineWidthx;
        /// <summary>void glLineWidthxOES(GLfixed width);</summary>
        public readonly delegate* unmanaged<GLfixed, void> glLineWidthxOES;
        /// <summary>void glLinkProgram(GLuint program);</summary>
        public readonly delegate* unmanaged<GLuint, void> glLinkProgram;
        /// <summary>void glLinkProgramARB(GLhandleARB programObj);</summary>
        public readonly delegate* unmanaged<GLhandleARB, void> glLinkProgramARB;
        /// <summary>void glListBase(GLuint base);</summary>
        public readonly delegate* unmanaged<GLuint, void> glListBase;
        /// <summary>void glListDrawCommandsStatesClientNV(GLuint list, GLuint segment, IntPtr indirects, GLsizei[] sizes, GLuint[] states, GLuint[] fbos, GLuint count);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, IntPtr, GLsizei[], GLuint[], GLuint[], GLuint, void> glListDrawCommandsStatesClientNV;
        /// <summary>void glListParameterfSGIX(GLuint list, GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLfloat, void> glListParameterfSGIX;
        /// <summary>void glListParameterfvSGIX(GLuint list, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLfloat[], void> glListParameterfvSGIX;
        /// <summary>void glListParameteriSGIX(GLuint list, GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, void> glListParameteriSGIX;
        /// <summary>void glListParameterivSGIX(GLuint list, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glListParameterivSGIX;
        /// <summary>void glLoadIdentity();</summary>
        public readonly delegate* unmanaged<void> glLoadIdentity;
        /// <summary>void glLoadIdentityDeformationMapSGIX(GLbitfield mask);</summary>
        public readonly delegate* unmanaged<GLbitfield, void> glLoadIdentityDeformationMapSGIX;
        /// <summary>void glLoadMatrixd(GLdouble[] m);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glLoadMatrixd;
        /// <summary>void glLoadMatrixf(GLfloat[] m);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glLoadMatrixf;
        /// <summary>void glLoadMatrixx(GLfixed[] m);</summary>
        public readonly delegate* unmanaged<GLfixed[], void> glLoadMatrixx;
        /// <summary>void glLoadMatrixxOES(GLfixed[] m);</summary>
        public readonly delegate* unmanaged<GLfixed[], void> glLoadMatrixxOES;
        /// <summary>void glLoadName(GLuint name);</summary>
        public readonly delegate* unmanaged<GLuint, void> glLoadName;
        /// <summary>void glLoadPaletteFromModelViewMatrixOES();</summary>
        public readonly delegate* unmanaged<void> glLoadPaletteFromModelViewMatrixOES;
        /// <summary>void glLoadProgramNV(GLenum target, GLuint id, GLsizei len, GLubyte[] program);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLsizei, GLubyte[], void> glLoadProgramNV;
        /// <summary>void glLoadTransposeMatrixd(GLdouble[] m);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glLoadTransposeMatrixd;
        /// <summary>void glLoadTransposeMatrixdARB(GLdouble[] m);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glLoadTransposeMatrixdARB;
        /// <summary>void glLoadTransposeMatrixf(GLfloat[] m);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glLoadTransposeMatrixf;
        /// <summary>void glLoadTransposeMatrixfARB(GLfloat[] m);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glLoadTransposeMatrixfARB;
        /// <summary>void glLoadTransposeMatrixxOES(GLfixed[] m);</summary>
        public readonly delegate* unmanaged<GLfixed[], void> glLoadTransposeMatrixxOES;
        /// <summary>void glLockArraysEXT(GLint first, GLsizei count);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, void> glLockArraysEXT;
        /// <summary>void glLogicOp(GLenum opcode);</summary>
        public readonly delegate* unmanaged<GLenum, void> glLogicOp;
        /// <summary>void glMakeBufferNonResidentNV(GLenum target);</summary>
        public readonly delegate* unmanaged<GLenum, void> glMakeBufferNonResidentNV;
        /// <summary>void glMakeBufferResidentNV(GLenum target, GLenum access);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, void> glMakeBufferResidentNV;
        /// <summary>void glMakeImageHandleNonResidentARB(GLuint64 handle);</summary>
        public readonly delegate* unmanaged<GLuint64, void> glMakeImageHandleNonResidentARB;
        /// <summary>void glMakeImageHandleNonResidentNV(GLuint64 handle);</summary>
        public readonly delegate* unmanaged<GLuint64, void> glMakeImageHandleNonResidentNV;
        /// <summary>void glMakeImageHandleResidentARB(GLuint64 handle, GLenum access);</summary>
        public readonly delegate* unmanaged<GLuint64, GLenum, void> glMakeImageHandleResidentARB;
        /// <summary>void glMakeImageHandleResidentNV(GLuint64 handle, GLenum access);</summary>
        public readonly delegate* unmanaged<GLuint64, GLenum, void> glMakeImageHandleResidentNV;
        /// <summary>void glMakeNamedBufferNonResidentNV(GLuint buffer);</summary>
        public readonly delegate* unmanaged<GLuint, void> glMakeNamedBufferNonResidentNV;
        /// <summary>void glMakeNamedBufferResidentNV(GLuint buffer, GLenum access);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, void> glMakeNamedBufferResidentNV;
        /// <summary>void glMakeTextureHandleNonResidentARB(GLuint64 handle);</summary>
        public readonly delegate* unmanaged<GLuint64, void> glMakeTextureHandleNonResidentARB;
        /// <summary>void glMakeTextureHandleNonResidentNV(GLuint64 handle);</summary>
        public readonly delegate* unmanaged<GLuint64, void> glMakeTextureHandleNonResidentNV;
        /// <summary>void glMakeTextureHandleResidentARB(GLuint64 handle);</summary>
        public readonly delegate* unmanaged<GLuint64, void> glMakeTextureHandleResidentARB;
        /// <summary>void glMakeTextureHandleResidentNV(GLuint64 handle);</summary>
        public readonly delegate* unmanaged<GLuint64, void> glMakeTextureHandleResidentNV;
        /// <summary>void glMap1d(GLenum target, GLdouble u1, GLdouble u2, GLint stride, GLint order, GLdouble[] points);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble, GLdouble, GLint, GLint, GLdouble[], void> glMap1d;
        /// <summary>void glMap1f(GLenum target, GLfloat u1, GLfloat u2, GLint stride, GLint order, GLfloat[] points);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, GLfloat, GLint, GLint, GLfloat[], void> glMap1f;
        /// <summary>void glMap1xOES(GLenum target, GLfixed u1, GLfixed u2, GLint stride, GLint order, GLfixed points);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed, GLfixed, GLint, GLint, GLfixed, void> glMap1xOES;
        /// <summary>void glMap2d(GLenum target, GLdouble u1, GLdouble u2, GLint ustride, GLint uorder, GLdouble v1, GLdouble v2, GLint vstride, GLint vorder, GLdouble[] points);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble, GLdouble, GLint, GLint, GLdouble, GLdouble, GLint, GLint, GLdouble[], void> glMap2d;
        /// <summary>void glMap2f(GLenum target, GLfloat u1, GLfloat u2, GLint ustride, GLint uorder, GLfloat v1, GLfloat v2, GLint vstride, GLint vorder, GLfloat[] points);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, GLfloat, GLint, GLint, GLfloat, GLfloat, GLint, GLint, GLfloat*, void> glMap2f;
        /// <summary>void glMap2xOES(GLenum target, GLfixed u1, GLfixed u2, GLint ustride, GLint uorder, GLfixed v1, GLfixed v2, GLint vstride, GLint vorder, GLfixed points);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed, GLfixed, GLint, GLint, GLfixed, GLfixed, GLint, GLint, GLfixed, void> glMap2xOES;
        /// <summary>IntPtr glMapBuffer(GLenum target, GLenum access);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, IntPtr> glMapBuffer;
        /// <summary>IntPtr glMapBufferARB(GLenum target, GLenum access);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, IntPtr> glMapBufferARB;
        /// <summary>IntPtr glMapBufferOES(GLenum target, GLenum access);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, IntPtr> glMapBufferOES;
        /// <summary>IntPtr glMapBufferRange(GLenum target, GLintptr offset, GLsizeiptr length, GLbitfield access);</summary>
        public readonly delegate* unmanaged<GLenum, GLintptr, GLsizeiptr, GLbitfield, IntPtr> glMapBufferRange;
        /// <summary>IntPtr glMapBufferRangeEXT(GLenum target, GLintptr offset, GLsizeiptr length, GLbitfield access);</summary>
        public readonly delegate* unmanaged<GLenum, GLintptr, GLsizeiptr, GLbitfield, IntPtr> glMapBufferRangeEXT;
        /// <summary>void glMapControlPointsNV(GLenum target, GLuint index, GLenum type, GLsizei ustride, GLsizei vstride, GLint uorder, GLint vorder, GLboolean packed, IntPtr points);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLenum, GLsizei, GLsizei, GLint, GLint, GLboolean, IntPtr, void> glMapControlPointsNV;
        /// <summary>void glMapGrid1d(GLint un, GLdouble u1, GLdouble u2);</summary>
        public readonly delegate* unmanaged<GLint, GLdouble, GLdouble, void> glMapGrid1d;
        /// <summary>void glMapGrid1f(GLint un, GLfloat u1, GLfloat u2);</summary>
        public readonly delegate* unmanaged<GLint, GLfloat, GLfloat, void> glMapGrid1f;
        /// <summary>void glMapGrid1xOES(GLint n, GLfixed u1, GLfixed u2);</summary>
        public readonly delegate* unmanaged<GLint, GLfixed, GLfixed, void> glMapGrid1xOES;
        /// <summary>void glMapGrid2d(GLint un, GLdouble u1, GLdouble u2, GLint vn, GLdouble v1, GLdouble v2);</summary>
        public readonly delegate* unmanaged<GLint, GLdouble, GLdouble, GLint, GLdouble, GLdouble, void> glMapGrid2d;
        /// <summary>void glMapGrid2f(GLint un, GLfloat u1, GLfloat u2, GLint vn, GLfloat v1, GLfloat v2);</summary>
        public readonly delegate* unmanaged<GLint, GLfloat, GLfloat, GLint, GLfloat, GLfloat, void> glMapGrid2f;
        /// <summary>void glMapGrid2xOES(GLint n, GLfixed u1, GLfixed u2, GLfixed v1, GLfixed v2);</summary>
        public readonly delegate* unmanaged<GLint, GLfixed, GLfixed, GLfixed, GLfixed, void> glMapGrid2xOES;
        /// <summary>IntPtr glMapNamedBuffer(GLuint buffer, GLenum access);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, IntPtr> glMapNamedBuffer;
        /// <summary>IntPtr glMapNamedBufferEXT(GLuint buffer, GLenum access);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, IntPtr> glMapNamedBufferEXT;
        /// <summary>IntPtr glMapNamedBufferRange(GLuint buffer, GLintptr offset, GLsizeiptr length, GLbitfield access);</summary>
        public readonly delegate* unmanaged<GLuint, GLintptr, GLsizeiptr, GLbitfield, IntPtr> glMapNamedBufferRange;
        /// <summary>IntPtr glMapNamedBufferRangeEXT(GLuint buffer, GLintptr offset, GLsizeiptr length, GLbitfield access);</summary>
        public readonly delegate* unmanaged<GLuint, GLintptr, GLsizeiptr, GLbitfield, IntPtr> glMapNamedBufferRangeEXT;
        /// <summary>IntPtr glMapObjectBufferATI(GLuint buffer);</summary>
        public readonly delegate* unmanaged<GLuint, IntPtr> glMapObjectBufferATI;
        /// <summary>void glMapParameterfvNV(GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glMapParameterfvNV;
        /// <summary>void glMapParameterivNV(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glMapParameterivNV;
        /// <summary>IntPtr glMapTexture2DINTEL(GLuint texture, GLint level, GLbitfield access, GLint[] stride, GLenum[] layout);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLbitfield, GLint[], GLenum[], IntPtr> glMapTexture2DINTEL;
        /// <summary>void glMapVertexAttrib1dAPPLE(GLuint index, GLuint size, GLdouble u1, GLdouble u2, GLint stride, GLint order, GLdouble[] points);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLdouble, GLdouble, GLint, GLint, GLdouble[], void> glMapVertexAttrib1dAPPLE;
        /// <summary>void glMapVertexAttrib1fAPPLE(GLuint index, GLuint size, GLfloat u1, GLfloat u2, GLint stride, GLint order, GLfloat[] points);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLfloat, GLfloat, GLint, GLint, GLfloat[], void> glMapVertexAttrib1fAPPLE;
        /// <summary>void glMapVertexAttrib2dAPPLE(GLuint index, GLuint size, GLdouble u1, GLdouble u2, GLint ustride, GLint uorder, GLdouble v1, GLdouble v2, GLint vstride, GLint vorder, GLdouble[] points);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLdouble, GLdouble, GLint, GLint, GLdouble, GLdouble, GLint, GLint, GLdouble[], void> glMapVertexAttrib2dAPPLE;
        /// <summary>void glMapVertexAttrib2fAPPLE(GLuint index, GLuint size, GLfloat u1, GLfloat u2, GLint ustride, GLint uorder, GLfloat v1, GLfloat v2, GLint vstride, GLint vorder, GLfloat[] points);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLfloat, GLfloat, GLint, GLint, GLfloat, GLfloat, GLint, GLint, GLfloat[], void> glMapVertexAttrib2fAPPLE;
        /// <summary>void glMaterialf(GLenum face, GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat, void> glMaterialf;
        /// <summary>void glMaterialfv(GLenum face, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat*, void> glMaterialfv;
        /// <summary>void glMateriali(GLenum face, GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, void> glMateriali;
        /// <summary>void glMaterialiv(GLenum face, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glMaterialiv;
        /// <summary>void glMaterialx(GLenum face, GLenum pname, GLfixed param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed, void> glMaterialx;
        /// <summary>void glMaterialxOES(GLenum face, GLenum pname, GLfixed param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed, void> glMaterialxOES;
        /// <summary>void glMaterialxv(GLenum face, GLenum pname, GLfixed[] param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed[], void> glMaterialxv;
        /// <summary>void glMaterialxvOES(GLenum face, GLenum pname, GLfixed[] param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed[], void> glMaterialxvOES;
        /// <summary>void glMatrixFrustumEXT(GLenum mode, GLdouble left, GLdouble right, GLdouble bottom, GLdouble top, GLdouble zNear, GLdouble zFar);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble, GLdouble, GLdouble, GLdouble, GLdouble, GLdouble, void> glMatrixFrustumEXT;
        /// <summary>void glMatrixIndexPointerARB(GLint size, GLenum type, GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLint, GLenum, GLsizei, IntPtr, void> glMatrixIndexPointerARB;
        /// <summary>void glMatrixIndexPointerOES(GLint size, GLenum type, GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLint, GLenum, GLsizei, IntPtr, void> glMatrixIndexPointerOES;
        /// <summary>void glMatrixIndexubvARB(GLint size, GLubyte[] indices);</summary>
        public readonly delegate* unmanaged<GLint, GLubyte[], void> glMatrixIndexubvARB;
        /// <summary>void glMatrixIndexuivARB(GLint size, GLuint[] indices);</summary>
        public readonly delegate* unmanaged<GLint, GLuint[], void> glMatrixIndexuivARB;
        /// <summary>void glMatrixIndexusvARB(GLint size, GLushort[] indices);</summary>
        public readonly delegate* unmanaged<GLint, GLushort[], void> glMatrixIndexusvARB;
        /// <summary>void glMatrixLoad3x2fNV(GLenum matrixMode, GLfloat[] m);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glMatrixLoad3x2fNV;
        /// <summary>void glMatrixLoad3x3fNV(GLenum matrixMode, GLfloat[] m);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glMatrixLoad3x3fNV;
        /// <summary>void glMatrixLoadIdentityEXT(GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, void> glMatrixLoadIdentityEXT;
        /// <summary>void glMatrixLoadTranspose3x3fNV(GLenum matrixMode, GLfloat[] m);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glMatrixLoadTranspose3x3fNV;
        /// <summary>void glMatrixLoadTransposedEXT(GLenum mode, GLdouble[] m);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble[], void> glMatrixLoadTransposedEXT;
        /// <summary>void glMatrixLoadTransposefEXT(GLenum mode, GLfloat[] m);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glMatrixLoadTransposefEXT;
        /// <summary>void glMatrixLoaddEXT(GLenum mode, GLdouble[] m);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble[], void> glMatrixLoaddEXT;
        /// <summary>void glMatrixLoadfEXT(GLenum mode, GLfloat[] m);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glMatrixLoadfEXT;
        /// <summary>void glMatrixMode(GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, void> glMatrixMode;
        /// <summary>void glMatrixMult3x2fNV(GLenum matrixMode, GLfloat[] m);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glMatrixMult3x2fNV;
        /// <summary>void glMatrixMult3x3fNV(GLenum matrixMode, GLfloat[] m);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glMatrixMult3x3fNV;
        /// <summary>void glMatrixMultTranspose3x3fNV(GLenum matrixMode, GLfloat[] m);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glMatrixMultTranspose3x3fNV;
        /// <summary>void glMatrixMultTransposedEXT(GLenum mode, GLdouble[] m);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble[], void> glMatrixMultTransposedEXT;
        /// <summary>void glMatrixMultTransposefEXT(GLenum mode, GLfloat[] m);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glMatrixMultTransposefEXT;
        /// <summary>void glMatrixMultdEXT(GLenum mode, GLdouble[] m);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble[], void> glMatrixMultdEXT;
        /// <summary>void glMatrixMultfEXT(GLenum mode, GLfloat[] m);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glMatrixMultfEXT;
        /// <summary>void glMatrixOrthoEXT(GLenum mode, GLdouble left, GLdouble right, GLdouble bottom, GLdouble top, GLdouble zNear, GLdouble zFar);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble, GLdouble, GLdouble, GLdouble, GLdouble, GLdouble, void> glMatrixOrthoEXT;
        /// <summary>void glMatrixPopEXT(GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, void> glMatrixPopEXT;
        /// <summary>void glMatrixPushEXT(GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, void> glMatrixPushEXT;
        /// <summary>void glMatrixRotatedEXT(GLenum mode, GLdouble angle, GLdouble x, GLdouble y, GLdouble z);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble, GLdouble, GLdouble, GLdouble, void> glMatrixRotatedEXT;
        /// <summary>void glMatrixRotatefEXT(GLenum mode, GLfloat angle, GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, GLfloat, GLfloat, GLfloat, void> glMatrixRotatefEXT;
        /// <summary>void glMatrixScaledEXT(GLenum mode, GLdouble x, GLdouble y, GLdouble z);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble, GLdouble, GLdouble, void> glMatrixScaledEXT;
        /// <summary>void glMatrixScalefEXT(GLenum mode, GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, GLfloat, GLfloat, void> glMatrixScalefEXT;
        /// <summary>void glMatrixTranslatedEXT(GLenum mode, GLdouble x, GLdouble y, GLdouble z);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble, GLdouble, GLdouble, void> glMatrixTranslatedEXT;
        /// <summary>void glMatrixTranslatefEXT(GLenum mode, GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, GLfloat, GLfloat, void> glMatrixTranslatefEXT;
        /// <summary>void glMaxShaderCompilerThreadsKHR(GLuint count);</summary>
        public readonly delegate* unmanaged<GLuint, void> glMaxShaderCompilerThreadsKHR;
        /// <summary>void glMaxShaderCompilerThreadsARB(GLuint count);</summary>
        public readonly delegate* unmanaged<GLuint, void> glMaxShaderCompilerThreadsARB;
        /// <summary>void glMemoryBarrier(GLbitfield barriers);</summary>
        public readonly delegate* unmanaged<GLbitfield, void> glMemoryBarrier;
        /// <summary>void glMemoryBarrierByRegion(GLbitfield barriers);</summary>
        public readonly delegate* unmanaged<GLbitfield, void> glMemoryBarrierByRegion;
        /// <summary>void glMemoryBarrierEXT(GLbitfield barriers);</summary>
        public readonly delegate* unmanaged<GLbitfield, void> glMemoryBarrierEXT;
        /// <summary>void glMemoryObjectParameterivEXT(GLuint memoryObject, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glMemoryObjectParameterivEXT;
        /// <summary>void glMinSampleShading(GLfloat value);</summary>
        public readonly delegate* unmanaged<GLfloat, void> glMinSampleShading;
        /// <summary>void glMinSampleShadingARB(GLfloat value);</summary>
        public readonly delegate* unmanaged<GLfloat, void> glMinSampleShadingARB;
        /// <summary>void glMinSampleShadingOES(GLfloat value);</summary>
        public readonly delegate* unmanaged<GLfloat, void> glMinSampleShadingOES;
        /// <summary>void glMinmax(GLenum target, GLenum internalformat, GLboolean sink);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLboolean, void> glMinmax;
        /// <summary>void glMinmaxEXT(GLenum target, GLenum internalformat, GLboolean sink);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLboolean, void> glMinmaxEXT;
        /// <summary>void glMultMatrixd(GLdouble[] m);</summary>
        public readonly delegate* unmanaged<GLdouble*, void> glMultMatrixd;
        /// <summary>void glMultMatrixf(GLfloat[] m);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glMultMatrixf;
        /// <summary>void glMultMatrixx(GLfixed[] m);</summary>
        public readonly delegate* unmanaged<GLfixed[], void> glMultMatrixx;
        /// <summary>void glMultMatrixxOES(GLfixed[] m);</summary>
        public readonly delegate* unmanaged<GLfixed[], void> glMultMatrixxOES;
        /// <summary>void glMultTransposeMatrixd(GLdouble[] m);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glMultTransposeMatrixd;
        /// <summary>void glMultTransposeMatrixdARB(GLdouble[] m);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glMultTransposeMatrixdARB;
        /// <summary>void glMultTransposeMatrixf(GLfloat[] m);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glMultTransposeMatrixf;
        /// <summary>void glMultTransposeMatrixfARB(GLfloat[] m);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glMultTransposeMatrixfARB;
        /// <summary>void glMultTransposeMatrixxOES(GLfixed[] m);</summary>
        public readonly delegate* unmanaged<GLfixed[], void> glMultTransposeMatrixxOES;
        /// <summary>void glMultiDrawArrays(GLenum mode, GLint[] first, GLsizei[] count, GLsizei drawcount);</summary>
        public readonly delegate* unmanaged<GLenum, GLint[], GLsizei[], GLsizei, void> glMultiDrawArrays;
        /// <summary>void glMultiDrawArraysEXT(GLenum mode, GLint[] first, GLsizei[] count, GLsizei primcount);</summary>
        public readonly delegate* unmanaged<GLenum, GLint[], GLsizei[], GLsizei, void> glMultiDrawArraysEXT;
        /// <summary>void glMultiDrawArraysIndirect(GLenum mode, IntPtr indirect, GLsizei drawcount, GLsizei stride);</summary>
        public readonly delegate* unmanaged<GLenum, IntPtr, GLsizei, GLsizei, void> glMultiDrawArraysIndirect;
        /// <summary>void glMultiDrawArraysIndirectAMD(GLenum mode, IntPtr indirect, GLsizei primcount, GLsizei stride);</summary>
        public readonly delegate* unmanaged<GLenum, IntPtr, GLsizei, GLsizei, void> glMultiDrawArraysIndirectAMD;
        /// <summary>void glMultiDrawArraysIndirectBindlessCountNV(GLenum mode, IntPtr indirect, GLsizei drawCount, GLsizei maxDrawCount, GLsizei stride, GLint vertexBufferCount);</summary>
        public readonly delegate* unmanaged<GLenum, IntPtr, GLsizei, GLsizei, GLsizei, GLint, void> glMultiDrawArraysIndirectBindlessCountNV;
        /// <summary>void glMultiDrawArraysIndirectBindlessNV(GLenum mode, IntPtr indirect, GLsizei drawCount, GLsizei stride, GLint vertexBufferCount);</summary>
        public readonly delegate* unmanaged<GLenum, IntPtr, GLsizei, GLsizei, GLint, void> glMultiDrawArraysIndirectBindlessNV;
        /// <summary>void glMultiDrawArraysIndirectCount(GLenum mode, IntPtr indirect, GLintptr drawcount, GLsizei maxdrawcount, GLsizei stride);</summary>
        public readonly delegate* unmanaged<GLenum, IntPtr, GLintptr, GLsizei, GLsizei, void> glMultiDrawArraysIndirectCount;
        /// <summary>void glMultiDrawArraysIndirectCountARB(GLenum mode, IntPtr indirect, GLintptr drawcount, GLsizei maxdrawcount, GLsizei stride);</summary>
        public readonly delegate* unmanaged<GLenum, IntPtr, GLintptr, GLsizei, GLsizei, void> glMultiDrawArraysIndirectCountARB;
        /// <summary>void glMultiDrawArraysIndirectEXT(GLenum mode, IntPtr indirect, GLsizei drawcount, GLsizei stride);</summary>
        public readonly delegate* unmanaged<GLenum, IntPtr, GLsizei, GLsizei, void> glMultiDrawArraysIndirectEXT;
        /// <summary>void glMultiDrawElementArrayAPPLE(GLenum mode, GLint[] first, GLsizei[] count, GLsizei primcount);</summary>
        public readonly delegate* unmanaged<GLenum, GLint[], GLsizei[], GLsizei, void> glMultiDrawElementArrayAPPLE;
        /// <summary>void glMultiDrawElements(GLenum mode, GLsizei[] count, GLenum type, IntPtr indices, GLsizei drawcount);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei[], GLenum, IntPtr, GLsizei, void> glMultiDrawElements;
        /// <summary>void glMultiDrawElementsBaseVertex(GLenum mode, GLsizei[] count, GLenum type, IntPtr indices, GLsizei drawcount, GLint[] basevertex);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei[], GLenum, IntPtr, GLsizei, GLint[], void> glMultiDrawElementsBaseVertex;
        /// <summary>void glMultiDrawElementsBaseVertexEXT(GLenum mode, GLsizei[] count, GLenum type, IntPtr indices, GLsizei primcount, GLint[] basevertex);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei[], GLenum, IntPtr, GLsizei, GLint[], void> glMultiDrawElementsBaseVertexEXT;
        /// <summary>void glMultiDrawElementsEXT(GLenum mode, GLsizei[] count, GLenum type, IntPtr indices, GLsizei primcount);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei[], GLenum, IntPtr, GLsizei, void> glMultiDrawElementsEXT;
        /// <summary>void glMultiDrawElementsIndirect(GLenum mode, GLenum type, IntPtr indirect, GLsizei drawcount, GLsizei stride);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, IntPtr, GLsizei, GLsizei, void> glMultiDrawElementsIndirect;
        /// <summary>void glMultiDrawElementsIndirectAMD(GLenum mode, GLenum type, IntPtr indirect, GLsizei primcount, GLsizei stride);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, IntPtr, GLsizei, GLsizei, void> glMultiDrawElementsIndirectAMD;
        /// <summary>void glMultiDrawElementsIndirectBindlessCountNV(GLenum mode, GLenum type, IntPtr indirect, GLsizei drawCount, GLsizei maxDrawCount, GLsizei stride, GLint vertexBufferCount);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, IntPtr, GLsizei, GLsizei, GLsizei, GLint, void> glMultiDrawElementsIndirectBindlessCountNV;
        /// <summary>void glMultiDrawElementsIndirectBindlessNV(GLenum mode, GLenum type, IntPtr indirect, GLsizei drawCount, GLsizei stride, GLint vertexBufferCount);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, IntPtr, GLsizei, GLsizei, GLint, void> glMultiDrawElementsIndirectBindlessNV;
        /// <summary>void glMultiDrawElementsIndirectCount(GLenum mode, GLenum type, IntPtr indirect, GLintptr drawcount, GLsizei maxdrawcount, GLsizei stride);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, IntPtr, GLintptr, GLsizei, GLsizei, void> glMultiDrawElementsIndirectCount;
        /// <summary>void glMultiDrawElementsIndirectCountARB(GLenum mode, GLenum type, IntPtr indirect, GLintptr drawcount, GLsizei maxdrawcount, GLsizei stride);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, IntPtr, GLintptr, GLsizei, GLsizei, void> glMultiDrawElementsIndirectCountARB;
        /// <summary>void glMultiDrawElementsIndirectEXT(GLenum mode, GLenum type, IntPtr indirect, GLsizei drawcount, GLsizei stride);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, IntPtr, GLsizei, GLsizei, void> glMultiDrawElementsIndirectEXT;
        /// <summary>void glMultiDrawMeshTasksIndirectNV(GLintptr indirect, GLsizei drawcount, GLsizei stride);</summary>
        public readonly delegate* unmanaged<GLintptr, GLsizei, GLsizei, void> glMultiDrawMeshTasksIndirectNV;
        /// <summary>void glMultiDrawMeshTasksIndirectCountNV(GLintptr indirect, GLintptr drawcount, GLsizei maxdrawcount, GLsizei stride);</summary>
        public readonly delegate* unmanaged<GLintptr, GLintptr, GLsizei, GLsizei, void> glMultiDrawMeshTasksIndirectCountNV;
        /// <summary>void glMultiDrawRangeElementArrayAPPLE(GLenum mode, GLuint start, GLuint end, GLint[] first, GLsizei[] count, GLsizei primcount);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLint[], GLsizei[], GLsizei, void> glMultiDrawRangeElementArrayAPPLE;
        /// <summary>void glMultiModeDrawArraysIBM(GLenum[] mode, GLint[] first, GLsizei[] count, GLsizei primcount, GLint modestride);</summary>
        public readonly delegate* unmanaged<GLenum[], GLint[], GLsizei[], GLsizei, GLint, void> glMultiModeDrawArraysIBM;
        /// <summary>void glMultiModeDrawElementsIBM(GLenum[] mode, GLsizei[] count, GLenum type, IntPtr indices, GLsizei primcount, GLint modestride);</summary>
        public readonly delegate* unmanaged<GLenum[], GLsizei[], GLenum, IntPtr, GLsizei, GLint, void> glMultiModeDrawElementsIBM;
        /// <summary>void glMultiTexBufferEXT(GLenum texunit, GLenum target, GLenum internalformat, GLuint buffer);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, void> glMultiTexBufferEXT;
        /// <summary>void glMultiTexCoord1bOES(GLenum texture, GLbyte s);</summary>
        public readonly delegate* unmanaged<GLenum, GLbyte, void> glMultiTexCoord1bOES;
        /// <summary>void glMultiTexCoord1bvOES(GLenum texture, GLbyte[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLbyte[], void> glMultiTexCoord1bvOES;
        /// <summary>void glMultiTexCoord1d(GLenum target, GLdouble s);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble, void> glMultiTexCoord1d;
        /// <summary>void glMultiTexCoord1dARB(GLenum target, GLdouble s);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble, void> glMultiTexCoord1dARB;
        /// <summary>void glMultiTexCoord1dv(GLenum target, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble[], void> glMultiTexCoord1dv;
        /// <summary>void glMultiTexCoord1dvARB(GLenum target, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble[], void> glMultiTexCoord1dvARB;
        /// <summary>void glMultiTexCoord1f(GLenum target, GLfloat s);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, void> glMultiTexCoord1f;
        /// <summary>void glMultiTexCoord1fARB(GLenum target, GLfloat s);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, void> glMultiTexCoord1fARB;
        /// <summary>void glMultiTexCoord1fv(GLenum target, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glMultiTexCoord1fv;
        /// <summary>void glMultiTexCoord1fvARB(GLenum target, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glMultiTexCoord1fvARB;
        /// <summary>void glMultiTexCoord1hNV(GLenum target, GLhalfNV s);</summary>
        public readonly delegate* unmanaged<GLenum, GLhalfNV, void> glMultiTexCoord1hNV;
        /// <summary>void glMultiTexCoord1hvNV(GLenum target, GLhalfNV[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLhalfNV[], void> glMultiTexCoord1hvNV;
        /// <summary>void glMultiTexCoord1i(GLenum target, GLint s);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, void> glMultiTexCoord1i;
        /// <summary>void glMultiTexCoord1iARB(GLenum target, GLint s);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, void> glMultiTexCoord1iARB;
        /// <summary>void glMultiTexCoord1iv(GLenum target, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLint[], void> glMultiTexCoord1iv;
        /// <summary>void glMultiTexCoord1ivARB(GLenum target, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLint[], void> glMultiTexCoord1ivARB;
        /// <summary>void glMultiTexCoord1s(GLenum target, GLshort s);</summary>
        public readonly delegate* unmanaged<GLenum, GLshort, void> glMultiTexCoord1s;
        /// <summary>void glMultiTexCoord1sARB(GLenum target, GLshort s);</summary>
        public readonly delegate* unmanaged<GLenum, GLshort, void> glMultiTexCoord1sARB;
        /// <summary>void glMultiTexCoord1sv(GLenum target, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLshort[], void> glMultiTexCoord1sv;
        /// <summary>void glMultiTexCoord1svARB(GLenum target, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLshort[], void> glMultiTexCoord1svARB;
        /// <summary>void glMultiTexCoord1xOES(GLenum texture, GLfixed s);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed, void> glMultiTexCoord1xOES;
        /// <summary>void glMultiTexCoord1xvOES(GLenum texture, GLfixed[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed[], void> glMultiTexCoord1xvOES;
        /// <summary>void glMultiTexCoord2bOES(GLenum texture, GLbyte s, GLbyte t);</summary>
        public readonly delegate* unmanaged<GLenum, GLbyte, GLbyte, void> glMultiTexCoord2bOES;
        /// <summary>void glMultiTexCoord2bvOES(GLenum texture, GLbyte[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLbyte[], void> glMultiTexCoord2bvOES;
        /// <summary>void glMultiTexCoord2d(GLenum target, GLdouble s, GLdouble t);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble, GLdouble, void> glMultiTexCoord2d;
        /// <summary>void glMultiTexCoord2dARB(GLenum target, GLdouble s, GLdouble t);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble, GLdouble, void> glMultiTexCoord2dARB;
        /// <summary>void glMultiTexCoord2dv(GLenum target, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble[], void> glMultiTexCoord2dv;
        /// <summary>void glMultiTexCoord2dvARB(GLenum target, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble[], void> glMultiTexCoord2dvARB;
        /// <summary>void glMultiTexCoord2f(GLenum target, GLfloat s, GLfloat t);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, GLfloat, void> glMultiTexCoord2f;
        /// <summary>void glMultiTexCoord2fARB(GLenum target, GLfloat s, GLfloat t);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, GLfloat, void> glMultiTexCoord2fARB;
        /// <summary>void glMultiTexCoord2fv(GLenum target, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glMultiTexCoord2fv;
        /// <summary>void glMultiTexCoord2fvARB(GLenum target, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glMultiTexCoord2fvARB;
        /// <summary>void glMultiTexCoord2hNV(GLenum target, GLhalfNV s, GLhalfNV t);</summary>
        public readonly delegate* unmanaged<GLenum, GLhalfNV, GLhalfNV, void> glMultiTexCoord2hNV;
        /// <summary>void glMultiTexCoord2hvNV(GLenum target, GLhalfNV[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLhalfNV[], void> glMultiTexCoord2hvNV;
        /// <summary>void glMultiTexCoord2i(GLenum target, GLint s, GLint t);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, void> glMultiTexCoord2i;
        /// <summary>void glMultiTexCoord2iARB(GLenum target, GLint s, GLint t);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, void> glMultiTexCoord2iARB;
        /// <summary>void glMultiTexCoord2iv(GLenum target, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLint[], void> glMultiTexCoord2iv;
        /// <summary>void glMultiTexCoord2ivARB(GLenum target, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLint[], void> glMultiTexCoord2ivARB;
        /// <summary>void glMultiTexCoord2s(GLenum target, GLshort s, GLshort t);</summary>
        public readonly delegate* unmanaged<GLenum, GLshort, GLshort, void> glMultiTexCoord2s;
        /// <summary>void glMultiTexCoord2sARB(GLenum target, GLshort s, GLshort t);</summary>
        public readonly delegate* unmanaged<GLenum, GLshort, GLshort, void> glMultiTexCoord2sARB;
        /// <summary>void glMultiTexCoord2sv(GLenum target, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLshort[], void> glMultiTexCoord2sv;
        /// <summary>void glMultiTexCoord2svARB(GLenum target, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLshort[], void> glMultiTexCoord2svARB;
        /// <summary>void glMultiTexCoord2xOES(GLenum texture, GLfixed s, GLfixed t);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed, GLfixed, void> glMultiTexCoord2xOES;
        /// <summary>void glMultiTexCoord2xvOES(GLenum texture, GLfixed[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed[], void> glMultiTexCoord2xvOES;
        /// <summary>void glMultiTexCoord3bOES(GLenum texture, GLbyte s, GLbyte t, GLbyte r);</summary>
        public readonly delegate* unmanaged<GLenum, GLbyte, GLbyte, GLbyte, void> glMultiTexCoord3bOES;
        /// <summary>void glMultiTexCoord3bvOES(GLenum texture, GLbyte[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLbyte[], void> glMultiTexCoord3bvOES;
        /// <summary>void glMultiTexCoord3d(GLenum target, GLdouble s, GLdouble t, GLdouble r);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble, GLdouble, GLdouble, void> glMultiTexCoord3d;
        /// <summary>void glMultiTexCoord3dARB(GLenum target, GLdouble s, GLdouble t, GLdouble r);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble, GLdouble, GLdouble, void> glMultiTexCoord3dARB;
        /// <summary>void glMultiTexCoord3dv(GLenum target, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble[], void> glMultiTexCoord3dv;
        /// <summary>void glMultiTexCoord3dvARB(GLenum target, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble[], void> glMultiTexCoord3dvARB;
        /// <summary>void glMultiTexCoord3f(GLenum target, GLfloat s, GLfloat t, GLfloat r);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, GLfloat, GLfloat, void> glMultiTexCoord3f;
        /// <summary>void glMultiTexCoord3fARB(GLenum target, GLfloat s, GLfloat t, GLfloat r);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, GLfloat, GLfloat, void> glMultiTexCoord3fARB;
        /// <summary>void glMultiTexCoord3fv(GLenum target, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glMultiTexCoord3fv;
        /// <summary>void glMultiTexCoord3fvARB(GLenum target, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glMultiTexCoord3fvARB;
        /// <summary>void glMultiTexCoord3hNV(GLenum target, GLhalfNV s, GLhalfNV t, GLhalfNV r);</summary>
        public readonly delegate* unmanaged<GLenum, GLhalfNV, GLhalfNV, GLhalfNV, void> glMultiTexCoord3hNV;
        /// <summary>void glMultiTexCoord3hvNV(GLenum target, GLhalfNV[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLhalfNV[], void> glMultiTexCoord3hvNV;
        /// <summary>void glMultiTexCoord3i(GLenum target, GLint s, GLint t, GLint r);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, void> glMultiTexCoord3i;
        /// <summary>void glMultiTexCoord3iARB(GLenum target, GLint s, GLint t, GLint r);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, void> glMultiTexCoord3iARB;
        /// <summary>void glMultiTexCoord3iv(GLenum target, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLint[], void> glMultiTexCoord3iv;
        /// <summary>void glMultiTexCoord3ivARB(GLenum target, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLint[], void> glMultiTexCoord3ivARB;
        /// <summary>void glMultiTexCoord3s(GLenum target, GLshort s, GLshort t, GLshort r);</summary>
        public readonly delegate* unmanaged<GLenum, GLshort, GLshort, GLshort, void> glMultiTexCoord3s;
        /// <summary>void glMultiTexCoord3sARB(GLenum target, GLshort s, GLshort t, GLshort r);</summary>
        public readonly delegate* unmanaged<GLenum, GLshort, GLshort, GLshort, void> glMultiTexCoord3sARB;
        /// <summary>void glMultiTexCoord3sv(GLenum target, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLshort[], void> glMultiTexCoord3sv;
        /// <summary>void glMultiTexCoord3svARB(GLenum target, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLshort[], void> glMultiTexCoord3svARB;
        /// <summary>void glMultiTexCoord3xOES(GLenum texture, GLfixed s, GLfixed t, GLfixed r);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed, GLfixed, GLfixed, void> glMultiTexCoord3xOES;
        /// <summary>void glMultiTexCoord3xvOES(GLenum texture, GLfixed[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed[], void> glMultiTexCoord3xvOES;
        /// <summary>void glMultiTexCoord4bOES(GLenum texture, GLbyte s, GLbyte t, GLbyte r, GLbyte q);</summary>
        public readonly delegate* unmanaged<GLenum, GLbyte, GLbyte, GLbyte, GLbyte, void> glMultiTexCoord4bOES;
        /// <summary>void glMultiTexCoord4bvOES(GLenum texture, GLbyte[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLbyte[], void> glMultiTexCoord4bvOES;
        /// <summary>void glMultiTexCoord4d(GLenum target, GLdouble s, GLdouble t, GLdouble r, GLdouble q);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble, GLdouble, GLdouble, GLdouble, void> glMultiTexCoord4d;
        /// <summary>void glMultiTexCoord4dARB(GLenum target, GLdouble s, GLdouble t, GLdouble r, GLdouble q);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble, GLdouble, GLdouble, GLdouble, void> glMultiTexCoord4dARB;
        /// <summary>void glMultiTexCoord4dv(GLenum target, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble[], void> glMultiTexCoord4dv;
        /// <summary>void glMultiTexCoord4dvARB(GLenum target, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble[], void> glMultiTexCoord4dvARB;
        /// <summary>void glMultiTexCoord4f(GLenum target, GLfloat s, GLfloat t, GLfloat r, GLfloat q);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, GLfloat, GLfloat, GLfloat, void> glMultiTexCoord4f;
        /// <summary>void glMultiTexCoord4fARB(GLenum target, GLfloat s, GLfloat t, GLfloat r, GLfloat q);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, GLfloat, GLfloat, GLfloat, void> glMultiTexCoord4fARB;
        /// <summary>void glMultiTexCoord4fv(GLenum target, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glMultiTexCoord4fv;
        /// <summary>void glMultiTexCoord4fvARB(GLenum target, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glMultiTexCoord4fvARB;
        /// <summary>void glMultiTexCoord4hNV(GLenum target, GLhalfNV s, GLhalfNV t, GLhalfNV r, GLhalfNV q);</summary>
        public readonly delegate* unmanaged<GLenum, GLhalfNV, GLhalfNV, GLhalfNV, GLhalfNV, void> glMultiTexCoord4hNV;
        /// <summary>void glMultiTexCoord4hvNV(GLenum target, GLhalfNV[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLhalfNV[], void> glMultiTexCoord4hvNV;
        /// <summary>void glMultiTexCoord4i(GLenum target, GLint s, GLint t, GLint r, GLint q);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, void> glMultiTexCoord4i;
        /// <summary>void glMultiTexCoord4iARB(GLenum target, GLint s, GLint t, GLint r, GLint q);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, void> glMultiTexCoord4iARB;
        /// <summary>void glMultiTexCoord4iv(GLenum target, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLint[], void> glMultiTexCoord4iv;
        /// <summary>void glMultiTexCoord4ivARB(GLenum target, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLint[], void> glMultiTexCoord4ivARB;
        /// <summary>void glMultiTexCoord4s(GLenum target, GLshort s, GLshort t, GLshort r, GLshort q);</summary>
        public readonly delegate* unmanaged<GLenum, GLshort, GLshort, GLshort, GLshort, void> glMultiTexCoord4s;
        /// <summary>void glMultiTexCoord4sARB(GLenum target, GLshort s, GLshort t, GLshort r, GLshort q);</summary>
        public readonly delegate* unmanaged<GLenum, GLshort, GLshort, GLshort, GLshort, void> glMultiTexCoord4sARB;
        /// <summary>void glMultiTexCoord4sv(GLenum target, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLshort[], void> glMultiTexCoord4sv;
        /// <summary>void glMultiTexCoord4svARB(GLenum target, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLshort[], void> glMultiTexCoord4svARB;
        /// <summary>void glMultiTexCoord4x(GLenum texture, GLfixed s, GLfixed t, GLfixed r, GLfixed q);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed, GLfixed, GLfixed, GLfixed, void> glMultiTexCoord4x;
        /// <summary>void glMultiTexCoord4xOES(GLenum texture, GLfixed s, GLfixed t, GLfixed r, GLfixed q);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed, GLfixed, GLfixed, GLfixed, void> glMultiTexCoord4xOES;
        /// <summary>void glMultiTexCoord4xvOES(GLenum texture, GLfixed[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed[], void> glMultiTexCoord4xvOES;
        /// <summary>void glMultiTexCoordP1ui(GLenum texture, GLenum type, GLuint coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, void> glMultiTexCoordP1ui;
        /// <summary>void glMultiTexCoordP1uiv(GLenum texture, GLenum type, GLuint[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint[], void> glMultiTexCoordP1uiv;
        /// <summary>void glMultiTexCoordP2ui(GLenum texture, GLenum type, GLuint coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, void> glMultiTexCoordP2ui;
        /// <summary>void glMultiTexCoordP2uiv(GLenum texture, GLenum type, GLuint[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint[], void> glMultiTexCoordP2uiv;
        /// <summary>void glMultiTexCoordP3ui(GLenum texture, GLenum type, GLuint coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, void> glMultiTexCoordP3ui;
        /// <summary>void glMultiTexCoordP3uiv(GLenum texture, GLenum type, GLuint[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint[], void> glMultiTexCoordP3uiv;
        /// <summary>void glMultiTexCoordP4ui(GLenum texture, GLenum type, GLuint coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, void> glMultiTexCoordP4ui;
        /// <summary>void glMultiTexCoordP4uiv(GLenum texture, GLenum type, GLuint[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint[], void> glMultiTexCoordP4uiv;
        /// <summary>void glMultiTexCoordPointerEXT(GLenum texunit, GLint size, GLenum type, GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLenum, GLsizei, IntPtr, void> glMultiTexCoordPointerEXT;
        /// <summary>void glMultiTexEnvfEXT(GLenum texunit, GLenum target, GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLfloat, void> glMultiTexEnvfEXT;
        /// <summary>void glMultiTexEnvfvEXT(GLenum texunit, GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLfloat[], void> glMultiTexEnvfvEXT;
        /// <summary>void glMultiTexEnviEXT(GLenum texunit, GLenum target, GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLint, void> glMultiTexEnviEXT;
        /// <summary>void glMultiTexEnvivEXT(GLenum texunit, GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLint[], void> glMultiTexEnvivEXT;
        /// <summary>void glMultiTexGendEXT(GLenum texunit, GLenum coord, GLenum pname, GLdouble param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLdouble, void> glMultiTexGendEXT;
        /// <summary>void glMultiTexGendvEXT(GLenum texunit, GLenum coord, GLenum pname, GLdouble[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLdouble[], void> glMultiTexGendvEXT;
        /// <summary>void glMultiTexGenfEXT(GLenum texunit, GLenum coord, GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLfloat, void> glMultiTexGenfEXT;
        /// <summary>void glMultiTexGenfvEXT(GLenum texunit, GLenum coord, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLfloat[], void> glMultiTexGenfvEXT;
        /// <summary>void glMultiTexGeniEXT(GLenum texunit, GLenum coord, GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLint, void> glMultiTexGeniEXT;
        /// <summary>void glMultiTexGenivEXT(GLenum texunit, GLenum coord, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLint[], void> glMultiTexGenivEXT;
        /// <summary>void glMultiTexImage1DEXT(GLenum texunit, GLenum target, GLint level, GLint internalformat, GLsizei width, GLint border, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLsizei, GLint, GLenum, GLenum, IntPtr, void> glMultiTexImage1DEXT;
        /// <summary>void glMultiTexImage2DEXT(GLenum texunit, GLenum target, GLint level, GLint internalformat, GLsizei width, GLsizei height, GLint border, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLsizei, GLsizei, GLint, GLenum, GLenum, IntPtr, void> glMultiTexImage2DEXT;
        /// <summary>void glMultiTexImage3DEXT(GLenum texunit, GLenum target, GLint level, GLint internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLsizei, GLsizei, GLsizei, GLint, GLenum, GLenum, IntPtr, void> glMultiTexImage3DEXT;
        /// <summary>void glMultiTexParameterIivEXT(GLenum texunit, GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLint[], void> glMultiTexParameterIivEXT;
        /// <summary>void glMultiTexParameterIuivEXT(GLenum texunit, GLenum target, GLenum pname, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLuint[], void> glMultiTexParameterIuivEXT;
        /// <summary>void glMultiTexParameterfEXT(GLenum texunit, GLenum target, GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLfloat, void> glMultiTexParameterfEXT;
        /// <summary>void glMultiTexParameterfvEXT(GLenum texunit, GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLfloat[], void> glMultiTexParameterfvEXT;
        /// <summary>void glMultiTexParameteriEXT(GLenum texunit, GLenum target, GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLint, void> glMultiTexParameteriEXT;
        /// <summary>void glMultiTexParameterivEXT(GLenum texunit, GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLint[], void> glMultiTexParameterivEXT;
        /// <summary>void glMultiTexRenderbufferEXT(GLenum texunit, GLenum target, GLuint renderbuffer);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, void> glMultiTexRenderbufferEXT;
        /// <summary>void glMultiTexSubImage1DEXT(GLenum texunit, GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLsizei, GLenum, GLenum, IntPtr, void> glMultiTexSubImage1DEXT;
        /// <summary>void glMultiTexSubImage2DEXT(GLenum texunit, GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLint, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void> glMultiTexSubImage2DEXT;
        /// <summary>void glMultiTexSubImage3DEXT(GLenum texunit, GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void> glMultiTexSubImage3DEXT;
        /// <summary>void glMulticastBarrierNV();</summary>
        public readonly delegate* unmanaged<void> glMulticastBarrierNV;
        /// <summary>void glMulticastBlitFramebufferNV(GLuint srcGpu, GLuint dstGpu, GLint srcX0, GLint srcY0, GLint srcX1, GLint srcY1, GLint dstX0, GLint dstY0, GLint dstX1, GLint dstY1, GLbitfield mask, GLenum filter);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLint, GLint, GLint, GLint, GLint, GLint, GLint, GLint, GLbitfield, GLenum, void> glMulticastBlitFramebufferNV;
        /// <summary>void glMulticastBufferSubDataNV(GLbitfield gpuMask, GLuint buffer, GLintptr offset, GLsizeiptr size, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLbitfield, GLuint, GLintptr, GLsizeiptr, IntPtr, void> glMulticastBufferSubDataNV;
        /// <summary>void glMulticastCopyBufferSubDataNV(GLuint readGpu, GLbitfield writeGpuMask, GLuint readBuffer, GLuint writeBuffer, GLintptr readOffset, GLintptr writeOffset, GLsizeiptr size);</summary>
        public readonly delegate* unmanaged<GLuint, GLbitfield, GLuint, GLuint, GLintptr, GLintptr, GLsizeiptr, void> glMulticastCopyBufferSubDataNV;
        /// <summary>void glMulticastCopyImageSubDataNV(GLuint srcGpu, GLbitfield dstGpuMask, GLuint srcName, GLenum srcTarget, GLint srcLevel, GLint srcX, GLint srcY, GLint srcZ, GLuint dstName, GLenum dstTarget, GLint dstLevel, GLint dstX, GLint dstY, GLint dstZ, GLsizei srcWidth, GLsizei srcHeight, GLsizei srcDepth);</summary>
        public readonly delegate* unmanaged<GLuint, GLbitfield, GLuint, GLenum, GLint, GLint, GLint, GLint, GLuint, GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, void> glMulticastCopyImageSubDataNV;
        /// <summary>void glMulticastFramebufferSampleLocationsfvNV(GLuint gpu, GLuint framebuffer, GLuint start, GLsizei count, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, GLsizei, GLfloat[], void> glMulticastFramebufferSampleLocationsfvNV;
        /// <summary>void glMulticastGetQueryObjecti64vNV(GLuint gpu, GLuint id, GLenum pname, GLint64[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLint64[], void> glMulticastGetQueryObjecti64vNV;
        /// <summary>void glMulticastGetQueryObjectivNV(GLuint gpu, GLuint id, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLint[], void> glMulticastGetQueryObjectivNV;
        /// <summary>void glMulticastGetQueryObjectui64vNV(GLuint gpu, GLuint id, GLenum pname, GLuint64[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLuint64[], void> glMulticastGetQueryObjectui64vNV;
        /// <summary>void glMulticastGetQueryObjectuivNV(GLuint gpu, GLuint id, GLenum pname, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLuint[], void> glMulticastGetQueryObjectuivNV;
        /// <summary>void glMulticastScissorArrayvNVX(GLuint gpu, GLuint first, GLsizei count, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLsizei, GLint[], void> glMulticastScissorArrayvNVX;
        /// <summary>void glMulticastViewportArrayvNVX(GLuint gpu, GLuint first, GLsizei count, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLsizei, GLfloat[], void> glMulticastViewportArrayvNVX;
        /// <summary>void glMulticastViewportPositionWScaleNVX(GLuint gpu, GLuint index, GLfloat xcoeff, GLfloat ycoeff);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLfloat, GLfloat, void> glMulticastViewportPositionWScaleNVX;
        /// <summary>void glMulticastWaitSyncNV(GLuint signalGpu, GLbitfield waitGpuMask);</summary>
        public readonly delegate* unmanaged<GLuint, GLbitfield, void> glMulticastWaitSyncNV;
        /// <summary>void glNamedBufferAttachMemoryNV(GLuint buffer, GLuint memory, GLuint64 offset);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint64, void> glNamedBufferAttachMemoryNV;
        /// <summary>void glNamedBufferData(GLuint buffer, GLsizeiptr size, IntPtr data, GLenum usage);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizeiptr, IntPtr, GLenum, void> glNamedBufferData;
        /// <summary>void glNamedBufferDataEXT(GLuint buffer, GLsizeiptr size, IntPtr data, GLenum usage);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizeiptr, IntPtr, GLenum, void> glNamedBufferDataEXT;
        /// <summary>void glNamedBufferPageCommitmentARB(GLuint buffer, GLintptr offset, GLsizeiptr size, GLboolean commit);</summary>
        public readonly delegate* unmanaged<GLuint, GLintptr, GLsizeiptr, GLboolean, void> glNamedBufferPageCommitmentARB;
        /// <summary>void glNamedBufferPageCommitmentEXT(GLuint buffer, GLintptr offset, GLsizeiptr size, GLboolean commit);</summary>
        public readonly delegate* unmanaged<GLuint, GLintptr, GLsizeiptr, GLboolean, void> glNamedBufferPageCommitmentEXT;
        /// <summary>void glNamedBufferStorage(GLuint buffer, GLsizeiptr size, IntPtr data, GLbitfield flags);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizeiptr, IntPtr, GLbitfield, void> glNamedBufferStorage;
        /// <summary>void glNamedBufferStorageExternalEXT(GLuint buffer, GLintptr offset, GLsizeiptr size, GLeglClientBufferEXT clientBuffer, GLbitfield flags);</summary>
        public readonly delegate* unmanaged<GLuint, GLintptr, GLsizeiptr, GLeglClientBufferEXT, GLbitfield, void> glNamedBufferStorageExternalEXT;
        /// <summary>void glNamedBufferStorageEXT(GLuint buffer, GLsizeiptr size, IntPtr data, GLbitfield flags);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizeiptr, IntPtr, GLbitfield, void> glNamedBufferStorageEXT;
        /// <summary>void glNamedBufferStorageMemEXT(GLuint buffer, GLsizeiptr size, GLuint memory, GLuint64 offset);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizeiptr, GLuint, GLuint64, void> glNamedBufferStorageMemEXT;
        /// <summary>void glNamedBufferSubData(GLuint buffer, GLintptr offset, GLsizeiptr size, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLuint, GLintptr, GLsizeiptr, IntPtr, void> glNamedBufferSubData;
        /// <summary>void glNamedBufferSubDataEXT(GLuint buffer, GLintptr offset, GLsizeiptr size, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLuint, GLintptr, GLsizeiptr, IntPtr, void> glNamedBufferSubDataEXT;
        /// <summary>void glNamedCopyBufferSubDataEXT(GLuint readBuffer, GLuint writeBuffer, GLintptr readOffset, GLintptr writeOffset, GLsizeiptr size);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLintptr, GLintptr, GLsizeiptr, void> glNamedCopyBufferSubDataEXT;
        /// <summary>void glNamedFramebufferDrawBuffer(GLuint framebuffer, GLenum buf);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, void> glNamedFramebufferDrawBuffer;
        /// <summary>void glNamedFramebufferDrawBuffers(GLuint framebuffer, GLsizei n, GLenum[] bufs);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLenum[], void> glNamedFramebufferDrawBuffers;
        /// <summary>void glNamedFramebufferParameteri(GLuint framebuffer, GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, void> glNamedFramebufferParameteri;
        /// <summary>void glNamedFramebufferParameteriEXT(GLuint framebuffer, GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, void> glNamedFramebufferParameteriEXT;
        /// <summary>void glNamedFramebufferReadBuffer(GLuint framebuffer, GLenum src);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, void> glNamedFramebufferReadBuffer;
        /// <summary>void glNamedFramebufferRenderbuffer(GLuint framebuffer, GLenum attachment, GLenum renderbuffertarget, GLuint renderbuffer);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLuint, void> glNamedFramebufferRenderbuffer;
        /// <summary>void glNamedFramebufferRenderbufferEXT(GLuint framebuffer, GLenum attachment, GLenum renderbuffertarget, GLuint renderbuffer);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLuint, void> glNamedFramebufferRenderbufferEXT;
        /// <summary>void glNamedFramebufferSampleLocationsfvARB(GLuint framebuffer, GLuint start, GLsizei count, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLsizei, GLfloat[], void> glNamedFramebufferSampleLocationsfvARB;
        /// <summary>void glNamedFramebufferSampleLocationsfvNV(GLuint framebuffer, GLuint start, GLsizei count, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLsizei, GLfloat[], void> glNamedFramebufferSampleLocationsfvNV;
        /// <summary>void glNamedFramebufferTexture(GLuint framebuffer, GLenum attachment, GLuint texture, GLint level);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLint, void> glNamedFramebufferTexture;
        /// <summary>void glNamedFramebufferSamplePositionsfvAMD(GLuint framebuffer, GLuint numsamples, GLuint pixelindex, GLfloat[] values);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, GLfloat[], void> glNamedFramebufferSamplePositionsfvAMD;
        /// <summary>void glNamedFramebufferTexture1DEXT(GLuint framebuffer, GLenum attachment, GLenum textarget, GLuint texture, GLint level);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLuint, GLint, void> glNamedFramebufferTexture1DEXT;
        /// <summary>void glNamedFramebufferTexture2DEXT(GLuint framebuffer, GLenum attachment, GLenum textarget, GLuint texture, GLint level);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLuint, GLint, void> glNamedFramebufferTexture2DEXT;
        /// <summary>void glNamedFramebufferTexture3DEXT(GLuint framebuffer, GLenum attachment, GLenum textarget, GLuint texture, GLint level, GLint zoffset);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLuint, GLint, GLint, void> glNamedFramebufferTexture3DEXT;
        /// <summary>void glNamedFramebufferTextureEXT(GLuint framebuffer, GLenum attachment, GLuint texture, GLint level);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLint, void> glNamedFramebufferTextureEXT;
        /// <summary>void glNamedFramebufferTextureFaceEXT(GLuint framebuffer, GLenum attachment, GLuint texture, GLint level, GLenum face);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLint, GLenum, void> glNamedFramebufferTextureFaceEXT;
        /// <summary>void glNamedFramebufferTextureLayer(GLuint framebuffer, GLenum attachment, GLuint texture, GLint level, GLint layer);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLint, GLint, void> glNamedFramebufferTextureLayer;
        /// <summary>void glNamedFramebufferTextureLayerEXT(GLuint framebuffer, GLenum attachment, GLuint texture, GLint level, GLint layer);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLint, GLint, void> glNamedFramebufferTextureLayerEXT;
        /// <summary>void glNamedProgramLocalParameter4dEXT(GLuint program, GLenum target, GLuint index, GLdouble x, GLdouble y, GLdouble z, GLdouble w);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLdouble, GLdouble, GLdouble, GLdouble, void> glNamedProgramLocalParameter4dEXT;
        /// <summary>void glNamedProgramLocalParameter4dvEXT(GLuint program, GLenum target, GLuint index, GLdouble[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLdouble[], void> glNamedProgramLocalParameter4dvEXT;
        /// <summary>void glNamedProgramLocalParameter4fEXT(GLuint program, GLenum target, GLuint index, GLfloat x, GLfloat y, GLfloat z, GLfloat w);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLfloat, GLfloat, GLfloat, GLfloat, void> glNamedProgramLocalParameter4fEXT;
        /// <summary>void glNamedProgramLocalParameter4fvEXT(GLuint program, GLenum target, GLuint index, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLfloat[], void> glNamedProgramLocalParameter4fvEXT;
        /// <summary>void glNamedProgramLocalParameterI4iEXT(GLuint program, GLenum target, GLuint index, GLint x, GLint y, GLint z, GLint w);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLint, GLint, GLint, GLint, void> glNamedProgramLocalParameterI4iEXT;
        /// <summary>void glNamedProgramLocalParameterI4ivEXT(GLuint program, GLenum target, GLuint index, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLint[], void> glNamedProgramLocalParameterI4ivEXT;
        /// <summary>void glNamedProgramLocalParameterI4uiEXT(GLuint program, GLenum target, GLuint index, GLuint x, GLuint y, GLuint z, GLuint w);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLuint, GLuint, GLuint, GLuint, void> glNamedProgramLocalParameterI4uiEXT;
        /// <summary>void glNamedProgramLocalParameterI4uivEXT(GLuint program, GLenum target, GLuint index, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLuint[], void> glNamedProgramLocalParameterI4uivEXT;
        /// <summary>void glNamedProgramLocalParameters4fvEXT(GLuint program, GLenum target, GLuint index, GLsizei count, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLsizei, GLfloat[], void> glNamedProgramLocalParameters4fvEXT;
        /// <summary>void glNamedProgramLocalParametersI4ivEXT(GLuint program, GLenum target, GLuint index, GLsizei count, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLsizei, GLint[], void> glNamedProgramLocalParametersI4ivEXT;
        /// <summary>void glNamedProgramLocalParametersI4uivEXT(GLuint program, GLenum target, GLuint index, GLsizei count, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLsizei, GLuint[], void> glNamedProgramLocalParametersI4uivEXT;
        /// <summary>void glNamedProgramStringEXT(GLuint program, GLenum target, GLenum format, GLsizei len, IntPtr string);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLsizei, IntPtr, void> glNamedProgramStringEXT;
        /// <summary>void glNamedRenderbufferStorage(GLuint renderbuffer, GLenum internalformat, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLsizei, GLsizei, void> glNamedRenderbufferStorage;
        /// <summary>void glNamedRenderbufferStorageEXT(GLuint renderbuffer, GLenum internalformat, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLsizei, GLsizei, void> glNamedRenderbufferStorageEXT;
        /// <summary>void glNamedRenderbufferStorageMultisample(GLuint renderbuffer, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLenum, GLsizei, GLsizei, void> glNamedRenderbufferStorageMultisample;
        /// <summary>void glNamedRenderbufferStorageMultisampleAdvancedAMD(GLuint renderbuffer, GLsizei samples, GLsizei storageSamples, GLenum internalformat, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLsizei, GLenum, GLsizei, GLsizei, void> glNamedRenderbufferStorageMultisampleAdvancedAMD;
        /// <summary>void glNamedRenderbufferStorageMultisampleCoverageEXT(GLuint renderbuffer, GLsizei coverageSamples, GLsizei colorSamples, GLenum internalformat, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLsizei, GLenum, GLsizei, GLsizei, void> glNamedRenderbufferStorageMultisampleCoverageEXT;
        /// <summary>void glNamedRenderbufferStorageMultisampleEXT(GLuint renderbuffer, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLenum, GLsizei, GLsizei, void> glNamedRenderbufferStorageMultisampleEXT;
        /// <summary>void glNamedStringARB(GLenum type, GLint namelen, string name, GLint stringlen, string string);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, string, GLint, string, void> glNamedStringARB;
        /// <summary>void glNewList(GLuint list, GLenum mode);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, void> glNewList;
        /// <summary>GLuint glNewObjectBufferATI(GLsizei size, IntPtr pointer, GLenum usage);</summary>
        public readonly delegate* unmanaged<GLsizei, IntPtr, GLenum, GLuint> glNewObjectBufferATI;
        /// <summary>void glNormal3b(GLbyte nx, GLbyte ny, GLbyte nz);</summary>
        public readonly delegate* unmanaged<GLbyte, GLbyte, GLbyte, void> glNormal3b;
        /// <summary>void glNormal3bv(GLbyte[] v);</summary>
        public readonly delegate* unmanaged<GLbyte[], void> glNormal3bv;
        /// <summary>void glNormal3d(GLdouble nx, GLdouble ny, GLdouble nz);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, GLdouble, void> glNormal3d;
        /// <summary>void glNormal3dv(GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glNormal3dv;
        /// <summary>void glNormal3f(GLfloat nx, GLfloat ny, GLfloat nz);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, void> glNormal3f;
        /// <summary>void glNormal3fVertex3fSUN(GLfloat nx, GLfloat ny, GLfloat nz, GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glNormal3fVertex3fSUN;
        /// <summary>void glNormal3fVertex3fvSUN(GLfloat[] n, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], GLfloat[], void> glNormal3fVertex3fvSUN;
        /// <summary>void glNormal3fv(GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glNormal3fv;
        /// <summary>void glNormal3hNV(GLhalfNV nx, GLhalfNV ny, GLhalfNV nz);</summary>
        public readonly delegate* unmanaged<GLhalfNV, GLhalfNV, GLhalfNV, void> glNormal3hNV;
        /// <summary>void glNormal3hvNV(GLhalfNV[] v);</summary>
        public readonly delegate* unmanaged<GLhalfNV[], void> glNormal3hvNV;
        /// <summary>void glNormal3i(GLint nx, GLint ny, GLint nz);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, void> glNormal3i;
        /// <summary>void glNormal3iv(GLint[] v);</summary>
        public readonly delegate* unmanaged<GLint[], void> glNormal3iv;
        /// <summary>void glNormal3s(GLshort nx, GLshort ny, GLshort nz);</summary>
        public readonly delegate* unmanaged<GLshort, GLshort, GLshort, void> glNormal3s;
        /// <summary>void glNormal3sv(GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLshort[], void> glNormal3sv;
        /// <summary>void glNormal3x(GLfixed nx, GLfixed ny, GLfixed nz);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, GLfixed, void> glNormal3x;
        /// <summary>void glNormal3xOES(GLfixed nx, GLfixed ny, GLfixed nz);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, GLfixed, void> glNormal3xOES;
        /// <summary>void glNormal3xvOES(GLfixed[] coords);</summary>
        public readonly delegate* unmanaged<GLfixed[], void> glNormal3xvOES;
        /// <summary>void glNormalFormatNV(GLenum type, GLsizei stride);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, void> glNormalFormatNV;
        /// <summary>void glNormalP3ui(GLenum type, GLuint coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glNormalP3ui;
        /// <summary>void glNormalP3uiv(GLenum type, GLuint[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint[], void> glNormalP3uiv;
        /// <summary>void glNormalPointer(GLenum type, GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, IntPtr, void> glNormalPointer;
        /// <summary>void glNormalPointerEXT(GLenum type, GLsizei stride, GLsizei count, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLsizei, IntPtr, void> glNormalPointerEXT;
        /// <summary>void glNormalPointerListIBM(GLenum type, GLint stride, IntPtr pointer, GLint ptrstride);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, IntPtr, GLint, void> glNormalPointerListIBM;
        /// <summary>void glNormalPointervINTEL(GLenum type, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLenum, IntPtr, void> glNormalPointervINTEL;
        /// <summary>void glNormalStream3bATI(GLenum stream, GLbyte nx, GLbyte ny, GLbyte nz);</summary>
        public readonly delegate* unmanaged<GLenum, GLbyte, GLbyte, GLbyte, void> glNormalStream3bATI;
        /// <summary>void glNormalStream3bvATI(GLenum stream, GLbyte[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLbyte[], void> glNormalStream3bvATI;
        /// <summary>void glNormalStream3dATI(GLenum stream, GLdouble nx, GLdouble ny, GLdouble nz);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble, GLdouble, GLdouble, void> glNormalStream3dATI;
        /// <summary>void glNormalStream3dvATI(GLenum stream, GLdouble[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble[], void> glNormalStream3dvATI;
        /// <summary>void glNormalStream3fATI(GLenum stream, GLfloat nx, GLfloat ny, GLfloat nz);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, GLfloat, GLfloat, void> glNormalStream3fATI;
        /// <summary>void glNormalStream3fvATI(GLenum stream, GLfloat[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glNormalStream3fvATI;
        /// <summary>void glNormalStream3iATI(GLenum stream, GLint nx, GLint ny, GLint nz);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, void> glNormalStream3iATI;
        /// <summary>void glNormalStream3ivATI(GLenum stream, GLint[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLint[], void> glNormalStream3ivATI;
        /// <summary>void glNormalStream3sATI(GLenum stream, GLshort nx, GLshort ny, GLshort nz);</summary>
        public readonly delegate* unmanaged<GLenum, GLshort, GLshort, GLshort, void> glNormalStream3sATI;
        /// <summary>void glNormalStream3svATI(GLenum stream, GLshort[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLshort[], void> glNormalStream3svATI;
        /// <summary>void glObjectLabel(GLenum identifier, GLuint name, GLsizei length, string label);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLsizei, string, void> glObjectLabel;
        /// <summary>void glObjectLabelKHR(GLenum identifier, GLuint name, GLsizei length, string label);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLsizei, string, void> glObjectLabelKHR;
        /// <summary>void glObjectPtrLabel(IntPtr ptr, GLsizei length, string label);</summary>
        public readonly delegate* unmanaged<IntPtr, GLsizei, string, void> glObjectPtrLabel;
        /// <summary>void glObjectPtrLabelKHR(IntPtr ptr, GLsizei length, string label);</summary>
        public readonly delegate* unmanaged<IntPtr, GLsizei, string, void> glObjectPtrLabelKHR;
        /// <summary>GLenum glObjectPurgeableAPPLE(GLenum objectType, GLuint name, GLenum option);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLenum, GLenum> glObjectPurgeableAPPLE;
        /// <summary>GLenum glObjectUnpurgeableAPPLE(GLenum objectType, GLuint name, GLenum option);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLenum, GLenum> glObjectUnpurgeableAPPLE;
        /// <summary>void glOrtho(GLdouble left, GLdouble right, GLdouble bottom, GLdouble top, GLdouble zNear, GLdouble zFar);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, GLdouble, GLdouble, GLdouble, GLdouble, void> glOrtho;
        /// <summary>void glOrthof(GLfloat l, GLfloat r, GLfloat b, GLfloat t, GLfloat n, GLfloat f);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glOrthof;
        /// <summary>void glOrthofOES(GLfloat l, GLfloat r, GLfloat b, GLfloat t, GLfloat n, GLfloat f);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glOrthofOES;
        /// <summary>void glOrthox(GLfixed l, GLfixed r, GLfixed b, GLfixed t, GLfixed n, GLfixed f);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, GLfixed, GLfixed, void> glOrthox;
        /// <summary>void glOrthoxOES(GLfixed l, GLfixed r, GLfixed b, GLfixed t, GLfixed n, GLfixed f);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, GLfixed, GLfixed, void> glOrthoxOES;
        /// <summary>void glPNTrianglesfATI(GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, void> glPNTrianglesfATI;
        /// <summary>void glPNTrianglesiATI(GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, void> glPNTrianglesiATI;
        /// <summary>void glPassTexCoordATI(GLuint dst, GLuint coord, GLenum swizzle);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, void> glPassTexCoordATI;
        /// <summary>void glPassThrough(GLfloat token);</summary>
        public readonly delegate* unmanaged<GLfloat, void> glPassThrough;
        /// <summary>void glPassThroughxOES(GLfixed token);</summary>
        public readonly delegate* unmanaged<GLfixed, void> glPassThroughxOES;
        /// <summary>void glPatchParameterfv(GLenum pname, GLfloat[] values);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glPatchParameterfv;
        /// <summary>void glPatchParameteri(GLenum pname, GLint value);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, void> glPatchParameteri;
        /// <summary>void glPatchParameteriEXT(GLenum pname, GLint value);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, void> glPatchParameteriEXT;
        /// <summary>void glPatchParameteriOES(GLenum pname, GLint value);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, void> glPatchParameteriOES;
        /// <summary>void glPathColorGenNV(GLenum color, GLenum genMode, GLenum colorFormat, GLfloat[] coeffs);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLfloat[], void> glPathColorGenNV;
        /// <summary>void glPathCommandsNV(GLuint path, GLsizei numCommands, GLubyte[] commands, GLsizei numCoords, GLenum coordType, IntPtr coords);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLubyte[], GLsizei, GLenum, IntPtr, void> glPathCommandsNV;
        /// <summary>void glPathCoordsNV(GLuint path, GLsizei numCoords, GLenum coordType, IntPtr coords);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLenum, IntPtr, void> glPathCoordsNV;
        /// <summary>void glPathCoverDepthFuncNV(GLenum func);</summary>
        public readonly delegate* unmanaged<GLenum, void> glPathCoverDepthFuncNV;
        /// <summary>void glPathDashArrayNV(GLuint path, GLsizei dashCount, GLfloat[] dashArray);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLfloat[], void> glPathDashArrayNV;
        /// <summary>void glPathFogGenNV(GLenum genMode);</summary>
        public readonly delegate* unmanaged<GLenum, void> glPathFogGenNV;
        /// <summary>GLenum glPathGlyphIndexArrayNV(GLuint firstPathName, GLenum fontTarget, IntPtr fontName, GLbitfield fontStyle, GLuint firstGlyphIndex, GLsizei numGlyphs, GLuint pathParameterTemplate, GLfloat emScale);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, IntPtr, GLbitfield, GLuint, GLsizei, GLuint, GLfloat, GLenum> glPathGlyphIndexArrayNV;
        /// <summary>GLenum glPathGlyphIndexRangeNV(GLenum fontTarget, IntPtr fontName, GLbitfield fontStyle, GLuint pathParameterTemplate, GLfloat emScale, GLuint baseAndCount);</summary>
        public readonly delegate* unmanaged<GLenum, IntPtr, GLbitfield, GLuint, GLfloat, GLuint, GLenum> glPathGlyphIndexRangeNV;
        /// <summary>void glPathGlyphRangeNV(GLuint firstPathName, GLenum fontTarget, IntPtr fontName, GLbitfield fontStyle, GLuint firstGlyph, GLsizei numGlyphs, GLenum handleMissingGlyphs, GLuint pathParameterTemplate, GLfloat emScale);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, IntPtr, GLbitfield, GLuint, GLsizei, GLenum, GLuint, GLfloat, void> glPathGlyphRangeNV;
        /// <summary>void glPathGlyphsNV(GLuint firstPathName, GLenum fontTarget, IntPtr fontName, GLbitfield fontStyle, GLsizei numGlyphs, GLenum type, IntPtr charcodes, GLenum handleMissingGlyphs, GLuint pathParameterTemplate, GLfloat emScale);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, IntPtr, GLbitfield, GLsizei, GLenum, IntPtr, GLenum, GLuint, GLfloat, void> glPathGlyphsNV;
        /// <summary>GLenum glPathMemoryGlyphIndexArrayNV(GLuint firstPathName, GLenum fontTarget, GLsizeiptr fontSize, IntPtr fontData, GLsizei faceIndex, GLuint firstGlyphIndex, GLsizei numGlyphs, GLuint pathParameterTemplate, GLfloat emScale);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLsizeiptr, IntPtr, GLsizei, GLuint, GLsizei, GLuint, GLfloat, GLenum> glPathMemoryGlyphIndexArrayNV;
        /// <summary>void glPathParameterfNV(GLuint path, GLenum pname, GLfloat value);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLfloat, void> glPathParameterfNV;
        /// <summary>void glPathParameterfvNV(GLuint path, GLenum pname, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLfloat[], void> glPathParameterfvNV;
        /// <summary>void glPathParameteriNV(GLuint path, GLenum pname, GLint value);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, void> glPathParameteriNV;
        /// <summary>void glPathParameterivNV(GLuint path, GLenum pname, GLint[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glPathParameterivNV;
        /// <summary>void glPathStencilDepthOffsetNV(GLfloat factor, GLfloat units);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, void> glPathStencilDepthOffsetNV;
        /// <summary>void glPathStencilFuncNV(GLenum func, GLint ref, GLuint mask);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLuint, void> glPathStencilFuncNV;
        /// <summary>void glPathStringNV(GLuint path, GLenum format, GLsizei length, IntPtr pathString);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLsizei, IntPtr, void> glPathStringNV;
        /// <summary>void glPathSubCommandsNV(GLuint path, GLsizei commandStart, GLsizei commandsToDelete, GLsizei numCommands, GLubyte[] commands, GLsizei numCoords, GLenum coordType, IntPtr coords);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLsizei, GLsizei, GLubyte[], GLsizei, GLenum, IntPtr, void> glPathSubCommandsNV;
        /// <summary>void glPathSubCoordsNV(GLuint path, GLsizei coordStart, GLsizei numCoords, GLenum coordType, IntPtr coords);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLsizei, GLenum, IntPtr, void> glPathSubCoordsNV;
        /// <summary>void glPathTexGenNV(GLenum texCoordSet, GLenum genMode, GLint components, GLfloat[] coeffs);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLfloat[], void> glPathTexGenNV;
        /// <summary>void glPauseTransformFeedback();</summary>
        public readonly delegate* unmanaged<void> glPauseTransformFeedback;
        /// <summary>void glPauseTransformFeedbackNV();</summary>
        public readonly delegate* unmanaged<void> glPauseTransformFeedbackNV;
        /// <summary>void glPixelDataRangeNV(GLenum target, GLsizei length, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, IntPtr, void> glPixelDataRangeNV;
        /// <summary>void glPixelMapfv(GLenum map, GLsizei mapsize, GLfloat[] values);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLfloat[], void> glPixelMapfv;
        /// <summary>void glPixelMapuiv(GLenum map, GLsizei mapsize, GLuint[] values);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLuint[], void> glPixelMapuiv;
        /// <summary>void glPixelMapusv(GLenum map, GLsizei mapsize, GLushort[] values);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLushort[], void> glPixelMapusv;
        /// <summary>void glPixelMapx(GLenum map, GLint size, GLfixed[] values);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLfixed[], void> glPixelMapx;
        /// <summary>void glPixelStoref(GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, void> glPixelStoref;
        /// <summary>void glPixelStorei(GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, void> glPixelStorei;
        /// <summary>void glPixelStorex(GLenum pname, GLfixed param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed, void> glPixelStorex;
        /// <summary>void glPixelTexGenParameterfSGIS(GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, void> glPixelTexGenParameterfSGIS;
        /// <summary>void glPixelTexGenParameterfvSGIS(GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glPixelTexGenParameterfvSGIS;
        /// <summary>void glPixelTexGenParameteriSGIS(GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, void> glPixelTexGenParameteriSGIS;
        /// <summary>void glPixelTexGenParameterivSGIS(GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLint[], void> glPixelTexGenParameterivSGIS;
        /// <summary>void glPixelTexGenSGIX(GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, void> glPixelTexGenSGIX;
        /// <summary>void glPixelTransferf(GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, void> glPixelTransferf;
        /// <summary>void glPixelTransferi(GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, void> glPixelTransferi;
        /// <summary>void glPixelTransferxOES(GLenum pname, GLfixed param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed, void> glPixelTransferxOES;
        /// <summary>void glPixelTransformParameterfEXT(GLenum target, GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat, void> glPixelTransformParameterfEXT;
        /// <summary>void glPixelTransformParameterfvEXT(GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glPixelTransformParameterfvEXT;
        /// <summary>void glPixelTransformParameteriEXT(GLenum target, GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, void> glPixelTransformParameteriEXT;
        /// <summary>void glPixelTransformParameterivEXT(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glPixelTransformParameterivEXT;
        /// <summary>void glPixelZoom(GLfloat xfactor, GLfloat yfactor);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, void> glPixelZoom;
        /// <summary>void glPixelZoomxOES(GLfixed xfactor, GLfixed yfactor);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, void> glPixelZoomxOES;
        /// <summary>GLboolean glPointAlongPathNV(GLuint path, GLsizei startSegment, GLsizei numSegments, GLfloat distance, GLfloat[] x, GLfloat[] y, GLfloat[] tangentX, GLfloat[] tangentY);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLsizei, GLfloat, GLfloat[], GLfloat[], GLfloat[], GLfloat[], GLboolean> glPointAlongPathNV;
        /// <summary>void glPointParameterf(GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, void> glPointParameterf;
        /// <summary>void glPointParameterfARB(GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, void> glPointParameterfARB;
        /// <summary>void glPointParameterfEXT(GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, void> glPointParameterfEXT;
        /// <summary>void glPointParameterfSGIS(GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, void> glPointParameterfSGIS;
        /// <summary>void glPointParameterfv(GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glPointParameterfv;
        /// <summary>void glPointParameterfvARB(GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glPointParameterfvARB;
        /// <summary>void glPointParameterfvEXT(GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glPointParameterfvEXT;
        /// <summary>void glPointParameterfvSGIS(GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glPointParameterfvSGIS;
        /// <summary>void glPointParameteri(GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, void> glPointParameteri;
        /// <summary>void glPointParameteriNV(GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, void> glPointParameteriNV;
        /// <summary>void glPointParameteriv(GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLint[], void> glPointParameteriv;
        /// <summary>void glPointParameterivNV(GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLint[], void> glPointParameterivNV;
        /// <summary>void glPointParameterx(GLenum pname, GLfixed param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed, void> glPointParameterx;
        /// <summary>void glPointParameterxOES(GLenum pname, GLfixed param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed, void> glPointParameterxOES;
        /// <summary>void glPointParameterxv(GLenum pname, GLfixed[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed[], void> glPointParameterxv;
        /// <summary>void glPointParameterxvOES(GLenum pname, GLfixed[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLfixed[], void> glPointParameterxvOES;
        /// <summary>void glPointSize(GLfloat size);</summary>
        public readonly delegate* unmanaged<GLfloat, void> glPointSize;
        /// <summary>void glPointSizePointerOES(GLenum type, GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, IntPtr, void> glPointSizePointerOES;
        /// <summary>void glPointSizex(GLfixed size);</summary>
        public readonly delegate* unmanaged<GLfixed, void> glPointSizex;
        /// <summary>void glPointSizexOES(GLfixed size);</summary>
        public readonly delegate* unmanaged<GLfixed, void> glPointSizexOES;
        /// <summary>GLint glPollAsyncSGIX(GLuint[] markerp);</summary>
        public readonly delegate* unmanaged<GLuint[], GLint> glPollAsyncSGIX;
        /// <summary>GLint glPollInstrumentsSGIX(GLint[] marker_p);</summary>
        public readonly delegate* unmanaged<GLint[], GLint> glPollInstrumentsSGIX;
        /// <summary>void glPolygonMode(GLenum face, GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, void> glPolygonMode;
        /// <summary>void glPolygonModeNV(GLenum face, GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, void> glPolygonModeNV;
        /// <summary>void glPolygonOffset(GLfloat factor, GLfloat units);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, void> glPolygonOffset;
        /// <summary>void glPolygonOffsetClamp(GLfloat factor, GLfloat units, GLfloat clamp);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, void> glPolygonOffsetClamp;
        /// <summary>void glPolygonOffsetClampEXT(GLfloat factor, GLfloat units, GLfloat clamp);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, void> glPolygonOffsetClampEXT;
        /// <summary>void glPolygonOffsetEXT(GLfloat factor, GLfloat bias);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, void> glPolygonOffsetEXT;
        /// <summary>void glPolygonOffsetx(GLfixed factor, GLfixed units);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, void> glPolygonOffsetx;
        /// <summary>void glPolygonOffsetxOES(GLfixed factor, GLfixed units);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, void> glPolygonOffsetxOES;
        /// <summary>void glPolygonStipple(GLubyte[] mask);</summary>
        public readonly delegate* unmanaged<GLubyte[], void> glPolygonStipple;
        /// <summary>void glPopAttrib();</summary>
        public readonly delegate* unmanaged<void> glPopAttrib;
        /// <summary>void glPopClientAttrib();</summary>
        public readonly delegate* unmanaged<void> glPopClientAttrib;
        /// <summary>void glPopDebugGroup();</summary>
        public readonly delegate* unmanaged<void> glPopDebugGroup;
        /// <summary>void glPopDebugGroupKHR();</summary>
        public readonly delegate* unmanaged<void> glPopDebugGroupKHR;
        /// <summary>void glPopGroupMarkerEXT();</summary>
        public readonly delegate* unmanaged<void> glPopGroupMarkerEXT;
        /// <summary>void glPopMatrix();</summary>
        public readonly delegate* unmanaged<void> glPopMatrix;
        /// <summary>void glPopName();</summary>
        public readonly delegate* unmanaged<void> glPopName;
        /// <summary>void glPresentFrameDualFillNV(GLuint video_slot, GLuint64EXT minPresentTime, GLuint beginPresentTimeId, GLuint presentDurationId, GLenum type, GLenum target0, GLuint fill0, GLenum target1, GLuint fill1, GLenum target2, GLuint fill2, GLenum target3, GLuint fill3);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint64EXT, GLuint, GLuint, GLenum, GLenum, GLuint, GLenum, GLuint, GLenum, GLuint, GLenum, GLuint, void> glPresentFrameDualFillNV;
        /// <summary>void glPresentFrameKeyedNV(GLuint video_slot, GLuint64EXT minPresentTime, GLuint beginPresentTimeId, GLuint presentDurationId, GLenum type, GLenum target0, GLuint fill0, GLuint key0, GLenum target1, GLuint fill1, GLuint key1);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint64EXT, GLuint, GLuint, GLenum, GLenum, GLuint, GLuint, GLenum, GLuint, GLuint, void> glPresentFrameKeyedNV;
        /// <summary>void glPrimitiveBoundingBox(GLfloat minX, GLfloat minY, GLfloat minZ, GLfloat minW, GLfloat maxX, GLfloat maxY, GLfloat maxZ, GLfloat maxW);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glPrimitiveBoundingBox;
        /// <summary>void glPrimitiveBoundingBoxARB(GLfloat minX, GLfloat minY, GLfloat minZ, GLfloat minW, GLfloat maxX, GLfloat maxY, GLfloat maxZ, GLfloat maxW);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glPrimitiveBoundingBoxARB;
        /// <summary>void glPrimitiveBoundingBoxEXT(GLfloat minX, GLfloat minY, GLfloat minZ, GLfloat minW, GLfloat maxX, GLfloat maxY, GLfloat maxZ, GLfloat maxW);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glPrimitiveBoundingBoxEXT;
        /// <summary>void glPrimitiveBoundingBoxOES(GLfloat minX, GLfloat minY, GLfloat minZ, GLfloat minW, GLfloat maxX, GLfloat maxY, GLfloat maxZ, GLfloat maxW);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glPrimitiveBoundingBoxOES;
        /// <summary>void glPrimitiveRestartIndex(GLuint index);</summary>
        public readonly delegate* unmanaged<GLuint, void> glPrimitiveRestartIndex;
        /// <summary>void glPrimitiveRestartIndexNV(GLuint index);</summary>
        public readonly delegate* unmanaged<GLuint, void> glPrimitiveRestartIndexNV;
        /// <summary>void glPrimitiveRestartNV();</summary>
        public readonly delegate* unmanaged<void> glPrimitiveRestartNV;
        /// <summary>void glPrioritizeTextures(GLsizei n, GLuint[] textures, GLfloat[] priorities);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], GLfloat[], void> glPrioritizeTextures;
        /// <summary>void glPrioritizeTexturesEXT(GLsizei n, GLuint[] textures, GLclampf[] priorities);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], GLclampf[], void> glPrioritizeTexturesEXT;
        /// <summary>void glPrioritizeTexturesxOES(GLsizei n, GLuint[] textures, GLfixed[] priorities);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], GLfixed[], void> glPrioritizeTexturesxOES;
        /// <summary>void glProgramBinary(GLuint program, GLenum binaryFormat, IntPtr binary, GLsizei length);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, IntPtr, GLsizei, void> glProgramBinary;
        /// <summary>void glProgramBinaryOES(GLuint program, GLenum binaryFormat, IntPtr binary, GLint length);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, IntPtr, GLint, void> glProgramBinaryOES;
        /// <summary>void glProgramBufferParametersIivNV(GLenum target, GLuint bindingIndex, GLuint wordIndex, GLsizei count, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLsizei, GLint[], void> glProgramBufferParametersIivNV;
        /// <summary>void glProgramBufferParametersIuivNV(GLenum target, GLuint bindingIndex, GLuint wordIndex, GLsizei count, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLsizei, GLuint[], void> glProgramBufferParametersIuivNV;
        /// <summary>void glProgramBufferParametersfvNV(GLenum target, GLuint bindingIndex, GLuint wordIndex, GLsizei count, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLsizei, GLfloat[], void> glProgramBufferParametersfvNV;
        /// <summary>void glProgramEnvParameter4dARB(GLenum target, GLuint index, GLdouble x, GLdouble y, GLdouble z, GLdouble w);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLdouble, GLdouble, GLdouble, GLdouble, void> glProgramEnvParameter4dARB;
        /// <summary>void glProgramEnvParameter4dvARB(GLenum target, GLuint index, GLdouble[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLdouble[], void> glProgramEnvParameter4dvARB;
        /// <summary>void glProgramEnvParameter4fARB(GLenum target, GLuint index, GLfloat x, GLfloat y, GLfloat z, GLfloat w);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLfloat, GLfloat, GLfloat, GLfloat, void> glProgramEnvParameter4fARB;
        /// <summary>void glProgramEnvParameter4fvARB(GLenum target, GLuint index, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLfloat[], void> glProgramEnvParameter4fvARB;
        /// <summary>void glProgramEnvParameterI4iNV(GLenum target, GLuint index, GLint x, GLint y, GLint z, GLint w);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLint, GLint, GLint, GLint, void> glProgramEnvParameterI4iNV;
        /// <summary>void glProgramEnvParameterI4ivNV(GLenum target, GLuint index, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLint[], void> glProgramEnvParameterI4ivNV;
        /// <summary>void glProgramEnvParameterI4uiNV(GLenum target, GLuint index, GLuint x, GLuint y, GLuint z, GLuint w);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLuint, GLuint, GLuint, void> glProgramEnvParameterI4uiNV;
        /// <summary>void glProgramEnvParameterI4uivNV(GLenum target, GLuint index, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint[], void> glProgramEnvParameterI4uivNV;
        /// <summary>void glProgramEnvParameters4fvEXT(GLenum target, GLuint index, GLsizei count, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLsizei, GLfloat[], void> glProgramEnvParameters4fvEXT;
        /// <summary>void glProgramEnvParametersI4ivNV(GLenum target, GLuint index, GLsizei count, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLsizei, GLint[], void> glProgramEnvParametersI4ivNV;
        /// <summary>void glProgramEnvParametersI4uivNV(GLenum target, GLuint index, GLsizei count, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLsizei, GLuint[], void> glProgramEnvParametersI4uivNV;
        /// <summary>void glProgramLocalParameter4dARB(GLenum target, GLuint index, GLdouble x, GLdouble y, GLdouble z, GLdouble w);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLdouble, GLdouble, GLdouble, GLdouble, void> glProgramLocalParameter4dARB;
        /// <summary>void glProgramLocalParameter4dvARB(GLenum target, GLuint index, GLdouble[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLdouble[], void> glProgramLocalParameter4dvARB;
        /// <summary>void glProgramLocalParameter4fARB(GLenum target, GLuint index, GLfloat x, GLfloat y, GLfloat z, GLfloat w);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLfloat, GLfloat, GLfloat, GLfloat, void> glProgramLocalParameter4fARB;
        /// <summary>void glProgramLocalParameter4fvARB(GLenum target, GLuint index, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLfloat[], void> glProgramLocalParameter4fvARB;
        /// <summary>void glProgramLocalParameterI4iNV(GLenum target, GLuint index, GLint x, GLint y, GLint z, GLint w);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLint, GLint, GLint, GLint, void> glProgramLocalParameterI4iNV;
        /// <summary>void glProgramLocalParameterI4ivNV(GLenum target, GLuint index, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLint[], void> glProgramLocalParameterI4ivNV;
        /// <summary>void glProgramLocalParameterI4uiNV(GLenum target, GLuint index, GLuint x, GLuint y, GLuint z, GLuint w);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLuint, GLuint, GLuint, void> glProgramLocalParameterI4uiNV;
        /// <summary>void glProgramLocalParameterI4uivNV(GLenum target, GLuint index, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint[], void> glProgramLocalParameterI4uivNV;
        /// <summary>void glProgramLocalParameters4fvEXT(GLenum target, GLuint index, GLsizei count, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLsizei, GLfloat[], void> glProgramLocalParameters4fvEXT;
        /// <summary>void glProgramLocalParametersI4ivNV(GLenum target, GLuint index, GLsizei count, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLsizei, GLint[], void> glProgramLocalParametersI4ivNV;
        /// <summary>void glProgramLocalParametersI4uivNV(GLenum target, GLuint index, GLsizei count, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLsizei, GLuint[], void> glProgramLocalParametersI4uivNV;
        /// <summary>void glProgramNamedParameter4dNV(GLuint id, GLsizei len, GLubyte[] name, GLdouble x, GLdouble y, GLdouble z, GLdouble w);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLubyte[], GLdouble, GLdouble, GLdouble, GLdouble, void> glProgramNamedParameter4dNV;
        /// <summary>void glProgramNamedParameter4dvNV(GLuint id, GLsizei len, GLubyte[] name, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLubyte[], GLdouble[], void> glProgramNamedParameter4dvNV;
        /// <summary>void glProgramNamedParameter4fNV(GLuint id, GLsizei len, GLubyte[] name, GLfloat x, GLfloat y, GLfloat z, GLfloat w);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLubyte[], GLfloat, GLfloat, GLfloat, GLfloat, void> glProgramNamedParameter4fNV;
        /// <summary>void glProgramNamedParameter4fvNV(GLuint id, GLsizei len, GLubyte[] name, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLubyte[], GLfloat[], void> glProgramNamedParameter4fvNV;
        /// <summary>void glProgramParameter4dNV(GLenum target, GLuint index, GLdouble x, GLdouble y, GLdouble z, GLdouble w);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLdouble, GLdouble, GLdouble, GLdouble, void> glProgramParameter4dNV;
        /// <summary>void glProgramParameter4dvNV(GLenum target, GLuint index, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLdouble[], void> glProgramParameter4dvNV;
        /// <summary>void glProgramParameter4fNV(GLenum target, GLuint index, GLfloat x, GLfloat y, GLfloat z, GLfloat w);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLfloat, GLfloat, GLfloat, GLfloat, void> glProgramParameter4fNV;
        /// <summary>void glProgramParameter4fvNV(GLenum target, GLuint index, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLfloat[], void> glProgramParameter4fvNV;
        /// <summary>void glProgramParameteri(GLuint program, GLenum pname, GLint value);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, void> glProgramParameteri;
        /// <summary>void glProgramParameteriARB(GLuint program, GLenum pname, GLint value);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, void> glProgramParameteriARB;
        /// <summary>void glProgramParameteriEXT(GLuint program, GLenum pname, GLint value);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, void> glProgramParameteriEXT;
        /// <summary>void glProgramParameters4dvNV(GLenum target, GLuint index, GLsizei count, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLsizei, GLdouble[], void> glProgramParameters4dvNV;
        /// <summary>void glProgramParameters4fvNV(GLenum target, GLuint index, GLsizei count, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLsizei, GLfloat[], void> glProgramParameters4fvNV;
        /// <summary>void glProgramPathFragmentInputGenNV(GLuint program, GLint location, GLenum genMode, GLint components, GLfloat[] coeffs);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLenum, GLint, GLfloat[], void> glProgramPathFragmentInputGenNV;
        /// <summary>void glProgramStringARB(GLenum target, GLenum format, GLsizei len, IntPtr string);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLsizei, IntPtr, void> glProgramStringARB;
        /// <summary>void glProgramSubroutineParametersuivNV(GLenum target, GLsizei count, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLuint[], void> glProgramSubroutineParametersuivNV;
        /// <summary>void glProgramUniform1d(GLuint program, GLint location, GLdouble v0);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLdouble, void> glProgramUniform1d;
        /// <summary>void glProgramUniform1dEXT(GLuint program, GLint location, GLdouble x);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLdouble, void> glProgramUniform1dEXT;
        /// <summary>void glProgramUniform1dv(GLuint program, GLint location, GLsizei count, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLdouble[], void> glProgramUniform1dv;
        /// <summary>void glProgramUniform1dvEXT(GLuint program, GLint location, GLsizei count, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLdouble[], void> glProgramUniform1dvEXT;
        /// <summary>void glProgramUniform1f(GLuint program, GLint location, GLfloat v0);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLfloat, void> glProgramUniform1f;
        /// <summary>void glProgramUniform1fEXT(GLuint program, GLint location, GLfloat v0);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLfloat, void> glProgramUniform1fEXT;
        /// <summary>void glProgramUniform1fv(GLuint program, GLint location, GLsizei count, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLfloat[], void> glProgramUniform1fv;
        /// <summary>void glProgramUniform1fvEXT(GLuint program, GLint location, GLsizei count, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLfloat[], void> glProgramUniform1fvEXT;
        /// <summary>void glProgramUniform1i(GLuint program, GLint location, GLint v0);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, void> glProgramUniform1i;
        /// <summary>void glProgramUniform1i64ARB(GLuint program, GLint location, GLint64 x);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint64, void> glProgramUniform1i64ARB;
        /// <summary>void glProgramUniform1i64NV(GLuint program, GLint location, GLint64EXT x);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint64EXT, void> glProgramUniform1i64NV;
        /// <summary>void glProgramUniform1i64vARB(GLuint program, GLint location, GLsizei count, GLint64[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLint64[], void> glProgramUniform1i64vARB;
        /// <summary>void glProgramUniform1i64vNV(GLuint program, GLint location, GLsizei count, GLint64EXT[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLint64EXT[], void> glProgramUniform1i64vNV;
        /// <summary>void glProgramUniform1iEXT(GLuint program, GLint location, GLint v0);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, void> glProgramUniform1iEXT;
        /// <summary>void glProgramUniform1iv(GLuint program, GLint location, GLsizei count, GLint[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLint[], void> glProgramUniform1iv;
        /// <summary>void glProgramUniform1ivEXT(GLuint program, GLint location, GLsizei count, GLint[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLint[], void> glProgramUniform1ivEXT;
        /// <summary>void glProgramUniform1ui(GLuint program, GLint location, GLuint v0);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLuint, void> glProgramUniform1ui;
        /// <summary>void glProgramUniform1ui64ARB(GLuint program, GLint location, GLuint64 x);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLuint64, void> glProgramUniform1ui64ARB;
        /// <summary>void glProgramUniform1ui64NV(GLuint program, GLint location, GLuint64EXT x);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLuint64EXT, void> glProgramUniform1ui64NV;
        /// <summary>void glProgramUniform1ui64vARB(GLuint program, GLint location, GLsizei count, GLuint64[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLuint64[], void> glProgramUniform1ui64vARB;
        /// <summary>void glProgramUniform1ui64vNV(GLuint program, GLint location, GLsizei count, GLuint64EXT[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLuint64EXT[], void> glProgramUniform1ui64vNV;
        /// <summary>void glProgramUniform1uiEXT(GLuint program, GLint location, GLuint v0);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLuint, void> glProgramUniform1uiEXT;
        /// <summary>void glProgramUniform1uiv(GLuint program, GLint location, GLsizei count, GLuint[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLuint[], void> glProgramUniform1uiv;
        /// <summary>void glProgramUniform1uivEXT(GLuint program, GLint location, GLsizei count, GLuint[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLuint[], void> glProgramUniform1uivEXT;
        /// <summary>void glProgramUniform2d(GLuint program, GLint location, GLdouble v0, GLdouble v1);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLdouble, GLdouble, void> glProgramUniform2d;
        /// <summary>void glProgramUniform2dEXT(GLuint program, GLint location, GLdouble x, GLdouble y);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLdouble, GLdouble, void> glProgramUniform2dEXT;
        /// <summary>void glProgramUniform2dv(GLuint program, GLint location, GLsizei count, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLdouble[], void> glProgramUniform2dv;
        /// <summary>void glProgramUniform2dvEXT(GLuint program, GLint location, GLsizei count, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLdouble[], void> glProgramUniform2dvEXT;
        /// <summary>void glProgramUniform2f(GLuint program, GLint location, GLfloat v0, GLfloat v1);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLfloat, GLfloat, void> glProgramUniform2f;
        /// <summary>void glProgramUniform2fEXT(GLuint program, GLint location, GLfloat v0, GLfloat v1);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLfloat, GLfloat, void> glProgramUniform2fEXT;
        /// <summary>void glProgramUniform2fv(GLuint program, GLint location, GLsizei count, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLfloat[], void> glProgramUniform2fv;
        /// <summary>void glProgramUniform2fvEXT(GLuint program, GLint location, GLsizei count, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLfloat[], void> glProgramUniform2fvEXT;
        /// <summary>void glProgramUniform2i(GLuint program, GLint location, GLint v0, GLint v1);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLint, void> glProgramUniform2i;
        /// <summary>void glProgramUniform2i64ARB(GLuint program, GLint location, GLint64 x, GLint64 y);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint64, GLint64, void> glProgramUniform2i64ARB;
        /// <summary>void glProgramUniform2i64NV(GLuint program, GLint location, GLint64EXT x, GLint64EXT y);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint64EXT, GLint64EXT, void> glProgramUniform2i64NV;
        /// <summary>void glProgramUniform2i64vARB(GLuint program, GLint location, GLsizei count, GLint64[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLint64[], void> glProgramUniform2i64vARB;
        /// <summary>void glProgramUniform2i64vNV(GLuint program, GLint location, GLsizei count, GLint64EXT[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLint64EXT[], void> glProgramUniform2i64vNV;
        /// <summary>void glProgramUniform2iEXT(GLuint program, GLint location, GLint v0, GLint v1);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLint, void> glProgramUniform2iEXT;
        /// <summary>void glProgramUniform2iv(GLuint program, GLint location, GLsizei count, GLint[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLint[], void> glProgramUniform2iv;
        /// <summary>void glProgramUniform2ivEXT(GLuint program, GLint location, GLsizei count, GLint[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLint[], void> glProgramUniform2ivEXT;
        /// <summary>void glProgramUniform2ui(GLuint program, GLint location, GLuint v0, GLuint v1);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLuint, GLuint, void> glProgramUniform2ui;
        /// <summary>void glProgramUniform2ui64ARB(GLuint program, GLint location, GLuint64 x, GLuint64 y);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLuint64, GLuint64, void> glProgramUniform2ui64ARB;
        /// <summary>void glProgramUniform2ui64NV(GLuint program, GLint location, GLuint64EXT x, GLuint64EXT y);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLuint64EXT, GLuint64EXT, void> glProgramUniform2ui64NV;
        /// <summary>void glProgramUniform2ui64vARB(GLuint program, GLint location, GLsizei count, GLuint64[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLuint64[], void> glProgramUniform2ui64vARB;
        /// <summary>void glProgramUniform2ui64vNV(GLuint program, GLint location, GLsizei count, GLuint64EXT[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLuint64EXT[], void> glProgramUniform2ui64vNV;
        /// <summary>void glProgramUniform2uiEXT(GLuint program, GLint location, GLuint v0, GLuint v1);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLuint, GLuint, void> glProgramUniform2uiEXT;
        /// <summary>void glProgramUniform2uiv(GLuint program, GLint location, GLsizei count, GLuint[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLuint[], void> glProgramUniform2uiv;
        /// <summary>void glProgramUniform2uivEXT(GLuint program, GLint location, GLsizei count, GLuint[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLuint[], void> glProgramUniform2uivEXT;
        /// <summary>void glProgramUniform3d(GLuint program, GLint location, GLdouble v0, GLdouble v1, GLdouble v2);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLdouble, GLdouble, GLdouble, void> glProgramUniform3d;
        /// <summary>void glProgramUniform3dEXT(GLuint program, GLint location, GLdouble x, GLdouble y, GLdouble z);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLdouble, GLdouble, GLdouble, void> glProgramUniform3dEXT;
        /// <summary>void glProgramUniform3dv(GLuint program, GLint location, GLsizei count, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLdouble[], void> glProgramUniform3dv;
        /// <summary>void glProgramUniform3dvEXT(GLuint program, GLint location, GLsizei count, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLdouble[], void> glProgramUniform3dvEXT;
        /// <summary>void glProgramUniform3f(GLuint program, GLint location, GLfloat v0, GLfloat v1, GLfloat v2);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLfloat, GLfloat, GLfloat, void> glProgramUniform3f;
        /// <summary>void glProgramUniform3fEXT(GLuint program, GLint location, GLfloat v0, GLfloat v1, GLfloat v2);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLfloat, GLfloat, GLfloat, void> glProgramUniform3fEXT;
        /// <summary>void glProgramUniform3fv(GLuint program, GLint location, GLsizei count, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLfloat[], void> glProgramUniform3fv;
        /// <summary>void glProgramUniform3fvEXT(GLuint program, GLint location, GLsizei count, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLfloat[], void> glProgramUniform3fvEXT;
        /// <summary>void glProgramUniform3i(GLuint program, GLint location, GLint v0, GLint v1, GLint v2);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, void> glProgramUniform3i;
        /// <summary>void glProgramUniform3i64ARB(GLuint program, GLint location, GLint64 x, GLint64 y, GLint64 z);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint64, GLint64, GLint64, void> glProgramUniform3i64ARB;
        /// <summary>void glProgramUniform3i64NV(GLuint program, GLint location, GLint64EXT x, GLint64EXT y, GLint64EXT z);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint64EXT, GLint64EXT, GLint64EXT, void> glProgramUniform3i64NV;
        /// <summary>void glProgramUniform3i64vARB(GLuint program, GLint location, GLsizei count, GLint64[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLint64[], void> glProgramUniform3i64vARB;
        /// <summary>void glProgramUniform3i64vNV(GLuint program, GLint location, GLsizei count, GLint64EXT[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLint64EXT[], void> glProgramUniform3i64vNV;
        /// <summary>void glProgramUniform3iEXT(GLuint program, GLint location, GLint v0, GLint v1, GLint v2);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, void> glProgramUniform3iEXT;
        /// <summary>void glProgramUniform3iv(GLuint program, GLint location, GLsizei count, GLint[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLint[], void> glProgramUniform3iv;
        /// <summary>void glProgramUniform3ivEXT(GLuint program, GLint location, GLsizei count, GLint[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLint[], void> glProgramUniform3ivEXT;
        /// <summary>void glProgramUniform3ui(GLuint program, GLint location, GLuint v0, GLuint v1, GLuint v2);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLuint, GLuint, GLuint, void> glProgramUniform3ui;
        /// <summary>void glProgramUniform3ui64ARB(GLuint program, GLint location, GLuint64 x, GLuint64 y, GLuint64 z);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLuint64, GLuint64, GLuint64, void> glProgramUniform3ui64ARB;
        /// <summary>void glProgramUniform3ui64NV(GLuint program, GLint location, GLuint64EXT x, GLuint64EXT y, GLuint64EXT z);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLuint64EXT, GLuint64EXT, GLuint64EXT, void> glProgramUniform3ui64NV;
        /// <summary>void glProgramUniform3ui64vARB(GLuint program, GLint location, GLsizei count, GLuint64[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLuint64[], void> glProgramUniform3ui64vARB;
        /// <summary>void glProgramUniform3ui64vNV(GLuint program, GLint location, GLsizei count, GLuint64EXT[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLuint64EXT[], void> glProgramUniform3ui64vNV;
        /// <summary>void glProgramUniform3uiEXT(GLuint program, GLint location, GLuint v0, GLuint v1, GLuint v2);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLuint, GLuint, GLuint, void> glProgramUniform3uiEXT;
        /// <summary>void glProgramUniform3uiv(GLuint program, GLint location, GLsizei count, GLuint[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLuint[], void> glProgramUniform3uiv;
        /// <summary>void glProgramUniform3uivEXT(GLuint program, GLint location, GLsizei count, GLuint[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLuint[], void> glProgramUniform3uivEXT;
        /// <summary>void glProgramUniform4d(GLuint program, GLint location, GLdouble v0, GLdouble v1, GLdouble v2, GLdouble v3);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLdouble, GLdouble, GLdouble, GLdouble, void> glProgramUniform4d;
        /// <summary>void glProgramUniform4dEXT(GLuint program, GLint location, GLdouble x, GLdouble y, GLdouble z, GLdouble w);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLdouble, GLdouble, GLdouble, GLdouble, void> glProgramUniform4dEXT;
        /// <summary>void glProgramUniform4dv(GLuint program, GLint location, GLsizei count, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLdouble[], void> glProgramUniform4dv;
        /// <summary>void glProgramUniform4dvEXT(GLuint program, GLint location, GLsizei count, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLdouble[], void> glProgramUniform4dvEXT;
        /// <summary>void glProgramUniform4f(GLuint program, GLint location, GLfloat v0, GLfloat v1, GLfloat v2, GLfloat v3);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLfloat, GLfloat, GLfloat, GLfloat, void> glProgramUniform4f;
        /// <summary>void glProgramUniform4fEXT(GLuint program, GLint location, GLfloat v0, GLfloat v1, GLfloat v2, GLfloat v3);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLfloat, GLfloat, GLfloat, GLfloat, void> glProgramUniform4fEXT;
        /// <summary>void glProgramUniform4fv(GLuint program, GLint location, GLsizei count, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLfloat[], void> glProgramUniform4fv;
        /// <summary>void glProgramUniform4fvEXT(GLuint program, GLint location, GLsizei count, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLfloat[], void> glProgramUniform4fvEXT;
        /// <summary>void glProgramUniform4i(GLuint program, GLint location, GLint v0, GLint v1, GLint v2, GLint v3);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, GLint, void> glProgramUniform4i;
        /// <summary>void glProgramUniform4i64ARB(GLuint program, GLint location, GLint64 x, GLint64 y, GLint64 z, GLint64 w);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint64, GLint64, GLint64, GLint64, void> glProgramUniform4i64ARB;
        /// <summary>void glProgramUniform4i64NV(GLuint program, GLint location, GLint64EXT x, GLint64EXT y, GLint64EXT z, GLint64EXT w);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint64EXT, GLint64EXT, GLint64EXT, GLint64EXT, void> glProgramUniform4i64NV;
        /// <summary>void glProgramUniform4i64vARB(GLuint program, GLint location, GLsizei count, GLint64[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLint64[], void> glProgramUniform4i64vARB;
        /// <summary>void glProgramUniform4i64vNV(GLuint program, GLint location, GLsizei count, GLint64EXT[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLint64EXT[], void> glProgramUniform4i64vNV;
        /// <summary>void glProgramUniform4iEXT(GLuint program, GLint location, GLint v0, GLint v1, GLint v2, GLint v3);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, GLint, void> glProgramUniform4iEXT;
        /// <summary>void glProgramUniform4iv(GLuint program, GLint location, GLsizei count, GLint[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLint[], void> glProgramUniform4iv;
        /// <summary>void glProgramUniform4ivEXT(GLuint program, GLint location, GLsizei count, GLint[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLint[], void> glProgramUniform4ivEXT;
        /// <summary>void glProgramUniform4ui(GLuint program, GLint location, GLuint v0, GLuint v1, GLuint v2, GLuint v3);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLuint, GLuint, GLuint, GLuint, void> glProgramUniform4ui;
        /// <summary>void glProgramUniform4ui64ARB(GLuint program, GLint location, GLuint64 x, GLuint64 y, GLuint64 z, GLuint64 w);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLuint64, GLuint64, GLuint64, GLuint64, void> glProgramUniform4ui64ARB;
        /// <summary>void glProgramUniform4ui64NV(GLuint program, GLint location, GLuint64EXT x, GLuint64EXT y, GLuint64EXT z, GLuint64EXT w);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLuint64EXT, GLuint64EXT, GLuint64EXT, GLuint64EXT, void> glProgramUniform4ui64NV;
        /// <summary>void glProgramUniform4ui64vARB(GLuint program, GLint location, GLsizei count, GLuint64[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLuint64[], void> glProgramUniform4ui64vARB;
        /// <summary>void glProgramUniform4ui64vNV(GLuint program, GLint location, GLsizei count, GLuint64EXT[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLuint64EXT[], void> glProgramUniform4ui64vNV;
        /// <summary>void glProgramUniform4uiEXT(GLuint program, GLint location, GLuint v0, GLuint v1, GLuint v2, GLuint v3);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLuint, GLuint, GLuint, GLuint, void> glProgramUniform4uiEXT;
        /// <summary>void glProgramUniform4uiv(GLuint program, GLint location, GLsizei count, GLuint[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLuint[], void> glProgramUniform4uiv;
        /// <summary>void glProgramUniform4uivEXT(GLuint program, GLint location, GLsizei count, GLuint[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLuint[], void> glProgramUniform4uivEXT;
        /// <summary>void glProgramUniformHandleui64ARB(GLuint program, GLint location, GLuint64 value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLuint64, void> glProgramUniformHandleui64ARB;
        /// <summary>void glProgramUniformHandleui64IMG(GLuint program, GLint location, GLuint64 value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLuint64, void> glProgramUniformHandleui64IMG;
        /// <summary>void glProgramUniformHandleui64NV(GLuint program, GLint location, GLuint64 value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLuint64, void> glProgramUniformHandleui64NV;
        /// <summary>void glProgramUniformHandleui64vARB(GLuint program, GLint location, GLsizei count, GLuint64[] values);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLuint64[], void> glProgramUniformHandleui64vARB;
        /// <summary>void glProgramUniformHandleui64vIMG(GLuint program, GLint location, GLsizei count, GLuint64[] values);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLuint64[], void> glProgramUniformHandleui64vIMG;
        /// <summary>void glProgramUniformHandleui64vNV(GLuint program, GLint location, GLsizei count, GLuint64[] values);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLuint64[], void> glProgramUniformHandleui64vNV;
        /// <summary>void glProgramUniformMatrix2dv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void> glProgramUniformMatrix2dv;
        /// <summary>void glProgramUniformMatrix2dvEXT(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void> glProgramUniformMatrix2dvEXT;
        /// <summary>void glProgramUniformMatrix2fv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void> glProgramUniformMatrix2fv;
        /// <summary>void glProgramUniformMatrix2fvEXT(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void> glProgramUniformMatrix2fvEXT;
        /// <summary>void glProgramUniformMatrix2x3dv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void> glProgramUniformMatrix2x3dv;
        /// <summary>void glProgramUniformMatrix2x3dvEXT(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void> glProgramUniformMatrix2x3dvEXT;
        /// <summary>void glProgramUniformMatrix2x3fv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void> glProgramUniformMatrix2x3fv;
        /// <summary>void glProgramUniformMatrix2x3fvEXT(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void> glProgramUniformMatrix2x3fvEXT;
        /// <summary>void glProgramUniformMatrix2x4dv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void> glProgramUniformMatrix2x4dv;
        /// <summary>void glProgramUniformMatrix2x4dvEXT(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void> glProgramUniformMatrix2x4dvEXT;
        /// <summary>void glProgramUniformMatrix2x4fv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void> glProgramUniformMatrix2x4fv;
        /// <summary>void glProgramUniformMatrix2x4fvEXT(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void> glProgramUniformMatrix2x4fvEXT;
        /// <summary>void glProgramUniformMatrix3dv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void> glProgramUniformMatrix3dv;
        /// <summary>void glProgramUniformMatrix3dvEXT(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void> glProgramUniformMatrix3dvEXT;
        /// <summary>void glProgramUniformMatrix3fv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void> glProgramUniformMatrix3fv;
        /// <summary>void glProgramUniformMatrix3fvEXT(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void> glProgramUniformMatrix3fvEXT;
        /// <summary>void glProgramUniformMatrix3x2dv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void> glProgramUniformMatrix3x2dv;
        /// <summary>void glProgramUniformMatrix3x2dvEXT(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void> glProgramUniformMatrix3x2dvEXT;
        /// <summary>void glProgramUniformMatrix3x2fv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void> glProgramUniformMatrix3x2fv;
        /// <summary>void glProgramUniformMatrix3x2fvEXT(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void> glProgramUniformMatrix3x2fvEXT;
        /// <summary>void glProgramUniformMatrix3x4dv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void> glProgramUniformMatrix3x4dv;
        /// <summary>void glProgramUniformMatrix3x4dvEXT(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void> glProgramUniformMatrix3x4dvEXT;
        /// <summary>void glProgramUniformMatrix3x4fv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void> glProgramUniformMatrix3x4fv;
        /// <summary>void glProgramUniformMatrix3x4fvEXT(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void> glProgramUniformMatrix3x4fvEXT;
        /// <summary>void glProgramUniformMatrix4dv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void> glProgramUniformMatrix4dv;
        /// <summary>void glProgramUniformMatrix4dvEXT(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void> glProgramUniformMatrix4dvEXT;
        /// <summary>void glProgramUniformMatrix4fv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void> glProgramUniformMatrix4fv;
        /// <summary>void glProgramUniformMatrix4fvEXT(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void> glProgramUniformMatrix4fvEXT;
        /// <summary>void glProgramUniformMatrix4x2dv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void> glProgramUniformMatrix4x2dv;
        /// <summary>void glProgramUniformMatrix4x2dvEXT(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void> glProgramUniformMatrix4x2dvEXT;
        /// <summary>void glProgramUniformMatrix4x2fv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void> glProgramUniformMatrix4x2fv;
        /// <summary>void glProgramUniformMatrix4x2fvEXT(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void> glProgramUniformMatrix4x2fvEXT;
        /// <summary>void glProgramUniformMatrix4x3dv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void> glProgramUniformMatrix4x3dv;
        /// <summary>void glProgramUniformMatrix4x3dvEXT(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void> glProgramUniformMatrix4x3dvEXT;
        /// <summary>void glProgramUniformMatrix4x3fv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void> glProgramUniformMatrix4x3fv;
        /// <summary>void glProgramUniformMatrix4x3fvEXT(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void> glProgramUniformMatrix4x3fvEXT;
        /// <summary>void glProgramUniformui64NV(GLuint program, GLint location, GLuint64EXT value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLuint64EXT, void> glProgramUniformui64NV;
        /// <summary>void glProgramUniformui64vNV(GLuint program, GLint location, GLsizei count, GLuint64EXT[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLsizei, GLuint64EXT[], void> glProgramUniformui64vNV;
        /// <summary>void glProgramVertexLimitNV(GLenum target, GLint limit);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, void> glProgramVertexLimitNV;
        /// <summary>void glProvokingVertex(GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, void> glProvokingVertex;
        /// <summary>void glProvokingVertexEXT(GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, void> glProvokingVertexEXT;
        /// <summary>void glPushAttrib(GLbitfield mask);</summary>
        public readonly delegate* unmanaged<GLbitfield, void> glPushAttrib;
        /// <summary>void glPushClientAttrib(GLbitfield mask);</summary>
        public readonly delegate* unmanaged<GLbitfield, void> glPushClientAttrib;
        /// <summary>void glPushClientAttribDefaultEXT(GLbitfield mask);</summary>
        public readonly delegate* unmanaged<GLbitfield, void> glPushClientAttribDefaultEXT;
        /// <summary>void glPushDebugGroup(GLenum source, GLuint id, GLsizei length, string message);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLsizei, string, void> glPushDebugGroup;
        /// <summary>void glPushDebugGroupKHR(GLenum source, GLuint id, GLsizei length, string message);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLsizei, string, void> glPushDebugGroupKHR;
        /// <summary>void glPushGroupMarkerEXT(GLsizei length, string marker);</summary>
        public readonly delegate* unmanaged<GLsizei, string, void> glPushGroupMarkerEXT;
        /// <summary>void glPushMatrix();</summary>
        public readonly delegate* unmanaged<void> glPushMatrix;
        /// <summary>void glPushName(GLuint name);</summary>
        public readonly delegate* unmanaged<GLuint, void> glPushName;
        /// <summary>void glQueryCounter(GLuint id, GLenum target);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, void> glQueryCounter;
        /// <summary>void glQueryCounterEXT(GLuint id, GLenum target);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, void> glQueryCounterEXT;
        /// <summary>GLbitfield glQueryMatrixxOES(GLfixed[] mantissa, GLint[] exponent);</summary>
        public readonly delegate* unmanaged<GLfixed[], GLint[], GLbitfield> glQueryMatrixxOES;
        /// <summary>void glQueryObjectParameteruiAMD(GLenum target, GLuint id, GLenum pname, GLuint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLenum, GLuint, void> glQueryObjectParameteruiAMD;
        /// <summary>GLint glQueryResourceNV(GLenum queryType, GLint tagId, GLuint count, GLint[] buffer);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLuint, GLint[], GLint> glQueryResourceNV;
        /// <summary>void glQueryResourceTagNV(GLint tagId, string tagString);</summary>
        public readonly delegate* unmanaged<GLint, string, void> glQueryResourceTagNV;
        /// <summary>void glRasterPos2d(GLdouble x, GLdouble y);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, void> glRasterPos2d;
        /// <summary>void glRasterPos2dv(GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glRasterPos2dv;
        /// <summary>void glRasterPos2f(GLfloat x, GLfloat y);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, void> glRasterPos2f;
        /// <summary>void glRasterPos2fv(GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glRasterPos2fv;
        /// <summary>void glRasterPos2i(GLint x, GLint y);</summary>
        public readonly delegate* unmanaged<GLint, GLint, void> glRasterPos2i;
        /// <summary>void glRasterPos2iv(GLint[] v);</summary>
        public readonly delegate* unmanaged<GLint[], void> glRasterPos2iv;
        /// <summary>void glRasterPos2s(GLshort x, GLshort y);</summary>
        public readonly delegate* unmanaged<GLshort, GLshort, void> glRasterPos2s;
        /// <summary>void glRasterPos2sv(GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLshort[], void> glRasterPos2sv;
        /// <summary>void glRasterPos2xOES(GLfixed x, GLfixed y);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, void> glRasterPos2xOES;
        /// <summary>void glRasterPos2xvOES(GLfixed[] coords);</summary>
        public readonly delegate* unmanaged<GLfixed[], void> glRasterPos2xvOES;
        /// <summary>void glRasterPos3d(GLdouble x, GLdouble y, GLdouble z);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, GLdouble, void> glRasterPos3d;
        /// <summary>void glRasterPos3dv(GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glRasterPos3dv;
        /// <summary>void glRasterPos3f(GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, void> glRasterPos3f;
        /// <summary>void glRasterPos3fv(GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glRasterPos3fv;
        /// <summary>void glRasterPos3i(GLint x, GLint y, GLint z);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, void> glRasterPos3i;
        /// <summary>void glRasterPos3iv(GLint[] v);</summary>
        public readonly delegate* unmanaged<GLint[], void> glRasterPos3iv;
        /// <summary>void glRasterPos3s(GLshort x, GLshort y, GLshort z);</summary>
        public readonly delegate* unmanaged<GLshort, GLshort, GLshort, void> glRasterPos3s;
        /// <summary>void glRasterPos3sv(GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLshort[], void> glRasterPos3sv;
        /// <summary>void glRasterPos3xOES(GLfixed x, GLfixed y, GLfixed z);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, GLfixed, void> glRasterPos3xOES;
        /// <summary>void glRasterPos3xvOES(GLfixed[] coords);</summary>
        public readonly delegate* unmanaged<GLfixed[], void> glRasterPos3xvOES;
        /// <summary>void glRasterPos4d(GLdouble x, GLdouble y, GLdouble z, GLdouble w);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, GLdouble, GLdouble, void> glRasterPos4d;
        /// <summary>void glRasterPos4dv(GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glRasterPos4dv;
        /// <summary>void glRasterPos4f(GLfloat x, GLfloat y, GLfloat z, GLfloat w);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, void> glRasterPos4f;
        /// <summary>void glRasterPos4fv(GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glRasterPos4fv;
        /// <summary>void glRasterPos4i(GLint x, GLint y, GLint z, GLint w);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, GLint, void> glRasterPos4i;
        /// <summary>void glRasterPos4iv(GLint[] v);</summary>
        public readonly delegate* unmanaged<GLint[], void> glRasterPos4iv;
        /// <summary>void glRasterPos4s(GLshort x, GLshort y, GLshort z, GLshort w);</summary>
        public readonly delegate* unmanaged<GLshort, GLshort, GLshort, GLshort, void> glRasterPos4s;
        /// <summary>void glRasterPos4sv(GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLshort[], void> glRasterPos4sv;
        /// <summary>void glRasterPos4xOES(GLfixed x, GLfixed y, GLfixed z, GLfixed w);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, void> glRasterPos4xOES;
        /// <summary>void glRasterPos4xvOES(GLfixed[] coords);</summary>
        public readonly delegate* unmanaged<GLfixed[], void> glRasterPos4xvOES;
        /// <summary>void glRasterSamplesEXT(GLuint samples, GLboolean fixedsamplelocations);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean, void> glRasterSamplesEXT;
        /// <summary>void glReadBuffer(GLenum src);</summary>
        public readonly delegate* unmanaged<GLenum, void> glReadBuffer;
        /// <summary>void glReadBufferIndexedEXT(GLenum src, GLint index);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, void> glReadBufferIndexedEXT;
        /// <summary>void glReadBufferNV(GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, void> glReadBufferNV;
        /// <summary>void glReadInstrumentsSGIX(GLint marker);</summary>
        public readonly delegate* unmanaged<GLint, void> glReadInstrumentsSGIX;
        /// <summary>void glReadPixels(GLint x, GLint y, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void> glReadPixels;
        /// <summary>void glReadnPixels(GLint x, GLint y, GLsizei width, GLsizei height, GLenum format, GLenum type, GLsizei bufSize, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLsizei, GLsizei, GLenum, GLenum, GLsizei, IntPtr, void> glReadnPixels;
        /// <summary>void glReadnPixelsARB(GLint x, GLint y, GLsizei width, GLsizei height, GLenum format, GLenum type, GLsizei bufSize, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLsizei, GLsizei, GLenum, GLenum, GLsizei, IntPtr, void> glReadnPixelsARB;
        /// <summary>void glReadnPixelsEXT(GLint x, GLint y, GLsizei width, GLsizei height, GLenum format, GLenum type, GLsizei bufSize, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLsizei, GLsizei, GLenum, GLenum, GLsizei, IntPtr, void> glReadnPixelsEXT;
        /// <summary>void glReadnPixelsKHR(GLint x, GLint y, GLsizei width, GLsizei height, GLenum format, GLenum type, GLsizei bufSize, IntPtr data);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLsizei, GLsizei, GLenum, GLenum, GLsizei, IntPtr, void> glReadnPixelsKHR;
        /// <summary>GLboolean glReleaseKeyedMutexWin32EXT(GLuint memory, GLuint64 key);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint64, GLboolean> glReleaseKeyedMutexWin32EXT;
        /// <summary>void glRectd(GLdouble x1, GLdouble y1, GLdouble x2, GLdouble y2);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, GLdouble, GLdouble, void> glRectd;
        /// <summary>void glRectdv(GLdouble[] v1, GLdouble[] v2);</summary>
        public readonly delegate* unmanaged<GLdouble[], GLdouble[], void> glRectdv;
        /// <summary>void glRectf(GLfloat x1, GLfloat y1, GLfloat x2, GLfloat y2);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, void> glRectf;
        /// <summary>void glRectfv(GLfloat[] v1, GLfloat[] v2);</summary>
        public readonly delegate* unmanaged<GLfloat[], GLfloat[], void> glRectfv;
        /// <summary>void glRecti(GLint x1, GLint y1, GLint x2, GLint y2);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, GLint, void> glRecti;
        /// <summary>void glRectiv(GLint[] v1, GLint[] v2);</summary>
        public readonly delegate* unmanaged<GLint[], GLint[], void> glRectiv;
        /// <summary>void glRects(GLshort x1, GLshort y1, GLshort x2, GLshort y2);</summary>
        public readonly delegate* unmanaged<GLshort, GLshort, GLshort, GLshort, void> glRects;
        /// <summary>void glRectsv(GLshort[] v1, GLshort[] v2);</summary>
        public readonly delegate* unmanaged<GLshort[], GLshort[], void> glRectsv;
        /// <summary>void glRectxOES(GLfixed x1, GLfixed y1, GLfixed x2, GLfixed y2);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, void> glRectxOES;
        /// <summary>void glRectxvOES(GLfixed[] v1, GLfixed[] v2);</summary>
        public readonly delegate* unmanaged<GLfixed[], GLfixed[], void> glRectxvOES;
        /// <summary>void glReferencePlaneSGIX(GLdouble[] equation);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glReferencePlaneSGIX;
        /// <summary>void glReleaseShaderCompiler();</summary>
        public readonly delegate* unmanaged<void> glReleaseShaderCompiler;
        /// <summary>void glRenderGpuMaskNV(GLbitfield mask);</summary>
        public readonly delegate* unmanaged<GLbitfield, void> glRenderGpuMaskNV;
        /// <summary>GLint glRenderMode(GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, GLint> glRenderMode;
        /// <summary>void glRenderbufferStorage(GLenum target, GLenum internalformat, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLsizei, GLsizei, void> glRenderbufferStorage;
        /// <summary>void glRenderbufferStorageEXT(GLenum target, GLenum internalformat, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLsizei, GLsizei, void> glRenderbufferStorageEXT;
        /// <summary>void glRenderbufferStorageMultisample(GLenum target, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, void> glRenderbufferStorageMultisample;
        /// <summary>void glRenderbufferStorageMultisampleANGLE(GLenum target, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, void> glRenderbufferStorageMultisampleANGLE;
        /// <summary>void glRenderbufferStorageMultisampleAPPLE(GLenum target, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, void> glRenderbufferStorageMultisampleAPPLE;
        /// <summary>void glRenderbufferStorageMultisampleAdvancedAMD(GLenum target, GLsizei samples, GLsizei storageSamples, GLenum internalformat, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLsizei, GLenum, GLsizei, GLsizei, void> glRenderbufferStorageMultisampleAdvancedAMD;
        /// <summary>void glRenderbufferStorageMultisampleCoverageNV(GLenum target, GLsizei coverageSamples, GLsizei colorSamples, GLenum internalformat, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLsizei, GLenum, GLsizei, GLsizei, void> glRenderbufferStorageMultisampleCoverageNV;
        /// <summary>void glRenderbufferStorageMultisampleEXT(GLenum target, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, void> glRenderbufferStorageMultisampleEXT;
        /// <summary>void glRenderbufferStorageMultisampleIMG(GLenum target, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, void> glRenderbufferStorageMultisampleIMG;
        /// <summary>void glRenderbufferStorageMultisampleNV(GLenum target, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, void> glRenderbufferStorageMultisampleNV;
        /// <summary>void glRenderbufferStorageOES(GLenum target, GLenum internalformat, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLsizei, GLsizei, void> glRenderbufferStorageOES;
        /// <summary>void glReplacementCodePointerSUN(GLenum type, GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, IntPtr, void> glReplacementCodePointerSUN;
        /// <summary>void glReplacementCodeubSUN(GLubyte code);</summary>
        public readonly delegate* unmanaged<GLubyte, void> glReplacementCodeubSUN;
        /// <summary>void glReplacementCodeubvSUN(GLubyte[] code);</summary>
        public readonly delegate* unmanaged<GLubyte[], void> glReplacementCodeubvSUN;
        /// <summary>void glReplacementCodeuiColor3fVertex3fSUN(GLuint rc, GLfloat r, GLfloat g, GLfloat b, GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glReplacementCodeuiColor3fVertex3fSUN;
        /// <summary>void glReplacementCodeuiColor3fVertex3fvSUN(GLuint[] rc, GLfloat[] c, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint[], GLfloat[], GLfloat[], void> glReplacementCodeuiColor3fVertex3fvSUN;
        /// <summary>void glReplacementCodeuiColor4fNormal3fVertex3fSUN(GLuint rc, GLfloat r, GLfloat g, GLfloat b, GLfloat a, GLfloat nx, GLfloat ny, GLfloat nz, GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glReplacementCodeuiColor4fNormal3fVertex3fSUN;
        /// <summary>void glReplacementCodeuiColor4fNormal3fVertex3fvSUN(GLuint[] rc, GLfloat[] c, GLfloat[] n, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint[], GLfloat[], GLfloat[], GLfloat[], void> glReplacementCodeuiColor4fNormal3fVertex3fvSUN;
        /// <summary>void glReplacementCodeuiColor4ubVertex3fSUN(GLuint rc, GLubyte r, GLubyte g, GLubyte b, GLubyte a, GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLuint, GLubyte, GLubyte, GLubyte, GLubyte, GLfloat, GLfloat, GLfloat, void> glReplacementCodeuiColor4ubVertex3fSUN;
        /// <summary>void glReplacementCodeuiColor4ubVertex3fvSUN(GLuint[] rc, GLubyte[] c, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint[], GLubyte[], GLfloat[], void> glReplacementCodeuiColor4ubVertex3fvSUN;
        /// <summary>void glReplacementCodeuiNormal3fVertex3fSUN(GLuint rc, GLfloat nx, GLfloat ny, GLfloat nz, GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glReplacementCodeuiNormal3fVertex3fSUN;
        /// <summary>void glReplacementCodeuiNormal3fVertex3fvSUN(GLuint[] rc, GLfloat[] n, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint[], GLfloat[], GLfloat[], void> glReplacementCodeuiNormal3fVertex3fvSUN;
        /// <summary>void glReplacementCodeuiSUN(GLuint code);</summary>
        public readonly delegate* unmanaged<GLuint, void> glReplacementCodeuiSUN;
        /// <summary>void glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fSUN(GLuint rc, GLfloat s, GLfloat t, GLfloat r, GLfloat g, GLfloat b, GLfloat a, GLfloat nx, GLfloat ny, GLfloat nz, GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fSUN;
        /// <summary>void glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fvSUN(GLuint[] rc, GLfloat[] tc, GLfloat[] c, GLfloat[] n, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint[], GLfloat[], GLfloat[], GLfloat[], GLfloat[], void> glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fvSUN;
        /// <summary>void glReplacementCodeuiTexCoord2fNormal3fVertex3fSUN(GLuint rc, GLfloat s, GLfloat t, GLfloat nx, GLfloat ny, GLfloat nz, GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glReplacementCodeuiTexCoord2fNormal3fVertex3fSUN;
        /// <summary>void glReplacementCodeuiTexCoord2fNormal3fVertex3fvSUN(GLuint[] rc, GLfloat[] tc, GLfloat[] n, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint[], GLfloat[], GLfloat[], GLfloat[], void> glReplacementCodeuiTexCoord2fNormal3fVertex3fvSUN;
        /// <summary>void glReplacementCodeuiTexCoord2fVertex3fSUN(GLuint rc, GLfloat s, GLfloat t, GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glReplacementCodeuiTexCoord2fVertex3fSUN;
        /// <summary>void glReplacementCodeuiTexCoord2fVertex3fvSUN(GLuint[] rc, GLfloat[] tc, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint[], GLfloat[], GLfloat[], void> glReplacementCodeuiTexCoord2fVertex3fvSUN;
        /// <summary>void glReplacementCodeuiVertex3fSUN(GLuint rc, GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, void> glReplacementCodeuiVertex3fSUN;
        /// <summary>void glReplacementCodeuiVertex3fvSUN(GLuint[] rc, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint[], GLfloat[], void> glReplacementCodeuiVertex3fvSUN;
        /// <summary>void glReplacementCodeuivSUN(GLuint[] code);</summary>
        public readonly delegate* unmanaged<GLuint[], void> glReplacementCodeuivSUN;
        /// <summary>void glReplacementCodeusSUN(GLushort code);</summary>
        public readonly delegate* unmanaged<GLushort, void> glReplacementCodeusSUN;
        /// <summary>void glReplacementCodeusvSUN(GLushort[] code);</summary>
        public readonly delegate* unmanaged<GLushort[], void> glReplacementCodeusvSUN;
        /// <summary>void glRequestResidentProgramsNV(GLsizei n, GLuint[] programs);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], void> glRequestResidentProgramsNV;
        /// <summary>void glResetHistogram(GLenum target);</summary>
        public readonly delegate* unmanaged<GLenum, void> glResetHistogram;
        /// <summary>void glResetHistogramEXT(GLenum target);</summary>
        public readonly delegate* unmanaged<GLenum, void> glResetHistogramEXT;
        /// <summary>void glResetMemoryObjectParameterNV(GLuint memory, GLenum pname);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, void> glResetMemoryObjectParameterNV;
        /// <summary>void glResetMinmax(GLenum target);</summary>
        public readonly delegate* unmanaged<GLenum, void> glResetMinmax;
        /// <summary>void glResetMinmaxEXT(GLenum target);</summary>
        public readonly delegate* unmanaged<GLenum, void> glResetMinmaxEXT;
        /// <summary>void glResizeBuffersMESA();</summary>
        public readonly delegate* unmanaged<void> glResizeBuffersMESA;
        /// <summary>void glResolveDepthValuesNV();</summary>
        public readonly delegate* unmanaged<void> glResolveDepthValuesNV;
        /// <summary>void glResolveMultisampleFramebufferAPPLE();</summary>
        public readonly delegate* unmanaged<void> glResolveMultisampleFramebufferAPPLE;
        /// <summary>void glResumeTransformFeedback();</summary>
        public readonly delegate* unmanaged<void> glResumeTransformFeedback;
        /// <summary>void glResumeTransformFeedbackNV();</summary>
        public readonly delegate* unmanaged<void> glResumeTransformFeedbackNV;
        /// <summary>void glRotated(GLdouble angle, GLdouble x, GLdouble y, GLdouble z);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, GLdouble, GLdouble, void> glRotated;
        /// <summary>void glRotatef(GLfloat angle, GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, void> glRotatef;
        /// <summary>void glRotatex(GLfixed angle, GLfixed x, GLfixed y, GLfixed z);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, void> glRotatex;
        /// <summary>void glRotatexOES(GLfixed angle, GLfixed x, GLfixed y, GLfixed z);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, void> glRotatexOES;
        /// <summary>void glSampleCoverage(GLfloat value, GLboolean invert);</summary>
        public readonly delegate* unmanaged<GLfloat, GLboolean, void> glSampleCoverage;
        /// <summary>void glSampleCoverageARB(GLfloat value, GLboolean invert);</summary>
        public readonly delegate* unmanaged<GLfloat, GLboolean, void> glSampleCoverageARB;
        /// <summary>void glSampleCoveragex(GLclampx value, GLboolean invert);</summary>
        public readonly delegate* unmanaged<GLclampx, GLboolean, void> glSampleCoveragex;
        /// <summary>void glSampleCoveragexOES(GLclampx value, GLboolean invert);</summary>
        public readonly delegate* unmanaged<GLclampx, GLboolean, void> glSampleCoveragexOES;
        /// <summary>void glSampleMapATI(GLuint dst, GLuint interp, GLenum swizzle);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, void> glSampleMapATI;
        /// <summary>void glSampleMaskEXT(GLclampf value, GLboolean invert);</summary>
        public readonly delegate* unmanaged<GLclampf, GLboolean, void> glSampleMaskEXT;
        /// <summary>void glSampleMaskIndexedNV(GLuint index, GLbitfield mask);</summary>
        public readonly delegate* unmanaged<GLuint, GLbitfield, void> glSampleMaskIndexedNV;
        /// <summary>void glSampleMaskSGIS(GLclampf value, GLboolean invert);</summary>
        public readonly delegate* unmanaged<GLclampf, GLboolean, void> glSampleMaskSGIS;
        /// <summary>void glSampleMaski(GLuint maskNumber, GLbitfield mask);</summary>
        public readonly delegate* unmanaged<GLuint, GLbitfield, void> glSampleMaski;
        /// <summary>void glSamplePatternEXT(GLenum pattern);</summary>
        public readonly delegate* unmanaged<GLenum, void> glSamplePatternEXT;
        /// <summary>void glSamplePatternSGIS(GLenum pattern);</summary>
        public readonly delegate* unmanaged<GLenum, void> glSamplePatternSGIS;
        /// <summary>void glSamplerParameterIiv(GLuint sampler, GLenum pname, GLint[] param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glSamplerParameterIiv;
        /// <summary>void glSamplerParameterIivEXT(GLuint sampler, GLenum pname, GLint[] param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glSamplerParameterIivEXT;
        /// <summary>void glSamplerParameterIivOES(GLuint sampler, GLenum pname, GLint[] param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glSamplerParameterIivOES;
        /// <summary>void glSamplerParameterIuiv(GLuint sampler, GLenum pname, GLuint[] param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint[], void> glSamplerParameterIuiv;
        /// <summary>void glSamplerParameterIuivEXT(GLuint sampler, GLenum pname, GLuint[] param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint[], void> glSamplerParameterIuivEXT;
        /// <summary>void glSamplerParameterIuivOES(GLuint sampler, GLenum pname, GLuint[] param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint[], void> glSamplerParameterIuivOES;
        /// <summary>void glSamplerParameterf(GLuint sampler, GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLfloat, void> glSamplerParameterf;
        /// <summary>void glSamplerParameterfv(GLuint sampler, GLenum pname, GLfloat[] param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLfloat[], void> glSamplerParameterfv;
        /// <summary>void glSamplerParameteri(GLuint sampler, GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, void> glSamplerParameteri;
        /// <summary>void glSamplerParameteriv(GLuint sampler, GLenum pname, GLint[] param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glSamplerParameteriv;
        /// <summary>void glScaled(GLdouble x, GLdouble y, GLdouble z);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, GLdouble, void> glScaled;
        /// <summary>void glScalef(GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, void> glScalef;
        /// <summary>void glScalex(GLfixed x, GLfixed y, GLfixed z);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, GLfixed, void> glScalex;
        /// <summary>void glScalexOES(GLfixed x, GLfixed y, GLfixed z);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, GLfixed, void> glScalexOES;
        /// <summary>void glScissor(GLint x, GLint y, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLsizei, GLsizei, void> glScissor;
        /// <summary>void glScissorArrayv(GLuint first, GLsizei count, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLint[], void> glScissorArrayv;
        /// <summary>void glScissorArrayvNV(GLuint first, GLsizei count, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLint[], void> glScissorArrayvNV;
        /// <summary>void glScissorArrayvOES(GLuint first, GLsizei count, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLint[], void> glScissorArrayvOES;
        /// <summary>void glScissorExclusiveArrayvNV(GLuint first, GLsizei count, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLint[], void> glScissorExclusiveArrayvNV;
        /// <summary>void glScissorExclusiveNV(GLint x, GLint y, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLsizei, GLsizei, void> glScissorExclusiveNV;
        /// <summary>void glScissorIndexed(GLuint index, GLint left, GLint bottom, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLsizei, GLsizei, void> glScissorIndexed;
        /// <summary>void glScissorIndexedNV(GLuint index, GLint left, GLint bottom, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLsizei, GLsizei, void> glScissorIndexedNV;
        /// <summary>void glScissorIndexedOES(GLuint index, GLint left, GLint bottom, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLsizei, GLsizei, void> glScissorIndexedOES;
        /// <summary>void glScissorIndexedv(GLuint index, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLint[], void> glScissorIndexedv;
        /// <summary>void glScissorIndexedvNV(GLuint index, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLint[], void> glScissorIndexedvNV;
        /// <summary>void glScissorIndexedvOES(GLuint index, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLint[], void> glScissorIndexedvOES;
        /// <summary>void glSecondaryColor3b(GLbyte red, GLbyte green, GLbyte blue);</summary>
        public readonly delegate* unmanaged<GLbyte, GLbyte, GLbyte, void> glSecondaryColor3b;
        /// <summary>void glSecondaryColor3bEXT(GLbyte red, GLbyte green, GLbyte blue);</summary>
        public readonly delegate* unmanaged<GLbyte, GLbyte, GLbyte, void> glSecondaryColor3bEXT;
        /// <summary>void glSecondaryColor3bv(GLbyte[] v);</summary>
        public readonly delegate* unmanaged<GLbyte[], void> glSecondaryColor3bv;
        /// <summary>void glSecondaryColor3bvEXT(GLbyte[] v);</summary>
        public readonly delegate* unmanaged<GLbyte[], void> glSecondaryColor3bvEXT;
        /// <summary>void glSecondaryColor3d(GLdouble red, GLdouble green, GLdouble blue);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, GLdouble, void> glSecondaryColor3d;
        /// <summary>void glSecondaryColor3dEXT(GLdouble red, GLdouble green, GLdouble blue);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, GLdouble, void> glSecondaryColor3dEXT;
        /// <summary>void glSecondaryColor3dv(GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glSecondaryColor3dv;
        /// <summary>void glSecondaryColor3dvEXT(GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glSecondaryColor3dvEXT;
        /// <summary>void glSecondaryColor3f(GLfloat red, GLfloat green, GLfloat blue);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, void> glSecondaryColor3f;
        /// <summary>void glSecondaryColor3fEXT(GLfloat red, GLfloat green, GLfloat blue);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, void> glSecondaryColor3fEXT;
        /// <summary>void glSecondaryColor3fv(GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glSecondaryColor3fv;
        /// <summary>void glSecondaryColor3fvEXT(GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glSecondaryColor3fvEXT;
        /// <summary>void glSecondaryColor3hNV(GLhalfNV red, GLhalfNV green, GLhalfNV blue);</summary>
        public readonly delegate* unmanaged<GLhalfNV, GLhalfNV, GLhalfNV, void> glSecondaryColor3hNV;
        /// <summary>void glSecondaryColor3hvNV(GLhalfNV[] v);</summary>
        public readonly delegate* unmanaged<GLhalfNV[], void> glSecondaryColor3hvNV;
        /// <summary>void glSecondaryColor3i(GLint red, GLint green, GLint blue);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, void> glSecondaryColor3i;
        /// <summary>void glSecondaryColor3iEXT(GLint red, GLint green, GLint blue);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, void> glSecondaryColor3iEXT;
        /// <summary>void glSecondaryColor3iv(GLint[] v);</summary>
        public readonly delegate* unmanaged<GLint[], void> glSecondaryColor3iv;
        /// <summary>void glSecondaryColor3ivEXT(GLint[] v);</summary>
        public readonly delegate* unmanaged<GLint[], void> glSecondaryColor3ivEXT;
        /// <summary>void glSecondaryColor3s(GLshort red, GLshort green, GLshort blue);</summary>
        public readonly delegate* unmanaged<GLshort, GLshort, GLshort, void> glSecondaryColor3s;
        /// <summary>void glSecondaryColor3sEXT(GLshort red, GLshort green, GLshort blue);</summary>
        public readonly delegate* unmanaged<GLshort, GLshort, GLshort, void> glSecondaryColor3sEXT;
        /// <summary>void glSecondaryColor3sv(GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLshort[], void> glSecondaryColor3sv;
        /// <summary>void glSecondaryColor3svEXT(GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLshort[], void> glSecondaryColor3svEXT;
        /// <summary>void glSecondaryColor3ub(GLubyte red, GLubyte green, GLubyte blue);</summary>
        public readonly delegate* unmanaged<GLubyte, GLubyte, GLubyte, void> glSecondaryColor3ub;
        /// <summary>void glSecondaryColor3ubEXT(GLubyte red, GLubyte green, GLubyte blue);</summary>
        public readonly delegate* unmanaged<GLubyte, GLubyte, GLubyte, void> glSecondaryColor3ubEXT;
        /// <summary>void glSecondaryColor3ubv(GLubyte[] v);</summary>
        public readonly delegate* unmanaged<GLubyte[], void> glSecondaryColor3ubv;
        /// <summary>void glSecondaryColor3ubvEXT(GLubyte[] v);</summary>
        public readonly delegate* unmanaged<GLubyte[], void> glSecondaryColor3ubvEXT;
        /// <summary>void glSecondaryColor3ui(GLuint red, GLuint green, GLuint blue);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, void> glSecondaryColor3ui;
        /// <summary>void glSecondaryColor3uiEXT(GLuint red, GLuint green, GLuint blue);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, void> glSecondaryColor3uiEXT;
        /// <summary>void glSecondaryColor3uiv(GLuint[] v);</summary>
        public readonly delegate* unmanaged<GLuint[], void> glSecondaryColor3uiv;
        /// <summary>void glSecondaryColor3uivEXT(GLuint[] v);</summary>
        public readonly delegate* unmanaged<GLuint[], void> glSecondaryColor3uivEXT;
        /// <summary>void glSecondaryColor3us(GLushort red, GLushort green, GLushort blue);</summary>
        public readonly delegate* unmanaged<GLushort, GLushort, GLushort, void> glSecondaryColor3us;
        /// <summary>void glSecondaryColor3usEXT(GLushort red, GLushort green, GLushort blue);</summary>
        public readonly delegate* unmanaged<GLushort, GLushort, GLushort, void> glSecondaryColor3usEXT;
        /// <summary>void glSecondaryColor3usv(GLushort[] v);</summary>
        public readonly delegate* unmanaged<GLushort[], void> glSecondaryColor3usv;
        /// <summary>void glSecondaryColor3usvEXT(GLushort[] v);</summary>
        public readonly delegate* unmanaged<GLushort[], void> glSecondaryColor3usvEXT;
        /// <summary>void glSecondaryColorFormatNV(GLint size, GLenum type, GLsizei stride);</summary>
        public readonly delegate* unmanaged<GLint, GLenum, GLsizei, void> glSecondaryColorFormatNV;
        /// <summary>void glSecondaryColorP3ui(GLenum type, GLuint color);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glSecondaryColorP3ui;
        /// <summary>void glSecondaryColorP3uiv(GLenum type, GLuint[] color);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint[], void> glSecondaryColorP3uiv;
        /// <summary>void glSecondaryColorPointer(GLint size, GLenum type, GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLint, GLenum, GLsizei, IntPtr, void> glSecondaryColorPointer;
        /// <summary>void glSecondaryColorPointerEXT(GLint size, GLenum type, GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLint, GLenum, GLsizei, IntPtr, void> glSecondaryColorPointerEXT;
        /// <summary>void glSecondaryColorPointerListIBM(GLint size, GLenum type, GLint stride, IntPtr pointer, GLint ptrstride);</summary>
        public readonly delegate* unmanaged<GLint, GLenum, GLint, IntPtr, GLint, void> glSecondaryColorPointerListIBM;
        /// <summary>void glSelectBuffer(GLsizei size, GLuint[] buffer);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint*, void> glSelectBuffer;
        /// <summary>void glSelectPerfMonitorCountersAMD(GLuint monitor, GLboolean enable, GLuint group, GLint numCounters, GLuint[] counterList);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean, GLuint, GLint, GLuint[], void> glSelectPerfMonitorCountersAMD;
        /// <summary>void glSemaphoreParameterui64vEXT(GLuint semaphore, GLenum pname, GLuint64[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint64[], void> glSemaphoreParameterui64vEXT;
        /// <summary>void glSeparableFilter2D(GLenum target, GLenum internalformat, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr row, IntPtr column);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLsizei, GLsizei, GLenum, GLenum, IntPtr, IntPtr, void> glSeparableFilter2D;
        /// <summary>void glSeparableFilter2DEXT(GLenum target, GLenum internalformat, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr row, IntPtr column);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLsizei, GLsizei, GLenum, GLenum, IntPtr, IntPtr, void> glSeparableFilter2DEXT;
        /// <summary>void glSetFenceAPPLE(GLuint fence);</summary>
        public readonly delegate* unmanaged<GLuint, void> glSetFenceAPPLE;
        /// <summary>void glSetFenceNV(GLuint fence, GLenum condition);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, void> glSetFenceNV;
        /// <summary>void glSetFragmentShaderConstantATI(GLuint dst, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat[], void> glSetFragmentShaderConstantATI;
        /// <summary>void glSetInvariantEXT(GLuint id, GLenum type, IntPtr addr);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, IntPtr, void> glSetInvariantEXT;
        /// <summary>void glSetLocalConstantEXT(GLuint id, GLenum type, IntPtr addr);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, IntPtr, void> glSetLocalConstantEXT;
        /// <summary>void glSetMultisamplefvAMD(GLenum pname, GLuint index, GLfloat[] val);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLfloat[], void> glSetMultisamplefvAMD;
        /// <summary>void glShadeModel(GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, void> glShadeModel;
        /// <summary>void glShaderBinary(GLsizei count, GLuint[] shaders, GLenum binaryformat, IntPtr binary, GLsizei length);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint[], GLenum, IntPtr, GLsizei, void> glShaderBinary;
        /// <summary>void glShaderOp1EXT(GLenum op, GLuint res, GLuint arg1);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, void> glShaderOp1EXT;
        /// <summary>void glShaderOp2EXT(GLenum op, GLuint res, GLuint arg1, GLuint arg2);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLuint, void> glShaderOp2EXT;
        /// <summary>void glShaderOp3EXT(GLenum op, GLuint res, GLuint arg1, GLuint arg2, GLuint arg3);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint, GLuint, GLuint, void> glShaderOp3EXT;
        /// <summary>void glShaderSource(GLuint shader, GLsizei count, string[] string, GLint* length);</summary>
        public readonly delegate* unmanaged[Cdecl]<GLuint, GLsizei, string[], GLint*, void> glShaderSource;
        /// <summary>void glShaderSourceARB(GLhandleARB shaderObj, GLsizei count, string[] string, GLint[] length);</summary>
        public readonly delegate* unmanaged<GLhandleARB, GLsizei, string[], GLint[], void> glShaderSourceARB;
        /// <summary>void glShaderStorageBlockBinding(GLuint program, GLuint storageBlockIndex, GLuint storageBlockBinding);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, void> glShaderStorageBlockBinding;
        /// <summary>void glShadingRateImageBarrierNV(GLboolean synchronize);</summary>
        public readonly delegate* unmanaged<GLboolean, void> glShadingRateImageBarrierNV;
        /// <summary>void glShadingRateImagePaletteNV(GLuint viewport, GLuint first, GLsizei count, GLenum[] rates);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLsizei, GLenum[], void> glShadingRateImagePaletteNV;
        /// <summary>void glShadingRateSampleOrderNV(GLenum order);</summary>
        public readonly delegate* unmanaged<GLenum, void> glShadingRateSampleOrderNV;
        /// <summary>void glShadingRateSampleOrderCustomNV(GLenum rate, GLuint samples, GLint[] locations);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLint[], void> glShadingRateSampleOrderCustomNV;
        /// <summary>void glSharpenTexFuncSGIS(GLenum target, GLsizei n, GLfloat[] points);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLfloat[], void> glSharpenTexFuncSGIS;
        /// <summary>void glSignalSemaphoreEXT(GLuint semaphore, GLuint numBufferBarriers, GLuint[] buffers, GLuint numTextureBarriers, GLuint[] textures, GLenum[] dstLayouts);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint[], GLuint, GLuint[], GLenum[], void> glSignalSemaphoreEXT;
        /// <summary>void glSignalSemaphoreui64NVX(GLuint signalGpu, GLsizei fenceObjectCount, GLuint[] semaphoreArray, GLuint64[] fenceValueArray);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLuint[], GLuint64[], void> glSignalSemaphoreui64NVX;
        /// <summary>void glSpecializeShader(GLuint shader, string pEntryPoint, GLuint numSpecializationConstants, GLuint[] pConstantIndex, GLuint[] pConstantValue);</summary>
        public readonly delegate* unmanaged<GLuint, string, GLuint, GLuint[], GLuint[], void> glSpecializeShader;
        /// <summary>void glSpecializeShaderARB(GLuint shader, string pEntryPoint, GLuint numSpecializationConstants, GLuint[] pConstantIndex, GLuint[] pConstantValue);</summary>
        public readonly delegate* unmanaged<GLuint, string, GLuint, GLuint[], GLuint[], void> glSpecializeShaderARB;
        /// <summary>void glSpriteParameterfSGIX(GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, void> glSpriteParameterfSGIX;
        /// <summary>void glSpriteParameterfvSGIX(GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glSpriteParameterfvSGIX;
        /// <summary>void glSpriteParameteriSGIX(GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, void> glSpriteParameteriSGIX;
        /// <summary>void glSpriteParameterivSGIX(GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLint[], void> glSpriteParameterivSGIX;
        /// <summary>void glStartInstrumentsSGIX();</summary>
        public readonly delegate* unmanaged<void> glStartInstrumentsSGIX;
        /// <summary>void glStartTilingQCOM(GLuint x, GLuint y, GLuint width, GLuint height, GLbitfield preserveMask);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, GLuint, GLbitfield, void> glStartTilingQCOM;
        /// <summary>void glStateCaptureNV(GLuint state, GLenum mode);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, void> glStateCaptureNV;
        /// <summary>void glStencilClearTagEXT(GLsizei stencilTagBits, GLuint stencilClearTag);</summary>
        public readonly delegate* unmanaged<GLsizei, GLuint, void> glStencilClearTagEXT;
        /// <summary>void glStencilFillPathInstancedNV(GLsizei numPaths, GLenum pathNameType, IntPtr paths, GLuint pathBase, GLenum fillMode, GLuint mask, GLenum transformType, GLfloat[] transformValues);</summary>
        public readonly delegate* unmanaged<GLsizei, GLenum, IntPtr, GLuint, GLenum, GLuint, GLenum, GLfloat[], void> glStencilFillPathInstancedNV;
        /// <summary>void glStencilFillPathNV(GLuint path, GLenum fillMode, GLuint mask);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, void> glStencilFillPathNV;
        /// <summary>void glStencilFunc(GLenum func, GLint ref, GLuint mask);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLuint, void> glStencilFunc;
        /// <summary>void glStencilFuncSeparate(GLenum face, GLenum func, GLint ref, GLuint mask);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLuint, void> glStencilFuncSeparate;
        /// <summary>void glStencilFuncSeparateATI(GLenum frontfunc, GLenum backfunc, GLint ref, GLuint mask);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, GLuint, void> glStencilFuncSeparateATI;
        /// <summary>void glStencilMask(GLuint mask);</summary>
        public readonly delegate* unmanaged<GLuint, void> glStencilMask;
        /// <summary>void glStencilMaskSeparate(GLenum face, GLuint mask);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glStencilMaskSeparate;
        /// <summary>void glStencilOp(GLenum fail, GLenum zfail, GLenum zpass);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, void> glStencilOp;
        /// <summary>void glStencilOpSeparate(GLenum face, GLenum sfail, GLenum dpfail, GLenum dppass);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLenum, void> glStencilOpSeparate;
        /// <summary>void glStencilOpSeparateATI(GLenum face, GLenum sfail, GLenum dpfail, GLenum dppass);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLenum, GLenum, void> glStencilOpSeparateATI;
        /// <summary>void glStencilOpValueAMD(GLenum face, GLuint value);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glStencilOpValueAMD;
        /// <summary>void glStencilStrokePathInstancedNV(GLsizei numPaths, GLenum pathNameType, IntPtr paths, GLuint pathBase, GLint reference, GLuint mask, GLenum transformType, GLfloat[] transformValues);</summary>
        public readonly delegate* unmanaged<GLsizei, GLenum, IntPtr, GLuint, GLint, GLuint, GLenum, GLfloat[], void> glStencilStrokePathInstancedNV;
        /// <summary>void glStencilStrokePathNV(GLuint path, GLint reference, GLuint mask);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLuint, void> glStencilStrokePathNV;
        /// <summary>void glStencilThenCoverFillPathInstancedNV(GLsizei numPaths, GLenum pathNameType, IntPtr paths, GLuint pathBase, GLenum fillMode, GLuint mask, GLenum coverMode, GLenum transformType, GLfloat[] transformValues);</summary>
        public readonly delegate* unmanaged<GLsizei, GLenum, IntPtr, GLuint, GLenum, GLuint, GLenum, GLenum, GLfloat[], void> glStencilThenCoverFillPathInstancedNV;
        /// <summary>void glStencilThenCoverFillPathNV(GLuint path, GLenum fillMode, GLuint mask, GLenum coverMode);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLenum, void> glStencilThenCoverFillPathNV;
        /// <summary>void glStencilThenCoverStrokePathInstancedNV(GLsizei numPaths, GLenum pathNameType, IntPtr paths, GLuint pathBase, GLint reference, GLuint mask, GLenum coverMode, GLenum transformType, GLfloat[] transformValues);</summary>
        public readonly delegate* unmanaged<GLsizei, GLenum, IntPtr, GLuint, GLint, GLuint, GLenum, GLenum, GLfloat[], void> glStencilThenCoverStrokePathInstancedNV;
        /// <summary>void glStencilThenCoverStrokePathNV(GLuint path, GLint reference, GLuint mask, GLenum coverMode);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLuint, GLenum, void> glStencilThenCoverStrokePathNV;
        /// <summary>void glStopInstrumentsSGIX(GLint marker);</summary>
        public readonly delegate* unmanaged<GLint, void> glStopInstrumentsSGIX;
        /// <summary>void glStringMarkerGREMEDY(GLsizei len, IntPtr string);</summary>
        public readonly delegate* unmanaged<GLsizei, IntPtr, void> glStringMarkerGREMEDY;
        /// <summary>void glSubpixelPrecisionBiasNV(GLuint xbits, GLuint ybits);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, void> glSubpixelPrecisionBiasNV;
        /// <summary>void glSwizzleEXT(GLuint res, GLuint in, GLenum outX, GLenum outY, GLenum outZ, GLenum outW);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLenum, GLenum, GLenum, void> glSwizzleEXT;
        /// <summary>void glSyncTextureINTEL(GLuint texture);</summary>
        public readonly delegate* unmanaged<GLuint, void> glSyncTextureINTEL;
        /// <summary>void glTagSampleBufferSGIX();</summary>
        public readonly delegate* unmanaged<void> glTagSampleBufferSGIX;
        /// <summary>void glTangent3bEXT(GLbyte tx, GLbyte ty, GLbyte tz);</summary>
        public readonly delegate* unmanaged<GLbyte, GLbyte, GLbyte, void> glTangent3bEXT;
        /// <summary>void glTangent3bvEXT(GLbyte[] v);</summary>
        public readonly delegate* unmanaged<GLbyte[], void> glTangent3bvEXT;
        /// <summary>void glTangent3dEXT(GLdouble tx, GLdouble ty, GLdouble tz);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, GLdouble, void> glTangent3dEXT;
        /// <summary>void glTangent3dvEXT(GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glTangent3dvEXT;
        /// <summary>void glTangent3fEXT(GLfloat tx, GLfloat ty, GLfloat tz);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, void> glTangent3fEXT;
        /// <summary>void glTangent3fvEXT(GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glTangent3fvEXT;
        /// <summary>void glTangent3iEXT(GLint tx, GLint ty, GLint tz);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, void> glTangent3iEXT;
        /// <summary>void glTangent3ivEXT(GLint[] v);</summary>
        public readonly delegate* unmanaged<GLint[], void> glTangent3ivEXT;
        /// <summary>void glTangent3sEXT(GLshort tx, GLshort ty, GLshort tz);</summary>
        public readonly delegate* unmanaged<GLshort, GLshort, GLshort, void> glTangent3sEXT;
        /// <summary>void glTangent3svEXT(GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLshort[], void> glTangent3svEXT;
        /// <summary>void glTangentPointerEXT(GLenum type, GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, IntPtr, void> glTangentPointerEXT;
        /// <summary>void glTbufferMask3DFX(GLuint mask);</summary>
        public readonly delegate* unmanaged<GLuint, void> glTbufferMask3DFX;
        /// <summary>void glTessellationFactorAMD(GLfloat factor);</summary>
        public readonly delegate* unmanaged<GLfloat, void> glTessellationFactorAMD;
        /// <summary>void glTessellationModeAMD(GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, void> glTessellationModeAMD;
        /// <summary>GLboolean glTestFenceAPPLE(GLuint fence);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glTestFenceAPPLE;
        /// <summary>GLboolean glTestFenceNV(GLuint fence);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glTestFenceNV;
        /// <summary>GLboolean glTestObjectAPPLE(GLenum object, GLuint name);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLboolean> glTestObjectAPPLE;
        /// <summary>void glTexAttachMemoryNV(GLenum target, GLuint memory, GLuint64 offset);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLuint64, void> glTexAttachMemoryNV;
        /// <summary>void glTexBuffer(GLenum target, GLenum internalformat, GLuint buffer);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, void> glTexBuffer;
        /// <summary>void glTexBufferARB(GLenum target, GLenum internalformat, GLuint buffer);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, void> glTexBufferARB;
        /// <summary>void glTexBufferEXT(GLenum target, GLenum internalformat, GLuint buffer);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, void> glTexBufferEXT;
        /// <summary>void glTexBufferOES(GLenum target, GLenum internalformat, GLuint buffer);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, void> glTexBufferOES;
        /// <summary>void glTexBufferRange(GLenum target, GLenum internalformat, GLuint buffer, GLintptr offset, GLsizeiptr size);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, GLintptr, GLsizeiptr, void> glTexBufferRange;
        /// <summary>void glTexBufferRangeEXT(GLenum target, GLenum internalformat, GLuint buffer, GLintptr offset, GLsizeiptr size);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, GLintptr, GLsizeiptr, void> glTexBufferRangeEXT;
        /// <summary>void glTexBufferRangeOES(GLenum target, GLenum internalformat, GLuint buffer, GLintptr offset, GLsizeiptr size);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint, GLintptr, GLsizeiptr, void> glTexBufferRangeOES;
        /// <summary>void glTexBumpParameterfvATI(GLenum pname, GLfloat[] param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glTexBumpParameterfvATI;
        /// <summary>void glTexBumpParameterivATI(GLenum pname, GLint[] param);</summary>
        public readonly delegate* unmanaged<GLenum, GLint[], void> glTexBumpParameterivATI;
        /// <summary>void glTexCoord1bOES(GLbyte s);</summary>
        public readonly delegate* unmanaged<GLbyte, void> glTexCoord1bOES;
        /// <summary>void glTexCoord1bvOES(GLbyte[] coords);</summary>
        public readonly delegate* unmanaged<GLbyte[], void> glTexCoord1bvOES;
        /// <summary>void glTexCoord1d(GLdouble s);</summary>
        public readonly delegate* unmanaged<GLdouble, void> glTexCoord1d;
        /// <summary>void glTexCoord1dv(GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glTexCoord1dv;
        /// <summary>void glTexCoord1f(GLfloat s);</summary>
        public readonly delegate* unmanaged<GLfloat, void> glTexCoord1f;
        /// <summary>void glTexCoord1fv(GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glTexCoord1fv;
        /// <summary>void glTexCoord1hNV(GLhalfNV s);</summary>
        public readonly delegate* unmanaged<GLhalfNV, void> glTexCoord1hNV;
        /// <summary>void glTexCoord1hvNV(GLhalfNV[] v);</summary>
        public readonly delegate* unmanaged<GLhalfNV[], void> glTexCoord1hvNV;
        /// <summary>void glTexCoord1i(GLint s);</summary>
        public readonly delegate* unmanaged<GLint, void> glTexCoord1i;
        /// <summary>void glTexCoord1iv(GLint[] v);</summary>
        public readonly delegate* unmanaged<GLint[], void> glTexCoord1iv;
        /// <summary>void glTexCoord1s(GLshort s);</summary>
        public readonly delegate* unmanaged<GLshort, void> glTexCoord1s;
        /// <summary>void glTexCoord1sv(GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLshort[], void> glTexCoord1sv;
        /// <summary>void glTexCoord1xOES(GLfixed s);</summary>
        public readonly delegate* unmanaged<GLfixed, void> glTexCoord1xOES;
        /// <summary>void glTexCoord1xvOES(GLfixed[] coords);</summary>
        public readonly delegate* unmanaged<GLfixed[], void> glTexCoord1xvOES;
        /// <summary>void glTexCoord2bOES(GLbyte s, GLbyte t);</summary>
        public readonly delegate* unmanaged<GLbyte, GLbyte, void> glTexCoord2bOES;
        /// <summary>void glTexCoord2bvOES(GLbyte[] coords);</summary>
        public readonly delegate* unmanaged<GLbyte[], void> glTexCoord2bvOES;
        /// <summary>void glTexCoord2d(GLdouble s, GLdouble t);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, void> glTexCoord2d;
        /// <summary>void glTexCoord2dv(GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glTexCoord2dv;
        /// <summary>void glTexCoord2f(GLfloat s, GLfloat t);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, void> glTexCoord2f;
        /// <summary>void glTexCoord2fColor3fVertex3fSUN(GLfloat s, GLfloat t, GLfloat r, GLfloat g, GLfloat b, GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glTexCoord2fColor3fVertex3fSUN;
        /// <summary>void glTexCoord2fColor3fVertex3fvSUN(GLfloat[] tc, GLfloat[] c, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], GLfloat[], GLfloat[], void> glTexCoord2fColor3fVertex3fvSUN;
        /// <summary>void glTexCoord2fColor4fNormal3fVertex3fSUN(GLfloat s, GLfloat t, GLfloat r, GLfloat g, GLfloat b, GLfloat a, GLfloat nx, GLfloat ny, GLfloat nz, GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glTexCoord2fColor4fNormal3fVertex3fSUN;
        /// <summary>void glTexCoord2fColor4fNormal3fVertex3fvSUN(GLfloat[] tc, GLfloat[] c, GLfloat[] n, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], GLfloat[], GLfloat[], GLfloat[], void> glTexCoord2fColor4fNormal3fVertex3fvSUN;
        /// <summary>void glTexCoord2fColor4ubVertex3fSUN(GLfloat s, GLfloat t, GLubyte r, GLubyte g, GLubyte b, GLubyte a, GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLubyte, GLubyte, GLubyte, GLubyte, GLfloat, GLfloat, GLfloat, void> glTexCoord2fColor4ubVertex3fSUN;
        /// <summary>void glTexCoord2fColor4ubVertex3fvSUN(GLfloat[] tc, GLubyte[] c, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], GLubyte[], GLfloat[], void> glTexCoord2fColor4ubVertex3fvSUN;
        /// <summary>void glTexCoord2fNormal3fVertex3fSUN(GLfloat s, GLfloat t, GLfloat nx, GLfloat ny, GLfloat nz, GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glTexCoord2fNormal3fVertex3fSUN;
        /// <summary>void glTexCoord2fNormal3fVertex3fvSUN(GLfloat[] tc, GLfloat[] n, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], GLfloat[], GLfloat[], void> glTexCoord2fNormal3fVertex3fvSUN;
        /// <summary>void glTexCoord2fVertex3fSUN(GLfloat s, GLfloat t, GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glTexCoord2fVertex3fSUN;
        /// <summary>void glTexCoord2fVertex3fvSUN(GLfloat[] tc, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], GLfloat[], void> glTexCoord2fVertex3fvSUN;
        /// <summary>void glTexCoord2fv(GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glTexCoord2fv;
        /// <summary>void glTexCoord2hNV(GLhalfNV s, GLhalfNV t);</summary>
        public readonly delegate* unmanaged<GLhalfNV, GLhalfNV, void> glTexCoord2hNV;
        /// <summary>void glTexCoord2hvNV(GLhalfNV[] v);</summary>
        public readonly delegate* unmanaged<GLhalfNV[], void> glTexCoord2hvNV;
        /// <summary>void glTexCoord2i(GLint s, GLint t);</summary>
        public readonly delegate* unmanaged<GLint, GLint, void> glTexCoord2i;
        /// <summary>void glTexCoord2iv(GLint[] v);</summary>
        public readonly delegate* unmanaged<GLint[], void> glTexCoord2iv;
        /// <summary>void glTexCoord2s(GLshort s, GLshort t);</summary>
        public readonly delegate* unmanaged<GLshort, GLshort, void> glTexCoord2s;
        /// <summary>void glTexCoord2sv(GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLshort[], void> glTexCoord2sv;
        /// <summary>void glTexCoord2xOES(GLfixed s, GLfixed t);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, void> glTexCoord2xOES;
        /// <summary>void glTexCoord2xvOES(GLfixed[] coords);</summary>
        public readonly delegate* unmanaged<GLfixed[], void> glTexCoord2xvOES;
        /// <summary>void glTexCoord3bOES(GLbyte s, GLbyte t, GLbyte r);</summary>
        public readonly delegate* unmanaged<GLbyte, GLbyte, GLbyte, void> glTexCoord3bOES;
        /// <summary>void glTexCoord3bvOES(GLbyte[] coords);</summary>
        public readonly delegate* unmanaged<GLbyte[], void> glTexCoord3bvOES;
        /// <summary>void glTexCoord3d(GLdouble s, GLdouble t, GLdouble r);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, GLdouble, void> glTexCoord3d;
        /// <summary>void glTexCoord3dv(GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glTexCoord3dv;
        /// <summary>void glTexCoord3f(GLfloat s, GLfloat t, GLfloat r);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, void> glTexCoord3f;
        /// <summary>void glTexCoord3fv(GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glTexCoord3fv;
        /// <summary>void glTexCoord3hNV(GLhalfNV s, GLhalfNV t, GLhalfNV r);</summary>
        public readonly delegate* unmanaged<GLhalfNV, GLhalfNV, GLhalfNV, void> glTexCoord3hNV;
        /// <summary>void glTexCoord3hvNV(GLhalfNV[] v);</summary>
        public readonly delegate* unmanaged<GLhalfNV[], void> glTexCoord3hvNV;
        /// <summary>void glTexCoord3i(GLint s, GLint t, GLint r);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, void> glTexCoord3i;
        /// <summary>void glTexCoord3iv(GLint[] v);</summary>
        public readonly delegate* unmanaged<GLint[], void> glTexCoord3iv;
        /// <summary>void glTexCoord3s(GLshort s, GLshort t, GLshort r);</summary>
        public readonly delegate* unmanaged<GLshort, GLshort, GLshort, void> glTexCoord3s;
        /// <summary>void glTexCoord3sv(GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLshort[], void> glTexCoord3sv;
        /// <summary>void glTexCoord3xOES(GLfixed s, GLfixed t, GLfixed r);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, GLfixed, void> glTexCoord3xOES;
        /// <summary>void glTexCoord3xvOES(GLfixed[] coords);</summary>
        public readonly delegate* unmanaged<GLfixed[], void> glTexCoord3xvOES;
        /// <summary>void glTexCoord4bOES(GLbyte s, GLbyte t, GLbyte r, GLbyte q);</summary>
        public readonly delegate* unmanaged<GLbyte, GLbyte, GLbyte, GLbyte, void> glTexCoord4bOES;
        /// <summary>void glTexCoord4bvOES(GLbyte[] coords);</summary>
        public readonly delegate* unmanaged<GLbyte[], void> glTexCoord4bvOES;
        /// <summary>void glTexCoord4d(GLdouble s, GLdouble t, GLdouble r, GLdouble q);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, GLdouble, GLdouble, void> glTexCoord4d;
        /// <summary>void glTexCoord4dv(GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glTexCoord4dv;
        /// <summary>void glTexCoord4f(GLfloat s, GLfloat t, GLfloat r, GLfloat q);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, void> glTexCoord4f;
        /// <summary>void glTexCoord4fColor4fNormal3fVertex4fSUN(GLfloat s, GLfloat t, GLfloat p, GLfloat q, GLfloat r, GLfloat g, GLfloat b, GLfloat a, GLfloat nx, GLfloat ny, GLfloat nz, GLfloat x, GLfloat y, GLfloat z, GLfloat w);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glTexCoord4fColor4fNormal3fVertex4fSUN;
        /// <summary>void glTexCoord4fColor4fNormal3fVertex4fvSUN(GLfloat[] tc, GLfloat[] c, GLfloat[] n, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], GLfloat[], GLfloat[], GLfloat[], void> glTexCoord4fColor4fNormal3fVertex4fvSUN;
        /// <summary>void glTexCoord4fVertex4fSUN(GLfloat s, GLfloat t, GLfloat p, GLfloat q, GLfloat x, GLfloat y, GLfloat z, GLfloat w);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glTexCoord4fVertex4fSUN;
        /// <summary>void glTexCoord4fVertex4fvSUN(GLfloat[] tc, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], GLfloat[], void> glTexCoord4fVertex4fvSUN;
        /// <summary>void glTexCoord4fv(GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glTexCoord4fv;
        /// <summary>void glTexCoord4hNV(GLhalfNV s, GLhalfNV t, GLhalfNV r, GLhalfNV q);</summary>
        public readonly delegate* unmanaged<GLhalfNV, GLhalfNV, GLhalfNV, GLhalfNV, void> glTexCoord4hNV;
        /// <summary>void glTexCoord4hvNV(GLhalfNV[] v);</summary>
        public readonly delegate* unmanaged<GLhalfNV[], void> glTexCoord4hvNV;
        /// <summary>void glTexCoord4i(GLint s, GLint t, GLint r, GLint q);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, GLint, void> glTexCoord4i;
        /// <summary>void glTexCoord4iv(GLint[] v);</summary>
        public readonly delegate* unmanaged<GLint[], void> glTexCoord4iv;
        /// <summary>void glTexCoord4s(GLshort s, GLshort t, GLshort r, GLshort q);</summary>
        public readonly delegate* unmanaged<GLshort, GLshort, GLshort, GLshort, void> glTexCoord4s;
        /// <summary>void glTexCoord4sv(GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLshort[], void> glTexCoord4sv;
        /// <summary>void glTexCoord4xOES(GLfixed s, GLfixed t, GLfixed r, GLfixed q);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, void> glTexCoord4xOES;
        /// <summary>void glTexCoord4xvOES(GLfixed[] coords);</summary>
        public readonly delegate* unmanaged<GLfixed[], void> glTexCoord4xvOES;
        /// <summary>void glTexCoordFormatNV(GLint size, GLenum type, GLsizei stride);</summary>
        public readonly delegate* unmanaged<GLint, GLenum, GLsizei, void> glTexCoordFormatNV;
        /// <summary>void glTexCoordP1ui(GLenum type, GLuint coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glTexCoordP1ui;
        /// <summary>void glTexCoordP1uiv(GLenum type, GLuint[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint[], void> glTexCoordP1uiv;
        /// <summary>void glTexCoordP2ui(GLenum type, GLuint coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glTexCoordP2ui;
        /// <summary>void glTexCoordP2uiv(GLenum type, GLuint[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint[], void> glTexCoordP2uiv;
        /// <summary>void glTexCoordP3ui(GLenum type, GLuint coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glTexCoordP3ui;
        /// <summary>void glTexCoordP3uiv(GLenum type, GLuint[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint[], void> glTexCoordP3uiv;
        /// <summary>void glTexCoordP4ui(GLenum type, GLuint coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glTexCoordP4ui;
        /// <summary>void glTexCoordP4uiv(GLenum type, GLuint[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint[], void> glTexCoordP4uiv;
        /// <summary>void glTexCoordPointer(GLint size, GLenum type, GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLint, GLenum, GLsizei, IntPtr, void> glTexCoordPointer;
        /// <summary>void glTexCoordPointerEXT(GLint size, GLenum type, GLsizei stride, GLsizei count, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLint, GLenum, GLsizei, GLsizei, IntPtr, void> glTexCoordPointerEXT;
        /// <summary>void glTexCoordPointerListIBM(GLint size, GLenum type, GLint stride, IntPtr pointer, GLint ptrstride);</summary>
        public readonly delegate* unmanaged<GLint, GLenum, GLint, IntPtr, GLint, void> glTexCoordPointerListIBM;
        /// <summary>void glTexCoordPointervINTEL(GLint size, GLenum type, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLint, GLenum, IntPtr, void> glTexCoordPointervINTEL;
        /// <summary>void glTexEnvf(GLenum target, GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat, void> glTexEnvf;
        /// <summary>void glTexEnvfv(GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glTexEnvfv;
        /// <summary>void glTexEnvi(GLenum target, GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, void> glTexEnvi;
        /// <summary>void glTexEnviv(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glTexEnviv;
        /// <summary>void glTexEnvx(GLenum target, GLenum pname, GLfixed param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed, void> glTexEnvx;
        /// <summary>void glTexEnvxOES(GLenum target, GLenum pname, GLfixed param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed, void> glTexEnvxOES;
        /// <summary>void glTexEnvxv(GLenum target, GLenum pname, GLfixed[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed[], void> glTexEnvxv;
        /// <summary>void glTexEnvxvOES(GLenum target, GLenum pname, GLfixed[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed[], void> glTexEnvxvOES;
        /// <summary>void glTexFilterFuncSGIS(GLenum target, GLenum filter, GLsizei n, GLfloat[] weights);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLsizei, GLfloat[], void> glTexFilterFuncSGIS;
        /// <summary>void glTexGend(GLenum coord, GLenum pname, GLdouble param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLdouble, void> glTexGend;
        /// <summary>void glTexGendv(GLenum coord, GLenum pname, GLdouble[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLdouble[], void> glTexGendv;
        /// <summary>void glTexGenf(GLenum coord, GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat, void> glTexGenf;
        /// <summary>void glTexGenfOES(GLenum coord, GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat, void> glTexGenfOES;
        /// <summary>void glTexGenfv(GLenum coord, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glTexGenfv;
        /// <summary>void glTexGenfvOES(GLenum coord, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glTexGenfvOES;
        /// <summary>void glTexGeni(GLenum coord, GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, void> glTexGeni;
        /// <summary>void glTexGeniOES(GLenum coord, GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, void> glTexGeniOES;
        /// <summary>void glTexGeniv(GLenum coord, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glTexGeniv;
        /// <summary>void glTexGenivOES(GLenum coord, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glTexGenivOES;
        /// <summary>void glTexGenxOES(GLenum coord, GLenum pname, GLfixed param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed, void> glTexGenxOES;
        /// <summary>void glTexGenxvOES(GLenum coord, GLenum pname, GLfixed[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed[], void> glTexGenxvOES;
        /// <summary>void glTexImage1D(GLenum target, GLint level, GLint internalformat, GLsizei width, GLint border, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLsizei, GLint, GLenum, GLenum, IntPtr, void> glTexImage1D;
        /// <summary>void glTexImage2D(GLenum target, GLint level, GLint internalformat, GLsizei width, GLsizei height, GLint border, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLsizei, GLsizei, GLint, GLenum, GLenum, IntPtr, void> glTexImage2D;
        /// <summary>void glTexImage2DMultisample(GLenum target, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height, GLboolean fixedsamplelocations);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLboolean, void> glTexImage2DMultisample;
        /// <summary>void glTexImage2DMultisampleCoverageNV(GLenum target, GLsizei coverageSamples, GLsizei colorSamples, GLint internalFormat, GLsizei width, GLsizei height, GLboolean fixedSampleLocations);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLsizei, GLint, GLsizei, GLsizei, GLboolean, void> glTexImage2DMultisampleCoverageNV;
        /// <summary>void glTexImage3D(GLenum target, GLint level, GLint internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLsizei, GLsizei, GLsizei, GLint, GLenum, GLenum, IntPtr, void> glTexImage3D;
        /// <summary>void glTexImage3DEXT(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLenum, GLsizei, GLsizei, GLsizei, GLint, GLenum, GLenum, IntPtr, void> glTexImage3DEXT;
        /// <summary>void glTexImage3DMultisample(GLenum target, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLboolean fixedsamplelocations);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLsizei, GLboolean, void> glTexImage3DMultisample;
        /// <summary>void glTexImage3DMultisampleCoverageNV(GLenum target, GLsizei coverageSamples, GLsizei colorSamples, GLint internalFormat, GLsizei width, GLsizei height, GLsizei depth, GLboolean fixedSampleLocations);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLsizei, GLint, GLsizei, GLsizei, GLsizei, GLboolean, void> glTexImage3DMultisampleCoverageNV;
        /// <summary>void glTexImage3DOES(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLenum, GLsizei, GLsizei, GLsizei, GLint, GLenum, GLenum, IntPtr, void> glTexImage3DOES;
        /// <summary>void glTexImage4DSGIS(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLsizei size4d, GLint border, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLenum, GLsizei, GLsizei, GLsizei, GLsizei, GLint, GLenum, GLenum, IntPtr, void> glTexImage4DSGIS;
        /// <summary>void glTexPageCommitmentARB(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLboolean commit);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLboolean, void> glTexPageCommitmentARB;
        /// <summary>void glTexPageCommitmentEXT(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLboolean commit);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLboolean, void> glTexPageCommitmentEXT;
        /// <summary>void glTexParameterIiv(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glTexParameterIiv;
        /// <summary>void glTexParameterIivEXT(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glTexParameterIivEXT;
        /// <summary>void glTexParameterIivOES(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glTexParameterIivOES;
        /// <summary>void glTexParameterIuiv(GLenum target, GLenum pname, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint[], void> glTexParameterIuiv;
        /// <summary>void glTexParameterIuivEXT(GLenum target, GLenum pname, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint[], void> glTexParameterIuivEXT;
        /// <summary>void glTexParameterIuivOES(GLenum target, GLenum pname, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLuint[], void> glTexParameterIuivOES;
        /// <summary>void glTexParameterf(GLenum target, GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat, void> glTexParameterf;
        /// <summary>void glTexParameterfv(GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfloat[], void> glTexParameterfv;
        /// <summary>void glTexParameteri(GLenum target, GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, void> glTexParameteri;
        /// <summary>void glTexParameteriv(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint*, void> glTexParameteriv;
        /// <summary>void glTexParameterx(GLenum target, GLenum pname, GLfixed param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed, void> glTexParameterx;
        /// <summary>void glTexParameterxOES(GLenum target, GLenum pname, GLfixed param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed, void> glTexParameterxOES;
        /// <summary>void glTexParameterxv(GLenum target, GLenum pname, GLfixed[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed[], void> glTexParameterxv;
        /// <summary>void glTexParameterxvOES(GLenum target, GLenum pname, GLfixed[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLfixed[], void> glTexParameterxvOES;
        /// <summary>void glTexRenderbufferNV(GLenum target, GLuint renderbuffer);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glTexRenderbufferNV;
        /// <summary>void glTexStorage1D(GLenum target, GLsizei levels, GLenum internalformat, GLsizei width);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, void> glTexStorage1D;
        /// <summary>void glTexStorage1DEXT(GLenum target, GLsizei levels, GLenum internalformat, GLsizei width);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, void> glTexStorage1DEXT;
        /// <summary>void glTexStorage2D(GLenum target, GLsizei levels, GLenum internalformat, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, void> glTexStorage2D;
        /// <summary>void glTexStorage2DEXT(GLenum target, GLsizei levels, GLenum internalformat, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, void> glTexStorage2DEXT;
        /// <summary>void glTexStorage2DMultisample(GLenum target, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height, GLboolean fixedsamplelocations);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLboolean, void> glTexStorage2DMultisample;
        /// <summary>void glTexStorage3D(GLenum target, GLsizei levels, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLsizei, void> glTexStorage3D;
        /// <summary>void glTexStorage3DEXT(GLenum target, GLsizei levels, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLsizei, void> glTexStorage3DEXT;
        /// <summary>void glTexStorage3DMultisample(GLenum target, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLboolean fixedsamplelocations);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLsizei, GLboolean, void> glTexStorage3DMultisample;
        /// <summary>void glTexStorage3DMultisampleOES(GLenum target, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLboolean fixedsamplelocations);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLsizei, GLboolean, void> glTexStorage3DMultisampleOES;
        /// <summary>void glTexStorageMem1DEXT(GLenum target, GLsizei levels, GLenum internalFormat, GLsizei width, GLuint memory, GLuint64 offset);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLuint, GLuint64, void> glTexStorageMem1DEXT;
        /// <summary>void glTexStorageMem2DEXT(GLenum target, GLsizei levels, GLenum internalFormat, GLsizei width, GLsizei height, GLuint memory, GLuint64 offset);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLuint, GLuint64, void> glTexStorageMem2DEXT;
        /// <summary>void glTexStorageMem2DMultisampleEXT(GLenum target, GLsizei samples, GLenum internalFormat, GLsizei width, GLsizei height, GLboolean fixedSampleLocations, GLuint memory, GLuint64 offset);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLboolean, GLuint, GLuint64, void> glTexStorageMem2DMultisampleEXT;
        /// <summary>void glTexStorageMem3DEXT(GLenum target, GLsizei levels, GLenum internalFormat, GLsizei width, GLsizei height, GLsizei depth, GLuint memory, GLuint64 offset);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLsizei, GLuint, GLuint64, void> glTexStorageMem3DEXT;
        /// <summary>void glTexStorageMem3DMultisampleEXT(GLenum target, GLsizei samples, GLenum internalFormat, GLsizei width, GLsizei height, GLsizei depth, GLboolean fixedSampleLocations, GLuint memory, GLuint64 offset);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLsizei, GLboolean, GLuint, GLuint64, void> glTexStorageMem3DMultisampleEXT;
        /// <summary>void glTexStorageSparseAMD(GLenum target, GLenum internalFormat, GLsizei width, GLsizei height, GLsizei depth, GLsizei layers, GLbitfield flags);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLsizei, GLsizei, GLsizei, GLsizei, GLbitfield, void> glTexStorageSparseAMD;
        /// <summary>void glTexSubImage1D(GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLsizei, GLenum, GLenum, IntPtr, void> glTexSubImage1D;
        /// <summary>void glTexSubImage1DEXT(GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLsizei, GLenum, GLenum, IntPtr, void> glTexSubImage1DEXT;
        /// <summary>void glTexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void> glTexSubImage2D;
        /// <summary>void glTexSubImage2DEXT(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void> glTexSubImage2DEXT;
        /// <summary>void glTexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void> glTexSubImage3D;
        /// <summary>void glTexSubImage3DEXT(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void> glTexSubImage3DEXT;
        /// <summary>void glTexSubImage3DOES(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void> glTexSubImage3DOES;
        /// <summary>void glTexSubImage4DSGIS(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLint woffset, GLsizei width, GLsizei height, GLsizei depth, GLsizei size4d, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void> glTexSubImage4DSGIS;
        /// <summary>void glTextureAttachMemoryNV(GLuint texture, GLuint memory, GLuint64 offset);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint64, void> glTextureAttachMemoryNV;
        /// <summary>void glTextureBarrier();</summary>
        public readonly delegate* unmanaged<void> glTextureBarrier;
        /// <summary>void glTextureBarrierNV();</summary>
        public readonly delegate* unmanaged<void> glTextureBarrierNV;
        /// <summary>void glTextureBuffer(GLuint texture, GLenum internalformat, GLuint buffer);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, void> glTextureBuffer;
        /// <summary>void glTextureBufferEXT(GLuint texture, GLenum target, GLenum internalformat, GLuint buffer);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLuint, void> glTextureBufferEXT;
        /// <summary>void glTextureBufferRange(GLuint texture, GLenum internalformat, GLuint buffer, GLintptr offset, GLsizeiptr size);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLintptr, GLsizeiptr, void> glTextureBufferRange;
        /// <summary>void glTextureBufferRangeEXT(GLuint texture, GLenum target, GLenum internalformat, GLuint buffer, GLintptr offset, GLsizeiptr size);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLuint, GLintptr, GLsizeiptr, void> glTextureBufferRangeEXT;
        /// <summary>void glTextureColorMaskSGIS(GLboolean red, GLboolean green, GLboolean blue, GLboolean alpha);</summary>
        public readonly delegate* unmanaged<GLboolean, GLboolean, GLboolean, GLboolean, void> glTextureColorMaskSGIS;
        /// <summary>void glTextureFoveationParametersQCOM(GLuint texture, GLuint layer, GLuint focalPoint, GLfloat focalX, GLfloat focalY, GLfloat gainX, GLfloat gainY, GLfloat foveaArea);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glTextureFoveationParametersQCOM;
        /// <summary>void glTextureImage1DEXT(GLuint texture, GLenum target, GLint level, GLint internalformat, GLsizei width, GLint border, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLsizei, GLint, GLenum, GLenum, IntPtr, void> glTextureImage1DEXT;
        /// <summary>void glTextureImage2DEXT(GLuint texture, GLenum target, GLint level, GLint internalformat, GLsizei width, GLsizei height, GLint border, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLsizei, GLsizei, GLint, GLenum, GLenum, IntPtr, void> glTextureImage2DEXT;
        /// <summary>void glTextureImage2DMultisampleCoverageNV(GLuint texture, GLenum target, GLsizei coverageSamples, GLsizei colorSamples, GLint internalFormat, GLsizei width, GLsizei height, GLboolean fixedSampleLocations);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLsizei, GLsizei, GLint, GLsizei, GLsizei, GLboolean, void> glTextureImage2DMultisampleCoverageNV;
        /// <summary>void glTextureImage2DMultisampleNV(GLuint texture, GLenum target, GLsizei samples, GLint internalFormat, GLsizei width, GLsizei height, GLboolean fixedSampleLocations);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLsizei, GLint, GLsizei, GLsizei, GLboolean, void> glTextureImage2DMultisampleNV;
        /// <summary>void glTextureImage3DEXT(GLuint texture, GLenum target, GLint level, GLint internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLsizei, GLsizei, GLsizei, GLint, GLenum, GLenum, IntPtr, void> glTextureImage3DEXT;
        /// <summary>void glTextureImage3DMultisampleCoverageNV(GLuint texture, GLenum target, GLsizei coverageSamples, GLsizei colorSamples, GLint internalFormat, GLsizei width, GLsizei height, GLsizei depth, GLboolean fixedSampleLocations);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLsizei, GLsizei, GLint, GLsizei, GLsizei, GLsizei, GLboolean, void> glTextureImage3DMultisampleCoverageNV;
        /// <summary>void glTextureImage3DMultisampleNV(GLuint texture, GLenum target, GLsizei samples, GLint internalFormat, GLsizei width, GLsizei height, GLsizei depth, GLboolean fixedSampleLocations);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLsizei, GLint, GLsizei, GLsizei, GLsizei, GLboolean, void> glTextureImage3DMultisampleNV;
        /// <summary>void glTextureLightEXT(GLenum pname);</summary>
        public readonly delegate* unmanaged<GLenum, void> glTextureLightEXT;
        /// <summary>void glTextureMaterialEXT(GLenum face, GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, void> glTextureMaterialEXT;
        /// <summary>void glTextureNormalEXT(GLenum mode);</summary>
        public readonly delegate* unmanaged<GLenum, void> glTextureNormalEXT;
        /// <summary>void glTexturePageCommitmentEXT(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLboolean commit);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLboolean, void> glTexturePageCommitmentEXT;
        /// <summary>void glTextureParameterIiv(GLuint texture, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glTextureParameterIiv;
        /// <summary>void glTextureParameterIivEXT(GLuint texture, GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLint[], void> glTextureParameterIivEXT;
        /// <summary>void glTextureParameterIuiv(GLuint texture, GLenum pname, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint[], void> glTextureParameterIuiv;
        /// <summary>void glTextureParameterIuivEXT(GLuint texture, GLenum target, GLenum pname, GLuint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLuint[], void> glTextureParameterIuivEXT;
        /// <summary>void glTextureParameterf(GLuint texture, GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLfloat, void> glTextureParameterf;
        /// <summary>void glTextureParameterfEXT(GLuint texture, GLenum target, GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLfloat, void> glTextureParameterfEXT;
        /// <summary>void glTextureParameterfv(GLuint texture, GLenum pname, GLfloat[] param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLfloat[], void> glTextureParameterfv;
        /// <summary>void glTextureParameterfvEXT(GLuint texture, GLenum target, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLfloat[], void> glTextureParameterfvEXT;
        /// <summary>void glTextureParameteri(GLuint texture, GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, void> glTextureParameteri;
        /// <summary>void glTextureParameteriEXT(GLuint texture, GLenum target, GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLint, void> glTextureParameteriEXT;
        /// <summary>void glTextureParameteriv(GLuint texture, GLenum pname, GLint[] param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint[], void> glTextureParameteriv;
        /// <summary>void glTextureParameterivEXT(GLuint texture, GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLint[], void> glTextureParameterivEXT;
        /// <summary>void glTextureRangeAPPLE(GLenum target, GLsizei length, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, IntPtr, void> glTextureRangeAPPLE;
        /// <summary>void glTextureRenderbufferEXT(GLuint texture, GLenum target, GLuint renderbuffer);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, void> glTextureRenderbufferEXT;
        /// <summary>void glTextureStorage1D(GLuint texture, GLsizei levels, GLenum internalformat, GLsizei width);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLenum, GLsizei, void> glTextureStorage1D;
        /// <summary>void glTextureStorage1DEXT(GLuint texture, GLenum target, GLsizei levels, GLenum internalformat, GLsizei width);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLsizei, GLenum, GLsizei, void> glTextureStorage1DEXT;
        /// <summary>void glTextureStorage2D(GLuint texture, GLsizei levels, GLenum internalformat, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLenum, GLsizei, GLsizei, void> glTextureStorage2D;
        /// <summary>void glTextureStorage2DEXT(GLuint texture, GLenum target, GLsizei levels, GLenum internalformat, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLsizei, GLenum, GLsizei, GLsizei, void> glTextureStorage2DEXT;
        /// <summary>void glTextureStorage2DMultisample(GLuint texture, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height, GLboolean fixedsamplelocations);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLenum, GLsizei, GLsizei, GLboolean, void> glTextureStorage2DMultisample;
        /// <summary>void glTextureStorage2DMultisampleEXT(GLuint texture, GLenum target, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height, GLboolean fixedsamplelocations);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLboolean, void> glTextureStorage2DMultisampleEXT;
        /// <summary>void glTextureStorage3D(GLuint texture, GLsizei levels, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLenum, GLsizei, GLsizei, GLsizei, void> glTextureStorage3D;
        /// <summary>void glTextureStorage3DEXT(GLuint texture, GLenum target, GLsizei levels, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLsizei, void> glTextureStorage3DEXT;
        /// <summary>void glTextureStorage3DMultisample(GLuint texture, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLboolean fixedsamplelocations);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLenum, GLsizei, GLsizei, GLsizei, GLboolean, void> glTextureStorage3DMultisample;
        /// <summary>void glTextureStorage3DMultisampleEXT(GLuint texture, GLenum target, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLboolean fixedsamplelocations);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLsizei, GLboolean, void> glTextureStorage3DMultisampleEXT;
        /// <summary>void glTextureStorageMem1DEXT(GLuint texture, GLsizei levels, GLenum internalFormat, GLsizei width, GLuint memory, GLuint64 offset);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLenum, GLsizei, GLuint, GLuint64, void> glTextureStorageMem1DEXT;
        /// <summary>void glTextureStorageMem2DEXT(GLuint texture, GLsizei levels, GLenum internalFormat, GLsizei width, GLsizei height, GLuint memory, GLuint64 offset);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLenum, GLsizei, GLsizei, GLuint, GLuint64, void> glTextureStorageMem2DEXT;
        /// <summary>void glTextureStorageMem2DMultisampleEXT(GLuint texture, GLsizei samples, GLenum internalFormat, GLsizei width, GLsizei height, GLboolean fixedSampleLocations, GLuint memory, GLuint64 offset);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLenum, GLsizei, GLsizei, GLboolean, GLuint, GLuint64, void> glTextureStorageMem2DMultisampleEXT;
        /// <summary>void glTextureStorageMem3DEXT(GLuint texture, GLsizei levels, GLenum internalFormat, GLsizei width, GLsizei height, GLsizei depth, GLuint memory, GLuint64 offset);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLenum, GLsizei, GLsizei, GLsizei, GLuint, GLuint64, void> glTextureStorageMem3DEXT;
        /// <summary>void glTextureStorageMem3DMultisampleEXT(GLuint texture, GLsizei samples, GLenum internalFormat, GLsizei width, GLsizei height, GLsizei depth, GLboolean fixedSampleLocations, GLuint memory, GLuint64 offset);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLenum, GLsizei, GLsizei, GLsizei, GLboolean, GLuint, GLuint64, void> glTextureStorageMem3DMultisampleEXT;
        /// <summary>void glTextureStorageSparseAMD(GLuint texture, GLenum target, GLenum internalFormat, GLsizei width, GLsizei height, GLsizei depth, GLsizei layers, GLbitfield flags);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLsizei, GLsizei, GLsizei, GLsizei, GLbitfield, void> glTextureStorageSparseAMD;
        /// <summary>void glTextureSubImage1D(GLuint texture, GLint level, GLint xoffset, GLsizei width, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLsizei, GLenum, GLenum, IntPtr, void> glTextureSubImage1D;
        /// <summary>void glTextureSubImage1DEXT(GLuint texture, GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLsizei, GLenum, GLenum, IntPtr, void> glTextureSubImage1DEXT;
        /// <summary>void glTextureSubImage2D(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLint, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void> glTextureSubImage2D;
        /// <summary>void glTextureSubImage2DEXT(GLuint texture, GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLint, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void> glTextureSubImage2DEXT;
        /// <summary>void glTextureSubImage3D(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void> glTextureSubImage3D;
        /// <summary>void glTextureSubImage3DEXT(GLuint texture, GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, IntPtr pixels);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void> glTextureSubImage3DEXT;
        /// <summary>void glTextureView(GLuint texture, GLenum target, GLuint origtexture, GLenum internalformat, GLuint minlevel, GLuint numlevels, GLuint minlayer, GLuint numlayers);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLenum, GLuint, GLuint, GLuint, GLuint, void> glTextureView;
        /// <summary>void glTextureViewEXT(GLuint texture, GLenum target, GLuint origtexture, GLenum internalformat, GLuint minlevel, GLuint numlevels, GLuint minlayer, GLuint numlayers);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLenum, GLuint, GLuint, GLuint, GLuint, void> glTextureViewEXT;
        /// <summary>void glTextureViewOES(GLuint texture, GLenum target, GLuint origtexture, GLenum internalformat, GLuint minlevel, GLuint numlevels, GLuint minlayer, GLuint numlayers);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, GLenum, GLuint, GLuint, GLuint, GLuint, void> glTextureViewOES;
        /// <summary>void glTrackMatrixNV(GLenum target, GLuint address, GLenum matrix, GLenum transform);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, GLenum, GLenum, void> glTrackMatrixNV;
        /// <summary>void glTransformFeedbackAttribsNV(GLsizei count, GLint[] attribs, GLenum bufferMode);</summary>
        public readonly delegate* unmanaged<GLsizei, GLint[], GLenum, void> glTransformFeedbackAttribsNV;
        /// <summary>void glTransformFeedbackBufferBase(GLuint xfb, GLuint index, GLuint buffer);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, void> glTransformFeedbackBufferBase;
        /// <summary>void glTransformFeedbackBufferRange(GLuint xfb, GLuint index, GLuint buffer, GLintptr offset, GLsizeiptr size);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, GLintptr, GLsizeiptr, void> glTransformFeedbackBufferRange;
        /// <summary>void glTransformFeedbackStreamAttribsNV(GLsizei count, GLint[] attribs, GLsizei nbuffers, GLint[] bufstreams, GLenum bufferMode);</summary>
        public readonly delegate* unmanaged<GLsizei, GLint[], GLsizei, GLint[], GLenum, void> glTransformFeedbackStreamAttribsNV;
        /// <summary>void glTransformFeedbackVaryings(GLuint program, GLsizei count, string[] varyings, GLenum bufferMode);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, string[], GLenum, void> glTransformFeedbackVaryings;
        /// <summary>void glTransformFeedbackVaryingsEXT(GLuint program, GLsizei count, string[] varyings, GLenum bufferMode);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, string[], GLenum, void> glTransformFeedbackVaryingsEXT;
        /// <summary>void glTransformFeedbackVaryingsNV(GLuint program, GLsizei count, GLint[] locations, GLenum bufferMode);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLint[], GLenum, void> glTransformFeedbackVaryingsNV;
        /// <summary>void glTransformPathNV(GLuint resultPath, GLuint srcPath, GLenum transformType, GLfloat[] transformValues);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLfloat[], void> glTransformPathNV;
        /// <summary>void glTranslated(GLdouble x, GLdouble y, GLdouble z);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, GLdouble, void> glTranslated;
        /// <summary>void glTranslatef(GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, void> glTranslatef;
        /// <summary>void glTranslatex(GLfixed x, GLfixed y, GLfixed z);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, GLfixed, void> glTranslatex;
        /// <summary>void glTranslatexOES(GLfixed x, GLfixed y, GLfixed z);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, GLfixed, void> glTranslatexOES;
        /// <summary>void glUniform1d(GLint location, GLdouble x);</summary>
        public readonly delegate* unmanaged<GLint, GLdouble, void> glUniform1d;
        /// <summary>void glUniform1dv(GLint location, GLsizei count, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLdouble[], void> glUniform1dv;
        /// <summary>void glUniform1f(GLint location, GLfloat v0);</summary>
        public readonly delegate* unmanaged<GLint, GLfloat, void> glUniform1f;
        /// <summary>void glUniform1fARB(GLint location, GLfloat v0);</summary>
        public readonly delegate* unmanaged<GLint, GLfloat, void> glUniform1fARB;
        /// <summary>void glUniform1fv(GLint location, GLsizei count, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLfloat[], void> glUniform1fv;
        /// <summary>void glUniform1fvARB(GLint location, GLsizei count, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLfloat[], void> glUniform1fvARB;
        /// <summary>void glUniform1i(GLint location, GLint v0);</summary>
        public readonly delegate* unmanaged<GLint, GLint, void> glUniform1i;
        /// <summary>void glUniform1i64ARB(GLint location, GLint64 x);</summary>
        public readonly delegate* unmanaged<GLint, GLint64, void> glUniform1i64ARB;
        /// <summary>void glUniform1i64NV(GLint location, GLint64EXT x);</summary>
        public readonly delegate* unmanaged<GLint, GLint64EXT, void> glUniform1i64NV;
        /// <summary>void glUniform1i64vARB(GLint location, GLsizei count, GLint64[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLint64[], void> glUniform1i64vARB;
        /// <summary>void glUniform1i64vNV(GLint location, GLsizei count, GLint64EXT[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLint64EXT[], void> glUniform1i64vNV;
        /// <summary>void glUniform1iARB(GLint location, GLint v0);</summary>
        public readonly delegate* unmanaged<GLint, GLint, void> glUniform1iARB;
        /// <summary>void glUniform1iv(GLint location, GLsizei count, GLint[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLint[], void> glUniform1iv;
        /// <summary>void glUniform1ivARB(GLint location, GLsizei count, GLint[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLint[], void> glUniform1ivARB;
        /// <summary>void glUniform1ui(GLint location, GLuint v0);</summary>
        public readonly delegate* unmanaged<GLint, GLuint, void> glUniform1ui;
        /// <summary>void glUniform1ui64ARB(GLint location, GLuint64 x);</summary>
        public readonly delegate* unmanaged<GLint, GLuint64, void> glUniform1ui64ARB;
        /// <summary>void glUniform1ui64NV(GLint location, GLuint64EXT x);</summary>
        public readonly delegate* unmanaged<GLint, GLuint64EXT, void> glUniform1ui64NV;
        /// <summary>void glUniform1ui64vARB(GLint location, GLsizei count, GLuint64[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLuint64[], void> glUniform1ui64vARB;
        /// <summary>void glUniform1ui64vNV(GLint location, GLsizei count, GLuint64EXT[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLuint64EXT[], void> glUniform1ui64vNV;
        /// <summary>void glUniform1uiEXT(GLint location, GLuint v0);</summary>
        public readonly delegate* unmanaged<GLint, GLuint, void> glUniform1uiEXT;
        /// <summary>void glUniform1uiv(GLint location, GLsizei count, GLuint[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLuint[], void> glUniform1uiv;
        /// <summary>void glUniform1uivEXT(GLint location, GLsizei count, GLuint[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLuint[], void> glUniform1uivEXT;
        /// <summary>void glUniform2d(GLint location, GLdouble x, GLdouble y);</summary>
        public readonly delegate* unmanaged<GLint, GLdouble, GLdouble, void> glUniform2d;
        /// <summary>void glUniform2dv(GLint location, GLsizei count, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLdouble[], void> glUniform2dv;
        /// <summary>void glUniform2f(GLint location, GLfloat v0, GLfloat v1);</summary>
        public readonly delegate* unmanaged<GLint, GLfloat, GLfloat, void> glUniform2f;
        /// <summary>void glUniform2fARB(GLint location, GLfloat v0, GLfloat v1);</summary>
        public readonly delegate* unmanaged<GLint, GLfloat, GLfloat, void> glUniform2fARB;
        /// <summary>void glUniform2fv(GLint location, GLsizei count, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLfloat*, void> glUniform2fv;
        /// <summary>void glUniform2fvARB(GLint location, GLsizei count, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLfloat[], void> glUniform2fvARB;
        /// <summary>void glUniform2i(GLint location, GLint v0, GLint v1);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, void> glUniform2i;
        /// <summary>void glUniform2i64ARB(GLint location, GLint64 x, GLint64 y);</summary>
        public readonly delegate* unmanaged<GLint, GLint64, GLint64, void> glUniform2i64ARB;
        /// <summary>void glUniform2i64NV(GLint location, GLint64EXT x, GLint64EXT y);</summary>
        public readonly delegate* unmanaged<GLint, GLint64EXT, GLint64EXT, void> glUniform2i64NV;
        /// <summary>void glUniform2i64vARB(GLint location, GLsizei count, GLint64[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLint64[], void> glUniform2i64vARB;
        /// <summary>void glUniform2i64vNV(GLint location, GLsizei count, GLint64EXT[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLint64EXT[], void> glUniform2i64vNV;
        /// <summary>void glUniform2iARB(GLint location, GLint v0, GLint v1);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, void> glUniform2iARB;
        /// <summary>void glUniform2iv(GLint location, GLsizei count, GLint[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLint[], void> glUniform2iv;
        /// <summary>void glUniform2ivARB(GLint location, GLsizei count, GLint[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLint[], void> glUniform2ivARB;
        /// <summary>void glUniform2ui(GLint location, GLuint v0, GLuint v1);</summary>
        public readonly delegate* unmanaged<GLint, GLuint, GLuint, void> glUniform2ui;
        /// <summary>void glUniform2ui64ARB(GLint location, GLuint64 x, GLuint64 y);</summary>
        public readonly delegate* unmanaged<GLint, GLuint64, GLuint64, void> glUniform2ui64ARB;
        /// <summary>void glUniform2ui64NV(GLint location, GLuint64EXT x, GLuint64EXT y);</summary>
        public readonly delegate* unmanaged<GLint, GLuint64EXT, GLuint64EXT, void> glUniform2ui64NV;
        /// <summary>void glUniform2ui64vARB(GLint location, GLsizei count, GLuint64[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLuint64[], void> glUniform2ui64vARB;
        /// <summary>void glUniform2ui64vNV(GLint location, GLsizei count, GLuint64EXT[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLuint64EXT[], void> glUniform2ui64vNV;
        /// <summary>void glUniform2uiEXT(GLint location, GLuint v0, GLuint v1);</summary>
        public readonly delegate* unmanaged<GLint, GLuint, GLuint, void> glUniform2uiEXT;
        /// <summary>void glUniform2uiv(GLint location, GLsizei count, GLuint[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLuint[], void> glUniform2uiv;
        /// <summary>void glUniform2uivEXT(GLint location, GLsizei count, GLuint[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLuint[], void> glUniform2uivEXT;
        /// <summary>void glUniform3d(GLint location, GLdouble x, GLdouble y, GLdouble z);</summary>
        public readonly delegate* unmanaged<GLint, GLdouble, GLdouble, GLdouble, void> glUniform3d;
        /// <summary>void glUniform3dv(GLint location, GLsizei count, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLdouble[], void> glUniform3dv;
        /// <summary>void glUniform3f(GLint location, GLfloat v0, GLfloat v1, GLfloat v2);</summary>
        public readonly delegate* unmanaged<GLint, GLfloat, GLfloat, GLfloat, void> glUniform3f;
        /// <summary>void glUniform3fARB(GLint location, GLfloat v0, GLfloat v1, GLfloat v2);</summary>
        public readonly delegate* unmanaged<GLint, GLfloat, GLfloat, GLfloat, void> glUniform3fARB;
        /// <summary>void glUniform3fv(GLint location, GLsizei count, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLfloat*, void> glUniform3fv;
        /// <summary>void glUniform3fvARB(GLint location, GLsizei count, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLfloat[], void> glUniform3fvARB;
        /// <summary>void glUniform3i(GLint location, GLint v0, GLint v1, GLint v2);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, GLint, void> glUniform3i;
        /// <summary>void glUniform3i64ARB(GLint location, GLint64 x, GLint64 y, GLint64 z);</summary>
        public readonly delegate* unmanaged<GLint, GLint64, GLint64, GLint64, void> glUniform3i64ARB;
        /// <summary>void glUniform3i64NV(GLint location, GLint64EXT x, GLint64EXT y, GLint64EXT z);</summary>
        public readonly delegate* unmanaged<GLint, GLint64EXT, GLint64EXT, GLint64EXT, void> glUniform3i64NV;
        /// <summary>void glUniform3i64vARB(GLint location, GLsizei count, GLint64[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLint64[], void> glUniform3i64vARB;
        /// <summary>void glUniform3i64vNV(GLint location, GLsizei count, GLint64EXT[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLint64EXT[], void> glUniform3i64vNV;
        /// <summary>void glUniform3iARB(GLint location, GLint v0, GLint v1, GLint v2);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, GLint, void> glUniform3iARB;
        /// <summary>void glUniform3iv(GLint location, GLsizei count, GLint[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLint[], void> glUniform3iv;
        /// <summary>void glUniform3ivARB(GLint location, GLsizei count, GLint[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLint[], void> glUniform3ivARB;
        /// <summary>void glUniform3ui(GLint location, GLuint v0, GLuint v1, GLuint v2);</summary>
        public readonly delegate* unmanaged<GLint, GLuint, GLuint, GLuint, void> glUniform3ui;
        /// <summary>void glUniform3ui64ARB(GLint location, GLuint64 x, GLuint64 y, GLuint64 z);</summary>
        public readonly delegate* unmanaged<GLint, GLuint64, GLuint64, GLuint64, void> glUniform3ui64ARB;
        /// <summary>void glUniform3ui64NV(GLint location, GLuint64EXT x, GLuint64EXT y, GLuint64EXT z);</summary>
        public readonly delegate* unmanaged<GLint, GLuint64EXT, GLuint64EXT, GLuint64EXT, void> glUniform3ui64NV;
        /// <summary>void glUniform3ui64vARB(GLint location, GLsizei count, GLuint64[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLuint64[], void> glUniform3ui64vARB;
        /// <summary>void glUniform3ui64vNV(GLint location, GLsizei count, GLuint64EXT[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLuint64EXT[], void> glUniform3ui64vNV;
        /// <summary>void glUniform3uiEXT(GLint location, GLuint v0, GLuint v1, GLuint v2);</summary>
        public readonly delegate* unmanaged<GLint, GLuint, GLuint, GLuint, void> glUniform3uiEXT;
        /// <summary>void glUniform3uiv(GLint location, GLsizei count, GLuint[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLuint[], void> glUniform3uiv;
        /// <summary>void glUniform3uivEXT(GLint location, GLsizei count, GLuint[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLuint[], void> glUniform3uivEXT;
        /// <summary>void glUniform4d(GLint location, GLdouble x, GLdouble y, GLdouble z, GLdouble w);</summary>
        public readonly delegate* unmanaged<GLint, GLdouble, GLdouble, GLdouble, GLdouble, void> glUniform4d;
        /// <summary>void glUniform4dv(GLint location, GLsizei count, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLdouble[], void> glUniform4dv;
        /// <summary>void glUniform4f(GLint location, GLfloat v0, GLfloat v1, GLfloat v2, GLfloat v3);</summary>
        public readonly delegate* unmanaged<GLint, GLfloat, GLfloat, GLfloat, GLfloat, void> glUniform4f;
        /// <summary>void glUniform4fARB(GLint location, GLfloat v0, GLfloat v1, GLfloat v2, GLfloat v3);</summary>
        public readonly delegate* unmanaged<GLint, GLfloat, GLfloat, GLfloat, GLfloat, void> glUniform4fARB;
        /// <summary>void glUniform4fv(GLint location, GLsizei count, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLfloat*, void> glUniform4fv;
        /// <summary>void glUniform4fvARB(GLint location, GLsizei count, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLfloat[], void> glUniform4fvARB;
        /// <summary>void glUniform4i(GLint location, GLint v0, GLint v1, GLint v2, GLint v3);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, GLint, GLint, void> glUniform4i;
        /// <summary>void glUniform4i64ARB(GLint location, GLint64 x, GLint64 y, GLint64 z, GLint64 w);</summary>
        public readonly delegate* unmanaged<GLint, GLint64, GLint64, GLint64, GLint64, void> glUniform4i64ARB;
        /// <summary>void glUniform4i64NV(GLint location, GLint64EXT x, GLint64EXT y, GLint64EXT z, GLint64EXT w);</summary>
        public readonly delegate* unmanaged<GLint, GLint64EXT, GLint64EXT, GLint64EXT, GLint64EXT, void> glUniform4i64NV;
        /// <summary>void glUniform4i64vARB(GLint location, GLsizei count, GLint64[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLint64[], void> glUniform4i64vARB;
        /// <summary>void glUniform4i64vNV(GLint location, GLsizei count, GLint64EXT[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLint64EXT[], void> glUniform4i64vNV;
        /// <summary>void glUniform4iARB(GLint location, GLint v0, GLint v1, GLint v2, GLint v3);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, GLint, GLint, void> glUniform4iARB;
        /// <summary>void glUniform4iv(GLint location, GLsizei count, GLint[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLint[], void> glUniform4iv;
        /// <summary>void glUniform4ivARB(GLint location, GLsizei count, GLint[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLint[], void> glUniform4ivARB;
        /// <summary>void glUniform4ui(GLint location, GLuint v0, GLuint v1, GLuint v2, GLuint v3);</summary>
        public readonly delegate* unmanaged<GLint, GLuint, GLuint, GLuint, GLuint, void> glUniform4ui;
        /// <summary>void glUniform4ui64ARB(GLint location, GLuint64 x, GLuint64 y, GLuint64 z, GLuint64 w);</summary>
        public readonly delegate* unmanaged<GLint, GLuint64, GLuint64, GLuint64, GLuint64, void> glUniform4ui64ARB;
        /// <summary>void glUniform4ui64NV(GLint location, GLuint64EXT x, GLuint64EXT y, GLuint64EXT z, GLuint64EXT w);</summary>
        public readonly delegate* unmanaged<GLint, GLuint64EXT, GLuint64EXT, GLuint64EXT, GLuint64EXT, void> glUniform4ui64NV;
        /// <summary>void glUniform4ui64vARB(GLint location, GLsizei count, GLuint64[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLuint64[], void> glUniform4ui64vARB;
        /// <summary>void glUniform4ui64vNV(GLint location, GLsizei count, GLuint64EXT[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLuint64EXT[], void> glUniform4ui64vNV;
        /// <summary>void glUniform4uiEXT(GLint location, GLuint v0, GLuint v1, GLuint v2, GLuint v3);</summary>
        public readonly delegate* unmanaged<GLint, GLuint, GLuint, GLuint, GLuint, void> glUniform4uiEXT;
        /// <summary>void glUniform4uiv(GLint location, GLsizei count, GLuint[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLuint[], void> glUniform4uiv;
        /// <summary>void glUniform4uivEXT(GLint location, GLsizei count, GLuint[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLuint[], void> glUniform4uivEXT;
        /// <summary>void glUniformBlockBinding(GLuint program, GLuint uniformBlockIndex, GLuint uniformBlockBinding);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, void> glUniformBlockBinding;
        /// <summary>void glUniformBufferEXT(GLuint program, GLint location, GLuint buffer);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLuint, void> glUniformBufferEXT;
        /// <summary>void glUniformHandleui64ARB(GLint location, GLuint64 value);</summary>
        public readonly delegate* unmanaged<GLint, GLuint64, void> glUniformHandleui64ARB;
        /// <summary>void glUniformHandleui64IMG(GLint location, GLuint64 value);</summary>
        public readonly delegate* unmanaged<GLint, GLuint64, void> glUniformHandleui64IMG;
        /// <summary>void glUniformHandleui64NV(GLint location, GLuint64 value);</summary>
        public readonly delegate* unmanaged<GLint, GLuint64, void> glUniformHandleui64NV;
        /// <summary>void glUniformHandleui64vARB(GLint location, GLsizei count, GLuint64[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLuint64[], void> glUniformHandleui64vARB;
        /// <summary>void glUniformHandleui64vIMG(GLint location, GLsizei count, GLuint64[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLuint64[], void> glUniformHandleui64vIMG;
        /// <summary>void glUniformHandleui64vNV(GLint location, GLsizei count, GLuint64[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLuint64[], void> glUniformHandleui64vNV;
        /// <summary>void glUniformMatrix2dv(GLint location, GLsizei count, GLboolean transpose, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLboolean, GLdouble[], void> glUniformMatrix2dv;
        /// <summary>void glUniformMatrix2fv(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void> glUniformMatrix2fv;
        /// <summary>void glUniformMatrix2fvARB(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void> glUniformMatrix2fvARB;
        /// <summary>void glUniformMatrix2x3dv(GLint location, GLsizei count, GLboolean transpose, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLboolean, GLdouble[], void> glUniformMatrix2x3dv;
        /// <summary>void glUniformMatrix2x3fv(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void> glUniformMatrix2x3fv;
        /// <summary>void glUniformMatrix2x3fvNV(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void> glUniformMatrix2x3fvNV;
        /// <summary>void glUniformMatrix2x4dv(GLint location, GLsizei count, GLboolean transpose, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLboolean, GLdouble[], void> glUniformMatrix2x4dv;
        /// <summary>void glUniformMatrix2x4fv(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void> glUniformMatrix2x4fv;
        /// <summary>void glUniformMatrix2x4fvNV(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void> glUniformMatrix2x4fvNV;
        /// <summary>void glUniformMatrix3dv(GLint location, GLsizei count, GLboolean transpose, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLboolean, GLdouble[], void> glUniformMatrix3dv;
        /// <summary>void glUniformMatrix3fv(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void> glUniformMatrix3fv;
        /// <summary>void glUniformMatrix3fvARB(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void> glUniformMatrix3fvARB;
        /// <summary>void glUniformMatrix3x2dv(GLint location, GLsizei count, GLboolean transpose, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLboolean, GLdouble[], void> glUniformMatrix3x2dv;
        /// <summary>void glUniformMatrix3x2fv(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void> glUniformMatrix3x2fv;
        /// <summary>void glUniformMatrix3x2fvNV(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void> glUniformMatrix3x2fvNV;
        /// <summary>void glUniformMatrix3x4dv(GLint location, GLsizei count, GLboolean transpose, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLboolean, GLdouble[], void> glUniformMatrix3x4dv;
        /// <summary>void glUniformMatrix3x4fv(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void> glUniformMatrix3x4fv;
        /// <summary>void glUniformMatrix3x4fvNV(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void> glUniformMatrix3x4fvNV;
        /// <summary>void glUniformMatrix4dv(GLint location, GLsizei count, GLboolean transpose, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLboolean, GLdouble[], void> glUniformMatrix4dv;
        /// <summary>void glUniformMatrix4fv(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat*, void> glUniformMatrix4fv;
        /// <summary>void glUniformMatrix4fvARB(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void> glUniformMatrix4fvARB;
        /// <summary>void glUniformMatrix4x2dv(GLint location, GLsizei count, GLboolean transpose, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLboolean, GLdouble[], void> glUniformMatrix4x2dv;
        /// <summary>void glUniformMatrix4x2fv(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void> glUniformMatrix4x2fv;
        /// <summary>void glUniformMatrix4x2fvNV(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void> glUniformMatrix4x2fvNV;
        /// <summary>void glUniformMatrix4x3dv(GLint location, GLsizei count, GLboolean transpose, GLdouble[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLboolean, GLdouble[], void> glUniformMatrix4x3dv;
        /// <summary>void glUniformMatrix4x3fv(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void> glUniformMatrix4x3fv;
        /// <summary>void glUniformMatrix4x3fvNV(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void> glUniformMatrix4x3fvNV;
        /// <summary>void glUniformSubroutinesuiv(GLenum shadertype, GLsizei count, GLuint[] indices);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLuint*, void> glUniformSubroutinesuiv;
        /// <summary>void glUniformui64NV(GLint location, GLuint64EXT value);</summary>
        public readonly delegate* unmanaged<GLint, GLuint64EXT, void> glUniformui64NV;
        /// <summary>void glUniformui64vNV(GLint location, GLsizei count, GLuint64EXT[] value);</summary>
        public readonly delegate* unmanaged<GLint, GLsizei, GLuint64EXT[], void> glUniformui64vNV;
        /// <summary>void glUnlockArraysEXT();</summary>
        public readonly delegate* unmanaged<void> glUnlockArraysEXT;
        /// <summary>GLboolean glUnmapBuffer(GLenum target);</summary>
        public readonly delegate* unmanaged<GLenum, GLboolean> glUnmapBuffer;
        /// <summary>GLboolean glUnmapBufferARB(GLenum target);</summary>
        public readonly delegate* unmanaged<GLenum, GLboolean> glUnmapBufferARB;
        /// <summary>GLboolean glUnmapBufferOES(GLenum target);</summary>
        public readonly delegate* unmanaged<GLenum, GLboolean> glUnmapBufferOES;
        /// <summary>GLboolean glUnmapNamedBuffer(GLuint buffer);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glUnmapNamedBuffer;
        /// <summary>GLboolean glUnmapNamedBufferEXT(GLuint buffer);</summary>
        public readonly delegate* unmanaged<GLuint, GLboolean> glUnmapNamedBufferEXT;
        /// <summary>void glUnmapObjectBufferATI(GLuint buffer);</summary>
        public readonly delegate* unmanaged<GLuint, void> glUnmapObjectBufferATI;
        /// <summary>void glUnmapTexture2DINTEL(GLuint texture, GLint level);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, void> glUnmapTexture2DINTEL;
        /// <summary>void glUpdateObjectBufferATI(GLuint buffer, GLuint offset, GLsizei size, IntPtr pointer, GLenum preserve);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLsizei, IntPtr, GLenum, void> glUpdateObjectBufferATI;
        /// <summary>void glUploadGpuMaskNVX(GLbitfield mask);</summary>
        public readonly delegate* unmanaged<GLbitfield, void> glUploadGpuMaskNVX;
        /// <summary>void glUseProgram(GLuint program);</summary>
        public readonly delegate* unmanaged<GLuint, void> glUseProgram;
        /// <summary>void glUseProgramObjectARB(GLhandleARB programObj);</summary>
        public readonly delegate* unmanaged<GLhandleARB, void> glUseProgramObjectARB;
        /// <summary>void glUseProgramStages(GLuint pipeline, GLbitfield stages, GLuint program);</summary>
        public readonly delegate* unmanaged<GLuint, GLbitfield, GLuint, void> glUseProgramStages;
        /// <summary>void glUseProgramStagesEXT(GLuint pipeline, GLbitfield stages, GLuint program);</summary>
        public readonly delegate* unmanaged<GLuint, GLbitfield, GLuint, void> glUseProgramStagesEXT;
        /// <summary>void glUseShaderProgramEXT(GLenum type, GLuint program);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glUseShaderProgramEXT;
        /// <summary>void glVDPAUFiniNV();</summary>
        public readonly delegate* unmanaged<void> glVDPAUFiniNV;
        /// <summary>void glVDPAUGetSurfaceivNV(GLvdpauSurfaceNV surface, GLenum pname, GLsizei count, GLsizei[] length, GLint[] values);</summary>
        public readonly delegate* unmanaged<GLvdpauSurfaceNV, GLenum, GLsizei, GLsizei[], GLint[], void> glVDPAUGetSurfaceivNV;
        /// <summary>void glVDPAUInitNV(IntPtr vdpDevice, IntPtr getProcAddress);</summary>
        public readonly delegate* unmanaged<IntPtr, IntPtr, void> glVDPAUInitNV;
        /// <summary>GLboolean glVDPAUIsSurfaceNV(GLvdpauSurfaceNV surface);</summary>
        public readonly delegate* unmanaged<GLvdpauSurfaceNV, GLboolean> glVDPAUIsSurfaceNV;
        /// <summary>void glVDPAUMapSurfacesNV(GLsizei numSurfaces, GLvdpauSurfaceNV[] surfaces);</summary>
        public readonly delegate* unmanaged<GLsizei, GLvdpauSurfaceNV[], void> glVDPAUMapSurfacesNV;
        /// <summary>GLvdpauSurfaceNV glVDPAURegisterOutputSurfaceNV(IntPtr vdpSurface, GLenum target, GLsizei numTextureNames, GLuint[] textureNames);</summary>
        public readonly delegate* unmanaged<IntPtr, GLenum, GLsizei, GLuint[], GLvdpauSurfaceNV> glVDPAURegisterOutputSurfaceNV;
        /// <summary>GLvdpauSurfaceNV glVDPAURegisterVideoSurfaceNV(IntPtr vdpSurface, GLenum target, GLsizei numTextureNames, GLuint[] textureNames);</summary>
        public readonly delegate* unmanaged<IntPtr, GLenum, GLsizei, GLuint[], GLvdpauSurfaceNV> glVDPAURegisterVideoSurfaceNV;
        /// <summary>GLvdpauSurfaceNV glVDPAURegisterVideoSurfaceWithPictureStructureNV(IntPtr vdpSurface, GLenum target, GLsizei numTextureNames, GLuint[] textureNames, GLboolean isFrameStructure);</summary>
        public readonly delegate* unmanaged<IntPtr, GLenum, GLsizei, GLuint[], GLboolean, GLvdpauSurfaceNV> glVDPAURegisterVideoSurfaceWithPictureStructureNV;
        /// <summary>void glVDPAUSurfaceAccessNV(GLvdpauSurfaceNV surface, GLenum access);</summary>
        public readonly delegate* unmanaged<GLvdpauSurfaceNV, GLenum, void> glVDPAUSurfaceAccessNV;
        /// <summary>void glVDPAUUnmapSurfacesNV(GLsizei numSurface, GLvdpauSurfaceNV[] surfaces);</summary>
        public readonly delegate* unmanaged<GLsizei, GLvdpauSurfaceNV[], void> glVDPAUUnmapSurfacesNV;
        /// <summary>void glVDPAUUnregisterSurfaceNV(GLvdpauSurfaceNV surface);</summary>
        public readonly delegate* unmanaged<GLvdpauSurfaceNV, void> glVDPAUUnregisterSurfaceNV;
        /// <summary>void glValidateProgram(GLuint program);</summary>
        public readonly delegate* unmanaged<GLuint, void> glValidateProgram;
        /// <summary>void glValidateProgramARB(GLhandleARB programObj);</summary>
        public readonly delegate* unmanaged<GLhandleARB, void> glValidateProgramARB;
        /// <summary>void glValidateProgramPipeline(GLuint pipeline);</summary>
        public readonly delegate* unmanaged<GLuint, void> glValidateProgramPipeline;
        /// <summary>void glValidateProgramPipelineEXT(GLuint pipeline);</summary>
        public readonly delegate* unmanaged<GLuint, void> glValidateProgramPipelineEXT;
        /// <summary>void glVariantArrayObjectATI(GLuint id, GLenum type, GLsizei stride, GLuint buffer, GLuint offset);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLsizei, GLuint, GLuint, void> glVariantArrayObjectATI;
        /// <summary>void glVariantPointerEXT(GLuint id, GLenum type, GLuint stride, IntPtr addr);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLuint, IntPtr, void> glVariantPointerEXT;
        /// <summary>void glVariantbvEXT(GLuint id, GLbyte[] addr);</summary>
        public readonly delegate* unmanaged<GLuint, GLbyte[], void> glVariantbvEXT;
        /// <summary>void glVariantdvEXT(GLuint id, GLdouble[] addr);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble[], void> glVariantdvEXT;
        /// <summary>void glVariantfvEXT(GLuint id, GLfloat[] addr);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat[], void> glVariantfvEXT;
        /// <summary>void glVariantivEXT(GLuint id, GLint[] addr);</summary>
        public readonly delegate* unmanaged<GLuint, GLint[], void> glVariantivEXT;
        /// <summary>void glVariantsvEXT(GLuint id, GLshort[] addr);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort[], void> glVariantsvEXT;
        /// <summary>void glVariantubvEXT(GLuint id, GLubyte[] addr);</summary>
        public readonly delegate* unmanaged<GLuint, GLubyte[], void> glVariantubvEXT;
        /// <summary>void glVariantuivEXT(GLuint id, GLuint[] addr);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint[], void> glVariantuivEXT;
        /// <summary>void glVariantusvEXT(GLuint id, GLushort[] addr);</summary>
        public readonly delegate* unmanaged<GLuint, GLushort[], void> glVariantusvEXT;
        /// <summary>void glVertex2bOES(GLbyte x, GLbyte y);</summary>
        public readonly delegate* unmanaged<GLbyte, GLbyte, void> glVertex2bOES;
        /// <summary>void glVertex2bvOES(GLbyte[] coords);</summary>
        public readonly delegate* unmanaged<GLbyte[], void> glVertex2bvOES;
        /// <summary>void glVertex2d(GLdouble x, GLdouble y);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, void> glVertex2d;
        /// <summary>void glVertex2dv(GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glVertex2dv;
        /// <summary>void glVertex2f(GLfloat x, GLfloat y);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, void> glVertex2f;
        /// <summary>void glVertex2fv(GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glVertex2fv;
        /// <summary>void glVertex2hNV(GLhalfNV x, GLhalfNV y);</summary>
        public readonly delegate* unmanaged<GLhalfNV, GLhalfNV, void> glVertex2hNV;
        /// <summary>void glVertex2hvNV(GLhalfNV[] v);</summary>
        public readonly delegate* unmanaged<GLhalfNV[], void> glVertex2hvNV;
        /// <summary>void glVertex2i(GLint x, GLint y);</summary>
        public readonly delegate* unmanaged<GLint, GLint, void> glVertex2i;
        /// <summary>void glVertex2iv(GLint[] v);</summary>
        public readonly delegate* unmanaged<GLint[], void> glVertex2iv;
        /// <summary>void glVertex2s(GLshort x, GLshort y);</summary>
        public readonly delegate* unmanaged<GLshort, GLshort, void> glVertex2s;
        /// <summary>void glVertex2sv(GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLshort[], void> glVertex2sv;
        /// <summary>void glVertex2xOES(GLfixed x);</summary>
        public readonly delegate* unmanaged<GLfixed, void> glVertex2xOES;
        /// <summary>void glVertex2xvOES(GLfixed[] coords);</summary>
        public readonly delegate* unmanaged<GLfixed[], void> glVertex2xvOES;
        /// <summary>void glVertex3bOES(GLbyte x, GLbyte y, GLbyte z);</summary>
        public readonly delegate* unmanaged<GLbyte, GLbyte, GLbyte, void> glVertex3bOES;
        /// <summary>void glVertex3bvOES(GLbyte[] coords);</summary>
        public readonly delegate* unmanaged<GLbyte[], void> glVertex3bvOES;
        /// <summary>void glVertex3d(GLdouble x, GLdouble y, GLdouble z);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, GLdouble, void> glVertex3d;
        /// <summary>void glVertex3dv(GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glVertex3dv;
        /// <summary>void glVertex3f(GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, void> glVertex3f;
        /// <summary>void glVertex3fv(GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glVertex3fv;
        /// <summary>void glVertex3hNV(GLhalfNV x, GLhalfNV y, GLhalfNV z);</summary>
        public readonly delegate* unmanaged<GLhalfNV, GLhalfNV, GLhalfNV, void> glVertex3hNV;
        /// <summary>void glVertex3hvNV(GLhalfNV[] v);</summary>
        public readonly delegate* unmanaged<GLhalfNV[], void> glVertex3hvNV;
        /// <summary>void glVertex3i(GLint x, GLint y, GLint z);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, void> glVertex3i;
        /// <summary>void glVertex3iv(GLint[] v);</summary>
        public readonly delegate* unmanaged<GLint[], void> glVertex3iv;
        /// <summary>void glVertex3s(GLshort x, GLshort y, GLshort z);</summary>
        public readonly delegate* unmanaged<GLshort, GLshort, GLshort, void> glVertex3s;
        /// <summary>void glVertex3sv(GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLshort[], void> glVertex3sv;
        /// <summary>void glVertex3xOES(GLfixed x, GLfixed y);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, void> glVertex3xOES;
        /// <summary>void glVertex3xvOES(GLfixed[] coords);</summary>
        public readonly delegate* unmanaged<GLfixed[], void> glVertex3xvOES;
        /// <summary>void glVertex4bOES(GLbyte x, GLbyte y, GLbyte z, GLbyte w);</summary>
        public readonly delegate* unmanaged<GLbyte, GLbyte, GLbyte, GLbyte, void> glVertex4bOES;
        /// <summary>void glVertex4bvOES(GLbyte[] coords);</summary>
        public readonly delegate* unmanaged<GLbyte[], void> glVertex4bvOES;
        /// <summary>void glVertex4d(GLdouble x, GLdouble y, GLdouble z, GLdouble w);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, GLdouble, GLdouble, void> glVertex4d;
        /// <summary>void glVertex4dv(GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glVertex4dv;
        /// <summary>void glVertex4f(GLfloat x, GLfloat y, GLfloat z, GLfloat w);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, void> glVertex4f;
        /// <summary>void glVertex4fv(GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glVertex4fv;
        /// <summary>void glVertex4hNV(GLhalfNV x, GLhalfNV y, GLhalfNV z, GLhalfNV w);</summary>
        public readonly delegate* unmanaged<GLhalfNV, GLhalfNV, GLhalfNV, GLhalfNV, void> glVertex4hNV;
        /// <summary>void glVertex4hvNV(GLhalfNV[] v);</summary>
        public readonly delegate* unmanaged<GLhalfNV[], void> glVertex4hvNV;
        /// <summary>void glVertex4i(GLint x, GLint y, GLint z, GLint w);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, GLint, void> glVertex4i;
        /// <summary>void glVertex4iv(GLint[] v);</summary>
        public readonly delegate* unmanaged<GLint[], void> glVertex4iv;
        /// <summary>void glVertex4s(GLshort x, GLshort y, GLshort z, GLshort w);</summary>
        public readonly delegate* unmanaged<GLshort, GLshort, GLshort, GLshort, void> glVertex4s;
        /// <summary>void glVertex4sv(GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLshort[], void> glVertex4sv;
        /// <summary>void glVertex4xOES(GLfixed x, GLfixed y, GLfixed z);</summary>
        public readonly delegate* unmanaged<GLfixed, GLfixed, GLfixed, void> glVertex4xOES;
        /// <summary>void glVertex4xvOES(GLfixed[] coords);</summary>
        public readonly delegate* unmanaged<GLfixed[], void> glVertex4xvOES;
        /// <summary>void glVertexArrayAttribBinding(GLuint vaobj, GLuint attribindex, GLuint bindingindex);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, void> glVertexArrayAttribBinding;
        /// <summary>void glVertexArrayAttribFormat(GLuint vaobj, GLuint attribindex, GLint size, GLenum type, GLboolean normalized, GLuint relativeoffset);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLint, GLenum, GLboolean, GLuint, void> glVertexArrayAttribFormat;
        /// <summary>void glVertexArrayAttribIFormat(GLuint vaobj, GLuint attribindex, GLint size, GLenum type, GLuint relativeoffset);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLint, GLenum, GLuint, void> glVertexArrayAttribIFormat;
        /// <summary>void glVertexArrayAttribLFormat(GLuint vaobj, GLuint attribindex, GLint size, GLenum type, GLuint relativeoffset);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLint, GLenum, GLuint, void> glVertexArrayAttribLFormat;
        /// <summary>void glVertexArrayBindVertexBufferEXT(GLuint vaobj, GLuint bindingindex, GLuint buffer, GLintptr offset, GLsizei stride);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, GLintptr, GLsizei, void> glVertexArrayBindVertexBufferEXT;
        /// <summary>void glVertexArrayBindingDivisor(GLuint vaobj, GLuint bindingindex, GLuint divisor);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, void> glVertexArrayBindingDivisor;
        /// <summary>void glVertexArrayColorOffsetEXT(GLuint vaobj, GLuint buffer, GLint size, GLenum type, GLsizei stride, GLintptr offset);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLint, GLenum, GLsizei, GLintptr, void> glVertexArrayColorOffsetEXT;
        /// <summary>void glVertexArrayEdgeFlagOffsetEXT(GLuint vaobj, GLuint buffer, GLsizei stride, GLintptr offset);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLsizei, GLintptr, void> glVertexArrayEdgeFlagOffsetEXT;
        /// <summary>void glVertexArrayElementBuffer(GLuint vaobj, GLuint buffer);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, void> glVertexArrayElementBuffer;
        /// <summary>void glVertexArrayFogCoordOffsetEXT(GLuint vaobj, GLuint buffer, GLenum type, GLsizei stride, GLintptr offset);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLsizei, GLintptr, void> glVertexArrayFogCoordOffsetEXT;
        /// <summary>void glVertexArrayIndexOffsetEXT(GLuint vaobj, GLuint buffer, GLenum type, GLsizei stride, GLintptr offset);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLsizei, GLintptr, void> glVertexArrayIndexOffsetEXT;
        /// <summary>void glVertexArrayMultiTexCoordOffsetEXT(GLuint vaobj, GLuint buffer, GLenum texunit, GLint size, GLenum type, GLsizei stride, GLintptr offset);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLint, GLenum, GLsizei, GLintptr, void> glVertexArrayMultiTexCoordOffsetEXT;
        /// <summary>void glVertexArrayNormalOffsetEXT(GLuint vaobj, GLuint buffer, GLenum type, GLsizei stride, GLintptr offset);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLsizei, GLintptr, void> glVertexArrayNormalOffsetEXT;
        /// <summary>void glVertexArrayParameteriAPPLE(GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, void> glVertexArrayParameteriAPPLE;
        /// <summary>void glVertexArrayRangeAPPLE(GLsizei length, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLsizei, IntPtr, void> glVertexArrayRangeAPPLE;
        /// <summary>void glVertexArrayRangeNV(GLsizei length, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLsizei, IntPtr, void> glVertexArrayRangeNV;
        /// <summary>void glVertexArraySecondaryColorOffsetEXT(GLuint vaobj, GLuint buffer, GLint size, GLenum type, GLsizei stride, GLintptr offset);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLint, GLenum, GLsizei, GLintptr, void> glVertexArraySecondaryColorOffsetEXT;
        /// <summary>void glVertexArrayTexCoordOffsetEXT(GLuint vaobj, GLuint buffer, GLint size, GLenum type, GLsizei stride, GLintptr offset);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLint, GLenum, GLsizei, GLintptr, void> glVertexArrayTexCoordOffsetEXT;
        /// <summary>void glVertexArrayVertexAttribBindingEXT(GLuint vaobj, GLuint attribindex, GLuint bindingindex);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, void> glVertexArrayVertexAttribBindingEXT;
        /// <summary>void glVertexArrayVertexAttribDivisorEXT(GLuint vaobj, GLuint index, GLuint divisor);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, void> glVertexArrayVertexAttribDivisorEXT;
        /// <summary>void glVertexArrayVertexAttribFormatEXT(GLuint vaobj, GLuint attribindex, GLint size, GLenum type, GLboolean normalized, GLuint relativeoffset);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLint, GLenum, GLboolean, GLuint, void> glVertexArrayVertexAttribFormatEXT;
        /// <summary>void glVertexArrayVertexAttribIFormatEXT(GLuint vaobj, GLuint attribindex, GLint size, GLenum type, GLuint relativeoffset);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLint, GLenum, GLuint, void> glVertexArrayVertexAttribIFormatEXT;
        /// <summary>void glVertexArrayVertexAttribIOffsetEXT(GLuint vaobj, GLuint buffer, GLuint index, GLint size, GLenum type, GLsizei stride, GLintptr offset);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, GLint, GLenum, GLsizei, GLintptr, void> glVertexArrayVertexAttribIOffsetEXT;
        /// <summary>void glVertexArrayVertexAttribLFormatEXT(GLuint vaobj, GLuint attribindex, GLint size, GLenum type, GLuint relativeoffset);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLint, GLenum, GLuint, void> glVertexArrayVertexAttribLFormatEXT;
        /// <summary>void glVertexArrayVertexAttribLOffsetEXT(GLuint vaobj, GLuint buffer, GLuint index, GLint size, GLenum type, GLsizei stride, GLintptr offset);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, GLint, GLenum, GLsizei, GLintptr, void> glVertexArrayVertexAttribLOffsetEXT;
        /// <summary>void glVertexArrayVertexAttribOffsetEXT(GLuint vaobj, GLuint buffer, GLuint index, GLint size, GLenum type, GLboolean normalized, GLsizei stride, GLintptr offset);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, GLint, GLenum, GLboolean, GLsizei, GLintptr, void> glVertexArrayVertexAttribOffsetEXT;
        /// <summary>void glVertexArrayVertexBindingDivisorEXT(GLuint vaobj, GLuint bindingindex, GLuint divisor);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, void> glVertexArrayVertexBindingDivisorEXT;
        /// <summary>void glVertexArrayVertexBuffer(GLuint vaobj, GLuint bindingindex, GLuint buffer, GLintptr offset, GLsizei stride);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, GLintptr, GLsizei, void> glVertexArrayVertexBuffer;
        /// <summary>void glVertexArrayVertexBuffers(GLuint vaobj, GLuint first, GLsizei count, GLuint[] buffers, GLintptr[] offsets, GLsizei[] strides);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLsizei, GLuint[], GLintptr[], GLsizei[], void> glVertexArrayVertexBuffers;
        /// <summary>void glVertexArrayVertexOffsetEXT(GLuint vaobj, GLuint buffer, GLint size, GLenum type, GLsizei stride, GLintptr offset);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLint, GLenum, GLsizei, GLintptr, void> glVertexArrayVertexOffsetEXT;
        /// <summary>void glVertexAttrib1d(GLuint index, GLdouble x);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble, void> glVertexAttrib1d;
        /// <summary>void glVertexAttrib1dARB(GLuint index, GLdouble x);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble, void> glVertexAttrib1dARB;
        /// <summary>void glVertexAttrib1dNV(GLuint index, GLdouble x);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble, void> glVertexAttrib1dNV;
        /// <summary>void glVertexAttrib1dv(GLuint index, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble[], void> glVertexAttrib1dv;
        /// <summary>void glVertexAttrib1dvARB(GLuint index, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble[], void> glVertexAttrib1dvARB;
        /// <summary>void glVertexAttrib1dvNV(GLuint index, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble[], void> glVertexAttrib1dvNV;
        /// <summary>void glVertexAttrib1f(GLuint index, GLfloat x);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat, void> glVertexAttrib1f;
        /// <summary>void glVertexAttrib1fARB(GLuint index, GLfloat x);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat, void> glVertexAttrib1fARB;
        /// <summary>void glVertexAttrib1fNV(GLuint index, GLfloat x);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat, void> glVertexAttrib1fNV;
        /// <summary>void glVertexAttrib1fv(GLuint index, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat[], void> glVertexAttrib1fv;
        /// <summary>void glVertexAttrib1fvARB(GLuint index, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat[], void> glVertexAttrib1fvARB;
        /// <summary>void glVertexAttrib1fvNV(GLuint index, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat[], void> glVertexAttrib1fvNV;
        /// <summary>void glVertexAttrib1hNV(GLuint index, GLhalfNV x);</summary>
        public readonly delegate* unmanaged<GLuint, GLhalfNV, void> glVertexAttrib1hNV;
        /// <summary>void glVertexAttrib1hvNV(GLuint index, GLhalfNV[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLhalfNV[], void> glVertexAttrib1hvNV;
        /// <summary>void glVertexAttrib1s(GLuint index, GLshort x);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort, void> glVertexAttrib1s;
        /// <summary>void glVertexAttrib1sARB(GLuint index, GLshort x);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort, void> glVertexAttrib1sARB;
        /// <summary>void glVertexAttrib1sNV(GLuint index, GLshort x);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort, void> glVertexAttrib1sNV;
        /// <summary>void glVertexAttrib1sv(GLuint index, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort[], void> glVertexAttrib1sv;
        /// <summary>void glVertexAttrib1svARB(GLuint index, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort[], void> glVertexAttrib1svARB;
        /// <summary>void glVertexAttrib1svNV(GLuint index, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort[], void> glVertexAttrib1svNV;
        /// <summary>void glVertexAttrib2d(GLuint index, GLdouble x, GLdouble y);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble, GLdouble, void> glVertexAttrib2d;
        /// <summary>void glVertexAttrib2dARB(GLuint index, GLdouble x, GLdouble y);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble, GLdouble, void> glVertexAttrib2dARB;
        /// <summary>void glVertexAttrib2dNV(GLuint index, GLdouble x, GLdouble y);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble, GLdouble, void> glVertexAttrib2dNV;
        /// <summary>void glVertexAttrib2dv(GLuint index, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble[], void> glVertexAttrib2dv;
        /// <summary>void glVertexAttrib2dvARB(GLuint index, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble[], void> glVertexAttrib2dvARB;
        /// <summary>void glVertexAttrib2dvNV(GLuint index, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble[], void> glVertexAttrib2dvNV;
        /// <summary>void glVertexAttrib2f(GLuint index, GLfloat x, GLfloat y);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat, GLfloat, void> glVertexAttrib2f;
        /// <summary>void glVertexAttrib2fARB(GLuint index, GLfloat x, GLfloat y);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat, GLfloat, void> glVertexAttrib2fARB;
        /// <summary>void glVertexAttrib2fNV(GLuint index, GLfloat x, GLfloat y);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat, GLfloat, void> glVertexAttrib2fNV;
        /// <summary>void glVertexAttrib2fv(GLuint index, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat[], void> glVertexAttrib2fv;
        /// <summary>void glVertexAttrib2fvARB(GLuint index, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat[], void> glVertexAttrib2fvARB;
        /// <summary>void glVertexAttrib2fvNV(GLuint index, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat[], void> glVertexAttrib2fvNV;
        /// <summary>void glVertexAttrib2hNV(GLuint index, GLhalfNV x, GLhalfNV y);</summary>
        public readonly delegate* unmanaged<GLuint, GLhalfNV, GLhalfNV, void> glVertexAttrib2hNV;
        /// <summary>void glVertexAttrib2hvNV(GLuint index, GLhalfNV[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLhalfNV[], void> glVertexAttrib2hvNV;
        /// <summary>void glVertexAttrib2s(GLuint index, GLshort x, GLshort y);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort, GLshort, void> glVertexAttrib2s;
        /// <summary>void glVertexAttrib2sARB(GLuint index, GLshort x, GLshort y);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort, GLshort, void> glVertexAttrib2sARB;
        /// <summary>void glVertexAttrib2sNV(GLuint index, GLshort x, GLshort y);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort, GLshort, void> glVertexAttrib2sNV;
        /// <summary>void glVertexAttrib2sv(GLuint index, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort[], void> glVertexAttrib2sv;
        /// <summary>void glVertexAttrib2svARB(GLuint index, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort[], void> glVertexAttrib2svARB;
        /// <summary>void glVertexAttrib2svNV(GLuint index, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort[], void> glVertexAttrib2svNV;
        /// <summary>void glVertexAttrib3d(GLuint index, GLdouble x, GLdouble y, GLdouble z);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble, GLdouble, GLdouble, void> glVertexAttrib3d;
        /// <summary>void glVertexAttrib3dARB(GLuint index, GLdouble x, GLdouble y, GLdouble z);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble, GLdouble, GLdouble, void> glVertexAttrib3dARB;
        /// <summary>void glVertexAttrib3dNV(GLuint index, GLdouble x, GLdouble y, GLdouble z);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble, GLdouble, GLdouble, void> glVertexAttrib3dNV;
        /// <summary>void glVertexAttrib3dv(GLuint index, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble[], void> glVertexAttrib3dv;
        /// <summary>void glVertexAttrib3dvARB(GLuint index, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble[], void> glVertexAttrib3dvARB;
        /// <summary>void glVertexAttrib3dvNV(GLuint index, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble[], void> glVertexAttrib3dvNV;
        /// <summary>void glVertexAttrib3f(GLuint index, GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, void> glVertexAttrib3f;
        /// <summary>void glVertexAttrib3fARB(GLuint index, GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, void> glVertexAttrib3fARB;
        /// <summary>void glVertexAttrib3fNV(GLuint index, GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, void> glVertexAttrib3fNV;
        /// <summary>void glVertexAttrib3fv(GLuint index, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat[], void> glVertexAttrib3fv;
        /// <summary>void glVertexAttrib3fvARB(GLuint index, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat[], void> glVertexAttrib3fvARB;
        /// <summary>void glVertexAttrib3fvNV(GLuint index, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat[], void> glVertexAttrib3fvNV;
        /// <summary>void glVertexAttrib3hNV(GLuint index, GLhalfNV x, GLhalfNV y, GLhalfNV z);</summary>
        public readonly delegate* unmanaged<GLuint, GLhalfNV, GLhalfNV, GLhalfNV, void> glVertexAttrib3hNV;
        /// <summary>void glVertexAttrib3hvNV(GLuint index, GLhalfNV[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLhalfNV[], void> glVertexAttrib3hvNV;
        /// <summary>void glVertexAttrib3s(GLuint index, GLshort x, GLshort y, GLshort z);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort, GLshort, GLshort, void> glVertexAttrib3s;
        /// <summary>void glVertexAttrib3sARB(GLuint index, GLshort x, GLshort y, GLshort z);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort, GLshort, GLshort, void> glVertexAttrib3sARB;
        /// <summary>void glVertexAttrib3sNV(GLuint index, GLshort x, GLshort y, GLshort z);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort, GLshort, GLshort, void> glVertexAttrib3sNV;
        /// <summary>void glVertexAttrib3sv(GLuint index, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort[], void> glVertexAttrib3sv;
        /// <summary>void glVertexAttrib3svARB(GLuint index, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort[], void> glVertexAttrib3svARB;
        /// <summary>void glVertexAttrib3svNV(GLuint index, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort[], void> glVertexAttrib3svNV;
        /// <summary>void glVertexAttrib4Nbv(GLuint index, GLbyte[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLbyte[], void> glVertexAttrib4Nbv;
        /// <summary>void glVertexAttrib4NbvARB(GLuint index, GLbyte[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLbyte[], void> glVertexAttrib4NbvARB;
        /// <summary>void glVertexAttrib4Niv(GLuint index, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLint[], void> glVertexAttrib4Niv;
        /// <summary>void glVertexAttrib4NivARB(GLuint index, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLint[], void> glVertexAttrib4NivARB;
        /// <summary>void glVertexAttrib4Nsv(GLuint index, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort[], void> glVertexAttrib4Nsv;
        /// <summary>void glVertexAttrib4NsvARB(GLuint index, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort[], void> glVertexAttrib4NsvARB;
        /// <summary>void glVertexAttrib4Nub(GLuint index, GLubyte x, GLubyte y, GLubyte z, GLubyte w);</summary>
        public readonly delegate* unmanaged<GLuint, GLubyte, GLubyte, GLubyte, GLubyte, void> glVertexAttrib4Nub;
        /// <summary>void glVertexAttrib4NubARB(GLuint index, GLubyte x, GLubyte y, GLubyte z, GLubyte w);</summary>
        public readonly delegate* unmanaged<GLuint, GLubyte, GLubyte, GLubyte, GLubyte, void> glVertexAttrib4NubARB;
        /// <summary>void glVertexAttrib4Nubv(GLuint index, GLubyte[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLubyte[], void> glVertexAttrib4Nubv;
        /// <summary>void glVertexAttrib4NubvARB(GLuint index, GLubyte[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLubyte[], void> glVertexAttrib4NubvARB;
        /// <summary>void glVertexAttrib4Nuiv(GLuint index, GLuint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint[], void> glVertexAttrib4Nuiv;
        /// <summary>void glVertexAttrib4NuivARB(GLuint index, GLuint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint[], void> glVertexAttrib4NuivARB;
        /// <summary>void glVertexAttrib4Nusv(GLuint index, GLushort[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLushort[], void> glVertexAttrib4Nusv;
        /// <summary>void glVertexAttrib4NusvARB(GLuint index, GLushort[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLushort[], void> glVertexAttrib4NusvARB;
        /// <summary>void glVertexAttrib4bv(GLuint index, GLbyte[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLbyte[], void> glVertexAttrib4bv;
        /// <summary>void glVertexAttrib4bvARB(GLuint index, GLbyte[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLbyte[], void> glVertexAttrib4bvARB;
        /// <summary>void glVertexAttrib4d(GLuint index, GLdouble x, GLdouble y, GLdouble z, GLdouble w);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble, GLdouble, GLdouble, GLdouble, void> glVertexAttrib4d;
        /// <summary>void glVertexAttrib4dARB(GLuint index, GLdouble x, GLdouble y, GLdouble z, GLdouble w);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble, GLdouble, GLdouble, GLdouble, void> glVertexAttrib4dARB;
        /// <summary>void glVertexAttrib4dNV(GLuint index, GLdouble x, GLdouble y, GLdouble z, GLdouble w);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble, GLdouble, GLdouble, GLdouble, void> glVertexAttrib4dNV;
        /// <summary>void glVertexAttrib4dv(GLuint index, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble[], void> glVertexAttrib4dv;
        /// <summary>void glVertexAttrib4dvARB(GLuint index, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble[], void> glVertexAttrib4dvARB;
        /// <summary>void glVertexAttrib4dvNV(GLuint index, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble[], void> glVertexAttrib4dvNV;
        /// <summary>void glVertexAttrib4f(GLuint index, GLfloat x, GLfloat y, GLfloat z, GLfloat w);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, GLfloat, void> glVertexAttrib4f;
        /// <summary>void glVertexAttrib4fARB(GLuint index, GLfloat x, GLfloat y, GLfloat z, GLfloat w);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, GLfloat, void> glVertexAttrib4fARB;
        /// <summary>void glVertexAttrib4fNV(GLuint index, GLfloat x, GLfloat y, GLfloat z, GLfloat w);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, GLfloat, void> glVertexAttrib4fNV;
        /// <summary>void glVertexAttrib4fv(GLuint index, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat*, void> glVertexAttrib4fv;
        /// <summary>void glVertexAttrib4fvARB(GLuint index, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat[], void> glVertexAttrib4fvARB;
        /// <summary>void glVertexAttrib4fvNV(GLuint index, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat[], void> glVertexAttrib4fvNV;
        /// <summary>void glVertexAttrib4hNV(GLuint index, GLhalfNV x, GLhalfNV y, GLhalfNV z, GLhalfNV w);</summary>
        public readonly delegate* unmanaged<GLuint, GLhalfNV, GLhalfNV, GLhalfNV, GLhalfNV, void> glVertexAttrib4hNV;
        /// <summary>void glVertexAttrib4hvNV(GLuint index, GLhalfNV[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLhalfNV[], void> glVertexAttrib4hvNV;
        /// <summary>void glVertexAttrib4iv(GLuint index, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLint[], void> glVertexAttrib4iv;
        /// <summary>void glVertexAttrib4ivARB(GLuint index, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLint[], void> glVertexAttrib4ivARB;
        /// <summary>void glVertexAttrib4s(GLuint index, GLshort x, GLshort y, GLshort z, GLshort w);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort, GLshort, GLshort, GLshort, void> glVertexAttrib4s;
        /// <summary>void glVertexAttrib4sARB(GLuint index, GLshort x, GLshort y, GLshort z, GLshort w);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort, GLshort, GLshort, GLshort, void> glVertexAttrib4sARB;
        /// <summary>void glVertexAttrib4sNV(GLuint index, GLshort x, GLshort y, GLshort z, GLshort w);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort, GLshort, GLshort, GLshort, void> glVertexAttrib4sNV;
        /// <summary>void glVertexAttrib4sv(GLuint index, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort[], void> glVertexAttrib4sv;
        /// <summary>void glVertexAttrib4svARB(GLuint index, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort[], void> glVertexAttrib4svARB;
        /// <summary>void glVertexAttrib4svNV(GLuint index, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort[], void> glVertexAttrib4svNV;
        /// <summary>void glVertexAttrib4ubNV(GLuint index, GLubyte x, GLubyte y, GLubyte z, GLubyte w);</summary>
        public readonly delegate* unmanaged<GLuint, GLubyte, GLubyte, GLubyte, GLubyte, void> glVertexAttrib4ubNV;
        /// <summary>void glVertexAttrib4ubv(GLuint index, GLubyte[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLubyte[], void> glVertexAttrib4ubv;
        /// <summary>void glVertexAttrib4ubvARB(GLuint index, GLubyte[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLubyte[], void> glVertexAttrib4ubvARB;
        /// <summary>void glVertexAttrib4ubvNV(GLuint index, GLubyte[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLubyte[], void> glVertexAttrib4ubvNV;
        /// <summary>void glVertexAttrib4uiv(GLuint index, GLuint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint[], void> glVertexAttrib4uiv;
        /// <summary>void glVertexAttrib4uivARB(GLuint index, GLuint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint[], void> glVertexAttrib4uivARB;
        /// <summary>void glVertexAttrib4usv(GLuint index, GLushort[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLushort[], void> glVertexAttrib4usv;
        /// <summary>void glVertexAttrib4usvARB(GLuint index, GLushort[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLushort[], void> glVertexAttrib4usvARB;
        /// <summary>void glVertexAttribArrayObjectATI(GLuint index, GLint size, GLenum type, GLboolean normalized, GLsizei stride, GLuint buffer, GLuint offset);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLenum, GLboolean, GLsizei, GLuint, GLuint, void> glVertexAttribArrayObjectATI;
        /// <summary>void glVertexAttribBinding(GLuint attribindex, GLuint bindingindex);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, void> glVertexAttribBinding;
        /// <summary>void glVertexAttribDivisor(GLuint index, GLuint divisor);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, void> glVertexAttribDivisor;
        /// <summary>void glVertexAttribDivisorANGLE(GLuint index, GLuint divisor);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, void> glVertexAttribDivisorANGLE;
        /// <summary>void glVertexAttribDivisorARB(GLuint index, GLuint divisor);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, void> glVertexAttribDivisorARB;
        /// <summary>void glVertexAttribDivisorEXT(GLuint index, GLuint divisor);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, void> glVertexAttribDivisorEXT;
        /// <summary>void glVertexAttribDivisorNV(GLuint index, GLuint divisor);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, void> glVertexAttribDivisorNV;
        /// <summary>void glVertexAttribFormat(GLuint attribindex, GLint size, GLenum type, GLboolean normalized, GLuint relativeoffset);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLenum, GLboolean, GLuint, void> glVertexAttribFormat;
        /// <summary>void glVertexAttribFormatNV(GLuint index, GLint size, GLenum type, GLboolean normalized, GLsizei stride);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLenum, GLboolean, GLsizei, void> glVertexAttribFormatNV;
        /// <summary>void glVertexAttribI1i(GLuint index, GLint x);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, void> glVertexAttribI1i;
        /// <summary>void glVertexAttribI1iEXT(GLuint index, GLint x);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, void> glVertexAttribI1iEXT;
        /// <summary>void glVertexAttribI1iv(GLuint index, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLint[], void> glVertexAttribI1iv;
        /// <summary>void glVertexAttribI1ivEXT(GLuint index, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLint[], void> glVertexAttribI1ivEXT;
        /// <summary>void glVertexAttribI1ui(GLuint index, GLuint x);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, void> glVertexAttribI1ui;
        /// <summary>void glVertexAttribI1uiEXT(GLuint index, GLuint x);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, void> glVertexAttribI1uiEXT;
        /// <summary>void glVertexAttribI1uiv(GLuint index, GLuint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint[], void> glVertexAttribI1uiv;
        /// <summary>void glVertexAttribI1uivEXT(GLuint index, GLuint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint[], void> glVertexAttribI1uivEXT;
        /// <summary>void glVertexAttribI2i(GLuint index, GLint x, GLint y);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, void> glVertexAttribI2i;
        /// <summary>void glVertexAttribI2iEXT(GLuint index, GLint x, GLint y);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, void> glVertexAttribI2iEXT;
        /// <summary>void glVertexAttribI2iv(GLuint index, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLint[], void> glVertexAttribI2iv;
        /// <summary>void glVertexAttribI2ivEXT(GLuint index, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLint[], void> glVertexAttribI2ivEXT;
        /// <summary>void glVertexAttribI2ui(GLuint index, GLuint x, GLuint y);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, void> glVertexAttribI2ui;
        /// <summary>void glVertexAttribI2uiEXT(GLuint index, GLuint x, GLuint y);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, void> glVertexAttribI2uiEXT;
        /// <summary>void glVertexAttribI2uiv(GLuint index, GLuint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint[], void> glVertexAttribI2uiv;
        /// <summary>void glVertexAttribI2uivEXT(GLuint index, GLuint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint[], void> glVertexAttribI2uivEXT;
        /// <summary>void glVertexAttribI3i(GLuint index, GLint x, GLint y, GLint z);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLint, void> glVertexAttribI3i;
        /// <summary>void glVertexAttribI3iEXT(GLuint index, GLint x, GLint y, GLint z);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLint, void> glVertexAttribI3iEXT;
        /// <summary>void glVertexAttribI3iv(GLuint index, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLint[], void> glVertexAttribI3iv;
        /// <summary>void glVertexAttribI3ivEXT(GLuint index, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLint[], void> glVertexAttribI3ivEXT;
        /// <summary>void glVertexAttribI3ui(GLuint index, GLuint x, GLuint y, GLuint z);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, GLuint, void> glVertexAttribI3ui;
        /// <summary>void glVertexAttribI3uiEXT(GLuint index, GLuint x, GLuint y, GLuint z);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, GLuint, void> glVertexAttribI3uiEXT;
        /// <summary>void glVertexAttribI3uiv(GLuint index, GLuint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint[], void> glVertexAttribI3uiv;
        /// <summary>void glVertexAttribI3uivEXT(GLuint index, GLuint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint[], void> glVertexAttribI3uivEXT;
        /// <summary>void glVertexAttribI4bv(GLuint index, GLbyte[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLbyte[], void> glVertexAttribI4bv;
        /// <summary>void glVertexAttribI4bvEXT(GLuint index, GLbyte[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLbyte[], void> glVertexAttribI4bvEXT;
        /// <summary>void glVertexAttribI4i(GLuint index, GLint x, GLint y, GLint z, GLint w);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, void> glVertexAttribI4i;
        /// <summary>void glVertexAttribI4iEXT(GLuint index, GLint x, GLint y, GLint z, GLint w);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, void> glVertexAttribI4iEXT;
        /// <summary>void glVertexAttribI4iv(GLuint index, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLint[], void> glVertexAttribI4iv;
        /// <summary>void glVertexAttribI4ivEXT(GLuint index, GLint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLint[], void> glVertexAttribI4ivEXT;
        /// <summary>void glVertexAttribI4sv(GLuint index, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort[], void> glVertexAttribI4sv;
        /// <summary>void glVertexAttribI4svEXT(GLuint index, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLshort[], void> glVertexAttribI4svEXT;
        /// <summary>void glVertexAttribI4ubv(GLuint index, GLubyte[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLubyte[], void> glVertexAttribI4ubv;
        /// <summary>void glVertexAttribI4ubvEXT(GLuint index, GLubyte[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLubyte[], void> glVertexAttribI4ubvEXT;
        /// <summary>void glVertexAttribI4ui(GLuint index, GLuint x, GLuint y, GLuint z, GLuint w);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, GLuint, GLuint, void> glVertexAttribI4ui;
        /// <summary>void glVertexAttribI4uiEXT(GLuint index, GLuint x, GLuint y, GLuint z, GLuint w);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint, GLuint, GLuint, void> glVertexAttribI4uiEXT;
        /// <summary>void glVertexAttribI4uiv(GLuint index, GLuint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint[], void> glVertexAttribI4uiv;
        /// <summary>void glVertexAttribI4uivEXT(GLuint index, GLuint[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint[], void> glVertexAttribI4uivEXT;
        /// <summary>void glVertexAttribI4usv(GLuint index, GLushort[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLushort[], void> glVertexAttribI4usv;
        /// <summary>void glVertexAttribI4usvEXT(GLuint index, GLushort[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLushort[], void> glVertexAttribI4usvEXT;
        /// <summary>void glVertexAttribIFormat(GLuint attribindex, GLint size, GLenum type, GLuint relativeoffset);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLenum, GLuint, void> glVertexAttribIFormat;
        /// <summary>void glVertexAttribIFormatNV(GLuint index, GLint size, GLenum type, GLsizei stride);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLenum, GLsizei, void> glVertexAttribIFormatNV;
        /// <summary>void glVertexAttribIPointer(GLuint index, GLint size, GLenum type, GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLenum, GLsizei, IntPtr, void> glVertexAttribIPointer;
        /// <summary>void glVertexAttribIPointerEXT(GLuint index, GLint size, GLenum type, GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLenum, GLsizei, IntPtr, void> glVertexAttribIPointerEXT;
        /// <summary>void glVertexAttribL1d(GLuint index, GLdouble x);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble, void> glVertexAttribL1d;
        /// <summary>void glVertexAttribL1dEXT(GLuint index, GLdouble x);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble, void> glVertexAttribL1dEXT;
        /// <summary>void glVertexAttribL1dv(GLuint index, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble[], void> glVertexAttribL1dv;
        /// <summary>void glVertexAttribL1dvEXT(GLuint index, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble[], void> glVertexAttribL1dvEXT;
        /// <summary>void glVertexAttribL1i64NV(GLuint index, GLint64EXT x);</summary>
        public readonly delegate* unmanaged<GLuint, GLint64EXT, void> glVertexAttribL1i64NV;
        /// <summary>void glVertexAttribL1i64vNV(GLuint index, GLint64EXT[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLint64EXT[], void> glVertexAttribL1i64vNV;
        /// <summary>void glVertexAttribL1ui64ARB(GLuint index, GLuint64EXT x);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint64EXT, void> glVertexAttribL1ui64ARB;
        /// <summary>void glVertexAttribL1ui64NV(GLuint index, GLuint64EXT x);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint64EXT, void> glVertexAttribL1ui64NV;
        /// <summary>void glVertexAttribL1ui64vARB(GLuint index, GLuint64EXT[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint64EXT[], void> glVertexAttribL1ui64vARB;
        /// <summary>void glVertexAttribL1ui64vNV(GLuint index, GLuint64EXT[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint64EXT[], void> glVertexAttribL1ui64vNV;
        /// <summary>void glVertexAttribL2d(GLuint index, GLdouble x, GLdouble y);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble, GLdouble, void> glVertexAttribL2d;
        /// <summary>void glVertexAttribL2dEXT(GLuint index, GLdouble x, GLdouble y);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble, GLdouble, void> glVertexAttribL2dEXT;
        /// <summary>void glVertexAttribL2dv(GLuint index, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble[], void> glVertexAttribL2dv;
        /// <summary>void glVertexAttribL2dvEXT(GLuint index, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble[], void> glVertexAttribL2dvEXT;
        /// <summary>void glVertexAttribL2i64NV(GLuint index, GLint64EXT x, GLint64EXT y);</summary>
        public readonly delegate* unmanaged<GLuint, GLint64EXT, GLint64EXT, void> glVertexAttribL2i64NV;
        /// <summary>void glVertexAttribL2i64vNV(GLuint index, GLint64EXT[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLint64EXT[], void> glVertexAttribL2i64vNV;
        /// <summary>void glVertexAttribL2ui64NV(GLuint index, GLuint64EXT x, GLuint64EXT y);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint64EXT, GLuint64EXT, void> glVertexAttribL2ui64NV;
        /// <summary>void glVertexAttribL2ui64vNV(GLuint index, GLuint64EXT[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint64EXT[], void> glVertexAttribL2ui64vNV;
        /// <summary>void glVertexAttribL3d(GLuint index, GLdouble x, GLdouble y, GLdouble z);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble, GLdouble, GLdouble, void> glVertexAttribL3d;
        /// <summary>void glVertexAttribL3dEXT(GLuint index, GLdouble x, GLdouble y, GLdouble z);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble, GLdouble, GLdouble, void> glVertexAttribL3dEXT;
        /// <summary>void glVertexAttribL3dv(GLuint index, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble[], void> glVertexAttribL3dv;
        /// <summary>void glVertexAttribL3dvEXT(GLuint index, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble[], void> glVertexAttribL3dvEXT;
        /// <summary>void glVertexAttribL3i64NV(GLuint index, GLint64EXT x, GLint64EXT y, GLint64EXT z);</summary>
        public readonly delegate* unmanaged<GLuint, GLint64EXT, GLint64EXT, GLint64EXT, void> glVertexAttribL3i64NV;
        /// <summary>void glVertexAttribL3i64vNV(GLuint index, GLint64EXT[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLint64EXT[], void> glVertexAttribL3i64vNV;
        /// <summary>void glVertexAttribL3ui64NV(GLuint index, GLuint64EXT x, GLuint64EXT y, GLuint64EXT z);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint64EXT, GLuint64EXT, GLuint64EXT, void> glVertexAttribL3ui64NV;
        /// <summary>void glVertexAttribL3ui64vNV(GLuint index, GLuint64EXT[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint64EXT[], void> glVertexAttribL3ui64vNV;
        /// <summary>void glVertexAttribL4d(GLuint index, GLdouble x, GLdouble y, GLdouble z, GLdouble w);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble, GLdouble, GLdouble, GLdouble, void> glVertexAttribL4d;
        /// <summary>void glVertexAttribL4dEXT(GLuint index, GLdouble x, GLdouble y, GLdouble z, GLdouble w);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble, GLdouble, GLdouble, GLdouble, void> glVertexAttribL4dEXT;
        /// <summary>void glVertexAttribL4dv(GLuint index, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble[], void> glVertexAttribL4dv;
        /// <summary>void glVertexAttribL4dvEXT(GLuint index, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLdouble[], void> glVertexAttribL4dvEXT;
        /// <summary>void glVertexAttribL4i64NV(GLuint index, GLint64EXT x, GLint64EXT y, GLint64EXT z, GLint64EXT w);</summary>
        public readonly delegate* unmanaged<GLuint, GLint64EXT, GLint64EXT, GLint64EXT, GLint64EXT, void> glVertexAttribL4i64NV;
        /// <summary>void glVertexAttribL4i64vNV(GLuint index, GLint64EXT[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLint64EXT[], void> glVertexAttribL4i64vNV;
        /// <summary>void glVertexAttribL4ui64NV(GLuint index, GLuint64EXT x, GLuint64EXT y, GLuint64EXT z, GLuint64EXT w);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint64EXT, GLuint64EXT, GLuint64EXT, GLuint64EXT, void> glVertexAttribL4ui64NV;
        /// <summary>void glVertexAttribL4ui64vNV(GLuint index, GLuint64EXT[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint64EXT[], void> glVertexAttribL4ui64vNV;
        /// <summary>void glVertexAttribLFormat(GLuint attribindex, GLint size, GLenum type, GLuint relativeoffset);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLenum, GLuint, void> glVertexAttribLFormat;
        /// <summary>void glVertexAttribLFormatNV(GLuint index, GLint size, GLenum type, GLsizei stride);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLenum, GLsizei, void> glVertexAttribLFormatNV;
        /// <summary>void glVertexAttribLPointer(GLuint index, GLint size, GLenum type, GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLenum, GLsizei, IntPtr, void> glVertexAttribLPointer;
        /// <summary>void glVertexAttribLPointerEXT(GLuint index, GLint size, GLenum type, GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLenum, GLsizei, IntPtr, void> glVertexAttribLPointerEXT;
        /// <summary>void glVertexAttribP1ui(GLuint index, GLenum type, GLboolean normalized, GLuint value);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLboolean, GLuint, void> glVertexAttribP1ui;
        /// <summary>void glVertexAttribP1uiv(GLuint index, GLenum type, GLboolean normalized, GLuint[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLboolean, GLuint[], void> glVertexAttribP1uiv;
        /// <summary>void glVertexAttribP2ui(GLuint index, GLenum type, GLboolean normalized, GLuint value);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLboolean, GLuint, void> glVertexAttribP2ui;
        /// <summary>void glVertexAttribP2uiv(GLuint index, GLenum type, GLboolean normalized, GLuint[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLboolean, GLuint[], void> glVertexAttribP2uiv;
        /// <summary>void glVertexAttribP3ui(GLuint index, GLenum type, GLboolean normalized, GLuint value);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLboolean, GLuint, void> glVertexAttribP3ui;
        /// <summary>void glVertexAttribP3uiv(GLuint index, GLenum type, GLboolean normalized, GLuint[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLboolean, GLuint[], void> glVertexAttribP3uiv;
        /// <summary>void glVertexAttribP4ui(GLuint index, GLenum type, GLboolean normalized, GLuint value);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLboolean, GLuint, void> glVertexAttribP4ui;
        /// <summary>void glVertexAttribP4uiv(GLuint index, GLenum type, GLboolean normalized, GLuint[] value);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLboolean, GLuint[], void> glVertexAttribP4uiv;
        /// <summary>void glVertexAttribParameteriAMD(GLuint index, GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLint, void> glVertexAttribParameteriAMD;
        /// <summary>void glVertexAttribPointer(GLuint index, GLint size, GLenum type, GLboolean normalized, GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLenum, GLboolean, GLsizei, IntPtr, void> glVertexAttribPointer;
        /// <summary>void glVertexAttribPointerARB(GLuint index, GLint size, GLenum type, GLboolean normalized, GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLenum, GLboolean, GLsizei, IntPtr, void> glVertexAttribPointerARB;
        /// <summary>void glVertexAttribPointerNV(GLuint index, GLint fsize, GLenum type, GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLuint, GLint, GLenum, GLsizei, IntPtr, void> glVertexAttribPointerNV;
        /// <summary>void glVertexAttribs1dvNV(GLuint index, GLsizei count, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLdouble[], void> glVertexAttribs1dvNV;
        /// <summary>void glVertexAttribs1fvNV(GLuint index, GLsizei count, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLfloat[], void> glVertexAttribs1fvNV;
        /// <summary>void glVertexAttribs1hvNV(GLuint index, GLsizei n, GLhalfNV[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLhalfNV[], void> glVertexAttribs1hvNV;
        /// <summary>void glVertexAttribs1svNV(GLuint index, GLsizei count, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLshort[], void> glVertexAttribs1svNV;
        /// <summary>void glVertexAttribs2dvNV(GLuint index, GLsizei count, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLdouble[], void> glVertexAttribs2dvNV;
        /// <summary>void glVertexAttribs2fvNV(GLuint index, GLsizei count, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLfloat[], void> glVertexAttribs2fvNV;
        /// <summary>void glVertexAttribs2hvNV(GLuint index, GLsizei n, GLhalfNV[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLhalfNV[], void> glVertexAttribs2hvNV;
        /// <summary>void glVertexAttribs2svNV(GLuint index, GLsizei count, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLshort[], void> glVertexAttribs2svNV;
        /// <summary>void glVertexAttribs3dvNV(GLuint index, GLsizei count, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLdouble[], void> glVertexAttribs3dvNV;
        /// <summary>void glVertexAttribs3fvNV(GLuint index, GLsizei count, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLfloat[], void> glVertexAttribs3fvNV;
        /// <summary>void glVertexAttribs3hvNV(GLuint index, GLsizei n, GLhalfNV[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLhalfNV[], void> glVertexAttribs3hvNV;
        /// <summary>void glVertexAttribs3svNV(GLuint index, GLsizei count, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLshort[], void> glVertexAttribs3svNV;
        /// <summary>void glVertexAttribs4dvNV(GLuint index, GLsizei count, GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLdouble[], void> glVertexAttribs4dvNV;
        /// <summary>void glVertexAttribs4fvNV(GLuint index, GLsizei count, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLfloat[], void> glVertexAttribs4fvNV;
        /// <summary>void glVertexAttribs4hvNV(GLuint index, GLsizei n, GLhalfNV[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLhalfNV[], void> glVertexAttribs4hvNV;
        /// <summary>void glVertexAttribs4svNV(GLuint index, GLsizei count, GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLshort[], void> glVertexAttribs4svNV;
        /// <summary>void glVertexAttribs4ubvNV(GLuint index, GLsizei count, GLubyte[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLubyte[], void> glVertexAttribs4ubvNV;
        /// <summary>void glVertexBindingDivisor(GLuint bindingindex, GLuint divisor);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, void> glVertexBindingDivisor;
        /// <summary>void glVertexBlendARB(GLint count);</summary>
        public readonly delegate* unmanaged<GLint, void> glVertexBlendARB;
        /// <summary>void glVertexBlendEnvfATI(GLenum pname, GLfloat param);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, void> glVertexBlendEnvfATI;
        /// <summary>void glVertexBlendEnviATI(GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, void> glVertexBlendEnviATI;
        /// <summary>void glVertexFormatNV(GLint size, GLenum type, GLsizei stride);</summary>
        public readonly delegate* unmanaged<GLint, GLenum, GLsizei, void> glVertexFormatNV;
        /// <summary>void glVertexP2ui(GLenum type, GLuint value);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glVertexP2ui;
        /// <summary>void glVertexP2uiv(GLenum type, GLuint[] value);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint[], void> glVertexP2uiv;
        /// <summary>void glVertexP3ui(GLenum type, GLuint value);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glVertexP3ui;
        /// <summary>void glVertexP3uiv(GLenum type, GLuint[] value);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint[], void> glVertexP3uiv;
        /// <summary>void glVertexP4ui(GLenum type, GLuint value);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint, void> glVertexP4ui;
        /// <summary>void glVertexP4uiv(GLenum type, GLuint[] value);</summary>
        public readonly delegate* unmanaged<GLenum, GLuint[], void> glVertexP4uiv;
        /// <summary>void glVertexPointer(GLint size, GLenum type, GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLint, GLenum, GLsizei, IntPtr, void> glVertexPointer;
        /// <summary>void glVertexPointerEXT(GLint size, GLenum type, GLsizei stride, GLsizei count, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLint, GLenum, GLsizei, GLsizei, IntPtr, void> glVertexPointerEXT;
        /// <summary>void glVertexPointerListIBM(GLint size, GLenum type, GLint stride, IntPtr pointer, GLint ptrstride);</summary>
        public readonly delegate* unmanaged<GLint, GLenum, GLint, IntPtr, GLint, void> glVertexPointerListIBM;
        /// <summary>void glVertexPointervINTEL(GLint size, GLenum type, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLint, GLenum, IntPtr, void> glVertexPointervINTEL;
        /// <summary>void glVertexStream1dATI(GLenum stream, GLdouble x);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble, void> glVertexStream1dATI;
        /// <summary>void glVertexStream1dvATI(GLenum stream, GLdouble[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble[], void> glVertexStream1dvATI;
        /// <summary>void glVertexStream1fATI(GLenum stream, GLfloat x);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, void> glVertexStream1fATI;
        /// <summary>void glVertexStream1fvATI(GLenum stream, GLfloat[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glVertexStream1fvATI;
        /// <summary>void glVertexStream1iATI(GLenum stream, GLint x);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, void> glVertexStream1iATI;
        /// <summary>void glVertexStream1ivATI(GLenum stream, GLint[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLint[], void> glVertexStream1ivATI;
        /// <summary>void glVertexStream1sATI(GLenum stream, GLshort x);</summary>
        public readonly delegate* unmanaged<GLenum, GLshort, void> glVertexStream1sATI;
        /// <summary>void glVertexStream1svATI(GLenum stream, GLshort[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLshort[], void> glVertexStream1svATI;
        /// <summary>void glVertexStream2dATI(GLenum stream, GLdouble x, GLdouble y);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble, GLdouble, void> glVertexStream2dATI;
        /// <summary>void glVertexStream2dvATI(GLenum stream, GLdouble[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble[], void> glVertexStream2dvATI;
        /// <summary>void glVertexStream2fATI(GLenum stream, GLfloat x, GLfloat y);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, GLfloat, void> glVertexStream2fATI;
        /// <summary>void glVertexStream2fvATI(GLenum stream, GLfloat[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glVertexStream2fvATI;
        /// <summary>void glVertexStream2iATI(GLenum stream, GLint x, GLint y);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, void> glVertexStream2iATI;
        /// <summary>void glVertexStream2ivATI(GLenum stream, GLint[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLint[], void> glVertexStream2ivATI;
        /// <summary>void glVertexStream2sATI(GLenum stream, GLshort x, GLshort y);</summary>
        public readonly delegate* unmanaged<GLenum, GLshort, GLshort, void> glVertexStream2sATI;
        /// <summary>void glVertexStream2svATI(GLenum stream, GLshort[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLshort[], void> glVertexStream2svATI;
        /// <summary>void glVertexStream3dATI(GLenum stream, GLdouble x, GLdouble y, GLdouble z);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble, GLdouble, GLdouble, void> glVertexStream3dATI;
        /// <summary>void glVertexStream3dvATI(GLenum stream, GLdouble[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble[], void> glVertexStream3dvATI;
        /// <summary>void glVertexStream3fATI(GLenum stream, GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, GLfloat, GLfloat, void> glVertexStream3fATI;
        /// <summary>void glVertexStream3fvATI(GLenum stream, GLfloat[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glVertexStream3fvATI;
        /// <summary>void glVertexStream3iATI(GLenum stream, GLint x, GLint y, GLint z);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, void> glVertexStream3iATI;
        /// <summary>void glVertexStream3ivATI(GLenum stream, GLint[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLint[], void> glVertexStream3ivATI;
        /// <summary>void glVertexStream3sATI(GLenum stream, GLshort x, GLshort y, GLshort z);</summary>
        public readonly delegate* unmanaged<GLenum, GLshort, GLshort, GLshort, void> glVertexStream3sATI;
        /// <summary>void glVertexStream3svATI(GLenum stream, GLshort[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLshort[], void> glVertexStream3svATI;
        /// <summary>void glVertexStream4dATI(GLenum stream, GLdouble x, GLdouble y, GLdouble z, GLdouble w);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble, GLdouble, GLdouble, GLdouble, void> glVertexStream4dATI;
        /// <summary>void glVertexStream4dvATI(GLenum stream, GLdouble[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLdouble[], void> glVertexStream4dvATI;
        /// <summary>void glVertexStream4fATI(GLenum stream, GLfloat x, GLfloat y, GLfloat z, GLfloat w);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat, GLfloat, GLfloat, GLfloat, void> glVertexStream4fATI;
        /// <summary>void glVertexStream4fvATI(GLenum stream, GLfloat[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLfloat[], void> glVertexStream4fvATI;
        /// <summary>void glVertexStream4iATI(GLenum stream, GLint x, GLint y, GLint z, GLint w);</summary>
        public readonly delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, void> glVertexStream4iATI;
        /// <summary>void glVertexStream4ivATI(GLenum stream, GLint[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLint[], void> glVertexStream4ivATI;
        /// <summary>void glVertexStream4sATI(GLenum stream, GLshort x, GLshort y, GLshort z, GLshort w);</summary>
        public readonly delegate* unmanaged<GLenum, GLshort, GLshort, GLshort, GLshort, void> glVertexStream4sATI;
        /// <summary>void glVertexStream4svATI(GLenum stream, GLshort[] coords);</summary>
        public readonly delegate* unmanaged<GLenum, GLshort[], void> glVertexStream4svATI;
        /// <summary>void glVertexWeightPointerEXT(GLint size, GLenum type, GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLint, GLenum, GLsizei, IntPtr, void> glVertexWeightPointerEXT;
        /// <summary>void glVertexWeightfEXT(GLfloat weight);</summary>
        public readonly delegate* unmanaged<GLfloat, void> glVertexWeightfEXT;
        /// <summary>void glVertexWeightfvEXT(GLfloat[] weight);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glVertexWeightfvEXT;
        /// <summary>void glVertexWeighthNV(GLhalfNV weight);</summary>
        public readonly delegate* unmanaged<GLhalfNV, void> glVertexWeighthNV;
        /// <summary>void glVertexWeighthvNV(GLhalfNV[] weight);</summary>
        public readonly delegate* unmanaged<GLhalfNV[], void> glVertexWeighthvNV;
        /// <summary>GLenum glVideoCaptureNV(GLuint video_capture_slot, GLuint[] sequence_num, GLuint64EXT[] capture_time);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint[], GLuint64EXT[], GLenum> glVideoCaptureNV;
        /// <summary>void glVideoCaptureStreamParameterdvNV(GLuint video_capture_slot, GLuint stream, GLenum pname, GLdouble[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLdouble[], void> glVideoCaptureStreamParameterdvNV;
        /// <summary>void glVideoCaptureStreamParameterfvNV(GLuint video_capture_slot, GLuint stream, GLenum pname, GLfloat[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLfloat[], void> glVideoCaptureStreamParameterfvNV;
        /// <summary>void glVideoCaptureStreamParameterivNV(GLuint video_capture_slot, GLuint stream, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLint[], void> glVideoCaptureStreamParameterivNV;
        /// <summary>void glViewport(GLint x, GLint y, GLsizei width, GLsizei height);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLsizei, GLsizei, void> glViewport;
        /// <summary>void glViewportArrayv(GLuint first, GLsizei count, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLfloat[], void> glViewportArrayv;
        /// <summary>void glViewportArrayvNV(GLuint first, GLsizei count, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLfloat[], void> glViewportArrayvNV;
        /// <summary>void glViewportArrayvOES(GLuint first, GLsizei count, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLfloat[], void> glViewportArrayvOES;
        /// <summary>void glViewportIndexedf(GLuint index, GLfloat x, GLfloat y, GLfloat w, GLfloat h);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, GLfloat, void> glViewportIndexedf;
        /// <summary>void glViewportIndexedfOES(GLuint index, GLfloat x, GLfloat y, GLfloat w, GLfloat h);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, GLfloat, void> glViewportIndexedfOES;
        /// <summary>void glViewportIndexedfNV(GLuint index, GLfloat x, GLfloat y, GLfloat w, GLfloat h);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, GLfloat, void> glViewportIndexedfNV;
        /// <summary>void glViewportIndexedfv(GLuint index, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat[], void> glViewportIndexedfv;
        /// <summary>void glViewportIndexedfvOES(GLuint index, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat[], void> glViewportIndexedfvOES;
        /// <summary>void glViewportIndexedfvNV(GLuint index, GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat[], void> glViewportIndexedfvNV;
        /// <summary>void glViewportPositionWScaleNV(GLuint index, GLfloat xcoeff, GLfloat ycoeff);</summary>
        public readonly delegate* unmanaged<GLuint, GLfloat, GLfloat, void> glViewportPositionWScaleNV;
        /// <summary>void glViewportSwizzleNV(GLuint index, GLenum swizzlex, GLenum swizzley, GLenum swizzlez, GLenum swizzlew);</summary>
        public readonly delegate* unmanaged<GLuint, GLenum, GLenum, GLenum, GLenum, void> glViewportSwizzleNV;
        /// <summary>void glWaitSemaphoreEXT(GLuint semaphore, GLuint numBufferBarriers, GLuint[] buffers, GLuint numTextureBarriers, GLuint[] textures, GLenum[] srcLayouts);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLuint[], GLuint, GLuint[], GLenum[], void> glWaitSemaphoreEXT;
        /// <summary>void glWaitSemaphoreui64NVX(GLuint waitGpu, GLsizei fenceObjectCount, GLuint[] semaphoreArray, GLuint64[] fenceValueArray);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLuint[], GLuint64[], void> glWaitSemaphoreui64NVX;
        /// <summary>void glWaitSync(GLsync sync, GLbitfield flags, GLuint64 timeout);</summary>
        public readonly delegate* unmanaged<GLsync, GLbitfield, GLuint64, void> glWaitSync;
        /// <summary>void glWaitSyncAPPLE(GLsync sync, GLbitfield flags, GLuint64 timeout);</summary>
        public readonly delegate* unmanaged<GLsync, GLbitfield, GLuint64, void> glWaitSyncAPPLE;
        /// <summary>void glWeightPathsNV(GLuint resultPath, GLsizei numPaths, GLuint[] paths, GLfloat[] weights);</summary>
        public readonly delegate* unmanaged<GLuint, GLsizei, GLuint[], GLfloat[], void> glWeightPathsNV;
        /// <summary>void glWeightPointerARB(GLint size, GLenum type, GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLint, GLenum, GLsizei, IntPtr, void> glWeightPointerARB;
        /// <summary>void glWeightPointerOES(GLint size, GLenum type, GLsizei stride, IntPtr pointer);</summary>
        public readonly delegate* unmanaged<GLint, GLenum, GLsizei, IntPtr, void> glWeightPointerOES;
        /// <summary>void glWeightbvARB(GLint size, GLbyte[] weights);</summary>
        public readonly delegate* unmanaged<GLint, GLbyte[], void> glWeightbvARB;
        /// <summary>void glWeightdvARB(GLint size, GLdouble[] weights);</summary>
        public readonly delegate* unmanaged<GLint, GLdouble[], void> glWeightdvARB;
        /// <summary>void glWeightfvARB(GLint size, GLfloat[] weights);</summary>
        public readonly delegate* unmanaged<GLint, GLfloat[], void> glWeightfvARB;
        /// <summary>void glWeightivARB(GLint size, GLint[] weights);</summary>
        public readonly delegate* unmanaged<GLint, GLint[], void> glWeightivARB;
        /// <summary>void glWeightsvARB(GLint size, GLshort[] weights);</summary>
        public readonly delegate* unmanaged<GLint, GLshort[], void> glWeightsvARB;
        /// <summary>void glWeightubvARB(GLint size, GLubyte[] weights);</summary>
        public readonly delegate* unmanaged<GLint, GLubyte[], void> glWeightubvARB;
        /// <summary>void glWeightuivARB(GLint size, GLuint[] weights);</summary>
        public readonly delegate* unmanaged<GLint, GLuint[], void> glWeightuivARB;
        /// <summary>void glWeightusvARB(GLint size, GLushort[] weights);</summary>
        public readonly delegate* unmanaged<GLint, GLushort[], void> glWeightusvARB;
        /// <summary>void glWindowPos2d(GLdouble x, GLdouble y);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, void> glWindowPos2d;
        /// <summary>void glWindowPos2dARB(GLdouble x, GLdouble y);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, void> glWindowPos2dARB;
        /// <summary>void glWindowPos2dMESA(GLdouble x, GLdouble y);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, void> glWindowPos2dMESA;
        /// <summary>void glWindowPos2dv(GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glWindowPos2dv;
        /// <summary>void glWindowPos2dvARB(GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glWindowPos2dvARB;
        /// <summary>void glWindowPos2dvMESA(GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glWindowPos2dvMESA;
        /// <summary>void glWindowPos2f(GLfloat x, GLfloat y);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, void> glWindowPos2f;
        /// <summary>void glWindowPos2fARB(GLfloat x, GLfloat y);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, void> glWindowPos2fARB;
        /// <summary>void glWindowPos2fMESA(GLfloat x, GLfloat y);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, void> glWindowPos2fMESA;
        /// <summary>void glWindowPos2fv(GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glWindowPos2fv;
        /// <summary>void glWindowPos2fvARB(GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glWindowPos2fvARB;
        /// <summary>void glWindowPos2fvMESA(GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glWindowPos2fvMESA;
        /// <summary>void glWindowPos2i(GLint x, GLint y);</summary>
        public readonly delegate* unmanaged<GLint, GLint, void> glWindowPos2i;
        /// <summary>void glWindowPos2iARB(GLint x, GLint y);</summary>
        public readonly delegate* unmanaged<GLint, GLint, void> glWindowPos2iARB;
        /// <summary>void glWindowPos2iMESA(GLint x, GLint y);</summary>
        public readonly delegate* unmanaged<GLint, GLint, void> glWindowPos2iMESA;
        /// <summary>void glWindowPos2iv(GLint[] v);</summary>
        public readonly delegate* unmanaged<GLint[], void> glWindowPos2iv;
        /// <summary>void glWindowPos2ivARB(GLint[] v);</summary>
        public readonly delegate* unmanaged<GLint[], void> glWindowPos2ivARB;
        /// <summary>void glWindowPos2ivMESA(GLint[] v);</summary>
        public readonly delegate* unmanaged<GLint[], void> glWindowPos2ivMESA;
        /// <summary>void glWindowPos2s(GLshort x, GLshort y);</summary>
        public readonly delegate* unmanaged<GLshort, GLshort, void> glWindowPos2s;
        /// <summary>void glWindowPos2sARB(GLshort x, GLshort y);</summary>
        public readonly delegate* unmanaged<GLshort, GLshort, void> glWindowPos2sARB;
        /// <summary>void glWindowPos2sMESA(GLshort x, GLshort y);</summary>
        public readonly delegate* unmanaged<GLshort, GLshort, void> glWindowPos2sMESA;
        /// <summary>void glWindowPos2sv(GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLshort[], void> glWindowPos2sv;
        /// <summary>void glWindowPos2svARB(GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLshort[], void> glWindowPos2svARB;
        /// <summary>void glWindowPos2svMESA(GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLshort[], void> glWindowPos2svMESA;
        /// <summary>void glWindowPos3d(GLdouble x, GLdouble y, GLdouble z);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, GLdouble, void> glWindowPos3d;
        /// <summary>void glWindowPos3dARB(GLdouble x, GLdouble y, GLdouble z);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, GLdouble, void> glWindowPos3dARB;
        /// <summary>void glWindowPos3dMESA(GLdouble x, GLdouble y, GLdouble z);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, GLdouble, void> glWindowPos3dMESA;
        /// <summary>void glWindowPos3dv(GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glWindowPos3dv;
        /// <summary>void glWindowPos3dvARB(GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glWindowPos3dvARB;
        /// <summary>void glWindowPos3dvMESA(GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glWindowPos3dvMESA;
        /// <summary>void glWindowPos3f(GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, void> glWindowPos3f;
        /// <summary>void glWindowPos3fARB(GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, void> glWindowPos3fARB;
        /// <summary>void glWindowPos3fMESA(GLfloat x, GLfloat y, GLfloat z);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, void> glWindowPos3fMESA;
        /// <summary>void glWindowPos3fv(GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glWindowPos3fv;
        /// <summary>void glWindowPos3fvARB(GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glWindowPos3fvARB;
        /// <summary>void glWindowPos3fvMESA(GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glWindowPos3fvMESA;
        /// <summary>void glWindowPos3i(GLint x, GLint y, GLint z);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, void> glWindowPos3i;
        /// <summary>void glWindowPos3iARB(GLint x, GLint y, GLint z);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, void> glWindowPos3iARB;
        /// <summary>void glWindowPos3iMESA(GLint x, GLint y, GLint z);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, void> glWindowPos3iMESA;
        /// <summary>void glWindowPos3iv(GLint[] v);</summary>
        public readonly delegate* unmanaged<GLint[], void> glWindowPos3iv;
        /// <summary>void glWindowPos3ivARB(GLint[] v);</summary>
        public readonly delegate* unmanaged<GLint[], void> glWindowPos3ivARB;
        /// <summary>void glWindowPos3ivMESA(GLint[] v);</summary>
        public readonly delegate* unmanaged<GLint[], void> glWindowPos3ivMESA;
        /// <summary>void glWindowPos3s(GLshort x, GLshort y, GLshort z);</summary>
        public readonly delegate* unmanaged<GLshort, GLshort, GLshort, void> glWindowPos3s;
        /// <summary>void glWindowPos3sARB(GLshort x, GLshort y, GLshort z);</summary>
        public readonly delegate* unmanaged<GLshort, GLshort, GLshort, void> glWindowPos3sARB;
        /// <summary>void glWindowPos3sMESA(GLshort x, GLshort y, GLshort z);</summary>
        public readonly delegate* unmanaged<GLshort, GLshort, GLshort, void> glWindowPos3sMESA;
        /// <summary>void glWindowPos3sv(GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLshort[], void> glWindowPos3sv;
        /// <summary>void glWindowPos3svARB(GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLshort[], void> glWindowPos3svARB;
        /// <summary>void glWindowPos3svMESA(GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLshort[], void> glWindowPos3svMESA;
        /// <summary>void glWindowPos4dMESA(GLdouble x, GLdouble y, GLdouble z, GLdouble w);</summary>
        public readonly delegate* unmanaged<GLdouble, GLdouble, GLdouble, GLdouble, void> glWindowPos4dMESA;
        /// <summary>void glWindowPos4dvMESA(GLdouble[] v);</summary>
        public readonly delegate* unmanaged<GLdouble[], void> glWindowPos4dvMESA;
        /// <summary>void glWindowPos4fMESA(GLfloat x, GLfloat y, GLfloat z, GLfloat w);</summary>
        public readonly delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, void> glWindowPos4fMESA;
        /// <summary>void glWindowPos4fvMESA(GLfloat[] v);</summary>
        public readonly delegate* unmanaged<GLfloat[], void> glWindowPos4fvMESA;
        /// <summary>void glWindowPos4iMESA(GLint x, GLint y, GLint z, GLint w);</summary>
        public readonly delegate* unmanaged<GLint, GLint, GLint, GLint, void> glWindowPos4iMESA;
        /// <summary>void glWindowPos4ivMESA(GLint[] v);</summary>
        public readonly delegate* unmanaged<GLint[], void> glWindowPos4ivMESA;
        /// <summary>void glWindowPos4sMESA(GLshort x, GLshort y, GLshort z, GLshort w);</summary>
        public readonly delegate* unmanaged<GLshort, GLshort, GLshort, GLshort, void> glWindowPos4sMESA;
        /// <summary>void glWindowPos4svMESA(GLshort[] v);</summary>
        public readonly delegate* unmanaged<GLshort[], void> glWindowPos4svMESA;
        /// <summary>void glWindowRectanglesEXT(GLenum mode, GLsizei count, GLint[] box);</summary>
        public readonly delegate* unmanaged<GLenum, GLsizei, GLint[], void> glWindowRectanglesEXT;
        /// <summary>void glWriteMaskEXT(GLuint res, GLuint in, GLenum outX, GLenum outY, GLenum outZ, GLenum outW);</summary>
        public readonly delegate* unmanaged<GLuint, GLuint, GLenum, GLenum, GLenum, GLenum, void> glWriteMaskEXT;
        /// <summary>void glDrawVkImageNV(GLuint64 vkImage, GLuint sampler, GLfloat x0, GLfloat y0, GLfloat x1, GLfloat y1, GLfloat z, GLfloat s0, GLfloat t0, GLfloat s1, GLfloat t1);</summary>
        public readonly delegate* unmanaged<GLuint64, GLuint, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void> glDrawVkImageNV;
        // typedef void (APIENTRY  *GLVULKANPROCNV)(void);
        /// <summary>GLVULKANPROCNV glGetVkProcAddrNV(string name);</summary>
        public readonly delegate* unmanaged<string, delegate*<void>> glGetVkProcAddrNV;
        /// <summary>void glWaitVkSemaphoreNV(GLuint64 vkSemaphore);</summary>
        public readonly delegate* unmanaged<GLuint64, void> glWaitVkSemaphoreNV;
        /// <summary>void glSignalVkSemaphoreNV(GLuint64 vkSemaphore);</summary>
        public readonly delegate* unmanaged<GLuint64, void> glSignalVkSemaphoreNV;
        /// <summary>void glSignalVkFenceNV(GLuint64 vkFence);</summary>
        public readonly delegate* unmanaged<GLuint64, void> glSignalVkFenceNV;
        /// <summary>void glFramebufferParameteriMESA(GLenum target, GLenum pname, GLint param);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint, void> glFramebufferParameteriMESA;
        /// <summary>void glGetFramebufferParameterivMESA(GLenum target, GLenum pname, GLint[] params);</summary>
        public readonly delegate* unmanaged<GLenum, GLenum, GLint[], void> glGetFramebufferParameterivMESA;

    }
}
