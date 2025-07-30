using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CSharpGL {
    unsafe partial class GL {
        /// <summary>
        /// collection of openGL function pointers.
        /// </summary>
        /// <param name="GetProcAddress">the function that gets openGL function pointers</param>
        /// <param name="config">load which opengl functions? no config(null) means I want all.</param>
        public GL(Func<string, IntPtr> GetProcAddress, HashSet<string>? config) {
            //this.GetProcAddress = GetProcAddress;
            ArgumentNullException.ThrowIfNull(GetProcAddress);

            // way #1
            var type = this.GetType();
            var fieldInfos = type.GetFields(BindingFlags.Instance | BindingFlags.Public /*| BindingFlags.NonPublic*/);
            foreach (var fieldInfo in fieldInfos) {
                var glFuncName = fieldInfo.Name;
                if (config == null || config.Contains(glFuncName)) {
                    var pointer = GetProcAddress(glFuncName);
                    if (pointer != IntPtr.Zero) {
                        fieldInfo.SetValue(this, pointer);
                    }
                }
            }
            //// dump opengl functions supported by this machine.
            //var filename = $"GLPointers{DateTime.Now.ToString("yyyyMMdd-HHmmss")}.txt";
            //using (var writer = new StreamWriter(filename))
            //    foreach (var fieldInfo in fieldInfos) {
            //        var glFuncName = fieldInfo.Name;
            //        var pointer = GetProcAddress(glFuncName);
            //        if (pointer != IntPtr.Zero) {
            //            writer.WriteLine(glFuncName);
            //        }
            //    }

            // way #2
            // openGL functions
            #region openGL functions

            //if (config == null || config.Contains("glAccum")) {
            //    glAccum = (delegate* unmanaged<GLenum, GLfloat, void>)GetProcAddress("glAccum");
            //}
            //if (config == null || config.Contains("glAccumxOES")) {
            //    glAccumxOES = (delegate* unmanaged<GLenum, GLfixed, void>)GetProcAddress("glAccumxOES");
            //}
            //if (config == null || config.Contains("glActiveProgramEXT")) {
            //    glActiveProgramEXT = (delegate* unmanaged<GLuint, void>)GetProcAddress("glActiveProgramEXT");
            //}
            //if (config == null || config.Contains("glActiveShaderProgram")) {
            //    glActiveShaderProgram = (delegate* unmanaged<GLuint, GLuint, void>)GetProcAddress("glActiveShaderProgram");
            //}
            //if (config == null || config.Contains("glActiveShaderProgramEXT")) {
            //    glActiveShaderProgramEXT = (delegate* unmanaged<GLuint, GLuint, void>)GetProcAddress("glActiveShaderProgramEXT");
            //}
            //if (config == null || config.Contains("glActiveStencilFaceEXT")) {
            //    glActiveStencilFaceEXT = (delegate* unmanaged<GLenum, void>)GetProcAddress("glActiveStencilFaceEXT");
            //}
            //if (config == null || config.Contains("glActiveTexture")) {
            //    glActiveTexture = (delegate* unmanaged<GLenum, void>)GetProcAddress("glActiveTexture");
            //}
            //if (config == null || config.Contains("glActiveTextureARB")) {
            //    glActiveTextureARB = (delegate* unmanaged<GLenum, void>)GetProcAddress("glActiveTextureARB");
            //}
            //if (config == null || config.Contains("glActiveVaryingNV")) {
            //    glActiveVaryingNV = (delegate* unmanaged<GLuint, string, void>)GetProcAddress("glActiveVaryingNV");
            //}
            //if (config == null || config.Contains("glAlphaFragmentOp1ATI")) {
            //    glAlphaFragmentOp1ATI = (delegate* unmanaged<GLenum, GLuint, GLuint, GLuint, GLuint, GLuint, void>)GetProcAddress("glAlphaFragmentOp1ATI");
            //}
            //if (config == null || config.Contains("glAlphaFragmentOp2ATI")) {
            //    glAlphaFragmentOp2ATI = (delegate* unmanaged<GLenum, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, void>)GetProcAddress("glAlphaFragmentOp2ATI");
            //}
            //if (config == null || config.Contains("glAlphaFragmentOp3ATI")) {
            //    glAlphaFragmentOp3ATI = (delegate* unmanaged<GLenum, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, void>)GetProcAddress("glAlphaFragmentOp3ATI");
            //}
            //if (config == null || config.Contains("glAlphaFunc")) {
            //    glAlphaFunc = (delegate* unmanaged<GLenum, GLfloat, void>)GetProcAddress("glAlphaFunc");
            //}
            //if (config == null || config.Contains("glAlphaFuncQCOM")) {
            //    glAlphaFuncQCOM = (delegate* unmanaged<GLenum, GLclampf, void>)GetProcAddress("glAlphaFuncQCOM");
            //}
            //if (config == null || config.Contains("glAlphaFuncx")) {
            //    glAlphaFuncx = (delegate* unmanaged<GLenum, GLfixed, void>)GetProcAddress("glAlphaFuncx");
            //}
            //if (config == null || config.Contains("glAlphaFuncxOES")) {
            //    glAlphaFuncxOES = (delegate* unmanaged<GLenum, GLfixed, void>)GetProcAddress("glAlphaFuncxOES");
            //}
            //if (config == null || config.Contains("glAlphaToCoverageDitherControlNV")) {
            //    glAlphaToCoverageDitherControlNV = (delegate* unmanaged<GLenum, void>)GetProcAddress("glAlphaToCoverageDitherControlNV");
            //}
            //if (config == null || config.Contains("glApplyFramebufferAttachmentCMAAINTEL")) {
            //    glApplyFramebufferAttachmentCMAAINTEL = (delegate* unmanaged<void>)GetProcAddress("glApplyFramebufferAttachmentCMAAINTEL");
            //}
            //if (config == null || config.Contains("glApplyTextureEXT")) {
            //    glApplyTextureEXT = (delegate* unmanaged<GLenum, void>)GetProcAddress("glApplyTextureEXT");
            //}
            //if (config == null || config.Contains("glAcquireKeyedMutexWin32EXT")) {
            //    glAcquireKeyedMutexWin32EXT = (delegate* unmanaged<GLuint, GLuint64, GLuint, GLboolean>)GetProcAddress("glAcquireKeyedMutexWin32EXT");
            //}
            //if (config == null || config.Contains("glAreProgramsResidentNV")) {
            //    glAreProgramsResidentNV = (delegate* unmanaged<GLsizei, GLuint[], GLboolean[], GLboolean>)GetProcAddress("glAreProgramsResidentNV");
            //}
            //if (config == null || config.Contains("glAreTexturesResident")) {
            //    glAreTexturesResident = (delegate* unmanaged<GLsizei, GLuint[], GLboolean[], GLboolean>)GetProcAddress("glAreTexturesResident");
            //}
            //if (config == null || config.Contains("glAreTexturesResidentEXT")) {
            //    glAreTexturesResidentEXT = (delegate* unmanaged<GLsizei, GLuint[], GLboolean[], GLboolean>)GetProcAddress("glAreTexturesResidentEXT");
            //}
            //if (config == null || config.Contains("glArrayElement")) {
            //    glArrayElement = (delegate* unmanaged<GLint, void>)GetProcAddress("glArrayElement");
            //}
            //if (config == null || config.Contains("glArrayElementEXT")) {
            //    glArrayElementEXT = (delegate* unmanaged<GLint, void>)GetProcAddress("glArrayElementEXT");
            //}
            //if (config == null || config.Contains("glArrayObjectATI")) {
            //    glArrayObjectATI = (delegate* unmanaged<GLenum, GLint, GLenum, GLsizei, GLuint, GLuint, void>)GetProcAddress("glArrayObjectATI");
            //}
            //if (config == null || config.Contains("glAsyncCopyBufferSubDataNVX")) {
            //    glAsyncCopyBufferSubDataNVX = (delegate* unmanaged<GLsizei, GLuint[], GLuint64[], GLuint, GLbitfield, GLuint, GLuint, GLintptr, GLintptr, GLsizeiptr, GLsizei, GLuint[], GLuint64[], GLuint>)GetProcAddress("glAsyncCopyBufferSubDataNVX");
            //}
            //if (config == null || config.Contains("glAsyncCopyImageSubDataNVX")) {
            //    glAsyncCopyImageSubDataNVX = (delegate* unmanaged<GLsizei, GLuint[], GLuint64[], GLuint, GLbitfield, GLuint, GLenum, GLint, GLint, GLint, GLint, GLuint, GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLsizei, GLuint[], GLuint64[], GLuint>)GetProcAddress("glAsyncCopyImageSubDataNVX");
            //}
            //if (config == null || config.Contains("glAsyncMarkerSGIX")) {
            //    glAsyncMarkerSGIX = (delegate* unmanaged<GLuint, void>)GetProcAddress("glAsyncMarkerSGIX");
            //}
            //if (config == null || config.Contains("glAttachObjectARB")) {
            //    glAttachObjectARB = (delegate* unmanaged<GLhandleARB, GLhandleARB, void>)GetProcAddress("glAttachObjectARB");
            //}
            //if (config == null || config.Contains("glAttachShader")) {
            //    glAttachShader = (delegate* unmanaged<GLuint, GLuint, void>)GetProcAddress("glAttachShader");
            //}
            //if (config == null || config.Contains("glBegin")) {
            //    glBegin = (delegate* unmanaged<GLenum, void>)GetProcAddress("glBegin");
            //}
            //if (config == null || config.Contains("glBeginConditionalRender")) {
            //    glBeginConditionalRender = (delegate* unmanaged<GLuint, GLenum, void>)GetProcAddress("glBeginConditionalRender");
            //}
            //if (config == null || config.Contains("glBeginConditionalRenderNV")) {
            //    glBeginConditionalRenderNV = (delegate* unmanaged<GLuint, GLenum, void>)GetProcAddress("glBeginConditionalRenderNV");
            //}
            //if (config == null || config.Contains("glBeginConditionalRenderNVX")) {
            //    glBeginConditionalRenderNVX = (delegate* unmanaged<GLuint, void>)GetProcAddress("glBeginConditionalRenderNVX");
            //}
            //if (config == null || config.Contains("glBeginFragmentShaderATI")) {
            //    glBeginFragmentShaderATI = (delegate* unmanaged<void>)GetProcAddress("glBeginFragmentShaderATI");
            //}
            //if (config == null || config.Contains("glBeginOcclusionQueryNV")) {
            //    glBeginOcclusionQueryNV = (delegate* unmanaged<GLuint, void>)GetProcAddress("glBeginOcclusionQueryNV");
            //}
            //if (config == null || config.Contains("glBeginPerfMonitorAMD")) {
            //    glBeginPerfMonitorAMD = (delegate* unmanaged<GLuint, void>)GetProcAddress("glBeginPerfMonitorAMD");
            //}
            //if (config == null || config.Contains("glBeginPerfQueryINTEL")) {
            //    glBeginPerfQueryINTEL = (delegate* unmanaged<GLuint, void>)GetProcAddress("glBeginPerfQueryINTEL");
            //}
            //if (config == null || config.Contains("glBeginQuery")) {
            //    glBeginQuery = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glBeginQuery");
            //}
            //if (config == null || config.Contains("glBeginQueryARB")) {
            //    glBeginQueryARB = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glBeginQueryARB");
            //}
            //if (config == null || config.Contains("glBeginQueryEXT")) {
            //    glBeginQueryEXT = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glBeginQueryEXT");
            //}
            //if (config == null || config.Contains("glBeginQueryIndexed")) {
            //    glBeginQueryIndexed = (delegate* unmanaged<GLenum, GLuint, GLuint, void>)GetProcAddress("glBeginQueryIndexed");
            //}
            //if (config == null || config.Contains("glBeginTransformFeedback")) {
            //    glBeginTransformFeedback = (delegate* unmanaged<GLenum, void>)GetProcAddress("glBeginTransformFeedback");
            //}
            //if (config == null || config.Contains("glBeginTransformFeedbackEXT")) {
            //    glBeginTransformFeedbackEXT = (delegate* unmanaged<GLenum, void>)GetProcAddress("glBeginTransformFeedbackEXT");
            //}
            //if (config == null || config.Contains("glBeginTransformFeedbackNV")) {
            //    glBeginTransformFeedbackNV = (delegate* unmanaged<GLenum, void>)GetProcAddress("glBeginTransformFeedbackNV");
            //}
            //if (config == null || config.Contains("glBeginVertexShaderEXT")) {
            //    glBeginVertexShaderEXT = (delegate* unmanaged<void>)GetProcAddress("glBeginVertexShaderEXT");
            //}
            //if (config == null || config.Contains("glBeginVideoCaptureNV")) {
            //    glBeginVideoCaptureNV = (delegate* unmanaged<GLuint, void>)GetProcAddress("glBeginVideoCaptureNV");
            //}
            //if (config == null || config.Contains("glBindAttribLocation")) {
            //    glBindAttribLocation = (delegate* unmanaged<GLuint, GLuint, string, void>)GetProcAddress("glBindAttribLocation");
            //}
            //if (config == null || config.Contains("glBindAttribLocationARB")) {
            //    glBindAttribLocationARB = (delegate* unmanaged<GLhandleARB, GLuint, string, void>)GetProcAddress("glBindAttribLocationARB");
            //}
            //if (config == null || config.Contains("glBindBuffer")) {
            //    glBindBuffer = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glBindBuffer");
            //}
            //if (config == null || config.Contains("glBindBufferARB")) {
            //    glBindBufferARB = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glBindBufferARB");
            //}
            //if (config == null || config.Contains("glBindBufferBase")) {
            //    glBindBufferBase = (delegate* unmanaged<GLenum, GLuint, GLuint, void>)GetProcAddress("glBindBufferBase");
            //}
            //if (config == null || config.Contains("glBindBufferBaseEXT")) {
            //    glBindBufferBaseEXT = (delegate* unmanaged<GLenum, GLuint, GLuint, void>)GetProcAddress("glBindBufferBaseEXT");
            //}
            //if (config == null || config.Contains("glBindBufferBaseNV")) {
            //    glBindBufferBaseNV = (delegate* unmanaged<GLenum, GLuint, GLuint, void>)GetProcAddress("glBindBufferBaseNV");
            //}
            //if (config == null || config.Contains("glBindBufferOffsetEXT")) {
            //    glBindBufferOffsetEXT = (delegate* unmanaged<GLenum, GLuint, GLuint, GLintptr, void>)GetProcAddress("glBindBufferOffsetEXT");
            //}
            //if (config == null || config.Contains("glBindBufferOffsetNV")) {
            //    glBindBufferOffsetNV = (delegate* unmanaged<GLenum, GLuint, GLuint, GLintptr, void>)GetProcAddress("glBindBufferOffsetNV");
            //}
            //if (config == null || config.Contains("glBindBufferRange")) {
            //    glBindBufferRange = (delegate* unmanaged<GLenum, GLuint, GLuint, GLintptr, GLsizeiptr, void>)GetProcAddress("glBindBufferRange");
            //}
            //if (config == null || config.Contains("glBindBufferRangeEXT")) {
            //    glBindBufferRangeEXT = (delegate* unmanaged<GLenum, GLuint, GLuint, GLintptr, GLsizeiptr, void>)GetProcAddress("glBindBufferRangeEXT");
            //}
            //if (config == null || config.Contains("glBindBufferRangeNV")) {
            //    glBindBufferRangeNV = (delegate* unmanaged<GLenum, GLuint, GLuint, GLintptr, GLsizeiptr, void>)GetProcAddress("glBindBufferRangeNV");
            //}
            //if (config == null || config.Contains("glBindBuffersBase")) {
            //    glBindBuffersBase = (delegate* unmanaged<GLenum, GLuint, GLsizei, GLuint[], void>)GetProcAddress("glBindBuffersBase");
            //}
            //if (config == null || config.Contains("glBindBuffersRange")) {
            //    glBindBuffersRange = (delegate* unmanaged<GLenum, GLuint, GLsizei, GLuint[], GLintptr[], GLsizeiptr[], void>)GetProcAddress("glBindBuffersRange");
            //}
            //if (config == null || config.Contains("glBindFragDataLocation")) {
            //    glBindFragDataLocation = (delegate* unmanaged<GLuint, GLuint, string, void>)GetProcAddress("glBindFragDataLocation");
            //}
            //if (config == null || config.Contains("glBindFragDataLocationEXT")) {
            //    glBindFragDataLocationEXT = (delegate* unmanaged<GLuint, GLuint, string, void>)GetProcAddress("glBindFragDataLocationEXT");
            //}
            //if (config == null || config.Contains("glBindFragDataLocationIndexed")) {
            //    glBindFragDataLocationIndexed = (delegate* unmanaged<GLuint, GLuint, GLuint, string, void>)GetProcAddress("glBindFragDataLocationIndexed");
            //}
            //if (config == null || config.Contains("glBindFragDataLocationIndexedEXT")) {
            //    glBindFragDataLocationIndexedEXT = (delegate* unmanaged<GLuint, GLuint, GLuint, string, void>)GetProcAddress("glBindFragDataLocationIndexedEXT");
            //}
            //if (config == null || config.Contains("glBindFragmentShaderATI")) {
            //    glBindFragmentShaderATI = (delegate* unmanaged<GLuint, void>)GetProcAddress("glBindFragmentShaderATI");
            //}
            //if (config == null || config.Contains("glBindFramebuffer")) {
            //    glBindFramebuffer = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glBindFramebuffer");
            //}
            //if (config == null || config.Contains("glBindFramebufferEXT")) {
            //    glBindFramebufferEXT = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glBindFramebufferEXT");
            //}
            //if (config == null || config.Contains("glBindFramebufferOES")) {
            //    glBindFramebufferOES = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glBindFramebufferOES");
            //}
            //if (config == null || config.Contains("glBindImageTexture")) {
            //    glBindImageTexture = (delegate* unmanaged<GLuint, GLuint, GLint, GLboolean, GLint, GLenum, GLenum, void>)GetProcAddress("glBindImageTexture");
            //}
            //if (config == null || config.Contains("glBindImageTextureEXT")) {
            //    glBindImageTextureEXT = (delegate* unmanaged<GLuint, GLuint, GLint, GLboolean, GLint, GLenum, GLint, void>)GetProcAddress("glBindImageTextureEXT");
            //}
            //if (config == null || config.Contains("glBindImageTextures")) {
            //    glBindImageTextures = (delegate* unmanaged<GLuint, GLsizei, GLuint[], void>)GetProcAddress("glBindImageTextures");
            //}
            //if (config == null || config.Contains("glBindLightParameterEXT")) {
            //    glBindLightParameterEXT = (delegate* unmanaged<GLenum, GLenum, GLuint>)GetProcAddress("glBindLightParameterEXT");
            //}
            //if (config == null || config.Contains("glBindMaterialParameterEXT")) {
            //    glBindMaterialParameterEXT = (delegate* unmanaged<GLenum, GLenum, GLuint>)GetProcAddress("glBindMaterialParameterEXT");
            //}
            //if (config == null || config.Contains("glBindMultiTextureEXT")) {
            //    glBindMultiTextureEXT = (delegate* unmanaged<GLenum, GLenum, GLuint, void>)GetProcAddress("glBindMultiTextureEXT");
            //}
            //if (config == null || config.Contains("glBindParameterEXT")) {
            //    glBindParameterEXT = (delegate* unmanaged<GLenum, GLuint>)GetProcAddress("glBindParameterEXT");
            //}
            //if (config == null || config.Contains("glBindProgramARB")) {
            //    glBindProgramARB = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glBindProgramARB");
            //}
            //if (config == null || config.Contains("glBindProgramNV")) {
            //    glBindProgramNV = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glBindProgramNV");
            //}
            //if (config == null || config.Contains("glBindProgramPipeline")) {
            //    glBindProgramPipeline = (delegate* unmanaged<GLuint, void>)GetProcAddress("glBindProgramPipeline");
            //}
            //if (config == null || config.Contains("glBindProgramPipelineEXT")) {
            //    glBindProgramPipelineEXT = (delegate* unmanaged<GLuint, void>)GetProcAddress("glBindProgramPipelineEXT");
            //}
            //if (config == null || config.Contains("glBindRenderbuffer")) {
            //    glBindRenderbuffer = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glBindRenderbuffer");
            //}
            //if (config == null || config.Contains("glBindRenderbufferEXT")) {
            //    glBindRenderbufferEXT = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glBindRenderbufferEXT");
            //}
            //if (config == null || config.Contains("glBindRenderbufferOES")) {
            //    glBindRenderbufferOES = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glBindRenderbufferOES");
            //}
            //if (config == null || config.Contains("glBindSampler")) {
            //    glBindSampler = (delegate* unmanaged<GLuint, GLuint, void>)GetProcAddress("glBindSampler");
            //}
            //if (config == null || config.Contains("glBindSamplers")) {
            //    glBindSamplers = (delegate* unmanaged<GLuint, GLsizei, GLuint[], void>)GetProcAddress("glBindSamplers");
            //}
            //if (config == null || config.Contains("glBindShadingRateImageNV")) {
            //    glBindShadingRateImageNV = (delegate* unmanaged<GLuint, void>)GetProcAddress("glBindShadingRateImageNV");
            //}
            //if (config == null || config.Contains("glBindTexGenParameterEXT")) {
            //    glBindTexGenParameterEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLuint>)GetProcAddress("glBindTexGenParameterEXT");
            //}
            //if (config == null || config.Contains("glBindTexture")) {
            //    glBindTexture = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glBindTexture");
            //}
            //if (config == null || config.Contains("glBindTextureEXT")) {
            //    glBindTextureEXT = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glBindTextureEXT");
            //}
            //if (config == null || config.Contains("glBindTextureUnit")) {
            //    glBindTextureUnit = (delegate* unmanaged<GLuint, GLuint, void>)GetProcAddress("glBindTextureUnit");
            //}
            //if (config == null || config.Contains("glBindTextureUnitParameterEXT")) {
            //    glBindTextureUnitParameterEXT = (delegate* unmanaged<GLenum, GLenum, GLuint>)GetProcAddress("glBindTextureUnitParameterEXT");
            //}
            //if (config == null || config.Contains("glBindTextures")) {
            //    glBindTextures = (delegate* unmanaged<GLuint, GLsizei, GLuint[], void>)GetProcAddress("glBindTextures");
            //}
            //if (config == null || config.Contains("glBindTransformFeedback")) {
            //    glBindTransformFeedback = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glBindTransformFeedback");
            //}
            //if (config == null || config.Contains("glBindTransformFeedbackNV")) {
            //    glBindTransformFeedbackNV = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glBindTransformFeedbackNV");
            //}
            //if (config == null || config.Contains("glBindVertexArray")) {
            //    glBindVertexArray = (delegate* unmanaged<GLuint, void>)GetProcAddress("glBindVertexArray");
            //}
            //if (config == null || config.Contains("glBindVertexArrayAPPLE")) {
            //    glBindVertexArrayAPPLE = (delegate* unmanaged<GLuint, void>)GetProcAddress("glBindVertexArrayAPPLE");
            //}
            //if (config == null || config.Contains("glBindVertexArrayOES")) {
            //    glBindVertexArrayOES = (delegate* unmanaged<GLuint, void>)GetProcAddress("glBindVertexArrayOES");
            //}
            //if (config == null || config.Contains("glBindVertexBuffer")) {
            //    glBindVertexBuffer = (delegate* unmanaged<GLuint, GLuint, GLintptr, GLsizei, void>)GetProcAddress("glBindVertexBuffer");
            //}
            //if (config == null || config.Contains("glBindVertexBuffers")) {
            //    glBindVertexBuffers = (delegate* unmanaged<GLuint, GLsizei, GLuint[], GLintptr[], GLsizei[], void>)GetProcAddress("glBindVertexBuffers");
            //}
            //if (config == null || config.Contains("glBindVertexShaderEXT")) {
            //    glBindVertexShaderEXT = (delegate* unmanaged<GLuint, void>)GetProcAddress("glBindVertexShaderEXT");
            //}
            //if (config == null || config.Contains("glBindVideoCaptureStreamBufferNV")) {
            //    glBindVideoCaptureStreamBufferNV = (delegate* unmanaged<GLuint, GLuint, GLenum, GLintptrARB, void>)GetProcAddress("glBindVideoCaptureStreamBufferNV");
            //}
            //if (config == null || config.Contains("glBindVideoCaptureStreamTextureNV")) {
            //    glBindVideoCaptureStreamTextureNV = (delegate* unmanaged<GLuint, GLuint, GLenum, GLenum, GLuint, void>)GetProcAddress("glBindVideoCaptureStreamTextureNV");
            //}
            //if (config == null || config.Contains("glBinormal3bEXT")) {
            //    glBinormal3bEXT = (delegate* unmanaged<GLbyte, GLbyte, GLbyte, void>)GetProcAddress("glBinormal3bEXT");
            //}
            //if (config == null || config.Contains("glBinormal3bvEXT")) {
            //    glBinormal3bvEXT = (delegate* unmanaged<GLbyte[], void>)GetProcAddress("glBinormal3bvEXT");
            //}
            //if (config == null || config.Contains("glBinormal3dEXT")) {
            //    glBinormal3dEXT = (delegate* unmanaged<GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glBinormal3dEXT");
            //}
            //if (config == null || config.Contains("glBinormal3dvEXT")) {
            //    glBinormal3dvEXT = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glBinormal3dvEXT");
            //}
            //if (config == null || config.Contains("glBinormal3fEXT")) {
            //    glBinormal3fEXT = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glBinormal3fEXT");
            //}
            //if (config == null || config.Contains("glBinormal3fvEXT")) {
            //    glBinormal3fvEXT = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glBinormal3fvEXT");
            //}
            //if (config == null || config.Contains("glBinormal3iEXT")) {
            //    glBinormal3iEXT = (delegate* unmanaged<GLint, GLint, GLint, void>)GetProcAddress("glBinormal3iEXT");
            //}
            //if (config == null || config.Contains("glBinormal3ivEXT")) {
            //    glBinormal3ivEXT = (delegate* unmanaged<GLint[], void>)GetProcAddress("glBinormal3ivEXT");
            //}
            //if (config == null || config.Contains("glBinormal3sEXT")) {
            //    glBinormal3sEXT = (delegate* unmanaged<GLshort, GLshort, GLshort, void>)GetProcAddress("glBinormal3sEXT");
            //}
            //if (config == null || config.Contains("glBinormal3svEXT")) {
            //    glBinormal3svEXT = (delegate* unmanaged<GLshort[], void>)GetProcAddress("glBinormal3svEXT");
            //}
            //if (config == null || config.Contains("glBinormalPointerEXT")) {
            //    glBinormalPointerEXT = (delegate* unmanaged<GLenum, GLsizei, IntPtr, void>)GetProcAddress("glBinormalPointerEXT");
            //}
            //if (config == null || config.Contains("glBitmap")) {
            //    glBitmap = (delegate* unmanaged<GLsizei, GLsizei, GLfloat, GLfloat, GLfloat, GLfloat, GLubyte[], void>)GetProcAddress("glBitmap");
            //}
            //if (config == null || config.Contains("glBitmapxOES")) {
            //    glBitmapxOES = (delegate* unmanaged<GLsizei, GLsizei, GLfixed, GLfixed, GLfixed, GLfixed, GLubyte[], void>)GetProcAddress("glBitmapxOES");
            //}
            //if (config == null || config.Contains("glBlendBarrier")) {
            //    glBlendBarrier = (delegate* unmanaged<void>)GetProcAddress("glBlendBarrier");
            //}
            //if (config == null || config.Contains("glBlendBarrierKHR")) {
            //    glBlendBarrierKHR = (delegate* unmanaged<void>)GetProcAddress("glBlendBarrierKHR");
            //}
            //if (config == null || config.Contains("glBlendBarrierNV")) {
            //    glBlendBarrierNV = (delegate* unmanaged<void>)GetProcAddress("glBlendBarrierNV");
            //}
            //if (config == null || config.Contains("glBlendColor")) {
            //    glBlendColor = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glBlendColor");
            //}
            //if (config == null || config.Contains("glBlendColorEXT")) {
            //    glBlendColorEXT = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glBlendColorEXT");
            //}
            //if (config == null || config.Contains("glBlendColorxOES")) {
            //    glBlendColorxOES = (delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glBlendColorxOES");
            //}
            //if (config == null || config.Contains("glBlendEquation")) {
            //    glBlendEquation = (delegate* unmanaged<GLenum, void>)GetProcAddress("glBlendEquation");
            //}
            //if (config == null || config.Contains("glBlendEquationEXT")) {
            //    glBlendEquationEXT = (delegate* unmanaged<GLenum, void>)GetProcAddress("glBlendEquationEXT");
            //}
            //if (config == null || config.Contains("glBlendEquationIndexedAMD")) {
            //    glBlendEquationIndexedAMD = (delegate* unmanaged<GLuint, GLenum, void>)GetProcAddress("glBlendEquationIndexedAMD");
            //}
            //if (config == null || config.Contains("glBlendEquationOES")) {
            //    glBlendEquationOES = (delegate* unmanaged<GLenum, void>)GetProcAddress("glBlendEquationOES");
            //}
            //if (config == null || config.Contains("glBlendEquationSeparate")) {
            //    glBlendEquationSeparate = (delegate* unmanaged<GLenum, GLenum, void>)GetProcAddress("glBlendEquationSeparate");
            //}
            //if (config == null || config.Contains("glBlendEquationSeparateEXT")) {
            //    glBlendEquationSeparateEXT = (delegate* unmanaged<GLenum, GLenum, void>)GetProcAddress("glBlendEquationSeparateEXT");
            //}
            //if (config == null || config.Contains("glBlendEquationSeparateIndexedAMD")) {
            //    glBlendEquationSeparateIndexedAMD = (delegate* unmanaged<GLuint, GLenum, GLenum, void>)GetProcAddress("glBlendEquationSeparateIndexedAMD");
            //}
            //if (config == null || config.Contains("glBlendEquationSeparateOES")) {
            //    glBlendEquationSeparateOES = (delegate* unmanaged<GLenum, GLenum, void>)GetProcAddress("glBlendEquationSeparateOES");
            //}
            //if (config == null || config.Contains("glBlendEquationSeparatei")) {
            //    glBlendEquationSeparatei = (delegate* unmanaged<GLuint, GLenum, GLenum, void>)GetProcAddress("glBlendEquationSeparatei");
            //}
            //if (config == null || config.Contains("glBlendEquationSeparateiARB")) {
            //    glBlendEquationSeparateiARB = (delegate* unmanaged<GLuint, GLenum, GLenum, void>)GetProcAddress("glBlendEquationSeparateiARB");
            //}
            //if (config == null || config.Contains("glBlendEquationSeparateiEXT")) {
            //    glBlendEquationSeparateiEXT = (delegate* unmanaged<GLuint, GLenum, GLenum, void>)GetProcAddress("glBlendEquationSeparateiEXT");
            //}
            //if (config == null || config.Contains("glBlendEquationSeparateiOES")) {
            //    glBlendEquationSeparateiOES = (delegate* unmanaged<GLuint, GLenum, GLenum, void>)GetProcAddress("glBlendEquationSeparateiOES");
            //}
            //if (config == null || config.Contains("glBlendEquationi")) {
            //    glBlendEquationi = (delegate* unmanaged<GLuint, GLenum, void>)GetProcAddress("glBlendEquationi");
            //}
            //if (config == null || config.Contains("glBlendEquationiARB")) {
            //    glBlendEquationiARB = (delegate* unmanaged<GLuint, GLenum, void>)GetProcAddress("glBlendEquationiARB");
            //}
            //if (config == null || config.Contains("glBlendEquationiEXT")) {
            //    glBlendEquationiEXT = (delegate* unmanaged<GLuint, GLenum, void>)GetProcAddress("glBlendEquationiEXT");
            //}
            //if (config == null || config.Contains("glBlendEquationiOES")) {
            //    glBlendEquationiOES = (delegate* unmanaged<GLuint, GLenum, void>)GetProcAddress("glBlendEquationiOES");
            //}
            //if (config == null || config.Contains("glBlendFunc")) {
            //    glBlendFunc = (delegate* unmanaged<GLenum, GLenum, void>)GetProcAddress("glBlendFunc");
            //}
            //if (config == null || config.Contains("glBlendFuncIndexedAMD")) {
            //    glBlendFuncIndexedAMD = (delegate* unmanaged<GLuint, GLenum, GLenum, void>)GetProcAddress("glBlendFuncIndexedAMD");
            //}
            //if (config == null || config.Contains("glBlendFuncSeparate")) {
            //    glBlendFuncSeparate = (delegate* unmanaged<GLenum, GLenum, GLenum, GLenum, void>)GetProcAddress("glBlendFuncSeparate");
            //}
            //if (config == null || config.Contains("glBlendFuncSeparateEXT")) {
            //    glBlendFuncSeparateEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLenum, void>)GetProcAddress("glBlendFuncSeparateEXT");
            //}
            //if (config == null || config.Contains("glBlendFuncSeparateINGR")) {
            //    glBlendFuncSeparateINGR = (delegate* unmanaged<GLenum, GLenum, GLenum, GLenum, void>)GetProcAddress("glBlendFuncSeparateINGR");
            //}
            //if (config == null || config.Contains("glBlendFuncSeparateIndexedAMD")) {
            //    glBlendFuncSeparateIndexedAMD = (delegate* unmanaged<GLuint, GLenum, GLenum, GLenum, GLenum, void>)GetProcAddress("glBlendFuncSeparateIndexedAMD");
            //}
            //if (config == null || config.Contains("glBlendFuncSeparateOES")) {
            //    glBlendFuncSeparateOES = (delegate* unmanaged<GLenum, GLenum, GLenum, GLenum, void>)GetProcAddress("glBlendFuncSeparateOES");
            //}
            //if (config == null || config.Contains("glBlendFuncSeparatei")) {
            //    glBlendFuncSeparatei = (delegate* unmanaged<GLuint, GLenum, GLenum, GLenum, GLenum, void>)GetProcAddress("glBlendFuncSeparatei");
            //}
            //if (config == null || config.Contains("glBlendFuncSeparateiARB")) {
            //    glBlendFuncSeparateiARB = (delegate* unmanaged<GLuint, GLenum, GLenum, GLenum, GLenum, void>)GetProcAddress("glBlendFuncSeparateiARB");
            //}
            //if (config == null || config.Contains("glBlendFuncSeparateiEXT")) {
            //    glBlendFuncSeparateiEXT = (delegate* unmanaged<GLuint, GLenum, GLenum, GLenum, GLenum, void>)GetProcAddress("glBlendFuncSeparateiEXT");
            //}
            //if (config == null || config.Contains("glBlendFuncSeparateiOES")) {
            //    glBlendFuncSeparateiOES = (delegate* unmanaged<GLuint, GLenum, GLenum, GLenum, GLenum, void>)GetProcAddress("glBlendFuncSeparateiOES");
            //}
            //if (config == null || config.Contains("glBlendFunci")) {
            //    glBlendFunci = (delegate* unmanaged<GLuint, GLenum, GLenum, void>)GetProcAddress("glBlendFunci");
            //}
            //if (config == null || config.Contains("glBlendFunciARB")) {
            //    glBlendFunciARB = (delegate* unmanaged<GLuint, GLenum, GLenum, void>)GetProcAddress("glBlendFunciARB");
            //}
            //if (config == null || config.Contains("glBlendFunciEXT")) {
            //    glBlendFunciEXT = (delegate* unmanaged<GLuint, GLenum, GLenum, void>)GetProcAddress("glBlendFunciEXT");
            //}
            //if (config == null || config.Contains("glBlendFunciOES")) {
            //    glBlendFunciOES = (delegate* unmanaged<GLuint, GLenum, GLenum, void>)GetProcAddress("glBlendFunciOES");
            //}
            //if (config == null || config.Contains("glBlendParameteriNV")) {
            //    glBlendParameteriNV = (delegate* unmanaged<GLenum, GLint, void>)GetProcAddress("glBlendParameteriNV");
            //}
            //if (config == null || config.Contains("glBlitFramebuffer")) {
            //    glBlitFramebuffer = (delegate* unmanaged<GLint, GLint, GLint, GLint, GLint, GLint, GLint, GLint, GLbitfield, GLenum, void>)GetProcAddress("glBlitFramebuffer");
            //}
            //if (config == null || config.Contains("glBlitFramebufferANGLE")) {
            //    glBlitFramebufferANGLE = (delegate* unmanaged<GLint, GLint, GLint, GLint, GLint, GLint, GLint, GLint, GLbitfield, GLenum, void>)GetProcAddress("glBlitFramebufferANGLE");
            //}
            //if (config == null || config.Contains("glBlitFramebufferEXT")) {
            //    glBlitFramebufferEXT = (delegate* unmanaged<GLint, GLint, GLint, GLint, GLint, GLint, GLint, GLint, GLbitfield, GLenum, void>)GetProcAddress("glBlitFramebufferEXT");
            //}
            //if (config == null || config.Contains("glBlitFramebufferNV")) {
            //    glBlitFramebufferNV = (delegate* unmanaged<GLint, GLint, GLint, GLint, GLint, GLint, GLint, GLint, GLbitfield, GLenum, void>)GetProcAddress("glBlitFramebufferNV");
            //}
            //if (config == null || config.Contains("glBlitNamedFramebuffer")) {
            //    glBlitNamedFramebuffer = (delegate* unmanaged<GLuint, GLuint, GLint, GLint, GLint, GLint, GLint, GLint, GLint, GLint, GLbitfield, GLenum, void>)GetProcAddress("glBlitNamedFramebuffer");
            //}
            //if (config == null || config.Contains("glBufferAddressRangeNV")) {
            //    glBufferAddressRangeNV = (delegate* unmanaged<GLenum, GLuint, GLuint64EXT, GLsizeiptr, void>)GetProcAddress("glBufferAddressRangeNV");
            //}
            //if (config == null || config.Contains("glBufferAttachMemoryNV")) {
            //    glBufferAttachMemoryNV = (delegate* unmanaged<GLenum, GLuint, GLuint64, void>)GetProcAddress("glBufferAttachMemoryNV");
            //}
            //if (config == null || config.Contains("glBufferData")) {
            //    glBufferData = (delegate* unmanaged<GLenum, GLsizeiptr, IntPtr, GLenum, void>)GetProcAddress("glBufferData");
            //}
            //if (config == null || config.Contains("glBufferDataARB")) {
            //    glBufferDataARB = (delegate* unmanaged<GLenum, GLsizeiptrARB, IntPtr, GLenum, void>)GetProcAddress("glBufferDataARB");
            //}
            //if (config == null || config.Contains("glBufferPageCommitmentARB")) {
            //    glBufferPageCommitmentARB = (delegate* unmanaged<GLenum, GLintptr, GLsizeiptr, GLboolean, void>)GetProcAddress("glBufferPageCommitmentARB");
            //}
            //if (config == null || config.Contains("glBufferParameteriAPPLE")) {
            //    glBufferParameteriAPPLE = (delegate* unmanaged<GLenum, GLenum, GLint, void>)GetProcAddress("glBufferParameteriAPPLE");
            //}
            //if (config == null || config.Contains("glBufferStorage")) {
            //    glBufferStorage = (delegate* unmanaged<GLenum, GLsizeiptr, IntPtr, GLbitfield, void>)GetProcAddress("glBufferStorage");
            //}
            //if (config == null || config.Contains("glBufferStorageEXT")) {
            //    glBufferStorageEXT = (delegate* unmanaged<GLenum, GLsizeiptr, IntPtr, GLbitfield, void>)GetProcAddress("glBufferStorageEXT");
            //}
            //if (config == null || config.Contains("glBufferStorageExternalEXT")) {
            //    glBufferStorageExternalEXT = (delegate* unmanaged<GLenum, GLintptr, GLsizeiptr, GLeglClientBufferEXT, GLbitfield, void>)GetProcAddress("glBufferStorageExternalEXT");
            //}
            //if (config == null || config.Contains("glBufferStorageMemEXT")) {
            //    glBufferStorageMemEXT = (delegate* unmanaged<GLenum, GLsizeiptr, GLuint, GLuint64, void>)GetProcAddress("glBufferStorageMemEXT");
            //}
            //if (config == null || config.Contains("glBufferSubData")) {
            //    glBufferSubData = (delegate* unmanaged<GLenum, GLintptr, GLsizeiptr, IntPtr, void>)GetProcAddress("glBufferSubData");
            //}
            //if (config == null || config.Contains("glBufferSubDataARB")) {
            //    glBufferSubDataARB = (delegate* unmanaged<GLenum, GLintptrARB, GLsizeiptrARB, IntPtr, void>)GetProcAddress("glBufferSubDataARB");
            //}
            //if (config == null || config.Contains("glCallCommandListNV")) {
            //    glCallCommandListNV = (delegate* unmanaged<GLuint, void>)GetProcAddress("glCallCommandListNV");
            //}
            //if (config == null || config.Contains("glCallList")) {
            //    glCallList = (delegate* unmanaged<GLuint, void>)GetProcAddress("glCallList");
            //}
            //if (config == null || config.Contains("glCallLists")) {
            //    glCallLists = (delegate* unmanaged<GLsizei, GLenum, IntPtr, void>)GetProcAddress("glCallLists");
            //}
            //if (config == null || config.Contains("glCheckFramebufferStatus")) {
            //    glCheckFramebufferStatus = (delegate* unmanaged<GLenum, GLenum>)GetProcAddress("glCheckFramebufferStatus");
            //}
            //if (config == null || config.Contains("glCheckFramebufferStatusEXT")) {
            //    glCheckFramebufferStatusEXT = (delegate* unmanaged<GLenum, GLenum>)GetProcAddress("glCheckFramebufferStatusEXT");
            //}
            //if (config == null || config.Contains("glCheckFramebufferStatusOES")) {
            //    glCheckFramebufferStatusOES = (delegate* unmanaged<GLenum, GLenum>)GetProcAddress("glCheckFramebufferStatusOES");
            //}
            //if (config == null || config.Contains("glCheckNamedFramebufferStatus")) {
            //    glCheckNamedFramebufferStatus = (delegate* unmanaged<GLuint, GLenum, GLenum>)GetProcAddress("glCheckNamedFramebufferStatus");
            //}
            //if (config == null || config.Contains("glCheckNamedFramebufferStatusEXT")) {
            //    glCheckNamedFramebufferStatusEXT = (delegate* unmanaged<GLuint, GLenum, GLenum>)GetProcAddress("glCheckNamedFramebufferStatusEXT");
            //}
            //if (config == null || config.Contains("glClampColor")) {
            //    glClampColor = (delegate* unmanaged<GLenum, GLenum, void>)GetProcAddress("glClampColor");
            //}
            //if (config == null || config.Contains("glClampColorARB")) {
            //    glClampColorARB = (delegate* unmanaged<GLenum, GLenum, void>)GetProcAddress("glClampColorARB");
            //}
            //if (config == null || config.Contains("glClear")) {
            //    glClear = (delegate* unmanaged<GLbitfield, void>)GetProcAddress("glClear");
            //}
            //if (config == null || config.Contains("glClearAccum")) {
            //    glClearAccum = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glClearAccum");
            //}
            //if (config == null || config.Contains("glClearAccumxOES")) {
            //    glClearAccumxOES = (delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glClearAccumxOES");
            //}
            //if (config == null || config.Contains("glClearBufferData")) {
            //    glClearBufferData = (delegate* unmanaged<GLenum, GLenum, GLenum, GLenum, IntPtr, void>)GetProcAddress("glClearBufferData");
            //}
            //if (config == null || config.Contains("glClearBufferSubData")) {
            //    glClearBufferSubData = (delegate* unmanaged<GLenum, GLenum, GLintptr, GLsizeiptr, GLenum, GLenum, IntPtr, void>)GetProcAddress("glClearBufferSubData");
            //}
            //if (config == null || config.Contains("glClearBufferfi")) {
            //    glClearBufferfi = (delegate* unmanaged<GLenum, GLint, GLfloat, GLint, void>)GetProcAddress("glClearBufferfi");
            //}
            //if (config == null || config.Contains("glClearBufferfv")) {
            //    glClearBufferfv = (delegate* unmanaged<GLenum, GLint, GLfloat[], void>)GetProcAddress("glClearBufferfv");
            //}
            //if (config == null || config.Contains("glClearBufferiv")) {
            //    glClearBufferiv = (delegate* unmanaged<GLenum, GLint, GLint[], void>)GetProcAddress("glClearBufferiv");
            //}
            //if (config == null || config.Contains("glClearBufferuiv")) {
            //    glClearBufferuiv = (delegate* unmanaged<GLenum, GLint, GLuint[], void>)GetProcAddress("glClearBufferuiv");
            //}
            //if (config == null || config.Contains("glClearColor")) {
            //    glClearColor = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glClearColor");
            //}
            //if (config == null || config.Contains("glClearColorIiEXT")) {
            //    glClearColorIiEXT = (delegate* unmanaged<GLint, GLint, GLint, GLint, void>)GetProcAddress("glClearColorIiEXT");
            //}
            //if (config == null || config.Contains("glClearColorIuiEXT")) {
            //    glClearColorIuiEXT = (delegate* unmanaged<GLuint, GLuint, GLuint, GLuint, void>)GetProcAddress("glClearColorIuiEXT");
            //}
            //if (config == null || config.Contains("glClearColorx")) {
            //    glClearColorx = (delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glClearColorx");
            //}
            //if (config == null || config.Contains("glClearColorxOES")) {
            //    glClearColorxOES = (delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glClearColorxOES");
            //}
            //if (config == null || config.Contains("glClearDepth")) {
            //    glClearDepth = (delegate* unmanaged<GLdouble, void>)GetProcAddress("glClearDepth");
            //}
            //if (config == null || config.Contains("glClearDepthdNV")) {
            //    glClearDepthdNV = (delegate* unmanaged<GLdouble, void>)GetProcAddress("glClearDepthdNV");
            //}
            //if (config == null || config.Contains("glClearDepthf")) {
            //    glClearDepthf = (delegate* unmanaged<GLfloat, void>)GetProcAddress("glClearDepthf");
            //}
            //if (config == null || config.Contains("glClearDepthfOES")) {
            //    glClearDepthfOES = (delegate* unmanaged<GLclampf, void>)GetProcAddress("glClearDepthfOES");
            //}
            //if (config == null || config.Contains("glClearDepthx")) {
            //    glClearDepthx = (delegate* unmanaged<GLfixed, void>)GetProcAddress("glClearDepthx");
            //}
            //if (config == null || config.Contains("glClearDepthxOES")) {
            //    glClearDepthxOES = (delegate* unmanaged<GLfixed, void>)GetProcAddress("glClearDepthxOES");
            //}
            //if (config == null || config.Contains("glClearIndex")) {
            //    glClearIndex = (delegate* unmanaged<GLfloat, void>)GetProcAddress("glClearIndex");
            //}
            //if (config == null || config.Contains("glClearNamedBufferData")) {
            //    glClearNamedBufferData = (delegate* unmanaged<GLuint, GLenum, GLenum, GLenum, IntPtr, void>)GetProcAddress("glClearNamedBufferData");
            //}
            //if (config == null || config.Contains("glClearNamedBufferDataEXT")) {
            //    glClearNamedBufferDataEXT = (delegate* unmanaged<GLuint, GLenum, GLenum, GLenum, IntPtr, void>)GetProcAddress("glClearNamedBufferDataEXT");
            //}
            //if (config == null || config.Contains("glClearNamedBufferSubData")) {
            //    glClearNamedBufferSubData = (delegate* unmanaged<GLuint, GLenum, GLintptr, GLsizeiptr, GLenum, GLenum, IntPtr, void>)GetProcAddress("glClearNamedBufferSubData");
            //}
            //if (config == null || config.Contains("glClearNamedBufferSubDataEXT")) {
            //    glClearNamedBufferSubDataEXT = (delegate* unmanaged<GLuint, GLenum, GLsizeiptr, GLsizeiptr, GLenum, GLenum, IntPtr, void>)GetProcAddress("glClearNamedBufferSubDataEXT");
            //}
            //if (config == null || config.Contains("glClearNamedFramebufferfi")) {
            //    glClearNamedFramebufferfi = (delegate* unmanaged<GLuint, GLenum, GLint, GLfloat, GLint, void>)GetProcAddress("glClearNamedFramebufferfi");
            //}
            //if (config == null || config.Contains("glClearNamedFramebufferfv")) {
            //    glClearNamedFramebufferfv = (delegate* unmanaged<GLuint, GLenum, GLint, GLfloat[], void>)GetProcAddress("glClearNamedFramebufferfv");
            //}
            //if (config == null || config.Contains("glClearNamedFramebufferiv")) {
            //    glClearNamedFramebufferiv = (delegate* unmanaged<GLuint, GLenum, GLint, GLint[], void>)GetProcAddress("glClearNamedFramebufferiv");
            //}
            //if (config == null || config.Contains("glClearNamedFramebufferuiv")) {
            //    glClearNamedFramebufferuiv = (delegate* unmanaged<GLuint, GLenum, GLint, GLuint[], void>)GetProcAddress("glClearNamedFramebufferuiv");
            //}
            //if (config == null || config.Contains("glClearPixelLocalStorageuiEXT")) {
            //    glClearPixelLocalStorageuiEXT = (delegate* unmanaged<GLsizei, GLsizei, GLuint[], void>)GetProcAddress("glClearPixelLocalStorageuiEXT");
            //}
            //if (config == null || config.Contains("glClearStencil")) {
            //    glClearStencil = (delegate* unmanaged<GLint, void>)GetProcAddress("glClearStencil");
            //}
            //if (config == null || config.Contains("glClearTexImage")) {
            //    glClearTexImage = (delegate* unmanaged<GLuint, GLint, GLenum, GLenum, IntPtr, void>)GetProcAddress("glClearTexImage");
            //}
            //if (config == null || config.Contains("glClearTexImageEXT")) {
            //    glClearTexImageEXT = (delegate* unmanaged<GLuint, GLint, GLenum, GLenum, IntPtr, void>)GetProcAddress("glClearTexImageEXT");
            //}
            //if (config == null || config.Contains("glClearTexSubImage")) {
            //    glClearTexSubImage = (delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glClearTexSubImage");
            //}
            //if (config == null || config.Contains("glClearTexSubImageEXT")) {
            //    glClearTexSubImageEXT = (delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glClearTexSubImageEXT");
            //}
            //if (config == null || config.Contains("glClientActiveTexture")) {
            //    glClientActiveTexture = (delegate* unmanaged<GLenum, void>)GetProcAddress("glClientActiveTexture");
            //}
            //if (config == null || config.Contains("glClientActiveTextureARB")) {
            //    glClientActiveTextureARB = (delegate* unmanaged<GLenum, void>)GetProcAddress("glClientActiveTextureARB");
            //}
            //if (config == null || config.Contains("glClientActiveVertexStreamATI")) {
            //    glClientActiveVertexStreamATI = (delegate* unmanaged<GLenum, void>)GetProcAddress("glClientActiveVertexStreamATI");
            //}
            //if (config == null || config.Contains("glClientAttribDefaultEXT")) {
            //    glClientAttribDefaultEXT = (delegate* unmanaged<GLbitfield, void>)GetProcAddress("glClientAttribDefaultEXT");
            //}
            //if (config == null || config.Contains("glClientWaitSemaphoreui64NVX")) {
            //    glClientWaitSemaphoreui64NVX = (delegate* unmanaged<GLsizei, GLuint[], GLuint64[], void>)GetProcAddress("glClientWaitSemaphoreui64NVX");
            //}
            //if (config == null || config.Contains("glClientWaitSync")) {
            //    glClientWaitSync = (delegate* unmanaged<GLsync, GLbitfield, GLuint64, GLenum>)GetProcAddress("glClientWaitSync");
            //}
            //if (config == null || config.Contains("glClientWaitSyncAPPLE")) {
            //    glClientWaitSyncAPPLE = (delegate* unmanaged<GLsync, GLbitfield, GLuint64, GLenum>)GetProcAddress("glClientWaitSyncAPPLE");
            //}
            //if (config == null || config.Contains("glClipControl")) {
            //    glClipControl = (delegate* unmanaged<GLenum, GLenum, void>)GetProcAddress("glClipControl");
            //}
            //if (config == null || config.Contains("glClipControlEXT")) {
            //    glClipControlEXT = (delegate* unmanaged<GLenum, GLenum, void>)GetProcAddress("glClipControlEXT");
            //}
            //if (config == null || config.Contains("glClipPlane")) {
            //    glClipPlane = (delegate* unmanaged<GLenum, GLdouble[], void>)GetProcAddress("glClipPlane");
            //}
            //if (config == null || config.Contains("glClipPlanef")) {
            //    glClipPlanef = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glClipPlanef");
            //}
            //if (config == null || config.Contains("glClipPlanefIMG")) {
            //    glClipPlanefIMG = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glClipPlanefIMG");
            //}
            //if (config == null || config.Contains("glClipPlanefOES")) {
            //    glClipPlanefOES = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glClipPlanefOES");
            //}
            //if (config == null || config.Contains("glClipPlanex")) {
            //    glClipPlanex = (delegate* unmanaged<GLenum, GLfixed[], void>)GetProcAddress("glClipPlanex");
            //}
            //if (config == null || config.Contains("glClipPlanexIMG")) {
            //    glClipPlanexIMG = (delegate* unmanaged<GLenum, GLfixed[], void>)GetProcAddress("glClipPlanexIMG");
            //}
            //if (config == null || config.Contains("glClipPlanexOES")) {
            //    glClipPlanexOES = (delegate* unmanaged<GLenum, GLfixed[], void>)GetProcAddress("glClipPlanexOES");
            //}
            //if (config == null || config.Contains("glColor3b")) {
            //    glColor3b = (delegate* unmanaged<GLbyte, GLbyte, GLbyte, void>)GetProcAddress("glColor3b");
            //}
            //if (config == null || config.Contains("glColor3bv")) {
            //    glColor3bv = (delegate* unmanaged<GLbyte[], void>)GetProcAddress("glColor3bv");
            //}
            //if (config == null || config.Contains("glColor3d")) {
            //    glColor3d = (delegate* unmanaged<GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glColor3d");
            //}
            //if (config == null || config.Contains("glColor3dv")) {
            //    glColor3dv = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glColor3dv");
            //}
            //if (config == null || config.Contains("glColor3f")) {
            //    glColor3f = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glColor3f");
            //}
            //if (config == null || config.Contains("glColor3fVertex3fSUN")) {
            //    glColor3fVertex3fSUN = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glColor3fVertex3fSUN");
            //}
            //if (config == null || config.Contains("glColor3fVertex3fvSUN")) {
            //    glColor3fVertex3fvSUN = (delegate* unmanaged<GLfloat[], GLfloat[], void>)GetProcAddress("glColor3fVertex3fvSUN");
            //}
            //if (config == null || config.Contains("glColor3fv")) {
            //    glColor3fv = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glColor3fv");
            //}
            //if (config == null || config.Contains("glColor3hNV")) {
            //    glColor3hNV = (delegate* unmanaged<GLhalfNV, GLhalfNV, GLhalfNV, void>)GetProcAddress("glColor3hNV");
            //}
            //if (config == null || config.Contains("glColor3hvNV")) {
            //    glColor3hvNV = (delegate* unmanaged<GLhalfNV[], void>)GetProcAddress("glColor3hvNV");
            //}
            //if (config == null || config.Contains("glColor3i")) {
            //    glColor3i = (delegate* unmanaged<GLint, GLint, GLint, void>)GetProcAddress("glColor3i");
            //}
            //if (config == null || config.Contains("glColor3iv")) {
            //    glColor3iv = (delegate* unmanaged<GLint[], void>)GetProcAddress("glColor3iv");
            //}
            //if (config == null || config.Contains("glColor3s")) {
            //    glColor3s = (delegate* unmanaged<GLshort, GLshort, GLshort, void>)GetProcAddress("glColor3s");
            //}
            //if (config == null || config.Contains("glColor3sv")) {
            //    glColor3sv = (delegate* unmanaged<GLshort[], void>)GetProcAddress("glColor3sv");
            //}
            //if (config == null || config.Contains("glColor3ub")) {
            //    glColor3ub = (delegate* unmanaged<GLubyte, GLubyte, GLubyte, void>)GetProcAddress("glColor3ub");
            //}
            //if (config == null || config.Contains("glColor3ubv")) {
            //    glColor3ubv = (delegate* unmanaged<GLubyte[], void>)GetProcAddress("glColor3ubv");
            //}
            //if (config == null || config.Contains("glColor3ui")) {
            //    glColor3ui = (delegate* unmanaged<GLuint, GLuint, GLuint, void>)GetProcAddress("glColor3ui");
            //}
            //if (config == null || config.Contains("glColor3uiv")) {
            //    glColor3uiv = (delegate* unmanaged<GLuint[], void>)GetProcAddress("glColor3uiv");
            //}
            //if (config == null || config.Contains("glColor3us")) {
            //    glColor3us = (delegate* unmanaged<GLushort, GLushort, GLushort, void>)GetProcAddress("glColor3us");
            //}
            //if (config == null || config.Contains("glColor3usv")) {
            //    glColor3usv = (delegate* unmanaged<GLushort[], void>)GetProcAddress("glColor3usv");
            //}
            //if (config == null || config.Contains("glColor3xOES")) {
            //    glColor3xOES = (delegate* unmanaged<GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glColor3xOES");
            //}
            //if (config == null || config.Contains("glColor3xvOES")) {
            //    glColor3xvOES = (delegate* unmanaged<GLfixed[], void>)GetProcAddress("glColor3xvOES");
            //}
            //if (config == null || config.Contains("glColor4b")) {
            //    glColor4b = (delegate* unmanaged<GLbyte, GLbyte, GLbyte, GLbyte, void>)GetProcAddress("glColor4b");
            //}
            //if (config == null || config.Contains("glColor4bv")) {
            //    glColor4bv = (delegate* unmanaged<GLbyte[], void>)GetProcAddress("glColor4bv");
            //}
            //if (config == null || config.Contains("glColor4d")) {
            //    glColor4d = (delegate* unmanaged<GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glColor4d");
            //}
            //if (config == null || config.Contains("glColor4dv")) {
            //    glColor4dv = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glColor4dv");
            //}
            //if (config == null || config.Contains("glColor4f")) {
            //    glColor4f = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glColor4f");
            //}
            //if (config == null || config.Contains("glColor4fNormal3fVertex3fSUN")) {
            //    glColor4fNormal3fVertex3fSUN = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glColor4fNormal3fVertex3fSUN");
            //}
            //if (config == null || config.Contains("glColor4fNormal3fVertex3fvSUN")) {
            //    glColor4fNormal3fVertex3fvSUN = (delegate* unmanaged<GLfloat[], GLfloat[], GLfloat[], void>)GetProcAddress("glColor4fNormal3fVertex3fvSUN");
            //}
            //if (config == null || config.Contains("glColor4fv")) {
            //    glColor4fv = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glColor4fv");
            //}
            //if (config == null || config.Contains("glColor4hNV")) {
            //    glColor4hNV = (delegate* unmanaged<GLhalfNV, GLhalfNV, GLhalfNV, GLhalfNV, void>)GetProcAddress("glColor4hNV");
            //}
            //if (config == null || config.Contains("glColor4hvNV")) {
            //    glColor4hvNV = (delegate* unmanaged<GLhalfNV[], void>)GetProcAddress("glColor4hvNV");
            //}
            //if (config == null || config.Contains("glColor4i")) {
            //    glColor4i = (delegate* unmanaged<GLint, GLint, GLint, GLint, void>)GetProcAddress("glColor4i");
            //}
            //if (config == null || config.Contains("glColor4iv")) {
            //    glColor4iv = (delegate* unmanaged<GLint[], void>)GetProcAddress("glColor4iv");
            //}
            //if (config == null || config.Contains("glColor4s")) {
            //    glColor4s = (delegate* unmanaged<GLshort, GLshort, GLshort, GLshort, void>)GetProcAddress("glColor4s");
            //}
            //if (config == null || config.Contains("glColor4sv")) {
            //    glColor4sv = (delegate* unmanaged<GLshort[], void>)GetProcAddress("glColor4sv");
            //}
            //if (config == null || config.Contains("glColor4ub")) {
            //    glColor4ub = (delegate* unmanaged<GLubyte, GLubyte, GLubyte, GLubyte, void>)GetProcAddress("glColor4ub");
            //}
            //if (config == null || config.Contains("glColor4ubVertex2fSUN")) {
            //    glColor4ubVertex2fSUN = (delegate* unmanaged<GLubyte, GLubyte, GLubyte, GLubyte, GLfloat, GLfloat, void>)GetProcAddress("glColor4ubVertex2fSUN");
            //}
            //if (config == null || config.Contains("glColor4ubVertex2fvSUN")) {
            //    glColor4ubVertex2fvSUN = (delegate* unmanaged<GLubyte[], GLfloat[], void>)GetProcAddress("glColor4ubVertex2fvSUN");
            //}
            //if (config == null || config.Contains("glColor4ubVertex3fSUN")) {
            //    glColor4ubVertex3fSUN = (delegate* unmanaged<GLubyte, GLubyte, GLubyte, GLubyte, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glColor4ubVertex3fSUN");
            //}
            //if (config == null || config.Contains("glColor4ubVertex3fvSUN")) {
            //    glColor4ubVertex3fvSUN = (delegate* unmanaged<GLubyte[], GLfloat[], void>)GetProcAddress("glColor4ubVertex3fvSUN");
            //}
            //if (config == null || config.Contains("glColor4ubv")) {
            //    glColor4ubv = (delegate* unmanaged<GLubyte[], void>)GetProcAddress("glColor4ubv");
            //}
            //if (config == null || config.Contains("glColor4ui")) {
            //    glColor4ui = (delegate* unmanaged<GLuint, GLuint, GLuint, GLuint, void>)GetProcAddress("glColor4ui");
            //}
            //if (config == null || config.Contains("glColor4uiv")) {
            //    glColor4uiv = (delegate* unmanaged<GLuint[], void>)GetProcAddress("glColor4uiv");
            //}
            //if (config == null || config.Contains("glColor4us")) {
            //    glColor4us = (delegate* unmanaged<GLushort, GLushort, GLushort, GLushort, void>)GetProcAddress("glColor4us");
            //}
            //if (config == null || config.Contains("glColor4usv")) {
            //    glColor4usv = (delegate* unmanaged<GLushort[], void>)GetProcAddress("glColor4usv");
            //}
            //if (config == null || config.Contains("glColor4x")) {
            //    glColor4x = (delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glColor4x");
            //}
            //if (config == null || config.Contains("glColor4xOES")) {
            //    glColor4xOES = (delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glColor4xOES");
            //}
            //if (config == null || config.Contains("glColor4xvOES")) {
            //    glColor4xvOES = (delegate* unmanaged<GLfixed[], void>)GetProcAddress("glColor4xvOES");
            //}
            //if (config == null || config.Contains("glColorFormatNV")) {
            //    glColorFormatNV = (delegate* unmanaged<GLint, GLenum, GLsizei, void>)GetProcAddress("glColorFormatNV");
            //}
            //if (config == null || config.Contains("glColorFragmentOp1ATI")) {
            //    glColorFragmentOp1ATI = (delegate* unmanaged<GLenum, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, void>)GetProcAddress("glColorFragmentOp1ATI");
            //}
            //if (config == null || config.Contains("glColorFragmentOp2ATI")) {
            //    glColorFragmentOp2ATI = (delegate* unmanaged<GLenum, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, void>)GetProcAddress("glColorFragmentOp2ATI");
            //}
            //if (config == null || config.Contains("glColorFragmentOp3ATI")) {
            //    glColorFragmentOp3ATI = (delegate* unmanaged<GLenum, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, void>)GetProcAddress("glColorFragmentOp3ATI");
            //}
            //if (config == null || config.Contains("glColorMask")) {
            //    glColorMask = (delegate* unmanaged<GLboolean, GLboolean, GLboolean, GLboolean, void>)GetProcAddress("glColorMask");
            //}
            //if (config == null || config.Contains("glColorMaskIndexedEXT")) {
            //    glColorMaskIndexedEXT = (delegate* unmanaged<GLuint, GLboolean, GLboolean, GLboolean, GLboolean, void>)GetProcAddress("glColorMaskIndexedEXT");
            //}
            //if (config == null || config.Contains("glColorMaski")) {
            //    glColorMaski = (delegate* unmanaged<GLuint, GLboolean, GLboolean, GLboolean, GLboolean, void>)GetProcAddress("glColorMaski");
            //}
            //if (config == null || config.Contains("glColorMaskiEXT")) {
            //    glColorMaskiEXT = (delegate* unmanaged<GLuint, GLboolean, GLboolean, GLboolean, GLboolean, void>)GetProcAddress("glColorMaskiEXT");
            //}
            //if (config == null || config.Contains("glColorMaskiOES")) {
            //    glColorMaskiOES = (delegate* unmanaged<GLuint, GLboolean, GLboolean, GLboolean, GLboolean, void>)GetProcAddress("glColorMaskiOES");
            //}
            //if (config == null || config.Contains("glColorMaterial")) {
            //    glColorMaterial = (delegate* unmanaged<GLenum, GLenum, void>)GetProcAddress("glColorMaterial");
            //}
            //if (config == null || config.Contains("glColorP3ui")) {
            //    glColorP3ui = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glColorP3ui");
            //}
            //if (config == null || config.Contains("glColorP3uiv")) {
            //    glColorP3uiv = (delegate* unmanaged<GLenum, GLuint[], void>)GetProcAddress("glColorP3uiv");
            //}
            //if (config == null || config.Contains("glColorP4ui")) {
            //    glColorP4ui = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glColorP4ui");
            //}
            //if (config == null || config.Contains("glColorP4uiv")) {
            //    glColorP4uiv = (delegate* unmanaged<GLenum, GLuint[], void>)GetProcAddress("glColorP4uiv");
            //}
            //if (config == null || config.Contains("glColorPointer")) {
            //    glColorPointer = (delegate* unmanaged<GLint, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glColorPointer");
            //}
            //if (config == null || config.Contains("glColorPointerEXT")) {
            //    glColorPointerEXT = (delegate* unmanaged<GLint, GLenum, GLsizei, GLsizei, IntPtr, void>)GetProcAddress("glColorPointerEXT");
            //}
            //if (config == null || config.Contains("glColorPointerListIBM")) {
            //    glColorPointerListIBM = (delegate* unmanaged<GLint, GLenum, GLint, IntPtr, GLint, void>)GetProcAddress("glColorPointerListIBM");
            //}
            //if (config == null || config.Contains("glColorPointervINTEL")) {
            //    glColorPointervINTEL = (delegate* unmanaged<GLint, GLenum, IntPtr, void>)GetProcAddress("glColorPointervINTEL");
            //}
            //if (config == null || config.Contains("glColorSubTable")) {
            //    glColorSubTable = (delegate* unmanaged<GLenum, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glColorSubTable");
            //}
            //if (config == null || config.Contains("glColorSubTableEXT")) {
            //    glColorSubTableEXT = (delegate* unmanaged<GLenum, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glColorSubTableEXT");
            //}
            //if (config == null || config.Contains("glColorTable")) {
            //    glColorTable = (delegate* unmanaged<GLenum, GLenum, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glColorTable");
            //}
            //if (config == null || config.Contains("glColorTableEXT")) {
            //    glColorTableEXT = (delegate* unmanaged<GLenum, GLenum, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glColorTableEXT");
            //}
            //if (config == null || config.Contains("glColorTableParameterfv")) {
            //    glColorTableParameterfv = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glColorTableParameterfv");
            //}
            //if (config == null || config.Contains("glColorTableParameterfvSGI")) {
            //    glColorTableParameterfvSGI = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glColorTableParameterfvSGI");
            //}
            //if (config == null || config.Contains("glColorTableParameteriv")) {
            //    glColorTableParameteriv = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glColorTableParameteriv");
            //}
            //if (config == null || config.Contains("glColorTableParameterivSGI")) {
            //    glColorTableParameterivSGI = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glColorTableParameterivSGI");
            //}
            //if (config == null || config.Contains("glColorTableSGI")) {
            //    glColorTableSGI = (delegate* unmanaged<GLenum, GLenum, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glColorTableSGI");
            //}
            //if (config == null || config.Contains("glCombinerInputNV")) {
            //    glCombinerInputNV = (delegate* unmanaged<GLenum, GLenum, GLenum, GLenum, GLenum, GLenum, void>)GetProcAddress("glCombinerInputNV");
            //}
            //if (config == null || config.Contains("glCombinerOutputNV")) {
            //    glCombinerOutputNV = (delegate* unmanaged<GLenum, GLenum, GLenum, GLenum, GLenum, GLenum, GLenum, GLboolean, GLboolean, GLboolean, void>)GetProcAddress("glCombinerOutputNV");
            //}
            //if (config == null || config.Contains("glCombinerParameterfNV")) {
            //    glCombinerParameterfNV = (delegate* unmanaged<GLenum, GLfloat, void>)GetProcAddress("glCombinerParameterfNV");
            //}
            //if (config == null || config.Contains("glCombinerParameterfvNV")) {
            //    glCombinerParameterfvNV = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glCombinerParameterfvNV");
            //}
            //if (config == null || config.Contains("glCombinerParameteriNV")) {
            //    glCombinerParameteriNV = (delegate* unmanaged<GLenum, GLint, void>)GetProcAddress("glCombinerParameteriNV");
            //}
            //if (config == null || config.Contains("glCombinerParameterivNV")) {
            //    glCombinerParameterivNV = (delegate* unmanaged<GLenum, GLint[], void>)GetProcAddress("glCombinerParameterivNV");
            //}
            //if (config == null || config.Contains("glCombinerStageParameterfvNV")) {
            //    glCombinerStageParameterfvNV = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glCombinerStageParameterfvNV");
            //}
            //if (config == null || config.Contains("glCommandListSegmentsNV")) {
            //    glCommandListSegmentsNV = (delegate* unmanaged<GLuint, GLuint, void>)GetProcAddress("glCommandListSegmentsNV");
            //}
            //if (config == null || config.Contains("glCompileCommandListNV")) {
            //    glCompileCommandListNV = (delegate* unmanaged<GLuint, void>)GetProcAddress("glCompileCommandListNV");
            //}
            //if (config == null || config.Contains("glCompileShader")) {
            //    glCompileShader = (delegate* unmanaged<GLuint, void>)GetProcAddress("glCompileShader");
            //}
            //if (config == null || config.Contains("glCompileShaderARB")) {
            //    glCompileShaderARB = (delegate* unmanaged<GLhandleARB, void>)GetProcAddress("glCompileShaderARB");
            //}
            //if (config == null || config.Contains("glCompileShaderIncludeARB")) {
            //    glCompileShaderIncludeARB = (delegate* unmanaged<GLuint, GLsizei, string[], GLint[], void>)GetProcAddress("glCompileShaderIncludeARB");
            //}
            //if (config == null || config.Contains("glCompressedMultiTexImage1DEXT")) {
            //    glCompressedMultiTexImage1DEXT = (delegate* unmanaged<GLenum, GLenum, GLint, GLenum, GLsizei, GLint, GLsizei, IntPtr, void>)GetProcAddress("glCompressedMultiTexImage1DEXT");
            //}
            //if (config == null || config.Contains("glCompressedMultiTexImage2DEXT")) {
            //    glCompressedMultiTexImage2DEXT = (delegate* unmanaged<GLenum, GLenum, GLint, GLenum, GLsizei, GLsizei, GLint, GLsizei, IntPtr, void>)GetProcAddress("glCompressedMultiTexImage2DEXT");
            //}
            //if (config == null || config.Contains("glCompressedMultiTexImage3DEXT")) {
            //    glCompressedMultiTexImage3DEXT = (delegate* unmanaged<GLenum, GLenum, GLint, GLenum, GLsizei, GLsizei, GLsizei, GLint, GLsizei, IntPtr, void>)GetProcAddress("glCompressedMultiTexImage3DEXT");
            //}
            //if (config == null || config.Contains("glCompressedMultiTexSubImage1DEXT")) {
            //    glCompressedMultiTexSubImage1DEXT = (delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLsizei, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glCompressedMultiTexSubImage1DEXT");
            //}
            //if (config == null || config.Contains("glCompressedMultiTexSubImage2DEXT")) {
            //    glCompressedMultiTexSubImage2DEXT = (delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLint, GLsizei, GLsizei, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glCompressedMultiTexSubImage2DEXT");
            //}
            //if (config == null || config.Contains("glCompressedMultiTexSubImage3DEXT")) {
            //    glCompressedMultiTexSubImage3DEXT = (delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glCompressedMultiTexSubImage3DEXT");
            //}
            //if (config == null || config.Contains("glCompressedTexImage1D")) {
            //    glCompressedTexImage1D = (delegate* unmanaged<GLenum, GLint, GLenum, GLsizei, GLint, GLsizei, IntPtr, void>)GetProcAddress("glCompressedTexImage1D");
            //}
            //if (config == null || config.Contains("glCompressedTexImage1DARB")) {
            //    glCompressedTexImage1DARB = (delegate* unmanaged<GLenum, GLint, GLenum, GLsizei, GLint, GLsizei, IntPtr, void>)GetProcAddress("glCompressedTexImage1DARB");
            //}
            //if (config == null || config.Contains("glCompressedTexImage2D")) {
            //    glCompressedTexImage2D = (delegate* unmanaged<GLenum, GLint, GLenum, GLsizei, GLsizei, GLint, GLsizei, IntPtr, void>)GetProcAddress("glCompressedTexImage2D");
            //}
            //if (config == null || config.Contains("glCompressedTexImage2DARB")) {
            //    glCompressedTexImage2DARB = (delegate* unmanaged<GLenum, GLint, GLenum, GLsizei, GLsizei, GLint, GLsizei, IntPtr, void>)GetProcAddress("glCompressedTexImage2DARB");
            //}
            //if (config == null || config.Contains("glCompressedTexImage3D")) {
            //    glCompressedTexImage3D = (delegate* unmanaged<GLenum, GLint, GLenum, GLsizei, GLsizei, GLsizei, GLint, GLsizei, IntPtr, void>)GetProcAddress("glCompressedTexImage3D");
            //}
            //if (config == null || config.Contains("glCompressedTexImage3DARB")) {
            //    glCompressedTexImage3DARB = (delegate* unmanaged<GLenum, GLint, GLenum, GLsizei, GLsizei, GLsizei, GLint, GLsizei, IntPtr, void>)GetProcAddress("glCompressedTexImage3DARB");
            //}
            //if (config == null || config.Contains("glCompressedTexImage3DOES")) {
            //    glCompressedTexImage3DOES = (delegate* unmanaged<GLenum, GLint, GLenum, GLsizei, GLsizei, GLsizei, GLint, GLsizei, IntPtr, void>)GetProcAddress("glCompressedTexImage3DOES");
            //}
            //if (config == null || config.Contains("glCompressedTexSubImage1D")) {
            //    glCompressedTexSubImage1D = (delegate* unmanaged<GLenum, GLint, GLint, GLsizei, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glCompressedTexSubImage1D");
            //}
            //if (config == null || config.Contains("glCompressedTexSubImage1DARB")) {
            //    glCompressedTexSubImage1DARB = (delegate* unmanaged<GLenum, GLint, GLint, GLsizei, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glCompressedTexSubImage1DARB");
            //}
            //if (config == null || config.Contains("glCompressedTexSubImage2D")) {
            //    glCompressedTexSubImage2D = (delegate* unmanaged<GLenum, GLint, GLint, GLint, GLsizei, GLsizei, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glCompressedTexSubImage2D");
            //}
            //if (config == null || config.Contains("glCompressedTexSubImage2DARB")) {
            //    glCompressedTexSubImage2DARB = (delegate* unmanaged<GLenum, GLint, GLint, GLint, GLsizei, GLsizei, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glCompressedTexSubImage2DARB");
            //}
            //if (config == null || config.Contains("glCompressedTexSubImage3D")) {
            //    glCompressedTexSubImage3D = (delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glCompressedTexSubImage3D");
            //}
            //if (config == null || config.Contains("glCompressedTexSubImage3DARB")) {
            //    glCompressedTexSubImage3DARB = (delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glCompressedTexSubImage3DARB");
            //}
            //if (config == null || config.Contains("glCompressedTexSubImage3DOES")) {
            //    glCompressedTexSubImage3DOES = (delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glCompressedTexSubImage3DOES");
            //}
            //if (config == null || config.Contains("glCompressedTextureImage1DEXT")) {
            //    glCompressedTextureImage1DEXT = (delegate* unmanaged<GLuint, GLenum, GLint, GLenum, GLsizei, GLint, GLsizei, IntPtr, void>)GetProcAddress("glCompressedTextureImage1DEXT");
            //}
            //if (config == null || config.Contains("glCompressedTextureImage2DEXT")) {
            //    glCompressedTextureImage2DEXT = (delegate* unmanaged<GLuint, GLenum, GLint, GLenum, GLsizei, GLsizei, GLint, GLsizei, IntPtr, void>)GetProcAddress("glCompressedTextureImage2DEXT");
            //}
            //if (config == null || config.Contains("glCompressedTextureImage3DEXT")) {
            //    glCompressedTextureImage3DEXT = (delegate* unmanaged<GLuint, GLenum, GLint, GLenum, GLsizei, GLsizei, GLsizei, GLint, GLsizei, IntPtr, void>)GetProcAddress("glCompressedTextureImage3DEXT");
            //}
            //if (config == null || config.Contains("glCompressedTextureSubImage1D")) {
            //    glCompressedTextureSubImage1D = (delegate* unmanaged<GLuint, GLint, GLint, GLsizei, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glCompressedTextureSubImage1D");
            //}
            //if (config == null || config.Contains("glCompressedTextureSubImage1DEXT")) {
            //    glCompressedTextureSubImage1DEXT = (delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLsizei, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glCompressedTextureSubImage1DEXT");
            //}
            //if (config == null || config.Contains("glCompressedTextureSubImage2D")) {
            //    glCompressedTextureSubImage2D = (delegate* unmanaged<GLuint, GLint, GLint, GLint, GLsizei, GLsizei, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glCompressedTextureSubImage2D");
            //}
            //if (config == null || config.Contains("glCompressedTextureSubImage2DEXT")) {
            //    glCompressedTextureSubImage2DEXT = (delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLint, GLsizei, GLsizei, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glCompressedTextureSubImage2DEXT");
            //}
            //if (config == null || config.Contains("glCompressedTextureSubImage3D")) {
            //    glCompressedTextureSubImage3D = (delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glCompressedTextureSubImage3D");
            //}
            //if (config == null || config.Contains("glCompressedTextureSubImage3DEXT")) {
            //    glCompressedTextureSubImage3DEXT = (delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glCompressedTextureSubImage3DEXT");
            //}
            //if (config == null || config.Contains("glConservativeRasterParameterfNV")) {
            //    glConservativeRasterParameterfNV = (delegate* unmanaged<GLenum, GLfloat, void>)GetProcAddress("glConservativeRasterParameterfNV");
            //}
            //if (config == null || config.Contains("glConservativeRasterParameteriNV")) {
            //    glConservativeRasterParameteriNV = (delegate* unmanaged<GLenum, GLint, void>)GetProcAddress("glConservativeRasterParameteriNV");
            //}
            //if (config == null || config.Contains("glConvolutionFilter1D")) {
            //    glConvolutionFilter1D = (delegate* unmanaged<GLenum, GLenum, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glConvolutionFilter1D");
            //}
            //if (config == null || config.Contains("glConvolutionFilter1DEXT")) {
            //    glConvolutionFilter1DEXT = (delegate* unmanaged<GLenum, GLenum, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glConvolutionFilter1DEXT");
            //}
            //if (config == null || config.Contains("glConvolutionFilter2D")) {
            //    glConvolutionFilter2D = (delegate* unmanaged<GLenum, GLenum, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glConvolutionFilter2D");
            //}
            //if (config == null || config.Contains("glConvolutionFilter2DEXT")) {
            //    glConvolutionFilter2DEXT = (delegate* unmanaged<GLenum, GLenum, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glConvolutionFilter2DEXT");
            //}
            //if (config == null || config.Contains("glConvolutionParameterf")) {
            //    glConvolutionParameterf = (delegate* unmanaged<GLenum, GLenum, GLfloat, void>)GetProcAddress("glConvolutionParameterf");
            //}
            //if (config == null || config.Contains("glConvolutionParameterfEXT")) {
            //    glConvolutionParameterfEXT = (delegate* unmanaged<GLenum, GLenum, GLfloat, void>)GetProcAddress("glConvolutionParameterfEXT");
            //}
            //if (config == null || config.Contains("glConvolutionParameterfv")) {
            //    glConvolutionParameterfv = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glConvolutionParameterfv");
            //}
            //if (config == null || config.Contains("glConvolutionParameterfvEXT")) {
            //    glConvolutionParameterfvEXT = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glConvolutionParameterfvEXT");
            //}
            //if (config == null || config.Contains("glConvolutionParameteri")) {
            //    glConvolutionParameteri = (delegate* unmanaged<GLenum, GLenum, GLint, void>)GetProcAddress("glConvolutionParameteri");
            //}
            //if (config == null || config.Contains("glConvolutionParameteriEXT")) {
            //    glConvolutionParameteriEXT = (delegate* unmanaged<GLenum, GLenum, GLint, void>)GetProcAddress("glConvolutionParameteriEXT");
            //}
            //if (config == null || config.Contains("glConvolutionParameteriv")) {
            //    glConvolutionParameteriv = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glConvolutionParameteriv");
            //}
            //if (config == null || config.Contains("glConvolutionParameterivEXT")) {
            //    glConvolutionParameterivEXT = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glConvolutionParameterivEXT");
            //}
            //if (config == null || config.Contains("glConvolutionParameterxOES")) {
            //    glConvolutionParameterxOES = (delegate* unmanaged<GLenum, GLenum, GLfixed, void>)GetProcAddress("glConvolutionParameterxOES");
            //}
            //if (config == null || config.Contains("glConvolutionParameterxvOES")) {
            //    glConvolutionParameterxvOES = (delegate* unmanaged<GLenum, GLenum, GLfixed[], void>)GetProcAddress("glConvolutionParameterxvOES");
            //}
            //if (config == null || config.Contains("glCopyBufferSubData")) {
            //    glCopyBufferSubData = (delegate* unmanaged<GLenum, GLenum, GLintptr, GLintptr, GLsizeiptr, void>)GetProcAddress("glCopyBufferSubData");
            //}
            //if (config == null || config.Contains("glCopyBufferSubDataNV")) {
            //    glCopyBufferSubDataNV = (delegate* unmanaged<GLenum, GLenum, GLintptr, GLintptr, GLsizeiptr, void>)GetProcAddress("glCopyBufferSubDataNV");
            //}
            //if (config == null || config.Contains("glCopyColorSubTable")) {
            //    glCopyColorSubTable = (delegate* unmanaged<GLenum, GLsizei, GLint, GLint, GLsizei, void>)GetProcAddress("glCopyColorSubTable");
            //}
            //if (config == null || config.Contains("glCopyColorSubTableEXT")) {
            //    glCopyColorSubTableEXT = (delegate* unmanaged<GLenum, GLsizei, GLint, GLint, GLsizei, void>)GetProcAddress("glCopyColorSubTableEXT");
            //}
            //if (config == null || config.Contains("glCopyColorTable")) {
            //    glCopyColorTable = (delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLsizei, void>)GetProcAddress("glCopyColorTable");
            //}
            //if (config == null || config.Contains("glCopyColorTableSGI")) {
            //    glCopyColorTableSGI = (delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLsizei, void>)GetProcAddress("glCopyColorTableSGI");
            //}
            //if (config == null || config.Contains("glCopyConvolutionFilter1D")) {
            //    glCopyConvolutionFilter1D = (delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLsizei, void>)GetProcAddress("glCopyConvolutionFilter1D");
            //}
            //if (config == null || config.Contains("glCopyConvolutionFilter1DEXT")) {
            //    glCopyConvolutionFilter1DEXT = (delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLsizei, void>)GetProcAddress("glCopyConvolutionFilter1DEXT");
            //}
            //if (config == null || config.Contains("glCopyConvolutionFilter2D")) {
            //    glCopyConvolutionFilter2D = (delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLsizei, GLsizei, void>)GetProcAddress("glCopyConvolutionFilter2D");
            //}
            //if (config == null || config.Contains("glCopyConvolutionFilter2DEXT")) {
            //    glCopyConvolutionFilter2DEXT = (delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLsizei, GLsizei, void>)GetProcAddress("glCopyConvolutionFilter2DEXT");
            //}
            //if (config == null || config.Contains("glCopyImageSubData")) {
            //    glCopyImageSubData = (delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLint, GLint, GLuint, GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, void>)GetProcAddress("glCopyImageSubData");
            //}
            //if (config == null || config.Contains("glCopyImageSubDataEXT")) {
            //    glCopyImageSubDataEXT = (delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLint, GLint, GLuint, GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, void>)GetProcAddress("glCopyImageSubDataEXT");
            //}
            //if (config == null || config.Contains("glCopyImageSubDataNV")) {
            //    glCopyImageSubDataNV = (delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLint, GLint, GLuint, GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, void>)GetProcAddress("glCopyImageSubDataNV");
            //}
            //if (config == null || config.Contains("glCopyImageSubDataOES")) {
            //    glCopyImageSubDataOES = (delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLint, GLint, GLuint, GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, void>)GetProcAddress("glCopyImageSubDataOES");
            //}
            //if (config == null || config.Contains("glCopyMultiTexImage1DEXT")) {
            //    glCopyMultiTexImage1DEXT = (delegate* unmanaged<GLenum, GLenum, GLint, GLenum, GLint, GLint, GLsizei, GLint, void>)GetProcAddress("glCopyMultiTexImage1DEXT");
            //}
            //if (config == null || config.Contains("glCopyMultiTexImage2DEXT")) {
            //    glCopyMultiTexImage2DEXT = (delegate* unmanaged<GLenum, GLenum, GLint, GLenum, GLint, GLint, GLsizei, GLsizei, GLint, void>)GetProcAddress("glCopyMultiTexImage2DEXT");
            //}
            //if (config == null || config.Contains("glCopyMultiTexSubImage1DEXT")) {
            //    glCopyMultiTexSubImage1DEXT = (delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLint, GLint, GLsizei, void>)GetProcAddress("glCopyMultiTexSubImage1DEXT");
            //}
            //if (config == null || config.Contains("glCopyMultiTexSubImage2DEXT")) {
            //    glCopyMultiTexSubImage2DEXT = (delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, void>)GetProcAddress("glCopyMultiTexSubImage2DEXT");
            //}
            //if (config == null || config.Contains("glCopyMultiTexSubImage3DEXT")) {
            //    glCopyMultiTexSubImage3DEXT = (delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, void>)GetProcAddress("glCopyMultiTexSubImage3DEXT");
            //}
            //if (config == null || config.Contains("glCopyNamedBufferSubData")) {
            //    glCopyNamedBufferSubData = (delegate* unmanaged<GLuint, GLuint, GLintptr, GLintptr, GLsizeiptr, void>)GetProcAddress("glCopyNamedBufferSubData");
            //}
            //if (config == null || config.Contains("glCopyPathNV")) {
            //    glCopyPathNV = (delegate* unmanaged<GLuint, GLuint, void>)GetProcAddress("glCopyPathNV");
            //}
            //if (config == null || config.Contains("glCopyPixels")) {
            //    glCopyPixels = (delegate* unmanaged<GLint, GLint, GLsizei, GLsizei, GLenum, void>)GetProcAddress("glCopyPixels");
            //}
            //if (config == null || config.Contains("glCopyTexImage1D")) {
            //    glCopyTexImage1D = (delegate* unmanaged<GLenum, GLint, GLenum, GLint, GLint, GLsizei, GLint, void>)GetProcAddress("glCopyTexImage1D");
            //}
            //if (config == null || config.Contains("glCopyTexImage1DEXT")) {
            //    glCopyTexImage1DEXT = (delegate* unmanaged<GLenum, GLint, GLenum, GLint, GLint, GLsizei, GLint, void>)GetProcAddress("glCopyTexImage1DEXT");
            //}
            //if (config == null || config.Contains("glCopyTexImage2D")) {
            //    glCopyTexImage2D = (delegate* unmanaged<GLenum, GLint, GLenum, GLint, GLint, GLsizei, GLsizei, GLint, void>)GetProcAddress("glCopyTexImage2D");
            //}
            //if (config == null || config.Contains("glCopyTexImage2DEXT")) {
            //    glCopyTexImage2DEXT = (delegate* unmanaged<GLenum, GLint, GLenum, GLint, GLint, GLsizei, GLsizei, GLint, void>)GetProcAddress("glCopyTexImage2DEXT");
            //}
            //if (config == null || config.Contains("glCopyTexSubImage1D")) {
            //    glCopyTexSubImage1D = (delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLsizei, void>)GetProcAddress("glCopyTexSubImage1D");
            //}
            //if (config == null || config.Contains("glCopyTexSubImage1DEXT")) {
            //    glCopyTexSubImage1DEXT = (delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLsizei, void>)GetProcAddress("glCopyTexSubImage1DEXT");
            //}
            //if (config == null || config.Contains("glCopyTexSubImage2D")) {
            //    glCopyTexSubImage2D = (delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, void>)GetProcAddress("glCopyTexSubImage2D");
            //}
            //if (config == null || config.Contains("glCopyTexSubImage2DEXT")) {
            //    glCopyTexSubImage2DEXT = (delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, void>)GetProcAddress("glCopyTexSubImage2DEXT");
            //}
            //if (config == null || config.Contains("glCopyTexSubImage3D")) {
            //    glCopyTexSubImage3D = (delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, void>)GetProcAddress("glCopyTexSubImage3D");
            //}
            //if (config == null || config.Contains("glCopyTexSubImage3DEXT")) {
            //    glCopyTexSubImage3DEXT = (delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, void>)GetProcAddress("glCopyTexSubImage3DEXT");
            //}
            //if (config == null || config.Contains("glCopyTexSubImage3DOES")) {
            //    glCopyTexSubImage3DOES = (delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, void>)GetProcAddress("glCopyTexSubImage3DOES");
            //}
            //if (config == null || config.Contains("glCopyTextureImage1DEXT")) {
            //    glCopyTextureImage1DEXT = (delegate* unmanaged<GLuint, GLenum, GLint, GLenum, GLint, GLint, GLsizei, GLint, void>)GetProcAddress("glCopyTextureImage1DEXT");
            //}
            //if (config == null || config.Contains("glCopyTextureImage2DEXT")) {
            //    glCopyTextureImage2DEXT = (delegate* unmanaged<GLuint, GLenum, GLint, GLenum, GLint, GLint, GLsizei, GLsizei, GLint, void>)GetProcAddress("glCopyTextureImage2DEXT");
            //}
            //if (config == null || config.Contains("glCopyTextureLevelsAPPLE")) {
            //    glCopyTextureLevelsAPPLE = (delegate* unmanaged<GLuint, GLuint, GLint, GLsizei, void>)GetProcAddress("glCopyTextureLevelsAPPLE");
            //}
            //if (config == null || config.Contains("glCopyTextureSubImage1D")) {
            //    glCopyTextureSubImage1D = (delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, GLsizei, void>)GetProcAddress("glCopyTextureSubImage1D");
            //}
            //if (config == null || config.Contains("glCopyTextureSubImage1DEXT")) {
            //    glCopyTextureSubImage1DEXT = (delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLint, GLint, GLsizei, void>)GetProcAddress("glCopyTextureSubImage1DEXT");
            //}
            //if (config == null || config.Contains("glCopyTextureSubImage2D")) {
            //    glCopyTextureSubImage2D = (delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, void>)GetProcAddress("glCopyTextureSubImage2D");
            //}
            //if (config == null || config.Contains("glCopyTextureSubImage2DEXT")) {
            //    glCopyTextureSubImage2DEXT = (delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, void>)GetProcAddress("glCopyTextureSubImage2DEXT");
            //}
            //if (config == null || config.Contains("glCopyTextureSubImage3D")) {
            //    glCopyTextureSubImage3D = (delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, void>)GetProcAddress("glCopyTextureSubImage3D");
            //}
            //if (config == null || config.Contains("glCopyTextureSubImage3DEXT")) {
            //    glCopyTextureSubImage3DEXT = (delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, void>)GetProcAddress("glCopyTextureSubImage3DEXT");
            //}
            //if (config == null || config.Contains("glCoverFillPathInstancedNV")) {
            //    glCoverFillPathInstancedNV = (delegate* unmanaged<GLsizei, GLenum, IntPtr, GLuint, GLenum, GLenum, GLfloat[], void>)GetProcAddress("glCoverFillPathInstancedNV");
            //}
            //if (config == null || config.Contains("glCoverFillPathNV")) {
            //    glCoverFillPathNV = (delegate* unmanaged<GLuint, GLenum, void>)GetProcAddress("glCoverFillPathNV");
            //}
            //if (config == null || config.Contains("glCoverStrokePathInstancedNV")) {
            //    glCoverStrokePathInstancedNV = (delegate* unmanaged<GLsizei, GLenum, IntPtr, GLuint, GLenum, GLenum, GLfloat[], void>)GetProcAddress("glCoverStrokePathInstancedNV");
            //}
            //if (config == null || config.Contains("glCoverStrokePathNV")) {
            //    glCoverStrokePathNV = (delegate* unmanaged<GLuint, GLenum, void>)GetProcAddress("glCoverStrokePathNV");
            //}
            //if (config == null || config.Contains("glCoverageMaskNV")) {
            //    glCoverageMaskNV = (delegate* unmanaged<GLboolean, void>)GetProcAddress("glCoverageMaskNV");
            //}
            //if (config == null || config.Contains("glCoverageModulationNV")) {
            //    glCoverageModulationNV = (delegate* unmanaged<GLenum, void>)GetProcAddress("glCoverageModulationNV");
            //}
            //if (config == null || config.Contains("glCoverageModulationTableNV")) {
            //    glCoverageModulationTableNV = (delegate* unmanaged<GLsizei, GLfloat[], void>)GetProcAddress("glCoverageModulationTableNV");
            //}
            //if (config == null || config.Contains("glCoverageOperationNV")) {
            //    glCoverageOperationNV = (delegate* unmanaged<GLenum, void>)GetProcAddress("glCoverageOperationNV");
            //}
            //if (config == null || config.Contains("glCreateBuffers")) {
            //    glCreateBuffers = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glCreateBuffers");
            //}
            //if (config == null || config.Contains("glCreateCommandListsNV")) {
            //    glCreateCommandListsNV = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glCreateCommandListsNV");
            //}
            //if (config == null || config.Contains("glCreateFramebuffers")) {
            //    glCreateFramebuffers = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glCreateFramebuffers");
            //}
            //if (config == null || config.Contains("glCreateMemoryObjectsEXT")) {
            //    glCreateMemoryObjectsEXT = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glCreateMemoryObjectsEXT");
            //}
            //if (config == null || config.Contains("glCreatePerfQueryINTEL")) {
            //    glCreatePerfQueryINTEL = (delegate* unmanaged<GLuint, GLuint[], void>)GetProcAddress("glCreatePerfQueryINTEL");
            //}
            //if (config == null || config.Contains("glCreateProgram")) {
            //    glCreateProgram = (delegate* unmanaged<GLuint>)GetProcAddress("glCreateProgram");
            //}
            //if (config == null || config.Contains("glCreateProgramObjectARB")) {
            //    glCreateProgramObjectARB = (delegate* unmanaged<GLhandleARB>)GetProcAddress("glCreateProgramObjectARB");
            //}
            //if (config == null || config.Contains("glCreateProgramPipelines")) {
            //    glCreateProgramPipelines = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glCreateProgramPipelines");
            //}
            //if (config == null || config.Contains("glCreateProgressFenceNVX")) {
            //    glCreateProgressFenceNVX = (delegate* unmanaged<GLuint>)GetProcAddress("glCreateProgressFenceNVX");
            //}
            //if (config == null || config.Contains("glCreateQueries")) {
            //    glCreateQueries = (delegate* unmanaged<GLenum, GLsizei, GLuint[], void>)GetProcAddress("glCreateQueries");
            //}
            //if (config == null || config.Contains("glCreateRenderbuffers")) {
            //    glCreateRenderbuffers = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glCreateRenderbuffers");
            //}
            //if (config == null || config.Contains("glCreateSamplers")) {
            //    glCreateSamplers = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glCreateSamplers");
            //}
            //if (config == null || config.Contains("glCreateShader")) {
            //    glCreateShader = (delegate* unmanaged<GLenum, GLuint>)GetProcAddress("glCreateShader");
            //}
            //if (config == null || config.Contains("glCreateShaderObjectARB")) {
            //    glCreateShaderObjectARB = (delegate* unmanaged<GLenum, GLhandleARB>)GetProcAddress("glCreateShaderObjectARB");
            //}
            //if (config == null || config.Contains("glCreateShaderProgramEXT")) {
            //    glCreateShaderProgramEXT = (delegate* unmanaged<GLenum, string, GLuint>)GetProcAddress("glCreateShaderProgramEXT");
            //}
            //if (config == null || config.Contains("glCreateShaderProgramv")) {
            //    glCreateShaderProgramv = (delegate* unmanaged<GLenum, GLsizei, string[], GLuint>)GetProcAddress("glCreateShaderProgramv");
            //}
            //if (config == null || config.Contains("glCreateShaderProgramvEXT")) {
            //    glCreateShaderProgramvEXT = (delegate* unmanaged<GLenum, GLsizei, string[], GLuint>)GetProcAddress("glCreateShaderProgramvEXT");
            //}
            //if (config == null || config.Contains("glCreateStatesNV")) {
            //    glCreateStatesNV = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glCreateStatesNV");
            //}
            //if (config == null || config.Contains("glCreateSyncFromCLeventARB")) {
            //    glCreateSyncFromCLeventARB = (delegate* unmanaged<IntPtr/*struct_cl_context*/[], IntPtr/*struct_cl_event*/[], GLbitfield, GLsync>)GetProcAddress("glCreateSyncFromCLeventARB");
            //}
            //if (config == null || config.Contains("glCreateTextures")) {
            //    glCreateTextures = (delegate* unmanaged<GLenum, GLsizei, GLuint[], void>)GetProcAddress("glCreateTextures");
            //}
            //if (config == null || config.Contains("glCreateTransformFeedbacks")) {
            //    glCreateTransformFeedbacks = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glCreateTransformFeedbacks");
            //}
            //if (config == null || config.Contains("glCreateVertexArrays")) {
            //    glCreateVertexArrays = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glCreateVertexArrays");
            //}
            //if (config == null || config.Contains("glCullFace")) {
            //    glCullFace = (delegate* unmanaged<GLenum, void>)GetProcAddress("glCullFace");
            //}
            //if (config == null || config.Contains("glCullParameterdvEXT")) {
            //    glCullParameterdvEXT = (delegate* unmanaged<GLenum, GLdouble[], void>)GetProcAddress("glCullParameterdvEXT");
            //}
            //if (config == null || config.Contains("glCullParameterfvEXT")) {
            //    glCullParameterfvEXT = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glCullParameterfvEXT");
            //}
            //if (config == null || config.Contains("glCurrentPaletteMatrixARB")) {
            //    glCurrentPaletteMatrixARB = (delegate* unmanaged<GLint, void>)GetProcAddress("glCurrentPaletteMatrixARB");
            //}
            //if (config == null || config.Contains("glCurrentPaletteMatrixOES")) {
            //    glCurrentPaletteMatrixOES = (delegate* unmanaged<GLuint, void>)GetProcAddress("glCurrentPaletteMatrixOES");
            //}
            //if (config == null || config.Contains("glDebugMessageCallback")) {
            //    glDebugMessageCallback = (delegate* unmanaged<delegate*<GLenum, GLenum, GLuint, GLenum, GLsizei, string, IntPtr>/*GLDEBUGPROC*/, IntPtr, void>)GetProcAddress("glDebugMessageCallback");
            //}
            //if (config == null || config.Contains("glDebugMessageCallbackAMD")) {
            //    glDebugMessageCallbackAMD = (delegate* unmanaged<delegate*<GLuint, GLenum, GLenum, GLsizei, string, IntPtr>/*GLDEBUGPROCAMD*/, IntPtr, void>)GetProcAddress("glDebugMessageCallbackAMD");
            //}
            //if (config == null || config.Contains("glDebugMessageCallbackARB")) {
            //    glDebugMessageCallbackARB = (delegate* unmanaged<delegate*<GLenum, GLenum, GLuint, GLenum, GLsizei, string, IntPtr>/*GLDEBUGPROCARB*/, IntPtr, void>)GetProcAddress("glDebugMessageCallbackARB");
            //}
            //if (config == null || config.Contains("glDebugMessageCallbackKHR")) {
            //    glDebugMessageCallbackKHR = (delegate* unmanaged<delegate*<GLenum, GLenum, GLuint, GLenum, GLsizei, string, IntPtr>/*GLDEBUGPROCKHR*/, IntPtr, void>)GetProcAddress("glDebugMessageCallbackKHR");
            //}
            //if (config == null || config.Contains("glDebugMessageControl")) {
            //    glDebugMessageControl = (delegate* unmanaged<GLenum, GLenum, GLenum, GLsizei, GLuint[], GLboolean, void>)GetProcAddress("glDebugMessageControl");
            //}
            //if (config == null || config.Contains("glDebugMessageControlARB")) {
            //    glDebugMessageControlARB = (delegate* unmanaged<GLenum, GLenum, GLenum, GLsizei, GLuint[], GLboolean, void>)GetProcAddress("glDebugMessageControlARB");
            //}
            //if (config == null || config.Contains("glDebugMessageControlKHR")) {
            //    glDebugMessageControlKHR = (delegate* unmanaged<GLenum, GLenum, GLenum, GLsizei, GLuint[], GLboolean, void>)GetProcAddress("glDebugMessageControlKHR");
            //}
            //if (config == null || config.Contains("glDebugMessageEnableAMD")) {
            //    glDebugMessageEnableAMD = (delegate* unmanaged<GLenum, GLenum, GLsizei, GLuint[], GLboolean, void>)GetProcAddress("glDebugMessageEnableAMD");
            //}
            //if (config == null || config.Contains("glDebugMessageInsert")) {
            //    glDebugMessageInsert = (delegate* unmanaged<GLenum, GLenum, GLuint, GLenum, GLsizei, string, void>)GetProcAddress("glDebugMessageInsert");
            //}
            //if (config == null || config.Contains("glDebugMessageInsertAMD")) {
            //    glDebugMessageInsertAMD = (delegate* unmanaged<GLenum, GLenum, GLuint, GLsizei, string, void>)GetProcAddress("glDebugMessageInsertAMD");
            //}
            //if (config == null || config.Contains("glDebugMessageInsertARB")) {
            //    glDebugMessageInsertARB = (delegate* unmanaged<GLenum, GLenum, GLuint, GLenum, GLsizei, string, void>)GetProcAddress("glDebugMessageInsertARB");
            //}
            //if (config == null || config.Contains("glDebugMessageInsertKHR")) {
            //    glDebugMessageInsertKHR = (delegate* unmanaged<GLenum, GLenum, GLuint, GLenum, GLsizei, string, void>)GetProcAddress("glDebugMessageInsertKHR");
            //}
            //if (config == null || config.Contains("glDeformSGIX")) {
            //    glDeformSGIX = (delegate* unmanaged<GLbitfield, void>)GetProcAddress("glDeformSGIX");
            //}
            //if (config == null || config.Contains("glDeformationMap3dSGIX")) {
            //    glDeformationMap3dSGIX = (delegate* unmanaged<GLenum, GLdouble, GLdouble, GLint, GLint, GLdouble, GLdouble, GLint, GLint, GLdouble, GLdouble, GLint, GLint, GLdouble[], void>)GetProcAddress("glDeformationMap3dSGIX");
            //}
            //if (config == null || config.Contains("glDeformationMap3fSGIX")) {
            //    glDeformationMap3fSGIX = (delegate* unmanaged<GLenum, GLfloat, GLfloat, GLint, GLint, GLfloat, GLfloat, GLint, GLint, GLfloat, GLfloat, GLint, GLint, GLfloat[], void>)GetProcAddress("glDeformationMap3fSGIX");
            //}
            //if (config == null || config.Contains("glDeleteAsyncMarkersSGIX")) {
            //    glDeleteAsyncMarkersSGIX = (delegate* unmanaged<GLuint, GLsizei, void>)GetProcAddress("glDeleteAsyncMarkersSGIX");
            //}
            //if (config == null || config.Contains("glDeleteBuffers")) {
            //    glDeleteBuffers = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteBuffers");
            //}
            //if (config == null || config.Contains("glDeleteBuffersARB")) {
            //    glDeleteBuffersARB = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteBuffersARB");
            //}
            //if (config == null || config.Contains("glDeleteCommandListsNV")) {
            //    glDeleteCommandListsNV = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteCommandListsNV");
            //}
            //if (config == null || config.Contains("glDeleteFencesAPPLE")) {
            //    glDeleteFencesAPPLE = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteFencesAPPLE");
            //}
            //if (config == null || config.Contains("glDeleteFencesNV")) {
            //    glDeleteFencesNV = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteFencesNV");
            //}
            //if (config == null || config.Contains("glDeleteFragmentShaderATI")) {
            //    glDeleteFragmentShaderATI = (delegate* unmanaged<GLuint, void>)GetProcAddress("glDeleteFragmentShaderATI");
            //}
            //if (config == null || config.Contains("glDeleteFramebuffers")) {
            //    glDeleteFramebuffers = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteFramebuffers");
            //}
            //if (config == null || config.Contains("glDeleteFramebuffersEXT")) {
            //    glDeleteFramebuffersEXT = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteFramebuffersEXT");
            //}
            //if (config == null || config.Contains("glDeleteFramebuffersOES")) {
            //    glDeleteFramebuffersOES = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteFramebuffersOES");
            //}
            //if (config == null || config.Contains("glDeleteLists")) {
            //    glDeleteLists = (delegate* unmanaged<GLuint, GLsizei, void>)GetProcAddress("glDeleteLists");
            //}
            //if (config == null || config.Contains("glDeleteMemoryObjectsEXT")) {
            //    glDeleteMemoryObjectsEXT = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteMemoryObjectsEXT");
            //}
            //if (config == null || config.Contains("glDeleteNamedStringARB")) {
            //    glDeleteNamedStringARB = (delegate* unmanaged<GLint, string, void>)GetProcAddress("glDeleteNamedStringARB");
            //}
            //if (config == null || config.Contains("glDeleteNamesAMD")) {
            //    glDeleteNamesAMD = (delegate* unmanaged<GLenum, GLuint, GLuint[], void>)GetProcAddress("glDeleteNamesAMD");
            //}
            //if (config == null || config.Contains("glDeleteObjectARB")) {
            //    glDeleteObjectARB = (delegate* unmanaged<GLhandleARB, void>)GetProcAddress("glDeleteObjectARB");
            //}
            //if (config == null || config.Contains("glDeleteOcclusionQueriesNV")) {
            //    glDeleteOcclusionQueriesNV = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteOcclusionQueriesNV");
            //}
            //if (config == null || config.Contains("glDeletePathsNV")) {
            //    glDeletePathsNV = (delegate* unmanaged<GLuint, GLsizei, void>)GetProcAddress("glDeletePathsNV");
            //}
            //if (config == null || config.Contains("glDeletePerfMonitorsAMD")) {
            //    glDeletePerfMonitorsAMD = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeletePerfMonitorsAMD");
            //}
            //if (config == null || config.Contains("glDeletePerfQueryINTEL")) {
            //    glDeletePerfQueryINTEL = (delegate* unmanaged<GLuint, void>)GetProcAddress("glDeletePerfQueryINTEL");
            //}
            //if (config == null || config.Contains("glDeleteProgram")) {
            //    glDeleteProgram = (delegate* unmanaged<GLuint, void>)GetProcAddress("glDeleteProgram");
            //}
            //if (config == null || config.Contains("glDeleteProgramPipelines")) {
            //    glDeleteProgramPipelines = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteProgramPipelines");
            //}
            //if (config == null || config.Contains("glDeleteProgramPipelinesEXT")) {
            //    glDeleteProgramPipelinesEXT = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteProgramPipelinesEXT");
            //}
            //if (config == null || config.Contains("glDeleteProgramsARB")) {
            //    glDeleteProgramsARB = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteProgramsARB");
            //}
            //if (config == null || config.Contains("glDeleteProgramsNV")) {
            //    glDeleteProgramsNV = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteProgramsNV");
            //}
            //if (config == null || config.Contains("glDeleteQueries")) {
            //    glDeleteQueries = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteQueries");
            //}
            //if (config == null || config.Contains("glDeleteQueriesARB")) {
            //    glDeleteQueriesARB = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteQueriesARB");
            //}
            //if (config == null || config.Contains("glDeleteQueriesEXT")) {
            //    glDeleteQueriesEXT = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteQueriesEXT");
            //}
            //if (config == null || config.Contains("glDeleteQueryResourceTagNV")) {
            //    glDeleteQueryResourceTagNV = (delegate* unmanaged<GLsizei, GLint[], void>)GetProcAddress("glDeleteQueryResourceTagNV");
            //}
            //if (config == null || config.Contains("glDeleteRenderbuffers")) {
            //    glDeleteRenderbuffers = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteRenderbuffers");
            //}
            //if (config == null || config.Contains("glDeleteRenderbuffersEXT")) {
            //    glDeleteRenderbuffersEXT = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteRenderbuffersEXT");
            //}
            //if (config == null || config.Contains("glDeleteRenderbuffersOES")) {
            //    glDeleteRenderbuffersOES = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteRenderbuffersOES");
            //}
            //if (config == null || config.Contains("glDeleteSamplers")) {
            //    glDeleteSamplers = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteSamplers");
            //}
            //if (config == null || config.Contains("glDeleteSemaphoresEXT")) {
            //    glDeleteSemaphoresEXT = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteSemaphoresEXT");
            //}
            //if (config == null || config.Contains("glDeleteShader")) {
            //    glDeleteShader = (delegate* unmanaged<GLuint, void>)GetProcAddress("glDeleteShader");
            //}
            //if (config == null || config.Contains("glDeleteStatesNV")) {
            //    glDeleteStatesNV = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteStatesNV");
            //}
            //if (config == null || config.Contains("glDeleteSync")) {
            //    glDeleteSync = (delegate* unmanaged<GLsync, void>)GetProcAddress("glDeleteSync");
            //}
            //if (config == null || config.Contains("glDeleteSyncAPPLE")) {
            //    glDeleteSyncAPPLE = (delegate* unmanaged<GLsync, void>)GetProcAddress("glDeleteSyncAPPLE");
            //}
            //if (config == null || config.Contains("glDeleteTextures")) {
            //    glDeleteTextures = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteTextures");
            //}
            //if (config == null || config.Contains("glDeleteTexturesEXT")) {
            //    glDeleteTexturesEXT = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteTexturesEXT");
            //}
            //if (config == null || config.Contains("glDeleteTransformFeedbacks")) {
            //    glDeleteTransformFeedbacks = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteTransformFeedbacks");
            //}
            //if (config == null || config.Contains("glDeleteTransformFeedbacksNV")) {
            //    glDeleteTransformFeedbacksNV = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteTransformFeedbacksNV");
            //}
            //if (config == null || config.Contains("glDeleteVertexArrays")) {
            //    glDeleteVertexArrays = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteVertexArrays");
            //}
            //if (config == null || config.Contains("glDeleteVertexArraysAPPLE")) {
            //    glDeleteVertexArraysAPPLE = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteVertexArraysAPPLE");
            //}
            //if (config == null || config.Contains("glDeleteVertexArraysOES")) {
            //    glDeleteVertexArraysOES = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glDeleteVertexArraysOES");
            //}
            //if (config == null || config.Contains("glDeleteVertexShaderEXT")) {
            //    glDeleteVertexShaderEXT = (delegate* unmanaged<GLuint, void>)GetProcAddress("glDeleteVertexShaderEXT");
            //}
            //if (config == null || config.Contains("glDepthBoundsEXT")) {
            //    glDepthBoundsEXT = (delegate* unmanaged<GLclampd, GLclampd, void>)GetProcAddress("glDepthBoundsEXT");
            //}
            //if (config == null || config.Contains("glDepthBoundsdNV")) {
            //    glDepthBoundsdNV = (delegate* unmanaged<GLdouble, GLdouble, void>)GetProcAddress("glDepthBoundsdNV");
            //}
            //if (config == null || config.Contains("glDepthFunc")) {
            //    glDepthFunc = (delegate* unmanaged<GLenum, void>)GetProcAddress("glDepthFunc");
            //}
            //if (config == null || config.Contains("glDepthMask")) {
            //    glDepthMask = (delegate* unmanaged<GLboolean, void>)GetProcAddress("glDepthMask");
            //}
            //if (config == null || config.Contains("glDepthRange")) {
            //    glDepthRange = (delegate* unmanaged<GLdouble, GLdouble, void>)GetProcAddress("glDepthRange");
            //}
            //if (config == null || config.Contains("glDepthRangeArrayfvNV")) {
            //    glDepthRangeArrayfvNV = (delegate* unmanaged<GLuint, GLsizei, GLfloat[], void>)GetProcAddress("glDepthRangeArrayfvNV");
            //}
            //if (config == null || config.Contains("glDepthRangeArrayfvOES")) {
            //    glDepthRangeArrayfvOES = (delegate* unmanaged<GLuint, GLsizei, GLfloat[], void>)GetProcAddress("glDepthRangeArrayfvOES");
            //}
            //if (config == null || config.Contains("glDepthRangeArrayv")) {
            //    glDepthRangeArrayv = (delegate* unmanaged<GLuint, GLsizei, GLdouble[], void>)GetProcAddress("glDepthRangeArrayv");
            //}
            //if (config == null || config.Contains("glDepthRangeIndexed")) {
            //    glDepthRangeIndexed = (delegate* unmanaged<GLuint, GLdouble, GLdouble, void>)GetProcAddress("glDepthRangeIndexed");
            //}
            //if (config == null || config.Contains("glDepthRangeIndexedfNV")) {
            //    glDepthRangeIndexedfNV = (delegate* unmanaged<GLuint, GLfloat, GLfloat, void>)GetProcAddress("glDepthRangeIndexedfNV");
            //}
            //if (config == null || config.Contains("glDepthRangeIndexedfOES")) {
            //    glDepthRangeIndexedfOES = (delegate* unmanaged<GLuint, GLfloat, GLfloat, void>)GetProcAddress("glDepthRangeIndexedfOES");
            //}
            //if (config == null || config.Contains("glDepthRangedNV")) {
            //    glDepthRangedNV = (delegate* unmanaged<GLdouble, GLdouble, void>)GetProcAddress("glDepthRangedNV");
            //}
            //if (config == null || config.Contains("glDepthRangef")) {
            //    glDepthRangef = (delegate* unmanaged<GLfloat, GLfloat, void>)GetProcAddress("glDepthRangef");
            //}
            //if (config == null || config.Contains("glDepthRangefOES")) {
            //    glDepthRangefOES = (delegate* unmanaged<GLclampf, GLclampf, void>)GetProcAddress("glDepthRangefOES");
            //}
            //if (config == null || config.Contains("glDepthRangex")) {
            //    glDepthRangex = (delegate* unmanaged<GLfixed, GLfixed, void>)GetProcAddress("glDepthRangex");
            //}
            //if (config == null || config.Contains("glDepthRangexOES")) {
            //    glDepthRangexOES = (delegate* unmanaged<GLfixed, GLfixed, void>)GetProcAddress("glDepthRangexOES");
            //}
            //if (config == null || config.Contains("glDetachObjectARB")) {
            //    glDetachObjectARB = (delegate* unmanaged<GLhandleARB, GLhandleARB, void>)GetProcAddress("glDetachObjectARB");
            //}
            //if (config == null || config.Contains("glDetachShader")) {
            //    glDetachShader = (delegate* unmanaged<GLuint, GLuint, void>)GetProcAddress("glDetachShader");
            //}
            //if (config == null || config.Contains("glDetailTexFuncSGIS")) {
            //    glDetailTexFuncSGIS = (delegate* unmanaged<GLenum, GLsizei, GLfloat[], void>)GetProcAddress("glDetailTexFuncSGIS");
            //}
            //if (config == null || config.Contains("glDisable")) {
            //    glDisable = (delegate* unmanaged<GLenum, void>)GetProcAddress("glDisable");
            //}
            //if (config == null || config.Contains("glDisableClientState")) {
            //    glDisableClientState = (delegate* unmanaged<GLenum, void>)GetProcAddress("glDisableClientState");
            //}
            //if (config == null || config.Contains("glDisableClientStateIndexedEXT")) {
            //    glDisableClientStateIndexedEXT = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glDisableClientStateIndexedEXT");
            //}
            //if (config == null || config.Contains("glDisableClientStateiEXT")) {
            //    glDisableClientStateiEXT = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glDisableClientStateiEXT");
            //}
            //if (config == null || config.Contains("glDisableDriverControlQCOM")) {
            //    glDisableDriverControlQCOM = (delegate* unmanaged<GLuint, void>)GetProcAddress("glDisableDriverControlQCOM");
            //}
            //if (config == null || config.Contains("glDisableIndexedEXT")) {
            //    glDisableIndexedEXT = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glDisableIndexedEXT");
            //}
            //if (config == null || config.Contains("glDisableVariantClientStateEXT")) {
            //    glDisableVariantClientStateEXT = (delegate* unmanaged<GLuint, void>)GetProcAddress("glDisableVariantClientStateEXT");
            //}
            //if (config == null || config.Contains("glDisableVertexArrayAttrib")) {
            //    glDisableVertexArrayAttrib = (delegate* unmanaged<GLuint, GLuint, void>)GetProcAddress("glDisableVertexArrayAttrib");
            //}
            //if (config == null || config.Contains("glDisableVertexArrayAttribEXT")) {
            //    glDisableVertexArrayAttribEXT = (delegate* unmanaged<GLuint, GLuint, void>)GetProcAddress("glDisableVertexArrayAttribEXT");
            //}
            //if (config == null || config.Contains("glDisableVertexArrayEXT")) {
            //    glDisableVertexArrayEXT = (delegate* unmanaged<GLuint, GLenum, void>)GetProcAddress("glDisableVertexArrayEXT");
            //}
            //if (config == null || config.Contains("glDisableVertexAttribAPPLE")) {
            //    glDisableVertexAttribAPPLE = (delegate* unmanaged<GLuint, GLenum, void>)GetProcAddress("glDisableVertexAttribAPPLE");
            //}
            //if (config == null || config.Contains("glDisableVertexAttribArray")) {
            //    glDisableVertexAttribArray = (delegate* unmanaged<GLuint, void>)GetProcAddress("glDisableVertexAttribArray");
            //}
            //if (config == null || config.Contains("glDisableVertexAttribArrayARB")) {
            //    glDisableVertexAttribArrayARB = (delegate* unmanaged<GLuint, void>)GetProcAddress("glDisableVertexAttribArrayARB");
            //}
            //if (config == null || config.Contains("glDisablei")) {
            //    glDisablei = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glDisablei");
            //}
            //if (config == null || config.Contains("glDisableiEXT")) {
            //    glDisableiEXT = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glDisableiEXT");
            //}
            //if (config == null || config.Contains("glDisableiNV")) {
            //    glDisableiNV = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glDisableiNV");
            //}
            //if (config == null || config.Contains("glDisableiOES")) {
            //    glDisableiOES = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glDisableiOES");
            //}
            //if (config == null || config.Contains("glDiscardFramebufferEXT")) {
            //    glDiscardFramebufferEXT = (delegate* unmanaged<GLenum, GLsizei, GLenum[], void>)GetProcAddress("glDiscardFramebufferEXT");
            //}
            //if (config == null || config.Contains("glDispatchCompute")) {
            //    glDispatchCompute = (delegate* unmanaged<GLuint, GLuint, GLuint, void>)GetProcAddress("glDispatchCompute");
            //}
            //if (config == null || config.Contains("glDispatchComputeGroupSizeARB")) {
            //    glDispatchComputeGroupSizeARB = (delegate* unmanaged<GLuint, GLuint, GLuint, GLuint, GLuint, GLuint, void>)GetProcAddress("glDispatchComputeGroupSizeARB");
            //}
            //if (config == null || config.Contains("glDispatchComputeIndirect")) {
            //    glDispatchComputeIndirect = (delegate* unmanaged<GLintptr, void>)GetProcAddress("glDispatchComputeIndirect");
            //}
            //if (config == null || config.Contains("glDrawArrays")) {
            //    glDrawArrays = (delegate* unmanaged<GLenum, GLint, GLsizei, void>)GetProcAddress("glDrawArrays");
            //}
            //if (config == null || config.Contains("glDrawArraysEXT")) {
            //    glDrawArraysEXT = (delegate* unmanaged<GLenum, GLint, GLsizei, void>)GetProcAddress("glDrawArraysEXT");
            //}
            //if (config == null || config.Contains("glDrawArraysIndirect")) {
            //    glDrawArraysIndirect = (delegate* unmanaged<GLenum, IntPtr, void>)GetProcAddress("glDrawArraysIndirect");
            //}
            //if (config == null || config.Contains("glDrawArraysInstanced")) {
            //    glDrawArraysInstanced = (delegate* unmanaged<GLenum, GLint, GLsizei, GLsizei, void>)GetProcAddress("glDrawArraysInstanced");
            //}
            //if (config == null || config.Contains("glDrawArraysInstancedANGLE")) {
            //    glDrawArraysInstancedANGLE = (delegate* unmanaged<GLenum, GLint, GLsizei, GLsizei, void>)GetProcAddress("glDrawArraysInstancedANGLE");
            //}
            //if (config == null || config.Contains("glDrawArraysInstancedARB")) {
            //    glDrawArraysInstancedARB = (delegate* unmanaged<GLenum, GLint, GLsizei, GLsizei, void>)GetProcAddress("glDrawArraysInstancedARB");
            //}
            //if (config == null || config.Contains("glDrawArraysInstancedBaseInstance")) {
            //    glDrawArraysInstancedBaseInstance = (delegate* unmanaged<GLenum, GLint, GLsizei, GLsizei, GLuint, void>)GetProcAddress("glDrawArraysInstancedBaseInstance");
            //}
            //if (config == null || config.Contains("glDrawArraysInstancedBaseInstanceEXT")) {
            //    glDrawArraysInstancedBaseInstanceEXT = (delegate* unmanaged<GLenum, GLint, GLsizei, GLsizei, GLuint, void>)GetProcAddress("glDrawArraysInstancedBaseInstanceEXT");
            //}
            //if (config == null || config.Contains("glDrawArraysInstancedEXT")) {
            //    glDrawArraysInstancedEXT = (delegate* unmanaged<GLenum, GLint, GLsizei, GLsizei, void>)GetProcAddress("glDrawArraysInstancedEXT");
            //}
            //if (config == null || config.Contains("glDrawArraysInstancedNV")) {
            //    glDrawArraysInstancedNV = (delegate* unmanaged<GLenum, GLint, GLsizei, GLsizei, void>)GetProcAddress("glDrawArraysInstancedNV");
            //}
            //if (config == null || config.Contains("glDrawBuffer")) {
            //    glDrawBuffer = (delegate* unmanaged<GLenum, void>)GetProcAddress("glDrawBuffer");
            //}
            //if (config == null || config.Contains("glDrawBuffers")) {
            //    glDrawBuffers = (delegate* unmanaged<GLsizei, GLenum[], void>)GetProcAddress("glDrawBuffers");
            //}
            //if (config == null || config.Contains("glDrawBuffersARB")) {
            //    glDrawBuffersARB = (delegate* unmanaged<GLsizei, GLenum[], void>)GetProcAddress("glDrawBuffersARB");
            //}
            //if (config == null || config.Contains("glDrawBuffersATI")) {
            //    glDrawBuffersATI = (delegate* unmanaged<GLsizei, GLenum[], void>)GetProcAddress("glDrawBuffersATI");
            //}
            //if (config == null || config.Contains("glDrawBuffersEXT")) {
            //    glDrawBuffersEXT = (delegate* unmanaged<GLsizei, GLenum[], void>)GetProcAddress("glDrawBuffersEXT");
            //}
            //if (config == null || config.Contains("glDrawBuffersIndexedEXT")) {
            //    glDrawBuffersIndexedEXT = (delegate* unmanaged<GLint, GLenum[], GLint[], void>)GetProcAddress("glDrawBuffersIndexedEXT");
            //}
            //if (config == null || config.Contains("glDrawBuffersNV")) {
            //    glDrawBuffersNV = (delegate* unmanaged<GLsizei, GLenum[], void>)GetProcAddress("glDrawBuffersNV");
            //}
            //if (config == null || config.Contains("glDrawCommandsAddressNV")) {
            //    glDrawCommandsAddressNV = (delegate* unmanaged<GLenum, GLuint64[], GLsizei[], GLuint, void>)GetProcAddress("glDrawCommandsAddressNV");
            //}
            //if (config == null || config.Contains("glDrawCommandsNV")) {
            //    glDrawCommandsNV = (delegate* unmanaged<GLenum, GLuint, GLintptr[], GLsizei[], GLuint, void>)GetProcAddress("glDrawCommandsNV");
            //}
            //if (config == null || config.Contains("glDrawCommandsStatesAddressNV")) {
            //    glDrawCommandsStatesAddressNV = (delegate* unmanaged<GLuint64[], GLsizei[], GLuint[], GLuint[], GLuint, void>)GetProcAddress("glDrawCommandsStatesAddressNV");
            //}
            //if (config == null || config.Contains("glDrawCommandsStatesNV")) {
            //    glDrawCommandsStatesNV = (delegate* unmanaged<GLuint, GLintptr[], GLsizei[], GLuint[], GLuint[], GLuint, void>)GetProcAddress("glDrawCommandsStatesNV");
            //}
            //if (config == null || config.Contains("glDrawElementArrayAPPLE")) {
            //    glDrawElementArrayAPPLE = (delegate* unmanaged<GLenum, GLint, GLsizei, void>)GetProcAddress("glDrawElementArrayAPPLE");
            //}
            //if (config == null || config.Contains("glDrawElementArrayATI")) {
            //    glDrawElementArrayATI = (delegate* unmanaged<GLenum, GLsizei, void>)GetProcAddress("glDrawElementArrayATI");
            //}
            //if (config == null || config.Contains("glDrawElements")) {
            //    glDrawElements = (delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, void>)GetProcAddress("glDrawElements");
            //}
            //if (config == null || config.Contains("glDrawElementsBaseVertex")) {
            //    glDrawElementsBaseVertex = (delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLint, void>)GetProcAddress("glDrawElementsBaseVertex");
            //}
            //if (config == null || config.Contains("glDrawElementsBaseVertexEXT")) {
            //    glDrawElementsBaseVertexEXT = (delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLint, void>)GetProcAddress("glDrawElementsBaseVertexEXT");
            //}
            //if (config == null || config.Contains("glDrawElementsBaseVertexOES")) {
            //    glDrawElementsBaseVertexOES = (delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLint, void>)GetProcAddress("glDrawElementsBaseVertexOES");
            //}
            //if (config == null || config.Contains("glDrawElementsIndirect")) {
            //    glDrawElementsIndirect = (delegate* unmanaged<GLenum, GLenum, IntPtr, void>)GetProcAddress("glDrawElementsIndirect");
            //}
            //if (config == null || config.Contains("glDrawElementsInstanced")) {
            //    glDrawElementsInstanced = (delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLsizei, void>)GetProcAddress("glDrawElementsInstanced");
            //}
            //if (config == null || config.Contains("glDrawElementsInstancedANGLE")) {
            //    glDrawElementsInstancedANGLE = (delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLsizei, void>)GetProcAddress("glDrawElementsInstancedANGLE");
            //}
            //if (config == null || config.Contains("glDrawElementsInstancedARB")) {
            //    glDrawElementsInstancedARB = (delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLsizei, void>)GetProcAddress("glDrawElementsInstancedARB");
            //}
            //if (config == null || config.Contains("glDrawElementsInstancedBaseInstance")) {
            //    glDrawElementsInstancedBaseInstance = (delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLsizei, GLuint, void>)GetProcAddress("glDrawElementsInstancedBaseInstance");
            //}
            //if (config == null || config.Contains("glDrawElementsInstancedBaseInstanceEXT")) {
            //    glDrawElementsInstancedBaseInstanceEXT = (delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLsizei, GLuint, void>)GetProcAddress("glDrawElementsInstancedBaseInstanceEXT");
            //}
            //if (config == null || config.Contains("glDrawElementsInstancedBaseVertex")) {
            //    glDrawElementsInstancedBaseVertex = (delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLsizei, GLint, void>)GetProcAddress("glDrawElementsInstancedBaseVertex");
            //}
            //if (config == null || config.Contains("glDrawElementsInstancedBaseVertexBaseInstance")) {
            //    glDrawElementsInstancedBaseVertexBaseInstance = (delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLsizei, GLint, GLuint, void>)GetProcAddress("glDrawElementsInstancedBaseVertexBaseInstance");
            //}
            //if (config == null || config.Contains("glDrawElementsInstancedBaseVertexBaseInstanceEXT")) {
            //    glDrawElementsInstancedBaseVertexBaseInstanceEXT = (delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLsizei, GLint, GLuint, void>)GetProcAddress("glDrawElementsInstancedBaseVertexBaseInstanceEXT");
            //}
            //if (config == null || config.Contains("glDrawElementsInstancedBaseVertexEXT")) {
            //    glDrawElementsInstancedBaseVertexEXT = (delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLsizei, GLint, void>)GetProcAddress("glDrawElementsInstancedBaseVertexEXT");
            //}
            //if (config == null || config.Contains("glDrawElementsInstancedBaseVertexOES")) {
            //    glDrawElementsInstancedBaseVertexOES = (delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLsizei, GLint, void>)GetProcAddress("glDrawElementsInstancedBaseVertexOES");
            //}
            //if (config == null || config.Contains("glDrawElementsInstancedEXT")) {
            //    glDrawElementsInstancedEXT = (delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLsizei, void>)GetProcAddress("glDrawElementsInstancedEXT");
            //}
            //if (config == null || config.Contains("glDrawElementsInstancedNV")) {
            //    glDrawElementsInstancedNV = (delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLsizei, void>)GetProcAddress("glDrawElementsInstancedNV");
            //}
            //if (config == null || config.Contains("glDrawMeshArraysSUN")) {
            //    glDrawMeshArraysSUN = (delegate* unmanaged<GLenum, GLint, GLsizei, GLsizei, void>)GetProcAddress("glDrawMeshArraysSUN");
            //}
            //if (config == null || config.Contains("glDrawMeshTasksNV")) {
            //    glDrawMeshTasksNV = (delegate* unmanaged<GLuint, GLuint, void>)GetProcAddress("glDrawMeshTasksNV");
            //}
            //if (config == null || config.Contains("glDrawMeshTasksIndirectNV")) {
            //    glDrawMeshTasksIndirectNV = (delegate* unmanaged<GLintptr, void>)GetProcAddress("glDrawMeshTasksIndirectNV");
            //}
            //if (config == null || config.Contains("glDrawPixels")) {
            //    glDrawPixels = (delegate* unmanaged<GLsizei, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glDrawPixels");
            //}
            //if (config == null || config.Contains("glDrawRangeElementArrayAPPLE")) {
            //    glDrawRangeElementArrayAPPLE = (delegate* unmanaged<GLenum, GLuint, GLuint, GLint, GLsizei, void>)GetProcAddress("glDrawRangeElementArrayAPPLE");
            //}
            //if (config == null || config.Contains("glDrawRangeElementArrayATI")) {
            //    glDrawRangeElementArrayATI = (delegate* unmanaged<GLenum, GLuint, GLuint, GLsizei, void>)GetProcAddress("glDrawRangeElementArrayATI");
            //}
            //if (config == null || config.Contains("glDrawRangeElements")) {
            //    glDrawRangeElements = (delegate* unmanaged<GLenum, GLuint, GLuint, GLsizei, GLenum, IntPtr, void>)GetProcAddress("glDrawRangeElements");
            //}
            //if (config == null || config.Contains("glDrawRangeElementsBaseVertex")) {
            //    glDrawRangeElementsBaseVertex = (delegate* unmanaged<GLenum, GLuint, GLuint, GLsizei, GLenum, IntPtr, GLint, void>)GetProcAddress("glDrawRangeElementsBaseVertex");
            //}
            //if (config == null || config.Contains("glDrawRangeElementsBaseVertexEXT")) {
            //    glDrawRangeElementsBaseVertexEXT = (delegate* unmanaged<GLenum, GLuint, GLuint, GLsizei, GLenum, IntPtr, GLint, void>)GetProcAddress("glDrawRangeElementsBaseVertexEXT");
            //}
            //if (config == null || config.Contains("glDrawRangeElementsBaseVertexOES")) {
            //    glDrawRangeElementsBaseVertexOES = (delegate* unmanaged<GLenum, GLuint, GLuint, GLsizei, GLenum, IntPtr, GLint, void>)GetProcAddress("glDrawRangeElementsBaseVertexOES");
            //}
            //if (config == null || config.Contains("glDrawRangeElementsEXT")) {
            //    glDrawRangeElementsEXT = (delegate* unmanaged<GLenum, GLuint, GLuint, GLsizei, GLenum, IntPtr, void>)GetProcAddress("glDrawRangeElementsEXT");
            //}
            //if (config == null || config.Contains("glDrawTexfOES")) {
            //    glDrawTexfOES = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glDrawTexfOES");
            //}
            //if (config == null || config.Contains("glDrawTexfvOES")) {
            //    glDrawTexfvOES = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glDrawTexfvOES");
            //}
            //if (config == null || config.Contains("glDrawTexiOES")) {
            //    glDrawTexiOES = (delegate* unmanaged<GLint, GLint, GLint, GLint, GLint, void>)GetProcAddress("glDrawTexiOES");
            //}
            //if (config == null || config.Contains("glDrawTexivOES")) {
            //    glDrawTexivOES = (delegate* unmanaged<GLint[], void>)GetProcAddress("glDrawTexivOES");
            //}
            //if (config == null || config.Contains("glDrawTexsOES")) {
            //    glDrawTexsOES = (delegate* unmanaged<GLshort, GLshort, GLshort, GLshort, GLshort, void>)GetProcAddress("glDrawTexsOES");
            //}
            //if (config == null || config.Contains("glDrawTexsvOES")) {
            //    glDrawTexsvOES = (delegate* unmanaged<GLshort[], void>)GetProcAddress("glDrawTexsvOES");
            //}
            //if (config == null || config.Contains("glDrawTextureNV")) {
            //    glDrawTextureNV = (delegate* unmanaged<GLuint, GLuint, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glDrawTextureNV");
            //}
            //if (config == null || config.Contains("glDrawTexxOES")) {
            //    glDrawTexxOES = (delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glDrawTexxOES");
            //}
            //if (config == null || config.Contains("glDrawTexxvOES")) {
            //    glDrawTexxvOES = (delegate* unmanaged<GLfixed[], void>)GetProcAddress("glDrawTexxvOES");
            //}
            //if (config == null || config.Contains("glDrawTransformFeedback")) {
            //    glDrawTransformFeedback = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glDrawTransformFeedback");
            //}
            //if (config == null || config.Contains("glDrawTransformFeedbackEXT")) {
            //    glDrawTransformFeedbackEXT = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glDrawTransformFeedbackEXT");
            //}
            //if (config == null || config.Contains("glDrawTransformFeedbackInstanced")) {
            //    glDrawTransformFeedbackInstanced = (delegate* unmanaged<GLenum, GLuint, GLsizei, void>)GetProcAddress("glDrawTransformFeedbackInstanced");
            //}
            //if (config == null || config.Contains("glDrawTransformFeedbackInstancedEXT")) {
            //    glDrawTransformFeedbackInstancedEXT = (delegate* unmanaged<GLenum, GLuint, GLsizei, void>)GetProcAddress("glDrawTransformFeedbackInstancedEXT");
            //}
            //if (config == null || config.Contains("glDrawTransformFeedbackNV")) {
            //    glDrawTransformFeedbackNV = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glDrawTransformFeedbackNV");
            //}
            //if (config == null || config.Contains("glDrawTransformFeedbackStream")) {
            //    glDrawTransformFeedbackStream = (delegate* unmanaged<GLenum, GLuint, GLuint, void>)GetProcAddress("glDrawTransformFeedbackStream");
            //}
            //if (config == null || config.Contains("glDrawTransformFeedbackStreamInstanced")) {
            //    glDrawTransformFeedbackStreamInstanced = (delegate* unmanaged<GLenum, GLuint, GLuint, GLsizei, void>)GetProcAddress("glDrawTransformFeedbackStreamInstanced");
            //}
            //if (config == null || config.Contains("glEGLImageTargetRenderbufferStorageOES")) {
            //    glEGLImageTargetRenderbufferStorageOES = (delegate* unmanaged<GLenum, GLeglImageOES, void>)GetProcAddress("glEGLImageTargetRenderbufferStorageOES");
            //}
            //if (config == null || config.Contains("glEGLImageTargetTexStorageEXT")) {
            //    glEGLImageTargetTexStorageEXT = (delegate* unmanaged<GLenum, GLeglImageOES, GLint[], void>)GetProcAddress("glEGLImageTargetTexStorageEXT");
            //}
            //if (config == null || config.Contains("glEGLImageTargetTexture2DOES")) {
            //    glEGLImageTargetTexture2DOES = (delegate* unmanaged<GLenum, GLeglImageOES, void>)GetProcAddress("glEGLImageTargetTexture2DOES");
            //}
            //if (config == null || config.Contains("glEGLImageTargetTextureStorageEXT")) {
            //    glEGLImageTargetTextureStorageEXT = (delegate* unmanaged<GLuint, GLeglImageOES, GLint[], void>)GetProcAddress("glEGLImageTargetTextureStorageEXT");
            //}
            //if (config == null || config.Contains("glEdgeFlag")) {
            //    glEdgeFlag = (delegate* unmanaged<GLboolean, void>)GetProcAddress("glEdgeFlag");
            //}
            //if (config == null || config.Contains("glEdgeFlagFormatNV")) {
            //    glEdgeFlagFormatNV = (delegate* unmanaged<GLsizei, void>)GetProcAddress("glEdgeFlagFormatNV");
            //}
            //if (config == null || config.Contains("glEdgeFlagPointer")) {
            //    glEdgeFlagPointer = (delegate* unmanaged<GLsizei, IntPtr, void>)GetProcAddress("glEdgeFlagPointer");
            //}
            //if (config == null || config.Contains("glEdgeFlagPointerEXT")) {
            //    glEdgeFlagPointerEXT = (delegate* unmanaged<GLsizei, GLsizei, GLboolean[], void>)GetProcAddress("glEdgeFlagPointerEXT");
            //}
            //if (config == null || config.Contains("glEdgeFlagPointerListIBM")) {
            //    glEdgeFlagPointerListIBM = (delegate* unmanaged<GLint, GLboolean[][], GLint, void>)GetProcAddress("glEdgeFlagPointerListIBM");
            //}
            //if (config == null || config.Contains("glEdgeFlagv")) {
            //    glEdgeFlagv = (delegate* unmanaged<GLboolean[], void>)GetProcAddress("glEdgeFlagv");
            //}
            //if (config == null || config.Contains("glElementPointerAPPLE")) {
            //    glElementPointerAPPLE = (delegate* unmanaged<GLenum, IntPtr, void>)GetProcAddress("glElementPointerAPPLE");
            //}
            //if (config == null || config.Contains("glElementPointerATI")) {
            //    glElementPointerATI = (delegate* unmanaged<GLenum, IntPtr, void>)GetProcAddress("glElementPointerATI");
            //}
            //if (config == null || config.Contains("glEnable")) {
            //    glEnable = (delegate* unmanaged<GLenum, void>)GetProcAddress("glEnable");
            //}
            //if (config == null || config.Contains("glEnableClientState")) {
            //    glEnableClientState = (delegate* unmanaged<GLenum, void>)GetProcAddress("glEnableClientState");
            //}
            //if (config == null || config.Contains("glEnableClientStateIndexedEXT")) {
            //    glEnableClientStateIndexedEXT = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glEnableClientStateIndexedEXT");
            //}
            //if (config == null || config.Contains("glEnableClientStateiEXT")) {
            //    glEnableClientStateiEXT = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glEnableClientStateiEXT");
            //}
            //if (config == null || config.Contains("glEnableDriverControlQCOM")) {
            //    glEnableDriverControlQCOM = (delegate* unmanaged<GLuint, void>)GetProcAddress("glEnableDriverControlQCOM");
            //}
            //if (config == null || config.Contains("glEnableIndexedEXT")) {
            //    glEnableIndexedEXT = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glEnableIndexedEXT");
            //}
            //if (config == null || config.Contains("glEnableVariantClientStateEXT")) {
            //    glEnableVariantClientStateEXT = (delegate* unmanaged<GLuint, void>)GetProcAddress("glEnableVariantClientStateEXT");
            //}
            //if (config == null || config.Contains("glEnableVertexArrayAttrib")) {
            //    glEnableVertexArrayAttrib = (delegate* unmanaged<GLuint, GLuint, void>)GetProcAddress("glEnableVertexArrayAttrib");
            //}
            //if (config == null || config.Contains("glEnableVertexArrayAttribEXT")) {
            //    glEnableVertexArrayAttribEXT = (delegate* unmanaged<GLuint, GLuint, void>)GetProcAddress("glEnableVertexArrayAttribEXT");
            //}
            //if (config == null || config.Contains("glEnableVertexArrayEXT")) {
            //    glEnableVertexArrayEXT = (delegate* unmanaged<GLuint, GLenum, void>)GetProcAddress("glEnableVertexArrayEXT");
            //}
            //if (config == null || config.Contains("glEnableVertexAttribAPPLE")) {
            //    glEnableVertexAttribAPPLE = (delegate* unmanaged<GLuint, GLenum, void>)GetProcAddress("glEnableVertexAttribAPPLE");
            //}
            //if (config == null || config.Contains("glEnableVertexAttribArray")) {
            //    glEnableVertexAttribArray = (delegate* unmanaged<GLuint, void>)GetProcAddress("glEnableVertexAttribArray");
            //}
            //if (config == null || config.Contains("glEnableVertexAttribArrayARB")) {
            //    glEnableVertexAttribArrayARB = (delegate* unmanaged<GLuint, void>)GetProcAddress("glEnableVertexAttribArrayARB");
            //}
            //if (config == null || config.Contains("glEnablei")) {
            //    glEnablei = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glEnablei");
            //}
            //if (config == null || config.Contains("glEnableiEXT")) {
            //    glEnableiEXT = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glEnableiEXT");
            //}
            //if (config == null || config.Contains("glEnableiNV")) {
            //    glEnableiNV = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glEnableiNV");
            //}
            //if (config == null || config.Contains("glEnableiOES")) {
            //    glEnableiOES = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glEnableiOES");
            //}
            //if (config == null || config.Contains("glEnd")) {
            //    glEnd = (delegate* unmanaged<void>)GetProcAddress("glEnd");
            //}
            //if (config == null || config.Contains("glEndConditionalRender")) {
            //    glEndConditionalRender = (delegate* unmanaged<void>)GetProcAddress("glEndConditionalRender");
            //}
            //if (config == null || config.Contains("glEndConditionalRenderNV")) {
            //    glEndConditionalRenderNV = (delegate* unmanaged<void>)GetProcAddress("glEndConditionalRenderNV");
            //}
            //if (config == null || config.Contains("glEndConditionalRenderNVX")) {
            //    glEndConditionalRenderNVX = (delegate* unmanaged<void>)GetProcAddress("glEndConditionalRenderNVX");
            //}
            //if (config == null || config.Contains("glEndFragmentShaderATI")) {
            //    glEndFragmentShaderATI = (delegate* unmanaged<void>)GetProcAddress("glEndFragmentShaderATI");
            //}
            //if (config == null || config.Contains("glEndList")) {
            //    glEndList = (delegate* unmanaged<void>)GetProcAddress("glEndList");
            //}
            //if (config == null || config.Contains("glEndOcclusionQueryNV")) {
            //    glEndOcclusionQueryNV = (delegate* unmanaged<void>)GetProcAddress("glEndOcclusionQueryNV");
            //}
            //if (config == null || config.Contains("glEndPerfMonitorAMD")) {
            //    glEndPerfMonitorAMD = (delegate* unmanaged<GLuint, void>)GetProcAddress("glEndPerfMonitorAMD");
            //}
            //if (config == null || config.Contains("glEndPerfQueryINTEL")) {
            //    glEndPerfQueryINTEL = (delegate* unmanaged<GLuint, void>)GetProcAddress("glEndPerfQueryINTEL");
            //}
            //if (config == null || config.Contains("glEndQuery")) {
            //    glEndQuery = (delegate* unmanaged<GLenum, void>)GetProcAddress("glEndQuery");
            //}
            //if (config == null || config.Contains("glEndQueryARB")) {
            //    glEndQueryARB = (delegate* unmanaged<GLenum, void>)GetProcAddress("glEndQueryARB");
            //}
            //if (config == null || config.Contains("glEndQueryEXT")) {
            //    glEndQueryEXT = (delegate* unmanaged<GLenum, void>)GetProcAddress("glEndQueryEXT");
            //}
            //if (config == null || config.Contains("glEndQueryIndexed")) {
            //    glEndQueryIndexed = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glEndQueryIndexed");
            //}
            //if (config == null || config.Contains("glEndTilingQCOM")) {
            //    glEndTilingQCOM = (delegate* unmanaged<GLbitfield, void>)GetProcAddress("glEndTilingQCOM");
            //}
            //if (config == null || config.Contains("glEndTransformFeedback")) {
            //    glEndTransformFeedback = (delegate* unmanaged<void>)GetProcAddress("glEndTransformFeedback");
            //}
            //if (config == null || config.Contains("glEndTransformFeedbackEXT")) {
            //    glEndTransformFeedbackEXT = (delegate* unmanaged<void>)GetProcAddress("glEndTransformFeedbackEXT");
            //}
            //if (config == null || config.Contains("glEndTransformFeedbackNV")) {
            //    glEndTransformFeedbackNV = (delegate* unmanaged<void>)GetProcAddress("glEndTransformFeedbackNV");
            //}
            //if (config == null || config.Contains("glEndVertexShaderEXT")) {
            //    glEndVertexShaderEXT = (delegate* unmanaged<void>)GetProcAddress("glEndVertexShaderEXT");
            //}
            //if (config == null || config.Contains("glEndVideoCaptureNV")) {
            //    glEndVideoCaptureNV = (delegate* unmanaged<GLuint, void>)GetProcAddress("glEndVideoCaptureNV");
            //}
            //if (config == null || config.Contains("glEvalCoord1d")) {
            //    glEvalCoord1d = (delegate* unmanaged<GLdouble, void>)GetProcAddress("glEvalCoord1d");
            //}
            //if (config == null || config.Contains("glEvalCoord1dv")) {
            //    glEvalCoord1dv = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glEvalCoord1dv");
            //}
            //if (config == null || config.Contains("glEvalCoord1f")) {
            //    glEvalCoord1f = (delegate* unmanaged<GLfloat, void>)GetProcAddress("glEvalCoord1f");
            //}
            //if (config == null || config.Contains("glEvalCoord1fv")) {
            //    glEvalCoord1fv = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glEvalCoord1fv");
            //}
            //if (config == null || config.Contains("glEvalCoord1xOES")) {
            //    glEvalCoord1xOES = (delegate* unmanaged<GLfixed, void>)GetProcAddress("glEvalCoord1xOES");
            //}
            //if (config == null || config.Contains("glEvalCoord1xvOES")) {
            //    glEvalCoord1xvOES = (delegate* unmanaged<GLfixed[], void>)GetProcAddress("glEvalCoord1xvOES");
            //}
            //if (config == null || config.Contains("glEvalCoord2d")) {
            //    glEvalCoord2d = (delegate* unmanaged<GLdouble, GLdouble, void>)GetProcAddress("glEvalCoord2d");
            //}
            //if (config == null || config.Contains("glEvalCoord2dv")) {
            //    glEvalCoord2dv = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glEvalCoord2dv");
            //}
            //if (config == null || config.Contains("glEvalCoord2f")) {
            //    glEvalCoord2f = (delegate* unmanaged<GLfloat, GLfloat, void>)GetProcAddress("glEvalCoord2f");
            //}
            //if (config == null || config.Contains("glEvalCoord2fv")) {
            //    glEvalCoord2fv = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glEvalCoord2fv");
            //}
            //if (config == null || config.Contains("glEvalCoord2xOES")) {
            //    glEvalCoord2xOES = (delegate* unmanaged<GLfixed, GLfixed, void>)GetProcAddress("glEvalCoord2xOES");
            //}
            //if (config == null || config.Contains("glEvalCoord2xvOES")) {
            //    glEvalCoord2xvOES = (delegate* unmanaged<GLfixed[], void>)GetProcAddress("glEvalCoord2xvOES");
            //}
            //if (config == null || config.Contains("glEvalMapsNV")) {
            //    glEvalMapsNV = (delegate* unmanaged<GLenum, GLenum, void>)GetProcAddress("glEvalMapsNV");
            //}
            //if (config == null || config.Contains("glEvalMesh1")) {
            //    glEvalMesh1 = (delegate* unmanaged<GLenum, GLint, GLint, void>)GetProcAddress("glEvalMesh1");
            //}
            //if (config == null || config.Contains("glEvalMesh2")) {
            //    glEvalMesh2 = (delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, void>)GetProcAddress("glEvalMesh2");
            //}
            //if (config == null || config.Contains("glEvalPoint1")) {
            //    glEvalPoint1 = (delegate* unmanaged<GLint, void>)GetProcAddress("glEvalPoint1");
            //}
            //if (config == null || config.Contains("glEvalPoint2")) {
            //    glEvalPoint2 = (delegate* unmanaged<GLint, GLint, void>)GetProcAddress("glEvalPoint2");
            //}
            //if (config == null || config.Contains("glEvaluateDepthValuesARB")) {
            //    glEvaluateDepthValuesARB = (delegate* unmanaged<void>)GetProcAddress("glEvaluateDepthValuesARB");
            //}
            //if (config == null || config.Contains("glExecuteProgramNV")) {
            //    glExecuteProgramNV = (delegate* unmanaged<GLenum, GLuint, GLfloat[], void>)GetProcAddress("glExecuteProgramNV");
            //}
            //if (config == null || config.Contains("glExtGetBufferPointervQCOM")) {
            //    glExtGetBufferPointervQCOM = (delegate* unmanaged<GLenum, IntPtr, void>)GetProcAddress("glExtGetBufferPointervQCOM");
            //}
            //if (config == null || config.Contains("glExtGetBuffersQCOM")) {
            //    glExtGetBuffersQCOM = (delegate* unmanaged<GLuint[], GLint, GLint[], void>)GetProcAddress("glExtGetBuffersQCOM");
            //}
            //if (config == null || config.Contains("glExtGetFramebuffersQCOM")) {
            //    glExtGetFramebuffersQCOM = (delegate* unmanaged<GLuint[], GLint, GLint[], void>)GetProcAddress("glExtGetFramebuffersQCOM");
            //}
            //if (config == null || config.Contains("glExtGetProgramBinarySourceQCOM")) {
            //    glExtGetProgramBinarySourceQCOM = (delegate* unmanaged<GLuint, GLenum, string, GLint[], void>)GetProcAddress("glExtGetProgramBinarySourceQCOM");
            //}
            //if (config == null || config.Contains("glExtGetProgramsQCOM")) {
            //    glExtGetProgramsQCOM = (delegate* unmanaged<GLuint[], GLint, GLint[], void>)GetProcAddress("glExtGetProgramsQCOM");
            //}
            //if (config == null || config.Contains("glExtGetRenderbuffersQCOM")) {
            //    glExtGetRenderbuffersQCOM = (delegate* unmanaged<GLuint[], GLint, GLint[], void>)GetProcAddress("glExtGetRenderbuffersQCOM");
            //}
            //if (config == null || config.Contains("glExtGetShadersQCOM")) {
            //    glExtGetShadersQCOM = (delegate* unmanaged<GLuint[], GLint, GLint[], void>)GetProcAddress("glExtGetShadersQCOM");
            //}
            //if (config == null || config.Contains("glExtGetTexLevelParameterivQCOM")) {
            //    glExtGetTexLevelParameterivQCOM = (delegate* unmanaged<GLuint, GLenum, GLint, GLenum, GLint[], void>)GetProcAddress("glExtGetTexLevelParameterivQCOM");
            //}
            //if (config == null || config.Contains("glExtGetTexSubImageQCOM")) {
            //    glExtGetTexSubImageQCOM = (delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glExtGetTexSubImageQCOM");
            //}
            //if (config == null || config.Contains("glExtGetTexturesQCOM")) {
            //    glExtGetTexturesQCOM = (delegate* unmanaged<GLuint[], GLint, GLint[], void>)GetProcAddress("glExtGetTexturesQCOM");
            //}
            //if (config == null || config.Contains("glExtIsProgramBinaryQCOM")) {
            //    glExtIsProgramBinaryQCOM = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glExtIsProgramBinaryQCOM");
            //}
            //if (config == null || config.Contains("glExtTexObjectStateOverrideiQCOM")) {
            //    glExtTexObjectStateOverrideiQCOM = (delegate* unmanaged<GLenum, GLenum, GLint, void>)GetProcAddress("glExtTexObjectStateOverrideiQCOM");
            //}
            //if (config == null || config.Contains("glExtractComponentEXT")) {
            //    glExtractComponentEXT = (delegate* unmanaged<GLuint, GLuint, GLuint, void>)GetProcAddress("glExtractComponentEXT");
            //}
            //if (config == null || config.Contains("glFeedbackBuffer")) {
            //    glFeedbackBuffer = (delegate* unmanaged<GLsizei, GLenum, GLfloat[], void>)GetProcAddress("glFeedbackBuffer");
            //}
            //if (config == null || config.Contains("glFeedbackBufferxOES")) {
            //    glFeedbackBufferxOES = (delegate* unmanaged<GLsizei, GLenum, GLfixed[], void>)GetProcAddress("glFeedbackBufferxOES");
            //}
            //if (config == null || config.Contains("glFenceSync")) {
            //    glFenceSync = (delegate* unmanaged<GLenum, GLbitfield, GLsync>)GetProcAddress("glFenceSync");
            //}
            //if (config == null || config.Contains("glFenceSyncAPPLE")) {
            //    glFenceSyncAPPLE = (delegate* unmanaged<GLenum, GLbitfield, GLsync>)GetProcAddress("glFenceSyncAPPLE");
            //}
            //if (config == null || config.Contains("glFinalCombinerInputNV")) {
            //    glFinalCombinerInputNV = (delegate* unmanaged<GLenum, GLenum, GLenum, GLenum, void>)GetProcAddress("glFinalCombinerInputNV");
            //}
            //if (config == null || config.Contains("glFinish")) {
            //    glFinish = (delegate* unmanaged<void>)GetProcAddress("glFinish");
            //}
            //if (config == null || config.Contains("glFinishAsyncSGIX")) {
            //    glFinishAsyncSGIX = (delegate* unmanaged<GLuint[], GLint>)GetProcAddress("glFinishAsyncSGIX");
            //}
            //if (config == null || config.Contains("glFinishFenceAPPLE")) {
            //    glFinishFenceAPPLE = (delegate* unmanaged<GLuint, void>)GetProcAddress("glFinishFenceAPPLE");
            //}
            //if (config == null || config.Contains("glFinishFenceNV")) {
            //    glFinishFenceNV = (delegate* unmanaged<GLuint, void>)GetProcAddress("glFinishFenceNV");
            //}
            //if (config == null || config.Contains("glFinishObjectAPPLE")) {
            //    glFinishObjectAPPLE = (delegate* unmanaged<GLenum, GLint, void>)GetProcAddress("glFinishObjectAPPLE");
            //}
            //if (config == null || config.Contains("glFinishTextureSUNX")) {
            //    glFinishTextureSUNX = (delegate* unmanaged<void>)GetProcAddress("glFinishTextureSUNX");
            //}
            //if (config == null || config.Contains("glFlush")) {
            //    glFlush = (delegate* unmanaged<void>)GetProcAddress("glFlush");
            //}
            //if (config == null || config.Contains("glFlushMappedBufferRange")) {
            //    glFlushMappedBufferRange = (delegate* unmanaged<GLenum, GLintptr, GLsizeiptr, void>)GetProcAddress("glFlushMappedBufferRange");
            //}
            //if (config == null || config.Contains("glFlushMappedBufferRangeAPPLE")) {
            //    glFlushMappedBufferRangeAPPLE = (delegate* unmanaged<GLenum, GLintptr, GLsizeiptr, void>)GetProcAddress("glFlushMappedBufferRangeAPPLE");
            //}
            //if (config == null || config.Contains("glFlushMappedBufferRangeEXT")) {
            //    glFlushMappedBufferRangeEXT = (delegate* unmanaged<GLenum, GLintptr, GLsizeiptr, void>)GetProcAddress("glFlushMappedBufferRangeEXT");
            //}
            //if (config == null || config.Contains("glFlushMappedNamedBufferRange")) {
            //    glFlushMappedNamedBufferRange = (delegate* unmanaged<GLuint, GLintptr, GLsizeiptr, void>)GetProcAddress("glFlushMappedNamedBufferRange");
            //}
            //if (config == null || config.Contains("glFlushMappedNamedBufferRangeEXT")) {
            //    glFlushMappedNamedBufferRangeEXT = (delegate* unmanaged<GLuint, GLintptr, GLsizeiptr, void>)GetProcAddress("glFlushMappedNamedBufferRangeEXT");
            //}
            //if (config == null || config.Contains("glFlushPixelDataRangeNV")) {
            //    glFlushPixelDataRangeNV = (delegate* unmanaged<GLenum, void>)GetProcAddress("glFlushPixelDataRangeNV");
            //}
            //if (config == null || config.Contains("glFlushRasterSGIX")) {
            //    glFlushRasterSGIX = (delegate* unmanaged<void>)GetProcAddress("glFlushRasterSGIX");
            //}
            //if (config == null || config.Contains("glFlushStaticDataIBM")) {
            //    glFlushStaticDataIBM = (delegate* unmanaged<GLenum, void>)GetProcAddress("glFlushStaticDataIBM");
            //}
            //if (config == null || config.Contains("glFlushVertexArrayRangeAPPLE")) {
            //    glFlushVertexArrayRangeAPPLE = (delegate* unmanaged<GLsizei, IntPtr, void>)GetProcAddress("glFlushVertexArrayRangeAPPLE");
            //}
            //if (config == null || config.Contains("glFlushVertexArrayRangeNV")) {
            //    glFlushVertexArrayRangeNV = (delegate* unmanaged<void>)GetProcAddress("glFlushVertexArrayRangeNV");
            //}
            //if (config == null || config.Contains("glFogCoordFormatNV")) {
            //    glFogCoordFormatNV = (delegate* unmanaged<GLenum, GLsizei, void>)GetProcAddress("glFogCoordFormatNV");
            //}
            //if (config == null || config.Contains("glFogCoordPointer")) {
            //    glFogCoordPointer = (delegate* unmanaged<GLenum, GLsizei, IntPtr, void>)GetProcAddress("glFogCoordPointer");
            //}
            //if (config == null || config.Contains("glFogCoordPointerEXT")) {
            //    glFogCoordPointerEXT = (delegate* unmanaged<GLenum, GLsizei, IntPtr, void>)GetProcAddress("glFogCoordPointerEXT");
            //}
            //if (config == null || config.Contains("glFogCoordPointerListIBM")) {
            //    glFogCoordPointerListIBM = (delegate* unmanaged<GLenum, GLint, IntPtr, GLint, void>)GetProcAddress("glFogCoordPointerListIBM");
            //}
            //if (config == null || config.Contains("glFogCoordd")) {
            //    glFogCoordd = (delegate* unmanaged<GLdouble, void>)GetProcAddress("glFogCoordd");
            //}
            //if (config == null || config.Contains("glFogCoorddEXT")) {
            //    glFogCoorddEXT = (delegate* unmanaged<GLdouble, void>)GetProcAddress("glFogCoorddEXT");
            //}
            //if (config == null || config.Contains("glFogCoorddv")) {
            //    glFogCoorddv = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glFogCoorddv");
            //}
            //if (config == null || config.Contains("glFogCoorddvEXT")) {
            //    glFogCoorddvEXT = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glFogCoorddvEXT");
            //}
            //if (config == null || config.Contains("glFogCoordf")) {
            //    glFogCoordf = (delegate* unmanaged<GLfloat, void>)GetProcAddress("glFogCoordf");
            //}
            //if (config == null || config.Contains("glFogCoordfEXT")) {
            //    glFogCoordfEXT = (delegate* unmanaged<GLfloat, void>)GetProcAddress("glFogCoordfEXT");
            //}
            //if (config == null || config.Contains("glFogCoordfv")) {
            //    glFogCoordfv = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glFogCoordfv");
            //}
            //if (config == null || config.Contains("glFogCoordfvEXT")) {
            //    glFogCoordfvEXT = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glFogCoordfvEXT");
            //}
            //if (config == null || config.Contains("glFogCoordhNV")) {
            //    glFogCoordhNV = (delegate* unmanaged<GLhalfNV, void>)GetProcAddress("glFogCoordhNV");
            //}
            //if (config == null || config.Contains("glFogCoordhvNV")) {
            //    glFogCoordhvNV = (delegate* unmanaged<GLhalfNV[], void>)GetProcAddress("glFogCoordhvNV");
            //}
            //if (config == null || config.Contains("glFogFuncSGIS")) {
            //    glFogFuncSGIS = (delegate* unmanaged<GLsizei, GLfloat[], void>)GetProcAddress("glFogFuncSGIS");
            //}
            //if (config == null || config.Contains("glFogf")) {
            //    glFogf = (delegate* unmanaged<GLenum, GLfloat, void>)GetProcAddress("glFogf");
            //}
            //if (config == null || config.Contains("glFogfv")) {
            //    glFogfv = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glFogfv");
            //}
            //if (config == null || config.Contains("glFogi")) {
            //    glFogi = (delegate* unmanaged<GLenum, GLint, void>)GetProcAddress("glFogi");
            //}
            //if (config == null || config.Contains("glFogiv")) {
            //    glFogiv = (delegate* unmanaged<GLenum, GLint[], void>)GetProcAddress("glFogiv");
            //}
            //if (config == null || config.Contains("glFogx")) {
            //    glFogx = (delegate* unmanaged<GLenum, GLfixed, void>)GetProcAddress("glFogx");
            //}
            //if (config == null || config.Contains("glFogxOES")) {
            //    glFogxOES = (delegate* unmanaged<GLenum, GLfixed, void>)GetProcAddress("glFogxOES");
            //}
            //if (config == null || config.Contains("glFogxv")) {
            //    glFogxv = (delegate* unmanaged<GLenum, GLfixed[], void>)GetProcAddress("glFogxv");
            //}
            //if (config == null || config.Contains("glFogxvOES")) {
            //    glFogxvOES = (delegate* unmanaged<GLenum, GLfixed[], void>)GetProcAddress("glFogxvOES");
            //}
            //if (config == null || config.Contains("glFragmentColorMaterialSGIX")) {
            //    glFragmentColorMaterialSGIX = (delegate* unmanaged<GLenum, GLenum, void>)GetProcAddress("glFragmentColorMaterialSGIX");
            //}
            //if (config == null || config.Contains("glFragmentCoverageColorNV")) {
            //    glFragmentCoverageColorNV = (delegate* unmanaged<GLuint, void>)GetProcAddress("glFragmentCoverageColorNV");
            //}
            //if (config == null || config.Contains("glFragmentLightModelfSGIX")) {
            //    glFragmentLightModelfSGIX = (delegate* unmanaged<GLenum, GLfloat, void>)GetProcAddress("glFragmentLightModelfSGIX");
            //}
            //if (config == null || config.Contains("glFragmentLightModelfvSGIX")) {
            //    glFragmentLightModelfvSGIX = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glFragmentLightModelfvSGIX");
            //}
            //if (config == null || config.Contains("glFragmentLightModeliSGIX")) {
            //    glFragmentLightModeliSGIX = (delegate* unmanaged<GLenum, GLint, void>)GetProcAddress("glFragmentLightModeliSGIX");
            //}
            //if (config == null || config.Contains("glFragmentLightModelivSGIX")) {
            //    glFragmentLightModelivSGIX = (delegate* unmanaged<GLenum, GLint[], void>)GetProcAddress("glFragmentLightModelivSGIX");
            //}
            //if (config == null || config.Contains("glFragmentLightfSGIX")) {
            //    glFragmentLightfSGIX = (delegate* unmanaged<GLenum, GLenum, GLfloat, void>)GetProcAddress("glFragmentLightfSGIX");
            //}
            //if (config == null || config.Contains("glFragmentLightfvSGIX")) {
            //    glFragmentLightfvSGIX = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glFragmentLightfvSGIX");
            //}
            //if (config == null || config.Contains("glFragmentLightiSGIX")) {
            //    glFragmentLightiSGIX = (delegate* unmanaged<GLenum, GLenum, GLint, void>)GetProcAddress("glFragmentLightiSGIX");
            //}
            //if (config == null || config.Contains("glFragmentLightivSGIX")) {
            //    glFragmentLightivSGIX = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glFragmentLightivSGIX");
            //}
            //if (config == null || config.Contains("glFragmentMaterialfSGIX")) {
            //    glFragmentMaterialfSGIX = (delegate* unmanaged<GLenum, GLenum, GLfloat, void>)GetProcAddress("glFragmentMaterialfSGIX");
            //}
            //if (config == null || config.Contains("glFragmentMaterialfvSGIX")) {
            //    glFragmentMaterialfvSGIX = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glFragmentMaterialfvSGIX");
            //}
            //if (config == null || config.Contains("glFragmentMaterialiSGIX")) {
            //    glFragmentMaterialiSGIX = (delegate* unmanaged<GLenum, GLenum, GLint, void>)GetProcAddress("glFragmentMaterialiSGIX");
            //}
            //if (config == null || config.Contains("glFragmentMaterialivSGIX")) {
            //    glFragmentMaterialivSGIX = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glFragmentMaterialivSGIX");
            //}
            //if (config == null || config.Contains("glFrameTerminatorGREMEDY")) {
            //    glFrameTerminatorGREMEDY = (delegate* unmanaged<void>)GetProcAddress("glFrameTerminatorGREMEDY");
            //}
            //if (config == null || config.Contains("glFrameZoomSGIX")) {
            //    glFrameZoomSGIX = (delegate* unmanaged<GLint, void>)GetProcAddress("glFrameZoomSGIX");
            //}
            //if (config == null || config.Contains("glFramebufferDrawBufferEXT")) {
            //    glFramebufferDrawBufferEXT = (delegate* unmanaged<GLuint, GLenum, void>)GetProcAddress("glFramebufferDrawBufferEXT");
            //}
            //if (config == null || config.Contains("glFramebufferDrawBuffersEXT")) {
            //    glFramebufferDrawBuffersEXT = (delegate* unmanaged<GLuint, GLsizei, GLenum[], void>)GetProcAddress("glFramebufferDrawBuffersEXT");
            //}
            //if (config == null || config.Contains("glFramebufferFetchBarrierEXT")) {
            //    glFramebufferFetchBarrierEXT = (delegate* unmanaged<void>)GetProcAddress("glFramebufferFetchBarrierEXT");
            //}
            //if (config == null || config.Contains("glFramebufferFetchBarrierQCOM")) {
            //    glFramebufferFetchBarrierQCOM = (delegate* unmanaged<void>)GetProcAddress("glFramebufferFetchBarrierQCOM");
            //}
            //if (config == null || config.Contains("glFramebufferFoveationConfigQCOM")) {
            //    glFramebufferFoveationConfigQCOM = (delegate* unmanaged<GLuint, GLuint, GLuint, GLuint, GLuint[], void>)GetProcAddress("glFramebufferFoveationConfigQCOM");
            //}
            //if (config == null || config.Contains("glFramebufferFoveationParametersQCOM")) {
            //    glFramebufferFoveationParametersQCOM = (delegate* unmanaged<GLuint, GLuint, GLuint, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glFramebufferFoveationParametersQCOM");
            //}
            //if (config == null || config.Contains("glFramebufferParameteri")) {
            //    glFramebufferParameteri = (delegate* unmanaged<GLenum, GLenum, GLint, void>)GetProcAddress("glFramebufferParameteri");
            //}
            //if (config == null || config.Contains("glFramebufferPixelLocalStorageSizeEXT")) {
            //    glFramebufferPixelLocalStorageSizeEXT = (delegate* unmanaged<GLuint, GLsizei, void>)GetProcAddress("glFramebufferPixelLocalStorageSizeEXT");
            //}
            //if (config == null || config.Contains("glFramebufferReadBufferEXT")) {
            //    glFramebufferReadBufferEXT = (delegate* unmanaged<GLuint, GLenum, void>)GetProcAddress("glFramebufferReadBufferEXT");
            //}
            //if (config == null || config.Contains("glFramebufferRenderbuffer")) {
            //    glFramebufferRenderbuffer = (delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, void>)GetProcAddress("glFramebufferRenderbuffer");
            //}
            //if (config == null || config.Contains("glFramebufferRenderbufferEXT")) {
            //    glFramebufferRenderbufferEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, void>)GetProcAddress("glFramebufferRenderbufferEXT");
            //}
            //if (config == null || config.Contains("glFramebufferRenderbufferOES")) {
            //    glFramebufferRenderbufferOES = (delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, void>)GetProcAddress("glFramebufferRenderbufferOES");
            //}
            //if (config == null || config.Contains("glFramebufferSampleLocationsfvARB")) {
            //    glFramebufferSampleLocationsfvARB = (delegate* unmanaged<GLenum, GLuint, GLsizei, GLfloat[], void>)GetProcAddress("glFramebufferSampleLocationsfvARB");
            //}
            //if (config == null || config.Contains("glFramebufferSampleLocationsfvNV")) {
            //    glFramebufferSampleLocationsfvNV = (delegate* unmanaged<GLenum, GLuint, GLsizei, GLfloat[], void>)GetProcAddress("glFramebufferSampleLocationsfvNV");
            //}
            //if (config == null || config.Contains("glFramebufferSamplePositionsfvAMD")) {
            //    glFramebufferSamplePositionsfvAMD = (delegate* unmanaged<GLenum, GLuint, GLuint, GLfloat[], void>)GetProcAddress("glFramebufferSamplePositionsfvAMD");
            //}
            //if (config == null || config.Contains("glFramebufferTexture")) {
            //    glFramebufferTexture = (delegate* unmanaged<GLenum, GLenum, GLuint, GLint, void>)GetProcAddress("glFramebufferTexture");
            //}
            //if (config == null || config.Contains("glFramebufferTexture1D")) {
            //    glFramebufferTexture1D = (delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, GLint, void>)GetProcAddress("glFramebufferTexture1D");
            //}
            //if (config == null || config.Contains("glFramebufferTexture1DEXT")) {
            //    glFramebufferTexture1DEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, GLint, void>)GetProcAddress("glFramebufferTexture1DEXT");
            //}
            //if (config == null || config.Contains("glFramebufferTexture2D")) {
            //    glFramebufferTexture2D = (delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, GLint, void>)GetProcAddress("glFramebufferTexture2D");
            //}
            //if (config == null || config.Contains("glFramebufferTexture2DEXT")) {
            //    glFramebufferTexture2DEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, GLint, void>)GetProcAddress("glFramebufferTexture2DEXT");
            //}
            //if (config == null || config.Contains("glFramebufferTexture2DDownsampleIMG")) {
            //    glFramebufferTexture2DDownsampleIMG = (delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, GLint, GLint, GLint, void>)GetProcAddress("glFramebufferTexture2DDownsampleIMG");
            //}
            //if (config == null || config.Contains("glFramebufferTexture2DMultisampleEXT")) {
            //    glFramebufferTexture2DMultisampleEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, GLint, GLsizei, void>)GetProcAddress("glFramebufferTexture2DMultisampleEXT");
            //}
            //if (config == null || config.Contains("glFramebufferTexture2DMultisampleIMG")) {
            //    glFramebufferTexture2DMultisampleIMG = (delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, GLint, GLsizei, void>)GetProcAddress("glFramebufferTexture2DMultisampleIMG");
            //}
            //if (config == null || config.Contains("glFramebufferTexture2DOES")) {
            //    glFramebufferTexture2DOES = (delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, GLint, void>)GetProcAddress("glFramebufferTexture2DOES");
            //}
            //if (config == null || config.Contains("glFramebufferTexture3D")) {
            //    glFramebufferTexture3D = (delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, GLint, GLint, void>)GetProcAddress("glFramebufferTexture3D");
            //}
            //if (config == null || config.Contains("glFramebufferTexture3DEXT")) {
            //    glFramebufferTexture3DEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, GLint, GLint, void>)GetProcAddress("glFramebufferTexture3DEXT");
            //}
            //if (config == null || config.Contains("glFramebufferTexture3DOES")) {
            //    glFramebufferTexture3DOES = (delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, GLint, GLint, void>)GetProcAddress("glFramebufferTexture3DOES");
            //}
            //if (config == null || config.Contains("glFramebufferTextureARB")) {
            //    glFramebufferTextureARB = (delegate* unmanaged<GLenum, GLenum, GLuint, GLint, void>)GetProcAddress("glFramebufferTextureARB");
            //}
            //if (config == null || config.Contains("glFramebufferTextureEXT")) {
            //    glFramebufferTextureEXT = (delegate* unmanaged<GLenum, GLenum, GLuint, GLint, void>)GetProcAddress("glFramebufferTextureEXT");
            //}
            //if (config == null || config.Contains("glFramebufferTextureFaceARB")) {
            //    glFramebufferTextureFaceARB = (delegate* unmanaged<GLenum, GLenum, GLuint, GLint, GLenum, void>)GetProcAddress("glFramebufferTextureFaceARB");
            //}
            //if (config == null || config.Contains("glFramebufferTextureFaceEXT")) {
            //    glFramebufferTextureFaceEXT = (delegate* unmanaged<GLenum, GLenum, GLuint, GLint, GLenum, void>)GetProcAddress("glFramebufferTextureFaceEXT");
            //}
            //if (config == null || config.Contains("glFramebufferTextureLayer")) {
            //    glFramebufferTextureLayer = (delegate* unmanaged<GLenum, GLenum, GLuint, GLint, GLint, void>)GetProcAddress("glFramebufferTextureLayer");
            //}
            //if (config == null || config.Contains("glFramebufferTextureLayerARB")) {
            //    glFramebufferTextureLayerARB = (delegate* unmanaged<GLenum, GLenum, GLuint, GLint, GLint, void>)GetProcAddress("glFramebufferTextureLayerARB");
            //}
            //if (config == null || config.Contains("glFramebufferTextureLayerEXT")) {
            //    glFramebufferTextureLayerEXT = (delegate* unmanaged<GLenum, GLenum, GLuint, GLint, GLint, void>)GetProcAddress("glFramebufferTextureLayerEXT");
            //}
            //if (config == null || config.Contains("glFramebufferTextureLayerDownsampleIMG")) {
            //    glFramebufferTextureLayerDownsampleIMG = (delegate* unmanaged<GLenum, GLenum, GLuint, GLint, GLint, GLint, GLint, void>)GetProcAddress("glFramebufferTextureLayerDownsampleIMG");
            //}
            //if (config == null || config.Contains("glFramebufferTextureMultisampleMultiviewOVR")) {
            //    glFramebufferTextureMultisampleMultiviewOVR = (delegate* unmanaged<GLenum, GLenum, GLuint, GLint, GLsizei, GLint, GLsizei, void>)GetProcAddress("glFramebufferTextureMultisampleMultiviewOVR");
            //}
            //if (config == null || config.Contains("glFramebufferTextureMultiviewOVR")) {
            //    glFramebufferTextureMultiviewOVR = (delegate* unmanaged<GLenum, GLenum, GLuint, GLint, GLint, GLsizei, void>)GetProcAddress("glFramebufferTextureMultiviewOVR");
            //}
            //if (config == null || config.Contains("glFramebufferTextureOES")) {
            //    glFramebufferTextureOES = (delegate* unmanaged<GLenum, GLenum, GLuint, GLint, void>)GetProcAddress("glFramebufferTextureOES");
            //}
            //if (config == null || config.Contains("glFreeObjectBufferATI")) {
            //    glFreeObjectBufferATI = (delegate* unmanaged<GLuint, void>)GetProcAddress("glFreeObjectBufferATI");
            //}
            //if (config == null || config.Contains("glFrontFace")) {
            //    glFrontFace = (delegate* unmanaged<GLenum, void>)GetProcAddress("glFrontFace");
            //}
            //if (config == null || config.Contains("glFrustum")) {
            //    glFrustum = (delegate* unmanaged<GLdouble, GLdouble, GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glFrustum");
            //}
            //if (config == null || config.Contains("glFrustumf")) {
            //    glFrustumf = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glFrustumf");
            //}
            //if (config == null || config.Contains("glFrustumfOES")) {
            //    glFrustumfOES = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glFrustumfOES");
            //}
            //if (config == null || config.Contains("glFrustumx")) {
            //    glFrustumx = (delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glFrustumx");
            //}
            //if (config == null || config.Contains("glFrustumxOES")) {
            //    glFrustumxOES = (delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glFrustumxOES");
            //}
            //if (config == null || config.Contains("glGenAsyncMarkersSGIX")) {
            //    glGenAsyncMarkersSGIX = (delegate* unmanaged<GLsizei, GLuint>)GetProcAddress("glGenAsyncMarkersSGIX");
            //}
            //if (config == null || config.Contains("glGenBuffers")) {
            //    glGenBuffers = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenBuffers");
            //}
            //if (config == null || config.Contains("glGenBuffersARB")) {
            //    glGenBuffersARB = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenBuffersARB");
            //}
            //if (config == null || config.Contains("glGenFencesAPPLE")) {
            //    glGenFencesAPPLE = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenFencesAPPLE");
            //}
            //if (config == null || config.Contains("glGenFencesNV")) {
            //    glGenFencesNV = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenFencesNV");
            //}
            //if (config == null || config.Contains("glGenFragmentShadersATI")) {
            //    glGenFragmentShadersATI = (delegate* unmanaged<GLuint, GLuint>)GetProcAddress("glGenFragmentShadersATI");
            //}
            //if (config == null || config.Contains("glGenFramebuffers")) {
            //    glGenFramebuffers = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenFramebuffers");
            //}
            //if (config == null || config.Contains("glGenFramebuffersEXT")) {
            //    glGenFramebuffersEXT = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenFramebuffersEXT");
            //}
            //if (config == null || config.Contains("glGenFramebuffersOES")) {
            //    glGenFramebuffersOES = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenFramebuffersOES");
            //}
            //if (config == null || config.Contains("glGenLists")) {
            //    glGenLists = (delegate* unmanaged<GLsizei, GLuint>)GetProcAddress("glGenLists");
            //}
            //if (config == null || config.Contains("glGenNamesAMD")) {
            //    glGenNamesAMD = (delegate* unmanaged<GLenum, GLuint, GLuint[], void>)GetProcAddress("glGenNamesAMD");
            //}
            //if (config == null || config.Contains("glGenOcclusionQueriesNV")) {
            //    glGenOcclusionQueriesNV = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenOcclusionQueriesNV");
            //}
            //if (config == null || config.Contains("glGenPathsNV")) {
            //    glGenPathsNV = (delegate* unmanaged<GLsizei, GLuint>)GetProcAddress("glGenPathsNV");
            //}
            //if (config == null || config.Contains("glGenPerfMonitorsAMD")) {
            //    glGenPerfMonitorsAMD = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenPerfMonitorsAMD");
            //}
            //if (config == null || config.Contains("glGenProgramPipelines")) {
            //    glGenProgramPipelines = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenProgramPipelines");
            //}
            //if (config == null || config.Contains("glGenProgramPipelinesEXT")) {
            //    glGenProgramPipelinesEXT = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenProgramPipelinesEXT");
            //}
            //if (config == null || config.Contains("glGenProgramsARB")) {
            //    glGenProgramsARB = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenProgramsARB");
            //}
            //if (config == null || config.Contains("glGenProgramsNV")) {
            //    glGenProgramsNV = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenProgramsNV");
            //}
            //if (config == null || config.Contains("glGenQueries")) {
            //    glGenQueries = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenQueries");
            //}
            //if (config == null || config.Contains("glGenQueriesARB")) {
            //    glGenQueriesARB = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenQueriesARB");
            //}
            //if (config == null || config.Contains("glGenQueriesEXT")) {
            //    glGenQueriesEXT = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenQueriesEXT");
            //}
            //if (config == null || config.Contains("glGenQueryResourceTagNV")) {
            //    glGenQueryResourceTagNV = (delegate* unmanaged<GLsizei, GLint[], void>)GetProcAddress("glGenQueryResourceTagNV");
            //}
            //if (config == null || config.Contains("glGenRenderbuffers")) {
            //    glGenRenderbuffers = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenRenderbuffers");
            //}
            //if (config == null || config.Contains("glGenRenderbuffersEXT")) {
            //    glGenRenderbuffersEXT = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenRenderbuffersEXT");
            //}
            //if (config == null || config.Contains("glGenRenderbuffersOES")) {
            //    glGenRenderbuffersOES = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenRenderbuffersOES");
            //}
            //if (config == null || config.Contains("glGenSamplers")) {
            //    glGenSamplers = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenSamplers");
            //}
            //if (config == null || config.Contains("glGenSemaphoresEXT")) {
            //    glGenSemaphoresEXT = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenSemaphoresEXT");
            //}
            //if (config == null || config.Contains("glGenSymbolsEXT")) {
            //    glGenSymbolsEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, GLuint>)GetProcAddress("glGenSymbolsEXT");
            //}
            //if (config == null || config.Contains("glGenTextures")) {
            //    glGenTextures = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenTextures");
            //}
            //if (config == null || config.Contains("glGenTexturesEXT")) {
            //    glGenTexturesEXT = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenTexturesEXT");
            //}
            //if (config == null || config.Contains("glGenTransformFeedbacks")) {
            //    glGenTransformFeedbacks = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenTransformFeedbacks");
            //}
            //if (config == null || config.Contains("glGenTransformFeedbacksNV")) {
            //    glGenTransformFeedbacksNV = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenTransformFeedbacksNV");
            //}
            //if (config == null || config.Contains("glGenVertexArrays")) {
            //    glGenVertexArrays = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenVertexArrays");
            //}
            //if (config == null || config.Contains("glGenVertexArraysAPPLE")) {
            //    glGenVertexArraysAPPLE = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenVertexArraysAPPLE");
            //}
            //if (config == null || config.Contains("glGenVertexArraysOES")) {
            //    glGenVertexArraysOES = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glGenVertexArraysOES");
            //}
            //if (config == null || config.Contains("glGenVertexShadersEXT")) {
            //    glGenVertexShadersEXT = (delegate* unmanaged<GLuint, GLuint>)GetProcAddress("glGenVertexShadersEXT");
            //}
            //if (config == null || config.Contains("glGenerateMipmap")) {
            //    glGenerateMipmap = (delegate* unmanaged<GLenum, void>)GetProcAddress("glGenerateMipmap");
            //}
            //if (config == null || config.Contains("glGenerateMipmapEXT")) {
            //    glGenerateMipmapEXT = (delegate* unmanaged<GLenum, void>)GetProcAddress("glGenerateMipmapEXT");
            //}
            //if (config == null || config.Contains("glGenerateMipmapOES")) {
            //    glGenerateMipmapOES = (delegate* unmanaged<GLenum, void>)GetProcAddress("glGenerateMipmapOES");
            //}
            //if (config == null || config.Contains("glGenerateMultiTexMipmapEXT")) {
            //    glGenerateMultiTexMipmapEXT = (delegate* unmanaged<GLenum, GLenum, void>)GetProcAddress("glGenerateMultiTexMipmapEXT");
            //}
            //if (config == null || config.Contains("glGenerateTextureMipmap")) {
            //    glGenerateTextureMipmap = (delegate* unmanaged<GLuint, void>)GetProcAddress("glGenerateTextureMipmap");
            //}
            //if (config == null || config.Contains("glGenerateTextureMipmapEXT")) {
            //    glGenerateTextureMipmapEXT = (delegate* unmanaged<GLuint, GLenum, void>)GetProcAddress("glGenerateTextureMipmapEXT");
            //}
            //if (config == null || config.Contains("glGetActiveAtomicCounterBufferiv")) {
            //    glGetActiveAtomicCounterBufferiv = (delegate* unmanaged<GLuint, GLuint, GLenum, GLint[], void>)GetProcAddress("glGetActiveAtomicCounterBufferiv");
            //}
            //if (config == null || config.Contains("glGetActiveAttrib")) {
            //    glGetActiveAttrib = (delegate* unmanaged<GLuint, GLuint, GLsizei, GLsizei[], GLint[], GLenum[], string, void>)GetProcAddress("glGetActiveAttrib");
            //}
            //if (config == null || config.Contains("glGetActiveAttribARB")) {
            //    glGetActiveAttribARB = (delegate* unmanaged<GLhandleARB, GLuint, GLsizei, GLsizei[], GLint[], GLenum[], string, void>)GetProcAddress("glGetActiveAttribARB");
            //}
            //if (config == null || config.Contains("glGetActiveSubroutineName")) {
            //    glGetActiveSubroutineName = (delegate* unmanaged<GLuint, GLenum, GLuint, GLsizei, GLsizei[], string, void>)GetProcAddress("glGetActiveSubroutineName");
            //}
            //if (config == null || config.Contains("glGetActiveSubroutineUniformName")) {
            //    glGetActiveSubroutineUniformName = (delegate* unmanaged<GLuint, GLenum, GLuint, GLsizei, GLsizei[], string, void>)GetProcAddress("glGetActiveSubroutineUniformName");
            //}
            //if (config == null || config.Contains("glGetActiveSubroutineUniformiv")) {
            //    glGetActiveSubroutineUniformiv = (delegate* unmanaged<GLuint, GLenum, GLuint, GLenum, GLint[], void>)GetProcAddress("glGetActiveSubroutineUniformiv");
            //}
            //if (config == null || config.Contains("glGetActiveUniform")) {
            //    glGetActiveUniform = (delegate* unmanaged<GLuint, GLuint, GLsizei, GLsizei[], GLint[], GLenum[], string, void>)GetProcAddress("glGetActiveUniform");
            //}
            //if (config == null || config.Contains("glGetActiveUniformARB")) {
            //    glGetActiveUniformARB = (delegate* unmanaged<GLhandleARB, GLuint, GLsizei, GLsizei[], GLint[], GLenum[], string, void>)GetProcAddress("glGetActiveUniformARB");
            //}
            //if (config == null || config.Contains("glGetActiveUniformBlockName")) {
            //    glGetActiveUniformBlockName = (delegate* unmanaged<GLuint, GLuint, GLsizei, GLsizei[], string, void>)GetProcAddress("glGetActiveUniformBlockName");
            //}
            //if (config == null || config.Contains("glGetActiveUniformBlockiv")) {
            //    glGetActiveUniformBlockiv = (delegate* unmanaged<GLuint, GLuint, GLenum, GLint[], void>)GetProcAddress("glGetActiveUniformBlockiv");
            //}
            //if (config == null || config.Contains("glGetActiveUniformName")) {
            //    glGetActiveUniformName = (delegate* unmanaged<GLuint, GLuint, GLsizei, GLsizei[], string, void>)GetProcAddress("glGetActiveUniformName");
            //}
            //if (config == null || config.Contains("glGetActiveUniformsiv")) {
            //    glGetActiveUniformsiv = (delegate* unmanaged<GLuint, GLsizei, GLuint[], GLenum, GLint[], void>)GetProcAddress("glGetActiveUniformsiv");
            //}
            //if (config == null || config.Contains("glGetActiveVaryingNV")) {
            //    glGetActiveVaryingNV = (delegate* unmanaged<GLuint, GLuint, GLsizei, GLsizei[], GLsizei[], GLenum[], string, void>)GetProcAddress("glGetActiveVaryingNV");
            //}
            //if (config == null || config.Contains("glGetArrayObjectfvATI")) {
            //    glGetArrayObjectfvATI = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetArrayObjectfvATI");
            //}
            //if (config == null || config.Contains("glGetArrayObjectivATI")) {
            //    glGetArrayObjectivATI = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetArrayObjectivATI");
            //}
            //if (config == null || config.Contains("glGetAttachedObjectsARB")) {
            //    glGetAttachedObjectsARB = (delegate* unmanaged<GLhandleARB, GLsizei, GLsizei[], GLhandleARB[], void>)GetProcAddress("glGetAttachedObjectsARB");
            //}
            //if (config == null || config.Contains("glGetAttachedShaders")) {
            //    glGetAttachedShaders = (delegate* unmanaged<GLuint, GLsizei, GLsizei[], GLuint[], void>)GetProcAddress("glGetAttachedShaders");
            //}
            //if (config == null || config.Contains("glGetAttribLocation")) {
            //    glGetAttribLocation = (delegate* unmanaged<GLuint, string, GLint>)GetProcAddress("glGetAttribLocation");
            //}
            //if (config == null || config.Contains("glGetAttribLocationARB")) {
            //    glGetAttribLocationARB = (delegate* unmanaged<GLhandleARB, string, GLint>)GetProcAddress("glGetAttribLocationARB");
            //}
            //if (config == null || config.Contains("glGetBooleanIndexedvEXT")) {
            //    glGetBooleanIndexedvEXT = (delegate* unmanaged<GLenum, GLuint, GLboolean[], void>)GetProcAddress("glGetBooleanIndexedvEXT");
            //}
            //if (config == null || config.Contains("glGetBooleani_v")) {
            //    glGetBooleani_v = (delegate* unmanaged<GLenum, GLuint, GLboolean[], void>)GetProcAddress("glGetBooleani_v");
            //}
            //if (config == null || config.Contains("glGetBooleanv")) {
            //    glGetBooleanv = (delegate* unmanaged<GLenum, GLboolean[], void>)GetProcAddress("glGetBooleanv");
            //}
            //if (config == null || config.Contains("glGetBufferParameteri64v")) {
            //    glGetBufferParameteri64v = (delegate* unmanaged<GLenum, GLenum, GLint64[], void>)GetProcAddress("glGetBufferParameteri64v");
            //}
            //if (config == null || config.Contains("glGetBufferParameteriv")) {
            //    glGetBufferParameteriv = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetBufferParameteriv");
            //}
            //if (config == null || config.Contains("glGetBufferParameterivARB")) {
            //    glGetBufferParameterivARB = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetBufferParameterivARB");
            //}
            //if (config == null || config.Contains("glGetBufferParameterui64vNV")) {
            //    glGetBufferParameterui64vNV = (delegate* unmanaged<GLenum, GLenum, GLuint64EXT[], void>)GetProcAddress("glGetBufferParameterui64vNV");
            //}
            //if (config == null || config.Contains("glGetBufferPointerv")) {
            //    glGetBufferPointerv = (delegate* unmanaged<GLenum, GLenum, IntPtr, void>)GetProcAddress("glGetBufferPointerv");
            //}
            //if (config == null || config.Contains("glGetBufferPointervARB")) {
            //    glGetBufferPointervARB = (delegate* unmanaged<GLenum, GLenum, IntPtr, void>)GetProcAddress("glGetBufferPointervARB");
            //}
            //if (config == null || config.Contains("glGetBufferPointervOES")) {
            //    glGetBufferPointervOES = (delegate* unmanaged<GLenum, GLenum, IntPtr, void>)GetProcAddress("glGetBufferPointervOES");
            //}
            //if (config == null || config.Contains("glGetBufferSubData")) {
            //    glGetBufferSubData = (delegate* unmanaged<GLenum, GLintptr, GLsizeiptr, IntPtr, void>)GetProcAddress("glGetBufferSubData");
            //}
            //if (config == null || config.Contains("glGetBufferSubDataARB")) {
            //    glGetBufferSubDataARB = (delegate* unmanaged<GLenum, GLintptrARB, GLsizeiptrARB, IntPtr, void>)GetProcAddress("glGetBufferSubDataARB");
            //}
            //if (config == null || config.Contains("glGetClipPlane")) {
            //    glGetClipPlane = (delegate* unmanaged<GLenum, GLdouble[], void>)GetProcAddress("glGetClipPlane");
            //}
            //if (config == null || config.Contains("glGetClipPlanef")) {
            //    glGetClipPlanef = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glGetClipPlanef");
            //}
            //if (config == null || config.Contains("glGetClipPlanefOES")) {
            //    glGetClipPlanefOES = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glGetClipPlanefOES");
            //}
            //if (config == null || config.Contains("glGetClipPlanex")) {
            //    glGetClipPlanex = (delegate* unmanaged<GLenum, GLfixed[], void>)GetProcAddress("glGetClipPlanex");
            //}
            //if (config == null || config.Contains("glGetClipPlanexOES")) {
            //    glGetClipPlanexOES = (delegate* unmanaged<GLenum, GLfixed[], void>)GetProcAddress("glGetClipPlanexOES");
            //}
            //if (config == null || config.Contains("glGetColorTable")) {
            //    glGetColorTable = (delegate* unmanaged<GLenum, GLenum, GLenum, IntPtr, void>)GetProcAddress("glGetColorTable");
            //}
            //if (config == null || config.Contains("glGetColorTableEXT")) {
            //    glGetColorTableEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, IntPtr, void>)GetProcAddress("glGetColorTableEXT");
            //}
            //if (config == null || config.Contains("glGetColorTableParameterfv")) {
            //    glGetColorTableParameterfv = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetColorTableParameterfv");
            //}
            //if (config == null || config.Contains("glGetColorTableParameterfvEXT")) {
            //    glGetColorTableParameterfvEXT = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetColorTableParameterfvEXT");
            //}
            //if (config == null || config.Contains("glGetColorTableParameterfvSGI")) {
            //    glGetColorTableParameterfvSGI = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetColorTableParameterfvSGI");
            //}
            //if (config == null || config.Contains("glGetColorTableParameteriv")) {
            //    glGetColorTableParameteriv = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetColorTableParameteriv");
            //}
            //if (config == null || config.Contains("glGetColorTableParameterivEXT")) {
            //    glGetColorTableParameterivEXT = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetColorTableParameterivEXT");
            //}
            //if (config == null || config.Contains("glGetColorTableParameterivSGI")) {
            //    glGetColorTableParameterivSGI = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetColorTableParameterivSGI");
            //}
            //if (config == null || config.Contains("glGetColorTableSGI")) {
            //    glGetColorTableSGI = (delegate* unmanaged<GLenum, GLenum, GLenum, IntPtr, void>)GetProcAddress("glGetColorTableSGI");
            //}
            //if (config == null || config.Contains("glGetCombinerInputParameterfvNV")) {
            //    glGetCombinerInputParameterfvNV = (delegate* unmanaged<GLenum, GLenum, GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetCombinerInputParameterfvNV");
            //}
            //if (config == null || config.Contains("glGetCombinerInputParameterivNV")) {
            //    glGetCombinerInputParameterivNV = (delegate* unmanaged<GLenum, GLenum, GLenum, GLenum, GLint[], void>)GetProcAddress("glGetCombinerInputParameterivNV");
            //}
            //if (config == null || config.Contains("glGetCombinerOutputParameterfvNV")) {
            //    glGetCombinerOutputParameterfvNV = (delegate* unmanaged<GLenum, GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetCombinerOutputParameterfvNV");
            //}
            //if (config == null || config.Contains("glGetCombinerOutputParameterivNV")) {
            //    glGetCombinerOutputParameterivNV = (delegate* unmanaged<GLenum, GLenum, GLenum, GLint[], void>)GetProcAddress("glGetCombinerOutputParameterivNV");
            //}
            //if (config == null || config.Contains("glGetCombinerStageParameterfvNV")) {
            //    glGetCombinerStageParameterfvNV = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetCombinerStageParameterfvNV");
            //}
            //if (config == null || config.Contains("glGetCommandHeaderNV")) {
            //    glGetCommandHeaderNV = (delegate* unmanaged<GLenum, GLuint, GLuint>)GetProcAddress("glGetCommandHeaderNV");
            //}
            //if (config == null || config.Contains("glGetCompressedMultiTexImageEXT")) {
            //    glGetCompressedMultiTexImageEXT = (delegate* unmanaged<GLenum, GLenum, GLint, IntPtr, void>)GetProcAddress("glGetCompressedMultiTexImageEXT");
            //}
            //if (config == null || config.Contains("glGetCompressedTexImage")) {
            //    glGetCompressedTexImage = (delegate* unmanaged<GLenum, GLint, IntPtr, void>)GetProcAddress("glGetCompressedTexImage");
            //}
            //if (config == null || config.Contains("glGetCompressedTexImageARB")) {
            //    glGetCompressedTexImageARB = (delegate* unmanaged<GLenum, GLint, IntPtr, void>)GetProcAddress("glGetCompressedTexImageARB");
            //}
            //if (config == null || config.Contains("glGetCompressedTextureImage")) {
            //    glGetCompressedTextureImage = (delegate* unmanaged<GLuint, GLint, GLsizei, IntPtr, void>)GetProcAddress("glGetCompressedTextureImage");
            //}
            //if (config == null || config.Contains("glGetCompressedTextureImageEXT")) {
            //    glGetCompressedTextureImageEXT = (delegate* unmanaged<GLuint, GLenum, GLint, IntPtr, void>)GetProcAddress("glGetCompressedTextureImageEXT");
            //}
            //if (config == null || config.Contains("glGetCompressedTextureSubImage")) {
            //    glGetCompressedTextureSubImage = (delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLsizei, IntPtr, void>)GetProcAddress("glGetCompressedTextureSubImage");
            //}
            //if (config == null || config.Contains("glGetConvolutionFilter")) {
            //    glGetConvolutionFilter = (delegate* unmanaged<GLenum, GLenum, GLenum, IntPtr, void>)GetProcAddress("glGetConvolutionFilter");
            //}
            //if (config == null || config.Contains("glGetConvolutionFilterEXT")) {
            //    glGetConvolutionFilterEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, IntPtr, void>)GetProcAddress("glGetConvolutionFilterEXT");
            //}
            //if (config == null || config.Contains("glGetConvolutionParameterfv")) {
            //    glGetConvolutionParameterfv = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetConvolutionParameterfv");
            //}
            //if (config == null || config.Contains("glGetConvolutionParameterfvEXT")) {
            //    glGetConvolutionParameterfvEXT = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetConvolutionParameterfvEXT");
            //}
            //if (config == null || config.Contains("glGetConvolutionParameteriv")) {
            //    glGetConvolutionParameteriv = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetConvolutionParameteriv");
            //}
            //if (config == null || config.Contains("glGetConvolutionParameterivEXT")) {
            //    glGetConvolutionParameterivEXT = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetConvolutionParameterivEXT");
            //}
            //if (config == null || config.Contains("glGetConvolutionParameterxvOES")) {
            //    glGetConvolutionParameterxvOES = (delegate* unmanaged<GLenum, GLenum, GLfixed[], void>)GetProcAddress("glGetConvolutionParameterxvOES");
            //}
            //if (config == null || config.Contains("glGetCoverageModulationTableNV")) {
            //    glGetCoverageModulationTableNV = (delegate* unmanaged<GLsizei, GLfloat[], void>)GetProcAddress("glGetCoverageModulationTableNV");
            //}
            //if (config == null || config.Contains("glGetDebugMessageLog")) {
            //    glGetDebugMessageLog = (delegate* unmanaged<GLuint, GLsizei, GLenum[], GLenum[], GLuint[], GLenum[], GLsizei[], string, GLuint>)GetProcAddress("glGetDebugMessageLog");
            //}
            //if (config == null || config.Contains("glGetDebugMessageLogAMD")) {
            //    glGetDebugMessageLogAMD = (delegate* unmanaged<GLuint, GLsizei, GLenum[], GLuint[], GLuint[], GLsizei[], string, GLuint>)GetProcAddress("glGetDebugMessageLogAMD");
            //}
            //if (config == null || config.Contains("glGetDebugMessageLogARB")) {
            //    glGetDebugMessageLogARB = (delegate* unmanaged<GLuint, GLsizei, GLenum[], GLenum[], GLuint[], GLenum[], GLsizei[], string, GLuint>)GetProcAddress("glGetDebugMessageLogARB");
            //}
            //if (config == null || config.Contains("glGetDebugMessageLogKHR")) {
            //    glGetDebugMessageLogKHR = (delegate* unmanaged<GLuint, GLsizei, GLenum[], GLenum[], GLuint[], GLenum[], GLsizei[], string, GLuint>)GetProcAddress("glGetDebugMessageLogKHR");
            //}
            //if (config == null || config.Contains("glGetDetailTexFuncSGIS")) {
            //    glGetDetailTexFuncSGIS = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glGetDetailTexFuncSGIS");
            //}
            //if (config == null || config.Contains("glGetDoubleIndexedvEXT")) {
            //    glGetDoubleIndexedvEXT = (delegate* unmanaged<GLenum, GLuint, GLdouble[], void>)GetProcAddress("glGetDoubleIndexedvEXT");
            //}
            //if (config == null || config.Contains("glGetDoublei_v")) {
            //    glGetDoublei_v = (delegate* unmanaged<GLenum, GLuint, GLdouble[], void>)GetProcAddress("glGetDoublei_v");
            //}
            //if (config == null || config.Contains("glGetDoublei_vEXT")) {
            //    glGetDoublei_vEXT = (delegate* unmanaged<GLenum, GLuint, GLdouble[], void>)GetProcAddress("glGetDoublei_vEXT");
            //}
            //if (config == null || config.Contains("glGetDoublev")) {
            //    glGetDoublev = (delegate* unmanaged<GLenum, GLdouble[], void>)GetProcAddress("glGetDoublev");
            //}
            //if (config == null || config.Contains("glGetDriverControlStringQCOM")) {
            //    glGetDriverControlStringQCOM = (delegate* unmanaged<GLuint, GLsizei, GLsizei[], string, void>)GetProcAddress("glGetDriverControlStringQCOM");
            //}
            //if (config == null || config.Contains("glGetDriverControlsQCOM")) {
            //    glGetDriverControlsQCOM = (delegate* unmanaged<GLint[], GLsizei, GLuint[], void>)GetProcAddress("glGetDriverControlsQCOM");
            //}
            //if (config == null || config.Contains("glGetError")) {
            //    glGetError = (delegate* unmanaged<GLenum>)GetProcAddress("glGetError");
            //}
            //if (config == null || config.Contains("glGetFenceivNV")) {
            //    glGetFenceivNV = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetFenceivNV");
            //}
            //if (config == null || config.Contains("glGetFinalCombinerInputParameterfvNV")) {
            //    glGetFinalCombinerInputParameterfvNV = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetFinalCombinerInputParameterfvNV");
            //}
            //if (config == null || config.Contains("glGetFinalCombinerInputParameterivNV")) {
            //    glGetFinalCombinerInputParameterivNV = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetFinalCombinerInputParameterivNV");
            //}
            //if (config == null || config.Contains("glGetFirstPerfQueryIdINTEL")) {
            //    glGetFirstPerfQueryIdINTEL = (delegate* unmanaged<GLuint[], void>)GetProcAddress("glGetFirstPerfQueryIdINTEL");
            //}
            //if (config == null || config.Contains("glGetFixedv")) {
            //    glGetFixedv = (delegate* unmanaged<GLenum, GLfixed[], void>)GetProcAddress("glGetFixedv");
            //}
            //if (config == null || config.Contains("glGetFixedvOES")) {
            //    glGetFixedvOES = (delegate* unmanaged<GLenum, GLfixed[], void>)GetProcAddress("glGetFixedvOES");
            //}
            //if (config == null || config.Contains("glGetFloatIndexedvEXT")) {
            //    glGetFloatIndexedvEXT = (delegate* unmanaged<GLenum, GLuint, GLfloat[], void>)GetProcAddress("glGetFloatIndexedvEXT");
            //}
            //if (config == null || config.Contains("glGetFloati_v")) {
            //    glGetFloati_v = (delegate* unmanaged<GLenum, GLuint, GLfloat[], void>)GetProcAddress("glGetFloati_v");
            //}
            //if (config == null || config.Contains("glGetFloati_vEXT")) {
            //    glGetFloati_vEXT = (delegate* unmanaged<GLenum, GLuint, GLfloat[], void>)GetProcAddress("glGetFloati_vEXT");
            //}
            //if (config == null || config.Contains("glGetFloati_vNV")) {
            //    glGetFloati_vNV = (delegate* unmanaged<GLenum, GLuint, GLfloat[], void>)GetProcAddress("glGetFloati_vNV");
            //}
            //if (config == null || config.Contains("glGetFloati_vOES")) {
            //    glGetFloati_vOES = (delegate* unmanaged<GLenum, GLuint, GLfloat[], void>)GetProcAddress("glGetFloati_vOES");
            //}
            //if (config == null || config.Contains("glGetFloatv")) {
            //    glGetFloatv = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glGetFloatv");
            //}
            //if (config == null || config.Contains("glGetFogFuncSGIS")) {
            //    glGetFogFuncSGIS = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glGetFogFuncSGIS");
            //}
            //if (config == null || config.Contains("glGetFragDataIndex")) {
            //    glGetFragDataIndex = (delegate* unmanaged<GLuint, string, GLint>)GetProcAddress("glGetFragDataIndex");
            //}
            //if (config == null || config.Contains("glGetFragDataIndexEXT")) {
            //    glGetFragDataIndexEXT = (delegate* unmanaged<GLuint, string, GLint>)GetProcAddress("glGetFragDataIndexEXT");
            //}
            //if (config == null || config.Contains("glGetFragDataLocation")) {
            //    glGetFragDataLocation = (delegate* unmanaged<GLuint, string, GLint>)GetProcAddress("glGetFragDataLocation");
            //}
            //if (config == null || config.Contains("glGetFragDataLocationEXT")) {
            //    glGetFragDataLocationEXT = (delegate* unmanaged<GLuint, string, GLint>)GetProcAddress("glGetFragDataLocationEXT");
            //}
            //if (config == null || config.Contains("glGetFragmentLightfvSGIX")) {
            //    glGetFragmentLightfvSGIX = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetFragmentLightfvSGIX");
            //}
            //if (config == null || config.Contains("glGetFragmentLightivSGIX")) {
            //    glGetFragmentLightivSGIX = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetFragmentLightivSGIX");
            //}
            //if (config == null || config.Contains("glGetFragmentMaterialfvSGIX")) {
            //    glGetFragmentMaterialfvSGIX = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetFragmentMaterialfvSGIX");
            //}
            //if (config == null || config.Contains("glGetFragmentMaterialivSGIX")) {
            //    glGetFragmentMaterialivSGIX = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetFragmentMaterialivSGIX");
            //}
            //if (config == null || config.Contains("glGetFramebufferAttachmentParameteriv")) {
            //    glGetFramebufferAttachmentParameteriv = (delegate* unmanaged<GLenum, GLenum, GLenum, GLint[], void>)GetProcAddress("glGetFramebufferAttachmentParameteriv");
            //}
            //if (config == null || config.Contains("glGetFramebufferAttachmentParameterivEXT")) {
            //    glGetFramebufferAttachmentParameterivEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLint[], void>)GetProcAddress("glGetFramebufferAttachmentParameterivEXT");
            //}
            //if (config == null || config.Contains("glGetFramebufferAttachmentParameterivOES")) {
            //    glGetFramebufferAttachmentParameterivOES = (delegate* unmanaged<GLenum, GLenum, GLenum, GLint[], void>)GetProcAddress("glGetFramebufferAttachmentParameterivOES");
            //}
            //if (config == null || config.Contains("glGetFramebufferParameterfvAMD")) {
            //    glGetFramebufferParameterfvAMD = (delegate* unmanaged<GLenum, GLenum, GLuint, GLuint, GLsizei, GLfloat[], void>)GetProcAddress("glGetFramebufferParameterfvAMD");
            //}
            //if (config == null || config.Contains("glGetFramebufferParameteriv")) {
            //    glGetFramebufferParameteriv = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetFramebufferParameteriv");
            //}
            //if (config == null || config.Contains("glGetFramebufferParameterivEXT")) {
            //    glGetFramebufferParameterivEXT = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetFramebufferParameterivEXT");
            //}
            //if (config == null || config.Contains("glGetFramebufferPixelLocalStorageSizeEXT")) {
            //    glGetFramebufferPixelLocalStorageSizeEXT = (delegate* unmanaged<GLuint, GLsizei>)GetProcAddress("glGetFramebufferPixelLocalStorageSizeEXT");
            //}
            //if (config == null || config.Contains("glGetGraphicsResetStatus")) {
            //    glGetGraphicsResetStatus = (delegate* unmanaged<GLenum>)GetProcAddress("glGetGraphicsResetStatus");
            //}
            //if (config == null || config.Contains("glGetGraphicsResetStatusARB")) {
            //    glGetGraphicsResetStatusARB = (delegate* unmanaged<GLenum>)GetProcAddress("glGetGraphicsResetStatusARB");
            //}
            //if (config == null || config.Contains("glGetGraphicsResetStatusEXT")) {
            //    glGetGraphicsResetStatusEXT = (delegate* unmanaged<GLenum>)GetProcAddress("glGetGraphicsResetStatusEXT");
            //}
            //if (config == null || config.Contains("glGetGraphicsResetStatusKHR")) {
            //    glGetGraphicsResetStatusKHR = (delegate* unmanaged<GLenum>)GetProcAddress("glGetGraphicsResetStatusKHR");
            //}
            //if (config == null || config.Contains("glGetHandleARB")) {
            //    glGetHandleARB = (delegate* unmanaged<GLenum, GLhandleARB>)GetProcAddress("glGetHandleARB");
            //}
            //if (config == null || config.Contains("glGetHistogram")) {
            //    glGetHistogram = (delegate* unmanaged<GLenum, GLboolean, GLenum, GLenum, IntPtr, void>)GetProcAddress("glGetHistogram");
            //}
            //if (config == null || config.Contains("glGetHistogramEXT")) {
            //    glGetHistogramEXT = (delegate* unmanaged<GLenum, GLboolean, GLenum, GLenum, IntPtr, void>)GetProcAddress("glGetHistogramEXT");
            //}
            //if (config == null || config.Contains("glGetHistogramParameterfv")) {
            //    glGetHistogramParameterfv = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetHistogramParameterfv");
            //}
            //if (config == null || config.Contains("glGetHistogramParameterfvEXT")) {
            //    glGetHistogramParameterfvEXT = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetHistogramParameterfvEXT");
            //}
            //if (config == null || config.Contains("glGetHistogramParameteriv")) {
            //    glGetHistogramParameteriv = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetHistogramParameteriv");
            //}
            //if (config == null || config.Contains("glGetHistogramParameterivEXT")) {
            //    glGetHistogramParameterivEXT = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetHistogramParameterivEXT");
            //}
            //if (config == null || config.Contains("glGetHistogramParameterxvOES")) {
            //    glGetHistogramParameterxvOES = (delegate* unmanaged<GLenum, GLenum, GLfixed[], void>)GetProcAddress("glGetHistogramParameterxvOES");
            //}
            //if (config == null || config.Contains("glGetImageHandleARB")) {
            //    glGetImageHandleARB = (delegate* unmanaged<GLuint, GLint, GLboolean, GLint, GLenum, GLuint64>)GetProcAddress("glGetImageHandleARB");
            //}
            //if (config == null || config.Contains("glGetImageHandleNV")) {
            //    glGetImageHandleNV = (delegate* unmanaged<GLuint, GLint, GLboolean, GLint, GLenum, GLuint64>)GetProcAddress("glGetImageHandleNV");
            //}
            //if (config == null || config.Contains("glGetImageTransformParameterfvHP")) {
            //    glGetImageTransformParameterfvHP = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetImageTransformParameterfvHP");
            //}
            //if (config == null || config.Contains("glGetImageTransformParameterivHP")) {
            //    glGetImageTransformParameterivHP = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetImageTransformParameterivHP");
            //}
            //if (config == null || config.Contains("glGetInfoLogARB")) {
            //    glGetInfoLogARB = (delegate* unmanaged<GLhandleARB, GLsizei, GLsizei[], string, void>)GetProcAddress("glGetInfoLogARB");
            //}
            //if (config == null || config.Contains("glGetInstrumentsSGIX")) {
            //    glGetInstrumentsSGIX = (delegate* unmanaged<GLint>)GetProcAddress("glGetInstrumentsSGIX");
            //}
            //if (config == null || config.Contains("glGetInteger64i_v")) {
            //    glGetInteger64i_v = (delegate* unmanaged<GLenum, GLuint, GLint64[], void>)GetProcAddress("glGetInteger64i_v");
            //}
            //if (config == null || config.Contains("glGetInteger64v")) {
            //    glGetInteger64v = (delegate* unmanaged<GLenum, GLint64[], void>)GetProcAddress("glGetInteger64v");
            //}
            //if (config == null || config.Contains("glGetInteger64vAPPLE")) {
            //    glGetInteger64vAPPLE = (delegate* unmanaged<GLenum, GLint64[], void>)GetProcAddress("glGetInteger64vAPPLE");
            //}
            //if (config == null || config.Contains("glGetInteger64vEXT")) {
            //    glGetInteger64vEXT = (delegate* unmanaged<GLenum, GLint64[], void>)GetProcAddress("glGetInteger64vEXT");
            //}
            //if (config == null || config.Contains("glGetIntegerIndexedvEXT")) {
            //    glGetIntegerIndexedvEXT = (delegate* unmanaged<GLenum, GLuint, GLint[], void>)GetProcAddress("glGetIntegerIndexedvEXT");
            //}
            //if (config == null || config.Contains("glGetIntegeri_v")) {
            //    glGetIntegeri_v = (delegate* unmanaged<GLenum, GLuint, GLint[], void>)GetProcAddress("glGetIntegeri_v");
            //}
            //if (config == null || config.Contains("glGetIntegeri_vEXT")) {
            //    glGetIntegeri_vEXT = (delegate* unmanaged<GLenum, GLuint, GLint[], void>)GetProcAddress("glGetIntegeri_vEXT");
            //}
            //if (config == null || config.Contains("glGetIntegerui64i_vNV")) {
            //    glGetIntegerui64i_vNV = (delegate* unmanaged<GLenum, GLuint, GLuint64EXT[], void>)GetProcAddress("glGetIntegerui64i_vNV");
            //}
            //if (config == null || config.Contains("glGetIntegerui64vNV")) {
            //    glGetIntegerui64vNV = (delegate* unmanaged<GLenum, GLuint64EXT[], void>)GetProcAddress("glGetIntegerui64vNV");
            //}
            //if (config == null || config.Contains("glGetIntegerv")) {
            //    glGetIntegerv = (delegate* unmanaged<GLenum, GLint[], void>)GetProcAddress("glGetIntegerv");
            //}
            //if (config == null || config.Contains("glGetInternalformatSampleivNV")) {
            //    glGetInternalformatSampleivNV = (delegate* unmanaged<GLenum, GLenum, GLsizei, GLenum, GLsizei, GLint[], void>)GetProcAddress("glGetInternalformatSampleivNV");
            //}
            //if (config == null || config.Contains("glGetInternalformati64v")) {
            //    glGetInternalformati64v = (delegate* unmanaged<GLenum, GLenum, GLenum, GLsizei, GLint64[], void>)GetProcAddress("glGetInternalformati64v");
            //}
            //if (config == null || config.Contains("glGetInternalformativ")) {
            //    glGetInternalformativ = (delegate* unmanaged<GLenum, GLenum, GLenum, GLsizei, GLint[], void>)GetProcAddress("glGetInternalformativ");
            //}
            //if (config == null || config.Contains("glGetInvariantBooleanvEXT")) {
            //    glGetInvariantBooleanvEXT = (delegate* unmanaged<GLuint, GLenum, GLboolean[], void>)GetProcAddress("glGetInvariantBooleanvEXT");
            //}
            //if (config == null || config.Contains("glGetInvariantFloatvEXT")) {
            //    glGetInvariantFloatvEXT = (delegate* unmanaged<GLuint, GLenum, GLfloat[], void>)GetProcAddress("glGetInvariantFloatvEXT");
            //}
            //if (config == null || config.Contains("glGetInvariantIntegervEXT")) {
            //    glGetInvariantIntegervEXT = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetInvariantIntegervEXT");
            //}
            //if (config == null || config.Contains("glGetLightfv")) {
            //    glGetLightfv = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetLightfv");
            //}
            //if (config == null || config.Contains("glGetLightiv")) {
            //    glGetLightiv = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetLightiv");
            //}
            //if (config == null || config.Contains("glGetLightxOES")) {
            //    glGetLightxOES = (delegate* unmanaged<GLenum, GLenum, GLfixed[], void>)GetProcAddress("glGetLightxOES");
            //}
            //if (config == null || config.Contains("glGetLightxv")) {
            //    glGetLightxv = (delegate* unmanaged<GLenum, GLenum, GLfixed[], void>)GetProcAddress("glGetLightxv");
            //}
            //if (config == null || config.Contains("glGetLightxvOES")) {
            //    glGetLightxvOES = (delegate* unmanaged<GLenum, GLenum, GLfixed[], void>)GetProcAddress("glGetLightxvOES");
            //}
            //if (config == null || config.Contains("glGetListParameterfvSGIX")) {
            //    glGetListParameterfvSGIX = (delegate* unmanaged<GLuint, GLenum, GLfloat[], void>)GetProcAddress("glGetListParameterfvSGIX");
            //}
            //if (config == null || config.Contains("glGetListParameterivSGIX")) {
            //    glGetListParameterivSGIX = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetListParameterivSGIX");
            //}
            //if (config == null || config.Contains("glGetLocalConstantBooleanvEXT")) {
            //    glGetLocalConstantBooleanvEXT = (delegate* unmanaged<GLuint, GLenum, GLboolean[], void>)GetProcAddress("glGetLocalConstantBooleanvEXT");
            //}
            //if (config == null || config.Contains("glGetLocalConstantFloatvEXT")) {
            //    glGetLocalConstantFloatvEXT = (delegate* unmanaged<GLuint, GLenum, GLfloat[], void>)GetProcAddress("glGetLocalConstantFloatvEXT");
            //}
            //if (config == null || config.Contains("glGetLocalConstantIntegervEXT")) {
            //    glGetLocalConstantIntegervEXT = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetLocalConstantIntegervEXT");
            //}
            //if (config == null || config.Contains("glGetMapAttribParameterfvNV")) {
            //    glGetMapAttribParameterfvNV = (delegate* unmanaged<GLenum, GLuint, GLenum, GLfloat[], void>)GetProcAddress("glGetMapAttribParameterfvNV");
            //}
            //if (config == null || config.Contains("glGetMapAttribParameterivNV")) {
            //    glGetMapAttribParameterivNV = (delegate* unmanaged<GLenum, GLuint, GLenum, GLint[], void>)GetProcAddress("glGetMapAttribParameterivNV");
            //}
            //if (config == null || config.Contains("glGetMapControlPointsNV")) {
            //    glGetMapControlPointsNV = (delegate* unmanaged<GLenum, GLuint, GLenum, GLsizei, GLsizei, GLboolean, IntPtr, void>)GetProcAddress("glGetMapControlPointsNV");
            //}
            //if (config == null || config.Contains("glGetMapParameterfvNV")) {
            //    glGetMapParameterfvNV = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetMapParameterfvNV");
            //}
            //if (config == null || config.Contains("glGetMapParameterivNV")) {
            //    glGetMapParameterivNV = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetMapParameterivNV");
            //}
            //if (config == null || config.Contains("glGetMapdv")) {
            //    glGetMapdv = (delegate* unmanaged<GLenum, GLenum, GLdouble[], void>)GetProcAddress("glGetMapdv");
            //}
            //if (config == null || config.Contains("glGetMapfv")) {
            //    glGetMapfv = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetMapfv");
            //}
            //if (config == null || config.Contains("glGetMapiv")) {
            //    glGetMapiv = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetMapiv");
            //}
            //if (config == null || config.Contains("glGetMapxvOES")) {
            //    glGetMapxvOES = (delegate* unmanaged<GLenum, GLenum, GLfixed[], void>)GetProcAddress("glGetMapxvOES");
            //}
            //if (config == null || config.Contains("glGetMaterialfv")) {
            //    glGetMaterialfv = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetMaterialfv");
            //}
            //if (config == null || config.Contains("glGetMaterialiv")) {
            //    glGetMaterialiv = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetMaterialiv");
            //}
            //if (config == null || config.Contains("glGetMaterialxOES")) {
            //    glGetMaterialxOES = (delegate* unmanaged<GLenum, GLenum, GLfixed, void>)GetProcAddress("glGetMaterialxOES");
            //}
            //if (config == null || config.Contains("glGetMaterialxv")) {
            //    glGetMaterialxv = (delegate* unmanaged<GLenum, GLenum, GLfixed[], void>)GetProcAddress("glGetMaterialxv");
            //}
            //if (config == null || config.Contains("glGetMaterialxvOES")) {
            //    glGetMaterialxvOES = (delegate* unmanaged<GLenum, GLenum, GLfixed[], void>)GetProcAddress("glGetMaterialxvOES");
            //}
            //if (config == null || config.Contains("glGetMemoryObjectDetachedResourcesuivNV")) {
            //    glGetMemoryObjectDetachedResourcesuivNV = (delegate* unmanaged<GLuint, GLenum, GLint, GLsizei, GLuint[], void>)GetProcAddress("glGetMemoryObjectDetachedResourcesuivNV");
            //}
            //if (config == null || config.Contains("glGetMemoryObjectParameterivEXT")) {
            //    glGetMemoryObjectParameterivEXT = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetMemoryObjectParameterivEXT");
            //}
            //if (config == null || config.Contains("glGetMinmax")) {
            //    glGetMinmax = (delegate* unmanaged<GLenum, GLboolean, GLenum, GLenum, IntPtr, void>)GetProcAddress("glGetMinmax");
            //}
            //if (config == null || config.Contains("glGetMinmaxEXT")) {
            //    glGetMinmaxEXT = (delegate* unmanaged<GLenum, GLboolean, GLenum, GLenum, IntPtr, void>)GetProcAddress("glGetMinmaxEXT");
            //}
            //if (config == null || config.Contains("glGetMinmaxParameterfv")) {
            //    glGetMinmaxParameterfv = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetMinmaxParameterfv");
            //}
            //if (config == null || config.Contains("glGetMinmaxParameterfvEXT")) {
            //    glGetMinmaxParameterfvEXT = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetMinmaxParameterfvEXT");
            //}
            //if (config == null || config.Contains("glGetMinmaxParameteriv")) {
            //    glGetMinmaxParameteriv = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetMinmaxParameteriv");
            //}
            //if (config == null || config.Contains("glGetMinmaxParameterivEXT")) {
            //    glGetMinmaxParameterivEXT = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetMinmaxParameterivEXT");
            //}
            //if (config == null || config.Contains("glGetMultiTexEnvfvEXT")) {
            //    glGetMultiTexEnvfvEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetMultiTexEnvfvEXT");
            //}
            //if (config == null || config.Contains("glGetMultiTexEnvivEXT")) {
            //    glGetMultiTexEnvivEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLint[], void>)GetProcAddress("glGetMultiTexEnvivEXT");
            //}
            //if (config == null || config.Contains("glGetMultiTexGendvEXT")) {
            //    glGetMultiTexGendvEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLdouble[], void>)GetProcAddress("glGetMultiTexGendvEXT");
            //}
            //if (config == null || config.Contains("glGetMultiTexGenfvEXT")) {
            //    glGetMultiTexGenfvEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetMultiTexGenfvEXT");
            //}
            //if (config == null || config.Contains("glGetMultiTexGenivEXT")) {
            //    glGetMultiTexGenivEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLint[], void>)GetProcAddress("glGetMultiTexGenivEXT");
            //}
            //if (config == null || config.Contains("glGetMultiTexImageEXT")) {
            //    glGetMultiTexImageEXT = (delegate* unmanaged<GLenum, GLenum, GLint, GLenum, GLenum, IntPtr, void>)GetProcAddress("glGetMultiTexImageEXT");
            //}
            //if (config == null || config.Contains("glGetMultiTexLevelParameterfvEXT")) {
            //    glGetMultiTexLevelParameterfvEXT = (delegate* unmanaged<GLenum, GLenum, GLint, GLenum, GLfloat[], void>)GetProcAddress("glGetMultiTexLevelParameterfvEXT");
            //}
            //if (config == null || config.Contains("glGetMultiTexLevelParameterivEXT")) {
            //    glGetMultiTexLevelParameterivEXT = (delegate* unmanaged<GLenum, GLenum, GLint, GLenum, GLint[], void>)GetProcAddress("glGetMultiTexLevelParameterivEXT");
            //}
            //if (config == null || config.Contains("glGetMultiTexParameterIivEXT")) {
            //    glGetMultiTexParameterIivEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLint[], void>)GetProcAddress("glGetMultiTexParameterIivEXT");
            //}
            //if (config == null || config.Contains("glGetMultiTexParameterIuivEXT")) {
            //    glGetMultiTexParameterIuivEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLuint[], void>)GetProcAddress("glGetMultiTexParameterIuivEXT");
            //}
            //if (config == null || config.Contains("glGetMultiTexParameterfvEXT")) {
            //    glGetMultiTexParameterfvEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetMultiTexParameterfvEXT");
            //}
            //if (config == null || config.Contains("glGetMultiTexParameterivEXT")) {
            //    glGetMultiTexParameterivEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLint[], void>)GetProcAddress("glGetMultiTexParameterivEXT");
            //}
            //if (config == null || config.Contains("glGetMultisamplefv")) {
            //    glGetMultisamplefv = (delegate* unmanaged<GLenum, GLuint, GLfloat[], void>)GetProcAddress("glGetMultisamplefv");
            //}
            //if (config == null || config.Contains("glGetMultisamplefvNV")) {
            //    glGetMultisamplefvNV = (delegate* unmanaged<GLenum, GLuint, GLfloat[], void>)GetProcAddress("glGetMultisamplefvNV");
            //}
            //if (config == null || config.Contains("glGetNamedBufferParameteri64v")) {
            //    glGetNamedBufferParameteri64v = (delegate* unmanaged<GLuint, GLenum, GLint64[], void>)GetProcAddress("glGetNamedBufferParameteri64v");
            //}
            //if (config == null || config.Contains("glGetNamedBufferParameteriv")) {
            //    glGetNamedBufferParameteriv = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetNamedBufferParameteriv");
            //}
            //if (config == null || config.Contains("glGetNamedBufferParameterivEXT")) {
            //    glGetNamedBufferParameterivEXT = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetNamedBufferParameterivEXT");
            //}
            //if (config == null || config.Contains("glGetNamedBufferParameterui64vNV")) {
            //    glGetNamedBufferParameterui64vNV = (delegate* unmanaged<GLuint, GLenum, GLuint64EXT[], void>)GetProcAddress("glGetNamedBufferParameterui64vNV");
            //}
            //if (config == null || config.Contains("glGetNamedBufferPointerv")) {
            //    glGetNamedBufferPointerv = (delegate* unmanaged<GLuint, GLenum, IntPtr, void>)GetProcAddress("glGetNamedBufferPointerv");
            //}
            //if (config == null || config.Contains("glGetNamedBufferPointervEXT")) {
            //    glGetNamedBufferPointervEXT = (delegate* unmanaged<GLuint, GLenum, IntPtr, void>)GetProcAddress("glGetNamedBufferPointervEXT");
            //}
            //if (config == null || config.Contains("glGetNamedBufferSubData")) {
            //    glGetNamedBufferSubData = (delegate* unmanaged<GLuint, GLintptr, GLsizeiptr, IntPtr, void>)GetProcAddress("glGetNamedBufferSubData");
            //}
            //if (config == null || config.Contains("glGetNamedBufferSubDataEXT")) {
            //    glGetNamedBufferSubDataEXT = (delegate* unmanaged<GLuint, GLintptr, GLsizeiptr, IntPtr, void>)GetProcAddress("glGetNamedBufferSubDataEXT");
            //}
            //if (config == null || config.Contains("glGetNamedFramebufferParameterfvAMD")) {
            //    glGetNamedFramebufferParameterfvAMD = (delegate* unmanaged<GLuint, GLenum, GLuint, GLuint, GLsizei, GLfloat[], void>)GetProcAddress("glGetNamedFramebufferParameterfvAMD");
            //}
            //if (config == null || config.Contains("glGetNamedFramebufferAttachmentParameteriv")) {
            //    glGetNamedFramebufferAttachmentParameteriv = (delegate* unmanaged<GLuint, GLenum, GLenum, GLint[], void>)GetProcAddress("glGetNamedFramebufferAttachmentParameteriv");
            //}
            //if (config == null || config.Contains("glGetNamedFramebufferAttachmentParameterivEXT")) {
            //    glGetNamedFramebufferAttachmentParameterivEXT = (delegate* unmanaged<GLuint, GLenum, GLenum, GLint[], void>)GetProcAddress("glGetNamedFramebufferAttachmentParameterivEXT");
            //}
            //if (config == null || config.Contains("glGetNamedFramebufferParameteriv")) {
            //    glGetNamedFramebufferParameteriv = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetNamedFramebufferParameteriv");
            //}
            //if (config == null || config.Contains("glGetNamedFramebufferParameterivEXT")) {
            //    glGetNamedFramebufferParameterivEXT = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetNamedFramebufferParameterivEXT");
            //}
            //if (config == null || config.Contains("glGetNamedProgramLocalParameterIivEXT")) {
            //    glGetNamedProgramLocalParameterIivEXT = (delegate* unmanaged<GLuint, GLenum, GLuint, GLint[], void>)GetProcAddress("glGetNamedProgramLocalParameterIivEXT");
            //}
            //if (config == null || config.Contains("glGetNamedProgramLocalParameterIuivEXT")) {
            //    glGetNamedProgramLocalParameterIuivEXT = (delegate* unmanaged<GLuint, GLenum, GLuint, GLuint[], void>)GetProcAddress("glGetNamedProgramLocalParameterIuivEXT");
            //}
            //if (config == null || config.Contains("glGetNamedProgramLocalParameterdvEXT")) {
            //    glGetNamedProgramLocalParameterdvEXT = (delegate* unmanaged<GLuint, GLenum, GLuint, GLdouble[], void>)GetProcAddress("glGetNamedProgramLocalParameterdvEXT");
            //}
            //if (config == null || config.Contains("glGetNamedProgramLocalParameterfvEXT")) {
            //    glGetNamedProgramLocalParameterfvEXT = (delegate* unmanaged<GLuint, GLenum, GLuint, GLfloat[], void>)GetProcAddress("glGetNamedProgramLocalParameterfvEXT");
            //}
            //if (config == null || config.Contains("glGetNamedProgramStringEXT")) {
            //    glGetNamedProgramStringEXT = (delegate* unmanaged<GLuint, GLenum, GLenum, IntPtr, void>)GetProcAddress("glGetNamedProgramStringEXT");
            //}
            //if (config == null || config.Contains("glGetNamedProgramivEXT")) {
            //    glGetNamedProgramivEXT = (delegate* unmanaged<GLuint, GLenum, GLenum, GLint[], void>)GetProcAddress("glGetNamedProgramivEXT");
            //}
            //if (config == null || config.Contains("glGetNamedRenderbufferParameteriv")) {
            //    glGetNamedRenderbufferParameteriv = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetNamedRenderbufferParameteriv");
            //}
            //if (config == null || config.Contains("glGetNamedRenderbufferParameterivEXT")) {
            //    glGetNamedRenderbufferParameterivEXT = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetNamedRenderbufferParameterivEXT");
            //}
            //if (config == null || config.Contains("glGetNamedStringARB")) {
            //    glGetNamedStringARB = (delegate* unmanaged<GLint, string, GLsizei, GLint[], string, void>)GetProcAddress("glGetNamedStringARB");
            //}
            //if (config == null || config.Contains("glGetNamedStringivARB")) {
            //    glGetNamedStringivARB = (delegate* unmanaged<GLint, string, GLenum, GLint[], void>)GetProcAddress("glGetNamedStringivARB");
            //}
            //if (config == null || config.Contains("glGetNextPerfQueryIdINTEL")) {
            //    glGetNextPerfQueryIdINTEL = (delegate* unmanaged<GLuint, GLuint[], void>)GetProcAddress("glGetNextPerfQueryIdINTEL");
            //}
            //if (config == null || config.Contains("glGetObjectBufferfvATI")) {
            //    glGetObjectBufferfvATI = (delegate* unmanaged<GLuint, GLenum, GLfloat[], void>)GetProcAddress("glGetObjectBufferfvATI");
            //}
            //if (config == null || config.Contains("glGetObjectBufferivATI")) {
            //    glGetObjectBufferivATI = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetObjectBufferivATI");
            //}
            //if (config == null || config.Contains("glGetObjectLabel")) {
            //    glGetObjectLabel = (delegate* unmanaged<GLenum, GLuint, GLsizei, GLsizei[], string, void>)GetProcAddress("glGetObjectLabel");
            //}
            //if (config == null || config.Contains("glGetObjectLabelEXT")) {
            //    glGetObjectLabelEXT = (delegate* unmanaged<GLenum, GLuint, GLsizei, GLsizei[], string, void>)GetProcAddress("glGetObjectLabelEXT");
            //}
            //if (config == null || config.Contains("glGetObjectLabelKHR")) {
            //    glGetObjectLabelKHR = (delegate* unmanaged<GLenum, GLuint, GLsizei, GLsizei[], string, void>)GetProcAddress("glGetObjectLabelKHR");
            //}
            //if (config == null || config.Contains("glGetObjectParameterfvARB")) {
            //    glGetObjectParameterfvARB = (delegate* unmanaged<GLhandleARB, GLenum, GLfloat[], void>)GetProcAddress("glGetObjectParameterfvARB");
            //}
            //if (config == null || config.Contains("glGetObjectParameterivAPPLE")) {
            //    glGetObjectParameterivAPPLE = (delegate* unmanaged<GLenum, GLuint, GLenum, GLint[], void>)GetProcAddress("glGetObjectParameterivAPPLE");
            //}
            //if (config == null || config.Contains("glGetObjectParameterivARB")) {
            //    glGetObjectParameterivARB = (delegate* unmanaged<GLhandleARB, GLenum, GLint[], void>)GetProcAddress("glGetObjectParameterivARB");
            //}
            //if (config == null || config.Contains("glGetObjectPtrLabel")) {
            //    glGetObjectPtrLabel = (delegate* unmanaged<IntPtr, GLsizei, GLsizei[], string, void>)GetProcAddress("glGetObjectPtrLabel");
            //}
            //if (config == null || config.Contains("glGetObjectPtrLabelKHR")) {
            //    glGetObjectPtrLabelKHR = (delegate* unmanaged<IntPtr, GLsizei, GLsizei[], string, void>)GetProcAddress("glGetObjectPtrLabelKHR");
            //}
            //if (config == null || config.Contains("glGetOcclusionQueryivNV")) {
            //    glGetOcclusionQueryivNV = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetOcclusionQueryivNV");
            //}
            //if (config == null || config.Contains("glGetOcclusionQueryuivNV")) {
            //    glGetOcclusionQueryuivNV = (delegate* unmanaged<GLuint, GLenum, GLuint[], void>)GetProcAddress("glGetOcclusionQueryuivNV");
            //}
            //if (config == null || config.Contains("glGetPathColorGenfvNV")) {
            //    glGetPathColorGenfvNV = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetPathColorGenfvNV");
            //}
            //if (config == null || config.Contains("glGetPathColorGenivNV")) {
            //    glGetPathColorGenivNV = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetPathColorGenivNV");
            //}
            //if (config == null || config.Contains("glGetPathCommandsNV")) {
            //    glGetPathCommandsNV = (delegate* unmanaged<GLuint, GLubyte[], void>)GetProcAddress("glGetPathCommandsNV");
            //}
            //if (config == null || config.Contains("glGetPathCoordsNV")) {
            //    glGetPathCoordsNV = (delegate* unmanaged<GLuint, GLfloat[], void>)GetProcAddress("glGetPathCoordsNV");
            //}
            //if (config == null || config.Contains("glGetPathDashArrayNV")) {
            //    glGetPathDashArrayNV = (delegate* unmanaged<GLuint, GLfloat[], void>)GetProcAddress("glGetPathDashArrayNV");
            //}
            //if (config == null || config.Contains("glGetPathLengthNV")) {
            //    glGetPathLengthNV = (delegate* unmanaged<GLuint, GLsizei, GLsizei, GLfloat>)GetProcAddress("glGetPathLengthNV");
            //}
            //if (config == null || config.Contains("glGetPathMetricRangeNV")) {
            //    glGetPathMetricRangeNV = (delegate* unmanaged<GLbitfield, GLuint, GLsizei, GLsizei, GLfloat[], void>)GetProcAddress("glGetPathMetricRangeNV");
            //}
            //if (config == null || config.Contains("glGetPathMetricsNV")) {
            //    glGetPathMetricsNV = (delegate* unmanaged<GLbitfield, GLsizei, GLenum, IntPtr, GLuint, GLsizei, GLfloat[], void>)GetProcAddress("glGetPathMetricsNV");
            //}
            //if (config == null || config.Contains("glGetPathParameterfvNV")) {
            //    glGetPathParameterfvNV = (delegate* unmanaged<GLuint, GLenum, GLfloat[], void>)GetProcAddress("glGetPathParameterfvNV");
            //}
            //if (config == null || config.Contains("glGetPathParameterivNV")) {
            //    glGetPathParameterivNV = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetPathParameterivNV");
            //}
            //if (config == null || config.Contains("glGetPathSpacingNV")) {
            //    glGetPathSpacingNV = (delegate* unmanaged<GLenum, GLsizei, GLenum, IntPtr, GLuint, GLfloat, GLfloat, GLenum, GLfloat[], void>)GetProcAddress("glGetPathSpacingNV");
            //}
            //if (config == null || config.Contains("glGetPathTexGenfvNV")) {
            //    glGetPathTexGenfvNV = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetPathTexGenfvNV");
            //}
            //if (config == null || config.Contains("glGetPathTexGenivNV")) {
            //    glGetPathTexGenivNV = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetPathTexGenivNV");
            //}
            //if (config == null || config.Contains("glGetPerfCounterInfoINTEL")) {
            //    glGetPerfCounterInfoINTEL = (delegate* unmanaged<GLuint, GLuint, GLuint, string, GLuint, string, GLuint[], GLuint[], GLuint[], GLuint[], GLuint64[], void>)GetProcAddress("glGetPerfCounterInfoINTEL");
            //}
            //if (config == null || config.Contains("glGetPerfMonitorCounterDataAMD")) {
            //    glGetPerfMonitorCounterDataAMD = (delegate* unmanaged<GLuint, GLenum, GLsizei, GLuint[], GLint[], void>)GetProcAddress("glGetPerfMonitorCounterDataAMD");
            //}
            //if (config == null || config.Contains("glGetPerfMonitorCounterInfoAMD")) {
            //    glGetPerfMonitorCounterInfoAMD = (delegate* unmanaged<GLuint, GLuint, GLenum, IntPtr, void>)GetProcAddress("glGetPerfMonitorCounterInfoAMD");
            //}
            //if (config == null || config.Contains("glGetPerfMonitorCounterStringAMD")) {
            //    glGetPerfMonitorCounterStringAMD = (delegate* unmanaged<GLuint, GLuint, GLsizei, GLsizei[], string, void>)GetProcAddress("glGetPerfMonitorCounterStringAMD");
            //}
            //if (config == null || config.Contains("glGetPerfMonitorCountersAMD")) {
            //    glGetPerfMonitorCountersAMD = (delegate* unmanaged<GLuint, GLint[], GLint[], GLsizei, GLuint[], void>)GetProcAddress("glGetPerfMonitorCountersAMD");
            //}
            //if (config == null || config.Contains("glGetPerfMonitorGroupStringAMD")) {
            //    glGetPerfMonitorGroupStringAMD = (delegate* unmanaged<GLuint, GLsizei, GLsizei[], string, void>)GetProcAddress("glGetPerfMonitorGroupStringAMD");
            //}
            //if (config == null || config.Contains("glGetPerfMonitorGroupsAMD")) {
            //    glGetPerfMonitorGroupsAMD = (delegate* unmanaged<GLint[], GLsizei, GLuint[], void>)GetProcAddress("glGetPerfMonitorGroupsAMD");
            //}
            //if (config == null || config.Contains("glGetPerfQueryDataINTEL")) {
            //    glGetPerfQueryDataINTEL = (delegate* unmanaged<GLuint, GLuint, GLsizei, IntPtr, GLuint[], void>)GetProcAddress("glGetPerfQueryDataINTEL");
            //}
            //if (config == null || config.Contains("glGetPerfQueryIdByNameINTEL")) {
            //    glGetPerfQueryIdByNameINTEL = (delegate* unmanaged<string, GLuint[], void>)GetProcAddress("glGetPerfQueryIdByNameINTEL");
            //}
            //if (config == null || config.Contains("glGetPerfQueryInfoINTEL")) {
            //    glGetPerfQueryInfoINTEL = (delegate* unmanaged<GLuint, GLuint, string, GLuint[], GLuint[], GLuint[], GLuint[], void>)GetProcAddress("glGetPerfQueryInfoINTEL");
            //}
            //if (config == null || config.Contains("glGetPixelMapfv")) {
            //    glGetPixelMapfv = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glGetPixelMapfv");
            //}
            //if (config == null || config.Contains("glGetPixelMapuiv")) {
            //    glGetPixelMapuiv = (delegate* unmanaged<GLenum, GLuint[], void>)GetProcAddress("glGetPixelMapuiv");
            //}
            //if (config == null || config.Contains("glGetPixelMapusv")) {
            //    glGetPixelMapusv = (delegate* unmanaged<GLenum, GLushort[], void>)GetProcAddress("glGetPixelMapusv");
            //}
            //if (config == null || config.Contains("glGetPixelMapxv")) {
            //    glGetPixelMapxv = (delegate* unmanaged<GLenum, GLint, GLfixed[], void>)GetProcAddress("glGetPixelMapxv");
            //}
            //if (config == null || config.Contains("glGetPixelTexGenParameterfvSGIS")) {
            //    glGetPixelTexGenParameterfvSGIS = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glGetPixelTexGenParameterfvSGIS");
            //}
            //if (config == null || config.Contains("glGetPixelTexGenParameterivSGIS")) {
            //    glGetPixelTexGenParameterivSGIS = (delegate* unmanaged<GLenum, GLint[], void>)GetProcAddress("glGetPixelTexGenParameterivSGIS");
            //}
            //if (config == null || config.Contains("glGetPixelTransformParameterfvEXT")) {
            //    glGetPixelTransformParameterfvEXT = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetPixelTransformParameterfvEXT");
            //}
            //if (config == null || config.Contains("glGetPixelTransformParameterivEXT")) {
            //    glGetPixelTransformParameterivEXT = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetPixelTransformParameterivEXT");
            //}
            //if (config == null || config.Contains("glGetPointerIndexedvEXT")) {
            //    glGetPointerIndexedvEXT = (delegate* unmanaged<GLenum, GLuint, IntPtr, void>)GetProcAddress("glGetPointerIndexedvEXT");
            //}
            //if (config == null || config.Contains("glGetPointeri_vEXT")) {
            //    glGetPointeri_vEXT = (delegate* unmanaged<GLenum, GLuint, IntPtr, void>)GetProcAddress("glGetPointeri_vEXT");
            //}
            //if (config == null || config.Contains("glGetPointerv")) {
            //    glGetPointerv = (delegate* unmanaged<GLenum, IntPtr, void>)GetProcAddress("glGetPointerv");
            //}
            //if (config == null || config.Contains("glGetPointervEXT")) {
            //    glGetPointervEXT = (delegate* unmanaged<GLenum, IntPtr, void>)GetProcAddress("glGetPointervEXT");
            //}
            //if (config == null || config.Contains("glGetPointervKHR")) {
            //    glGetPointervKHR = (delegate* unmanaged<GLenum, IntPtr, void>)GetProcAddress("glGetPointervKHR");
            //}
            //if (config == null || config.Contains("glGetPolygonStipple")) {
            //    glGetPolygonStipple = (delegate* unmanaged<GLubyte[], void>)GetProcAddress("glGetPolygonStipple");
            //}
            //if (config == null || config.Contains("glGetProgramBinary")) {
            //    glGetProgramBinary = (delegate* unmanaged<GLuint, GLsizei, GLsizei[], GLenum[], IntPtr, void>)GetProcAddress("glGetProgramBinary");
            //}
            //if (config == null || config.Contains("glGetProgramBinaryOES")) {
            //    glGetProgramBinaryOES = (delegate* unmanaged<GLuint, GLsizei, GLsizei[], GLenum[], IntPtr, void>)GetProcAddress("glGetProgramBinaryOES");
            //}
            //if (config == null || config.Contains("glGetProgramEnvParameterIivNV")) {
            //    glGetProgramEnvParameterIivNV = (delegate* unmanaged<GLenum, GLuint, GLint[], void>)GetProcAddress("glGetProgramEnvParameterIivNV");
            //}
            //if (config == null || config.Contains("glGetProgramEnvParameterIuivNV")) {
            //    glGetProgramEnvParameterIuivNV = (delegate* unmanaged<GLenum, GLuint, GLuint[], void>)GetProcAddress("glGetProgramEnvParameterIuivNV");
            //}
            //if (config == null || config.Contains("glGetProgramEnvParameterdvARB")) {
            //    glGetProgramEnvParameterdvARB = (delegate* unmanaged<GLenum, GLuint, GLdouble[], void>)GetProcAddress("glGetProgramEnvParameterdvARB");
            //}
            //if (config == null || config.Contains("glGetProgramEnvParameterfvARB")) {
            //    glGetProgramEnvParameterfvARB = (delegate* unmanaged<GLenum, GLuint, GLfloat[], void>)GetProcAddress("glGetProgramEnvParameterfvARB");
            //}
            //if (config == null || config.Contains("glGetProgramInfoLog")) {
            //    glGetProgramInfoLog = (delegate* unmanaged<GLuint, GLsizei, GLsizei[], StringBuilder/*string*/, void>)GetProcAddress("glGetProgramInfoLog");
            //}
            //if (config == null || config.Contains("glGetProgramInterfaceiv")) {
            //    glGetProgramInterfaceiv = (delegate* unmanaged<GLuint, GLenum, GLenum, GLint[], void>)GetProcAddress("glGetProgramInterfaceiv");
            //}
            //if (config == null || config.Contains("glGetProgramLocalParameterIivNV")) {
            //    glGetProgramLocalParameterIivNV = (delegate* unmanaged<GLenum, GLuint, GLint[], void>)GetProcAddress("glGetProgramLocalParameterIivNV");
            //}
            //if (config == null || config.Contains("glGetProgramLocalParameterIuivNV")) {
            //    glGetProgramLocalParameterIuivNV = (delegate* unmanaged<GLenum, GLuint, GLuint[], void>)GetProcAddress("glGetProgramLocalParameterIuivNV");
            //}
            //if (config == null || config.Contains("glGetProgramLocalParameterdvARB")) {
            //    glGetProgramLocalParameterdvARB = (delegate* unmanaged<GLenum, GLuint, GLdouble[], void>)GetProcAddress("glGetProgramLocalParameterdvARB");
            //}
            //if (config == null || config.Contains("glGetProgramLocalParameterfvARB")) {
            //    glGetProgramLocalParameterfvARB = (delegate* unmanaged<GLenum, GLuint, GLfloat[], void>)GetProcAddress("glGetProgramLocalParameterfvARB");
            //}
            //if (config == null || config.Contains("glGetProgramNamedParameterdvNV")) {
            //    glGetProgramNamedParameterdvNV = (delegate* unmanaged<GLuint, GLsizei, GLubyte[], GLdouble[], void>)GetProcAddress("glGetProgramNamedParameterdvNV");
            //}
            //if (config == null || config.Contains("glGetProgramNamedParameterfvNV")) {
            //    glGetProgramNamedParameterfvNV = (delegate* unmanaged<GLuint, GLsizei, GLubyte[], GLfloat[], void>)GetProcAddress("glGetProgramNamedParameterfvNV");
            //}
            //if (config == null || config.Contains("glGetProgramParameterdvNV")) {
            //    glGetProgramParameterdvNV = (delegate* unmanaged<GLenum, GLuint, GLenum, GLdouble[], void>)GetProcAddress("glGetProgramParameterdvNV");
            //}
            //if (config == null || config.Contains("glGetProgramParameterfvNV")) {
            //    glGetProgramParameterfvNV = (delegate* unmanaged<GLenum, GLuint, GLenum, GLfloat[], void>)GetProcAddress("glGetProgramParameterfvNV");
            //}
            //if (config == null || config.Contains("glGetProgramPipelineInfoLog")) {
            //    glGetProgramPipelineInfoLog = (delegate* unmanaged<GLuint, GLsizei, GLsizei[], string, void>)GetProcAddress("glGetProgramPipelineInfoLog");
            //}
            //if (config == null || config.Contains("glGetProgramPipelineInfoLogEXT")) {
            //    glGetProgramPipelineInfoLogEXT = (delegate* unmanaged<GLuint, GLsizei, GLsizei[], string, void>)GetProcAddress("glGetProgramPipelineInfoLogEXT");
            //}
            //if (config == null || config.Contains("glGetProgramPipelineiv")) {
            //    glGetProgramPipelineiv = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetProgramPipelineiv");
            //}
            //if (config == null || config.Contains("glGetProgramPipelineivEXT")) {
            //    glGetProgramPipelineivEXT = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetProgramPipelineivEXT");
            //}
            //if (config == null || config.Contains("glGetProgramResourceIndex")) {
            //    glGetProgramResourceIndex = (delegate* unmanaged<GLuint, GLenum, string, GLuint>)GetProcAddress("glGetProgramResourceIndex");
            //}
            //if (config == null || config.Contains("glGetProgramResourceLocation")) {
            //    glGetProgramResourceLocation = (delegate* unmanaged<GLuint, GLenum, string, GLint>)GetProcAddress("glGetProgramResourceLocation");
            //}
            //if (config == null || config.Contains("glGetProgramResourceLocationIndex")) {
            //    glGetProgramResourceLocationIndex = (delegate* unmanaged<GLuint, GLenum, string, GLint>)GetProcAddress("glGetProgramResourceLocationIndex");
            //}
            //if (config == null || config.Contains("glGetProgramResourceLocationIndexEXT")) {
            //    glGetProgramResourceLocationIndexEXT = (delegate* unmanaged<GLuint, GLenum, string, GLint>)GetProcAddress("glGetProgramResourceLocationIndexEXT");
            //}
            //if (config == null || config.Contains("glGetProgramResourceName")) {
            //    glGetProgramResourceName = (delegate* unmanaged<GLuint, GLenum, GLuint, GLsizei, GLsizei[], string, void>)GetProcAddress("glGetProgramResourceName");
            //}
            //if (config == null || config.Contains("glGetProgramResourcefvNV")) {
            //    glGetProgramResourcefvNV = (delegate* unmanaged<GLuint, GLenum, GLuint, GLsizei, GLenum[], GLsizei, GLsizei[], GLfloat[], void>)GetProcAddress("glGetProgramResourcefvNV");
            //}
            //if (config == null || config.Contains("glGetProgramResourceiv")) {
            //    glGetProgramResourceiv = (delegate* unmanaged<GLuint, GLenum, GLuint, GLsizei, GLenum[], GLsizei, GLsizei[], GLint[], void>)GetProcAddress("glGetProgramResourceiv");
            //}
            //if (config == null || config.Contains("glGetProgramStageiv")) {
            //    glGetProgramStageiv = (delegate* unmanaged<GLuint, GLenum, GLenum, GLint[], void>)GetProcAddress("glGetProgramStageiv");
            //}
            //if (config == null || config.Contains("glGetProgramStringARB")) {
            //    glGetProgramStringARB = (delegate* unmanaged<GLenum, GLenum, IntPtr, void>)GetProcAddress("glGetProgramStringARB");
            //}
            //if (config == null || config.Contains("glGetProgramStringNV")) {
            //    glGetProgramStringNV = (delegate* unmanaged<GLuint, GLenum, GLubyte[], void>)GetProcAddress("glGetProgramStringNV");
            //}
            //if (config == null || config.Contains("glGetProgramSubroutineParameteruivNV")) {
            //    glGetProgramSubroutineParameteruivNV = (delegate* unmanaged<GLenum, GLuint, GLuint[], void>)GetProcAddress("glGetProgramSubroutineParameteruivNV");
            //}
            //if (config == null || config.Contains("glGetProgramiv")) {
            //    glGetProgramiv = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetProgramiv");
            //}
            //if (config == null || config.Contains("glGetProgramivARB")) {
            //    glGetProgramivARB = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetProgramivARB");
            //}
            //if (config == null || config.Contains("glGetProgramivNV")) {
            //    glGetProgramivNV = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetProgramivNV");
            //}
            //if (config == null || config.Contains("glGetQueryBufferObjecti64v")) {
            //    glGetQueryBufferObjecti64v = (delegate* unmanaged<GLuint, GLuint, GLenum, GLintptr, void>)GetProcAddress("glGetQueryBufferObjecti64v");
            //}
            //if (config == null || config.Contains("glGetQueryBufferObjectiv")) {
            //    glGetQueryBufferObjectiv = (delegate* unmanaged<GLuint, GLuint, GLenum, GLintptr, void>)GetProcAddress("glGetQueryBufferObjectiv");
            //}
            //if (config == null || config.Contains("glGetQueryBufferObjectui64v")) {
            //    glGetQueryBufferObjectui64v = (delegate* unmanaged<GLuint, GLuint, GLenum, GLintptr, void>)GetProcAddress("glGetQueryBufferObjectui64v");
            //}
            //if (config == null || config.Contains("glGetQueryBufferObjectuiv")) {
            //    glGetQueryBufferObjectuiv = (delegate* unmanaged<GLuint, GLuint, GLenum, GLintptr, void>)GetProcAddress("glGetQueryBufferObjectuiv");
            //}
            //if (config == null || config.Contains("glGetQueryIndexediv")) {
            //    glGetQueryIndexediv = (delegate* unmanaged<GLenum, GLuint, GLenum, GLint[], void>)GetProcAddress("glGetQueryIndexediv");
            //}
            //if (config == null || config.Contains("glGetQueryObjecti64v")) {
            //    glGetQueryObjecti64v = (delegate* unmanaged<GLuint, GLenum, GLint64[], void>)GetProcAddress("glGetQueryObjecti64v");
            //}
            //if (config == null || config.Contains("glGetQueryObjecti64vEXT")) {
            //    glGetQueryObjecti64vEXT = (delegate* unmanaged<GLuint, GLenum, GLint64[], void>)GetProcAddress("glGetQueryObjecti64vEXT");
            //}
            //if (config == null || config.Contains("glGetQueryObjectiv")) {
            //    glGetQueryObjectiv = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetQueryObjectiv");
            //}
            //if (config == null || config.Contains("glGetQueryObjectivARB")) {
            //    glGetQueryObjectivARB = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetQueryObjectivARB");
            //}
            //if (config == null || config.Contains("glGetQueryObjectivEXT")) {
            //    glGetQueryObjectivEXT = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetQueryObjectivEXT");
            //}
            //if (config == null || config.Contains("glGetQueryObjectui64v")) {
            //    glGetQueryObjectui64v = (delegate* unmanaged<GLuint, GLenum, GLuint64[], void>)GetProcAddress("glGetQueryObjectui64v");
            //}
            //if (config == null || config.Contains("glGetQueryObjectui64vEXT")) {
            //    glGetQueryObjectui64vEXT = (delegate* unmanaged<GLuint, GLenum, GLuint64[], void>)GetProcAddress("glGetQueryObjectui64vEXT");
            //}
            //if (config == null || config.Contains("glGetQueryObjectuiv")) {
            //    glGetQueryObjectuiv = (delegate* unmanaged<GLuint, GLenum, GLuint[], void>)GetProcAddress("glGetQueryObjectuiv");
            //}
            //if (config == null || config.Contains("glGetQueryObjectuivARB")) {
            //    glGetQueryObjectuivARB = (delegate* unmanaged<GLuint, GLenum, GLuint[], void>)GetProcAddress("glGetQueryObjectuivARB");
            //}
            //if (config == null || config.Contains("glGetQueryObjectuivEXT")) {
            //    glGetQueryObjectuivEXT = (delegate* unmanaged<GLuint, GLenum, GLuint[], void>)GetProcAddress("glGetQueryObjectuivEXT");
            //}
            //if (config == null || config.Contains("glGetQueryiv")) {
            //    glGetQueryiv = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetQueryiv");
            //}
            //if (config == null || config.Contains("glGetQueryivARB")) {
            //    glGetQueryivARB = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetQueryivARB");
            //}
            //if (config == null || config.Contains("glGetQueryivEXT")) {
            //    glGetQueryivEXT = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetQueryivEXT");
            //}
            //if (config == null || config.Contains("glGetRenderbufferParameteriv")) {
            //    glGetRenderbufferParameteriv = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetRenderbufferParameteriv");
            //}
            //if (config == null || config.Contains("glGetRenderbufferParameterivEXT")) {
            //    glGetRenderbufferParameterivEXT = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetRenderbufferParameterivEXT");
            //}
            //if (config == null || config.Contains("glGetRenderbufferParameterivOES")) {
            //    glGetRenderbufferParameterivOES = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetRenderbufferParameterivOES");
            //}
            //if (config == null || config.Contains("glGetSamplerParameterIiv")) {
            //    glGetSamplerParameterIiv = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetSamplerParameterIiv");
            //}
            //if (config == null || config.Contains("glGetSamplerParameterIivEXT")) {
            //    glGetSamplerParameterIivEXT = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetSamplerParameterIivEXT");
            //}
            //if (config == null || config.Contains("glGetSamplerParameterIivOES")) {
            //    glGetSamplerParameterIivOES = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetSamplerParameterIivOES");
            //}
            //if (config == null || config.Contains("glGetSamplerParameterIuiv")) {
            //    glGetSamplerParameterIuiv = (delegate* unmanaged<GLuint, GLenum, GLuint[], void>)GetProcAddress("glGetSamplerParameterIuiv");
            //}
            //if (config == null || config.Contains("glGetSamplerParameterIuivEXT")) {
            //    glGetSamplerParameterIuivEXT = (delegate* unmanaged<GLuint, GLenum, GLuint[], void>)GetProcAddress("glGetSamplerParameterIuivEXT");
            //}
            //if (config == null || config.Contains("glGetSamplerParameterIuivOES")) {
            //    glGetSamplerParameterIuivOES = (delegate* unmanaged<GLuint, GLenum, GLuint[], void>)GetProcAddress("glGetSamplerParameterIuivOES");
            //}
            //if (config == null || config.Contains("glGetSamplerParameterfv")) {
            //    glGetSamplerParameterfv = (delegate* unmanaged<GLuint, GLenum, GLfloat[], void>)GetProcAddress("glGetSamplerParameterfv");
            //}
            //if (config == null || config.Contains("glGetSamplerParameteriv")) {
            //    glGetSamplerParameteriv = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetSamplerParameteriv");
            //}
            //if (config == null || config.Contains("glGetSemaphoreParameterui64vEXT")) {
            //    glGetSemaphoreParameterui64vEXT = (delegate* unmanaged<GLuint, GLenum, GLuint64[], void>)GetProcAddress("glGetSemaphoreParameterui64vEXT");
            //}
            //if (config == null || config.Contains("glGetSeparableFilter")) {
            //    glGetSeparableFilter = (delegate* unmanaged<GLenum, GLenum, GLenum, IntPtr, IntPtr, IntPtr, void>)GetProcAddress("glGetSeparableFilter");
            //}
            //if (config == null || config.Contains("glGetSeparableFilterEXT")) {
            //    glGetSeparableFilterEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, IntPtr, IntPtr, IntPtr, void>)GetProcAddress("glGetSeparableFilterEXT");
            //}
            //if (config == null || config.Contains("glGetShaderInfoLog")) {
            //    glGetShaderInfoLog = (delegate* unmanaged<GLuint, GLsizei, GLsizei[], StringBuilder/*string*/, void>)GetProcAddress("glGetShaderInfoLog");
            //}
            //if (config == null || config.Contains("glGetShaderPrecisionFormat")) {
            //    glGetShaderPrecisionFormat = (delegate* unmanaged<GLenum, GLenum, GLint[], GLint[], void>)GetProcAddress("glGetShaderPrecisionFormat");
            //}
            //if (config == null || config.Contains("glGetShaderSource")) {
            //    glGetShaderSource = (delegate* unmanaged<GLuint, GLsizei, GLsizei[], string, void>)GetProcAddress("glGetShaderSource");
            //}
            //if (config == null || config.Contains("glGetShaderSourceARB")) {
            //    glGetShaderSourceARB = (delegate* unmanaged<GLhandleARB, GLsizei, GLsizei[], string, void>)GetProcAddress("glGetShaderSourceARB");
            //}
            //if (config == null || config.Contains("glGetShaderiv")) {
            //    glGetShaderiv = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetShaderiv");
            //}
            //if (config == null || config.Contains("glGetShadingRateImagePaletteNV")) {
            //    glGetShadingRateImagePaletteNV = (delegate* unmanaged<GLuint, GLuint, GLenum[], void>)GetProcAddress("glGetShadingRateImagePaletteNV");
            //}
            //if (config == null || config.Contains("glGetShadingRateSampleLocationivNV")) {
            //    glGetShadingRateSampleLocationivNV = (delegate* unmanaged<GLenum, GLuint, GLuint, GLint[], void>)GetProcAddress("glGetShadingRateSampleLocationivNV");
            //}
            //if (config == null || config.Contains("glGetSharpenTexFuncSGIS")) {
            //    glGetSharpenTexFuncSGIS = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glGetSharpenTexFuncSGIS");
            //}
            //if (config == null || config.Contains("glGetStageIndexNV")) {
            //    glGetStageIndexNV = (delegate* unmanaged<GLenum, GLushort>)GetProcAddress("glGetStageIndexNV");
            //}
            //if (config == null || config.Contains("glGetString")) {
            //    glGetString = (delegate* unmanaged<GLenum, string/*GLubyte*/>)GetProcAddress("glGetString");
            //}
            //if (config == null || config.Contains("glGetStringi")) {
            //    glGetStringi = (delegate* unmanaged<GLenum, GLuint, string/*GLubyte*/>)GetProcAddress("glGetStringi");
            //}
            //if (config == null || config.Contains("glGetSubroutineIndex")) {
            //    glGetSubroutineIndex = (delegate* unmanaged<GLuint, GLenum, string, GLuint>)GetProcAddress("glGetSubroutineIndex");
            //}
            //if (config == null || config.Contains("glGetSubroutineUniformLocation")) {
            //    glGetSubroutineUniformLocation = (delegate* unmanaged<GLuint, GLenum, string, GLint>)GetProcAddress("glGetSubroutineUniformLocation");
            //}
            //if (config == null || config.Contains("glGetSynciv")) {
            //    glGetSynciv = (delegate* unmanaged<GLsync, GLenum, GLsizei, GLsizei[], GLint[], void>)GetProcAddress("glGetSynciv");
            //}
            //if (config == null || config.Contains("glGetSyncivAPPLE")) {
            //    glGetSyncivAPPLE = (delegate* unmanaged<GLsync, GLenum, GLsizei, GLsizei[], GLint[], void>)GetProcAddress("glGetSyncivAPPLE");
            //}
            //if (config == null || config.Contains("glGetTexBumpParameterfvATI")) {
            //    glGetTexBumpParameterfvATI = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glGetTexBumpParameterfvATI");
            //}
            //if (config == null || config.Contains("glGetTexBumpParameterivATI")) {
            //    glGetTexBumpParameterivATI = (delegate* unmanaged<GLenum, GLint[], void>)GetProcAddress("glGetTexBumpParameterivATI");
            //}
            //if (config == null || config.Contains("glGetTexEnvfv")) {
            //    glGetTexEnvfv = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetTexEnvfv");
            //}
            //if (config == null || config.Contains("glGetTexEnviv")) {
            //    glGetTexEnviv = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetTexEnviv");
            //}
            //if (config == null || config.Contains("glGetTexEnvxv")) {
            //    glGetTexEnvxv = (delegate* unmanaged<GLenum, GLenum, GLfixed[], void>)GetProcAddress("glGetTexEnvxv");
            //}
            //if (config == null || config.Contains("glGetTexEnvxvOES")) {
            //    glGetTexEnvxvOES = (delegate* unmanaged<GLenum, GLenum, GLfixed[], void>)GetProcAddress("glGetTexEnvxvOES");
            //}
            //if (config == null || config.Contains("glGetTexFilterFuncSGIS")) {
            //    glGetTexFilterFuncSGIS = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetTexFilterFuncSGIS");
            //}
            //if (config == null || config.Contains("glGetTexGendv")) {
            //    glGetTexGendv = (delegate* unmanaged<GLenum, GLenum, GLdouble[], void>)GetProcAddress("glGetTexGendv");
            //}
            //if (config == null || config.Contains("glGetTexGenfv")) {
            //    glGetTexGenfv = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetTexGenfv");
            //}
            //if (config == null || config.Contains("glGetTexGenfvOES")) {
            //    glGetTexGenfvOES = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetTexGenfvOES");
            //}
            //if (config == null || config.Contains("glGetTexGeniv")) {
            //    glGetTexGeniv = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetTexGeniv");
            //}
            //if (config == null || config.Contains("glGetTexGenivOES")) {
            //    glGetTexGenivOES = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetTexGenivOES");
            //}
            //if (config == null || config.Contains("glGetTexGenxvOES")) {
            //    glGetTexGenxvOES = (delegate* unmanaged<GLenum, GLenum, GLfixed[], void>)GetProcAddress("glGetTexGenxvOES");
            //}
            //if (config == null || config.Contains("glGetTexImage")) {
            //    glGetTexImage = (delegate* unmanaged<GLenum, GLint, GLenum, GLenum, IntPtr, void>)GetProcAddress("glGetTexImage");
            //}
            //if (config == null || config.Contains("glGetTexLevelParameterfv")) {
            //    glGetTexLevelParameterfv = (delegate* unmanaged<GLenum, GLint, GLenum, GLfloat[], void>)GetProcAddress("glGetTexLevelParameterfv");
            //}
            //if (config == null || config.Contains("glGetTexLevelParameteriv")) {
            //    glGetTexLevelParameteriv = (delegate* unmanaged<GLenum, GLint, GLenum, GLint[], void>)GetProcAddress("glGetTexLevelParameteriv");
            //}
            //if (config == null || config.Contains("glGetTexLevelParameterxvOES")) {
            //    glGetTexLevelParameterxvOES = (delegate* unmanaged<GLenum, GLint, GLenum, GLfixed[], void>)GetProcAddress("glGetTexLevelParameterxvOES");
            //}
            //if (config == null || config.Contains("glGetTexParameterIiv")) {
            //    glGetTexParameterIiv = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetTexParameterIiv");
            //}
            //if (config == null || config.Contains("glGetTexParameterIivEXT")) {
            //    glGetTexParameterIivEXT = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetTexParameterIivEXT");
            //}
            //if (config == null || config.Contains("glGetTexParameterIivOES")) {
            //    glGetTexParameterIivOES = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetTexParameterIivOES");
            //}
            //if (config == null || config.Contains("glGetTexParameterIuiv")) {
            //    glGetTexParameterIuiv = (delegate* unmanaged<GLenum, GLenum, GLuint[], void>)GetProcAddress("glGetTexParameterIuiv");
            //}
            //if (config == null || config.Contains("glGetTexParameterIuivEXT")) {
            //    glGetTexParameterIuivEXT = (delegate* unmanaged<GLenum, GLenum, GLuint[], void>)GetProcAddress("glGetTexParameterIuivEXT");
            //}
            //if (config == null || config.Contains("glGetTexParameterIuivOES")) {
            //    glGetTexParameterIuivOES = (delegate* unmanaged<GLenum, GLenum, GLuint[], void>)GetProcAddress("glGetTexParameterIuivOES");
            //}
            //if (config == null || config.Contains("glGetTexParameterPointervAPPLE")) {
            //    glGetTexParameterPointervAPPLE = (delegate* unmanaged<GLenum, GLenum, IntPtr, void>)GetProcAddress("glGetTexParameterPointervAPPLE");
            //}
            //if (config == null || config.Contains("glGetTexParameterfv")) {
            //    glGetTexParameterfv = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetTexParameterfv");
            //}
            //if (config == null || config.Contains("glGetTexParameteriv")) {
            //    glGetTexParameteriv = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetTexParameteriv");
            //}
            //if (config == null || config.Contains("glGetTexParameterxv")) {
            //    glGetTexParameterxv = (delegate* unmanaged<GLenum, GLenum, GLfixed[], void>)GetProcAddress("glGetTexParameterxv");
            //}
            //if (config == null || config.Contains("glGetTexParameterxvOES")) {
            //    glGetTexParameterxvOES = (delegate* unmanaged<GLenum, GLenum, GLfixed[], void>)GetProcAddress("glGetTexParameterxvOES");
            //}
            //if (config == null || config.Contains("glGetTextureHandleARB")) {
            //    glGetTextureHandleARB = (delegate* unmanaged<GLuint, GLuint64>)GetProcAddress("glGetTextureHandleARB");
            //}
            //if (config == null || config.Contains("glGetTextureHandleIMG")) {
            //    glGetTextureHandleIMG = (delegate* unmanaged<GLuint, GLuint64>)GetProcAddress("glGetTextureHandleIMG");
            //}
            //if (config == null || config.Contains("glGetTextureHandleNV")) {
            //    glGetTextureHandleNV = (delegate* unmanaged<GLuint, GLuint64>)GetProcAddress("glGetTextureHandleNV");
            //}
            //if (config == null || config.Contains("glGetTextureImage")) {
            //    glGetTextureImage = (delegate* unmanaged<GLuint, GLint, GLenum, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glGetTextureImage");
            //}
            //if (config == null || config.Contains("glGetTextureImageEXT")) {
            //    glGetTextureImageEXT = (delegate* unmanaged<GLuint, GLenum, GLint, GLenum, GLenum, IntPtr, void>)GetProcAddress("glGetTextureImageEXT");
            //}
            //if (config == null || config.Contains("glGetTextureLevelParameterfv")) {
            //    glGetTextureLevelParameterfv = (delegate* unmanaged<GLuint, GLint, GLenum, GLfloat[], void>)GetProcAddress("glGetTextureLevelParameterfv");
            //}
            //if (config == null || config.Contains("glGetTextureLevelParameterfvEXT")) {
            //    glGetTextureLevelParameterfvEXT = (delegate* unmanaged<GLuint, GLenum, GLint, GLenum, GLfloat[], void>)GetProcAddress("glGetTextureLevelParameterfvEXT");
            //}
            //if (config == null || config.Contains("glGetTextureLevelParameteriv")) {
            //    glGetTextureLevelParameteriv = (delegate* unmanaged<GLuint, GLint, GLenum, GLint[], void>)GetProcAddress("glGetTextureLevelParameteriv");
            //}
            //if (config == null || config.Contains("glGetTextureLevelParameterivEXT")) {
            //    glGetTextureLevelParameterivEXT = (delegate* unmanaged<GLuint, GLenum, GLint, GLenum, GLint[], void>)GetProcAddress("glGetTextureLevelParameterivEXT");
            //}
            //if (config == null || config.Contains("glGetTextureParameterIiv")) {
            //    glGetTextureParameterIiv = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetTextureParameterIiv");
            //}
            //if (config == null || config.Contains("glGetTextureParameterIivEXT")) {
            //    glGetTextureParameterIivEXT = (delegate* unmanaged<GLuint, GLenum, GLenum, GLint[], void>)GetProcAddress("glGetTextureParameterIivEXT");
            //}
            //if (config == null || config.Contains("glGetTextureParameterIuiv")) {
            //    glGetTextureParameterIuiv = (delegate* unmanaged<GLuint, GLenum, GLuint[], void>)GetProcAddress("glGetTextureParameterIuiv");
            //}
            //if (config == null || config.Contains("glGetTextureParameterIuivEXT")) {
            //    glGetTextureParameterIuivEXT = (delegate* unmanaged<GLuint, GLenum, GLenum, GLuint[], void>)GetProcAddress("glGetTextureParameterIuivEXT");
            //}
            //if (config == null || config.Contains("glGetTextureParameterfv")) {
            //    glGetTextureParameterfv = (delegate* unmanaged<GLuint, GLenum, GLfloat[], void>)GetProcAddress("glGetTextureParameterfv");
            //}
            //if (config == null || config.Contains("glGetTextureParameterfvEXT")) {
            //    glGetTextureParameterfvEXT = (delegate* unmanaged<GLuint, GLenum, GLenum, GLfloat[], void>)GetProcAddress("glGetTextureParameterfvEXT");
            //}
            //if (config == null || config.Contains("glGetTextureParameteriv")) {
            //    glGetTextureParameteriv = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetTextureParameteriv");
            //}
            //if (config == null || config.Contains("glGetTextureParameterivEXT")) {
            //    glGetTextureParameterivEXT = (delegate* unmanaged<GLuint, GLenum, GLenum, GLint[], void>)GetProcAddress("glGetTextureParameterivEXT");
            //}
            //if (config == null || config.Contains("glGetTextureSamplerHandleARB")) {
            //    glGetTextureSamplerHandleARB = (delegate* unmanaged<GLuint, GLuint, GLuint64>)GetProcAddress("glGetTextureSamplerHandleARB");
            //}
            //if (config == null || config.Contains("glGetTextureSamplerHandleIMG")) {
            //    glGetTextureSamplerHandleIMG = (delegate* unmanaged<GLuint, GLuint, GLuint64>)GetProcAddress("glGetTextureSamplerHandleIMG");
            //}
            //if (config == null || config.Contains("glGetTextureSamplerHandleNV")) {
            //    glGetTextureSamplerHandleNV = (delegate* unmanaged<GLuint, GLuint, GLuint64>)GetProcAddress("glGetTextureSamplerHandleNV");
            //}
            //if (config == null || config.Contains("glGetTextureSubImage")) {
            //    glGetTextureSubImage = (delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glGetTextureSubImage");
            //}
            //if (config == null || config.Contains("glGetTrackMatrixivNV")) {
            //    glGetTrackMatrixivNV = (delegate* unmanaged<GLenum, GLuint, GLenum, GLint[], void>)GetProcAddress("glGetTrackMatrixivNV");
            //}
            //if (config == null || config.Contains("glGetTransformFeedbackVarying")) {
            //    glGetTransformFeedbackVarying = (delegate* unmanaged<GLuint, GLuint, GLsizei, GLsizei[], GLsizei[], GLenum[], string, void>)GetProcAddress("glGetTransformFeedbackVarying");
            //}
            //if (config == null || config.Contains("glGetTransformFeedbackVaryingEXT")) {
            //    glGetTransformFeedbackVaryingEXT = (delegate* unmanaged<GLuint, GLuint, GLsizei, GLsizei[], GLsizei[], GLenum[], string, void>)GetProcAddress("glGetTransformFeedbackVaryingEXT");
            //}
            //if (config == null || config.Contains("glGetTransformFeedbackVaryingNV")) {
            //    glGetTransformFeedbackVaryingNV = (delegate* unmanaged<GLuint, GLuint, GLint[], void>)GetProcAddress("glGetTransformFeedbackVaryingNV");
            //}
            //if (config == null || config.Contains("glGetTransformFeedbacki64_v")) {
            //    glGetTransformFeedbacki64_v = (delegate* unmanaged<GLuint, GLenum, GLuint, GLint64[], void>)GetProcAddress("glGetTransformFeedbacki64_v");
            //}
            //if (config == null || config.Contains("glGetTransformFeedbacki_v")) {
            //    glGetTransformFeedbacki_v = (delegate* unmanaged<GLuint, GLenum, GLuint, GLint[], void>)GetProcAddress("glGetTransformFeedbacki_v");
            //}
            //if (config == null || config.Contains("glGetTransformFeedbackiv")) {
            //    glGetTransformFeedbackiv = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetTransformFeedbackiv");
            //}
            //if (config == null || config.Contains("glGetTranslatedShaderSourceANGLE")) {
            //    glGetTranslatedShaderSourceANGLE = (delegate* unmanaged<GLuint, GLsizei, GLsizei[], string, void>)GetProcAddress("glGetTranslatedShaderSourceANGLE");
            //}
            //if (config == null || config.Contains("glGetUniformBlockIndex")) {
            //    glGetUniformBlockIndex = (delegate* unmanaged<GLuint, string, GLuint>)GetProcAddress("glGetUniformBlockIndex");
            //}
            //if (config == null || config.Contains("glGetUniformBufferSizeEXT")) {
            //    glGetUniformBufferSizeEXT = (delegate* unmanaged<GLuint, GLint, GLint>)GetProcAddress("glGetUniformBufferSizeEXT");
            //}
            //if (config == null || config.Contains("glGetUniformIndices")) {
            //    glGetUniformIndices = (delegate* unmanaged<GLuint, GLsizei, string[], GLuint[], void>)GetProcAddress("glGetUniformIndices");
            //}
            //if (config == null || config.Contains("glGetUniformLocation")) {
            //    glGetUniformLocation = (delegate* unmanaged<GLuint, string, GLint>)GetProcAddress("glGetUniformLocation");
            //}
            //if (config == null || config.Contains("glGetUniformLocationARB")) {
            //    glGetUniformLocationARB = (delegate* unmanaged<GLhandleARB, string, GLint>)GetProcAddress("glGetUniformLocationARB");
            //}
            //if (config == null || config.Contains("glGetUniformOffsetEXT")) {
            //    glGetUniformOffsetEXT = (delegate* unmanaged<GLuint, GLint, GLintptr>)GetProcAddress("glGetUniformOffsetEXT");
            //}
            //if (config == null || config.Contains("glGetUniformSubroutineuiv")) {
            //    glGetUniformSubroutineuiv = (delegate* unmanaged<GLenum, GLint, GLuint[], void>)GetProcAddress("glGetUniformSubroutineuiv");
            //}
            //if (config == null || config.Contains("glGetUniformdv")) {
            //    glGetUniformdv = (delegate* unmanaged<GLuint, GLint, GLdouble[], void>)GetProcAddress("glGetUniformdv");
            //}
            //if (config == null || config.Contains("glGetUniformfv")) {
            //    glGetUniformfv = (delegate* unmanaged<GLuint, GLint, GLfloat[], void>)GetProcAddress("glGetUniformfv");
            //}
            //if (config == null || config.Contains("glGetUniformfvARB")) {
            //    glGetUniformfvARB = (delegate* unmanaged<GLhandleARB, GLint, GLfloat[], void>)GetProcAddress("glGetUniformfvARB");
            //}
            //if (config == null || config.Contains("glGetUniformi64vARB")) {
            //    glGetUniformi64vARB = (delegate* unmanaged<GLuint, GLint, GLint64[], void>)GetProcAddress("glGetUniformi64vARB");
            //}
            //if (config == null || config.Contains("glGetUniformi64vNV")) {
            //    glGetUniformi64vNV = (delegate* unmanaged<GLuint, GLint, GLint64EXT[], void>)GetProcAddress("glGetUniformi64vNV");
            //}
            //if (config == null || config.Contains("glGetUniformiv")) {
            //    glGetUniformiv = (delegate* unmanaged<GLuint, GLint, GLint[], void>)GetProcAddress("glGetUniformiv");
            //}
            //if (config == null || config.Contains("glGetUniformivARB")) {
            //    glGetUniformivARB = (delegate* unmanaged<GLhandleARB, GLint, GLint[], void>)GetProcAddress("glGetUniformivARB");
            //}
            //if (config == null || config.Contains("glGetUniformui64vARB")) {
            //    glGetUniformui64vARB = (delegate* unmanaged<GLuint, GLint, GLuint64[], void>)GetProcAddress("glGetUniformui64vARB");
            //}
            //if (config == null || config.Contains("glGetUniformui64vNV")) {
            //    glGetUniformui64vNV = (delegate* unmanaged<GLuint, GLint, GLuint64EXT[], void>)GetProcAddress("glGetUniformui64vNV");
            //}
            //if (config == null || config.Contains("glGetUniformuiv")) {
            //    glGetUniformuiv = (delegate* unmanaged<GLuint, GLint, GLuint[], void>)GetProcAddress("glGetUniformuiv");
            //}
            //if (config == null || config.Contains("glGetUniformuivEXT")) {
            //    glGetUniformuivEXT = (delegate* unmanaged<GLuint, GLint, GLuint[], void>)GetProcAddress("glGetUniformuivEXT");
            //}
            //if (config == null || config.Contains("glGetUnsignedBytevEXT")) {
            //    glGetUnsignedBytevEXT = (delegate* unmanaged<GLenum, GLubyte[], void>)GetProcAddress("glGetUnsignedBytevEXT");
            //}
            //if (config == null || config.Contains("glGetUnsignedBytei_vEXT")) {
            //    glGetUnsignedBytei_vEXT = (delegate* unmanaged<GLenum, GLuint, GLubyte[], void>)GetProcAddress("glGetUnsignedBytei_vEXT");
            //}
            //if (config == null || config.Contains("glGetVariantArrayObjectfvATI")) {
            //    glGetVariantArrayObjectfvATI = (delegate* unmanaged<GLuint, GLenum, GLfloat[], void>)GetProcAddress("glGetVariantArrayObjectfvATI");
            //}
            //if (config == null || config.Contains("glGetVariantArrayObjectivATI")) {
            //    glGetVariantArrayObjectivATI = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetVariantArrayObjectivATI");
            //}
            //if (config == null || config.Contains("glGetVariantBooleanvEXT")) {
            //    glGetVariantBooleanvEXT = (delegate* unmanaged<GLuint, GLenum, GLboolean[], void>)GetProcAddress("glGetVariantBooleanvEXT");
            //}
            //if (config == null || config.Contains("glGetVariantFloatvEXT")) {
            //    glGetVariantFloatvEXT = (delegate* unmanaged<GLuint, GLenum, GLfloat[], void>)GetProcAddress("glGetVariantFloatvEXT");
            //}
            //if (config == null || config.Contains("glGetVariantIntegervEXT")) {
            //    glGetVariantIntegervEXT = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetVariantIntegervEXT");
            //}
            //if (config == null || config.Contains("glGetVariantPointervEXT")) {
            //    glGetVariantPointervEXT = (delegate* unmanaged<GLuint, GLenum, IntPtr, void>)GetProcAddress("glGetVariantPointervEXT");
            //}
            //if (config == null || config.Contains("glGetVaryingLocationNV")) {
            //    glGetVaryingLocationNV = (delegate* unmanaged<GLuint, string, GLint>)GetProcAddress("glGetVaryingLocationNV");
            //}
            //if (config == null || config.Contains("glGetVertexArrayIndexed64iv")) {
            //    glGetVertexArrayIndexed64iv = (delegate* unmanaged<GLuint, GLuint, GLenum, GLint64[], void>)GetProcAddress("glGetVertexArrayIndexed64iv");
            //}
            //if (config == null || config.Contains("glGetVertexArrayIndexediv")) {
            //    glGetVertexArrayIndexediv = (delegate* unmanaged<GLuint, GLuint, GLenum, GLint[], void>)GetProcAddress("glGetVertexArrayIndexediv");
            //}
            //if (config == null || config.Contains("glGetVertexArrayIntegeri_vEXT")) {
            //    glGetVertexArrayIntegeri_vEXT = (delegate* unmanaged<GLuint, GLuint, GLenum, GLint[], void>)GetProcAddress("glGetVertexArrayIntegeri_vEXT");
            //}
            //if (config == null || config.Contains("glGetVertexArrayIntegervEXT")) {
            //    glGetVertexArrayIntegervEXT = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetVertexArrayIntegervEXT");
            //}
            //if (config == null || config.Contains("glGetVertexArrayPointeri_vEXT")) {
            //    glGetVertexArrayPointeri_vEXT = (delegate* unmanaged<GLuint, GLuint, GLenum, IntPtr, void>)GetProcAddress("glGetVertexArrayPointeri_vEXT");
            //}
            //if (config == null || config.Contains("glGetVertexArrayPointervEXT")) {
            //    glGetVertexArrayPointervEXT = (delegate* unmanaged<GLuint, GLenum, IntPtr, void>)GetProcAddress("glGetVertexArrayPointervEXT");
            //}
            //if (config == null || config.Contains("glGetVertexArrayiv")) {
            //    glGetVertexArrayiv = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetVertexArrayiv");
            //}
            //if (config == null || config.Contains("glGetVertexAttribArrayObjectfvATI")) {
            //    glGetVertexAttribArrayObjectfvATI = (delegate* unmanaged<GLuint, GLenum, GLfloat[], void>)GetProcAddress("glGetVertexAttribArrayObjectfvATI");
            //}
            //if (config == null || config.Contains("glGetVertexAttribArrayObjectivATI")) {
            //    glGetVertexAttribArrayObjectivATI = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetVertexAttribArrayObjectivATI");
            //}
            //if (config == null || config.Contains("glGetVertexAttribIiv")) {
            //    glGetVertexAttribIiv = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetVertexAttribIiv");
            //}
            //if (config == null || config.Contains("glGetVertexAttribIivEXT")) {
            //    glGetVertexAttribIivEXT = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetVertexAttribIivEXT");
            //}
            //if (config == null || config.Contains("glGetVertexAttribIuiv")) {
            //    glGetVertexAttribIuiv = (delegate* unmanaged<GLuint, GLenum, GLuint[], void>)GetProcAddress("glGetVertexAttribIuiv");
            //}
            //if (config == null || config.Contains("glGetVertexAttribIuivEXT")) {
            //    glGetVertexAttribIuivEXT = (delegate* unmanaged<GLuint, GLenum, GLuint[], void>)GetProcAddress("glGetVertexAttribIuivEXT");
            //}
            //if (config == null || config.Contains("glGetVertexAttribLdv")) {
            //    glGetVertexAttribLdv = (delegate* unmanaged<GLuint, GLenum, GLdouble[], void>)GetProcAddress("glGetVertexAttribLdv");
            //}
            //if (config == null || config.Contains("glGetVertexAttribLdvEXT")) {
            //    glGetVertexAttribLdvEXT = (delegate* unmanaged<GLuint, GLenum, GLdouble[], void>)GetProcAddress("glGetVertexAttribLdvEXT");
            //}
            //if (config == null || config.Contains("glGetVertexAttribLi64vNV")) {
            //    glGetVertexAttribLi64vNV = (delegate* unmanaged<GLuint, GLenum, GLint64EXT[], void>)GetProcAddress("glGetVertexAttribLi64vNV");
            //}
            //if (config == null || config.Contains("glGetVertexAttribLui64vARB")) {
            //    glGetVertexAttribLui64vARB = (delegate* unmanaged<GLuint, GLenum, GLuint64EXT[], void>)GetProcAddress("glGetVertexAttribLui64vARB");
            //}
            //if (config == null || config.Contains("glGetVertexAttribLui64vNV")) {
            //    glGetVertexAttribLui64vNV = (delegate* unmanaged<GLuint, GLenum, GLuint64EXT[], void>)GetProcAddress("glGetVertexAttribLui64vNV");
            //}
            //if (config == null || config.Contains("glGetVertexAttribPointerv")) {
            //    glGetVertexAttribPointerv = (delegate* unmanaged<GLuint, GLenum, IntPtr, void>)GetProcAddress("glGetVertexAttribPointerv");
            //}
            //if (config == null || config.Contains("glGetVertexAttribPointervARB")) {
            //    glGetVertexAttribPointervARB = (delegate* unmanaged<GLuint, GLenum, IntPtr, void>)GetProcAddress("glGetVertexAttribPointervARB");
            //}
            //if (config == null || config.Contains("glGetVertexAttribPointervNV")) {
            //    glGetVertexAttribPointervNV = (delegate* unmanaged<GLuint, GLenum, IntPtr, void>)GetProcAddress("glGetVertexAttribPointervNV");
            //}
            //if (config == null || config.Contains("glGetVertexAttribdv")) {
            //    glGetVertexAttribdv = (delegate* unmanaged<GLuint, GLenum, GLdouble[], void>)GetProcAddress("glGetVertexAttribdv");
            //}
            //if (config == null || config.Contains("glGetVertexAttribdvARB")) {
            //    glGetVertexAttribdvARB = (delegate* unmanaged<GLuint, GLenum, GLdouble[], void>)GetProcAddress("glGetVertexAttribdvARB");
            //}
            //if (config == null || config.Contains("glGetVertexAttribdvNV")) {
            //    glGetVertexAttribdvNV = (delegate* unmanaged<GLuint, GLenum, GLdouble[], void>)GetProcAddress("glGetVertexAttribdvNV");
            //}
            //if (config == null || config.Contains("glGetVertexAttribfv")) {
            //    glGetVertexAttribfv = (delegate* unmanaged<GLuint, GLenum, GLfloat[], void>)GetProcAddress("glGetVertexAttribfv");
            //}
            //if (config == null || config.Contains("glGetVertexAttribfvARB")) {
            //    glGetVertexAttribfvARB = (delegate* unmanaged<GLuint, GLenum, GLfloat[], void>)GetProcAddress("glGetVertexAttribfvARB");
            //}
            //if (config == null || config.Contains("glGetVertexAttribfvNV")) {
            //    glGetVertexAttribfvNV = (delegate* unmanaged<GLuint, GLenum, GLfloat[], void>)GetProcAddress("glGetVertexAttribfvNV");
            //}
            //if (config == null || config.Contains("glGetVertexAttribiv")) {
            //    glGetVertexAttribiv = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetVertexAttribiv");
            //}
            //if (config == null || config.Contains("glGetVertexAttribivARB")) {
            //    glGetVertexAttribivARB = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetVertexAttribivARB");
            //}
            //if (config == null || config.Contains("glGetVertexAttribivNV")) {
            //    glGetVertexAttribivNV = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetVertexAttribivNV");
            //}
            //if (config == null || config.Contains("glGetVideoCaptureStreamdvNV")) {
            //    glGetVideoCaptureStreamdvNV = (delegate* unmanaged<GLuint, GLuint, GLenum, GLdouble[], void>)GetProcAddress("glGetVideoCaptureStreamdvNV");
            //}
            //if (config == null || config.Contains("glGetVideoCaptureStreamfvNV")) {
            //    glGetVideoCaptureStreamfvNV = (delegate* unmanaged<GLuint, GLuint, GLenum, GLfloat[], void>)GetProcAddress("glGetVideoCaptureStreamfvNV");
            //}
            //if (config == null || config.Contains("glGetVideoCaptureStreamivNV")) {
            //    glGetVideoCaptureStreamivNV = (delegate* unmanaged<GLuint, GLuint, GLenum, GLint[], void>)GetProcAddress("glGetVideoCaptureStreamivNV");
            //}
            //if (config == null || config.Contains("glGetVideoCaptureivNV")) {
            //    glGetVideoCaptureivNV = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetVideoCaptureivNV");
            //}
            //if (config == null || config.Contains("glGetVideoi64vNV")) {
            //    glGetVideoi64vNV = (delegate* unmanaged<GLuint, GLenum, GLint64EXT[], void>)GetProcAddress("glGetVideoi64vNV");
            //}
            //if (config == null || config.Contains("glGetVideoivNV")) {
            //    glGetVideoivNV = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glGetVideoivNV");
            //}
            //if (config == null || config.Contains("glGetVideoui64vNV")) {
            //    glGetVideoui64vNV = (delegate* unmanaged<GLuint, GLenum, GLuint64EXT[], void>)GetProcAddress("glGetVideoui64vNV");
            //}
            //if (config == null || config.Contains("glGetVideouivNV")) {
            //    glGetVideouivNV = (delegate* unmanaged<GLuint, GLenum, GLuint[], void>)GetProcAddress("glGetVideouivNV");
            //}
            //if (config == null || config.Contains("glGetnColorTable")) {
            //    glGetnColorTable = (delegate* unmanaged<GLenum, GLenum, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glGetnColorTable");
            //}
            //if (config == null || config.Contains("glGetnColorTableARB")) {
            //    glGetnColorTableARB = (delegate* unmanaged<GLenum, GLenum, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glGetnColorTableARB");
            //}
            //if (config == null || config.Contains("glGetnCompressedTexImage")) {
            //    glGetnCompressedTexImage = (delegate* unmanaged<GLenum, GLint, GLsizei, IntPtr, void>)GetProcAddress("glGetnCompressedTexImage");
            //}
            //if (config == null || config.Contains("glGetnCompressedTexImageARB")) {
            //    glGetnCompressedTexImageARB = (delegate* unmanaged<GLenum, GLint, GLsizei, IntPtr, void>)GetProcAddress("glGetnCompressedTexImageARB");
            //}
            //if (config == null || config.Contains("glGetnConvolutionFilter")) {
            //    glGetnConvolutionFilter = (delegate* unmanaged<GLenum, GLenum, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glGetnConvolutionFilter");
            //}
            //if (config == null || config.Contains("glGetnConvolutionFilterARB")) {
            //    glGetnConvolutionFilterARB = (delegate* unmanaged<GLenum, GLenum, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glGetnConvolutionFilterARB");
            //}
            //if (config == null || config.Contains("glGetnHistogram")) {
            //    glGetnHistogram = (delegate* unmanaged<GLenum, GLboolean, GLenum, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glGetnHistogram");
            //}
            //if (config == null || config.Contains("glGetnHistogramARB")) {
            //    glGetnHistogramARB = (delegate* unmanaged<GLenum, GLboolean, GLenum, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glGetnHistogramARB");
            //}
            //if (config == null || config.Contains("glGetnMapdv")) {
            //    glGetnMapdv = (delegate* unmanaged<GLenum, GLenum, GLsizei, GLdouble[], void>)GetProcAddress("glGetnMapdv");
            //}
            //if (config == null || config.Contains("glGetnMapdvARB")) {
            //    glGetnMapdvARB = (delegate* unmanaged<GLenum, GLenum, GLsizei, GLdouble[], void>)GetProcAddress("glGetnMapdvARB");
            //}
            //if (config == null || config.Contains("glGetnMapfv")) {
            //    glGetnMapfv = (delegate* unmanaged<GLenum, GLenum, GLsizei, GLfloat[], void>)GetProcAddress("glGetnMapfv");
            //}
            //if (config == null || config.Contains("glGetnMapfvARB")) {
            //    glGetnMapfvARB = (delegate* unmanaged<GLenum, GLenum, GLsizei, GLfloat[], void>)GetProcAddress("glGetnMapfvARB");
            //}
            //if (config == null || config.Contains("glGetnMapiv")) {
            //    glGetnMapiv = (delegate* unmanaged<GLenum, GLenum, GLsizei, GLint[], void>)GetProcAddress("glGetnMapiv");
            //}
            //if (config == null || config.Contains("glGetnMapivARB")) {
            //    glGetnMapivARB = (delegate* unmanaged<GLenum, GLenum, GLsizei, GLint[], void>)GetProcAddress("glGetnMapivARB");
            //}
            //if (config == null || config.Contains("glGetnMinmax")) {
            //    glGetnMinmax = (delegate* unmanaged<GLenum, GLboolean, GLenum, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glGetnMinmax");
            //}
            //if (config == null || config.Contains("glGetnMinmaxARB")) {
            //    glGetnMinmaxARB = (delegate* unmanaged<GLenum, GLboolean, GLenum, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glGetnMinmaxARB");
            //}
            //if (config == null || config.Contains("glGetnPixelMapfv")) {
            //    glGetnPixelMapfv = (delegate* unmanaged<GLenum, GLsizei, GLfloat[], void>)GetProcAddress("glGetnPixelMapfv");
            //}
            //if (config == null || config.Contains("glGetnPixelMapfvARB")) {
            //    glGetnPixelMapfvARB = (delegate* unmanaged<GLenum, GLsizei, GLfloat[], void>)GetProcAddress("glGetnPixelMapfvARB");
            //}
            //if (config == null || config.Contains("glGetnPixelMapuiv")) {
            //    glGetnPixelMapuiv = (delegate* unmanaged<GLenum, GLsizei, GLuint[], void>)GetProcAddress("glGetnPixelMapuiv");
            //}
            //if (config == null || config.Contains("glGetnPixelMapuivARB")) {
            //    glGetnPixelMapuivARB = (delegate* unmanaged<GLenum, GLsizei, GLuint[], void>)GetProcAddress("glGetnPixelMapuivARB");
            //}
            //if (config == null || config.Contains("glGetnPixelMapusv")) {
            //    glGetnPixelMapusv = (delegate* unmanaged<GLenum, GLsizei, GLushort[], void>)GetProcAddress("glGetnPixelMapusv");
            //}
            //if (config == null || config.Contains("glGetnPixelMapusvARB")) {
            //    glGetnPixelMapusvARB = (delegate* unmanaged<GLenum, GLsizei, GLushort[], void>)GetProcAddress("glGetnPixelMapusvARB");
            //}
            //if (config == null || config.Contains("glGetnPolygonStipple")) {
            //    glGetnPolygonStipple = (delegate* unmanaged<GLsizei, GLubyte[], void>)GetProcAddress("glGetnPolygonStipple");
            //}
            //if (config == null || config.Contains("glGetnPolygonStippleARB")) {
            //    glGetnPolygonStippleARB = (delegate* unmanaged<GLsizei, GLubyte[], void>)GetProcAddress("glGetnPolygonStippleARB");
            //}
            //if (config == null || config.Contains("glGetnSeparableFilter")) {
            //    glGetnSeparableFilter = (delegate* unmanaged<GLenum, GLenum, GLenum, GLsizei, IntPtr, GLsizei, IntPtr, IntPtr, void>)GetProcAddress("glGetnSeparableFilter");
            //}
            //if (config == null || config.Contains("glGetnSeparableFilterARB")) {
            //    glGetnSeparableFilterARB = (delegate* unmanaged<GLenum, GLenum, GLenum, GLsizei, IntPtr, GLsizei, IntPtr, IntPtr, void>)GetProcAddress("glGetnSeparableFilterARB");
            //}
            //if (config == null || config.Contains("glGetnTexImage")) {
            //    glGetnTexImage = (delegate* unmanaged<GLenum, GLint, GLenum, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glGetnTexImage");
            //}
            //if (config == null || config.Contains("glGetnTexImageARB")) {
            //    glGetnTexImageARB = (delegate* unmanaged<GLenum, GLint, GLenum, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glGetnTexImageARB");
            //}
            //if (config == null || config.Contains("glGetnUniformdv")) {
            //    glGetnUniformdv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLdouble[], void>)GetProcAddress("glGetnUniformdv");
            //}
            //if (config == null || config.Contains("glGetnUniformdvARB")) {
            //    glGetnUniformdvARB = (delegate* unmanaged<GLuint, GLint, GLsizei, GLdouble[], void>)GetProcAddress("glGetnUniformdvARB");
            //}
            //if (config == null || config.Contains("glGetnUniformfv")) {
            //    glGetnUniformfv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLfloat[], void>)GetProcAddress("glGetnUniformfv");
            //}
            //if (config == null || config.Contains("glGetnUniformfvARB")) {
            //    glGetnUniformfvARB = (delegate* unmanaged<GLuint, GLint, GLsizei, GLfloat[], void>)GetProcAddress("glGetnUniformfvARB");
            //}
            //if (config == null || config.Contains("glGetnUniformfvEXT")) {
            //    glGetnUniformfvEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLfloat[], void>)GetProcAddress("glGetnUniformfvEXT");
            //}
            //if (config == null || config.Contains("glGetnUniformfvKHR")) {
            //    glGetnUniformfvKHR = (delegate* unmanaged<GLuint, GLint, GLsizei, GLfloat[], void>)GetProcAddress("glGetnUniformfvKHR");
            //}
            //if (config == null || config.Contains("glGetnUniformi64vARB")) {
            //    glGetnUniformi64vARB = (delegate* unmanaged<GLuint, GLint, GLsizei, GLint64[], void>)GetProcAddress("glGetnUniformi64vARB");
            //}
            //if (config == null || config.Contains("glGetnUniformiv")) {
            //    glGetnUniformiv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLint[], void>)GetProcAddress("glGetnUniformiv");
            //}
            //if (config == null || config.Contains("glGetnUniformivARB")) {
            //    glGetnUniformivARB = (delegate* unmanaged<GLuint, GLint, GLsizei, GLint[], void>)GetProcAddress("glGetnUniformivARB");
            //}
            //if (config == null || config.Contains("glGetnUniformivEXT")) {
            //    glGetnUniformivEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLint[], void>)GetProcAddress("glGetnUniformivEXT");
            //}
            //if (config == null || config.Contains("glGetnUniformivKHR")) {
            //    glGetnUniformivKHR = (delegate* unmanaged<GLuint, GLint, GLsizei, GLint[], void>)GetProcAddress("glGetnUniformivKHR");
            //}
            //if (config == null || config.Contains("glGetnUniformui64vARB")) {
            //    glGetnUniformui64vARB = (delegate* unmanaged<GLuint, GLint, GLsizei, GLuint64[], void>)GetProcAddress("glGetnUniformui64vARB");
            //}
            //if (config == null || config.Contains("glGetnUniformuiv")) {
            //    glGetnUniformuiv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLuint[], void>)GetProcAddress("glGetnUniformuiv");
            //}
            //if (config == null || config.Contains("glGetnUniformuivARB")) {
            //    glGetnUniformuivARB = (delegate* unmanaged<GLuint, GLint, GLsizei, GLuint[], void>)GetProcAddress("glGetnUniformuivARB");
            //}
            //if (config == null || config.Contains("glGetnUniformuivKHR")) {
            //    glGetnUniformuivKHR = (delegate* unmanaged<GLuint, GLint, GLsizei, GLuint[], void>)GetProcAddress("glGetnUniformuivKHR");
            //}
            //if (config == null || config.Contains("glGlobalAlphaFactorbSUN")) {
            //    glGlobalAlphaFactorbSUN = (delegate* unmanaged<GLbyte, void>)GetProcAddress("glGlobalAlphaFactorbSUN");
            //}
            //if (config == null || config.Contains("glGlobalAlphaFactordSUN")) {
            //    glGlobalAlphaFactordSUN = (delegate* unmanaged<GLdouble, void>)GetProcAddress("glGlobalAlphaFactordSUN");
            //}
            //if (config == null || config.Contains("glGlobalAlphaFactorfSUN")) {
            //    glGlobalAlphaFactorfSUN = (delegate* unmanaged<GLfloat, void>)GetProcAddress("glGlobalAlphaFactorfSUN");
            //}
            //if (config == null || config.Contains("glGlobalAlphaFactoriSUN")) {
            //    glGlobalAlphaFactoriSUN = (delegate* unmanaged<GLint, void>)GetProcAddress("glGlobalAlphaFactoriSUN");
            //}
            //if (config == null || config.Contains("glGlobalAlphaFactorsSUN")) {
            //    glGlobalAlphaFactorsSUN = (delegate* unmanaged<GLshort, void>)GetProcAddress("glGlobalAlphaFactorsSUN");
            //}
            //if (config == null || config.Contains("glGlobalAlphaFactorubSUN")) {
            //    glGlobalAlphaFactorubSUN = (delegate* unmanaged<GLubyte, void>)GetProcAddress("glGlobalAlphaFactorubSUN");
            //}
            //if (config == null || config.Contains("glGlobalAlphaFactoruiSUN")) {
            //    glGlobalAlphaFactoruiSUN = (delegate* unmanaged<GLuint, void>)GetProcAddress("glGlobalAlphaFactoruiSUN");
            //}
            //if (config == null || config.Contains("glGlobalAlphaFactorusSUN")) {
            //    glGlobalAlphaFactorusSUN = (delegate* unmanaged<GLushort, void>)GetProcAddress("glGlobalAlphaFactorusSUN");
            //}
            //if (config == null || config.Contains("glHint")) {
            //    glHint = (delegate* unmanaged<GLenum, GLenum, void>)GetProcAddress("glHint");
            //}
            //if (config == null || config.Contains("glHintPGI")) {
            //    glHintPGI = (delegate* unmanaged<GLenum, GLint, void>)GetProcAddress("glHintPGI");
            //}
            //if (config == null || config.Contains("glHistogram")) {
            //    glHistogram = (delegate* unmanaged<GLenum, GLsizei, GLenum, GLboolean, void>)GetProcAddress("glHistogram");
            //}
            //if (config == null || config.Contains("glHistogramEXT")) {
            //    glHistogramEXT = (delegate* unmanaged<GLenum, GLsizei, GLenum, GLboolean, void>)GetProcAddress("glHistogramEXT");
            //}
            //if (config == null || config.Contains("glIglooInterfaceSGIX")) {
            //    glIglooInterfaceSGIX = (delegate* unmanaged<GLenum, IntPtr, void>)GetProcAddress("glIglooInterfaceSGIX");
            //}
            //if (config == null || config.Contains("glImageTransformParameterfHP")) {
            //    glImageTransformParameterfHP = (delegate* unmanaged<GLenum, GLenum, GLfloat, void>)GetProcAddress("glImageTransformParameterfHP");
            //}
            //if (config == null || config.Contains("glImageTransformParameterfvHP")) {
            //    glImageTransformParameterfvHP = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glImageTransformParameterfvHP");
            //}
            //if (config == null || config.Contains("glImageTransformParameteriHP")) {
            //    glImageTransformParameteriHP = (delegate* unmanaged<GLenum, GLenum, GLint, void>)GetProcAddress("glImageTransformParameteriHP");
            //}
            //if (config == null || config.Contains("glImageTransformParameterivHP")) {
            //    glImageTransformParameterivHP = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glImageTransformParameterivHP");
            //}
            //if (config == null || config.Contains("glImportMemoryFdEXT")) {
            //    glImportMemoryFdEXT = (delegate* unmanaged<GLuint, GLuint64, GLenum, GLint, void>)GetProcAddress("glImportMemoryFdEXT");
            //}
            //if (config == null || config.Contains("glImportMemoryWin32HandleEXT")) {
            //    glImportMemoryWin32HandleEXT = (delegate* unmanaged<GLuint, GLuint64, GLenum, IntPtr, void>)GetProcAddress("glImportMemoryWin32HandleEXT");
            //}
            //if (config == null || config.Contains("glImportMemoryWin32NameEXT")) {
            //    glImportMemoryWin32NameEXT = (delegate* unmanaged<GLuint, GLuint64, GLenum, IntPtr, void>)GetProcAddress("glImportMemoryWin32NameEXT");
            //}
            //if (config == null || config.Contains("glImportSemaphoreFdEXT")) {
            //    glImportSemaphoreFdEXT = (delegate* unmanaged<GLuint, GLenum, GLint, void>)GetProcAddress("glImportSemaphoreFdEXT");
            //}
            //if (config == null || config.Contains("glImportSemaphoreWin32HandleEXT")) {
            //    glImportSemaphoreWin32HandleEXT = (delegate* unmanaged<GLuint, GLenum, IntPtr, void>)GetProcAddress("glImportSemaphoreWin32HandleEXT");
            //}
            //if (config == null || config.Contains("glImportSemaphoreWin32NameEXT")) {
            //    glImportSemaphoreWin32NameEXT = (delegate* unmanaged<GLuint, GLenum, IntPtr, void>)GetProcAddress("glImportSemaphoreWin32NameEXT");
            //}
            //if (config == null || config.Contains("glImportSyncEXT")) {
            //    glImportSyncEXT = (delegate* unmanaged<GLenum, GLintptr, GLbitfield, GLsync>)GetProcAddress("glImportSyncEXT");
            //}
            //if (config == null || config.Contains("glIndexFormatNV")) {
            //    glIndexFormatNV = (delegate* unmanaged<GLenum, GLsizei, void>)GetProcAddress("glIndexFormatNV");
            //}
            //if (config == null || config.Contains("glIndexFuncEXT")) {
            //    glIndexFuncEXT = (delegate* unmanaged<GLenum, GLclampf, void>)GetProcAddress("glIndexFuncEXT");
            //}
            //if (config == null || config.Contains("glIndexMask")) {
            //    glIndexMask = (delegate* unmanaged<GLuint, void>)GetProcAddress("glIndexMask");
            //}
            //if (config == null || config.Contains("glIndexMaterialEXT")) {
            //    glIndexMaterialEXT = (delegate* unmanaged<GLenum, GLenum, void>)GetProcAddress("glIndexMaterialEXT");
            //}
            //if (config == null || config.Contains("glIndexPointer")) {
            //    glIndexPointer = (delegate* unmanaged<GLenum, GLsizei, IntPtr, void>)GetProcAddress("glIndexPointer");
            //}
            //if (config == null || config.Contains("glIndexPointerEXT")) {
            //    glIndexPointerEXT = (delegate* unmanaged<GLenum, GLsizei, GLsizei, IntPtr, void>)GetProcAddress("glIndexPointerEXT");
            //}
            //if (config == null || config.Contains("glIndexPointerListIBM")) {
            //    glIndexPointerListIBM = (delegate* unmanaged<GLenum, GLint, IntPtr, GLint, void>)GetProcAddress("glIndexPointerListIBM");
            //}
            //if (config == null || config.Contains("glIndexd")) {
            //    glIndexd = (delegate* unmanaged<GLdouble, void>)GetProcAddress("glIndexd");
            //}
            //if (config == null || config.Contains("glIndexdv")) {
            //    glIndexdv = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glIndexdv");
            //}
            //if (config == null || config.Contains("glIndexf")) {
            //    glIndexf = (delegate* unmanaged<GLfloat, void>)GetProcAddress("glIndexf");
            //}
            //if (config == null || config.Contains("glIndexfv")) {
            //    glIndexfv = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glIndexfv");
            //}
            //if (config == null || config.Contains("glIndexi")) {
            //    glIndexi = (delegate* unmanaged<GLint, void>)GetProcAddress("glIndexi");
            //}
            //if (config == null || config.Contains("glIndexiv")) {
            //    glIndexiv = (delegate* unmanaged<GLint[], void>)GetProcAddress("glIndexiv");
            //}
            //if (config == null || config.Contains("glIndexs")) {
            //    glIndexs = (delegate* unmanaged<GLshort, void>)GetProcAddress("glIndexs");
            //}
            //if (config == null || config.Contains("glIndexsv")) {
            //    glIndexsv = (delegate* unmanaged<GLshort[], void>)GetProcAddress("glIndexsv");
            //}
            //if (config == null || config.Contains("glIndexub")) {
            //    glIndexub = (delegate* unmanaged<GLubyte, void>)GetProcAddress("glIndexub");
            //}
            //if (config == null || config.Contains("glIndexubv")) {
            //    glIndexubv = (delegate* unmanaged<GLubyte[], void>)GetProcAddress("glIndexubv");
            //}
            //if (config == null || config.Contains("glIndexxOES")) {
            //    glIndexxOES = (delegate* unmanaged<GLfixed, void>)GetProcAddress("glIndexxOES");
            //}
            //if (config == null || config.Contains("glIndexxvOES")) {
            //    glIndexxvOES = (delegate* unmanaged<GLfixed[], void>)GetProcAddress("glIndexxvOES");
            //}
            //if (config == null || config.Contains("glInitNames")) {
            //    glInitNames = (delegate* unmanaged<void>)GetProcAddress("glInitNames");
            //}
            //if (config == null || config.Contains("glInsertComponentEXT")) {
            //    glInsertComponentEXT = (delegate* unmanaged<GLuint, GLuint, GLuint, void>)GetProcAddress("glInsertComponentEXT");
            //}
            //if (config == null || config.Contains("glInsertEventMarkerEXT")) {
            //    glInsertEventMarkerEXT = (delegate* unmanaged<GLsizei, string, void>)GetProcAddress("glInsertEventMarkerEXT");
            //}
            //if (config == null || config.Contains("glInstrumentsBufferSGIX")) {
            //    glInstrumentsBufferSGIX = (delegate* unmanaged<GLsizei, GLint[], void>)GetProcAddress("glInstrumentsBufferSGIX");
            //}
            //if (config == null || config.Contains("glInterleavedArrays")) {
            //    glInterleavedArrays = (delegate* unmanaged<GLenum, GLsizei, IntPtr, void>)GetProcAddress("glInterleavedArrays");
            //}
            //if (config == null || config.Contains("glInterpolatePathsNV")) {
            //    glInterpolatePathsNV = (delegate* unmanaged<GLuint, GLuint, GLuint, GLfloat, void>)GetProcAddress("glInterpolatePathsNV");
            //}
            //if (config == null || config.Contains("glInvalidateBufferData")) {
            //    glInvalidateBufferData = (delegate* unmanaged<GLuint, void>)GetProcAddress("glInvalidateBufferData");
            //}
            //if (config == null || config.Contains("glInvalidateBufferSubData")) {
            //    glInvalidateBufferSubData = (delegate* unmanaged<GLuint, GLintptr, GLsizeiptr, void>)GetProcAddress("glInvalidateBufferSubData");
            //}
            //if (config == null || config.Contains("glInvalidateFramebuffer")) {
            //    glInvalidateFramebuffer = (delegate* unmanaged<GLenum, GLsizei, GLenum[], void>)GetProcAddress("glInvalidateFramebuffer");
            //}
            //if (config == null || config.Contains("glInvalidateNamedFramebufferData")) {
            //    glInvalidateNamedFramebufferData = (delegate* unmanaged<GLuint, GLsizei, GLenum[], void>)GetProcAddress("glInvalidateNamedFramebufferData");
            //}
            //if (config == null || config.Contains("glInvalidateNamedFramebufferSubData")) {
            //    glInvalidateNamedFramebufferSubData = (delegate* unmanaged<GLuint, GLsizei, GLenum[], GLint, GLint, GLsizei, GLsizei, void>)GetProcAddress("glInvalidateNamedFramebufferSubData");
            //}
            //if (config == null || config.Contains("glInvalidateSubFramebuffer")) {
            //    glInvalidateSubFramebuffer = (delegate* unmanaged<GLenum, GLsizei, GLenum[], GLint, GLint, GLsizei, GLsizei, void>)GetProcAddress("glInvalidateSubFramebuffer");
            //}
            //if (config == null || config.Contains("glInvalidateTexImage")) {
            //    glInvalidateTexImage = (delegate* unmanaged<GLuint, GLint, void>)GetProcAddress("glInvalidateTexImage");
            //}
            //if (config == null || config.Contains("glInvalidateTexSubImage")) {
            //    glInvalidateTexSubImage = (delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, void>)GetProcAddress("glInvalidateTexSubImage");
            //}
            //if (config == null || config.Contains("glIsAsyncMarkerSGIX")) {
            //    glIsAsyncMarkerSGIX = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsAsyncMarkerSGIX");
            //}
            //if (config == null || config.Contains("glIsBuffer")) {
            //    glIsBuffer = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsBuffer");
            //}
            //if (config == null || config.Contains("glIsBufferARB")) {
            //    glIsBufferARB = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsBufferARB");
            //}
            //if (config == null || config.Contains("glIsBufferResidentNV")) {
            //    glIsBufferResidentNV = (delegate* unmanaged<GLenum, GLboolean>)GetProcAddress("glIsBufferResidentNV");
            //}
            //if (config == null || config.Contains("glIsCommandListNV")) {
            //    glIsCommandListNV = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsCommandListNV");
            //}
            //if (config == null || config.Contains("glIsEnabled")) {
            //    glIsEnabled = (delegate* unmanaged<GLenum, GLboolean>)GetProcAddress("glIsEnabled");
            //}
            //if (config == null || config.Contains("glIsEnabledIndexedEXT")) {
            //    glIsEnabledIndexedEXT = (delegate* unmanaged<GLenum, GLuint, GLboolean>)GetProcAddress("glIsEnabledIndexedEXT");
            //}
            //if (config == null || config.Contains("glIsEnabledi")) {
            //    glIsEnabledi = (delegate* unmanaged<GLenum, GLuint, GLboolean>)GetProcAddress("glIsEnabledi");
            //}
            //if (config == null || config.Contains("glIsEnablediEXT")) {
            //    glIsEnablediEXT = (delegate* unmanaged<GLenum, GLuint, GLboolean>)GetProcAddress("glIsEnablediEXT");
            //}
            //if (config == null || config.Contains("glIsEnablediNV")) {
            //    glIsEnablediNV = (delegate* unmanaged<GLenum, GLuint, GLboolean>)GetProcAddress("glIsEnablediNV");
            //}
            //if (config == null || config.Contains("glIsEnablediOES")) {
            //    glIsEnablediOES = (delegate* unmanaged<GLenum, GLuint, GLboolean>)GetProcAddress("glIsEnablediOES");
            //}
            //if (config == null || config.Contains("glIsFenceAPPLE")) {
            //    glIsFenceAPPLE = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsFenceAPPLE");
            //}
            //if (config == null || config.Contains("glIsFenceNV")) {
            //    glIsFenceNV = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsFenceNV");
            //}
            //if (config == null || config.Contains("glIsFramebuffer")) {
            //    glIsFramebuffer = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsFramebuffer");
            //}
            //if (config == null || config.Contains("glIsFramebufferEXT")) {
            //    glIsFramebufferEXT = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsFramebufferEXT");
            //}
            //if (config == null || config.Contains("glIsFramebufferOES")) {
            //    glIsFramebufferOES = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsFramebufferOES");
            //}
            //if (config == null || config.Contains("glIsImageHandleResidentARB")) {
            //    glIsImageHandleResidentARB = (delegate* unmanaged<GLuint64, GLboolean>)GetProcAddress("glIsImageHandleResidentARB");
            //}
            //if (config == null || config.Contains("glIsImageHandleResidentNV")) {
            //    glIsImageHandleResidentNV = (delegate* unmanaged<GLuint64, GLboolean>)GetProcAddress("glIsImageHandleResidentNV");
            //}
            //if (config == null || config.Contains("glIsList")) {
            //    glIsList = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsList");
            //}
            //if (config == null || config.Contains("glIsMemoryObjectEXT")) {
            //    glIsMemoryObjectEXT = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsMemoryObjectEXT");
            //}
            //if (config == null || config.Contains("glIsNameAMD")) {
            //    glIsNameAMD = (delegate* unmanaged<GLenum, GLuint, GLboolean>)GetProcAddress("glIsNameAMD");
            //}
            //if (config == null || config.Contains("glIsNamedBufferResidentNV")) {
            //    glIsNamedBufferResidentNV = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsNamedBufferResidentNV");
            //}
            //if (config == null || config.Contains("glIsNamedStringARB")) {
            //    glIsNamedStringARB = (delegate* unmanaged<GLint, string, GLboolean>)GetProcAddress("glIsNamedStringARB");
            //}
            //if (config == null || config.Contains("glIsObjectBufferATI")) {
            //    glIsObjectBufferATI = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsObjectBufferATI");
            //}
            //if (config == null || config.Contains("glIsOcclusionQueryNV")) {
            //    glIsOcclusionQueryNV = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsOcclusionQueryNV");
            //}
            //if (config == null || config.Contains("glIsPathNV")) {
            //    glIsPathNV = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsPathNV");
            //}
            //if (config == null || config.Contains("glIsPointInFillPathNV")) {
            //    glIsPointInFillPathNV = (delegate* unmanaged<GLuint, GLuint, GLfloat, GLfloat, GLboolean>)GetProcAddress("glIsPointInFillPathNV");
            //}
            //if (config == null || config.Contains("glIsPointInStrokePathNV")) {
            //    glIsPointInStrokePathNV = (delegate* unmanaged<GLuint, GLfloat, GLfloat, GLboolean>)GetProcAddress("glIsPointInStrokePathNV");
            //}
            //if (config == null || config.Contains("glIsProgram")) {
            //    glIsProgram = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsProgram");
            //}
            //if (config == null || config.Contains("glIsProgramARB")) {
            //    glIsProgramARB = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsProgramARB");
            //}
            //if (config == null || config.Contains("glIsProgramNV")) {
            //    glIsProgramNV = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsProgramNV");
            //}
            //if (config == null || config.Contains("glIsProgramPipeline")) {
            //    glIsProgramPipeline = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsProgramPipeline");
            //}
            //if (config == null || config.Contains("glIsProgramPipelineEXT")) {
            //    glIsProgramPipelineEXT = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsProgramPipelineEXT");
            //}
            //if (config == null || config.Contains("glIsQuery")) {
            //    glIsQuery = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsQuery");
            //}
            //if (config == null || config.Contains("glIsQueryARB")) {
            //    glIsQueryARB = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsQueryARB");
            //}
            //if (config == null || config.Contains("glIsQueryEXT")) {
            //    glIsQueryEXT = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsQueryEXT");
            //}
            //if (config == null || config.Contains("glIsRenderbuffer")) {
            //    glIsRenderbuffer = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsRenderbuffer");
            //}
            //if (config == null || config.Contains("glIsRenderbufferEXT")) {
            //    glIsRenderbufferEXT = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsRenderbufferEXT");
            //}
            //if (config == null || config.Contains("glIsRenderbufferOES")) {
            //    glIsRenderbufferOES = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsRenderbufferOES");
            //}
            //if (config == null || config.Contains("glIsSemaphoreEXT")) {
            //    glIsSemaphoreEXT = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsSemaphoreEXT");
            //}
            //if (config == null || config.Contains("glIsSampler")) {
            //    glIsSampler = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsSampler");
            //}
            //if (config == null || config.Contains("glIsShader")) {
            //    glIsShader = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsShader");
            //}
            //if (config == null || config.Contains("glIsStateNV")) {
            //    glIsStateNV = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsStateNV");
            //}
            //if (config == null || config.Contains("glIsSync")) {
            //    glIsSync = (delegate* unmanaged<GLsync, GLboolean>)GetProcAddress("glIsSync");
            //}
            //if (config == null || config.Contains("glIsSyncAPPLE")) {
            //    glIsSyncAPPLE = (delegate* unmanaged<GLsync, GLboolean>)GetProcAddress("glIsSyncAPPLE");
            //}
            //if (config == null || config.Contains("glIsTexture")) {
            //    glIsTexture = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsTexture");
            //}
            //if (config == null || config.Contains("glIsTextureEXT")) {
            //    glIsTextureEXT = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsTextureEXT");
            //}
            //if (config == null || config.Contains("glIsTextureHandleResidentARB")) {
            //    glIsTextureHandleResidentARB = (delegate* unmanaged<GLuint64, GLboolean>)GetProcAddress("glIsTextureHandleResidentARB");
            //}
            //if (config == null || config.Contains("glIsTextureHandleResidentNV")) {
            //    glIsTextureHandleResidentNV = (delegate* unmanaged<GLuint64, GLboolean>)GetProcAddress("glIsTextureHandleResidentNV");
            //}
            //if (config == null || config.Contains("glIsTransformFeedback")) {
            //    glIsTransformFeedback = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsTransformFeedback");
            //}
            //if (config == null || config.Contains("glIsTransformFeedbackNV")) {
            //    glIsTransformFeedbackNV = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsTransformFeedbackNV");
            //}
            //if (config == null || config.Contains("glIsVariantEnabledEXT")) {
            //    glIsVariantEnabledEXT = (delegate* unmanaged<GLuint, GLenum, GLboolean>)GetProcAddress("glIsVariantEnabledEXT");
            //}
            //if (config == null || config.Contains("glIsVertexArray")) {
            //    glIsVertexArray = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsVertexArray");
            //}
            //if (config == null || config.Contains("glIsVertexArrayAPPLE")) {
            //    glIsVertexArrayAPPLE = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsVertexArrayAPPLE");
            //}
            //if (config == null || config.Contains("glIsVertexArrayOES")) {
            //    glIsVertexArrayOES = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glIsVertexArrayOES");
            //}
            //if (config == null || config.Contains("glIsVertexAttribEnabledAPPLE")) {
            //    glIsVertexAttribEnabledAPPLE = (delegate* unmanaged<GLuint, GLenum, GLboolean>)GetProcAddress("glIsVertexAttribEnabledAPPLE");
            //}
            //if (config == null || config.Contains("glLGPUCopyImageSubDataNVX")) {
            //    glLGPUCopyImageSubDataNVX = (delegate* unmanaged<GLuint, GLbitfield, GLuint, GLenum, GLint, GLint, GLint, GLint, GLuint, GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, void>)GetProcAddress("glLGPUCopyImageSubDataNVX");
            //}
            //if (config == null || config.Contains("glLGPUInterlockNVX")) {
            //    glLGPUInterlockNVX = (delegate* unmanaged<void>)GetProcAddress("glLGPUInterlockNVX");
            //}
            //if (config == null || config.Contains("glLGPUNamedBufferSubDataNVX")) {
            //    glLGPUNamedBufferSubDataNVX = (delegate* unmanaged<GLbitfield, GLuint, GLintptr, GLsizeiptr, IntPtr, void>)GetProcAddress("glLGPUNamedBufferSubDataNVX");
            //}
            //if (config == null || config.Contains("glLabelObjectEXT")) {
            //    glLabelObjectEXT = (delegate* unmanaged<GLenum, GLuint, GLsizei, string, void>)GetProcAddress("glLabelObjectEXT");
            //}
            //if (config == null || config.Contains("glLightEnviSGIX")) {
            //    glLightEnviSGIX = (delegate* unmanaged<GLenum, GLint, void>)GetProcAddress("glLightEnviSGIX");
            //}
            //if (config == null || config.Contains("glLightModelf")) {
            //    glLightModelf = (delegate* unmanaged<GLenum, GLfloat, void>)GetProcAddress("glLightModelf");
            //}
            //if (config == null || config.Contains("glLightModelfv")) {
            //    glLightModelfv = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glLightModelfv");
            //}
            //if (config == null || config.Contains("glLightModeli")) {
            //    glLightModeli = (delegate* unmanaged<GLenum, GLint, void>)GetProcAddress("glLightModeli");
            //}
            //if (config == null || config.Contains("glLightModeliv")) {
            //    glLightModeliv = (delegate* unmanaged<GLenum, GLint[], void>)GetProcAddress("glLightModeliv");
            //}
            //if (config == null || config.Contains("glLightModelx")) {
            //    glLightModelx = (delegate* unmanaged<GLenum, GLfixed, void>)GetProcAddress("glLightModelx");
            //}
            //if (config == null || config.Contains("glLightModelxOES")) {
            //    glLightModelxOES = (delegate* unmanaged<GLenum, GLfixed, void>)GetProcAddress("glLightModelxOES");
            //}
            //if (config == null || config.Contains("glLightModelxv")) {
            //    glLightModelxv = (delegate* unmanaged<GLenum, GLfixed[], void>)GetProcAddress("glLightModelxv");
            //}
            //if (config == null || config.Contains("glLightModelxvOES")) {
            //    glLightModelxvOES = (delegate* unmanaged<GLenum, GLfixed[], void>)GetProcAddress("glLightModelxvOES");
            //}
            //if (config == null || config.Contains("glLightf")) {
            //    glLightf = (delegate* unmanaged<GLenum, GLenum, GLfloat, void>)GetProcAddress("glLightf");
            //}
            //if (config == null || config.Contains("glLightfv")) {
            //    glLightfv = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glLightfv");
            //}
            //if (config == null || config.Contains("glLighti")) {
            //    glLighti = (delegate* unmanaged<GLenum, GLenum, GLint, void>)GetProcAddress("glLighti");
            //}
            //if (config == null || config.Contains("glLightiv")) {
            //    glLightiv = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glLightiv");
            //}
            //if (config == null || config.Contains("glLightx")) {
            //    glLightx = (delegate* unmanaged<GLenum, GLenum, GLfixed, void>)GetProcAddress("glLightx");
            //}
            //if (config == null || config.Contains("glLightxOES")) {
            //    glLightxOES = (delegate* unmanaged<GLenum, GLenum, GLfixed, void>)GetProcAddress("glLightxOES");
            //}
            //if (config == null || config.Contains("glLightxv")) {
            //    glLightxv = (delegate* unmanaged<GLenum, GLenum, GLfixed[], void>)GetProcAddress("glLightxv");
            //}
            //if (config == null || config.Contains("glLightxvOES")) {
            //    glLightxvOES = (delegate* unmanaged<GLenum, GLenum, GLfixed[], void>)GetProcAddress("glLightxvOES");
            //}
            //if (config == null || config.Contains("glLineStipple")) {
            //    glLineStipple = (delegate* unmanaged<GLint, GLushort, void>)GetProcAddress("glLineStipple");
            //}
            //if (config == null || config.Contains("glLineWidth")) {
            //    glLineWidth = (delegate* unmanaged<GLfloat, void>)GetProcAddress("glLineWidth");
            //}
            //if (config == null || config.Contains("glLineWidthx")) {
            //    glLineWidthx = (delegate* unmanaged<GLfixed, void>)GetProcAddress("glLineWidthx");
            //}
            //if (config == null || config.Contains("glLineWidthxOES")) {
            //    glLineWidthxOES = (delegate* unmanaged<GLfixed, void>)GetProcAddress("glLineWidthxOES");
            //}
            //if (config == null || config.Contains("glLinkProgram")) {
            //    glLinkProgram = (delegate* unmanaged<GLuint, void>)GetProcAddress("glLinkProgram");
            //}
            //if (config == null || config.Contains("glLinkProgramARB")) {
            //    glLinkProgramARB = (delegate* unmanaged<GLhandleARB, void>)GetProcAddress("glLinkProgramARB");
            //}
            //if (config == null || config.Contains("glListBase")) {
            //    glListBase = (delegate* unmanaged<GLuint, void>)GetProcAddress("glListBase");
            //}
            //if (config == null || config.Contains("glListDrawCommandsStatesClientNV")) {
            //    glListDrawCommandsStatesClientNV = (delegate* unmanaged<GLuint, GLuint, IntPtr, GLsizei[], GLuint[], GLuint[], GLuint, void>)GetProcAddress("glListDrawCommandsStatesClientNV");
            //}
            //if (config == null || config.Contains("glListParameterfSGIX")) {
            //    glListParameterfSGIX = (delegate* unmanaged<GLuint, GLenum, GLfloat, void>)GetProcAddress("glListParameterfSGIX");
            //}
            //if (config == null || config.Contains("glListParameterfvSGIX")) {
            //    glListParameterfvSGIX = (delegate* unmanaged<GLuint, GLenum, GLfloat[], void>)GetProcAddress("glListParameterfvSGIX");
            //}
            //if (config == null || config.Contains("glListParameteriSGIX")) {
            //    glListParameteriSGIX = (delegate* unmanaged<GLuint, GLenum, GLint, void>)GetProcAddress("glListParameteriSGIX");
            //}
            //if (config == null || config.Contains("glListParameterivSGIX")) {
            //    glListParameterivSGIX = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glListParameterivSGIX");
            //}
            //if (config == null || config.Contains("glLoadIdentity")) {
            //    glLoadIdentity = (delegate* unmanaged<void>)GetProcAddress("glLoadIdentity");
            //}
            //if (config == null || config.Contains("glLoadIdentityDeformationMapSGIX")) {
            //    glLoadIdentityDeformationMapSGIX = (delegate* unmanaged<GLbitfield, void>)GetProcAddress("glLoadIdentityDeformationMapSGIX");
            //}
            //if (config == null || config.Contains("glLoadMatrixd")) {
            //    glLoadMatrixd = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glLoadMatrixd");
            //}
            //if (config == null || config.Contains("glLoadMatrixf")) {
            //    glLoadMatrixf = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glLoadMatrixf");
            //}
            //if (config == null || config.Contains("glLoadMatrixx")) {
            //    glLoadMatrixx = (delegate* unmanaged<GLfixed[], void>)GetProcAddress("glLoadMatrixx");
            //}
            //if (config == null || config.Contains("glLoadMatrixxOES")) {
            //    glLoadMatrixxOES = (delegate* unmanaged<GLfixed[], void>)GetProcAddress("glLoadMatrixxOES");
            //}
            //if (config == null || config.Contains("glLoadName")) {
            //    glLoadName = (delegate* unmanaged<GLuint, void>)GetProcAddress("glLoadName");
            //}
            //if (config == null || config.Contains("glLoadPaletteFromModelViewMatrixOES")) {
            //    glLoadPaletteFromModelViewMatrixOES = (delegate* unmanaged<void>)GetProcAddress("glLoadPaletteFromModelViewMatrixOES");
            //}
            //if (config == null || config.Contains("glLoadProgramNV")) {
            //    glLoadProgramNV = (delegate* unmanaged<GLenum, GLuint, GLsizei, GLubyte[], void>)GetProcAddress("glLoadProgramNV");
            //}
            //if (config == null || config.Contains("glLoadTransposeMatrixd")) {
            //    glLoadTransposeMatrixd = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glLoadTransposeMatrixd");
            //}
            //if (config == null || config.Contains("glLoadTransposeMatrixdARB")) {
            //    glLoadTransposeMatrixdARB = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glLoadTransposeMatrixdARB");
            //}
            //if (config == null || config.Contains("glLoadTransposeMatrixf")) {
            //    glLoadTransposeMatrixf = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glLoadTransposeMatrixf");
            //}
            //if (config == null || config.Contains("glLoadTransposeMatrixfARB")) {
            //    glLoadTransposeMatrixfARB = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glLoadTransposeMatrixfARB");
            //}
            //if (config == null || config.Contains("glLoadTransposeMatrixxOES")) {
            //    glLoadTransposeMatrixxOES = (delegate* unmanaged<GLfixed[], void>)GetProcAddress("glLoadTransposeMatrixxOES");
            //}
            //if (config == null || config.Contains("glLockArraysEXT")) {
            //    glLockArraysEXT = (delegate* unmanaged<GLint, GLsizei, void>)GetProcAddress("glLockArraysEXT");
            //}
            //if (config == null || config.Contains("glLogicOp")) {
            //    glLogicOp = (delegate* unmanaged<GLenum, void>)GetProcAddress("glLogicOp");
            //}
            //if (config == null || config.Contains("glMakeBufferNonResidentNV")) {
            //    glMakeBufferNonResidentNV = (delegate* unmanaged<GLenum, void>)GetProcAddress("glMakeBufferNonResidentNV");
            //}
            //if (config == null || config.Contains("glMakeBufferResidentNV")) {
            //    glMakeBufferResidentNV = (delegate* unmanaged<GLenum, GLenum, void>)GetProcAddress("glMakeBufferResidentNV");
            //}
            //if (config == null || config.Contains("glMakeImageHandleNonResidentARB")) {
            //    glMakeImageHandleNonResidentARB = (delegate* unmanaged<GLuint64, void>)GetProcAddress("glMakeImageHandleNonResidentARB");
            //}
            //if (config == null || config.Contains("glMakeImageHandleNonResidentNV")) {
            //    glMakeImageHandleNonResidentNV = (delegate* unmanaged<GLuint64, void>)GetProcAddress("glMakeImageHandleNonResidentNV");
            //}
            //if (config == null || config.Contains("glMakeImageHandleResidentARB")) {
            //    glMakeImageHandleResidentARB = (delegate* unmanaged<GLuint64, GLenum, void>)GetProcAddress("glMakeImageHandleResidentARB");
            //}
            //if (config == null || config.Contains("glMakeImageHandleResidentNV")) {
            //    glMakeImageHandleResidentNV = (delegate* unmanaged<GLuint64, GLenum, void>)GetProcAddress("glMakeImageHandleResidentNV");
            //}
            //if (config == null || config.Contains("glMakeNamedBufferNonResidentNV")) {
            //    glMakeNamedBufferNonResidentNV = (delegate* unmanaged<GLuint, void>)GetProcAddress("glMakeNamedBufferNonResidentNV");
            //}
            //if (config == null || config.Contains("glMakeNamedBufferResidentNV")) {
            //    glMakeNamedBufferResidentNV = (delegate* unmanaged<GLuint, GLenum, void>)GetProcAddress("glMakeNamedBufferResidentNV");
            //}
            //if (config == null || config.Contains("glMakeTextureHandleNonResidentARB")) {
            //    glMakeTextureHandleNonResidentARB = (delegate* unmanaged<GLuint64, void>)GetProcAddress("glMakeTextureHandleNonResidentARB");
            //}
            //if (config == null || config.Contains("glMakeTextureHandleNonResidentNV")) {
            //    glMakeTextureHandleNonResidentNV = (delegate* unmanaged<GLuint64, void>)GetProcAddress("glMakeTextureHandleNonResidentNV");
            //}
            //if (config == null || config.Contains("glMakeTextureHandleResidentARB")) {
            //    glMakeTextureHandleResidentARB = (delegate* unmanaged<GLuint64, void>)GetProcAddress("glMakeTextureHandleResidentARB");
            //}
            //if (config == null || config.Contains("glMakeTextureHandleResidentNV")) {
            //    glMakeTextureHandleResidentNV = (delegate* unmanaged<GLuint64, void>)GetProcAddress("glMakeTextureHandleResidentNV");
            //}
            //if (config == null || config.Contains("glMap1d")) {
            //    glMap1d = (delegate* unmanaged<GLenum, GLdouble, GLdouble, GLint, GLint, GLdouble[], void>)GetProcAddress("glMap1d");
            //}
            //if (config == null || config.Contains("glMap1f")) {
            //    glMap1f = (delegate* unmanaged<GLenum, GLfloat, GLfloat, GLint, GLint, GLfloat[], void>)GetProcAddress("glMap1f");
            //}
            //if (config == null || config.Contains("glMap1xOES")) {
            //    glMap1xOES = (delegate* unmanaged<GLenum, GLfixed, GLfixed, GLint, GLint, GLfixed, void>)GetProcAddress("glMap1xOES");
            //}
            //if (config == null || config.Contains("glMap2d")) {
            //    glMap2d = (delegate* unmanaged<GLenum, GLdouble, GLdouble, GLint, GLint, GLdouble, GLdouble, GLint, GLint, GLdouble[], void>)GetProcAddress("glMap2d");
            //}
            //if (config == null || config.Contains("glMap2f")) {
            //    glMap2f = (delegate* unmanaged<GLenum, GLfloat, GLfloat, GLint, GLint, GLfloat, GLfloat, GLint, GLint, GLfloat[], void>)GetProcAddress("glMap2f");
            //}
            //if (config == null || config.Contains("glMap2xOES")) {
            //    glMap2xOES = (delegate* unmanaged<GLenum, GLfixed, GLfixed, GLint, GLint, GLfixed, GLfixed, GLint, GLint, GLfixed, void>)GetProcAddress("glMap2xOES");
            //}
            //if (config == null || config.Contains("glMapBuffer")) {
            //    glMapBuffer = (delegate* unmanaged<GLenum, GLenum, void>)GetProcAddress("glMapBuffer");
            //}
            //if (config == null || config.Contains("glMapBufferARB")) {
            //    glMapBufferARB = (delegate* unmanaged<GLenum, GLenum, void>)GetProcAddress("glMapBufferARB");
            //}
            //if (config == null || config.Contains("glMapBufferOES")) {
            //    glMapBufferOES = (delegate* unmanaged<GLenum, GLenum, void>)GetProcAddress("glMapBufferOES");
            //}
            //if (config == null || config.Contains("glMapBufferRange")) {
            //    glMapBufferRange = (delegate* unmanaged<GLenum, GLintptr, GLsizeiptr, GLbitfield, void>)GetProcAddress("glMapBufferRange");
            //}
            //if (config == null || config.Contains("glMapBufferRangeEXT")) {
            //    glMapBufferRangeEXT = (delegate* unmanaged<GLenum, GLintptr, GLsizeiptr, GLbitfield, void>)GetProcAddress("glMapBufferRangeEXT");
            //}
            //if (config == null || config.Contains("glMapControlPointsNV")) {
            //    glMapControlPointsNV = (delegate* unmanaged<GLenum, GLuint, GLenum, GLsizei, GLsizei, GLint, GLint, GLboolean, IntPtr, void>)GetProcAddress("glMapControlPointsNV");
            //}
            //if (config == null || config.Contains("glMapGrid1d")) {
            //    glMapGrid1d = (delegate* unmanaged<GLint, GLdouble, GLdouble, void>)GetProcAddress("glMapGrid1d");
            //}
            //if (config == null || config.Contains("glMapGrid1f")) {
            //    glMapGrid1f = (delegate* unmanaged<GLint, GLfloat, GLfloat, void>)GetProcAddress("glMapGrid1f");
            //}
            //if (config == null || config.Contains("glMapGrid1xOES")) {
            //    glMapGrid1xOES = (delegate* unmanaged<GLint, GLfixed, GLfixed, void>)GetProcAddress("glMapGrid1xOES");
            //}
            //if (config == null || config.Contains("glMapGrid2d")) {
            //    glMapGrid2d = (delegate* unmanaged<GLint, GLdouble, GLdouble, GLint, GLdouble, GLdouble, void>)GetProcAddress("glMapGrid2d");
            //}
            //if (config == null || config.Contains("glMapGrid2f")) {
            //    glMapGrid2f = (delegate* unmanaged<GLint, GLfloat, GLfloat, GLint, GLfloat, GLfloat, void>)GetProcAddress("glMapGrid2f");
            //}
            //if (config == null || config.Contains("glMapGrid2xOES")) {
            //    glMapGrid2xOES = (delegate* unmanaged<GLint, GLfixed, GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glMapGrid2xOES");
            //}
            //if (config == null || config.Contains("glMapNamedBuffer")) {
            //    glMapNamedBuffer = (delegate* unmanaged<GLuint, GLenum, void>)GetProcAddress("glMapNamedBuffer");
            //}
            //if (config == null || config.Contains("glMapNamedBufferEXT")) {
            //    glMapNamedBufferEXT = (delegate* unmanaged<GLuint, GLenum, void>)GetProcAddress("glMapNamedBufferEXT");
            //}
            //if (config == null || config.Contains("glMapNamedBufferRange")) {
            //    glMapNamedBufferRange = (delegate* unmanaged<GLuint, GLintptr, GLsizeiptr, GLbitfield, void>)GetProcAddress("glMapNamedBufferRange");
            //}
            //if (config == null || config.Contains("glMapNamedBufferRangeEXT")) {
            //    glMapNamedBufferRangeEXT = (delegate* unmanaged<GLuint, GLintptr, GLsizeiptr, GLbitfield, void>)GetProcAddress("glMapNamedBufferRangeEXT");
            //}
            //if (config == null || config.Contains("glMapObjectBufferATI")) {
            //    glMapObjectBufferATI = (delegate* unmanaged<GLuint, void>)GetProcAddress("glMapObjectBufferATI");
            //}
            //if (config == null || config.Contains("glMapParameterfvNV")) {
            //    glMapParameterfvNV = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glMapParameterfvNV");
            //}
            //if (config == null || config.Contains("glMapParameterivNV")) {
            //    glMapParameterivNV = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glMapParameterivNV");
            //}
            //if (config == null || config.Contains("glMapTexture2DINTEL")) {
            //    glMapTexture2DINTEL = (delegate* unmanaged<GLuint, GLint, GLbitfield, GLint[], GLenum[], void>)GetProcAddress("glMapTexture2DINTEL");
            //}
            //if (config == null || config.Contains("glMapVertexAttrib1dAPPLE")) {
            //    glMapVertexAttrib1dAPPLE = (delegate* unmanaged<GLuint, GLuint, GLdouble, GLdouble, GLint, GLint, GLdouble[], void>)GetProcAddress("glMapVertexAttrib1dAPPLE");
            //}
            //if (config == null || config.Contains("glMapVertexAttrib1fAPPLE")) {
            //    glMapVertexAttrib1fAPPLE = (delegate* unmanaged<GLuint, GLuint, GLfloat, GLfloat, GLint, GLint, GLfloat[], void>)GetProcAddress("glMapVertexAttrib1fAPPLE");
            //}
            //if (config == null || config.Contains("glMapVertexAttrib2dAPPLE")) {
            //    glMapVertexAttrib2dAPPLE = (delegate* unmanaged<GLuint, GLuint, GLdouble, GLdouble, GLint, GLint, GLdouble, GLdouble, GLint, GLint, GLdouble[], void>)GetProcAddress("glMapVertexAttrib2dAPPLE");
            //}
            //if (config == null || config.Contains("glMapVertexAttrib2fAPPLE")) {
            //    glMapVertexAttrib2fAPPLE = (delegate* unmanaged<GLuint, GLuint, GLfloat, GLfloat, GLint, GLint, GLfloat, GLfloat, GLint, GLint, GLfloat[], void>)GetProcAddress("glMapVertexAttrib2fAPPLE");
            //}
            //if (config == null || config.Contains("glMaterialf")) {
            //    glMaterialf = (delegate* unmanaged<GLenum, GLenum, GLfloat, void>)GetProcAddress("glMaterialf");
            //}
            //if (config == null || config.Contains("glMaterialfv")) {
            //    glMaterialfv = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glMaterialfv");
            //}
            //if (config == null || config.Contains("glMateriali")) {
            //    glMateriali = (delegate* unmanaged<GLenum, GLenum, GLint, void>)GetProcAddress("glMateriali");
            //}
            //if (config == null || config.Contains("glMaterialiv")) {
            //    glMaterialiv = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glMaterialiv");
            //}
            //if (config == null || config.Contains("glMaterialx")) {
            //    glMaterialx = (delegate* unmanaged<GLenum, GLenum, GLfixed, void>)GetProcAddress("glMaterialx");
            //}
            //if (config == null || config.Contains("glMaterialxOES")) {
            //    glMaterialxOES = (delegate* unmanaged<GLenum, GLenum, GLfixed, void>)GetProcAddress("glMaterialxOES");
            //}
            //if (config == null || config.Contains("glMaterialxv")) {
            //    glMaterialxv = (delegate* unmanaged<GLenum, GLenum, GLfixed[], void>)GetProcAddress("glMaterialxv");
            //}
            //if (config == null || config.Contains("glMaterialxvOES")) {
            //    glMaterialxvOES = (delegate* unmanaged<GLenum, GLenum, GLfixed[], void>)GetProcAddress("glMaterialxvOES");
            //}
            //if (config == null || config.Contains("glMatrixFrustumEXT")) {
            //    glMatrixFrustumEXT = (delegate* unmanaged<GLenum, GLdouble, GLdouble, GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glMatrixFrustumEXT");
            //}
            //if (config == null || config.Contains("glMatrixIndexPointerARB")) {
            //    glMatrixIndexPointerARB = (delegate* unmanaged<GLint, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glMatrixIndexPointerARB");
            //}
            //if (config == null || config.Contains("glMatrixIndexPointerOES")) {
            //    glMatrixIndexPointerOES = (delegate* unmanaged<GLint, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glMatrixIndexPointerOES");
            //}
            //if (config == null || config.Contains("glMatrixIndexubvARB")) {
            //    glMatrixIndexubvARB = (delegate* unmanaged<GLint, GLubyte[], void>)GetProcAddress("glMatrixIndexubvARB");
            //}
            //if (config == null || config.Contains("glMatrixIndexuivARB")) {
            //    glMatrixIndexuivARB = (delegate* unmanaged<GLint, GLuint[], void>)GetProcAddress("glMatrixIndexuivARB");
            //}
            //if (config == null || config.Contains("glMatrixIndexusvARB")) {
            //    glMatrixIndexusvARB = (delegate* unmanaged<GLint, GLushort[], void>)GetProcAddress("glMatrixIndexusvARB");
            //}
            //if (config == null || config.Contains("glMatrixLoad3x2fNV")) {
            //    glMatrixLoad3x2fNV = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glMatrixLoad3x2fNV");
            //}
            //if (config == null || config.Contains("glMatrixLoad3x3fNV")) {
            //    glMatrixLoad3x3fNV = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glMatrixLoad3x3fNV");
            //}
            //if (config == null || config.Contains("glMatrixLoadIdentityEXT")) {
            //    glMatrixLoadIdentityEXT = (delegate* unmanaged<GLenum, void>)GetProcAddress("glMatrixLoadIdentityEXT");
            //}
            //if (config == null || config.Contains("glMatrixLoadTranspose3x3fNV")) {
            //    glMatrixLoadTranspose3x3fNV = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glMatrixLoadTranspose3x3fNV");
            //}
            //if (config == null || config.Contains("glMatrixLoadTransposedEXT")) {
            //    glMatrixLoadTransposedEXT = (delegate* unmanaged<GLenum, GLdouble[], void>)GetProcAddress("glMatrixLoadTransposedEXT");
            //}
            //if (config == null || config.Contains("glMatrixLoadTransposefEXT")) {
            //    glMatrixLoadTransposefEXT = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glMatrixLoadTransposefEXT");
            //}
            //if (config == null || config.Contains("glMatrixLoaddEXT")) {
            //    glMatrixLoaddEXT = (delegate* unmanaged<GLenum, GLdouble[], void>)GetProcAddress("glMatrixLoaddEXT");
            //}
            //if (config == null || config.Contains("glMatrixLoadfEXT")) {
            //    glMatrixLoadfEXT = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glMatrixLoadfEXT");
            //}
            //if (config == null || config.Contains("glMatrixMode")) {
            //    glMatrixMode = (delegate* unmanaged<GLenum, void>)GetProcAddress("glMatrixMode");
            //}
            //if (config == null || config.Contains("glMatrixMult3x2fNV")) {
            //    glMatrixMult3x2fNV = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glMatrixMult3x2fNV");
            //}
            //if (config == null || config.Contains("glMatrixMult3x3fNV")) {
            //    glMatrixMult3x3fNV = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glMatrixMult3x3fNV");
            //}
            //if (config == null || config.Contains("glMatrixMultTranspose3x3fNV")) {
            //    glMatrixMultTranspose3x3fNV = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glMatrixMultTranspose3x3fNV");
            //}
            //if (config == null || config.Contains("glMatrixMultTransposedEXT")) {
            //    glMatrixMultTransposedEXT = (delegate* unmanaged<GLenum, GLdouble[], void>)GetProcAddress("glMatrixMultTransposedEXT");
            //}
            //if (config == null || config.Contains("glMatrixMultTransposefEXT")) {
            //    glMatrixMultTransposefEXT = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glMatrixMultTransposefEXT");
            //}
            //if (config == null || config.Contains("glMatrixMultdEXT")) {
            //    glMatrixMultdEXT = (delegate* unmanaged<GLenum, GLdouble[], void>)GetProcAddress("glMatrixMultdEXT");
            //}
            //if (config == null || config.Contains("glMatrixMultfEXT")) {
            //    glMatrixMultfEXT = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glMatrixMultfEXT");
            //}
            //if (config == null || config.Contains("glMatrixOrthoEXT")) {
            //    glMatrixOrthoEXT = (delegate* unmanaged<GLenum, GLdouble, GLdouble, GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glMatrixOrthoEXT");
            //}
            //if (config == null || config.Contains("glMatrixPopEXT")) {
            //    glMatrixPopEXT = (delegate* unmanaged<GLenum, void>)GetProcAddress("glMatrixPopEXT");
            //}
            //if (config == null || config.Contains("glMatrixPushEXT")) {
            //    glMatrixPushEXT = (delegate* unmanaged<GLenum, void>)GetProcAddress("glMatrixPushEXT");
            //}
            //if (config == null || config.Contains("glMatrixRotatedEXT")) {
            //    glMatrixRotatedEXT = (delegate* unmanaged<GLenum, GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glMatrixRotatedEXT");
            //}
            //if (config == null || config.Contains("glMatrixRotatefEXT")) {
            //    glMatrixRotatefEXT = (delegate* unmanaged<GLenum, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glMatrixRotatefEXT");
            //}
            //if (config == null || config.Contains("glMatrixScaledEXT")) {
            //    glMatrixScaledEXT = (delegate* unmanaged<GLenum, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glMatrixScaledEXT");
            //}
            //if (config == null || config.Contains("glMatrixScalefEXT")) {
            //    glMatrixScalefEXT = (delegate* unmanaged<GLenum, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glMatrixScalefEXT");
            //}
            //if (config == null || config.Contains("glMatrixTranslatedEXT")) {
            //    glMatrixTranslatedEXT = (delegate* unmanaged<GLenum, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glMatrixTranslatedEXT");
            //}
            //if (config == null || config.Contains("glMatrixTranslatefEXT")) {
            //    glMatrixTranslatefEXT = (delegate* unmanaged<GLenum, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glMatrixTranslatefEXT");
            //}
            //if (config == null || config.Contains("glMaxShaderCompilerThreadsKHR")) {
            //    glMaxShaderCompilerThreadsKHR = (delegate* unmanaged<GLuint, void>)GetProcAddress("glMaxShaderCompilerThreadsKHR");
            //}
            //if (config == null || config.Contains("glMaxShaderCompilerThreadsARB")) {
            //    glMaxShaderCompilerThreadsARB = (delegate* unmanaged<GLuint, void>)GetProcAddress("glMaxShaderCompilerThreadsARB");
            //}
            //if (config == null || config.Contains("glMemoryBarrier")) {
            //    glMemoryBarrier = (delegate* unmanaged<GLbitfield, void>)GetProcAddress("glMemoryBarrier");
            //}
            //if (config == null || config.Contains("glMemoryBarrierByRegion")) {
            //    glMemoryBarrierByRegion = (delegate* unmanaged<GLbitfield, void>)GetProcAddress("glMemoryBarrierByRegion");
            //}
            //if (config == null || config.Contains("glMemoryBarrierEXT")) {
            //    glMemoryBarrierEXT = (delegate* unmanaged<GLbitfield, void>)GetProcAddress("glMemoryBarrierEXT");
            //}
            //if (config == null || config.Contains("glMemoryObjectParameterivEXT")) {
            //    glMemoryObjectParameterivEXT = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glMemoryObjectParameterivEXT");
            //}
            //if (config == null || config.Contains("glMinSampleShading")) {
            //    glMinSampleShading = (delegate* unmanaged<GLfloat, void>)GetProcAddress("glMinSampleShading");
            //}
            //if (config == null || config.Contains("glMinSampleShadingARB")) {
            //    glMinSampleShadingARB = (delegate* unmanaged<GLfloat, void>)GetProcAddress("glMinSampleShadingARB");
            //}
            //if (config == null || config.Contains("glMinSampleShadingOES")) {
            //    glMinSampleShadingOES = (delegate* unmanaged<GLfloat, void>)GetProcAddress("glMinSampleShadingOES");
            //}
            //if (config == null || config.Contains("glMinmax")) {
            //    glMinmax = (delegate* unmanaged<GLenum, GLenum, GLboolean, void>)GetProcAddress("glMinmax");
            //}
            //if (config == null || config.Contains("glMinmaxEXT")) {
            //    glMinmaxEXT = (delegate* unmanaged<GLenum, GLenum, GLboolean, void>)GetProcAddress("glMinmaxEXT");
            //}
            //if (config == null || config.Contains("glMultMatrixd")) {
            //    glMultMatrixd = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glMultMatrixd");
            //}
            //if (config == null || config.Contains("glMultMatrixf")) {
            //    glMultMatrixf = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glMultMatrixf");
            //}
            //if (config == null || config.Contains("glMultMatrixx")) {
            //    glMultMatrixx = (delegate* unmanaged<GLfixed[], void>)GetProcAddress("glMultMatrixx");
            //}
            //if (config == null || config.Contains("glMultMatrixxOES")) {
            //    glMultMatrixxOES = (delegate* unmanaged<GLfixed[], void>)GetProcAddress("glMultMatrixxOES");
            //}
            //if (config == null || config.Contains("glMultTransposeMatrixd")) {
            //    glMultTransposeMatrixd = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glMultTransposeMatrixd");
            //}
            //if (config == null || config.Contains("glMultTransposeMatrixdARB")) {
            //    glMultTransposeMatrixdARB = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glMultTransposeMatrixdARB");
            //}
            //if (config == null || config.Contains("glMultTransposeMatrixf")) {
            //    glMultTransposeMatrixf = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glMultTransposeMatrixf");
            //}
            //if (config == null || config.Contains("glMultTransposeMatrixfARB")) {
            //    glMultTransposeMatrixfARB = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glMultTransposeMatrixfARB");
            //}
            //if (config == null || config.Contains("glMultTransposeMatrixxOES")) {
            //    glMultTransposeMatrixxOES = (delegate* unmanaged<GLfixed[], void>)GetProcAddress("glMultTransposeMatrixxOES");
            //}
            //if (config == null || config.Contains("glMultiDrawArrays")) {
            //    glMultiDrawArrays = (delegate* unmanaged<GLenum, GLint[], GLsizei[], GLsizei, void>)GetProcAddress("glMultiDrawArrays");
            //}
            //if (config == null || config.Contains("glMultiDrawArraysEXT")) {
            //    glMultiDrawArraysEXT = (delegate* unmanaged<GLenum, GLint[], GLsizei[], GLsizei, void>)GetProcAddress("glMultiDrawArraysEXT");
            //}
            //if (config == null || config.Contains("glMultiDrawArraysIndirect")) {
            //    glMultiDrawArraysIndirect = (delegate* unmanaged<GLenum, IntPtr, GLsizei, GLsizei, void>)GetProcAddress("glMultiDrawArraysIndirect");
            //}
            //if (config == null || config.Contains("glMultiDrawArraysIndirectAMD")) {
            //    glMultiDrawArraysIndirectAMD = (delegate* unmanaged<GLenum, IntPtr, GLsizei, GLsizei, void>)GetProcAddress("glMultiDrawArraysIndirectAMD");
            //}
            //if (config == null || config.Contains("glMultiDrawArraysIndirectBindlessCountNV")) {
            //    glMultiDrawArraysIndirectBindlessCountNV = (delegate* unmanaged<GLenum, IntPtr, GLsizei, GLsizei, GLsizei, GLint, void>)GetProcAddress("glMultiDrawArraysIndirectBindlessCountNV");
            //}
            //if (config == null || config.Contains("glMultiDrawArraysIndirectBindlessNV")) {
            //    glMultiDrawArraysIndirectBindlessNV = (delegate* unmanaged<GLenum, IntPtr, GLsizei, GLsizei, GLint, void>)GetProcAddress("glMultiDrawArraysIndirectBindlessNV");
            //}
            //if (config == null || config.Contains("glMultiDrawArraysIndirectCount")) {
            //    glMultiDrawArraysIndirectCount = (delegate* unmanaged<GLenum, IntPtr, GLintptr, GLsizei, GLsizei, void>)GetProcAddress("glMultiDrawArraysIndirectCount");
            //}
            //if (config == null || config.Contains("glMultiDrawArraysIndirectCountARB")) {
            //    glMultiDrawArraysIndirectCountARB = (delegate* unmanaged<GLenum, IntPtr, GLintptr, GLsizei, GLsizei, void>)GetProcAddress("glMultiDrawArraysIndirectCountARB");
            //}
            //if (config == null || config.Contains("glMultiDrawArraysIndirectEXT")) {
            //    glMultiDrawArraysIndirectEXT = (delegate* unmanaged<GLenum, IntPtr, GLsizei, GLsizei, void>)GetProcAddress("glMultiDrawArraysIndirectEXT");
            //}
            //if (config == null || config.Contains("glMultiDrawElementArrayAPPLE")) {
            //    glMultiDrawElementArrayAPPLE = (delegate* unmanaged<GLenum, GLint[], GLsizei[], GLsizei, void>)GetProcAddress("glMultiDrawElementArrayAPPLE");
            //}
            //if (config == null || config.Contains("glMultiDrawElements")) {
            //    glMultiDrawElements = (delegate* unmanaged<GLenum, GLsizei[], GLenum, IntPtr, GLsizei, void>)GetProcAddress("glMultiDrawElements");
            //}
            //if (config == null || config.Contains("glMultiDrawElementsBaseVertex")) {
            //    glMultiDrawElementsBaseVertex = (delegate* unmanaged<GLenum, GLsizei[], GLenum, IntPtr, GLsizei, GLint[], void>)GetProcAddress("glMultiDrawElementsBaseVertex");
            //}
            //if (config == null || config.Contains("glMultiDrawElementsBaseVertexEXT")) {
            //    glMultiDrawElementsBaseVertexEXT = (delegate* unmanaged<GLenum, GLsizei[], GLenum, IntPtr, GLsizei, GLint[], void>)GetProcAddress("glMultiDrawElementsBaseVertexEXT");
            //}
            //if (config == null || config.Contains("glMultiDrawElementsEXT")) {
            //    glMultiDrawElementsEXT = (delegate* unmanaged<GLenum, GLsizei[], GLenum, IntPtr, GLsizei, void>)GetProcAddress("glMultiDrawElementsEXT");
            //}
            //if (config == null || config.Contains("glMultiDrawElementsIndirect")) {
            //    glMultiDrawElementsIndirect = (delegate* unmanaged<GLenum, GLenum, IntPtr, GLsizei, GLsizei, void>)GetProcAddress("glMultiDrawElementsIndirect");
            //}
            //if (config == null || config.Contains("glMultiDrawElementsIndirectAMD")) {
            //    glMultiDrawElementsIndirectAMD = (delegate* unmanaged<GLenum, GLenum, IntPtr, GLsizei, GLsizei, void>)GetProcAddress("glMultiDrawElementsIndirectAMD");
            //}
            //if (config == null || config.Contains("glMultiDrawElementsIndirectBindlessCountNV")) {
            //    glMultiDrawElementsIndirectBindlessCountNV = (delegate* unmanaged<GLenum, GLenum, IntPtr, GLsizei, GLsizei, GLsizei, GLint, void>)GetProcAddress("glMultiDrawElementsIndirectBindlessCountNV");
            //}
            //if (config == null || config.Contains("glMultiDrawElementsIndirectBindlessNV")) {
            //    glMultiDrawElementsIndirectBindlessNV = (delegate* unmanaged<GLenum, GLenum, IntPtr, GLsizei, GLsizei, GLint, void>)GetProcAddress("glMultiDrawElementsIndirectBindlessNV");
            //}
            //if (config == null || config.Contains("glMultiDrawElementsIndirectCount")) {
            //    glMultiDrawElementsIndirectCount = (delegate* unmanaged<GLenum, GLenum, IntPtr, GLintptr, GLsizei, GLsizei, void>)GetProcAddress("glMultiDrawElementsIndirectCount");
            //}
            //if (config == null || config.Contains("glMultiDrawElementsIndirectCountARB")) {
            //    glMultiDrawElementsIndirectCountARB = (delegate* unmanaged<GLenum, GLenum, IntPtr, GLintptr, GLsizei, GLsizei, void>)GetProcAddress("glMultiDrawElementsIndirectCountARB");
            //}
            //if (config == null || config.Contains("glMultiDrawElementsIndirectEXT")) {
            //    glMultiDrawElementsIndirectEXT = (delegate* unmanaged<GLenum, GLenum, IntPtr, GLsizei, GLsizei, void>)GetProcAddress("glMultiDrawElementsIndirectEXT");
            //}
            //if (config == null || config.Contains("glMultiDrawMeshTasksIndirectNV")) {
            //    glMultiDrawMeshTasksIndirectNV = (delegate* unmanaged<GLintptr, GLsizei, GLsizei, void>)GetProcAddress("glMultiDrawMeshTasksIndirectNV");
            //}
            //if (config == null || config.Contains("glMultiDrawMeshTasksIndirectCountNV")) {
            //    glMultiDrawMeshTasksIndirectCountNV = (delegate* unmanaged<GLintptr, GLintptr, GLsizei, GLsizei, void>)GetProcAddress("glMultiDrawMeshTasksIndirectCountNV");
            //}
            //if (config == null || config.Contains("glMultiDrawRangeElementArrayAPPLE")) {
            //    glMultiDrawRangeElementArrayAPPLE = (delegate* unmanaged<GLenum, GLuint, GLuint, GLint[], GLsizei[], GLsizei, void>)GetProcAddress("glMultiDrawRangeElementArrayAPPLE");
            //}
            //if (config == null || config.Contains("glMultiModeDrawArraysIBM")) {
            //    glMultiModeDrawArraysIBM = (delegate* unmanaged<GLenum[], GLint[], GLsizei[], GLsizei, GLint, void>)GetProcAddress("glMultiModeDrawArraysIBM");
            //}
            //if (config == null || config.Contains("glMultiModeDrawElementsIBM")) {
            //    glMultiModeDrawElementsIBM = (delegate* unmanaged<GLenum[], GLsizei[], GLenum, IntPtr, GLsizei, GLint, void>)GetProcAddress("glMultiModeDrawElementsIBM");
            //}
            //if (config == null || config.Contains("glMultiTexBufferEXT")) {
            //    glMultiTexBufferEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLuint, void>)GetProcAddress("glMultiTexBufferEXT");
            //}
            //if (config == null || config.Contains("glMultiTexCoord1bOES")) {
            //    glMultiTexCoord1bOES = (delegate* unmanaged<GLenum, GLbyte, void>)GetProcAddress("glMultiTexCoord1bOES");
            //}
            //if (config == null || config.Contains("glMultiTexCoord1bvOES")) {
            //    glMultiTexCoord1bvOES = (delegate* unmanaged<GLenum, GLbyte[], void>)GetProcAddress("glMultiTexCoord1bvOES");
            //}
            //if (config == null || config.Contains("glMultiTexCoord1d")) {
            //    glMultiTexCoord1d = (delegate* unmanaged<GLenum, GLdouble, void>)GetProcAddress("glMultiTexCoord1d");
            //}
            //if (config == null || config.Contains("glMultiTexCoord1dARB")) {
            //    glMultiTexCoord1dARB = (delegate* unmanaged<GLenum, GLdouble, void>)GetProcAddress("glMultiTexCoord1dARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord1dv")) {
            //    glMultiTexCoord1dv = (delegate* unmanaged<GLenum, GLdouble[], void>)GetProcAddress("glMultiTexCoord1dv");
            //}
            //if (config == null || config.Contains("glMultiTexCoord1dvARB")) {
            //    glMultiTexCoord1dvARB = (delegate* unmanaged<GLenum, GLdouble[], void>)GetProcAddress("glMultiTexCoord1dvARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord1f")) {
            //    glMultiTexCoord1f = (delegate* unmanaged<GLenum, GLfloat, void>)GetProcAddress("glMultiTexCoord1f");
            //}
            //if (config == null || config.Contains("glMultiTexCoord1fARB")) {
            //    glMultiTexCoord1fARB = (delegate* unmanaged<GLenum, GLfloat, void>)GetProcAddress("glMultiTexCoord1fARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord1fv")) {
            //    glMultiTexCoord1fv = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glMultiTexCoord1fv");
            //}
            //if (config == null || config.Contains("glMultiTexCoord1fvARB")) {
            //    glMultiTexCoord1fvARB = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glMultiTexCoord1fvARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord1hNV")) {
            //    glMultiTexCoord1hNV = (delegate* unmanaged<GLenum, GLhalfNV, void>)GetProcAddress("glMultiTexCoord1hNV");
            //}
            //if (config == null || config.Contains("glMultiTexCoord1hvNV")) {
            //    glMultiTexCoord1hvNV = (delegate* unmanaged<GLenum, GLhalfNV[], void>)GetProcAddress("glMultiTexCoord1hvNV");
            //}
            //if (config == null || config.Contains("glMultiTexCoord1i")) {
            //    glMultiTexCoord1i = (delegate* unmanaged<GLenum, GLint, void>)GetProcAddress("glMultiTexCoord1i");
            //}
            //if (config == null || config.Contains("glMultiTexCoord1iARB")) {
            //    glMultiTexCoord1iARB = (delegate* unmanaged<GLenum, GLint, void>)GetProcAddress("glMultiTexCoord1iARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord1iv")) {
            //    glMultiTexCoord1iv = (delegate* unmanaged<GLenum, GLint[], void>)GetProcAddress("glMultiTexCoord1iv");
            //}
            //if (config == null || config.Contains("glMultiTexCoord1ivARB")) {
            //    glMultiTexCoord1ivARB = (delegate* unmanaged<GLenum, GLint[], void>)GetProcAddress("glMultiTexCoord1ivARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord1s")) {
            //    glMultiTexCoord1s = (delegate* unmanaged<GLenum, GLshort, void>)GetProcAddress("glMultiTexCoord1s");
            //}
            //if (config == null || config.Contains("glMultiTexCoord1sARB")) {
            //    glMultiTexCoord1sARB = (delegate* unmanaged<GLenum, GLshort, void>)GetProcAddress("glMultiTexCoord1sARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord1sv")) {
            //    glMultiTexCoord1sv = (delegate* unmanaged<GLenum, GLshort[], void>)GetProcAddress("glMultiTexCoord1sv");
            //}
            //if (config == null || config.Contains("glMultiTexCoord1svARB")) {
            //    glMultiTexCoord1svARB = (delegate* unmanaged<GLenum, GLshort[], void>)GetProcAddress("glMultiTexCoord1svARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord1xOES")) {
            //    glMultiTexCoord1xOES = (delegate* unmanaged<GLenum, GLfixed, void>)GetProcAddress("glMultiTexCoord1xOES");
            //}
            //if (config == null || config.Contains("glMultiTexCoord1xvOES")) {
            //    glMultiTexCoord1xvOES = (delegate* unmanaged<GLenum, GLfixed[], void>)GetProcAddress("glMultiTexCoord1xvOES");
            //}
            //if (config == null || config.Contains("glMultiTexCoord2bOES")) {
            //    glMultiTexCoord2bOES = (delegate* unmanaged<GLenum, GLbyte, GLbyte, void>)GetProcAddress("glMultiTexCoord2bOES");
            //}
            //if (config == null || config.Contains("glMultiTexCoord2bvOES")) {
            //    glMultiTexCoord2bvOES = (delegate* unmanaged<GLenum, GLbyte[], void>)GetProcAddress("glMultiTexCoord2bvOES");
            //}
            //if (config == null || config.Contains("glMultiTexCoord2d")) {
            //    glMultiTexCoord2d = (delegate* unmanaged<GLenum, GLdouble, GLdouble, void>)GetProcAddress("glMultiTexCoord2d");
            //}
            //if (config == null || config.Contains("glMultiTexCoord2dARB")) {
            //    glMultiTexCoord2dARB = (delegate* unmanaged<GLenum, GLdouble, GLdouble, void>)GetProcAddress("glMultiTexCoord2dARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord2dv")) {
            //    glMultiTexCoord2dv = (delegate* unmanaged<GLenum, GLdouble[], void>)GetProcAddress("glMultiTexCoord2dv");
            //}
            //if (config == null || config.Contains("glMultiTexCoord2dvARB")) {
            //    glMultiTexCoord2dvARB = (delegate* unmanaged<GLenum, GLdouble[], void>)GetProcAddress("glMultiTexCoord2dvARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord2f")) {
            //    glMultiTexCoord2f = (delegate* unmanaged<GLenum, GLfloat, GLfloat, void>)GetProcAddress("glMultiTexCoord2f");
            //}
            //if (config == null || config.Contains("glMultiTexCoord2fARB")) {
            //    glMultiTexCoord2fARB = (delegate* unmanaged<GLenum, GLfloat, GLfloat, void>)GetProcAddress("glMultiTexCoord2fARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord2fv")) {
            //    glMultiTexCoord2fv = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glMultiTexCoord2fv");
            //}
            //if (config == null || config.Contains("glMultiTexCoord2fvARB")) {
            //    glMultiTexCoord2fvARB = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glMultiTexCoord2fvARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord2hNV")) {
            //    glMultiTexCoord2hNV = (delegate* unmanaged<GLenum, GLhalfNV, GLhalfNV, void>)GetProcAddress("glMultiTexCoord2hNV");
            //}
            //if (config == null || config.Contains("glMultiTexCoord2hvNV")) {
            //    glMultiTexCoord2hvNV = (delegate* unmanaged<GLenum, GLhalfNV[], void>)GetProcAddress("glMultiTexCoord2hvNV");
            //}
            //if (config == null || config.Contains("glMultiTexCoord2i")) {
            //    glMultiTexCoord2i = (delegate* unmanaged<GLenum, GLint, GLint, void>)GetProcAddress("glMultiTexCoord2i");
            //}
            //if (config == null || config.Contains("glMultiTexCoord2iARB")) {
            //    glMultiTexCoord2iARB = (delegate* unmanaged<GLenum, GLint, GLint, void>)GetProcAddress("glMultiTexCoord2iARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord2iv")) {
            //    glMultiTexCoord2iv = (delegate* unmanaged<GLenum, GLint[], void>)GetProcAddress("glMultiTexCoord2iv");
            //}
            //if (config == null || config.Contains("glMultiTexCoord2ivARB")) {
            //    glMultiTexCoord2ivARB = (delegate* unmanaged<GLenum, GLint[], void>)GetProcAddress("glMultiTexCoord2ivARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord2s")) {
            //    glMultiTexCoord2s = (delegate* unmanaged<GLenum, GLshort, GLshort, void>)GetProcAddress("glMultiTexCoord2s");
            //}
            //if (config == null || config.Contains("glMultiTexCoord2sARB")) {
            //    glMultiTexCoord2sARB = (delegate* unmanaged<GLenum, GLshort, GLshort, void>)GetProcAddress("glMultiTexCoord2sARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord2sv")) {
            //    glMultiTexCoord2sv = (delegate* unmanaged<GLenum, GLshort[], void>)GetProcAddress("glMultiTexCoord2sv");
            //}
            //if (config == null || config.Contains("glMultiTexCoord2svARB")) {
            //    glMultiTexCoord2svARB = (delegate* unmanaged<GLenum, GLshort[], void>)GetProcAddress("glMultiTexCoord2svARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord2xOES")) {
            //    glMultiTexCoord2xOES = (delegate* unmanaged<GLenum, GLfixed, GLfixed, void>)GetProcAddress("glMultiTexCoord2xOES");
            //}
            //if (config == null || config.Contains("glMultiTexCoord2xvOES")) {
            //    glMultiTexCoord2xvOES = (delegate* unmanaged<GLenum, GLfixed[], void>)GetProcAddress("glMultiTexCoord2xvOES");
            //}
            //if (config == null || config.Contains("glMultiTexCoord3bOES")) {
            //    glMultiTexCoord3bOES = (delegate* unmanaged<GLenum, GLbyte, GLbyte, GLbyte, void>)GetProcAddress("glMultiTexCoord3bOES");
            //}
            //if (config == null || config.Contains("glMultiTexCoord3bvOES")) {
            //    glMultiTexCoord3bvOES = (delegate* unmanaged<GLenum, GLbyte[], void>)GetProcAddress("glMultiTexCoord3bvOES");
            //}
            //if (config == null || config.Contains("glMultiTexCoord3d")) {
            //    glMultiTexCoord3d = (delegate* unmanaged<GLenum, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glMultiTexCoord3d");
            //}
            //if (config == null || config.Contains("glMultiTexCoord3dARB")) {
            //    glMultiTexCoord3dARB = (delegate* unmanaged<GLenum, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glMultiTexCoord3dARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord3dv")) {
            //    glMultiTexCoord3dv = (delegate* unmanaged<GLenum, GLdouble[], void>)GetProcAddress("glMultiTexCoord3dv");
            //}
            //if (config == null || config.Contains("glMultiTexCoord3dvARB")) {
            //    glMultiTexCoord3dvARB = (delegate* unmanaged<GLenum, GLdouble[], void>)GetProcAddress("glMultiTexCoord3dvARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord3f")) {
            //    glMultiTexCoord3f = (delegate* unmanaged<GLenum, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glMultiTexCoord3f");
            //}
            //if (config == null || config.Contains("glMultiTexCoord3fARB")) {
            //    glMultiTexCoord3fARB = (delegate* unmanaged<GLenum, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glMultiTexCoord3fARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord3fv")) {
            //    glMultiTexCoord3fv = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glMultiTexCoord3fv");
            //}
            //if (config == null || config.Contains("glMultiTexCoord3fvARB")) {
            //    glMultiTexCoord3fvARB = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glMultiTexCoord3fvARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord3hNV")) {
            //    glMultiTexCoord3hNV = (delegate* unmanaged<GLenum, GLhalfNV, GLhalfNV, GLhalfNV, void>)GetProcAddress("glMultiTexCoord3hNV");
            //}
            //if (config == null || config.Contains("glMultiTexCoord3hvNV")) {
            //    glMultiTexCoord3hvNV = (delegate* unmanaged<GLenum, GLhalfNV[], void>)GetProcAddress("glMultiTexCoord3hvNV");
            //}
            //if (config == null || config.Contains("glMultiTexCoord3i")) {
            //    glMultiTexCoord3i = (delegate* unmanaged<GLenum, GLint, GLint, GLint, void>)GetProcAddress("glMultiTexCoord3i");
            //}
            //if (config == null || config.Contains("glMultiTexCoord3iARB")) {
            //    glMultiTexCoord3iARB = (delegate* unmanaged<GLenum, GLint, GLint, GLint, void>)GetProcAddress("glMultiTexCoord3iARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord3iv")) {
            //    glMultiTexCoord3iv = (delegate* unmanaged<GLenum, GLint[], void>)GetProcAddress("glMultiTexCoord3iv");
            //}
            //if (config == null || config.Contains("glMultiTexCoord3ivARB")) {
            //    glMultiTexCoord3ivARB = (delegate* unmanaged<GLenum, GLint[], void>)GetProcAddress("glMultiTexCoord3ivARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord3s")) {
            //    glMultiTexCoord3s = (delegate* unmanaged<GLenum, GLshort, GLshort, GLshort, void>)GetProcAddress("glMultiTexCoord3s");
            //}
            //if (config == null || config.Contains("glMultiTexCoord3sARB")) {
            //    glMultiTexCoord3sARB = (delegate* unmanaged<GLenum, GLshort, GLshort, GLshort, void>)GetProcAddress("glMultiTexCoord3sARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord3sv")) {
            //    glMultiTexCoord3sv = (delegate* unmanaged<GLenum, GLshort[], void>)GetProcAddress("glMultiTexCoord3sv");
            //}
            //if (config == null || config.Contains("glMultiTexCoord3svARB")) {
            //    glMultiTexCoord3svARB = (delegate* unmanaged<GLenum, GLshort[], void>)GetProcAddress("glMultiTexCoord3svARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord3xOES")) {
            //    glMultiTexCoord3xOES = (delegate* unmanaged<GLenum, GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glMultiTexCoord3xOES");
            //}
            //if (config == null || config.Contains("glMultiTexCoord3xvOES")) {
            //    glMultiTexCoord3xvOES = (delegate* unmanaged<GLenum, GLfixed[], void>)GetProcAddress("glMultiTexCoord3xvOES");
            //}
            //if (config == null || config.Contains("glMultiTexCoord4bOES")) {
            //    glMultiTexCoord4bOES = (delegate* unmanaged<GLenum, GLbyte, GLbyte, GLbyte, GLbyte, void>)GetProcAddress("glMultiTexCoord4bOES");
            //}
            //if (config == null || config.Contains("glMultiTexCoord4bvOES")) {
            //    glMultiTexCoord4bvOES = (delegate* unmanaged<GLenum, GLbyte[], void>)GetProcAddress("glMultiTexCoord4bvOES");
            //}
            //if (config == null || config.Contains("glMultiTexCoord4d")) {
            //    glMultiTexCoord4d = (delegate* unmanaged<GLenum, GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glMultiTexCoord4d");
            //}
            //if (config == null || config.Contains("glMultiTexCoord4dARB")) {
            //    glMultiTexCoord4dARB = (delegate* unmanaged<GLenum, GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glMultiTexCoord4dARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord4dv")) {
            //    glMultiTexCoord4dv = (delegate* unmanaged<GLenum, GLdouble[], void>)GetProcAddress("glMultiTexCoord4dv");
            //}
            //if (config == null || config.Contains("glMultiTexCoord4dvARB")) {
            //    glMultiTexCoord4dvARB = (delegate* unmanaged<GLenum, GLdouble[], void>)GetProcAddress("glMultiTexCoord4dvARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord4f")) {
            //    glMultiTexCoord4f = (delegate* unmanaged<GLenum, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glMultiTexCoord4f");
            //}
            //if (config == null || config.Contains("glMultiTexCoord4fARB")) {
            //    glMultiTexCoord4fARB = (delegate* unmanaged<GLenum, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glMultiTexCoord4fARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord4fv")) {
            //    glMultiTexCoord4fv = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glMultiTexCoord4fv");
            //}
            //if (config == null || config.Contains("glMultiTexCoord4fvARB")) {
            //    glMultiTexCoord4fvARB = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glMultiTexCoord4fvARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord4hNV")) {
            //    glMultiTexCoord4hNV = (delegate* unmanaged<GLenum, GLhalfNV, GLhalfNV, GLhalfNV, GLhalfNV, void>)GetProcAddress("glMultiTexCoord4hNV");
            //}
            //if (config == null || config.Contains("glMultiTexCoord4hvNV")) {
            //    glMultiTexCoord4hvNV = (delegate* unmanaged<GLenum, GLhalfNV[], void>)GetProcAddress("glMultiTexCoord4hvNV");
            //}
            //if (config == null || config.Contains("glMultiTexCoord4i")) {
            //    glMultiTexCoord4i = (delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, void>)GetProcAddress("glMultiTexCoord4i");
            //}
            //if (config == null || config.Contains("glMultiTexCoord4iARB")) {
            //    glMultiTexCoord4iARB = (delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, void>)GetProcAddress("glMultiTexCoord4iARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord4iv")) {
            //    glMultiTexCoord4iv = (delegate* unmanaged<GLenum, GLint[], void>)GetProcAddress("glMultiTexCoord4iv");
            //}
            //if (config == null || config.Contains("glMultiTexCoord4ivARB")) {
            //    glMultiTexCoord4ivARB = (delegate* unmanaged<GLenum, GLint[], void>)GetProcAddress("glMultiTexCoord4ivARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord4s")) {
            //    glMultiTexCoord4s = (delegate* unmanaged<GLenum, GLshort, GLshort, GLshort, GLshort, void>)GetProcAddress("glMultiTexCoord4s");
            //}
            //if (config == null || config.Contains("glMultiTexCoord4sARB")) {
            //    glMultiTexCoord4sARB = (delegate* unmanaged<GLenum, GLshort, GLshort, GLshort, GLshort, void>)GetProcAddress("glMultiTexCoord4sARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord4sv")) {
            //    glMultiTexCoord4sv = (delegate* unmanaged<GLenum, GLshort[], void>)GetProcAddress("glMultiTexCoord4sv");
            //}
            //if (config == null || config.Contains("glMultiTexCoord4svARB")) {
            //    glMultiTexCoord4svARB = (delegate* unmanaged<GLenum, GLshort[], void>)GetProcAddress("glMultiTexCoord4svARB");
            //}
            //if (config == null || config.Contains("glMultiTexCoord4x")) {
            //    glMultiTexCoord4x = (delegate* unmanaged<GLenum, GLfixed, GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glMultiTexCoord4x");
            //}
            //if (config == null || config.Contains("glMultiTexCoord4xOES")) {
            //    glMultiTexCoord4xOES = (delegate* unmanaged<GLenum, GLfixed, GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glMultiTexCoord4xOES");
            //}
            //if (config == null || config.Contains("glMultiTexCoord4xvOES")) {
            //    glMultiTexCoord4xvOES = (delegate* unmanaged<GLenum, GLfixed[], void>)GetProcAddress("glMultiTexCoord4xvOES");
            //}
            //if (config == null || config.Contains("glMultiTexCoordP1ui")) {
            //    glMultiTexCoordP1ui = (delegate* unmanaged<GLenum, GLenum, GLuint, void>)GetProcAddress("glMultiTexCoordP1ui");
            //}
            //if (config == null || config.Contains("glMultiTexCoordP1uiv")) {
            //    glMultiTexCoordP1uiv = (delegate* unmanaged<GLenum, GLenum, GLuint[], void>)GetProcAddress("glMultiTexCoordP1uiv");
            //}
            //if (config == null || config.Contains("glMultiTexCoordP2ui")) {
            //    glMultiTexCoordP2ui = (delegate* unmanaged<GLenum, GLenum, GLuint, void>)GetProcAddress("glMultiTexCoordP2ui");
            //}
            //if (config == null || config.Contains("glMultiTexCoordP2uiv")) {
            //    glMultiTexCoordP2uiv = (delegate* unmanaged<GLenum, GLenum, GLuint[], void>)GetProcAddress("glMultiTexCoordP2uiv");
            //}
            //if (config == null || config.Contains("glMultiTexCoordP3ui")) {
            //    glMultiTexCoordP3ui = (delegate* unmanaged<GLenum, GLenum, GLuint, void>)GetProcAddress("glMultiTexCoordP3ui");
            //}
            //if (config == null || config.Contains("glMultiTexCoordP3uiv")) {
            //    glMultiTexCoordP3uiv = (delegate* unmanaged<GLenum, GLenum, GLuint[], void>)GetProcAddress("glMultiTexCoordP3uiv");
            //}
            //if (config == null || config.Contains("glMultiTexCoordP4ui")) {
            //    glMultiTexCoordP4ui = (delegate* unmanaged<GLenum, GLenum, GLuint, void>)GetProcAddress("glMultiTexCoordP4ui");
            //}
            //if (config == null || config.Contains("glMultiTexCoordP4uiv")) {
            //    glMultiTexCoordP4uiv = (delegate* unmanaged<GLenum, GLenum, GLuint[], void>)GetProcAddress("glMultiTexCoordP4uiv");
            //}
            //if (config == null || config.Contains("glMultiTexCoordPointerEXT")) {
            //    glMultiTexCoordPointerEXT = (delegate* unmanaged<GLenum, GLint, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glMultiTexCoordPointerEXT");
            //}
            //if (config == null || config.Contains("glMultiTexEnvfEXT")) {
            //    glMultiTexEnvfEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLfloat, void>)GetProcAddress("glMultiTexEnvfEXT");
            //}
            //if (config == null || config.Contains("glMultiTexEnvfvEXT")) {
            //    glMultiTexEnvfvEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLfloat[], void>)GetProcAddress("glMultiTexEnvfvEXT");
            //}
            //if (config == null || config.Contains("glMultiTexEnviEXT")) {
            //    glMultiTexEnviEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLint, void>)GetProcAddress("glMultiTexEnviEXT");
            //}
            //if (config == null || config.Contains("glMultiTexEnvivEXT")) {
            //    glMultiTexEnvivEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLint[], void>)GetProcAddress("glMultiTexEnvivEXT");
            //}
            //if (config == null || config.Contains("glMultiTexGendEXT")) {
            //    glMultiTexGendEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLdouble, void>)GetProcAddress("glMultiTexGendEXT");
            //}
            //if (config == null || config.Contains("glMultiTexGendvEXT")) {
            //    glMultiTexGendvEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLdouble[], void>)GetProcAddress("glMultiTexGendvEXT");
            //}
            //if (config == null || config.Contains("glMultiTexGenfEXT")) {
            //    glMultiTexGenfEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLfloat, void>)GetProcAddress("glMultiTexGenfEXT");
            //}
            //if (config == null || config.Contains("glMultiTexGenfvEXT")) {
            //    glMultiTexGenfvEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLfloat[], void>)GetProcAddress("glMultiTexGenfvEXT");
            //}
            //if (config == null || config.Contains("glMultiTexGeniEXT")) {
            //    glMultiTexGeniEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLint, void>)GetProcAddress("glMultiTexGeniEXT");
            //}
            //if (config == null || config.Contains("glMultiTexGenivEXT")) {
            //    glMultiTexGenivEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLint[], void>)GetProcAddress("glMultiTexGenivEXT");
            //}
            //if (config == null || config.Contains("glMultiTexImage1DEXT")) {
            //    glMultiTexImage1DEXT = (delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLsizei, GLint, GLenum, GLenum, IntPtr, void>)GetProcAddress("glMultiTexImage1DEXT");
            //}
            //if (config == null || config.Contains("glMultiTexImage2DEXT")) {
            //    glMultiTexImage2DEXT = (delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLsizei, GLsizei, GLint, GLenum, GLenum, IntPtr, void>)GetProcAddress("glMultiTexImage2DEXT");
            //}
            //if (config == null || config.Contains("glMultiTexImage3DEXT")) {
            //    glMultiTexImage3DEXT = (delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLsizei, GLsizei, GLsizei, GLint, GLenum, GLenum, IntPtr, void>)GetProcAddress("glMultiTexImage3DEXT");
            //}
            //if (config == null || config.Contains("glMultiTexParameterIivEXT")) {
            //    glMultiTexParameterIivEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLint[], void>)GetProcAddress("glMultiTexParameterIivEXT");
            //}
            //if (config == null || config.Contains("glMultiTexParameterIuivEXT")) {
            //    glMultiTexParameterIuivEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLuint[], void>)GetProcAddress("glMultiTexParameterIuivEXT");
            //}
            //if (config == null || config.Contains("glMultiTexParameterfEXT")) {
            //    glMultiTexParameterfEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLfloat, void>)GetProcAddress("glMultiTexParameterfEXT");
            //}
            //if (config == null || config.Contains("glMultiTexParameterfvEXT")) {
            //    glMultiTexParameterfvEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLfloat[], void>)GetProcAddress("glMultiTexParameterfvEXT");
            //}
            //if (config == null || config.Contains("glMultiTexParameteriEXT")) {
            //    glMultiTexParameteriEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLint, void>)GetProcAddress("glMultiTexParameteriEXT");
            //}
            //if (config == null || config.Contains("glMultiTexParameterivEXT")) {
            //    glMultiTexParameterivEXT = (delegate* unmanaged<GLenum, GLenum, GLenum, GLint[], void>)GetProcAddress("glMultiTexParameterivEXT");
            //}
            //if (config == null || config.Contains("glMultiTexRenderbufferEXT")) {
            //    glMultiTexRenderbufferEXT = (delegate* unmanaged<GLenum, GLenum, GLuint, void>)GetProcAddress("glMultiTexRenderbufferEXT");
            //}
            //if (config == null || config.Contains("glMultiTexSubImage1DEXT")) {
            //    glMultiTexSubImage1DEXT = (delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glMultiTexSubImage1DEXT");
            //}
            //if (config == null || config.Contains("glMultiTexSubImage2DEXT")) {
            //    glMultiTexSubImage2DEXT = (delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLint, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glMultiTexSubImage2DEXT");
            //}
            //if (config == null || config.Contains("glMultiTexSubImage3DEXT")) {
            //    glMultiTexSubImage3DEXT = (delegate* unmanaged<GLenum, GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glMultiTexSubImage3DEXT");
            //}
            //if (config == null || config.Contains("glMulticastBarrierNV")) {
            //    glMulticastBarrierNV = (delegate* unmanaged<void>)GetProcAddress("glMulticastBarrierNV");
            //}
            //if (config == null || config.Contains("glMulticastBlitFramebufferNV")) {
            //    glMulticastBlitFramebufferNV = (delegate* unmanaged<GLuint, GLuint, GLint, GLint, GLint, GLint, GLint, GLint, GLint, GLint, GLbitfield, GLenum, void>)GetProcAddress("glMulticastBlitFramebufferNV");
            //}
            //if (config == null || config.Contains("glMulticastBufferSubDataNV")) {
            //    glMulticastBufferSubDataNV = (delegate* unmanaged<GLbitfield, GLuint, GLintptr, GLsizeiptr, IntPtr, void>)GetProcAddress("glMulticastBufferSubDataNV");
            //}
            //if (config == null || config.Contains("glMulticastCopyBufferSubDataNV")) {
            //    glMulticastCopyBufferSubDataNV = (delegate* unmanaged<GLuint, GLbitfield, GLuint, GLuint, GLintptr, GLintptr, GLsizeiptr, void>)GetProcAddress("glMulticastCopyBufferSubDataNV");
            //}
            //if (config == null || config.Contains("glMulticastCopyImageSubDataNV")) {
            //    glMulticastCopyImageSubDataNV = (delegate* unmanaged<GLuint, GLbitfield, GLuint, GLenum, GLint, GLint, GLint, GLint, GLuint, GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, void>)GetProcAddress("glMulticastCopyImageSubDataNV");
            //}
            //if (config == null || config.Contains("glMulticastFramebufferSampleLocationsfvNV")) {
            //    glMulticastFramebufferSampleLocationsfvNV = (delegate* unmanaged<GLuint, GLuint, GLuint, GLsizei, GLfloat[], void>)GetProcAddress("glMulticastFramebufferSampleLocationsfvNV");
            //}
            //if (config == null || config.Contains("glMulticastGetQueryObjecti64vNV")) {
            //    glMulticastGetQueryObjecti64vNV = (delegate* unmanaged<GLuint, GLuint, GLenum, GLint64[], void>)GetProcAddress("glMulticastGetQueryObjecti64vNV");
            //}
            //if (config == null || config.Contains("glMulticastGetQueryObjectivNV")) {
            //    glMulticastGetQueryObjectivNV = (delegate* unmanaged<GLuint, GLuint, GLenum, GLint[], void>)GetProcAddress("glMulticastGetQueryObjectivNV");
            //}
            //if (config == null || config.Contains("glMulticastGetQueryObjectui64vNV")) {
            //    glMulticastGetQueryObjectui64vNV = (delegate* unmanaged<GLuint, GLuint, GLenum, GLuint64[], void>)GetProcAddress("glMulticastGetQueryObjectui64vNV");
            //}
            //if (config == null || config.Contains("glMulticastGetQueryObjectuivNV")) {
            //    glMulticastGetQueryObjectuivNV = (delegate* unmanaged<GLuint, GLuint, GLenum, GLuint[], void>)GetProcAddress("glMulticastGetQueryObjectuivNV");
            //}
            //if (config == null || config.Contains("glMulticastScissorArrayvNVX")) {
            //    glMulticastScissorArrayvNVX = (delegate* unmanaged<GLuint, GLuint, GLsizei, GLint[], void>)GetProcAddress("glMulticastScissorArrayvNVX");
            //}
            //if (config == null || config.Contains("glMulticastViewportArrayvNVX")) {
            //    glMulticastViewportArrayvNVX = (delegate* unmanaged<GLuint, GLuint, GLsizei, GLfloat[], void>)GetProcAddress("glMulticastViewportArrayvNVX");
            //}
            //if (config == null || config.Contains("glMulticastViewportPositionWScaleNVX")) {
            //    glMulticastViewportPositionWScaleNVX = (delegate* unmanaged<GLuint, GLuint, GLfloat, GLfloat, void>)GetProcAddress("glMulticastViewportPositionWScaleNVX");
            //}
            //if (config == null || config.Contains("glMulticastWaitSyncNV")) {
            //    glMulticastWaitSyncNV = (delegate* unmanaged<GLuint, GLbitfield, void>)GetProcAddress("glMulticastWaitSyncNV");
            //}
            //if (config == null || config.Contains("glNamedBufferAttachMemoryNV")) {
            //    glNamedBufferAttachMemoryNV = (delegate* unmanaged<GLuint, GLuint, GLuint64, void>)GetProcAddress("glNamedBufferAttachMemoryNV");
            //}
            //if (config == null || config.Contains("glNamedBufferData")) {
            //    glNamedBufferData = (delegate* unmanaged<GLuint, GLsizeiptr, IntPtr, GLenum, void>)GetProcAddress("glNamedBufferData");
            //}
            //if (config == null || config.Contains("glNamedBufferDataEXT")) {
            //    glNamedBufferDataEXT = (delegate* unmanaged<GLuint, GLsizeiptr, IntPtr, GLenum, void>)GetProcAddress("glNamedBufferDataEXT");
            //}
            //if (config == null || config.Contains("glNamedBufferPageCommitmentARB")) {
            //    glNamedBufferPageCommitmentARB = (delegate* unmanaged<GLuint, GLintptr, GLsizeiptr, GLboolean, void>)GetProcAddress("glNamedBufferPageCommitmentARB");
            //}
            //if (config == null || config.Contains("glNamedBufferPageCommitmentEXT")) {
            //    glNamedBufferPageCommitmentEXT = (delegate* unmanaged<GLuint, GLintptr, GLsizeiptr, GLboolean, void>)GetProcAddress("glNamedBufferPageCommitmentEXT");
            //}
            //if (config == null || config.Contains("glNamedBufferStorage")) {
            //    glNamedBufferStorage = (delegate* unmanaged<GLuint, GLsizeiptr, IntPtr, GLbitfield, void>)GetProcAddress("glNamedBufferStorage");
            //}
            //if (config == null || config.Contains("glNamedBufferStorageExternalEXT")) {
            //    glNamedBufferStorageExternalEXT = (delegate* unmanaged<GLuint, GLintptr, GLsizeiptr, GLeglClientBufferEXT, GLbitfield, void>)GetProcAddress("glNamedBufferStorageExternalEXT");
            //}
            //if (config == null || config.Contains("glNamedBufferStorageEXT")) {
            //    glNamedBufferStorageEXT = (delegate* unmanaged<GLuint, GLsizeiptr, IntPtr, GLbitfield, void>)GetProcAddress("glNamedBufferStorageEXT");
            //}
            //if (config == null || config.Contains("glNamedBufferStorageMemEXT")) {
            //    glNamedBufferStorageMemEXT = (delegate* unmanaged<GLuint, GLsizeiptr, GLuint, GLuint64, void>)GetProcAddress("glNamedBufferStorageMemEXT");
            //}
            //if (config == null || config.Contains("glNamedBufferSubData")) {
            //    glNamedBufferSubData = (delegate* unmanaged<GLuint, GLintptr, GLsizeiptr, IntPtr, void>)GetProcAddress("glNamedBufferSubData");
            //}
            //if (config == null || config.Contains("glNamedBufferSubDataEXT")) {
            //    glNamedBufferSubDataEXT = (delegate* unmanaged<GLuint, GLintptr, GLsizeiptr, IntPtr, void>)GetProcAddress("glNamedBufferSubDataEXT");
            //}
            //if (config == null || config.Contains("glNamedCopyBufferSubDataEXT")) {
            //    glNamedCopyBufferSubDataEXT = (delegate* unmanaged<GLuint, GLuint, GLintptr, GLintptr, GLsizeiptr, void>)GetProcAddress("glNamedCopyBufferSubDataEXT");
            //}
            //if (config == null || config.Contains("glNamedFramebufferDrawBuffer")) {
            //    glNamedFramebufferDrawBuffer = (delegate* unmanaged<GLuint, GLenum, void>)GetProcAddress("glNamedFramebufferDrawBuffer");
            //}
            //if (config == null || config.Contains("glNamedFramebufferDrawBuffers")) {
            //    glNamedFramebufferDrawBuffers = (delegate* unmanaged<GLuint, GLsizei, GLenum[], void>)GetProcAddress("glNamedFramebufferDrawBuffers");
            //}
            //if (config == null || config.Contains("glNamedFramebufferParameteri")) {
            //    glNamedFramebufferParameteri = (delegate* unmanaged<GLuint, GLenum, GLint, void>)GetProcAddress("glNamedFramebufferParameteri");
            //}
            //if (config == null || config.Contains("glNamedFramebufferParameteriEXT")) {
            //    glNamedFramebufferParameteriEXT = (delegate* unmanaged<GLuint, GLenum, GLint, void>)GetProcAddress("glNamedFramebufferParameteriEXT");
            //}
            //if (config == null || config.Contains("glNamedFramebufferReadBuffer")) {
            //    glNamedFramebufferReadBuffer = (delegate* unmanaged<GLuint, GLenum, void>)GetProcAddress("glNamedFramebufferReadBuffer");
            //}
            //if (config == null || config.Contains("glNamedFramebufferRenderbuffer")) {
            //    glNamedFramebufferRenderbuffer = (delegate* unmanaged<GLuint, GLenum, GLenum, GLuint, void>)GetProcAddress("glNamedFramebufferRenderbuffer");
            //}
            //if (config == null || config.Contains("glNamedFramebufferRenderbufferEXT")) {
            //    glNamedFramebufferRenderbufferEXT = (delegate* unmanaged<GLuint, GLenum, GLenum, GLuint, void>)GetProcAddress("glNamedFramebufferRenderbufferEXT");
            //}
            //if (config == null || config.Contains("glNamedFramebufferSampleLocationsfvARB")) {
            //    glNamedFramebufferSampleLocationsfvARB = (delegate* unmanaged<GLuint, GLuint, GLsizei, GLfloat[], void>)GetProcAddress("glNamedFramebufferSampleLocationsfvARB");
            //}
            //if (config == null || config.Contains("glNamedFramebufferSampleLocationsfvNV")) {
            //    glNamedFramebufferSampleLocationsfvNV = (delegate* unmanaged<GLuint, GLuint, GLsizei, GLfloat[], void>)GetProcAddress("glNamedFramebufferSampleLocationsfvNV");
            //}
            //if (config == null || config.Contains("glNamedFramebufferTexture")) {
            //    glNamedFramebufferTexture = (delegate* unmanaged<GLuint, GLenum, GLuint, GLint, void>)GetProcAddress("glNamedFramebufferTexture");
            //}
            //if (config == null || config.Contains("glNamedFramebufferSamplePositionsfvAMD")) {
            //    glNamedFramebufferSamplePositionsfvAMD = (delegate* unmanaged<GLuint, GLuint, GLuint, GLfloat[], void>)GetProcAddress("glNamedFramebufferSamplePositionsfvAMD");
            //}
            //if (config == null || config.Contains("glNamedFramebufferTexture1DEXT")) {
            //    glNamedFramebufferTexture1DEXT = (delegate* unmanaged<GLuint, GLenum, GLenum, GLuint, GLint, void>)GetProcAddress("glNamedFramebufferTexture1DEXT");
            //}
            //if (config == null || config.Contains("glNamedFramebufferTexture2DEXT")) {
            //    glNamedFramebufferTexture2DEXT = (delegate* unmanaged<GLuint, GLenum, GLenum, GLuint, GLint, void>)GetProcAddress("glNamedFramebufferTexture2DEXT");
            //}
            //if (config == null || config.Contains("glNamedFramebufferTexture3DEXT")) {
            //    glNamedFramebufferTexture3DEXT = (delegate* unmanaged<GLuint, GLenum, GLenum, GLuint, GLint, GLint, void>)GetProcAddress("glNamedFramebufferTexture3DEXT");
            //}
            //if (config == null || config.Contains("glNamedFramebufferTextureEXT")) {
            //    glNamedFramebufferTextureEXT = (delegate* unmanaged<GLuint, GLenum, GLuint, GLint, void>)GetProcAddress("glNamedFramebufferTextureEXT");
            //}
            //if (config == null || config.Contains("glNamedFramebufferTextureFaceEXT")) {
            //    glNamedFramebufferTextureFaceEXT = (delegate* unmanaged<GLuint, GLenum, GLuint, GLint, GLenum, void>)GetProcAddress("glNamedFramebufferTextureFaceEXT");
            //}
            //if (config == null || config.Contains("glNamedFramebufferTextureLayer")) {
            //    glNamedFramebufferTextureLayer = (delegate* unmanaged<GLuint, GLenum, GLuint, GLint, GLint, void>)GetProcAddress("glNamedFramebufferTextureLayer");
            //}
            //if (config == null || config.Contains("glNamedFramebufferTextureLayerEXT")) {
            //    glNamedFramebufferTextureLayerEXT = (delegate* unmanaged<GLuint, GLenum, GLuint, GLint, GLint, void>)GetProcAddress("glNamedFramebufferTextureLayerEXT");
            //}
            //if (config == null || config.Contains("glNamedProgramLocalParameter4dEXT")) {
            //    glNamedProgramLocalParameter4dEXT = (delegate* unmanaged<GLuint, GLenum, GLuint, GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glNamedProgramLocalParameter4dEXT");
            //}
            //if (config == null || config.Contains("glNamedProgramLocalParameter4dvEXT")) {
            //    glNamedProgramLocalParameter4dvEXT = (delegate* unmanaged<GLuint, GLenum, GLuint, GLdouble[], void>)GetProcAddress("glNamedProgramLocalParameter4dvEXT");
            //}
            //if (config == null || config.Contains("glNamedProgramLocalParameter4fEXT")) {
            //    glNamedProgramLocalParameter4fEXT = (delegate* unmanaged<GLuint, GLenum, GLuint, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glNamedProgramLocalParameter4fEXT");
            //}
            //if (config == null || config.Contains("glNamedProgramLocalParameter4fvEXT")) {
            //    glNamedProgramLocalParameter4fvEXT = (delegate* unmanaged<GLuint, GLenum, GLuint, GLfloat[], void>)GetProcAddress("glNamedProgramLocalParameter4fvEXT");
            //}
            //if (config == null || config.Contains("glNamedProgramLocalParameterI4iEXT")) {
            //    glNamedProgramLocalParameterI4iEXT = (delegate* unmanaged<GLuint, GLenum, GLuint, GLint, GLint, GLint, GLint, void>)GetProcAddress("glNamedProgramLocalParameterI4iEXT");
            //}
            //if (config == null || config.Contains("glNamedProgramLocalParameterI4ivEXT")) {
            //    glNamedProgramLocalParameterI4ivEXT = (delegate* unmanaged<GLuint, GLenum, GLuint, GLint[], void>)GetProcAddress("glNamedProgramLocalParameterI4ivEXT");
            //}
            //if (config == null || config.Contains("glNamedProgramLocalParameterI4uiEXT")) {
            //    glNamedProgramLocalParameterI4uiEXT = (delegate* unmanaged<GLuint, GLenum, GLuint, GLuint, GLuint, GLuint, GLuint, void>)GetProcAddress("glNamedProgramLocalParameterI4uiEXT");
            //}
            //if (config == null || config.Contains("glNamedProgramLocalParameterI4uivEXT")) {
            //    glNamedProgramLocalParameterI4uivEXT = (delegate* unmanaged<GLuint, GLenum, GLuint, GLuint[], void>)GetProcAddress("glNamedProgramLocalParameterI4uivEXT");
            //}
            //if (config == null || config.Contains("glNamedProgramLocalParameters4fvEXT")) {
            //    glNamedProgramLocalParameters4fvEXT = (delegate* unmanaged<GLuint, GLenum, GLuint, GLsizei, GLfloat[], void>)GetProcAddress("glNamedProgramLocalParameters4fvEXT");
            //}
            //if (config == null || config.Contains("glNamedProgramLocalParametersI4ivEXT")) {
            //    glNamedProgramLocalParametersI4ivEXT = (delegate* unmanaged<GLuint, GLenum, GLuint, GLsizei, GLint[], void>)GetProcAddress("glNamedProgramLocalParametersI4ivEXT");
            //}
            //if (config == null || config.Contains("glNamedProgramLocalParametersI4uivEXT")) {
            //    glNamedProgramLocalParametersI4uivEXT = (delegate* unmanaged<GLuint, GLenum, GLuint, GLsizei, GLuint[], void>)GetProcAddress("glNamedProgramLocalParametersI4uivEXT");
            //}
            //if (config == null || config.Contains("glNamedProgramStringEXT")) {
            //    glNamedProgramStringEXT = (delegate* unmanaged<GLuint, GLenum, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glNamedProgramStringEXT");
            //}
            //if (config == null || config.Contains("glNamedRenderbufferStorage")) {
            //    glNamedRenderbufferStorage = (delegate* unmanaged<GLuint, GLenum, GLsizei, GLsizei, void>)GetProcAddress("glNamedRenderbufferStorage");
            //}
            //if (config == null || config.Contains("glNamedRenderbufferStorageEXT")) {
            //    glNamedRenderbufferStorageEXT = (delegate* unmanaged<GLuint, GLenum, GLsizei, GLsizei, void>)GetProcAddress("glNamedRenderbufferStorageEXT");
            //}
            //if (config == null || config.Contains("glNamedRenderbufferStorageMultisample")) {
            //    glNamedRenderbufferStorageMultisample = (delegate* unmanaged<GLuint, GLsizei, GLenum, GLsizei, GLsizei, void>)GetProcAddress("glNamedRenderbufferStorageMultisample");
            //}
            //if (config == null || config.Contains("glNamedRenderbufferStorageMultisampleAdvancedAMD")) {
            //    glNamedRenderbufferStorageMultisampleAdvancedAMD = (delegate* unmanaged<GLuint, GLsizei, GLsizei, GLenum, GLsizei, GLsizei, void>)GetProcAddress("glNamedRenderbufferStorageMultisampleAdvancedAMD");
            //}
            //if (config == null || config.Contains("glNamedRenderbufferStorageMultisampleCoverageEXT")) {
            //    glNamedRenderbufferStorageMultisampleCoverageEXT = (delegate* unmanaged<GLuint, GLsizei, GLsizei, GLenum, GLsizei, GLsizei, void>)GetProcAddress("glNamedRenderbufferStorageMultisampleCoverageEXT");
            //}
            //if (config == null || config.Contains("glNamedRenderbufferStorageMultisampleEXT")) {
            //    glNamedRenderbufferStorageMultisampleEXT = (delegate* unmanaged<GLuint, GLsizei, GLenum, GLsizei, GLsizei, void>)GetProcAddress("glNamedRenderbufferStorageMultisampleEXT");
            //}
            //if (config == null || config.Contains("glNamedStringARB")) {
            //    glNamedStringARB = (delegate* unmanaged<GLenum, GLint, string, GLint, string, void>)GetProcAddress("glNamedStringARB");
            //}
            //if (config == null || config.Contains("glNewList")) {
            //    glNewList = (delegate* unmanaged<GLuint, GLenum, void>)GetProcAddress("glNewList");
            //}
            //if (config == null || config.Contains("glNewObjectBufferATI")) {
            //    glNewObjectBufferATI = (delegate* unmanaged<GLsizei, IntPtr, GLenum, GLuint>)GetProcAddress("glNewObjectBufferATI");
            //}
            //if (config == null || config.Contains("glNormal3b")) {
            //    glNormal3b = (delegate* unmanaged<GLbyte, GLbyte, GLbyte, void>)GetProcAddress("glNormal3b");
            //}
            //if (config == null || config.Contains("glNormal3bv")) {
            //    glNormal3bv = (delegate* unmanaged<GLbyte[], void>)GetProcAddress("glNormal3bv");
            //}
            //if (config == null || config.Contains("glNormal3d")) {
            //    glNormal3d = (delegate* unmanaged<GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glNormal3d");
            //}
            //if (config == null || config.Contains("glNormal3dv")) {
            //    glNormal3dv = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glNormal3dv");
            //}
            //if (config == null || config.Contains("glNormal3f")) {
            //    glNormal3f = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glNormal3f");
            //}
            //if (config == null || config.Contains("glNormal3fVertex3fSUN")) {
            //    glNormal3fVertex3fSUN = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glNormal3fVertex3fSUN");
            //}
            //if (config == null || config.Contains("glNormal3fVertex3fvSUN")) {
            //    glNormal3fVertex3fvSUN = (delegate* unmanaged<GLfloat[], GLfloat[], void>)GetProcAddress("glNormal3fVertex3fvSUN");
            //}
            //if (config == null || config.Contains("glNormal3fv")) {
            //    glNormal3fv = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glNormal3fv");
            //}
            //if (config == null || config.Contains("glNormal3hNV")) {
            //    glNormal3hNV = (delegate* unmanaged<GLhalfNV, GLhalfNV, GLhalfNV, void>)GetProcAddress("glNormal3hNV");
            //}
            //if (config == null || config.Contains("glNormal3hvNV")) {
            //    glNormal3hvNV = (delegate* unmanaged<GLhalfNV[], void>)GetProcAddress("glNormal3hvNV");
            //}
            //if (config == null || config.Contains("glNormal3i")) {
            //    glNormal3i = (delegate* unmanaged<GLint, GLint, GLint, void>)GetProcAddress("glNormal3i");
            //}
            //if (config == null || config.Contains("glNormal3iv")) {
            //    glNormal3iv = (delegate* unmanaged<GLint[], void>)GetProcAddress("glNormal3iv");
            //}
            //if (config == null || config.Contains("glNormal3s")) {
            //    glNormal3s = (delegate* unmanaged<GLshort, GLshort, GLshort, void>)GetProcAddress("glNormal3s");
            //}
            //if (config == null || config.Contains("glNormal3sv")) {
            //    glNormal3sv = (delegate* unmanaged<GLshort[], void>)GetProcAddress("glNormal3sv");
            //}
            //if (config == null || config.Contains("glNormal3x")) {
            //    glNormal3x = (delegate* unmanaged<GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glNormal3x");
            //}
            //if (config == null || config.Contains("glNormal3xOES")) {
            //    glNormal3xOES = (delegate* unmanaged<GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glNormal3xOES");
            //}
            //if (config == null || config.Contains("glNormal3xvOES")) {
            //    glNormal3xvOES = (delegate* unmanaged<GLfixed[], void>)GetProcAddress("glNormal3xvOES");
            //}
            //if (config == null || config.Contains("glNormalFormatNV")) {
            //    glNormalFormatNV = (delegate* unmanaged<GLenum, GLsizei, void>)GetProcAddress("glNormalFormatNV");
            //}
            //if (config == null || config.Contains("glNormalP3ui")) {
            //    glNormalP3ui = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glNormalP3ui");
            //}
            //if (config == null || config.Contains("glNormalP3uiv")) {
            //    glNormalP3uiv = (delegate* unmanaged<GLenum, GLuint[], void>)GetProcAddress("glNormalP3uiv");
            //}
            //if (config == null || config.Contains("glNormalPointer")) {
            //    glNormalPointer = (delegate* unmanaged<GLenum, GLsizei, IntPtr, void>)GetProcAddress("glNormalPointer");
            //}
            //if (config == null || config.Contains("glNormalPointerEXT")) {
            //    glNormalPointerEXT = (delegate* unmanaged<GLenum, GLsizei, GLsizei, IntPtr, void>)GetProcAddress("glNormalPointerEXT");
            //}
            //if (config == null || config.Contains("glNormalPointerListIBM")) {
            //    glNormalPointerListIBM = (delegate* unmanaged<GLenum, GLint, IntPtr, GLint, void>)GetProcAddress("glNormalPointerListIBM");
            //}
            //if (config == null || config.Contains("glNormalPointervINTEL")) {
            //    glNormalPointervINTEL = (delegate* unmanaged<GLenum, IntPtr, void>)GetProcAddress("glNormalPointervINTEL");
            //}
            //if (config == null || config.Contains("glNormalStream3bATI")) {
            //    glNormalStream3bATI = (delegate* unmanaged<GLenum, GLbyte, GLbyte, GLbyte, void>)GetProcAddress("glNormalStream3bATI");
            //}
            //if (config == null || config.Contains("glNormalStream3bvATI")) {
            //    glNormalStream3bvATI = (delegate* unmanaged<GLenum, GLbyte[], void>)GetProcAddress("glNormalStream3bvATI");
            //}
            //if (config == null || config.Contains("glNormalStream3dATI")) {
            //    glNormalStream3dATI = (delegate* unmanaged<GLenum, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glNormalStream3dATI");
            //}
            //if (config == null || config.Contains("glNormalStream3dvATI")) {
            //    glNormalStream3dvATI = (delegate* unmanaged<GLenum, GLdouble[], void>)GetProcAddress("glNormalStream3dvATI");
            //}
            //if (config == null || config.Contains("glNormalStream3fATI")) {
            //    glNormalStream3fATI = (delegate* unmanaged<GLenum, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glNormalStream3fATI");
            //}
            //if (config == null || config.Contains("glNormalStream3fvATI")) {
            //    glNormalStream3fvATI = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glNormalStream3fvATI");
            //}
            //if (config == null || config.Contains("glNormalStream3iATI")) {
            //    glNormalStream3iATI = (delegate* unmanaged<GLenum, GLint, GLint, GLint, void>)GetProcAddress("glNormalStream3iATI");
            //}
            //if (config == null || config.Contains("glNormalStream3ivATI")) {
            //    glNormalStream3ivATI = (delegate* unmanaged<GLenum, GLint[], void>)GetProcAddress("glNormalStream3ivATI");
            //}
            //if (config == null || config.Contains("glNormalStream3sATI")) {
            //    glNormalStream3sATI = (delegate* unmanaged<GLenum, GLshort, GLshort, GLshort, void>)GetProcAddress("glNormalStream3sATI");
            //}
            //if (config == null || config.Contains("glNormalStream3svATI")) {
            //    glNormalStream3svATI = (delegate* unmanaged<GLenum, GLshort[], void>)GetProcAddress("glNormalStream3svATI");
            //}
            //if (config == null || config.Contains("glObjectLabel")) {
            //    glObjectLabel = (delegate* unmanaged<GLenum, GLuint, GLsizei, string, void>)GetProcAddress("glObjectLabel");
            //}
            //if (config == null || config.Contains("glObjectLabelKHR")) {
            //    glObjectLabelKHR = (delegate* unmanaged<GLenum, GLuint, GLsizei, string, void>)GetProcAddress("glObjectLabelKHR");
            //}
            //if (config == null || config.Contains("glObjectPtrLabel")) {
            //    glObjectPtrLabel = (delegate* unmanaged<IntPtr, GLsizei, string, void>)GetProcAddress("glObjectPtrLabel");
            //}
            //if (config == null || config.Contains("glObjectPtrLabelKHR")) {
            //    glObjectPtrLabelKHR = (delegate* unmanaged<IntPtr, GLsizei, string, void>)GetProcAddress("glObjectPtrLabelKHR");
            //}
            //if (config == null || config.Contains("glObjectPurgeableAPPLE")) {
            //    glObjectPurgeableAPPLE = (delegate* unmanaged<GLenum, GLuint, GLenum, GLenum>)GetProcAddress("glObjectPurgeableAPPLE");
            //}
            //if (config == null || config.Contains("glObjectUnpurgeableAPPLE")) {
            //    glObjectUnpurgeableAPPLE = (delegate* unmanaged<GLenum, GLuint, GLenum, GLenum>)GetProcAddress("glObjectUnpurgeableAPPLE");
            //}
            //if (config == null || config.Contains("glOrtho")) {
            //    glOrtho = (delegate* unmanaged<GLdouble, GLdouble, GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glOrtho");
            //}
            //if (config == null || config.Contains("glOrthof")) {
            //    glOrthof = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glOrthof");
            //}
            //if (config == null || config.Contains("glOrthofOES")) {
            //    glOrthofOES = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glOrthofOES");
            //}
            //if (config == null || config.Contains("glOrthox")) {
            //    glOrthox = (delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glOrthox");
            //}
            //if (config == null || config.Contains("glOrthoxOES")) {
            //    glOrthoxOES = (delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glOrthoxOES");
            //}
            //if (config == null || config.Contains("glPNTrianglesfATI")) {
            //    glPNTrianglesfATI = (delegate* unmanaged<GLenum, GLfloat, void>)GetProcAddress("glPNTrianglesfATI");
            //}
            //if (config == null || config.Contains("glPNTrianglesiATI")) {
            //    glPNTrianglesiATI = (delegate* unmanaged<GLenum, GLint, void>)GetProcAddress("glPNTrianglesiATI");
            //}
            //if (config == null || config.Contains("glPassTexCoordATI")) {
            //    glPassTexCoordATI = (delegate* unmanaged<GLuint, GLuint, GLenum, void>)GetProcAddress("glPassTexCoordATI");
            //}
            //if (config == null || config.Contains("glPassThrough")) {
            //    glPassThrough = (delegate* unmanaged<GLfloat, void>)GetProcAddress("glPassThrough");
            //}
            //if (config == null || config.Contains("glPassThroughxOES")) {
            //    glPassThroughxOES = (delegate* unmanaged<GLfixed, void>)GetProcAddress("glPassThroughxOES");
            //}
            //if (config == null || config.Contains("glPatchParameterfv")) {
            //    glPatchParameterfv = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glPatchParameterfv");
            //}
            //if (config == null || config.Contains("glPatchParameteri")) {
            //    glPatchParameteri = (delegate* unmanaged<GLenum, GLint, void>)GetProcAddress("glPatchParameteri");
            //}
            //if (config == null || config.Contains("glPatchParameteriEXT")) {
            //    glPatchParameteriEXT = (delegate* unmanaged<GLenum, GLint, void>)GetProcAddress("glPatchParameteriEXT");
            //}
            //if (config == null || config.Contains("glPatchParameteriOES")) {
            //    glPatchParameteriOES = (delegate* unmanaged<GLenum, GLint, void>)GetProcAddress("glPatchParameteriOES");
            //}
            //if (config == null || config.Contains("glPathColorGenNV")) {
            //    glPathColorGenNV = (delegate* unmanaged<GLenum, GLenum, GLenum, GLfloat[], void>)GetProcAddress("glPathColorGenNV");
            //}
            //if (config == null || config.Contains("glPathCommandsNV")) {
            //    glPathCommandsNV = (delegate* unmanaged<GLuint, GLsizei, GLubyte[], GLsizei, GLenum, IntPtr, void>)GetProcAddress("glPathCommandsNV");
            //}
            //if (config == null || config.Contains("glPathCoordsNV")) {
            //    glPathCoordsNV = (delegate* unmanaged<GLuint, GLsizei, GLenum, IntPtr, void>)GetProcAddress("glPathCoordsNV");
            //}
            //if (config == null || config.Contains("glPathCoverDepthFuncNV")) {
            //    glPathCoverDepthFuncNV = (delegate* unmanaged<GLenum, void>)GetProcAddress("glPathCoverDepthFuncNV");
            //}
            //if (config == null || config.Contains("glPathDashArrayNV")) {
            //    glPathDashArrayNV = (delegate* unmanaged<GLuint, GLsizei, GLfloat[], void>)GetProcAddress("glPathDashArrayNV");
            //}
            //if (config == null || config.Contains("glPathFogGenNV")) {
            //    glPathFogGenNV = (delegate* unmanaged<GLenum, void>)GetProcAddress("glPathFogGenNV");
            //}
            //if (config == null || config.Contains("glPathGlyphIndexArrayNV")) {
            //    glPathGlyphIndexArrayNV = (delegate* unmanaged<GLuint, GLenum, IntPtr, GLbitfield, GLuint, GLsizei, GLuint, GLfloat, GLenum>)GetProcAddress("glPathGlyphIndexArrayNV");
            //}
            //if (config == null || config.Contains("glPathGlyphIndexRangeNV")) {
            //    glPathGlyphIndexRangeNV = (delegate* unmanaged<GLenum, IntPtr, GLbitfield, GLuint, GLfloat, GLuint, GLenum>)GetProcAddress("glPathGlyphIndexRangeNV");
            //}
            //if (config == null || config.Contains("glPathGlyphRangeNV")) {
            //    glPathGlyphRangeNV = (delegate* unmanaged<GLuint, GLenum, IntPtr, GLbitfield, GLuint, GLsizei, GLenum, GLuint, GLfloat, void>)GetProcAddress("glPathGlyphRangeNV");
            //}
            //if (config == null || config.Contains("glPathGlyphsNV")) {
            //    glPathGlyphsNV = (delegate* unmanaged<GLuint, GLenum, IntPtr, GLbitfield, GLsizei, GLenum, IntPtr, GLenum, GLuint, GLfloat, void>)GetProcAddress("glPathGlyphsNV");
            //}
            //if (config == null || config.Contains("glPathMemoryGlyphIndexArrayNV")) {
            //    glPathMemoryGlyphIndexArrayNV = (delegate* unmanaged<GLuint, GLenum, GLsizeiptr, IntPtr, GLsizei, GLuint, GLsizei, GLuint, GLfloat, GLenum>)GetProcAddress("glPathMemoryGlyphIndexArrayNV");
            //}
            //if (config == null || config.Contains("glPathParameterfNV")) {
            //    glPathParameterfNV = (delegate* unmanaged<GLuint, GLenum, GLfloat, void>)GetProcAddress("glPathParameterfNV");
            //}
            //if (config == null || config.Contains("glPathParameterfvNV")) {
            //    glPathParameterfvNV = (delegate* unmanaged<GLuint, GLenum, GLfloat[], void>)GetProcAddress("glPathParameterfvNV");
            //}
            //if (config == null || config.Contains("glPathParameteriNV")) {
            //    glPathParameteriNV = (delegate* unmanaged<GLuint, GLenum, GLint, void>)GetProcAddress("glPathParameteriNV");
            //}
            //if (config == null || config.Contains("glPathParameterivNV")) {
            //    glPathParameterivNV = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glPathParameterivNV");
            //}
            //if (config == null || config.Contains("glPathStencilDepthOffsetNV")) {
            //    glPathStencilDepthOffsetNV = (delegate* unmanaged<GLfloat, GLfloat, void>)GetProcAddress("glPathStencilDepthOffsetNV");
            //}
            //if (config == null || config.Contains("glPathStencilFuncNV")) {
            //    glPathStencilFuncNV = (delegate* unmanaged<GLenum, GLint, GLuint, void>)GetProcAddress("glPathStencilFuncNV");
            //}
            //if (config == null || config.Contains("glPathStringNV")) {
            //    glPathStringNV = (delegate* unmanaged<GLuint, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glPathStringNV");
            //}
            //if (config == null || config.Contains("glPathSubCommandsNV")) {
            //    glPathSubCommandsNV = (delegate* unmanaged<GLuint, GLsizei, GLsizei, GLsizei, GLubyte[], GLsizei, GLenum, IntPtr, void>)GetProcAddress("glPathSubCommandsNV");
            //}
            //if (config == null || config.Contains("glPathSubCoordsNV")) {
            //    glPathSubCoordsNV = (delegate* unmanaged<GLuint, GLsizei, GLsizei, GLenum, IntPtr, void>)GetProcAddress("glPathSubCoordsNV");
            //}
            //if (config == null || config.Contains("glPathTexGenNV")) {
            //    glPathTexGenNV = (delegate* unmanaged<GLenum, GLenum, GLint, GLfloat[], void>)GetProcAddress("glPathTexGenNV");
            //}
            //if (config == null || config.Contains("glPauseTransformFeedback")) {
            //    glPauseTransformFeedback = (delegate* unmanaged<void>)GetProcAddress("glPauseTransformFeedback");
            //}
            //if (config == null || config.Contains("glPauseTransformFeedbackNV")) {
            //    glPauseTransformFeedbackNV = (delegate* unmanaged<void>)GetProcAddress("glPauseTransformFeedbackNV");
            //}
            //if (config == null || config.Contains("glPixelDataRangeNV")) {
            //    glPixelDataRangeNV = (delegate* unmanaged<GLenum, GLsizei, IntPtr, void>)GetProcAddress("glPixelDataRangeNV");
            //}
            //if (config == null || config.Contains("glPixelMapfv")) {
            //    glPixelMapfv = (delegate* unmanaged<GLenum, GLsizei, GLfloat[], void>)GetProcAddress("glPixelMapfv");
            //}
            //if (config == null || config.Contains("glPixelMapuiv")) {
            //    glPixelMapuiv = (delegate* unmanaged<GLenum, GLsizei, GLuint[], void>)GetProcAddress("glPixelMapuiv");
            //}
            //if (config == null || config.Contains("glPixelMapusv")) {
            //    glPixelMapusv = (delegate* unmanaged<GLenum, GLsizei, GLushort[], void>)GetProcAddress("glPixelMapusv");
            //}
            //if (config == null || config.Contains("glPixelMapx")) {
            //    glPixelMapx = (delegate* unmanaged<GLenum, GLint, GLfixed[], void>)GetProcAddress("glPixelMapx");
            //}
            //if (config == null || config.Contains("glPixelStoref")) {
            //    glPixelStoref = (delegate* unmanaged<GLenum, GLfloat, void>)GetProcAddress("glPixelStoref");
            //}
            //if (config == null || config.Contains("glPixelStorei")) {
            //    glPixelStorei = (delegate* unmanaged<GLenum, GLint, void>)GetProcAddress("glPixelStorei");
            //}
            //if (config == null || config.Contains("glPixelStorex")) {
            //    glPixelStorex = (delegate* unmanaged<GLenum, GLfixed, void>)GetProcAddress("glPixelStorex");
            //}
            //if (config == null || config.Contains("glPixelTexGenParameterfSGIS")) {
            //    glPixelTexGenParameterfSGIS = (delegate* unmanaged<GLenum, GLfloat, void>)GetProcAddress("glPixelTexGenParameterfSGIS");
            //}
            //if (config == null || config.Contains("glPixelTexGenParameterfvSGIS")) {
            //    glPixelTexGenParameterfvSGIS = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glPixelTexGenParameterfvSGIS");
            //}
            //if (config == null || config.Contains("glPixelTexGenParameteriSGIS")) {
            //    glPixelTexGenParameteriSGIS = (delegate* unmanaged<GLenum, GLint, void>)GetProcAddress("glPixelTexGenParameteriSGIS");
            //}
            //if (config == null || config.Contains("glPixelTexGenParameterivSGIS")) {
            //    glPixelTexGenParameterivSGIS = (delegate* unmanaged<GLenum, GLint[], void>)GetProcAddress("glPixelTexGenParameterivSGIS");
            //}
            //if (config == null || config.Contains("glPixelTexGenSGIX")) {
            //    glPixelTexGenSGIX = (delegate* unmanaged<GLenum, void>)GetProcAddress("glPixelTexGenSGIX");
            //}
            //if (config == null || config.Contains("glPixelTransferf")) {
            //    glPixelTransferf = (delegate* unmanaged<GLenum, GLfloat, void>)GetProcAddress("glPixelTransferf");
            //}
            //if (config == null || config.Contains("glPixelTransferi")) {
            //    glPixelTransferi = (delegate* unmanaged<GLenum, GLint, void>)GetProcAddress("glPixelTransferi");
            //}
            //if (config == null || config.Contains("glPixelTransferxOES")) {
            //    glPixelTransferxOES = (delegate* unmanaged<GLenum, GLfixed, void>)GetProcAddress("glPixelTransferxOES");
            //}
            //if (config == null || config.Contains("glPixelTransformParameterfEXT")) {
            //    glPixelTransformParameterfEXT = (delegate* unmanaged<GLenum, GLenum, GLfloat, void>)GetProcAddress("glPixelTransformParameterfEXT");
            //}
            //if (config == null || config.Contains("glPixelTransformParameterfvEXT")) {
            //    glPixelTransformParameterfvEXT = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glPixelTransformParameterfvEXT");
            //}
            //if (config == null || config.Contains("glPixelTransformParameteriEXT")) {
            //    glPixelTransformParameteriEXT = (delegate* unmanaged<GLenum, GLenum, GLint, void>)GetProcAddress("glPixelTransformParameteriEXT");
            //}
            //if (config == null || config.Contains("glPixelTransformParameterivEXT")) {
            //    glPixelTransformParameterivEXT = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glPixelTransformParameterivEXT");
            //}
            //if (config == null || config.Contains("glPixelZoom")) {
            //    glPixelZoom = (delegate* unmanaged<GLfloat, GLfloat, void>)GetProcAddress("glPixelZoom");
            //}
            //if (config == null || config.Contains("glPixelZoomxOES")) {
            //    glPixelZoomxOES = (delegate* unmanaged<GLfixed, GLfixed, void>)GetProcAddress("glPixelZoomxOES");
            //}
            //if (config == null || config.Contains("glPointAlongPathNV")) {
            //    glPointAlongPathNV = (delegate* unmanaged<GLuint, GLsizei, GLsizei, GLfloat, GLfloat[], GLfloat[], GLfloat[], GLfloat[], GLboolean>)GetProcAddress("glPointAlongPathNV");
            //}
            //if (config == null || config.Contains("glPointParameterf")) {
            //    glPointParameterf = (delegate* unmanaged<GLenum, GLfloat, void>)GetProcAddress("glPointParameterf");
            //}
            //if (config == null || config.Contains("glPointParameterfARB")) {
            //    glPointParameterfARB = (delegate* unmanaged<GLenum, GLfloat, void>)GetProcAddress("glPointParameterfARB");
            //}
            //if (config == null || config.Contains("glPointParameterfEXT")) {
            //    glPointParameterfEXT = (delegate* unmanaged<GLenum, GLfloat, void>)GetProcAddress("glPointParameterfEXT");
            //}
            //if (config == null || config.Contains("glPointParameterfSGIS")) {
            //    glPointParameterfSGIS = (delegate* unmanaged<GLenum, GLfloat, void>)GetProcAddress("glPointParameterfSGIS");
            //}
            //if (config == null || config.Contains("glPointParameterfv")) {
            //    glPointParameterfv = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glPointParameterfv");
            //}
            //if (config == null || config.Contains("glPointParameterfvARB")) {
            //    glPointParameterfvARB = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glPointParameterfvARB");
            //}
            //if (config == null || config.Contains("glPointParameterfvEXT")) {
            //    glPointParameterfvEXT = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glPointParameterfvEXT");
            //}
            //if (config == null || config.Contains("glPointParameterfvSGIS")) {
            //    glPointParameterfvSGIS = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glPointParameterfvSGIS");
            //}
            //if (config == null || config.Contains("glPointParameteri")) {
            //    glPointParameteri = (delegate* unmanaged<GLenum, GLint, void>)GetProcAddress("glPointParameteri");
            //}
            //if (config == null || config.Contains("glPointParameteriNV")) {
            //    glPointParameteriNV = (delegate* unmanaged<GLenum, GLint, void>)GetProcAddress("glPointParameteriNV");
            //}
            //if (config == null || config.Contains("glPointParameteriv")) {
            //    glPointParameteriv = (delegate* unmanaged<GLenum, GLint[], void>)GetProcAddress("glPointParameteriv");
            //}
            //if (config == null || config.Contains("glPointParameterivNV")) {
            //    glPointParameterivNV = (delegate* unmanaged<GLenum, GLint[], void>)GetProcAddress("glPointParameterivNV");
            //}
            //if (config == null || config.Contains("glPointParameterx")) {
            //    glPointParameterx = (delegate* unmanaged<GLenum, GLfixed, void>)GetProcAddress("glPointParameterx");
            //}
            //if (config == null || config.Contains("glPointParameterxOES")) {
            //    glPointParameterxOES = (delegate* unmanaged<GLenum, GLfixed, void>)GetProcAddress("glPointParameterxOES");
            //}
            //if (config == null || config.Contains("glPointParameterxv")) {
            //    glPointParameterxv = (delegate* unmanaged<GLenum, GLfixed[], void>)GetProcAddress("glPointParameterxv");
            //}
            //if (config == null || config.Contains("glPointParameterxvOES")) {
            //    glPointParameterxvOES = (delegate* unmanaged<GLenum, GLfixed[], void>)GetProcAddress("glPointParameterxvOES");
            //}
            //if (config == null || config.Contains("glPointSize")) {
            //    glPointSize = (delegate* unmanaged<GLfloat, void>)GetProcAddress("glPointSize");
            //}
            //if (config == null || config.Contains("glPointSizePointerOES")) {
            //    glPointSizePointerOES = (delegate* unmanaged<GLenum, GLsizei, IntPtr, void>)GetProcAddress("glPointSizePointerOES");
            //}
            //if (config == null || config.Contains("glPointSizex")) {
            //    glPointSizex = (delegate* unmanaged<GLfixed, void>)GetProcAddress("glPointSizex");
            //}
            //if (config == null || config.Contains("glPointSizexOES")) {
            //    glPointSizexOES = (delegate* unmanaged<GLfixed, void>)GetProcAddress("glPointSizexOES");
            //}
            //if (config == null || config.Contains("glPollAsyncSGIX")) {
            //    glPollAsyncSGIX = (delegate* unmanaged<GLuint[], GLint>)GetProcAddress("glPollAsyncSGIX");
            //}
            //if (config == null || config.Contains("glPollInstrumentsSGIX")) {
            //    glPollInstrumentsSGIX = (delegate* unmanaged<GLint[], GLint>)GetProcAddress("glPollInstrumentsSGIX");
            //}
            //if (config == null || config.Contains("glPolygonMode")) {
            //    glPolygonMode = (delegate* unmanaged<GLenum, GLenum, void>)GetProcAddress("glPolygonMode");
            //}
            //if (config == null || config.Contains("glPolygonModeNV")) {
            //    glPolygonModeNV = (delegate* unmanaged<GLenum, GLenum, void>)GetProcAddress("glPolygonModeNV");
            //}
            //if (config == null || config.Contains("glPolygonOffset")) {
            //    glPolygonOffset = (delegate* unmanaged<GLfloat, GLfloat, void>)GetProcAddress("glPolygonOffset");
            //}
            //if (config == null || config.Contains("glPolygonOffsetClamp")) {
            //    glPolygonOffsetClamp = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glPolygonOffsetClamp");
            //}
            //if (config == null || config.Contains("glPolygonOffsetClampEXT")) {
            //    glPolygonOffsetClampEXT = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glPolygonOffsetClampEXT");
            //}
            //if (config == null || config.Contains("glPolygonOffsetEXT")) {
            //    glPolygonOffsetEXT = (delegate* unmanaged<GLfloat, GLfloat, void>)GetProcAddress("glPolygonOffsetEXT");
            //}
            //if (config == null || config.Contains("glPolygonOffsetx")) {
            //    glPolygonOffsetx = (delegate* unmanaged<GLfixed, GLfixed, void>)GetProcAddress("glPolygonOffsetx");
            //}
            //if (config == null || config.Contains("glPolygonOffsetxOES")) {
            //    glPolygonOffsetxOES = (delegate* unmanaged<GLfixed, GLfixed, void>)GetProcAddress("glPolygonOffsetxOES");
            //}
            //if (config == null || config.Contains("glPolygonStipple")) {
            //    glPolygonStipple = (delegate* unmanaged<GLubyte[], void>)GetProcAddress("glPolygonStipple");
            //}
            //if (config == null || config.Contains("glPopAttrib")) {
            //    glPopAttrib = (delegate* unmanaged<void>)GetProcAddress("glPopAttrib");
            //}
            //if (config == null || config.Contains("glPopClientAttrib")) {
            //    glPopClientAttrib = (delegate* unmanaged<void>)GetProcAddress("glPopClientAttrib");
            //}
            //if (config == null || config.Contains("glPopDebugGroup")) {
            //    glPopDebugGroup = (delegate* unmanaged<void>)GetProcAddress("glPopDebugGroup");
            //}
            //if (config == null || config.Contains("glPopDebugGroupKHR")) {
            //    glPopDebugGroupKHR = (delegate* unmanaged<void>)GetProcAddress("glPopDebugGroupKHR");
            //}
            //if (config == null || config.Contains("glPopGroupMarkerEXT")) {
            //    glPopGroupMarkerEXT = (delegate* unmanaged<void>)GetProcAddress("glPopGroupMarkerEXT");
            //}
            //if (config == null || config.Contains("glPopMatrix")) {
            //    glPopMatrix = (delegate* unmanaged<void>)GetProcAddress("glPopMatrix");
            //}
            //if (config == null || config.Contains("glPopName")) {
            //    glPopName = (delegate* unmanaged<void>)GetProcAddress("glPopName");
            //}
            //if (config == null || config.Contains("glPresentFrameDualFillNV")) {
            //    glPresentFrameDualFillNV = (delegate* unmanaged<GLuint, GLuint64EXT, GLuint, GLuint, GLenum, GLenum, GLuint, GLenum, GLuint, GLenum, GLuint, GLenum, GLuint, void>)GetProcAddress("glPresentFrameDualFillNV");
            //}
            //if (config == null || config.Contains("glPresentFrameKeyedNV")) {
            //    glPresentFrameKeyedNV = (delegate* unmanaged<GLuint, GLuint64EXT, GLuint, GLuint, GLenum, GLenum, GLuint, GLuint, GLenum, GLuint, GLuint, void>)GetProcAddress("glPresentFrameKeyedNV");
            //}
            //if (config == null || config.Contains("glPrimitiveBoundingBox")) {
            //    glPrimitiveBoundingBox = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glPrimitiveBoundingBox");
            //}
            //if (config == null || config.Contains("glPrimitiveBoundingBoxARB")) {
            //    glPrimitiveBoundingBoxARB = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glPrimitiveBoundingBoxARB");
            //}
            //if (config == null || config.Contains("glPrimitiveBoundingBoxEXT")) {
            //    glPrimitiveBoundingBoxEXT = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glPrimitiveBoundingBoxEXT");
            //}
            //if (config == null || config.Contains("glPrimitiveBoundingBoxOES")) {
            //    glPrimitiveBoundingBoxOES = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glPrimitiveBoundingBoxOES");
            //}
            //if (config == null || config.Contains("glPrimitiveRestartIndex")) {
            //    glPrimitiveRestartIndex = (delegate* unmanaged<GLuint, void>)GetProcAddress("glPrimitiveRestartIndex");
            //}
            //if (config == null || config.Contains("glPrimitiveRestartIndexNV")) {
            //    glPrimitiveRestartIndexNV = (delegate* unmanaged<GLuint, void>)GetProcAddress("glPrimitiveRestartIndexNV");
            //}
            //if (config == null || config.Contains("glPrimitiveRestartNV")) {
            //    glPrimitiveRestartNV = (delegate* unmanaged<void>)GetProcAddress("glPrimitiveRestartNV");
            //}
            //if (config == null || config.Contains("glPrioritizeTextures")) {
            //    glPrioritizeTextures = (delegate* unmanaged<GLsizei, GLuint[], GLfloat[], void>)GetProcAddress("glPrioritizeTextures");
            //}
            //if (config == null || config.Contains("glPrioritizeTexturesEXT")) {
            //    glPrioritizeTexturesEXT = (delegate* unmanaged<GLsizei, GLuint[], GLclampf[], void>)GetProcAddress("glPrioritizeTexturesEXT");
            //}
            //if (config == null || config.Contains("glPrioritizeTexturesxOES")) {
            //    glPrioritizeTexturesxOES = (delegate* unmanaged<GLsizei, GLuint[], GLfixed[], void>)GetProcAddress("glPrioritizeTexturesxOES");
            //}
            //if (config == null || config.Contains("glProgramBinary")) {
            //    glProgramBinary = (delegate* unmanaged<GLuint, GLenum, IntPtr, GLsizei, void>)GetProcAddress("glProgramBinary");
            //}
            //if (config == null || config.Contains("glProgramBinaryOES")) {
            //    glProgramBinaryOES = (delegate* unmanaged<GLuint, GLenum, IntPtr, GLint, void>)GetProcAddress("glProgramBinaryOES");
            //}
            //if (config == null || config.Contains("glProgramBufferParametersIivNV")) {
            //    glProgramBufferParametersIivNV = (delegate* unmanaged<GLenum, GLuint, GLuint, GLsizei, GLint[], void>)GetProcAddress("glProgramBufferParametersIivNV");
            //}
            //if (config == null || config.Contains("glProgramBufferParametersIuivNV")) {
            //    glProgramBufferParametersIuivNV = (delegate* unmanaged<GLenum, GLuint, GLuint, GLsizei, GLuint[], void>)GetProcAddress("glProgramBufferParametersIuivNV");
            //}
            //if (config == null || config.Contains("glProgramBufferParametersfvNV")) {
            //    glProgramBufferParametersfvNV = (delegate* unmanaged<GLenum, GLuint, GLuint, GLsizei, GLfloat[], void>)GetProcAddress("glProgramBufferParametersfvNV");
            //}
            //if (config == null || config.Contains("glProgramEnvParameter4dARB")) {
            //    glProgramEnvParameter4dARB = (delegate* unmanaged<GLenum, GLuint, GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glProgramEnvParameter4dARB");
            //}
            //if (config == null || config.Contains("glProgramEnvParameter4dvARB")) {
            //    glProgramEnvParameter4dvARB = (delegate* unmanaged<GLenum, GLuint, GLdouble[], void>)GetProcAddress("glProgramEnvParameter4dvARB");
            //}
            //if (config == null || config.Contains("glProgramEnvParameter4fARB")) {
            //    glProgramEnvParameter4fARB = (delegate* unmanaged<GLenum, GLuint, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glProgramEnvParameter4fARB");
            //}
            //if (config == null || config.Contains("glProgramEnvParameter4fvARB")) {
            //    glProgramEnvParameter4fvARB = (delegate* unmanaged<GLenum, GLuint, GLfloat[], void>)GetProcAddress("glProgramEnvParameter4fvARB");
            //}
            //if (config == null || config.Contains("glProgramEnvParameterI4iNV")) {
            //    glProgramEnvParameterI4iNV = (delegate* unmanaged<GLenum, GLuint, GLint, GLint, GLint, GLint, void>)GetProcAddress("glProgramEnvParameterI4iNV");
            //}
            //if (config == null || config.Contains("glProgramEnvParameterI4ivNV")) {
            //    glProgramEnvParameterI4ivNV = (delegate* unmanaged<GLenum, GLuint, GLint[], void>)GetProcAddress("glProgramEnvParameterI4ivNV");
            //}
            //if (config == null || config.Contains("glProgramEnvParameterI4uiNV")) {
            //    glProgramEnvParameterI4uiNV = (delegate* unmanaged<GLenum, GLuint, GLuint, GLuint, GLuint, GLuint, void>)GetProcAddress("glProgramEnvParameterI4uiNV");
            //}
            //if (config == null || config.Contains("glProgramEnvParameterI4uivNV")) {
            //    glProgramEnvParameterI4uivNV = (delegate* unmanaged<GLenum, GLuint, GLuint[], void>)GetProcAddress("glProgramEnvParameterI4uivNV");
            //}
            //if (config == null || config.Contains("glProgramEnvParameters4fvEXT")) {
            //    glProgramEnvParameters4fvEXT = (delegate* unmanaged<GLenum, GLuint, GLsizei, GLfloat[], void>)GetProcAddress("glProgramEnvParameters4fvEXT");
            //}
            //if (config == null || config.Contains("glProgramEnvParametersI4ivNV")) {
            //    glProgramEnvParametersI4ivNV = (delegate* unmanaged<GLenum, GLuint, GLsizei, GLint[], void>)GetProcAddress("glProgramEnvParametersI4ivNV");
            //}
            //if (config == null || config.Contains("glProgramEnvParametersI4uivNV")) {
            //    glProgramEnvParametersI4uivNV = (delegate* unmanaged<GLenum, GLuint, GLsizei, GLuint[], void>)GetProcAddress("glProgramEnvParametersI4uivNV");
            //}
            //if (config == null || config.Contains("glProgramLocalParameter4dARB")) {
            //    glProgramLocalParameter4dARB = (delegate* unmanaged<GLenum, GLuint, GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glProgramLocalParameter4dARB");
            //}
            //if (config == null || config.Contains("glProgramLocalParameter4dvARB")) {
            //    glProgramLocalParameter4dvARB = (delegate* unmanaged<GLenum, GLuint, GLdouble[], void>)GetProcAddress("glProgramLocalParameter4dvARB");
            //}
            //if (config == null || config.Contains("glProgramLocalParameter4fARB")) {
            //    glProgramLocalParameter4fARB = (delegate* unmanaged<GLenum, GLuint, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glProgramLocalParameter4fARB");
            //}
            //if (config == null || config.Contains("glProgramLocalParameter4fvARB")) {
            //    glProgramLocalParameter4fvARB = (delegate* unmanaged<GLenum, GLuint, GLfloat[], void>)GetProcAddress("glProgramLocalParameter4fvARB");
            //}
            //if (config == null || config.Contains("glProgramLocalParameterI4iNV")) {
            //    glProgramLocalParameterI4iNV = (delegate* unmanaged<GLenum, GLuint, GLint, GLint, GLint, GLint, void>)GetProcAddress("glProgramLocalParameterI4iNV");
            //}
            //if (config == null || config.Contains("glProgramLocalParameterI4ivNV")) {
            //    glProgramLocalParameterI4ivNV = (delegate* unmanaged<GLenum, GLuint, GLint[], void>)GetProcAddress("glProgramLocalParameterI4ivNV");
            //}
            //if (config == null || config.Contains("glProgramLocalParameterI4uiNV")) {
            //    glProgramLocalParameterI4uiNV = (delegate* unmanaged<GLenum, GLuint, GLuint, GLuint, GLuint, GLuint, void>)GetProcAddress("glProgramLocalParameterI4uiNV");
            //}
            //if (config == null || config.Contains("glProgramLocalParameterI4uivNV")) {
            //    glProgramLocalParameterI4uivNV = (delegate* unmanaged<GLenum, GLuint, GLuint[], void>)GetProcAddress("glProgramLocalParameterI4uivNV");
            //}
            //if (config == null || config.Contains("glProgramLocalParameters4fvEXT")) {
            //    glProgramLocalParameters4fvEXT = (delegate* unmanaged<GLenum, GLuint, GLsizei, GLfloat[], void>)GetProcAddress("glProgramLocalParameters4fvEXT");
            //}
            //if (config == null || config.Contains("glProgramLocalParametersI4ivNV")) {
            //    glProgramLocalParametersI4ivNV = (delegate* unmanaged<GLenum, GLuint, GLsizei, GLint[], void>)GetProcAddress("glProgramLocalParametersI4ivNV");
            //}
            //if (config == null || config.Contains("glProgramLocalParametersI4uivNV")) {
            //    glProgramLocalParametersI4uivNV = (delegate* unmanaged<GLenum, GLuint, GLsizei, GLuint[], void>)GetProcAddress("glProgramLocalParametersI4uivNV");
            //}
            //if (config == null || config.Contains("glProgramNamedParameter4dNV")) {
            //    glProgramNamedParameter4dNV = (delegate* unmanaged<GLuint, GLsizei, GLubyte[], GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glProgramNamedParameter4dNV");
            //}
            //if (config == null || config.Contains("glProgramNamedParameter4dvNV")) {
            //    glProgramNamedParameter4dvNV = (delegate* unmanaged<GLuint, GLsizei, GLubyte[], GLdouble[], void>)GetProcAddress("glProgramNamedParameter4dvNV");
            //}
            //if (config == null || config.Contains("glProgramNamedParameter4fNV")) {
            //    glProgramNamedParameter4fNV = (delegate* unmanaged<GLuint, GLsizei, GLubyte[], GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glProgramNamedParameter4fNV");
            //}
            //if (config == null || config.Contains("glProgramNamedParameter4fvNV")) {
            //    glProgramNamedParameter4fvNV = (delegate* unmanaged<GLuint, GLsizei, GLubyte[], GLfloat[], void>)GetProcAddress("glProgramNamedParameter4fvNV");
            //}
            //if (config == null || config.Contains("glProgramParameter4dNV")) {
            //    glProgramParameter4dNV = (delegate* unmanaged<GLenum, GLuint, GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glProgramParameter4dNV");
            //}
            //if (config == null || config.Contains("glProgramParameter4dvNV")) {
            //    glProgramParameter4dvNV = (delegate* unmanaged<GLenum, GLuint, GLdouble[], void>)GetProcAddress("glProgramParameter4dvNV");
            //}
            //if (config == null || config.Contains("glProgramParameter4fNV")) {
            //    glProgramParameter4fNV = (delegate* unmanaged<GLenum, GLuint, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glProgramParameter4fNV");
            //}
            //if (config == null || config.Contains("glProgramParameter4fvNV")) {
            //    glProgramParameter4fvNV = (delegate* unmanaged<GLenum, GLuint, GLfloat[], void>)GetProcAddress("glProgramParameter4fvNV");
            //}
            //if (config == null || config.Contains("glProgramParameteri")) {
            //    glProgramParameteri = (delegate* unmanaged<GLuint, GLenum, GLint, void>)GetProcAddress("glProgramParameteri");
            //}
            //if (config == null || config.Contains("glProgramParameteriARB")) {
            //    glProgramParameteriARB = (delegate* unmanaged<GLuint, GLenum, GLint, void>)GetProcAddress("glProgramParameteriARB");
            //}
            //if (config == null || config.Contains("glProgramParameteriEXT")) {
            //    glProgramParameteriEXT = (delegate* unmanaged<GLuint, GLenum, GLint, void>)GetProcAddress("glProgramParameteriEXT");
            //}
            //if (config == null || config.Contains("glProgramParameters4dvNV")) {
            //    glProgramParameters4dvNV = (delegate* unmanaged<GLenum, GLuint, GLsizei, GLdouble[], void>)GetProcAddress("glProgramParameters4dvNV");
            //}
            //if (config == null || config.Contains("glProgramParameters4fvNV")) {
            //    glProgramParameters4fvNV = (delegate* unmanaged<GLenum, GLuint, GLsizei, GLfloat[], void>)GetProcAddress("glProgramParameters4fvNV");
            //}
            //if (config == null || config.Contains("glProgramPathFragmentInputGenNV")) {
            //    glProgramPathFragmentInputGenNV = (delegate* unmanaged<GLuint, GLint, GLenum, GLint, GLfloat[], void>)GetProcAddress("glProgramPathFragmentInputGenNV");
            //}
            //if (config == null || config.Contains("glProgramStringARB")) {
            //    glProgramStringARB = (delegate* unmanaged<GLenum, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glProgramStringARB");
            //}
            //if (config == null || config.Contains("glProgramSubroutineParametersuivNV")) {
            //    glProgramSubroutineParametersuivNV = (delegate* unmanaged<GLenum, GLsizei, GLuint[], void>)GetProcAddress("glProgramSubroutineParametersuivNV");
            //}
            //if (config == null || config.Contains("glProgramUniform1d")) {
            //    glProgramUniform1d = (delegate* unmanaged<GLuint, GLint, GLdouble, void>)GetProcAddress("glProgramUniform1d");
            //}
            //if (config == null || config.Contains("glProgramUniform1dEXT")) {
            //    glProgramUniform1dEXT = (delegate* unmanaged<GLuint, GLint, GLdouble, void>)GetProcAddress("glProgramUniform1dEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform1dv")) {
            //    glProgramUniform1dv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLdouble[], void>)GetProcAddress("glProgramUniform1dv");
            //}
            //if (config == null || config.Contains("glProgramUniform1dvEXT")) {
            //    glProgramUniform1dvEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLdouble[], void>)GetProcAddress("glProgramUniform1dvEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform1f")) {
            //    glProgramUniform1f = (delegate* unmanaged<GLuint, GLint, GLfloat, void>)GetProcAddress("glProgramUniform1f");
            //}
            //if (config == null || config.Contains("glProgramUniform1fEXT")) {
            //    glProgramUniform1fEXT = (delegate* unmanaged<GLuint, GLint, GLfloat, void>)GetProcAddress("glProgramUniform1fEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform1fv")) {
            //    glProgramUniform1fv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLfloat[], void>)GetProcAddress("glProgramUniform1fv");
            //}
            //if (config == null || config.Contains("glProgramUniform1fvEXT")) {
            //    glProgramUniform1fvEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLfloat[], void>)GetProcAddress("glProgramUniform1fvEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform1i")) {
            //    glProgramUniform1i = (delegate* unmanaged<GLuint, GLint, GLint, void>)GetProcAddress("glProgramUniform1i");
            //}
            //if (config == null || config.Contains("glProgramUniform1i64ARB")) {
            //    glProgramUniform1i64ARB = (delegate* unmanaged<GLuint, GLint, GLint64, void>)GetProcAddress("glProgramUniform1i64ARB");
            //}
            //if (config == null || config.Contains("glProgramUniform1i64NV")) {
            //    glProgramUniform1i64NV = (delegate* unmanaged<GLuint, GLint, GLint64EXT, void>)GetProcAddress("glProgramUniform1i64NV");
            //}
            //if (config == null || config.Contains("glProgramUniform1i64vARB")) {
            //    glProgramUniform1i64vARB = (delegate* unmanaged<GLuint, GLint, GLsizei, GLint64[], void>)GetProcAddress("glProgramUniform1i64vARB");
            //}
            //if (config == null || config.Contains("glProgramUniform1i64vNV")) {
            //    glProgramUniform1i64vNV = (delegate* unmanaged<GLuint, GLint, GLsizei, GLint64EXT[], void>)GetProcAddress("glProgramUniform1i64vNV");
            //}
            //if (config == null || config.Contains("glProgramUniform1iEXT")) {
            //    glProgramUniform1iEXT = (delegate* unmanaged<GLuint, GLint, GLint, void>)GetProcAddress("glProgramUniform1iEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform1iv")) {
            //    glProgramUniform1iv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLint[], void>)GetProcAddress("glProgramUniform1iv");
            //}
            //if (config == null || config.Contains("glProgramUniform1ivEXT")) {
            //    glProgramUniform1ivEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLint[], void>)GetProcAddress("glProgramUniform1ivEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform1ui")) {
            //    glProgramUniform1ui = (delegate* unmanaged<GLuint, GLint, GLuint, void>)GetProcAddress("glProgramUniform1ui");
            //}
            //if (config == null || config.Contains("glProgramUniform1ui64ARB")) {
            //    glProgramUniform1ui64ARB = (delegate* unmanaged<GLuint, GLint, GLuint64, void>)GetProcAddress("glProgramUniform1ui64ARB");
            //}
            //if (config == null || config.Contains("glProgramUniform1ui64NV")) {
            //    glProgramUniform1ui64NV = (delegate* unmanaged<GLuint, GLint, GLuint64EXT, void>)GetProcAddress("glProgramUniform1ui64NV");
            //}
            //if (config == null || config.Contains("glProgramUniform1ui64vARB")) {
            //    glProgramUniform1ui64vARB = (delegate* unmanaged<GLuint, GLint, GLsizei, GLuint64[], void>)GetProcAddress("glProgramUniform1ui64vARB");
            //}
            //if (config == null || config.Contains("glProgramUniform1ui64vNV")) {
            //    glProgramUniform1ui64vNV = (delegate* unmanaged<GLuint, GLint, GLsizei, GLuint64EXT[], void>)GetProcAddress("glProgramUniform1ui64vNV");
            //}
            //if (config == null || config.Contains("glProgramUniform1uiEXT")) {
            //    glProgramUniform1uiEXT = (delegate* unmanaged<GLuint, GLint, GLuint, void>)GetProcAddress("glProgramUniform1uiEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform1uiv")) {
            //    glProgramUniform1uiv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLuint[], void>)GetProcAddress("glProgramUniform1uiv");
            //}
            //if (config == null || config.Contains("glProgramUniform1uivEXT")) {
            //    glProgramUniform1uivEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLuint[], void>)GetProcAddress("glProgramUniform1uivEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform2d")) {
            //    glProgramUniform2d = (delegate* unmanaged<GLuint, GLint, GLdouble, GLdouble, void>)GetProcAddress("glProgramUniform2d");
            //}
            //if (config == null || config.Contains("glProgramUniform2dEXT")) {
            //    glProgramUniform2dEXT = (delegate* unmanaged<GLuint, GLint, GLdouble, GLdouble, void>)GetProcAddress("glProgramUniform2dEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform2dv")) {
            //    glProgramUniform2dv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLdouble[], void>)GetProcAddress("glProgramUniform2dv");
            //}
            //if (config == null || config.Contains("glProgramUniform2dvEXT")) {
            //    glProgramUniform2dvEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLdouble[], void>)GetProcAddress("glProgramUniform2dvEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform2f")) {
            //    glProgramUniform2f = (delegate* unmanaged<GLuint, GLint, GLfloat, GLfloat, void>)GetProcAddress("glProgramUniform2f");
            //}
            //if (config == null || config.Contains("glProgramUniform2fEXT")) {
            //    glProgramUniform2fEXT = (delegate* unmanaged<GLuint, GLint, GLfloat, GLfloat, void>)GetProcAddress("glProgramUniform2fEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform2fv")) {
            //    glProgramUniform2fv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLfloat[], void>)GetProcAddress("glProgramUniform2fv");
            //}
            //if (config == null || config.Contains("glProgramUniform2fvEXT")) {
            //    glProgramUniform2fvEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLfloat[], void>)GetProcAddress("glProgramUniform2fvEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform2i")) {
            //    glProgramUniform2i = (delegate* unmanaged<GLuint, GLint, GLint, GLint, void>)GetProcAddress("glProgramUniform2i");
            //}
            //if (config == null || config.Contains("glProgramUniform2i64ARB")) {
            //    glProgramUniform2i64ARB = (delegate* unmanaged<GLuint, GLint, GLint64, GLint64, void>)GetProcAddress("glProgramUniform2i64ARB");
            //}
            //if (config == null || config.Contains("glProgramUniform2i64NV")) {
            //    glProgramUniform2i64NV = (delegate* unmanaged<GLuint, GLint, GLint64EXT, GLint64EXT, void>)GetProcAddress("glProgramUniform2i64NV");
            //}
            //if (config == null || config.Contains("glProgramUniform2i64vARB")) {
            //    glProgramUniform2i64vARB = (delegate* unmanaged<GLuint, GLint, GLsizei, GLint64[], void>)GetProcAddress("glProgramUniform2i64vARB");
            //}
            //if (config == null || config.Contains("glProgramUniform2i64vNV")) {
            //    glProgramUniform2i64vNV = (delegate* unmanaged<GLuint, GLint, GLsizei, GLint64EXT[], void>)GetProcAddress("glProgramUniform2i64vNV");
            //}
            //if (config == null || config.Contains("glProgramUniform2iEXT")) {
            //    glProgramUniform2iEXT = (delegate* unmanaged<GLuint, GLint, GLint, GLint, void>)GetProcAddress("glProgramUniform2iEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform2iv")) {
            //    glProgramUniform2iv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLint[], void>)GetProcAddress("glProgramUniform2iv");
            //}
            //if (config == null || config.Contains("glProgramUniform2ivEXT")) {
            //    glProgramUniform2ivEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLint[], void>)GetProcAddress("glProgramUniform2ivEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform2ui")) {
            //    glProgramUniform2ui = (delegate* unmanaged<GLuint, GLint, GLuint, GLuint, void>)GetProcAddress("glProgramUniform2ui");
            //}
            //if (config == null || config.Contains("glProgramUniform2ui64ARB")) {
            //    glProgramUniform2ui64ARB = (delegate* unmanaged<GLuint, GLint, GLuint64, GLuint64, void>)GetProcAddress("glProgramUniform2ui64ARB");
            //}
            //if (config == null || config.Contains("glProgramUniform2ui64NV")) {
            //    glProgramUniform2ui64NV = (delegate* unmanaged<GLuint, GLint, GLuint64EXT, GLuint64EXT, void>)GetProcAddress("glProgramUniform2ui64NV");
            //}
            //if (config == null || config.Contains("glProgramUniform2ui64vARB")) {
            //    glProgramUniform2ui64vARB = (delegate* unmanaged<GLuint, GLint, GLsizei, GLuint64[], void>)GetProcAddress("glProgramUniform2ui64vARB");
            //}
            //if (config == null || config.Contains("glProgramUniform2ui64vNV")) {
            //    glProgramUniform2ui64vNV = (delegate* unmanaged<GLuint, GLint, GLsizei, GLuint64EXT[], void>)GetProcAddress("glProgramUniform2ui64vNV");
            //}
            //if (config == null || config.Contains("glProgramUniform2uiEXT")) {
            //    glProgramUniform2uiEXT = (delegate* unmanaged<GLuint, GLint, GLuint, GLuint, void>)GetProcAddress("glProgramUniform2uiEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform2uiv")) {
            //    glProgramUniform2uiv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLuint[], void>)GetProcAddress("glProgramUniform2uiv");
            //}
            //if (config == null || config.Contains("glProgramUniform2uivEXT")) {
            //    glProgramUniform2uivEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLuint[], void>)GetProcAddress("glProgramUniform2uivEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform3d")) {
            //    glProgramUniform3d = (delegate* unmanaged<GLuint, GLint, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glProgramUniform3d");
            //}
            //if (config == null || config.Contains("glProgramUniform3dEXT")) {
            //    glProgramUniform3dEXT = (delegate* unmanaged<GLuint, GLint, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glProgramUniform3dEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform3dv")) {
            //    glProgramUniform3dv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLdouble[], void>)GetProcAddress("glProgramUniform3dv");
            //}
            //if (config == null || config.Contains("glProgramUniform3dvEXT")) {
            //    glProgramUniform3dvEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLdouble[], void>)GetProcAddress("glProgramUniform3dvEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform3f")) {
            //    glProgramUniform3f = (delegate* unmanaged<GLuint, GLint, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glProgramUniform3f");
            //}
            //if (config == null || config.Contains("glProgramUniform3fEXT")) {
            //    glProgramUniform3fEXT = (delegate* unmanaged<GLuint, GLint, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glProgramUniform3fEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform3fv")) {
            //    glProgramUniform3fv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLfloat[], void>)GetProcAddress("glProgramUniform3fv");
            //}
            //if (config == null || config.Contains("glProgramUniform3fvEXT")) {
            //    glProgramUniform3fvEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLfloat[], void>)GetProcAddress("glProgramUniform3fvEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform3i")) {
            //    glProgramUniform3i = (delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, void>)GetProcAddress("glProgramUniform3i");
            //}
            //if (config == null || config.Contains("glProgramUniform3i64ARB")) {
            //    glProgramUniform3i64ARB = (delegate* unmanaged<GLuint, GLint, GLint64, GLint64, GLint64, void>)GetProcAddress("glProgramUniform3i64ARB");
            //}
            //if (config == null || config.Contains("glProgramUniform3i64NV")) {
            //    glProgramUniform3i64NV = (delegate* unmanaged<GLuint, GLint, GLint64EXT, GLint64EXT, GLint64EXT, void>)GetProcAddress("glProgramUniform3i64NV");
            //}
            //if (config == null || config.Contains("glProgramUniform3i64vARB")) {
            //    glProgramUniform3i64vARB = (delegate* unmanaged<GLuint, GLint, GLsizei, GLint64[], void>)GetProcAddress("glProgramUniform3i64vARB");
            //}
            //if (config == null || config.Contains("glProgramUniform3i64vNV")) {
            //    glProgramUniform3i64vNV = (delegate* unmanaged<GLuint, GLint, GLsizei, GLint64EXT[], void>)GetProcAddress("glProgramUniform3i64vNV");
            //}
            //if (config == null || config.Contains("glProgramUniform3iEXT")) {
            //    glProgramUniform3iEXT = (delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, void>)GetProcAddress("glProgramUniform3iEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform3iv")) {
            //    glProgramUniform3iv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLint[], void>)GetProcAddress("glProgramUniform3iv");
            //}
            //if (config == null || config.Contains("glProgramUniform3ivEXT")) {
            //    glProgramUniform3ivEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLint[], void>)GetProcAddress("glProgramUniform3ivEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform3ui")) {
            //    glProgramUniform3ui = (delegate* unmanaged<GLuint, GLint, GLuint, GLuint, GLuint, void>)GetProcAddress("glProgramUniform3ui");
            //}
            //if (config == null || config.Contains("glProgramUniform3ui64ARB")) {
            //    glProgramUniform3ui64ARB = (delegate* unmanaged<GLuint, GLint, GLuint64, GLuint64, GLuint64, void>)GetProcAddress("glProgramUniform3ui64ARB");
            //}
            //if (config == null || config.Contains("glProgramUniform3ui64NV")) {
            //    glProgramUniform3ui64NV = (delegate* unmanaged<GLuint, GLint, GLuint64EXT, GLuint64EXT, GLuint64EXT, void>)GetProcAddress("glProgramUniform3ui64NV");
            //}
            //if (config == null || config.Contains("glProgramUniform3ui64vARB")) {
            //    glProgramUniform3ui64vARB = (delegate* unmanaged<GLuint, GLint, GLsizei, GLuint64[], void>)GetProcAddress("glProgramUniform3ui64vARB");
            //}
            //if (config == null || config.Contains("glProgramUniform3ui64vNV")) {
            //    glProgramUniform3ui64vNV = (delegate* unmanaged<GLuint, GLint, GLsizei, GLuint64EXT[], void>)GetProcAddress("glProgramUniform3ui64vNV");
            //}
            //if (config == null || config.Contains("glProgramUniform3uiEXT")) {
            //    glProgramUniform3uiEXT = (delegate* unmanaged<GLuint, GLint, GLuint, GLuint, GLuint, void>)GetProcAddress("glProgramUniform3uiEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform3uiv")) {
            //    glProgramUniform3uiv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLuint[], void>)GetProcAddress("glProgramUniform3uiv");
            //}
            //if (config == null || config.Contains("glProgramUniform3uivEXT")) {
            //    glProgramUniform3uivEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLuint[], void>)GetProcAddress("glProgramUniform3uivEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform4d")) {
            //    glProgramUniform4d = (delegate* unmanaged<GLuint, GLint, GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glProgramUniform4d");
            //}
            //if (config == null || config.Contains("glProgramUniform4dEXT")) {
            //    glProgramUniform4dEXT = (delegate* unmanaged<GLuint, GLint, GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glProgramUniform4dEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform4dv")) {
            //    glProgramUniform4dv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLdouble[], void>)GetProcAddress("glProgramUniform4dv");
            //}
            //if (config == null || config.Contains("glProgramUniform4dvEXT")) {
            //    glProgramUniform4dvEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLdouble[], void>)GetProcAddress("glProgramUniform4dvEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform4f")) {
            //    glProgramUniform4f = (delegate* unmanaged<GLuint, GLint, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glProgramUniform4f");
            //}
            //if (config == null || config.Contains("glProgramUniform4fEXT")) {
            //    glProgramUniform4fEXT = (delegate* unmanaged<GLuint, GLint, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glProgramUniform4fEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform4fv")) {
            //    glProgramUniform4fv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLfloat[], void>)GetProcAddress("glProgramUniform4fv");
            //}
            //if (config == null || config.Contains("glProgramUniform4fvEXT")) {
            //    glProgramUniform4fvEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLfloat[], void>)GetProcAddress("glProgramUniform4fvEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform4i")) {
            //    glProgramUniform4i = (delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, GLint, void>)GetProcAddress("glProgramUniform4i");
            //}
            //if (config == null || config.Contains("glProgramUniform4i64ARB")) {
            //    glProgramUniform4i64ARB = (delegate* unmanaged<GLuint, GLint, GLint64, GLint64, GLint64, GLint64, void>)GetProcAddress("glProgramUniform4i64ARB");
            //}
            //if (config == null || config.Contains("glProgramUniform4i64NV")) {
            //    glProgramUniform4i64NV = (delegate* unmanaged<GLuint, GLint, GLint64EXT, GLint64EXT, GLint64EXT, GLint64EXT, void>)GetProcAddress("glProgramUniform4i64NV");
            //}
            //if (config == null || config.Contains("glProgramUniform4i64vARB")) {
            //    glProgramUniform4i64vARB = (delegate* unmanaged<GLuint, GLint, GLsizei, GLint64[], void>)GetProcAddress("glProgramUniform4i64vARB");
            //}
            //if (config == null || config.Contains("glProgramUniform4i64vNV")) {
            //    glProgramUniform4i64vNV = (delegate* unmanaged<GLuint, GLint, GLsizei, GLint64EXT[], void>)GetProcAddress("glProgramUniform4i64vNV");
            //}
            //if (config == null || config.Contains("glProgramUniform4iEXT")) {
            //    glProgramUniform4iEXT = (delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, GLint, void>)GetProcAddress("glProgramUniform4iEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform4iv")) {
            //    glProgramUniform4iv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLint[], void>)GetProcAddress("glProgramUniform4iv");
            //}
            //if (config == null || config.Contains("glProgramUniform4ivEXT")) {
            //    glProgramUniform4ivEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLint[], void>)GetProcAddress("glProgramUniform4ivEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform4ui")) {
            //    glProgramUniform4ui = (delegate* unmanaged<GLuint, GLint, GLuint, GLuint, GLuint, GLuint, void>)GetProcAddress("glProgramUniform4ui");
            //}
            //if (config == null || config.Contains("glProgramUniform4ui64ARB")) {
            //    glProgramUniform4ui64ARB = (delegate* unmanaged<GLuint, GLint, GLuint64, GLuint64, GLuint64, GLuint64, void>)GetProcAddress("glProgramUniform4ui64ARB");
            //}
            //if (config == null || config.Contains("glProgramUniform4ui64NV")) {
            //    glProgramUniform4ui64NV = (delegate* unmanaged<GLuint, GLint, GLuint64EXT, GLuint64EXT, GLuint64EXT, GLuint64EXT, void>)GetProcAddress("glProgramUniform4ui64NV");
            //}
            //if (config == null || config.Contains("glProgramUniform4ui64vARB")) {
            //    glProgramUniform4ui64vARB = (delegate* unmanaged<GLuint, GLint, GLsizei, GLuint64[], void>)GetProcAddress("glProgramUniform4ui64vARB");
            //}
            //if (config == null || config.Contains("glProgramUniform4ui64vNV")) {
            //    glProgramUniform4ui64vNV = (delegate* unmanaged<GLuint, GLint, GLsizei, GLuint64EXT[], void>)GetProcAddress("glProgramUniform4ui64vNV");
            //}
            //if (config == null || config.Contains("glProgramUniform4uiEXT")) {
            //    glProgramUniform4uiEXT = (delegate* unmanaged<GLuint, GLint, GLuint, GLuint, GLuint, GLuint, void>)GetProcAddress("glProgramUniform4uiEXT");
            //}
            //if (config == null || config.Contains("glProgramUniform4uiv")) {
            //    glProgramUniform4uiv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLuint[], void>)GetProcAddress("glProgramUniform4uiv");
            //}
            //if (config == null || config.Contains("glProgramUniform4uivEXT")) {
            //    glProgramUniform4uivEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLuint[], void>)GetProcAddress("glProgramUniform4uivEXT");
            //}
            //if (config == null || config.Contains("glProgramUniformHandleui64ARB")) {
            //    glProgramUniformHandleui64ARB = (delegate* unmanaged<GLuint, GLint, GLuint64, void>)GetProcAddress("glProgramUniformHandleui64ARB");
            //}
            //if (config == null || config.Contains("glProgramUniformHandleui64IMG")) {
            //    glProgramUniformHandleui64IMG = (delegate* unmanaged<GLuint, GLint, GLuint64, void>)GetProcAddress("glProgramUniformHandleui64IMG");
            //}
            //if (config == null || config.Contains("glProgramUniformHandleui64NV")) {
            //    glProgramUniformHandleui64NV = (delegate* unmanaged<GLuint, GLint, GLuint64, void>)GetProcAddress("glProgramUniformHandleui64NV");
            //}
            //if (config == null || config.Contains("glProgramUniformHandleui64vARB")) {
            //    glProgramUniformHandleui64vARB = (delegate* unmanaged<GLuint, GLint, GLsizei, GLuint64[], void>)GetProcAddress("glProgramUniformHandleui64vARB");
            //}
            //if (config == null || config.Contains("glProgramUniformHandleui64vIMG")) {
            //    glProgramUniformHandleui64vIMG = (delegate* unmanaged<GLuint, GLint, GLsizei, GLuint64[], void>)GetProcAddress("glProgramUniformHandleui64vIMG");
            //}
            //if (config == null || config.Contains("glProgramUniformHandleui64vNV")) {
            //    glProgramUniformHandleui64vNV = (delegate* unmanaged<GLuint, GLint, GLsizei, GLuint64[], void>)GetProcAddress("glProgramUniformHandleui64vNV");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix2dv")) {
            //    glProgramUniformMatrix2dv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void>)GetProcAddress("glProgramUniformMatrix2dv");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix2dvEXT")) {
            //    glProgramUniformMatrix2dvEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void>)GetProcAddress("glProgramUniformMatrix2dvEXT");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix2fv")) {
            //    glProgramUniformMatrix2fv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glProgramUniformMatrix2fv");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix2fvEXT")) {
            //    glProgramUniformMatrix2fvEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glProgramUniformMatrix2fvEXT");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix2x3dv")) {
            //    glProgramUniformMatrix2x3dv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void>)GetProcAddress("glProgramUniformMatrix2x3dv");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix2x3dvEXT")) {
            //    glProgramUniformMatrix2x3dvEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void>)GetProcAddress("glProgramUniformMatrix2x3dvEXT");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix2x3fv")) {
            //    glProgramUniformMatrix2x3fv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glProgramUniformMatrix2x3fv");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix2x3fvEXT")) {
            //    glProgramUniformMatrix2x3fvEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glProgramUniformMatrix2x3fvEXT");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix2x4dv")) {
            //    glProgramUniformMatrix2x4dv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void>)GetProcAddress("glProgramUniformMatrix2x4dv");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix2x4dvEXT")) {
            //    glProgramUniformMatrix2x4dvEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void>)GetProcAddress("glProgramUniformMatrix2x4dvEXT");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix2x4fv")) {
            //    glProgramUniformMatrix2x4fv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glProgramUniformMatrix2x4fv");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix2x4fvEXT")) {
            //    glProgramUniformMatrix2x4fvEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glProgramUniformMatrix2x4fvEXT");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix3dv")) {
            //    glProgramUniformMatrix3dv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void>)GetProcAddress("glProgramUniformMatrix3dv");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix3dvEXT")) {
            //    glProgramUniformMatrix3dvEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void>)GetProcAddress("glProgramUniformMatrix3dvEXT");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix3fv")) {
            //    glProgramUniformMatrix3fv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glProgramUniformMatrix3fv");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix3fvEXT")) {
            //    glProgramUniformMatrix3fvEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glProgramUniformMatrix3fvEXT");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix3x2dv")) {
            //    glProgramUniformMatrix3x2dv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void>)GetProcAddress("glProgramUniformMatrix3x2dv");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix3x2dvEXT")) {
            //    glProgramUniformMatrix3x2dvEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void>)GetProcAddress("glProgramUniformMatrix3x2dvEXT");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix3x2fv")) {
            //    glProgramUniformMatrix3x2fv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glProgramUniformMatrix3x2fv");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix3x2fvEXT")) {
            //    glProgramUniformMatrix3x2fvEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glProgramUniformMatrix3x2fvEXT");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix3x4dv")) {
            //    glProgramUniformMatrix3x4dv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void>)GetProcAddress("glProgramUniformMatrix3x4dv");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix3x4dvEXT")) {
            //    glProgramUniformMatrix3x4dvEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void>)GetProcAddress("glProgramUniformMatrix3x4dvEXT");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix3x4fv")) {
            //    glProgramUniformMatrix3x4fv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glProgramUniformMatrix3x4fv");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix3x4fvEXT")) {
            //    glProgramUniformMatrix3x4fvEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glProgramUniformMatrix3x4fvEXT");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix4dv")) {
            //    glProgramUniformMatrix4dv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void>)GetProcAddress("glProgramUniformMatrix4dv");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix4dvEXT")) {
            //    glProgramUniformMatrix4dvEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void>)GetProcAddress("glProgramUniformMatrix4dvEXT");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix4fv")) {
            //    glProgramUniformMatrix4fv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glProgramUniformMatrix4fv");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix4fvEXT")) {
            //    glProgramUniformMatrix4fvEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glProgramUniformMatrix4fvEXT");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix4x2dv")) {
            //    glProgramUniformMatrix4x2dv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void>)GetProcAddress("glProgramUniformMatrix4x2dv");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix4x2dvEXT")) {
            //    glProgramUniformMatrix4x2dvEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void>)GetProcAddress("glProgramUniformMatrix4x2dvEXT");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix4x2fv")) {
            //    glProgramUniformMatrix4x2fv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glProgramUniformMatrix4x2fv");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix4x2fvEXT")) {
            //    glProgramUniformMatrix4x2fvEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glProgramUniformMatrix4x2fvEXT");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix4x3dv")) {
            //    glProgramUniformMatrix4x3dv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void>)GetProcAddress("glProgramUniformMatrix4x3dv");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix4x3dvEXT")) {
            //    glProgramUniformMatrix4x3dvEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLdouble[], void>)GetProcAddress("glProgramUniformMatrix4x3dvEXT");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix4x3fv")) {
            //    glProgramUniformMatrix4x3fv = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glProgramUniformMatrix4x3fv");
            //}
            //if (config == null || config.Contains("glProgramUniformMatrix4x3fvEXT")) {
            //    glProgramUniformMatrix4x3fvEXT = (delegate* unmanaged<GLuint, GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glProgramUniformMatrix4x3fvEXT");
            //}
            //if (config == null || config.Contains("glProgramUniformui64NV")) {
            //    glProgramUniformui64NV = (delegate* unmanaged<GLuint, GLint, GLuint64EXT, void>)GetProcAddress("glProgramUniformui64NV");
            //}
            //if (config == null || config.Contains("glProgramUniformui64vNV")) {
            //    glProgramUniformui64vNV = (delegate* unmanaged<GLuint, GLint, GLsizei, GLuint64EXT[], void>)GetProcAddress("glProgramUniformui64vNV");
            //}
            //if (config == null || config.Contains("glProgramVertexLimitNV")) {
            //    glProgramVertexLimitNV = (delegate* unmanaged<GLenum, GLint, void>)GetProcAddress("glProgramVertexLimitNV");
            //}
            //if (config == null || config.Contains("glProvokingVertex")) {
            //    glProvokingVertex = (delegate* unmanaged<GLenum, void>)GetProcAddress("glProvokingVertex");
            //}
            //if (config == null || config.Contains("glProvokingVertexEXT")) {
            //    glProvokingVertexEXT = (delegate* unmanaged<GLenum, void>)GetProcAddress("glProvokingVertexEXT");
            //}
            //if (config == null || config.Contains("glPushAttrib")) {
            //    glPushAttrib = (delegate* unmanaged<GLbitfield, void>)GetProcAddress("glPushAttrib");
            //}
            //if (config == null || config.Contains("glPushClientAttrib")) {
            //    glPushClientAttrib = (delegate* unmanaged<GLbitfield, void>)GetProcAddress("glPushClientAttrib");
            //}
            //if (config == null || config.Contains("glPushClientAttribDefaultEXT")) {
            //    glPushClientAttribDefaultEXT = (delegate* unmanaged<GLbitfield, void>)GetProcAddress("glPushClientAttribDefaultEXT");
            //}
            //if (config == null || config.Contains("glPushDebugGroup")) {
            //    glPushDebugGroup = (delegate* unmanaged<GLenum, GLuint, GLsizei, string, void>)GetProcAddress("glPushDebugGroup");
            //}
            //if (config == null || config.Contains("glPushDebugGroupKHR")) {
            //    glPushDebugGroupKHR = (delegate* unmanaged<GLenum, GLuint, GLsizei, string, void>)GetProcAddress("glPushDebugGroupKHR");
            //}
            //if (config == null || config.Contains("glPushGroupMarkerEXT")) {
            //    glPushGroupMarkerEXT = (delegate* unmanaged<GLsizei, string, void>)GetProcAddress("glPushGroupMarkerEXT");
            //}
            //if (config == null || config.Contains("glPushMatrix")) {
            //    glPushMatrix = (delegate* unmanaged<void>)GetProcAddress("glPushMatrix");
            //}
            //if (config == null || config.Contains("glPushName")) {
            //    glPushName = (delegate* unmanaged<GLuint, void>)GetProcAddress("glPushName");
            //}
            //if (config == null || config.Contains("glQueryCounter")) {
            //    glQueryCounter = (delegate* unmanaged<GLuint, GLenum, void>)GetProcAddress("glQueryCounter");
            //}
            //if (config == null || config.Contains("glQueryCounterEXT")) {
            //    glQueryCounterEXT = (delegate* unmanaged<GLuint, GLenum, void>)GetProcAddress("glQueryCounterEXT");
            //}
            //if (config == null || config.Contains("glQueryMatrixxOES")) {
            //    glQueryMatrixxOES = (delegate* unmanaged<GLfixed[], GLint[], GLbitfield>)GetProcAddress("glQueryMatrixxOES");
            //}
            //if (config == null || config.Contains("glQueryObjectParameteruiAMD")) {
            //    glQueryObjectParameteruiAMD = (delegate* unmanaged<GLenum, GLuint, GLenum, GLuint, void>)GetProcAddress("glQueryObjectParameteruiAMD");
            //}
            //if (config == null || config.Contains("glQueryResourceNV")) {
            //    glQueryResourceNV = (delegate* unmanaged<GLenum, GLint, GLuint, GLint[], GLint>)GetProcAddress("glQueryResourceNV");
            //}
            //if (config == null || config.Contains("glQueryResourceTagNV")) {
            //    glQueryResourceTagNV = (delegate* unmanaged<GLint, string, void>)GetProcAddress("glQueryResourceTagNV");
            //}
            //if (config == null || config.Contains("glRasterPos2d")) {
            //    glRasterPos2d = (delegate* unmanaged<GLdouble, GLdouble, void>)GetProcAddress("glRasterPos2d");
            //}
            //if (config == null || config.Contains("glRasterPos2dv")) {
            //    glRasterPos2dv = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glRasterPos2dv");
            //}
            //if (config == null || config.Contains("glRasterPos2f")) {
            //    glRasterPos2f = (delegate* unmanaged<GLfloat, GLfloat, void>)GetProcAddress("glRasterPos2f");
            //}
            //if (config == null || config.Contains("glRasterPos2fv")) {
            //    glRasterPos2fv = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glRasterPos2fv");
            //}
            //if (config == null || config.Contains("glRasterPos2i")) {
            //    glRasterPos2i = (delegate* unmanaged<GLint, GLint, void>)GetProcAddress("glRasterPos2i");
            //}
            //if (config == null || config.Contains("glRasterPos2iv")) {
            //    glRasterPos2iv = (delegate* unmanaged<GLint[], void>)GetProcAddress("glRasterPos2iv");
            //}
            //if (config == null || config.Contains("glRasterPos2s")) {
            //    glRasterPos2s = (delegate* unmanaged<GLshort, GLshort, void>)GetProcAddress("glRasterPos2s");
            //}
            //if (config == null || config.Contains("glRasterPos2sv")) {
            //    glRasterPos2sv = (delegate* unmanaged<GLshort[], void>)GetProcAddress("glRasterPos2sv");
            //}
            //if (config == null || config.Contains("glRasterPos2xOES")) {
            //    glRasterPos2xOES = (delegate* unmanaged<GLfixed, GLfixed, void>)GetProcAddress("glRasterPos2xOES");
            //}
            //if (config == null || config.Contains("glRasterPos2xvOES")) {
            //    glRasterPos2xvOES = (delegate* unmanaged<GLfixed[], void>)GetProcAddress("glRasterPos2xvOES");
            //}
            //if (config == null || config.Contains("glRasterPos3d")) {
            //    glRasterPos3d = (delegate* unmanaged<GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glRasterPos3d");
            //}
            //if (config == null || config.Contains("glRasterPos3dv")) {
            //    glRasterPos3dv = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glRasterPos3dv");
            //}
            //if (config == null || config.Contains("glRasterPos3f")) {
            //    glRasterPos3f = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glRasterPos3f");
            //}
            //if (config == null || config.Contains("glRasterPos3fv")) {
            //    glRasterPos3fv = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glRasterPos3fv");
            //}
            //if (config == null || config.Contains("glRasterPos3i")) {
            //    glRasterPos3i = (delegate* unmanaged<GLint, GLint, GLint, void>)GetProcAddress("glRasterPos3i");
            //}
            //if (config == null || config.Contains("glRasterPos3iv")) {
            //    glRasterPos3iv = (delegate* unmanaged<GLint[], void>)GetProcAddress("glRasterPos3iv");
            //}
            //if (config == null || config.Contains("glRasterPos3s")) {
            //    glRasterPos3s = (delegate* unmanaged<GLshort, GLshort, GLshort, void>)GetProcAddress("glRasterPos3s");
            //}
            //if (config == null || config.Contains("glRasterPos3sv")) {
            //    glRasterPos3sv = (delegate* unmanaged<GLshort[], void>)GetProcAddress("glRasterPos3sv");
            //}
            //if (config == null || config.Contains("glRasterPos3xOES")) {
            //    glRasterPos3xOES = (delegate* unmanaged<GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glRasterPos3xOES");
            //}
            //if (config == null || config.Contains("glRasterPos3xvOES")) {
            //    glRasterPos3xvOES = (delegate* unmanaged<GLfixed[], void>)GetProcAddress("glRasterPos3xvOES");
            //}
            //if (config == null || config.Contains("glRasterPos4d")) {
            //    glRasterPos4d = (delegate* unmanaged<GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glRasterPos4d");
            //}
            //if (config == null || config.Contains("glRasterPos4dv")) {
            //    glRasterPos4dv = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glRasterPos4dv");
            //}
            //if (config == null || config.Contains("glRasterPos4f")) {
            //    glRasterPos4f = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glRasterPos4f");
            //}
            //if (config == null || config.Contains("glRasterPos4fv")) {
            //    glRasterPos4fv = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glRasterPos4fv");
            //}
            //if (config == null || config.Contains("glRasterPos4i")) {
            //    glRasterPos4i = (delegate* unmanaged<GLint, GLint, GLint, GLint, void>)GetProcAddress("glRasterPos4i");
            //}
            //if (config == null || config.Contains("glRasterPos4iv")) {
            //    glRasterPos4iv = (delegate* unmanaged<GLint[], void>)GetProcAddress("glRasterPos4iv");
            //}
            //if (config == null || config.Contains("glRasterPos4s")) {
            //    glRasterPos4s = (delegate* unmanaged<GLshort, GLshort, GLshort, GLshort, void>)GetProcAddress("glRasterPos4s");
            //}
            //if (config == null || config.Contains("glRasterPos4sv")) {
            //    glRasterPos4sv = (delegate* unmanaged<GLshort[], void>)GetProcAddress("glRasterPos4sv");
            //}
            //if (config == null || config.Contains("glRasterPos4xOES")) {
            //    glRasterPos4xOES = (delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glRasterPos4xOES");
            //}
            //if (config == null || config.Contains("glRasterPos4xvOES")) {
            //    glRasterPos4xvOES = (delegate* unmanaged<GLfixed[], void>)GetProcAddress("glRasterPos4xvOES");
            //}
            //if (config == null || config.Contains("glRasterSamplesEXT")) {
            //    glRasterSamplesEXT = (delegate* unmanaged<GLuint, GLboolean, void>)GetProcAddress("glRasterSamplesEXT");
            //}
            //if (config == null || config.Contains("glReadBuffer")) {
            //    glReadBuffer = (delegate* unmanaged<GLenum, void>)GetProcAddress("glReadBuffer");
            //}
            //if (config == null || config.Contains("glReadBufferIndexedEXT")) {
            //    glReadBufferIndexedEXT = (delegate* unmanaged<GLenum, GLint, void>)GetProcAddress("glReadBufferIndexedEXT");
            //}
            //if (config == null || config.Contains("glReadBufferNV")) {
            //    glReadBufferNV = (delegate* unmanaged<GLenum, void>)GetProcAddress("glReadBufferNV");
            //}
            //if (config == null || config.Contains("glReadInstrumentsSGIX")) {
            //    glReadInstrumentsSGIX = (delegate* unmanaged<GLint, void>)GetProcAddress("glReadInstrumentsSGIX");
            //}
            //if (config == null || config.Contains("glReadPixels")) {
            //    glReadPixels = (delegate* unmanaged<GLint, GLint, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glReadPixels");
            //}
            //if (config == null || config.Contains("glReadnPixels")) {
            //    glReadnPixels = (delegate* unmanaged<GLint, GLint, GLsizei, GLsizei, GLenum, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glReadnPixels");
            //}
            //if (config == null || config.Contains("glReadnPixelsARB")) {
            //    glReadnPixelsARB = (delegate* unmanaged<GLint, GLint, GLsizei, GLsizei, GLenum, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glReadnPixelsARB");
            //}
            //if (config == null || config.Contains("glReadnPixelsEXT")) {
            //    glReadnPixelsEXT = (delegate* unmanaged<GLint, GLint, GLsizei, GLsizei, GLenum, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glReadnPixelsEXT");
            //}
            //if (config == null || config.Contains("glReadnPixelsKHR")) {
            //    glReadnPixelsKHR = (delegate* unmanaged<GLint, GLint, GLsizei, GLsizei, GLenum, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glReadnPixelsKHR");
            //}
            //if (config == null || config.Contains("glReleaseKeyedMutexWin32EXT")) {
            //    glReleaseKeyedMutexWin32EXT = (delegate* unmanaged<GLuint, GLuint64, GLboolean>)GetProcAddress("glReleaseKeyedMutexWin32EXT");
            //}
            //if (config == null || config.Contains("glRectd")) {
            //    glRectd = (delegate* unmanaged<GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glRectd");
            //}
            //if (config == null || config.Contains("glRectdv")) {
            //    glRectdv = (delegate* unmanaged<GLdouble[], GLdouble[], void>)GetProcAddress("glRectdv");
            //}
            //if (config == null || config.Contains("glRectf")) {
            //    glRectf = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glRectf");
            //}
            //if (config == null || config.Contains("glRectfv")) {
            //    glRectfv = (delegate* unmanaged<GLfloat[], GLfloat[], void>)GetProcAddress("glRectfv");
            //}
            //if (config == null || config.Contains("glRecti")) {
            //    glRecti = (delegate* unmanaged<GLint, GLint, GLint, GLint, void>)GetProcAddress("glRecti");
            //}
            //if (config == null || config.Contains("glRectiv")) {
            //    glRectiv = (delegate* unmanaged<GLint[], GLint[], void>)GetProcAddress("glRectiv");
            //}
            //if (config == null || config.Contains("glRects")) {
            //    glRects = (delegate* unmanaged<GLshort, GLshort, GLshort, GLshort, void>)GetProcAddress("glRects");
            //}
            //if (config == null || config.Contains("glRectsv")) {
            //    glRectsv = (delegate* unmanaged<GLshort[], GLshort[], void>)GetProcAddress("glRectsv");
            //}
            //if (config == null || config.Contains("glRectxOES")) {
            //    glRectxOES = (delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glRectxOES");
            //}
            //if (config == null || config.Contains("glRectxvOES")) {
            //    glRectxvOES = (delegate* unmanaged<GLfixed[], GLfixed[], void>)GetProcAddress("glRectxvOES");
            //}
            //if (config == null || config.Contains("glReferencePlaneSGIX")) {
            //    glReferencePlaneSGIX = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glReferencePlaneSGIX");
            //}
            //if (config == null || config.Contains("glReleaseShaderCompiler")) {
            //    glReleaseShaderCompiler = (delegate* unmanaged<void>)GetProcAddress("glReleaseShaderCompiler");
            //}
            //if (config == null || config.Contains("glRenderGpuMaskNV")) {
            //    glRenderGpuMaskNV = (delegate* unmanaged<GLbitfield, void>)GetProcAddress("glRenderGpuMaskNV");
            //}
            //if (config == null || config.Contains("glRenderMode")) {
            //    glRenderMode = (delegate* unmanaged<GLenum, GLint>)GetProcAddress("glRenderMode");
            //}
            //if (config == null || config.Contains("glRenderbufferStorage")) {
            //    glRenderbufferStorage = (delegate* unmanaged<GLenum, GLenum, GLsizei, GLsizei, void>)GetProcAddress("glRenderbufferStorage");
            //}
            //if (config == null || config.Contains("glRenderbufferStorageEXT")) {
            //    glRenderbufferStorageEXT = (delegate* unmanaged<GLenum, GLenum, GLsizei, GLsizei, void>)GetProcAddress("glRenderbufferStorageEXT");
            //}
            //if (config == null || config.Contains("glRenderbufferStorageMultisample")) {
            //    glRenderbufferStorageMultisample = (delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, void>)GetProcAddress("glRenderbufferStorageMultisample");
            //}
            //if (config == null || config.Contains("glRenderbufferStorageMultisampleANGLE")) {
            //    glRenderbufferStorageMultisampleANGLE = (delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, void>)GetProcAddress("glRenderbufferStorageMultisampleANGLE");
            //}
            //if (config == null || config.Contains("glRenderbufferStorageMultisampleAPPLE")) {
            //    glRenderbufferStorageMultisampleAPPLE = (delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, void>)GetProcAddress("glRenderbufferStorageMultisampleAPPLE");
            //}
            //if (config == null || config.Contains("glRenderbufferStorageMultisampleAdvancedAMD")) {
            //    glRenderbufferStorageMultisampleAdvancedAMD = (delegate* unmanaged<GLenum, GLsizei, GLsizei, GLenum, GLsizei, GLsizei, void>)GetProcAddress("glRenderbufferStorageMultisampleAdvancedAMD");
            //}
            //if (config == null || config.Contains("glRenderbufferStorageMultisampleCoverageNV")) {
            //    glRenderbufferStorageMultisampleCoverageNV = (delegate* unmanaged<GLenum, GLsizei, GLsizei, GLenum, GLsizei, GLsizei, void>)GetProcAddress("glRenderbufferStorageMultisampleCoverageNV");
            //}
            //if (config == null || config.Contains("glRenderbufferStorageMultisampleEXT")) {
            //    glRenderbufferStorageMultisampleEXT = (delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, void>)GetProcAddress("glRenderbufferStorageMultisampleEXT");
            //}
            //if (config == null || config.Contains("glRenderbufferStorageMultisampleIMG")) {
            //    glRenderbufferStorageMultisampleIMG = (delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, void>)GetProcAddress("glRenderbufferStorageMultisampleIMG");
            //}
            //if (config == null || config.Contains("glRenderbufferStorageMultisampleNV")) {
            //    glRenderbufferStorageMultisampleNV = (delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, void>)GetProcAddress("glRenderbufferStorageMultisampleNV");
            //}
            //if (config == null || config.Contains("glRenderbufferStorageOES")) {
            //    glRenderbufferStorageOES = (delegate* unmanaged<GLenum, GLenum, GLsizei, GLsizei, void>)GetProcAddress("glRenderbufferStorageOES");
            //}
            //if (config == null || config.Contains("glReplacementCodePointerSUN")) {
            //    glReplacementCodePointerSUN = (delegate* unmanaged<GLenum, GLsizei, IntPtr, void>)GetProcAddress("glReplacementCodePointerSUN");
            //}
            //if (config == null || config.Contains("glReplacementCodeubSUN")) {
            //    glReplacementCodeubSUN = (delegate* unmanaged<GLubyte, void>)GetProcAddress("glReplacementCodeubSUN");
            //}
            //if (config == null || config.Contains("glReplacementCodeubvSUN")) {
            //    glReplacementCodeubvSUN = (delegate* unmanaged<GLubyte[], void>)GetProcAddress("glReplacementCodeubvSUN");
            //}
            //if (config == null || config.Contains("glReplacementCodeuiColor3fVertex3fSUN")) {
            //    glReplacementCodeuiColor3fVertex3fSUN = (delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glReplacementCodeuiColor3fVertex3fSUN");
            //}
            //if (config == null || config.Contains("glReplacementCodeuiColor3fVertex3fvSUN")) {
            //    glReplacementCodeuiColor3fVertex3fvSUN = (delegate* unmanaged<GLuint[], GLfloat[], GLfloat[], void>)GetProcAddress("glReplacementCodeuiColor3fVertex3fvSUN");
            //}
            //if (config == null || config.Contains("glReplacementCodeuiColor4fNormal3fVertex3fSUN")) {
            //    glReplacementCodeuiColor4fNormal3fVertex3fSUN = (delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glReplacementCodeuiColor4fNormal3fVertex3fSUN");
            //}
            //if (config == null || config.Contains("glReplacementCodeuiColor4fNormal3fVertex3fvSUN")) {
            //    glReplacementCodeuiColor4fNormal3fVertex3fvSUN = (delegate* unmanaged<GLuint[], GLfloat[], GLfloat[], GLfloat[], void>)GetProcAddress("glReplacementCodeuiColor4fNormal3fVertex3fvSUN");
            //}
            //if (config == null || config.Contains("glReplacementCodeuiColor4ubVertex3fSUN")) {
            //    glReplacementCodeuiColor4ubVertex3fSUN = (delegate* unmanaged<GLuint, GLubyte, GLubyte, GLubyte, GLubyte, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glReplacementCodeuiColor4ubVertex3fSUN");
            //}
            //if (config == null || config.Contains("glReplacementCodeuiColor4ubVertex3fvSUN")) {
            //    glReplacementCodeuiColor4ubVertex3fvSUN = (delegate* unmanaged<GLuint[], GLubyte[], GLfloat[], void>)GetProcAddress("glReplacementCodeuiColor4ubVertex3fvSUN");
            //}
            //if (config == null || config.Contains("glReplacementCodeuiNormal3fVertex3fSUN")) {
            //    glReplacementCodeuiNormal3fVertex3fSUN = (delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glReplacementCodeuiNormal3fVertex3fSUN");
            //}
            //if (config == null || config.Contains("glReplacementCodeuiNormal3fVertex3fvSUN")) {
            //    glReplacementCodeuiNormal3fVertex3fvSUN = (delegate* unmanaged<GLuint[], GLfloat[], GLfloat[], void>)GetProcAddress("glReplacementCodeuiNormal3fVertex3fvSUN");
            //}
            //if (config == null || config.Contains("glReplacementCodeuiSUN")) {
            //    glReplacementCodeuiSUN = (delegate* unmanaged<GLuint, void>)GetProcAddress("glReplacementCodeuiSUN");
            //}
            //if (config == null || config.Contains("glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fSUN")) {
            //    glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fSUN = (delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fSUN");
            //}
            //if (config == null || config.Contains("glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fvSUN")) {
            //    glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fvSUN = (delegate* unmanaged<GLuint[], GLfloat[], GLfloat[], GLfloat[], GLfloat[], void>)GetProcAddress("glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fvSUN");
            //}
            //if (config == null || config.Contains("glReplacementCodeuiTexCoord2fNormal3fVertex3fSUN")) {
            //    glReplacementCodeuiTexCoord2fNormal3fVertex3fSUN = (delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glReplacementCodeuiTexCoord2fNormal3fVertex3fSUN");
            //}
            //if (config == null || config.Contains("glReplacementCodeuiTexCoord2fNormal3fVertex3fvSUN")) {
            //    glReplacementCodeuiTexCoord2fNormal3fVertex3fvSUN = (delegate* unmanaged<GLuint[], GLfloat[], GLfloat[], GLfloat[], void>)GetProcAddress("glReplacementCodeuiTexCoord2fNormal3fVertex3fvSUN");
            //}
            //if (config == null || config.Contains("glReplacementCodeuiTexCoord2fVertex3fSUN")) {
            //    glReplacementCodeuiTexCoord2fVertex3fSUN = (delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glReplacementCodeuiTexCoord2fVertex3fSUN");
            //}
            //if (config == null || config.Contains("glReplacementCodeuiTexCoord2fVertex3fvSUN")) {
            //    glReplacementCodeuiTexCoord2fVertex3fvSUN = (delegate* unmanaged<GLuint[], GLfloat[], GLfloat[], void>)GetProcAddress("glReplacementCodeuiTexCoord2fVertex3fvSUN");
            //}
            //if (config == null || config.Contains("glReplacementCodeuiVertex3fSUN")) {
            //    glReplacementCodeuiVertex3fSUN = (delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glReplacementCodeuiVertex3fSUN");
            //}
            //if (config == null || config.Contains("glReplacementCodeuiVertex3fvSUN")) {
            //    glReplacementCodeuiVertex3fvSUN = (delegate* unmanaged<GLuint[], GLfloat[], void>)GetProcAddress("glReplacementCodeuiVertex3fvSUN");
            //}
            //if (config == null || config.Contains("glReplacementCodeuivSUN")) {
            //    glReplacementCodeuivSUN = (delegate* unmanaged<GLuint[], void>)GetProcAddress("glReplacementCodeuivSUN");
            //}
            //if (config == null || config.Contains("glReplacementCodeusSUN")) {
            //    glReplacementCodeusSUN = (delegate* unmanaged<GLushort, void>)GetProcAddress("glReplacementCodeusSUN");
            //}
            //if (config == null || config.Contains("glReplacementCodeusvSUN")) {
            //    glReplacementCodeusvSUN = (delegate* unmanaged<GLushort[], void>)GetProcAddress("glReplacementCodeusvSUN");
            //}
            //if (config == null || config.Contains("glRequestResidentProgramsNV")) {
            //    glRequestResidentProgramsNV = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glRequestResidentProgramsNV");
            //}
            //if (config == null || config.Contains("glResetHistogram")) {
            //    glResetHistogram = (delegate* unmanaged<GLenum, void>)GetProcAddress("glResetHistogram");
            //}
            //if (config == null || config.Contains("glResetHistogramEXT")) {
            //    glResetHistogramEXT = (delegate* unmanaged<GLenum, void>)GetProcAddress("glResetHistogramEXT");
            //}
            //if (config == null || config.Contains("glResetMemoryObjectParameterNV")) {
            //    glResetMemoryObjectParameterNV = (delegate* unmanaged<GLuint, GLenum, void>)GetProcAddress("glResetMemoryObjectParameterNV");
            //}
            //if (config == null || config.Contains("glResetMinmax")) {
            //    glResetMinmax = (delegate* unmanaged<GLenum, void>)GetProcAddress("glResetMinmax");
            //}
            //if (config == null || config.Contains("glResetMinmaxEXT")) {
            //    glResetMinmaxEXT = (delegate* unmanaged<GLenum, void>)GetProcAddress("glResetMinmaxEXT");
            //}
            //if (config == null || config.Contains("glResizeBuffersMESA")) {
            //    glResizeBuffersMESA = (delegate* unmanaged<void>)GetProcAddress("glResizeBuffersMESA");
            //}
            //if (config == null || config.Contains("glResolveDepthValuesNV")) {
            //    glResolveDepthValuesNV = (delegate* unmanaged<void>)GetProcAddress("glResolveDepthValuesNV");
            //}
            //if (config == null || config.Contains("glResolveMultisampleFramebufferAPPLE")) {
            //    glResolveMultisampleFramebufferAPPLE = (delegate* unmanaged<void>)GetProcAddress("glResolveMultisampleFramebufferAPPLE");
            //}
            //if (config == null || config.Contains("glResumeTransformFeedback")) {
            //    glResumeTransformFeedback = (delegate* unmanaged<void>)GetProcAddress("glResumeTransformFeedback");
            //}
            //if (config == null || config.Contains("glResumeTransformFeedbackNV")) {
            //    glResumeTransformFeedbackNV = (delegate* unmanaged<void>)GetProcAddress("glResumeTransformFeedbackNV");
            //}
            //if (config == null || config.Contains("glRotated")) {
            //    glRotated = (delegate* unmanaged<GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glRotated");
            //}
            //if (config == null || config.Contains("glRotatef")) {
            //    glRotatef = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glRotatef");
            //}
            //if (config == null || config.Contains("glRotatex")) {
            //    glRotatex = (delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glRotatex");
            //}
            //if (config == null || config.Contains("glRotatexOES")) {
            //    glRotatexOES = (delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glRotatexOES");
            //}
            //if (config == null || config.Contains("glSampleCoverage")) {
            //    glSampleCoverage = (delegate* unmanaged<GLfloat, GLboolean, void>)GetProcAddress("glSampleCoverage");
            //}
            //if (config == null || config.Contains("glSampleCoverageARB")) {
            //    glSampleCoverageARB = (delegate* unmanaged<GLfloat, GLboolean, void>)GetProcAddress("glSampleCoverageARB");
            //}
            //if (config == null || config.Contains("glSampleCoveragex")) {
            //    glSampleCoveragex = (delegate* unmanaged<GLclampx, GLboolean, void>)GetProcAddress("glSampleCoveragex");
            //}
            //if (config == null || config.Contains("glSampleCoveragexOES")) {
            //    glSampleCoveragexOES = (delegate* unmanaged<GLclampx, GLboolean, void>)GetProcAddress("glSampleCoveragexOES");
            //}
            //if (config == null || config.Contains("glSampleMapATI")) {
            //    glSampleMapATI = (delegate* unmanaged<GLuint, GLuint, GLenum, void>)GetProcAddress("glSampleMapATI");
            //}
            //if (config == null || config.Contains("glSampleMaskEXT")) {
            //    glSampleMaskEXT = (delegate* unmanaged<GLclampf, GLboolean, void>)GetProcAddress("glSampleMaskEXT");
            //}
            //if (config == null || config.Contains("glSampleMaskIndexedNV")) {
            //    glSampleMaskIndexedNV = (delegate* unmanaged<GLuint, GLbitfield, void>)GetProcAddress("glSampleMaskIndexedNV");
            //}
            //if (config == null || config.Contains("glSampleMaskSGIS")) {
            //    glSampleMaskSGIS = (delegate* unmanaged<GLclampf, GLboolean, void>)GetProcAddress("glSampleMaskSGIS");
            //}
            //if (config == null || config.Contains("glSampleMaski")) {
            //    glSampleMaski = (delegate* unmanaged<GLuint, GLbitfield, void>)GetProcAddress("glSampleMaski");
            //}
            //if (config == null || config.Contains("glSamplePatternEXT")) {
            //    glSamplePatternEXT = (delegate* unmanaged<GLenum, void>)GetProcAddress("glSamplePatternEXT");
            //}
            //if (config == null || config.Contains("glSamplePatternSGIS")) {
            //    glSamplePatternSGIS = (delegate* unmanaged<GLenum, void>)GetProcAddress("glSamplePatternSGIS");
            //}
            //if (config == null || config.Contains("glSamplerParameterIiv")) {
            //    glSamplerParameterIiv = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glSamplerParameterIiv");
            //}
            //if (config == null || config.Contains("glSamplerParameterIivEXT")) {
            //    glSamplerParameterIivEXT = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glSamplerParameterIivEXT");
            //}
            //if (config == null || config.Contains("glSamplerParameterIivOES")) {
            //    glSamplerParameterIivOES = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glSamplerParameterIivOES");
            //}
            //if (config == null || config.Contains("glSamplerParameterIuiv")) {
            //    glSamplerParameterIuiv = (delegate* unmanaged<GLuint, GLenum, GLuint[], void>)GetProcAddress("glSamplerParameterIuiv");
            //}
            //if (config == null || config.Contains("glSamplerParameterIuivEXT")) {
            //    glSamplerParameterIuivEXT = (delegate* unmanaged<GLuint, GLenum, GLuint[], void>)GetProcAddress("glSamplerParameterIuivEXT");
            //}
            //if (config == null || config.Contains("glSamplerParameterIuivOES")) {
            //    glSamplerParameterIuivOES = (delegate* unmanaged<GLuint, GLenum, GLuint[], void>)GetProcAddress("glSamplerParameterIuivOES");
            //}
            //if (config == null || config.Contains("glSamplerParameterf")) {
            //    glSamplerParameterf = (delegate* unmanaged<GLuint, GLenum, GLfloat, void>)GetProcAddress("glSamplerParameterf");
            //}
            //if (config == null || config.Contains("glSamplerParameterfv")) {
            //    glSamplerParameterfv = (delegate* unmanaged<GLuint, GLenum, GLfloat[], void>)GetProcAddress("glSamplerParameterfv");
            //}
            //if (config == null || config.Contains("glSamplerParameteri")) {
            //    glSamplerParameteri = (delegate* unmanaged<GLuint, GLenum, GLint, void>)GetProcAddress("glSamplerParameteri");
            //}
            //if (config == null || config.Contains("glSamplerParameteriv")) {
            //    glSamplerParameteriv = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glSamplerParameteriv");
            //}
            //if (config == null || config.Contains("glScaled")) {
            //    glScaled = (delegate* unmanaged<GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glScaled");
            //}
            //if (config == null || config.Contains("glScalef")) {
            //    glScalef = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glScalef");
            //}
            //if (config == null || config.Contains("glScalex")) {
            //    glScalex = (delegate* unmanaged<GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glScalex");
            //}
            //if (config == null || config.Contains("glScalexOES")) {
            //    glScalexOES = (delegate* unmanaged<GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glScalexOES");
            //}
            //if (config == null || config.Contains("glScissor")) {
            //    glScissor = (delegate* unmanaged<GLint, GLint, GLsizei, GLsizei, void>)GetProcAddress("glScissor");
            //}
            //if (config == null || config.Contains("glScissorArrayv")) {
            //    glScissorArrayv = (delegate* unmanaged<GLuint, GLsizei, GLint[], void>)GetProcAddress("glScissorArrayv");
            //}
            //if (config == null || config.Contains("glScissorArrayvNV")) {
            //    glScissorArrayvNV = (delegate* unmanaged<GLuint, GLsizei, GLint[], void>)GetProcAddress("glScissorArrayvNV");
            //}
            //if (config == null || config.Contains("glScissorArrayvOES")) {
            //    glScissorArrayvOES = (delegate* unmanaged<GLuint, GLsizei, GLint[], void>)GetProcAddress("glScissorArrayvOES");
            //}
            //if (config == null || config.Contains("glScissorExclusiveArrayvNV")) {
            //    glScissorExclusiveArrayvNV = (delegate* unmanaged<GLuint, GLsizei, GLint[], void>)GetProcAddress("glScissorExclusiveArrayvNV");
            //}
            //if (config == null || config.Contains("glScissorExclusiveNV")) {
            //    glScissorExclusiveNV = (delegate* unmanaged<GLint, GLint, GLsizei, GLsizei, void>)GetProcAddress("glScissorExclusiveNV");
            //}
            //if (config == null || config.Contains("glScissorIndexed")) {
            //    glScissorIndexed = (delegate* unmanaged<GLuint, GLint, GLint, GLsizei, GLsizei, void>)GetProcAddress("glScissorIndexed");
            //}
            //if (config == null || config.Contains("glScissorIndexedNV")) {
            //    glScissorIndexedNV = (delegate* unmanaged<GLuint, GLint, GLint, GLsizei, GLsizei, void>)GetProcAddress("glScissorIndexedNV");
            //}
            //if (config == null || config.Contains("glScissorIndexedOES")) {
            //    glScissorIndexedOES = (delegate* unmanaged<GLuint, GLint, GLint, GLsizei, GLsizei, void>)GetProcAddress("glScissorIndexedOES");
            //}
            //if (config == null || config.Contains("glScissorIndexedv")) {
            //    glScissorIndexedv = (delegate* unmanaged<GLuint, GLint[], void>)GetProcAddress("glScissorIndexedv");
            //}
            //if (config == null || config.Contains("glScissorIndexedvNV")) {
            //    glScissorIndexedvNV = (delegate* unmanaged<GLuint, GLint[], void>)GetProcAddress("glScissorIndexedvNV");
            //}
            //if (config == null || config.Contains("glScissorIndexedvOES")) {
            //    glScissorIndexedvOES = (delegate* unmanaged<GLuint, GLint[], void>)GetProcAddress("glScissorIndexedvOES");
            //}
            //if (config == null || config.Contains("glSecondaryColor3b")) {
            //    glSecondaryColor3b = (delegate* unmanaged<GLbyte, GLbyte, GLbyte, void>)GetProcAddress("glSecondaryColor3b");
            //}
            //if (config == null || config.Contains("glSecondaryColor3bEXT")) {
            //    glSecondaryColor3bEXT = (delegate* unmanaged<GLbyte, GLbyte, GLbyte, void>)GetProcAddress("glSecondaryColor3bEXT");
            //}
            //if (config == null || config.Contains("glSecondaryColor3bv")) {
            //    glSecondaryColor3bv = (delegate* unmanaged<GLbyte[], void>)GetProcAddress("glSecondaryColor3bv");
            //}
            //if (config == null || config.Contains("glSecondaryColor3bvEXT")) {
            //    glSecondaryColor3bvEXT = (delegate* unmanaged<GLbyte[], void>)GetProcAddress("glSecondaryColor3bvEXT");
            //}
            //if (config == null || config.Contains("glSecondaryColor3d")) {
            //    glSecondaryColor3d = (delegate* unmanaged<GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glSecondaryColor3d");
            //}
            //if (config == null || config.Contains("glSecondaryColor3dEXT")) {
            //    glSecondaryColor3dEXT = (delegate* unmanaged<GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glSecondaryColor3dEXT");
            //}
            //if (config == null || config.Contains("glSecondaryColor3dv")) {
            //    glSecondaryColor3dv = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glSecondaryColor3dv");
            //}
            //if (config == null || config.Contains("glSecondaryColor3dvEXT")) {
            //    glSecondaryColor3dvEXT = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glSecondaryColor3dvEXT");
            //}
            //if (config == null || config.Contains("glSecondaryColor3f")) {
            //    glSecondaryColor3f = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glSecondaryColor3f");
            //}
            //if (config == null || config.Contains("glSecondaryColor3fEXT")) {
            //    glSecondaryColor3fEXT = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glSecondaryColor3fEXT");
            //}
            //if (config == null || config.Contains("glSecondaryColor3fv")) {
            //    glSecondaryColor3fv = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glSecondaryColor3fv");
            //}
            //if (config == null || config.Contains("glSecondaryColor3fvEXT")) {
            //    glSecondaryColor3fvEXT = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glSecondaryColor3fvEXT");
            //}
            //if (config == null || config.Contains("glSecondaryColor3hNV")) {
            //    glSecondaryColor3hNV = (delegate* unmanaged<GLhalfNV, GLhalfNV, GLhalfNV, void>)GetProcAddress("glSecondaryColor3hNV");
            //}
            //if (config == null || config.Contains("glSecondaryColor3hvNV")) {
            //    glSecondaryColor3hvNV = (delegate* unmanaged<GLhalfNV[], void>)GetProcAddress("glSecondaryColor3hvNV");
            //}
            //if (config == null || config.Contains("glSecondaryColor3i")) {
            //    glSecondaryColor3i = (delegate* unmanaged<GLint, GLint, GLint, void>)GetProcAddress("glSecondaryColor3i");
            //}
            //if (config == null || config.Contains("glSecondaryColor3iEXT")) {
            //    glSecondaryColor3iEXT = (delegate* unmanaged<GLint, GLint, GLint, void>)GetProcAddress("glSecondaryColor3iEXT");
            //}
            //if (config == null || config.Contains("glSecondaryColor3iv")) {
            //    glSecondaryColor3iv = (delegate* unmanaged<GLint[], void>)GetProcAddress("glSecondaryColor3iv");
            //}
            //if (config == null || config.Contains("glSecondaryColor3ivEXT")) {
            //    glSecondaryColor3ivEXT = (delegate* unmanaged<GLint[], void>)GetProcAddress("glSecondaryColor3ivEXT");
            //}
            //if (config == null || config.Contains("glSecondaryColor3s")) {
            //    glSecondaryColor3s = (delegate* unmanaged<GLshort, GLshort, GLshort, void>)GetProcAddress("glSecondaryColor3s");
            //}
            //if (config == null || config.Contains("glSecondaryColor3sEXT")) {
            //    glSecondaryColor3sEXT = (delegate* unmanaged<GLshort, GLshort, GLshort, void>)GetProcAddress("glSecondaryColor3sEXT");
            //}
            //if (config == null || config.Contains("glSecondaryColor3sv")) {
            //    glSecondaryColor3sv = (delegate* unmanaged<GLshort[], void>)GetProcAddress("glSecondaryColor3sv");
            //}
            //if (config == null || config.Contains("glSecondaryColor3svEXT")) {
            //    glSecondaryColor3svEXT = (delegate* unmanaged<GLshort[], void>)GetProcAddress("glSecondaryColor3svEXT");
            //}
            //if (config == null || config.Contains("glSecondaryColor3ub")) {
            //    glSecondaryColor3ub = (delegate* unmanaged<GLubyte, GLubyte, GLubyte, void>)GetProcAddress("glSecondaryColor3ub");
            //}
            //if (config == null || config.Contains("glSecondaryColor3ubEXT")) {
            //    glSecondaryColor3ubEXT = (delegate* unmanaged<GLubyte, GLubyte, GLubyte, void>)GetProcAddress("glSecondaryColor3ubEXT");
            //}
            //if (config == null || config.Contains("glSecondaryColor3ubv")) {
            //    glSecondaryColor3ubv = (delegate* unmanaged<GLubyte[], void>)GetProcAddress("glSecondaryColor3ubv");
            //}
            //if (config == null || config.Contains("glSecondaryColor3ubvEXT")) {
            //    glSecondaryColor3ubvEXT = (delegate* unmanaged<GLubyte[], void>)GetProcAddress("glSecondaryColor3ubvEXT");
            //}
            //if (config == null || config.Contains("glSecondaryColor3ui")) {
            //    glSecondaryColor3ui = (delegate* unmanaged<GLuint, GLuint, GLuint, void>)GetProcAddress("glSecondaryColor3ui");
            //}
            //if (config == null || config.Contains("glSecondaryColor3uiEXT")) {
            //    glSecondaryColor3uiEXT = (delegate* unmanaged<GLuint, GLuint, GLuint, void>)GetProcAddress("glSecondaryColor3uiEXT");
            //}
            //if (config == null || config.Contains("glSecondaryColor3uiv")) {
            //    glSecondaryColor3uiv = (delegate* unmanaged<GLuint[], void>)GetProcAddress("glSecondaryColor3uiv");
            //}
            //if (config == null || config.Contains("glSecondaryColor3uivEXT")) {
            //    glSecondaryColor3uivEXT = (delegate* unmanaged<GLuint[], void>)GetProcAddress("glSecondaryColor3uivEXT");
            //}
            //if (config == null || config.Contains("glSecondaryColor3us")) {
            //    glSecondaryColor3us = (delegate* unmanaged<GLushort, GLushort, GLushort, void>)GetProcAddress("glSecondaryColor3us");
            //}
            //if (config == null || config.Contains("glSecondaryColor3usEXT")) {
            //    glSecondaryColor3usEXT = (delegate* unmanaged<GLushort, GLushort, GLushort, void>)GetProcAddress("glSecondaryColor3usEXT");
            //}
            //if (config == null || config.Contains("glSecondaryColor3usv")) {
            //    glSecondaryColor3usv = (delegate* unmanaged<GLushort[], void>)GetProcAddress("glSecondaryColor3usv");
            //}
            //if (config == null || config.Contains("glSecondaryColor3usvEXT")) {
            //    glSecondaryColor3usvEXT = (delegate* unmanaged<GLushort[], void>)GetProcAddress("glSecondaryColor3usvEXT");
            //}
            //if (config == null || config.Contains("glSecondaryColorFormatNV")) {
            //    glSecondaryColorFormatNV = (delegate* unmanaged<GLint, GLenum, GLsizei, void>)GetProcAddress("glSecondaryColorFormatNV");
            //}
            //if (config == null || config.Contains("glSecondaryColorP3ui")) {
            //    glSecondaryColorP3ui = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glSecondaryColorP3ui");
            //}
            //if (config == null || config.Contains("glSecondaryColorP3uiv")) {
            //    glSecondaryColorP3uiv = (delegate* unmanaged<GLenum, GLuint[], void>)GetProcAddress("glSecondaryColorP3uiv");
            //}
            //if (config == null || config.Contains("glSecondaryColorPointer")) {
            //    glSecondaryColorPointer = (delegate* unmanaged<GLint, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glSecondaryColorPointer");
            //}
            //if (config == null || config.Contains("glSecondaryColorPointerEXT")) {
            //    glSecondaryColorPointerEXT = (delegate* unmanaged<GLint, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glSecondaryColorPointerEXT");
            //}
            //if (config == null || config.Contains("glSecondaryColorPointerListIBM")) {
            //    glSecondaryColorPointerListIBM = (delegate* unmanaged<GLint, GLenum, GLint, IntPtr, GLint, void>)GetProcAddress("glSecondaryColorPointerListIBM");
            //}
            //if (config == null || config.Contains("glSelectBuffer")) {
            //    glSelectBuffer = (delegate* unmanaged<GLsizei, GLuint[], void>)GetProcAddress("glSelectBuffer");
            //}
            //if (config == null || config.Contains("glSelectPerfMonitorCountersAMD")) {
            //    glSelectPerfMonitorCountersAMD = (delegate* unmanaged<GLuint, GLboolean, GLuint, GLint, GLuint[], void>)GetProcAddress("glSelectPerfMonitorCountersAMD");
            //}
            //if (config == null || config.Contains("glSemaphoreParameterui64vEXT")) {
            //    glSemaphoreParameterui64vEXT = (delegate* unmanaged<GLuint, GLenum, GLuint64[], void>)GetProcAddress("glSemaphoreParameterui64vEXT");
            //}
            //if (config == null || config.Contains("glSeparableFilter2D")) {
            //    glSeparableFilter2D = (delegate* unmanaged<GLenum, GLenum, GLsizei, GLsizei, GLenum, GLenum, IntPtr, IntPtr, void>)GetProcAddress("glSeparableFilter2D");
            //}
            //if (config == null || config.Contains("glSeparableFilter2DEXT")) {
            //    glSeparableFilter2DEXT = (delegate* unmanaged<GLenum, GLenum, GLsizei, GLsizei, GLenum, GLenum, IntPtr, IntPtr, void>)GetProcAddress("glSeparableFilter2DEXT");
            //}
            //if (config == null || config.Contains("glSetFenceAPPLE")) {
            //    glSetFenceAPPLE = (delegate* unmanaged<GLuint, void>)GetProcAddress("glSetFenceAPPLE");
            //}
            //if (config == null || config.Contains("glSetFenceNV")) {
            //    glSetFenceNV = (delegate* unmanaged<GLuint, GLenum, void>)GetProcAddress("glSetFenceNV");
            //}
            //if (config == null || config.Contains("glSetFragmentShaderConstantATI")) {
            //    glSetFragmentShaderConstantATI = (delegate* unmanaged<GLuint, GLfloat[], void>)GetProcAddress("glSetFragmentShaderConstantATI");
            //}
            //if (config == null || config.Contains("glSetInvariantEXT")) {
            //    glSetInvariantEXT = (delegate* unmanaged<GLuint, GLenum, IntPtr, void>)GetProcAddress("glSetInvariantEXT");
            //}
            //if (config == null || config.Contains("glSetLocalConstantEXT")) {
            //    glSetLocalConstantEXT = (delegate* unmanaged<GLuint, GLenum, IntPtr, void>)GetProcAddress("glSetLocalConstantEXT");
            //}
            //if (config == null || config.Contains("glSetMultisamplefvAMD")) {
            //    glSetMultisamplefvAMD = (delegate* unmanaged<GLenum, GLuint, GLfloat[], void>)GetProcAddress("glSetMultisamplefvAMD");
            //}
            //if (config == null || config.Contains("glShadeModel")) {
            //    glShadeModel = (delegate* unmanaged<GLenum, void>)GetProcAddress("glShadeModel");
            //}
            //if (config == null || config.Contains("glShaderBinary")) {
            //    glShaderBinary = (delegate* unmanaged<GLsizei, GLuint[], GLenum, IntPtr, GLsizei, void>)GetProcAddress("glShaderBinary");
            //}
            //if (config == null || config.Contains("glShaderOp1EXT")) {
            //    glShaderOp1EXT = (delegate* unmanaged<GLenum, GLuint, GLuint, void>)GetProcAddress("glShaderOp1EXT");
            //}
            //if (config == null || config.Contains("glShaderOp2EXT")) {
            //    glShaderOp2EXT = (delegate* unmanaged<GLenum, GLuint, GLuint, GLuint, void>)GetProcAddress("glShaderOp2EXT");
            //}
            //if (config == null || config.Contains("glShaderOp3EXT")) {
            //    glShaderOp3EXT = (delegate* unmanaged<GLenum, GLuint, GLuint, GLuint, GLuint, void>)GetProcAddress("glShaderOp3EXT");
            //}
            //if (config == null || config.Contains("glShaderSource")) {
            //    glShaderSource = (delegate* unmanaged<GLuint, GLsizei, string[], GLint[], void>)GetProcAddress("glShaderSource");
            //}
            //if (config == null || config.Contains("glShaderSourceARB")) {
            //    glShaderSourceARB = (delegate* unmanaged<GLhandleARB, GLsizei, string[], GLint[], void>)GetProcAddress("glShaderSourceARB");
            //}
            //if (config == null || config.Contains("glShaderStorageBlockBinding")) {
            //    glShaderStorageBlockBinding = (delegate* unmanaged<GLuint, GLuint, GLuint, void>)GetProcAddress("glShaderStorageBlockBinding");
            //}
            //if (config == null || config.Contains("glShadingRateImageBarrierNV")) {
            //    glShadingRateImageBarrierNV = (delegate* unmanaged<GLboolean, void>)GetProcAddress("glShadingRateImageBarrierNV");
            //}
            //if (config == null || config.Contains("glShadingRateImagePaletteNV")) {
            //    glShadingRateImagePaletteNV = (delegate* unmanaged<GLuint, GLuint, GLsizei, GLenum[], void>)GetProcAddress("glShadingRateImagePaletteNV");
            //}
            //if (config == null || config.Contains("glShadingRateSampleOrderNV")) {
            //    glShadingRateSampleOrderNV = (delegate* unmanaged<GLenum, void>)GetProcAddress("glShadingRateSampleOrderNV");
            //}
            //if (config == null || config.Contains("glShadingRateSampleOrderCustomNV")) {
            //    glShadingRateSampleOrderCustomNV = (delegate* unmanaged<GLenum, GLuint, GLint[], void>)GetProcAddress("glShadingRateSampleOrderCustomNV");
            //}
            //if (config == null || config.Contains("glSharpenTexFuncSGIS")) {
            //    glSharpenTexFuncSGIS = (delegate* unmanaged<GLenum, GLsizei, GLfloat[], void>)GetProcAddress("glSharpenTexFuncSGIS");
            //}
            //if (config == null || config.Contains("glSignalSemaphoreEXT")) {
            //    glSignalSemaphoreEXT = (delegate* unmanaged<GLuint, GLuint, GLuint[], GLuint, GLuint[], GLenum[], void>)GetProcAddress("glSignalSemaphoreEXT");
            //}
            //if (config == null || config.Contains("glSignalSemaphoreui64NVX")) {
            //    glSignalSemaphoreui64NVX = (delegate* unmanaged<GLuint, GLsizei, GLuint[], GLuint64[], void>)GetProcAddress("glSignalSemaphoreui64NVX");
            //}
            //if (config == null || config.Contains("glSpecializeShader")) {
            //    glSpecializeShader = (delegate* unmanaged<GLuint, string, GLuint, GLuint[], GLuint[], void>)GetProcAddress("glSpecializeShader");
            //}
            //if (config == null || config.Contains("glSpecializeShaderARB")) {
            //    glSpecializeShaderARB = (delegate* unmanaged<GLuint, string, GLuint, GLuint[], GLuint[], void>)GetProcAddress("glSpecializeShaderARB");
            //}
            //if (config == null || config.Contains("glSpriteParameterfSGIX")) {
            //    glSpriteParameterfSGIX = (delegate* unmanaged<GLenum, GLfloat, void>)GetProcAddress("glSpriteParameterfSGIX");
            //}
            //if (config == null || config.Contains("glSpriteParameterfvSGIX")) {
            //    glSpriteParameterfvSGIX = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glSpriteParameterfvSGIX");
            //}
            //if (config == null || config.Contains("glSpriteParameteriSGIX")) {
            //    glSpriteParameteriSGIX = (delegate* unmanaged<GLenum, GLint, void>)GetProcAddress("glSpriteParameteriSGIX");
            //}
            //if (config == null || config.Contains("glSpriteParameterivSGIX")) {
            //    glSpriteParameterivSGIX = (delegate* unmanaged<GLenum, GLint[], void>)GetProcAddress("glSpriteParameterivSGIX");
            //}
            //if (config == null || config.Contains("glStartInstrumentsSGIX")) {
            //    glStartInstrumentsSGIX = (delegate* unmanaged<void>)GetProcAddress("glStartInstrumentsSGIX");
            //}
            //if (config == null || config.Contains("glStartTilingQCOM")) {
            //    glStartTilingQCOM = (delegate* unmanaged<GLuint, GLuint, GLuint, GLuint, GLbitfield, void>)GetProcAddress("glStartTilingQCOM");
            //}
            //if (config == null || config.Contains("glStateCaptureNV")) {
            //    glStateCaptureNV = (delegate* unmanaged<GLuint, GLenum, void>)GetProcAddress("glStateCaptureNV");
            //}
            //if (config == null || config.Contains("glStencilClearTagEXT")) {
            //    glStencilClearTagEXT = (delegate* unmanaged<GLsizei, GLuint, void>)GetProcAddress("glStencilClearTagEXT");
            //}
            //if (config == null || config.Contains("glStencilFillPathInstancedNV")) {
            //    glStencilFillPathInstancedNV = (delegate* unmanaged<GLsizei, GLenum, IntPtr, GLuint, GLenum, GLuint, GLenum, GLfloat[], void>)GetProcAddress("glStencilFillPathInstancedNV");
            //}
            //if (config == null || config.Contains("glStencilFillPathNV")) {
            //    glStencilFillPathNV = (delegate* unmanaged<GLuint, GLenum, GLuint, void>)GetProcAddress("glStencilFillPathNV");
            //}
            //if (config == null || config.Contains("glStencilFunc")) {
            //    glStencilFunc = (delegate* unmanaged<GLenum, GLint, GLuint, void>)GetProcAddress("glStencilFunc");
            //}
            //if (config == null || config.Contains("glStencilFuncSeparate")) {
            //    glStencilFuncSeparate = (delegate* unmanaged<GLenum, GLenum, GLint, GLuint, void>)GetProcAddress("glStencilFuncSeparate");
            //}
            //if (config == null || config.Contains("glStencilFuncSeparateATI")) {
            //    glStencilFuncSeparateATI = (delegate* unmanaged<GLenum, GLenum, GLint, GLuint, void>)GetProcAddress("glStencilFuncSeparateATI");
            //}
            //if (config == null || config.Contains("glStencilMask")) {
            //    glStencilMask = (delegate* unmanaged<GLuint, void>)GetProcAddress("glStencilMask");
            //}
            //if (config == null || config.Contains("glStencilMaskSeparate")) {
            //    glStencilMaskSeparate = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glStencilMaskSeparate");
            //}
            //if (config == null || config.Contains("glStencilOp")) {
            //    glStencilOp = (delegate* unmanaged<GLenum, GLenum, GLenum, void>)GetProcAddress("glStencilOp");
            //}
            //if (config == null || config.Contains("glStencilOpSeparate")) {
            //    glStencilOpSeparate = (delegate* unmanaged<GLenum, GLenum, GLenum, GLenum, void>)GetProcAddress("glStencilOpSeparate");
            //}
            //if (config == null || config.Contains("glStencilOpSeparateATI")) {
            //    glStencilOpSeparateATI = (delegate* unmanaged<GLenum, GLenum, GLenum, GLenum, void>)GetProcAddress("glStencilOpSeparateATI");
            //}
            //if (config == null || config.Contains("glStencilOpValueAMD")) {
            //    glStencilOpValueAMD = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glStencilOpValueAMD");
            //}
            //if (config == null || config.Contains("glStencilStrokePathInstancedNV")) {
            //    glStencilStrokePathInstancedNV = (delegate* unmanaged<GLsizei, GLenum, IntPtr, GLuint, GLint, GLuint, GLenum, GLfloat[], void>)GetProcAddress("glStencilStrokePathInstancedNV");
            //}
            //if (config == null || config.Contains("glStencilStrokePathNV")) {
            //    glStencilStrokePathNV = (delegate* unmanaged<GLuint, GLint, GLuint, void>)GetProcAddress("glStencilStrokePathNV");
            //}
            //if (config == null || config.Contains("glStencilThenCoverFillPathInstancedNV")) {
            //    glStencilThenCoverFillPathInstancedNV = (delegate* unmanaged<GLsizei, GLenum, IntPtr, GLuint, GLenum, GLuint, GLenum, GLenum, GLfloat[], void>)GetProcAddress("glStencilThenCoverFillPathInstancedNV");
            //}
            //if (config == null || config.Contains("glStencilThenCoverFillPathNV")) {
            //    glStencilThenCoverFillPathNV = (delegate* unmanaged<GLuint, GLenum, GLuint, GLenum, void>)GetProcAddress("glStencilThenCoverFillPathNV");
            //}
            //if (config == null || config.Contains("glStencilThenCoverStrokePathInstancedNV")) {
            //    glStencilThenCoverStrokePathInstancedNV = (delegate* unmanaged<GLsizei, GLenum, IntPtr, GLuint, GLint, GLuint, GLenum, GLenum, GLfloat[], void>)GetProcAddress("glStencilThenCoverStrokePathInstancedNV");
            //}
            //if (config == null || config.Contains("glStencilThenCoverStrokePathNV")) {
            //    glStencilThenCoverStrokePathNV = (delegate* unmanaged<GLuint, GLint, GLuint, GLenum, void>)GetProcAddress("glStencilThenCoverStrokePathNV");
            //}
            //if (config == null || config.Contains("glStopInstrumentsSGIX")) {
            //    glStopInstrumentsSGIX = (delegate* unmanaged<GLint, void>)GetProcAddress("glStopInstrumentsSGIX");
            //}
            //if (config == null || config.Contains("glStringMarkerGREMEDY")) {
            //    glStringMarkerGREMEDY = (delegate* unmanaged<GLsizei, IntPtr, void>)GetProcAddress("glStringMarkerGREMEDY");
            //}
            //if (config == null || config.Contains("glSubpixelPrecisionBiasNV")) {
            //    glSubpixelPrecisionBiasNV = (delegate* unmanaged<GLuint, GLuint, void>)GetProcAddress("glSubpixelPrecisionBiasNV");
            //}
            //if (config == null || config.Contains("glSwizzleEXT")) {
            //    glSwizzleEXT = (delegate* unmanaged<GLuint, GLuint, GLenum, GLenum, GLenum, GLenum, void>)GetProcAddress("glSwizzleEXT");
            //}
            //if (config == null || config.Contains("glSyncTextureINTEL")) {
            //    glSyncTextureINTEL = (delegate* unmanaged<GLuint, void>)GetProcAddress("glSyncTextureINTEL");
            //}
            //if (config == null || config.Contains("glTagSampleBufferSGIX")) {
            //    glTagSampleBufferSGIX = (delegate* unmanaged<void>)GetProcAddress("glTagSampleBufferSGIX");
            //}
            //if (config == null || config.Contains("glTangent3bEXT")) {
            //    glTangent3bEXT = (delegate* unmanaged<GLbyte, GLbyte, GLbyte, void>)GetProcAddress("glTangent3bEXT");
            //}
            //if (config == null || config.Contains("glTangent3bvEXT")) {
            //    glTangent3bvEXT = (delegate* unmanaged<GLbyte[], void>)GetProcAddress("glTangent3bvEXT");
            //}
            //if (config == null || config.Contains("glTangent3dEXT")) {
            //    glTangent3dEXT = (delegate* unmanaged<GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glTangent3dEXT");
            //}
            //if (config == null || config.Contains("glTangent3dvEXT")) {
            //    glTangent3dvEXT = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glTangent3dvEXT");
            //}
            //if (config == null || config.Contains("glTangent3fEXT")) {
            //    glTangent3fEXT = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glTangent3fEXT");
            //}
            //if (config == null || config.Contains("glTangent3fvEXT")) {
            //    glTangent3fvEXT = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glTangent3fvEXT");
            //}
            //if (config == null || config.Contains("glTangent3iEXT")) {
            //    glTangent3iEXT = (delegate* unmanaged<GLint, GLint, GLint, void>)GetProcAddress("glTangent3iEXT");
            //}
            //if (config == null || config.Contains("glTangent3ivEXT")) {
            //    glTangent3ivEXT = (delegate* unmanaged<GLint[], void>)GetProcAddress("glTangent3ivEXT");
            //}
            //if (config == null || config.Contains("glTangent3sEXT")) {
            //    glTangent3sEXT = (delegate* unmanaged<GLshort, GLshort, GLshort, void>)GetProcAddress("glTangent3sEXT");
            //}
            //if (config == null || config.Contains("glTangent3svEXT")) {
            //    glTangent3svEXT = (delegate* unmanaged<GLshort[], void>)GetProcAddress("glTangent3svEXT");
            //}
            //if (config == null || config.Contains("glTangentPointerEXT")) {
            //    glTangentPointerEXT = (delegate* unmanaged<GLenum, GLsizei, IntPtr, void>)GetProcAddress("glTangentPointerEXT");
            //}
            //if (config == null || config.Contains("glTbufferMask3DFX")) {
            //    glTbufferMask3DFX = (delegate* unmanaged<GLuint, void>)GetProcAddress("glTbufferMask3DFX");
            //}
            //if (config == null || config.Contains("glTessellationFactorAMD")) {
            //    glTessellationFactorAMD = (delegate* unmanaged<GLfloat, void>)GetProcAddress("glTessellationFactorAMD");
            //}
            //if (config == null || config.Contains("glTessellationModeAMD")) {
            //    glTessellationModeAMD = (delegate* unmanaged<GLenum, void>)GetProcAddress("glTessellationModeAMD");
            //}
            //if (config == null || config.Contains("glTestFenceAPPLE")) {
            //    glTestFenceAPPLE = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glTestFenceAPPLE");
            //}
            //if (config == null || config.Contains("glTestFenceNV")) {
            //    glTestFenceNV = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glTestFenceNV");
            //}
            //if (config == null || config.Contains("glTestObjectAPPLE")) {
            //    glTestObjectAPPLE = (delegate* unmanaged<GLenum, GLuint, GLboolean>)GetProcAddress("glTestObjectAPPLE");
            //}
            //if (config == null || config.Contains("glTexAttachMemoryNV")) {
            //    glTexAttachMemoryNV = (delegate* unmanaged<GLenum, GLuint, GLuint64, void>)GetProcAddress("glTexAttachMemoryNV");
            //}
            //if (config == null || config.Contains("glTexBuffer")) {
            //    glTexBuffer = (delegate* unmanaged<GLenum, GLenum, GLuint, void>)GetProcAddress("glTexBuffer");
            //}
            //if (config == null || config.Contains("glTexBufferARB")) {
            //    glTexBufferARB = (delegate* unmanaged<GLenum, GLenum, GLuint, void>)GetProcAddress("glTexBufferARB");
            //}
            //if (config == null || config.Contains("glTexBufferEXT")) {
            //    glTexBufferEXT = (delegate* unmanaged<GLenum, GLenum, GLuint, void>)GetProcAddress("glTexBufferEXT");
            //}
            //if (config == null || config.Contains("glTexBufferOES")) {
            //    glTexBufferOES = (delegate* unmanaged<GLenum, GLenum, GLuint, void>)GetProcAddress("glTexBufferOES");
            //}
            //if (config == null || config.Contains("glTexBufferRange")) {
            //    glTexBufferRange = (delegate* unmanaged<GLenum, GLenum, GLuint, GLintptr, GLsizeiptr, void>)GetProcAddress("glTexBufferRange");
            //}
            //if (config == null || config.Contains("glTexBufferRangeEXT")) {
            //    glTexBufferRangeEXT = (delegate* unmanaged<GLenum, GLenum, GLuint, GLintptr, GLsizeiptr, void>)GetProcAddress("glTexBufferRangeEXT");
            //}
            //if (config == null || config.Contains("glTexBufferRangeOES")) {
            //    glTexBufferRangeOES = (delegate* unmanaged<GLenum, GLenum, GLuint, GLintptr, GLsizeiptr, void>)GetProcAddress("glTexBufferRangeOES");
            //}
            //if (config == null || config.Contains("glTexBumpParameterfvATI")) {
            //    glTexBumpParameterfvATI = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glTexBumpParameterfvATI");
            //}
            //if (config == null || config.Contains("glTexBumpParameterivATI")) {
            //    glTexBumpParameterivATI = (delegate* unmanaged<GLenum, GLint[], void>)GetProcAddress("glTexBumpParameterivATI");
            //}
            //if (config == null || config.Contains("glTexCoord1bOES")) {
            //    glTexCoord1bOES = (delegate* unmanaged<GLbyte, void>)GetProcAddress("glTexCoord1bOES");
            //}
            //if (config == null || config.Contains("glTexCoord1bvOES")) {
            //    glTexCoord1bvOES = (delegate* unmanaged<GLbyte[], void>)GetProcAddress("glTexCoord1bvOES");
            //}
            //if (config == null || config.Contains("glTexCoord1d")) {
            //    glTexCoord1d = (delegate* unmanaged<GLdouble, void>)GetProcAddress("glTexCoord1d");
            //}
            //if (config == null || config.Contains("glTexCoord1dv")) {
            //    glTexCoord1dv = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glTexCoord1dv");
            //}
            //if (config == null || config.Contains("glTexCoord1f")) {
            //    glTexCoord1f = (delegate* unmanaged<GLfloat, void>)GetProcAddress("glTexCoord1f");
            //}
            //if (config == null || config.Contains("glTexCoord1fv")) {
            //    glTexCoord1fv = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glTexCoord1fv");
            //}
            //if (config == null || config.Contains("glTexCoord1hNV")) {
            //    glTexCoord1hNV = (delegate* unmanaged<GLhalfNV, void>)GetProcAddress("glTexCoord1hNV");
            //}
            //if (config == null || config.Contains("glTexCoord1hvNV")) {
            //    glTexCoord1hvNV = (delegate* unmanaged<GLhalfNV[], void>)GetProcAddress("glTexCoord1hvNV");
            //}
            //if (config == null || config.Contains("glTexCoord1i")) {
            //    glTexCoord1i = (delegate* unmanaged<GLint, void>)GetProcAddress("glTexCoord1i");
            //}
            //if (config == null || config.Contains("glTexCoord1iv")) {
            //    glTexCoord1iv = (delegate* unmanaged<GLint[], void>)GetProcAddress("glTexCoord1iv");
            //}
            //if (config == null || config.Contains("glTexCoord1s")) {
            //    glTexCoord1s = (delegate* unmanaged<GLshort, void>)GetProcAddress("glTexCoord1s");
            //}
            //if (config == null || config.Contains("glTexCoord1sv")) {
            //    glTexCoord1sv = (delegate* unmanaged<GLshort[], void>)GetProcAddress("glTexCoord1sv");
            //}
            //if (config == null || config.Contains("glTexCoord1xOES")) {
            //    glTexCoord1xOES = (delegate* unmanaged<GLfixed, void>)GetProcAddress("glTexCoord1xOES");
            //}
            //if (config == null || config.Contains("glTexCoord1xvOES")) {
            //    glTexCoord1xvOES = (delegate* unmanaged<GLfixed[], void>)GetProcAddress("glTexCoord1xvOES");
            //}
            //if (config == null || config.Contains("glTexCoord2bOES")) {
            //    glTexCoord2bOES = (delegate* unmanaged<GLbyte, GLbyte, void>)GetProcAddress("glTexCoord2bOES");
            //}
            //if (config == null || config.Contains("glTexCoord2bvOES")) {
            //    glTexCoord2bvOES = (delegate* unmanaged<GLbyte[], void>)GetProcAddress("glTexCoord2bvOES");
            //}
            //if (config == null || config.Contains("glTexCoord2d")) {
            //    glTexCoord2d = (delegate* unmanaged<GLdouble, GLdouble, void>)GetProcAddress("glTexCoord2d");
            //}
            //if (config == null || config.Contains("glTexCoord2dv")) {
            //    glTexCoord2dv = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glTexCoord2dv");
            //}
            //if (config == null || config.Contains("glTexCoord2f")) {
            //    glTexCoord2f = (delegate* unmanaged<GLfloat, GLfloat, void>)GetProcAddress("glTexCoord2f");
            //}
            //if (config == null || config.Contains("glTexCoord2fColor3fVertex3fSUN")) {
            //    glTexCoord2fColor3fVertex3fSUN = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glTexCoord2fColor3fVertex3fSUN");
            //}
            //if (config == null || config.Contains("glTexCoord2fColor3fVertex3fvSUN")) {
            //    glTexCoord2fColor3fVertex3fvSUN = (delegate* unmanaged<GLfloat[], GLfloat[], GLfloat[], void>)GetProcAddress("glTexCoord2fColor3fVertex3fvSUN");
            //}
            //if (config == null || config.Contains("glTexCoord2fColor4fNormal3fVertex3fSUN")) {
            //    glTexCoord2fColor4fNormal3fVertex3fSUN = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glTexCoord2fColor4fNormal3fVertex3fSUN");
            //}
            //if (config == null || config.Contains("glTexCoord2fColor4fNormal3fVertex3fvSUN")) {
            //    glTexCoord2fColor4fNormal3fVertex3fvSUN = (delegate* unmanaged<GLfloat[], GLfloat[], GLfloat[], GLfloat[], void>)GetProcAddress("glTexCoord2fColor4fNormal3fVertex3fvSUN");
            //}
            //if (config == null || config.Contains("glTexCoord2fColor4ubVertex3fSUN")) {
            //    glTexCoord2fColor4ubVertex3fSUN = (delegate* unmanaged<GLfloat, GLfloat, GLubyte, GLubyte, GLubyte, GLubyte, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glTexCoord2fColor4ubVertex3fSUN");
            //}
            //if (config == null || config.Contains("glTexCoord2fColor4ubVertex3fvSUN")) {
            //    glTexCoord2fColor4ubVertex3fvSUN = (delegate* unmanaged<GLfloat[], GLubyte[], GLfloat[], void>)GetProcAddress("glTexCoord2fColor4ubVertex3fvSUN");
            //}
            //if (config == null || config.Contains("glTexCoord2fNormal3fVertex3fSUN")) {
            //    glTexCoord2fNormal3fVertex3fSUN = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glTexCoord2fNormal3fVertex3fSUN");
            //}
            //if (config == null || config.Contains("glTexCoord2fNormal3fVertex3fvSUN")) {
            //    glTexCoord2fNormal3fVertex3fvSUN = (delegate* unmanaged<GLfloat[], GLfloat[], GLfloat[], void>)GetProcAddress("glTexCoord2fNormal3fVertex3fvSUN");
            //}
            //if (config == null || config.Contains("glTexCoord2fVertex3fSUN")) {
            //    glTexCoord2fVertex3fSUN = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glTexCoord2fVertex3fSUN");
            //}
            //if (config == null || config.Contains("glTexCoord2fVertex3fvSUN")) {
            //    glTexCoord2fVertex3fvSUN = (delegate* unmanaged<GLfloat[], GLfloat[], void>)GetProcAddress("glTexCoord2fVertex3fvSUN");
            //}
            //if (config == null || config.Contains("glTexCoord2fv")) {
            //    glTexCoord2fv = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glTexCoord2fv");
            //}
            //if (config == null || config.Contains("glTexCoord2hNV")) {
            //    glTexCoord2hNV = (delegate* unmanaged<GLhalfNV, GLhalfNV, void>)GetProcAddress("glTexCoord2hNV");
            //}
            //if (config == null || config.Contains("glTexCoord2hvNV")) {
            //    glTexCoord2hvNV = (delegate* unmanaged<GLhalfNV[], void>)GetProcAddress("glTexCoord2hvNV");
            //}
            //if (config == null || config.Contains("glTexCoord2i")) {
            //    glTexCoord2i = (delegate* unmanaged<GLint, GLint, void>)GetProcAddress("glTexCoord2i");
            //}
            //if (config == null || config.Contains("glTexCoord2iv")) {
            //    glTexCoord2iv = (delegate* unmanaged<GLint[], void>)GetProcAddress("glTexCoord2iv");
            //}
            //if (config == null || config.Contains("glTexCoord2s")) {
            //    glTexCoord2s = (delegate* unmanaged<GLshort, GLshort, void>)GetProcAddress("glTexCoord2s");
            //}
            //if (config == null || config.Contains("glTexCoord2sv")) {
            //    glTexCoord2sv = (delegate* unmanaged<GLshort[], void>)GetProcAddress("glTexCoord2sv");
            //}
            //if (config == null || config.Contains("glTexCoord2xOES")) {
            //    glTexCoord2xOES = (delegate* unmanaged<GLfixed, GLfixed, void>)GetProcAddress("glTexCoord2xOES");
            //}
            //if (config == null || config.Contains("glTexCoord2xvOES")) {
            //    glTexCoord2xvOES = (delegate* unmanaged<GLfixed[], void>)GetProcAddress("glTexCoord2xvOES");
            //}
            //if (config == null || config.Contains("glTexCoord3bOES")) {
            //    glTexCoord3bOES = (delegate* unmanaged<GLbyte, GLbyte, GLbyte, void>)GetProcAddress("glTexCoord3bOES");
            //}
            //if (config == null || config.Contains("glTexCoord3bvOES")) {
            //    glTexCoord3bvOES = (delegate* unmanaged<GLbyte[], void>)GetProcAddress("glTexCoord3bvOES");
            //}
            //if (config == null || config.Contains("glTexCoord3d")) {
            //    glTexCoord3d = (delegate* unmanaged<GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glTexCoord3d");
            //}
            //if (config == null || config.Contains("glTexCoord3dv")) {
            //    glTexCoord3dv = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glTexCoord3dv");
            //}
            //if (config == null || config.Contains("glTexCoord3f")) {
            //    glTexCoord3f = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glTexCoord3f");
            //}
            //if (config == null || config.Contains("glTexCoord3fv")) {
            //    glTexCoord3fv = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glTexCoord3fv");
            //}
            //if (config == null || config.Contains("glTexCoord3hNV")) {
            //    glTexCoord3hNV = (delegate* unmanaged<GLhalfNV, GLhalfNV, GLhalfNV, void>)GetProcAddress("glTexCoord3hNV");
            //}
            //if (config == null || config.Contains("glTexCoord3hvNV")) {
            //    glTexCoord3hvNV = (delegate* unmanaged<GLhalfNV[], void>)GetProcAddress("glTexCoord3hvNV");
            //}
            //if (config == null || config.Contains("glTexCoord3i")) {
            //    glTexCoord3i = (delegate* unmanaged<GLint, GLint, GLint, void>)GetProcAddress("glTexCoord3i");
            //}
            //if (config == null || config.Contains("glTexCoord3iv")) {
            //    glTexCoord3iv = (delegate* unmanaged<GLint[], void>)GetProcAddress("glTexCoord3iv");
            //}
            //if (config == null || config.Contains("glTexCoord3s")) {
            //    glTexCoord3s = (delegate* unmanaged<GLshort, GLshort, GLshort, void>)GetProcAddress("glTexCoord3s");
            //}
            //if (config == null || config.Contains("glTexCoord3sv")) {
            //    glTexCoord3sv = (delegate* unmanaged<GLshort[], void>)GetProcAddress("glTexCoord3sv");
            //}
            //if (config == null || config.Contains("glTexCoord3xOES")) {
            //    glTexCoord3xOES = (delegate* unmanaged<GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glTexCoord3xOES");
            //}
            //if (config == null || config.Contains("glTexCoord3xvOES")) {
            //    glTexCoord3xvOES = (delegate* unmanaged<GLfixed[], void>)GetProcAddress("glTexCoord3xvOES");
            //}
            //if (config == null || config.Contains("glTexCoord4bOES")) {
            //    glTexCoord4bOES = (delegate* unmanaged<GLbyte, GLbyte, GLbyte, GLbyte, void>)GetProcAddress("glTexCoord4bOES");
            //}
            //if (config == null || config.Contains("glTexCoord4bvOES")) {
            //    glTexCoord4bvOES = (delegate* unmanaged<GLbyte[], void>)GetProcAddress("glTexCoord4bvOES");
            //}
            //if (config == null || config.Contains("glTexCoord4d")) {
            //    glTexCoord4d = (delegate* unmanaged<GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glTexCoord4d");
            //}
            //if (config == null || config.Contains("glTexCoord4dv")) {
            //    glTexCoord4dv = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glTexCoord4dv");
            //}
            //if (config == null || config.Contains("glTexCoord4f")) {
            //    glTexCoord4f = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glTexCoord4f");
            //}
            //if (config == null || config.Contains("glTexCoord4fColor4fNormal3fVertex4fSUN")) {
            //    glTexCoord4fColor4fNormal3fVertex4fSUN = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glTexCoord4fColor4fNormal3fVertex4fSUN");
            //}
            //if (config == null || config.Contains("glTexCoord4fColor4fNormal3fVertex4fvSUN")) {
            //    glTexCoord4fColor4fNormal3fVertex4fvSUN = (delegate* unmanaged<GLfloat[], GLfloat[], GLfloat[], GLfloat[], void>)GetProcAddress("glTexCoord4fColor4fNormal3fVertex4fvSUN");
            //}
            //if (config == null || config.Contains("glTexCoord4fVertex4fSUN")) {
            //    glTexCoord4fVertex4fSUN = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glTexCoord4fVertex4fSUN");
            //}
            //if (config == null || config.Contains("glTexCoord4fVertex4fvSUN")) {
            //    glTexCoord4fVertex4fvSUN = (delegate* unmanaged<GLfloat[], GLfloat[], void>)GetProcAddress("glTexCoord4fVertex4fvSUN");
            //}
            //if (config == null || config.Contains("glTexCoord4fv")) {
            //    glTexCoord4fv = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glTexCoord4fv");
            //}
            //if (config == null || config.Contains("glTexCoord4hNV")) {
            //    glTexCoord4hNV = (delegate* unmanaged<GLhalfNV, GLhalfNV, GLhalfNV, GLhalfNV, void>)GetProcAddress("glTexCoord4hNV");
            //}
            //if (config == null || config.Contains("glTexCoord4hvNV")) {
            //    glTexCoord4hvNV = (delegate* unmanaged<GLhalfNV[], void>)GetProcAddress("glTexCoord4hvNV");
            //}
            //if (config == null || config.Contains("glTexCoord4i")) {
            //    glTexCoord4i = (delegate* unmanaged<GLint, GLint, GLint, GLint, void>)GetProcAddress("glTexCoord4i");
            //}
            //if (config == null || config.Contains("glTexCoord4iv")) {
            //    glTexCoord4iv = (delegate* unmanaged<GLint[], void>)GetProcAddress("glTexCoord4iv");
            //}
            //if (config == null || config.Contains("glTexCoord4s")) {
            //    glTexCoord4s = (delegate* unmanaged<GLshort, GLshort, GLshort, GLshort, void>)GetProcAddress("glTexCoord4s");
            //}
            //if (config == null || config.Contains("glTexCoord4sv")) {
            //    glTexCoord4sv = (delegate* unmanaged<GLshort[], void>)GetProcAddress("glTexCoord4sv");
            //}
            //if (config == null || config.Contains("glTexCoord4xOES")) {
            //    glTexCoord4xOES = (delegate* unmanaged<GLfixed, GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glTexCoord4xOES");
            //}
            //if (config == null || config.Contains("glTexCoord4xvOES")) {
            //    glTexCoord4xvOES = (delegate* unmanaged<GLfixed[], void>)GetProcAddress("glTexCoord4xvOES");
            //}
            //if (config == null || config.Contains("glTexCoordFormatNV")) {
            //    glTexCoordFormatNV = (delegate* unmanaged<GLint, GLenum, GLsizei, void>)GetProcAddress("glTexCoordFormatNV");
            //}
            //if (config == null || config.Contains("glTexCoordP1ui")) {
            //    glTexCoordP1ui = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glTexCoordP1ui");
            //}
            //if (config == null || config.Contains("glTexCoordP1uiv")) {
            //    glTexCoordP1uiv = (delegate* unmanaged<GLenum, GLuint[], void>)GetProcAddress("glTexCoordP1uiv");
            //}
            //if (config == null || config.Contains("glTexCoordP2ui")) {
            //    glTexCoordP2ui = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glTexCoordP2ui");
            //}
            //if (config == null || config.Contains("glTexCoordP2uiv")) {
            //    glTexCoordP2uiv = (delegate* unmanaged<GLenum, GLuint[], void>)GetProcAddress("glTexCoordP2uiv");
            //}
            //if (config == null || config.Contains("glTexCoordP3ui")) {
            //    glTexCoordP3ui = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glTexCoordP3ui");
            //}
            //if (config == null || config.Contains("glTexCoordP3uiv")) {
            //    glTexCoordP3uiv = (delegate* unmanaged<GLenum, GLuint[], void>)GetProcAddress("glTexCoordP3uiv");
            //}
            //if (config == null || config.Contains("glTexCoordP4ui")) {
            //    glTexCoordP4ui = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glTexCoordP4ui");
            //}
            //if (config == null || config.Contains("glTexCoordP4uiv")) {
            //    glTexCoordP4uiv = (delegate* unmanaged<GLenum, GLuint[], void>)GetProcAddress("glTexCoordP4uiv");
            //}
            //if (config == null || config.Contains("glTexCoordPointer")) {
            //    glTexCoordPointer = (delegate* unmanaged<GLint, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glTexCoordPointer");
            //}
            //if (config == null || config.Contains("glTexCoordPointerEXT")) {
            //    glTexCoordPointerEXT = (delegate* unmanaged<GLint, GLenum, GLsizei, GLsizei, IntPtr, void>)GetProcAddress("glTexCoordPointerEXT");
            //}
            //if (config == null || config.Contains("glTexCoordPointerListIBM")) {
            //    glTexCoordPointerListIBM = (delegate* unmanaged<GLint, GLenum, GLint, IntPtr, GLint, void>)GetProcAddress("glTexCoordPointerListIBM");
            //}
            //if (config == null || config.Contains("glTexCoordPointervINTEL")) {
            //    glTexCoordPointervINTEL = (delegate* unmanaged<GLint, GLenum, IntPtr, void>)GetProcAddress("glTexCoordPointervINTEL");
            //}
            //if (config == null || config.Contains("glTexEnvf")) {
            //    glTexEnvf = (delegate* unmanaged<GLenum, GLenum, GLfloat, void>)GetProcAddress("glTexEnvf");
            //}
            //if (config == null || config.Contains("glTexEnvfv")) {
            //    glTexEnvfv = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glTexEnvfv");
            //}
            //if (config == null || config.Contains("glTexEnvi")) {
            //    glTexEnvi = (delegate* unmanaged<GLenum, GLenum, GLint, void>)GetProcAddress("glTexEnvi");
            //}
            //if (config == null || config.Contains("glTexEnviv")) {
            //    glTexEnviv = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glTexEnviv");
            //}
            //if (config == null || config.Contains("glTexEnvx")) {
            //    glTexEnvx = (delegate* unmanaged<GLenum, GLenum, GLfixed, void>)GetProcAddress("glTexEnvx");
            //}
            //if (config == null || config.Contains("glTexEnvxOES")) {
            //    glTexEnvxOES = (delegate* unmanaged<GLenum, GLenum, GLfixed, void>)GetProcAddress("glTexEnvxOES");
            //}
            //if (config == null || config.Contains("glTexEnvxv")) {
            //    glTexEnvxv = (delegate* unmanaged<GLenum, GLenum, GLfixed[], void>)GetProcAddress("glTexEnvxv");
            //}
            //if (config == null || config.Contains("glTexEnvxvOES")) {
            //    glTexEnvxvOES = (delegate* unmanaged<GLenum, GLenum, GLfixed[], void>)GetProcAddress("glTexEnvxvOES");
            //}
            //if (config == null || config.Contains("glTexFilterFuncSGIS")) {
            //    glTexFilterFuncSGIS = (delegate* unmanaged<GLenum, GLenum, GLsizei, GLfloat[], void>)GetProcAddress("glTexFilterFuncSGIS");
            //}
            //if (config == null || config.Contains("glTexGend")) {
            //    glTexGend = (delegate* unmanaged<GLenum, GLenum, GLdouble, void>)GetProcAddress("glTexGend");
            //}
            //if (config == null || config.Contains("glTexGendv")) {
            //    glTexGendv = (delegate* unmanaged<GLenum, GLenum, GLdouble[], void>)GetProcAddress("glTexGendv");
            //}
            //if (config == null || config.Contains("glTexGenf")) {
            //    glTexGenf = (delegate* unmanaged<GLenum, GLenum, GLfloat, void>)GetProcAddress("glTexGenf");
            //}
            //if (config == null || config.Contains("glTexGenfOES")) {
            //    glTexGenfOES = (delegate* unmanaged<GLenum, GLenum, GLfloat, void>)GetProcAddress("glTexGenfOES");
            //}
            //if (config == null || config.Contains("glTexGenfv")) {
            //    glTexGenfv = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glTexGenfv");
            //}
            //if (config == null || config.Contains("glTexGenfvOES")) {
            //    glTexGenfvOES = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glTexGenfvOES");
            //}
            //if (config == null || config.Contains("glTexGeni")) {
            //    glTexGeni = (delegate* unmanaged<GLenum, GLenum, GLint, void>)GetProcAddress("glTexGeni");
            //}
            //if (config == null || config.Contains("glTexGeniOES")) {
            //    glTexGeniOES = (delegate* unmanaged<GLenum, GLenum, GLint, void>)GetProcAddress("glTexGeniOES");
            //}
            //if (config == null || config.Contains("glTexGeniv")) {
            //    glTexGeniv = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glTexGeniv");
            //}
            //if (config == null || config.Contains("glTexGenivOES")) {
            //    glTexGenivOES = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glTexGenivOES");
            //}
            //if (config == null || config.Contains("glTexGenxOES")) {
            //    glTexGenxOES = (delegate* unmanaged<GLenum, GLenum, GLfixed, void>)GetProcAddress("glTexGenxOES");
            //}
            //if (config == null || config.Contains("glTexGenxvOES")) {
            //    glTexGenxvOES = (delegate* unmanaged<GLenum, GLenum, GLfixed[], void>)GetProcAddress("glTexGenxvOES");
            //}
            //if (config == null || config.Contains("glTexImage1D")) {
            //    glTexImage1D = (delegate* unmanaged<GLenum, GLint, GLint, GLsizei, GLint, GLenum, GLenum, IntPtr, void>)GetProcAddress("glTexImage1D");
            //}
            //if (config == null || config.Contains("glTexImage2D")) {
            //    glTexImage2D = (delegate* unmanaged<GLenum, GLint, GLint, GLsizei, GLsizei, GLint, GLenum, GLenum, IntPtr, void>)GetProcAddress("glTexImage2D");
            //}
            //if (config == null || config.Contains("glTexImage2DMultisample")) {
            //    glTexImage2DMultisample = (delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLboolean, void>)GetProcAddress("glTexImage2DMultisample");
            //}
            //if (config == null || config.Contains("glTexImage2DMultisampleCoverageNV")) {
            //    glTexImage2DMultisampleCoverageNV = (delegate* unmanaged<GLenum, GLsizei, GLsizei, GLint, GLsizei, GLsizei, GLboolean, void>)GetProcAddress("glTexImage2DMultisampleCoverageNV");
            //}
            //if (config == null || config.Contains("glTexImage3D")) {
            //    glTexImage3D = (delegate* unmanaged<GLenum, GLint, GLint, GLsizei, GLsizei, GLsizei, GLint, GLenum, GLenum, IntPtr, void>)GetProcAddress("glTexImage3D");
            //}
            //if (config == null || config.Contains("glTexImage3DEXT")) {
            //    glTexImage3DEXT = (delegate* unmanaged<GLenum, GLint, GLenum, GLsizei, GLsizei, GLsizei, GLint, GLenum, GLenum, IntPtr, void>)GetProcAddress("glTexImage3DEXT");
            //}
            //if (config == null || config.Contains("glTexImage3DMultisample")) {
            //    glTexImage3DMultisample = (delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLsizei, GLboolean, void>)GetProcAddress("glTexImage3DMultisample");
            //}
            //if (config == null || config.Contains("glTexImage3DMultisampleCoverageNV")) {
            //    glTexImage3DMultisampleCoverageNV = (delegate* unmanaged<GLenum, GLsizei, GLsizei, GLint, GLsizei, GLsizei, GLsizei, GLboolean, void>)GetProcAddress("glTexImage3DMultisampleCoverageNV");
            //}
            //if (config == null || config.Contains("glTexImage3DOES")) {
            //    glTexImage3DOES = (delegate* unmanaged<GLenum, GLint, GLenum, GLsizei, GLsizei, GLsizei, GLint, GLenum, GLenum, IntPtr, void>)GetProcAddress("glTexImage3DOES");
            //}
            //if (config == null || config.Contains("glTexImage4DSGIS")) {
            //    glTexImage4DSGIS = (delegate* unmanaged<GLenum, GLint, GLenum, GLsizei, GLsizei, GLsizei, GLsizei, GLint, GLenum, GLenum, IntPtr, void>)GetProcAddress("glTexImage4DSGIS");
            //}
            //if (config == null || config.Contains("glTexPageCommitmentARB")) {
            //    glTexPageCommitmentARB = (delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLboolean, void>)GetProcAddress("glTexPageCommitmentARB");
            //}
            //if (config == null || config.Contains("glTexPageCommitmentEXT")) {
            //    glTexPageCommitmentEXT = (delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLboolean, void>)GetProcAddress("glTexPageCommitmentEXT");
            //}
            //if (config == null || config.Contains("glTexParameterIiv")) {
            //    glTexParameterIiv = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glTexParameterIiv");
            //}
            //if (config == null || config.Contains("glTexParameterIivEXT")) {
            //    glTexParameterIivEXT = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glTexParameterIivEXT");
            //}
            //if (config == null || config.Contains("glTexParameterIivOES")) {
            //    glTexParameterIivOES = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glTexParameterIivOES");
            //}
            //if (config == null || config.Contains("glTexParameterIuiv")) {
            //    glTexParameterIuiv = (delegate* unmanaged<GLenum, GLenum, GLuint[], void>)GetProcAddress("glTexParameterIuiv");
            //}
            //if (config == null || config.Contains("glTexParameterIuivEXT")) {
            //    glTexParameterIuivEXT = (delegate* unmanaged<GLenum, GLenum, GLuint[], void>)GetProcAddress("glTexParameterIuivEXT");
            //}
            //if (config == null || config.Contains("glTexParameterIuivOES")) {
            //    glTexParameterIuivOES = (delegate* unmanaged<GLenum, GLenum, GLuint[], void>)GetProcAddress("glTexParameterIuivOES");
            //}
            //if (config == null || config.Contains("glTexParameterf")) {
            //    glTexParameterf = (delegate* unmanaged<GLenum, GLenum, GLfloat, void>)GetProcAddress("glTexParameterf");
            //}
            //if (config == null || config.Contains("glTexParameterfv")) {
            //    glTexParameterfv = (delegate* unmanaged<GLenum, GLenum, GLfloat[], void>)GetProcAddress("glTexParameterfv");
            //}
            //if (config == null || config.Contains("glTexParameteri")) {
            //    glTexParameteri = (delegate* unmanaged<GLenum, GLenum, GLint, void>)GetProcAddress("glTexParameteri");
            //}
            //if (config == null || config.Contains("glTexParameteriv")) {
            //    glTexParameteriv = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glTexParameteriv");
            //}
            //if (config == null || config.Contains("glTexParameterx")) {
            //    glTexParameterx = (delegate* unmanaged<GLenum, GLenum, GLfixed, void>)GetProcAddress("glTexParameterx");
            //}
            //if (config == null || config.Contains("glTexParameterxOES")) {
            //    glTexParameterxOES = (delegate* unmanaged<GLenum, GLenum, GLfixed, void>)GetProcAddress("glTexParameterxOES");
            //}
            //if (config == null || config.Contains("glTexParameterxv")) {
            //    glTexParameterxv = (delegate* unmanaged<GLenum, GLenum, GLfixed[], void>)GetProcAddress("glTexParameterxv");
            //}
            //if (config == null || config.Contains("glTexParameterxvOES")) {
            //    glTexParameterxvOES = (delegate* unmanaged<GLenum, GLenum, GLfixed[], void>)GetProcAddress("glTexParameterxvOES");
            //}
            //if (config == null || config.Contains("glTexRenderbufferNV")) {
            //    glTexRenderbufferNV = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glTexRenderbufferNV");
            //}
            //if (config == null || config.Contains("glTexStorage1D")) {
            //    glTexStorage1D = (delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, void>)GetProcAddress("glTexStorage1D");
            //}
            //if (config == null || config.Contains("glTexStorage1DEXT")) {
            //    glTexStorage1DEXT = (delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, void>)GetProcAddress("glTexStorage1DEXT");
            //}
            //if (config == null || config.Contains("glTexStorage2D")) {
            //    glTexStorage2D = (delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, void>)GetProcAddress("glTexStorage2D");
            //}
            //if (config == null || config.Contains("glTexStorage2DEXT")) {
            //    glTexStorage2DEXT = (delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, void>)GetProcAddress("glTexStorage2DEXT");
            //}
            //if (config == null || config.Contains("glTexStorage2DMultisample")) {
            //    glTexStorage2DMultisample = (delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLboolean, void>)GetProcAddress("glTexStorage2DMultisample");
            //}
            //if (config == null || config.Contains("glTexStorage3D")) {
            //    glTexStorage3D = (delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLsizei, void>)GetProcAddress("glTexStorage3D");
            //}
            //if (config == null || config.Contains("glTexStorage3DEXT")) {
            //    glTexStorage3DEXT = (delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLsizei, void>)GetProcAddress("glTexStorage3DEXT");
            //}
            //if (config == null || config.Contains("glTexStorage3DMultisample")) {
            //    glTexStorage3DMultisample = (delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLsizei, GLboolean, void>)GetProcAddress("glTexStorage3DMultisample");
            //}
            //if (config == null || config.Contains("glTexStorage3DMultisampleOES")) {
            //    glTexStorage3DMultisampleOES = (delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLsizei, GLboolean, void>)GetProcAddress("glTexStorage3DMultisampleOES");
            //}
            //if (config == null || config.Contains("glTexStorageMem1DEXT")) {
            //    glTexStorageMem1DEXT = (delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLuint, GLuint64, void>)GetProcAddress("glTexStorageMem1DEXT");
            //}
            //if (config == null || config.Contains("glTexStorageMem2DEXT")) {
            //    glTexStorageMem2DEXT = (delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLuint, GLuint64, void>)GetProcAddress("glTexStorageMem2DEXT");
            //}
            //if (config == null || config.Contains("glTexStorageMem2DMultisampleEXT")) {
            //    glTexStorageMem2DMultisampleEXT = (delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLboolean, GLuint, GLuint64, void>)GetProcAddress("glTexStorageMem2DMultisampleEXT");
            //}
            //if (config == null || config.Contains("glTexStorageMem3DEXT")) {
            //    glTexStorageMem3DEXT = (delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLsizei, GLuint, GLuint64, void>)GetProcAddress("glTexStorageMem3DEXT");
            //}
            //if (config == null || config.Contains("glTexStorageMem3DMultisampleEXT")) {
            //    glTexStorageMem3DMultisampleEXT = (delegate* unmanaged<GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLsizei, GLboolean, GLuint, GLuint64, void>)GetProcAddress("glTexStorageMem3DMultisampleEXT");
            //}
            //if (config == null || config.Contains("glTexStorageSparseAMD")) {
            //    glTexStorageSparseAMD = (delegate* unmanaged<GLenum, GLenum, GLsizei, GLsizei, GLsizei, GLsizei, GLbitfield, void>)GetProcAddress("glTexStorageSparseAMD");
            //}
            //if (config == null || config.Contains("glTexSubImage1D")) {
            //    glTexSubImage1D = (delegate* unmanaged<GLenum, GLint, GLint, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glTexSubImage1D");
            //}
            //if (config == null || config.Contains("glTexSubImage1DEXT")) {
            //    glTexSubImage1DEXT = (delegate* unmanaged<GLenum, GLint, GLint, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glTexSubImage1DEXT");
            //}
            //if (config == null || config.Contains("glTexSubImage2D")) {
            //    glTexSubImage2D = (delegate* unmanaged<GLenum, GLint, GLint, GLint, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glTexSubImage2D");
            //}
            //if (config == null || config.Contains("glTexSubImage2DEXT")) {
            //    glTexSubImage2DEXT = (delegate* unmanaged<GLenum, GLint, GLint, GLint, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glTexSubImage2DEXT");
            //}
            //if (config == null || config.Contains("glTexSubImage3D")) {
            //    glTexSubImage3D = (delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glTexSubImage3D");
            //}
            //if (config == null || config.Contains("glTexSubImage3DEXT")) {
            //    glTexSubImage3DEXT = (delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glTexSubImage3DEXT");
            //}
            //if (config == null || config.Contains("glTexSubImage3DOES")) {
            //    glTexSubImage3DOES = (delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glTexSubImage3DOES");
            //}
            //if (config == null || config.Contains("glTexSubImage4DSGIS")) {
            //    glTexSubImage4DSGIS = (delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glTexSubImage4DSGIS");
            //}
            //if (config == null || config.Contains("glTextureAttachMemoryNV")) {
            //    glTextureAttachMemoryNV = (delegate* unmanaged<GLuint, GLuint, GLuint64, void>)GetProcAddress("glTextureAttachMemoryNV");
            //}
            //if (config == null || config.Contains("glTextureBarrier")) {
            //    glTextureBarrier = (delegate* unmanaged<void>)GetProcAddress("glTextureBarrier");
            //}
            //if (config == null || config.Contains("glTextureBarrierNV")) {
            //    glTextureBarrierNV = (delegate* unmanaged<void>)GetProcAddress("glTextureBarrierNV");
            //}
            //if (config == null || config.Contains("glTextureBuffer")) {
            //    glTextureBuffer = (delegate* unmanaged<GLuint, GLenum, GLuint, void>)GetProcAddress("glTextureBuffer");
            //}
            //if (config == null || config.Contains("glTextureBufferEXT")) {
            //    glTextureBufferEXT = (delegate* unmanaged<GLuint, GLenum, GLenum, GLuint, void>)GetProcAddress("glTextureBufferEXT");
            //}
            //if (config == null || config.Contains("glTextureBufferRange")) {
            //    glTextureBufferRange = (delegate* unmanaged<GLuint, GLenum, GLuint, GLintptr, GLsizeiptr, void>)GetProcAddress("glTextureBufferRange");
            //}
            //if (config == null || config.Contains("glTextureBufferRangeEXT")) {
            //    glTextureBufferRangeEXT = (delegate* unmanaged<GLuint, GLenum, GLenum, GLuint, GLintptr, GLsizeiptr, void>)GetProcAddress("glTextureBufferRangeEXT");
            //}
            //if (config == null || config.Contains("glTextureColorMaskSGIS")) {
            //    glTextureColorMaskSGIS = (delegate* unmanaged<GLboolean, GLboolean, GLboolean, GLboolean, void>)GetProcAddress("glTextureColorMaskSGIS");
            //}
            //if (config == null || config.Contains("glTextureFoveationParametersQCOM")) {
            //    glTextureFoveationParametersQCOM = (delegate* unmanaged<GLuint, GLuint, GLuint, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glTextureFoveationParametersQCOM");
            //}
            //if (config == null || config.Contains("glTextureImage1DEXT")) {
            //    glTextureImage1DEXT = (delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLsizei, GLint, GLenum, GLenum, IntPtr, void>)GetProcAddress("glTextureImage1DEXT");
            //}
            //if (config == null || config.Contains("glTextureImage2DEXT")) {
            //    glTextureImage2DEXT = (delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLsizei, GLsizei, GLint, GLenum, GLenum, IntPtr, void>)GetProcAddress("glTextureImage2DEXT");
            //}
            //if (config == null || config.Contains("glTextureImage2DMultisampleCoverageNV")) {
            //    glTextureImage2DMultisampleCoverageNV = (delegate* unmanaged<GLuint, GLenum, GLsizei, GLsizei, GLint, GLsizei, GLsizei, GLboolean, void>)GetProcAddress("glTextureImage2DMultisampleCoverageNV");
            //}
            //if (config == null || config.Contains("glTextureImage2DMultisampleNV")) {
            //    glTextureImage2DMultisampleNV = (delegate* unmanaged<GLuint, GLenum, GLsizei, GLint, GLsizei, GLsizei, GLboolean, void>)GetProcAddress("glTextureImage2DMultisampleNV");
            //}
            //if (config == null || config.Contains("glTextureImage3DEXT")) {
            //    glTextureImage3DEXT = (delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLsizei, GLsizei, GLsizei, GLint, GLenum, GLenum, IntPtr, void>)GetProcAddress("glTextureImage3DEXT");
            //}
            //if (config == null || config.Contains("glTextureImage3DMultisampleCoverageNV")) {
            //    glTextureImage3DMultisampleCoverageNV = (delegate* unmanaged<GLuint, GLenum, GLsizei, GLsizei, GLint, GLsizei, GLsizei, GLsizei, GLboolean, void>)GetProcAddress("glTextureImage3DMultisampleCoverageNV");
            //}
            //if (config == null || config.Contains("glTextureImage3DMultisampleNV")) {
            //    glTextureImage3DMultisampleNV = (delegate* unmanaged<GLuint, GLenum, GLsizei, GLint, GLsizei, GLsizei, GLsizei, GLboolean, void>)GetProcAddress("glTextureImage3DMultisampleNV");
            //}
            //if (config == null || config.Contains("glTextureLightEXT")) {
            //    glTextureLightEXT = (delegate* unmanaged<GLenum, void>)GetProcAddress("glTextureLightEXT");
            //}
            //if (config == null || config.Contains("glTextureMaterialEXT")) {
            //    glTextureMaterialEXT = (delegate* unmanaged<GLenum, GLenum, void>)GetProcAddress("glTextureMaterialEXT");
            //}
            //if (config == null || config.Contains("glTextureNormalEXT")) {
            //    glTextureNormalEXT = (delegate* unmanaged<GLenum, void>)GetProcAddress("glTextureNormalEXT");
            //}
            //if (config == null || config.Contains("glTexturePageCommitmentEXT")) {
            //    glTexturePageCommitmentEXT = (delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLboolean, void>)GetProcAddress("glTexturePageCommitmentEXT");
            //}
            //if (config == null || config.Contains("glTextureParameterIiv")) {
            //    glTextureParameterIiv = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glTextureParameterIiv");
            //}
            //if (config == null || config.Contains("glTextureParameterIivEXT")) {
            //    glTextureParameterIivEXT = (delegate* unmanaged<GLuint, GLenum, GLenum, GLint[], void>)GetProcAddress("glTextureParameterIivEXT");
            //}
            //if (config == null || config.Contains("glTextureParameterIuiv")) {
            //    glTextureParameterIuiv = (delegate* unmanaged<GLuint, GLenum, GLuint[], void>)GetProcAddress("glTextureParameterIuiv");
            //}
            //if (config == null || config.Contains("glTextureParameterIuivEXT")) {
            //    glTextureParameterIuivEXT = (delegate* unmanaged<GLuint, GLenum, GLenum, GLuint[], void>)GetProcAddress("glTextureParameterIuivEXT");
            //}
            //if (config == null || config.Contains("glTextureParameterf")) {
            //    glTextureParameterf = (delegate* unmanaged<GLuint, GLenum, GLfloat, void>)GetProcAddress("glTextureParameterf");
            //}
            //if (config == null || config.Contains("glTextureParameterfEXT")) {
            //    glTextureParameterfEXT = (delegate* unmanaged<GLuint, GLenum, GLenum, GLfloat, void>)GetProcAddress("glTextureParameterfEXT");
            //}
            //if (config == null || config.Contains("glTextureParameterfv")) {
            //    glTextureParameterfv = (delegate* unmanaged<GLuint, GLenum, GLfloat[], void>)GetProcAddress("glTextureParameterfv");
            //}
            //if (config == null || config.Contains("glTextureParameterfvEXT")) {
            //    glTextureParameterfvEXT = (delegate* unmanaged<GLuint, GLenum, GLenum, GLfloat[], void>)GetProcAddress("glTextureParameterfvEXT");
            //}
            //if (config == null || config.Contains("glTextureParameteri")) {
            //    glTextureParameteri = (delegate* unmanaged<GLuint, GLenum, GLint, void>)GetProcAddress("glTextureParameteri");
            //}
            //if (config == null || config.Contains("glTextureParameteriEXT")) {
            //    glTextureParameteriEXT = (delegate* unmanaged<GLuint, GLenum, GLenum, GLint, void>)GetProcAddress("glTextureParameteriEXT");
            //}
            //if (config == null || config.Contains("glTextureParameteriv")) {
            //    glTextureParameteriv = (delegate* unmanaged<GLuint, GLenum, GLint[], void>)GetProcAddress("glTextureParameteriv");
            //}
            //if (config == null || config.Contains("glTextureParameterivEXT")) {
            //    glTextureParameterivEXT = (delegate* unmanaged<GLuint, GLenum, GLenum, GLint[], void>)GetProcAddress("glTextureParameterivEXT");
            //}
            //if (config == null || config.Contains("glTextureRangeAPPLE")) {
            //    glTextureRangeAPPLE = (delegate* unmanaged<GLenum, GLsizei, IntPtr, void>)GetProcAddress("glTextureRangeAPPLE");
            //}
            //if (config == null || config.Contains("glTextureRenderbufferEXT")) {
            //    glTextureRenderbufferEXT = (delegate* unmanaged<GLuint, GLenum, GLuint, void>)GetProcAddress("glTextureRenderbufferEXT");
            //}
            //if (config == null || config.Contains("glTextureStorage1D")) {
            //    glTextureStorage1D = (delegate* unmanaged<GLuint, GLsizei, GLenum, GLsizei, void>)GetProcAddress("glTextureStorage1D");
            //}
            //if (config == null || config.Contains("glTextureStorage1DEXT")) {
            //    glTextureStorage1DEXT = (delegate* unmanaged<GLuint, GLenum, GLsizei, GLenum, GLsizei, void>)GetProcAddress("glTextureStorage1DEXT");
            //}
            //if (config == null || config.Contains("glTextureStorage2D")) {
            //    glTextureStorage2D = (delegate* unmanaged<GLuint, GLsizei, GLenum, GLsizei, GLsizei, void>)GetProcAddress("glTextureStorage2D");
            //}
            //if (config == null || config.Contains("glTextureStorage2DEXT")) {
            //    glTextureStorage2DEXT = (delegate* unmanaged<GLuint, GLenum, GLsizei, GLenum, GLsizei, GLsizei, void>)GetProcAddress("glTextureStorage2DEXT");
            //}
            //if (config == null || config.Contains("glTextureStorage2DMultisample")) {
            //    glTextureStorage2DMultisample = (delegate* unmanaged<GLuint, GLsizei, GLenum, GLsizei, GLsizei, GLboolean, void>)GetProcAddress("glTextureStorage2DMultisample");
            //}
            //if (config == null || config.Contains("glTextureStorage2DMultisampleEXT")) {
            //    glTextureStorage2DMultisampleEXT = (delegate* unmanaged<GLuint, GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLboolean, void>)GetProcAddress("glTextureStorage2DMultisampleEXT");
            //}
            //if (config == null || config.Contains("glTextureStorage3D")) {
            //    glTextureStorage3D = (delegate* unmanaged<GLuint, GLsizei, GLenum, GLsizei, GLsizei, GLsizei, void>)GetProcAddress("glTextureStorage3D");
            //}
            //if (config == null || config.Contains("glTextureStorage3DEXT")) {
            //    glTextureStorage3DEXT = (delegate* unmanaged<GLuint, GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLsizei, void>)GetProcAddress("glTextureStorage3DEXT");
            //}
            //if (config == null || config.Contains("glTextureStorage3DMultisample")) {
            //    glTextureStorage3DMultisample = (delegate* unmanaged<GLuint, GLsizei, GLenum, GLsizei, GLsizei, GLsizei, GLboolean, void>)GetProcAddress("glTextureStorage3DMultisample");
            //}
            //if (config == null || config.Contains("glTextureStorage3DMultisampleEXT")) {
            //    glTextureStorage3DMultisampleEXT = (delegate* unmanaged<GLuint, GLenum, GLsizei, GLenum, GLsizei, GLsizei, GLsizei, GLboolean, void>)GetProcAddress("glTextureStorage3DMultisampleEXT");
            //}
            //if (config == null || config.Contains("glTextureStorageMem1DEXT")) {
            //    glTextureStorageMem1DEXT = (delegate* unmanaged<GLuint, GLsizei, GLenum, GLsizei, GLuint, GLuint64, void>)GetProcAddress("glTextureStorageMem1DEXT");
            //}
            //if (config == null || config.Contains("glTextureStorageMem2DEXT")) {
            //    glTextureStorageMem2DEXT = (delegate* unmanaged<GLuint, GLsizei, GLenum, GLsizei, GLsizei, GLuint, GLuint64, void>)GetProcAddress("glTextureStorageMem2DEXT");
            //}
            //if (config == null || config.Contains("glTextureStorageMem2DMultisampleEXT")) {
            //    glTextureStorageMem2DMultisampleEXT = (delegate* unmanaged<GLuint, GLsizei, GLenum, GLsizei, GLsizei, GLboolean, GLuint, GLuint64, void>)GetProcAddress("glTextureStorageMem2DMultisampleEXT");
            //}
            //if (config == null || config.Contains("glTextureStorageMem3DEXT")) {
            //    glTextureStorageMem3DEXT = (delegate* unmanaged<GLuint, GLsizei, GLenum, GLsizei, GLsizei, GLsizei, GLuint, GLuint64, void>)GetProcAddress("glTextureStorageMem3DEXT");
            //}
            //if (config == null || config.Contains("glTextureStorageMem3DMultisampleEXT")) {
            //    glTextureStorageMem3DMultisampleEXT = (delegate* unmanaged<GLuint, GLsizei, GLenum, GLsizei, GLsizei, GLsizei, GLboolean, GLuint, GLuint64, void>)GetProcAddress("glTextureStorageMem3DMultisampleEXT");
            //}
            //if (config == null || config.Contains("glTextureStorageSparseAMD")) {
            //    glTextureStorageSparseAMD = (delegate* unmanaged<GLuint, GLenum, GLenum, GLsizei, GLsizei, GLsizei, GLsizei, GLbitfield, void>)GetProcAddress("glTextureStorageSparseAMD");
            //}
            //if (config == null || config.Contains("glTextureSubImage1D")) {
            //    glTextureSubImage1D = (delegate* unmanaged<GLuint, GLint, GLint, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glTextureSubImage1D");
            //}
            //if (config == null || config.Contains("glTextureSubImage1DEXT")) {
            //    glTextureSubImage1DEXT = (delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glTextureSubImage1DEXT");
            //}
            //if (config == null || config.Contains("glTextureSubImage2D")) {
            //    glTextureSubImage2D = (delegate* unmanaged<GLuint, GLint, GLint, GLint, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glTextureSubImage2D");
            //}
            //if (config == null || config.Contains("glTextureSubImage2DEXT")) {
            //    glTextureSubImage2DEXT = (delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLint, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glTextureSubImage2DEXT");
            //}
            //if (config == null || config.Contains("glTextureSubImage3D")) {
            //    glTextureSubImage3D = (delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glTextureSubImage3D");
            //}
            //if (config == null || config.Contains("glTextureSubImage3DEXT")) {
            //    glTextureSubImage3DEXT = (delegate* unmanaged<GLuint, GLenum, GLint, GLint, GLint, GLint, GLsizei, GLsizei, GLsizei, GLenum, GLenum, IntPtr, void>)GetProcAddress("glTextureSubImage3DEXT");
            //}
            //if (config == null || config.Contains("glTextureView")) {
            //    glTextureView = (delegate* unmanaged<GLuint, GLenum, GLuint, GLenum, GLuint, GLuint, GLuint, GLuint, void>)GetProcAddress("glTextureView");
            //}
            //if (config == null || config.Contains("glTextureViewEXT")) {
            //    glTextureViewEXT = (delegate* unmanaged<GLuint, GLenum, GLuint, GLenum, GLuint, GLuint, GLuint, GLuint, void>)GetProcAddress("glTextureViewEXT");
            //}
            //if (config == null || config.Contains("glTextureViewOES")) {
            //    glTextureViewOES = (delegate* unmanaged<GLuint, GLenum, GLuint, GLenum, GLuint, GLuint, GLuint, GLuint, void>)GetProcAddress("glTextureViewOES");
            //}
            //if (config == null || config.Contains("glTrackMatrixNV")) {
            //    glTrackMatrixNV = (delegate* unmanaged<GLenum, GLuint, GLenum, GLenum, void>)GetProcAddress("glTrackMatrixNV");
            //}
            //if (config == null || config.Contains("glTransformFeedbackAttribsNV")) {
            //    glTransformFeedbackAttribsNV = (delegate* unmanaged<GLsizei, GLint[], GLenum, void>)GetProcAddress("glTransformFeedbackAttribsNV");
            //}
            //if (config == null || config.Contains("glTransformFeedbackBufferBase")) {
            //    glTransformFeedbackBufferBase = (delegate* unmanaged<GLuint, GLuint, GLuint, void>)GetProcAddress("glTransformFeedbackBufferBase");
            //}
            //if (config == null || config.Contains("glTransformFeedbackBufferRange")) {
            //    glTransformFeedbackBufferRange = (delegate* unmanaged<GLuint, GLuint, GLuint, GLintptr, GLsizeiptr, void>)GetProcAddress("glTransformFeedbackBufferRange");
            //}
            //if (config == null || config.Contains("glTransformFeedbackStreamAttribsNV")) {
            //    glTransformFeedbackStreamAttribsNV = (delegate* unmanaged<GLsizei, GLint[], GLsizei, GLint[], GLenum, void>)GetProcAddress("glTransformFeedbackStreamAttribsNV");
            //}
            //if (config == null || config.Contains("glTransformFeedbackVaryings")) {
            //    glTransformFeedbackVaryings = (delegate* unmanaged<GLuint, GLsizei, string[], GLenum, void>)GetProcAddress("glTransformFeedbackVaryings");
            //}
            //if (config == null || config.Contains("glTransformFeedbackVaryingsEXT")) {
            //    glTransformFeedbackVaryingsEXT = (delegate* unmanaged<GLuint, GLsizei, string[], GLenum, void>)GetProcAddress("glTransformFeedbackVaryingsEXT");
            //}
            //if (config == null || config.Contains("glTransformFeedbackVaryingsNV")) {
            //    glTransformFeedbackVaryingsNV = (delegate* unmanaged<GLuint, GLsizei, GLint[], GLenum, void>)GetProcAddress("glTransformFeedbackVaryingsNV");
            //}
            //if (config == null || config.Contains("glTransformPathNV")) {
            //    glTransformPathNV = (delegate* unmanaged<GLuint, GLuint, GLenum, GLfloat[], void>)GetProcAddress("glTransformPathNV");
            //}
            //if (config == null || config.Contains("glTranslated")) {
            //    glTranslated = (delegate* unmanaged<GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glTranslated");
            //}
            //if (config == null || config.Contains("glTranslatef")) {
            //    glTranslatef = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glTranslatef");
            //}
            //if (config == null || config.Contains("glTranslatex")) {
            //    glTranslatex = (delegate* unmanaged<GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glTranslatex");
            //}
            //if (config == null || config.Contains("glTranslatexOES")) {
            //    glTranslatexOES = (delegate* unmanaged<GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glTranslatexOES");
            //}
            //if (config == null || config.Contains("glUniform1d")) {
            //    glUniform1d = (delegate* unmanaged<GLint, GLdouble, void>)GetProcAddress("glUniform1d");
            //}
            //if (config == null || config.Contains("glUniform1dv")) {
            //    glUniform1dv = (delegate* unmanaged<GLint, GLsizei, GLdouble[], void>)GetProcAddress("glUniform1dv");
            //}
            //if (config == null || config.Contains("glUniform1f")) {
            //    glUniform1f = (delegate* unmanaged<GLint, GLfloat, void>)GetProcAddress("glUniform1f");
            //}
            //if (config == null || config.Contains("glUniform1fARB")) {
            //    glUniform1fARB = (delegate* unmanaged<GLint, GLfloat, void>)GetProcAddress("glUniform1fARB");
            //}
            //if (config == null || config.Contains("glUniform1fv")) {
            //    glUniform1fv = (delegate* unmanaged<GLint, GLsizei, GLfloat[], void>)GetProcAddress("glUniform1fv");
            //}
            //if (config == null || config.Contains("glUniform1fvARB")) {
            //    glUniform1fvARB = (delegate* unmanaged<GLint, GLsizei, GLfloat[], void>)GetProcAddress("glUniform1fvARB");
            //}
            //if (config == null || config.Contains("glUniform1i")) {
            //    glUniform1i = (delegate* unmanaged<GLint, GLint, void>)GetProcAddress("glUniform1i");
            //}
            //if (config == null || config.Contains("glUniform1i64ARB")) {
            //    glUniform1i64ARB = (delegate* unmanaged<GLint, GLint64, void>)GetProcAddress("glUniform1i64ARB");
            //}
            //if (config == null || config.Contains("glUniform1i64NV")) {
            //    glUniform1i64NV = (delegate* unmanaged<GLint, GLint64EXT, void>)GetProcAddress("glUniform1i64NV");
            //}
            //if (config == null || config.Contains("glUniform1i64vARB")) {
            //    glUniform1i64vARB = (delegate* unmanaged<GLint, GLsizei, GLint64[], void>)GetProcAddress("glUniform1i64vARB");
            //}
            //if (config == null || config.Contains("glUniform1i64vNV")) {
            //    glUniform1i64vNV = (delegate* unmanaged<GLint, GLsizei, GLint64EXT[], void>)GetProcAddress("glUniform1i64vNV");
            //}
            //if (config == null || config.Contains("glUniform1iARB")) {
            //    glUniform1iARB = (delegate* unmanaged<GLint, GLint, void>)GetProcAddress("glUniform1iARB");
            //}
            //if (config == null || config.Contains("glUniform1iv")) {
            //    glUniform1iv = (delegate* unmanaged<GLint, GLsizei, GLint[], void>)GetProcAddress("glUniform1iv");
            //}
            //if (config == null || config.Contains("glUniform1ivARB")) {
            //    glUniform1ivARB = (delegate* unmanaged<GLint, GLsizei, GLint[], void>)GetProcAddress("glUniform1ivARB");
            //}
            //if (config == null || config.Contains("glUniform1ui")) {
            //    glUniform1ui = (delegate* unmanaged<GLint, GLuint, void>)GetProcAddress("glUniform1ui");
            //}
            //if (config == null || config.Contains("glUniform1ui64ARB")) {
            //    glUniform1ui64ARB = (delegate* unmanaged<GLint, GLuint64, void>)GetProcAddress("glUniform1ui64ARB");
            //}
            //if (config == null || config.Contains("glUniform1ui64NV")) {
            //    glUniform1ui64NV = (delegate* unmanaged<GLint, GLuint64EXT, void>)GetProcAddress("glUniform1ui64NV");
            //}
            //if (config == null || config.Contains("glUniform1ui64vARB")) {
            //    glUniform1ui64vARB = (delegate* unmanaged<GLint, GLsizei, GLuint64[], void>)GetProcAddress("glUniform1ui64vARB");
            //}
            //if (config == null || config.Contains("glUniform1ui64vNV")) {
            //    glUniform1ui64vNV = (delegate* unmanaged<GLint, GLsizei, GLuint64EXT[], void>)GetProcAddress("glUniform1ui64vNV");
            //}
            //if (config == null || config.Contains("glUniform1uiEXT")) {
            //    glUniform1uiEXT = (delegate* unmanaged<GLint, GLuint, void>)GetProcAddress("glUniform1uiEXT");
            //}
            //if (config == null || config.Contains("glUniform1uiv")) {
            //    glUniform1uiv = (delegate* unmanaged<GLint, GLsizei, GLuint[], void>)GetProcAddress("glUniform1uiv");
            //}
            //if (config == null || config.Contains("glUniform1uivEXT")) {
            //    glUniform1uivEXT = (delegate* unmanaged<GLint, GLsizei, GLuint[], void>)GetProcAddress("glUniform1uivEXT");
            //}
            //if (config == null || config.Contains("glUniform2d")) {
            //    glUniform2d = (delegate* unmanaged<GLint, GLdouble, GLdouble, void>)GetProcAddress("glUniform2d");
            //}
            //if (config == null || config.Contains("glUniform2dv")) {
            //    glUniform2dv = (delegate* unmanaged<GLint, GLsizei, GLdouble[], void>)GetProcAddress("glUniform2dv");
            //}
            //if (config == null || config.Contains("glUniform2f")) {
            //    glUniform2f = (delegate* unmanaged<GLint, GLfloat, GLfloat, void>)GetProcAddress("glUniform2f");
            //}
            //if (config == null || config.Contains("glUniform2fARB")) {
            //    glUniform2fARB = (delegate* unmanaged<GLint, GLfloat, GLfloat, void>)GetProcAddress("glUniform2fARB");
            //}
            //if (config == null || config.Contains("glUniform2fv")) {
            //    glUniform2fv = (delegate* unmanaged<GLint, GLsizei, GLfloat[], void>)GetProcAddress("glUniform2fv");
            //}
            //if (config == null || config.Contains("glUniform2fvARB")) {
            //    glUniform2fvARB = (delegate* unmanaged<GLint, GLsizei, GLfloat[], void>)GetProcAddress("glUniform2fvARB");
            //}
            //if (config == null || config.Contains("glUniform2i")) {
            //    glUniform2i = (delegate* unmanaged<GLint, GLint, GLint, void>)GetProcAddress("glUniform2i");
            //}
            //if (config == null || config.Contains("glUniform2i64ARB")) {
            //    glUniform2i64ARB = (delegate* unmanaged<GLint, GLint64, GLint64, void>)GetProcAddress("glUniform2i64ARB");
            //}
            //if (config == null || config.Contains("glUniform2i64NV")) {
            //    glUniform2i64NV = (delegate* unmanaged<GLint, GLint64EXT, GLint64EXT, void>)GetProcAddress("glUniform2i64NV");
            //}
            //if (config == null || config.Contains("glUniform2i64vARB")) {
            //    glUniform2i64vARB = (delegate* unmanaged<GLint, GLsizei, GLint64[], void>)GetProcAddress("glUniform2i64vARB");
            //}
            //if (config == null || config.Contains("glUniform2i64vNV")) {
            //    glUniform2i64vNV = (delegate* unmanaged<GLint, GLsizei, GLint64EXT[], void>)GetProcAddress("glUniform2i64vNV");
            //}
            //if (config == null || config.Contains("glUniform2iARB")) {
            //    glUniform2iARB = (delegate* unmanaged<GLint, GLint, GLint, void>)GetProcAddress("glUniform2iARB");
            //}
            //if (config == null || config.Contains("glUniform2iv")) {
            //    glUniform2iv = (delegate* unmanaged<GLint, GLsizei, GLint[], void>)GetProcAddress("glUniform2iv");
            //}
            //if (config == null || config.Contains("glUniform2ivARB")) {
            //    glUniform2ivARB = (delegate* unmanaged<GLint, GLsizei, GLint[], void>)GetProcAddress("glUniform2ivARB");
            //}
            //if (config == null || config.Contains("glUniform2ui")) {
            //    glUniform2ui = (delegate* unmanaged<GLint, GLuint, GLuint, void>)GetProcAddress("glUniform2ui");
            //}
            //if (config == null || config.Contains("glUniform2ui64ARB")) {
            //    glUniform2ui64ARB = (delegate* unmanaged<GLint, GLuint64, GLuint64, void>)GetProcAddress("glUniform2ui64ARB");
            //}
            //if (config == null || config.Contains("glUniform2ui64NV")) {
            //    glUniform2ui64NV = (delegate* unmanaged<GLint, GLuint64EXT, GLuint64EXT, void>)GetProcAddress("glUniform2ui64NV");
            //}
            //if (config == null || config.Contains("glUniform2ui64vARB")) {
            //    glUniform2ui64vARB = (delegate* unmanaged<GLint, GLsizei, GLuint64[], void>)GetProcAddress("glUniform2ui64vARB");
            //}
            //if (config == null || config.Contains("glUniform2ui64vNV")) {
            //    glUniform2ui64vNV = (delegate* unmanaged<GLint, GLsizei, GLuint64EXT[], void>)GetProcAddress("glUniform2ui64vNV");
            //}
            //if (config == null || config.Contains("glUniform2uiEXT")) {
            //    glUniform2uiEXT = (delegate* unmanaged<GLint, GLuint, GLuint, void>)GetProcAddress("glUniform2uiEXT");
            //}
            //if (config == null || config.Contains("glUniform2uiv")) {
            //    glUniform2uiv = (delegate* unmanaged<GLint, GLsizei, GLuint[], void>)GetProcAddress("glUniform2uiv");
            //}
            //if (config == null || config.Contains("glUniform2uivEXT")) {
            //    glUniform2uivEXT = (delegate* unmanaged<GLint, GLsizei, GLuint[], void>)GetProcAddress("glUniform2uivEXT");
            //}
            //if (config == null || config.Contains("glUniform3d")) {
            //    glUniform3d = (delegate* unmanaged<GLint, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glUniform3d");
            //}
            //if (config == null || config.Contains("glUniform3dv")) {
            //    glUniform3dv = (delegate* unmanaged<GLint, GLsizei, GLdouble[], void>)GetProcAddress("glUniform3dv");
            //}
            //if (config == null || config.Contains("glUniform3f")) {
            //    glUniform3f = (delegate* unmanaged<GLint, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glUniform3f");
            //}
            //if (config == null || config.Contains("glUniform3fARB")) {
            //    glUniform3fARB = (delegate* unmanaged<GLint, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glUniform3fARB");
            //}
            //if (config == null || config.Contains("glUniform3fv")) {
            //    glUniform3fv = (delegate* unmanaged<GLint, GLsizei, GLfloat[], void>)GetProcAddress("glUniform3fv");
            //}
            //if (config == null || config.Contains("glUniform3fvARB")) {
            //    glUniform3fvARB = (delegate* unmanaged<GLint, GLsizei, GLfloat[], void>)GetProcAddress("glUniform3fvARB");
            //}
            //if (config == null || config.Contains("glUniform3i")) {
            //    glUniform3i = (delegate* unmanaged<GLint, GLint, GLint, GLint, void>)GetProcAddress("glUniform3i");
            //}
            //if (config == null || config.Contains("glUniform3i64ARB")) {
            //    glUniform3i64ARB = (delegate* unmanaged<GLint, GLint64, GLint64, GLint64, void>)GetProcAddress("glUniform3i64ARB");
            //}
            //if (config == null || config.Contains("glUniform3i64NV")) {
            //    glUniform3i64NV = (delegate* unmanaged<GLint, GLint64EXT, GLint64EXT, GLint64EXT, void>)GetProcAddress("glUniform3i64NV");
            //}
            //if (config == null || config.Contains("glUniform3i64vARB")) {
            //    glUniform3i64vARB = (delegate* unmanaged<GLint, GLsizei, GLint64[], void>)GetProcAddress("glUniform3i64vARB");
            //}
            //if (config == null || config.Contains("glUniform3i64vNV")) {
            //    glUniform3i64vNV = (delegate* unmanaged<GLint, GLsizei, GLint64EXT[], void>)GetProcAddress("glUniform3i64vNV");
            //}
            //if (config == null || config.Contains("glUniform3iARB")) {
            //    glUniform3iARB = (delegate* unmanaged<GLint, GLint, GLint, GLint, void>)GetProcAddress("glUniform3iARB");
            //}
            //if (config == null || config.Contains("glUniform3iv")) {
            //    glUniform3iv = (delegate* unmanaged<GLint, GLsizei, GLint[], void>)GetProcAddress("glUniform3iv");
            //}
            //if (config == null || config.Contains("glUniform3ivARB")) {
            //    glUniform3ivARB = (delegate* unmanaged<GLint, GLsizei, GLint[], void>)GetProcAddress("glUniform3ivARB");
            //}
            //if (config == null || config.Contains("glUniform3ui")) {
            //    glUniform3ui = (delegate* unmanaged<GLint, GLuint, GLuint, GLuint, void>)GetProcAddress("glUniform3ui");
            //}
            //if (config == null || config.Contains("glUniform3ui64ARB")) {
            //    glUniform3ui64ARB = (delegate* unmanaged<GLint, GLuint64, GLuint64, GLuint64, void>)GetProcAddress("glUniform3ui64ARB");
            //}
            //if (config == null || config.Contains("glUniform3ui64NV")) {
            //    glUniform3ui64NV = (delegate* unmanaged<GLint, GLuint64EXT, GLuint64EXT, GLuint64EXT, void>)GetProcAddress("glUniform3ui64NV");
            //}
            //if (config == null || config.Contains("glUniform3ui64vARB")) {
            //    glUniform3ui64vARB = (delegate* unmanaged<GLint, GLsizei, GLuint64[], void>)GetProcAddress("glUniform3ui64vARB");
            //}
            //if (config == null || config.Contains("glUniform3ui64vNV")) {
            //    glUniform3ui64vNV = (delegate* unmanaged<GLint, GLsizei, GLuint64EXT[], void>)GetProcAddress("glUniform3ui64vNV");
            //}
            //if (config == null || config.Contains("glUniform3uiEXT")) {
            //    glUniform3uiEXT = (delegate* unmanaged<GLint, GLuint, GLuint, GLuint, void>)GetProcAddress("glUniform3uiEXT");
            //}
            //if (config == null || config.Contains("glUniform3uiv")) {
            //    glUniform3uiv = (delegate* unmanaged<GLint, GLsizei, GLuint[], void>)GetProcAddress("glUniform3uiv");
            //}
            //if (config == null || config.Contains("glUniform3uivEXT")) {
            //    glUniform3uivEXT = (delegate* unmanaged<GLint, GLsizei, GLuint[], void>)GetProcAddress("glUniform3uivEXT");
            //}
            //if (config == null || config.Contains("glUniform4d")) {
            //    glUniform4d = (delegate* unmanaged<GLint, GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glUniform4d");
            //}
            //if (config == null || config.Contains("glUniform4dv")) {
            //    glUniform4dv = (delegate* unmanaged<GLint, GLsizei, GLdouble[], void>)GetProcAddress("glUniform4dv");
            //}
            //if (config == null || config.Contains("glUniform4f")) {
            //    glUniform4f = (delegate* unmanaged<GLint, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glUniform4f");
            //}
            //if (config == null || config.Contains("glUniform4fARB")) {
            //    glUniform4fARB = (delegate* unmanaged<GLint, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glUniform4fARB");
            //}
            //if (config == null || config.Contains("glUniform4fv")) {
            //    glUniform4fv = (delegate* unmanaged<GLint, GLsizei, GLfloat[], void>)GetProcAddress("glUniform4fv");
            //}
            //if (config == null || config.Contains("glUniform4fvARB")) {
            //    glUniform4fvARB = (delegate* unmanaged<GLint, GLsizei, GLfloat[], void>)GetProcAddress("glUniform4fvARB");
            //}
            //if (config == null || config.Contains("glUniform4i")) {
            //    glUniform4i = (delegate* unmanaged<GLint, GLint, GLint, GLint, GLint, void>)GetProcAddress("glUniform4i");
            //}
            //if (config == null || config.Contains("glUniform4i64ARB")) {
            //    glUniform4i64ARB = (delegate* unmanaged<GLint, GLint64, GLint64, GLint64, GLint64, void>)GetProcAddress("glUniform4i64ARB");
            //}
            //if (config == null || config.Contains("glUniform4i64NV")) {
            //    glUniform4i64NV = (delegate* unmanaged<GLint, GLint64EXT, GLint64EXT, GLint64EXT, GLint64EXT, void>)GetProcAddress("glUniform4i64NV");
            //}
            //if (config == null || config.Contains("glUniform4i64vARB")) {
            //    glUniform4i64vARB = (delegate* unmanaged<GLint, GLsizei, GLint64[], void>)GetProcAddress("glUniform4i64vARB");
            //}
            //if (config == null || config.Contains("glUniform4i64vNV")) {
            //    glUniform4i64vNV = (delegate* unmanaged<GLint, GLsizei, GLint64EXT[], void>)GetProcAddress("glUniform4i64vNV");
            //}
            //if (config == null || config.Contains("glUniform4iARB")) {
            //    glUniform4iARB = (delegate* unmanaged<GLint, GLint, GLint, GLint, GLint, void>)GetProcAddress("glUniform4iARB");
            //}
            //if (config == null || config.Contains("glUniform4iv")) {
            //    glUniform4iv = (delegate* unmanaged<GLint, GLsizei, GLint[], void>)GetProcAddress("glUniform4iv");
            //}
            //if (config == null || config.Contains("glUniform4ivARB")) {
            //    glUniform4ivARB = (delegate* unmanaged<GLint, GLsizei, GLint[], void>)GetProcAddress("glUniform4ivARB");
            //}
            //if (config == null || config.Contains("glUniform4ui")) {
            //    glUniform4ui = (delegate* unmanaged<GLint, GLuint, GLuint, GLuint, GLuint, void>)GetProcAddress("glUniform4ui");
            //}
            //if (config == null || config.Contains("glUniform4ui64ARB")) {
            //    glUniform4ui64ARB = (delegate* unmanaged<GLint, GLuint64, GLuint64, GLuint64, GLuint64, void>)GetProcAddress("glUniform4ui64ARB");
            //}
            //if (config == null || config.Contains("glUniform4ui64NV")) {
            //    glUniform4ui64NV = (delegate* unmanaged<GLint, GLuint64EXT, GLuint64EXT, GLuint64EXT, GLuint64EXT, void>)GetProcAddress("glUniform4ui64NV");
            //}
            //if (config == null || config.Contains("glUniform4ui64vARB")) {
            //    glUniform4ui64vARB = (delegate* unmanaged<GLint, GLsizei, GLuint64[], void>)GetProcAddress("glUniform4ui64vARB");
            //}
            //if (config == null || config.Contains("glUniform4ui64vNV")) {
            //    glUniform4ui64vNV = (delegate* unmanaged<GLint, GLsizei, GLuint64EXT[], void>)GetProcAddress("glUniform4ui64vNV");
            //}
            //if (config == null || config.Contains("glUniform4uiEXT")) {
            //    glUniform4uiEXT = (delegate* unmanaged<GLint, GLuint, GLuint, GLuint, GLuint, void>)GetProcAddress("glUniform4uiEXT");
            //}
            //if (config == null || config.Contains("glUniform4uiv")) {
            //    glUniform4uiv = (delegate* unmanaged<GLint, GLsizei, GLuint[], void>)GetProcAddress("glUniform4uiv");
            //}
            //if (config == null || config.Contains("glUniform4uivEXT")) {
            //    glUniform4uivEXT = (delegate* unmanaged<GLint, GLsizei, GLuint[], void>)GetProcAddress("glUniform4uivEXT");
            //}
            //if (config == null || config.Contains("glUniformBlockBinding")) {
            //    glUniformBlockBinding = (delegate* unmanaged<GLuint, GLuint, GLuint, void>)GetProcAddress("glUniformBlockBinding");
            //}
            //if (config == null || config.Contains("glUniformBufferEXT")) {
            //    glUniformBufferEXT = (delegate* unmanaged<GLuint, GLint, GLuint, void>)GetProcAddress("glUniformBufferEXT");
            //}
            //if (config == null || config.Contains("glUniformHandleui64ARB")) {
            //    glUniformHandleui64ARB = (delegate* unmanaged<GLint, GLuint64, void>)GetProcAddress("glUniformHandleui64ARB");
            //}
            //if (config == null || config.Contains("glUniformHandleui64IMG")) {
            //    glUniformHandleui64IMG = (delegate* unmanaged<GLint, GLuint64, void>)GetProcAddress("glUniformHandleui64IMG");
            //}
            //if (config == null || config.Contains("glUniformHandleui64NV")) {
            //    glUniformHandleui64NV = (delegate* unmanaged<GLint, GLuint64, void>)GetProcAddress("glUniformHandleui64NV");
            //}
            //if (config == null || config.Contains("glUniformHandleui64vARB")) {
            //    glUniformHandleui64vARB = (delegate* unmanaged<GLint, GLsizei, GLuint64[], void>)GetProcAddress("glUniformHandleui64vARB");
            //}
            //if (config == null || config.Contains("glUniformHandleui64vIMG")) {
            //    glUniformHandleui64vIMG = (delegate* unmanaged<GLint, GLsizei, GLuint64[], void>)GetProcAddress("glUniformHandleui64vIMG");
            //}
            //if (config == null || config.Contains("glUniformHandleui64vNV")) {
            //    glUniformHandleui64vNV = (delegate* unmanaged<GLint, GLsizei, GLuint64[], void>)GetProcAddress("glUniformHandleui64vNV");
            //}
            //if (config == null || config.Contains("glUniformMatrix2dv")) {
            //    glUniformMatrix2dv = (delegate* unmanaged<GLint, GLsizei, GLboolean, GLdouble[], void>)GetProcAddress("glUniformMatrix2dv");
            //}
            //if (config == null || config.Contains("glUniformMatrix2fv")) {
            //    glUniformMatrix2fv = (delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glUniformMatrix2fv");
            //}
            //if (config == null || config.Contains("glUniformMatrix2fvARB")) {
            //    glUniformMatrix2fvARB = (delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glUniformMatrix2fvARB");
            //}
            //if (config == null || config.Contains("glUniformMatrix2x3dv")) {
            //    glUniformMatrix2x3dv = (delegate* unmanaged<GLint, GLsizei, GLboolean, GLdouble[], void>)GetProcAddress("glUniformMatrix2x3dv");
            //}
            //if (config == null || config.Contains("glUniformMatrix2x3fv")) {
            //    glUniformMatrix2x3fv = (delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glUniformMatrix2x3fv");
            //}
            //if (config == null || config.Contains("glUniformMatrix2x3fvNV")) {
            //    glUniformMatrix2x3fvNV = (delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glUniformMatrix2x3fvNV");
            //}
            //if (config == null || config.Contains("glUniformMatrix2x4dv")) {
            //    glUniformMatrix2x4dv = (delegate* unmanaged<GLint, GLsizei, GLboolean, GLdouble[], void>)GetProcAddress("glUniformMatrix2x4dv");
            //}
            //if (config == null || config.Contains("glUniformMatrix2x4fv")) {
            //    glUniformMatrix2x4fv = (delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glUniformMatrix2x4fv");
            //}
            //if (config == null || config.Contains("glUniformMatrix2x4fvNV")) {
            //    glUniformMatrix2x4fvNV = (delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glUniformMatrix2x4fvNV");
            //}
            //if (config == null || config.Contains("glUniformMatrix3dv")) {
            //    glUniformMatrix3dv = (delegate* unmanaged<GLint, GLsizei, GLboolean, GLdouble[], void>)GetProcAddress("glUniformMatrix3dv");
            //}
            //if (config == null || config.Contains("glUniformMatrix3fv")) {
            //    glUniformMatrix3fv = (delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glUniformMatrix3fv");
            //}
            //if (config == null || config.Contains("glUniformMatrix3fvARB")) {
            //    glUniformMatrix3fvARB = (delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glUniformMatrix3fvARB");
            //}
            //if (config == null || config.Contains("glUniformMatrix3x2dv")) {
            //    glUniformMatrix3x2dv = (delegate* unmanaged<GLint, GLsizei, GLboolean, GLdouble[], void>)GetProcAddress("glUniformMatrix3x2dv");
            //}
            //if (config == null || config.Contains("glUniformMatrix3x2fv")) {
            //    glUniformMatrix3x2fv = (delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glUniformMatrix3x2fv");
            //}
            //if (config == null || config.Contains("glUniformMatrix3x2fvNV")) {
            //    glUniformMatrix3x2fvNV = (delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glUniformMatrix3x2fvNV");
            //}
            //if (config == null || config.Contains("glUniformMatrix3x4dv")) {
            //    glUniformMatrix3x4dv = (delegate* unmanaged<GLint, GLsizei, GLboolean, GLdouble[], void>)GetProcAddress("glUniformMatrix3x4dv");
            //}
            //if (config == null || config.Contains("glUniformMatrix3x4fv")) {
            //    glUniformMatrix3x4fv = (delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glUniformMatrix3x4fv");
            //}
            //if (config == null || config.Contains("glUniformMatrix3x4fvNV")) {
            //    glUniformMatrix3x4fvNV = (delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glUniformMatrix3x4fvNV");
            //}
            //if (config == null || config.Contains("glUniformMatrix4dv")) {
            //    glUniformMatrix4dv = (delegate* unmanaged<GLint, GLsizei, GLboolean, GLdouble[], void>)GetProcAddress("glUniformMatrix4dv");
            //}
            //if (config == null || config.Contains("glUniformMatrix4fv")) {
            //    glUniformMatrix4fv = (delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glUniformMatrix4fv");
            //}
            //if (config == null || config.Contains("glUniformMatrix4fvARB")) {
            //    glUniformMatrix4fvARB = (delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glUniformMatrix4fvARB");
            //}
            //if (config == null || config.Contains("glUniformMatrix4x2dv")) {
            //    glUniformMatrix4x2dv = (delegate* unmanaged<GLint, GLsizei, GLboolean, GLdouble[], void>)GetProcAddress("glUniformMatrix4x2dv");
            //}
            //if (config == null || config.Contains("glUniformMatrix4x2fv")) {
            //    glUniformMatrix4x2fv = (delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glUniformMatrix4x2fv");
            //}
            //if (config == null || config.Contains("glUniformMatrix4x2fvNV")) {
            //    glUniformMatrix4x2fvNV = (delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glUniformMatrix4x2fvNV");
            //}
            //if (config == null || config.Contains("glUniformMatrix4x3dv")) {
            //    glUniformMatrix4x3dv = (delegate* unmanaged<GLint, GLsizei, GLboolean, GLdouble[], void>)GetProcAddress("glUniformMatrix4x3dv");
            //}
            //if (config == null || config.Contains("glUniformMatrix4x3fv")) {
            //    glUniformMatrix4x3fv = (delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glUniformMatrix4x3fv");
            //}
            //if (config == null || config.Contains("glUniformMatrix4x3fvNV")) {
            //    glUniformMatrix4x3fvNV = (delegate* unmanaged<GLint, GLsizei, GLboolean, GLfloat[], void>)GetProcAddress("glUniformMatrix4x3fvNV");
            //}
            //if (config == null || config.Contains("glUniformSubroutinesuiv")) {
            //    glUniformSubroutinesuiv = (delegate* unmanaged<GLenum, GLsizei, GLuint[], void>)GetProcAddress("glUniformSubroutinesuiv");
            //}
            //if (config == null || config.Contains("glUniformui64NV")) {
            //    glUniformui64NV = (delegate* unmanaged<GLint, GLuint64EXT, void>)GetProcAddress("glUniformui64NV");
            //}
            //if (config == null || config.Contains("glUniformui64vNV")) {
            //    glUniformui64vNV = (delegate* unmanaged<GLint, GLsizei, GLuint64EXT[], void>)GetProcAddress("glUniformui64vNV");
            //}
            //if (config == null || config.Contains("glUnlockArraysEXT")) {
            //    glUnlockArraysEXT = (delegate* unmanaged<void>)GetProcAddress("glUnlockArraysEXT");
            //}
            //if (config == null || config.Contains("glUnmapBuffer")) {
            //    glUnmapBuffer = (delegate* unmanaged<GLenum, GLboolean>)GetProcAddress("glUnmapBuffer");
            //}
            //if (config == null || config.Contains("glUnmapBufferARB")) {
            //    glUnmapBufferARB = (delegate* unmanaged<GLenum, GLboolean>)GetProcAddress("glUnmapBufferARB");
            //}
            //if (config == null || config.Contains("glUnmapBufferOES")) {
            //    glUnmapBufferOES = (delegate* unmanaged<GLenum, GLboolean>)GetProcAddress("glUnmapBufferOES");
            //}
            //if (config == null || config.Contains("glUnmapNamedBuffer")) {
            //    glUnmapNamedBuffer = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glUnmapNamedBuffer");
            //}
            //if (config == null || config.Contains("glUnmapNamedBufferEXT")) {
            //    glUnmapNamedBufferEXT = (delegate* unmanaged<GLuint, GLboolean>)GetProcAddress("glUnmapNamedBufferEXT");
            //}
            //if (config == null || config.Contains("glUnmapObjectBufferATI")) {
            //    glUnmapObjectBufferATI = (delegate* unmanaged<GLuint, void>)GetProcAddress("glUnmapObjectBufferATI");
            //}
            //if (config == null || config.Contains("glUnmapTexture2DINTEL")) {
            //    glUnmapTexture2DINTEL = (delegate* unmanaged<GLuint, GLint, void>)GetProcAddress("glUnmapTexture2DINTEL");
            //}
            //if (config == null || config.Contains("glUpdateObjectBufferATI")) {
            //    glUpdateObjectBufferATI = (delegate* unmanaged<GLuint, GLuint, GLsizei, IntPtr, GLenum, void>)GetProcAddress("glUpdateObjectBufferATI");
            //}
            //if (config == null || config.Contains("glUploadGpuMaskNVX")) {
            //    glUploadGpuMaskNVX = (delegate* unmanaged<GLbitfield, void>)GetProcAddress("glUploadGpuMaskNVX");
            //}
            //if (config == null || config.Contains("glUseProgram")) {
            //    glUseProgram = (delegate* unmanaged<GLuint, void>)GetProcAddress("glUseProgram");
            //}
            //if (config == null || config.Contains("glUseProgramObjectARB")) {
            //    glUseProgramObjectARB = (delegate* unmanaged<GLhandleARB, void>)GetProcAddress("glUseProgramObjectARB");
            //}
            //if (config == null || config.Contains("glUseProgramStages")) {
            //    glUseProgramStages = (delegate* unmanaged<GLuint, GLbitfield, GLuint, void>)GetProcAddress("glUseProgramStages");
            //}
            //if (config == null || config.Contains("glUseProgramStagesEXT")) {
            //    glUseProgramStagesEXT = (delegate* unmanaged<GLuint, GLbitfield, GLuint, void>)GetProcAddress("glUseProgramStagesEXT");
            //}
            //if (config == null || config.Contains("glUseShaderProgramEXT")) {
            //    glUseShaderProgramEXT = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glUseShaderProgramEXT");
            //}
            //if (config == null || config.Contains("glVDPAUFiniNV")) {
            //    glVDPAUFiniNV = (delegate* unmanaged<void>)GetProcAddress("glVDPAUFiniNV");
            //}
            //if (config == null || config.Contains("glVDPAUGetSurfaceivNV")) {
            //    glVDPAUGetSurfaceivNV = (delegate* unmanaged<GLvdpauSurfaceNV, GLenum, GLsizei, GLsizei[], GLint[], void>)GetProcAddress("glVDPAUGetSurfaceivNV");
            //}
            //if (config == null || config.Contains("glVDPAUInitNV")) {
            //    glVDPAUInitNV = (delegate* unmanaged<IntPtr, IntPtr, void>)GetProcAddress("glVDPAUInitNV");
            //}
            //if (config == null || config.Contains("glVDPAUIsSurfaceNV")) {
            //    glVDPAUIsSurfaceNV = (delegate* unmanaged<GLvdpauSurfaceNV, GLboolean>)GetProcAddress("glVDPAUIsSurfaceNV");
            //}
            //if (config == null || config.Contains("glVDPAUMapSurfacesNV")) {
            //    glVDPAUMapSurfacesNV = (delegate* unmanaged<GLsizei, GLvdpauSurfaceNV[], void>)GetProcAddress("glVDPAUMapSurfacesNV");
            //}
            //if (config == null || config.Contains("glVDPAURegisterOutputSurfaceNV")) {
            //    glVDPAURegisterOutputSurfaceNV = (delegate* unmanaged<IntPtr, GLenum, GLsizei, GLuint[], GLvdpauSurfaceNV>)GetProcAddress("glVDPAURegisterOutputSurfaceNV");
            //}
            //if (config == null || config.Contains("glVDPAURegisterVideoSurfaceNV")) {
            //    glVDPAURegisterVideoSurfaceNV = (delegate* unmanaged<IntPtr, GLenum, GLsizei, GLuint[], GLvdpauSurfaceNV>)GetProcAddress("glVDPAURegisterVideoSurfaceNV");
            //}
            //if (config == null || config.Contains("glVDPAURegisterVideoSurfaceWithPictureStructureNV")) {
            //    glVDPAURegisterVideoSurfaceWithPictureStructureNV = (delegate* unmanaged<IntPtr, GLenum, GLsizei, GLuint[], GLboolean, GLvdpauSurfaceNV>)GetProcAddress("glVDPAURegisterVideoSurfaceWithPictureStructureNV");
            //}
            //if (config == null || config.Contains("glVDPAUSurfaceAccessNV")) {
            //    glVDPAUSurfaceAccessNV = (delegate* unmanaged<GLvdpauSurfaceNV, GLenum, void>)GetProcAddress("glVDPAUSurfaceAccessNV");
            //}
            //if (config == null || config.Contains("glVDPAUUnmapSurfacesNV")) {
            //    glVDPAUUnmapSurfacesNV = (delegate* unmanaged<GLsizei, GLvdpauSurfaceNV[], void>)GetProcAddress("glVDPAUUnmapSurfacesNV");
            //}
            //if (config == null || config.Contains("glVDPAUUnregisterSurfaceNV")) {
            //    glVDPAUUnregisterSurfaceNV = (delegate* unmanaged<GLvdpauSurfaceNV, void>)GetProcAddress("glVDPAUUnregisterSurfaceNV");
            //}
            //if (config == null || config.Contains("glValidateProgram")) {
            //    glValidateProgram = (delegate* unmanaged<GLuint, void>)GetProcAddress("glValidateProgram");
            //}
            //if (config == null || config.Contains("glValidateProgramARB")) {
            //    glValidateProgramARB = (delegate* unmanaged<GLhandleARB, void>)GetProcAddress("glValidateProgramARB");
            //}
            //if (config == null || config.Contains("glValidateProgramPipeline")) {
            //    glValidateProgramPipeline = (delegate* unmanaged<GLuint, void>)GetProcAddress("glValidateProgramPipeline");
            //}
            //if (config == null || config.Contains("glValidateProgramPipelineEXT")) {
            //    glValidateProgramPipelineEXT = (delegate* unmanaged<GLuint, void>)GetProcAddress("glValidateProgramPipelineEXT");
            //}
            //if (config == null || config.Contains("glVariantArrayObjectATI")) {
            //    glVariantArrayObjectATI = (delegate* unmanaged<GLuint, GLenum, GLsizei, GLuint, GLuint, void>)GetProcAddress("glVariantArrayObjectATI");
            //}
            //if (config == null || config.Contains("glVariantPointerEXT")) {
            //    glVariantPointerEXT = (delegate* unmanaged<GLuint, GLenum, GLuint, IntPtr, void>)GetProcAddress("glVariantPointerEXT");
            //}
            //if (config == null || config.Contains("glVariantbvEXT")) {
            //    glVariantbvEXT = (delegate* unmanaged<GLuint, GLbyte[], void>)GetProcAddress("glVariantbvEXT");
            //}
            //if (config == null || config.Contains("glVariantdvEXT")) {
            //    glVariantdvEXT = (delegate* unmanaged<GLuint, GLdouble[], void>)GetProcAddress("glVariantdvEXT");
            //}
            //if (config == null || config.Contains("glVariantfvEXT")) {
            //    glVariantfvEXT = (delegate* unmanaged<GLuint, GLfloat[], void>)GetProcAddress("glVariantfvEXT");
            //}
            //if (config == null || config.Contains("glVariantivEXT")) {
            //    glVariantivEXT = (delegate* unmanaged<GLuint, GLint[], void>)GetProcAddress("glVariantivEXT");
            //}
            //if (config == null || config.Contains("glVariantsvEXT")) {
            //    glVariantsvEXT = (delegate* unmanaged<GLuint, GLshort[], void>)GetProcAddress("glVariantsvEXT");
            //}
            //if (config == null || config.Contains("glVariantubvEXT")) {
            //    glVariantubvEXT = (delegate* unmanaged<GLuint, GLubyte[], void>)GetProcAddress("glVariantubvEXT");
            //}
            //if (config == null || config.Contains("glVariantuivEXT")) {
            //    glVariantuivEXT = (delegate* unmanaged<GLuint, GLuint[], void>)GetProcAddress("glVariantuivEXT");
            //}
            //if (config == null || config.Contains("glVariantusvEXT")) {
            //    glVariantusvEXT = (delegate* unmanaged<GLuint, GLushort[], void>)GetProcAddress("glVariantusvEXT");
            //}
            //if (config == null || config.Contains("glVertex2bOES")) {
            //    glVertex2bOES = (delegate* unmanaged<GLbyte, GLbyte, void>)GetProcAddress("glVertex2bOES");
            //}
            //if (config == null || config.Contains("glVertex2bvOES")) {
            //    glVertex2bvOES = (delegate* unmanaged<GLbyte[], void>)GetProcAddress("glVertex2bvOES");
            //}
            //if (config == null || config.Contains("glVertex2d")) {
            //    glVertex2d = (delegate* unmanaged<GLdouble, GLdouble, void>)GetProcAddress("glVertex2d");
            //}
            //if (config == null || config.Contains("glVertex2dv")) {
            //    glVertex2dv = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glVertex2dv");
            //}
            //if (config == null || config.Contains("glVertex2f")) {
            //    glVertex2f = (delegate* unmanaged<GLfloat, GLfloat, void>)GetProcAddress("glVertex2f");
            //}
            //if (config == null || config.Contains("glVertex2fv")) {
            //    glVertex2fv = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glVertex2fv");
            //}
            //if (config == null || config.Contains("glVertex2hNV")) {
            //    glVertex2hNV = (delegate* unmanaged<GLhalfNV, GLhalfNV, void>)GetProcAddress("glVertex2hNV");
            //}
            //if (config == null || config.Contains("glVertex2hvNV")) {
            //    glVertex2hvNV = (delegate* unmanaged<GLhalfNV[], void>)GetProcAddress("glVertex2hvNV");
            //}
            //if (config == null || config.Contains("glVertex2i")) {
            //    glVertex2i = (delegate* unmanaged<GLint, GLint, void>)GetProcAddress("glVertex2i");
            //}
            //if (config == null || config.Contains("glVertex2iv")) {
            //    glVertex2iv = (delegate* unmanaged<GLint[], void>)GetProcAddress("glVertex2iv");
            //}
            //if (config == null || config.Contains("glVertex2s")) {
            //    glVertex2s = (delegate* unmanaged<GLshort, GLshort, void>)GetProcAddress("glVertex2s");
            //}
            //if (config == null || config.Contains("glVertex2sv")) {
            //    glVertex2sv = (delegate* unmanaged<GLshort[], void>)GetProcAddress("glVertex2sv");
            //}
            //if (config == null || config.Contains("glVertex2xOES")) {
            //    glVertex2xOES = (delegate* unmanaged<GLfixed, void>)GetProcAddress("glVertex2xOES");
            //}
            //if (config == null || config.Contains("glVertex2xvOES")) {
            //    glVertex2xvOES = (delegate* unmanaged<GLfixed[], void>)GetProcAddress("glVertex2xvOES");
            //}
            //if (config == null || config.Contains("glVertex3bOES")) {
            //    glVertex3bOES = (delegate* unmanaged<GLbyte, GLbyte, GLbyte, void>)GetProcAddress("glVertex3bOES");
            //}
            //if (config == null || config.Contains("glVertex3bvOES")) {
            //    glVertex3bvOES = (delegate* unmanaged<GLbyte[], void>)GetProcAddress("glVertex3bvOES");
            //}
            //if (config == null || config.Contains("glVertex3d")) {
            //    glVertex3d = (delegate* unmanaged<GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glVertex3d");
            //}
            //if (config == null || config.Contains("glVertex3dv")) {
            //    glVertex3dv = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glVertex3dv");
            //}
            //if (config == null || config.Contains("glVertex3f")) {
            //    glVertex3f = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glVertex3f");
            //}
            //if (config == null || config.Contains("glVertex3fv")) {
            //    glVertex3fv = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glVertex3fv");
            //}
            //if (config == null || config.Contains("glVertex3hNV")) {
            //    glVertex3hNV = (delegate* unmanaged<GLhalfNV, GLhalfNV, GLhalfNV, void>)GetProcAddress("glVertex3hNV");
            //}
            //if (config == null || config.Contains("glVertex3hvNV")) {
            //    glVertex3hvNV = (delegate* unmanaged<GLhalfNV[], void>)GetProcAddress("glVertex3hvNV");
            //}
            //if (config == null || config.Contains("glVertex3i")) {
            //    glVertex3i = (delegate* unmanaged<GLint, GLint, GLint, void>)GetProcAddress("glVertex3i");
            //}
            //if (config == null || config.Contains("glVertex3iv")) {
            //    glVertex3iv = (delegate* unmanaged<GLint[], void>)GetProcAddress("glVertex3iv");
            //}
            //if (config == null || config.Contains("glVertex3s")) {
            //    glVertex3s = (delegate* unmanaged<GLshort, GLshort, GLshort, void>)GetProcAddress("glVertex3s");
            //}
            //if (config == null || config.Contains("glVertex3sv")) {
            //    glVertex3sv = (delegate* unmanaged<GLshort[], void>)GetProcAddress("glVertex3sv");
            //}
            //if (config == null || config.Contains("glVertex3xOES")) {
            //    glVertex3xOES = (delegate* unmanaged<GLfixed, GLfixed, void>)GetProcAddress("glVertex3xOES");
            //}
            //if (config == null || config.Contains("glVertex3xvOES")) {
            //    glVertex3xvOES = (delegate* unmanaged<GLfixed[], void>)GetProcAddress("glVertex3xvOES");
            //}
            //if (config == null || config.Contains("glVertex4bOES")) {
            //    glVertex4bOES = (delegate* unmanaged<GLbyte, GLbyte, GLbyte, GLbyte, void>)GetProcAddress("glVertex4bOES");
            //}
            //if (config == null || config.Contains("glVertex4bvOES")) {
            //    glVertex4bvOES = (delegate* unmanaged<GLbyte[], void>)GetProcAddress("glVertex4bvOES");
            //}
            //if (config == null || config.Contains("glVertex4d")) {
            //    glVertex4d = (delegate* unmanaged<GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glVertex4d");
            //}
            //if (config == null || config.Contains("glVertex4dv")) {
            //    glVertex4dv = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glVertex4dv");
            //}
            //if (config == null || config.Contains("glVertex4f")) {
            //    glVertex4f = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glVertex4f");
            //}
            //if (config == null || config.Contains("glVertex4fv")) {
            //    glVertex4fv = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glVertex4fv");
            //}
            //if (config == null || config.Contains("glVertex4hNV")) {
            //    glVertex4hNV = (delegate* unmanaged<GLhalfNV, GLhalfNV, GLhalfNV, GLhalfNV, void>)GetProcAddress("glVertex4hNV");
            //}
            //if (config == null || config.Contains("glVertex4hvNV")) {
            //    glVertex4hvNV = (delegate* unmanaged<GLhalfNV[], void>)GetProcAddress("glVertex4hvNV");
            //}
            //if (config == null || config.Contains("glVertex4i")) {
            //    glVertex4i = (delegate* unmanaged<GLint, GLint, GLint, GLint, void>)GetProcAddress("glVertex4i");
            //}
            //if (config == null || config.Contains("glVertex4iv")) {
            //    glVertex4iv = (delegate* unmanaged<GLint[], void>)GetProcAddress("glVertex4iv");
            //}
            //if (config == null || config.Contains("glVertex4s")) {
            //    glVertex4s = (delegate* unmanaged<GLshort, GLshort, GLshort, GLshort, void>)GetProcAddress("glVertex4s");
            //}
            //if (config == null || config.Contains("glVertex4sv")) {
            //    glVertex4sv = (delegate* unmanaged<GLshort[], void>)GetProcAddress("glVertex4sv");
            //}
            //if (config == null || config.Contains("glVertex4xOES")) {
            //    glVertex4xOES = (delegate* unmanaged<GLfixed, GLfixed, GLfixed, void>)GetProcAddress("glVertex4xOES");
            //}
            //if (config == null || config.Contains("glVertex4xvOES")) {
            //    glVertex4xvOES = (delegate* unmanaged<GLfixed[], void>)GetProcAddress("glVertex4xvOES");
            //}
            //if (config == null || config.Contains("glVertexArrayAttribBinding")) {
            //    glVertexArrayAttribBinding = (delegate* unmanaged<GLuint, GLuint, GLuint, void>)GetProcAddress("glVertexArrayAttribBinding");
            //}
            //if (config == null || config.Contains("glVertexArrayAttribFormat")) {
            //    glVertexArrayAttribFormat = (delegate* unmanaged<GLuint, GLuint, GLint, GLenum, GLboolean, GLuint, void>)GetProcAddress("glVertexArrayAttribFormat");
            //}
            //if (config == null || config.Contains("glVertexArrayAttribIFormat")) {
            //    glVertexArrayAttribIFormat = (delegate* unmanaged<GLuint, GLuint, GLint, GLenum, GLuint, void>)GetProcAddress("glVertexArrayAttribIFormat");
            //}
            //if (config == null || config.Contains("glVertexArrayAttribLFormat")) {
            //    glVertexArrayAttribLFormat = (delegate* unmanaged<GLuint, GLuint, GLint, GLenum, GLuint, void>)GetProcAddress("glVertexArrayAttribLFormat");
            //}
            //if (config == null || config.Contains("glVertexArrayBindVertexBufferEXT")) {
            //    glVertexArrayBindVertexBufferEXT = (delegate* unmanaged<GLuint, GLuint, GLuint, GLintptr, GLsizei, void>)GetProcAddress("glVertexArrayBindVertexBufferEXT");
            //}
            //if (config == null || config.Contains("glVertexArrayBindingDivisor")) {
            //    glVertexArrayBindingDivisor = (delegate* unmanaged<GLuint, GLuint, GLuint, void>)GetProcAddress("glVertexArrayBindingDivisor");
            //}
            //if (config == null || config.Contains("glVertexArrayColorOffsetEXT")) {
            //    glVertexArrayColorOffsetEXT = (delegate* unmanaged<GLuint, GLuint, GLint, GLenum, GLsizei, GLintptr, void>)GetProcAddress("glVertexArrayColorOffsetEXT");
            //}
            //if (config == null || config.Contains("glVertexArrayEdgeFlagOffsetEXT")) {
            //    glVertexArrayEdgeFlagOffsetEXT = (delegate* unmanaged<GLuint, GLuint, GLsizei, GLintptr, void>)GetProcAddress("glVertexArrayEdgeFlagOffsetEXT");
            //}
            //if (config == null || config.Contains("glVertexArrayElementBuffer")) {
            //    glVertexArrayElementBuffer = (delegate* unmanaged<GLuint, GLuint, void>)GetProcAddress("glVertexArrayElementBuffer");
            //}
            //if (config == null || config.Contains("glVertexArrayFogCoordOffsetEXT")) {
            //    glVertexArrayFogCoordOffsetEXT = (delegate* unmanaged<GLuint, GLuint, GLenum, GLsizei, GLintptr, void>)GetProcAddress("glVertexArrayFogCoordOffsetEXT");
            //}
            //if (config == null || config.Contains("glVertexArrayIndexOffsetEXT")) {
            //    glVertexArrayIndexOffsetEXT = (delegate* unmanaged<GLuint, GLuint, GLenum, GLsizei, GLintptr, void>)GetProcAddress("glVertexArrayIndexOffsetEXT");
            //}
            //if (config == null || config.Contains("glVertexArrayMultiTexCoordOffsetEXT")) {
            //    glVertexArrayMultiTexCoordOffsetEXT = (delegate* unmanaged<GLuint, GLuint, GLenum, GLint, GLenum, GLsizei, GLintptr, void>)GetProcAddress("glVertexArrayMultiTexCoordOffsetEXT");
            //}
            //if (config == null || config.Contains("glVertexArrayNormalOffsetEXT")) {
            //    glVertexArrayNormalOffsetEXT = (delegate* unmanaged<GLuint, GLuint, GLenum, GLsizei, GLintptr, void>)GetProcAddress("glVertexArrayNormalOffsetEXT");
            //}
            //if (config == null || config.Contains("glVertexArrayParameteriAPPLE")) {
            //    glVertexArrayParameteriAPPLE = (delegate* unmanaged<GLenum, GLint, void>)GetProcAddress("glVertexArrayParameteriAPPLE");
            //}
            //if (config == null || config.Contains("glVertexArrayRangeAPPLE")) {
            //    glVertexArrayRangeAPPLE = (delegate* unmanaged<GLsizei, IntPtr, void>)GetProcAddress("glVertexArrayRangeAPPLE");
            //}
            //if (config == null || config.Contains("glVertexArrayRangeNV")) {
            //    glVertexArrayRangeNV = (delegate* unmanaged<GLsizei, IntPtr, void>)GetProcAddress("glVertexArrayRangeNV");
            //}
            //if (config == null || config.Contains("glVertexArraySecondaryColorOffsetEXT")) {
            //    glVertexArraySecondaryColorOffsetEXT = (delegate* unmanaged<GLuint, GLuint, GLint, GLenum, GLsizei, GLintptr, void>)GetProcAddress("glVertexArraySecondaryColorOffsetEXT");
            //}
            //if (config == null || config.Contains("glVertexArrayTexCoordOffsetEXT")) {
            //    glVertexArrayTexCoordOffsetEXT = (delegate* unmanaged<GLuint, GLuint, GLint, GLenum, GLsizei, GLintptr, void>)GetProcAddress("glVertexArrayTexCoordOffsetEXT");
            //}
            //if (config == null || config.Contains("glVertexArrayVertexAttribBindingEXT")) {
            //    glVertexArrayVertexAttribBindingEXT = (delegate* unmanaged<GLuint, GLuint, GLuint, void>)GetProcAddress("glVertexArrayVertexAttribBindingEXT");
            //}
            //if (config == null || config.Contains("glVertexArrayVertexAttribDivisorEXT")) {
            //    glVertexArrayVertexAttribDivisorEXT = (delegate* unmanaged<GLuint, GLuint, GLuint, void>)GetProcAddress("glVertexArrayVertexAttribDivisorEXT");
            //}
            //if (config == null || config.Contains("glVertexArrayVertexAttribFormatEXT")) {
            //    glVertexArrayVertexAttribFormatEXT = (delegate* unmanaged<GLuint, GLuint, GLint, GLenum, GLboolean, GLuint, void>)GetProcAddress("glVertexArrayVertexAttribFormatEXT");
            //}
            //if (config == null || config.Contains("glVertexArrayVertexAttribIFormatEXT")) {
            //    glVertexArrayVertexAttribIFormatEXT = (delegate* unmanaged<GLuint, GLuint, GLint, GLenum, GLuint, void>)GetProcAddress("glVertexArrayVertexAttribIFormatEXT");
            //}
            //if (config == null || config.Contains("glVertexArrayVertexAttribIOffsetEXT")) {
            //    glVertexArrayVertexAttribIOffsetEXT = (delegate* unmanaged<GLuint, GLuint, GLuint, GLint, GLenum, GLsizei, GLintptr, void>)GetProcAddress("glVertexArrayVertexAttribIOffsetEXT");
            //}
            //if (config == null || config.Contains("glVertexArrayVertexAttribLFormatEXT")) {
            //    glVertexArrayVertexAttribLFormatEXT = (delegate* unmanaged<GLuint, GLuint, GLint, GLenum, GLuint, void>)GetProcAddress("glVertexArrayVertexAttribLFormatEXT");
            //}
            //if (config == null || config.Contains("glVertexArrayVertexAttribLOffsetEXT")) {
            //    glVertexArrayVertexAttribLOffsetEXT = (delegate* unmanaged<GLuint, GLuint, GLuint, GLint, GLenum, GLsizei, GLintptr, void>)GetProcAddress("glVertexArrayVertexAttribLOffsetEXT");
            //}
            //if (config == null || config.Contains("glVertexArrayVertexAttribOffsetEXT")) {
            //    glVertexArrayVertexAttribOffsetEXT = (delegate* unmanaged<GLuint, GLuint, GLuint, GLint, GLenum, GLboolean, GLsizei, GLintptr, void>)GetProcAddress("glVertexArrayVertexAttribOffsetEXT");
            //}
            //if (config == null || config.Contains("glVertexArrayVertexBindingDivisorEXT")) {
            //    glVertexArrayVertexBindingDivisorEXT = (delegate* unmanaged<GLuint, GLuint, GLuint, void>)GetProcAddress("glVertexArrayVertexBindingDivisorEXT");
            //}
            //if (config == null || config.Contains("glVertexArrayVertexBuffer")) {
            //    glVertexArrayVertexBuffer = (delegate* unmanaged<GLuint, GLuint, GLuint, GLintptr, GLsizei, void>)GetProcAddress("glVertexArrayVertexBuffer");
            //}
            //if (config == null || config.Contains("glVertexArrayVertexBuffers")) {
            //    glVertexArrayVertexBuffers = (delegate* unmanaged<GLuint, GLuint, GLsizei, GLuint[], GLintptr[], GLsizei[], void>)GetProcAddress("glVertexArrayVertexBuffers");
            //}
            //if (config == null || config.Contains("glVertexArrayVertexOffsetEXT")) {
            //    glVertexArrayVertexOffsetEXT = (delegate* unmanaged<GLuint, GLuint, GLint, GLenum, GLsizei, GLintptr, void>)GetProcAddress("glVertexArrayVertexOffsetEXT");
            //}
            //if (config == null || config.Contains("glVertexAttrib1d")) {
            //    glVertexAttrib1d = (delegate* unmanaged<GLuint, GLdouble, void>)GetProcAddress("glVertexAttrib1d");
            //}
            //if (config == null || config.Contains("glVertexAttrib1dARB")) {
            //    glVertexAttrib1dARB = (delegate* unmanaged<GLuint, GLdouble, void>)GetProcAddress("glVertexAttrib1dARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib1dNV")) {
            //    glVertexAttrib1dNV = (delegate* unmanaged<GLuint, GLdouble, void>)GetProcAddress("glVertexAttrib1dNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib1dv")) {
            //    glVertexAttrib1dv = (delegate* unmanaged<GLuint, GLdouble[], void>)GetProcAddress("glVertexAttrib1dv");
            //}
            //if (config == null || config.Contains("glVertexAttrib1dvARB")) {
            //    glVertexAttrib1dvARB = (delegate* unmanaged<GLuint, GLdouble[], void>)GetProcAddress("glVertexAttrib1dvARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib1dvNV")) {
            //    glVertexAttrib1dvNV = (delegate* unmanaged<GLuint, GLdouble[], void>)GetProcAddress("glVertexAttrib1dvNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib1f")) {
            //    glVertexAttrib1f = (delegate* unmanaged<GLuint, GLfloat, void>)GetProcAddress("glVertexAttrib1f");
            //}
            //if (config == null || config.Contains("glVertexAttrib1fARB")) {
            //    glVertexAttrib1fARB = (delegate* unmanaged<GLuint, GLfloat, void>)GetProcAddress("glVertexAttrib1fARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib1fNV")) {
            //    glVertexAttrib1fNV = (delegate* unmanaged<GLuint, GLfloat, void>)GetProcAddress("glVertexAttrib1fNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib1fv")) {
            //    glVertexAttrib1fv = (delegate* unmanaged<GLuint, GLfloat[], void>)GetProcAddress("glVertexAttrib1fv");
            //}
            //if (config == null || config.Contains("glVertexAttrib1fvARB")) {
            //    glVertexAttrib1fvARB = (delegate* unmanaged<GLuint, GLfloat[], void>)GetProcAddress("glVertexAttrib1fvARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib1fvNV")) {
            //    glVertexAttrib1fvNV = (delegate* unmanaged<GLuint, GLfloat[], void>)GetProcAddress("glVertexAttrib1fvNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib1hNV")) {
            //    glVertexAttrib1hNV = (delegate* unmanaged<GLuint, GLhalfNV, void>)GetProcAddress("glVertexAttrib1hNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib1hvNV")) {
            //    glVertexAttrib1hvNV = (delegate* unmanaged<GLuint, GLhalfNV[], void>)GetProcAddress("glVertexAttrib1hvNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib1s")) {
            //    glVertexAttrib1s = (delegate* unmanaged<GLuint, GLshort, void>)GetProcAddress("glVertexAttrib1s");
            //}
            //if (config == null || config.Contains("glVertexAttrib1sARB")) {
            //    glVertexAttrib1sARB = (delegate* unmanaged<GLuint, GLshort, void>)GetProcAddress("glVertexAttrib1sARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib1sNV")) {
            //    glVertexAttrib1sNV = (delegate* unmanaged<GLuint, GLshort, void>)GetProcAddress("glVertexAttrib1sNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib1sv")) {
            //    glVertexAttrib1sv = (delegate* unmanaged<GLuint, GLshort[], void>)GetProcAddress("glVertexAttrib1sv");
            //}
            //if (config == null || config.Contains("glVertexAttrib1svARB")) {
            //    glVertexAttrib1svARB = (delegate* unmanaged<GLuint, GLshort[], void>)GetProcAddress("glVertexAttrib1svARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib1svNV")) {
            //    glVertexAttrib1svNV = (delegate* unmanaged<GLuint, GLshort[], void>)GetProcAddress("glVertexAttrib1svNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib2d")) {
            //    glVertexAttrib2d = (delegate* unmanaged<GLuint, GLdouble, GLdouble, void>)GetProcAddress("glVertexAttrib2d");
            //}
            //if (config == null || config.Contains("glVertexAttrib2dARB")) {
            //    glVertexAttrib2dARB = (delegate* unmanaged<GLuint, GLdouble, GLdouble, void>)GetProcAddress("glVertexAttrib2dARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib2dNV")) {
            //    glVertexAttrib2dNV = (delegate* unmanaged<GLuint, GLdouble, GLdouble, void>)GetProcAddress("glVertexAttrib2dNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib2dv")) {
            //    glVertexAttrib2dv = (delegate* unmanaged<GLuint, GLdouble[], void>)GetProcAddress("glVertexAttrib2dv");
            //}
            //if (config == null || config.Contains("glVertexAttrib2dvARB")) {
            //    glVertexAttrib2dvARB = (delegate* unmanaged<GLuint, GLdouble[], void>)GetProcAddress("glVertexAttrib2dvARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib2dvNV")) {
            //    glVertexAttrib2dvNV = (delegate* unmanaged<GLuint, GLdouble[], void>)GetProcAddress("glVertexAttrib2dvNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib2f")) {
            //    glVertexAttrib2f = (delegate* unmanaged<GLuint, GLfloat, GLfloat, void>)GetProcAddress("glVertexAttrib2f");
            //}
            //if (config == null || config.Contains("glVertexAttrib2fARB")) {
            //    glVertexAttrib2fARB = (delegate* unmanaged<GLuint, GLfloat, GLfloat, void>)GetProcAddress("glVertexAttrib2fARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib2fNV")) {
            //    glVertexAttrib2fNV = (delegate* unmanaged<GLuint, GLfloat, GLfloat, void>)GetProcAddress("glVertexAttrib2fNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib2fv")) {
            //    glVertexAttrib2fv = (delegate* unmanaged<GLuint, GLfloat[], void>)GetProcAddress("glVertexAttrib2fv");
            //}
            //if (config == null || config.Contains("glVertexAttrib2fvARB")) {
            //    glVertexAttrib2fvARB = (delegate* unmanaged<GLuint, GLfloat[], void>)GetProcAddress("glVertexAttrib2fvARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib2fvNV")) {
            //    glVertexAttrib2fvNV = (delegate* unmanaged<GLuint, GLfloat[], void>)GetProcAddress("glVertexAttrib2fvNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib2hNV")) {
            //    glVertexAttrib2hNV = (delegate* unmanaged<GLuint, GLhalfNV, GLhalfNV, void>)GetProcAddress("glVertexAttrib2hNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib2hvNV")) {
            //    glVertexAttrib2hvNV = (delegate* unmanaged<GLuint, GLhalfNV[], void>)GetProcAddress("glVertexAttrib2hvNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib2s")) {
            //    glVertexAttrib2s = (delegate* unmanaged<GLuint, GLshort, GLshort, void>)GetProcAddress("glVertexAttrib2s");
            //}
            //if (config == null || config.Contains("glVertexAttrib2sARB")) {
            //    glVertexAttrib2sARB = (delegate* unmanaged<GLuint, GLshort, GLshort, void>)GetProcAddress("glVertexAttrib2sARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib2sNV")) {
            //    glVertexAttrib2sNV = (delegate* unmanaged<GLuint, GLshort, GLshort, void>)GetProcAddress("glVertexAttrib2sNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib2sv")) {
            //    glVertexAttrib2sv = (delegate* unmanaged<GLuint, GLshort[], void>)GetProcAddress("glVertexAttrib2sv");
            //}
            //if (config == null || config.Contains("glVertexAttrib2svARB")) {
            //    glVertexAttrib2svARB = (delegate* unmanaged<GLuint, GLshort[], void>)GetProcAddress("glVertexAttrib2svARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib2svNV")) {
            //    glVertexAttrib2svNV = (delegate* unmanaged<GLuint, GLshort[], void>)GetProcAddress("glVertexAttrib2svNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib3d")) {
            //    glVertexAttrib3d = (delegate* unmanaged<GLuint, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glVertexAttrib3d");
            //}
            //if (config == null || config.Contains("glVertexAttrib3dARB")) {
            //    glVertexAttrib3dARB = (delegate* unmanaged<GLuint, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glVertexAttrib3dARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib3dNV")) {
            //    glVertexAttrib3dNV = (delegate* unmanaged<GLuint, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glVertexAttrib3dNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib3dv")) {
            //    glVertexAttrib3dv = (delegate* unmanaged<GLuint, GLdouble[], void>)GetProcAddress("glVertexAttrib3dv");
            //}
            //if (config == null || config.Contains("glVertexAttrib3dvARB")) {
            //    glVertexAttrib3dvARB = (delegate* unmanaged<GLuint, GLdouble[], void>)GetProcAddress("glVertexAttrib3dvARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib3dvNV")) {
            //    glVertexAttrib3dvNV = (delegate* unmanaged<GLuint, GLdouble[], void>)GetProcAddress("glVertexAttrib3dvNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib3f")) {
            //    glVertexAttrib3f = (delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glVertexAttrib3f");
            //}
            //if (config == null || config.Contains("glVertexAttrib3fARB")) {
            //    glVertexAttrib3fARB = (delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glVertexAttrib3fARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib3fNV")) {
            //    glVertexAttrib3fNV = (delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glVertexAttrib3fNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib3fv")) {
            //    glVertexAttrib3fv = (delegate* unmanaged<GLuint, GLfloat[], void>)GetProcAddress("glVertexAttrib3fv");
            //}
            //if (config == null || config.Contains("glVertexAttrib3fvARB")) {
            //    glVertexAttrib3fvARB = (delegate* unmanaged<GLuint, GLfloat[], void>)GetProcAddress("glVertexAttrib3fvARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib3fvNV")) {
            //    glVertexAttrib3fvNV = (delegate* unmanaged<GLuint, GLfloat[], void>)GetProcAddress("glVertexAttrib3fvNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib3hNV")) {
            //    glVertexAttrib3hNV = (delegate* unmanaged<GLuint, GLhalfNV, GLhalfNV, GLhalfNV, void>)GetProcAddress("glVertexAttrib3hNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib3hvNV")) {
            //    glVertexAttrib3hvNV = (delegate* unmanaged<GLuint, GLhalfNV[], void>)GetProcAddress("glVertexAttrib3hvNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib3s")) {
            //    glVertexAttrib3s = (delegate* unmanaged<GLuint, GLshort, GLshort, GLshort, void>)GetProcAddress("glVertexAttrib3s");
            //}
            //if (config == null || config.Contains("glVertexAttrib3sARB")) {
            //    glVertexAttrib3sARB = (delegate* unmanaged<GLuint, GLshort, GLshort, GLshort, void>)GetProcAddress("glVertexAttrib3sARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib3sNV")) {
            //    glVertexAttrib3sNV = (delegate* unmanaged<GLuint, GLshort, GLshort, GLshort, void>)GetProcAddress("glVertexAttrib3sNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib3sv")) {
            //    glVertexAttrib3sv = (delegate* unmanaged<GLuint, GLshort[], void>)GetProcAddress("glVertexAttrib3sv");
            //}
            //if (config == null || config.Contains("glVertexAttrib3svARB")) {
            //    glVertexAttrib3svARB = (delegate* unmanaged<GLuint, GLshort[], void>)GetProcAddress("glVertexAttrib3svARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib3svNV")) {
            //    glVertexAttrib3svNV = (delegate* unmanaged<GLuint, GLshort[], void>)GetProcAddress("glVertexAttrib3svNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib4Nbv")) {
            //    glVertexAttrib4Nbv = (delegate* unmanaged<GLuint, GLbyte[], void>)GetProcAddress("glVertexAttrib4Nbv");
            //}
            //if (config == null || config.Contains("glVertexAttrib4NbvARB")) {
            //    glVertexAttrib4NbvARB = (delegate* unmanaged<GLuint, GLbyte[], void>)GetProcAddress("glVertexAttrib4NbvARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib4Niv")) {
            //    glVertexAttrib4Niv = (delegate* unmanaged<GLuint, GLint[], void>)GetProcAddress("glVertexAttrib4Niv");
            //}
            //if (config == null || config.Contains("glVertexAttrib4NivARB")) {
            //    glVertexAttrib4NivARB = (delegate* unmanaged<GLuint, GLint[], void>)GetProcAddress("glVertexAttrib4NivARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib4Nsv")) {
            //    glVertexAttrib4Nsv = (delegate* unmanaged<GLuint, GLshort[], void>)GetProcAddress("glVertexAttrib4Nsv");
            //}
            //if (config == null || config.Contains("glVertexAttrib4NsvARB")) {
            //    glVertexAttrib4NsvARB = (delegate* unmanaged<GLuint, GLshort[], void>)GetProcAddress("glVertexAttrib4NsvARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib4Nub")) {
            //    glVertexAttrib4Nub = (delegate* unmanaged<GLuint, GLubyte, GLubyte, GLubyte, GLubyte, void>)GetProcAddress("glVertexAttrib4Nub");
            //}
            //if (config == null || config.Contains("glVertexAttrib4NubARB")) {
            //    glVertexAttrib4NubARB = (delegate* unmanaged<GLuint, GLubyte, GLubyte, GLubyte, GLubyte, void>)GetProcAddress("glVertexAttrib4NubARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib4Nubv")) {
            //    glVertexAttrib4Nubv = (delegate* unmanaged<GLuint, GLubyte[], void>)GetProcAddress("glVertexAttrib4Nubv");
            //}
            //if (config == null || config.Contains("glVertexAttrib4NubvARB")) {
            //    glVertexAttrib4NubvARB = (delegate* unmanaged<GLuint, GLubyte[], void>)GetProcAddress("glVertexAttrib4NubvARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib4Nuiv")) {
            //    glVertexAttrib4Nuiv = (delegate* unmanaged<GLuint, GLuint[], void>)GetProcAddress("glVertexAttrib4Nuiv");
            //}
            //if (config == null || config.Contains("glVertexAttrib4NuivARB")) {
            //    glVertexAttrib4NuivARB = (delegate* unmanaged<GLuint, GLuint[], void>)GetProcAddress("glVertexAttrib4NuivARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib4Nusv")) {
            //    glVertexAttrib4Nusv = (delegate* unmanaged<GLuint, GLushort[], void>)GetProcAddress("glVertexAttrib4Nusv");
            //}
            //if (config == null || config.Contains("glVertexAttrib4NusvARB")) {
            //    glVertexAttrib4NusvARB = (delegate* unmanaged<GLuint, GLushort[], void>)GetProcAddress("glVertexAttrib4NusvARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib4bv")) {
            //    glVertexAttrib4bv = (delegate* unmanaged<GLuint, GLbyte[], void>)GetProcAddress("glVertexAttrib4bv");
            //}
            //if (config == null || config.Contains("glVertexAttrib4bvARB")) {
            //    glVertexAttrib4bvARB = (delegate* unmanaged<GLuint, GLbyte[], void>)GetProcAddress("glVertexAttrib4bvARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib4d")) {
            //    glVertexAttrib4d = (delegate* unmanaged<GLuint, GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glVertexAttrib4d");
            //}
            //if (config == null || config.Contains("glVertexAttrib4dARB")) {
            //    glVertexAttrib4dARB = (delegate* unmanaged<GLuint, GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glVertexAttrib4dARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib4dNV")) {
            //    glVertexAttrib4dNV = (delegate* unmanaged<GLuint, GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glVertexAttrib4dNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib4dv")) {
            //    glVertexAttrib4dv = (delegate* unmanaged<GLuint, GLdouble[], void>)GetProcAddress("glVertexAttrib4dv");
            //}
            //if (config == null || config.Contains("glVertexAttrib4dvARB")) {
            //    glVertexAttrib4dvARB = (delegate* unmanaged<GLuint, GLdouble[], void>)GetProcAddress("glVertexAttrib4dvARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib4dvNV")) {
            //    glVertexAttrib4dvNV = (delegate* unmanaged<GLuint, GLdouble[], void>)GetProcAddress("glVertexAttrib4dvNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib4f")) {
            //    glVertexAttrib4f = (delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glVertexAttrib4f");
            //}
            //if (config == null || config.Contains("glVertexAttrib4fARB")) {
            //    glVertexAttrib4fARB = (delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glVertexAttrib4fARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib4fNV")) {
            //    glVertexAttrib4fNV = (delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glVertexAttrib4fNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib4fv")) {
            //    glVertexAttrib4fv = (delegate* unmanaged<GLuint, GLfloat[], void>)GetProcAddress("glVertexAttrib4fv");
            //}
            //if (config == null || config.Contains("glVertexAttrib4fvARB")) {
            //    glVertexAttrib4fvARB = (delegate* unmanaged<GLuint, GLfloat[], void>)GetProcAddress("glVertexAttrib4fvARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib4fvNV")) {
            //    glVertexAttrib4fvNV = (delegate* unmanaged<GLuint, GLfloat[], void>)GetProcAddress("glVertexAttrib4fvNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib4hNV")) {
            //    glVertexAttrib4hNV = (delegate* unmanaged<GLuint, GLhalfNV, GLhalfNV, GLhalfNV, GLhalfNV, void>)GetProcAddress("glVertexAttrib4hNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib4hvNV")) {
            //    glVertexAttrib4hvNV = (delegate* unmanaged<GLuint, GLhalfNV[], void>)GetProcAddress("glVertexAttrib4hvNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib4iv")) {
            //    glVertexAttrib4iv = (delegate* unmanaged<GLuint, GLint[], void>)GetProcAddress("glVertexAttrib4iv");
            //}
            //if (config == null || config.Contains("glVertexAttrib4ivARB")) {
            //    glVertexAttrib4ivARB = (delegate* unmanaged<GLuint, GLint[], void>)GetProcAddress("glVertexAttrib4ivARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib4s")) {
            //    glVertexAttrib4s = (delegate* unmanaged<GLuint, GLshort, GLshort, GLshort, GLshort, void>)GetProcAddress("glVertexAttrib4s");
            //}
            //if (config == null || config.Contains("glVertexAttrib4sARB")) {
            //    glVertexAttrib4sARB = (delegate* unmanaged<GLuint, GLshort, GLshort, GLshort, GLshort, void>)GetProcAddress("glVertexAttrib4sARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib4sNV")) {
            //    glVertexAttrib4sNV = (delegate* unmanaged<GLuint, GLshort, GLshort, GLshort, GLshort, void>)GetProcAddress("glVertexAttrib4sNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib4sv")) {
            //    glVertexAttrib4sv = (delegate* unmanaged<GLuint, GLshort[], void>)GetProcAddress("glVertexAttrib4sv");
            //}
            //if (config == null || config.Contains("glVertexAttrib4svARB")) {
            //    glVertexAttrib4svARB = (delegate* unmanaged<GLuint, GLshort[], void>)GetProcAddress("glVertexAttrib4svARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib4svNV")) {
            //    glVertexAttrib4svNV = (delegate* unmanaged<GLuint, GLshort[], void>)GetProcAddress("glVertexAttrib4svNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib4ubNV")) {
            //    glVertexAttrib4ubNV = (delegate* unmanaged<GLuint, GLubyte, GLubyte, GLubyte, GLubyte, void>)GetProcAddress("glVertexAttrib4ubNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib4ubv")) {
            //    glVertexAttrib4ubv = (delegate* unmanaged<GLuint, GLubyte[], void>)GetProcAddress("glVertexAttrib4ubv");
            //}
            //if (config == null || config.Contains("glVertexAttrib4ubvARB")) {
            //    glVertexAttrib4ubvARB = (delegate* unmanaged<GLuint, GLubyte[], void>)GetProcAddress("glVertexAttrib4ubvARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib4ubvNV")) {
            //    glVertexAttrib4ubvNV = (delegate* unmanaged<GLuint, GLubyte[], void>)GetProcAddress("glVertexAttrib4ubvNV");
            //}
            //if (config == null || config.Contains("glVertexAttrib4uiv")) {
            //    glVertexAttrib4uiv = (delegate* unmanaged<GLuint, GLuint[], void>)GetProcAddress("glVertexAttrib4uiv");
            //}
            //if (config == null || config.Contains("glVertexAttrib4uivARB")) {
            //    glVertexAttrib4uivARB = (delegate* unmanaged<GLuint, GLuint[], void>)GetProcAddress("glVertexAttrib4uivARB");
            //}
            //if (config == null || config.Contains("glVertexAttrib4usv")) {
            //    glVertexAttrib4usv = (delegate* unmanaged<GLuint, GLushort[], void>)GetProcAddress("glVertexAttrib4usv");
            //}
            //if (config == null || config.Contains("glVertexAttrib4usvARB")) {
            //    glVertexAttrib4usvARB = (delegate* unmanaged<GLuint, GLushort[], void>)GetProcAddress("glVertexAttrib4usvARB");
            //}
            //if (config == null || config.Contains("glVertexAttribArrayObjectATI")) {
            //    glVertexAttribArrayObjectATI = (delegate* unmanaged<GLuint, GLint, GLenum, GLboolean, GLsizei, GLuint, GLuint, void>)GetProcAddress("glVertexAttribArrayObjectATI");
            //}
            //if (config == null || config.Contains("glVertexAttribBinding")) {
            //    glVertexAttribBinding = (delegate* unmanaged<GLuint, GLuint, void>)GetProcAddress("glVertexAttribBinding");
            //}
            //if (config == null || config.Contains("glVertexAttribDivisor")) {
            //    glVertexAttribDivisor = (delegate* unmanaged<GLuint, GLuint, void>)GetProcAddress("glVertexAttribDivisor");
            //}
            //if (config == null || config.Contains("glVertexAttribDivisorANGLE")) {
            //    glVertexAttribDivisorANGLE = (delegate* unmanaged<GLuint, GLuint, void>)GetProcAddress("glVertexAttribDivisorANGLE");
            //}
            //if (config == null || config.Contains("glVertexAttribDivisorARB")) {
            //    glVertexAttribDivisorARB = (delegate* unmanaged<GLuint, GLuint, void>)GetProcAddress("glVertexAttribDivisorARB");
            //}
            //if (config == null || config.Contains("glVertexAttribDivisorEXT")) {
            //    glVertexAttribDivisorEXT = (delegate* unmanaged<GLuint, GLuint, void>)GetProcAddress("glVertexAttribDivisorEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribDivisorNV")) {
            //    glVertexAttribDivisorNV = (delegate* unmanaged<GLuint, GLuint, void>)GetProcAddress("glVertexAttribDivisorNV");
            //}
            //if (config == null || config.Contains("glVertexAttribFormat")) {
            //    glVertexAttribFormat = (delegate* unmanaged<GLuint, GLint, GLenum, GLboolean, GLuint, void>)GetProcAddress("glVertexAttribFormat");
            //}
            //if (config == null || config.Contains("glVertexAttribFormatNV")) {
            //    glVertexAttribFormatNV = (delegate* unmanaged<GLuint, GLint, GLenum, GLboolean, GLsizei, void>)GetProcAddress("glVertexAttribFormatNV");
            //}
            //if (config == null || config.Contains("glVertexAttribI1i")) {
            //    glVertexAttribI1i = (delegate* unmanaged<GLuint, GLint, void>)GetProcAddress("glVertexAttribI1i");
            //}
            //if (config == null || config.Contains("glVertexAttribI1iEXT")) {
            //    glVertexAttribI1iEXT = (delegate* unmanaged<GLuint, GLint, void>)GetProcAddress("glVertexAttribI1iEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribI1iv")) {
            //    glVertexAttribI1iv = (delegate* unmanaged<GLuint, GLint[], void>)GetProcAddress("glVertexAttribI1iv");
            //}
            //if (config == null || config.Contains("glVertexAttribI1ivEXT")) {
            //    glVertexAttribI1ivEXT = (delegate* unmanaged<GLuint, GLint[], void>)GetProcAddress("glVertexAttribI1ivEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribI1ui")) {
            //    glVertexAttribI1ui = (delegate* unmanaged<GLuint, GLuint, void>)GetProcAddress("glVertexAttribI1ui");
            //}
            //if (config == null || config.Contains("glVertexAttribI1uiEXT")) {
            //    glVertexAttribI1uiEXT = (delegate* unmanaged<GLuint, GLuint, void>)GetProcAddress("glVertexAttribI1uiEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribI1uiv")) {
            //    glVertexAttribI1uiv = (delegate* unmanaged<GLuint, GLuint[], void>)GetProcAddress("glVertexAttribI1uiv");
            //}
            //if (config == null || config.Contains("glVertexAttribI1uivEXT")) {
            //    glVertexAttribI1uivEXT = (delegate* unmanaged<GLuint, GLuint[], void>)GetProcAddress("glVertexAttribI1uivEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribI2i")) {
            //    glVertexAttribI2i = (delegate* unmanaged<GLuint, GLint, GLint, void>)GetProcAddress("glVertexAttribI2i");
            //}
            //if (config == null || config.Contains("glVertexAttribI2iEXT")) {
            //    glVertexAttribI2iEXT = (delegate* unmanaged<GLuint, GLint, GLint, void>)GetProcAddress("glVertexAttribI2iEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribI2iv")) {
            //    glVertexAttribI2iv = (delegate* unmanaged<GLuint, GLint[], void>)GetProcAddress("glVertexAttribI2iv");
            //}
            //if (config == null || config.Contains("glVertexAttribI2ivEXT")) {
            //    glVertexAttribI2ivEXT = (delegate* unmanaged<GLuint, GLint[], void>)GetProcAddress("glVertexAttribI2ivEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribI2ui")) {
            //    glVertexAttribI2ui = (delegate* unmanaged<GLuint, GLuint, GLuint, void>)GetProcAddress("glVertexAttribI2ui");
            //}
            //if (config == null || config.Contains("glVertexAttribI2uiEXT")) {
            //    glVertexAttribI2uiEXT = (delegate* unmanaged<GLuint, GLuint, GLuint, void>)GetProcAddress("glVertexAttribI2uiEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribI2uiv")) {
            //    glVertexAttribI2uiv = (delegate* unmanaged<GLuint, GLuint[], void>)GetProcAddress("glVertexAttribI2uiv");
            //}
            //if (config == null || config.Contains("glVertexAttribI2uivEXT")) {
            //    glVertexAttribI2uivEXT = (delegate* unmanaged<GLuint, GLuint[], void>)GetProcAddress("glVertexAttribI2uivEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribI3i")) {
            //    glVertexAttribI3i = (delegate* unmanaged<GLuint, GLint, GLint, GLint, void>)GetProcAddress("glVertexAttribI3i");
            //}
            //if (config == null || config.Contains("glVertexAttribI3iEXT")) {
            //    glVertexAttribI3iEXT = (delegate* unmanaged<GLuint, GLint, GLint, GLint, void>)GetProcAddress("glVertexAttribI3iEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribI3iv")) {
            //    glVertexAttribI3iv = (delegate* unmanaged<GLuint, GLint[], void>)GetProcAddress("glVertexAttribI3iv");
            //}
            //if (config == null || config.Contains("glVertexAttribI3ivEXT")) {
            //    glVertexAttribI3ivEXT = (delegate* unmanaged<GLuint, GLint[], void>)GetProcAddress("glVertexAttribI3ivEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribI3ui")) {
            //    glVertexAttribI3ui = (delegate* unmanaged<GLuint, GLuint, GLuint, GLuint, void>)GetProcAddress("glVertexAttribI3ui");
            //}
            //if (config == null || config.Contains("glVertexAttribI3uiEXT")) {
            //    glVertexAttribI3uiEXT = (delegate* unmanaged<GLuint, GLuint, GLuint, GLuint, void>)GetProcAddress("glVertexAttribI3uiEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribI3uiv")) {
            //    glVertexAttribI3uiv = (delegate* unmanaged<GLuint, GLuint[], void>)GetProcAddress("glVertexAttribI3uiv");
            //}
            //if (config == null || config.Contains("glVertexAttribI3uivEXT")) {
            //    glVertexAttribI3uivEXT = (delegate* unmanaged<GLuint, GLuint[], void>)GetProcAddress("glVertexAttribI3uivEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribI4bv")) {
            //    glVertexAttribI4bv = (delegate* unmanaged<GLuint, GLbyte[], void>)GetProcAddress("glVertexAttribI4bv");
            //}
            //if (config == null || config.Contains("glVertexAttribI4bvEXT")) {
            //    glVertexAttribI4bvEXT = (delegate* unmanaged<GLuint, GLbyte[], void>)GetProcAddress("glVertexAttribI4bvEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribI4i")) {
            //    glVertexAttribI4i = (delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, void>)GetProcAddress("glVertexAttribI4i");
            //}
            //if (config == null || config.Contains("glVertexAttribI4iEXT")) {
            //    glVertexAttribI4iEXT = (delegate* unmanaged<GLuint, GLint, GLint, GLint, GLint, void>)GetProcAddress("glVertexAttribI4iEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribI4iv")) {
            //    glVertexAttribI4iv = (delegate* unmanaged<GLuint, GLint[], void>)GetProcAddress("glVertexAttribI4iv");
            //}
            //if (config == null || config.Contains("glVertexAttribI4ivEXT")) {
            //    glVertexAttribI4ivEXT = (delegate* unmanaged<GLuint, GLint[], void>)GetProcAddress("glVertexAttribI4ivEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribI4sv")) {
            //    glVertexAttribI4sv = (delegate* unmanaged<GLuint, GLshort[], void>)GetProcAddress("glVertexAttribI4sv");
            //}
            //if (config == null || config.Contains("glVertexAttribI4svEXT")) {
            //    glVertexAttribI4svEXT = (delegate* unmanaged<GLuint, GLshort[], void>)GetProcAddress("glVertexAttribI4svEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribI4ubv")) {
            //    glVertexAttribI4ubv = (delegate* unmanaged<GLuint, GLubyte[], void>)GetProcAddress("glVertexAttribI4ubv");
            //}
            //if (config == null || config.Contains("glVertexAttribI4ubvEXT")) {
            //    glVertexAttribI4ubvEXT = (delegate* unmanaged<GLuint, GLubyte[], void>)GetProcAddress("glVertexAttribI4ubvEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribI4ui")) {
            //    glVertexAttribI4ui = (delegate* unmanaged<GLuint, GLuint, GLuint, GLuint, GLuint, void>)GetProcAddress("glVertexAttribI4ui");
            //}
            //if (config == null || config.Contains("glVertexAttribI4uiEXT")) {
            //    glVertexAttribI4uiEXT = (delegate* unmanaged<GLuint, GLuint, GLuint, GLuint, GLuint, void>)GetProcAddress("glVertexAttribI4uiEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribI4uiv")) {
            //    glVertexAttribI4uiv = (delegate* unmanaged<GLuint, GLuint[], void>)GetProcAddress("glVertexAttribI4uiv");
            //}
            //if (config == null || config.Contains("glVertexAttribI4uivEXT")) {
            //    glVertexAttribI4uivEXT = (delegate* unmanaged<GLuint, GLuint[], void>)GetProcAddress("glVertexAttribI4uivEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribI4usv")) {
            //    glVertexAttribI4usv = (delegate* unmanaged<GLuint, GLushort[], void>)GetProcAddress("glVertexAttribI4usv");
            //}
            //if (config == null || config.Contains("glVertexAttribI4usvEXT")) {
            //    glVertexAttribI4usvEXT = (delegate* unmanaged<GLuint, GLushort[], void>)GetProcAddress("glVertexAttribI4usvEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribIFormat")) {
            //    glVertexAttribIFormat = (delegate* unmanaged<GLuint, GLint, GLenum, GLuint, void>)GetProcAddress("glVertexAttribIFormat");
            //}
            //if (config == null || config.Contains("glVertexAttribIFormatNV")) {
            //    glVertexAttribIFormatNV = (delegate* unmanaged<GLuint, GLint, GLenum, GLsizei, void>)GetProcAddress("glVertexAttribIFormatNV");
            //}
            //if (config == null || config.Contains("glVertexAttribIPointer")) {
            //    glVertexAttribIPointer = (delegate* unmanaged<GLuint, GLint, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glVertexAttribIPointer");
            //}
            //if (config == null || config.Contains("glVertexAttribIPointerEXT")) {
            //    glVertexAttribIPointerEXT = (delegate* unmanaged<GLuint, GLint, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glVertexAttribIPointerEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribL1d")) {
            //    glVertexAttribL1d = (delegate* unmanaged<GLuint, GLdouble, void>)GetProcAddress("glVertexAttribL1d");
            //}
            //if (config == null || config.Contains("glVertexAttribL1dEXT")) {
            //    glVertexAttribL1dEXT = (delegate* unmanaged<GLuint, GLdouble, void>)GetProcAddress("glVertexAttribL1dEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribL1dv")) {
            //    glVertexAttribL1dv = (delegate* unmanaged<GLuint, GLdouble[], void>)GetProcAddress("glVertexAttribL1dv");
            //}
            //if (config == null || config.Contains("glVertexAttribL1dvEXT")) {
            //    glVertexAttribL1dvEXT = (delegate* unmanaged<GLuint, GLdouble[], void>)GetProcAddress("glVertexAttribL1dvEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribL1i64NV")) {
            //    glVertexAttribL1i64NV = (delegate* unmanaged<GLuint, GLint64EXT, void>)GetProcAddress("glVertexAttribL1i64NV");
            //}
            //if (config == null || config.Contains("glVertexAttribL1i64vNV")) {
            //    glVertexAttribL1i64vNV = (delegate* unmanaged<GLuint, GLint64EXT[], void>)GetProcAddress("glVertexAttribL1i64vNV");
            //}
            //if (config == null || config.Contains("glVertexAttribL1ui64ARB")) {
            //    glVertexAttribL1ui64ARB = (delegate* unmanaged<GLuint, GLuint64EXT, void>)GetProcAddress("glVertexAttribL1ui64ARB");
            //}
            //if (config == null || config.Contains("glVertexAttribL1ui64NV")) {
            //    glVertexAttribL1ui64NV = (delegate* unmanaged<GLuint, GLuint64EXT, void>)GetProcAddress("glVertexAttribL1ui64NV");
            //}
            //if (config == null || config.Contains("glVertexAttribL1ui64vARB")) {
            //    glVertexAttribL1ui64vARB = (delegate* unmanaged<GLuint, GLuint64EXT[], void>)GetProcAddress("glVertexAttribL1ui64vARB");
            //}
            //if (config == null || config.Contains("glVertexAttribL1ui64vNV")) {
            //    glVertexAttribL1ui64vNV = (delegate* unmanaged<GLuint, GLuint64EXT[], void>)GetProcAddress("glVertexAttribL1ui64vNV");
            //}
            //if (config == null || config.Contains("glVertexAttribL2d")) {
            //    glVertexAttribL2d = (delegate* unmanaged<GLuint, GLdouble, GLdouble, void>)GetProcAddress("glVertexAttribL2d");
            //}
            //if (config == null || config.Contains("glVertexAttribL2dEXT")) {
            //    glVertexAttribL2dEXT = (delegate* unmanaged<GLuint, GLdouble, GLdouble, void>)GetProcAddress("glVertexAttribL2dEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribL2dv")) {
            //    glVertexAttribL2dv = (delegate* unmanaged<GLuint, GLdouble[], void>)GetProcAddress("glVertexAttribL2dv");
            //}
            //if (config == null || config.Contains("glVertexAttribL2dvEXT")) {
            //    glVertexAttribL2dvEXT = (delegate* unmanaged<GLuint, GLdouble[], void>)GetProcAddress("glVertexAttribL2dvEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribL2i64NV")) {
            //    glVertexAttribL2i64NV = (delegate* unmanaged<GLuint, GLint64EXT, GLint64EXT, void>)GetProcAddress("glVertexAttribL2i64NV");
            //}
            //if (config == null || config.Contains("glVertexAttribL2i64vNV")) {
            //    glVertexAttribL2i64vNV = (delegate* unmanaged<GLuint, GLint64EXT[], void>)GetProcAddress("glVertexAttribL2i64vNV");
            //}
            //if (config == null || config.Contains("glVertexAttribL2ui64NV")) {
            //    glVertexAttribL2ui64NV = (delegate* unmanaged<GLuint, GLuint64EXT, GLuint64EXT, void>)GetProcAddress("glVertexAttribL2ui64NV");
            //}
            //if (config == null || config.Contains("glVertexAttribL2ui64vNV")) {
            //    glVertexAttribL2ui64vNV = (delegate* unmanaged<GLuint, GLuint64EXT[], void>)GetProcAddress("glVertexAttribL2ui64vNV");
            //}
            //if (config == null || config.Contains("glVertexAttribL3d")) {
            //    glVertexAttribL3d = (delegate* unmanaged<GLuint, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glVertexAttribL3d");
            //}
            //if (config == null || config.Contains("glVertexAttribL3dEXT")) {
            //    glVertexAttribL3dEXT = (delegate* unmanaged<GLuint, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glVertexAttribL3dEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribL3dv")) {
            //    glVertexAttribL3dv = (delegate* unmanaged<GLuint, GLdouble[], void>)GetProcAddress("glVertexAttribL3dv");
            //}
            //if (config == null || config.Contains("glVertexAttribL3dvEXT")) {
            //    glVertexAttribL3dvEXT = (delegate* unmanaged<GLuint, GLdouble[], void>)GetProcAddress("glVertexAttribL3dvEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribL3i64NV")) {
            //    glVertexAttribL3i64NV = (delegate* unmanaged<GLuint, GLint64EXT, GLint64EXT, GLint64EXT, void>)GetProcAddress("glVertexAttribL3i64NV");
            //}
            //if (config == null || config.Contains("glVertexAttribL3i64vNV")) {
            //    glVertexAttribL3i64vNV = (delegate* unmanaged<GLuint, GLint64EXT[], void>)GetProcAddress("glVertexAttribL3i64vNV");
            //}
            //if (config == null || config.Contains("glVertexAttribL3ui64NV")) {
            //    glVertexAttribL3ui64NV = (delegate* unmanaged<GLuint, GLuint64EXT, GLuint64EXT, GLuint64EXT, void>)GetProcAddress("glVertexAttribL3ui64NV");
            //}
            //if (config == null || config.Contains("glVertexAttribL3ui64vNV")) {
            //    glVertexAttribL3ui64vNV = (delegate* unmanaged<GLuint, GLuint64EXT[], void>)GetProcAddress("glVertexAttribL3ui64vNV");
            //}
            //if (config == null || config.Contains("glVertexAttribL4d")) {
            //    glVertexAttribL4d = (delegate* unmanaged<GLuint, GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glVertexAttribL4d");
            //}
            //if (config == null || config.Contains("glVertexAttribL4dEXT")) {
            //    glVertexAttribL4dEXT = (delegate* unmanaged<GLuint, GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glVertexAttribL4dEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribL4dv")) {
            //    glVertexAttribL4dv = (delegate* unmanaged<GLuint, GLdouble[], void>)GetProcAddress("glVertexAttribL4dv");
            //}
            //if (config == null || config.Contains("glVertexAttribL4dvEXT")) {
            //    glVertexAttribL4dvEXT = (delegate* unmanaged<GLuint, GLdouble[], void>)GetProcAddress("glVertexAttribL4dvEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribL4i64NV")) {
            //    glVertexAttribL4i64NV = (delegate* unmanaged<GLuint, GLint64EXT, GLint64EXT, GLint64EXT, GLint64EXT, void>)GetProcAddress("glVertexAttribL4i64NV");
            //}
            //if (config == null || config.Contains("glVertexAttribL4i64vNV")) {
            //    glVertexAttribL4i64vNV = (delegate* unmanaged<GLuint, GLint64EXT[], void>)GetProcAddress("glVertexAttribL4i64vNV");
            //}
            //if (config == null || config.Contains("glVertexAttribL4ui64NV")) {
            //    glVertexAttribL4ui64NV = (delegate* unmanaged<GLuint, GLuint64EXT, GLuint64EXT, GLuint64EXT, GLuint64EXT, void>)GetProcAddress("glVertexAttribL4ui64NV");
            //}
            //if (config == null || config.Contains("glVertexAttribL4ui64vNV")) {
            //    glVertexAttribL4ui64vNV = (delegate* unmanaged<GLuint, GLuint64EXT[], void>)GetProcAddress("glVertexAttribL4ui64vNV");
            //}
            //if (config == null || config.Contains("glVertexAttribLFormat")) {
            //    glVertexAttribLFormat = (delegate* unmanaged<GLuint, GLint, GLenum, GLuint, void>)GetProcAddress("glVertexAttribLFormat");
            //}
            //if (config == null || config.Contains("glVertexAttribLFormatNV")) {
            //    glVertexAttribLFormatNV = (delegate* unmanaged<GLuint, GLint, GLenum, GLsizei, void>)GetProcAddress("glVertexAttribLFormatNV");
            //}
            //if (config == null || config.Contains("glVertexAttribLPointer")) {
            //    glVertexAttribLPointer = (delegate* unmanaged<GLuint, GLint, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glVertexAttribLPointer");
            //}
            //if (config == null || config.Contains("glVertexAttribLPointerEXT")) {
            //    glVertexAttribLPointerEXT = (delegate* unmanaged<GLuint, GLint, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glVertexAttribLPointerEXT");
            //}
            //if (config == null || config.Contains("glVertexAttribP1ui")) {
            //    glVertexAttribP1ui = (delegate* unmanaged<GLuint, GLenum, GLboolean, GLuint, void>)GetProcAddress("glVertexAttribP1ui");
            //}
            //if (config == null || config.Contains("glVertexAttribP1uiv")) {
            //    glVertexAttribP1uiv = (delegate* unmanaged<GLuint, GLenum, GLboolean, GLuint[], void>)GetProcAddress("glVertexAttribP1uiv");
            //}
            //if (config == null || config.Contains("glVertexAttribP2ui")) {
            //    glVertexAttribP2ui = (delegate* unmanaged<GLuint, GLenum, GLboolean, GLuint, void>)GetProcAddress("glVertexAttribP2ui");
            //}
            //if (config == null || config.Contains("glVertexAttribP2uiv")) {
            //    glVertexAttribP2uiv = (delegate* unmanaged<GLuint, GLenum, GLboolean, GLuint[], void>)GetProcAddress("glVertexAttribP2uiv");
            //}
            //if (config == null || config.Contains("glVertexAttribP3ui")) {
            //    glVertexAttribP3ui = (delegate* unmanaged<GLuint, GLenum, GLboolean, GLuint, void>)GetProcAddress("glVertexAttribP3ui");
            //}
            //if (config == null || config.Contains("glVertexAttribP3uiv")) {
            //    glVertexAttribP3uiv = (delegate* unmanaged<GLuint, GLenum, GLboolean, GLuint[], void>)GetProcAddress("glVertexAttribP3uiv");
            //}
            //if (config == null || config.Contains("glVertexAttribP4ui")) {
            //    glVertexAttribP4ui = (delegate* unmanaged<GLuint, GLenum, GLboolean, GLuint, void>)GetProcAddress("glVertexAttribP4ui");
            //}
            //if (config == null || config.Contains("glVertexAttribP4uiv")) {
            //    glVertexAttribP4uiv = (delegate* unmanaged<GLuint, GLenum, GLboolean, GLuint[], void>)GetProcAddress("glVertexAttribP4uiv");
            //}
            //if (config == null || config.Contains("glVertexAttribParameteriAMD")) {
            //    glVertexAttribParameteriAMD = (delegate* unmanaged<GLuint, GLenum, GLint, void>)GetProcAddress("glVertexAttribParameteriAMD");
            //}
            //if (config == null || config.Contains("glVertexAttribPointer")) {
            //    glVertexAttribPointer = (delegate* unmanaged<GLuint, GLint, GLenum, GLboolean, GLsizei, IntPtr, void>)GetProcAddress("glVertexAttribPointer");
            //}
            //if (config == null || config.Contains("glVertexAttribPointerARB")) {
            //    glVertexAttribPointerARB = (delegate* unmanaged<GLuint, GLint, GLenum, GLboolean, GLsizei, IntPtr, void>)GetProcAddress("glVertexAttribPointerARB");
            //}
            //if (config == null || config.Contains("glVertexAttribPointerNV")) {
            //    glVertexAttribPointerNV = (delegate* unmanaged<GLuint, GLint, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glVertexAttribPointerNV");
            //}
            //if (config == null || config.Contains("glVertexAttribs1dvNV")) {
            //    glVertexAttribs1dvNV = (delegate* unmanaged<GLuint, GLsizei, GLdouble[], void>)GetProcAddress("glVertexAttribs1dvNV");
            //}
            //if (config == null || config.Contains("glVertexAttribs1fvNV")) {
            //    glVertexAttribs1fvNV = (delegate* unmanaged<GLuint, GLsizei, GLfloat[], void>)GetProcAddress("glVertexAttribs1fvNV");
            //}
            //if (config == null || config.Contains("glVertexAttribs1hvNV")) {
            //    glVertexAttribs1hvNV = (delegate* unmanaged<GLuint, GLsizei, GLhalfNV[], void>)GetProcAddress("glVertexAttribs1hvNV");
            //}
            //if (config == null || config.Contains("glVertexAttribs1svNV")) {
            //    glVertexAttribs1svNV = (delegate* unmanaged<GLuint, GLsizei, GLshort[], void>)GetProcAddress("glVertexAttribs1svNV");
            //}
            //if (config == null || config.Contains("glVertexAttribs2dvNV")) {
            //    glVertexAttribs2dvNV = (delegate* unmanaged<GLuint, GLsizei, GLdouble[], void>)GetProcAddress("glVertexAttribs2dvNV");
            //}
            //if (config == null || config.Contains("glVertexAttribs2fvNV")) {
            //    glVertexAttribs2fvNV = (delegate* unmanaged<GLuint, GLsizei, GLfloat[], void>)GetProcAddress("glVertexAttribs2fvNV");
            //}
            //if (config == null || config.Contains("glVertexAttribs2hvNV")) {
            //    glVertexAttribs2hvNV = (delegate* unmanaged<GLuint, GLsizei, GLhalfNV[], void>)GetProcAddress("glVertexAttribs2hvNV");
            //}
            //if (config == null || config.Contains("glVertexAttribs2svNV")) {
            //    glVertexAttribs2svNV = (delegate* unmanaged<GLuint, GLsizei, GLshort[], void>)GetProcAddress("glVertexAttribs2svNV");
            //}
            //if (config == null || config.Contains("glVertexAttribs3dvNV")) {
            //    glVertexAttribs3dvNV = (delegate* unmanaged<GLuint, GLsizei, GLdouble[], void>)GetProcAddress("glVertexAttribs3dvNV");
            //}
            //if (config == null || config.Contains("glVertexAttribs3fvNV")) {
            //    glVertexAttribs3fvNV = (delegate* unmanaged<GLuint, GLsizei, GLfloat[], void>)GetProcAddress("glVertexAttribs3fvNV");
            //}
            //if (config == null || config.Contains("glVertexAttribs3hvNV")) {
            //    glVertexAttribs3hvNV = (delegate* unmanaged<GLuint, GLsizei, GLhalfNV[], void>)GetProcAddress("glVertexAttribs3hvNV");
            //}
            //if (config == null || config.Contains("glVertexAttribs3svNV")) {
            //    glVertexAttribs3svNV = (delegate* unmanaged<GLuint, GLsizei, GLshort[], void>)GetProcAddress("glVertexAttribs3svNV");
            //}
            //if (config == null || config.Contains("glVertexAttribs4dvNV")) {
            //    glVertexAttribs4dvNV = (delegate* unmanaged<GLuint, GLsizei, GLdouble[], void>)GetProcAddress("glVertexAttribs4dvNV");
            //}
            //if (config == null || config.Contains("glVertexAttribs4fvNV")) {
            //    glVertexAttribs4fvNV = (delegate* unmanaged<GLuint, GLsizei, GLfloat[], void>)GetProcAddress("glVertexAttribs4fvNV");
            //}
            //if (config == null || config.Contains("glVertexAttribs4hvNV")) {
            //    glVertexAttribs4hvNV = (delegate* unmanaged<GLuint, GLsizei, GLhalfNV[], void>)GetProcAddress("glVertexAttribs4hvNV");
            //}
            //if (config == null || config.Contains("glVertexAttribs4svNV")) {
            //    glVertexAttribs4svNV = (delegate* unmanaged<GLuint, GLsizei, GLshort[], void>)GetProcAddress("glVertexAttribs4svNV");
            //}
            //if (config == null || config.Contains("glVertexAttribs4ubvNV")) {
            //    glVertexAttribs4ubvNV = (delegate* unmanaged<GLuint, GLsizei, GLubyte[], void>)GetProcAddress("glVertexAttribs4ubvNV");
            //}
            //if (config == null || config.Contains("glVertexBindingDivisor")) {
            //    glVertexBindingDivisor = (delegate* unmanaged<GLuint, GLuint, void>)GetProcAddress("glVertexBindingDivisor");
            //}
            //if (config == null || config.Contains("glVertexBlendARB")) {
            //    glVertexBlendARB = (delegate* unmanaged<GLint, void>)GetProcAddress("glVertexBlendARB");
            //}
            //if (config == null || config.Contains("glVertexBlendEnvfATI")) {
            //    glVertexBlendEnvfATI = (delegate* unmanaged<GLenum, GLfloat, void>)GetProcAddress("glVertexBlendEnvfATI");
            //}
            //if (config == null || config.Contains("glVertexBlendEnviATI")) {
            //    glVertexBlendEnviATI = (delegate* unmanaged<GLenum, GLint, void>)GetProcAddress("glVertexBlendEnviATI");
            //}
            //if (config == null || config.Contains("glVertexFormatNV")) {
            //    glVertexFormatNV = (delegate* unmanaged<GLint, GLenum, GLsizei, void>)GetProcAddress("glVertexFormatNV");
            //}
            //if (config == null || config.Contains("glVertexP2ui")) {
            //    glVertexP2ui = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glVertexP2ui");
            //}
            //if (config == null || config.Contains("glVertexP2uiv")) {
            //    glVertexP2uiv = (delegate* unmanaged<GLenum, GLuint[], void>)GetProcAddress("glVertexP2uiv");
            //}
            //if (config == null || config.Contains("glVertexP3ui")) {
            //    glVertexP3ui = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glVertexP3ui");
            //}
            //if (config == null || config.Contains("glVertexP3uiv")) {
            //    glVertexP3uiv = (delegate* unmanaged<GLenum, GLuint[], void>)GetProcAddress("glVertexP3uiv");
            //}
            //if (config == null || config.Contains("glVertexP4ui")) {
            //    glVertexP4ui = (delegate* unmanaged<GLenum, GLuint, void>)GetProcAddress("glVertexP4ui");
            //}
            //if (config == null || config.Contains("glVertexP4uiv")) {
            //    glVertexP4uiv = (delegate* unmanaged<GLenum, GLuint[], void>)GetProcAddress("glVertexP4uiv");
            //}
            //if (config == null || config.Contains("glVertexPointer")) {
            //    glVertexPointer = (delegate* unmanaged<GLint, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glVertexPointer");
            //}
            //if (config == null || config.Contains("glVertexPointerEXT")) {
            //    glVertexPointerEXT = (delegate* unmanaged<GLint, GLenum, GLsizei, GLsizei, IntPtr, void>)GetProcAddress("glVertexPointerEXT");
            //}
            //if (config == null || config.Contains("glVertexPointerListIBM")) {
            //    glVertexPointerListIBM = (delegate* unmanaged<GLint, GLenum, GLint, IntPtr, GLint, void>)GetProcAddress("glVertexPointerListIBM");
            //}
            //if (config == null || config.Contains("glVertexPointervINTEL")) {
            //    glVertexPointervINTEL = (delegate* unmanaged<GLint, GLenum, IntPtr, void>)GetProcAddress("glVertexPointervINTEL");
            //}
            //if (config == null || config.Contains("glVertexStream1dATI")) {
            //    glVertexStream1dATI = (delegate* unmanaged<GLenum, GLdouble, void>)GetProcAddress("glVertexStream1dATI");
            //}
            //if (config == null || config.Contains("glVertexStream1dvATI")) {
            //    glVertexStream1dvATI = (delegate* unmanaged<GLenum, GLdouble[], void>)GetProcAddress("glVertexStream1dvATI");
            //}
            //if (config == null || config.Contains("glVertexStream1fATI")) {
            //    glVertexStream1fATI = (delegate* unmanaged<GLenum, GLfloat, void>)GetProcAddress("glVertexStream1fATI");
            //}
            //if (config == null || config.Contains("glVertexStream1fvATI")) {
            //    glVertexStream1fvATI = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glVertexStream1fvATI");
            //}
            //if (config == null || config.Contains("glVertexStream1iATI")) {
            //    glVertexStream1iATI = (delegate* unmanaged<GLenum, GLint, void>)GetProcAddress("glVertexStream1iATI");
            //}
            //if (config == null || config.Contains("glVertexStream1ivATI")) {
            //    glVertexStream1ivATI = (delegate* unmanaged<GLenum, GLint[], void>)GetProcAddress("glVertexStream1ivATI");
            //}
            //if (config == null || config.Contains("glVertexStream1sATI")) {
            //    glVertexStream1sATI = (delegate* unmanaged<GLenum, GLshort, void>)GetProcAddress("glVertexStream1sATI");
            //}
            //if (config == null || config.Contains("glVertexStream1svATI")) {
            //    glVertexStream1svATI = (delegate* unmanaged<GLenum, GLshort[], void>)GetProcAddress("glVertexStream1svATI");
            //}
            //if (config == null || config.Contains("glVertexStream2dATI")) {
            //    glVertexStream2dATI = (delegate* unmanaged<GLenum, GLdouble, GLdouble, void>)GetProcAddress("glVertexStream2dATI");
            //}
            //if (config == null || config.Contains("glVertexStream2dvATI")) {
            //    glVertexStream2dvATI = (delegate* unmanaged<GLenum, GLdouble[], void>)GetProcAddress("glVertexStream2dvATI");
            //}
            //if (config == null || config.Contains("glVertexStream2fATI")) {
            //    glVertexStream2fATI = (delegate* unmanaged<GLenum, GLfloat, GLfloat, void>)GetProcAddress("glVertexStream2fATI");
            //}
            //if (config == null || config.Contains("glVertexStream2fvATI")) {
            //    glVertexStream2fvATI = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glVertexStream2fvATI");
            //}
            //if (config == null || config.Contains("glVertexStream2iATI")) {
            //    glVertexStream2iATI = (delegate* unmanaged<GLenum, GLint, GLint, void>)GetProcAddress("glVertexStream2iATI");
            //}
            //if (config == null || config.Contains("glVertexStream2ivATI")) {
            //    glVertexStream2ivATI = (delegate* unmanaged<GLenum, GLint[], void>)GetProcAddress("glVertexStream2ivATI");
            //}
            //if (config == null || config.Contains("glVertexStream2sATI")) {
            //    glVertexStream2sATI = (delegate* unmanaged<GLenum, GLshort, GLshort, void>)GetProcAddress("glVertexStream2sATI");
            //}
            //if (config == null || config.Contains("glVertexStream2svATI")) {
            //    glVertexStream2svATI = (delegate* unmanaged<GLenum, GLshort[], void>)GetProcAddress("glVertexStream2svATI");
            //}
            //if (config == null || config.Contains("glVertexStream3dATI")) {
            //    glVertexStream3dATI = (delegate* unmanaged<GLenum, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glVertexStream3dATI");
            //}
            //if (config == null || config.Contains("glVertexStream3dvATI")) {
            //    glVertexStream3dvATI = (delegate* unmanaged<GLenum, GLdouble[], void>)GetProcAddress("glVertexStream3dvATI");
            //}
            //if (config == null || config.Contains("glVertexStream3fATI")) {
            //    glVertexStream3fATI = (delegate* unmanaged<GLenum, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glVertexStream3fATI");
            //}
            //if (config == null || config.Contains("glVertexStream3fvATI")) {
            //    glVertexStream3fvATI = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glVertexStream3fvATI");
            //}
            //if (config == null || config.Contains("glVertexStream3iATI")) {
            //    glVertexStream3iATI = (delegate* unmanaged<GLenum, GLint, GLint, GLint, void>)GetProcAddress("glVertexStream3iATI");
            //}
            //if (config == null || config.Contains("glVertexStream3ivATI")) {
            //    glVertexStream3ivATI = (delegate* unmanaged<GLenum, GLint[], void>)GetProcAddress("glVertexStream3ivATI");
            //}
            //if (config == null || config.Contains("glVertexStream3sATI")) {
            //    glVertexStream3sATI = (delegate* unmanaged<GLenum, GLshort, GLshort, GLshort, void>)GetProcAddress("glVertexStream3sATI");
            //}
            //if (config == null || config.Contains("glVertexStream3svATI")) {
            //    glVertexStream3svATI = (delegate* unmanaged<GLenum, GLshort[], void>)GetProcAddress("glVertexStream3svATI");
            //}
            //if (config == null || config.Contains("glVertexStream4dATI")) {
            //    glVertexStream4dATI = (delegate* unmanaged<GLenum, GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glVertexStream4dATI");
            //}
            //if (config == null || config.Contains("glVertexStream4dvATI")) {
            //    glVertexStream4dvATI = (delegate* unmanaged<GLenum, GLdouble[], void>)GetProcAddress("glVertexStream4dvATI");
            //}
            //if (config == null || config.Contains("glVertexStream4fATI")) {
            //    glVertexStream4fATI = (delegate* unmanaged<GLenum, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glVertexStream4fATI");
            //}
            //if (config == null || config.Contains("glVertexStream4fvATI")) {
            //    glVertexStream4fvATI = (delegate* unmanaged<GLenum, GLfloat[], void>)GetProcAddress("glVertexStream4fvATI");
            //}
            //if (config == null || config.Contains("glVertexStream4iATI")) {
            //    glVertexStream4iATI = (delegate* unmanaged<GLenum, GLint, GLint, GLint, GLint, void>)GetProcAddress("glVertexStream4iATI");
            //}
            //if (config == null || config.Contains("glVertexStream4ivATI")) {
            //    glVertexStream4ivATI = (delegate* unmanaged<GLenum, GLint[], void>)GetProcAddress("glVertexStream4ivATI");
            //}
            //if (config == null || config.Contains("glVertexStream4sATI")) {
            //    glVertexStream4sATI = (delegate* unmanaged<GLenum, GLshort, GLshort, GLshort, GLshort, void>)GetProcAddress("glVertexStream4sATI");
            //}
            //if (config == null || config.Contains("glVertexStream4svATI")) {
            //    glVertexStream4svATI = (delegate* unmanaged<GLenum, GLshort[], void>)GetProcAddress("glVertexStream4svATI");
            //}
            //if (config == null || config.Contains("glVertexWeightPointerEXT")) {
            //    glVertexWeightPointerEXT = (delegate* unmanaged<GLint, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glVertexWeightPointerEXT");
            //}
            //if (config == null || config.Contains("glVertexWeightfEXT")) {
            //    glVertexWeightfEXT = (delegate* unmanaged<GLfloat, void>)GetProcAddress("glVertexWeightfEXT");
            //}
            //if (config == null || config.Contains("glVertexWeightfvEXT")) {
            //    glVertexWeightfvEXT = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glVertexWeightfvEXT");
            //}
            //if (config == null || config.Contains("glVertexWeighthNV")) {
            //    glVertexWeighthNV = (delegate* unmanaged<GLhalfNV, void>)GetProcAddress("glVertexWeighthNV");
            //}
            //if (config == null || config.Contains("glVertexWeighthvNV")) {
            //    glVertexWeighthvNV = (delegate* unmanaged<GLhalfNV[], void>)GetProcAddress("glVertexWeighthvNV");
            //}
            //if (config == null || config.Contains("glVideoCaptureNV")) {
            //    glVideoCaptureNV = (delegate* unmanaged<GLuint, GLuint[], GLuint64EXT[], GLenum>)GetProcAddress("glVideoCaptureNV");
            //}
            //if (config == null || config.Contains("glVideoCaptureStreamParameterdvNV")) {
            //    glVideoCaptureStreamParameterdvNV = (delegate* unmanaged<GLuint, GLuint, GLenum, GLdouble[], void>)GetProcAddress("glVideoCaptureStreamParameterdvNV");
            //}
            //if (config == null || config.Contains("glVideoCaptureStreamParameterfvNV")) {
            //    glVideoCaptureStreamParameterfvNV = (delegate* unmanaged<GLuint, GLuint, GLenum, GLfloat[], void>)GetProcAddress("glVideoCaptureStreamParameterfvNV");
            //}
            //if (config == null || config.Contains("glVideoCaptureStreamParameterivNV")) {
            //    glVideoCaptureStreamParameterivNV = (delegate* unmanaged<GLuint, GLuint, GLenum, GLint[], void>)GetProcAddress("glVideoCaptureStreamParameterivNV");
            //}
            //if (config == null || config.Contains("glViewport")) {
            //    glViewport = (delegate* unmanaged<GLint, GLint, GLsizei, GLsizei, void>)GetProcAddress("glViewport");
            //}
            //if (config == null || config.Contains("glViewportArrayv")) {
            //    glViewportArrayv = (delegate* unmanaged<GLuint, GLsizei, GLfloat[], void>)GetProcAddress("glViewportArrayv");
            //}
            //if (config == null || config.Contains("glViewportArrayvNV")) {
            //    glViewportArrayvNV = (delegate* unmanaged<GLuint, GLsizei, GLfloat[], void>)GetProcAddress("glViewportArrayvNV");
            //}
            //if (config == null || config.Contains("glViewportArrayvOES")) {
            //    glViewportArrayvOES = (delegate* unmanaged<GLuint, GLsizei, GLfloat[], void>)GetProcAddress("glViewportArrayvOES");
            //}
            //if (config == null || config.Contains("glViewportIndexedf")) {
            //    glViewportIndexedf = (delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glViewportIndexedf");
            //}
            //if (config == null || config.Contains("glViewportIndexedfOES")) {
            //    glViewportIndexedfOES = (delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glViewportIndexedfOES");
            //}
            //if (config == null || config.Contains("glViewportIndexedfNV")) {
            //    glViewportIndexedfNV = (delegate* unmanaged<GLuint, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glViewportIndexedfNV");
            //}
            //if (config == null || config.Contains("glViewportIndexedfv")) {
            //    glViewportIndexedfv = (delegate* unmanaged<GLuint, GLfloat[], void>)GetProcAddress("glViewportIndexedfv");
            //}
            //if (config == null || config.Contains("glViewportIndexedfvOES")) {
            //    glViewportIndexedfvOES = (delegate* unmanaged<GLuint, GLfloat[], void>)GetProcAddress("glViewportIndexedfvOES");
            //}
            //if (config == null || config.Contains("glViewportIndexedfvNV")) {
            //    glViewportIndexedfvNV = (delegate* unmanaged<GLuint, GLfloat[], void>)GetProcAddress("glViewportIndexedfvNV");
            //}
            //if (config == null || config.Contains("glViewportPositionWScaleNV")) {
            //    glViewportPositionWScaleNV = (delegate* unmanaged<GLuint, GLfloat, GLfloat, void>)GetProcAddress("glViewportPositionWScaleNV");
            //}
            //if (config == null || config.Contains("glViewportSwizzleNV")) {
            //    glViewportSwizzleNV = (delegate* unmanaged<GLuint, GLenum, GLenum, GLenum, GLenum, void>)GetProcAddress("glViewportSwizzleNV");
            //}
            //if (config == null || config.Contains("glWaitSemaphoreEXT")) {
            //    glWaitSemaphoreEXT = (delegate* unmanaged<GLuint, GLuint, GLuint[], GLuint, GLuint[], GLenum[], void>)GetProcAddress("glWaitSemaphoreEXT");
            //}
            //if (config == null || config.Contains("glWaitSemaphoreui64NVX")) {
            //    glWaitSemaphoreui64NVX = (delegate* unmanaged<GLuint, GLsizei, GLuint[], GLuint64[], void>)GetProcAddress("glWaitSemaphoreui64NVX");
            //}
            //if (config == null || config.Contains("glWaitSync")) {
            //    glWaitSync = (delegate* unmanaged<GLsync, GLbitfield, GLuint64, void>)GetProcAddress("glWaitSync");
            //}
            //if (config == null || config.Contains("glWaitSyncAPPLE")) {
            //    glWaitSyncAPPLE = (delegate* unmanaged<GLsync, GLbitfield, GLuint64, void>)GetProcAddress("glWaitSyncAPPLE");
            //}
            //if (config == null || config.Contains("glWeightPathsNV")) {
            //    glWeightPathsNV = (delegate* unmanaged<GLuint, GLsizei, GLuint[], GLfloat[], void>)GetProcAddress("glWeightPathsNV");
            //}
            //if (config == null || config.Contains("glWeightPointerARB")) {
            //    glWeightPointerARB = (delegate* unmanaged<GLint, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glWeightPointerARB");
            //}
            //if (config == null || config.Contains("glWeightPointerOES")) {
            //    glWeightPointerOES = (delegate* unmanaged<GLint, GLenum, GLsizei, IntPtr, void>)GetProcAddress("glWeightPointerOES");
            //}
            //if (config == null || config.Contains("glWeightbvARB")) {
            //    glWeightbvARB = (delegate* unmanaged<GLint, GLbyte[], void>)GetProcAddress("glWeightbvARB");
            //}
            //if (config == null || config.Contains("glWeightdvARB")) {
            //    glWeightdvARB = (delegate* unmanaged<GLint, GLdouble[], void>)GetProcAddress("glWeightdvARB");
            //}
            //if (config == null || config.Contains("glWeightfvARB")) {
            //    glWeightfvARB = (delegate* unmanaged<GLint, GLfloat[], void>)GetProcAddress("glWeightfvARB");
            //}
            //if (config == null || config.Contains("glWeightivARB")) {
            //    glWeightivARB = (delegate* unmanaged<GLint, GLint[], void>)GetProcAddress("glWeightivARB");
            //}
            //if (config == null || config.Contains("glWeightsvARB")) {
            //    glWeightsvARB = (delegate* unmanaged<GLint, GLshort[], void>)GetProcAddress("glWeightsvARB");
            //}
            //if (config == null || config.Contains("glWeightubvARB")) {
            //    glWeightubvARB = (delegate* unmanaged<GLint, GLubyte[], void>)GetProcAddress("glWeightubvARB");
            //}
            //if (config == null || config.Contains("glWeightuivARB")) {
            //    glWeightuivARB = (delegate* unmanaged<GLint, GLuint[], void>)GetProcAddress("glWeightuivARB");
            //}
            //if (config == null || config.Contains("glWeightusvARB")) {
            //    glWeightusvARB = (delegate* unmanaged<GLint, GLushort[], void>)GetProcAddress("glWeightusvARB");
            //}
            //if (config == null || config.Contains("glWindowPos2d")) {
            //    glWindowPos2d = (delegate* unmanaged<GLdouble, GLdouble, void>)GetProcAddress("glWindowPos2d");
            //}
            //if (config == null || config.Contains("glWindowPos2dARB")) {
            //    glWindowPos2dARB = (delegate* unmanaged<GLdouble, GLdouble, void>)GetProcAddress("glWindowPos2dARB");
            //}
            //if (config == null || config.Contains("glWindowPos2dMESA")) {
            //    glWindowPos2dMESA = (delegate* unmanaged<GLdouble, GLdouble, void>)GetProcAddress("glWindowPos2dMESA");
            //}
            //if (config == null || config.Contains("glWindowPos2dv")) {
            //    glWindowPos2dv = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glWindowPos2dv");
            //}
            //if (config == null || config.Contains("glWindowPos2dvARB")) {
            //    glWindowPos2dvARB = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glWindowPos2dvARB");
            //}
            //if (config == null || config.Contains("glWindowPos2dvMESA")) {
            //    glWindowPos2dvMESA = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glWindowPos2dvMESA");
            //}
            //if (config == null || config.Contains("glWindowPos2f")) {
            //    glWindowPos2f = (delegate* unmanaged<GLfloat, GLfloat, void>)GetProcAddress("glWindowPos2f");
            //}
            //if (config == null || config.Contains("glWindowPos2fARB")) {
            //    glWindowPos2fARB = (delegate* unmanaged<GLfloat, GLfloat, void>)GetProcAddress("glWindowPos2fARB");
            //}
            //if (config == null || config.Contains("glWindowPos2fMESA")) {
            //    glWindowPos2fMESA = (delegate* unmanaged<GLfloat, GLfloat, void>)GetProcAddress("glWindowPos2fMESA");
            //}
            //if (config == null || config.Contains("glWindowPos2fv")) {
            //    glWindowPos2fv = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glWindowPos2fv");
            //}
            //if (config == null || config.Contains("glWindowPos2fvARB")) {
            //    glWindowPos2fvARB = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glWindowPos2fvARB");
            //}
            //if (config == null || config.Contains("glWindowPos2fvMESA")) {
            //    glWindowPos2fvMESA = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glWindowPos2fvMESA");
            //}
            //if (config == null || config.Contains("glWindowPos2i")) {
            //    glWindowPos2i = (delegate* unmanaged<GLint, GLint, void>)GetProcAddress("glWindowPos2i");
            //}
            //if (config == null || config.Contains("glWindowPos2iARB")) {
            //    glWindowPos2iARB = (delegate* unmanaged<GLint, GLint, void>)GetProcAddress("glWindowPos2iARB");
            //}
            //if (config == null || config.Contains("glWindowPos2iMESA")) {
            //    glWindowPos2iMESA = (delegate* unmanaged<GLint, GLint, void>)GetProcAddress("glWindowPos2iMESA");
            //}
            //if (config == null || config.Contains("glWindowPos2iv")) {
            //    glWindowPos2iv = (delegate* unmanaged<GLint[], void>)GetProcAddress("glWindowPos2iv");
            //}
            //if (config == null || config.Contains("glWindowPos2ivARB")) {
            //    glWindowPos2ivARB = (delegate* unmanaged<GLint[], void>)GetProcAddress("glWindowPos2ivARB");
            //}
            //if (config == null || config.Contains("glWindowPos2ivMESA")) {
            //    glWindowPos2ivMESA = (delegate* unmanaged<GLint[], void>)GetProcAddress("glWindowPos2ivMESA");
            //}
            //if (config == null || config.Contains("glWindowPos2s")) {
            //    glWindowPos2s = (delegate* unmanaged<GLshort, GLshort, void>)GetProcAddress("glWindowPos2s");
            //}
            //if (config == null || config.Contains("glWindowPos2sARB")) {
            //    glWindowPos2sARB = (delegate* unmanaged<GLshort, GLshort, void>)GetProcAddress("glWindowPos2sARB");
            //}
            //if (config == null || config.Contains("glWindowPos2sMESA")) {
            //    glWindowPos2sMESA = (delegate* unmanaged<GLshort, GLshort, void>)GetProcAddress("glWindowPos2sMESA");
            //}
            //if (config == null || config.Contains("glWindowPos2sv")) {
            //    glWindowPos2sv = (delegate* unmanaged<GLshort[], void>)GetProcAddress("glWindowPos2sv");
            //}
            //if (config == null || config.Contains("glWindowPos2svARB")) {
            //    glWindowPos2svARB = (delegate* unmanaged<GLshort[], void>)GetProcAddress("glWindowPos2svARB");
            //}
            //if (config == null || config.Contains("glWindowPos2svMESA")) {
            //    glWindowPos2svMESA = (delegate* unmanaged<GLshort[], void>)GetProcAddress("glWindowPos2svMESA");
            //}
            //if (config == null || config.Contains("glWindowPos3d")) {
            //    glWindowPos3d = (delegate* unmanaged<GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glWindowPos3d");
            //}
            //if (config == null || config.Contains("glWindowPos3dARB")) {
            //    glWindowPos3dARB = (delegate* unmanaged<GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glWindowPos3dARB");
            //}
            //if (config == null || config.Contains("glWindowPos3dMESA")) {
            //    glWindowPos3dMESA = (delegate* unmanaged<GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glWindowPos3dMESA");
            //}
            //if (config == null || config.Contains("glWindowPos3dv")) {
            //    glWindowPos3dv = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glWindowPos3dv");
            //}
            //if (config == null || config.Contains("glWindowPos3dvARB")) {
            //    glWindowPos3dvARB = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glWindowPos3dvARB");
            //}
            //if (config == null || config.Contains("glWindowPos3dvMESA")) {
            //    glWindowPos3dvMESA = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glWindowPos3dvMESA");
            //}
            //if (config == null || config.Contains("glWindowPos3f")) {
            //    glWindowPos3f = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glWindowPos3f");
            //}
            //if (config == null || config.Contains("glWindowPos3fARB")) {
            //    glWindowPos3fARB = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glWindowPos3fARB");
            //}
            //if (config == null || config.Contains("glWindowPos3fMESA")) {
            //    glWindowPos3fMESA = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glWindowPos3fMESA");
            //}
            //if (config == null || config.Contains("glWindowPos3fv")) {
            //    glWindowPos3fv = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glWindowPos3fv");
            //}
            //if (config == null || config.Contains("glWindowPos3fvARB")) {
            //    glWindowPos3fvARB = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glWindowPos3fvARB");
            //}
            //if (config == null || config.Contains("glWindowPos3fvMESA")) {
            //    glWindowPos3fvMESA = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glWindowPos3fvMESA");
            //}
            //if (config == null || config.Contains("glWindowPos3i")) {
            //    glWindowPos3i = (delegate* unmanaged<GLint, GLint, GLint, void>)GetProcAddress("glWindowPos3i");
            //}
            //if (config == null || config.Contains("glWindowPos3iARB")) {
            //    glWindowPos3iARB = (delegate* unmanaged<GLint, GLint, GLint, void>)GetProcAddress("glWindowPos3iARB");
            //}
            //if (config == null || config.Contains("glWindowPos3iMESA")) {
            //    glWindowPos3iMESA = (delegate* unmanaged<GLint, GLint, GLint, void>)GetProcAddress("glWindowPos3iMESA");
            //}
            //if (config == null || config.Contains("glWindowPos3iv")) {
            //    glWindowPos3iv = (delegate* unmanaged<GLint[], void>)GetProcAddress("glWindowPos3iv");
            //}
            //if (config == null || config.Contains("glWindowPos3ivARB")) {
            //    glWindowPos3ivARB = (delegate* unmanaged<GLint[], void>)GetProcAddress("glWindowPos3ivARB");
            //}
            //if (config == null || config.Contains("glWindowPos3ivMESA")) {
            //    glWindowPos3ivMESA = (delegate* unmanaged<GLint[], void>)GetProcAddress("glWindowPos3ivMESA");
            //}
            //if (config == null || config.Contains("glWindowPos3s")) {
            //    glWindowPos3s = (delegate* unmanaged<GLshort, GLshort, GLshort, void>)GetProcAddress("glWindowPos3s");
            //}
            //if (config == null || config.Contains("glWindowPos3sARB")) {
            //    glWindowPos3sARB = (delegate* unmanaged<GLshort, GLshort, GLshort, void>)GetProcAddress("glWindowPos3sARB");
            //}
            //if (config == null || config.Contains("glWindowPos3sMESA")) {
            //    glWindowPos3sMESA = (delegate* unmanaged<GLshort, GLshort, GLshort, void>)GetProcAddress("glWindowPos3sMESA");
            //}
            //if (config == null || config.Contains("glWindowPos3sv")) {
            //    glWindowPos3sv = (delegate* unmanaged<GLshort[], void>)GetProcAddress("glWindowPos3sv");
            //}
            //if (config == null || config.Contains("glWindowPos3svARB")) {
            //    glWindowPos3svARB = (delegate* unmanaged<GLshort[], void>)GetProcAddress("glWindowPos3svARB");
            //}
            //if (config == null || config.Contains("glWindowPos3svMESA")) {
            //    glWindowPos3svMESA = (delegate* unmanaged<GLshort[], void>)GetProcAddress("glWindowPos3svMESA");
            //}
            //if (config == null || config.Contains("glWindowPos4dMESA")) {
            //    glWindowPos4dMESA = (delegate* unmanaged<GLdouble, GLdouble, GLdouble, GLdouble, void>)GetProcAddress("glWindowPos4dMESA");
            //}
            //if (config == null || config.Contains("glWindowPos4dvMESA")) {
            //    glWindowPos4dvMESA = (delegate* unmanaged<GLdouble[], void>)GetProcAddress("glWindowPos4dvMESA");
            //}
            //if (config == null || config.Contains("glWindowPos4fMESA")) {
            //    glWindowPos4fMESA = (delegate* unmanaged<GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glWindowPos4fMESA");
            //}
            //if (config == null || config.Contains("glWindowPos4fvMESA")) {
            //    glWindowPos4fvMESA = (delegate* unmanaged<GLfloat[], void>)GetProcAddress("glWindowPos4fvMESA");
            //}
            //if (config == null || config.Contains("glWindowPos4iMESA")) {
            //    glWindowPos4iMESA = (delegate* unmanaged<GLint, GLint, GLint, GLint, void>)GetProcAddress("glWindowPos4iMESA");
            //}
            //if (config == null || config.Contains("glWindowPos4ivMESA")) {
            //    glWindowPos4ivMESA = (delegate* unmanaged<GLint[], void>)GetProcAddress("glWindowPos4ivMESA");
            //}
            //if (config == null || config.Contains("glWindowPos4sMESA")) {
            //    glWindowPos4sMESA = (delegate* unmanaged<GLshort, GLshort, GLshort, GLshort, void>)GetProcAddress("glWindowPos4sMESA");
            //}
            //if (config == null || config.Contains("glWindowPos4svMESA")) {
            //    glWindowPos4svMESA = (delegate* unmanaged<GLshort[], void>)GetProcAddress("glWindowPos4svMESA");
            //}
            //if (config == null || config.Contains("glWindowRectanglesEXT")) {
            //    glWindowRectanglesEXT = (delegate* unmanaged<GLenum, GLsizei, GLint[], void>)GetProcAddress("glWindowRectanglesEXT");
            //}
            //if (config == null || config.Contains("glWriteMaskEXT")) {
            //    glWriteMaskEXT = (delegate* unmanaged<GLuint, GLuint, GLenum, GLenum, GLenum, GLenum, void>)GetProcAddress("glWriteMaskEXT");
            //}
            //if (config == null || config.Contains("glDrawVkImageNV")) {
            //    glDrawVkImageNV = (delegate* unmanaged<GLuint64, GLuint, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, GLfloat, void>)GetProcAddress("glDrawVkImageNV");
            //}
            //if (config == null || config.Contains("glGetVkProcAddrNV")) {
            //    glGetVkProcAddrNV = (delegate* unmanaged<string, delegate*<void>/*GLVULKANPROCNV*/>)GetProcAddress("glGetVkProcAddrNV");
            //}
            //if (config == null || config.Contains("glWaitVkSemaphoreNV")) {
            //    glWaitVkSemaphoreNV = (delegate* unmanaged<GLuint64, void>)GetProcAddress("glWaitVkSemaphoreNV");
            //}
            //if (config == null || config.Contains("glSignalVkSemaphoreNV")) {
            //    glSignalVkSemaphoreNV = (delegate* unmanaged<GLuint64, void>)GetProcAddress("glSignalVkSemaphoreNV");
            //}
            //if (config == null || config.Contains("glSignalVkFenceNV")) {
            //    glSignalVkFenceNV = (delegate* unmanaged<GLuint64, void>)GetProcAddress("glSignalVkFenceNV");
            //}
            //if (config == null || config.Contains("glFramebufferParameteriMESA")) {
            //    glFramebufferParameteriMESA = (delegate* unmanaged<GLenum, GLenum, GLint, void>)GetProcAddress("glFramebufferParameteriMESA");
            //}
            //if (config == null || config.Contains("glGetFramebufferParameterivMESA")) {
            //    glGetFramebufferParameterivMESA = (delegate* unmanaged<GLenum, GLenum, GLint[], void>)GetProcAddress("glGetFramebufferParameterivMESA");
            //}



            #endregion openGL functions
        }
    }
}
