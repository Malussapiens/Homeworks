//Задача 1: Задайте двумерный массив. Напишите программу,
//которая упорядочивает по убыванию элементы каждой строки двумерного массива.

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

void Swap(int[,] matrix, uint i1, uint j1, uint i2, uint j2)
{
    (matrix[i1, j1], matrix[i2, j2]) = (matrix[i2, j2], matrix[i1, j1]);
}

void SortRow(int[,] matrix, uint row)
{
    int end = matrix.GetLength(1);
    while (end > 1)
    {
        for (uint i = 1; i < end; i++)
        {
            if (matrix[row, i] > matrix[row, i - 1]) Swap(matrix, row, i, row, i - 1);
        }
        end--;
    }
}

void SortRowsOfMatrix(int[,] matrix)
{
    for (uint i = 0; i < matrix.GetLength(0); i++) SortRow(matrix, i);
}

Console.Clear();
PrintMsg("Программа упорядочивает по убыванию элементы каждой строки двумерного массива.\n");
PrintMsg("Введите размерность матрицы:");
uint nSize = GetUserInput("строк=");
uint mSize = GetUserInput("столбцов=");
int[,] matrix = FillMatrixRandomInt(CreateMatrix(nSize, mSize));
PrintMsg("\nВаша матрица:\n");
PrintMatrix(matrix);
SortRowsOfMatrix(matrix);
PrintMsg("\nМатрица отсортированная по рядам:\n");
PrintMatrix(matrix);