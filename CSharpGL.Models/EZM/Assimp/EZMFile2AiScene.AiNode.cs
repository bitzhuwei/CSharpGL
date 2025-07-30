using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    public static partial class EZMFile2AiScene {

        private static void Match(AiNode aiNode, EZMBone ezmBone) {
            foreach (var childBone in ezmBone.children) {
                var childNode = Parse(childBone);
                aiNode.Children.Add(childNode);
                Match(childNode, childBone);
            }
        }

        private static AiNode Parse(EZMBone ezmBone) {
            var aiNode = new AiNode();
            aiNode.Name = ezmBone.Name;
            aiNode.Transform = ezmBone.state.matrix;

            return aiNode;
        }
    }
}
