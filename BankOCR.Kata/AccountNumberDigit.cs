using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOCR.Kata;

public record AccountNumberDigit(int Digit)
{
    public static AccountNumberDigit Unknown => new AccountNumberDigit(-1);

    public override string ToString()
    {
        return Digit >= 0 ? Digit.ToString() : "?";
    }
}