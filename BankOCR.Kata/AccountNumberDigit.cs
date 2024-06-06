namespace BankOCR.Kata;

public record AccountNumberDigit(int Digit)
{
    public bool IsLegible => Digit >= 0 && Digit <= 9;

    public static AccountNumberDigit Unknown => new AccountNumberDigit(-1);

    public override string ToString()
    {
        return IsLegible ? Digit.ToString() : "?";
    }
}