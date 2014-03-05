using System;

namespace GenLib.Constants
{
    public class Units
    {
        //JD on Greenwich Jan 1, 2000, noon 
        public const double ArcminToDeg = 1/DegToArcmin;
        public const double ArcminToRad = DegToRad/60;
        public const double ArcsecToDeg = 1/DegToArcsec;
        public const double ArcsecToRad = ArcminToRad/60;
        public const double ArcsecToRev = 1/RevToArcsec;
        public const double DayToHr = 24;
        public const double DayToMin = 60*DayToHr;
        public const double DayToSec = 60*DayToMin;
        public const double DayToYear = 365.25;
        public const double DegToArcmin = 60;
        public const double DegToArcsec = 3600;
        public const double DegToRad = OneRev/360;
        public const double HalfRev = Math.PI;
        public const double HrToDay = 1/DayToHr;
        public const double HrToRad = OneRev/24;
        public const double HundSecToRad = SecToRad/100;
        public const double JD2000 = 2451545;
        public const double JDYear = 2000;
        public const double MilliDegToRad = DegToRad/1000;
        public const double MilliSecToRad = SecToRad/1000;
        public const double MinToDay = 1/DayToMin;
        public const double MinToRad = HrToRad/60;

        // 1 revolution = 2 Pi Radians = 360 Degrees = 24 Hours 
        public const double OneRev = 2*Math.PI;
        public const double QtrRev = 0.5*Math.PI;
        public const double RadToArcmin = 60*RadToDeg;
        public const double RadToArcsec = 60*RadToArcmin;
        public const double RadToDeg = 360/OneRev;
        public const double RadToHr = 24/OneRev;
        public const double RadToHundSec = 100*RadToSec;
        public const double RadToMilliDeg = 1000*RadToDeg;
        public const double RadToMilliSec = 1000*RadToSec;
        public const double RadToMin = 60*RadToHr;
        public const double RadToRev = 1/OneRev;
        public const double RadToSec = 60*RadToMin;
        public const double RadToTenthsArcsec = 100*RadToArcsec;
        public const double RevToArcsec = 1296000;
        public const double RevToRad = OneRev;
        public const double SecToDay = 1/DayToSec;
        public const double SecToRad = MinToRad/60;
        public const double SidRate = 1.002737909;
        public const double TenthsArcsecToRad = ArcsecToRad/10;
        public const double ThreeFourthsRev = 1.5*Math.PI;
        public const double YearToDay = 1/DayToYear;
    }
}