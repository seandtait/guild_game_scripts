using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuildRooms : MonoBehaviour
{
    #region SINGLETON
    public static GuildRooms instance;

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

    public GuildRoom masterRoom;
    public GuildRoom barrackL;
    public GuildRoom barrackR;

    public GuildRoom library;
    public GuildRoom fighterHall;

    public List<GuildRoom> AvailableBarracks()
    {
        List<GuildRoom> rooms = new List<GuildRoom>();

        if(barrackL.gameObject.activeSelf) { rooms.Add(barrackL); }
        if(barrackR.gameObject.activeSelf) { rooms.Add(barrackR); }

        return rooms;
    }

    public void DropInAnyBarrack(GameObject _hero)
    {
        foreach (var _b in AvailableBarracks())
        {
            if (_b.HasSpace(_hero.GetComponent<Hero>()))
            {
                _b.DropHero(_hero);
            }
        }
    }

    public void BuildRoom(GuildRoom _room)
    {
        _room.gameObject.SetActive(true);
    }

}
