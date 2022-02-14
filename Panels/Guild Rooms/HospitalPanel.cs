using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalPanel : GuildRoom 
{
    public override bool HasSpace(Hero _hero)
    {
        

        return base.HasSpace(_hero);
    }

    public override void Action(GameObject _hero)
    {
        base.Action(_hero);

        // Check the job role is filled
        HospitalJobPanel _j = GetComponentInChildren<HospitalJobPanel>();
        if (!_j.full)
        {
            return;
        }

        Health _h = _hero.GetComponent<Health>();
        if (_h)
        {
            _h.Heal(1);
            GameController.instance.CreateHeroPopup(GameController.instance.healPopup, _hero, 1);
        }
    }




}
