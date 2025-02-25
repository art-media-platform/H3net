using H3Lib;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class TestCoordIJK
    {
        [Test]
        public void UnitIjkToDigit()
        {
            var zero = new CoordIJK();
            var i = new CoordIJK(1, 0, 0);
            var outOfRange = new CoordIJK(2, 0, 0);
            var unNormalizedZero = new CoordIJK(2, 2, 2);

            Assert.AreEqual(zero.ToDirection(), Direction.CENTER_DIGIT);
            Assert.AreEqual(i.ToDirection(), Direction.I_AXES_DIGIT);
            Assert.AreEqual(outOfRange.ToDirection(), Direction.INVALID_DIGIT);
            Assert.AreEqual(unNormalizedZero.ToDirection(), Direction.CENTER_DIGIT);
        }

        [Test]
        public void Neighbor()
        {
            var ijk = new CoordIJK();
            var zero = new CoordIJK();
            var i = new CoordIJK(1, 0, 0);

            ijk = ijk.Neighbor(Direction.CENTER_DIGIT);
            Assert.AreEqual(ijk, zero);

            ijk = ijk.Neighbor(Direction.I_AXES_DIGIT);
            Assert.AreEqual(ijk, i);

            ijk = ijk.Neighbor(Direction.INVALID_DIGIT);
            Assert.AreEqual(ijk, i);
        }
    }
}
