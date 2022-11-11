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

void PrintTriangleSequence2(int number) //Итеративно выводит треугольную последовательность
{
    for (int n = 1; n <= number; n++)   //циклом будем перебирать членов последовательности 
                                        //до заданного числа
    {
        int triangle = 0;    //здесь будем сохранять n-e треугольное число
        int res = 1;  //здесь будем сохранять число для вывода
        for (int count = 1; triangle < n; count++)  //циклом вычисляем число для вывода (count раз, но 
                                                    //не более n) по закону прогрессии треугольных чисел 
        {
            res = count;
            triangle += count;
        }
        Console.Write(res + " ");
    }
}
string PrintTriangleSequence(int number)    //Рекурсивно выводит треугольную последовательность.
{

    // Базовый случай 
    if (number == 1)
    { PrintMsg($"{1}"); }
    else
    {
        int triangle = 0;
        int res = 0;
        for (int count = 1; triangle < number; count++)
        {
            triangle += count;
            res = count;
        }
        // Шаг рекурсии / рекурсивное условие
        PrintMsg($"{PrintTriangleSequence(--number)} {res}");
    }
    return "";
}

Console.Clear();
PrintMsg("Программа выводит последовательность чисел, с заданым количеством этих чисел\n");
int input = GetUserInput("Введите число");
if (Validate(input))
{ PrintTriangleSequence(input); }

