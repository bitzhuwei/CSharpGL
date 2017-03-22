using System;
using System.ComponentModel;

namespace CSharpGL
{
	/// <summary>
	/// Renderer  that supports UI layout.
	/// 支持2D UI布局的渲染器
	/// </summary>
	public partial class UIRenderer : IRenderable, ILayout<UIRenderer>, ILayoutEvent, IDisposable
	{
		private GLStateList stateList = new GLStateList();

		private const string strUIRenderer = "UIRenderer";

		/// <summary>
		///
		/// </summary>
		[Category(strUIRenderer)]
		[Description("OpenGL switches.")]
		public GLStateList StateList
		{
			get { return stateList; }
		}

		/// <summary>
		///
		/// </summary>
		[Category(strUIRenderer)]
		[Description("Renderer that actrually renders something.")]
		public RendererBase Renderer { get; protected set; }

		/// <summary>
		/// 
		/// </summary>
		[Category(strUIRenderer)]
		[Description("Push all rendered stuff to farest position.")]
		public bool ClearDepthBuffer { get; set; }

		/// <summary>
		/// Render this or not.
		/// </summary>
		[Category(strUIRenderer)]
		[Description("Render this or not.")]
		public bool Enabled { get; set; }

		/// <summary>
		///
		/// </summary>
		/// <param name="anchor"></param>
		/// <param name="margin"></param>
		/// <param name="size"></param>
		/// <param name="zNear"></param>
		/// <param name="zFar"></param>
		public UIRenderer(
			System.Windows.Forms.AnchorStyles anchor, System.Windows.Forms.Padding margin,
			System.Drawing.Size size, int zNear, int zFar)
		{
			this.Children = new ChildList<UIRenderer>(this);// new ILayoutList(this);

			this.Anchor = anchor; this.Margin = margin;
			this.Size = size; this.zNear = zNear; this.zFar = zFar;

			this.ClearDepthBuffer = true;
			this.Enabled = true;
		}


	}
}