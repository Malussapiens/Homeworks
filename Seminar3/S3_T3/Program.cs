// Напишите программу, которая принимает на вход число (N) и
// выдаёт таблицу кубов чисел от 1 до N.
// 3 -> 1, 8, 27
// 5 -> 1, 8, 27, 64, 125

void PrintMsg(string message)   //выводим сообщение на экран
{
    Console.Write(message);
}

void PrintCubicTable(int numberN)
{
    for (int i = 1; i < numberN; i++)
    {
        PrintMsg($"{Math.Pow(i, 3)}, ");
    }
    PrintMsg($"{Math.Pow(numberN, 3)}");
}

int GetUserInput(string message) //Принимает ввод от пользователя
{
    PrintMsg($"{message}:>");
    return int.Parse(Console.ReadLine());
}

bool Validate(int numberN)
{
    return numberN > 0;
}


//Инициализация
Console.Clear(); //Очищаем экран
PrintMsg("Программа принимает на вход число (N) и \nвыдаёт таблицу кубов чисел от 1 до N.");    //Приветствуем пользователя
int numberN = GetUserInput("\nВведите натуральное число");  //получаем ввод от пользователя
//Валидация
if (Validate(numberN))  //если ввод верный
{
    //Вычисления
    PrintMsg($"{numberN} -> ");
    PrintCubicTable(numberN); //печатаем таблицу кубов
}
else PrintMsg("Число должно быть больше нуля!");    //иначе - выдаем сообщение об ошибке