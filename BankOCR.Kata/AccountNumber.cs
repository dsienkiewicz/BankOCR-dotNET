using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOCR.Kata;

public record AccountNumber(IReadOnlyCollection<AccountNumberDigit> Digits)
{
    public override string ToString()
    {
        return string.Join("", Digits);
    }
}