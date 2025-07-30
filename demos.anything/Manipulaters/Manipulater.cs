﻿namespace CSharpGL {
    /// <summary>
    /// Manipulate camera or model.
    /// </summary>
    public abstract class Manipulater {
        /// <summary>
        /// start to manipulate specified <paramref name="camera"/> or model.
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="canvas"></param>
        public abstract void Bind(ICamera camera, IGLCanvas canvas);

        /// <summary>
        /// stop to manipulate camera or model.
        /// </summary>
        public abstract void Unbind();
    }
}