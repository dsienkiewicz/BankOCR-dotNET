using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOCR.Kata;

public record AccountNumberPart
{
    public char First { get; init; }
    public char Second { get; init; }
    public char Third { get; init; }

    public AccountNumberPart(char first, char second, char third)
    {
        First = first;
        Second = second;
        Third = third;
    }

    public AccountNumberPart(string parts)
    {
        if (parts.Length != 3)
        {
            throw new ArgumentOutOfRangeException("Input must be exactly 3 characters long.");
        }

        First = parts[0];
        Second = parts[1];
        Third = parts[2];
    }

    public override string ToString()
    {
        return $"{First}{Second}{Third}";
    }
}