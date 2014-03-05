using System;
using GenLib.Extensions;
using GenLib.SFT;
using Xunit;

namespace GenLibUnitTests.SFT
{
    public class SFT
    {
        private const int TestKey = 0;
        private const string TestName = "Aaa";
        private const string TestDescription = "description of Aaa";
        private const int TestSize = 3;

        private readonly ISFT _testIsfTcopy;
        private readonly ISFT _testIsft;

        public SFT()
        {
            _testIsft = new SFTTestObject().FirstItem;
            _testIsfTcopy = new SFTTestObject().FirstItem;
        }

        [Fact]
        public void Descriptions()
        {
            Assert.Equal(TestDescription, _testIsft.FirstItem().Description);
            Assert.Equal(TestDescription, _testIsft.Descriptions()[0]);
            Assert.Equal(3, _testIsft.Descriptions().Count);

            Assert.True(true);
        }

        [Fact]
        public void Enumerator()
        {
            var count = 0;
            var eSft = _testIsft.Enumerator();
            while (eSft.MoveNext())
            {
                count++;
                Console.WriteLine("EnumeratorTest: current value is " + ((ISFT) eSft.Current).Name);
            }
            Assert.Equal(_testIsft.Size(), count);

            Assert.True(true);
        }

        [Fact]
        public void FacadeName()
        {
            Assert.Equal(_testIsft.FacadeName, typeof (SFTTestObject).FullName);

            Assert.True(true);
        }

        [Fact]
        public void FirstItemsSame()
        {
            Assert.Same(_testIsft.FirstItem(), _testIsfTcopy.FirstItem());

            Assert.True(true);
        }

        [Fact]
        public void Key()
        {
            Assert.Equal(_testIsft.FirstItem().Key, TestKey);
            Assert.Null(_testIsft.Match(TestSize));
            Assert.Equal(TestName, _testIsft.Match(TestKey).Name);
            Assert.Same(SFTTestObject.Isft.Match(TestKey), SFTTestObject.Isft.Match(TestKey));

            Assert.True(true);
        }

        [Fact]
        public void List()
        {
            var list = _testIsft.ToList();
            Assert.Equal(3, list.Count);
            Assert.Same(_testIsft.FirstItem(), list[0]);

            Assert.True(true);
        }

        [Fact]
        public void MatchString()
        {
            Assert.Equal(TestName, _testIsft.Match(TestName).Name);

            Assert.True(true);
        }

        [Fact]
        public void SelectedItem()
        {
            var isftFacade = new SFTTestObject();
            Assert.NotNull(isftFacade);
            isftFacade.SelectedItem = _testIsft.FirstItem().NextItem();
            Assert.Same(isftFacade.SelectedItem, SFTTestObject.Bbb);
            // get 2nd item a different way 
            Assert.Same(isftFacade.SelectedItem, _testIsft.FirstItem().NextItem());

            var isftFacade2 = new SFTTestObject();
            isftFacade2.SelectedItem = SFTTestObject.Aaa;
            Assert.Same(isftFacade2.SelectedItem, SFTTestObject.Aaa);
            // retest 1st template to demonstrate different template instances 
            Assert.Same(isftFacade.SelectedItem, _testIsft.FirstItem().NextItem());

            Assert.True(true);
        }

        [Fact]
        public void SelectedItems()
        {
            var isftFacade = new SFTTestObject();
            Assert.NotNull(isftFacade);
            isftFacade.SelectedItems.Add(_testIsft.FirstItem().NextItem());
            var found = false;

            isftFacade.SelectedItems
                .ForEach(i => ReferenceEquals(i, SFTTestObject.Bbb)
                                  .Then(() => found = true));
            Assert.True(found);

            Assert.True(true);
        }

        [Fact]
        public void SetSelectedItemByIsft()
        {
            var isftFacade2 = new SFTTestObject().SetSelectedItem(SFTTestObject.Bbb);
            Assert.NotNull(isftFacade2);
            Assert.Equal(SFTTestObject.Bbb.Name, isftFacade2.SelectedItem.Name);

            Assert.True(true);
        }

        [Fact]
        public void SetSelectedItemByKey()
        {
            var isftFacade = new SFTTestObject();
            isftFacade.SetSelectedItem(TestKey + 1);
            Assert.Same(isftFacade.SelectedItem, SFTTestObject.Bbb);

            Assert.True(true);
        }

        [Fact]
        public void SetSelectedItemByName()
        {
            var isftFacade = new SFTTestObject();
            // ... by name 
            isftFacade.SetSelectedItem(SFTTestObject.Bbb.Name);
            Assert.Same(isftFacade.SelectedItem, SFTTestObject.Bbb);

            Assert.True(true);
        }
    }
}