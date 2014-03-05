using GenLib.SFT;
using Xunit;

namespace GenLibUnitTests.SFT
{
    public class ZRunLastSFTInherited
    {
        private const int TestKey = 0;
        private const int ExtendedTestKey = 5;
        private const string NextTestName = "Bbb";
        private const string InheritedLastTestName = "Hhh";
        private const int TestInheritedSize = 6;

        private readonly ISFT _testIsft;
        private readonly ISFT _testIsftExtended;

        public ZRunLastSFTInherited()
        {
            _testIsft = new SFTTestObject().FirstItem;
            _testIsftExtended = new SFTInheritedTestObject().FirstItem;
        }

        [Fact]
        public void Inherit()
        {
            // demonstrate that the static member is complete when called statically; 
            Assert.NotNull(SFTInheritedTestObject.Hhh.Name);
            Assert.Equal(SFTInheritedTestObject.Hhh.Name, InheritedLastTestName);

            // test facade name 
            Assert.Equal(typeof (SFTInheritedTestObject).FullName, _testIsftExtended.FacadeName);
            // test size 
            Assert.Equal(TestInheritedSize, _testIsftExtended.Size());
            // test match methods 
            Assert.Equal(InheritedLastTestName, _testIsftExtended.Match(_testIsftExtended.Size() - 1).Name);
            Assert.Same(_testIsftExtended.FirstItem(), _testIsft.FirstItem());

            // test facade methods: SetSelected...SFT 
            var isftFacade2 = new SFTInheritedTestObject().SetSelectedItem(SFTInheritedTestObject.Hhh);
            Assert.NotNull(isftFacade2);
            Assert.Equal(InheritedLastTestName, isftFacade2.SelectedItem.Name);

            // test facade methods: SetSelected...Name 
            ISFTFacade isftFacade = new SFTInheritedTestObject();
            isftFacade.SetSelectedItem(NextTestName);
            Assert.Same(isftFacade.SelectedItem, SFTTestObject.Bbb);
            // use base class qualifier SFTTestObject instead of SFTInheritedTestObject
            Assert.Same(isftFacade.SelectedItem, SFTTestObject.Bbb);
            isftFacade.SetSelectedItem(InheritedLastTestName);
            Assert.Same(isftFacade.SelectedItem, SFTInheritedTestObject.Hhh);

            // test facade methods: SetSelected...Key 
            isftFacade = new SFTInheritedTestObject();
            isftFacade.SetSelectedItem(TestKey + 1);
            Assert.Same(isftFacade.SelectedItem, SFTTestObject.Bbb);
            isftFacade.SetSelectedItem(TestInheritedSize - 1);
            Assert.Same(isftFacade.SelectedItem, SFTInheritedTestObject.Hhh);

            // use base class qualifier SFTTestObject instead of SFTInheritedTestObject, ie, Assert.Same(SFTInheritedTestObject.Isft.Match(ExtendedTestKey)
            Assert.Same(SFTTestObject.Isft.Match(ExtendedTestKey), SFTTestObject.Isft.Match(ExtendedTestKey));

            Assert.True(true);
        }
    }
}