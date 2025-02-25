using System;

namespace H3Lib
{
    /// <summary>
    /// base cell at a given ijk and required rotations into its system
    /// </summary>
    /// <!--
    /// baseCells.c
    /// typedef struct BaseCellRotation
    /// -->
    public readonly struct BaseCellRotation:IEquatable<BaseCellRotation>
    {
        /// <summary>
        /// base cell number
        /// </summary>
        public readonly int BaseCell;
        /// <summary>
        /// number of ccw 60 degree rotations relative to current face
        /// </summary>
        public readonly int CCWRotate;
        
        /// <summary>
        /// constructor
        /// </summary>
        public BaseCellRotation(int baseCell, int ccwRotate)
        {
            BaseCell = baseCell;
            CCWRotate = ccwRotate;
        }

        /// <summary>
        /// Test for equality against BaseCellRotation
        /// </summary>
        public bool Equals(BaseCellRotation other)
        {
            return BaseCell == other.BaseCell &&
                   CCWRotate == other.CCWRotate;
        }

        /// <summary>
        /// Test for equality against object that can be unboxed to BaseCellRotation
        /// </summary>
        public override bool Equals(object obj)
        {
            return obj is BaseCellRotation other && Equals(other);
        }

        /// <summary>
        /// Hashcode for identity
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(BaseCell, CCWRotate);
        }

        /// <summary>
        /// Test for equality
        /// </summary>
        public static bool operator ==(BaseCellRotation left, BaseCellRotation right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Test for inequality
        /// </summary>
        public static bool operator !=(BaseCellRotation left, BaseCellRotation right)
        {
            return !left.Equals(right);
        }
    }
}
