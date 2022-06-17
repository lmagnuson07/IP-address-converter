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
        //[DataRow(ConversionType.BinaryToDecimal, "0101A.D0T312.101001")] // Throws format exception/first item 0101A, input not a number
        //[DataRow(ConversionType.BinaryToDecimal, "41230.402045.20301.101011")] // Throws ArgumentOutOfRangeException
        //[DataRow(ConversionType.BinaryToDecimal, "-101001.101001")] // Throws FormatException
        //[DataRow(ConversionType.BinaryToDecimal, "100101.-101001")] // Throws FormatException
        //[DataRow(ConversionType.BinaryToDecimal, "50203921")] // Throws ArgumentOutOfRangeException
        //[DataRow(ConversionType.BinaryToDecimal, "-1010010")] // Throws FormatException
        //[DataRow(ConversionType.BinaryToDecimal, "afdbowg")] // Throws FormatException
        [DataRow(ConversionType.BinaryToDecimal, "10100101011010110111.10010.1001001")] // 20 digit number (Max)
        public void CreateBinary_BadBinary_ExceptionThrown(ConversionType conversion, string input)
        {
            try
            {
                Binary binary = new Binary(conversion, input);
                Assert.Fail("Exception was expected and failed to be thrown");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsTrue(ex.Message.Contains("is not a binary number"));
            }
            catch (FormatException ex)
            {
                Assert.IsTrue(ex.Message.Contains("is not a number, or is negative"));
            }
            catch (Exception ex)
            {
                Assert.IsFalse(ex.Message.Contains("Assert.Fail"));
                Assert.IsTrue(ex.Message.Length > 0, "Exception contained no message");
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