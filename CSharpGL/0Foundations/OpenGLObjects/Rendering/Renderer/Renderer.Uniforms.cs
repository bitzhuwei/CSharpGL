using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CSharpGL
{
    public partial class Renderer
    {
        /// <summary>
        ///
        /// </summary>
        protected List<UniformVariable> uniformVariables = new List<UniformVariable>();

        //protected OrderedCollection<string> uniformVariableNames = new OrderedCollection<string>(", ");
        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="varNameInShader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool GetUniformValue<T>(string varNameInShader, out T value) where T : struct, IEquatable<T>
        {
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

            value = default(T);
            bool gotUniform = false;
            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    value = (item as UniformSingleVariable<T>).Value;
                    gotUniform = true;
                    break;
                }
            }

            return gotUniform;
        }

        ///// <summary>
        /////
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="blockName"></param>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public bool SetUniformBlock<T>(string blockName, T value) where T : struct,IEquatable<T>
        //{
        //    //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

        //    bool gotUniform = false;
        //    bool updated = false;
        //    foreach (var item in this.uniformVariables)
        //    {
        //        if (item.VarName == blockName)
        //        {
        //            var variable = item as UniformBlock<T>;
        //            if (variable == null)
        //            { throw new ArgumentException(string.Format("Wrong type[{0}] for uniform block [{1}] [{2}];", typeof(T), item.GetType().Name, item.VarName)); }

        //            variable.Value = value;
        //            updated = variable.Updated;
        //            gotUniform = true;
        //            break;
        //        }
        //    }

        //    if (!gotUniform)
        //    {
        //        //if (ShaderProgram == null)
        //        //{ throw new Exception(string.Format("{0} is not initialized!", this.GetType().Name)); }

        //        //int location = ShaderProgram.GetUniformLocation(varNameInShader);
        //        //if (location < 0)
        //        //{
        //        //    throw new Exception(string.Format(
        //        //        "niform variable [{0}] not exists! Remember to invoke RendererBase.Initialize(); before this method.", varNameInShader));
        //        //}

        //        var variable = new UniformBlock<T>(blockName);
        //        variable.Value = value;
        //        this.uniformVariables.Add(variable);
        //        updated = true;
        //    }

        //    return updated;
        //}

        /// <summary>
        /// Sets up a new value to specified uniform variable and mark it as updated so that the new value will be sent to shader before rendering.
        /// </summary>
        public bool SetUniform<T>(string varNameInShader, T value) where T : struct,IEquatable<T>
        {
            //if ((!this.Initialized) && (!this.Initializing)) { this.Initialize(); }

            bool gotUniform = false;
            bool updated = false;
            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    var variable = item as UniformSingleVariable<T>;
                    if (variable == null)
                    { throw new ArgumentException(string.Format("Wrong type[{0}] for uniform variable [{1}] [{2}];", typeof(T), item.GetType().Name, item.VarName)); }

                    variable.Value = value;
                    updated = variable.Updated;
                    gotUniform = true;
                    break;
                }
            }

            if (!gotUniform)
            {
                //if (ShaderProgram == null)
                //{ throw new Exception(string.Format("{0} is not initialized!", this.GetType().Name)); }

                //int location = ShaderProgram.GetUniformLocation(varNameInShader);
                //if (location < 0)
                //{
                //    throw new Exception(string.Format(
                //        "niform variable [{0}] not exists! Remember to invoke RendererBase.Initialize(); before this method.", varNameInShader));
                //}

                var variable = GetVariable(value, varNameInShader) as UniformSingleVariable<T>;
                variable.Value = value;
                this.uniformVariables.Add(variable);
                updated = true;
            }

            return updated;
        }

        private object GetVariable<T>(T value, string varNameInShader) where T : struct,IEquatable<T>
        {
            Type t = value.GetType();
            Type varType;

            if (variableDict == null)
            {
                variableDict = new Dictionary<Type, Type>();
                Type baseType = typeof(CSharpGL.UniformSingleVariableBase);
                Assembly asm = Assembly.GetAssembly(baseType);
                var types = from item in asm.GetTypes()
                            where (baseType.IsAssignableFrom(item)
                                 && (!item.IsAbstract)
                                 && (!item.IsGenericType))
                            orderby item.FullName
                            select item;
                foreach (Type item in types)
                {
                    try
                    {
                        // example: variableDict.Add(typeof(int), typeof(UniformInt32));
                        bool found = false;
                        foreach (PropertyInfo propertyInfo in item.GetProperties())
                        {
                            if (propertyInfo.GetCustomAttributes(typeof(UniformValueAttribute), true).Count() > 0)
                            {
                                variableDict.Add(propertyInfo.PropertyType, item);
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            throw new Exception(string.Format("No property in [{0}] is marked with [{1}].", item, typeof(UniformValueAttribute)));
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            if (variableDict.TryGetValue(t, out varType))
            {
                return Activator.CreateInstance(varType, varNameInShader);
            }
            else
            {
                // it's a uniform block.(The only non-abstract generic sub-type of UniformSingleVariableBase)
                return new UniformBlock<T>(varNameInShader);
                //throw new Exception(string.Format(
                //"UniformVariable type [{0}] doesn't exists or not included in the variableDict!",
                //t));
            }
        }

        private static Dictionary<Type, Type> variableDict;
    }
}