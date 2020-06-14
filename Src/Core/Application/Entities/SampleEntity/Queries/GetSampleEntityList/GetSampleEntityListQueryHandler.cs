using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Entities.SampleEntity.Queries.GetSampleEntityList
{
    public class GetSampleEntityListQueryHandler : IRequestHandler<GetSampleEntityListQuery, GetSampleEntityListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSampleEntityListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetSampleEntityListVm> Handle(GetSampleEntityListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var sampleEntities = await _context.SampleEntities
                    .ProjectTo<GetSampleEntityListDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                int sampleCount = sampleEntities.Count();

                var vm = new GetSampleEntityListVm
                {
                    SampleEntities = sampleEntities,
                    SampleCount = sampleCount
                };

                return vm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
