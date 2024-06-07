namespace BankOCR.Kata;

public class FileParser
{
    private readonly AccountNumberParser _accountNumberParser = new AccountNumberParser();
    private readonly AccountNumberValidator _accountNumberValidator = new AccountNumberValidator();

    public IReadOnlyCollection<(AccountNumber accountNumber, AccountNumberValidationResult validationResult)> Parse(IReadOnlyCollection<string> inputs)
    {
        return inputs
            .Chunk(4)
            .Aggregate(new List<AccountNumber>(), (acc, inputLines) =>
            {
                acc.Add(_accountNumberParser.Parse(inputLines));

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