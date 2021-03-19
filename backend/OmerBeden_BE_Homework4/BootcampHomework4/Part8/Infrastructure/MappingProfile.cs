using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Part8.Data.Entities;
using Part8.Data.Models;
using Part8.Data.Models.Derivered;

namespace Part8.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RoomEntity, Room>().ForMember(dst => dst.Rate,
                opt => opt.MapFrom(src => src.Rate / 100));


            CreateMap<UserEntity, UserInfo>().ForMember(dst => dst.FullName,
                opt => opt.MapFrom(src => string.Concat(src.Name, src.SurName)));
            
        }
    }
}
