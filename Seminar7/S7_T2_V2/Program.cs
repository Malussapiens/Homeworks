//Задача 2. Напишите программу, которая на вход принимает позиции элемента в 
//двумерном массиве, и возвращает значение этого элемента или же указание, 
//что такого элемента нет.
//Например, задан массив:
//1 4 7 2
//5 9 2 3
//8 4 2 4
//17 -> такого числа в массиве нет

//вариант решения после консультации (поиск элемента матрицы по координатам)

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

int GetRandomInt(int minRandom, int maxRandom)  //возвращает целое число из диапазона [minRandom;maxRandom)
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

bool IsInbound(int[,] matrix, int mPos, int nPos)
{
    return (mPos >= 0 && mPos < matrix.GetLength(0)
            && nPos >= 0 && nPos < matrix.GetLength(1));
}

int GetElementByPosition(int[,] matrix, int mPos, int nPos)
{
    return matrix[mPos, nPos];
}

Console.Clear();
PrintMsg("Программа принимает на вход позиции элемента в двумерном массиве (строка и столбец), \n");
PrintMsg("и возвращает значение этого элемента или же указание,что такого элемента нет.\n");
PrintMsg("Отсчет позиции начинается с 1");
int mSize = 5, nSize = 3;   //задаем размерность матрицы
int lowRndLimit = 0, upRndLimit = 10; //задаем пределы случайных чисел
int[,] matrix = CreateRandomMatrixInt(mSize, nSize, lowRndLimit, upRndLimit);
PrintMsg("\n");
PrintMatrix(matrix);
int mPos = GetUserInput("Введите номер строки (m, нумерация с 1)");
int nPos = GetUserInput("Введите столбца столбца (n, нумерация с 1)");
if (!IsInbound(matrix, mPos - 1, nPos - 1))
    PrintMsg("Такого элемента не существует!");
else
    PrintMsg($"Элемент в {mPos} строке и {nPos} столбце содержит значение {GetElementByPosition(matrix, mPos - 1, nPos - 1)}");

