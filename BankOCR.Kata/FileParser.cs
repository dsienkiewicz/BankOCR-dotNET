using System.CommandLine.Parsing;

namespace BankOCR.Kata;

public class FileParser
{
    private readonly IReadOnlyCollection<int> _digitPositions = new[] { 0, 3, 6, 9, 12, 15, 18, 21, 24 };
    private readonly int _numberLength = 3;
    private readonly AccountNumberParser _accountNumberParser = new AccountNumberParser();
    private readonly AccountNumberValidator _accountNumberValidator = new AccountNumberValidator();

    public IReadOnlyCollection<(AccountNumber accountNumber, AccountNumberValidationResult validationResult)> Parse(IReadOnlyCollection<string> inputs)
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
            .Select(an => (accountNumber: an, result: _accountNumberValidator.Validate(an)))
            .Select(an => an.result != AccountNumberValidationResult.Valid
                ? FindSimilarAccountNumber(an)
                : an)
            .ToList();
    }

    private (AccountNumber accountNumber, AccountNumberValidationResult validationResult) FindSimilarAccountNumber((AccountNumber accountNumber, AccountNumberValidationResult validationResult) accountNumberResult)
    {
        (AccountNumber accountNumber, AccountNumberValidationResult validationResult) = accountNumberResult;

        var similarAccountNumbers = accountNumber
            .GetSimilarAccountNumbers()
            .Select(an => new { Account = an, Status = _accountNumberValidator.Validate(an) })
            .Where(an => an.Status == AccountNumberValidationResult.Valid);

        return similarAccountNumbers.Any()
            ? similarAccountNumbers.Count() == 1
                ? (similarAccountNumbers.First().Account, similarAccountNumbers.First().Status)
                : (accountNumber, AccountNumberValidationResult.Ambiguous)
            : accountNumberResult;
    }
}