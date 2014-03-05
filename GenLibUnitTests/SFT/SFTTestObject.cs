using GenLib.SFT;

namespace GenLibUnitTests.SFT
{
    public class SFTTestObject : SFTFacadeBase
    {
        protected static SFTContainer SFTContainer = new SFTContainer(typeof (SFTTestObject));

        public static SFTPrototype Aaa = new SFTPrototype(SFTContainer, "description of Aaa");
        public static SFTPrototype Bbb = new SFTPrototype(SFTContainer, "description of Bbb");
        public static SFTPrototype Ccc = new SFTPrototype(SFTContainer, "description of Ccc");

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