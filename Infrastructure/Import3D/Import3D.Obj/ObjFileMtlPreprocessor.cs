
namespace Import3D.Obj {
    public static class ObjFileMtlPreprocessor {

        public static List<string> Preprocess(TextReader reader) {
            var noCommentLines = RemoveComments(reader);
            var lines = new List<string>();
            var lastLine = ""; var connect = false;
            foreach (var noCommentLine in noCommentLines) {
                var line = noCommentLine.Trim();
                var appendLine = false;
                if (connect) {
                    connect = line.EndsWith("\\");
                    if (connect) {
                        lastLine = lastLine + " " + line.Substring(0, line.Length - 1);
                    }
                    else {
                        lastLine = lastLine + " " + line;
                        appendLine = true;
                    }
                }
                else {
                    connect = line.EndsWith("\\");
                    if (connect) { lastLine = line.Substring(0, line.Length - 1); }
                    else { lastLine = line; appendLine = true; }
                }

                if (appendLine) {
                    lines.Add(lastLine);

                    lastLine = "";
                }
            }

            return lines;
        }

        private static List<string> RemoveComments(TextReader reader) {
            var lines = new List<string>();
            var line = reader.ReadLine();
            while (line != null) {
                var index = line.IndexOf('#');
                if (index >= 0) {
                    line = line.Substring(0, index);
                }
                lines.Add(line);

                line = reader.ReadLine();
            }

            return lines;
        }
    }
}
