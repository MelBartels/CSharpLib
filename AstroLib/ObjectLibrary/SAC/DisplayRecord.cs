namespace AstroLib.ObjectLibrary.SAC
{
    public class DisplayRecord
    {
        public string Name { get; set; }
        public string OtherName { get; set; }
        public string Type { get; set; }
        public string Constellation { get; set; }
        public string RightAscensionGroup { get; set; }
        public string DeclinationGroup { get; set; }
        public string RightAscension { get; set; }
        public string Declination { get; set; }
        public string Magnitude { get; set; }
        public string SurfaceBrightness { get; set; }
        public string UranometriaChart { get; set; }
        public string TirionChart { get; set; }
        public string MajorAxisSize { get; set; }
        public string MinorAxisSize { get; set; }
        public string PositionAngle { get; set; }
        public string Classification { get; set; }
        public string ClusterStarCount { get; set; }
        public string ClusterBrightestStar { get; set; }
        public string IncludedCatalogs { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public double MinimumAperture { get; set; }
        public double BestExitPupil { get; set; }
    }
}