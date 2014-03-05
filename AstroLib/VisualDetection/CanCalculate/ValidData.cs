namespace AstroLib.VisualDetection.CanCalculate
{
    public class ValidData
    {
        public bool Magnitude { get; set; }
        public bool MagnitudeRange { get; set; }
        public bool MajorSize { get; set; }
        public bool MinorSize { get; set; }

        public bool IsValid()
        {
            return Magnitude && MagnitudeRange && MajorSize;
        }
    }
}