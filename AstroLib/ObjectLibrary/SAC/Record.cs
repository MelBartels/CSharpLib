using FileHelpers;

namespace AstroLib.ObjectLibrary.SAC
{
    [DelimitedRecord(",")]
    public class Record
    {
// ReSharper disable InconsistentNaming
        // remove quotes from fields, trim spaces, eg, input record: "OBJECT           ","OTHER             "...
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)] [FieldTrim(TrimMode.Both)] public string OBJECT;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)] [FieldTrim(TrimMode.Both)] public string OTHER;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)] [FieldTrim(TrimMode.Both)] public string TYPE;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)] [FieldTrim(TrimMode.Both)] public string CON;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)] [FieldTrim(TrimMode.Both)] public string RA;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)] [FieldTrim(TrimMode.Both)] public string DEC;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)] [FieldTrim(TrimMode.Both)] public string MAG;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)] [FieldTrim(TrimMode.Both)] public string SUBR;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)] [FieldTrim(TrimMode.Both)] public string U2K;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)] [FieldTrim(TrimMode.Both)] public string TI;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)] [FieldTrim(TrimMode.Both)] public string SIZE_MAX;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)] [FieldTrim(TrimMode.Both)] public string SIZE_MIN;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)] [FieldTrim(TrimMode.Both)] public string PA;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)] [FieldTrim(TrimMode.Both)] public string CLASS;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)] [FieldTrim(TrimMode.Both)] public string NSTS;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)] [FieldTrim(TrimMode.Both)] public string BRSTR;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)] [FieldTrim(TrimMode.Both)] public string BCHM;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)] [FieldTrim(TrimMode.Both)] public string NGC_DESCR;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)] [FieldTrim(TrimMode.Both)] public string NOTES;
// ReSharper restore InconsistentNaming
    }
}