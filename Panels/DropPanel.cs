using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DropPanel : MonoBehaviour
{
    // Public
    public TMPro.TextMeshPro roomTitle;
    public GameObject outline;
    public List<Transform> slots;

    // Private
    SpriteRenderer sr;
    public bool allowDrop = false;

    public bool full = false;

    public int TotalAbilityScore(string _stat)
    {
        int score = 0;
        foreach (var hero in AssignedHeroes())
        {
            score += hero.GetComponent<AbilityScores>().GetActual(_stat);
        }
        return score;
    }

    public List<GameObject> AssignedHeroes()
    {
        List<GameObject> heroes = new List<GameObject>();
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].childCount > 0)
            {
                heroes.Add(slots[i].GetChild(0).gameObject);
            }
        }
        return heroes;
    }

    public virtual bool HasSpace(Hero _hero)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].childCount <= 0)
            {
                return true;
            }
        }
        return false;
    }

    public void DropHero(GameObject hero)
    {
        bool placed = false;
        for (int i = 0; i < slots.Count; i++)
        {
            if (!placed && slots[i].childCount <= 0)
            {
                hero.transform.SetParent(slots[i].transform);
                hero.transform.localPosition = new Vector3(0, 0, -5);
                placed = true;
            }
        }
        TallyFilled();
    }

    void TallyFilled()
    {
        int tally = 0;
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].childCount > 0)
            {
                tally += 1;
            }
        }
        full = tally == slots.Count;
    }

    public void Rearrange()
    {
        bool movedSomething = false;
        do
        {
            movedSomething = false;
            for (int i = 0; i < slots.Count - 1; i++)
            {
                if (slots[i + 1].childCount >= 1 && slots[i].childCount <= 0)
                {
                    // Move to the new parent
                    GameObject hero = slots[i + 1].GetChild(0).gameObject;
                    hero.transform.SetParent(slots[i].transform);
                    hero.transform.localPosition = new Vector3(0, 0, -5);
                    movedSomething = true;
                }
            }
        } while (movedSomething);
        TallyFilled();
    }

    private void OnMouseEnter()
    {
        if (GameController.instance.DragObject)
        {
            DropPanel previousPanel = GameController.instance.DragObject.GetComponent<Hero>().GetComponentInParent<DropPanel>();
            if (allowDrop && GameController.instance.DragObject && previousPanel == this)
            {
                outline.SetActive(false);
                GameController.instance.ActiveDropPanel = null;
                return;
            }
        }

        if (allowDrop && GameController.instance.DragObject && HasSpace(GameController.instance.DragObject.GetComponent<Hero>()))
        {
            outline.GetComponent<SpriteRenderer>().color = Color.green;
            outline.SetActive(true);
            GameController.instance.ActiveDropPanel = gameObject;
        } else if(allowDrop && GameController.instance.DragObject && !HasSpace(GameController.instance.DragObject.GetComponent<Hero>())) {
            outline.GetComponent<SpriteRenderer>().color = Color.red;
            outline.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        outline.SetActive(false);
        GameController.instance.ActiveDropPanel = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        allowDrop = GameController.instance.currentState.GetType() == typeof(AssignmentGameState);
    }

    public virtual void Action(GameObject _hero)
    {
        Debug.Log(this.GetType() + " is acting");

    }

}
