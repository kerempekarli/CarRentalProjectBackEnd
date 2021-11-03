using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).MinimumLength(20);
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.CalorId).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(100);
            RuleFor(c => c.ModelYear).Must(HighterThan2000); 
        }

        private bool HighterThan2000(int arg)
        {
            if(arg > 2000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
