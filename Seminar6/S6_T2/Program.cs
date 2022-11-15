// Задача 2: Напишите программу, которая найдёт точку пересечения двух прямых,
// заданных уравнениями y = k1 * x + b1, y = k2 * x + b2;
// значения b1, k1, b2 и k2 задаются пользователем.
// b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)

void PrintMsg(string message)   //выводим сообщение на экран
{
    Console.Write(message);
}

double GetUserInput(string message) //Принимает ввод от пользователя
{
    PrintMsg($"{message}:>");
    string input = Console.ReadLine();
    if (input == "") return 0;
    return double.Parse(input);
}

void PrintArrayReal(double[] array) //выводит содержимое массива на экран
{
    Console.Write($"{array[0]:N2}");
    for (int i = 1; i < array.Length; i++)
    {
        Console.Write($";{array[i]:N2}");
    }
}

double[,] CreateMatrix(int rows, int columns)   //возвращает матрицу заданной размерности
{
    double[,] matrix = new double[rows, columns];
    return matrix;
}

double[,] GetCoeffs(double[,] matrix)   //заполняет матрицу 2х2 значениями коэффициентов
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        matrix[i, 1] = GetUserInput($"Введите коэффициент b{i}");
        matrix[i, 0] = GetUserInput($"Введите коэффициент k{i}");
    }
    return matrix;
}

bool IsParallel(double[,] coordinates)  //если k1=k2 и b1!=b2, то прямые параллельны
{
    return ((coordinates[0, 0] == coordinates[1, 0]) && (coordinates[0, 1] != coordinates[1, 1]));
}

bool IsMatch(double[,] coordinates)  //если k1=k2 и b1=b2, то прямые параллельны
{
    return (coordinates[0, 1] == coordinates[1, 1] && (coordinates[0, 1] == coordinates[1, 1]));
}

double[] GetCrossingPoint(double[,] coordinates) //возвращает точку пересечения линейных функций Kx+b
                                                 //coordinates[i, 0] - k, coordinates[i, 1] - b
{
    double[] result = new double[2];
    //при k1!=k2 и b1=b2 точка пересечения будет (0;b)
    if (coordinates[0, 0] != coordinates[1, 0] && coordinates[0, 1] == coordinates[1, 1])
    {
        result[0] = 0;
        result[1] = coordinates[0, 1];
        return result;
    }
    //при k1!=k2 и b1!=b2 точка пересечения будет в координатах x=(b2-b1)/(k1-k2);y=k1x+b1
    result[0] = (coordinates[1, 1] - coordinates[0, 1]) / (coordinates[0, 0] - coordinates[1, 0]);
    result[1] = coordinates[0, 0] * result[0] + coordinates[0, 1];
    return result;
}

PrintMsg("Программа найдёт точку пересечения двух прямых,\n");
PrintMsg("заданных уравнениями y = k1 * x + b1, y = k2 * x + b2;\n");
PrintMsg("значения b1, k1, b2 и k2 задаются пользователем.\n");
double[,] matrix = CreateMatrix(2, 2);   //1. Создаем массив 2х2
GetCoeffs(matrix);              //2. Предлагаем ввести коэффициенты и сохраняем в массив
if (IsParallel(matrix))
{
    PrintMsg("Прямые параллельны!\n");  //3. Проверяем на параллельность
    return;
}
if (IsMatch(matrix))    //4. Проверяем на совпадение
{
    PrintMsg("Прямые совпадают!\n");
    return;
}
double[] result = GetCrossingPoint(matrix);  //5. Вычисляем точку пересечения
PrintMsg("Точка пересечения находится в координатах ("); //6. Выводим результат
PrintArrayReal(result);
PrintMsg(").");