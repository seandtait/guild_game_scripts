using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructABarracks : QuestRoom 
{
    private void Start()
    {
        daysLeft = -1;
        roomName = "Construct A Barracks";
        permanent = true;
        UpdateTitle();
    }

    public override void Resolve()
    {
        // Take cost
        Guild.instance.gold -= 50;
        // Build room
        GuildRooms.instance.BuildRoom(GuildRooms.instance.barrackL);
        // Add new quest
        GameController.instance.QuestsToAdd.Add(Resources.Load<GameObject>("Quests/Beg For Help"));

        base.Resolve();
    }



    public override bool CanComplete()
    {
        // Check there is at least one hero
        if (AssignedHeroes().Count <= 0)
        {
            return false;
        }

        // Check they can pay the gold fee
        if (Guild.instance.gold < 50)
        {
            return false;
        }

        return true;
    }

}
