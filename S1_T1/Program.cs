//Задача 1: Напишите программу, 
//которая на вход принимает два числа 
//и выдаёт, какое число большее, а какое меньшее.

Console.WriteLine("Данная программа принимает на вход 2 числа и сообщает, какое число большее, а какое меньшее.");
Console.Write("Введите 1-е число:>");
int firstNum = int.Parse(Console.ReadLine());
Console.Write("Введите 2-е число:>");
int secondNum = int.Parse(Console.ReadLine());
int min, max;
if (firstNum > secondNum) { max = firstNum; min = secondNum; }
else { max = secondNum; min = firstNum; }
Console.WriteLine($"max={max}, min={min}");