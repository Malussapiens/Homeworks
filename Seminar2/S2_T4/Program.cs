// Задача 4: Напишите программу, которая принимает на вход цифру, 
// обозначающую день недели, и проверяет, является ли этот день выходным.

// 6 -> да
// 7 -> да
// 1 -> нет

string GetUserInput(string message) //Принимает ввод от пользователя
{
    Console.Write(message);
    return Console.ReadLine();
}

bool IsNumber(string input) //Проверка, является ли ввод числом
{
    int result;
    return int.TryParse(input, out result);
}

bool IsDayOff(int number)   //Проверка, является ли день выходным
{
    return (number>5 && number<=7);
}

bool Validate(int input)    //Проверка на корректность номера дня недели
{
    return (input>0) && (input<8);
}

void PrintMsg(string message)   //Печатает сообщение в консоли
{
    Console.WriteLine(message);
}

Console.Clear();
PrintMsg("Программа принимает на вход цифру, обозначающую день недели,\nи проверяет, является ли этот день выходным.");
string input = GetUserInput("Введите номер дня недели (Пн=1): ");
string errorMessage = "Введите число от 1 до 7!";

if(IsNumber(input) && Validate(int.Parse(input))) {
    if (IsDayOff(int.Parse(input)))
        {PrintMsg($"{input} -> да");}
    else
    {PrintMsg($"{input} -> нет");}
}
else{PrintMsg(errorMessage);}