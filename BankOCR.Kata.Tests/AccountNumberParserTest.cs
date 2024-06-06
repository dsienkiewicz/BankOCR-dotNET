using BankOCR.Kata;

namespace BankOCR.Kata.Tests;

public class AccountNumberParserTest
{
    [Theory]
    [InlineData(new[] {
        " _ ",
        "| |",
        "|_|" },
        0)]
    [InlineData(new[] {
        "   ",
        "  |",
        "  |" },
        1)]
    [InlineData(new[] {
        " _ ",
        " _|",
        "|_ " },
        2)]
    [InlineData(new[] {
        " _ ",
        " _|",
        " _|" },
        3)]
    [InlineData(new[] {
        "   ",
        "|_|",
        "  |" },
        4)]
    [InlineData(new[] {
        " _ ",
        "|_ ",
        " _|" },
        5)]
    [InlineData(new[] {
        " _ ",
        "|_ ",
        "|_|" },
        6)]
    [InlineData(new[] {
        " _ ",
        "  |",
        "  |" },
        7)]
    [InlineData(new[] {
        " _ ",
        "|_|",
        "|_|" },
        8)]
    [InlineData(new[] {
        " _ ",
        "|_|",
        " _|" },
        9)]
    public void Parse_WhenGivenAnAccountNumberDigitInput_ReturnsTheExpectedAccountNumberDigit(string[] input, int expectedDigit)
    {
        var sut = new AccountNumberParser();
        var result = sut.Parse(new AccountNumberDigitInput(input[0], input[1], input[2]));

        Assert.Equal(expectedDigit, result.Digit);
    }
}