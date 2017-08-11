using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ColorCodedPicking
{
    /// <summary>
    /// 
    /// </summary>
    public class DirectTextNode : CSharpGL.SceneNodeBase
    {
        /// <summary>
        /// 
        /// </summary>
        public Color TextColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Point Position { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FontName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float FontSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DirectTextNode()
        {
            this.TextColor = Color.Gold;
            this.Position = new Point(10, 10);
            this.FontName = "Courier New";
            this.FontSize = 25.0f;
            this.Text = "This is Direct Text";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}", this.Text);
        }
    }
}
