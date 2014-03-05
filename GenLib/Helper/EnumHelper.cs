using System;
using System.Collections.Generic;
using System.Linq;

namespace GenLib.Helper
{
    public class EnumHelper
    {
        public object EnumName(Enum name, string value)
        {
            return Enum.Parse(name.GetType(), value);
        }

        public static List<T> GetList<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }
    }
}