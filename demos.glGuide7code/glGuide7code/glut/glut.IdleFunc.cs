
using CSharpGL;
using System.Xml.Linq;

namespace demos.glGuide7code {
    internal static unsafe partial class glut {

        private static EventHandler? idle;

        public static void IdleFunc(EventHandler? idleEvent) {
            if (idleEvent == null) {
                if (idle != null) {
                    Application.Idle -= idle;
                    idle = null;
                }
            }
            else {
                if (idle != idleEvent) {
                    if (idle != null) { Application.Idle -= idle; }

                    Application.Idle += idleEvent;
                    idle = idleEvent;
                }
            }
        }
    }
}