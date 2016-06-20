using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class Renderer
    {

        public bool GetUniformBoolArrayValue(string varNameInShader, out bool[] value)
        {
            value = null;
            bool gotUniform = false;

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = (item as UniformBoolArray).Value;
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

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = (item as UniformFloatArray).Value;
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

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = (item as UniformVec2Array).Value;
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

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = (item as UniformVec3Array).Value;
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

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = (item as UniformVec4Array).Value;
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

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = (item as UniformMat2Array).Value;
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

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = (item as UniformMat3Array).Value;
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

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = (item as UniformMat4Array).Value;
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

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = (item as UniformSamplerArray).Value;
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

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    (item as UniformBoolArray).Value = value;
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
                this.uniformVariables.Add(variable);
                updated = true;
            }

            return updated;
        }

        public bool SetUniform(string varNameInShader, float[] value)
        {
            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    (item as UniformFloatArray).Value = value;
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
                this.uniformVariables.Add(variable);
                updated = true;
            }

            return updated;
        }

        public bool SetUniform(string varNameInShader, vec2[] value)
        {
            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    (item as UniformVec2Array).Value = value;
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
                this.uniformVariables.Add(variable);
                updated = true;
            }

            return updated;
        }
        
        public bool SetUniform(string varNameInShader, vec3[] value)
        {
            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    (item as UniformVec3Array).Value = value;
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
                this.uniformVariables.Add(variable);
                updated = true;
            }

            return updated;
        }

        public bool SetUniform(string varNameInShader, vec4[] value)
        {
            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    (item as UniformVec4Array).Value = value;
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

                var variable = GetVariableArray(value, varNameInShader) as UniformVec4Array;
                variable.Value = value;
                this.uniformVariables.Add(variable);
                updated = true;
            }

            return updated;
        }

        public bool SetUniform(string varNameInShader, mat2[] value)
        {
            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    (item as UniformMat2Array).Value = value;
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
                this.uniformVariables.Add(variable);
                updated = true;
            }

            return updated;
        }

        public bool SetUniform(string varNameInShader, mat3[] value)
        {
            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    (item as UniformMat3Array).Value = value;
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
                this.uniformVariables.Add(variable);
                updated = true;
            }

            return updated;
        }

        public bool SetUniform(string varNameInShader, mat4[] value)
        {
            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    (item as UniformMat4Array).Value = value;
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
                this.uniformVariables.Add(variable);
                updated = true;
            }

            return updated;
        }

        public bool SetUniform(string varNameInShader, samplerValue[] value)
        {
            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }

            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    (item as UniformSamplerArray).Value = value;
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
                this.uniformVariables.Add(variable);
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
