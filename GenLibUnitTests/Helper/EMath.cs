using System;
using System.Collections.Generic;
using System.Drawing;
using GenLib.Constants;
using GenLibUnitTests.Extension;
using Xunit;

namespace GenLibUnitTests.Helper
{
    public class EMath
    {
        // repeated operations with Pi accumulate error from the last digit of Math.PI 
        private const double PiVariance = 1E-15;

        private readonly GenLib.Helper.EMath _eMath = new GenLib.Helper.EMath();

        [Fact]
        public void TestBoundsSinCos()
        {
            Assert.Equal(-1.0, _eMath.BoundsSinCos(-1.1));
            Assert.Equal(0.7, _eMath.BoundsSinCos(0.7));

            Assert.True(true);
        }

        [Fact]
        public void TestCot()
        {
            const double angle = 50;
            Assert.Equal(_eMath.Cot(angle), 1/Math.Tan(angle));

            Assert.True(true);
        }

        [Fact]
        public void TestFractional()
        {
            (-0.4).ShouldBeEqualWithVariance(Math.IEEERemainder(3.6, 1), PiVariance);
            0.6.ShouldBeEqualWithVariance(_eMath.Fractional(3.6), PiVariance);

            Assert.True(true);
        }

        [Fact]
        public void TestLogScaling()
        {
            const double precision = 1E-12;
            // to scale percent 
            double maxScale = 100;
            double minScale = 0;
            double value = 10;
            // not exactly .5 because value range of 0..100 compressed to 1..100, 
            // so value of 10 compressed to 10.9, resulting in slighter higher log value 
            const double expectedScale = 0.51871324897031179;
            Assert.Equal(expectedScale, _eMath.GetScalePercentLogScaling(value, minScale, maxScale));
            // to value 
            value.ShouldBeEqualWithVariance(_eMath.GetValueLogScaling(expectedScale, minScale, maxScale), precision);

            maxScale = 200;
            minScale = 100;
            value = 110;
            expectedScale.ShouldBeEqualWithVariance(_eMath.GetScalePercentLogScaling(value, minScale, maxScale), precision);
            value.ShouldBeEqualWithVariance(_eMath.GetValueLogScaling(expectedScale, minScale, maxScale), precision);

            Assert.Equal(0, _eMath.GetScalePercentLogScaling(0, 0, 100));
            Assert.Equal(0, _eMath.GetValueLogScaling(0, 0, 100));

            Assert.Equal(expectedScale, _eMath.GetScalePercentLogScaling(10, 0, 100));
            XunitShould.ShouldBeEqualWithVariance(10, _eMath.GetValueLogScaling(expectedScale, 0, 100), precision);

            Assert.Equal(1, _eMath.GetScalePercentLogScaling(100, 0, 100));
            //100.00000000000085d
            XunitShould.ShouldBeEqualWithVariance(100, _eMath.GetValueLogScaling(1, 0, 100), precision);

            Assert.True(true);
        }

        [Fact]
        public void TestQuadrant()
        {
            Assert.Equal(1, _eMath.Quadrant(45*Units.DegToRad));
            Assert.Equal(2, _eMath.Quadrant(135*Units.DegToRad));
            Assert.Equal(3, _eMath.Quadrant(225*Units.DegToRad));
            Assert.Equal(4, _eMath.Quadrant(315*Units.DegToRad));

            Assert.True(true);
        }

        [Fact]
        public void TestRandomize()
        {
            const int lowerBound = 5;
            const int upperBound = 10;
            var testArray = new List<int>();
            for (var ix = lowerBound; ix <= upperBound; ix++)
            {
                testArray.Add(ix);
            }

            for (var tries = 0; tries <= 100; tries++)
            {
                var d = _eMath.Randomize(lowerBound, upperBound);
                Console.WriteLine(d);
                var i = _eMath.RInt(d);
                for (var lIx = 0; lIx <= testArray.Count - 1; lIx++)
                {
                    if (i != testArray[lIx]) continue;
                    testArray.RemoveAt(lIx);
                    break;
                }
                if (testArray.Count != 0) continue;
                Console.WriteLine("all values removed in " + tries + " tries");
                break;
            }

            Assert.Equal(0, testArray.Count);

            Assert.True(true);
        }

        [Fact]
        public void TestResolveNumToPrecision()
        {
            const double num = 3.6;
            const double precision = 1.0/16;
            Assert.Equal(3.625, _eMath.ResolveNumToPrecision(num, precision));

            Assert.True(true);
        }

        [Fact]
        public void TestReverseRad()
        {
            Assert.Equal(Units.ThreeFourthsRev, _eMath.ReverseRad(Units.QtrRev));
            Assert.Equal(Units.QtrRev, _eMath.ReverseRadPi(-Units.QtrRev));
            Assert.Equal(-Units.QtrRev, _eMath.ReverseRadPi(Units.QtrRev));

            Assert.Equal(Units.ThreeFourthsRev, _eMath.ReverseRad(true, Units.QtrRev));
            Assert.Equal(Units.QtrRev, _eMath.ReverseRadPi(true, -Units.QtrRev));
            Assert.Equal(-Units.QtrRev, _eMath.ReverseRadPi(true, Units.QtrRev));
            Assert.Equal(Units.QtrRev, _eMath.ReverseRad(false, Units.QtrRev));
            Assert.Equal(-Units.QtrRev, _eMath.ReverseRadPi(false, -Units.QtrRev));
            Assert.Equal(Units.QtrRev, _eMath.ReverseRadPi(false, Units.QtrRev));

            Assert.True(true);
        }

        [Fact]
        public void TestRInt()
        {
            Assert.Equal(3, _eMath.RInt(3.1));
            Assert.Equal(4, _eMath.RInt(3.5));
            Assert.Equal(4, _eMath.RInt(3.9));
            Assert.Equal(-3, _eMath.RInt(-3.1));
            Assert.Equal(-4, _eMath.RInt(-3.5));
            Assert.Equal(-4, _eMath.RInt(-3.9));
            Assert.Equal(4, _eMath.RInt(4.1));
            Assert.Equal(5, _eMath.RInt(4.5));
            Assert.Equal(5, _eMath.RInt(4.9));
            Assert.Equal(-4, _eMath.RInt(-4.1));
            Assert.Equal(-5, _eMath.RInt(-4.5));
            Assert.Equal(-5, _eMath.RInt(-4.9));

            Assert.True(true);
        }

        [Fact]
        public void TestSqr()
        {
            Assert.Equal(20.25, _eMath.Sqr(4.5));

            Assert.True(true);
        }

        [Fact]
        public void TestValidRad()
        {
            // send in 3.7*360deg = 1332deg and see if routine normalizes value to 252deg 
            Assert.Equal(0.7*Units.OneRev, _eMath.ValidRad(3.7*Units.OneRev));
            Assert.Equal(0.3*Units.OneRev, _eMath.ValidRad(-3.7*Units.OneRev));

            Assert.True(true);
        }

        // slight errors because math.PI = 3.1415926535897931 
        [Fact]
        public void TestValidRadHalfPi()
        {
            // 1st quadrant 0-90 
            Assert.Equal(_eMath.ValidRadHalfPi(10*Units.DegToRad), 10*Units.DegToRad);
            Assert.Equal(_eMath.ValidRadHalfPi(80*Units.DegToRad), 80*Units.DegToRad);
            // 2nd quadrant 90-0 
            Assert.Equal(_eMath.ValidRadHalfPi(100*Units.DegToRad), 80*Units.DegToRad);
            _eMath.ValidRadHalfPi(170*Units.DegToRad).ShouldBeEqualWithVariance(10*Units.DegToRad, PiVariance);
            // 3rd quadrant 0--90 
            _eMath.ValidRadHalfPi(190*Units.DegToRad).ShouldBeEqualWithVariance(-10*Units.DegToRad, PiVariance);
            _eMath.ValidRadHalfPi(260*Units.DegToRad).ShouldBeEqualWithVariance(-80*Units.DegToRad, PiVariance);
            // 4th quadrant -90-0 
            _eMath.ValidRadHalfPi(280*Units.DegToRad).ShouldBeEqualWithVariance(-80*Units.DegToRad, PiVariance);
            _eMath.ValidRadHalfPi(350*Units.DegToRad).ShouldBeEqualWithVariance(-10*Units.DegToRad, PiVariance);
            // carry quadrant 0-90 again 
            _eMath.ValidRadHalfPi(370*Units.DegToRad).ShouldBeEqualWithVariance(10*Units.DegToRad, PiVariance);
            _eMath.ValidRadHalfPi(440*Units.DegToRad).ShouldBeEqualWithVariance(80*Units.DegToRad, PiVariance);

            Assert.True(true);
        }

        [Fact]
        public void TestValidRadPi()
        {
            // send in 3.7*360deg = 1332deg and see if routine normalizes value to -108deg 
            Assert.Equal(-0.3*Units.OneRev, _eMath.ValidRadPi(3.7*Units.OneRev));
            Assert.Equal(0.3*Units.OneRev, _eMath.ValidRadPi(-3.7*Units.OneRev));

            Assert.True(true);
        }

        [Fact]
        public void TestValueScaling()
        {
            // input value of 0 scales to 1 
            Assert.Equal(1, _eMath.ScaleValue(0, 1, 0, 100));
            // input value of 100 scales to 100 
            Assert.Equal(100, _eMath.ScaleValue(100, 1, 0, 100));
            // input value of 100 scales to 101 
            Assert.Equal(101, _eMath.ScaleValue(100, 1, 100, 200));
            // input value of 200 scales to 200 
            Assert.Equal(200, _eMath.ScaleValue(200, 1, 100, 200));
            // now in reverse... 
            // input value of 1 scales to 0 
            Assert.Equal(0, _eMath.ScaleValue(1, -1, 0, 100));
            // input value of 100 scales to 100 
            Assert.Equal(100, _eMath.ScaleValue(100, -1, 0, 100));
            // input value of 101 scales to 100 
            Assert.Equal(100, _eMath.ScaleValue(101, -1, 100, 200));
            // input value of 200 scales to 200 
            Assert.Equal(200, _eMath.ScaleValue(200, -1, 100, 200));

            // now back and forth 
            double value = 50;
            var compressedValue = _eMath.ScaleValue(value, 1, 0, 100);
            Assert.Equal(value, _eMath.ScaleValue(compressedValue, -1, 0, 100));
            value = 150;
            compressedValue = _eMath.ScaleValue(value, 1, 100, 200);
            Assert.Equal(value, _eMath.ScaleValue(compressedValue, -1, 100, 200));

            Assert.True(true);
        }

        [Fact]
        public void TestAngleRadFromPoints()
        {
            var fromPoint = new Point(0, 0);
            var toPoint = new Point(1, -1);
            Assert.Equal(45 * Units.DegToRad, _eMath.AngleRadFromPoints(fromPoint, toPoint));
            toPoint.Y = 1;
            Assert.Equal(135 * Units.DegToRad, _eMath.AngleRadFromPoints(fromPoint, toPoint));
            toPoint.X = -1;
            Assert.Equal(225 * Units.DegToRad, _eMath.AngleRadFromPoints(fromPoint, toPoint));
            toPoint.Y = -1;
            Assert.Equal(315 * Units.DegToRad, _eMath.AngleRadFromPoints(fromPoint, toPoint));

            Assert.True(true);
        }
    }
}