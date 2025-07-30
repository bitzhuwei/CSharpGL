using bitzhuwei.Compiler;

namespace SoftGLImpl {
    /// <summary>
    /// #version 330 core
    /// </summary>
    public class PreVersion {
        public readonly string number;
        public readonly string profile;

        public PreVersion(string number, string profile) {
            this.number = number;
            this.profile = profile;
        }

        public override string ToString() {
            return $"#version {this.number} {this.profile}";
        }
    }
}