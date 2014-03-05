using System;
using System.Collections.Generic;

namespace GenLib.SFT
{
    public interface ISFTFacade
    {
        ISFT FirstItem { get; }
        ISFT SelectedItem { get; set; }
        List<ISFT> SelectedItems { get; set; }
        ISFTFacade SetSelectedItem(ISFT isft);
        ISFTFacade SetSelectedItem(string name);
        ISFTFacade SetSelectedItem(Int32 key);
    }
}