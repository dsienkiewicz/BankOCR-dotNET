namespace BankOCR.Kata;

public record AccountNumber(IReadOnlyCollection<AccountNumberDigit> Digits)
{
    public bool IsLegible => Digits.All(d => d.IsLegible);

    public override string ToString()
    {
        return string.Join("", Digits);
    }

    public static AccountNumber Parse(string input)
    {
        return new AccountNumber(
            input.Select(c => int.TryParse(c.ToString(), out var digit)
                            ? new AccountNumberDigit(digit)
                            : AccountNumberDigit.Unknown
            ).ToList()
        );
    }
}