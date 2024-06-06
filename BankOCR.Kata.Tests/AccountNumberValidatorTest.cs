using System.Runtime.InteropServices;

namespace BankOCR.Kata.Tests
{
    public class AccountNumberValidatorTest
    {
        [Theory]
        [InlineData("457508000", AccountNumberValidationResult.Valid)]
        [InlineData("664371495", AccountNumberValidationResult.Invalid)]
        [InlineData("86110??36", AccountNumberValidationResult.Illegible)]
        public void Validate_WhenGivenAnAccountNumber_ReturnsResult(string accountNumberInput, AccountNumberValidationResult expected)
        {
            var sut = new AccountNumberValidator();

            var accountNumber = AccountNumber.Parse(accountNumberInput);
            var result = sut.Validate(accountNumber);

            Assert.Equal(expected, result);
        }
    }
}