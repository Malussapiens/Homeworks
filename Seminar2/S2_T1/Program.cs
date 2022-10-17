// Задача 1: Напишите программу, которая принимает на вход трёхзначное число и 
// на выходе показывает вторую цифру этого числа. Не использовать строки для расчета.

// 456 -> 5
// 782 -> 8
// 918 -> 1

string GetUserInput(string message)
{
    Console.Write("Введите трехзначное число: ");
    return Console.ReadLine();
}

bool ValidateInput(double number)
{
    return (number > 99) && (number < 1000);
}

void ErrorMsg(string message)
{
    Console.WriteLine("Введите трехзначное число!");
}


Console.Clear();
string input = GetUserInput("Введите трехзначное число: ");
double number;

if (!double.TryParse(input, out number))
{ ErrorMsg("Введите трехзначное число!"); }
else
{
    if (ValidateInput(number))
    { Console.WriteLine($"Второй разряд числа {number} -> {((int)number / 10) % 10}"); }
    else
    { ErrorMsg("Введите трехзначное число!"); }
}
