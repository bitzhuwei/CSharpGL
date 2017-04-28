using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    static class GLSnippetHelper
    {
        public static GLSnippet CreateInstance(GLAction someAction, GLNode glSomeNode)
        {
            Type actionType = someAction.GetType();
            Type nodeType = glSomeNode.GetType();

            GLSnippet result = null;
            // NOTE: This forces GLSnippet's class name's pattern.
            string prefix = actionType.Name.Substring(0, actionType.Name.Length - "Action".Length);
            string postfix = nodeType.Name.Substring("GL".Length, nodeType.Name.Length - "GL".Length - "Node".Length);
            try
            {
                Type type = Type.GetType(prefix + "_" + postfix);
                result = Activator.CreateInstance(type) as GLSnippet;
            }
            catch (Exception)
            {
            }

            return result;
        }
    }
}
