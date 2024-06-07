namespace BankOCR.Kata;

public record AccountNumberDigitInput
{
    public AccountNumberPartInput TopPart { get; init; }
    public AccountNumberPartInput MiddlePart { get; init; }
    public AccountNumberPartInput BottomPart { get; init; }

    public AccountNumberDigitInput(AccountNumberPartInput topPart, AccountNumberPartInput middlePart, AccountNumberPartInput bottomPart)
    {
        TopPart = topPart ?? throw new ArgumentNullException(nameof(topPart));
        MiddlePart = middlePart ?? throw new ArgumentNullException(nameof(middlePart));
        BottomPart = bottomPart ?? throw new ArgumentNullException(nameof(bottomPart));
    }

    public AccountNumberDigitInput(string topPartLine, string middlePartLine, string bottomPartLine)
    : this(new AccountNumberPartInput(topPartLine), new AccountNumberPartInput(middlePartLine), new AccountNumberPartInput(bottomPartLine))
    {
    }

    public static IReadOnlyCollection<AccountNumberDigitInput> AllCombinations()
    {
        var partInputCombinations = AccountNumberPartInput.AllCombinations();

        return partInputCombinations
            .SelectMany(topPart => partInputCombinations
                .SelectMany(middlePart => partInputCombinations
                    .Select(bottomPart => new AccountNumberDigitInput(topPart, middlePart, bottomPart))))
            .ToList();
    }
}