using AutoMapper;
using Exchange.Api.Models;
using Exchange.Api.Models.Dtos;
using Exchange.Api.Models.Entities;
using Exchange.Models.Api.Dtos;

namespace Exchange.Api.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
              CreateMap<InstructionDto, Instruction>().ForMember(s=>s.Coin,t=>t.Ignore()).ReverseMap();
              CreateMap<InstructionCreateDto, Instruction>().ReverseMap();
              CreateMap<NotificationTemplateDto, NotificationTemplate>().ReverseMap();;
        }
    }
}