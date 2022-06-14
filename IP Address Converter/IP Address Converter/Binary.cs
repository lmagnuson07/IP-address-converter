using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP_Address_Converter
{
    // handles conversions to hex and decimal, and stores all the equations for the current session so the user can print the equations - use uLong integer
    public class Binary
    {
        private string _OriginalInput;
        private string _ConvertedInput;
        private List<string> aInput;
        private List<string> aConvertedString;
        private List<ulong> validBinary;
        public string OriginalInput
        {
            get 
            { 
                return _OriginalInput;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("An input value is required to do a conversion and one was not entered");
                }
                if (value.Contains('.'))
                {
                    aInput = value.Split('.').ToList<string>();
                    foreach (var item in aInput)
                    {
                        if (!ulong.TryParse(item, out ulong temp))
                        {
                            throw new FormatException($"The input of {value} is not a number");
                        }
                    }
                }
                else
                {
                    if (!ulong.TryParse(value, out ulong temp))
                    {
                        throw new FormatException($"The input of {value} is not a number");
                    }
                }
                validBinary = new();
                try
                {
                    ValidateNumber(value);
                }
                catch (FormatException ex)
                {
                    throw new FormatException(ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    throw new ArgumentOutOfRangeException(ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Unexpected error: {ex.Message}");
                }
                _OriginalInput = value;
            }
        }
        public string ConvertedInput
        {
            get
            {
                return _ConvertedInput;
            }
            private set
            {
                if (Conversion == ConversionType.BinaryToDecimal)
                {
                    _ConvertedInput = ConvertToDecimal();
                }
                else if (Conversion != ConversionType.BinaryToHex)
                {

                }
            }
        }
        public ConversionType Conversion { get; private set; }

        public Binary (ConversionType conversion, string originalInput)
        {
            // validate each element is a number. 
            if (conversion != ConversionType.BinaryToDecimal || conversion != ConversionType.BinaryToHex)
            {
                throw new ArgumentException($"Incorrect conversion type was selected: {conversion}");
            }
            Conversion = conversion;
            OriginalInput = originalInput;
            ConvertedInput = originalInput;
        }
        private string ConvertToDecimal()
        {
            StringBuilder convertedDecimal = new();
            int index = 0;
            foreach (var item in validBinary)
            {
                double returnValueDouble = 0;
                for (int i = item.ToString().Length; i > 0; i--)
                {
                    if (item == 1)
                    {
                        returnValueDouble += 1 * Math.Pow(2, index);
                    }
                    index++;
                }
                aConvertedString.Add(returnValueDouble.ToString());
            }
            return convertedDecimal.AppendJoin(".", aConvertedString).ToString();
        }
        private void ValidateNumber(string input)
        {
            ulong temp = 0;
            if (input.Contains('.'))
            {
                List<string> aInput = input.Split('.').ToList<string>();
                foreach (var str in aInput)
                {
                    if (ulong.TryParse(str, out temp))
                    {
                        foreach (var item in str)
                        {
                            if (!Utilities.IsBinary(item))
                            {
                                throw new ArgumentOutOfRangeException($"The input of {input} is not a binary number");
                            }
                        }
                        validBinary.Add(temp);
                    }
                    else
                    {
                        throw new FormatException($"The binary value entered: {str} - is not a number, or it is a negative number");
                    }
                }
            }
            else
            {
                if (ulong.TryParse(input, out temp))
                {
                    foreach (var item in input)
                    {
                        if (!Utilities.IsBinary(item))
                        {
                            throw new ArgumentOutOfRangeException($"The input of {input} is not a binary number");
                        }
                    }
                    validBinary.Add(temp);
                }
                else
                {
                    throw new FormatException($"The binary value entered: {input} - is not a number, or it is a negative number");
                }
            }
        }
    }
}
