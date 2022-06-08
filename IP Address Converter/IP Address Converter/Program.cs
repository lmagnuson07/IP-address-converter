// See https://aka.ms/new-console-template for more information

char menuChoice = ' ';

while(menuChoice != 'x')
{
    menuChoice = GetMenuChoice();
    switch (menuChoice)
    {
        case '1': // Binary to decimal
            {
                break;
            }
        case '2': // Binary to hexadecimal
            {
                break;
            }
        case '3': // Decimal to binary
            {
                break;
            }
        case '4': // Decimal to hexadecimal
            {
                break;
            }
        case '5': // Hexadecimal to binary 
            {
                break;
            }
        case '6': // Hexadecimal to decimal
            {
                break;
            }
        case 'x':
            {
                break;
            }
        default:
            {
                break;
            }
    } // ends switch 
} // ends while 

Console.WriteLine("Thanks for using Conversion Calculator");

static char GetMenuChoice()
{
    Console.WriteLine("\t****** Choose your conversion type *****\n");
    Console.WriteLine("\t{0,2}1. Binary to Decimal", "");
    Console.WriteLine("\t{0,2}2. Binary to Hexadecimal", "");
    Console.WriteLine("\t{0,2}3. Decimal to Binary", "");
    Console.WriteLine("\t{0,2}4. Decimal to Hexadecimal", "");
    Console.WriteLine("\t{0,2}5. Hexadecimal to Binary", "");
    Console.WriteLine("\t{0,2}6. Hexadecimal to decimal", "");
    Console.WriteLine("\t{0,2}x. Exit", "");
    Console.WriteLine("\n\t****************************************\n");
    return GetValidChar($"\tEnter your selection >> ");
} // Display and get menu
static char GetValidChar(string prompt)
{
    char letter = ' ';
    Console.Write(prompt);
    if (!char.TryParse(Console.ReadLine(), out letter))
    {
        Console.WriteLine("\n\tInvalid input... try again.\n");
    }
    return letter;
} // UserChoiceAfterConversion