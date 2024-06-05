namespace BankOCR.Kata;

class Program
{
    static void Main(string[] args)
    {
        var inputLine = args.FirstOrDefault("");
        var parser = new AccountNumberParser();
        var bankAccount = parser.Parse(inputLine);

        PrintBankAccount(bankAccount, ' ');
    }

    private static void PrintBankAccount(object bankAccount, char separator)
    {
        Console.WriteLine(bankAccount.ToString());
    }
}