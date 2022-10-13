//Задача 3: Напишите программу, которая на вход принимает число и выдаёт, является ли число чётным (делится ли оно на два без остатка).
Console.WriteLine("Программа принимает на вход число и выдаёт, является ли число чётным.");
Console.Write("Введите число:>");
int number = int.Parse(Console.ReadLine());
if (IsEven(number)) { Console.WriteLine("Число четное!"); }
else { Console.WriteLine("Число нечетное!"); }

bool IsEven(int num)
{
    bool even = false;
    if (num % 2 == 0) { even = true; }
    return even;
}