using CreditApp.Services;
using Xunit;
using FluentValidation.TestHelper;
using CreditApp.Validators;
using CreditApp.Models;

namespace CreditApp.UnitTests
{
    public class CreditServiceTests
    {
        private readonly CreditService _creditService;
        private readonly CreditValidator _validator;
        public CreditServiceTests()
        {
            _creditService = new CreditService();
            _validator = new CreditValidator();
        }

        [Fact]
        public void GetApproval_GivenValidItems_CalculatePriceCorrectly()
        {
            var exampleCredit = new Credit()
            {
                Amount = 10000.00M,
                Term = 2,
                CurrentAmount = 40000.00M
            };
            Answer answer = _creditService.GetApproval(exampleCredit);

            var expectedResult = new Answer()
            {
                Approval = true,
                InterestRate = 0.05M
            };
            Assert.Equal(expectedResult.Approval, answer.Approval);
            Assert.Equal(expectedResult.InterestRate, answer.InterestRate);
        }
        [Fact]
        public void GetApproval_GivenValidItems_CalculatePriceCorrectly2()
        {
            var exampleCredit = new Credit()
            {
                Amount = 29999.00M,
                Term = 5,
                CurrentAmount = 10000.00M
            };
            Answer answer = _creditService.GetApproval(exampleCredit);

            var expectedResult = new Answer()
            {
                Approval = true,
                InterestRate = 0.04M
            };
            Assert.Equal(expectedResult.Approval, answer.Approval);
            Assert.Equal(expectedResult.InterestRate, answer.InterestRate);
        }
        [Fact]
        public void GetApproval_GivenValidItems_CalculatePriceCorrectly3()
        {
            var exampleCredit = new Credit()
            {
                Amount = 1000.00M,
                Term = 5,
                CurrentAmount = 0
            };
            Answer answer = _creditService.GetApproval(exampleCredit);

            var expectedResult = new Answer()
            {
                Approval = false,
                InterestRate = 0.00M
            };
            Assert.Equal(expectedResult.Approval, answer.Approval);
            Assert.Equal(expectedResult.InterestRate, answer.InterestRate);
        }
        [Fact]
        public void GetApproval_GivenInvalidItems_ThrowsValidationException()
        {
            var exampleCredit = new Credit()
            {
                Amount = 0,
                Term = 0,
                CurrentAmount = 40000.00M
            };
            var result = _validator.TestValidate(exampleCredit);

            result.ShouldHaveValidationErrorFor(credit => credit.Amount);
            result.ShouldHaveValidationErrorFor(credit => credit.Term);
        }
    }
}
