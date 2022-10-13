//Задача 2: Напишите программу, которая принимает на вход три числа и выдаёт максимальное из этих чисел.
Console.WriteLine("Программа принимает на вход три числа и выдаёт максимальное из этих чисел.");
int[] numbers = new int[3];     //создаем массив размерностью [3]
int i = 0;                        //переменная-счетчик
while (i < numbers.Length)
{     //заполняем массив
    Console.Write($"Введите {i + 1}-e число:>");    //последовательно запрашивая
    numbers[i] = int.Parse(Console.ReadLine());       // у пользователя числа
    i++;
}

int max = numbers[0];
i = 1;
while (i < numbers.Length)
{
    if (max < numbers[i]) { max = numbers[i]; }
    i++;
}

Console.WriteLine($"max={max}");