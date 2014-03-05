using System;

namespace GenLibUnitTests.Extension
{
    public interface IAirplane
    {
        Engine Engine { get; set; }
    }

    public class Jet : IAirplane
    {
        #region IAirplane Members

        public Engine Engine { get; set; }

        #endregion
    }

    public class Airplane : IAirplane
    {
        #region IAirplane Members

        public Engine Engine { get; set; }

        #endregion
    }

    public class Engine
    {
        public string FuelType { get; set; }
        public bool HasFuel { get; set; }
        public bool FuelTypeTest { get; set; }
        public Guid? Guid { get; set; }
    }

    public enum TestingEnum
    {
        TestingOne,
        TestingTwo,
        TestingThree
    }
}