using System.Linq;
using API.DTOs;
using API.Models;
using API.Models.IdentityModels;
using API.Extensions;
using AutoMapper;
using API.DTOs.AdminDtos;

namespace API.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ApplicationUser, MemberDto>()
                //.ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src =>
                //    src.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<MemberUpdateDto, ApplicationUser>();
            CreateMap<RegisterDto, ApplicationUser>();
            CreateMap<Message, MessageDto>();
                //.ForMember(dest => dest.SenderPhotoUrl, opt => opt.MapFrom(src =>
                //    src.Sender.Photos.FirstOrDefault(x => x.IsMain).Url))
                //.ForMember(dest => dest.RecipientPhotoUrl, opt => opt.MapFrom(src =>
                //    src.Recipient.Photos.FirstOrDefault(x => x.IsMain).Url));
            CreateMap<MessageDto, Message>();
            CreateMap<Photo, PhotoDto>();
        }
    }
}