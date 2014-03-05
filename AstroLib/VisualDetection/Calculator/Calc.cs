using System;

namespace AstroLib.VisualDetection.Calculator
{
    public class Calc
    {
        private const int AngleSize = 7;
        private const int LtcSize = 24;
        private const int FirstRowBkgndBright = 4;
        private const int LastRowBkgndBright = 27;
        private const double EyeLimitMagGainAtX = 2.5;

        /* array of log of angles used to derive LTC (LogThreshContrast) array;
           angles in arcmin are: 0.595, 3.60, 9.68, 18.2, 55.2, 121, 360 */

        private readonly double[] _logAngle =
            {
                -0.2255, 0.5563, 0.9859, 1.260, 1.742, 2.083, 2.556
            };

        /* log threshold contrast as function of background brightness
           for angles of: 0.595, 3.60, 9.68, 18.2, 55.2, 121, 360 */

        private readonly double[][] _ltc =
            {
                /* 0 to 23: first row is brightness of 4, last row is brightness of 27 */
                new[] {-0.3769, -1.8064, -2.3368, -2.4601, -2.5469, -2.5610, -2.5660},
                new[] {-0.3315, -1.7747, -2.3337, -2.4608, -2.5465, -2.5607, -2.5658},
                new[] {-0.2682, -1.7345, -2.3310, -2.4605, -2.5467, -2.5608, -2.5658},
                new[] {-0.1982, -1.6851, -2.3140, -2.4572, -2.5481, -2.5615, -2.5665},
                new[] {-0.1238, -1.6252, -2.2791, -2.4462, -2.5463, -2.5597, -2.5646},
                new[] {-0.0424, -1.5529, -2.2297, -2.4214, -2.5343, -2.5501, -2.5552},
                new[] {0.0498, -1.4655, -2.1659, -2.3763, -2.5047, -2.5269, -2.5333},
                new[] {0.1596, -1.3581, -2.0810, -2.3036, -2.4499, -2.4823, -2.4937},
                new[] {0.2934, -1.2256, -1.9674, -2.1965, -2.3631, -2.4092, -2.4318},
                new[] {0.4557, -1.0673, -1.8186, -2.0531, -2.2445, -2.3083, -2.3491},
                new[] {0.6500, -0.8841, -1.6292, -1.8741, -2.0989, -2.1848, -2.2505},
                new[] {0.8808, -0.6687, -1.3967, -1.6611, -1.9284, -2.0411, -2.1375},
                new[] {1.1558, -0.3952, -1.1264, -1.4176, -1.7300, -1.8727, -2.0034},
                new[] {1.4822, -0.0419, -0.8243, -1.1475, -1.5021, -1.6768, -1.8420},
                new[] {1.8559, 0.3458, -0.4924, -0.8561, -1.2661, -1.4721, -1.6624},
                new[] {2.2669, 0.6960, -0.1315, -0.5510, -1.0562, -1.2892, -1.4827},
                new[] {2.6760, 1.0880, 0.2060, -0.3210, -0.8800, -1.1370, -1.3620},
                new[] {2.7766, 1.2065, 0.3467, -0.1377, -0.7361, -0.9964, -1.2439},
                new[] {2.9304, 1.3821, 0.5353, 0.0328, -0.5605, -0.8606, -1.1187},
                new[] {3.1634, 1.6107, 0.7708, 0.2531, -0.3895, -0.7030, -0.9681},
                new[] {3.4643, 1.9034, 1.0338, 0.4943, -0.2033, -0.5259, -0.8288},
                new[] {3.8211, 2.2564, 1.3265, 0.7605, 0.0172, -0.2992, -0.6394},
                new[] {4.2210, 2.6320, 1.6990, 1.1320, 0.2860, -0.0510, -0.4080},
                new[] {4.6100, 3.0660, 2.1320, 1.5850, 0.6520, 0.2410, -0.1210}
            };

        public Calc()
        {
            EyeLimitMag = 6;
            ExitPupilmm = 7;
            ScopeTrans = .8;
            SingleEyeFactor = .5;
        }

        /* input vars */
        public double ApertureIn { get; set; }
        public double ScopeTrans { get; set; }
        public double EyeLimitMag { get; set; }
        public double ExitPupilmm { get; set; }
        public double BkgndBrightEye { get; set; }
        public string ObjName { get; set; }
        public double ObjMag { get; set; }
        public double MaxObjArcmin { get; set; }
        public double MinObjArcmin { get; set; }
        public double EyepieceExitPupilmm { get; set; }
        public double ApparentFoV { get; set; }
        public double SingleEyeFactor { get; set; }

        /* output vars */
        public double LimitMag { get; set; }
        public double LogContrastDiff { get; set; }
        public double LogContrastObject { get; set; }
        public double LogContrastRequired { get; set; }
        public double X { get; set; }
        public double MinX { get; set; }
        public double MaxXMaxObj { get; set; }
        public double MaxXMinObj { get; set; }
        public double ActualFoV { get; set; }
        public double ScopeTransMagChange { get; set; }
        public double SingleEyeMagChange { get; set; }
        public double SurfBrightObj { get; set; }
        public double BrightReductionAtX { get; set; }
        public double BkgndBrightAtX { get; set; }
        public double SurfBrightObjAtX { get; set; }
        public double SurfBrightObjPlusBkgndAtX { get; set; }

        public void Generate()
        {
            X = ApertureIn*25.4/EyepieceExitPupilmm;
            MinX = ApertureIn*25.4/ExitPupilmm;
            MaxXMaxObj = ApparentFoV/(MinObjArcmin/60);
            MaxXMinObj = ApparentFoV/(MaxObjArcmin/60);
            var maxXBasedOn1MmExitPupil = 25.4*ApertureIn;
            if (MaxXMaxObj > maxXBasedOn1MmExitPupil)
                MaxXMaxObj = maxXBasedOn1MmExitPupil;
            if (MaxXMinObj > maxXBasedOn1MmExitPupil)
                MaxXMinObj = maxXBasedOn1MmExitPupil;
            ActualFoV = ApparentFoV/X;

            SingleEyeMagChange = -2.5*Math.Log10(SingleEyeFactor);
            ScopeTransMagChange = -2.5*Math.Log10(ScopeTrans);
            LimitMag = EyeLimitMag + EyeLimitMagGainAtX + 2.5*Math.Log10(MinX*MinX) - SingleEyeMagChange;

            SurfBrightObj = ObjMag + 2.5*Math.Log10(2827.0*MinObjArcmin*MaxObjArcmin);
            LogContrastObject = -0.4*(SurfBrightObj - BkgndBrightEye);

            BrightReductionAtX = 5*Math.Log10(X/MinX);
            BkgndBrightAtX = BkgndBrightEye + BrightReductionAtX + SingleEyeMagChange + ScopeTransMagChange;
            SurfBrightObjAtX = -2.5*Math.Log10(Math.Pow(10, (-0.4*SurfBrightObj))) + BrightReductionAtX +
                               SingleEyeMagChange + ScopeTransMagChange;
            /* surface brightness of object + background brightness */
            var objPlusBkgnd = Math.Pow(10, (-0.4*SurfBrightObj)) + Math.Pow(10, (-0.4*BkgndBrightEye));
            SurfBrightObjPlusBkgndAtX = -2.5*Math.Log10(objPlusBkgnd) + BrightReductionAtX;

            /* 2 dimensional interpolation of LTC array */
            var apparentAngle = X*MinObjArcmin;
            var logApparentAngle = Math.Log10(apparentAngle);
            var bbX = BkgndBrightAtX;
            var I = 0;
            /* int of background brightness */
            var intbbX = (int) bbX;
            /* background brightness index A */
            var bbIxA = intbbX - FirstRowBkgndBright;
            /* min index must be at least 0 */
            if (bbIxA < 0)
                bbIxA = 0;
            /* max bbIxA index cannot > 22 to leave room for bbIxB */
            if (bbIxA > LtcSize - 2)
                bbIxA = LtcSize - 2;
            /* background brightness index B */
            var bbIxB = bbIxA + 1;
            while (I < AngleSize && logApparentAngle > _logAngle[I])
            {
                I++;
            }
            /* found 1st Angle[] value > logApparentAngle, so back up 2 */
            I -= 2;
            if (I < 0)
            {
                I = 0;
                logApparentAngle = _logAngle[0];
            }
            /* eg, if LogApparentAngle = 4 and Angle[I] = 3 and Angle[I+1] = 5: 
             * InterpAngle = .5, or .5 of the way between Angle[I] and Angle[I+1] */
            var interpAngle = (logApparentAngle - _logAngle[I])/(_logAngle[I + 1] - _logAngle[I]);
            var interpA = _ltc[bbIxA][I] + interpAngle*(_ltc[bbIxA][I + 1] - _ltc[bbIxA][I]);
            var interpB = _ltc[bbIxB][I] + interpAngle*(_ltc[bbIxB][I + 1] - _ltc[bbIxB][I]);

            if (bbX < FirstRowBkgndBright)
                bbX = FirstRowBkgndBright;
            if (intbbX >= LastRowBkgndBright)
                LogContrastRequired = interpB + (bbX - LastRowBkgndBright)*(interpB - interpA);
            else
                LogContrastRequired = interpA + (bbX - intbbX)*(interpB - interpA);

            LogContrastDiff = LogContrastObject - LogContrastRequired;
        }

        public void DisplayResults()
        {
            Console.WriteLine(@"input values:");
            Console.WriteLine(@"  aperture (in)                    " + ApertureIn);
            Console.WriteLine(@"  eye's limiting magnitude         " + EyeLimitMag);
            Console.WriteLine(@"  eye's max exit pupil mm          " + ExitPupilmm);
            Console.WriteLine(@"  sky background brightness        " + BkgndBrightEye);
            Console.WriteLine(@"  object name                      " + ObjName);
            Console.WriteLine(@"  object integrated magnitude      " + ObjMag);
            Console.WriteLine(@"  object dimensions                " + MaxObjArcmin + @" x " + MinObjArcmin);
            Console.WriteLine(@"  magnification                    " + X);
            Console.WriteLine(@"  eyepiece apparent field deg      " + ApparentFoV);
            Console.WriteLine(@"  actual field deg                 " + ActualFoV);
            Console.WriteLine(@"calculated values:");
            Console.WriteLine(@"  minimum useful X                 " + MinX);
            Console.WriteLine(@"  maximum useful X varies from     " + (int) MaxXMinObj + @" to " + (int) MaxXMaxObj);
            Console.WriteLine(@"  faintest star                    " + LimitMag);
            Console.WriteLine(@"  single eye mag reduction         " + SingleEyeMagChange);
            Console.WriteLine(@"  scope transmission mag reduction " + ScopeTransMagChange);
            Console.WriteLine(@"  brightness (mag/arcsec^2):");
            Console.WriteLine(@"    object without telescope       " + SurfBrightObj);
            Console.WriteLine(@"    brightness reduction at X      " + BrightReductionAtX);
            Console.WriteLine(@"    object in scope at X           " + SurfBrightObjAtX);
            Console.WriteLine(@"    background in scope at X       " + BkgndBrightAtX);
            Console.WriteLine(@"    object+bkgnd in scope at X     " + SurfBrightObjPlusBkgndAtX);
            Console.WriteLine(@"  log object contrast              " + LogContrastObject);
            Console.WriteLine(@"  log contrast required            " + LogContrastRequired);
            Console.WriteLine(@"  log contrast difference          " + LogContrastDiff + @"; detectable? " +
                              (LogContrastObject >= LogContrastRequired));
        }
    }
}