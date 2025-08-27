// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Text.RegularExpressions;

///Console.WriteLine("Hello, World!");
///

int nDigits = args.Length;
Console.WriteLine(args.Length);

string pattern = String.Empty;
StringBuilder myPatternStr = new StringBuilder(@"^(");
for (int i = 0; i < args.Length; i++)
{
    string arg = args[i];

    myPatternStr.Append(@"[" + arg + "]");
}

myPatternStr.Append(@")$");

Console.WriteLine(myPatternStr);

string filePath = "words.txt";

pattern = myPatternStr.ToString();

//String pattern = @"^([stga][hlre][oleb][vrde][eats][srhe])$";

int wordindex = 1;


try
{
    foreach (string line in File.ReadLines(filePath))
    {
        if (line.Length == nDigits)
        {
            Match match = Regex.Match(line, pattern, RegexOptions.IgnoreCase); // Case-insensitive match

            if (match.Success)
            {
                Console.WriteLine(wordindex++ + " " + line);
            }
        }
    }
}
// File does not exist...
catch (Exception err)
{
    Console.WriteLine("FILE NOT FOUND!");
    Console.WriteLine(err);
}
