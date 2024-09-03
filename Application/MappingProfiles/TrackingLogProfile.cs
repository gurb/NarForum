﻿using Application.Features.TrackingLog.Queries.GetTrackingLog;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class TrackingLogProfile : Profile
    {
        public TrackingLogProfile()
        {
            CreateMap<TrackingLogDTO, TrackingLog>().ReverseMap();
        }
    }
}
