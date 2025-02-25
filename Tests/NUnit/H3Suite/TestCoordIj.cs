using H3Lib;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class TestCoordIJ
    {
        [Test]
        public void IjkToIj()
        {
            var ijk = new CoordIJK();
            var ij = ijk.ToIj();
            Assert.AreEqual(0, ij.I);
            Assert.AreEqual(0, ij.J);

            ijk = ij.ToIjk();
            Assert.AreEqual(0, ijk.I);
            Assert.AreEqual(0, ijk.J);
            Assert.AreEqual(0, ijk.K);
        }

        [Test]
        public void IjkToIjRoundtrip()
        {
            for (Direction dir = Direction.CENTER_DIGIT; dir < Direction.NUM_DIGITS; dir++)
            {
                var ijk = new CoordIJK();
                ijk = ijk.Neighbor(dir);

                var ij = ijk.ToIj();

                var recovered = ij.ToIjk();

                Assert.AreEqual(ijk, recovered);
            }
        }

        [Test]
        public void IjkToCubeRoundtrip()
        {
            for (Direction dir = Direction.CENTER_DIGIT; dir < Direction.NUM_DIGITS; dir++)
            {
                var ijk = new CoordIJK().Neighbor(dir);
                var original = ijk;

                ijk = ijk.ToCube();
                ijk = ijk.FromCube();

                Assert.AreEqual(ijk, original);
            }
        }
    }
}
