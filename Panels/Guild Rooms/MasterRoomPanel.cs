using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterRoomPanel : GuildRoom 
{
    public override bool HasSpace(Hero _hero)
    {
        if (_hero.job != Jobs.GUILDMASTER)
        {
            return false;
        }

        return base.HasSpace(_hero);
    }

    public override void Action(GameObject _hero)
    {
        base.Action(_hero);
        Health _h = _hero.GetComponent<Health>();
        if (_h)
        {
            _h.Heal(1);
            GameController.instance.CreateHeroPopup(GameController.instance.healPopup, _hero, 1);
        }

        // Increase all exp
        AbilityScores stats = _hero.GetComponent<AbilityScores>();
        stats.IncreaseAllExp(1);
    }

}
