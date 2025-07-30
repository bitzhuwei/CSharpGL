using System.Reflection;

namespace SoftGLImpl {
    public unsafe partial class SoftGL {

        public static IntPtr GetProcAddress(string procName) {
            if (SoftGL.procName2Address.TryGetValue(procName, out var address)) {
                return address;
            }
            else { return IntPtr.Zero; }
            //var context = SoftGL.GetCurrentContextObj();
            //if (context == null) { return IntPtr.Zero; }

            //if (!context.name2ProcAddress.TryGetValue(procName, out var address)) {
            //    Type type = context.GetType();
            //    var field = type.GetField(procName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            //    if (field != null) {
            //        var value = field.GetValue(context);
            //        if (value != null) {
            //            address = (IntPtr)value;
            //            context.name2ProcAddress.Add(procName, address);
            //        }
            //    }
            //}

            //return address;
        }
    }
}
