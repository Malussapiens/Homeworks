// Задача 2: Задайте одномерный массив, заполненный случайными числами. 
// Найдите сумму элементов, стоящих на нечётных позициях.
// [3, 7, 23, 12] -> 19
// [-4, -6, 89, 6] -> 0

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

bool Validate(int number) //проверяем, что число больше нуля
{
    if (number < 0)
    {
        PrintMsg("Число должно быть больше нуля!");
        return false;
    }
    return true;
}

int[] GetRandomArray(int minRandom, int maxRandom, int arrSize) //Возвращает массив размерностью arrSize, заполненный случайными числами из диапазона [minRandom; maxRandom]
{
    int[] arr = new int[arrSize];

    for (int i = 0; i < arrSize; i++)
    {
        arr[i] = new Random().Next(minRandom, maxRandom + 1);
    }
    return arr;
}

int[] CreateRandomArray()
{
    int arrSize, minRandom, maxRandom;
    int[] arr = new int[0];
    arrSize = GetUserInput("Введите размерность массива (0/ENTER для восьми элементов)");
    if (Validate(arrSize))
    {
        minRandom = GetUserInput("Введите нижнюю границу диапазона (включительно)");
        maxRandom = GetUserInput("Введите верхнюю границу диапазона (включительно)");
        if (minRandom < maxRandom)
        {
            if (arrSize == 0) arrSize = 8;
            arr = GetRandomArray(minRandom, maxRandom, arrSize);
            PrintMsg("Ваш массив: ");
            PrintArray(arr);
        }
        else
        {
            PrintMsg("Нижняя граница должна быть меньше верхней!");
        }
    }
    return arr;
}

void PrintArray(int[] array)
{
    foreach (int number in array)
    {
        Console.Write($"{number} ");
    }
}

bool IsEven(int number)
{
    return (number % 2 == 0);
}

int OddPositionSum(int[] array)
{
    int sum = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (!IsEven(i))
        { sum += array[i]; }
    }
    return sum;
}


Console.Clear();
PrintMsg("Программа находит сумму элементов, стоящих на нечётных позициях в массиве.\n");
int[] arr = CreateRandomArray();
if (arr.Length > 0)
    PrintMsg($"\n Сумма нечетных элементов: {OddPositionSum(arr)}");