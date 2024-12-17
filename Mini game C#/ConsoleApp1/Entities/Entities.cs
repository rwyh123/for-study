using System.Drawing;

namespace ConsoleApp1.Entities;

public abstract class ObjBase
{
    public Point position;
    public char sprite;
    public bool visible { get; set; } = true; //ерунда переделоать просто убрать лужу из спика объектов отрисовки
}
