using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_QLHoSo_So.Model.Dto;
using Web_QLHoSo_So.Model.Entities;

namespace Web_QLHoSo_So.Model.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Kho, KhoDto>().ReverseMap();
        }
    }
}
