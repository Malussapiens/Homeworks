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

Console.WriteLine(IsEven(8));