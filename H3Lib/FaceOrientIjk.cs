using System;

namespace H3Lib
{
    /// <summary>
    /// Information to transform into an adjacent face IJK system
    /// </summary>
    public readonly struct FaceOrientIJK:IEquatable<FaceOrientIJK>
    {
        /// <summary>
        /// face number
        /// </summary>
        public readonly int Face;
        
        /// <summary>
        /// res 0 translation relative to primary face
        /// </summary>
        public readonly CoordIJK Translate;
        
        /// <summary>
        /// number of 60 degree ccw rotations relative to primary
        /// </summary>
        public readonly int Ccw60Rotations;

        /// <summary>
        /// Constructor
        /// </summary>
        public FaceOrientIJK(int f, int i, int j, int k, int c)
        {
            Face = f;
            Translate = new CoordIJK(i, j, k);
            Ccw60Rotations = c;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public FaceOrientIJK(int f, CoordIJK translate, int c)
        {
            Face = f;
            Translate = translate;
            Ccw60Rotations = c;
        }

        /// <summary>
        /// Equality test
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(FaceOrientIJK other)
        {
            return Face == other.Face &&
                   Translate.Equals(other.Translate) &&
                   Ccw60Rotations == other.Ccw60Rotations;
        }

        /// <summary>
        /// Equality test against unboxed object
        /// </summary>
        public override bool Equals(object obj)
        {
            return obj is FaceOrientIJK other && Equals(other);
        }

        /// <summary>
        /// Hashcode for identity
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Face, Translate, Ccw60Rotations);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        public static bool operator ==(FaceOrientIJK left, FaceOrientIJK right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        public static bool operator !=(FaceOrientIJK left, FaceOrientIJK right)
        {
            return !left.Equals(right);
        }
    }
}
