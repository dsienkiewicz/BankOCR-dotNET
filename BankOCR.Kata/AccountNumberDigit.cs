namespace BankOCR.Kata;

public record AccountNumberDigit(int Digit, AccountNumberDigitInput? Input = null)
{
    private static IReadOnlyDictionary<AccountNumberDigit, IReadOnlyCollection<AccountNumberDigit>> _digitSimilarities = new Dictionary<AccountNumberDigit, IReadOnlyCollection<AccountNumberDigit>>
    {
        { new AccountNumberDigit(0), new[] { new AccountNumberDigit(8) } },
        { new AccountNumberDigit(1), new[] { new AccountNumberDigit(7) } },
        { new AccountNumberDigit(2), new List<AccountNumberDigit>() },
        { new AccountNumberDigit(3), new [] { new AccountNumberDigit(9) } },
        { new AccountNumberDigit(4), new List<AccountNumberDigit>() },
        { new AccountNumberDigit(5), new[] { new AccountNumberDigit(6), new AccountNumberDigit(9) } },
        { new AccountNumberDigit(6), new[] { new AccountNumberDigit(5), new AccountNumberDigit(8) } },
        { new AccountNumberDigit(7), new[] { new AccountNumberDigit(1) } },
        { new AccountNumberDigit(8), new[] { new AccountNumberDigit(0), new AccountNumberDigit(6), new AccountNumberDigit(9) } },
        { new AccountNumberDigit(9), new[] { new AccountNumberDigit(3) , new AccountNumberDigit(5), new AccountNumberDigit(8) } }
    };

    public bool IsLegible => Digit >= 0 && Digit <= 9;

    public static AccountNumberDigit Unknown(AccountNumberDigitInput input) => new AccountNumberDigit(-1, input);

    public IReadOnlyCollection<AccountNumberDigit> FindSimilarDigits()
    {
        return IsLegible
            ? _digitSimilarities[this]
            : BruteForceGenerateSimilarDigits().ToList();
    }

    private IEnumerable<AccountNumberDigit> BruteForceGenerateSimilarDigits()
    {
        foreach (var inputCombination in AccountNumberDigitInput.AllCombinations())
        {
            if (inputCombination == Input)
            {
                continue;
            }

            if (AccountNumberDigitSchema.DigitMap.TryGetValue(inputCombination, out var similarDigit))
            {
                yield return similarDigit;
            }
        }
    }


    public override string ToString()
    {
        return IsLegible ? Digit.ToString() : "?";
    }
}