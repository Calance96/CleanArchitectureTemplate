using Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.SampleEntity.Queries.GetSampleEntityList
{
    public class GetSampleEntityListDto : IMapFrom<Domain.Entities.SampleEntity>
    {
        public int Id { get; set; } 
        public string SampleName { get; set; }

        public void Mapping(Profile profile)
        {
            // SAMPLE ONLY
            // If property names are the same for source entity and destination DTO, this is not necessary
            profile.CreateMap<Domain.Entities.SampleEntity, GetSampleEntityListDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.SampleName, opt => opt.MapFrom(s => s.SampleName));
        }
    }
}
