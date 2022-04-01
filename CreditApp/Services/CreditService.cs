using CreditApp.Models;
using CreditApp.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApp.Services
{
    public class CreditService
    {
        private readonly CreditValidator _validator = new CreditValidator();

        public Answer GetApproval(Credit credit)
        {
            _validator.ValidateAndThrow(credit);
            decimal totalFutureDebt = credit.Amount + credit.CurrentAmount;
            var ans = new Answer();
            if (totalFutureDebt < 2000.00M || totalFutureDebt > 69000.00M)
            {
                ans.Approval = false;
                ans.InterestRate = 0;               
            }
            else
            {
                var interest = 0.00M;
                if (totalFutureDebt < 20000.00M)
                {
                    interest = 0.03M;
                }
                if (totalFutureDebt >= 20000.00M && totalFutureDebt < 40000.00M) //nebuvo 39000-40000
                {
                    interest = 0.04M;
                }
                if (totalFutureDebt >= 40000.00M && totalFutureDebt < 60000.00M) //nebuvo 59000-60000
                {
                    interest = 0.05M;
                }
                if (totalFutureDebt >= 60000.00M) 
                {
                    interest = 0.06M;
                }
                ans.Approval = true;
                ans.InterestRate = interest;
            }
            return ans;
        }
    }
}
