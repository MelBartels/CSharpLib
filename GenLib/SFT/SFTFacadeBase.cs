using System.Collections.Generic;

namespace GenLib.SFT
{
    public abstract class SFTFacadeBase : ISFTFacade
    {
        protected SFTFacadeBase()
        {
            SelectedItems = new List<ISFT>();
        }

        #region ISFTFacade Members

        public abstract ISFT FirstItem { get; }

        public ISFT SelectedItem
        {
            get { return SelectedItems[0]; }
            set
            {
                SelectedItems.Clear();
                SelectedItems.Add(value);
            }
        }

        public List<ISFT> SelectedItems { get; set; }

        public ISFTFacade SetSelectedItem(ISFT isft)
        {
            SelectedItem = FirstItem.Match(isft);
            return this;
        }

        public ISFTFacade SetSelectedItem(string name)
        {
            SelectedItem = FirstItem.Match(name);
            return this;
        }

        public ISFTFacade SetSelectedItem(int key)
        {
            SelectedItem = FirstItem.Match(key);
            return this;
        }

        #endregion
    }
}