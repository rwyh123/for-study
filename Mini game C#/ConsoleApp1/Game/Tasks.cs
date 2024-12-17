using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Entities;

namespace ConsoleApp1.Game;

internal class Tasks
{
    public static char CMstate = 'x';
    public static char Dstate = 'x';
    public static char Sstate = 'v';
    public static void TaskList(List<ObjBase> ent)
    {
        foreach (var item in ent)
        {
            if (item is CashMachine)
            {
                CashMachine machine = item as CashMachine;
                if (machine.IsCalculated)
                {
                    CMstate = 'v';
                }
            }
            if (item is Door newDoor)
            {
                Door door = item as Door;
                if (door.IsOpen)
                {
                    Dstate = 'v';
                }
            }
            if (item is Spot)
            {
                Spot spot = item as Spot;
                if (spot.visible)
                {
                    Sstate = 'x';
                }
                else { Sstate = 'v'; }
            }
        }
        Console.WriteLine("Помыть пол: {0}", Sstate);
        Console.WriteLine("Поcчитать деньги: {0}", CMstate);
        Console.WriteLine("Открыть двурь: {0}", Dstate);
    }
}
