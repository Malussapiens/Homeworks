// Задача 4: * Напишите программу, которая заполнит спирально квадратный массив. 

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

int FillHorizonalLeftRight(int[,] matrix, int row, int left, int right, int countStart)
{
    int count = countStart;
    for (int i = left; i < right; i++)
    {
        matrix[row, i] = count++;
    }
    return count;
}

int FillHorizonalRightLeft(int[,] matrix, int row, int left, int right, int countStart)
{
    int count = countStart;
    for (int i = right - 1; i >= left; i--)
    {
        matrix[row, i] = count++;
    }
    return count;
}

int FillVerticalUpDown(int[,] matrix, int column, int up, int down, int countStart)
{
    int count = countStart;
    for (int i = up; i < down; i++)
    {
        matrix[i, column] = count++;
    }
    return count;
}

int FillVerticalDownUp(int[,] matrix, int column, int up, int down, int countStart)
{
    int count = countStart;
    for (int i = down - 1; i >= up; i--)
    {
        matrix[i, column] = count++;
    }
    return count;
}

int[,] GetSpiralMatrix(uint size)
{
    int[,] matrix = CreateMatrix(size, size);
    int left = 0, right = matrix.GetLength(1);
    int up = 0, down = matrix.GetLength(0);
    int countStart = 0;
    while (countStart < (size * size))
    {
        countStart = FillHorizonalLeftRight(matrix, up, left, right, countStart);
        up++;
        countStart = FillVerticalUpDown(matrix, right - 1, up, down, countStart);
        right--;
        countStart = FillHorizonalRightLeft(matrix, down - 1, left, right, countStart);
        down--;
        countStart = FillVerticalDownUp(matrix, left, up, down, countStart);
        left++;
    }
    return matrix;
}

Console.Clear();
PrintMsg("Программа заполняет по спирали квадратный массив.\n");
uint size = GetUserInput("Введите размерность матрицы:");
int[,] matrix = GetSpiralMatrix(size);

PrintMatrix(matrix);

// int[,] Spiral(int n)
// {
//     int[,] result = new int[n, n];

//     int pos = 1;
//     int count = n;
//     int value = -n;
//     int sum = -1;

//     do
//     {
//         value = -1 * value / n;
//         Console.WriteLine(value);
//         Console.ReadLine();
//         for (int i = 0; i < count; i++)
//         {
//             sum += value;
//             result[sum / n, sum % n] = pos++;
//         }
//         value *= n;
//         count--;
//         for (int i = 0; i < count; i++)
//         {
//             sum += value;
//             result[sum / n, sum % n] = pos++;
//         }
//     } while (count > 0);

//     return result;
// }

