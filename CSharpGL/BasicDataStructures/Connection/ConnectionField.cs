using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// When Someone chhanged its value, I will know.
    /// </summary>
    public class ConnectionField
    {
        private List<ConnectionField> to = new List<ConnectionField>();

        /// <summary>
        /// Send a connection request to <paramref name="field"/>.
        /// <para>If <paramref name="field"/>'s value has changed, I will know.</para>
        /// </summary>
        /// <param name="field">The field that I want to connect to.</param>
        public void ConnectTo(ConnectionField field)
        {
            if (field == null) { throw new ArgumentNullException("field"); }

            field.to.Add(this);
        }

        ///// <summary>
        ///// There is a connection request from <paramref name="field"/>.
        ///// <para>If my value has changed, <paramref name="field"/> will know.</para>
        ///// </summary>
        ///// <param name="field">The field that wants to connect to me(my value's change).</param>
        //public void ConnectFrom(ConnectionField field)
        //{
        //    this.to.Add(field);
        //}

        private object _value;
        /// <summary>
        /// 
        /// </summary>
        public object Value
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
                        item.RaiseNotifyEvent();
                    }
                }
            }
        }

        private void RaiseNotifyEvent()
        {
            var notified = this.Notified;
            if (notified != null)
            {
                notified(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Raised when one of the 'from' fields' value has changed.
        /// </summary>
        public event EventHandler Notified;
    }
}
