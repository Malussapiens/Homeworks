// Задача 2: Задайте прямоугольный двумерный массив. Напишите программу, 
// которая будет находить строку с наименьшей суммой элементов.

void PrintMsg(string message)   //выводим сообщение на экран
{
    Console.Write(message);
}

uint ParseUserInput(string message) //Принимает ввод от пользователя
{
    PrintMsg($"{message}:>");
    uint intNumber;
    if (uint.TryParse(Console.ReadLine(), out intNumber))
        return intNumber;
    throw new Exception("Требуется положительное целое число!");
}


uint GetUserInput(string message)
{
    while (true)
        try
        {
            return ParseUserInput(message);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка ввода: {e.Message}");
        }
}

int[,] CreateMatrix(uint nSize, uint mSize)
{
    return new int[nSize, mSize];
}

void PrintMatrix(int[,] matrix)  //Выводит на экран содержимое матрицы

{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]}\t");
        }
        Console.Write("\n");
    }
}

int GetRandomInt(int minRandom, int maxRandom)  //возвращает целое число из диапазона [minRandom;maxRandom)
{
    return new Random().Next(minRandom, maxRandom);
}

int[,] FillMatrixRandomInt(int[,] matrix, int minRandom = 0, int maxRandom = 10)   //возвращает случайную матрицу заданной размерности
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = GetRandomInt(minRandom, maxRandom);
        }
    }
    return matrix;
}

int GetSumOfRow(int[,] matrix, uint row)
{
    int sum = 0;
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        sum += matrix[row, i];
    }
    return sum;
}

uint GetSmallestSumRow(int[,] matrix)
{
    int minSum = GetSumOfRow(matrix, 0);
    uint row = 0;
    for (uint i = 1; i < matrix.GetLength(0); i++)
    {
        int sum = GetSumOfRow(matrix, i);
        if (minSum > sum)
            row = i;
    }
    return row;
}

Console.Clear();
PrintMsg("Программа находит строку с наименьшей суммой элементов двумерного массива.\n");
PrintMsg("Введите размерность матрицы:");
uint nSize = GetUserInput("строк=");
uint mSize = GetUserInput("столбцов=");
int[,] matrix = FillMatrixRandomInt(CreateMatrix(nSize, mSize));
PrintMsg("\nВаша матрица:\n");
PrintMatrix(matrix);
PrintMsg($"Наименьшая сумма элементов в ряду {GetSmallestSumRow(matrix) + 1}");