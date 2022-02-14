using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracksLPanel : GuildRoom 
{
    public override void Action(GameObject _hero)
    {
        base.Action(_hero);
        Health _h = _hero.GetComponent<Health>();
        if (_h)
        {
            _h.Heal(1);
            GameController.instance.CreateHeroPopup(GameController.instance.healPopup, _hero, 1);
        }
    }


}
