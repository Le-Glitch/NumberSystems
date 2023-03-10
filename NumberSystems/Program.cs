using System;

string number = "";
string startNumber;
int integer = 0;
int startBase = 0;
int newBase = 0;
bool isInt = false;
bool validNumber = false;

Console.WriteLine("What number do you want to convert?");
number = Console.ReadLine();

startNumber = number;

isInt = false;

Console.WriteLine("What base is this number in? (max 16)");
while (!validNumber)
{
    while (!isInt)
    {
        isInt = int.TryParse(Console.ReadLine(), out startBase);
    }

    // Working with higher bases is annoying
    if (startBase > 16)
    {
        validNumber = false;
        isInt = false;
    }

    // If the base is less or equal to 10 then all digits are between 0 - 9
    else if (startBase <= 10)
    {
        for (int i = 0; i < number.Length; i++)
        {
            if (!(number[i] >= '0' && number[i] < ('0' + startBase)))
            {
                validNumber = false;
                isInt = false;
                break;
            }
            else
            {
                validNumber = true;
            }
        }

    }

    // If the base if between 10 and 16 then digits can be from 0 - 9 and A - F
    else if (startBase > 10 && startBase <= 16)
    {
        for (int i = 0; i < number.Length; i++)
        {
            if (!((number[i] >= '0' && number[i] < ('0' + startBase)) || (number[i] >= 'A' && number[i] < ('A' + startBase - 10))))
            {
                validNumber = false;
                isInt = false;
                break;
            }
            else
            {
                validNumber = true;
            }
        }
    }

    if (!validNumber)
    {
        Console.WriteLine("That base is not valid for the given number");
    }
}

isInt = false;

Console.WriteLine("What base do you want to convert it to? (max 16)");
while (!isInt && newBase <= 16)
{
    isInt = int.TryParse(Console.ReadLine(), out newBase);
}

integer = BaseAToDecimal(number, startBase);
number = DecimalToBaseB(integer, newBase);

Console.WriteLine($"{startNumber}, base {startBase} in base {newBase} is {number}");
Console.ReadLine();


int val(char c)
{
    if (c >= '0' && c <= '9')
        return (int)c - '0';
    else
        return (int)c - 'A' + 10;
}

int BaseAToDecimal(string str, int fromBase)
{
    int len = str.Length;
    int power = 1; 
    int num = 0; 
    int i;

    for (i = len - 1; i >= 0; i--)
    {
        if (val(str[i]) >= fromBase)
        {
            Console.WriteLine("Invalid Number");
            return -1;
        }

        num += val(str[i]) * power;
        power = power * fromBase;
    }

    return num;
}

string DecimalToBaseB(int value, int toBase)
{
    string result = "";

    while (value > 0)
    {
        result = "0123456789ABCDEF"[value % toBase] + result;
        value /= toBase;
    }

    return result;
}