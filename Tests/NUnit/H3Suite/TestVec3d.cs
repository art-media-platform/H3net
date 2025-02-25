using System;
using H3Lib;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class TestVec3D
    {
        [Test]
        public void PointSquareDistance()
        {
            
            Vec3D v1 = new Vec3D(0, 0, 0);
            Vec3D v2 = new Vec3D(1, 0, 0);
            Vec3D v3 = new Vec3D(0, 1, 1);
            Vec3D v4 = new Vec3D(1, 1, 1);
            Vec3D v5 = new Vec3D(1, 1, 2);

            Assert.IsTrue(Math.Abs(v1.PointSquareDistance(v1)) < Constants.H3.DBL_EPSILON);
            Assert.IsTrue(Math.Abs(v1.PointSquareDistance(v2) - 1) < Constants.H3.DBL_EPSILON);
            Assert.IsTrue(Math.Abs(v1.PointSquareDistance(v3) - 2) < Constants.H3.DBL_EPSILON);
            Assert.IsTrue(Math.Abs(v1.PointSquareDistance(v4) - 3) < Constants.H3.DBL_EPSILON);
            Assert.IsTrue(Math.Abs(v1.PointSquareDistance(v5) - 6) < Constants.H3.DBL_EPSILON);
        }

        [Test]
        public void GeoToVec3D()
        {
            var origin = new Vec3D();
            var c1 = new GeoCoord();
            var p1 = c1.ToVec3D();
            Assert.IsTrue(Math.Abs(origin.PointSquareDistance(p1) -1) < Constants.H3.EPSILON_RAD);

            var c2 = new GeoCoord(Constants.H3.M_PI_2, 0);
            var p2 = c2.ToVec3D();
            Assert.IsTrue(Math.Abs(p1.PointSquareDistance(p2) - 2) < Constants.H3.EPSILON_RAD);

            var c3 = new GeoCoord(Constants.H3.M_PI, 0);
            var p3 = c3.ToVec3D();
            Assert.IsTrue(Math.Abs(p1.PointSquareDistance(p3) - 4)<Constants.H3.EPSILON_RAD);
        }
    }
}
