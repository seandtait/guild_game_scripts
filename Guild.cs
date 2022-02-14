using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guild : MonoBehaviour
{
    #region SINGLETON
    public static Guild instance;

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

    // Vars
    [HideInInspector]
    public int gold;
    [HideInInspector]
    public List<GameObject> heroRoster = new List<GameObject>();

    // Reputation
    public int gallenReputation = 0;


    // Ref.
    public TMPro.TextMeshProUGUI Gold;

    public GameObject AddHero(GameObject _heroPrefab)
    {
        GameObject hero = Instantiate(_heroPrefab);
        heroRoster.Add(_heroPrefab);
        return hero;
    }

    private void FixedUpdate()
    {
        Gold.text = gold + "g";
    }

    public void KillHero(GameObject _hero)
    {
        _hero.transform.SetParent(GameController.instance.DeadHeroes);
        _hero.transform.localPosition = new Vector3(0, 0, _hero.transform.localPosition.z);
        heroRoster.Remove(_hero);
    }

}
