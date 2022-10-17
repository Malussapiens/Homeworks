// Задача 3: Напишите программу, которая выводит третью цифру заданного числа или 
// сообщает, что третьей цифры нет. Не использовать строки для расчета.

// 645 -> 5
// 78 -> третьей цифры нет
// 326792 -> 6

string GetUserInput(string message) //Получает ввод от пользователя
{
    Console.Write(message);
    return Console.ReadLine();
}

bool IsMoreThanDigits(int[] digitsArray, int numOfDigits)   //Проверяет, что в массиве более заданного числа элементов
{
    return (digitsArray.Length > numOfDigits);
}

bool IsNumber(string input) //Проверка, является ли ввод числом
{
    int result;
    return int.TryParse(input, out result);
}

void PrintMsg(string message)   //Печатает сообщение
{
    Console.WriteLine(message);
}

int[] NumberToDigits(int number)    //преобразуем число в массив цифр
{
    int digit;
    int[] digits = new int[3];
    digits[0] = (int)number % 10;
    int i = 1;
    while (number > 0)
    {
        Array.Resize(ref digits, i + 1);
        number = (int)number / 10;
        digit = (int)number % 10;
        digits[i] = digit;
        i++;
    }
    Array.Resize(ref digits, i - 1);
    Array.Reverse(digits);
    return digits;
}

Console.Clear();
PrintMsg("Программа выводит третью цифру заданного числа или сообщает, что третьей цифры нет.");

string input = GetUserInput("Введите число: ");
int number;

if (!IsNumber(input))
{ PrintMsg("Введите число!"); }
else
{
    if (!int.TryParse(input, out number))
    { PrintMsg("Введите целое число!"); }
    else
    {
        int[] digits = NumberToDigits((int)number);
        if (IsMoreThanDigits(digits, 2))    //проверяем, что в числе более двух разрядов
        { PrintMsg($"Третья цифра числа {number} -> {digits[2]}"); }
        else
        { PrintMsg($"{number} -> Третьей цифры нет"); }
    }
}