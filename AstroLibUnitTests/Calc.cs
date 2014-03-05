using AstroLib.VisualDetection.Calculator;
using GenLib.Extensions;
using Xunit;

namespace AstroLibUnitTests
{
    public class Calc
    {
        [Fact]
        public void Calc1()
        {
            var calc = new AstroLib.VisualDetection.Calculator.Calc
                           {
                               ApertureIn = 13,
                               BkgndBrightEye = 21.5,
                               ObjName = "California Nebula",
                               ObjMag = 5,
                               MaxObjArcmin = 145,
                               MinObjArcmin = 40,
                               EyepieceExitPupilmm = 6,
                               ApparentFoV = 100,
                           };
            calc.Generate();
            calc.DisplayResults();
            Assert.Equal(0.81793677405235943, calc.LogContrastDiff);

            Assert.True(true);
        }

        [Fact]
        public void Calc2()
        {
            var calc = new AstroLib.VisualDetection.Calculator.Calc
                           {
                               ScopeTrans = .85,
                               EyeLimitMag = 6.5,
                               ExitPupilmm = 7,
                               ApertureIn = 20,
                               BkgndBrightEye = 21,
                               ObjName = "copy from earlier ODM unit test",
                               ObjMag = 12,
                               MaxObjArcmin = 2,
                               MinObjArcmin = 2,
                               EyepieceExitPupilmm = 7,
                               ApparentFoV = 100,
                           };
            calc.Generate();
            calc.DisplayResults();
            // old program LogContrastDiff = 0.51 because of 9mm exit pupil assumption, 
            // incorrect application of scope transmission and missing single eye factor
            Assert.Equal(0.48554434146162329, calc.LogContrastDiff);

            Assert.True(true);
        }

        [Fact]
        public void ExitPupilSequence()
        {
            var eps = GetEps();
            7.To(1).ForEach(i => Assert.Equal(i, eps.Calcs[7 - i].EyepieceExitPupilmm));
            // same as Calc1() (6mm eyepiece exit pupil)
            Assert.Equal(0.81793677405235943, eps.Calcs[1].LogContrastDiff);

            Assert.True(true);
        }

        [Fact]
        public void ApertureSequence()
        {
            var apertureSequence = new ApertureSequence
                                       {
                                           ApertureIn = 13,
                                           BkgndBrightEye = 21.5,
                                           ObjName = "California Nebula",
                                           ObjMag = 5,
                                           MaxObjArcmin = 145,
                                           MinObjArcmin = 40,
                                           ApparentFoV = 100,
                                       };
            apertureSequence.Generate();
            apertureSequence.DisplayResults();

            Assert.True(true);
        }

        [Fact]
        public void BestExitPupil()
        {
            var eps = GetEps();
            var initialCalcs = eps.Calcs.CreateListFrom(c => c);

            var r = eps.BestExitPupil();
            r.DisplayResults();
            Assert.Equal(3, r.EyepieceExitPupilmm);
            for (var cix = 0; cix < initialCalcs.Count; cix++)
                Assert.Same(initialCalcs[cix], eps.Calcs[cix]);

            Assert.Null(GetEpsBelowThreshold().BestExitPupil());

            Assert.True(true);
        }

        [Fact]
        public void MinApertureBestExitPupil()
        {
            var mabep = new MinApertureBestExitPupil
                            {
                                BkgndBrightEye = 21.5,
                                ObjName = "California Nebula",
                                // change from 5 to 7 for purposes of the test
                                ObjMag = 7,
                                MaxObjArcmin = 145,
                                MinObjArcmin = 40,
                                ApparentFoV = 100,
                                DisplayConsoleMessages = true,
                            };

            mabep.Calc();
            Assert.Equal(10, mabep.MinimumApertureIn);
            Assert.Equal(2, mabep.BestExitPupilmm);

            // test for not visible
            mabep.ObjMag = 15;
            mabep.Calc();
            Assert.Equal(0, mabep.MinimumApertureIn);
            Assert.Equal(0, mabep.BestExitPupilmm);
           
            // test where low and high apertures converge to same aperture that is not visible (a previous aperture was visible)
            mabep.ObjMag = 12.9;
            mabep.MaxObjArcmin = 1.2;
            mabep.MinObjArcmin = 1.1;
            mabep.Calc();
            Assert.Equal(5, mabep.MinimumApertureIn);
            Assert.Equal(3, mabep.BestExitPupilmm);     
            
            Assert.True(true);
        }

        private static ExitPupilSequence GetEps()
        {
            var eps = new ExitPupilSequence
                          {
                              ApertureIn = 13,
                              BkgndBrightEye = 21.5,
                              ObjName = "California Nebula",
                              ObjMag = 5,
                              MaxObjArcmin = 145,
                              MinObjArcmin = 40,
                              ApparentFoV = 100,
                          };
            eps.Generate();
            eps.DisplayResults();
            return eps;
        }

        private static ExitPupilSequence GetEpsBelowThreshold()
        {
            var eps = new ExitPupilSequence
                          {
                              ApertureIn = 13,
                              BkgndBrightEye = 21.5,
                              ObjName = "California Nebula",
                              ObjMag = 15,
                              MaxObjArcmin = 145,
                              MinObjArcmin = 40,
                              ApparentFoV = 100,
                          };
            eps.Generate();
            eps.DisplayResults();
            return eps;
        }
    }
}