using SeedtagRadar.Application.DTOs;
using SeedtagRadar.Domain.Entities;
using MapperProfile = AutoMapper.Profile;

namespace SeedtagRadar.Application
{
    public class Mapping : MapperProfile
    {
        public Mapping()
        {
            CreateMap<Point, PointDto>();
        }
    }
}