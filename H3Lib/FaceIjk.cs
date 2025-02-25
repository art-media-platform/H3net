using System;
using System.Diagnostics;

namespace H3Lib
{
    /// <summary>
    /// Functions for working with icosahedral face-centered hex IJK
    /// coordinate systems.
    /// </summary>
    [DebuggerDisplay("Face: {Face} Coord: {Coord}")]
    public readonly struct FaceIJK:IEquatable<FaceIJK>
    {
        /// <summary>
        /// face number
        /// </summary>
        public readonly int Face;
        
        /// <summary>
        /// ijk coordinates on that face
        /// </summary>
        public readonly CoordIJK Coord;

        /// <summary>
        /// constructor
        /// </summary>
        public FaceIJK(int f, CoordIJK cijk)
        {
            Face = f;
            Coord = cijk;
        }

        /// <summary>
        /// constructor
        /// </summary>
        public FaceIJK(FaceIJK fijk)
        {
            Face = fijk.Face;
            Coord = fijk.Coord;
        }

        /// <summary>
        /// Debug data in string
        /// </summary>
        public override string ToString()
        {
            return $"FaceIJK: Face: {Face} Coord: {Coord}";
        }

        /// <summary>
        /// Equality test
        /// </summary>
        public bool Equals(FaceIJK other)
        {
            return Face == other.Face && Coord.Equals(other.Coord);
        }

        /// <summary>
        /// Equality test on unboxed object
        /// </summary>
        public override bool Equals(object obj)
        {
            return obj is FaceIJK other && Equals(other);
        }

        /// <summary>
        /// Hashcode for identity
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(Face, Coord);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        public static bool operator ==(FaceIJK left, FaceIJK right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        public static bool operator !=(FaceIJK left, FaceIJK right)
        {
            return !left.Equals(right);
        }
    }
}
