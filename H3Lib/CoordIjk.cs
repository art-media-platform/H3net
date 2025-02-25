using System;
using System.Diagnostics;

namespace H3Lib
{
    /// <summary>
    /// Header file for CoordIJK functions including conversion from lat/lon
    /// </summary>
    /// <remarks>
    /// References two Vec2D cartesian coordinate systems:
    ///
    /// 1. gnomonic: face-centered polyhedral gnomonic projection space with
    ///    traditional scaling and x-axes aligned with the face Class II
    ///    i-axes
    ///
    /// 2. hex2d: local face-centered coordinate system scaled a specific H3 grid
    ///    resolution unit length and with x-axes aligned with the local i-axes
    /// </remarks>
    [DebuggerDisplay("IJK: ({I}, {J}, {K})")]
    public readonly struct CoordIJK:IEquatable<CoordIJK>
    {
        /// <summary>
        /// I Coordinate
        /// </summary>
        public readonly int I;
        
        /// <summary>
        /// J Coordinate
        /// </summary>
        public readonly int J;
        
        /// <summary>
        /// K Coordinate
        /// </summary>
        public readonly int K;

        /// <summary>
        /// IJK hexagon coordinates
        /// </summary>
        public CoordIJK(int i, int j, int k):this()
        {
            I = i;
            J = j;
            K = k;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public CoordIJK(CoordIJK coord)
        {
            I = coord.I;
            J = coord.J;
            K = coord.K;
        }

        /// <summary>
        /// Debug information
        /// </summary>
        public override string ToString()
        {
            return $"CoordIJK (IJK) {I}, {J}, {K}";
        }

        /// <summary>
        /// Given cube coords as doubles, round to valid integer coordinates. Algorithm
        /// from https://www.redblobgames.com/grids/hexagons/#rounding
        /// </summary>
        /// <param name="i">Floating-point I coord</param>
        /// <param name="j">Floating-point J coord</param>
        /// <param name="k">Floating-point K coord</param>
        /// <returns>IJK coord struct</returns>
        /// <!--
        /// localij.c
        /// static void cubeRound
        /// -->
        public static CoordIJK CubeRound(double i, double j, double k)
        {
            var ri = (int) Math.Round(i, MidpointRounding.AwayFromZero);
            var rj = (int) Math.Round(j, MidpointRounding.AwayFromZero);
            var rk = (int) Math.Round(k, MidpointRounding.AwayFromZero);

            double iDiff = Math.Abs(ri - i);
            double jDiff = Math.Abs(rj - j);
            double kDiff = Math.Abs(rk - k);

            // Round, maintaining valid cube coords
            if (iDiff > jDiff && iDiff > kDiff)
            {
                ri = -rj - rk;
            }
            else if (jDiff > kDiff)
            {
                rj = -ri - rk;
            }
            else
            {
                rk = -ri - rj;
            }

            return new CoordIJK(ri, rj, rk);
        }
        
        /// <summary>
        /// Equality test
        /// </summary>
        public bool Equals(CoordIJK other)
        {
            return I == other.I && J == other.J && K == other.K;
        }

        /// <summary>
        /// Equality for unboxed object
        /// </summary>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is CoordIJK ijk && Equals(ijk);
        }

        /// <summary>
        /// Hashcode for identity
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(I, J, K);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        public static bool operator ==(CoordIJK left, CoordIJK right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        public static bool operator !=(CoordIJK left, CoordIJK right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        /// Addition operator
        /// </summary>
        public static CoordIJK operator+(CoordIJK c1,CoordIJK c2)
        {
            return new CoordIJK(c1.I + c2.I, c1.J + c2.J, c1.K + c2.K);
        }

        /// <summary>
        /// Subtraction operator
        /// </summary>
        public static CoordIJK operator-(CoordIJK c1,CoordIJK c2)
        {
            return new CoordIJK(c1.I - c2.I, c1.J - c2.J, c1.K - c2.K);
        }

        /// <summary>
        /// Multiply operator for scaling
        /// </summary>
        public static CoordIJK operator *(CoordIJK c, int scalar)
        {
            return new CoordIJK(c.I * scalar, c.J * scalar, c.K * scalar);
        }
    }
}
