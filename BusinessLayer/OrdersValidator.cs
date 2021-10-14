using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using FluentValidation;

namespace BusinessLayer
{
    public class OrdersValidator : AbstractValidator<Orders>
    {
        public OrdersValidator()
        {
            RuleFor(x => x.OrderID).NotEmpty().WithMessage("OrderID Alanını Boş Bırakmayınız.");
            RuleFor(x => x.CustomerID).NotEmpty().WithMessage("CustomerID Boş Giremezsiniz");
            RuleFor(x => x.EmployeeID).NotEmpty().WithMessage("EmployeeID Boş Giremezsiniz");
            RuleFor(x => x.OrderDate).NotEmpty().WithMessage("OrderDate Boş Giremezsiniz");
            RuleFor(x => x.RequiredDate).NotEmpty().WithMessage("RequiredDate Boş Giremezsiniz");
            RuleFor(x => x.ShippedDate).NotEmpty().WithMessage("ShippedDate Boş Giremezsiniz");
            RuleFor(x => x.ShipVia).NotEmpty().WithMessage("ShipVia Boş Giremezsiniz");
            RuleFor(x => x.Freight).NotEmpty().WithMessage("Freight Boş Giremezsiniz");
            RuleFor(x => x.ShipName).NotEmpty().WithMessage("ShipName Boş Giremezsiniz");
            RuleFor(x => x.ShipAddress).NotEmpty().WithMessage("ShipAddress Boş Giremezsiniz");
            RuleFor(x => x.ShipCity).NotEmpty().WithMessage("ShipCity Boş Giremezsiniz");
            RuleFor(x => x.ShipRegion).NotEmpty().WithMessage("ShipRegion Boş Giremezsiniz");
            RuleFor(x => x.ShipPostalCode).NotEmpty().WithMessage("ShipPostalCode Boş Giremezsiniz");
            RuleFor(x => x.ShipCountry).NotEmpty().WithMessage("ShipCountry Boş Giremezsiniz");
        }
    }
}
