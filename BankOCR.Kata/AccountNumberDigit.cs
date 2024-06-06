namespace BankOCR.Kata;

public record AccountNumberDigit(int Digit)
{
    public static AccountNumberDigit Unknown => new AccountNumberDigit(-1);

    public override string ToString()
    {
        return Digit >= 0 ? Digit.ToString() : "?";
    }
}