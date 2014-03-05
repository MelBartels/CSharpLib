namespace AstroLib.Ronchi
{
    public class StringParms
    {
        public string MirrorDiameterInches;
        public string MirrorRCInches;
        public string GratingLinesPerInch;
        public string OffsetInches;
        public int Width;
        public int Height;
        public string Rays;

        public StringParms(string mirrorDiameterInches,
                             string mirrorRCInches,
                             string gratingLinesPerInch,
                             string offsetInches,
                             int width,
                             int height,
                             string rays)
        {
            MirrorDiameterInches = mirrorDiameterInches;
            MirrorRCInches = mirrorRCInches;
            GratingLinesPerInch = gratingLinesPerInch;
            OffsetInches = offsetInches;
            Width = width;
            Height = height;
            Rays = rays;
        }
    }
}