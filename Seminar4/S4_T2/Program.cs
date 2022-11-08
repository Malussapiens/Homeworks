//Задача 2: Напишите программу, которая принимает на вход число и
// выдаёт сумму цифр в числе. Реализовать через функции.

void PrintMsg(string message)   //выводим сообщение на экран
{
    Console.Write(message);
}

int GetUserInput(string message) //Принимает ввод от пользователя
{
    PrintMsg($"{message}:>");
    return int.Parse(Console.ReadLine());
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

int GetLastDigit(int number)    //Возвращает первый разряд числа (единицы)
{
    return number % 10;
}

int RemoveLastDigit(int number) //Убирает первый разряд числа (единицы)
{
    return number / 10;
}

Console.Clear();
PrintMsg("Программа принимает на вход число и выдаёт сумму цифр в числе.\n");
int number = GetUserInput("Введите целое число");
if (Validate(number))
{
    int userInput = number;
    int result = 0;
    while (number > 0)
    {
        result += GetLastDigit(number);
        number = RemoveLastDigit(number);
    }

    PrintMsg($"Сумма цифр числа {userInput} равна {result}");
}