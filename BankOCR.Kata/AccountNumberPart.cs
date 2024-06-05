using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOCR.Kata;

public record AccountNumberPart(char First, char Second, char Third)
{
    public static explicit operator AccountNumberPart(string input)
    {
        if (input.Length != 3)
        {
            throw new ArgumentOutOfRangeException("Input must be exactly 3 characters long.");
        }

        return new AccountNumberPart(input[0], input[1], input[2]);
    }

    public override string ToString()
    {
        return $"{First}{Second}{Third}";
    }
}