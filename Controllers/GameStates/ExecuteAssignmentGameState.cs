using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteAssignmentGameState : GameState 
{
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(Init());
    }

    IEnumerator Init()
    {
        yield return null;
        GuildRoom[] guildRooms = gc.GuildRoomsParent.GetComponentsInChildren<GuildRoom>();
        foreach (var room in guildRooms)
        {
            for (int i = 0; i < room.slots.Count; i++)
            {
                if (room.slots[i].childCount > 0)
                {
                    GameObject hero = room.slots[i].GetChild(0).gameObject;
                    room.Action(hero);
                }
            }
        }
        gc.ChangeState<ExecuteQuestsGameState>();
    }

    public override void Exit()
    {
        base.Exit();

    }


}
