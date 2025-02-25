using H3Lib;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class TestH3Index
    {
        [Test]
        public void GeoToH3ExtremeCoordinates()
        {
            // Check that none of these cause crashes.
            var g = new GeoCoord(0, 1E28);
            var h = g.ToH3Index(14);

            var g2 = new GeoCoord(1E28, 1E28);
            h = g2.ToH3Index(15);

            var g4 = new GeoCoord().SetDegrees(2, -1e28);
            h = g4.ToH3Index(0);
        }

        [Test]
        public void FaceIJKToH3ExtremeCoordinates()
        {
            var Fijk0I = new FaceIJK(0, new CoordIJK(3, 0, 0));
            Assert.AreEqual(0, Fijk0I.ToH3(0).Value);
            var Fijk0J = new FaceIJK(1, new CoordIJK(0, 4, 0));
            Assert.AreEqual(0, Fijk0J.ToH3(0).Value);
            var Fijk0K = new FaceIJK(2, new CoordIJK(2, 0, 5));
            Assert.AreEqual(0, Fijk0K.ToH3(0).Value);

            var Fijk1I = new FaceIJK(3, new CoordIJK(6, 0, 0));
            Assert.AreEqual(0, Fijk1I.ToH3(0).Value);
            var Fijk1J = new FaceIJK(4, new CoordIJK(0, 7, 1));
            Assert.AreEqual(0, Fijk1J.ToH3(0).Value);
            var Fijk1K = new FaceIJK(5, new CoordIJK(2, 0, 8));
            Assert.AreEqual(0, Fijk1K.ToH3(0).Value);

            var Fijk2I = new FaceIJK(3, new CoordIJK(18, 0, 0));
            Assert.AreEqual(0, Fijk2I.ToH3(0).Value);
            var Fijk2J = new FaceIJK(4, new CoordIJK(0, 19, 1));
            Assert.AreEqual(0, Fijk2J.ToH3(0).Value);
            var Fijk2K = new FaceIJK(5, new CoordIJK(2, 0, 20));
            Assert.AreEqual(0, Fijk2K.ToH3(0).Value);
        }
        
        [Test]
        public void H3IsValidAtResolution()
        {
            for (int i = 0; i <= Constants.H3.MAX_H3_RES; i++)
            {
                GeoCoord geoCoord = default;
                H3Index h3 = geoCoord.ToH3Index(i);
                Assert.IsTrue(h3.IsValid());
            }
        }

        [Test]
        public void H3IsValidDigits()
        {
            GeoCoord geoCoord = default;
            var h3 = geoCoord.ToH3Index(1);
            h3 ^= 1;
            Assert.IsFalse(h3.IsValid());
        }

        [Test]
        public void H3IsValidBaseCell()
        {
            for (int i = 0; i < Constants. H3.NUM_BASE_CELLS; i++)
            {
                H3Index h = H3Lib.Constants.H3_INIT;
                h = h.SetMode(H3Mode.Hexagon).SetBaseCell(i);
                Assert.IsTrue(h.IsValid());
                Assert.AreEqual(i, h.BaseCell);
            }
        }

        [Test]
        public void H3IsValidBaseCellInvalid()
        {
            H3Index hWrongBaseCell = H3Lib.Constants.H3_INIT;
            hWrongBaseCell.SetMode(H3Mode.Hexagon).SetBaseCell(Constants.H3.NUM_BASE_CELLS);
            Assert.IsFalse(hWrongBaseCell.IsValid());
        }

        [Test]
        public void H3IsValidWithMode()
        {
            for (var i = 0; i <= 15; i++)
            {
                H3Index h = H3Lib.Constants.H3_INIT;
                h = h.SetMode((H3Mode) i);
                if (i == (int) H3Mode.Hexagon)
                {
                    Assert.IsTrue(h.IsValid());
                }
                else
                {
                    Assert.IsFalse(h.IsValid());
                }
            }
        }

        [Test]
        public void H3IsValidReservedBits()
        {
            for (int i = 0; i < 8; i++)
            {
                H3Index h = H3Lib.Constants.H3_INIT;
                h = h.SetMode(H3Mode.Hexagon).SetReservedBits(i);

                if (i == 0)
                {
                    Assert.IsTrue(h.IsValid());
                }
                else
                {
                    Assert.IsFalse(h.IsValid());
                }
            }
        }

        [Test]
        public void H3IsValidHighBit()
        {
            H3Index h = H3Lib.Constants.H3_INIT;
            h = h.SetMode(H3Mode.Hexagon).SetHighBit(1);
            Assert.IsFalse(h.IsValid());
        }

        [Test]
        public void H3BadDigitInvalid()
        {
            H3Index h = H3Lib.Constants.H3_INIT;
            // By default the first index digit is out of range.
            h = h.SetMode(H3Mode.Hexagon).SetResolution(1);
            Assert.IsFalse(h.IsValid());
        }

        [Test]
        public void H3DeletedSubsequenceInvalid()
        {
            // Create an index located in a deleted subsequence of a pentagon.
            H3Index h = new H3Index(1, 4, Direction.K_AXES_DIGIT);
            Assert.IsFalse(h.IsValid());
        }

        [Test]
        public void H3ToString()
        {
            //  Not really applicable since H3Index already has
            //  its own ToString(), though there may be some
            //  options added to it in the future.
        }

        [Test]
        public void StringToH3()
        {
            //  NOTE: This one was skipped in implementation.
            //  However, it's not impossible to work around.
            if (ulong.TryParse("", out ulong result1))
            {
                H3Index h = result1;
                Assert.AreEqual(0, h.Value);
            }
            if (ulong.TryParse("**", out ulong result2))
            {
                H3Index h = result2;
                Assert.AreEqual(0, h.Value);
            }
        }

        [Test]
        public void SetH3Index()
        {
            var h = new H3Index(5, 12, 1);
            Assert.AreEqual(5, h.Resolution);
            Assert.AreEqual(12, h.BaseCell);
            Assert.AreEqual(H3Mode.Hexagon, h.Mode);

            for (int i = 1; i <= 5; i++)
            {
                Assert.AreEqual(1, (int) h.GetIndexDigit(i));
            }

            for (int i = 6; i <= Constants.H3.MAX_H3_RES; i++)
            {
                Assert.AreEqual(7, (int) h.GetIndexDigit(i));
            }

            Assert.AreEqual(0x85184927fffffffL, h.Value);
        }

        [Test]
        public void H3IsResClassIii()
        {
            GeoCoord coord = default;
            for (int i = 0; i <= Constants.H3.MAX_H3_RES; i++)
            {
                var h = coord.ToH3Index(i);
                Assert.AreEqual(h.IsResClassIii, i.IsResClassIii());
            }
        }
    }
}
