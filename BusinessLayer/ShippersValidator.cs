using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using FluentValidation;

namespace BusinessLayer
{
    public class ShippersValidator:AbstractValidator<Shippers>
    {
        public ShippersValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("CompanyName Boş Giremezsiniz");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone Boş Giremezsiniz");
        }
    }
}
