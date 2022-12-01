using FluentValidation;
using RealEstate.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.BusinessLayer.ValidationRules
{
    public class MemberValidator : AbstractValidator<Member>
    {
        public MemberValidator()
        {
            RuleFor(x => x.MemberName).NotEmpty().WithMessage("Lütfen Ad Alanını boş Geçmeyin");
            RuleFor(x => x.MemberSurname).NotEmpty().WithMessage("Lütfen Soy adı alanını Boş geçmeyin");
            RuleFor(x => x.MemberName).MinimumLength(3).WithMessage("Lütfen En az 3 karakter girin ");
            RuleFor(x => x.MemberName).MaximumLength(20).WithMessage("Lütfen çok 20 karakter girin ");


        }
    }
}
