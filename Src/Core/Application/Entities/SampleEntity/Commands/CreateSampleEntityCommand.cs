using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.SampleEntity.Commands
{
    public class CreateSampleEntityCommand : IRequest<ResultModel>
    {
        public string SampleName { get; set; }
    }
}
