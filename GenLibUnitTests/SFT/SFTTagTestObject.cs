using GenLib.SFT;

namespace GenLibUnitTests.SFT
{
    public class SFTTagTestObject : SFTFacadeBase
    {
        protected static SFTContainer SFTContainer = new SFTContainer(typeof (SFTTagTestObject));

        public static SFTPrototype Lll = new SFTPrototype(SFTContainer, "description of Lll", 5);
        public static SFTPrototype Mmm = new SFTPrototype(SFTContainer, "description of Mmm", "good");
        public static SFTPrototype Nnn = new SFTPrototype(SFTContainer, "description of Nnn", SFTTestObject.Bbb);

        public override ISFT FirstItem
        {
            get { return SFTContainer.FirstItem(); }
        }

        public static ISFT Isft
        {
            get { return SFTContainer.FirstItem(); }
        }
    }
}