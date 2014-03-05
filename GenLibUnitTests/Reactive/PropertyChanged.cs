using System;
using System.ComponentModel;
using GenLib.Extensions;
using Xunit;

namespace GenLibUnitTests.Reactive
{
    public class PropertyChanged
    {
        [Fact]
        public void ViaNotifyPropertyChanged()
        {
            TestIFoo(new Foo());
        }

        [Fact]
        public void ViaEvent()
        {
            TestIFoo(new Foo2()); 
        }

        private static void TestIFoo(IFoo foo)
        {
            const string testValue = "123";
            var result = string.Empty;

            foo.FromPropertyChanged(o => o.MyStringProperty)
                .Subscribe(value => result = value);

            foo.MyStringProperty = testValue;
            Assert.Equal(testValue, result);
            // setter above increments Count as does the extension when it gets the property value
            Assert.Equal(2, foo.Count);

            Assert.True(true);
        }

        [Fact]
        public void Exceptions()
        {
            try
            {
                new object().FromPropertyChanged(o => o.ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Equal("The expression does not reference a property.", ex.Message);
            }

            try
            {
                new int[2].FromPropertyChanged(i => i.IsFixedSize);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Equal("The property does not support change events.", ex.Message);
            }
        }
    }

    internal interface IFoo
    {
        string MyStringProperty { get; set; }
        string SecondProp { get; set; }
        int Count { get; set; }
    }

    internal class Foo : INotifyPropertyChanged, IFoo
    {
        private string _myStringProperty;
        private string _secondProp;

        #region IFoo Members

        public string SecondProp
        {
            get
            {
                Count++;
                return _secondProp;
            }
            set
            {
                Count++;
                _secondProp = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SecondProp"));
            }
        }

        public int Count { get; set; }

        public string MyStringProperty
        {
            get
            {
                Count++;
                return _myStringProperty;
            }
            set
            {
                Count++;
                _myStringProperty = value;
                // must use name of property
                PropertyChanged(this, new PropertyChangedEventArgs("MyStringProperty"));
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }

    internal class Foo2 : IFoo
    {
        private string _myStringProperty;
        private string _secondProp;

        #region IFoo Members

        public string SecondProp
        {
            get
            {
                Count++;
                return _secondProp; 
            }
            set
            {
                Count++;
                _secondProp = value;
                SecondPropChanged(this, EventArgs.Empty);
            }
        }

        public int Count { get; set; }

        public string MyStringProperty
        {
            get
            {
                Count++;
                return _myStringProperty;
            }
            set
            {
                Count++;
                _myStringProperty = value;
                MyStringPropertyChanged(this, EventArgs.Empty);
            }
        }

        #endregion

        // must use the name of the property followed by by the word 'Changed'
        public event EventHandler MyStringPropertyChanged;
        public event EventHandler SecondPropChanged;
    }
}