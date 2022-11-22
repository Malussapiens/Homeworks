//Задача 3: Задайте две матрицы. Напишите программу, 
//которая будет находить произведение двух матриц.

// Алгоритм умножения матриц
// 1. Умножаем элементы в строках первой матрицы на элементы в столбцах второй матрицы.

//  -Умножаем элементы первой строки на элементы первого столбца.
//  -Умножаем первый элемент первой строки на первый элемент первого столбца.
//  -Умножаем второй элемент первой строки на второй элемент первого столбца.
//  -Делаем то же самое с каждым элементом, пока не дойдем до конца как первой строки первой матрицы,
//   так и первого столбца второй матрицы.
//  -Складываем полученные произведения.
// Полученный результат будет первым элементом первой строки произведения матриц.

// 2. Умножаем элементы первой строки первой матрицы на элементы второго столбца второй матрицы.
//  -Умножаем первый элемент первой строки на первый элемент второго столбца.
//  -Умножаем второй элемент первой строки на второй элемент второго столбца.
//  -Делаем то же самое с каждым элементом, пока не дойдем до конца как первой строки первой матрицы, так и второго столбца второй матрицы.
//  -Складываем полученные произведения.
// Полученный результат будет вторым элементом первой строки произведения матриц.

// Применяя тот же самый алгоритм, умножаем элементы первой строки первой матрицы на элементы
// остальных столбцов второй матрицы. Полученные числа составят первую строку вычисляемой матрицы.

// Вторая строка вычисляемой матрицы находится аналогично умножением элементов второй строки первой матрицы на элементы каждого столбца второй матрицы: результаты записываются в новую матрицу после каждого суммирования.
// Делаем это с каждой строкой первой матрицы, пока все строки новой матрицы не будут заполнены.

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
    while(true)
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

bool IsMultipliable(int[,] matrixA, int[,] matrixB) //если кол-во строк первой матрицы не равно кол-ву столбцов второй - умножать нельзя
{
    return matrixA.GetLength(1) == matrixB.GetLength(0);
}

int[,] MultiplyMatrix(int[,] matrixA, int[,] matrixB)
{
    int[,] resultMatrix = CreateMatrix((uint)matrixA.GetLength(0), (uint)matrixB.GetLength(1));
    for (int i = 0; i < matrixA.GetLength(0); i++)
    {
        for (int j = 0; j < matrixB.GetLength(1); j++)
        {
            int sum = 0;
            for (int k = 0; k < matrixB.GetLength(0); k++)
            {
                sum += matrixA[i, k] * matrixB[k, j];
            }
            resultMatrix[i, j] = sum;
        }
    }
    return resultMatrix;
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

Console.Clear();
const int a = 0, b = 1;
const int row = 0, column = 1;
uint[,] dimensions = new uint[2, 2];
for (int i = 0; i < dimensions.GetLength(0); i++)
{
    PrintMsg($"Размерность {i + 1}-ой матрицы:\n");
    dimensions[i, row] = GetUserInput("m=");
    dimensions[i, column] = GetUserInput("n=");
}
uint rowsA = dimensions[a, row], columnsA = dimensions[a, column];
uint rowsB = dimensions[b, row], columnsB = dimensions[b, column];
int[,] matrixA = FillMatrixRandomInt(CreateMatrix(rowsA, columnsA));
int[,] matrixB = FillMatrixRandomInt(CreateMatrix(rowsB, columnsB));

PrintMsg("Матрица А:\n");
PrintMatrix(matrixA);
PrintMsg("\nМатрица B:\n");
PrintMatrix(matrixB);
if (!IsMultipliable(matrixA, matrixB))
{
    PrintMsg("Матрицы не подлежат перемножению!");
    return;
}

int[,] resultMatrix = MultiplyMatrix(matrixA, matrixB);
PrintMsg("\nРезультат:\n");
PrintMatrix(resultMatrix);