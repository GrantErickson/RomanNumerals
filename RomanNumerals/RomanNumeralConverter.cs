using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    public static class RomanNumeralConverter
    {
        private static readonly List<Letter> Letters = new()
        {
            new Letter('M', 1000),
            new Letter('D', 500),
            new Letter('C', 100),
            new Letter('L', 50),
            new Letter('X', 10),
            new Letter('V', 5),
            new Letter('I', 1),
        };

        public static string Convert(int number)
        {
            StringBuilder result = new();
            foreach (Letter letter in Letters)
            {
                // Remove all instances of the letter from the number and subtract that value
                while (number >= letter.Value)
                {
                    result.Append(letter.Character);
                    number -= letter.Value;
                };

                // Find the letter than reduces this by one and do the same if it exists
                Letter? modifier = FindModifier(letter);
                if (modifier != null)
                {
                    while (number >= letter.Value - modifier.Value)
                    {
                        result.Append(modifier.Character);
                        result.Append(letter.Character);
                        number -= letter.Value;
                        number += modifier.Value;
                    };

                }
            }
            return result.ToString();
        }

        public static int Convert(string numeral)
        {
            int result = 0;
            foreach (char character in numeral.Reverse())
            {
                var letter = GetLetter(character);
                if (letter.Value * 4 < result)
                {
                    result -= letter.Value;
                }
                else
                {
                    result += letter.Value;
                }

            }
            return result;
        }

        public static Letter GetLetter(char character) { return Letters.First(f => f.Character == character); }
        public static Letter GetLetter(int value) { return Letters.First(f => f.Value == value); }

        public static Letter? FindModifier(Letter target)
        {
            return Letters.FirstOrDefault(f => f.Value < target.Value / 2);
        }
    }


}

