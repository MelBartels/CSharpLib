using System;
using System.Collections;
using System.Collections.Generic;

namespace GenLib.SFT
{
    public interface ISFT
    {
        string FacadeName { get; }
        Int32 Key { get; }
        string Name { get; }
        string Description { get; }
        object Tag { get; }
        ISFT FirstItem();
        ISFT NextItem();
        Int32 Size();
        IEnumerator Enumerator();
        ISFT Match(ISFT isft);
        ISFT Match(Int32 key);
        ISFT Match(string @string);
        List<string> Descriptions();
        List<ISFT> ToList();
    }
}