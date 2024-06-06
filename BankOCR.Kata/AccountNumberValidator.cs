namespace BankOCR.Kata;

public class AccountNumberValidator
{
    public AccountNumberValidationResult Validate(AccountNumber accountNumber)
    {
        if (!accountNumber.IsLegible)
        {
            return AccountNumberValidationResult.Illegible;
        }

        var checksum = CalculateChecksum(accountNumber);
        return checksum % 11 == 0 ? AccountNumberValidationResult.Valid : AccountNumberValidationResult.Invalid;
    }

    private int CalculateChecksum(AccountNumber accountNumber)
    {
        return accountNumber.Digits
            .Select((digit, index) => digit.Digit * (accountNumber.Digits.Count - index))
            .Sum();
    }
}

public enum AccountNumberValidationResult
{
    Valid = 0,
    Invalid,
    Illegible,
    Ambiguous
}

public static class AccountNumberValidationResultFormatter
{
    public static string Format(this AccountNumberValidationResult result)
    {
        return result switch
        {
            AccountNumberValidationResult.Valid => "",
            AccountNumberValidationResult.Invalid => "ERR",
            AccountNumberValidationResult.Illegible => "ILL",
            AccountNumberValidationResult.Ambiguous => "AMB",
            _ => throw new ArgumentOutOfRangeException(nameof(result), result, null)
        };
    }
}