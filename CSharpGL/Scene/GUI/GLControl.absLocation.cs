using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public abstract partial class GLControl
    {

        private static void UpdateAbsLeft(GLControl parent, GLControl control)
        {
            control.absLeft = parent.absLeft + control.left;

            foreach (var item in control.Children)
            {
                UpdateAbsLeft(control, item);
            }
        }
        
        private static void UpdateAbsBottom(GLControl parent, GLControl control)
        {
            control.absBottom = parent.absBottom + control.bottom;

            foreach (var item in control.Children)
            {
                UpdateAbsBottom(control, item);
            }
        }

        /// <summary>
        /// Update absolution location for <paramref name="control"/> and its children.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="parent"><paramref name="control"/>'s parent.</param>
        internal static void UpdateAbsLocation(GLControl control, GLControl parent)
        {
            {
                control.absLeft = parent.absLeft + control.left;
                control.absBottom = parent.absBottom + control.bottom;
            }

            foreach (var child in control.Children)
            {
                UpdateAbsLocation(child, control);
            }
        }
    }
}
