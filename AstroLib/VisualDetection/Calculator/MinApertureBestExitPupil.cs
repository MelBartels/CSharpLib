using AutoMapper;
using GenLib.Extensions;

namespace AstroLib.VisualDetection.Calculator
{
    public class MinApertureBestExitPupil
    {
        private const int Loops = 5;

        public MinApertureBestExitPupil(ExitPupilSequence exitPupilSequence)
        {
            ExitPupilSequence = exitPupilSequence;
            CalcState = new CalcState();
            Mapper.CreateMap<MinApertureBestExitPupil, ExitPupilSequence>();
        }

        public MinApertureBestExitPupil() : this(new ExitPupilSequence())
        {
        }

        private ExitPupilSequence ExitPupilSequence { get; set; }

        public double BkgndBrightEye { get; set; }
        public string ObjName { get; set; }
        public double ObjMag { get; set; }
        public double MaxObjArcmin { get; set; }
        public double MinObjArcmin { get; set; }
        public double ApparentFoV { get; set; }

        public bool DisplayConsoleMessages { get; set; }
        private CalcState CalcState { get; set; }

        public double MinimumApertureIn { get; set; }
        public double BestExitPupilmm { get; set; }

        public void Calc()
        {
            MinimumApertureIn = BestExitPupilmm = 0;
            CalcState.Init(DisplayConsoleMessages);
            Mapper.Map(this, ExitPupilSequence);

            Loops.Each().ForEach(_ => ExitPupilSequence.BestExitPupil(CalcState.HighWaterMark)
                                          .Branch(CalcState.IsVisibleReset, CalcState.NotVisible));
            
            CalcState.BestCalc.Do(SetResults);
        }

        private void SetResults(Calc c)
        {
            MinimumApertureIn = c.ApertureIn;
            BestExitPupilmm = c.EyepieceExitPupilmm;
        }
    }
}