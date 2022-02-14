using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGameState : GameState
{
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(Init());
    }

    IEnumerator Init()
    {
        yield return null;

        // Initialise guild money
        Guild.instance.gold = 100;

        // Add starter heroes
        GameObject guildMaster = Guild.instance.AddHero(Resources.Load<GameObject>("Heroes/Maldo"));
        GuildRooms.instance.masterRoom.DropHero(guildMaster);

        // Add initial quests to the list
        QuestLog.instance.AddQuest(Resources.Load<GameObject>("Quests/Construct A Barracks"));



        gc.ChangeState<AssignmentGameState>();
    }

    public override void Exit()
    {
        base.Exit();

    }

}
