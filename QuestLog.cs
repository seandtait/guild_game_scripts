using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLog : MonoBehaviour 
{
    #region SINGLETON
    public static QuestLog instance;

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(this);
        } else
        {
            instance = this;
        }
    }
#endregion

    public List<GameObject> quests = new List<GameObject>();
    public int currentOffset = 0;
    int visibleQuests = 4;
    float max = 0;

    float startingQuestY = 8f;

    public List<GameObject> questsToRemove = new List<GameObject>();


    public void Next()
    {
        currentOffset += 1;
        ValidateOffset();
        transform.position = new Vector3(transform.position.x, currentOffset, transform.position.z);
    }

    public void Previous()
    {
        currentOffset -= 1;
        ValidateOffset();
        transform.position = new Vector3(transform.position.x, currentOffset, transform.position.z);
    }

    void ValidateOffset()
    {
        if (currentOffset < 0)
        {
            currentOffset = 0;
        }
        if (currentOffset > max)
        {
            currentOffset = (int)max;
        }
    }

    public void AddQuest(GameObject _questPrefab)
    {
        GameObject quest = Instantiate(_questPrefab);
        quests.Insert(0, quest);
        quest.transform.SetParent(transform);
        Rearrange();
    }

    public void Rearrange()
    {
        for (int i = 0; i < quests.Count; i++)
        {
            float y = startingQuestY - (i * 5.5f);
            quests[i].transform.localPosition = new Vector3(0, y, -1);
        }
    }

    private void Update()
    {
        int multiplier = 0;
        if (quests.Count - 4 > 0)
        {
            multiplier = quests.Count - 4;
        }
        max = multiplier * 5.5f;

        if (Input.mouseScrollDelta.y > 0)
        {
            Next();
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            Previous();
        }
    }

    public void CompleteQuest(GameObject _quest)
    {
        _quest.transform.SetParent(GameController.instance.CompletedQuests);
        _quest.transform.localPosition = new Vector3(0, 0, 0);
        QuestLog.instance.questsToRemove.Add(_quest);
    }

    public void ExpireQuest(GameObject _quest)
    {
        QuestLog.instance.quests.Remove(_quest);
        DestroyImmediate(_quest);
    }

    public List<GameObject> AddQuestOnDay(int daysLeft)
    {
        if (daysLeft == 360)
        {
            return new List<GameObject>() {
                Resources.Load<GameObject>("Quests/Save The Cat")
            };
        }
        return new List<GameObject>() { };
    }

}
