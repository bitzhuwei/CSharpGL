using System;
using System.Collections.Generic;

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
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

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
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

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
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

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
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

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
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

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
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

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
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

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
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

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
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

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
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

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
                //int location = Program.GetUniformLocation(varNameInShader);
                //if (location < 0)
                {
                    //throw new Exception(string.Format(
                    //"niform variable [{0}] not exists! Remember to invoke RendererBase.Initialize(); before this method.", varNameInShader));
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
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

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
                //int location = Program.GetUniformLocation(varNameInShader);
                //if (location < 0)
                {
                    //throw new Exception(string.Format(
                    //"niform variable [{0}] not exists! Remember to invoke RendererBase.Initialize(); before this method.", varNameInShader));
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
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

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
                //int location = Program.GetUniformLocation(varNameInShader);
                //if (location < 0)
                {
                    //throw new Exception(string.Format(
                    //"niform variable [{0}] not exists! Remember to invoke RendererBase.Initialize(); before this method.", varNameInShader));
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
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

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
                //int location = Program.GetUniformLocation(varNameInShader);
                //if (location < 0)
                {
                    //throw new Exception(string.Format(
                    //"niform variable [{0}] not exists! Remember to invoke RendererBase.Initialize(); before this method.", varNameInShader));
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
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

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
                //int location = Program.GetUniformLocation(varNameInShader);
                //if (location < 0)
                {
                    //throw new Exception(string.Format(
                    //"niform variable [{0}] not exists! Remember to invoke RendererBase.Initialize(); before this method.", varNameInShader));
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
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

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
                //int location = Program.GetUniformLocation(varNameInShader);
                //if (location < 0)
                {
                    //throw new Exception(string.Format(
                    //"niform variable [{0}] not exists! Remember to invoke RendererBase.Initialize(); before this method.", varNameInShader));
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
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

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
                //int location = Program.GetUniformLocation(varNameInShader);
                //if (location < 0)
                {
                    //throw new Exception(string.Format(
                    //"niform variable [{0}] not exists! Remember to invoke RendererBase.Initialize(); before this method.", varNameInShader));
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
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

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
                //int location = Program.GetUniformLocation(varNameInShader);
                //if (location < 0)
                {
                    //throw new Exception(string.Format(
                    //"niform variable [{0}] not exists! Remember to invoke RendererBase.Initialize(); before this method.", varNameInShader));
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
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

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
                //int location = Program.GetUniformLocation(varNameInShader);
                //if (location < 0)
                {
                    //throw new Exception(string.Format(
                    //"niform variable [{0}] not exists! Remember to invoke RendererBase.Initialize(); before this method.", varNameInShader));
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
                var types = AssemblyHelper.GetAllDerivedTypes(
                    typeof(UniformArrayVariableBase), x => !x.IsAbstract);
                foreach (var item in types)
                {
                    try
                    {
                        // example: variableArrayDict.Add(typeof(float), typeof(UniformFloatArray));
                        variableArrayDict.Add(item.BaseType.GetGenericArguments()[0], item);
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            if (variableArrayDict.TryGetValue(t, out varType))
            {
                return Activator.CreateInstance(varType, varNameInShader, value.Length);
            }
            else
            {
                throw new Exception(string.Format(
                    "UniformVariable type [{0}] doesn't exists or not included in the variableDict!",
                    t));
            }
        }

        private static Dictionary<Type, Type> variableArrayDict;
    }
}