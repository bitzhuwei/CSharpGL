using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public abstract partial class GLControl
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="args"></param>
        public virtual void InvokeEvent(EventType eventType, GUIEventArgs args)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public enum EventType
        {
            /// <summary>
            /// 
            /// </summary>
            KeyDown,

            /// <summary>
            /// 
            /// </summary>
            KeyUp,

            /// <summary>
            /// 
            /// </summary>
            MouseDown,

            /// <summary>
            /// 
            /// </summary>
            MouseUp,

            /// <summary>
            /// 
            /// </summary>
            MouseMove,
            // ...
        }
    }

}
