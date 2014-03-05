using System;
using System.Drawing;
using GenLib.Constants;

namespace GenLib.Helper
{
    public class EMath
    {
        readonly Random _random = new Random();

        public double Randomize(double lowerBound, double upperbound)
        {
            return (upperbound - lowerBound) * _random.NextDouble() + lowerBound;
        }

        public int RInt(double num)
        {
            if (num < 0)
                return -RInt(-num);
            return (int) (Math.Floor(num + 0.5));
        }

        public int RInt(string num)
        {
            return RInt(double.Parse(num));
        }

        public double ResolveNumToPrecision(double num, double precision)
        {
            return num - Math.IEEERemainder(num, precision);
        }

        public double Fractional(double num)
        {
            return num - Math.Floor(num);
        }

        public double Sqr(double num)
        {
            return num*num;
        }

        // brings a number in radians within the bounds of 0 to 2*Pi 
        public double ValidRad(double rad)
        {
            var thisRad = rad%Units.OneRev;
            if (thisRad < 0)
                thisRad += Units.OneRev;
            return thisRad;
        }

        // bring a number in radians within the bounds of 0 to 2*Pi but then adjust 
        //the return value to be between -Pi to +Pi         
        public double ValidRadPi(double rad)
        {
            var thisRad = ValidRad(rad);
            if (thisRad > Units.HalfRev)
                thisRad -= Units.OneRev;
            return thisRad;
        }

        // bring a number in radians within the bounds of 0 to 2*Pi but then adjust 
        // the return value to be between -Pi/2 to +Pi/2  
        public double ValidRadHalfPi(double rad)
        {
            var thisRad = ValidRad(rad);
            if (thisRad >= Units.ThreeFourthsRev)
                thisRad -= Units.OneRev;
            else if (thisRad >= Units.HalfRev)
                thisRad = -thisRad + Units.HalfRev;
            else if (thisRad >= Units.QtrRev)
                thisRad = Units.HalfRev - thisRad;
            return thisRad;
        }

        // Reverses a radian value, eg, 3/4 rev is converted to 1/4 rev
        public double ReverseRad(double value)
        {
            return Units.OneRev - value;
        }

        //Reverses a radian value within Pi bounds, eg, 1/4 rev is converted to -1/4 rev
        public double ReverseRadPi(double value)
        {
            return ValidRadPi(Units.OneRev - value);
        }

        // reverses if conditional is true
        public double ReverseRad(bool reverse, double value)
        {
            return reverse ? ReverseRad(value) : value;
        }

        // reverses if conditional is true
        public double ReverseRadPi(bool reverse, double value)
        {
            return reverse ? ValidRadPi(Units.OneRev - value) : value;
        }

        // quadrant 1 is 0-90 
        // quadrant 2 is 90-180 
        // quadrant 3 is 180-270 
        // quadrant 4 is 270-360 
        public int Quadrant(double radian)
        {
            radian = ValidRad(radian);
            if (radian <= Units.QtrRev)
                return 1;
            if (radian <= Units.HalfRev)
                return 2;
            if (radian <= Units.ThreeFourthsRev)
                return 3;
            if (radian <= Units.OneRev)
                return 4;
            throw new Exception("unhandled radian");
        }

        // bring a number within legal bounds of sine and cosine (between -1 and 1)
        public double BoundsSinCos(double value)
        {
            if (value > 1)
                return 1;
            if (value < -1)
                return -1;
            return value;
        }

        public double Cot(double value)
        {
            return 1/Math.Tan(value);
        }

        public double GetScalePercentLogScaling(double value, double minScale, double maxScale)
        {
            const double logOffset = 1;
            var compressedValue = ScaleValue(value, logOffset, minScale, maxScale);
            var scaleLog10 = Math.Log10(maxScale - minScale);
            var valueLog10 = Math.Log10(compressedValue - minScale);
            return valueLog10/scaleLog10;
        }

        public double GetValueLogScaling(double scalePercent, double minScale, double maxScale)
        {
            var scaleLog10 = Math.Log10(maxScale - minScale);
            var scalePercentValue = scalePercent*scaleLog10;
            var compressedValue = Math.Exp(scalePercentValue*2.30258509299405) + minScale;
            const double logOffset = -1;
            return ScaleValue(compressedValue, logOffset, minScale, maxScale);
        }

        // value ranges from 1 to 10 to 100 
        // scale percent ranges from 0 to .5 to 1 
        // that's because log10(1)=0; this is the lowest value that can be handled 
        // scale value so that input value range is 0 to 100 but operated on value range is 1 to 100 
        // if offset is positive, then compress value(ie, 0..100 becomes 1..100); if offset is negative, then expand value (ie, 1..100 becomes 0.100) 
        public double ScaleValue(double value, double offset, double minScale, double maxScale)
        {
            if (offset == 0)
                return value;
            var range = offset > 0 ? maxScale - minScale : maxScale - minScale + offset;
            return value + offset*(maxScale - value)/range;
        }

        // 0 deg is directly upward; 
        // returns within 0-360 deg range 
        public double AngleRadFromPoints(Point fromPoint, Point toPoint)
        {
            double xRange = Math.Abs(toPoint.X - fromPoint.X);
            double yRange = Math.Abs(toPoint.Y - fromPoint.Y);
            var tangent = xRange / yRange;
            var angleRad = Math.Atan(tangent);
            if (double.IsNaN(angleRad))
                angleRad = 0;

            if (toPoint.X >= fromPoint.X && toPoint.Y <= fromPoint.Y)
                return angleRad;
            if (toPoint.X >= fromPoint.X && toPoint.Y >= fromPoint.Y)
                return Units.HalfRev - angleRad;
            if (toPoint.X <= fromPoint.X && toPoint.Y >= fromPoint.Y)
                return Units.HalfRev + angleRad;
            if (toPoint.X <= fromPoint.X && toPoint.Y <= fromPoint.Y)
                return Units.OneRev - angleRad;
            throw new Exception("could not get angle from points");
        }

        public double DistanceBetweenPoints(Point fromPoint, Point toPoint)
        {
            double x = toPoint.X - fromPoint.X;
            double y = toPoint.Y - fromPoint.Y;
            return Math.Sqrt(x * x + y * y);
        }
    }
}