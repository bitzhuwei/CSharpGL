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

        /// <summary>
        /// 
        /// </summary>
        public bool SetUniform<T>(string varNameInShader, T value) where T : struct,IEquatable<T>
        {
            bool gotUniform = false;
            bool updated = false;
            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == varNameInShader)
                {
                    var variable = item as UniformSingleVariable<T>;
                    variable.Value = value;
                    updated = variable.Updated;
                    gotUniform = true;
                    break;
                }
            }

            if (!gotUniform)
            {
                if (ShaderProgram == null)
                { throw new Exception(string.Format("{0} is not initialized!", this.GetType().Name)); }

                int location = ShaderProgram.GetUniformLocation(varNameInShader);
                if (location < 0)
                {
                    throw new Exception(string.Format(
                        "uniform variable [{0}] not exists!", varNameInShader));
                }

                var variable = GetVariable(value, varNameInShader) as UniformSingleVariable<T>;
                variable.Value = value;
                this.uniformVariables.Add(variable);
                updated = true;
            }

            return updated;
        }

        private object GetVariable<T>(T value, string varNameInShader)
        {
            Type t = value.GetType();
            Type varType;

            if (variableDict == null)
            {
                variableDict = new Dictionary<Type, Type>();
                var types = AssemblyHelper.GetAllDerivedTypes(typeof(UniformSingleVariableBase));
                foreach (var item in types)
                {
                    try
                    {
                        // example: variableDict.Add(typeof(int), typeof(UniformInt32));
                        variableDict.Add(item.GetProperty("Value").PropertyType, item);
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
                throw new Exception(string.Format(
                    "UniformVariable type [{0}] doesn't exists or not included in the variableDict!",
                    t));
            }
        }

        static Dictionary<Type, Type> variableDict;


    }
}
