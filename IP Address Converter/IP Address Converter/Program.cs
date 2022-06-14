// See https://aka.ms/new-console-template for more information

char menuChoice = ' ';

while(menuChoice != 'x')
{
    string input = "";
    menuChoice = GetMenuChoice();
    switch (menuChoice)
    {
        case '1': // Binary to decimal
            {
                Console.WriteLine("\tEnter a binary number (i.e 1's and 0's only) \n\t>> ");
                input = Console.ReadLine();

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
        //case 'x':
        //    {
        //        break;
        //    }
        default:
            {
                break;
            }
    } // ends switch 
} // ends while 
Console.WriteLine("\n\tThanks for using Conversion Calculator");

static char GetMenuChoice()
{
    (char, bool) validCharRtn;
    bool bLoop = true;
    char menuChoice = ' ';
    while (bLoop)
    {
        Console.Clear();
        Console.WriteLine("\t****** Choose your conversion type *****\n");
        Console.WriteLine("\t{0,2}1. Binary to Decimal", "");
        Console.WriteLine("\t{0,2}2. Binary to Hexadecimal", "");
        Console.WriteLine("\t{0,2}3. Decimal to Binary", "");
        Console.WriteLine("\t{0,2}4. Decimal to Hexadecimal", "");
        Console.WriteLine("\t{0,2}5. Hexadecimal to Binary", "");
        Console.WriteLine("\t{0,2}6. Hexadecimal to decimal", "");
        Console.WriteLine("\t{0,2}x. Exit", "");
        Console.WriteLine("\n\t****************************************\n");
        if (bLoop && menuChoice != ' ')
        {
            Console.WriteLine("\tInvalid input... try again.\n");
            validCharRtn = GetValidChar("\tEnter your selection >> ");
            menuChoice = validCharRtn.Item1;
            bLoop = validCharRtn.Item2;
        }
        else
        {
            validCharRtn = GetValidChar("\tEnter your selection >> ");
            menuChoice = validCharRtn.Item1;
            bLoop = validCharRtn.Item2;
        }
    }
    
    return menuChoice;
} // Display and get menu
static (char, bool) GetValidChar(string prompt)
{
    bool bLoop = true;
    char letter = ' ';
    Console.Write(prompt);
    if (char.TryParse(Console.ReadLine(), out letter))
    {
        bLoop = false;
    }
    return (letter, bLoop);
} // UserChoiceAfterConversion