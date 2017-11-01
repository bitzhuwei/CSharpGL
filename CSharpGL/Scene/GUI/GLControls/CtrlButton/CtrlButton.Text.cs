using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class CtrlButton
    {
        private CtrlLabel label;

        /// <summary>
        /// 
        /// </summary>
        public string Text
        {
            get { return this.label.Text; }
            set { this.label.Text = value; }
        }
    }
}
