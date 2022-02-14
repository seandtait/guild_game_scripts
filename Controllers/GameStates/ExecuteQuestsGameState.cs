using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteQuestsGameState : GameState 
{

    public override void Enter()
    {
        base.Enter();
        StartCoroutine(Init());
    }

    IEnumerator Init()
    {
        yield return null;
        List<GameObject> questRooms = QuestLog.instance.quests;
        foreach (var _room in questRooms)
        {
            QuestRoom room = _room.GetComponent<QuestRoom>();
            room.attempted = false;
            if (room.AssignedHeroes().Count > 0)
            {
                room.attempted = true;
                // Perform the Action on all assigned heroes
                foreach (var hero in room.AssignedHeroes())
                {
                    room.Action(hero);
                }
                yield return new WaitForSeconds(room.actionWaitTime);
            }


            // Now the heroes have had a chance to die... re-check

            if (room.AssignedHeroes().Count > 0)
            {
                // Attempting to clear the quest
                if (room.CanComplete())
                {
                    room.Resolve();
                }

                // Now perform success or failure on the quest
                foreach (var hero in room.AssignedHeroes())
                {
                    if (room.resolved)
                    {
                        room.SuccessAction(hero);
                    } else
                    {
                        room.FailAction(hero);
                    }
                }
                yield return new WaitForSeconds(room.resolveWaitTime);
            }

            // If the quest is complete, return the heroes to a barracks, remove the quest
            if (room.attempted)
            {
                GameObject popup;
                if (room.resolved)
                {
                    Debug.Log("resolved");
                    // Completed
                    popup = Instantiate(gc.successPopup, room.transform);
                    popup.transform.localPosition = Vector3.zero;
                } else
                {
                    Debug.Log("failed");
                    // Failed
                    popup = Instantiate(gc.failPopup, room.transform);
                    popup.transform.localPosition = Vector3.zero;
                }

                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));

                if (room.resolved)
                {
                    ReturnHeroesToBarracks(room.AssignedHeroes());
                    QuestLog.instance.CompleteQuest(room.gameObject);
                } else
                {
                    DestroyImmediate(popup);
                }
            }
        }
        gc.ChangeState<NextDayGameState>();
    }

    void ReturnHeroesToBarracks(List<GameObject> _heroes)
    {
        foreach (var hero in _heroes)
        {
            // if guild master, send to guild master room
            if (hero.GetComponent<Hero>().job == Jobs.GUILDMASTER)
            {
                GuildRooms.instance.masterRoom.DropHero(hero);
                continue;
            }

            // Else, regular hero. Send to barracks
            GuildRooms.instance.DropInAnyBarrack(hero);
        }
    }

    

    public override void Exit()
    {
        base.Exit();

    }


}
