/*
Задача 3: Задайте массив вещественных чисел. Найдите разницу между 
максимальным и минимальным элементов массива.
[3 7 22 2 78] -> 76 
*/

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

double[] GetRandomArrayReal(int minRandom, int maxRandom, int arrSize) //Возвращает массив размерностью arrSize, заполненный случайными вещественными числами из диапазона [minRandom; maxRandom]
{
    double[] arr = new double[arrSize];

    for (int i = 0; i < arrSize; i++)
    {
        arr[i] = new Random().Next(minRandom, maxRandom + 1) + new Random().NextDouble();
    }
    return arr;
}

double[] CreateRandomArrayReal()
{
    int arrSize, minRandom, maxRandom;
    double[] arr = new double[0];
    arrSize = GetUserInput("Введите размерность массива (0/ENTER для восьми элементов)");
    if (Validate(arrSize))
    {
        minRandom = GetUserInput("Введите нижнюю границу диапазона (включительно)");
        maxRandom = GetUserInput("Введите верхнюю границу диапазона (включительно)");
        if (minRandom < maxRandom)
        {
            if (arrSize == 0) arrSize = 8;
            arr = GetRandomArrayReal(minRandom, maxRandom, arrSize);
            PrintMsg("Ваш массив: ");
            PrintArrayReal(arr);
        }
        else
        {
            PrintMsg("Нижняя граница должна быть меньше верхней!");
        }
    }
    return arr;
}

void PrintArrayReal(double[] array)
{
    foreach (double number in array)
    {
        Console.Write($"{number:N2} ");
    }
}

double FindMaxReal(double[] array)
{
    double max = array[0];
    for (int i = 1; i < array.Length; i++)
    {
        if (max < array[i])
        { max = array[i]; }
    }
    return max;
}

double FindMinReal(double[] array)
{
    double min = array[0];
    for (int i = 1; i < array.Length; i++)
    {
        if (min > array[i])
        { min = array[i]; }
    }
    return min;
}

Console.Clear();
PrintMsg("Программа находит разность между максимальным и минимальным элементом массива.\n");
double[] arr = CreateRandomArrayReal();
double max = FindMaxReal(arr);
double min = FindMinReal(arr);
PrintMsg($"\nМаксимальное значение: {max:N2}");
PrintMsg($"\nМинимальное значение: {min:N2}");
PrintMsg($"\nРазность составляет: {max - min:N2}");