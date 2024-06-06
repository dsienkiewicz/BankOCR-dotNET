using System.CommandLine;

namespace BankOCR.Kata;

class Program
{
  static async Task<int> Main(string[] args)
  {
    var rootCommand = new RootCommand(
      description: "Reads a file with bank account numbers in OCR format and converts them to other formats.");

    var inputOption = new Option<string>(
      name: "--input",
      description: "The path to the input file that is to be converted.",
      getDefaultValue: () => "input.txt");


    var outputOption = new Option<string>(
      name: "--output",
      description: "The target name of the output file after conversion.",
      getDefaultValue: () => "output.txt");

    var convertAccountNumbersCommand = new Command("convert", "Converts a bank accounts file from OCR format to plain numbers.");
    convertAccountNumbersCommand.AddOption(inputOption);
    convertAccountNumbersCommand.AddOption(outputOption);

    convertAccountNumbersCommand.SetHandler(async (inputOptionValue, outputOptionValue) =>
        {
          await ConvertAccountNumbers(inputOptionValue, outputOptionValue);
        },
        inputOption, outputOption);

    rootCommand.AddCommand(convertAccountNumbersCommand);

    return await rootCommand.InvokeAsync(args);
  }

  static public async Task ConvertAccountNumbers(string inputFilePath, string outputFilePath)
  {
    var fileParser = new FileParser();
    var inputLines = await File.ReadAllLinesAsync(inputFilePath);

    var accountNumberDigits = fileParser.Parse(inputLines);
    var outputLines = accountNumberDigits
      .Select(accountNumberDigit => accountNumberDigit.ToString());

    await File.WriteAllLinesAsync(outputFilePath, outputLines);
  }
}