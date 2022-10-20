// Задача 1
// Напишите программу, которая принимает на вход пятизначное число и 
// проверяет, является ли оно палиндромом. Без использования строк
// 14212 -> нет
// 12821 -> да
// 23432 -> да

void PrintMsg(string message)   //выводим сообщение на экран
{
    Console.Write(message);
}

int GetUserInput(string message) //Принимает ввод от пользователя
{
    PrintMsg($"{message}:>");
    return int.Parse(Console.ReadLine());
}

bool DigitsInNumber(int numberOfDigits, int number)    //Определяет, сколько разрядов в числе
{
    int testExpression = number / (int)Math.Pow(10, numberOfDigits - 1);
    return (testExpression > 0 && testExpression < 10);
}

int GetReverseNumber(int number)    //Возвращает "перевернутое" число
{
    int reverseNumber = 0;
    while (number / 10 > 0)
    {
        reverseNumber = reverseNumber * 10 + number % 10;
        number /= 10;
    }
    return reverseNumber * 10 + number;
}

Console.Clear();
PrintMsg("Программа принимает на вход пятизначное число и проверяет, является ли оно палиндромом.");
int number = GetUserInput("\nВведите пятизначное число"); //получаем число от пользователя
if (DigitsInNumber(5, number))     //если в числе 5 разрядов...
{
    if (number == GetReverseNumber(number)) { PrintMsg($"{number} -> Да"); }    //если число совпадает с "перевернутым" числом печатаем "Да"
    else { PrintMsg($"{number} -> Нет"); }    //иначе - "нет"
}
else { PrintMsg("Введите пятизначное число!"); }    //иначе...