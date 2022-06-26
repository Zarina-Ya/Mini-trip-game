using System;
using UnityEngine;

namespace ZarinkinProject
{
   [Serializable]
   public struct SVector3
    {
        public float X, Y, Z;

        public SVector3(float x, float y , float z)
        {
            X = x; Y = y; Z = z; 
        }

        public static implicit operator SVector3(Vector3 value)
        {
            return new SVector3(value.x, value.y, value.z);
        }

        public static implicit operator Vector3(SVector3 value)
        {
            return new Vector3(value.X, value.Y, value.Z);
        }

        public override string ToString()
        {
            return $"x: {X}, y: {Y}, z: {Z}";
        }
    }

    [Serializable]
    public struct SQuater
    {
        public float X, Y, Z, W;

        public SQuater(float x, float y, float z, float w)
        {
            X = x; Y = y; Z = z; W = w;
        }

        public static implicit operator SQuater(Quaternion value)
        {
           return new SQuater(value.x, value.y, value.z, value.w);
        }

        public static implicit operator Quaternion(SQuater value)
        {
           return new Quaternion(value.X, value.Y, value.Z, value.W);
        }
    }

    [Serializable]
    public struct SObject
    {
        public string Name;
        public SVector3 Position;
        public SQuater Rotation;
        public SVector3 Scale;
    }
}
