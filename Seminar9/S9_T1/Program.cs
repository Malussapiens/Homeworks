// Задача 1: Задайте значения M и N. Напишите программу, 
//которая выведет все чётные натуральные числа в промежутке от M до N с помощью рекурсии.
// M = 1; N = 5 -> "2, 4"
// M = 4; N = 8 -> "4, 6, 8"

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

void PrintEvenNumbers(uint start, uint end)
{
    if (end % 2 != 0)
        end--;
    if (start > end)
        return;
    PrintEvenNumbers(start, end - 2);
    Console.WriteLine(end);
}


Console.Clear();
PrintMsg("Программа выводит все чётные натуральные числа в промежутке от M до N с помощью рекурсии.\n");
uint mNumber = GetUserInput("Введите число M");
uint nNumber = GetUserInput("Введите число N");
PrintEvenNumbers(mNumber, nNumber);