using System.Linq;
using AstroLib.ObjectLibrary.Description;
using AstroLib.ObjectLibrary.SAC;
using Xunit;
using Record = AstroLib.ObjectLibrary.SAC.Record;

namespace AstroLibUnitTests
{
    public class ObjectLibrary
    {
        [Fact]
        public void Descriptions()
        {
            var lookup = new Lookup();

            Assert.Equal("very faint, very small, round",
                         lookup.GetFrom("vF, vS, R"));

            Assert.Equal("bright, very large, very much elongated/extended",
                         lookup.GetFrom("B, vL, vmE"));

            Assert.Equal("remarkable object, very bright, small",
                         lookup.GetFrom("!, vB, S"));

            Assert.Equal("remarkable object, bright, very rich, much compressed",
                         lookup.GetFrom("!  B, vRi, mC"));

            Assert.Equal(
                "very faint, very small, very little/long elongated/extended, 2 very faint stars involved/involving",
                lookup.GetFrom("vF;vS;vlE;2 vf st inv"));

            Assert.Equal(
                "extremely/very remarkable object, bright, very large, much brighter middle, well resolved clearly consisting of stars, stars magnitude 13",
                lookup.GetFrom("!! B, vL, mbM, rrr, stars mags 13"));

            Assert.Equal("pretty bright, pretty large, elongated in position angle 50 degrees, 2 stars preceding",
                         lookup.GetFrom("pB,pL,E50,2 st p"));

            Assert.Equal("pretty bright, pretty large, elongated/extended 0 degrees",
                         lookup.GetFrom("pB;pL;E 0 degrees"));

            Assert.Equal("very faint, small, round, star 13th magnitude attached following",
                         lookup.GetFrom("vF;S;R;*13 att f"));

            Assert.Equal(
                "extremely/excessively faint, very small, irregular round, suddenly/south brighter middle Nucleus or to a Nucleus, star?",
                lookup.GetFrom("eF;vS;iR;sbMN;(?*)"));

            Assert.Equal(
                "faint, very small, round, gradually brighter middle, star 10th magnitude preceding 8 arcminutes",
                lookup.GetFrom("F;vS;R;gbM;* 10 p 8'"));

            Assert.Equal("pretty faint, pretty small, much elongated/extended 145 degree, considerably brighter middle",
                         lookup.GetFrom("pF;pS;mE 145 deg;cbM"));

            Assert.Equal(
                "Globular Cluster, very bright, very large, extremely/excessively compressed middle, well resolved clearly consisting of stars, stars small",
                lookup.GetFrom("GC, vB, vL, eCM, rrr, st S"));

            Assert.Equal(
                "pretty bright, very small, elongated/extended, very suddenly/south brighter middle, star 9th magnitude preceding 5 suddenly/south",
                lookup.GetFrom("pB;vS;E;vsbM;*9 p 5s"));

            Assert.Equal("very faint, small, star 7th magnitude 4 arcminutes following",
                         lookup.GetFrom("vF;S;* 7 mag 4' foll"));

            Assert.Equal(
                "13 arcseconds - extremely/excessively faint, pretty large, in two parts with 5 stars involved/involving at 100X with UHC",
                lookup.GetFrom("13''-eF; pL; in two parts with 5* invl at 100X with UHC"));

            Assert.Equal(
                "very small cluster, star 10th magnitude preceding 1 suddenly/south, suddenly/south 1 arcminutes 29 arcseconds",
                lookup.GetFrom("vS Cl;*10p1s;s1'29''"));

            Assert.Equal(
                "pretty faint, very small, round, very much brighter middle, star 11th magnitude preceding 2 arcseconds",
                lookup.GetFrom("pF;vS;R;vmbM;*11p2''"));

            Assert.Equal("pretty bright, round, very smaller brighter middle, 2 or 3 stars involved/involving",
                         lookup.GetFrom("pB;R;vsmbM;2or3*inv"));

            Assert.Equal(
                "13 arcseconds - extremely/excessively faint, small, round at 100X, triangle of 11th magnitude stars to southwest",
                lookup.GetFrom("13''-eF; S; R at 100X; triangle of 11m * to SW"));

            Assert.Equal("(very small cluster)",
                         lookup.GetFrom("(vS cl)"));

            Assert.Equal("7 stars 135X",
                         lookup.GetFrom("7* 135X"));

            Assert.Equal("star 12.3th magnitude very small",
                         lookup.GetFrom("*12.3 vS"));

            Assert.True(true);
        }

        [Fact]
        public void DescriptionsToFix()
        {
            Assert.True(true);
        }

        [Fact]
        public void Classification()
        {
            var c = new Classification();

            Assert.Equal("elliptical",
                         c.GetFrom("GALXY", "Elliptical"));

            Assert.Equal("elliptical - lenticular ring",
                         c.GetFrom("GALXY", "E-SO Ring"));

            Assert.Equal("barred spiral moderately wound arms",
                         c.GetFrom("GALXY", "SBb"));

            Assert.Equal("barred spiral lenticular - tightly wound arms",
                         c.GetFrom("GALXY", "SBO-a"));

            Assert.Equal("elliptical - lenticular with central bar",
                         c.GetFrom("GALXY", "E-SO Bar"));

            Assert.Equal("elliptical peculiar",
                         c.GetFrom("GALXY", "E pec"));

            Assert.Equal("barred spiral / peculiar",
                         c.GetFrom("GALXY", "SB/P"));

            Assert.Equal("elliptical plus star",
                         c.GetFrom("GALXY", "E+*"));

            Assert.Equal("spiral (moderately wound arms) irregular Magellanic",
                         c.GetFrom("GALXY", "S(B)dm"));

            Assert.Equal("elliptical very round",
                         c.GetFrom("GALXY", "E0"));

            Assert.True(true);
        }

        [Fact]
        public void LoadObjectLibrary()
        {
            var records =
                new AstroLib.ObjectLibrary.SAC.Loader<Record>().Load(@"ObjectLibrary\SAC\SAC_DeepSky_Ver81_QCQ.TXT");
            Assert.Equal("OBJECT", records.First().OBJECT);
            Assert.Equal("NOTES", records.First().NOTES);

            Assert.True(true);
        }
    }
}