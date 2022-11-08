//Задача 1: Напишите цикл, который принимает на вход два числа (A и B) и
//возводит число A в натуральную степень B. Реализовать через функции.

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

int MyPow(int number, int pow)  //Итеративно вычисляет степень числа number (продвинутый метод)
{
    {
        int result = 1;
        while (pow > 0)
        {
            if (pow % 2 != 0)
            {
                result *= number;
                pow--;
            }
            else
            {
                number *= number;
                pow /= 2;
            }
        }
        return result;
    }
}

int MyPowRecursive(int number, int pow) //рекурсивно вычисляет степень числа number (продвинутый метод)
{
    if (pow == 0) return 1;
    if (pow % 2 != 0) return number * MyPowRecursive(number, pow - 1);
    else return MyPowRecursive(number * number, pow / 2);
}

PrintMsg("Программа принимает на вход два числа (A и B) и возводит число A в натуральную степень B.\n");
int number = GetUserInput("Введите число A");
int pow = GetUserInput("Введите число B");
if (Validate(pow)) PrintMsg($"Число {number} в степени {pow} равно {MyPow(number, pow)} (итеративно) {MyPowRecursive(number, pow)} (рекурсивно)");