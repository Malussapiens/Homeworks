//Задача 3: Напишите программу, которая выводит массив из 8 элементов, 
//заполненный случайными числами. Оформите заполнение массива и вывод в виде функции 
//(пригодится в следующих задачах).  Реализовать через функции. 
//(* Доп сложность, “введите количество элементов массива”, 
//“Введите минимальный порог случайных значений”, 
//“Введите максимальный порог случайных значений”)

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

Console.Clear();
PrintMsg("Программа выводит массив из заданного количества элементов (по умолчанию = 8),\n");
PrintMsg("заполненный случайными числами из указанного пользователем диапазона\n");
int arrSize, minRandom, maxRandom;
arrSize = GetUserInput("Введите размерность массива");
if (Validate(arrSize))
{
    minRandom = GetUserInput("Введите нижнюю границу диапазона (включительно)");
    maxRandom = GetUserInput("Введите верхнюю границу диапазона (включительно)");
    if (minRandom < maxRandom)
    {
        if (arrSize == 0) arrSize=8;
        int[] arr = GetRandomArray(minRandom, maxRandom, arrSize);
        PrintMsg("Ваш массив: ");
        PrintArray(arr);
    }
    else PrintMsg("Нижняя граница должна быть меньше верхней!");
}