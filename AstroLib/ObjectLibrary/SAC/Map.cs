using AutoMapper;
using GenLib.Extensions;

namespace AstroLib.ObjectLibrary.SAC
{
    public class Map
    {
        public void Create()
        {
            Mapper.CreateMap<Record, DisplayRecord>()
                .ForMember(dest => dest.Name, o => o.MapFrom(src => src.OBJECT))
                .ForMember(dest => dest.OtherName, o => o.MapFrom(src => src.OTHER))
                .ForMember(dest => dest.Type, o => o.MapFrom(src => src.TYPE))
                .ForMember(dest => dest.Constellation, o => o.MapFrom(src => src.CON))
                .ForMember(dest => dest.RightAscensionGroup, o => o.MapFrom(CalcRightAscensionGroup))
                .ForMember(dest => dest.DeclinationGroup, o => o.MapFrom(CalcDeclinationGroup))
                .ForMember(dest => dest.RightAscension, o => o.MapFrom(src => src.RA))
                .ForMember(dest => dest.Declination, o => o.MapFrom(src => src.DEC))
                .ForMember(dest => dest.Magnitude, o => o.MapFrom(src => src.MAG))
                .ForMember(dest => dest.SurfaceBrightness, o => o.MapFrom(src => src.SUBR))
                .ForMember(dest => dest.UranometriaChart, o => o.MapFrom(src => src.U2K))
                .ForMember(dest => dest.TirionChart, o => o.MapFrom(src => src.TI))
                .ForMember(dest => dest.MajorAxisSize, o => o.MapFrom(src => src.SIZE_MAX))
                .ForMember(dest => dest.MinorAxisSize, o => o.MapFrom(src => src.SIZE_MIN))
                .ForMember(dest => dest.PositionAngle, o => o.MapFrom(src => src.PA))
                .ForMember(dest => dest.Classification, o => o.MapFrom(src => src.CLASS))
                .ForMember(dest => dest.ClusterStarCount, o => o.MapFrom(src => src.NSTS))
                .ForMember(dest => dest.ClusterBrightestStar, o => o.MapFrom(src => src.BRSTR))
                .ForMember(dest => dest.IncludedCatalogs, o => o.MapFrom(src => src.BCHM))
                .ForMember(dest => dest.Description, o => o.MapFrom(src => src.NGC_DESCR))
                .ForMember(dest => dest.Notes, o => o.MapFrom(src => src.NOTES));
        }

        private static string CalcRightAscensionGroup(Record record)
        {
            return record.RA.Split(":".ToCharArray())[0].Trim();
        }

        private static string CalcDeclinationGroup(Record record)
        {
            int group;
            return (int.TryParse(record.DEC.Split(":".ToCharArray())[0], out group))
                .Return((group/10*10).ToString(), string.Empty);
        }
    }
}