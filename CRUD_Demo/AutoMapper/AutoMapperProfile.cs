using AutoMapper;
using CRUDDemo.DataAccessLayer.DbModels;
using CRUDDemo.Entities.CustomEntities;

namespace CRUDDemoWebAPI.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Users, DtoUsers>();
            CreateMap<DtoUsers, Users>();
        }
    }
}
