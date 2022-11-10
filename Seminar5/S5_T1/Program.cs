// Задача 1: Задайте массив заполненный случайными положительными трёхзначными числами.
// Напишите программу, которая покажет количество чётных чисел в массиве.

// [345, 897, 568, 234] -> 2

void PrintMsg(string message)   //выводим сообщение на экран
{
    Console.Write(message);
}

int GetUserInput(string message) //Принимает ввод от пользователя
{
    PrintMsg($"{message}:>");
    string input = Console.ReadLine();
    if (input == "") return 0;
    return int.Parse(input);
}

bool Validate(int number) //проверяем, что число больше нуля
{
    if (number < 0)
    {
        PrintMsg("Число должно быть больше нуля!");
        return false;
    }
    return true;
}

int[] GetRandomArray(int minRandom, int maxRandom, int arrSize) //Возвращает массив размерностью arrSize, заполненный случайными числами из диапазона [minRandom; maxRandom]
{
    Console.WriteLine(arrSize);
    int[] arr = new int[arrSize];

    for (int i = 0; i < arrSize; i++)
    {
        arr[i] = new Random().Next(minRandom, maxRandom + 1);
    }
    return arr;
}

void PrintArray(int[] array)
{
    foreach (int number in array)
    {
        Console.Write($"{number} ");
    }
}

int EvenCount(int[] array)  //Подсчитывает количество четных чисел в массиве
{
    int count = 0;
    foreach (int integer in array)
    {
        if (integer % 2 == 0)
        { count++; }
    }
    return count;
}

Console.Clear();
PrintMsg("Программа покажет количество чётных чисел в массиве.\n");
int arrSize = GetUserInput("Введите размерность массива");
int min = 100, max = 999;
int[] array = GetRandomArray(min, max, arrSize);
PrintArray(array);
Console.WriteLine();
Console.WriteLine($"В массиве содержится {EvenCount(array)} целых чисел\n");