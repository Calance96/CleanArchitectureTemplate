using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Entities.SampleEntity.Commands
{
    public class CreateSampleEntityCommandHandler : IRequestHandler<CreateSampleEntityCommand, ResultModel>
    {
        private readonly IApplicationDbContext _context;

        public CreateSampleEntityCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResultModel> Handle(CreateSampleEntityCommand request, CancellationToken cancellationToken)
        {
            ResultModel result = new ResultModel { IsSuccess = false };

            try
            {
                var entity = new Domain.Entities.SampleEntity
                {
                    SampleName = request.SampleName
                };

                _context.SampleEntities.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);

                result.IsSuccess = true;
                result.Message = "Sample entity created successfully!";
            } 
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
