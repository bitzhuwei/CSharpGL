using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Demos._16ArcBallManipulater
{
    class ModelManipulaterScript : ScriptComponent
    {
        private Manipulater modelManipulater;
        public ModelManipulaterScript(Manipulater modelManipulater)
        {
            this.modelManipulater = modelManipulater;
        }

        protected override void DoUpdate(double elapsedTime)
        {
            throw new NotImplementedException();
        }
    }
}
