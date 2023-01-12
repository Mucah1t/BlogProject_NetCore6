using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class WriterValidator:AbstractValidator<Writer>
	{
		public WriterValidator()
		{
			RuleFor(x => x.WriterName).NotEmpty().WithMessage("This field can not be empty.");
			RuleFor(x => x.WriterMail).NotEmpty().WithMessage("This field can not be empty.");
			RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("This field can not be empty.");
		}
	}
}
