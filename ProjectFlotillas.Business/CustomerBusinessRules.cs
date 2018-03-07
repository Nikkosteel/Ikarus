using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ProjectFlotillas.Business.Entities;
using System.Configuration;
using ProjectFlotillas.Interfaces;

namespace ProjectFlotillas.Business
{
    public class CustomerBusinessRules : AbstractValidator<Customer>
    {
      
        public CustomerBusinessRules()
        {          
            RuleFor(c => c.CompanyName).NotEmpty().WithMessage("Company Name is required.");
            RuleFor(c => c.CustomerCode).NotEmpty().WithMessage("Customer Code is required.");      
        }

    }
}
