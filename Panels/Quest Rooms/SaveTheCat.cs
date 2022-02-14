using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTheCat : QuestRoom 
{
    private void Start()
    {
        daysLeft = 3;
        roomName = "Save the Cat";
        UpdateTitle();
    }

    public override void Action(GameObject _hero)
    {
        base.Action(_hero);

        Health _h = _hero.GetComponent<Health>();
        if (_h)
        {
            int damage = 3;
            _h.TakeDamage(damage);
            GameController.instance.CreateHeroPopup(GameController.instance.damagePopup, _hero, damage);
        }
    }

    public override void Resolve()
    {
        // Gain 1 gold and 10 rep
        int rep = 10;
        int gold = 1;

        Guild.instance.gallenReputation += rep;
        Guild.instance.gold += gold;

        GameObject gpopup = Instantiate(GameController.instance.goldPopup, this.transform);
        gpopup.GetComponent<Popup>().SetText("+ " + gold + "g");
        gpopup.transform.localPosition = Vector3.zero;

        GameObject rpopup = Instantiate(GameController.instance.repPopup, this.transform);
        rpopup.GetComponent<Popup>().SetText("+ " + rep + " Gallen");
        rpopup.transform.localPosition = Vector3.zero;

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
