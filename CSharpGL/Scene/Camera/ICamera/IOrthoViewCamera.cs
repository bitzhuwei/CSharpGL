﻿namespace CSharpGL {
    /// <summary>
    /// Use this for ortho projection * view matrix.
    /// <para>Typical usage: projection * view * model in GLSL.</para>
    /// </summary>
    public interface IOrthoViewCamera : IOrthoCamera, IViewCamera {
    }
}