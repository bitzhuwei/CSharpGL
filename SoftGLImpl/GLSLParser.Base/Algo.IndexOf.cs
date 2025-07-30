namespace bitzhuwei.Compiler {
    partial class Algo {
        internal static int IndexOf<T>(IReadOnlyList<T> list, T target) {
            if (target == null) {
                for (int index = 0; index < list.Count; index++) {
                    if (list[index] == null) { return index; }
                }
            }
            else {
                for (int index = 0; index < list.Count; index++) {
                    if (target.Equals(list[index])) { return index; }
                }
            }
            return -1;
        }
    }
}

