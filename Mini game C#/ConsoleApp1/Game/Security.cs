using System;

namespace ConsoleApp1.Game;


internal class Security
{
    public void Busted()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Вы арестованы, имеете право хранить молчание");
            Console.ReadLine();
        }
    }

}
