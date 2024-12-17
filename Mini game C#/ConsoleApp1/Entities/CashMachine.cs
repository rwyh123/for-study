using System.Drawing;

namespace ConsoleApp1.Entities;

internal class CashMachine : ObjBase
{
    public bool IsCalculated { get; set;}
    public CashMachine()
    {
        position = new Point(5, 5);
        sprite = '$';
        IsCalculated = false;
    }
}
