using System;
using System.Collections.Generic;
using System.Linq;

namespace MinesweeperKata.Parsing
{
    public class InputCleanser
    {
        public IEnumerable<string> SplitInputFields(string input)
        {
            return input.Split(new[] { "\n\n" }, StringSplitOptions.None).Where(inputField => inputField != "00")
                .ToArray();
        }
    }
}
