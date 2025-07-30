using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    public static partial class EZMFile2AiScene {
        private static AiAnimation Parse(EZMAnimation ezmAnimation) {
            var aiAnimation = new AiAnimation();
            aiAnimation.Name = ezmAnimation.Name;
            /*
             double ticksPerSecond = aiScene.Animations[0].TicksPerSecond;
            if (ticksPerSecond == 0) { ticksPerSecond = 25.0; }
            double timeInTicks = TimeInSeconds * ticksPerSecond;
            float animationTime = (float)(timeInTicks % aiScene.Animations[0].DurationInTicks);
*/
            /*
             DateTime now = DateTime.Now;
                var deltaTime = now.Subtract(this.lastTime).TotalSeconds;
                float frameDuration = animation.duration / animation.FrameCount;
                if (deltaTime + passedTime > frameDuration)
                {
                    this.currentFrame = (this.currentFrame + 1) % animation.FrameCount;
                    passedTime = deltaTime - frameDuration;
                }
                this.lastTime = now;*/
            float durationInSeconds = ezmAnimation.duration;
            aiAnimation.TicksPerSecond = 1;
            aiAnimation.DurationInTicks = ezmAnimation.duration;
            // nothing to do with ezmAnimation.dtime...
            int trackCount = ezmAnimation.TrackCount;
            var channels = new AiNodeAnimationChannel[trackCount];
            for (int i = 0; i < trackCount; i++) {
                var channel = new AiNodeAnimationChannel();
                EZMAnimTrack track = ezmAnimation.AnimTracks[i];
                EZMBoneState[] states = track.States;
                int stateCount = states.Length;
                var positions = new VectorKey[stateCount];
                var quaternions = new QuaternionKey[stateCount];
                var scalings = new VectorKey[stateCount];
                for (int t = 0; t < stateCount; t++) {
                    EZMBoneState state = states[t];
                    positions[i] = new VectorKey(0, state.position);
                    quaternions[i] = new QuaternionKey(0, state.orientation);
                    scalings[i] = new VectorKey(0, state.scale);
                }
                channel.PositionKeys = positions;
                channel.QuaternionKeys = quaternions;
                channel.ScalingKeys = scalings;
                channels[i] = channel;
            }
            aiAnimation.NodeAnimationChannels = channels;

            return aiAnimation;
        }

    }
}
