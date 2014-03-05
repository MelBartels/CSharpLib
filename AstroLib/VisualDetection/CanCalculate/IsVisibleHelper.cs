using System.Text;
using AstroLib.ObjectLibrary.SAC;
using GenLib.Extensions;
using GenLib.Helper;
using GenLib.MessageBox;

namespace AstroLib.VisualDetection.CanCalculate
{
    public class IsVisibleHelper
    {
        public IsVisibleHelper(ValidData validData)
        {
            ValidData = validData;
        }

        public IsVisibleHelper() : this(new ValidData())
        {
        }

        private ValidData ValidData { get; set; }
        public string ObjectName { get; set; }
        public double ObjectMagnitude { get; set; }
        public double ObjectSize1 { get; set; }
        public double ObjectSize2 { get; set; }

        public bool Calc(DisplayRecord dr)
        {
            double objMag;
            ValidData.Magnitude = double.TryParse(dr.Magnitude, out objMag);
            ValidData.MagnitudeRange = objMag < 20;

            var majorAxisSize = GetSizeValue(dr.MajorAxisSize);
            ValidData.MajorSize = !double.IsNaN(majorAxisSize);

            var minorAxisSize = GetSizeValue(dr.MinorAxisSize);
            ValidData.MinorSize = !double.IsNaN(minorAxisSize);

            return ValidData.IsValid().Then(() =>
                                                {
                                                    ObjectName = dr.Name;
                                                    ObjectMagnitude = objMag;
                                                    ObjectSize1 = majorAxisSize;
                                                    ObjectSize2 = ValidData.MinorSize.Return(() => minorAxisSize,
                                                                                             () => majorAxisSize);
                                                });
        }

        // 12.1 m returns 12.1; 30 s returns 0.5
        private static double GetSizeValue(string input)
        {
            var value = double.NaN;
            var st = new StringTokenizer();
            st.Tokenize(input, " ".ToCharArray());
            (st.Count == 2).Then(() =>
                                     {
                                         var num = st.NextToken();
                                         var uom = st.NextToken();
                                         double size;
                                         if (double.TryParse(num, out size))
                                             value = uom == "s" ? size/60 : size;
                                     });
            return value;
        }

        public void DisplayCouldNotCalcMsg()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Cannot calculate visual detection because:");
            ValidData.Magnitude.Else(() => sb.AppendLine("magnitude is missing"));
            ValidData.MagnitudeRange.Else(() => sb.AppendLine("magnitude is out of range"));
            ValidData.MajorSize.Else(() => sb.AppendLine("major axis size is missing"));
            ValidData.MinorSize.Else(() => sb.AppendLine("minor axis size is missing"));

            AppMessageBox.Show(sb.ToString());
        }
    }
}