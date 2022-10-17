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

bool IsNumber(string input) //Проверка, является ли ввод числом
{
    int result;
    return int.TryParse(input, out result);
}


bool ValidateInput(int number)   //Проверяет, является ли число трехзначным
{
    return (number > 99) && (number < 1000);
}

void PrintMsg(string message)
{
    Console.WriteLine(message);
}


Console.Clear();
string input = GetUserInput("Введите трехзначное число: ");

if (!IsNumber(input))    //Проверка, является ли ввод числом
{ PrintMsg("Введите трехзначное число!"); }
else
{
    int number=int.Parse(input);
    if (ValidateInput(number))
    { PrintMsg($"Второй разряд числа {number} -> {((int)number / 10) % 10}"); }    //Выводим второй разряд числа.
    else
    { PrintMsg("Введите трехзначное число!"); }
}
