using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Validation.FluentLibrary
{
    public class ParcelValidator : AbstractValidator<Parcel>
    {

        public ParcelValidator()
        {
            RuleFor(parcel => parcel.OrderNumber).Length(1, 15).NotEmpty().WithMessage("Order Number is required");
            RuleFor(parcel => parcel.Description).Length(0, 32).WithMessage("Description can be only 32 characters");
            RuleFor(parcel => parcel.Address.HouseNo)
                .NotEmpty()
                .WithMessage("House Number is required");
            When(parcel => !string.IsNullOrEmpty(parcel.NodeType), () =>
            {
                RuleFor(parcel => parcel.NodeType).Length(0, 4).WithMessage("Invalid Node type");
                RuleFor(parcel => parcel.NodeType).Must(BeAValidNodetype).WithMessage("Invalid Node type");
                RuleFor(parcel => parcel.NodeId).NotEmpty().WithMessage("Nodeid is required");
                RuleFor(parcel => parcel.NodeName).NotEmpty().WithMessage("Node name is required");
            });


        }

        private bool BeAValidNodetype(string nodeType)
        {
            if (string.IsNullOrEmpty(nodeType))
                return true;
            if ((nodeType == "PSHP") || (nodeType == "STOR"))
            {
                return true;
            }
            return false;
        }
    }
}
