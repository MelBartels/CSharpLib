using GenLib.Extensions;
using Xunit;

namespace GenLibUnitTests.Extension
{
    public class TupleExtension
    {
        [Fact]
        public void IncludeNumbers()
        {
            var nums = 5.Combine(10);
            Assert.Equal(5, nums.Item1);
            Assert.Equal(10, nums.Item2);

            Assert.True(true);
        }

        [Fact]
        public void IncludeNumbersFunc()
        {
            var nums = 5.Combine(i => i*10);
            Assert.Equal(5, nums.Item1);
            Assert.Equal(50, nums.Item2);

            Assert.True(true);
        }

        [Fact]
        public void IncludeBool()
        {
            var obj = false.Combine(true);
            Assert.False(obj.Item1);
            Assert.True(obj.Item2);

            Assert.True(true);
        }

        [Fact]
        public void Combine2()
        {
            var obj = 5.Combine(true);
            Assert.Equal(5, obj.Item1);
            Assert.True(obj.Item2);

            Assert.True(true);
        }

        [Fact]
        public void Combine3()
        {
            var obj = 5.Combine(true).Combine("A string");
            Assert.Equal(5, obj.Item1);
            Assert.True(obj.Item2);
            Assert.Equal("A string", obj.Item3);

            Assert.True(true);
        }

        [Fact]
        public void Combine4()
        {
            var obj = 5.Combine(true).Combine("A string").Combine(6.7);
            Assert.Equal(5, obj.Item1);
            Assert.True(obj.Item2);
            Assert.Equal("A string", obj.Item3);
            Assert.Equal(6.7, obj.Item4);

            Assert.True(true);
        }

        [Fact]
        public void CombineObjects()
        {
            var obj = new Airplane {Engine = new Engine {FuelType = "type1", FuelTypeTest = true, HasFuel = true}}
                .Combine(new Engine
                             {
                                 FuelType = "None",
                                 FuelTypeTest = false,
                                 HasFuel = false
                             });
            Assert.Equal("type1", obj.Item1.Engine.FuelType);
            Assert.Equal("None", obj.Item2.FuelType);
            Assert.False(obj.Item2.FuelTypeTest);
            Assert.False(obj.Item2.HasFuel);

            Assert.True(true);
        }

        [Fact]
        public void IncludeObjectsFunc()
        {
            var obj = new Airplane {Engine = new Engine {FuelType = "type1", FuelTypeTest = true, HasFuel = true}}
                .Combine(a => new Engine
                                  {
                                      FuelType = a.Engine.FuelType,
                                      FuelTypeTest = a.Engine.FuelTypeTest,
                                      HasFuel = a.Engine.HasFuel
                                  });
            Assert.Equal("type1", obj.Item1.Engine.FuelType);
            Assert.Equal("type1", obj.Item2.FuelType);
            Assert.True(obj.Item2.FuelTypeTest);
            Assert.True(obj.Item2.HasFuel);

            Assert.True(true);
        }
    }
}