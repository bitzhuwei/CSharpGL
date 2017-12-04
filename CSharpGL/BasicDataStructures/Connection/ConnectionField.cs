using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// When Someone chhanged its value, I will know.
    /// <para>If my value has changed, others will know.</para>
    /// </summary>
    public class ConnectionField<T> : ConnectionFieldBase
    {
        private T _value;
        /// <summary>
        /// 
        /// </summary>
        public T Value
        {
            get { return _value; }
            set
            {
                if (!value.Equals(_value))
                {
                    _value = value;
                    // Notify all fields in 'to' that my value has changed.
                    foreach (var item in this.to)
                    {
                        RaiseNotifyEvent(item);
                    }
                }
            }
        }

        /// <summary>
        /// When Someone chhanged its value, I will know.
        /// </summary>
        /// <param name="value"></param>
        public ConnectionField(T value)
        {
            this._value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("value:{0}", this._value);
        }
    }
}
