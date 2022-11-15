// Задача 1: Пользователь вводит с клавиатуры M чисел.
// Посчитайте, сколько чисел больше 0 ввёл пользователь.
// 0, 7, 8, -2, -2 -> 2
// 1, -7, 567, 89, 223-> 3

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

int[] CreateArray(int length)   //возвращает массив, заполненный пользовательскими числами
{
    int[] array = new int[length];
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = GetUserInput($"Введите {i + 1}-е число");
    }
    return array;
}

void PrintArray(int[] array)    //выводит содержимое массива на экран
{
    foreach (int number in array)
    {
        Console.Write($"{number} ");
    }
}

int PositiveNumsCount(int[] array)  //возвращает количество положительных чисел в массиве
{
    int count = 0;
    foreach (int number in array)
    {
        if (number>0) count++;
    }
    return count;
}

PrintMsg("Программа принимает от пользователя с клавиатуры M чисел и\n");
PrintMsg("подсчитывает сколько чисел больше 0 ввёл пользователь.\n");
int m = GetUserInput("Сколько чисел собираетесь ввести?");  //1. запрашиваем от пользователя число М
if (!Validate(m)) return;
int[] userArray = CreateArray(m);   //2. создаем массив длиной М заполненный пользователем(функция)
PrintMsg("Ваш массив:\n");
PrintArray(userArray);
//3. анализируем массив и подсчитываем число элементов больших нуля и
//5. выводим результат.
PrintMsg($"\nВ данном массиве содержится {PositiveNumsCount(userArray)} положительных чисел.");
