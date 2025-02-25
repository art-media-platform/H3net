namespace H3Lib
{
    /// <summary>
    /// Operations on Vec3D
    /// </summary>
    public static class Vec3DExtensions
    {
        /// <summary>
        /// Calculate the square of the distance between two 3D coordinates.
        /// </summary>
        /// <param name="v1">The first 3D coordinate.</param>
        /// <param name="v2">The second 3D coordinate.</param>
        /// <returns>The square of the distance between the given points.</returns>
        /// <!--
        /// vec3d.c
        /// double _pointSquareDist
        /// -->
        internal static double PointSquareDistance(this Vec3D v1, Vec3D v2)
        {
            return (v1.X - v2.X).Square() + (v1.Y - v2.Y).Square() + (v1.Z - v2.Z).Square();
        }

        /// <summary>
        /// Replace X value
        /// </summary>
        /// <param name="v3"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vec3D SetX(this Vec3D v3, double x)
        {
            return new Vec3D(x, v3.Y, v3.Z);
        }

        /// <summary>
        /// Replace Y value
        /// </summary>
        /// <param name="v3"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Vec3D SetY(this Vec3D v3, double y)
        {
            return new Vec3D(v3.X, y, v3.Z);
        }

        /// <summary>
        /// Replace Z value
        /// </summary>
        /// <param name="v3"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Vec3D SetZ(this Vec3D v3, double z)
        {
            return new Vec3D(v3.X, v3.Y, z);
        }
    }
}
