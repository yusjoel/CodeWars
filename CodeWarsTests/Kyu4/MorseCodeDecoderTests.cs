using CodeWars.Kyu4;
using NUnit.Framework;

namespace CodeWarsTests.Kyu4
{
    [TestFixture()]
    public class MorseCodeDecoderTests
    {
        [Test]
        public void TestExampleFromDescription()
        {
            string decodeBits = MorseCodeDecoder.DecodeBits("1100110011001100000011000000111111001100111111001111110000000000000011001111110011111100111111000000110011001111110000001111110011001100000011");
            Assert.AreEqual(".... . -.--   .--- ..- -.. .", decodeBits);
            Assert.AreEqual("HEY JUDE", MorseCodeDecoder.DecodeMorse(decodeBits));
        }
    }
}
