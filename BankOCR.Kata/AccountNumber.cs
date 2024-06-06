namespace BankOCR.Kata;

public record AccountNumber(IReadOnlyCollection<AccountNumberDigit> Digits)
{
    public override string ToString()
    {
        return string.Join("", Digits);
    }
}