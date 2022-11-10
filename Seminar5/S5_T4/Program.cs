// Задача 4 (*) При помощи рекурсии вывести последовательность чисел, 
// с заданым количеством этих чисел по принципу:
// Ввожу => 12
// 1 2 2 3 3 3 4 4 4 4 5 5

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
    if (number <= 0)
    {
        PrintMsg("Число должно быть больше нуля!");
        return false;
    }
    return true;
}

string GetRecursiveNumbers(int number)
{
    int sum = 0;
    int j = 0;
    // Базовый случай 
    if (number == 1)
    { PrintMsg("1"); }
    else
    {
        for (int i = 1; sum < number; i++)
        {
            sum += i;
            j = i;
        }
        // Шаг рекурсии / рекурсивное условие
        PrintMsg($"{GetRecursiveNumbers(--number)} {j}");
    }
    return "";
}

Console.Clear();
PrintMsg("Программа выводит последовательность чисел, с заданым количеством этих чисел\n");
int input = GetUserInput("Введите число");
if (Validate(input))
    {GetRecursiveNumbers(input);}

