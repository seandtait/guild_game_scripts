using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LudorForest : QuestRoom 
{
    private void Start()
    {
        daysLeft = 4;
        roomName = "Ludor Forest";
        UpdateTitle();
    }

    public override void Action(GameObject _hero)
    {
        base.Action(_hero);


    }

    public override bool HasSpace(Hero _hero)
    {
        return base.HasSpace(_hero);

    }


}
