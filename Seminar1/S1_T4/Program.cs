﻿//Задача 4: Напишите программу, которая на вход принимает число (N), а на выходе показывает все чётные числа от 1 до N.
Console.WriteLine("Программа принимает на вход число (N), а на выходе показывает все чётные числа от 1 до N.");
Console.Write("Введите число:>");
int num = int.Parse(Console.ReadLine());    //принимаем от пользователя число

if (num <= 0)   //проверяем, является ли число натуральным
{
    Console.WriteLine("Введите положительное число!");  //если нет, то выводим предупреждение
    return; //и завершаем работу
}

int i = 1;
if (!IsEven(num)) { num -= 1; } //если введено нечетное число, уменьшаем его на 1 (нет смысла выводить нечетное)
while (i < num) //в цикле считаем до num-1
{
    if (IsEven(i)) { Console.Write($"{i}, "); } //и выводим четные числа через запятую, кроме последнего
    i++;
}
Console.Write($"{i}");   //выводим последнее число. Проверять нет смысла, т.к. оно заведомо четное.

bool IsEven(int num)    //функция проверяет число на четность
{
    bool even = false;  //изначально считаем число нечетным, устанавливаем переменную в false
    if (num % 2 == 0) { even = true; }      //Если число четное, устанавливаем в true
    return even;    //возвращаем результат
}