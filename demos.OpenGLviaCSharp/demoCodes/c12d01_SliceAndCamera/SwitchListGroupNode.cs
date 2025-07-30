using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace c12d01_SliceAndCamera {
    class SwitchListGroupNode : SceneNodeBase, IRenderable {
        /// <summary>
        /// contains some nodes in its children.
        /// </summary>
        /// <param name="nodes"></param>
        public SwitchListGroupNode(params SceneNodeBase[] nodes) {
            foreach (var item in nodes) {
                this.Children.Add(item);
            }

            this.SwitchList = new List<IGLSwitch>();
        }

        public IList<IGLSwitch> SwitchList { get; private set; }

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;
        public ThreeFlags EnableRendering {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg) {
            foreach (var item in this.SwitchList) {
                item.On();
            }
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
            foreach (var item in this.SwitchList) {
                item.Off();
            }
        }

        #endregion
    }
}