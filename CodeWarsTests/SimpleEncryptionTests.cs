using CodeWars;
using NUnit.Framework;

namespace CodeWarsTests
{
    [TestFixture]
    public class SimpleEncryptionTests
    {
        [Test]
        public void DecryptExampleTests()
        {
            Assert.AreEqual("This is a test!", SimpleEncryption.Decrypt("This is a test!", 0));
            Assert.AreEqual("This is a test!", SimpleEncryption.Decrypt("hsi  etTi sats!", 1));
            Assert.AreEqual("This is a test!", SimpleEncryption.Decrypt("s eT ashi tist!", 2));
            Assert.AreEqual("This is a test!", SimpleEncryption.Decrypt(" Tah itse sits!", 3));
            Assert.AreEqual("This is a test!", SimpleEncryption.Decrypt("This is a test!", 4));
            Assert.AreEqual("This is a test!", SimpleEncryption.Decrypt("This is a test!", -1));
            Assert.AreEqual("This kata is very interesting!",
                SimpleEncryption.Decrypt("hskt svr neetn!Ti aai eyitrsig", 1));
        }

        [Test]
        public void EmptyTests()
        {
            Assert.AreEqual("", SimpleEncryption.Encrypt("", 0));
            Assert.AreEqual("", SimpleEncryption.Decrypt("", 0));
        }

        [Test]
        public void EncryptExampleTests()
        {
            Assert.AreEqual("This is a test!", SimpleEncryption.Encrypt("This is a test!", 0));
            Assert.AreEqual("hsi  etTi sats!", SimpleEncryption.Encrypt("This is a test!", 1));
            Assert.AreEqual("s eT ashi tist!", SimpleEncryption.Encrypt("This is a test!", 2));
            Assert.AreEqual(" Tah itse sits!", SimpleEncryption.Encrypt("This is a test!", 3));
            Assert.AreEqual("This is a test!", SimpleEncryption.Encrypt("This is a test!", 4));
            Assert.AreEqual("This is a test!", SimpleEncryption.Encrypt("This is a test!", -1));
            Assert.AreEqual("hskt svr neetn!Ti aai eyitrsig",
                SimpleEncryption.Encrypt("This kata is very interesting!", 1));
        }

        [Test]
        public void NullTests()
        {
            Assert.AreEqual(null, SimpleEncryption.Encrypt(null, 0));
            Assert.AreEqual(null, SimpleEncryption.Decrypt(null, 0));
        }
    }
}