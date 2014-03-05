using GenLib.SFT;

namespace GenLibUnitTests.SFT
{
    public class SFTSingleItemTestObject : SFTFacadeBase
    {
        protected static SFTContainer SFTContainer = new SFTContainer(typeof (SFTSingleItemTestObject));

        public static SFTPrototype Aaa = new SFTPrototype(SFTContainer, "description of Aaa");

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