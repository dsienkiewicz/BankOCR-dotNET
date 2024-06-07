namespace BankOCR.Kata;

public class AccountNumberParser
{
    private readonly IReadOnlyCollection<int> _digitPositions = new[] { 0, 3, 6, 9, 12, 15, 18, 21, 24 };
    private readonly int _numberLength = 3;

    public AccountNumber Parse(string[] numberInputs)
    {
        var accountNumberDigits = new List<AccountNumberDigitInput>();

        var topPart = numberInputs.ElementAt(0);
        var middlePart = numberInputs.ElementAt(1);
        var bottomPart = numberInputs.ElementAt(2);

        foreach (var offset in _digitPositions)
        {
            accountNumberDigits.Add(new AccountNumberDigitInput(
                topPart.Substring(offset, _numberLength),
                middlePart.Substring(offset, _numberLength),
                bottomPart.Substring(offset, _numberLength)
            ));
        }

        return new AccountNumber(accountNumberDigits.Select(Parse).ToList());
    }

    public AccountNumberDigit Parse(AccountNumberDigitInput numberInput)
    {
        if (AccountNumberDigitSchema.DigitMap.TryGetValue(numberInput, out var digit))
        {
            return digit;
        }

        return AccountNumberDigit.Unknown(numberInput);
    }
}