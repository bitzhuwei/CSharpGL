using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace CSharpGL {
    public unsafe partial class GLProgram {
        /// <summary>
        ///
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool GetUniformBoolArrayValue(string varNameInShader, out bool[] value) {
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

            value = Array.Empty<bool>();
            bool gotUniform = false;
            if (this.uniformVariables.TryGetValue(varNameInShader, out var v)) {
                if (v is UniformBoolArray array) {
                    value = array.Value.Array;
                    gotUniform = true;
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
        public bool GetUniformFloatArrayValue(string varNameInShader, out float[] value) {
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

            value = Array.Empty<float>();
            bool gotUniform = false;
            if (this.uniformVariables.TryGetValue(varNameInShader, out var v)) {
                if (v is UniformFloatArray array) {
                    value = array.Value.Array;
                    gotUniform = true;
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
        public bool GetUniformVec2ArrayValue(string varNameInShader, out vec2[] value) {
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

            value = Array.Empty<vec2>();
            bool gotUniform = false;
            if (this.uniformVariables.TryGetValue(varNameInShader, out var v)) {
                if (v is UniformVec2Array array) {
                    value = array.Value.Array;
                    gotUniform = true;
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
        public bool GetUniformVec3ArrayValue(string varNameInShader, out vec3[] value) {
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

            value = Array.Empty<vec3>();
            bool gotUniform = false;
            if (this.uniformVariables.TryGetValue(varNameInShader, out var v)) {
                if (v is UniformVec3Array array) {
                    value = array.Value.Array;
                    gotUniform = true;
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
        public bool GetUniformVec4ArrayValue(string varNameInShader, out vec4[] value) {
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

            value = Array.Empty<vec4>();
            bool gotUniform = false;
            if (this.uniformVariables.TryGetValue(varNameInShader, out var v)) {
                if (v is UniformVec4Array array) {
                    value = array.Value.Array;
                    gotUniform = true;
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
        public bool GetUniformMat2ArrayValue(string varNameInShader, out mat2[] value) {
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

            value = Array.Empty<mat2>();
            bool gotUniform = false;
            if (this.uniformVariables.TryGetValue(varNameInShader, out var v)) {
                if (v is UniformMat2Array array) {
                    value = array.Value.Array;
                    gotUniform = true;
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
        public bool GetUniformMat3ArrayValue(string varNameInShader, out mat3[] value) {
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

            value = Array.Empty<mat3>();
            bool gotUniform = false;
            if (this.uniformVariables.TryGetValue(varNameInShader, out var v)) {
                if (v is UniformMat3Array array) {
                    value = array.Value.Array;
                    gotUniform = true;
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
        public bool GetUniformMat4ArrayValue(string varNameInShader, out mat4[] value) {
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

            value = Array.Empty<mat4>();
            bool gotUniform = false;
            if (this.uniformVariables.TryGetValue(varNameInShader, out var v)) {
                if (v is UniformMat4Array array) {
                    value = array.Value.Array;
                    gotUniform = true;
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
        public bool GetUniformSamplerArrayValue(string varNameInShader, out samplerValue[] value) {
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

            value = Array.Empty<samplerValue>();
            bool gotUniform = false;
            if (this.uniformVariables.TryGetValue(varNameInShader, out var v)) {
                if (v is UniformSamplerArray array) {
                    value = array.Value.Array;
                    gotUniform = true;
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
        public bool SetUniform(string varNameInShader, bool[] value) {
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }
            if (this.uniformVariables.TryGetValue(varNameInShader, out var v)) {
                if (v is UniformBoolArray array) {
                    array.Value = new NoisyArray<bool>(value);
                    updated = true;
                    gotUniform = true;
                }
            }

            if (!gotUniform) {
                //int location = Program.GetUniformLocation(varNameInShader);
                //if (location < 0)
                {
                    //throw new Exception(string.Format(
                    //"niform variable [{0}] not exists! Remember to invoke RendererBase.Initialize(); before this method.", varNameInShader));
                }

                if (GetVariableArray(value, varNameInShader) is UniformBoolArray variable) {
                    variable.Value = new NoisyArray<bool>(value);
                    Debug.Assert(varNameInShader == variable.varName);
                    this.uniformVariables.Add(variable.varName, variable);
                    updated = true;
                }
            }

            return updated;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetUniform(string varNameInShader, float[] value) {
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }
            if (this.uniformVariables.TryGetValue(varNameInShader, out var v)) {
                if (v is UniformFloatArray array) {
                    array.Value = new NoisyArray<float>(value);
                    updated = true;
                    gotUniform = true;
                }
            }

            if (!gotUniform) {
                //int location = Program.GetUniformLocation(varNameInShader);
                //if (location < 0)
                //{
                //throw new Exception(string.Format(
                //"niform variable [{0}] not exists! Remember to invoke RendererBase.Initialize(); before this method.", varNameInShader));
                //}

                if (GetVariableArray(value, varNameInShader) is UniformFloatArray variable) {
                    variable.Value = new NoisyArray<float>(value);
                    Debug.Assert(varNameInShader == variable.varName);
                    this.uniformVariables.Add(variable.varName, variable);
                    updated = true;
                }
            }

            return updated;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetUniform(string varNameInShader, vec2[] value) {
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }
            if (this.uniformVariables.TryGetValue(varNameInShader, out var v)) {
                if (v is UniformVec2Array array) {
                    array.Value = new NoisyArray<vec2>(value);
                    updated = true;
                    gotUniform = true;
                }
            }

            if (!gotUniform) {
                //int location = Program.GetUniformLocation(varNameInShader);
                //if (location < 0)
                {
                    //throw new Exception(string.Format(
                    //"niform variable [{0}] not exists! Remember to invoke RendererBase.Initialize(); before this method.", varNameInShader));
                }

                if (GetVariableArray(value, varNameInShader) is UniformVec2Array variable) {
                    variable.Value = new NoisyArray<vec2>(value);
                    Debug.Assert(varNameInShader == variable.varName);
                    this.uniformVariables.Add(variable.varName, variable);
                    updated = true;
                }
            }

            return updated;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetUniform(string varNameInShader, vec3[] value) {
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }
            if (this.uniformVariables.TryGetValue(varNameInShader, out var v)) {
                if (v is UniformVec3Array array) {
                    array.Value = new NoisyArray<vec3>(value);
                    updated = true;
                    gotUniform = true;
                }
            }

            if (!gotUniform) {
                //int location = Program.GetUniformLocation(varNameInShader);
                //if (location < 0)
                {
                    //throw new Exception(string.Format(
                    //"niform variable [{0}] not exists! Remember to invoke RendererBase.Initialize(); before this method.", varNameInShader));
                }

                if (GetVariableArray(value, varNameInShader) is UniformVec3Array variable) {
                    variable.Value = new NoisyArray<vec3>(value);
                    Debug.Assert(varNameInShader == variable.varName);
                    this.uniformVariables.Add(variable.varName, variable);
                    updated = true;
                }
            }

            return updated;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetUniform(string varNameInShader, vec4[] value) {
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }
            if (this.uniformVariables.TryGetValue(varNameInShader, out var v)) {
                if (v is UniformVec4Array array) {
                    array.Value = new NoisyArray<vec4>(value);
                    updated = true;
                    gotUniform = true;
                }
            }

            if (!gotUniform) {
                //int location = Program.GetUniformLocation(varNameInShader);
                //if (location < 0)
                {
                    //throw new Exception(string.Format(
                    //"niform variable [{0}] not exists! Remember to invoke RendererBase.Initialize(); before this method.", varNameInShader));
                }

                if (GetVariableArray(value, varNameInShader) is UniformVec4Array variable) {
                    variable.Value = new NoisyArray<vec4>(value);
                    Debug.Assert(varNameInShader == variable.varName);
                    this.uniformVariables.Add(variable.varName, variable);
                    updated = true;
                }
            }

            return updated;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetUniform(string varNameInShader, mat2[] value) {
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }
            if (this.uniformVariables.TryGetValue(varNameInShader, out var v)) {
                if (v is UniformMat2Array array) {
                    array.Value = new NoisyArray<mat2>(value);
                    updated = true;
                    gotUniform = true;
                }
            }

            if (!gotUniform) {
                //int location = Program.GetUniformLocation(varNameInShader);
                //if (location < 0)
                {
                    //throw new Exception(string.Format(
                    //"niform variable [{0}] not exists! Remember to invoke RendererBase.Initialize(); before this method.", varNameInShader));
                }

                if (GetVariableArray(value, varNameInShader) is UniformMat2Array variable) {
                    variable.Value = new NoisyArray<mat2>(value);
                    Debug.Assert(varNameInShader == variable.varName);
                    this.uniformVariables.Add(variable.varName, variable);
                    updated = true;
                }
            }

            return updated;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetUniform(string varNameInShader, mat3[] value) {
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }
            if (this.uniformVariables.TryGetValue(varNameInShader, out var v)) {
                if (v is UniformMat3Array array) {
                    array.Value = new NoisyArray<mat3>(value);
                    updated = true;
                    gotUniform = true;
                }
            }

            if (!gotUniform) {
                //int location = Program.GetUniformLocation(varNameInShader);
                //if (location < 0)
                {
                    //throw new Exception(string.Format(
                    //"niform variable [{0}] not exists! Remember to invoke RendererBase.Initialize(); before this method.", varNameInShader));
                }

                if (GetVariableArray(value, varNameInShader) is UniformMat3Array variable) {
                    variable.Value = new NoisyArray<mat3>(value);
                    Debug.Assert(varNameInShader == variable.varName);
                    this.uniformVariables.Add(variable.varName, variable);
                    updated = true;
                }
            }

            return updated;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetUniform(string varNameInShader, mat4[] value) {
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }
            if (this.uniformVariables.TryGetValue(varNameInShader, out var v)) {
                if (v is UniformMat4Array array) {
                    array.Value = new NoisyArray<mat4>(value);
                    updated = true;
                    gotUniform = true;
                }
            }

            if (!gotUniform) {
                //int location = Program.GetUniformLocation(varNameInShader);
                //if (location < 0)
                {
                    //throw new Exception(string.Format(
                    //"niform variable [{0}] not exists! Remember to invoke RendererBase.Initialize(); before this method.", varNameInShader));
                }

                if (GetVariableArray(value, varNameInShader) is UniformMat4Array variable) {
                    variable.Value = new NoisyArray<mat4>(value);
                    Debug.Assert(varNameInShader == variable.varName);
                    this.uniformVariables.Add(variable.varName, variable);
                    updated = true;
                }
            }

            return updated;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetUniform(string varNameInShader, samplerValue[] value) {
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

            bool gotUniform = false;
            bool updated = false;
            if (value.Length <= 0) { return updated; }
            if (this.uniformVariables.TryGetValue(varNameInShader, out var v)) {
                if (v is UniformSamplerArray array) {
                    array.Value = new NoisyArray<samplerValue>(value);
                    updated = true;
                    gotUniform = true;
                }
            }

            if (!gotUniform) {
                //int location = Program.GetUniformLocation(varNameInShader);
                //if (location < 0)
                {
                    //throw new Exception(string.Format(
                    //"niform variable [{0}] not exists! Remember to invoke RendererBase.Initialize(); before this method.", varNameInShader));
                }

                if (GetVariableArray(value, varNameInShader) is UniformSamplerArray variable) {
                    variable.Value = new NoisyArray<samplerValue>(value);
                    Debug.Assert(varNameInShader == variable.varName);
                    this.uniformVariables.Add(variable.varName, variable);
                    updated = true;
                }
            }

            return updated;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        private object? GetVariableArray(Array value, string varNameInShader) {
            if (variableArrayDict == null) {
                variableArrayDict = new Dictionary<Type, Type>();
                Type baseType = typeof(CSharpGL.UniformArrayVariableBase);
                var asm = Assembly.GetAssembly(baseType);
                Debug.Assert(asm != null);
                var types = from item in asm.GetTypes()
                            where (baseType.IsAssignableFrom(item)
                                 && (!item.IsAbstract)
                                 && (!item.IsGenericType))
                            select item;
                foreach (Type item in types) {
                    // example: variableDict.Add(typeof(int), typeof(UniformInt32));
                    bool found = false;
                    foreach (PropertyInfo propertyInfo in item.GetProperties()) {
                        if (propertyInfo.GetCustomAttributes(typeof(UniformValueAttribute), true).Count() > 0) {
                            // example: variableArrayDict.Add(typeof(float), typeof(UniformFloatArray));
                            Debug.Assert(item.BaseType != null);
                            variableArrayDict.Add(item.BaseType.GetGenericArguments()[0], item);
                            found = true;
                            break;
                        }
                    }
                    if (!found) {
                        throw new Exception(string.Format("No property in [{0}] is marked with [{1}].", item, typeof(UniformValueAttribute)));
                    }
                }
            }

            var key = value.GetType().GetElementType();
            Debug.Assert(key != null);
            if (variableArrayDict.TryGetValue(key, out var varType)) {
                return Activator.CreateInstance(varType, varNameInShader, value.Length);
            }
            else {
                throw new Exception(string.Format(
                    "UniformVariable type [{0}] doesn't exists or not included in the variableDict!",
                    key));
            }
        }

        private static Dictionary<Type, Type>? variableArrayDict;
    }
}