using API.DTOs.SettingDtos;
using API.Models.AppDevModels.Settings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Profiles
{
    public class SettingProfiles : Profile
    {
        public SettingProfiles()
        {
            CreateMap<DesignRecordDto, DesignRecord>().ReverseMap();

        }

    }
}
