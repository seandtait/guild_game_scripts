using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpGallenFarm : QuestRoom 
{
    private void Start()
    {
        daysLeft = -1;
        permanent = true;
        roomName = "Help Gallen Farm";
        UpdateTitle();
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

    public override void Resolve()
    {
        // Gain 5 gold and 1 rep per hero
        int rep = AssignedHeroes().Count * 1;
        int gold = AssignedHeroes().Count * 5;

        Guild.instance.gallenReputation += rep;
        Guild.instance.gold += gold;

        GameObject gpopup = Instantiate(GameController.instance.goldPopup, this.transform);
        gpopup.GetComponent<Popup>().SetText("+ " + gold + "g");
        gpopup.transform.localPosition = Vector3.zero;

        GameObject rpopup = Instantiate(GameController.instance.repPopup, this.transform);
        rpopup.GetComponent<Popup>().SetText("+ " + rep + " Gallen");
        rpopup.transform.localPosition = Vector3.zero;

        // Add new quest
        GameController.instance.QuestsToAdd.Add(Resources.Load<GameObject>("Quests/Help Gallen Farm"));

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
