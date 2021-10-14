using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace BusinessLayer
{
    public class CustomersValidator : AbstractValidator<Customers>
    {
        public CustomersValidator()
        {
            RuleFor(x => x.CustomerID).NotEmpty().WithMessage("CustomerID Alanını Boş Bırakmayınız.");
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("CompanyName Boş Giremezsiniz");
            RuleFor(x => x.ContactName).NotEmpty().WithMessage("ContactName Boş Giremezsiniz");
            RuleFor(x => x.ContactTitle).NotEmpty().WithMessage("ContactTitle Boş Giremezsiniz");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address Boş Giremezsiniz");
            RuleFor(x => x.City).NotEmpty().WithMessage("City Boş Giremezsiniz");
            RuleFor(x => x.Region).NotEmpty().WithMessage("Region Boş Giremezsiniz");
            RuleFor(x => x.PostalCode).NotEmpty().WithMessage("PostalCode Boş Giremezsiniz");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Country Boş Giremezsiniz");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone Boş Giremezsiniz");
            RuleFor(x => x.Fax).NotEmpty().WithMessage("Fax Boş Giremezsiniz");
        }
    }
}
