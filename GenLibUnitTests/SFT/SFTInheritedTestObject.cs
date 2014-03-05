using GenLib.SFT;

namespace GenLibUnitTests.SFT
{
    public class SFTInheritedTestObject : SFTTestObject
    {
        public static SFTPrototype Fff = new SFTPrototype(typeof (SFTInheritedTestObject), SFTContainer,
                                                          "description of Fff");

        public static SFTPrototype Ggg = new SFTPrototype(SFTContainer, "description of Ggg");
        public static SFTPrototype Hhh = new SFTPrototype(SFTContainer, "description of Hhh");
    }
}