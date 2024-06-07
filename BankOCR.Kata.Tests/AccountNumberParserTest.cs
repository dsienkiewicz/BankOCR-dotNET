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
    public void Parse_WhenGivenAnAccountNumberDigitAsString_ReturnsTheExpectedAccountNumberDigit(string[] inputs, int expectedDigit)
    {
        var sut = new AccountNumberParser();
        var result = sut.Parse(new AccountNumberDigitInput(inputs[0], inputs[1], inputs[2]));

        Assert.Equal(expectedDigit, result.Digit);
    }

    [Theory]
    [InlineData(new[] {
        " _  _  _  _  _  _  _  _  _ ",
        "| || || || || || || || || |",
        "|_||_||_||_||_||_||_||_||_|"
        },
        new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 })]
    [InlineData(new[] {
        "                           ",
        "  |  |  |  |  |  |  |  |  |",
        "  |  |  |  |  |  |  |  |  |"
        },
        new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 })]
    [InlineData(new[] {
        " _     _  _  _  _  _  _    ",
        "| || || || || || || ||_   |",
        "|_||_||_||_||_||_||_| _|  |"
        },
        new[] { 0, -1, 0, 0, 0, 0, 0, 5, 1 })]
    public void Parse_WhenGivenAnAccountNumberAsString_ReturnsTheExpectedAccountNumber(string[] inputs, int[] expectedAccountNumber)
    {
        var sut = new AccountNumberParser();
        var result = sut.Parse(inputs);

        Assert.Equal(expectedAccountNumber, result.Digits.Select(d => d.Digit));
    }
}