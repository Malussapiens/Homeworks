//Задача 2. Напишите программу, которая на вход принимает позиции элемента в 
//двумерном массиве, и возвращает значение этого элемента или же указание, 
//что такого элемента нет.
//Например, задан массив:
//1 4 7 2
//5 9 2 3
//8 4 2 4
//17 -> такого числа в массиве нет

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

int GetRandomInt(int minRandom, int maxRandom)  //возвращает вещественное число из диапазона [minRandom;maxRandom)
{
    return new Random().Next(minRandom, maxRandom);
}

int[,] CreateRandomMatrixInt(int rows, int columns, int minRandom = 0, int maxRandom = 10)   //возвращает случайную матрицу заданной размерности
{
    int[,] matrix = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = GetRandomInt(minRandom, maxRandom);
        }
    }
    return matrix;
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

bool IsInbound(int[,] matrix, int position)
{
    int mLength = matrix.GetLength(0) * matrix.GetLength(1);
    return (position > 0 && position <= mLength);
}

int GetNumByPosition(int[,] matrix, int position)
{
    int mCoord = (position - 1) / matrix.GetLength(0);
    int nCoord = (position - 1) % matrix.GetLength(1);
    return matrix[mCoord, nCoord];
}


Console.Clear();
PrintMsg("Программа принимает на вход позиции элемента в двумерном массиве, \n");
PrintMsg("и возвращает значение этого элемента или же указание,что такого элемента нет.\n");
PrintMsg("Отсчет позиции начинается с 1");
int mSize = 5, nSize = 5;   //задаем размерность матрицы
int lowRndLimit = 0, upRndLimit = 10; //задаем пределы случайных чисел
int[,] matrix = CreateRandomMatrixInt(mSize, nSize, lowRndLimit, upRndLimit);
PrintMsg("\n");
PrintMatrix(matrix);
int position = GetUserInput("Введите номер позиции");
int mLength = mSize * nSize;
if (!IsInbound(matrix, position))
    PrintMsg("Такого элемента не существует!");
else
    PrintMsg($"{position}-й элемент содержит значение {GetNumByPosition(matrix, position)}");
