using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoboldCave : QuestRoom 
{
    private void Start()
    {
        daysLeft = 7;
        roomName = "Kobold Cave";
        UpdateTitle();
    }

    public override void Action(GameObject _hero)
    {
        base.Action(_hero);


    }

    public override bool CanComplete()
    {
        if (AssignedHeroes().Count <= 0)
        {
            return false;
        }

        int strReq = 2;
        int intReq = 2;

        if (TotalAbilityScore("str") < strReq)
        {
            return false;
        }
        if (TotalAbilityScore("int") < intReq)
        {
            return false;
        }

        return base.CanComplete();
    }



}
