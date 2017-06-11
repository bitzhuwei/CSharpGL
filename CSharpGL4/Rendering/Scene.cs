using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class Scene
    {
        /// <summary>
        /// 
        /// </summary>
        public ICamera Camera { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SceneElement RootElement { get; set; }

        public void Render()
        {
            throw new NotImplementedException();
        }

        public SceneElement Pick()
        {
            throw new NotImplementedException();
        }

        //public void Write(Stream stream)
        //{

        //}
    }
}