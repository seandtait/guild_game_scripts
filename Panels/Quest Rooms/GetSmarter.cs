using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSmarter : QuestRoom 
{
    private void Start()
    {
        daysLeft = -1;
        roomName = "Get Smarter";
        permanent = true;
        UpdateTitle();
    }

    public override void Resolve()
    {
        // Take cost
        Guild.instance.gold -= 55;
        // Build room
        GuildRooms.instance.BuildRoom(GuildRooms.instance.library);
        // Add new quest
        GameController.instance.QuestsToAdd.Add(Resources.Load<GameObject>("Quests/An Inquisitive Mind"));

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
        if (Guild.instance.gold < 55)
        {
            return false;
        }

        return true;
    }

}
