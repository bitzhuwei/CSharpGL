using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace CSharpGL
{
    public partial class UIText
    {

        private string content = string.Empty;

        public string Text { get { return content; } set { this.model.SetText(value, this.fontResource); this.content = value; } }

    }
}