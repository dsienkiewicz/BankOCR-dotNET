using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOCR.Kata;

public class AccountNumberParser
{
    private readonly IReadOnlyDictionary<AccountNumberDigitInput, AccountNumberDigit> _digitMap = new Dictionary<AccountNumberDigitInput, AccountNumberDigit>
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

    public AccountNumber Parse(IReadOnlyCollection<AccountNumberDigitInput> numberInputs)
    {
        return new AccountNumber(numberInputs.Select(Parse).ToList());
    }

    public AccountNumberDigit Parse(AccountNumberDigitInput numberInput)
    {
        if (_digitMap.TryGetValue(numberInput, out var digit))
        {
            return digit;
        }

        return AccountNumberDigit.Unknown;
    }
}