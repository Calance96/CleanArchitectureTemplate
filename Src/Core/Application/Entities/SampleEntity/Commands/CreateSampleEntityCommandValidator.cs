using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.SampleEntity.Commands
{
    public class CreateSampleEntityCommandValidator : AbstractValidator<CreateSampleEntityCommand>
    {
        public CreateSampleEntityCommandValidator()
        {
            RuleFor
                (SampleEntity => SampleEntity.SampleName)
                .NotEmpty().WithMessage("The sample entity name cannot be empty")
                .Length(1, 100);
        }
    }
}
