namespace bitzhuwei.Compiler {
    public partial class BinaryFileReader {

        /// <summary>
        /// read <see cref="Regulation"/>[] from binary file.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static Regulation[] ReadRegulations(string filename) {
            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            using (var reader = new BinaryReader(fs)) {
                int count = reader.ReadInt32();
                var regulations = new Regulation[count];
                for (int index = 0; index < count; index++) {
                    int left = reader.ReadInt32();
                    int rightLength = reader.ReadInt32();
                    var right = new int[rightLength];
                    for (int t = 0; t < rightLength; t++) {
                        right[t] = reader.ReadInt32();
                    }
                    regulations[index] = new Regulation(index, left, right);
                }
                return regulations;
            }
        }

    }
}

