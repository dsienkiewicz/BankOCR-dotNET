using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOCR.Kata;

public record AccountNumberInput(
    AccountNumberDigitInput One,
    AccountNumberDigitInput Two,
    AccountNumberDigitInput Three,
    AccountNumberDigitInput Four,
    AccountNumberDigitInput Five,
    AccountNumberDigitInput Six,
    AccountNumberDigitInput Seven,
    AccountNumberDigitInput Eight,
    AccountNumberDigitInput Nine);