//Задача 3: Напишите программу вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n.
// m = 3, n = 2 -> A(m,n) = 29

// m = 2, n = 3 -> A(m,n) = 9
// m = 3, n = 2 -> A(m,n) = 29

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

uint Akkerman(uint m, uint n)
{
    if (m == 0)
        return n + 1;
    if (m > 0 && n == 0)
        return Akkerman(m - 1, 1);
    return Akkerman(m - 1, Akkerman(m, n - 1));
}

Console.Clear();
PrintMsg("Программа находит сумму натуральных элементов в промежутке от M до N с помощью рекурсии.\n");
uint mNumber = GetUserInput("Введите число M");
uint nNumber = GetUserInput("Введите число N");
Console.WriteLine(Akkerman(mNumber, nNumber));
