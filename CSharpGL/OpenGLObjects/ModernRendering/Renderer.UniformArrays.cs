using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class Renderer
    {
        protected List<UniformBoolArray> uniformBoolArrayVariables;
        protected List<UniformFloatArray> uniformFloatArrayVariables;
        protected List<UniformVec2Array> uniformVec2ArrayVariables;
        protected List<UniformVec3Array> uniformVec3ArrayVariables;
        protected List<UniformVec4Array> uniformVec4ArrayVariables;
        protected List<UniformMat2Array> uniformMat2ArrayVariables;
        protected List<UniformMat3Array> uniformMat3ArrayVariables;
        protected List<UniformMat4Array> uniformMat4ArrayVariables;
        protected List<UniformSamplerArray> uniformSamplerArrayVariables;

        public bool GetUniformBoolArrayValue(string varNameInShader, out bool[] value)
        {
            value = null;
            bool gotUniform = false;
            if (this.uniformBoolArrayVariables == null) { return gotUniform; }

            foreach (var item in this.uniformBoolArrayVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = item.Value;
                    gotUniform = true;
                    break;
                }
            }

            return gotUniform;
        }
        public bool GetUniformFloatArrayValue(string varNameInShader, out float[] value)
        {
            value = null;
            bool gotUniform = false;
            if (this.uniformFloatArrayVariables == null) { return gotUniform; }

            foreach (var item in this.uniformFloatArrayVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = item.Value;
                    gotUniform = true;
                    break;
                }
            }

            return gotUniform;
        }
        public bool GetUniformVec2ArrayValue(string varNameInShader, out vec2[] value)
        {
            value = null;
            bool gotUniform = false;
            if (this.uniformVec2ArrayVariables == null) { return gotUniform; }

            foreach (var item in this.uniformVec2ArrayVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = item.Value;
                    gotUniform = true;
                    break;
                }
            }

            return gotUniform;
        }
        public bool GetUniformVec3ArrayValue(string varNameInShader, out vec3[] value)
        {
            value = null;
            bool gotUniform = false;
            if (this.uniformVec3ArrayVariables == null) { return gotUniform; }

            foreach (var item in this.uniformVec3ArrayVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = item.Value;
                    gotUniform = true;
                    break;
                }
            }

            return gotUniform;
        }
        public bool GetUniformVec4ArrayValue(string varNameInShader, out vec4[] value)
        {
            value = null;
            bool gotUniform = false;
            if (this.uniformVec4ArrayVariables == null) { return gotUniform; }

            foreach (var item in this.uniformVec4ArrayVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = item.Value;
                    gotUniform = true;
                    break;
                }
            }

            return gotUniform;
        }
        public bool GetUniformMat2ArrayValue(string varNameInShader, out mat2[] value)
        {
            value = null;
            bool gotUniform = false;
            if (this.uniformMat2ArrayVariables == null) { return gotUniform; }

            foreach (var item in this.uniformMat2ArrayVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = item.Value;
                    gotUniform = true;
                    break;
                }
            }

            return gotUniform;
        }
        public bool GetUniformMat3ArrayValue(string varNameInShader, out mat3[] value)
        {
            value = null;
            bool gotUniform = false;
            if (this.uniformMat3ArrayVariables == null) { return gotUniform; }

            foreach (var item in this.uniformMat3ArrayVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = item.Value;
                    gotUniform = true;
                    break;
                }
            }

            return gotUniform;
        }
        public bool GetUniformMat4ArrayValue(string varNameInShader, out mat4[] value)
        {
            value = null;
            bool gotUniform = false;
            if (this.uniformMat4ArrayVariables == null) { return gotUniform; }

            foreach (var item in this.uniformMat4ArrayVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = item.Value;
                    gotUniform = true;
                    break;
                }
            }

            return gotUniform;
        }
        public bool GetUniformSamplerArrayValue(string varNameInShader, out samplerValue[] value)
        {
            value = null;
            bool gotUniform = false;
            if (this.uniformSamplerArrayVariables == null) { return gotUniform; }

            foreach (var item in this.uniformSamplerArrayVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = item.Value;
                    gotUniform = true;
                    break;
                }
            }

            return gotUniform;
        }

        public bool SetUniform(string varNameInShader, bool[] value)
        {
            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }

            if (this.uniformBoolArrayVariables == null)
            { this.uniformBoolArrayVariables = new List<UniformBoolArray>(); }

            foreach (var item in this.uniformBoolArrayVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    item.Value = value;
                    updated = true;
                    gotUniform = true;
                    break;
                }
            }

            if (!gotUniform)
            {
                int location = shaderProgram.GetUniformLocation(varNameInShader);
                if (location < 0)
                {
                    throw new Exception(string.Format(
                        "uniform variable [{0}] not exists!", varNameInShader));
                }

                var variable = GetVariableArray(value, varNameInShader) as UniformBoolArray;
                variable.Value = value;
                this.uniformBoolArrayVariables.Add(variable);
                updated = true;
            }

            return updated;
        }

        public bool SetUniform(string varNameInShader, float[] value)
        {
            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }

            if (this.uniformFloatArrayVariables == null)
            { this.uniformFloatArrayVariables = new List<UniformFloatArray>(); }

            foreach (var item in this.uniformFloatArrayVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    item.Value = value;
                    updated = true;
                    gotUniform = true;
                    break;
                }
            }

            if (!gotUniform)
            {
                int location = shaderProgram.GetUniformLocation(varNameInShader);
                if (location < 0)
                {
                    throw new Exception(string.Format(
                        "uniform variable [{0}] not exists!", varNameInShader));
                }

                var variable = GetVariableArray(value, varNameInShader) as UniformFloatArray;
                variable.Value = value;
                this.uniformFloatArrayVariables.Add(variable);
                updated = true;
            }

            return updated;
        }

        public bool SetUniform(string varNameInShader, vec2[] value)
        {
            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }

            if (this.uniformVec2ArrayVariables == null)
            { this.uniformVec2ArrayVariables = new List<UniformVec2Array>(); }

            foreach (var item in this.uniformVec2ArrayVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    item.Value = value;
                    updated = true;
                    gotUniform = true;
                    break;
                }
            }

            if (!gotUniform)
            {
                int location = shaderProgram.GetUniformLocation(varNameInShader);
                if (location < 0)
                {
                    throw new Exception(string.Format(
                        "uniform variable [{0}] not exists!", varNameInShader));
                }

                var variable = GetVariableArray(value, varNameInShader) as UniformVec2Array;
                variable.Value = value;
                this.uniformVec2ArrayVariables.Add(variable);
                updated = true;
            }

            return updated;
        }

        public bool SetUniform(string varNameInShader, vec3[] value)
        {
            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }

            if (this.uniformVec3ArrayVariables == null)
            { this.uniformVec3ArrayVariables = new List<UniformVec3Array>(); }

            foreach (var item in this.uniformVec3ArrayVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    item.Value = value;
                    updated = true;
                    gotUniform = true;
                    break;
                }
            }

            if (!gotUniform)
            {
                int location = shaderProgram.GetUniformLocation(varNameInShader);
                if (location < 0)
                {
                    throw new Exception(string.Format(
                        "uniform variable [{0}] not exists!", varNameInShader));
                }

                var variable = GetVariableArray(value, varNameInShader) as UniformVec3Array;
                variable.Value = value;
                this.uniformVec3ArrayVariables.Add(variable);
                updated = true;
            }

            return updated;
        }

        public bool SetUniform(string varNameInShader, mat2[] value)
        {
            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }

            if (this.uniformMat2ArrayVariables == null)
            { this.uniformMat2ArrayVariables = new List<UniformMat2Array>(); }

            foreach (var item in this.uniformMat2ArrayVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    item.Value = value;
                    updated = true;
                    gotUniform = true;
                    break;
                }
            }

            if (!gotUniform)
            {
                int location = shaderProgram.GetUniformLocation(varNameInShader);
                if (location < 0)
                {
                    throw new Exception(string.Format(
                        "uniform variable [{0}] not exists!", varNameInShader));
                }

                var variable = GetVariableArray(value, varNameInShader) as UniformMat2Array;
                variable.Value = value;
                this.uniformMat2ArrayVariables.Add(variable);
                updated = true;
            }

            return updated;
        }

        public bool SetUniform(string varNameInShader, mat3[] value)
        {
            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }

            if (this.uniformMat3ArrayVariables == null)
            { this.uniformMat3ArrayVariables = new List<UniformMat3Array>(); }

            foreach (var item in this.uniformMat3ArrayVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    item.Value = value;
                    updated = true;
                    gotUniform = true;
                    break;
                }
            }

            if (!gotUniform)
            {
                int location = shaderProgram.GetUniformLocation(varNameInShader);
                if (location < 0)
                {
                    throw new Exception(string.Format(
                        "uniform variable [{0}] not exists!", varNameInShader));
                }

                var variable = GetVariableArray(value, varNameInShader) as UniformMat3Array;
                variable.Value = value;
                this.uniformMat3ArrayVariables.Add(variable);
                updated = true;
            }

            return updated;
        }

        public bool SetUniform(string varNameInShader, mat4[] value)
        {
            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }

            if (this.uniformMat4ArrayVariables == null)
            { this.uniformMat4ArrayVariables = new List<UniformMat4Array>(); }

            foreach (var item in this.uniformMat4ArrayVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    item.Value = value;
                    updated = true;
                    gotUniform = true;
                    break;
                }
            }

            if (!gotUniform)
            {
                int location = shaderProgram.GetUniformLocation(varNameInShader);
                if (location < 0)
                {
                    throw new Exception(string.Format(
                        "uniform variable [{0}] not exists!", varNameInShader));
                }

                var variable = GetVariableArray(value, varNameInShader) as UniformMat4Array;
                variable.Value = value;
                this.uniformMat4ArrayVariables.Add(variable);
                updated = true;
            }

            return updated;
        }

        public bool SetUniform(string varNameInShader, samplerValue[] value)
        {
            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }

            if (this.uniformSamplerArrayVariables == null) 
            { this.uniformSamplerArrayVariables = new List<UniformSamplerArray>(); }

            foreach (var item in this.uniformSamplerArrayVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    item.Value = value;
                    updated = true;
                    gotUniform = true;
                    break;
                }
            }

            if (!gotUniform)
            {
                int location = shaderProgram.GetUniformLocation(varNameInShader);
                if (location < 0)
                {
                    throw new Exception(string.Format(
                        "uniform variable [{0}] not exists!", varNameInShader));
                }

                var variable = GetVariableArray(value, varNameInShader) as UniformSamplerArray;
                variable.Value = value;
                this.uniformSamplerArrayVariables.Add(variable);
                updated = true;
            }

            return updated;
        }

        private UniformArrayVariable GetVariableArray(Array value, string varNameInShader)
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
                object variable = Activator.CreateInstance(varType, varNameInShader);
                return variable as UniformArrayVariable;
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
