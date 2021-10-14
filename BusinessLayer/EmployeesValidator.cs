using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using FluentValidation;

namespace BusinessLayer
{
    public class EmployeesValidator : AbstractValidator<Employees>
    {
        public EmployeesValidator()
        {
            RuleFor(x => x.EmployeeID).NotEmpty().WithMessage("EmployeeID Alanını Boş Bırakmayınız.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName Boş Giremezsiniz");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName Boş Giremezsiniz");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title Boş Giremezsiniz");
            RuleFor(x => x.TitleOfCourtesy).NotEmpty().WithMessage("TitleOfCourtesy Boş Giremezsiniz");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("BirthDate Boş Giremezsiniz");
            RuleFor(x => x.HireDate).NotEmpty().WithMessage("HireDate Boş Giremezsiniz");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address Boş Giremezsiniz");
            RuleFor(x => x.City).NotEmpty().WithMessage("City Boş Giremezsiniz");
            RuleFor(x => x.Region).NotEmpty().WithMessage("Region Boş Giremezsiniz");
            RuleFor(x => x.PostalCode).NotEmpty().WithMessage("PostalCode Boş Giremezsiniz");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Country Boş Giremezsiniz");
            RuleFor(x => x.HomePhone).NotEmpty().WithMessage("HomePhone Boş Giremezsiniz");
            RuleFor(x => x.Extension).NotEmpty().WithMessage("Extension Boş Giremezsiniz");
            RuleFor(x => x.Notes).NotEmpty().WithMessage("Notes Boş Giremezsiniz");
            RuleFor(x => x.ReportsTo).NotEmpty().WithMessage("ReportsTo Boş Giremezsiniz");
            RuleFor(x => x.PhotoPath).NotEmpty().WithMessage("PhotoPath Boş Giremezsiniz");
        }
    }
}
