using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuildRoom : DropPanel 
{
    public override bool HasSpace(Hero _hero)
    {
        return base.HasSpace(_hero);
    }

    public override void Action(GameObject _hero)
    {
        base.Action(_hero);

    }

}
