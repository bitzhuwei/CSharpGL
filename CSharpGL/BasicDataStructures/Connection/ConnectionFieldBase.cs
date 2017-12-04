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
    public class ConnectionFieldBase
    {
        /// <summary>
        /// 
        /// </summary>
        protected List<ConnectionFieldBase> to = new List<ConnectionFieldBase>();

        /// <summary>
        /// Send a connection request to <paramref name="field"/>.
        /// <para>If <paramref name="field"/>'s value has changed, I will be notified.</para>
        /// </summary>
        /// <param name="field">The field that I want to connect to.</param>
        public void ConnectTo(ConnectionFieldBase field)
        {
            if (field == null) { throw new ArgumentNullException("field"); }

            field.to.Add(this);
        }

        ///// <summary>
        ///// There is a connection request from <paramref name="field"/>.
        ///// <para>If my value have changed, I will notify <paramref name="field"/>.</para>
        ///// </summary>
        ///// <param name="field">The field that wants to connect to me(my value's change).</param>
        //public void ConnectFrom(ConnectionFieldBase field)
        //{
        //    this.to.Add(field);
        //}

        /// <summary>
        /// Raise notify event for specified <param name="field"></param>.
        /// </summary>
        protected static void RaiseNotifyEvent(ConnectionFieldBase field)
        {
            var notified = field.Notified;
            if (notified != null)
            {
                notified(field, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Raised when one of the fields that I connected to has changed its value.
        /// </summary>
        public event EventHandler Notified;

    }
}
