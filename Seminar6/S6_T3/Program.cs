// Задача 3. (*) Найдите максимальное значение в матрице по каждой строке,
// получите сумму этих максимумов. Затем найдите минимальное значение по каждой колонке,
// получите сумму этих минимумов. Затем из первой суммы (с максимумами)
// вычтите вторую сумму(с минимумами)
// 1 2 3
// 3 4 5
// 3+5=8, 1+2+3=6, 8-6=2

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

bool ValidateRange(int minRange, int maxRange)
{
    return minRange < maxRange;
}

void PrintArrayReal(double[] array, string delimiter) //выводит содержимое массива на экран через строку-разделитель
{
    Console.Write($"{array[0]:N2}");
    for (int i = 1; i < array.Length; i++)
    {
        Console.Write($"{delimiter}{array[i]:N2}");
    }
}

double SumArrayReal(double[] array) //выводит содержимое массива на экран
{
    double sum = 0;
    foreach (double num in array)
    {
        sum += num;
    }
    return sum;
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
            Console.Write($"{matrix[i, j]:f2} ");
        }
        Console.Write("\n");
    }
}

double GetMaxInRow(double[,] matrix, int row)   //Возвращает наибольшее значение в ряду матрицы
{
    double max = matrix[row, 0];
    for (int i = 1; i < matrix.GetLength(0); i++)
    {
        if (max < matrix[row, i])
            max = matrix[row, i];
    }
    return max;
}

double GetMinInColumn(double[,] matrix, int column) //Возвращает наименьшее значение в столбце матрицы
{
    double min = matrix[0, column];
    for (int i = 1; i < matrix.GetLength(0); i++)
    {
        if (min > matrix[i, column])
            min = matrix[i, column];
    }
    return min;
}

double[] GetMaximumsInRows(double[,] matrix)  //Возвращает массив с максимумами в строках матрицы
{
    int counter = matrix.GetLength(0);
    double[] array = new double[counter];
    for (int i = 0; i < counter; i++)
    {
        array[i] = GetMaxInRow(matrix, i);
    }
    return array;
}

double[] GetMinimumsInRows(double[,] matrix)  //Возвращает массив с минимумами в столбцах матрицы
{
    int counter = matrix.GetLength(1);
    double[] array = new double[counter];
    for (int i = 0; i < counter; i++)
    {
        array[i] = GetMinInColumn(matrix, i);
    }
    return array;
}

//1. Создаем матрицу (размерность запросим у пользователя) и печатаем ее
int dimX = GetUserInput("Введите количество строк матрицы");
if (!ValidateBiggerZero(dimX))
    return;

int dimY = GetUserInput("Введите количество столбцов матрицы");
if (!ValidateBiggerZero(dimY))
    return;

int minRandom = (int)GetUserInput("Введите нижний предел значений");
int maxRandom = (int)GetUserInput("Введите верхний предел");
if (!ValidateRange(minRandom, maxRandom))
{
    PrintMsg("Верхний предел должен быть больше нижнего!");
    return;
}

double[,] matrix = CreateRandomMatrix(dimX, dimY, minRandom, maxRandom);

PrintMsg("Ваша матрица:\n");
PrintMatrixReal(matrix);

double[] array = GetMaximumsInRows(matrix);   //2. Получаем массив максимумов в ряду и 
                                        // печатаем сумму элементов массива.
PrintMsg("\nСумма максимумов в рядах: ");
PrintArrayReal(array, " + ");
PrintMsg(" = ");
double sumMax = SumArrayReal(array);    //Запоминаем сумму максимумов в строке
PrintMsg($"{sumMax:f2}");

array = GetMinimumsInRows(matrix);    //3. Получаем массив минимумов в ряду и
                                // печатаем сумму элементов массива.
PrintMsg("\nСумма минимумов в столбцах: ");
PrintArrayReal(array, " + ");
PrintMsg(" = ");
double sumMin = SumArrayReal(array);    //Запоминаем сумму минимумов в строке
PrintMsg($"{sumMin:f2}");

PrintMsg("\nРазность максимумов и минимумов: ");    //4. Выводим разность максимумов и минимумов.
PrintMsg($"{sumMax:f2} - {sumMin:f2} = {sumMax - sumMin:f2}");