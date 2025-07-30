﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CSharpGL {
    public partial class GLControl {
        /// <summary>
        /// 获取或设置控件绑定到的容器的边缘并确定控件如何随其父级一起调整大小。
        /// </summary>
        public GUIAnchorStyles Anchor { get; set; }

        /// <summary>
        /// 相对于Parent左下角的位置(Left Down location)
        /// </summary>
        public GUIPoint Location {
            get { return new GUIPoint(left, bottom); }
            set { this.X = value.X; this.Y = value.Y; }
        }

        /// <summary>
        /// Stores width when <see cref="Anchor"/>.Left &amp; <see cref="Anchor"/>.Right is <see cref="Anchor"/>.None.
        /// <para> and height when <see cref="Anchor"/>.Top &amp; <see cref="Anchor"/>.Bottom is <see cref="Anchor"/>.None.</para>
        /// </summary>
        public GUISize Size {
            get { return new GUISize(width, height); }
            set { this.Width = value.Width; this.Height = value.Height; }
        }

        /// <summary>
        /// Children Nodes. Inherits this node's IWorldSpace properties.
        /// </summary>
        public GLControlChildren Children { get; private set; }

        /// <summary>
        /// 为便于调试而设置的ID值，没有应用意义。(for debugging purpose only.)
        /// <para>for debugging purpose only.</para>
        /// </summary>
        public int Id { get; private set; }

        private bool acceptPicking = true;

        /// <summary>
        /// Accept mouse down event.
        /// </summary>
        public bool AcceptPicking {
            get { return acceptPicking; }
            set { acceptPicking = value; }
        }
    }
}
