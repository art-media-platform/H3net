using System;
using System.Runtime.CompilerServices;

namespace H3Lib
{
    /// <summary>
    /// 3D floating point structure
    /// </summary>
    public readonly struct Vec3D:IEquatable<Vec3D>
    {
        /// <summary>
        /// X Coordinate
        /// </summary>
        public readonly double X;
        /// <summary>
        /// Y Coordinate
        /// </summary>
        public readonly double Y;
        /// <summary>
        /// Z Coordinate
        /// </summary>
        public readonly double Z;

        /// <summary>
        /// Constructor
        /// </summary>
        public Vec3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Debug info in string format
        /// </summary>
        public override string ToString()
        {
            return $"Vec3D (X,Y,Z) {X:F6}, {Y:F6}, {Z:F6}";
        }

        /// <summary>
        /// Equality test
        /// </summary>
        public bool Equals(Vec3D other)
        {
            return X.Equals(other.X) &&
                   Y.Equals(other.Y) &&
                   Z.Equals(other.Z);
        }

        /// <summary>
        /// Equality test
        /// </summary>
        public override bool Equals(object obj)
        {
            return obj is Vec3D other &&
                   Equals(other);
        }

        /// <summary>
        /// Hashcode for identity
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Vec3D left, Vec3D right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// inequality operator
        /// </summary>
        public static bool operator !=(Vec3D left, Vec3D right)
        {
            return !left.Equals(right);
        }
        
        public static Vec3D operator +(Vec3D left, Vec3D right)
        {
            return new Vec3D(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }
        
        public static Vec3D operator -(Vec3D left, Vec3D right)
        {
            return new Vec3D(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }
    }
}
