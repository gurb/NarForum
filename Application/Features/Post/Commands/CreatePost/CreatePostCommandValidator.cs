using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Post.Commands.CreatePost
{
    public class CreatePostCommandValidator: AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator() 
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("{Content} is required")
                .NotNull()
                .MaximumLength(10000).WithMessage("{Content} must bw fewer than 10000 characters");
        }

    }
}
