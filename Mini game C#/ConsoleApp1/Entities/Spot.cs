using System.Drawing;

namespace ConsoleApp1.Entities;

internal class Spot : ObjBase
{

    Random rnd = new Random();
    public Spot()
    {
        position = new Point(rnd.Next(0, 9), rnd.Next(0, 9));
        sprite = '*';
    }
}
