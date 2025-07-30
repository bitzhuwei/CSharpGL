namespace bitzhuwei.Compiler {
    public partial class BinaryFileReader {

        /// <summary>
        /// read stArray from binary file.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string[] ReadstArray(string filename) {
            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            using (var reader = new BinaryReader(fs)) {
                int count = reader.ReadInt32();
                var stArray = new string[count];
                for (int i = 0; i < count; i++) {
                    stArray[i] = reader.ReadString();
                }
                return stArray;
            }
        }

    }
}

