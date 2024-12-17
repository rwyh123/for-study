using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Entities;

namespace ConsoleApp1._Place;

internal class Place
{
    public static void Show(List<ObjBase> ent)
    {
        //bool DrawOrNO = true;
        //int[,] Room = new int[3, 3];
        for (int i = 0; i < 14; i++)
        {

            for (int j = 0; j < 15; j++)
            {
                //DrawOrNO = true;
                foreach (ObjBase a in ent)
                {
                    if (a.position.X == j && a.position.Y == i)
                    {
                        if (a is Spot && a.visible)
                        {
                            Console.Write(a.sprite);
                            j++;
                            //DrawOrNO = false;
                            break;
                        }
                        else if (!(a is Spot))
                        {
                            Console.Write(a.sprite);
                            j++;
                            //DrawOrNO = false;
                            break;
                        }
                    }
                }
                if (j != 15)
                    Console.Write('#');
            }
            Console.WriteLine();
        }
    }
}
