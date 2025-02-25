using System;
using H3Lib;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class TestVec2D
    {
        [Test]
        public void V2DMagnitude()
        {
            var v = new Vec2D(3.0, 4.0);
            const  double expected = 5.0;
            double mag = v.Magnitude;
            Assert.IsTrue(Math.Abs(mag-expected) < Constants.H3.DBL_EPSILON);
        }

        [Test]
        public void V2DIntersect()
        {
            var p0 = new Vec2D(2.0, 2.0);
            var p1 = new Vec2D(6.0, 6.0);
            var p2 = new Vec2D(0.0, 4.0);
            var p3 = new Vec2D(10.0, 4.0);

            var intersection = Vec2D.FindIntersection(p0, p1, p2, p3);

            const  double expectedX = 4.0;
            const  double expectedY = 4.0;

            Assert.IsTrue(Math.Abs(intersection.X - expectedX) < Constants.H3.DBL_EPSILON);
            Assert.IsTrue(Math.Abs(intersection.Y - expectedY) < Constants.H3.DBL_EPSILON);
        }

        [Test]
        public void V2DEquals()
        {
            Vec2D v1 = new Vec2D(3.0, 4.0);
            Vec2D v2 = new Vec2D(3.0, 4.0);
            Vec2D v3 = new Vec2D(3.5, 4.0);
            Vec2D v4 = new Vec2D(3.0, 4.5);

            Assert.AreEqual(v1, v2);
            Assert.AreNotEqual(v1, v3);
            Assert.AreNotEqual(v1, v4);
        }
    }
}
