using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("This field connot be empty.");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Category description has to be filled.");
          
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("category adını Lütfen en az 2 karakter girişi yapınız");

        }
    }
}
