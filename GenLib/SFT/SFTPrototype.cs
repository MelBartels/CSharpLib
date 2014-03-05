using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GenLib.SFT
{
    public class SFTPrototype : ISFT
    {
        public SFTPrototype(Type facadeType, SFTContainer isftsEntity, string description)
            : this(facadeType, isftsEntity, description, null)
        {
        }

        // for inherited facades 
        public SFTPrototype(Type facadeType, SFTContainer isftsEntity, string description, object tag)
        {
            isftsEntity.FacadeType = facadeType;
            Build(isftsEntity, description, tag);
        }

        public SFTPrototype(SFTContainer isftsEntity, string description)
            : this(isftsEntity, description, null)
        {
        }

        public SFTPrototype(SFTContainer isftsEntity, string description, object tag)
        {
            Build(isftsEntity, description, tag);
        }

        protected SFTEntity SFTEntityInstance { get; set; }
        protected SFTContainer SFTContainer { get; set; }

        #region ISFT Members

        public string FacadeName
        {
            get { return SFTContainer.FacadeName; }
        }

        public string Name
        {
            get { return SFTEntityInstance.Name; }
        }

        public int Key
        {
            get { return SFTEntityInstance.Key; }
        }

        public string Description
        {
            get { return SFTEntityInstance.Description; }
        }

        public object Tag
        {
            get { return SFTEntityInstance.Tag; }
        }

        public ISFT FirstItem()
        {
            return SFTContainer.FirstItem();
        }

        public ISFT NextItem()
        {
            return SFTContainer.Match(SFTEntityInstance.Key + 1);
        }

        public int Size()
        {
            return SFTContainer.Size();
        }

        public IEnumerator Enumerator()
        {
            return SFTContainer.Enumerator();
        }

        public ISFT Match(ISFT isft)
        {
            return SFTContainer.Match(isft);
        }

        public ISFT Match(int key)
        {
            return SFTContainer.Match(key);
        }

        public ISFT Match(string @string)
        {
            return SFTContainer.Match(@string);
        }

        public List<string> Descriptions()
        {
            return SFTContainer.Descriptions();
        }

        public List<ISFT> ToList()
        {
            return SFTContainer.ToList();
        }

        #endregion

        public void Build(SFTContainer isftsEntity, string description, object tag)
        {
            //build List ISFTs entity

            SFTContainer = isftsEntity;
            SFTContainer.FacadeName = isftsEntity.FacadeType.FullName;
            SFTContainer.Add(this);

            // description set later after name found...
            SFTEntityInstance = new SFTEntity {Key = SFTContainer.Size() - 1, Tag = tag};

            // build support... 

            // get the facade's public items using reflection (names of the SFTs)
            var sftNames = SFTContainer.FacadeType
                .GetFields(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Static)
                .Select(f => f.Name)
                .ToList();

            // this method is called for each SFT, so process only if not yet processed;
            // eg, if SFTs are aaa bbb ccc, then 1st time through aaa is set, 
            // 2nd time through with aaa already set, set bbb,
            // final time through with aaa and bbb already set, finish by setting ccc;
            // go through each SFT, advancing the current field name pointer if field name already set, 
            // otherwise if SFT name is empty then add current field name 
            var eFieldName = sftNames.GetEnumerator();
            eFieldName.MoveNext();
            var isftEntity = SFTContainer.Enumerator();
            while (isftEntity.MoveNext())
            {
                var sftPrototype = isftEntity.Current as SFTPrototype;
                if (sftPrototype == null || string.IsNullOrEmpty(sftPrototype.Name))
                {
                    SFTEntityInstance.Name = eFieldName.Current;
                    break;
                }
                // conditional necessary for extended SFTs; 
                // extended SFTs need to skip over base ISFTEntity's before advancing the SFT field name
                if (sftPrototype.Name == eFieldName.Current)
                    eFieldName.MoveNext();
            }
            // if description empty, then set it to name
            SFTEntityInstance.Description = String.IsNullOrEmpty(description) ? SFTEntityInstance.Name : description;
        }

        #region Nested type: SFTEntity

        protected class SFTEntity
        {
            public Int32 Key { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public object Tag { get; set; }
        }

        #endregion
    }
}