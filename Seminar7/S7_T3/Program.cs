//Задача 3. Задайте двумерный массив из целых чисел.
//Найдите среднее арифметическое элементов в каждом столбце.

//Например, задан массив:
//1 4 7 2
//5 9 2 3
//8 4 2 4
//Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

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

void PrintMeanInColumns(int[,] matrix)
{

    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        double sum = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
            sum += matrix[i, j];
        Console.Write($"{sum / matrix.GetLength(0):f2}\t");
    }
}

Console.Clear();
PrintMsg("Программа находит среднее арифметическое элементов в каждом столбце\n");
PrintMsg("двумерного массива случайных целых чисел.");
int mSize = 5, nSize = 5;   //задаем размерность матрицы
int lowRndLimit = 0, upRndLimit = 10; //задаем пределы случайных чисел
int[,] matrix = CreateRandomMatrixInt(mSize, nSize, lowRndLimit, upRndLimit);
PrintMsg("\n");
PrintMatrix(matrix);
PrintMsg("\n");
PrintMeanInColumns(matrix);