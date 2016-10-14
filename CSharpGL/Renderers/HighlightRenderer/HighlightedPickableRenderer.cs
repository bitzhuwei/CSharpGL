using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// 高亮显示拾取的图元。
    /// </summary>
    public class HighlightedPickableRenderer : RendererBase, IColorCodedPicking
    {
        /// <summary>
        /// 高亮显示拾取的图元。
        /// </summary>
        /// <param name="highlighter"></param>
        /// <param name="pickableRenderer"></param>
        public HighlightedPickableRenderer(HighlightRenderer highlighter,
            PickableRenderer pickableRenderer)
        {
            this.Highlighter = highlighter;
            this.PickableRenderer = pickableRenderer;
        }

        /// <summary>
        ///
        /// </summary>
        protected override void DoInitialize()
        {
            this.Highlighter.Initialize();
            this.PickableRenderer.Initialize();
            this.Highlighter.CopyModelSpaceStateFrom(this.PickableRenderer);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            this.Highlighter.Render(arg);
            this.PickableRenderer.Render(arg);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void DisposeUnmanagedResources()
        {
            this.Highlighter.Dispose();
            this.PickableRenderer.Dispose();
        }

        /// <summary>
        /// 高亮。
        /// </summary>
        public HighlightRenderer Highlighter { get; private set; }

        /// <summary>
        /// 拾取。
        /// </summary>
        public PickableRenderer PickableRenderer { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public override vec3 WorldPosition
        {
            get
            {
                return PickableRenderer.WorldPosition;
            }
            set
            {
                Highlighter.WorldPosition = value;
                PickableRenderer.WorldPosition = value;
                base.WorldPosition = value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override vec3 Size
        {
            get
            {
                return PickableRenderer.Size;
            }
            set
            {
                Highlighter.Size = value;
                PickableRenderer.Size = value;
                base.Size = value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override float RotationAngleDegree
        {
            get
            {
                return PickableRenderer.RotationAngleDegree;
            }
            set
            {
                Highlighter.RotationAngleDegree = value;
                PickableRenderer.RotationAngleDegree = value;
                base.RotationAngleDegree = value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override vec3 RotationAxis
        {
            get
            {
                return PickableRenderer.RotationAxis;
            }
            set
            {
                Highlighter.RotationAxis = value;
                PickableRenderer.RotationAxis = value;
                base.RotationAxis = value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override vec3 Scale
        {
            get
            {
                return PickableRenderer.Scale;
            }
            set
            {
                Highlighter.Scale = value;
                PickableRenderer.Scale = value;
                base.Scale = value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        [Browsable(false)]
        public uint PickingBaseId
        {
            get
            {
                return this.PickableRenderer.PickingBaseId;
            }
            set
            {
                this.PickableRenderer.PickingBaseId = value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public uint GetVertexCount()
        {
            return this.PickableRenderer.GetVertexCount();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="x">mouse position(Left Down is (0, 0)).</param>
        /// <param name="y">mouse position(Left Down is (0, 0)).</param>
        /// <returns></returns>
        public PickedGeometry GetPickedGeometry(RenderEventArgs arg, uint stageVertexId, int x, int y)
        {
            PickedGeometry result = this.PickableRenderer.GetPickedGeometry(arg, stageVertexId, x, y);
            if (result != null)
            {
                result.FromRenderer = this;
            }

            return result;
        }
    }
}