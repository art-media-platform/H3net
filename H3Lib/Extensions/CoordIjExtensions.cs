namespace H3Lib
{
    /// <summary>
    /// Extension methods for working with CoordIJ type
    /// </summary>
    public static class CoordIJExtensions
    {
        /// <summary>
        /// Replace I value
        /// </summary>
        public static CoordIJ ReplaceI(this CoordIJ ij, int i)
        {
            return new CoordIJ(i, ij.J);
        }

        /// <summary>
        /// replace J value
        /// </summary>
        /// <returns></returns>
        public static CoordIJ ReplaceJ(this CoordIJ ij, int j)
        {
            return new CoordIJ(ij.I, j);
        }
        
        /// <summary>
        /// Transforms coordinates from the IJ coordinate system to the IJK+ coordinate system
        /// </summary>
        /// <param name="ij">The input IJ coordinates</param>
        /// <remarks>
        /// coordijk.c
        /// void ijToIjk
        /// </remarks>
        public static CoordIJK ToIjk(this CoordIJ ij)
        {
            return new CoordIJK(ij.I, ij.J, 0).Normalized();
        }

        /// <summary>
        /// Produces an index for ij coordinates anchored by an origin.
        ///
        /// The coordinate space used by this function may have deleted
        /// regions or warping due to pentagonal distortion.
        ///
        /// Failure may occur if the index is too far away from the origin
        /// or if the index is on the other side of a pentagon.
        ///
        /// This function is experimental, and its output is not guaranteed
        /// to be compatible across different versions of H3.
        /// </summary>
        /// <param name="ij">coordinates to index.</param>
        /// <param name="origin">An anchoring index for the ij coordinate system.</param>
        /// <returns>
        /// Tuple:
        /// Item1 indicates status => 0 = Success, other = failure
        /// Item2 contains H3Index upon success.
        /// </returns>
        /// <!--
        /// localij,c
        /// int H3_EXPORT(experimentalLocalIJToH3)
        /// -->
        public static (int, H3Index) ToH3Experimental(this CoordIJ ij, H3Index origin)
        {
            // This function is currently experimental. Once ready to be part of the
            // non-experimental API, this function (with the experimental prefix) will
            // be marked as deprecated and to be removed in the next major version. It
            // will be replaced with a non-prefixed function name.
            var ijk = ij.ToIjk();
            return ijk.LocalIJKToH3(origin);
        }
    }
}
