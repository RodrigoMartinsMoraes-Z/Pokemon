using AutoMapper;

using Pokemon.Domain.Masters;
using Pokemon.Models.Masters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.AutoMapper
{
    public class MasterMappingProfile : Profile
    {
        public MasterMappingProfile()
        {
            CreateMap<MasterModel, Master>().ForMember(dest => dest.PokeList, opt => opt.Ignore());
            CreateMap<Master, MasterModel>().ForMember(dest => dest.PokeList, opt => opt.Ignore());
        }
    }
}
