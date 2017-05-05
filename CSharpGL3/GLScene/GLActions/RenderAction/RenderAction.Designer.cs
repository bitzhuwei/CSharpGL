using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class RenderAction
    {
        private static readonly Type type = typeof(RenderAction);
        internal override Type SelfTypeCache { get { return type; } }

        // appliedNode -> snippet.
        private static readonly Dictionary<Type, GLSnippet> dictionary = new Dictionary<Type, GLSnippet>();

        static RenderAction()
        {
            dictionary.Add(typeof(GLColorsNode), new Render_Colors());
            dictionary.Add(typeof(GLOneIndexNode), new Render_OneIndex());
            dictionary.Add(typeof(GLPositionsNode), new Render_Positions());
            dictionary.Add(typeof(GLProgramNode), new Render_ProgramNode());
            dictionary.Add(typeof(GLStateNode), new Render_State());
            dictionary.Add(typeof(GLPositionColorNode), new Render_PositionColor());
            //dictionary.Add(typeof(GLVertexNode), new Render_Vertex());
            dictionary.Add(typeof(GLZeroIndexNode), new Render_ZeroIndex());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="glNode"></param>
        /// <returns></returns>
        protected override GLSnippet FindSnippet(GLNode glNode)
        {
            Type nodeType = glNode.SelfTypeCache;
            GLSnippet snippet = null;
            dictionary.TryGetValue(nodeType, out snippet);

            return snippet;
        }
        //protected override GLSnippet FindSnippet(GLNode glNode)
        //{
        //    Type nodeType = glNode.SelfTypeCache;
        //    GLSnippet snippet = null;
        //    if (!dictionary.TryGetValue(nodeType, out snippet))
        //    {
        //        snippet = CreateInstance(this.SelfTypeCache, glNode.SelfTypeCache);
        //        dictionary.Add(nodeType, snippet);
        //    }

        //    return snippet;
        //}

        //private static GLSnippet CreateInstance(Type actionType, Type nodeType)
        //{
        //    GLSnippet result = null;
        //    // NOTE: This forces GLSnippet's class name's pattern.
        //    string prefix = actionType.Name.Substring(0, actionType.Name.Length - "Action".Length);
        //    string postfix = nodeType.Name.Substring("GL".Length, nodeType.Name.Length - "GL".Length - "Node".Length);
        //    Assembly[] assemblies = AssemblyHelper.GetAssemblies(Application.ExecutablePath);

        //    Type type = Type.GetType(prefix + "_" + postfix);
        //    if (type != null)
        //    {
        //        result = Activator.CreateInstance(type,) as GLSnippet;
        //    }

        //    return result;
        //}
    }
}
