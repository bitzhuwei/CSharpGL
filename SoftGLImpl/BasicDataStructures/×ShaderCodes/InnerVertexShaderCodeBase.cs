using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {

    public abstract unsafe class InnerVertexShaderCodeBase : InnerShaderCodeBase {
        //[In]
        public int gl_VertexID;

        public vec4* gl_PositionData;
        [OutAttribute]
        public vec4 gl_Position {
            get { return gl_PositionData[gl_VertexID]; }
            set { gl_PositionData[gl_VertexID] = value; }
        }

    }

    unsafe class InnerDemoVert : InnerVertexShaderCodeBase, IMain {
        public vec3* inPositionData;
        [InAttribute]
        vec3 inPosition { get { return inPositionData[gl_VertexID]; } }
        /*
         get_inPosition() cil managed
{
  // 代码大小       27 (0x1b)
  .maxstack  8
  IL_0000:  ldarg.0
  IL_0001:  ldfld      valuetype [SoftGL.ShadingLanguage]SoftGL.vec3* SoftGL.InnerDemoVert::inPositionData
  IL_0006:  ldarg.0
  IL_0007:  ldfld      int32 SoftGL.InnerVertexShaderCodeBase::gl_VertexID
  IL_000c:  conv.i
  IL_000d:  sizeof     [SoftGL.ShadingLanguage]SoftGL.vec3
  IL_0013:  mul
  IL_0014:  add
  IL_0015:  ldobj      [SoftGL.ShadingLanguage]SoftGL.vec3
  IL_001a:  ret
} // end of method InnerDemoVert::get_inPosition
         */
        public vec3* inColorData;
        [InAttribute]
        vec3 inColor { get { return inColorData[gl_VertexID]; } }
        /*
          get_inColor() cil managed
{
  // 代码大小       27 (0x1b)
  .maxstack  8
  IL_0000:  ldarg.0
  IL_0001:  ldfld      valuetype [SoftGL.ShadingLanguage]SoftGL.vec3* SoftGL.InnerDemoVert::inColorData
  IL_0006:  ldarg.0
  IL_0007:  ldfld      int32 SoftGL.InnerVertexShaderCodeBase::gl_VertexID
  IL_000c:  conv.i
  IL_000d:  sizeof     [SoftGL.ShadingLanguage]SoftGL.vec3
  IL_0013:  mul
  IL_0014:  add
  IL_0015:  ldobj      [SoftGL.ShadingLanguage]SoftGL.vec3
  IL_001a:  ret
} // end of method InnerDemoVert::get_inColor
*/
        [uniform]
        mat4 projectionMat;
        [uniform]
        mat4 viewMat;
        [uniform]
        mat4 modelMat;
        public vec3* passColorData;
        [OutAttribute]
        vec3 passColor {
            get { return passColorData[gl_VertexID]; }
            set { passColorData[gl_VertexID] = value; }
        }
        /*
         get_passColor() cil managed
{
  // 代码大小       27 (0x1b)
  .maxstack  8
  IL_0000:  ldarg.0
  IL_0001:  ldfld      valuetype [SoftGL.ShadingLanguage]SoftGL.vec3* SoftGL.InnerDemoVert::passColorData
  IL_0006:  ldarg.0
  IL_0007:  ldfld      int32 SoftGL.InnerVertexShaderCodeBase::gl_VertexID
  IL_000c:  conv.i
  IL_000d:  sizeof     [SoftGL.ShadingLanguage]SoftGL.vec3
  IL_0013:  mul
  IL_0014:  add
  IL_0015:  ldobj      [SoftGL.ShadingLanguage]SoftGL.vec3
  IL_001a:  ret
} // end of method InnerDemoVert::get_passColor

         set_passColor(valuetype [SoftGL.ShadingLanguage]SoftGL.vec3 'value') cil managed
{
  // 代码大小       28 (0x1c)
  .maxstack  8
  IL_0000:  ldarg.0
  IL_0001:  ldfld      valuetype [SoftGL.ShadingLanguage]SoftGL.vec3* SoftGL.InnerDemoVert::passColorData
  IL_0006:  ldarg.0
  IL_0007:  ldfld      int32 SoftGL.InnerVertexShaderCodeBase::gl_VertexID
  IL_000c:  conv.i
  IL_000d:  sizeof     [SoftGL.ShadingLanguage]SoftGL.vec3
  IL_0013:  mul
  IL_0014:  add
  IL_0015:  ldarg.1
  IL_0016:  stobj      [SoftGL.ShadingLanguage]SoftGL.vec3
  IL_001b:  ret
} // end of method InnerDemoVert::set_passColor
         */

        #region IMain 成员

        public void main() {
            gl_Position = projectionMat * viewMat * modelMat * new vec4(inPosition, 1.0f);
            passColor = inColor;
        }

        #endregion
    }

}
