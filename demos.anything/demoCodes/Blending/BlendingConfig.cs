using CSharpGL;

namespace Blending {
    class BlendingConfig {
        public Color color;
        public vec3 position;
        public float alpha;

        public BlendingConfig(Color color, vec3 position, float alpha) {
            this.color = color;
            this.position = position;
            this.alpha = alpha;
        }

    }

}
