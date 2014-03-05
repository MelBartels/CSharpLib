using GenLib.SFT;

namespace GenLibUnitTests.SFT
{
    public class SFTSecondTestObject : SFTFacadeBase
    {
        protected static SFTContainer SFTContainer = new SFTContainer(typeof (SFTSecondTestObject));

        public static SFTPrototype Ddd = new SFTPrototype(SFTContainer, "description of Ddd");
        public static SFTPrototype Eee = new SFTPrototype(SFTContainer, "description of Eee");
        public static SFTPrototype Fff = new SFTPrototype(SFTContainer, "description of Fff");

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