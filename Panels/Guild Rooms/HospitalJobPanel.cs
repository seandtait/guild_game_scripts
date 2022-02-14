using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalJobPanel : GuildRoom 
{
    

    public override bool HasSpace(Hero _hero)
    {
        Cleric _c = _hero.GetComponent<Cleric>();
        bool isValidClass = false;

        if (_c)
        {
            isValidClass = true;
        }

        if (isValidClass == false)
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
            int damage = 1;
            _h.TakeDamage(damage);
            GameController.instance.CreateHeroPopup(GameController.instance.damagePopup, _hero, damage);
        }
    }




}
