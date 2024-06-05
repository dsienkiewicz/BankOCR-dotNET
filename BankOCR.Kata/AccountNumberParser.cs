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
                new AccountNumberPart(' ', '_', ' '),
                new AccountNumberPart('|', ' ', '|'),
                new AccountNumberPart('|', '_', '|')),
            new AccountNumberDigit(0)
        },
        {
            new AccountNumberDigitInput(
                new AccountNumberPart(' ', ' ', ' '),
                new AccountNumberPart(' ', ' ', '|'),
                new AccountNumberPart(' ', ' ', '|')),
            new AccountNumberDigit(1)
        },
        {
            new AccountNumberDigitInput(
                new AccountNumberPart(' ', '_', ' '),
                new AccountNumberPart(' ', '_', '|'),
                new AccountNumberPart('|', '_', ' ')),
            new AccountNumberDigit(2)
        },
        {
            new AccountNumberDigitInput(
                new AccountNumberPart(' ', '_', ' '),
                new AccountNumberPart(' ', '_', '|'),
                new AccountNumberPart(' ', '_', '|')),
            new AccountNumberDigit(3)
        },
        {
            new AccountNumberDigitInput(
                new AccountNumberPart(' ', ' ', ' '),
                new AccountNumberPart('|', '_', '|'),
                new AccountNumberPart(' ', ' ', '|')),
            new AccountNumberDigit(4)
        },
        {
            new AccountNumberDigitInput(
                new AccountNumberPart(' ', '_', ' '),
                new AccountNumberPart('|', '_', ' '),
                new AccountNumberPart(' ', '_', '|')),
            new AccountNumberDigit(5)
        },
        {
            new AccountNumberDigitInput(
                new AccountNumberPart(' ', '_', ' '),
                new AccountNumberPart('|', '_', ' '),
                new AccountNumberPart('|', '_', '|')),
            new AccountNumberDigit(6)
        },
        {
            new AccountNumberDigitInput(
                new AccountNumberPart(' ', '_', ' '),
                new AccountNumberPart(' ', ' ', '|'),
                new AccountNumberPart(' ', ' ', '|')),
            new AccountNumberDigit(7)
        },
        {
            new AccountNumberDigitInput(
                new AccountNumberPart(' ', '_', ' '),
                new AccountNumberPart('|', '_', '|'),
                new AccountNumberPart('|', '_', '|')),
            new AccountNumberDigit(8)
        },
        {
            new AccountNumberDigitInput(
                new AccountNumberPart(' ', '_', ' '),
                new AccountNumberPart('|', '_', '|'),
                new AccountNumberPart(' ', '_', '|')),
            new AccountNumberDigit(9)
        }
    };

    public AccountNumber Parse(IReadOnlyCollection<AccountNumberDigitInput> numberInputs)
    {
        return new AccountNumber(numberInputs.Select(Parse).ToList());
    }

    private AccountNumberDigit Parse(AccountNumberDigitInput numberInput)
    {
        if (_digitMap.TryGetValue(numberInput, out var digit))
        {
            return digit;
        }

        return AccountNumberDigit.Unknown;
    }
}