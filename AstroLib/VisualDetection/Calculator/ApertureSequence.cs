using System;
using System.Collections.Generic;
using AutoMapper;
using GenLib.Helper;

namespace AstroLib.VisualDetection.Calculator
{
    public class ApertureSequence
    {
        public readonly List<ExitPupilSequence> ExitPupilSequences = new List<ExitPupilSequence>();

        public ApertureSequence() : this(new EMath())
        {
        }

        public ApertureSequence(EMath eMath)
        {
            EMath = eMath;
            Mapper.CreateMap<ApertureSequence, ExitPupilSequence>();
        }

        private EMath EMath { get; set; }

        public double ApertureIn { get; set; }
        public double BkgndBrightEye { get; set; }
        public string ObjName { get; set; }
        public double ObjMag { get; set; }
        public double MaxObjArcmin { get; set; }
        public double MinObjArcmin { get; set; }
        public double ApparentFoV { get; set; }

        public void Generate()
        {
            var eps = Mapper.Map<ApertureSequence, ExitPupilSequence>(this);
            eps.Generate();

            var epsHalf = eps.GetShallowCopy();
            epsHalf.ApertureIn = EMath.RInt(epsHalf.ApertureIn/2);
            epsHalf.Generate();

            var epsDouble = eps.GetShallowCopy();
            epsDouble.ApertureIn = EMath.RInt(epsDouble.ApertureIn*2);
            epsDouble.Generate();

            ExitPupilSequences.Clear();
            ExitPupilSequences.Add(epsDouble);
            ExitPupilSequences.Add(eps);
            ExitPupilSequences.Add(epsHalf);
        }

        public void DisplayResults()
        {
            Console.WriteLine(@"Log contrast differences for apertures:");
            ExitPupilSequences.ForEach(eps =>
                                           {
                                               Console.WriteLine(@"Aperture = " + eps.ApertureIn);
                                               eps.DisplayResults();
                                               Console.WriteLine(string.Empty);
                                           });
        }
    }
}