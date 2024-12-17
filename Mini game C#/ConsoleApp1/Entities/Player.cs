using System.Drawing;

namespace ConsoleApp1.Entities;

internal class Player : ObjBase
{
    public delegate void InterHandler(ObjBase sender, EventArgs eventArgs);
    public event InterHandler PlayerInter;

    public void interaction(List<ObjBase> entit)
    {
        foreach (ObjBase ent in entit)
        {
            if ((ent.position.X - this.position.X == 1 && ent.position.Y == this.position.Y || ent.position.X - this.position.X == -1 && ent.position.Y == this.position.Y) ||
                (ent.position.Y - this.position.Y == 1 && ent.position.X == this.position.X || ent.position.Y - this.position.Y == -1 && ent.position.X == this.position.X))
            {
                ConsoleKey a = Console.ReadKey().Key;
                switch (a)
                {
                    case ConsoleKey.Enter:
                        if (PlayerInter != null)
                        {
                            PlayerInter(ent, new EventArgs());
                        }
                        break;
                }
            }
        }
    }
    public void Move()
    {
        ConsoleKey a = Console.ReadKey().Key;
        switch (a)
        {
            case ConsoleKey.UpArrow:
                if (position.Y < 1)
                {
                    break;
                }
                position.Y -= 1;
                break;
            case ConsoleKey.LeftArrow:
                if (position.X < 1)
                {
                    break;
                }
                position.X -= 1;
                break;
            case ConsoleKey.DownArrow:
                if (position.Y > 12)
                {
                    break;
                }
                position.Y += 1;
                break;
            case ConsoleKey.RightArrow:
                if (position.X > 13)
                {
                    break;
                }
                position.X += 1;
                break;

        }
    }
    public Player()
    {
        position = new Point(0, 0);
        sprite = '0';
    }
}
