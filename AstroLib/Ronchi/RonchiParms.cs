namespace AstroLib.Ronchi
{
    public class RonchiParms
    {
        public double MirrorDiameterInches;
        public double RCinches;
        public double GratingLinesPerInch;
        public double GratingOffsetFromRCinches;
        public double ParabolicCorrectionFactor;
        public double RaysToPlot;

        public RonchiParms(double mirrorDiameterInches,
                     double RCinches,
                     double gratingLinesPerInch,
                     double gratingOffsetFromRCinches,
                     double parabolicCorrectionFactor,
                     double raysToPlot)
        {
            MirrorDiameterInches = mirrorDiameterInches;
            this.RCinches = RCinches;
            GratingLinesPerInch = gratingLinesPerInch;
            GratingOffsetFromRCinches = gratingOffsetFromRCinches;
            ParabolicCorrectionFactor = parabolicCorrectionFactor;
            RaysToPlot = raysToPlot;
        }
    }
}