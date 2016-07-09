using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public static class TypeHelper
    {
        /// <summary>
        /// Create an instance of specified <typeparamref name="type"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object CreateInstance(this Type type)
        {
            if (type == null)
            { throw new ArgumentNullException(); }

            object obj;
            if (type.IsValueType)
            {
                obj = Activator.CreateInstance(type);
            }
            else
            {
                ConstructorInfo ctor = (from item in type.GetConstructors() orderby item.GetParameters().Length select item).First();
                ParameterInfo[] parameterInfos = ctor.GetParameters();
                if (parameterInfos.Length == 0)
                { obj = Activator.CreateInstance(type); }
                else
                {
                    var parameters = new object[parameterInfos.Length];
                    for (int i = 0; i < parameterInfos.Length; i++)
                    {
                        if (parameterInfos[i].ParameterType.IsClass)
                        { parameters[i] = null; }
                        else
                        { parameters[i] = Activator.CreateInstance(parameterInfos[i].ParameterType); }
                    }
                    obj = Activator.CreateInstance(type, parameters);
                }
            }

            return obj;
        }
    }
}
