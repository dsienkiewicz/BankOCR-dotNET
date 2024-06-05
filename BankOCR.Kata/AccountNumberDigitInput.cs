using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOCR.Kata;

public record AccountNumberDigitInput(AccountNumberPart TopPart, AccountNumberPart MiddlePart, AccountNumberPart BottomPart);