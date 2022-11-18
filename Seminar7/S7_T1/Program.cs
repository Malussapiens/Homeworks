//Задача 1. Задайте двумерный массив размером m×n,
//заполненный случайными вещественными числами.
//m = 3, n = 4.
//0,5 7 -2 -0,2
//1 -3,3 8 -9,9
//8 7,8 -7,1 9

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

bool ValidateBiggerZero(int number) //проверяем, что число больше нуля
{
    if (number < 0)
    {
        PrintMsg("Число должно быть больше нуля!");
        return false;
    }
    return true;
}

double GetRandomReal(int minRandom, int maxRandom)  //возвращает вещественное число из диапазона [minRandom;maxRandom)
{
    return new Random().Next(minRandom, maxRandom) + new Random().NextDouble();
}

double[,] CreateRandomMatrix(int rows, int columns, int minRandom = 0, int maxRandom = 10)   //возвращает случайную матрицу заданной размерности
{
    double[,] matrix = new double[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = GetRandomReal(minRandom, maxRandom);
        }
    }
    return matrix;
}

void PrintMatrixReal(double[,] matrix)  //Выводит на экран матрицу вещественных чисел
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]:f2}\t");
        }
        Console.Write("\n");
    }
}


Console.Clear();
PrintMsg("Программа генерирует двумерный массив размерностью m*n \n");
PrintMsg("заполненный случайными вещественными числами.\n");
int mSize = GetUserInput("Введите размерность m");
if (!ValidateBiggerZero(mSize))
    return;
int nSize = GetUserInput("Введите размерность n");
if (!ValidateBiggerZero(nSize))
    return;
int lowRndLimit = -10;
int upRndLimit = 10;
double[,] matrix = CreateRandomMatrix(mSize, nSize, lowRndLimit, upRndLimit);
PrintMsg("Ваша матрица:\n");
PrintMatrixReal(matrix);
