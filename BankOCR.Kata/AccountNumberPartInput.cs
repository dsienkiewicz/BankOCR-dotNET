namespace BankOCR.Kata;

public record AccountNumberPartInput
{
    private static readonly IReadOnlyCollection<char> _validCharacters = new List<char> { ' ', '|', '_' };

    public char First { get; init; }
    public char Second { get; init; }
    public char Third { get; init; }

    public AccountNumberPartInput(char first, char second, char third)
    {
        First = first;
        Second = second;
        Third = third;
    }

    public AccountNumberPartInput(string parts)
    {
        if (parts.Length != 3)
        {
            throw new ArgumentOutOfRangeException("Input must be exactly 3 characters long.");
        }

        First = parts[0];
        Second = parts[1];
        Third = parts[2];
    }

    public static IReadOnlyCollection<AccountNumberPartInput> AllCombinations()
    {
        return _validCharacters
            .SelectMany(first => _validCharacters
                .SelectMany(second => _validCharacters
                    .Select(third => new AccountNumberPartInput(first, second, third))))
            .ToList();
    }

    public override string ToString()
    {
        return $"{First}{Second}{Third}";
    }
}