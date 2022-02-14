using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : StateMachine 
{
    #region Singleton
    public static GameController instance;

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

    public GameObject DragObject;
    public GameObject ActiveDropPanel;

    public Transform GuildRoomsParent;
    public Transform QuestRoomsParent;
    public Transform CompletedQuests;
    public Transform DeadHeroes;
    public GameObject DoneButton;
    public TMPro.TextMeshProUGUI DaysLeft;

    public GameObject healPopup;
    public GameObject damagePopup;
    public GameObject successPopup;
    public GameObject failPopup;
    public GameObject goldPopup;
    public GameObject repPopup;

    public int daysLeft = 365;

    public List<GameObject> QuestsToAdd = new List<GameObject>();
    public List<GameObject> HeroesToAdd = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        ChangeState<InitGameState>();
    }

    public void Go()
    {
        ChangeState<ExecuteAssignmentGameState>();
    }

    public void CreateHeroPopup(GameObject popup, GameObject hero, int value)
    {
        GameObject p = Instantiate(popup, hero.transform);
        p.GetComponent<Popup>().Init(value);
    }


}
