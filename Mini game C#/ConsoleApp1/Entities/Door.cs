using System.Drawing;

namespace ConsoleApp1.Entities;

public class Door : ObjBase
{
    public delegate void OpenHandler(Door sender, EventArgs eventArgs);
    public event OpenHandler DoorIsOpen;
    public bool IsOpen;
    public bool IsOpenBySeller;

    public Door()
    {
        IsOpen = false;
        position = new Point(14, 5);
        sprite = '8';
    }

    public static void DoorInteraction(Door newDoor)
    {
        if (newDoor.IsOpen)
        {
            Console.WriteLine("Дверь уже открыта");
            Console.ReadLine();
        }
        else
        {
            Console.Write("Введите код от замка: ");
            string pass;
            pass = Console.ReadLine();
            OpenDoor(newDoor, pass);
        }
    }

    private static void OpenDoor(Door newDoor, string pass)
    {
        string password = "1234";
        newDoor.IsOpen = true;
        if (pass == password)
        {
            newDoor.IsOpenBySeller = true; 
        }
        else
        {
            newDoor.IsOpenBySeller = false;
        }
        Console.WriteLine($"Дверь открыта {(newDoor.IsOpenBySeller ? "Хозяином" : "Вором")}");
        Console.ReadLine();
        newDoor.DoorIsOpen.Invoke(newDoor, new EventArgs());
    }
}
