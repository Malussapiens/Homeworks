//Задача 2: Задайте значения M и N. Напишите программу,
//которая найдёт сумму натуральных элементов в промежутке от M до N с помощью рекурсии.
// M = 1; N = 15 -> 120
// M = 4; N = 8 -> 30

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

uint GetSumMtoN(uint m, uint n)
{
    if (n == m)
        return n;
    return n + GetSumMtoN(m, n - 1);
}

Console.Clear();
PrintMsg("Программа находит сумму натуральных элементов в промежутке от M до N с помощью рекурсии.\n");
uint mNumber = GetUserInput("Введите число M");
uint nNumber = GetUserInput("Введите число N");

Console.WriteLine(GetSumMtoN(mNumber, nNumber));