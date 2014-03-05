using FileHelpers;

namespace AstroLib.ObjectLibrary.Description
{
    [DelimitedRecord(",")]
    public class Record
    {
        [FieldTrim(TrimMode.Both)] public string Key;
        [FieldTrim(TrimMode.Both)] public string Value;
    }
}