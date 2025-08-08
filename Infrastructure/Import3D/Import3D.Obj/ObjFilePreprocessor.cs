
namespace Import3D.Obj {
    public static class ObjFilePreprocessor {

        public static ObjFilePreprocessed Preprocess(TextReader reader) {
            var noCommentLines = RemoveComments(reader);
            var lines = new List<string>();
            int vCount = 0, vtCount = 0, vnCount = 0, fCount = 0;
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
                    if (false) { }
                    else if (lastLine.StartsWith("vt")) {
                        vtCount++;
                    }
                    else if (lastLine.StartsWith("vn")) {
                        vnCount++;
                    }
                    else if (lastLine.StartsWith("v")) {
                        vCount++;
                    }
                    else if (lastLine.StartsWith("f")) {
                        fCount++;
                    }

                    lastLine = "";
                }
            }

            return new ObjFilePreprocessed(lines, vCount, vtCount, vnCount, fCount);
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
