using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GenLib.Extensions;

namespace AstroLib.VisualDetection.Calculator
{
    public class ExitPupilSequence
    {
        private readonly List<int> _exitPupils = new List<int> {7, 6, 5, 4, 3, 2, 1};
        public List<Calc> Calcs = new List<Calc>();

        public ExitPupilSequence() : this(new CalcComparer())
        {
        }

        public ExitPupilSequence(CalcComparer calcComparer)
        {
            CalcComparer = calcComparer;
            _exitPupils.ForEach(_ => Calcs.Add(new Calc()));
            Mapper.CreateMap<ExitPupilSequence, Calc>();
        }

        private CalcComparer CalcComparer { get; set; }

        public double ApertureIn { get; set; }
        public double BkgndBrightEye { get; set; }
        public string ObjName { get; set; }
        public double ObjMag { get; set; }
        public double MaxObjArcmin { get; set; }
        public double MinObjArcmin { get; set; }
        public double ApparentFoV { get; set; }

        public void Generate()
        {
            _exitPupils.Each(GenerateCalc);
        }

        private void GenerateCalc(int ep, int ix)
        {
            Calcs[ix].Do(c => Mapper.Map(this, c))
                .Do(c => c.EyepieceExitPupilmm = ep)
                .Do(c => c.Generate());
        }

        public void DisplayResults()
        {
            Console.WriteLine(@"Log contrast differences for exit pupils within min/max magnification:");
            Calcs.ForEach(c =>
                              {
                                  Console.Write(@"  exit pupil " + c.EyepieceExitPupilmm + @"mm: ");
                                  if (c.X <= c.MaxXMaxObj)
                                      if (c.LogContrastDiff > 0)
                                          Console.WriteLine(c.LogContrastDiff
                                                            + @", X=" + (int) c.X
                                                            + @", apparent FoV=" + c.ActualFoV + @" deg");
                                      else
                                          Console.WriteLine(@"not detectable");
                                  else
                                      Console.WriteLine(@"object too big to fit");
                              });
            Console.WriteLine(@"best exit pupil "
                              + BestExitPupil().Return(e => e.EyepieceExitPupilmm + @"mm", "(invisible)"));
        }

        public Calc BestExitPupil(int apertureIn)
        {
            ApertureIn = apertureIn;
            Generate();
            return BestExitPupil();
        }

        public Calc BestExitPupil()
        {
            return new Calc()
                .Do(b => Calcs.ForEach(c => (CalcComparer.Compare(b, c) > 0)
                                               .Then(() => b.SetPropertiesFrom(c))))
                .If(b => b.LogContrastDiff > 0);
        }

        public ExitPupilSequence GetShallowCopy()
        {
            return this.CloneAndSetPropertiesFrom();
        }
    }
}