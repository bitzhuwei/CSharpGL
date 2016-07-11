using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    public partial class Renderer
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool GetUniformBoolArrayValue(string varNameInShader, out bool[] value)
        {
            value = null;
            bool gotUniform = false;

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = (item as UniformBoolArray).Value.Array;
                    gotUniform = true;
                    break;
                }
            }

            return gotUniform;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool GetUniformFloatArrayValue(string varNameInShader, out float[] value)
        {
            value = null;
            bool gotUniform = false;

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = (item as UniformFloatArray).Value.Array;
                    gotUniform = true;
                    break;
                }
            }

            return gotUniform;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool GetUniformVec2ArrayValue(string varNameInShader, out vec2[] value)
        {
            value = null;
            bool gotUniform = false;

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = (item as UniformVec2Array).Value.Array;
                    gotUniform = true;
                    break;
                }
            }

            return gotUniform;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool GetUniformVec3ArrayValue(string varNameInShader, out vec3[] value)
        {
            value = null;
            bool gotUniform = false;

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = (item as UniformVec3Array).Value.Array;
                    gotUniform = true;
                    break;
                }
            }

            return gotUniform;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool GetUniformVec4ArrayValue(string varNameInShader, out vec4[] value)
        {
            value = null;
            bool gotUniform = false;

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = (item as UniformVec4Array).Value.Array;
                    gotUniform = true;
                    break;
                }
            }

            return gotUniform;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool GetUniformMat2ArrayValue(string varNameInShader, out mat2[] value)
        {
            value = null;
            bool gotUniform = false;

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = (item as UniformMat2Array).Value.Array;
                    gotUniform = true;
                    break;
                }
            }

            return gotUniform;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool GetUniformMat3ArrayValue(string varNameInShader, out mat3[] value)
        {
            value = null;
            bool gotUniform = false;

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = (item as UniformMat3Array).Value.Array;
                    gotUniform = true;
                    break;
                }
            }

            return gotUniform;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool GetUniformMat4ArrayValue(string varNameInShader, out mat4[] value)
        {
            value = null;
            bool gotUniform = false;

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = (item as UniformMat4Array).Value.Array;
                    gotUniform = true;
                    break;
                }
            }

            return gotUniform;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool GetUniformSamplerArrayValue(string varNameInShader, out samplerValue[] value)
        {
            value = null;
            bool gotUniform = false;

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = (item as UniformSamplerArray).Value.Array;
                    gotUniform = true;
                    break;
                }
            }

            return gotUniform;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetUniform(string varNameInShader, bool[] value)
        {
            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    (item as UniformBoolArray).Value = new NoisyArray<bool>(value);
                    updated = true;
                    gotUniform = true;
                    break;
                }
            }

            if (!gotUniform)
            {
                int location = ShaderProgram.GetUniformLocation(varNameInShader);
                if (location < 0)
                {
                    throw new Exception(string.Format(
                        "uniform variable [{0}] not exists!", varNameInShader));
                }

                var variable = GetVariableArray(value, varNameInShader) as UniformBoolArray;
                variable.Value = new NoisyArray<bool>(value);
                this.uniformVariables.Add(variable);
                updated = true;
            }

            return updated;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetUniform(string varNameInShader, float[] value)
        {
            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    (item as UniformFloatArray).Value = new NoisyArray<float>(value);
                    updated = true;
                    gotUniform = true;
                    break;
                }
            }

            if (!gotUniform)
            {
                int location = ShaderProgram.GetUniformLocation(varNameInShader);
                if (location < 0)
                {
                    throw new Exception(string.Format(
                        "uniform variable [{0}] not exists!", varNameInShader));
                }

                var variable = GetVariableArray(value, varNameInShader) as UniformFloatArray;
                variable.Value = new NoisyArray<float>(value);
                this.uniformVariables.Add(variable);
                updated = true;
            }

            return updated;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetUniform(string varNameInShader, vec2[] value)
        {
            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    (item as UniformVec2Array).Value = new NoisyArray<vec2>(value);
                    updated = true;
                    gotUniform = true;
                    break;
                }
            }

            if (!gotUniform)
            {
                int location = ShaderProgram.GetUniformLocation(varNameInShader);
                if (location < 0)
                {
                    throw new Exception(string.Format(
                        "uniform variable [{0}] not exists!", varNameInShader));
                }

                var variable = GetVariableArray(value, varNameInShader) as UniformVec2Array;
                variable.Value = new NoisyArray<vec2>(value);
                this.uniformVariables.Add(variable);
                updated = true;
            }

            return updated;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetUniform(string varNameInShader, vec3[] value)
        {
            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    (item as UniformVec3Array).Value = new NoisyArray<vec3>(value);
                    updated = true;
                    gotUniform = true;
                    break;
                }
            }

            if (!gotUniform)
            {
                int location = ShaderProgram.GetUniformLocation(varNameInShader);
                if (location < 0)
                {
                    throw new Exception(string.Format(
                        "uniform variable [{0}] not exists!", varNameInShader));
                }

                var variable = GetVariableArray(value, varNameInShader) as UniformVec3Array;
                variable.Value = new NoisyArray<vec3>(value);
                this.uniformVariables.Add(variable);
                updated = true;
            }

            return updated;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetUniform(string varNameInShader, vec4[] value)
        {
            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    (item as UniformVec4Array).Value = new NoisyArray<vec4>(value);
                    updated = true;
                    gotUniform = true;
                    break;
                }
            }

            if (!gotUniform)
            {
                int location = ShaderProgram.GetUniformLocation(varNameInShader);
                if (location < 0)
                {
                    throw new Exception(string.Format(
                        "uniform variable [{0}] not exists!", varNameInShader));
                }

                var variable = GetVariableArray(value, varNameInShader) as UniformVec4Array;
                variable.Value = new NoisyArray<vec4>(value);
                this.uniformVariables.Add(variable);
                updated = true;
            }

            return updated;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetUniform(string varNameInShader, mat2[] value)
        {
            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    (item as UniformMat2Array).Value = new NoisyArray<mat2>(value);
                    updated = true;
                    gotUniform = true;
                    break;
                }
            }

            if (!gotUniform)
            {
                int location = ShaderProgram.GetUniformLocation(varNameInShader);
                if (location < 0)
                {
                    throw new Exception(string.Format(
                        "uniform variable [{0}] not exists!", varNameInShader));
                }

                var variable = GetVariableArray(value, varNameInShader) as UniformMat2Array;
                variable.Value = new NoisyArray<mat2>(value);
                this.uniformVariables.Add(variable);
                updated = true;
            }

            return updated;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetUniform(string varNameInShader, mat3[] value)
        {
            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    (item as UniformMat3Array).Value = new NoisyArray<mat3>(value);
                    updated = true;
                    gotUniform = true;
                    break;
                }
            }

            if (!gotUniform)
            {
                int location = ShaderProgram.GetUniformLocation(varNameInShader);
                if (location < 0)
                {
                    throw new Exception(string.Format(
                        "uniform variable [{0}] not exists!", varNameInShader));
                }

                var variable = GetVariableArray(value, varNameInShader) as UniformMat3Array;
                variable.Value = new NoisyArray<mat3>(value);
                this.uniformVariables.Add(variable);
                updated = true;
            }

            return updated;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetUniform(string varNameInShader, mat4[] value)
        {
            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    (item as UniformMat4Array).Value = new NoisyArray<mat4>(value);
                    updated = true;
                    gotUniform = true;
                    break;
                }
            }

            if (!gotUniform)
            {
                int location = ShaderProgram.GetUniformLocation(varNameInShader);
                if (location < 0)
                {
                    throw new Exception(string.Format(
                        "uniform variable [{0}] not exists!", varNameInShader));
                }

                var variable = GetVariableArray(value, varNameInShader) as UniformMat4Array;
                variable.Value = new NoisyArray<mat4>(value);
                this.uniformVariables.Add(variable);
                updated = true;
            }

            return updated;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetUniform(string varNameInShader, samplerValue[] value)
        {
            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    (item as UniformSamplerArray).Value = new NoisyArray<samplerValue>(value);
                    updated = true;
                    gotUniform = true;
                    break;
                }
            }

            if (!gotUniform)
            {
                int location = ShaderProgram.GetUniformLocation(varNameInShader);
                if (location < 0)
                {
                    throw new Exception(string.Format(
                        "uniform variable [{0}] not exists!", varNameInShader));
                }

                var variable = GetVariableArray(value, varNameInShader) as UniformSamplerArray;
                variable.Value = new NoisyArray<samplerValue>(value);
                this.uniformVariables.Add(variable);
                updated = true;
            }

            return updated;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        private object GetVariableArray(Array value, string varNameInShader)
        {
            Type t = value.GetType().GetElementType();
            Type varType;

            if (variableArrayDict == null)
            {
                variableArrayDict = new Dictionary<Type, Type>();
                variableArrayDict.Add(typeof(bool), typeof(UniformBoolArray));
                variableArrayDict.Add(typeof(float), typeof(UniformFloatArray));
                variableArrayDict.Add(typeof(vec2), typeof(UniformVec2Array));
                variableArrayDict.Add(typeof(vec3), typeof(UniformVec3Array));
                variableArrayDict.Add(typeof(vec4), typeof(UniformVec4Array));
                variableArrayDict.Add(typeof(mat2), typeof(UniformMat2Array));
                variableArrayDict.Add(typeof(mat3), typeof(UniformMat3Array));
                variableArrayDict.Add(typeof(mat4), typeof(UniformMat4Array));
                variableArrayDict.Add(typeof(samplerValue), typeof(UniformSamplerArray));
            }

            if (variableArrayDict.TryGetValue(t, out varType))
            {
                return Activator.CreateInstance(varType, varNameInShader);
            }
            else
            {
                throw new Exception(string.Format(
                    "UniformVariable type [{0}] doesn't exists or not included in the variableDict!",
                    t));
            }
        }

        static Dictionary<Type, Type> variableArrayDict;

    }
}
