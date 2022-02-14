using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AWashedUpWarrior : QuestRoom 
{
    private void Start()
    {
        daysLeft = -1;
        roomName = "A Washed Up Warrior";
        permanent = true;
        UpdateTitle();
    }

    public override void Resolve()
    {
        GameController.instance.HeroesToAdd.Add(Resources.Load<GameObject>("Heroes/Landis"));

        // Add new quest
        //GameController.instance.QuestsToAdd.Add(Resources.Load<GameObject>("Quests/Get Smarter"));


        base.Resolve();
    }



    public override bool CanComplete()
    {
        // Check there is at least one hero
        if (AssignedHeroes().Count <= 0)
        {
            return false;
        }

        return true;
    }

}
