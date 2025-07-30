﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CSharpGL {
    public abstract partial class GLControl {
        /// <summary>
        /// 
        /// </summary>
        public event GLEventHandler<GLKeyEventArgs>? KeyDown;
        /// <summary>
        /// 
        /// </summary>
        public event GLEventHandler<GLKeyEventArgs>? KeyUp;
        /// <summary>
        /// 
        /// </summary>
        public event GLEventHandler<GLMouseEventArgs>? MouseDown;
        /// <summary>
        /// 
        /// </summary>
        public event GLEventHandler<GLMouseEventArgs>? MouseUp;
        /// <summary>
        /// 
        /// </summary>
        public event GLEventHandler<GLMouseEventArgs>? MouseMove;

        /// <summary>
        /// 
        /// </summary>
        public int TabIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Focused { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="args"></param>
        public virtual void InvokeEvent(EventType eventType, GLEventArgs args) {
            switch (eventType) {
            case EventType.KeyDown:
            if (this.Focused) {
                var keyDown = this.KeyDown;
                if (keyDown != null) {
                    var e = args as GLKeyEventArgs;
                    Debug.Assert(e != null);
                    keyDown(this, e);
                }
            }
            break;
            case EventType.KeyUp:
            if (this.Focused) {
                var keyUp = this.KeyUp;
                if (keyUp != null) {
                    var e = args as GLKeyEventArgs;
                    Debug.Assert(e != null);
                    keyUp(this, e);
                }
            }
            break;
            case EventType.MouseDown: {
                var mouseDown = this.MouseDown;
                if (mouseDown != null) {
                    var e = args as GLMouseEventArgs;
                    Debug.Assert(e != null);
                    mouseDown(this, e);
                }
            }
            break;
            case EventType.MouseUp: {
                var mouseUp = this.MouseUp;
                if (mouseUp != null) {
                    var e = args as GLMouseEventArgs;
                    Debug.Assert(e != null);
                    mouseUp(this, e);
                }
            }
            break;
            case EventType.MouseMove: {
                var mouseMove = this.MouseMove;
                if (mouseMove != null) {
                    var e = args as GLMouseEventArgs;
                    Debug.Assert(e != null);
                    mouseMove(this, e);
                }
            }
            break;
            default:
            throw new NotDealWithNewEnumItemException(typeof(EventType));
            }
        }

        /// <summary>
        /// Indicates whether the specified point(x, y) is inside the conrol or not?
        /// </summary>
        /// <param name="x">absolute location of x(0 -- x -- width).</param>
        /// <param name="y">absolute location of y(0 means bottom, height means top).</param>
        /// <returns></returns>
        public bool ContainsPoint(int x, int y) {
            if (x < this.absLeft || this.absLeft + this.Width <= x) { return false; }
            if (y < this.absBottom || this.absBottom + this.Height <= y) { return false; }

            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        public enum EventType {
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
