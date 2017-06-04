using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public partial class GameObject
    {
        private readonly List<ScriptComponent> components = new List<ScriptComponent>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        public void AddScript(ScriptComponent script)
        {
            script.gameObject = this;
            this.components.Add(script);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        public void RemoveScript(ScriptComponent script)
        {
            if (this.components.Contains(script))
            {
                this.components.Remove(script);
                script.gameObject = null;
            }
        }
    }
}
