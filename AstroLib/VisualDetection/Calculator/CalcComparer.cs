using System.Collections.Generic;

namespace AstroLib.VisualDetection.Calculator
{
    public class CalcComparer : IComparer<Calc>
    {
        #region IComparer<Calc> Members

        public int Compare(Calc x, Calc y)
        {
            var tooBigToFitComparison = (y.X <= y.MaxXMaxObj).CompareTo(x.X <= x.MaxXMaxObj);
            var logContrastDiffComparison = y.LogContrastDiff.CompareTo(x.LogContrastDiff);
            return tooBigToFitComparison == 0 ? logContrastDiffComparison : tooBigToFitComparison;
        }

        #endregion
    }
}