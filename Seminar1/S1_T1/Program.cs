//Задача 1: Напишите программу, 
//которая на вход принимает два числа 
//и выдаёт, какое число большее, а какое меньшее.

Console.WriteLine("Данная программа принимает на вход 2 числа и сообщает, какое число большее, а какое меньшее.");
Console.Write("Введите 1-е число:>");
int firstNum = int.Parse(Console.ReadLine());   //принимаем от пользователя 1-е число
Console.Write("Введите 2-е число:>");
int secondNum = int.Parse(Console.ReadLine());  //принимаем от пользователя 2-е число
int min, max;
//присваиваем min, max
if (firstNum > secondNum) { max = firstNum; min = secondNum; }  //если 1-е больше 2-го
else { max = secondNum; min = firstNum; }   //иначе 2-е больше 1-го
Console.WriteLine($"max={max}, min={min}"); //выводим результат.