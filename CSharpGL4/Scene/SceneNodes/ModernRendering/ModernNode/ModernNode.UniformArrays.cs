using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CSharpGL
{
    public partial class ModernNode
    {
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="varNameInShader"></param>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public bool GetUniformBoolArrayValue(string varNameInShader, out bool[] value)
        //{
        //    return this.Program.GetUniformBoolArrayValue(varNameInShader, out value);
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="varNameInShader"></param>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public bool GetUniformFloatArrayValue(string varNameInShader, out float[] value)
        //{
        //    return this.Program.GetUniformFloatArrayValue(varNameInShader, out value);
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="varNameInShader"></param>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public bool GetUniformVec2ArrayValue(string varNameInShader, out vec2[] value)
        //{
        //    return this.Program.GetUniformVec2ArrayValue(varNameInShader, out value);
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="varNameInShader"></param>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public bool GetUniformVec3ArrayValue(string varNameInShader, out vec3[] value)
        //{
        //    return this.Program.GetUniformVec3ArrayValue(varNameInShader, out value);

        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="varNameInShader"></param>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public bool GetUniformVec4ArrayValue(string varNameInShader, out vec4[] value)
        //{
        //    return this.Program.GetUniformVec4ArrayValue(varNameInShader, out value);
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="varNameInShader"></param>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public bool GetUniformMat2ArrayValue(string varNameInShader, out mat2[] value)
        //{
        //    return this.Program.GetUniformMat2ArrayValue(varNameInShader, out value);
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="varNameInShader"></param>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public bool GetUniformMat3ArrayValue(string varNameInShader, out mat3[] value)
        //{
        //    return this.Program.GetUniformMat3ArrayValue(varNameInShader, out value);
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="varNameInShader"></param>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public bool GetUniformMat4ArrayValue(string varNameInShader, out mat4[] value)
        //{
        //    return this.Program.GetUniformMat4ArrayValue(varNameInShader, out value);
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="varNameInShader"></param>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public bool GetUniformSamplerArrayValue(string varNameInShader, out samplerValue[] value)
        //{
        //    return this.Program.GetUniformSamplerArrayValue(varNameInShader, out value);
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="varNameInShader"></param>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public bool SetUniform(string varNameInShader, bool[] value)
        //{
        //    return this.Program.SetUniform(varNameInShader, value);
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="varNameInShader"></param>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public bool SetUniform(string varNameInShader, float[] value)
        //{
        //    return this.Program.SetUniform(varNameInShader, value);
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="varNameInShader"></param>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public bool SetUniform(string varNameInShader, vec2[] value)
        //{
        //    return this.Program.SetUniform(varNameInShader, value);
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="varNameInShader"></param>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public bool SetUniform(string varNameInShader, vec3[] value)
        //{
        //    return this.Program.SetUniform(varNameInShader, value);
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="varNameInShader"></param>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public bool SetUniform(string varNameInShader, vec4[] value)
        //{
        //    return this.Program.SetUniform(varNameInShader, value);
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="varNameInShader"></param>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public bool SetUniform(string varNameInShader, mat2[] value)
        //{
        //    return this.Program.SetUniform(varNameInShader, value);
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="varNameInShader"></param>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public bool SetUniform(string varNameInShader, mat3[] value)
        //{
        //    return this.Program.SetUniform(varNameInShader, value);
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="varNameInShader"></param>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public bool SetUniform(string varNameInShader, mat4[] value)
        //{
        //    return this.Program.SetUniform(varNameInShader, value);
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="varNameInShader"></param>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public bool SetUniform(string varNameInShader, samplerValue[] value)
        //{
        //    return this.Program.SetUniform(varNameInShader, value);
        //}

    }
}