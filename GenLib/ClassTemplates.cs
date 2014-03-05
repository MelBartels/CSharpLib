namespace GenLib
{
    public class SingletonClassTemplate
    {
        private SingletonClassTemplate()
        {
        }

        public static SingletonClassTemplate Instance()
        {
            return Nested.NestedInstance;
        }

        #region Nested type: NestedInstance

        private class Nested
        {
            // explicit constructor informs compiler not to mark type as beforefieldinit
            static Nested() { }

            internal static readonly SingletonClassTemplate NestedInstance = new SingletonClassTemplate();
        }

        #endregion
    }

    public class NullClassTemplate
    {
        public static NullClassTemplate GetNullInstance()
        {
            return new SubClass();
        }

        #region Nested type: SubClass

        private class SubClass : NullClassTemplate
        {
            // add overrides of NullClassTemplate methods here that will do nothing
        }

        #endregion
    }
}