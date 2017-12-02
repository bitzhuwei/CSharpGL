using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace NormalMapping
{

    public class BaseLight__
    {
        public vec3 Color;
        public float AmbientIntensity;
        public float DiffuseIntensity;

        public BaseLight__()
        {
            Color = new vec3(0.0f, 0.0f, 0.0f);
            AmbientIntensity = 0.0f;
            DiffuseIntensity = 0.0f;
        }
    }

    public class DirectionalLight__ : BaseLight__
    {
        public vec3 Direction;

        public DirectionalLight__()
        {
            Direction = new vec3(0.0f, 0.0f, 0.0f);
        }
    }
    public class Attenuation__
    {
        public float Constant;
        public float Linear;
        public float Exp;
    }

    public class PointLight__ : BaseLight__
    {
        public vec3 Position;
        public Attenuation__ Attenuation;

        public PointLight__()
        {
            Position = new vec3(0.0f, 0.0f, 0.0f);
            Attenuation.Constant = 1.0f;
            Attenuation.Linear = 0.0f;
            Attenuation.Exp = 0.0f;
        }
    }

    public class SpotLight__ : PointLight__
    {
        public vec3 Direction;
        public float Cutoff;

        public SpotLight__()
        {
            Direction = new vec3(0.0f, 0.0f, 0.0f);
            Cutoff = 0.0f;
        }
    }
}
