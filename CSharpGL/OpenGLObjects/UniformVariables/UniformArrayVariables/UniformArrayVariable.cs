using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    // TODO: No Uniform Array Variable types are tested yet.
    /// <summary>
    /// shader中的一个数组类型的uniform变量。
    /// 例如：uniform vec3 positions[10];
    /// </summary>
    public abstract class UniformArrayVariable<T> : UniformArrayVariableBase
    {

        private NoisyArray<T> value;
        /// <summary>
        /// 
        /// </summary>
        public NoisyArray<T> Value
        {
            get { return this.value; }
            set
            {
                if (this.value != value)
                {
                    if (this.value != null)
                    { this.value.ItemUpdated -= eventHandler; }

                    if (value != null)
                    {
                        value.ItemUpdated += eventHandler;
                        this.value = value;
                        this.Updated = true;
                    }
                }
            }
        }

        private void value_ItemUpdated(object sender, NoisyArrayEventArgs<T> e)
        {
            this.Updated = true;
        }

        EventHandler<NoisyArrayEventArgs<T>> eventHandler;
        /// <summary>
        /// shader中的一个数组类型的uniform变量。
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="length"></param>
        public UniformArrayVariable(string varName, int length)
            : base(varName)
        {
            this.eventHandler = new EventHandler<NoisyArrayEventArgs<T>>(value_ItemUpdated);
            this.Value = new NoisyArray<T>(length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            Array array = this.Value.Array;
            if (array != null)
            {
                return string.Format("{0} {1}: [{2}]", this.GetType().Name, this.VarName, array.PrintArray("; "));
            }
            else
            {
                return string.Format("{0} {1}: []", this.GetType().Name, this.VarName);
            }
        }
    }

}
