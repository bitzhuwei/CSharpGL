using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// 
    /// </summary>
    public class LegacyPicking {

        /// <summary>
        /// 
        /// </summary>
        public Scene Scene { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scene"></param>
        public LegacyPicking(Scene scene) { this.Scene = scene; }

        /// <summary>
        /// Pick <see cref="SceneNodeBase"/>s at specified positon.
        /// </summary>
        /// <param name="x">Left Down is (0, 0)</param>
        /// <param name="y">Left Down is (0, 0)</param>
        /// <param name="deltaX"></param>
        /// <param name="deltaY"></param>
        /// <param name="selectBufferLength"></param>
        /// <returns></returns>
        public unsafe List<HitTarget> Pick(int x, int y, int deltaX = 1, int deltaY = 1, int selectBufferLength = 512) {
            var gl = GL.current; if (gl == null) { return new List<HitTarget>(); }

            //	Create a select buffer.
            var selectBuffer = stackalloc GLuint[selectBufferLength];
            gl.glSelectBuffer(selectBufferLength, selectBuffer);

            //	Enter select mode.
            gl.glRenderMode(GL.GL_SELECT);
            //	Initialise the names, and add the first name.
            gl.glInitNames();
            gl.glPushName(0);

            var viewport = stackalloc int[4];
            gl.glGetIntegerv((GLenum)GetTarget.Viewport, viewport);
            mat4 pickMatrix = glm.pickMatrix(new ivec2(x, y), new ivec2(deltaX, deltaY), new ivec4(viewport[0], viewport[1], viewport[2], viewport[3]));
            var arg = new LegacyPickingEventArgs(pickMatrix, this.Scene, x, y);
            uint currentName = 1;
            this.RenderForPicking(this.Scene.RootNode, arg, ref currentName);
            //	Flush commands.
            gl.glFlush();

            List<HitTarget> pickedRenderer;
            //	End selection.
            int hits = gl.glRenderMode(GL.GL_RENDER);
            if (hits < 0)// select buffer is not long enough.
            {
                pickedRenderer = this.Pick(x, y, deltaX, deltaY, selectBufferLength * 2);
            }
            else {
                //  Create  result set.
                pickedRenderer = new List<HitTarget>();
                int posinarray = 0;
                //  Go through each name.
                for (int hit = 0; hit < hits; hit++) {
                    uint nameCount = selectBuffer[posinarray++];
                    uint zNear = selectBuffer[posinarray++];
                    uint zFar = selectBuffer[posinarray++];

                    if (nameCount == 0) { continue; }

                    //	Add each hit element to the result set to the array.
                    for (int i = 0; i < nameCount; i++) {
                        uint hitName = selectBuffer[posinarray++];
                        pickedRenderer.Add(new HitTarget(arg.hitMap[hitName], zNear, zFar));
                    }
                }
            }

            //  Return the result set.
            return pickedRenderer;
        }

        private unsafe void RenderForPicking(SceneNodeBase? sceneElement, LegacyPickingEventArgs arg, ref uint currentName) {
            if (sceneElement != null) {
                var pickable = sceneElement as ILegacyPickable;
                ThreeFlags flags = (pickable != null) ? (pickable.EnableLegacyPicking) : ThreeFlags.None;
                bool before = (pickable != null) && ((flags & ThreeFlags.BeforeChildren) == ThreeFlags.BeforeChildren);
                bool children = (pickable == null) || ((flags & ThreeFlags.Children) == ThreeFlags.Children);

                if (before) {
                    var gl = GL.current; if (gl != null) {
                        //  Load and map the name.
                        gl.glLoadName(currentName);
                    }
                    arg.hitMap[currentName] = sceneElement;

                    if (pickable != null) pickable.RenderBeforeChildrenForLegacyPicking(arg);

                    //  Increment the name.
                    currentName++;
                }

                if (children) {
                    foreach (var item in sceneElement.Children) {
                        this.RenderForPicking(item, arg, ref currentName);
                    }
                }
            }
        }
    }
}