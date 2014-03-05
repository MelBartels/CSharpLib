using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenLib.SFT
{
    public class SFTContainer
    {
        // List added to in SFTPrototype.Build via public Add(), which is called by SFTPrototype ctor 

        public SFTContainer(Type facadeType)
        {
            FacadeType = facadeType;
            List = new List<ISFT>();
        }

        private List<ISFT> List { get; set; }

        public Type FacadeType { get; set; }
        public string FacadeName { get; set; }

        public void Add(ISFT isft)
        {
            List.Add(isft);
        }

        public Int32 Size()
        {
            return List.Count;
        }

        public ISFT FirstItem()
        {
            return List[0];
        }

        public IEnumerator Enumerator()
        {
            return List.GetEnumerator();
        }

        public ISFT Match(ISFT isft)
        {
            return List.Find(qISFT => qISFT == isft);
        }

        public ISFT Match(Int32 key)
        {
            return key < List.Count ? List[key] : null;
        }

        public ISFT Match(string @string)
        {
            return List.Find(isft => isft.Name == @string || isft.Description == @string);
        }

        public List<string> Descriptions()
        {
            return List.Select(isft => isft.Description).ToList();
        }

        public List<ISFT> ToList()
        {
            return List;
        }
    }
}