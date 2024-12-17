using System;
using System.Drawing;
using ConsoleApp1._Place;
using ConsoleApp1.Entities;
using System.Numerics;
using System.Reflection.Metadata;

namespace ConsoleApp1.Game;

public class Game
{
    private static Lazy<Security> security = new Lazy<Security>();
    public static void Interaction(ObjBase sender, EventArgs eventArgs)
    {
        Console.Clear();
        if (sender is CashMachine)
        {
            CashInteraction(sender);
        }
        if (sender is Door newDoor)
        {
            Door.DoorInteraction(newDoor);
        }
        if (sender is Spot)
        {
            SpotInteraction(sender);
        }
    }

    private static void SpotInteraction(ObjBase sender)
    {
        Console.WriteLine("Лужа убрана");
        Console.ReadLine();
        sender.visible = false;
    }

   

    private static void CashInteraction(ObjBase sender)
    {
        Console.WriteLine("Деньги посчитаны");
        CashMachine buf = sender as CashMachine;
        buf.IsCalculated = true;
        Console.ReadLine();
    }

    public static void SendSignal(Door sender, EventArgs eventArgs)
    {

    }

    public static void AnsweredOrNo(Door sender, EventArgs eventArgs)
    {
        if (!(sender.IsOpenBySeller))
        {
            Security oXPAHA = security.Value as Security;
            oXPAHA.Busted();
        }
    }


    public static void StartGame()
    {

        Player player = new();
        player.PlayerInter += new Player.InterHandler(Interaction);
        Door door = new Door();
        door.DoorIsOpen += new Door.OpenHandler(SendSignal);
        door.DoorIsOpen += new Door.OpenHandler(AnsweredOrNo);
        CashMachine casheMachine = new CashMachine();
        Spot spot1 = new Spot();
        Spot spot2 = new Spot();
        Spot spot3 = new Spot();
        List<ObjBase> entities = new List<ObjBase>();
        entities.Add(player);
        entities.Add(door);
        entities.Add(casheMachine);
        entities.Add(new Spot());
        entities.Add(spot2);
        entities.Add(spot3);

        while (true)
        {
            Console.Clear();
            Place.Show(entities);
            Tasks.TaskList(entities);
            player.Move();
            player.interaction(entities);
        }



    }
    //static void EndGame()
    //{
    //    player.PlayerInter -= new Player.InterHandler(inter);
    //    Game.DoorIsOpen -= new Game.OpenHandler(SendSignal);
    //    Game.DoorIsOpen += new Game.OpenHandler(AnsweredOrNo);
    //}
}

