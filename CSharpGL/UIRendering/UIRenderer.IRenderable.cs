using System;
using System.ComponentModel;

namespace CSharpGL
{
	public partial class UIRenderer
	{
		private readonly object synObj = new object();

		private ViewportState viewportState;
		private ScissorTestState scissorTestState;

		//private bool initializing = false;

		///// <summary>
		///// in initializing process.
		///// </summary>
		//public bool Initializing
		//{
		//    get { return initializing; }
		//}

		private bool isInitialized = false;

		/// <summary>
		/// Already initialized.
		/// </summary>
		[Category(strUIRenderer)]
		[Description("Is this renderer initialized or not?")]
		public bool IsInitialized { get { return isInitialized; } }

		/// <summary>
		/// Initialize all stuff related to OpenGL.
		/// </summary>
		public void Initialize()
		{
			if (!isInitialized)
			{
				lock (synObj)
				{
					if (!isInitialized)
					{
						//initializing = true;
						DoInitialize();
						//initializing = false;
						isInitialized = true;
					}
				}
			}
		}

		/// <summary>
		/// This method should only be invoked once.
		/// </summary>
		protected virtual void DoInitialize()
		{
			this.viewportState = new ViewportState();
			this.scissorTestState = new ScissorTestState();

			RendererBase renderer = this.Renderer;
			if (renderer != null)
			{
				renderer.Initialize();
			}
		}

		/// <summary>
		/// Render something.
		/// </summary>
		/// <param name="arg"></param>
		public void Render(RenderEventArgs arg)
		{
			if (this.Enabled)
			{
				if (!isInitialized) { Initialize(); }

				DoRender(arg);
			}
		}

		

		/// <summary>
		/// Render something.
		/// </summary>
		/// <param name="arg"></param>
		protected virtual void DoRender(RenderEventArgs arg)
		{
			if (this.locationUpdated)
			{
				this.viewportState.X = this.Location.X;
				this.viewportState.Y = this.Location.Y;
				this.scissorTestState.X = this.Location.X;
				this.scissorTestState.Y = this.Location.Y;
				this.locationUpdated = false;
			}

			if (this.sizeUpdated)
			{
				this.viewportState.Width = this.Size.Width;
				this.viewportState.Height = this.Size.Height;
				this.scissorTestState.Width = this.Size.Width;
				this.scissorTestState.Height = this.Size.Height;
				this.sizeUpdated = false;
			}

			this.viewportState.On();
			this.scissorTestState.On();
			int count = this.stateList.Count;
			for (int i = 0; i < count; i++) { this.stateList[i].On(); }

			if (this.ClearDepthBuffer)
			{
				// 把所有在此之前渲染的内容都推到最远。
				// Push all rendered stuff to farest position.
				OpenGL.Clear(OpenGL.GL_DEPTH_BUFFER_BIT);
			}

			RendererBase renderer = this.Renderer;
			if (renderer != null)
			{
				renderer.Render(arg);
			}

			for (int i = count - 1; i >= 0; i--) { this.stateList[i].Off(); }
			this.scissorTestState.Off();
			this.viewportState.Off();
		}

	}
}