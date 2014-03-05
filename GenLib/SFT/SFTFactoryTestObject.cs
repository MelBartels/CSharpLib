namespace GenLib.SFT
{
    public class SFTFactoryTestObject : SFTFacadeBase
    {
        protected static SFTContainer SFTContainer = new SFTContainer(typeof (SFTFactoryTestObject));

        public SFTPrototype aaa = new SFTPrototype(SFTContainer, "description of aaa");
        public SFTPrototype bbb = new SFTPrototype(SFTContainer, "description of bbb");
        public SFTPrototype ccc = new SFTPrototype(SFTContainer, "description of ccc");

        public override ISFT FirstItem
        {
            get { return SFTContainer.FirstItem(); }
        }

        public ISFT ISFT
        {
            get { return SFTContainer.FirstItem(); }
        }
    }
}