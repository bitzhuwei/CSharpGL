using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Text;

namespace CSharpGL
{
    public partial class ShaderProgram
    {
        /// <summary>
        /// 
        /// </summary>
        public void LoadAllUniforms()
        {
            uint programId = this.ProgramId;
            int count = GetActivetUniformCount(programId);
            int maxLength = GetActionUniformNameMaxLength(programId);
            var uniformNames = new string[count];
            var nameLength = new int[1];
            var uniformVarSize = new int[1];
            var uniformVarType = new uint[1];
            for (uint index = 0; index < count; index++)
            {
                var il = new StringBuilder(maxLength);
                glGetActiveUniform(programId, index, maxLength, nameLength, uniformVarSize, uniformVarType, il);
                uniformNames[index] = il.ToString();
            }

        }

        private int GetActionUniformNameMaxLength(uint programId)
        {
            //  Get the info log length.
            int[] infoLength = new int[] { 0 };
            glGetProgramiv(programId, GL.GL_ACTIVE_UNIFORM_MAX_LENGTH, infoLength);
            return infoLength[0];
        }


        /// <summary>
        /// How many uniform variables are there?
        /// </summary>
        /// <param name="programId"></param>
        /// <returns></returns>
        private int GetActivetUniformCount(uint programId)
        {
            //  Get the info log length.
            int[] infoLength = new int[] { 0 };
            glGetProgramiv(programId, GL.GL_ACTIVE_UNIFORMS, infoLength);
            return infoLength[0];
        }

    }
}