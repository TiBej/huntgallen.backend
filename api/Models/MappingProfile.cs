using api.Dto;
using AutoMapper;

namespace api
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<QR,QRDtoGet>();
            CreateMap<History, HistoryDtoGet>()
                .ForMember(dest => dest.Points, opt => opt.MapFrom(src => src.QR.Points))
                .ForMember(dest => dest.QRDesription, opt => opt.MapFrom(src => src.QR.Description));
            CreateMap<Reward, RewardDtoGet>();
        }
    }
}