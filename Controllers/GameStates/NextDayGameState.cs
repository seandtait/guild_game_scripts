using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDayGameState : GameState 
{
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(Init());
    }

    IEnumerator Init()
    {
        yield return null;

        // Remove quests queued to be removed
        foreach (var _quest in QuestLog.instance.questsToRemove)
        {
            QuestLog.instance.quests.Remove(_quest);
        }
        QuestLog.instance.questsToRemove.Clear();

        // Reduce the day count
        gc.daysLeft -= 1;
        gc.DaysLeft.text = gc.daysLeft.ToString() + " Days Left";

        QuestRoom[] questRooms = gc.QuestRoomsParent.GetComponentsInChildren<QuestRoom>();
        foreach (var room in questRooms)
        {
            room.daysLeft -= 1;
            room.UpdateTitle();
        }

        // Remove expired quests
        List<QuestRoom> expiredRooms = new List<QuestRoom>();
        foreach (var room in questRooms)
        {
            if (!room.permanent && room.daysLeft < 0)
            {
                expiredRooms.Add(room);
            }
        }
        foreach (var _expiredRoom in expiredRooms)
        {
            // TODO: Maybe a failed quests log?
            QuestLog.instance.quests.Remove(_expiredRoom.gameObject);
            DestroyImmediate(_expiredRoom.gameObject);
        }

        // Add the new quests now, after the day is done
        foreach (var newQuest in gc.QuestsToAdd)
        {
            QuestLog.instance.AddQuest(newQuest);
        }
        gc.QuestsToAdd.Clear();

        // Add new quests that appear on specific days
        foreach (var _daySpecificQuest in QuestLog.instance.AddQuestOnDay(GameController.instance.daysLeft))
        {
            QuestLog.instance.AddQuest(_daySpecificQuest);
        }
        QuestLog.instance.Rearrange();

        // Add the new heroes now,
        foreach (var newHero in gc.HeroesToAdd)
        {
            GameObject hero = Guild.instance.AddHero(newHero);
            GuildRooms.instance.DropInAnyBarrack(hero);
        }
        gc.HeroesToAdd.Clear();

        

        gc.ChangeState<AssignmentGameState>();
    }

    public override void Exit()
    {
        base.Exit();

    }


}
