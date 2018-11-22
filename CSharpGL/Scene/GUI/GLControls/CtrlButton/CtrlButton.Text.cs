using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    // http://www.iskdy.com/?s=vod-play-id-49676-sid-0-pid-3.html

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
