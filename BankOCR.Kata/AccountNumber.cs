namespace BankOCR.Kata;

public record AccountNumber(IReadOnlyCollection<AccountNumberDigit> Digits)
{
    public bool IsLegible => Digits.All(d => d.IsLegible);

    public IReadOnlyCollection<AccountNumber> GetSimilarAccountNumbers()
    {
        return Digits
            .Select((digit, index) => new { Index = index, Similarities = digit.FindSimilarDigits() })
            .SelectMany(similarDigit => similarDigit.Similarities
                .Select(similar => new AccountNumber(Digits.Select((d, i) => i == similarDigit.Index ? similar : d).ToList())))
            .ToList();
    }

    public override string ToString()
    {
        return string.Join("", Digits);
    }

    /// <summary>
    /// Parses a string input into an AccountNumber.
    /// String should be made of 9 characters, each representing a digit.
    /// In case a digit is illegible, it should be represented by a `?` character.
    /// </summary>
    public static AccountNumber Parse(string input)
    {
        return new AccountNumber(
            input.Select(c => int.TryParse(c.ToString(), out var digit)
                            ? new AccountNumberDigit(digit)
                            : AccountNumberDigit.Unknown(new AccountNumberDigitInput("   ", "   ", "   "))
            ).ToList()
        );
    }
}