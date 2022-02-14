using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BegForHelp : QuestRoom 
{
    private void Start()
    {
        daysLeft = -1;
        roomName = "Beg For Help";
        permanent = true;
        UpdateTitle();
    }

    public override void Resolve()
    {
        GameController.instance.HeroesToAdd.Add(Resources.Load<GameObject>("Heroes/Annie"));

        // Add new quest
        GameController.instance.QuestsToAdd.Add(Resources.Load<GameObject>("Quests/Get Smarter"));
        GameController.instance.QuestsToAdd.Add(Resources.Load<GameObject>("Quests/Get Stronger"));
        GameController.instance.QuestsToAdd.Add(Resources.Load<GameObject>("Quests/Help Gallen Farm"));

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
