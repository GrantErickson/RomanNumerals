using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace RomanNumerals.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow("I", 1)]
        [DataRow("II", 2)]
        [DataRow("IV", 4)]
        [DataRow("XXX", 30)]
        [DataRow("XCIX", 99)]
        [DataRow("CCXCVI", 296)]
        [DataRow("MCM", 1900)]
        [DataRow("MCMXCIX", 1999)]
        [DataRow("MMCMXCIV", 2994)]
        public void ConvertNumber(string numeral, int number)
        {
            Assert.AreEqual(number, RomanNumeralConverter.Convert(numeral));
        }

        [TestMethod]
        [DataRow("I", 1)]
        [DataRow("II", 2)]
        [DataRow("IV", 4)]
        [DataRow("XXX", 30)]
        [DataRow("XCIX", 99)]
        [DataRow("CCXCVI", 296)]
        [DataRow("MCM", 1900)]
        [DataRow("MCMXCIX", 1999)]
        [DataRow("MMCMXCIV", 2994)]
        public void ConvertNumeral(string numeral, int number)
        {
            Assert.AreEqual(numeral, RomanNumeralConverter.Convert(number));
        }



        [TestMethod]
        [DataRow('M', 'C')]
        [DataRow('D', 'C')]
        [DataRow('C', 'X')]
        [DataRow('L', 'X')]
        [DataRow('X', 'I')]
        [DataRow('V', 'I')]
        public void FindModifierNotNull(char target, char modifier)
        {
            Letter t = RomanNumeralConverter.GetLetter(target);
            Letter? m = RomanNumeralConverter.FindModifier(t);
            Assert.IsNotNull(m);
            Assert.AreEqual(modifier, m.Character, $"{target} is modified by {modifier}");
        }

        [TestMethod]
        [DataRow('I')]
        public void FindModifierNull(char target)
        {
            Letter t = RomanNumeralConverter.GetLetter(target);
            Letter? m = RomanNumeralConverter.FindModifier(t);
            Assert.IsNull(m);
        }
    }
}