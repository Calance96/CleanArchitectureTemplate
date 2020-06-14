using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.SampleEntity.Queries.GetSampleEntityList
{
    public class GetSampleEntityListVm
    {
        public IList<GetSampleEntityListDto> SampleEntities { get; set; } 

        public int SampleCount { get; set; }
    }
}
