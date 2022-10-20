// Задача 2
// Напишите программу, которая принимает на вход координаты двух точек и 
// находит расстояние между ними в 3D пространстве.
// A (3,6,8); B (2,1,-7), -> 15.84
// A (7,-5, 0); B (1,-1,9) -> 11.53

void PrintMsg(string message)   //выводим сообщение на экран
{
    Console.Write(message);
}

int GetUserInput(string message) //Принимает ввод от пользователя
{
    PrintMsg($"{message}:>");
    return int.Parse(Console.ReadLine());
}

int[] GetCoordinates(string pointName)   //Получаем координаты x, y, z от пользователя
{
    int[] coordinates = new int[3];
    PrintMsg($"Введите координаты точки {pointName}:\n");
    coordinates[0] = GetUserInput($"Введите {pointName}(x)");
    coordinates[1] = GetUserInput($"Введите {pointName}(y)");
    coordinates[2] = GetUserInput($"Введите {pointName}(z)");
    return coordinates;
}

double GetDistance(int[] startPoint, int[] endPoint) //Вычисляем расстояние между точками в осях X, Y
{
    double distance = 0;
    for (int i = 0; i < 3; i++)
    {
        distance = distance + Math.Pow((endPoint[i] - startPoint[i]), 2);
    }
    return Math.Sqrt(distance);     //L(AB)=SQRT((x2-x1)^2+(y2-y1)^2+(z2-z1)^2)
}

int[] a = new int[3];
int[] b = new int[3];
Console.Clear();
PrintMsg("Программа принимает на вход координаты двух точек и\nнаходит расстояние между ними в 3D пространстве.\n");
a = GetCoordinates("A");
b = GetCoordinates("B");
double distance=GetDistance(a,b);
PrintMsg($"Расстояние между точками равно {distance:f2} \n");  //выводим расстояние между точками. :f2 - усекает вывод до 2-х знаков после запятой