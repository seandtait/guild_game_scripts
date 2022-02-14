using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestRoom : DropPanel 
{
    [HideInInspector]
    public int daysLeft;
    [HideInInspector]
    public bool permanent;
    [HideInInspector]
    public string roomName;

    // Timing
    public float actionWaitTime = 0f;
    public float resolveWaitTime = 0f;

    public bool attempted = false;
    public bool resolved = false;

    public void UpdateTitle()
    {
        if (permanent)
        {
            roomTitle.text = roomName;
        } else
        {
            roomTitle.text = roomName + " (" + daysLeft.ToString() + " Days Left)";
        }
    }

    public override void Action(GameObject _hero)
    {
        // This function runs on each hero.
        // Not all quests will have an action to perform on the hero/es
        base.Action(_hero);
    }

    public virtual void FailAction(GameObject _hero)
    {

    }

    public virtual void SuccessAction(GameObject _hero)
    {

    }

    public virtual void Resolve()
    {
        resolved = true;
    }

    public virtual bool CanComplete()
    {
        return false;
    }

    public override bool HasSpace(Hero _hero)
    {
        return base.HasSpace(_hero);

    }

    

}
