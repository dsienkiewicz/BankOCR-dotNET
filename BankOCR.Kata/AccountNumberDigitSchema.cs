namespace BankOCR.Kata;

public class AccountNumberDigitSchema
{
    public static readonly IReadOnlyDictionary<AccountNumberDigitInput, AccountNumberDigit> DigitMap = new Dictionary<AccountNumberDigitInput, AccountNumberDigit>
    {
        {
            new AccountNumberDigitInput(
                " _ ",
                "| |",
                "|_|"),
            new AccountNumberDigit(0)
        },
        {
            new AccountNumberDigitInput(
                "   ",
                "  |",
                "  |"),
            new AccountNumberDigit(1)
        },
        {
            new AccountNumberDigitInput(
                " _ ",
                " _|",
                "|_ "),
            new AccountNumberDigit(2)
        },
        {
            new AccountNumberDigitInput(
                " _ ",
                " _|",
                " _|"),
            new AccountNumberDigit(3)
        },
        {
            new AccountNumberDigitInput(
                "   ",
                "|_|",
                "  |"),
            new AccountNumberDigit(4)
        },
        {
            new AccountNumberDigitInput(
                " _ ",
                "|_ ",
                " _|"),
            new AccountNumberDigit(5)
        },
        {
            new AccountNumberDigitInput(
                " _ ",
                "|_ ",
                "|_|"),
            new AccountNumberDigit(6)
        },
        {
            new AccountNumberDigitInput(
                " _ ",
                "  |",
                "  |"),
            new AccountNumberDigit(7)
        },
        {
            new AccountNumberDigitInput(
                " _ ",
                "|_|",
                "|_|"),
            new AccountNumberDigit(8)
        },
        {
            new AccountNumberDigitInput(
                " _ ",
                "|_|",
                " _|"),
            new AccountNumberDigit(9)
        }
    };
}