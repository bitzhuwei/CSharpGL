using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// render a bounding box with legacy opengl.
    /// </summary>
    public class LegacyBoundingBoxNode : SceneNodeBase, IRenderable, ILegacyPickable
    {
        private const float xLength = 0.5f;
        private const float yLength = 0.5f;
        private const float zLength = 0.5f;
        /// <summary>
        /// eight vertexes.
        /// </summary>
        private static readonly vec3[] standardPosiions = new vec3[]
        {
            new vec3(-xLength, -yLength, -zLength),// 0
            new vec3(-xLength, -yLength, +zLength),// 1
            new vec3(-xLength, +yLength, -zLength),// 2
            new vec3(-xLength, +yLength, +zLength),// 3
            new vec3(+xLength, -yLength, -zLength),// 4
            new vec3(+xLength, -yLength, +zLength),// 5
            new vec3(+xLength, +yLength, -zLength),// 6
            new vec3(+xLength, +yLength, +zLength),// 7
        };


        /// <summary>
        /// render in GL_QUADS.
        /// </summary>
        private static readonly byte[] indexes = new byte[24]
        {
            1, 3, 7, 5, 0, 4, 6, 2,
            2, 6, 7, 3, 0, 1, 5, 4,
            4, 5, 7, 6, 0, 2, 3, 1,
        };

        private vec3 lineColor = new vec3(1, 1, 1);
        /// <summary>
        /// 
        /// </summary>
        public Color LineColor { get { return lineColor.ToColor(); } set { this.lineColor = value.ToVec3(); } }

        /// <summary>
        /// 
        /// </summary>
        public vec3[] Positions { get; private set; }

        /// <summary>
        /// contains some nodes in its children.
        /// </summary>
        /// <param name="modelSize"></param>
        public LegacyBoundingBoxNode(vec3 modelSize)
        {
            this.ModelSize = ModelSize;

            var positions = new vec3[8];
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = standardPosiions[i] * modelSize;
            }

            this.Positions = positions;
        }

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        /// <summary>
        /// 
        /// </summary>
        public ThreeFlags EnableRendering
        {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        private GLSwitch polygonModeState = new PolygonModeSwitch(PolygonMode.Line);
        private GLSwitch polygonOffsetState = new PolygonOffsetFillSwitch();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            this.PushProjectionViewMatrix(arg);
            this.PushModelMatrix();

            polygonModeState.On();
            polygonOffsetState.On();

            DoRender(this.Positions, indexes, this.lineColor);

            polygonOffsetState.Off();
            polygonModeState.Off();

            this.PopModelMatrix();
            this.PopProjectionViewMatrix();
        }


        private void DoRender(vec3[] positions, byte[] indexes, vec3 lineColor)
        {
            GL.Instance.Begin((uint)DrawMode.Quads);
            GL.Instance.Color3f(lineColor.x, lineColor.y, lineColor.z);
            for (int i = 0; i < indexes.Length; i++)
            {
                vec3 position = positions[indexes[i]];
                GL.Instance.Vertex3f(position.x, position.y, position.z);
            }
            GL.Instance.End();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion

        #region ILegacyPickable 成员

        private ThreeFlags enableLegacyPicking = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        /// <summary>
        /// 
        /// </summary>
        public ThreeFlags EnableLegacyPicking
        {
            get { return this.enableLegacyPicking; }
            set { this.enableLegacyPicking = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public void RenderBeforeChildrenForLegacyPicking(LegacyPickingEventArgs arg)
        {
            this.PushProjectionViewMatrix(arg);
            this.PushModelMatrix();

            DoRender(this.Positions, indexes, this.lineColor);

            this.PopModelMatrix();
            this.PopProjectionViewMatrix();
        }

        ///// <summary>
        ///// Render this model after rendering its children in legacy OpenGL.
        ///// </summary>
        ///// <param name="arg"></param>
        //public void RenderAfterChildrenForLegacyPicking(LegacyPickEventArgs arg) { }

        #endregion
    }
}
