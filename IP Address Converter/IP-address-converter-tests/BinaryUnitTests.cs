using IP_Address_Converter;

namespace IP_address_converter_tests
{
    [TestClass]
    public class BinaryUnitTests
    {
        [TestMethod]
        public void CreateBinary_GoodBinary_ToDecimal()
        {
            try
            {
                ConversionType conversion = ConversionType.BinaryToDecimal;
                string originalInput = "1101001.10100101.1101100";

                ConversionType expectedConversion = ConversionType.BinaryToDecimal;
                string expectedInput = "1101001.10100101.1101100";
                Binary binary = new Binary(conversion, originalInput);
                Assert.AreEqual(expectedConversion, binary.Conversion, "Binary conversion type not as expected");
                Assert.AreEqual(expectedInput, binary.OriginalInput, "Binary original input was not as expected");

                originalInput = "010010.100101.00100101";
                expectedInput = "010010.100101.00100101";
                binary = new Binary(conversion, originalInput);
                Assert.AreEqual(expectedConversion, binary.Conversion, "Binary conversion type not as expected");
                Assert.AreEqual(expectedInput, binary.OriginalInput, "Binary original input was not as expected");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }
        }
        [TestMethod]
        public void CreateBinary_ConvertToDecimal_GoodTest()
        {
            try
            {
                ConversionType conversion = ConversionType.BinaryToDecimal;
                string originalInput = "1101001.10100101.1101100";

                string expectedOutput = "105.165.108";
                Binary binary = new Binary(conversion, originalInput);
                Assert.AreEqual(expectedOutput, binary.ConvertedInput, $"The expected output is incorrect: {expectedOutput} vs {binary.ConvertedInput}");

                originalInput = "0010010.100101.00001010101";
                expectedOutput = "18.37.85";
                binary = new Binary(conversion, originalInput);
                Assert.AreEqual(expectedOutput, binary.ConvertedInput, $"The expected output is incorrect: {expectedOutput} vs {binary.ConvertedInput}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }
        }
    }
} 