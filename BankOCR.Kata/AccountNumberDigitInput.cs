using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOCR.Kata;

public record AccountNumberDigitInput
{
    public AccountNumberPart TopPart { get; init; }
    public AccountNumberPart MiddlePart { get; init; }
    public AccountNumberPart BottomPart { get; init; }

    public AccountNumberDigitInput(AccountNumberPart topPart, AccountNumberPart middlePart, AccountNumberPart bottomPart)
    {
        TopPart = topPart ?? throw new ArgumentNullException(nameof(topPart));
        MiddlePart = middlePart ?? throw new ArgumentNullException(nameof(middlePart));
        BottomPart = bottomPart ?? throw new ArgumentNullException(nameof(bottomPart));
    }

    public AccountNumberDigitInput(string topPartLine, string middlePartLine, string bottomPartLine)
    : this(new AccountNumberPart(topPartLine), new AccountNumberPart(middlePartLine), new AccountNumberPart(bottomPartLine))
    {
    }
}