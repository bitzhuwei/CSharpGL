namespace bitzhuwei.Compiler {
    public partial class BinaryFileReader {

        /// <summary>
        /// read <see cref="LRParseState"/>[] from binary file.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="regulations"></param>
        /// <returns></returns>
        public static LRParseState[] ReadLRParseStates(string filename, IReadOnlyList<Regulation> regulations) {
            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            using (var reader = new BinaryReader(fs)) {
                // init memory of state objects.
                int count = reader.ReadInt32();
                var states = new LRParseState[count];
                for (int i = 0; i < states.Length; i++) { states[i] = new(); }
                // init re-used action objects.
                int reusedCount = reader.ReadInt32();
                var reused = new LRParseAction[reusedCount];
                for (int i = 0; i < reusedCount; i++) {
                    int ikind = reader.ReadInt32();
                    int index = reader.ReadInt32();
                    var kind = (LRParseAction.Kind)ikind;
                    switch (kind) {
                    case LRParseAction.Kind.Shift: reused[i] = new(kind, states[index]); break;
                    case LRParseAction.Kind.Reduce: reused[i] = new(regulations[index]); break;
                    case LRParseAction.Kind.Goto: reused[i] = new(kind, states[index]); break;
                    case LRParseAction.Kind.Accept: reused[i] = LRParseAction.accept; break;
                    default: throw new NotImplementedException();
                    }
                }
                // fill in nodes and actions for states.
                for (int i = 0; i < count; i++) {
                    int length = reader.ReadInt32();
                    var nodes = new int[length];
                    for (int j = 0; j < length; j++) { nodes[j] = reader.ReadInt32(); }
                    var actions = new LRParseAction[length];
                    for (int j = 0; j < length; j++) {
                        int sign = reader.ReadInt32();
                        int next = reader.ReadInt32();
                        if (sign < 0) { // reused action object
                            actions[j] = reused[next];
                        }
                        else {
                            var kind = (LRParseAction.Kind)sign;
                            int index = next;
                            switch (kind) {
                            case LRParseAction.Kind.Shift: actions[j] = new(kind, states[index]); break;
                            case LRParseAction.Kind.Reduce: actions[j] = new(regulations[index]); break;
                            case LRParseAction.Kind.Goto: actions[j] = new(kind, states[index]); break;
                            case LRParseAction.Kind.Accept: actions[j] = LRParseAction.accept; break;
                            default: throw new NotImplementedException();
                            }
                        }
                    }
                    states[i].nodes = nodes;
                    states[i].actions = actions;
                }
                return states;
            }
        }

    }
}

