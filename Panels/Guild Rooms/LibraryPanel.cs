using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryPanel : GuildRoom 
{

    public override void Action(GameObject _hero)
    {
        base.Action(_hero);

        // Increase int exp
        AbilityScores stats = _hero.GetComponent<AbilityScores>();
        stats.IncreaseExp("int", 1);
    }

}
