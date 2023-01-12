using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("This area sholud be filled.");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("This area sholud be filled.");
            RuleFor(x => x.BlogThumbnailImage).NotEmpty().WithMessage("This area sholud be filled.");

            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("This field has to be larger then 5 characters.");

        }
    }
}
