using Application.Features.Report.Commands.CreateReport;
using Application.Features.Report.Queries.GetReport;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
    public class ReportProfile: Profile
    {

        public ReportProfile()
        {
            CreateMap<ReportDTO, Report>().ReverseMap();
            CreateMap<CreateReportCommand, Report>().ReverseMap();
        }
        
    }
}
