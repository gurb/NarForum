using Application.Features.SmtpSetting.Commands.UpdateSmtpSettings;
using Application.Features.SmtpSetting.Queries;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
    public class SmtpSettingsProfile : Profile
    {
        public SmtpSettingsProfile()
        {
            CreateMap<SmtpSettingsDTO, SmtpSettings>().ReverseMap();
            CreateMap<UpdateSmtpSettingsCommand, SmtpSettings>().ReverseMap();
        }
    }
}
