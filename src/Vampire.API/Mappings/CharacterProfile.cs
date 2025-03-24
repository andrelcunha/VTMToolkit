using System;
using AutoMapper;
using Vampire.API.Models;
using Vampire.Domain.Enums;
using Vampire.Domain.Models;

namespace Vampire.API.Mappings;

public class CharacterProfile : Profile
{
    public CharacterProfile()
    {
        // Character -> CharacterDto
        CreateMap<Character, CharacterDto>()
            .ForMember(dest => dest.Clan, opt => opt.MapFrom(src => src.Clan.ToString()))
            .ForMember(dest => dest.PredatorType, opt => opt.MapFrom(src => src.PredatorType.ToString()))
            .ForMember(dest => dest.Attributes, opt => opt.MapFrom(src => src.Attributes))
            .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.Skills))
            .ForMember(dest => dest.Disciplines, opt => opt.MapFrom(src => src.Disciplines))
            .ForMember(dest => dest.AdvantagesAndFlaws, opt => opt.MapFrom(src => src.AdvantagesAndFlaws))
            .ForMember(dest => dest.Touchstones, opt => opt.MapFrom(src => src.Touchstones))
            .ForMember(dest => dest.Convictions, opt => opt.MapFrom(src => src.Convictions));
    
        // CharacterDto -> Character
        CreateMap<CharacterDto, Character>()
            .ForMember(dest => dest.Clan, opt => opt.MapFrom(src => Enum.Parse<ClanType>(src.Clan)))
            .ForMember(dest => dest.PredatorType, opt => opt.MapFrom(src => Enum.Parse<PredatorType>(src.PredatorType)))
            .ForMember(dest => dest.Attributes, opt => opt.MapFrom(src => src.Attributes))
            .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.Skills))
            .ForMember(dest => dest.Disciplines, opt => opt.MapFrom(src => src.Disciplines))
            .ForMember(dest => dest.AdvantagesAndFlaws, opt => opt.MapFrom(src => src.AdvantagesAndFlaws))
            .ForMember(dest => dest.Touchstones, opt => opt.MapFrom(src => src.Touchstones))
            .ForMember(dest => dest.Convictions, opt => opt.MapFrom(src => src.Convictions));

        // Attributes -> AttribuitesDto
        CreateMap<Attributes, AttributesDto>().ReverseMap();

        // Discipline -> DisciplineDto
        CreateMap<Discipline, DisciplineDto>().ReverseMap();

        // AdvantageOrFlaw -> AdvantageOrFlawDto
        CreateMap<AdvantageOrFlaw, AdvantageOrFlawDto>().ReverseMap();

        // Touchstone -> TouchstoneDto
        CreateMap<Touchstone, TouchstoneDto>().ReverseMap();

        // Conviction -> ConvictionDto
        CreateMap<Conviction, ConvictionDto>().ReverseMap();
    }
}
