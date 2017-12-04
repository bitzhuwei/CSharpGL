using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// When Someone has changed its value, I will be notified.
    /// <para>If my value have changed, I will notify others.</para>
    /// </summary>
    public class ConnectionField<T> : ConnectionFieldBase
    {
        private T _value;
        /// <summary>
        /// The value.
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
        /// <param name="value">Initial value. This will not notify anyone.</param>
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
