//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;

//namespace CSharpGL
//{
//    public partial class PickableNode
//    {
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <typeparam name="T"></typeparam>
//        ///// <param name="varNameInShader"></param>
//        ///// <param name="value"></param>
//        ///// <returns></returns>
//        //public bool GetUniformValue<T>(string varNameInShader, out T value) where T : struct, IEquatable<T>
//        //{
//        //    return this.RenderProgram.GetUniformValue(varNameInShader, out value);
//        //}
//        ///// <summary>
//        ///// Sets up a new value to specified uniform variable and mark it as updated so that the new value will be sent to shader before rendering.
//        ///// </summary>
//        ///// <param name="varNameInShader"></param>
//        ///// <param name="texture"></param>
//        ///// <returns></returns>
//        //public bool SetUniform(string varNameInShader, Texture texture)
//        //{
//        //    return this.SetUniform(varNameInShader, texture.ToSamplerValue());
//        //}

//        ///// <summary>
//        ///// Sets up a new value to specified uniform variable and mark it as updated so that the new value will be sent to shader before rendering.
//        ///// </summary>
//        ///// <typeparam name="T"></typeparam>
//        ///// <param name="varNameInShader"></param>
//        ///// <param name="value"></param>
//        ///// <returns></returns>
//        //public bool SetUniform<T>(string varNameInShader, T value) where T : struct,IEquatable<T>
//        //{
//        //    return this.RenderProgram.SetUniform(varNameInShader, value);
//        //}
//    }
//}