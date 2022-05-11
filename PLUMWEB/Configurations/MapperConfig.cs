using AutoMapper;
using PLUMWEB.Data;
using PLUMWEB.Data.Models;

namespace PLUMWEB.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Produce, ProduceVM>().ReverseMap();
        }
    }
}
