namespace BankOCR.Kata;

public class FileParser
{
    private readonly IReadOnlyCollection<int> _digitPositions = new[] { 0, 3, 6, 9, 12, 15, 18, 21, 24 };
    private readonly int _numberLength = 3;
    private readonly AccountNumberParser _accountNumberParser = new AccountNumberParser();

    public IReadOnlyCollection<AccountNumber> Parse(IReadOnlyCollection<string> inputs)
    {
        return inputs
            .Chunk(4)
            .Aggregate(new List<AccountNumber>(), (acc, inputLines) =>
            {
                var accountNumberDigits = new List<AccountNumberDigitInput>();

                var topPart = inputLines.ElementAt(0);
                var middlePart = inputLines.ElementAt(1);
                var bottomPart = inputLines.ElementAt(2);

                foreach (var offset in _digitPositions)
                {
                    accountNumberDigits.Add(new AccountNumberDigitInput(
                        topPart.Substring(offset, _numberLength),
                        middlePart.Substring(offset, _numberLength),
                        bottomPart.Substring(offset, _numberLength)
                    ));
                }

                acc.Add(_accountNumberParser.Parse(accountNumberDigits));

                return acc;
            })
            .ToList();
    }
}